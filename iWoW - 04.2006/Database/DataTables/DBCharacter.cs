using System;
using WoWDaemon.Common;
using WoWDaemon.Database;
using WoWDaemon.Common.Attributes;

namespace WoWDaemon.Database.DataTables
{

	/// <summary>
	/// Summary description for Character.
	/// </summary>
	[DataTable(TableName="Character")]
	public class DBCharacter : DBObject
	{
		[PrimaryKey(Name="Name")]
		private string m_name;
		[DataElement(Name="Level")]
		private byte m_level;
		[DataElement(Name="Race")]
		private RACE m_race;
		[DataElement(Name="Class")]
		private CLASS m_class;
		[DataElement(Name="Gender")]
		private byte m_gender;
		[DataElement(Name="Skin")]
		private byte m_skin;
		[DataElement(Name="Face")]
		private byte m_face;
		[DataElement(Name="HairStyle")]
		private byte m_hairStyle;
		[DataElement(Name="HairColor")]
		private byte m_hairColor;
		[DataElement(Name="FacialHairStyle")]
		private byte m_facialHairStyle;
		[DataElement(Name="WorldMapID")]
		private uint m_worldmapID;
		[DataElement(Name="Zone")]
		private uint m_zone;
		[DataElement(Name="Continent")]
		private uint m_continent;
		[DataElement(Name="Position")]
		private Vector m_position = new Vector();
		[DataElement(Name="Facing")]
		private float m_facing;
		[DataElement(Name="RestedState")]
		private RESTEDSTATE m_restedState = RESTEDSTATE.NORMAL;
		[DataElement(Name="AccountID", AllowDbNull=false)]
		private uint m_accountID;
		[DataElement(Name="CreationDate", AllowDbNull=false)]
		private DateTime m_creationDate = DateTime.Now;
		[DataElement(Name="Scale")]
		private float m_scale;
		[DataElement(Name="Health")]
		private int m_health;
		[DataElement(Name="MaxHealth")]
		private int m_maxHealth;
		[DataElement(Name="Power")]
		private int m_power;
		[DataElement(Name="MaxPower")]
		private int m_maxPower;
		[DataElement(Name="AttackPower")]
		private int m_attackpower;
		[DataElement(Name="AttackPowerModifier")]
		private int m_attackpowermodifier;
		[DataElement(Name="PowerType")]
		private POWERTYPE m_powerType;
		[DataElement(Name="Strength")]
		private int m_Strength;
		[DataElement(Name="BaseStrength")]
		private int m_baseStrength;
		[DataElement(Name="BaseAgility")]
		private int m_baseAgility;
		[DataElement(Name="Agility")]
		private int m_Agility;
		[DataElement(Name="BaseStamina")]
		private int m_baseStamina;
		[DataElement(Name="Stamina")]
		private int m_Stamina;
		[DataElement(Name="BaseIntellect")]
		private int m_baseIntellect;
		[DataElement(Name="Intellect")]
		private int m_Intellect;
		[DataElement(Name="BaseSpirit")]
		private int m_baseSpirit;
		[DataElement(Name="Spirit")]
		private int m_Spirit;
		[DataElement(Name="Resist_Physical")]
		private int m_resist_physical;
		[DataElement(Name="Resist_Holy")]
		private int m_resist_holy;
		[DataElement(Name="Resist_Fire")]
		private int m_resist_fire;
		[DataElement(Name="Resist_Nature")]
		private int m_resist_nature;
		[DataElement(Name="Resist_Frost")]
		private int m_resist_frost;
		[DataElement(Name="Resist_Shadow")]
		private int m_resist_shadow;
		[DataElement(Name="Faction")]
		private int m_faction;
		[DataElement(Name="SkillPoints")]
		private int m_SkillPoints;
		[DataElement(Name="TalentPoints")]
		private int m_TalentPoints;
		[DataElement(Name="GuildID")]
		private uint m_guildid;
		[DataElement(Name="GuildRank")]
		private uint m_guildrank;
		[DataElement(Name="GuildName")]
		private string m_guildname=" ";
		[DataElement(Name="GuildTimeStamp")]
		private uint m_guildtimestamp=0;
		[DataElement(Name="Money")]
		private int m_money;
		[DataElement(Name="DisplayID")]
		private int m_displayID;
		[DataElement(Name="Exp")]
		private int m_exp;
		[DataElement(Serialize=false)]
		public string UIConfig0 = string.Empty;
		[DataElement(Serialize=false)]
		public string UIConfig1 = string.Empty;
		[DataElement(Serialize=false)]
		public string UIConfig2 = string.Empty;
		[DataElement(Serialize=false)]
		public string UIConfig3 = string.Empty;
		[DataElement(Serialize=false)]
		public string UIConfig4 = string.Empty;
        [DataElement(Serialize = false)]
        public string UIConfig6 = string.Empty;
		[DataElement(Serialize = false)]
		public string UIConfig7 = string.Empty;


		static bool m_autosave = true;

		public ulong Selected = 0;

		#region Character screen data
		public string Name
		{
			get {return m_name;}
			set {Dirty = true; m_name = value;}
		}

		public byte Level
		{
			get {return m_level;}
			set {Dirty = true; m_level = value;}
		}

		public RACE Race
		{
			get {return m_race;}
			set {Dirty = true; m_race = value;}
		}

		public CLASS Class
		{
			get {return m_class;}
			set {Dirty = true; m_class = value;}
		}

		public byte Gender
		{
			get {return m_gender;}
			set {Dirty = true; m_gender = value;}
		}

		public byte Skin
		{
			get {return m_skin;}
			set {Dirty = true; m_skin = value;}
		}

		public byte Face
		{
			get {return m_face;}
			set {Dirty = true; m_face = value;}
		}

		public byte HairStyle
		{
			get {return m_hairStyle;}
			set {Dirty = true; m_hairStyle = value;}
		}

		public byte HairColor
		{
			get {return m_hairColor;}
			set {Dirty = true; m_hairColor = value;}
		}

		public byte FacialHairStyle
		{
			get {return m_facialHairStyle;}
			set {Dirty = true; m_facialHairStyle = value;}
		}

		public uint Zone
		{
			get {return m_zone;}
			set {Dirty = true; m_zone = value;}
		}

		public uint Continent
		{
			get {return m_continent;}
			set {Dirty = true; m_continent = value;}
		}

		public Vector Position
		{
			get {return m_position;}
			set {Dirty = true; m_position = value;}
		}

		public RESTEDSTATE RestedState
		{
			get {return m_restedState;}
			set {Dirty = true; m_restedState = value;}
		}
		/*
				public uint GuildRank
				{
					get {return m_GuildRank;}
					set {Dirty = true; m_GuildID = value;}
				}*/
		#endregion

		public uint WorldMapID
		{
			get { return m_worldmapID;}
			set { Dirty = true; m_worldmapID = value;}
		}

		public uint AccountID
		{
			get {return m_accountID;}
			set {Dirty = true; m_accountID = value;}
		}

		public DateTime CreationDate
		{
			get {return m_creationDate;}
			set {Dirty = true; m_creationDate = value;}
		}

		public override bool AutoSave
		{
			get {return m_autosave;}
			set {m_autosave = value;}
		}

		public float Facing
		{
			get {return m_facing;}
			set {Dirty = true; m_facing = value;}
		}

		public float Scale
		{
			get {return m_scale;}
			set {Dirty = true; m_scale = value;}
		}

		public int Health
		{
			get {return m_health;}
			set {Dirty = true; m_health = value;}
		}

		public int MaxHealth
		{
			get {return m_maxHealth;}
			set {Dirty = true; m_maxHealth = value;}
		}

		public int Power
		{
			get {return m_power;}
			set {Dirty = true; m_power = value;}
		}

		public int MaxPower
		{
			get {return m_maxPower;}
			set {Dirty = true; m_maxPower = value;}
		}

		public POWERTYPE PowerType
		{
			get {return m_powerType;}
			set {Dirty = true; m_powerType = value;}
		}

		public int BaseStrength
		{
			get {return m_baseStrength;}
			set {Dirty = true; m_baseStrength = value;}
		}

		public int Strength
		{
			get {return m_Strength;}
			set {Dirty = true; m_Strength = value;}
		}

		public int BaseAgility
		{
			get {return m_baseAgility;}
			set {Dirty = true; m_baseAgility = value;}
		}

		public int Agility
		{
			get {return m_Agility;}
			set {Dirty = true; m_Agility = value;}
		}

		public int BaseStamina
		{
			get {return m_baseStamina;}
			set {Dirty = true; m_baseStamina = value;}
		}

		public int Stamina
		{
			get {return m_Stamina;}
			set {Dirty = true; m_Stamina = value;}
		}

		public int BaseIntellect
		{
			get {return m_baseIntellect;}
			set {Dirty = true; m_baseIntellect = value;}
		}

		public int Intellect
		{
			get {return m_Intellect;}
			set {Dirty = true; m_Intellect = value;}
		}

		public int BaseSpirit
		{
			get {return m_baseSpirit;}
			set {Dirty = true; m_baseSpirit = value;}
		}

		public int Spirit
		{
			get {return m_Spirit;}
			set {Dirty = true; m_Spirit = value;}
		}

		public int Faction
		{
			get {return m_faction;}
			set {Dirty = true; m_faction = value;}
		}

		public int AttackPower
		{
			get {return m_attackpower;}
			set {Dirty = true; m_attackpower = value;}
		}

		public int AttackPowerModifier
		{
			get {return m_attackpowermodifier;}
			set {Dirty = true; m_attackpowermodifier = value;}
		}

		public int Resist_Physical
		{
			get {return m_resist_physical;}
			set {Dirty = true; m_resist_physical = value;}
		}

		public int Resist_Holy
		{
			get {return m_resist_holy;}
			set {Dirty = true; m_resist_holy = value;}
		}

		public int Resist_Fire
		{
			get {return m_resist_fire;}
			set {Dirty = true; m_resist_fire = value;}
		}

		public int Resist_Nature
		{
			get {return m_resist_nature;}
			set {Dirty = true; m_resist_nature = value;}
		}

		public int Resist_Frost
		{
			get {return m_resist_frost;}
			set {Dirty = true; m_resist_frost = value;}
		}

		public int Resist_Shadow
		{
			get {return m_resist_shadow;}
			set {Dirty = true; m_resist_shadow = value;}
		}

		public int SkillPoints
		{
			get {return m_SkillPoints;}
			set {Dirty = true; m_SkillPoints = value;}
		}

		public int TalentPoints
		{
			get {return m_TalentPoints;}
			set {Dirty = true; m_TalentPoints = value;}
		}

		public int Money
		{
			get {return m_money;}
			set {Dirty = true; m_money = value;}
		}

		public uint GuildID
		{
			get {return m_guildid;}
			set {Dirty = true; m_guildid = value;}
		}

		public uint GuildRank
		{
			get {return m_guildrank;}
			set {Dirty = true; m_guildrank = value;}
		}

		public string GuildName
		{
			get {return m_guildname;}
			set {Dirty = true; m_guildname = value;}
		}
			
		public uint GuildTimeStamp
		{
			get {return m_guildtimestamp;}
			set {Dirty = true; m_guildtimestamp = value;}
		}

		public int DisplayID
		{
			get {return m_displayID;}
			set {Dirty = true; m_displayID = value;}
		}

		public int Exp
		{
			get {return m_exp;}
			set {Dirty = true; m_exp = value;}
		}

		public uint TradeItemCount=0;

		public uint TradeMoney=0;
		
		public bool TradeCompleted=false;
		
		public uint LastTradeID=0;
		
		public uint LastGuildID=0;

		public uint LastGuildInviterID=0;

		public byte GroupLook=0;

		public uint LastGroupInviterID=0;

		public void SerializeItems(BinWriter data)
		{
			if(Items == null)
			{
				data.Write(0);
				return;
			}
			data.Write(Items.Length);
			foreach(DBItem item in Items)
			{
				data.Write(item.ObjectId);
				item.Serialize(data);
			}
		}


		[Relation(LocalField="ObjectId", RemoteField="CharacterID", AutoLoad=true, AutoDelete=false)]
		public DBKnownQuest[] Quest=null;
		
		[Relation(LocalField="ObjectId", RemoteField="CharacterID", AutoLoad=true, AutoDelete=false)]
		public DBKnownTalents[] Talents=null;
		
		[Relation(LocalField="ObjectId", RemoteField="OwnerID", AutoLoad=true, AutoDelete=true)]
		public DBItem[] Items = null;

		[Relation(LocalField="ObjectId", RemoteField="CharacterID", AutoLoad=true, AutoDelete=false)]
		public DBKnownSpell[] Spells=null;

//		[Relation(LocalField="GuildID", RemoteField="Guild_ID", AutoLoad=true, AutoDelete=false)]
		public DBGuild Guild=null;

		[Relation(LocalField="ObjectId", RemoteField="Owner_ID", AutoLoad=true, AutoDelete=true)]
		public DBFriendList[] Friends=null;

		[Relation(LocalField="ObjectId", RemoteField="Friend_ID", AutoLoad=true, AutoDelete=true)]
		public DBFriendList[] OnFriends=null;

		


		public DBCharacter()
		{

		}

	}
}
