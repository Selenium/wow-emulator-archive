using System;
using System.Collections;
using WoWDaemon.Database;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.Database.MemberValues;
namespace WoWDaemon.Database.DataTables
{
	/// <summary>
	/// Base class for all data tables
	/// </summary>
	/// 

	public abstract class DBObject : DataObject
	{
		static Hashtable serializeValues = new Hashtable();
		public static SerializeValue[] GetSerializeValues(Type type)
		{
			lock(serializeValues.SyncRoot)
			{
				SerializeValue[] values = (SerializeValue[])serializeValues[type];
				if(values != null)
					return values;
				MemberValue[] memberValues = MemberValue.GetMemberValues(type, new Type[2] {typeof(ServerSerialize), typeof(DataElement)}, true, true);
				values = SerializeValue.GetSerializeValues(memberValues);
				serializeValues[type] = values;
				return values;
			}
		}
		public void Serialize(BinWriter data)
		{
			foreach(SerializeValue value in GetSerializeValues(this.GetType()))
				value.Serialize(this, data);
		}

		public void Deserialize(BinReader data)
		{
			foreach(SerializeValue value in GetSerializeValues(this.GetType()))
				value.Deserialize(this, data);
		}

		public bool PendingDelete = false;
		public bool PendingCreate = false;
		public bool PendingSave = false;
		public void OnDBCreate(uint id)
		{
			ObjectId = id;
			IsValid = true;
		}
	}
}
