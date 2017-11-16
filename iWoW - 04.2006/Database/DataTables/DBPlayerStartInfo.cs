using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
namespace WoWDaemon.Database.DataTables
{
	/*
	/// <summary>
	/// Summary description for DBPlayerStartInfo.
	/// </summary>
	public class DBPlayerStartInfo : DBObject
	{
		public override bool AutoSave
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[PrimaryKey]
		public int RaceClassGender
		{
			get
			{
				return (m_gender << 16) + (m_class << 8) + m_race;
			}
			set
			{
				m_race = (byte)(value & 0xFF);
				m_class = (byte)((value >> 8) & 0xFF);
				m_gender = (byte)((value >> 16) & 0xFF);
			}
		}

		private byte m_class;
		[DataElement]
		public byte Class
		{
			get {return m_class;}
			set {Dirty = true; m_class = value;}
		}

		private byte m_race;
		[DataElement]
		public byte Race
		{
			get {return m_race;}
			set {Dirty = true; m_race = value;}
		}

		private byte m_gender;
		[DataElement]
		public byte Gender
		{
			get {return m_gender;}
			set {Dirty = true; m_gender = value;}
		}

		private float m_scale;
		[DataElement]
		public float Scale
		{
			get {return m_scale;}
			set {Dirty = true; m_scale = value;}
		}

		private int m_health;
		[DataElement]
		public int Health
		{
			get {return m_health;}
			set {Dirty = true; m_health = value;}
		}

		private int m_maxHealth;
		[DataElement]
		public int MaxHealth
		{
			get {return m_maxHealth;}
			set {Dirty = true; m_maxHealth = value;}
		}

		private int m_power;
		[DataElement]
		public int Power
		{
			get {return m_power;}
			set {Dirty = true; m_power = value;}
		}

		private int m_maxPower;
		[DataElement]
		public int MaxPower
		{
			get {return m_maxPower;}
			set {Dirty = true; m_maxPower = value;}
		}

		[DataElement]
		public int SerializedPowerType
		{
			get {return (int)m_powerType;}
			set {m_powerType = (POWERTYPE)value;}
		}

		private POWERTYPE m_powerType;
		public POWERTYPE PowerType
		{
			get {return m_powerType;}
			set {Dirty = true; m_powerType = value;}
		}


		private uint m_zone;
		[DataElement]
		public uint Zone
		{
			get {return m_zone;}
			set {Dirty = true; m_zone = value;}
		}

		private uint m_continent;
		[DataElement]
		public uint Continent
		{
			get {return m_continent;}
			set {Dirty = true; m_continent = value;}
		}

		private Vector m_position = new Vector();
		[DataElement(AllowDbNull = false)]
		public Vector Position
		{
			get {return m_position;}
			set {Dirty = true; m_position = value;}
		}

		private int m_displayID;
		[DataElement]
		public int DisplayID
		{
			get {return m_displayID;}
			set {Dirty = true; m_displayID = value;}
		}

		private int m_baseStrength;
		[DataElement]
		public int BaseStrength
		{
			get {return m_baseStrength;}
			set {Dirty = true; m_baseStrength = value;}
		}

		private int m_baseAgility;
		[DataElement]
		public int BaseAgility
		{
			get {return m_baseAgility;}
			set {Dirty = true; m_baseAgility = value;}
		}

		private int m_baseStamina;
		[DataElement]
		public int BaseStamina
		{
			get {return m_baseStamina;}
			set {Dirty = true; m_baseStamina = value;}
		}

		private int m_baseIntellect;
		[DataElement]
		public int BaseIntellect
		{
			get {return m_baseIntellect;}
			set {Dirty = true; m_baseIntellect = value;}
		}

		private int m_baseSpirit;
		[DataElement]
		public int BaseSpirit
		{
			get {return m_baseSpirit;}
			set {Dirty = true; m_baseSpirit = value;}
		}

		private int m_faction;
		[DataElement]
		public int Faction
		{
			get {return m_faction;}
			set {Dirty = true; m_faction = value;}
		}

		public DBItemTemplate[] StartingItems;
	}*/
}
