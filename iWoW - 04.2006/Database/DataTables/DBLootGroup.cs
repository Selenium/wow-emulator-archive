using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
namespace WoWDaemon.Database.DataTables
{
	/// <summary>
	/// Summary description for DBLootGroup.
	/// </summary>
	[DataTable(TableName="LootGroup")]
	public class DBLootGroup : DBObject
	{
		[DataElement(Name="Name")]
		private string m_name;
		
		public DBLootGroup()
		{
		}

		public string Name
		{
			get { return m_name; }
			set { m_name = value; Dirty = true;}
		}

		public override bool AutoSave
		{
			get { return true;}
			set {}
		}

		[Relation(LocalField="ObjectId", RemoteField="LootGroupID", AutoLoad=true, AutoDelete=false)]
		public DBLootGroupItem[] LootGroupItem=null;
	}
}
