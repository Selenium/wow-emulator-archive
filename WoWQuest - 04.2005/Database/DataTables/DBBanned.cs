using System;
using System.Net;
using WoWDaemon.Database;
using WoWDaemon.Common.Attributes;
using WoWDaemon.Common;

namespace WoWDaemon.Database.DataTables
{
	[DataTable(TableName="Banned")]
	public class DBBanned : DBObject
	{
		public DBBanned()
		{
		}

		[PrimaryKey(Name="BanAddress")]
		private string m_ipaddress = null;
		[DataElement(Name="BannedDate")]
		private DateTime m_banneddate = DateTime.Now;
		[DataElement(Name="BannedBy")]
		private string m_bannedby;

		public string BanAddress
		{
			get {return m_ipaddress;}
			set {Dirty = true; m_ipaddress = value;}
		}

		public DateTime BannedDate
		{
			get {return m_banneddate;}
			set {Dirty = true; m_banneddate = value;}
		}


		public string BannedBy
		{
			get {return m_bannedby;}
			set {Dirty = true; m_bannedby = value;}
		}


		static bool m_autosave = true;
		public override bool AutoSave
		{
			get {return m_autosave;}
			set {m_autosave = value;}
		}

	}
}
