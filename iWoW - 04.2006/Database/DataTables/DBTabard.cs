using System;
using WoWDaemon.Database;
using WoWDaemon.Common.Attributes;

namespace WoWDaemon.Database.DataTables
{
	[DataTable(TableName="Tabard")]
	public class DBTabard : DBObject
	{
		public DBTabard()
		{
		}

		[PrimaryKey(Name="Name")]
		private string m_name = null;
		[DataElement(Name="Leader")]
		private string m_leader = null;
		[DataElement(Name="Color")]
		private byte m_color;
		[DataElement (Name="BorderColor")]
		private byte m_borderColor;
		[DataElement (Name="Icon")]
		private byte m_icon;

		public string Name
		{
			get {return m_name;}
			set {Dirty = true; m_name = value;}
		}

		public string Leader
		{
			get {return m_leader;}
			set {Dirty = true; m_leader = value;}
		}


		public byte Color
		{
			get {return m_color;}
			set {Dirty = true; m_color = value;}
		}

		public byte BorderColor
		{
			get {return m_borderColor;}
			set {Dirty = true; m_borderColor = value;}
		}

		public byte Icon
		{
			get {return m_icon;}
			set {Dirty = true; m_icon = value;}
		}

		static bool m_autosave = true;
		public override bool AutoSave
		{
			get {return m_autosave;}
			set {m_autosave = value;}
		}

	}
}
