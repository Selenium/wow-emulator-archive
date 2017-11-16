using System;
using WoWDaemon.Database;
using WoWDaemon.Common.Attributes;

namespace WoWDaemon.Database.DataTables
{
	[DataTable(TableName="GuildMembers")]
	public class DBGuildMembers : DBObject
	{
		public DBGuildMembers()
		{
		}

		[DataElement(Name="GuildId")]
		private uint m_guildID;
		[PrimaryKey(Name="MemberId")]
		private uint m_memberID;
		[DataElement(Name="Rank")]
		private uint m_rank;
		[DataElement(Name="Name")]
		private string m_name;
/*		[DataElement(Name="Level")]
		private byte m_level;
		[DataElement(Name="Class")]
		private byte m_class;
		[DataElement(Name="Zone")]
		private uint m_zone;
*/		[DataElement(Name="Note")]
		private string m_note=" ";
		[DataElement(Name="OfficerNote")]
		private string m_onote=" ";
		[DataElement(Name="LastOnline")]
		private uint m_lastonline=0;
		
		public uint GuildID
		{
			get {return m_guildID;}
			set {Dirty = true; m_guildID = value;}
		}

		public uint MemberID
		{
			get {return m_memberID;}
			set {Dirty = true; m_memberID = value;}
		}

		public uint Rank
		{
			get {return m_rank;}
			set {Dirty = true; m_rank = value;}
		}

		public string Name
		{
			get {return m_name;}
			set {Dirty = true; m_name = value;}
		}

/*		public byte Level
		{
			get {return m_level;}
			set {Dirty = true; m_level = value;}
		}

		public byte Class
		{
			get {return m_class;}
			set {Dirty = true; m_class = value;}
		}

		public uint Zone
		{
			get {return m_zone;}
			set {Dirty = true; m_guildID = value;}
		}
*/
		public string Note
		{
			get {return m_note;}
			set {Dirty = true; m_note = value;}
		}

		public string OfficerNote
		{
			get {return m_onote;}
			set {Dirty = true; m_onote = value;}
		}

		public uint LastOnline
		{
			get {return m_lastonline;}
			set {Dirty = true; m_lastonline = value;}
		}


		static bool m_autosave = true;
		public override bool AutoSave
		{
			get {return m_autosave;}
			set {m_autosave = value;}
		}

		[Relation(LocalField="MemberId", RemoteField="Character_ID", AutoLoad=true, AutoDelete=false)]
		public DBCharacter Character;
	}
}
