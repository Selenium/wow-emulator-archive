using System;
using System.IO;
using System.Xml;
using System.Data;

namespace Maelstrom
{
	public sealed class ConfigFile
	{
		private string m_Filename;
		private ConfigEngine m_Engine;
		private DataSet m_Data;

		public string Filename
		{
			get {return m_Filename;}
		}

		#region Indexed by Group

		public ConfigElement[] this[string Group]
		{
			get
			{
				lock(m_Data)
				{
					DataTable GroupTable = m_Data.Tables[Group];
					if (GroupTable == null)
					{
						throw new Exception("InvalidGroupException");
					}

					ConfigElement[] Result = new ConfigElement[GroupTable.Rows.Count];
					for(int i=0;i<=GroupTable.Rows.Count-1;i++)
					{
						Result[i] = new ConfigElement(this,GroupTable.Rows[i]);
					}

					return Result;
				}
			}
		}

		#endregion
		#region Indexed by Integer

		public ConfigElement this[string Group, ulong Key]
		{
			get
			{
				return this[Group,Key.ToString()];
			}
		}

		#endregion
		#region Indexed by String

		public ConfigElement this[string Group, string Key]
		{
			get
			{
				lock(m_Data)
				{
					if (Utilities.IsHexNumber(Key))
					{
						Key = Utilities.ToNumericValue(Key).ToString();
					}

					DataTable GroupTable = m_Data.Tables[Group];
					if (GroupTable == null)
					{
						throw new Exception("InvalidGroupException");
					}

					DataRow ElementRow;

					//Determine whether the table has a primary key or not (for faster lookups)
					if (GroupTable.PrimaryKey.Length > 0)
					{
						//Search using the primary key.
						ElementRow = GroupTable.Rows.Find(Key);
					}
					else
					{
						//Search using a normal select.
						DataRow[] Rows = GroupTable.Select("id='"+Key+"'");
						if (Rows.Length != 1)
						{
							return null;
						}

						ElementRow = Rows[0];
					}
				
					if (ElementRow != null)
					{
						return new ConfigElement(this,ElementRow);
					}
					else
					{
						return null;
					}
				}
			}
		}

		#endregion
		#region Indexed by Integer of Specific Property

		public ConfigElement[] this[string Group, string PropertyName, ulong Key]
		{
			get
			{
				return this[Group,PropertyName,Key.ToString()];
			}
		}

		#endregion
		#region Indexed by String of Specific Property

		public ConfigElement[] this[string Group, string PropertyName, string Key]
		{
			get
			{
				lock(m_Data)
				{
					if (Utilities.IsHexNumber(Key))
					{
						Key = Utilities.ToNumericValue(Key).ToString();
					}

					DataTable GroupTable = m_Data.Tables[Group];
					DataRow[] Rows = GroupTable.Select(PropertyName+"='"+Key+"'");

					ConfigElement[] Result = new ConfigElement[Rows.Length];

					for(int i=0;i<=Rows.Length-1;i++)
					{
						Result[i] = new ConfigElement(this,Rows[i]);
					}

					return Result;
				}
			}
		}

		#endregion
		#region Data Loading Methods

		#region ConvertNumericFields

		private void ConvertNumericFields()
		{
			foreach(DataTable Table in m_Data.Tables)
			{
				foreach(DataRow Row in Table.Rows)
				{
					foreach(DataColumn Column in Table.Columns)
					{
						if (Column.DataType == typeof(string))
						{
							//It's a string column, so we have to check this row's value to see if
							//it's numeric in nature. If it is then we convert it to its integer
							//version (primarily used from converting hex notation - 0x0123456789ABDCEF 
							//to searchable integer notation).

							object Value = Row[Column];
							if (Value != DBNull.Value)
							{
								if (Utilities.IsHexNumber((string)Value) || Utilities.IsRealNumber((string)Value) ||
									Utilities.IsWholeNumber((string)Value))
								{
									Row[Column] = Utilities.ToNumericValue((string)Value).ToString();
								}
							}
						}
					}
				}
			}
		}

		#endregion
		#region LoadDataFromDBC

		private void LoadDataFromDBC(string Filename)
		{
			FileInfo DBCInfo = new FileInfo(Filename);

			ConfigFile DBCLayout = m_Engine.LoadFile(@"data\dbc_layouts.xml");
			ConfigElement LayoutElement = DBCLayout["layout",DBCInfo.Name];

			if (LayoutElement == null)
			{
				return;
			}

			DataTable DBCTable = m_Data.Tables["data"];
			if (DBCTable == null)
			{
				DBCTable = m_Data.Tables.Add("data");
			}
			
			DBCTable.BeginLoadData();

			#region Construct Columns

			string LayoutID = LayoutElement.GetString("id");
			ConfigElement[] ColumnElements = DBCLayout["column","id",LayoutID];

			DataColumn PrimaryColumn = null;
			foreach (ConfigElement ColumnElement in ColumnElements)
			{
				Type ColumnType = typeof(uint);
				string TypeName = ColumnElement.GetString("type");

				if (TypeName != null)
				{
					ColumnType = Type.GetType("System."+TypeName,false,true);
					if (ColumnType == null)
					{
						throw new Exception("InvalidTypeException");
					}
				}

				DataColumn CurrentColumn = DBCTable.Columns.Add(ColumnElement.GetString("name").ToLower(),ColumnType);
				if (ColumnElement.GetBoolean("primarykey"))
				{
					PrimaryColumn = CurrentColumn;
				}
			}

			if (PrimaryColumn != null)
			{
				DBCTable.PrimaryKey = new DataColumn[1] {PrimaryColumn};
			}

			#endregion
			#region Load DBC

			BinaryReader DBCReader = new BinaryReader(File.OpenRead(Filename));
			DBCHeader Header = new DBCHeader(DBCReader);

			long StringTablePos = (Header.RowSize*Header.RowCount)+20;
			byte[] Buffer = new byte[Header.RowSize];

			#region Read each Row

			for(int i=0;i<=Header.RowCount-1;i++)
			{
				DataRow DBCRow = DBCTable.NewRow();

				DBCReader.Read(Buffer,0,(int)Header.RowSize);
				long NextRowPosition = DBCReader.BaseStream.Position;

				BinaryReader RowReader = new BinaryReader(new MemoryStream(Buffer));

				foreach (ConfigElement ColumnElement in ColumnElements)
				{
					string ColumnName = ColumnElement.GetString("name");
					if (ColumnElement.Exists("position"))
					{
						RowReader.BaseStream.Seek((long)ColumnElement.GetUInt64("position"),SeekOrigin.Begin);
					}
                    
					Type ColumnType = typeof(uint);
					string TypeName = ColumnElement.GetString("type");

					if (TypeName != null)
					{
						switch(TypeName.ToLower())
						{
								#region Type Read Cases
							case "sbyte":
								DBCRow[ColumnName] = RowReader.ReadSByte();
								break;
							case "byte":
								DBCRow[ColumnName] = RowReader.ReadByte();
								break;
							case "short":
								DBCRow[ColumnName] = RowReader.ReadInt16();
								break;
							case "ushort":
								DBCRow[ColumnName] = RowReader.ReadUInt16();
								break;
							case "int":
								DBCRow[ColumnName] = RowReader.ReadInt32();
								break;
							case "uint":
								DBCRow[ColumnName] = RowReader.ReadUInt32();
								break;
							case "long":
								DBCRow[ColumnName] = RowReader.ReadInt64();
								break;
							case "ulong":
								DBCRow[ColumnName] = RowReader.ReadUInt64();
								break;
							case "float":
								DBCRow[ColumnName] = RowReader.ReadSingle();
								break;
							case "double":
								DBCRow[ColumnName] = RowReader.ReadDouble();
								break;
							case "string":
								uint StringPos = RowReader.ReadUInt32();
								DBCReader.BaseStream.Seek(StringTablePos+StringPos,SeekOrigin.Begin);

								DBCRow[ColumnName] = Utilities.ReadString(DBCReader);
									
								DBCReader.BaseStream.Seek(NextRowPosition,SeekOrigin.Begin);
								break;
								#endregion
						}
					}
					else
					{
						DBCRow[ColumnName] = RowReader.ReadUInt32();
					}
				}

				RowReader.Close();
				DBCTable.Rows.Add(DBCRow);
			}

			#endregion

			DBCReader.Close();

			#endregion

			DBCTable.EndLoadData();
		}

		#endregion
		#region LoadDataFromXML

		private void LoadDataFromXML(string Filename)
		{
			try
			{
				FileInfo XMLInfo = new FileInfo(Filename);
				string XMLName = XMLInfo.Name.Substring(0,XMLInfo.Name.Length-XMLInfo.Extension.Length);

				XmlValidatingReader XMLReader = new XmlValidatingReader(File.OpenRead(Filename),XmlNodeType.Element,null);
				XMLReader.ValidationType = ValidationType.None;
				
				//Load the schema from the global resource stream...
				Stream XMLSchema = Utilities.GetStreamResource("Resources."+XMLName+".xsd");
				if (XMLSchema != null)
				{
					XmlTextReader XMLSchemaReader = new XmlTextReader(XMLSchema);
					XMLReader.Schemas.Add("",XMLSchemaReader);
					XMLReader.ValidationType = ValidationType.Schema;
				
					XMLSchema.Position = 0;
					m_Data.ReadXmlSchema(XMLSchema);
				}

				m_Data.ReadXml(XMLReader);
				ConvertNumericFields();
				XMLReader.Close();
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		#endregion

		#endregion
		#region LoadDataFromFile

		private void LoadDataFromFile(string Filename)
		{
			lock(m_Data)
			{
				FileInfo Info = new FileInfo(Filename);
			
				switch(Info.Extension.ToUpper())
				{
					case ".DBC":
						LoadDataFromDBC(Filename);
						break;
					case ".XML":
						LoadDataFromXML(Filename);
						break;
				}
			}
		}

		#endregion

		public void Reload()
		{
			if (m_Data != null)
			{
				m_Data.Clear();
				m_Data.Dispose();
				m_Data = null;
			}

			m_Data = new DataSet();
			LoadDataFromFile(m_Filename);
		}

		internal ConfigFile(string Filename, ConfigEngine Engine)
		{
			if (!File.Exists(Filename))
			{
				throw new FileNotFoundException("Configuration file '"+Filename+"' could not be found.",Filename);
			}

			m_Filename = Filename;
			m_Engine = Engine;

			Reload();
		}
	}
}
