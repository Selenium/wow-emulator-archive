using System;
using System.Collections;
using System.Reflection;
using System.Data;
using System.Data.SqlTypes;
using System.Xml;

using WoWDaemon.Database.Connection;
using WoWDaemon.Database.Cache;
using WoWDaemon.Database.MemberValues;

namespace WoWDaemon.Database
{
	/// <summary>
	/// Database to to full Dokumentation
	/// </summary>
	public class ObjectDatabase
	{
		private Hashtable tableDatasets;
		private DataConnection connection;

		public ObjectDatabase(DataConnection Connection)
		{
			tableDatasets = new Hashtable();
			connection = Connection;

		}

		public string[] GetTableNameList()
		{
			string[] ar = new string[tableDatasets.Count];


			IDictionaryEnumerator iter = tableDatasets.GetEnumerator();

			int index = 0;

			while(iter.MoveNext())
			{
				ar[index] = (string)iter.Key;
				++index;
			}

			return ar;
		}

		/// <summary>
		/// Loads the tables from all datasets
		/// </summary>
		public void LoadDatabaseTables()
		{		
			IDictionaryEnumerator i = tableDatasets.GetEnumerator();

			while(i.MoveNext())
			{
				DataTableHandler dth = (DataTableHandler)i.Value;
				connection.LoadDataSet((string)i.Key, dth.DataSet);
				DataTable table = dth.DataSet.Tables[(string)i.Key];
				if(table.Rows.Count == 0)
					IdGenerator.setIDStart(dth.DataObjectType, 1);
				else
				{
					IdGenerator.setIDStart(dth.DataObjectType, 1 + (uint)table.Rows[table.Rows.Count-1][(string)i.Key + "_ID"]);
				}

			}
		}

		public void ReloadDatabaseTables()
		{
			IDictionaryEnumerator i = tableDatasets.GetEnumerator();

			while(i.MoveNext())
			{
				connection.LoadDataSet((string)i.Key, GetDataSet((string)i.Key));
				ReloadCache((string)i.Key);
			}
		}

		public void WriteDatabaseTables()
		{
			IDictionaryEnumerator i = tableDatasets.GetEnumerator();

			while(i.MoveNext())
				connection.SaveDataSet((string)i.Key, GetDataSet((string)i.Key));
		}

		public void WriteDatabaseTable(Type ObjectType)
		{
			string tableName = DataObject.GetTableName(ObjectType);
			connection.SaveDataSet(tableName, GetDataSet(tableName));
		}

		public void ReloadDatabaseTable(Type ObjectType)
		{
			string tableName = DataObject.GetTableName(ObjectType);
			LoadDatabaseTable(ObjectType);
			ReloadCache(tableName);
		}

		public void LoadDatabaseTable(Type ObjectType)
		{
			string tableName = DataObject.GetTableName(ObjectType);
			connection.LoadDataSet(tableName, GetDataSet(tableName));
		}

		public int GetObjectCount(Type ObjectType)
		{
			string tableName = DataObject.GetTableName(ObjectType);

			DataTable table = GetDataSet(tableName).Tables[tableName];

			return table.Rows.Count;
		}

		public void AddNewObject(DataObject DataObject)
		{
			DataTable table = null;
			DataRow row = null;

			try
			{
				string tableName = DataObject.TableName;
		  
				table = GetDataSet(tableName).Tables[tableName];
		  
				row = table.NewRow();
			
				if(DataObject.ObjectId == 0)
					DataObject.ObjectId = IdGenerator.generateUID(DataObject.GetType());

				FillRowWithObject(DataObject, row);

				table.Rows.Add(row);

				if(DataObject.AutoSave == true)
					WriteDatabaseTable(DataObject.GetType());

				DataObject.Dirty = false;
				PutObjectInCache(tableName, DataObject);
				DataObject.IsValid = true;
				return;
			}

			catch(Exception e)
			{
				//DOLConsole.WriteError(e.ToString());
				Console.WriteLine(e.ToString());

				if(row != null && table != null)
				{
					table.Rows.Remove(row);
				}
				throw new DatabaseException("Adding Databaseobject failed !", e);
			}
		}
	
		public void SaveObject(DataObject DataObject)
		{
			try
			{
				if(DataObject.Dirty == false)
					return;

				DataRow row = FindRowByKey(DataObject);

				if(row == null)
					throw new DatabaseException("Saving Databaseobject failed (unable to find row)");

				FillRowWithObject(DataObject, row);

				if(DataObject.AutoSave == true)
					WriteDatabaseTable(DataObject.GetType());

				DataObject.Dirty = false;
				DataObject.IsValid = true;

				return;
			}
			catch ( Exception e)
			{
				throw new DatabaseException("Saving Database object failed!", e);
			}
		}

		public DataObject ReloadObject(DataObject DataObject)
		{
			try
			{
				if (DataObject == null)
					return null;
				DataObject ret = DataObject;

				DataRow row = FindRowByKey(ret);

				if(row == null)
					throw new DatabaseException("Reloading Databaseobject failed (Keyvalue Changed ?)!");

				FillObjectWithRow(ref ret, row, true);

				DataObject.Dirty = false;
				DataObject.IsValid = true;

				return ret;
			}
			catch ( Exception e)
			{
				throw new DatabaseException("Reloading Databaseobject failed !", e);
			}
		}

		public void DeleteObject(DataObject DataObject)
		{
			try
			{
				DataRow row = FindRowByKey(DataObject);

				if(row == null)
					throw new DatabaseException("Deleting Databaseobject failed (unable to find row)!");

				row.Delete();

				if(DataObject.AutoSave == true)
					WriteDatabaseTable(DataObject.GetType());

				DataObject.IsValid = false;

				DeleteObjectInCache(DataObject.TableName, DataObject);

				DeleteObjectRelations(DataObject);

				return;
			}
			catch ( Exception e)
			{
				throw new DatabaseException("Deleting Databaseobject failed !", e);
			}
		}

		public DataObject FindObjectByKey(Type ObjectType, object Key)
		{
			DataRow row;

			DataObject ret = (DataObject)Activator.CreateInstance(ObjectType);

			String tableName = ret.TableName;	  

			DataTable table = GetDataSet(tableName).Tables[tableName];

			row = table.Rows.Find(Key);

			if(row != null)
			{
				FillObjectWithRow(ref ret, row, false);
				return ret;
			}

  						
			return null;
		}
		
		public DataObject[] SelectObjects(Type objectType, string statement)
		{
			string tableName = DataObject.GetTableName(objectType);
			DataSet ds = GetDataSet(tableName);
			if(ds != null)
			{
				DataTable table = ds.Tables[tableName];
				DataRow[] rows = table.Select(statement);

				int count = rows.Length;
				DataObject[] objs = new DataObject[count];
				for(int i = 0; i < count; i++)
				{
					DataObject remap = (DataObject)(Activator.CreateInstance(objectType));
					FillObjectWithRow(ref remap, rows[i], false);
					objs[i] = remap;
				}

				return objs;
			}
	
			return new DataObject[0];
		}

		public DataObject[] SelectAllObjects(Type objectType)
		{
			string tableName = DataObject.GetTableName(objectType);
			DataSet ds = GetDataSet(tableName);

			if(ds != null)
			{
				DataTable table = ds.Tables[tableName];
				DataRow[] rows = table.Select();

				int count = rows.Length;
				DataObject[] objs = new DataObject[count];
				for(int i = 0; i < count; i++)
				{
					DataObject remap = (DataObject)(Activator.CreateInstance(objectType));
					FillObjectWithRow(ref remap, rows[i], false);
					objs[i] = remap;
				}

				return objs;
			}
	
			return new DataObject[0];
		}

		public void RegisterDataObject(Type DataObjectType)
		{
			bool primary = false;

			string TableName = DataObject.GetTableName(DataObjectType);

			DataSet ds = new DataSet(); 
		  
			DataTable table = new DataTable(TableName);		
			
			table.Columns.Add(TableName + "_ID", typeof(uint));
			MemberValue[] columns = MemberValue.GetMemberValues(DataObjectType, typeof(Common.Attributes.DataElement), true, true);
			MemberValue[] relations = MemberValue.GetMemberValues(DataObjectType, typeof(Common.Attributes.Relation), false, false);
			MemberValue primaryvalue = null;
			foreach(MemberValue column in columns)
			{
				Type valueType = column.GetValueType();
				if(!primary && column.Attribute is Common.Attributes.PrimaryKey)
				{
					primaryvalue = column;
					primary = true;
					DataColumn[] index = new DataColumn[1];
					index[0] = table.Columns.Add(column.GetName(), valueType);
					table.PrimaryKey = index;
				}
				else
					table.Columns.Add(column.GetName(), valueType);
			}

			if(primary == false)
			{
				primaryvalue = new PropertyMemberValue(DataObjectType.GetProperty("ObjectId"));
				DataColumn[] index = new DataColumn[1];		
				index[0] = table.Columns[TableName + "_ID"];
				table.PrimaryKey = index;
			}

			ds.DataSetName = TableName;
			ds.EnforceConstraints = true;
			ds.CaseSensitive = false;
			ds.Tables.Add(table);

			DataTableHandler dth = new DataTableHandler(ds, DataObjectType, primaryvalue, columns, relations);
			dth.HasRelations = relations.Length != 0;
			tableDatasets.Add(TableName, dth);
			IdGenerator.setIDStart(DataObjectType, 1);
		}


		public DataSet GetDataSet(string TableName)
		{
			DataTableHandler handler = (DataTableHandler)tableDatasets[TableName];
			return handler.DataSet;
		}

		private void FillObjectWithRow(ref DataObject DataObject, DataRow row, bool reload)
		{
			string tableName = DataObject.TableName;

			//Type myType = DataObject.GetType();

			uint id = (uint)row[tableName + "_ID"];

			DataObject cacheObj = GetObjectInCache(tableName, id);

			if(cacheObj != null)
			{
				DataObject = cacheObj;
				if(reload == false)
				  return;
			}

			DataTableHandler handler = (DataTableHandler)tableDatasets[tableName];

			DataObject.ObjectId = id;
			foreach(MemberValue member in handler.Columns)
			{
				object val = row[member.GetName()];
				if(val != null && !val.GetType().IsInstanceOfType(DBNull.Value))
				{
					member.SetValue(DataObject, val);
				}
			}
			DataObject.Dirty = false;


			if(handler.Relations.Length > 0)
			{
				FillLazyObjectRelations(DataObject, true);
			}

			if(reload == false)
			{
				PutObjectInCache(tableName, DataObject);
			}

			DataObject.IsValid = true;
		}

		private DataObject GetObjectInCache(string TableName, uint id)
		{
			DataTableHandler handler = tableDatasets[TableName] as DataTableHandler;
			return handler.GetCacheObject(id);
		}

		private void PutObjectInCache(string TableName, DataObject obj)
		{
			DataTableHandler handler = tableDatasets[TableName] as DataTableHandler;
			handler.SetCacheObject(obj.ObjectId, obj);
		}
		
		private void DeleteObjectInCache(string TableName, DataObject obj)
		{
			DataTableHandler handler = tableDatasets[TableName] as DataTableHandler;
			handler.SetCacheObject(obj.ObjectId, null);
		}

		private void FillRowWithObject(DataObject DataObject, DataRow row)
		{
			string tableName = DataObject.TableName;
			DataTableHandler handler = (DataTableHandler)tableDatasets[tableName];
			row[tableName + "_ID"] = DataObject.ObjectId;
			foreach(MemberValue member in handler.Columns)
			{
				object val = member.GetValue(DataObject);
				if(val != null)
					row[member.GetName()] = val;
			}
			if(handler.Relations.Length > 0)
			{
				SaveObjectRelations(DataObject);
			}
		}

		private DataRow FindRowByKey(DataObject DataObject)
		{
			String tableName = DataObject.TableName;
		  
			DataTableHandler handler = (DataTableHandler)tableDatasets[tableName];
			DataTable table = GetDataSet(tableName).Tables[tableName];
			DataRow[] rows = table.Select(tableName + "_ID = '" + DataObject.ObjectId + "'");
			if(rows.Length == 0)
				return null;
			return rows[0];
		}

		public void FillObjectRelations(DataObject DataObject)
		{
			FillLazyObjectRelations(DataObject, false);
		}

		private void SaveObjectRelations(DataObject DataObject)
		{
			try
			{
				String tableName = DataObject.TableName;
				DataTableHandler handler = (DataTableHandler)tableDatasets[tableName];
				foreach(MemberValue value in handler.Relations)
				{
					if(value.GetValueType().IsArray)
					{
						Array array = value.GetValue(DataObject) as Array;
						if(array != null)
						{
							foreach(DataObject obj in array)
								SaveObject(obj);
						}
					}
					else
					{
						object val = value.GetValue(DataObject);
						if(val != null)
							SaveObject(val as DataObject);
					}
				}
			}
			catch( Exception e)
			{
				throw new DatabaseException("Saving Relations failed !", e);
			}
		}

		private void DeleteObjectRelations(DataObject DataObject)
		{
			try
			{
				String tableName = DataObject.TableName;
				DataTableHandler handler = (DataTableHandler)tableDatasets[tableName];
				foreach(MemberValue value in handler.Relations)
				{
					if(((Common.Attributes.Relation)value.Attribute).AutoDelete == false)
						continue;
					if(value.GetValueType().IsArray)
					{
						Array array = value.GetValue(DataObject) as Array;
						foreach(DataObject obj in array)
							DeleteObject(obj);
					}
					else
						DeleteObject(value.GetValue(DataObject) as DataObject);
				}
			}
			catch( Exception e)
			{
				throw new DatabaseException("Deleting Relations failed !", e);
			}
		}


		private void FillLazyObjectRelations(DataObject DataObject, bool Autoload)
		{
			try
			{
				Type myType = DataObject.GetType();
				String tableName = DataObject.TableName;
				DataTableHandler handler = (DataTableHandler)tableDatasets[tableName];
				foreach(MemberValue value in handler.Relations)
				{
					Common.Attributes.Relation relation = (Common.Attributes.Relation)value.Attribute;
					if(relation.AutoLoad == false && Autoload == true)
						continue;
					
					PropertyInfo prop = myType.GetProperty(relation.LocalField, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
					object val = 0;				
					if(prop != null)
						val = prop.GetValue(DataObject, null);
					else
					{
						FieldInfo field = myType.GetField(relation.LocalField, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);	
						if(field != null)
							val = field.GetValue(DataObject);
						else
						{
							MemberValue member = handler.GetColumnByName(relation.LocalField);
							val = member.GetValue(DataObject);
						}
					}

					Type type = value.GetValueType();
					if(type.IsArray)
						type = type.GetElementType();

					DataObject[] Elements = null;
					if(val != null)
						Elements = SelectObjects(type, relation.RemoteField + " = '" + val.ToString() + "'");
					if(Elements != null && Elements.Length > 0)
					{
						if(value.GetValueType().IsArray)
						{
							object[] args = {Elements.Length};
							object[] array = (object[])Activator.CreateInstance(value.GetValueType(), args);;
							for(int i = 0;i < Elements.Length;i++)
								array[i] = Elements[i];
								
							value.SetValue(DataObject, array);
						}
						else
						{
							value.SetValue(DataObject, Elements[0]);
						}
					}
				}
			}
			catch( Exception e)
			{
				throw new DatabaseException("Resolving Relations failed !", e);
			}
		}

		private void ReloadCache(string TableName)
		{
			DataTableHandler handler = tableDatasets[TableName] as DataTableHandler;
			
			ICache cache = handler.Cache;

			foreach(object o in cache.Keys)
			{
			   ReloadObject(cache[o] as DataObject);
			}
			
		}
	}
}
