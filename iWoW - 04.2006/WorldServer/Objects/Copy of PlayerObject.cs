using System;
using System.Collections;
using WoWDaemon.Common;
using WoWDaemon.Database.DataTables;
using WoWDaemon.Common.Attributes;

namespace WoWDaemon.World
{
	[UpdateObjectAttribute(MaxFields=(int)PLAYERFIELDS.MAX)]
	public class PlayerObject : LivingObject
	{
		protected DBCharacter m_character;
		protected int m_nextLevelExp;
		protected float m_scale;
		protected int m_displayID;
		protected byte m_playerFlags;
		protected ACCESSLEVEL m_accessLevel;
		public PlayerObject(DBCharacter c) : base()
		{
			m_character = c;			
			m_nextLevelExp = c.Level * 1000;
			m_character.Health = c.Health;
			m_character.MaxHealth = c.MaxHealth;
			m_character.Power = c.Power;
			m_character.MaxPower = c.MaxPower;
			m_character.Strength = c.Strength;
			m_character.BaseStrength = c.BaseStrength;
			m_character.Stamina = c.Stamina;
			m_character.BaseStamina = c.BaseStamina;
			m_character.Agility = c.Agility;
			m_character.BaseAgility = c.BaseAgility;
			m_character.Intellect = c.Intellect;
			m_character.BaseIntellect = c.BaseIntellect;
			m_character.Spirit = c.Spirit;
			m_character.BaseSpirit = c.BaseSpirit;
			m_scale = c.Scale;
			m_displayID = c.DisplayID;			
			m_playerFlags = 0;
			m_accessLevel = ACCESSLEVEL.NORMAL;
			Inventory = new PlayerInventory(this);
			if(c.Items != null)
			{
				foreach(DBItem item in c.Items)
					Inventory.CreateItem(item);
			}
			ObjectManager.AddWorldObject(this);
		}

		public uint CharacterID
		{
			get {return m_character.ObjectId;}
		}

		public uint WorldMapID
		{
			get {return m_character.WorldMapID;}
			set {m_character.WorldMapID = value;}
		}

		public uint Continent
		{
			get { return m_character.Continent;}
			set { m_character.Continent = value;}
		}
		
		public uint Zone
		{
			get { return m_character.Zone;}
			set { m_character.Zone = value;}
		}
			
		public ACCESSLEVEL AccessLvl
		{
			get { return m_accessLevel;}
			set { m_accessLevel = value;}
		}


		public override void Save()
		{
			m_character.Items = new DBItem[Inventory.ItemCount];
			int n = 0;
			for(int i = 0;i < Inventory.NumSlots;i++)
			{
				if(Inventory[i] != null)
				{
					Inventory[i].Save();
					m_character.Items[n] = Inventory[i].DBItem;
					n++;
				}
			}
			DBManager.SaveDBObject(m_character);			
		}

		public override void SaveAndRemove()
		{
			if(this.MapTile != null)
				MapTile.Map.Leave(this);
			m_character.Items = new DBItem[Inventory.ItemCount];
			int n = 0;
			for(int i = 0;i < Inventory.NumSlots;i++)
			{
				if(Inventory[i] != null)
				{
					Inventory[i].SaveAndRemove();
					m_character.Items[n] = Inventory[i].DBItem;
					n++;
				}
			}
			DBManager.SaveDBObject(m_character);
			DBManager.RemoveDBObject(m_character);
			ObjectManager.RemoveWorldObject(this);
		}

		public override string Name
		{
			get
			{
				return m_character.Name;
			}
		}



		#region Object Properties
		public override Vector Position
		{
			get {return m_character.Position;}
			set {m_character.Position = value;}
		}

		public override float Facing
		{
			get {return m_character.Facing;}
			set {m_character.Facing = value;}
		}


		public override uint MovementFlags
		{
			get {return 0;}
			set {}
		}

		public override OBJECTTYPE ObjectType
		{
			get { return OBJECTTYPE.PLAYER;}
		}
		#endregion

		public override void PreCreateObject(bool isClient)
		{
			base.PreCreateObject (isClient);
			UpdateValue(PLAYERFIELDS.BYTES_1);
			UpdateValue(PLAYERFIELDS.BYTES_2);
			Inventory.PreCreateOwner(isClient);
			if(isClient)
			{
				UpdateValue(UNITFIELDS.TARGET);
				UpdateValue(PLAYERFIELDS.SELECTION);
				UpdateValue(PLAYERFIELDS.XP);
				UpdateValue(PLAYERFIELDS.NEXTLEVEL_XP);
			}
		}

		#region OBJECTFIELDS
		public override ulong GUID
		{
			get { return m_character.ObjectId;}
		}

		public override float Scale
		{
			get {return m_scale;}
			set
			{
				m_scale = value;
				UpdateValue(OBJECTFIELDS.SCALE);
			}
		}

		public override HIER_OBJECTTYPE HierType
		{
			get {return HIER_OBJECTTYPE.PLAYER;}
		}
		#endregion

		#region UNITFIELDS
		public override int Health
		{
			get {return m_character.Health;}
			set {m_character.Health = value;UpdateValue(UNITFIELDS.HEALTH);}
		}

		public override int MaxHealth
		{
			get {return m_character.MaxHealth;}
			set {m_character.MaxHealth = value;UpdateValue(UNITFIELDS.MAX_HEALTH);}
		}

		public override POWERTYPE PowerType
		{
			get {return m_character.PowerType;}
			set {m_character.PowerType = value;UpdateValue(UNITFIELDS.BYTES_0);}
		}

		public override int Power
		{
			get {return m_character.Power;}
			set {m_character.Power = value; UpdateValue(UNITFIELDS.POWER0+(int)m_character.PowerType);}
		}

		public override int MaxPower
		{
			get {return m_character.MaxPower;}
			set {m_character.MaxPower = value;UpdateValue(UNITFIELDS.MAX_POWER0+(int)m_character.PowerType);}
		}

		[UpdateValueAttribute(UNITFIELDS.BYTES_0, BytesIndex=0)]
		public RACE Race
		{
			get {return m_character.Race;}
		}
		[UpdateValueAttribute(UNITFIELDS.BYTES_0, BytesIndex=1)]
		public CLASS Class
		{
			get {return m_character.Class;}
		}
        
		[UpdateValueAttribute(UNITFIELDS.BYTES_0, BytesIndex=2)]
		public byte Gender
		{
			get {return m_character.Gender;}
		}

		public override int Level
		{
			get {return m_character.Level;}
			set {m_character.Level = (byte)value;UpdateValue(UNITFIELDS.LEVEL);}
		}

		public override int BaseStrength
		{
			get { return m_character.BaseStrength;}
			set { m_character.BaseStrength = value;UpdateValue(PLAYERFIELDS.BASE_STRENGTH);}
		}

		public override int BaseAgility
		{
			get {return m_character.BaseAgility;}
			set {m_character.BaseAgility = value; UpdateValue(PLAYERFIELDS.BASE_AGILITY);}
		}

		public override int BaseStamina
		{
			get	{return m_character.BaseStamina;}
			set {m_character.BaseStamina = value;UpdateValue(PLAYERFIELDS.BASE_STAMINA);}
		}

		public override int BaseIntellect
		{
			get {return m_character.BaseIntellect;}
			set {m_character.BaseIntellect = value;UpdateValue(PLAYERFIELDS.BASE_INTELLECT);}
		}

		public override int BaseSpirit
		{
			get	{return m_character.BaseSpirit;}
			set {m_character.BaseSpirit = value;UpdateValue(PLAYERFIELDS.BASE_SPIRIT);}
		}

		public override int Strength
		{
			get {return m_character.Strength;}
			set {m_character.Strength = value;UpdateValue(PLAYERFIELDS.STRENGTH);}
		}

		public override int Agility
		{
			get {return m_character.Agility;}
			set {m_character.Agility = value;UpdateValue(PLAYERFIELDS.AGILITY);}
		}

		public override int Stamina
		{
			get {return m_character.Stamina;}
			set {m_character.Stamina = value;UpdateValue(PLAYERFIELDS.STAMINA);}
		}

		public override int Intellect
		{
			get {return m_character.Intellect;}
			set {m_character.Intellect = value;UpdateValue(PLAYERFIELDS.INTELLECT);}
		}

		public override int Spirit
		{
			get {return m_character.Spirit;}
			set {m_character.Spirit = value;UpdateValue(PLAYERFIELDS.SPIRIT);}
		}

		public override int Resist_Physical
		{
			get {return m_character.Resist_Physical;}
			set {m_character.Resist_Physical = value;UpdateValue(PLAYERFIELDS.RESIST_PHYSICAL);}
		}

		public override int Resist_Holy
		{
			get {return m_character.Resist_Holy;}
			set {m_character.Resist_Holy = value;UpdateValue(PLAYERFIELDS.RESIST_HOLY);}
		}

		public override int Resist_Fire
		{
			get {return m_character.Resist_Fire;}
			set {m_character.Resist_Fire = value;UpdateValue(PLAYERFIELDS.RESIST_FIRE);}
		}

		public override int Resist_Nature
		{
			get {return m_character.Resist_Nature;}
			set {m_character.Resist_Nature = value;UpdateValue(PLAYERFIELDS.RESIST_NATURE);}
		}

		public override int Resist_Frost
		{
			get {return m_character.Resist_Frost;}
			set {m_character.Resist_Frost = value;UpdateValue(PLAYERFIELDS.RESIST_FROST);}
		}

		public override int Resist_Shadow
		{
			get {return m_character.Resist_Shadow;}
			set {m_character.Resist_Shadow = value;UpdateValue(PLAYERFIELDS.RESIST_SHADOW);}
		}

		public override int AttackPower
		{
			get {return m_character.AttackPower;}
			set {m_character.AttackPower = value;UpdateValue(PLAYERFIELDS.ATTACKPOWER);}
		}

		public override int AttackPowerModifier
		{
			get {return m_character.AttackPowerModifier;}
			set {m_character.AttackPowerModifier = value;UpdateValue(PLAYERFIELDS.ATTACKPOWERMODIFIER);}
		}
	
		public override int Money
		{
			get {return m_character.Money;}
			set {m_character.Money = value;UpdateValue(PLAYERFIELDS.COINAGE);}
		}

		public override int DisplayID
		{
			get { return m_displayID;}
			set {m_displayID = value;UpdateValue(UNITFIELDS.DISPLAYID);}
		}

		public override int Faction
		{
			get {return m_character.Faction;}
			set {m_character.Faction = value;UpdateValue(UNITFIELDS.FACTION);}
		}

		[UpdateValueAttribute(UNITFIELDS.TARGET)]
		protected ulong m_target = 0;
		
		public ulong Target
		{
			get {return m_target;}
			set { UpdateValue(UNITFIELDS.TARGET); m_target = value;}
		}
		#endregion

		#region PLAYERFIELDS
		[UpdateValueAttribute(PLAYERFIELDS.XP)]
		public int Exp
		{
			get { return m_character.Exp;}
			set
			{
				m_character.Exp = value;
				UpdateValue(PLAYERFIELDS.XP);
			}
		}

		[UpdateValueAttribute(PLAYERFIELDS.NEXTLEVEL_XP)]
		public int NextLevelExp
		{
			get { return m_nextLevelExp;}
			set { UpdateValue(PLAYERFIELDS.NEXTLEVEL_XP); m_nextLevelExp = value;}
		}

		public override int SkillPoints
		{
			get { return m_character.SkillPoints;}
			set { UpdateValue(PLAYERFIELDS.SKILL_POINTS); m_character.SkillPoints = value;}
		}

		public override int TalentPoints
		{
			get { return m_character.TalentPoints;}
			set { UpdateValue(PLAYERFIELDS.TALENT_POINTS); m_character.TalentPoints = value;}
		}

		public override uint GuildID
		{
			get { return m_character.GuildID;}
			set { UpdateValue(PLAYERFIELDS.GUILD_ID); m_character.GuildID = value;}
		}

		public override uint GuildRank
		{
			get { return m_character.GuildRank;}
			set { UpdateValue(PLAYERFIELDS.GUILD_RANK); m_character.GuildRank = value;}
		}

		[UpdateValueAttribute(PLAYERFIELDS.BYTES_1, BytesIndex=0)]
		public byte Skin
		{
			get { return m_character.Skin;}
		}

		[UpdateValueAttribute(PLAYERFIELDS.BYTES_1, BytesIndex=1)]
		public byte Face
		{
			get { return m_character.Face;}
		}

		[UpdateValueAttribute(PLAYERFIELDS.BYTES_1, BytesIndex=2)]
		public byte HairStyle
		{
			get { return m_character.HairStyle;}
		}

		[UpdateValueAttribute(PLAYERFIELDS.BYTES_1, BytesIndex=3)]
		public byte HairColor
		{
			get { return m_character.HairColor;}
		}

		[UpdateValueAttribute(PLAYERFIELDS.BYTES_2, BytesIndex=0)]
		public byte PlayerFlags
		{
			get { return m_playerFlags;}
			set { UpdateValue(PLAYERFIELDS.BYTES_2); m_playerFlags = value;}
		}

		[UpdateValueAttribute(PLAYERFIELDS.BYTES_2, BytesIndex=1)]
		public byte FacialHairStyle
		{
			get { return m_character.FacialHairStyle;}
		}

		[UpdateValueAttribute(PLAYERFIELDS.BYTES_2, BytesIndex=2)]
		public byte NumBankSlots
		{
			get { return 0;}
		}

		[UpdateValueAttribute(PLAYERFIELDS.BYTES_2, BytesIndex=3)]
		public RESTEDSTATE RestedState
		{
			get { return m_character.RestedState;}
			set { UpdateValue(PLAYERFIELDS.BYTES_2); m_character.RestedState = value;}
		}

		[UpdateValueAttribute(PLAYERFIELDS.SELECTION)]
		protected ulong m_selection;
		WorldObject m_SelectedObject = null;
		public WorldObject Selection
		{
				get { return m_SelectedObject;}
			set
			{
				UpdateValue(PLAYERFIELDS.SELECTION);
				m_SelectedObject = value;
				if(m_SelectedObject != null)
					m_selection = m_SelectedObject.GUID;
			}
		}


		[UpdateValueAttribute]
		public readonly PlayerInventory Inventory;
		#endregion
/*		#region SMSG
		public override int RunSpeed
			{
			get {return m_runspeed;}
			set {m_runspeed = value;UpdateValue(SMSG.MOVE_SET_WALK_SPEED_CHEAT);}
			}
		#endregion*/


	}
 }
