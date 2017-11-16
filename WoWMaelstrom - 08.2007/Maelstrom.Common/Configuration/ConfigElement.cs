using System;
using System.Data;

namespace Maelstrom
{
	public sealed class ConfigElement
	{
		private ConfigFile m_ConfigFile;
		private DataRow m_Data;

		#region Indexed

		public object this[string PropertyName]
		{
			get
			{
				object Result = m_Data[PropertyName];
				if (Result == DBNull.Value)
				{
					return null;
				}

				return m_Data[PropertyName];
			}
		}

		#endregion
		#region Get Methods

		#region GetSByte

		public sbyte GetSByte(string PropertyName)
		{
			return (sbyte)GetInt64(PropertyName);
		}

		#endregion
		#region GetByte

		public byte GetByte(string PropertyName)
		{
			return (byte)GetUInt64(PropertyName);
		}

		#endregion
		#region GetInt16

		public short GetInt16(string PropertyName)
		{
			return (short)GetInt64(PropertyName);
		}

		#endregion
		#region GetUInt16

		public ushort GetUInt16(string PropertyName)
		{
			return (ushort)GetUInt64(PropertyName);
		}

		#endregion
		#region GetInt32

		public int GetInt32(string PropertyName)
		{
			return (int)GetInt64(PropertyName);
		}

		#endregion
		#region GetUInt32

		public uint GetUInt32(string PropertyName)
		{
			return (uint)GetUInt64(PropertyName);
		}

		#endregion
		#region GetInt64

		public long GetInt64(string PropertyName)
		{
			return (long)GetUInt64(PropertyName);
		}

		#endregion
		#region GetUInt64

		public ulong GetUInt64(string PropertyName)
		{
			object PropertyValue = this[PropertyName];
			if (PropertyValue is string)
			{
				return (ulong)Utilities.ToNumericValue((string)PropertyValue);
			}

			return ulong.Parse(PropertyValue.ToString());
		}

		#endregion
		#region GetSingle

		public float GetSingle(string PropertyName)
		{
			return (float)GetDouble(PropertyName);
		}

		#endregion
		#region GetDouble

		public double GetDouble(string PropertyName)
		{
			object PropertyValue = this[PropertyName];
			if (PropertyValue is string)
			{
				object NumericValue = Utilities.ToNumericValue((string)PropertyValue);
				if ((NumericValue is ulong) || (NumericValue is long))
				{
					return (double)((ulong)NumericValue);
				}
				else
				{
					return (double)NumericValue;
				}
			}

			return double.Parse(PropertyValue.ToString());
		}

		#endregion
		#region GetString

		public string GetString(string PropertyName)
		{
			return this[PropertyName] as string;
		}

		#endregion
		#region GetBoolean

		public bool GetBoolean(string PropertyName)
		{
			object PropertyValue = this[PropertyName];
			if (PropertyValue is string)
			{
				return Utilities.ToBoolean((string)PropertyValue);
			}

			return (bool)PropertyValue;
		}

		#endregion
		#region GetSubElements

		public ConfigElement[] GetSubElements(string Name)
		{
			DataRelation Relation = m_Data.Table.ChildRelations[m_Data.Table.TableName+"_"+Name];
			if (Relation != null)
			{
				DataRow[] ResultRows = m_Data.GetChildRows(Relation);
				if (ResultRows.Length > 0)
				{
					ConfigElement[] Result = new ConfigElement[ResultRows.Length];
					for(int i=0;i<=ResultRows.Length-1;i++)
					{
						Result[i] = new ConfigElement(m_ConfigFile,ResultRows[i]);
					}

					return Result;
				}
			}

			return new ConfigElement[0];
		}

		#endregion

		#endregion
		#region Exists

		public bool Exists(string PropertyName)
		{
			return (this[PropertyName] != null);
		}

		#endregion

		internal ConfigElement(ConfigFile ConfigFile, DataRow Data)
		{
			m_ConfigFile = ConfigFile;
			m_Data = Data;
		}
	}
}
