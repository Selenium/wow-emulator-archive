using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
namespace WoWDaemon.Database.DataTables
{
	/// <summary>
	/// Summary description for DBSpawn.
	/// </summary>
	[DataTable(TableName="Spawn")]
	public class DBSpawn : DBObject
	{
		[DataElement(Name="WorldMapID")]
		private uint m_worldMapID;
		[DataElement(Name="Position")]
		private Vector m_position = new Vector();
		[DataElement(Name="Facing")]
		private float m_facing;
		[DataElement(Name="CreatureID")]
		private uint m_creatureID;
		[DataElement(Name="Level")]
		private int m_level;
		[DataElement(Name="Faction")]
		private int m_faction;
		[DataElement(Name="Health")]
		private int m_health;
		[DataElement(Name="Power")]
		private int m_power;
		[DataElement(Name="DisplayID")]
		private int m_displayID;
		[DataElement(Name="Min_Damage")]
		private uint m_mindamage;
		[DataElement(Name="Max_Damage")]
		private uint m_maxdamage;
		[DataElement(Name="Roam")]
		private bool m_roam;
		
		public DBSpawn()
		{
		}

		public int Faction
		{
			get { return m_faction; }
			set { m_faction = value; Dirty = true;}
		}

		public int Health
		{
			get { return m_health; }
			set { m_health = value; Dirty = true;}
		}

		public int Power
		{
			get { return m_power; }
			set { m_power = value; Dirty = true;}
		}

		public int DisplayID
		{
			get { return m_displayID; }
			set { m_displayID = value; Dirty = true;}
		}

		public int Level
		{
			get { return m_level; }
			set { m_level = value; Dirty = true;}
		}

		public uint WorldMapID
		{
			get { return m_worldMapID;}
			set { m_worldMapID = value; Dirty = true;}
		}

		public Vector Position
		{
			get { return m_position;}
			set { m_position = value; Dirty = true;}
		}

		public float Facing
		{
			get { return m_facing;}
			set { m_facing = value; Dirty = true;}
		}

		public uint CreatureID
		{
			get { return m_creatureID;}
			set { m_creatureID = value; Dirty = true;}
		}

		public uint Min_Damage 
		{
			get { return m_mindamage;}
			set { m_mindamage = value; Dirty = true;}
		}

		public uint Max_Damage 
		{
			get { return m_maxdamage;}
			set { m_maxdamage = value; Dirty = true;}
		}

		public bool Roam
		{
			get { return m_roam;}
			set { m_roam = value; Dirty = true;}
		}

		public override bool AutoSave
		{
			get { return true;}
			set {}
		}

		[Relation(LocalField="CreatureID", RemoteField="Creature_ID", AutoLoad=true, AutoDelete=false)]
		public DBCreature Creature;
	}
}
