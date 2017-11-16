using System;
using System.Data;
using System.Collections;

using WoWDaemon.Database.Cache;
using WoWDaemon.Database.MemberValues;
namespace WoWDaemon.Database
{
	/// <summary>
	/// Zusammenfassung für DataTableHandler.
	/// </summary>
	public class DataTableHandler
	{
		ICache cache;
		DataSet dset;
		bool hasRelations;
		Type dataObjectType;
		Hashtable columnsByName = new Hashtable();
		public readonly MemberValue[] Columns;
		public readonly MemberValue[] Relations;
		public readonly MemberValue Primary;
		public DataTableHandler(DataSet dataSet, Type dataobj, MemberValue primary, MemberValue[] columns, MemberValue[] relations)
		{
			Primary = primary;
			Columns = columns;
			Relations = relations;
			foreach(MemberValue column in columns)
				columnsByName[column.GetName()] = column;
			cache = new SimpleCache();
			dset = dataSet;
			hasRelations = false;
			dataObjectType = dataobj;
		}

		public MemberValue GetColumnByName(string name)
		{
			return (MemberValue)columnsByName[name];
		}

		public bool HasRelations
		{
			get
			{
				return hasRelations;
			}
			set
			{
				hasRelations = false;
			}
		}

		public ICache Cache
		{
			get
			{
				return cache;
			}
		}
	
		public DataSet DataSet
		{
			get
			{
				return dset;
			}
		}

		public Type DataObjectType
		{
			get
			{
				return dataObjectType;
			}
		}

		public void SetCacheObject(object Key, DataObject Obj)
		{
			cache[Key] = Obj;
		}

		public DataObject GetCacheObject(object Key)
		{
			return cache[Key] as DataObject;
		}
	}
}
