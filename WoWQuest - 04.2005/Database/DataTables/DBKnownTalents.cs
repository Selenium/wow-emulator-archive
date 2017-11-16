using System;
using WoWDaemon.Database;
using WoWDaemon.Common.Attributes;

namespace WoWDaemon.Database.DataTables
{
	[DataTable(TableName="KnownTalents")]
	public class DBKnownTalents : DBObject
	{
		public DBKnownTalents()
		{
		}

		[DataElement(Name="CharacterID")]
		private uint m_charID;

		[DataElement(Name="Talent_Id")]
		private uint m_talentID;

		[DataElement(Name="TalentLevel")]
		private uint m_talentlevel;

		
		public uint CharacterID
		{
			get {return m_charID;}
			set {Dirty = true; m_charID = value;}
		}

		public uint Talent_Id
		{
			get {return m_talentID;}
			set {Dirty = true; m_talentID = value;}
		}

		public uint TalentLevel
		{
			get {return m_talentlevel;}
			set {Dirty = true; m_talentlevel = value;}
		}
		
		static bool m_autosave = true;
		public override bool AutoSave
		{
			get {return m_autosave;}
			set {m_autosave = value;}
		}

		[Relation(LocalField="Talent_Id", RemoteField="Talent_ID", AutoLoad=true, AutoDelete=false)]
		public DBTalents Talents=null;
	}
}
