using System;
using WoWDaemon.Common.Attributes;
namespace WoWDaemon.Database.DataTables
{
	/// <summary>
	/// Summary description for DBCreature.
	/// </summary>
	[DataTable(TableName="Creature")]
	public class DBCreature : DBObject
	{
		[DataElement(Name="Name")]
		private string m_name = "Monster";
		[DataElement(Name="Name1")]
		private string m_name1 = string.Empty;
		[DataElement(Name="Name2")]
		private string m_name2 = string.Empty;
		[DataElement(Name="Name3")]
		private string m_name3 = string.Empty;
		[DataElement(Name="Title")]
		private string m_title = string.Empty;
		[DataElement(Name="Flags")]
		private int m_flags;
		[DataElement(Name="NPCFlags")]
		private uint m_npcflags;
		[DataElement(Name="CreatureType")]
		private int m_creatureType;
		[DataElement(Name="CreatureFamily")]
		private int m_creatureFamily;
		[DataElement(Name="Script")]
		private string m_script = "WoWDaemon.World.UnitBase";
		[DataElement(Name="Roam")]
		private bool m_roam=true;


		public DBCreature()
		{

		}

		public string Name
		{
			get { return m_name;}
			set { m_name = value; Dirty = true;}
		}

		public string Name1
		{
			get { return m_name1;}
			set { m_name1 = value; Dirty = true;}
		}
		public string Name2
		{
			get { return m_name2;}
			set { m_name2 = value; Dirty = true;}
		}
		public string Name3
		{
			get { return m_name3;}
			set { m_name3 = value; Dirty = true;}
		}

		public string Title
		{
			get { return m_title;}
			set { m_title = value; Dirty = true;}
		}

		public int Flags
		{
			get { return m_flags;}
			set { m_flags = value; Dirty = true;}
		}

		public uint NPCFlags
		{
			get { return m_npcflags;}
			set { m_npcflags = value; Dirty = true;}
		}

		public int CreatureType
		{
			get { return m_creatureType;}
			set { m_creatureType = value; Dirty = true;}
		}

		public int CreatureFamily
		{
			get { return m_creatureFamily;}
			set { m_creatureFamily = value; Dirty = true;}
		}

		public string Script
		{
			get { return m_script;}
			set { m_script = value; Dirty = true;}
		}

		public bool Roam
		{
			get { return m_roam;}
			set { m_roam = value; Dirty = true;}
		}

		public override bool AutoSave
		{
			get
			{
				return true;
			}
			set
			{
			}
		}
	}
}
