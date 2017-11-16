using System;
using WoWDaemon.Database;
using WoWDaemon.Common.Attributes;

namespace WoWDaemon.Database.DataTables
{
	[DataTable(TableName="FriendList")]
	public class DBFriendList : DBObject
	{
		public DBFriendList()
		{
		}

		[DataElement(Name="Owner_ID")]
		private uint m_ownerID;
		[DataElement(Name="Friend_ID")]
		private uint m_friendID;
/*  - Cut by Phaze
		[DataElement(Name="Area")]
		private int m_area;
		[DataElement(Name="Level")]
		private int m_level;
		[DataElement(Name="Class")]
		private int m_class;
*/
// Added by Phaze
//		[DataElement(Name="Name")]
//		private string m_friendName;
// End Added
		
		public uint Owner_ID
		{
			get {return m_ownerID;}
			set {Dirty = true; m_ownerID = value;}
		}

		public uint Friend_ID
		{
			get {return m_friendID;}
			set {Dirty = true; m_friendID = value;}
		}

//		public string Name
//		{
//			get {return m_friendName;}
//			set {Dirty = true; m_friendName = value;}
//		}

		
/*
		public int Area
		{
			get {return m_area;}
			set {Dirty = true; m_area = value;}
		}

		public int Level
		{
			get {return m_level;}
			set {Dirty = true; m_level = value;}
		}

		public int Class
		{
			get {return m_class;}
			set {Dirty = true; m_class = value;}
		}
*/
		static bool m_autosave = true;
		public override bool AutoSave
		{
			get {return m_autosave;}
			set {m_autosave = value;}
		}

//		[Relation(LocalField="Friend_ID", RemoteField="Char", AutoLoad=true, AutoDelete=true)]
//		public DBCharacter Name;
	}
}
