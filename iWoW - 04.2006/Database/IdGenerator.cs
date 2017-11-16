using System;
using System.Collections;
namespace WoWDaemon.Database
{
	/// <summary>
	/// Generates an UniqueID for every Object.
	/// </summary>
	public class IdGenerator
	{
		static Hashtable tbl = new Hashtable();
		public static void setIDStart(Type type, uint id)
		{
			tbl[type] = id;
		}

		public static uint getCurrentID(Type type)
		{
			if(tbl.Contains(type) == false)
				return 0;
			return (uint)tbl[type];
		}

		public static uint generateUID(Type type)
		{
			if(tbl.Contains(type) == false)
				throw new DatabaseException("Cannot generate uid for " + type.ToString());
			uint id = (uint)tbl[type];
			tbl[type] = id + 1;
			return id;
		}
	}
}
