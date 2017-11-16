using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
namespace WoWDaemon.Database.DataTables
{
	/// <summary>
	/// Summary description for DBSpawn.
	/// </summary>
	[DataTable(TableName="LootGroupItem")]
	public class DBLootGroupItem : DBObject
	{
		[DataElement(Name="LootGroupID")]
		private uint m_lootgroupid;
		[DataElement(Name="TemplateID")]
		private uint m_templateid;
		
		public DBLootGroupItem()
		{
		}

		public uint LootGroupID
		{
			get { return m_lootgroupid; }
			set { m_lootgroupid = value; Dirty = true;}
		}

		public uint TemplateID
		{
			get { return m_templateid; }
			set { m_templateid = value; Dirty = true;}
		}

		public override bool AutoSave
		{
			get { return true;}
			set {}
		}

		[Relation(LocalField="TemplateID", RemoteField="ItemTemplate_ID", AutoLoad=true, AutoDelete=false)]
		public DBItemTemplate Template = null;
	}
}
