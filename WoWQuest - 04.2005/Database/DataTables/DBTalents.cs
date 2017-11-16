using System;
using WoWDaemon.Database;
using WoWDaemon.Common.Attributes;

namespace WoWDaemon.Database.DataTables
{
	[DataTable(TableName="Talents")]
	public class DBTalents : DBObject
	{
		public DBTalents()
		{
		}

		[DataElement(Name="Name")]
		private string m_name = null;
		[DataElement(Name="TalentID")]
		private uint m_talentid;
		
		public string Name
		{
			get {return m_name;}
			set {Dirty = true; m_name = value;}
		}

		public uint TalentID
		{
			get {return m_talentid;}
			set {Dirty = true; m_talentid = value;}
		}
		static bool m_autosave = true;
		public override bool AutoSave
		{
			get {return m_autosave;}
			set {m_autosave = value;}
		}	
	
	}
}