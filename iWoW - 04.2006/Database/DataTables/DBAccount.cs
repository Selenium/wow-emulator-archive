using System;
using System.Net;
using WoWDaemon.Database;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using System.Runtime.Remoting.Contexts;

namespace WoWDaemon.Database.DataTables
{
	[DataTable(TableName="Account")]
	public class DBAccount : DBObject
	{
		public DBAccount()
		{
		}

		[PrimaryKey(Name="Name")]
		private string m_name = null;
		[PrimaryKey(Name="Password")]
		private string m_password = string.Empty;
		[DataElement(Name="SessionKey")]
		private string m_sessionkey = string.Empty;
		[DataElement(Name="CreationDate")]
		private DateTime m_creationDate = DateTime.Now;
		[DataElement(Name="LastAcess")]
		private string m_lastacess = null;
		[DataElement(Name="AccessLvl")]
		private ACCESSLEVEL m_accesslvl = ACCESSLEVEL.NORMAL;
		[DataElement(Name="LastIP")]
		private string m_lastip = "10.10.10.253";
		[DataElement(Name="FlagAccess")]
		private int m_flagaccess;

		public string Name
		{
			get {return m_name;}
			set {Dirty = true; m_name = value;}
		}
		
		public string Password
		{
			get {return m_password;}
			set {Dirty = true; m_password = value;}
		}

		public string SessionKey
		{
			get {return m_sessionkey;}
			set {Dirty = true; m_sessionkey = value;}
		}
        	
		public DateTime CreationDate
		{
			get {return m_creationDate;}
			set {Dirty = true; m_creationDate = value;}
		}

		public string LastAcess
		{
			get {return m_lastacess;}
			set {Dirty = true; m_lastacess = value;}
		}

		public ACCESSLEVEL AccessLvl
		{
			get {return m_accesslvl;}
			set {Dirty = true; m_accesslvl = value;}
		}

		public string LastIP
		{
			get {return m_lastip;}
			set {Dirty = true; m_lastip = value;}
		}


		static bool m_autosave = true;
		public override bool AutoSave
		{
			get {return m_autosave;}
			set {m_autosave = value;}
		}

		public int FlagAcess
		{
			get {return m_flagaccess;}
			set {Dirty = true; m_flagaccess = value;}
		}

		[Relation(LocalField="ObjectId", RemoteField="AccountID", AutoLoad=true, AutoDelete=true)]
		public DBCharacter[] Characters = null;
	}
}
