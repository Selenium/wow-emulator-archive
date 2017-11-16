using System;
using WoWDaemon.Database;
using WoWDaemon.Common.Attributes;

namespace WoWDaemon.Database.DataTables
{
	[DataTable(TableName="KnownQuest")]
	public class DBKnownQuest : DBObject
	{
		public DBKnownQuest()
		{
		}

		[DataElement(Name="CharacterID")]
		private uint m_charID;

		[DataElement(Name="Quest_ID")]
		private uint m_questID;

		[DataElement(Name="Quest_Status")]
		private uint m_questStatus;

		[DataElement(Name="Quest_Slot")]
		private uint m_questSlot;

		
		public uint CharacterID
		{
			get {return m_charID;}
			set {Dirty = true; m_charID = value;}
		}

		public uint Quest_ID
		{
			get {return m_questID;}
			set {Dirty = true; m_questID = value;}
		}

		public uint Quest_Status
		{
			get {return m_questStatus;}
			set {Dirty = true; m_questStatus = value;}
		}

		public uint Quest_Slot
		{
			get {return m_questSlot;}
			set {Dirty = true; m_questSlot = value;}
		}

		static bool m_autosave = true;
		public override bool AutoSave
		{
			get {return m_autosave;}
			set {m_autosave = value;}
		}

		[Relation(LocalField="Quest_ID", RemoteField="Quest_ID", AutoLoad=true, AutoDelete=false)]
		public DBQuest Quest=null;
	}
}
