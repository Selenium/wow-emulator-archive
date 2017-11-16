using System;
using WoWDaemon.Common;
using WoWDaemon.Database;
using WoWDaemon.Common.Attributes;

namespace WoWDaemon.Database.DataTables
{
	[DataTable(TableName="Guild")]
	public class DBGuild : DBObject
	{

		public DBGuild()
		{
			m_rankname=new string[10];
			m_rankflags=new uint[10];
			m_maxrank=4;
			m_motd=string.Empty;
			m_guildinfo=string.Empty;
			m_rankname[0]="GuildMaster";
			m_rankname[1]="Officer";
			m_rankname[2]="Veteran";
			m_rankname[3]="Member";
			m_rankname[4]="Initiate";
			m_rankflags[0]=61887;
			m_rankflags[1]=57991;
			m_rankflags[2]=19;
			m_rankflags[3]=3;
			m_rankflags[4]=1;

			for (int i=5;i<10;i++)
			{
				m_rankname[i]="Unused";
				m_rankflags[i]=0;
			}
		}
		
/*		public DBGuild()
		{
			this.m_creationDate = DateTime.Now;;
			int ctr=0;
			foreach(string s in Enum.GetNames(typeof(GUILDRANK)))
			{
				this.m_rankname[ctr]=s;
				ctr++;
			}
			for (int i=ctr;i<10;i++)
				this.m_rankname[1]="Unused";

			for (int j=0;j<10;j++)
				this.m_rankflags[1]=0;
		}
*/
		[DataElement(Name="Name")]
		private string m_name = null;
		[DataElement(Name="Leader")]
		private uint m_leader;
		[DataElement(Name="CreationDate")]
		private DateTime m_creationDate;// = DateTime.Now;

		[DataElement (Name="GuildInfo")]
		private string m_guildinfo;
		[DataElement(Name="MOTD")]
		private string m_motd;

		[DataElement(Name="Color")]
		private uint m_color=0xFFFFFFFF;
		[DataElement (Name="Border")]
		private uint m_border=0xFFFFFFFF;
		[DataElement (Name="BorderColor")]
		private uint m_bordercolor=0xFFFFFFFF;
		[DataElement (Name="Icon")]
		private uint m_icon=0xFFFFFFFF;
		[DataElement (Name="IconColor")]
		private uint m_iconcolor=0xFFFFFFFF;

		[DataElement (Name="RankName", ArraySize=10)]
		private string[] m_rankname; //=new string[10];
		[DataElement (Name="RankFlags", ArraySize=10)]
		private uint[] m_rankflags; //=new uint[10];
		[DataElement (Name="MaxRank")]
		private uint m_maxrank; //=new uint[10];
		

		public string Name
		{
			get {return m_name;}
			set {Dirty = true; m_name = value;}
		}

		public uint Leader
		{
			get {return m_leader;}
			set {Dirty = true; m_leader = value;}
		}

		public DateTime CreationDate
		{
			get {return m_creationDate;}
			set {Dirty = true; m_creationDate = value;}
		}

		public string GuildInfo
		{
			get {return m_guildinfo;}
			set {Dirty = true; m_guildinfo = value;}
		}

		public string MOTD
		{
			get {return m_motd;}
			set {Dirty = true; m_motd = value;}
		}

		
		#region Tabard Info
		public uint Color
		{
			get {return m_color;}
			set {Dirty = true; m_color = value;}
		}

		public uint Border
		{
			get {return m_border;}
			set {Dirty = true; m_border = value;}
		}

		public uint BorderColor
		{
			get {return m_bordercolor;}
			set {Dirty = true; m_bordercolor = value;}
		}

		public uint Icon
		{
			get {return m_icon;}
			set {Dirty = true; m_icon = value;}
		}

		public uint IconColor
		{
			get {return m_iconcolor;}
			set {Dirty = true; m_iconcolor = value;}
		}
		#endregion

		#region RankFields
		public string getRankName(uint ndx)
		{
			return m_rankname[ndx];
		}

		public void setRankName(uint ndx, string value)
		{
			m_rankname[ndx]=value;
			Dirty=true;
		}

		public uint getRankFlags(uint ndx)
		{
			return m_rankflags[ndx];
		}

		public void setRankFlags(uint ndx, uint value)
		{
			m_rankflags[ndx]=value;
			Dirty=true;
		}

		public uint MaxRank
		{
			get {return m_maxrank;}
			set {Dirty = true; m_maxrank = value;}
		}
		#endregion

		static bool m_autosave = true;
		public override bool AutoSave
		{
			get {return m_autosave;}
			set {m_autosave = value;}
		}


		[Relation(LocalField="ObjectId", RemoteField="GuildID", AutoLoad=true, AutoDelete=false)]
		public DBGuildMembers[] Members;
	}
}
