	using System;
using System.Threading;
using HelperTools;
using System.Collections;
using Server.Items;
using System.Reflection;
using System.Diagnostics;
using System.IO;
//using Server.Scripts.Properties;
#region IMPORTANT TO ADD
/*
yesterday I've played with Unit DynamicFlags and found some features:
- flag 1 (bit 0) - unit has loot inside
- flag 4 (bit 2) - unit was attacked by someone (gray caption)
- flag 16 (bit 4) - unit has 'Beast Lore' applied (it tooltip shows damage, health, etc.)
- flag 32 (bit 5) - unit is dead (force unit to lie on ground with 'Dead' sign on it's caption)
 */

#endregion
namespace Server
{
	#region Volhv Addons: 24.09.05

	#region Gossip Menu
	public enum GMenuIcons: byte
	{
		Gossip = 0x00,
		Vendor = 0x01,
		Taxi = 0x02,
		Trainer = 0x03,
		Healer = 0x04,
		Binder = 0x05,
		Banker = 0x06,
		Petition = 0x07,
		Tabard = 0x08,
		Battlemaster = 0x09,
		Auctioneer = 0x0A,
		Gossip2 = 0x0B,
		Gossip3 = 0x0C
	}
	public struct GMenuItem
	{
		private uint _menuId;
		private GMenuIcons _icon;
		private bool _inputBox;
		private string _text;
		public GMenuItem( uint menuId, GMenuIcons icon, bool inputBox, string text )
		{
			_menuId = menuId; _icon = icon; _inputBox = inputBox; _text = text;
		}
		public uint MenuId { get { return _menuId; } }
		public byte Icon { get { return (byte)_icon; } }
		public byte InputBox { get { return (byte)(_inputBox ? 0x01 : 0x00); } }
		public string Text { get { return _text; } }
	}
	public class GMenu
	{
		private ArrayList list = new ArrayList();
		public GMenu() {}
		public GMenu( uint menuId, GMenuIcons icon, bool inputBox, string text ) 
		{
			Add( menuId, icon, inputBox, text );
		}
		public GMenu( GMenuItem item )
		{ 
			Add( item ); 
		}
		public void Add( uint menuId, GMenuIcons icon, bool inputBox, string text )
		{
			list.Add( new GMenuItem( menuId, icon, inputBox, text ) );            
		}
		public void Add( GMenuItem item )
		{
			list.Add( item );
		}
		public int Count { get { return list.Count; } }
		public GMenuItem[] Items
		{
			get { return (GMenuItem[])list.ToArray( typeof( GMenuItem ) ); }
		}
	}
	#endregion

	#region Gossip Quest menu
	public struct GQMenuItem
	{
		private uint _menuId;
		private DialogStatus _icon;
		private string _text;
		public GQMenuItem( uint menuId, DialogStatus icon, string text )
		{
			_menuId = menuId; _icon = icon; _text = text;
		}
		public uint MenuId { get { return _menuId; } }
		public byte Icon { get { return (byte)_icon; } }
		public string Text { get { return _text; } }
	}
	public class GQMenu
	{
		private ArrayList list = new ArrayList();
		public GQMenu() {}
		public GQMenu( uint menuId, DialogStatus icon, string text ) 
		{
			Add( menuId, icon, text );
		}
		public GQMenu( GQMenuItem item )
		{ 
			Add( item ); 
		}
		public void Add( uint menuId, DialogStatus icon, string text )
		{
			list.Add( new GQMenuItem( menuId, icon, text ) );            
		}
		public void Add( GQMenuItem item )
		{
			list.Add( item );
		}
		public int Count { get { return list.Count; } }
		public GQMenuItem[] Items
		{
			get { return (GQMenuItem[])list.ToArray( typeof( GQMenuItem ) ); }
		}
	}
	#endregion

	#region Emote, qEmote

	public enum Emote: int
	{
		ONESHOT_NONE					= 0,
		ONESHOT_TALK					= 1,	//DNR by Wad
		ONESHOT_BOW						= 2,
		ONESHOT_WAVE					= 3,	//DNR by Wad
		ONESHOT_CHEER					= 4,	//DNR by Wad
		ONESHOT_EXCLAMATION				= 5,	//DNR by Wad
		ONESHOT_QUESTION				= 6,
		ONESHOT_EAT						= 7,
		STATE_DANCE						= 10,
		ONESHOT_LAUGH					= 11,
		STATE_SLEEP						= 12,
		STATE_SIT						= 13,
		ONESHOT_RUDE					= 14,	//DNR by Wad
		ONESHOT_ROAR					= 15,	//DNR by Wad
		ONESHOT_KNEEL					= 16,
		ONESHOT_KISS					= 17,
		ONESHOT_CRY						= 18,
		ONESHOT_CHICKEN					= 19,
		ONESHOT_BEG						= 20,
		ONESHOT_APPLAUD					= 21,
		ONESHOT_SHOUT					= 22,	//DNR by Wad
		ONESHOT_FLEX					= 23,
		ONESHOT_SHY						= 24,	//DNR by Wad
		ONESHOT_POINT					= 25,	//DNR by Wad
		STATE_STAND						= 26,
		STATE_READYUNARMED				= 27,
		STATE_WORK						= 28,
		STATE_POINT						= 29,	//DNR by Wad
		STATE_NONE						= 30,
		ONESHOT_WOUND					= 33,
		ONESHOT_WOUNDCRITICAL			= 34,
		ONESHOT_ATTACKUNARMED			= 35,
		ONESHOT_ATTACK1H				= 36,
		ONESHOT_ATTACK2HTIGHT			= 37,
		ONESHOT_ATTACK2HLOOSE			= 38,
		ONESHOT_PARRYUNARMED			= 39,
		ONESHOT_PARRYSHIELD				= 43,
		ONESHOT_READYUNARMED			= 44,
		ONESHOT_READY1H					= 45,
		ONESHOT_READYBOW				= 48,
		ONESHOT_SPELLPRECAST			= 50,
		ONESHOT_SPELLCAST				= 51,
		ONESHOT_BATTLEROAR				= 53,
		ONESHOT_SPECIALATTACK1H			= 54,
		ONESHOT_KICK					= 60,
		ONESHOT_ATTACKTHROWN			= 61,
		STATE_STUN						= 64,
		STATE_DEAD						= 65,
		ONESHOT_SALUTE					= 66,
		STATE_KNEEL						= 68,
		STATE_USESTANDING				= 69,
		ONESHOT_WAVE_NOSHEATHE			= 70,
		ONESHOT_CHEER_NOSHEATHE			= 71,
		ONESHOT_EAT_NOSHEATHE			= 92,
		STATE_STUN_NOSHEATHE			= 93,
		ONESHOT_DANCE					= 94,
		ONESHOT_SALUTE_NOSHEATH			= 113,
		STATE_USESTANDING_NOSHEATHE		= 133,
		ONESHOT_LAUGH_NOSHEATHE			= 153,
		STATE_WORK_NOSHEATHE			= 173,
		STATE_SPELLPRECAST				= 193,
		ONESHOT_READYRIFLE				= 213,
		STATE_READYRIFLE				= 214,
		STATE_WORK_NOSHEATHE_MINING		= 233,
		STATE_WORK_NOSHEATHE_CHOPWOOD	= 234,
		zzOLDONESHOT_LIFTOFF			= 253,
		ONESHOT_LIFTOFF					= 254,
		ONESHOT_YES						= 273,	//DNR by Wad
		ONESHOT_NO						= 274,	//DNR by Wad
		ONESHOT_TRAIN					= 275,	//DNR by Wad
		ONESHOT_LAND					= 293,
		STATE_READY1H					= 333,
		STATE_AT_EASE					= 313,
		STATE_SPELLKNEELSTART			= 353,
		STATE_SUBMERGED					= 373,
		ONESHOT_SUBMERGE				= 374	
	}

	public struct qEmote
	{
		private Emote _emote;
		private int _delay;
		public qEmote( Emote e, int msec_delay )
		{
			_emote = e;
			_delay = msec_delay;
		}
		/// <summary>
		/// Emote
		/// </summary>
		public Emote emote { get { return _emote; } }
		/// <summary>
		/// Delay ( msecs )
		/// </summary>
		public int Delay { get { return _delay; } }
	}

	#endregion

	#endregion
	#region Added Volhv (enums): 02.10.05
	public enum qInvalidReason
	{
		DontHaveReq				= 0x00,// default: 'You don',27h,'t meet the requirements for that quest'
		NotEnoughLevel			= 0x01,// 0x01: 'You are not high enough level for that quest.'
		NotAvailableRace		= 0x06,// 0x06: 'That quest is not available to your race'
		ReadyHaveTimedQuest		= 0x0C,// 0x0C: 'You can only be on one timed quest at a time'
		ReadyHaveThatQuest		= 0x0D,// 0x0D: 'You are already on that quest'
		DontHaveReqItems		= 0x13,// 0x13: 'You don',27h,'t have the required items with you.  Check storage.'
		DontHaveReqMoney		= 0x15 // 0x15: 'You don',27h,'t have enough money for that quest'
	}

	public enum qFailedReason
	{
		Failed					= 0x00,// default: '%s failed.'
		InventoryFull			= 0x04,// 0x04: '%s failed: Inventory is full.'
		DupeItemFound			= 0x10 // 0x10: '%s failed: Duplicate item found.'
		//	0x31: '%s failed: Inventory is full.'
	}
	#endregion
	#region Debug Events (Delegates activate only "#IF VOLHV" ): 04.10.05
#if VOLHV
	public delegate bool debugEvent( params object[] list );
#endif
	#endregion
	#region ENUMS
	public enum Races
	{
		Human = 1,
		Dwarf = 3,
		NightElf = 4,
		Gnome = 7,
		Orc = 2,
		Undead = 5,
		Tauren = 6,
		Troll = 8
	}
	public enum Classes
	{
		Warrior =		1,
		Paladin =		2,
		Hunter =		3,
		Rogue =			4,
		Priest =		5,
		Shaman =		7,
		Mage =			8,
		Warlock =		9,
		Druid =			0x0B
	}

	#endregion

	#region DELEGATES
	public delegate bool CharacterHandler( Character c );
	public delegate bool CharacterChooseRace( Character c, Races r );
	public delegate bool CharacterCommandHandler( Character c, string cmd );
	public delegate bool SpellHandler( Mobile c, int spell, Object target );
	public delegate bool LearnProfession( Character c, ProfessionLevels level, Professions type );
	public delegate bool LevelUp( Character c, int level, ref int gainHp, ref int gainMana, ref float gainStrength, ref float gainAgility, ref float gainStamina, ref float gainInt, ref float gainSpirit );
	public delegate bool EveryHeartBeat( Character c );	
	public delegate int SpellPrice( Character c, int id );
	public delegate int CraftLevelRequesite( Character c, int id );
	public delegate int CraftSkillPrerequesite( Character c, int id );	
	public delegate float SkillProgressFactorHandler( Mobile m, int val, int skillid );	
	public delegate void CharacterReclaimCorps( Character c );
	public delegate void AreaTrigger( Character c, int areaId );
	
	#endregion

	/// <summary>
	/// Description of Character.	
	/// </summary>
	public class Character : Mobile
	{
		#region CUSTOM_HANDLER
		public static CharacterHandler onLogin;
		public static CharacterHandler onLogout;
		public static CharacterHandler onTrainningAck;
		public static CharacterHandler onCreateCharacter;
		public static CharacterChooseRace onCharacterChooseRace;
		
		public static CharacterCommandHandler onCommand;
		public static LearnProfession onLearn;
		public static LevelUp onLevelUp;
		public static EveryHeartBeat onHeartBeat;
		public static SpellPrice onSpellPrice;
		public static CraftLevelRequesite onCraftLevelRequesite;
		public static CraftSkillPrerequesite onCraftSkillPrerequesite;
		public static SkillProgressFactorHandler onSkillProgressFactor;
		public static CharacterReclaimCorps onCharacterReclaimCorps;
		public static CharacterReclaimCorps onCharacterRepop;

		public static AreaTrigger onAreaTrigger;

		#endregion

		#region PROPERTIES
		Hashtable reputationAdjustments = new Hashtable();
		bool pvpActive;
		public static ArrayList allCharacters = new ArrayList();
		public static int decal = 0;
		public ArrayList friends = new ArrayList();
		Races race;
		//Classes classe;
		byte gender;
		byte skin;
		byte face;
		byte hairStyle;
		byte hairColour;
		byte facialHair;
		int ammoType;
		ArrayList actionBar = new ArrayList();		
		UInt64 target;
		uint copper;
		//
		InternalHeartBeatTimer internalTimer;		
		Account account;
		int sheathed;
		float CorpseLocationX;
		float CorpseLocationY;
		float CorpseLocationZ;
		ushort CorpseMapId;
		float bindingPointX;
		float bindingPointY;
		float bindingPointZ;
		UInt16 bindingPointMapId;
		UInt64 corpsGuid;
		uint []zones = new uint[ 32 ];
		Position mark;
		int []petActions;

		//	dynamic, pas de serialisation
		int linkedSpawner = -1;
		Object selection;
		Object currentObjectLooted;
		UInt64 lootOwner;
		public Trajet path;
		public bool logged = false;
		ActiveQuest []activeQuests = new ActiveQuest[ 20 ];
		Hashtable questsDone = new Hashtable();
		Character tradingWith;
		int tradeState;
		int []tradeItems = new int[ 7 ];
		int tradeGold;
		int tradeNum;
		#region TAXI 
		public uint[] TaxiField = new uint[8]; 
		public int TaxiPrice; 
		public bool taxiOn; 
		public TaxiNode to;
		#endregion 
		public HonorUnit Honor;
		#endregion		

		#region ACCESSORS	
		public int LinkedSpawner
		{
			get { return linkedSpawner; }
			set { linkedSpawner = value; }
		}
		public WowTimer FirstCombatTimer
		{
			get { return this.firstHitCombatTimer; }
		
		}
		public WowTimer SecondCombatTimer
		{
			get { return this.combatTimer; }
		
		}
		public Hashtable ReputationAdjustments
		{
			get { return reputationAdjustments; }
		}
		public ArrayList ActionBar
		{
			get { return actionBar; }
		}
		public bool PvpActive
		{
			get { return pvpActive; }
			set { pvpActive = value; }
		}
		public Object CurrentObjectLooted
		{
			get { return currentObjectLooted; }
			set { currentObjectLooted = value; }
		}
		public ArrayList Friends
		{
			get { return friends; }
			set { friends = value; }
		}
		
		public ActiveQuest[] GetActiveQuests 
		{ 
			get { return activeQuests; }// need return all active quests 
		}
		public override uint Flags
		{
			get
			{
				uint flags = 0;
				if ( MountModel != 0 )
					flags |= 0x3000;
				if ( this.Dead )
					flags |= 0x4000;
				if ( this.Freeze || this.ForceRoot || this.ForceStun )
					flags |= 0x4;
				if ( !this.pvpActive )
					flags |= 0x8;
				else
					flags |= 0x1000;
				if ( this.taxiOn ) 
				{ 
					flags |= 0x000004; 
					flags |= 0x002000; 
				} 
				return flags;
			}
		}
		public float BindingPointX
		{
			get { return bindingPointX; }
			set { bindingPointX = value; }
		}
		public float BindingPointY
		{
			get { return bindingPointY; }
			set { bindingPointY = value; }
		}
		public float BindingPointZ
		{
			get { return bindingPointZ; }
			set { bindingPointZ = value; }
		}
		public UInt16 BindingPointMapId
		{
			get { return bindingPointMapId; }
			set { bindingPointMapId = value; }
		}
		public override ArrayList KnownObjects
		{
			get { return Player.KnownObjects; }
		}
		public Object Selection
		{
			get { return selection; }
		}
		public int AmmoType
		{
			get { return ammoType; }
		}
		public override byte []tempBuff
		{
			get { return World.tempBuff; }
		}
		public int Face
		{
			get { return face; }
		}
		public int HairStyle
		{
			get { return hairStyle; }
		}
		public int HairColour
		{
			get { return hairColour; }
		}
		
		public int Skin
		{
			get { return skin; }
		}
		public int FacialHair
		{
			get { return facialHair; }
		}
		public Races Race
		{
			get { return race; }
		}
		public int Gender
		{
			get { return gender; }
		}
		public UInt64 LootOwner
		{
			get { return lootOwner; }
			set { lootOwner = value; }
		}
		
		public AccessLevels AccountLevel
		{
			get { return account.AccessLevel; }
		}
		public uint Copper
		{
			get { return copper; }
			set { copper = value; }
		}
		public int Sheathed
		{
			get { return sheathed; }
			set { sheathed = value; }
		}

		public UInt64 Target
		{
			get { return target; }
			set { target = value; }
		}
		public uint WeaponMode
		{
			get 
			{ /* WEAPONMODE_NORMALMODE            =0x0,
 WEAPONMODE_SHEATHEDMODE          =0x1,
 WEAPONMODE_RANGEDMODE            =0x2,*/
				return 0;
			}
		}

		public uint GuildID
		{
			get { return 0; }
		}

		public uint GuildRank
		{
			get { return 0; }
		}

		public UInt32 Appearance
		{
			get 
			{
				int r = (int)skin << 24 + (int)face << 16 + (int)hairStyle << 8 + (int)hairColour; 
				return (UInt32)r;
			}
		}

		public byte StatusFlags
		{// Status flags (AFK, DND, GM)
			get { return 0x00; }
		}

		public uint GuildTimestamp
		{
			get { return 0; }
		}

		public uint NextLevelExp
		{
			get { return 1000; }
		}

		public bool Logged
		{
			get { if ( account != null ) return true; else return false; }
		}
		public Account Player
		{
			get { return account; }
			set { account = value; }
		}
		#endregion

		#region CONSTRUCTORS		
		public Character( float x, float y, float z, float orient ) : base( x, y, z, orient )
		{

		}
		public Character()
		{
		}

		public Character( Account acc, byte []data ): this( -8897.50f, -173.480f, 81.5775f, 0f )
		{			
			account = acc;
			Name = "";
			int part = 0;
			for(int t = 6;t < data.Length;t++ )			
			{
				byte b = data[ t ];
				if ( part == 0 )
				{
					if ( b == 0 )
					{
						part++;					
					}
					else
						if ( b != 0 && part == 0 )
						Name += (char)b;
				}
				else
					if ( part == 1 )
				{
					race = (Races)b;
					part++;
				}
				else
					if ( part == 2 )
				{							
					switch( b )
					{
						case (int)Classes.Warrior:
							if ( !World.WarriorClassAvailable )
							{
								this.Send( OpCodes.SMSG_CHAR_CREATE, new byte[]{ 0, 0, 0, 0, 0x31 } );
								Name = null;
								return;
							}
							Classe = Classes.Warrior;
							manaType = 1;
							AllSkills.Add( new DaggerSkill( 1, 300 ) );
							AllSkills.Add( new AxeSkill( 1, 300 ) );
							AllSkills.Add( new SwordSkill( 1, 300 ) );
							AllSkills.Add( new MacesSkill( 1, 300 ) );
							AllSkills.Add( new ShieldSkill( 1, 1 ) );
							AllSkills.Add( new ClothSkill( 1, 1 ) );
							AllSkills.Add( new LeatherSkill( 1, 1 ) );
							AllSkills.Add( new MailSkill( 1, 1 ) );
							
							if ( Race == Races.Orc || Race == Races.Dwarf )
								AllSkills.Add( new TwoHandedAxeSkill( 1, 300 ) );
							else
							if ( Race == Races.Tauren )
								AllSkills.Add( new TwoHandedMaceSkill( 1, 300 ) );
							else								
								AllSkills.Add( new TwoHandedSwordSkill( 1, 300 ) );
							AllSkills.Add( new Arms( 1, 1 ) );
							AllSkills.Add( new Protection( 1, 1 ) );
							Mana = BaseMana = 100;							
							break;
						case (int)Classes.Paladin:
							if ( !World.PaladinClassAvailable )
							{
								this.Send( OpCodes.SMSG_CHAR_CREATE, new byte[]{ 0, 0, 0, 0, 0x31 } );
								Name = null;
								return;
							}
							Classe = Classes.Paladin;
							manaType = 0;
							AllSkills.Add( new TwoHandedMaceSkill( 1, 300 ) );
							AllSkills.Add( new MacesSkill( 1, 300 ) );
							AllSkills.Add( new ClothSkill( 1, 1 ) );
							AllSkills.Add( new ShieldSkill( 1, 1 ) );
							AllSkills.Add( new LeatherSkill( 1, 1 ) );
							AllSkills.Add( new MailSkill( 1, 1 ) );
							break;
						case (int)Classes.Rogue:
							if ( !World.RogueClassAvailable )
							{
								this.Send( OpCodes.SMSG_CHAR_CREATE, new byte[]{ 0, 0, 0, 0, 0x31 } );
								Name = null;
								return;
							}
							Classe = Classes.Rogue;
							manaType = 3;
							AllSkills.Add( new ThrowsSkill( 1, 300 ) );
							AllSkills.Add( new DaggerSkill( 1, 300 ) );
							AllSkills.Add( new ThrowsSkill( 1, 300 ) );
							AllSkills.Add( new ClothSkill( 1, 1 ) );
							AllSkills.Add( new LeatherSkill( 1, 1 ) );
							AllSkills.Add( new Assassination( 1, 1 ) );
							AllSkills.Add( new Subtlety( 1, 1 ) );
							AllSkills.Add( new Combat( 1, 1 ) );
							Mana = BaseMana = 100;
							break;
						case (int)Classes.Hunter:
							if ( !World.HunterClassAvailable )
							{
								this.Send( OpCodes.SMSG_CHAR_CREATE, new byte[]{ 0, 0, 0, 0, 0x31 } );
								Name = null;
								return;
							}
							Classe = Classes.Hunter;
							manaType = 0;
							AllSkills.Add( new AxeSkill( 1, 300 ) );
							AllSkills.Add( new BowsSkill( 1, 300 ) );
							AllSkills.Add( new DaggerSkill( 1, 300 ) );
							AllSkills.Add( new LeatherSkill( 1, 1 ) );
							AllSkills.Add( new ClothSkill( 1, 1 ) );
							AllSkills.Add( new GunSkill( 1, 300 ) );
							break;
						case (int)Classes.Warlock:
							if ( !World.WarlockClassAvailable )
							{
								this.Send( OpCodes.SMSG_CHAR_CREATE, new byte[]{ 0, 0, 0, 0, 0x31 } );
								Name = null;
								return;
							}
							Classe = Classes.Warlock;
							manaType = 0;
							AllSkills.Add( new WandsSkill( 1, 300 ) );
							AllSkills.Add( new DaggerSkill( 1, 300 ) );
							AllSkills.Add( new Destruction( 1, 300 ) );
							AllSkills.Add( new Demonology( 1, 300 ) );
							AllSkills.Add( new Affliction( 1, 300 ) );
							AllSkills.Add( new ClothSkill( 1, 1 ) );
							Mana = BaseMana = 100;
							break;
						case (int)Classes.Mage:
							if ( !World.MageClassAvailable )
							{
								this.Send( OpCodes.SMSG_CHAR_CREATE, new byte[]{ 0, 0, 0, 0, 0x31 } );
								Name = null;
								return;
							}
							Classe = Classes.Mage;
							manaType = 0;
							AllSkills.Add( new WandsSkill( 1, 300 ) );
							//AllSkills.Add( new DaggerSkill( 1, 300 ) );
							AllSkills.Add( new StavesSkill( 1, 300 ) );
							AllSkills.Add( new ClothSkill( 1, 300 ) );

							AllSkills.Add( new ArcaneSkill( 1, 300 ) );
							AllSkills.Add( new FireSkill( 1, 300 ) );
							AllSkills.Add( new FrostSkill( 1, 300 ) );

							Mana = BaseMana = 100;
							break;
						case (int)Classes.Shaman:
							if ( !World.ShamanClassAvailable )
							{
								this.Send( OpCodes.SMSG_CHAR_CREATE, new byte[]{ 0, 0, 0, 0, 0x31 } );
								Name = null;
								return;
							}
							Classe = Classes.Shaman;
							manaType = 0;
							AllSkills.Add( new StavesSkill( 1, 300 ) );
							AllSkills.Add( new MacesSkill( 1, 300 ) );
							AllSkills.Add( new ClothSkill( 1, 1 ) );
							AllSkills.Add( new LeatherSkill( 1, 1 ) );
							break;
						case (int)Classes.Priest:
							if ( !World.PriestClassAvailable )
							{
								this.Send( OpCodes.SMSG_CHAR_CREATE, new byte[]{ 0, 0, 0, 0, 0x31 } );
								Name = null;
								return;
							}
							Classe = Classes.Priest;
							manaType = 0;
							AllSkills.Add( new WandsSkill( 1, 300 ) );
							AllSkills.Add( new MacesSkill( 1, 300 ) );
							AllSkills.Add( new ClothSkill( 1, 1 ) );
							break;
						case (int)Classes.Druid:
							if ( !World.DruidClassAvailable )
							{
								this.Send( OpCodes.SMSG_CHAR_CREATE, new byte[]{ 0, 0, 0, 0, 0x31 } );
								Name = null;
								return;
							}
							Classe = Classes.Druid;
							manaType = 0;
							AllSkills.Add( new StavesSkill( 1, 300 ) );
							AllSkills.Add( new LeatherSkill( 1, 1 ) );
							AllSkills.Add( new ClothSkill( 1, 1 ) );
							break;
						default:
							manaType = 0;
							break;
					}
					part++;
				}
				else
					if ( part == 3 )
				{
					gender = b;
					part++;
				}
				else
					if ( part == 4 )
				{
					skin = b;
					part++;
				}
				else
					if ( part == 5 )
				{
					face = b;
					part++;
				}
				else
					if ( part == 6 )
				{
					hairStyle = b;
					part++;
				}
				else
					if ( part == 7 )
				{
					hairColour = b;
					part++;
				}
				else
					if ( part == 8 )
				{
					facialHair = b;
					part++;
					break;
				}
			}


			foreach( Account acco in World.allAccounts )
				foreach( Character ch in acco.characteres )
					if ( ch.Name.ToLower() == Name.ToLower() )
					{
						byte []pack = new byte[]{  0x00, 0x03, 0x3a, 0x00, 0x39 };
						Send( pack );
						Name = null;
						return;
					}

			MapId = 0;
			ZoneId = 9;

			HitPoints = 50;
			BaseHitPoints = 50;
			Rage = BaseRage = 350;
			Level = 1;

			//	Skill lang = null;

			/*TrainAbility( 6247 );//	Open
			TrainAbility( 6249 );//	Open
			TrainAbility( 6461 );//	Open*/
			TrainAbility( 6477 );//	Open
			TrainAbility( 6478 );//	Open
			TrainAbility( 7266 );//	Open
			//TrainAbility( 11437 );//	Open

			switch( Race)
			{
				case Races.Human:
					Faction = Factions.Player_Human;
					break;
				case Races.Dwarf:
					Faction = Factions.Player_Dwarf;
					break;
				case Races.NightElf:
					Faction = Factions.Player_Elf;
					break;
				case Races.Gnome:
					Faction = Factions.Player_Gnome;
					break;
				case Races.Orc:
					Faction = Factions.Player_Orc;
					break;
				case Races.Undead:
					Faction = Factions.Player_Undead;
					break;
				case Races.Tauren:
					Faction = Factions.Player_Tauren;
					break;
				case Races.Troll:
					Faction = Factions.Player_Troll;
					break;
			}
			foreach( Factions f in World.FriendRaces[ Race ] as ArrayList )
				reputationAdjustments[ (int)World.FactionAssociated[ f ] ] = 0;

			onCharacterChooseRace( this, race );
			Copper = 100;
			AllSkills.Add( new UnarmedSkill( 1, 300 ) );
			AllSkills.Add( new DefenseSkill( 1, 300 ) );

			OnCreateCharacter();
			byte []ok = new byte[]{  0x00, 0x03, 0x3a, 0x00, 0x2d };
			Send( ok );
		}

		#endregion

		#region SERIALISATION
		public override void Deserialize( GenericReader gr )
		{
			base.Deserialize( gr );
			int version = gr.ReadInt();
			if ( version > 6 )
			{
				int nreput = gr.ReadInt();
				for(int t = 0;t < nreput;t++ )
				{
					int krep = gr.ReadInt();
					int vrep = gr.ReadInt();
					reputationAdjustments[ krep ] = vrep;
				}
			}
			if ( version > 5 )
			{
				int nact = gr.ReadInt();
				for(int t = 0;t < nact;t++ )
					actionBar.Add( new Action( gr ) );
			}
			if ( version > 4 )
			{
				int nf = gr.ReadInt();
				for(int t = 0;t < nf;t++ )
				{
					UInt64 gu = (UInt64)gr.ReadInt64();
					friends.Add( gu );
					string user = gr.ReadString();
					friends.Add( user );
				}
			}
			if ( version > 2 )
			{
				BindingPointX = gr.ReadFloat();
				BindingPointY = gr.ReadFloat();
				BindingPointZ = gr.ReadFloat();
				BindingPointMapId = (UInt16)gr.ReadInt();
			}
			if ( version > 1 )
			{
				bool pa = gr.ReadBool();
				if ( pa )
				{
					petActions = new int[ 11 ];
					for(int t = 0;t < 11;t++ )
						petActions[ t ] = gr.ReadInt();
				}
			}
			int sum = gr.ReadInt();
			if ( sum != 0 )
			{
				UInt64 g = gr.ReadInt64();
				if ( version > 7 )
				{
					int sid = gr.ReadInt();
					Summon = new BaseCreature( gr );
					Summon.Id = sid;
				}
			//	Summon = (Mobile)MobileList.TempSummon[ g ];
				Summon.SummonedBy = this;					
				( Summon as BaseCreature ).AIEngine = new SummonedAI( this, Summon as BaseCreature );
			}
			sum = gr.ReadInt();
			if ( sum != 0 )
			{
				Charm = (Mobile)MobileList.TempSummon[ gr.ReadInt64() ];
				Charm.CharmedBy = this;
				( Charm as BaseCreature ).AIEngine = new SummonedAI( this, Charm as BaseCreature );
			}
			CorpseLocationX = gr.ReadFloat();
			CorpseLocationY = gr.ReadFloat();
			CorpseLocationZ = gr.ReadFloat();
			if ( version > 3 )
				CorpseMapId = (ushort)gr.ReadShort();
			corpsGuid = gr.ReadInt64();
			zones = new uint[ 32 ];
			for(int t = 0;t < 32;t++ )
				zones[ t ] = (uint)gr.ReadInt();
			int exi = gr.ReadInt();
			if ( exi == 1 )
			{
				mark = new Position( gr.ReadFloat(), gr.ReadFloat(), gr.ReadFloat(), gr.ReadInt() );
			}
			ammoType = gr.ReadInt();
			race = (Races)gr.ReadByte();
			if ( version == 0 )
				Classe = (Classes)gr.ReadByte();
			gender = gr.ReadByte();
			skin = gr.ReadByte();
			face = gr.ReadByte();
			hairStyle = gr.ReadByte();
			hairColour = gr.ReadByte();
			facialHair = gr.ReadByte();

			copper = (uint)gr.ReadInt();
			int nactq = 20;
			for(int t = 0;t < nactq;t++ )
			{
				int vv = gr.ReadInt();
				if ( vv == 1 )
				{
					ActiveQuest aq = new ActiveQuest( gr );
					if ( aq.Id > 0 )
						AddQuest( aq );
				}
			}

			int nq = gr.ReadInt();
			for(int t = 0;t < nq;t++ )
			{
				int id = gr.ReadInt();
				questsDone[ id ] = true;
			}
			for(int g = 0;g < 8;g++ )
			{
				int field = gr.ReadInt();
				TaxiField[ g ] = (uint)field;
			}
		//	RunSpeed = 11f;
			
		}
		public override void Serialize( GenericWriter gw )
		{			
			base.Serialize( gw );
			gw.Write( (int)8 );
			gw.Write( (int)reputationAdjustments.Count );
			IDictionaryEnumerator repEnum = reputationAdjustments.GetEnumerator();
			while ( repEnum.MoveNext() )
			{
				gw.Write( (int)repEnum.Key );
				gw.Write( (int)repEnum.Value );
			}
			gw.Write( this.actionBar.Count );
			foreach( Action act in actionBar )
				act.Serialize( gw );

			gw.Write( friends.Count );
			foreach( Character ch in friends )
			{
				gw.Write( ch.Guid );
				if ( ch.Player == null )
				{
					Account acc = World.FindPlayerAccountByCharacterGUID( ch.Guid );
					if ( acc == null )
						gw.Write( "Unknown" );
					else
						gw.Write( acc.Username );
				}
				else
					gw.Write( ch.Player.Username );
			}
			gw.Write( BindingPointX );
			gw.Write( BindingPointY );
			gw.Write( BindingPointZ );
			gw.Write( (int)BindingPointMapId );
			if ( petActions != null )
			{
				gw.Write( true );
				for(int t = 0;t < 11;t++ )
					gw.Write( petActions[ t ] );
			}
			else
				gw.Write( false );
			if ( Summon != null )
			{
				gw.Write( 1 );
				gw.Write( Summon.Guid );
				( Summon as BaseCreature ).Serialize( gw );
			}
			else
				gw.Write( 0 );
			if ( Charm != null )
			{
				gw.Write( 1 );
				gw.Write( Charm.Guid );
			}
			else
				gw.Write( 0 );
			gw.Write( CorpseLocationX );
			gw.Write( CorpseLocationY );
			gw.Write( CorpseLocationZ );
			gw.Write( CorpseMapId );
			gw.Write( corpsGuid );

			for(int t = 0;t < 32;t++ )
				gw.Write( zones[ t ] );

			if ( mark == null )
				gw.Write( 0 );
			else
			{
				gw.Write( 1 );
				gw.Write( mark.X );
				gw.Write( mark.Y );
				gw.Write( mark.Z );
				gw.Write( mark.MapId );
			}

			gw.Write( ammoType );
			gw.Write( (byte)race );
			//	gw.Write( (byte)classe );
			gw.Write( gender );
			gw.Write( skin );
			gw.Write( face );
			gw.Write( hairStyle );
			gw.Write( hairColour );
			gw.Write( facialHair );

			gw.Write( copper );
			
			foreach( ActiveQuest aq in activeQuests )
			{
				if (  aq == null )
					gw.Write( 0 );
				else
				{
					gw.Write( 1 );
					aq.Serialisation( gw );			
				}
			}

			gw.Write( (int)questsDone.Count );
			IDictionaryEnumerator questEnumerator = questsDone.GetEnumerator();
			while ( questEnumerator.MoveNext() )
			{
				int id = (int)questEnumerator.Key;
				gw.Write( id );
			}
			for(int g = 0;g < 8;g++ )
			{
				gw.Write( TaxiField[ g ] );
			}
		}
		#endregion

		#region BoviesAccesors for updates
		
		public int StrBonusUpdate
		{
			get 
			{
				int dif = 0;
				dif = (int)(this.Str - this.BaseStr);
				if (dif > 0) return dif;
				else return 0; 
			}
		}
		public int SpiritBonusUpdate
		{
			get 
			{
				int dif = 0;
				dif = (int)(this.Spirit - this.BaseSpirit);
				if (dif > 0) return dif;
				else return 0; 
			}
		}
		public int AgBonusUpdate
		{
			get 
			{
				int dif = 0;
				dif = (int)(this.Agility - this.BaseAgility);
				if (dif > 0) return dif;
				else return 0; 
			}
		}
		public int StaminaBonusUpdate
		{
			get 
			{
				int dif = 0;
				dif = (int)(this.Stamina - this.StaminaBonus);
				if (dif > 0) return dif;
				else return 0; 
			}
		}
		public int IqBonusUpdate
		{
			get 
			{
				int dif = 0;
				dif = (int)(this.Iq - this.BaseIq);
				if (dif > 0) return dif;
				else return 0; 
			}
		}
				
		public int StrMalusUpdate
		{
			get 
			{
				int dif = 0;
				dif = (int)(this.Str - this.BaseStr);
				if (dif < 0) return -1*dif;
				else return 0; 
			}
		}
		public int SpiritMalusUpdate
		{
			get 
			{
				int dif = 0;
				dif = (int)(this.Spirit - this.BaseSpirit);
				if (dif < 0) return -1*dif;
				else return 0; 
			}
		}
		public int AgMalusUpdate
		{
			get 
			{
				int dif = 0;
				dif = (int)(this.Agility - this.BaseAgility);
				if (dif < 0) return -1*dif;
				else return 0; 
			}
		}
		public int StaminaMalusUpdate
		{
			get 
			{
				int dif = 0;
				dif = (int)(this.Stamina - this.StaminaBonus);
				if (dif < 0) return -1*dif;
				else return 0; 
			}
		}
		public int IqMalusUpdate
		{
			get 
			{
				int dif = 0;
				dif = (int)(this.Iq - this.BaseIq);
				if (dif < 0) return -1*dif;
				else return 0; 
			}
		}

		
		
		
		#endregion

		#region TIMERS

		private class InternalHeartBeatTimer : WowTimer
		{
			Character from;
			public InternalHeartBeatTimer( Character c ) : base( WowTimer.Priorities.Second , 1000, "InternalHeartBeatTimer" )
			{
				from = c;
				Start();
			}
			public override void OnTick()
			{
				from.HeartBeat();
				base.OnTick ();
			}

		}
		#endregion

		#region TRADE
		public int[] TradeItems
		{
			get { return  tradeItems; }
		}
		public int TradeState
		{
			get { return  tradeState; }
			set { tradeState = value; }
		}
		//	l'inititateur du trade recoit : 
		public void InitiateTrade( UInt64 guid )
		{
			Character c = account.FindPlayerNearByGuid( guid );
			if ( c == null )
				return;
			// 01 00 00 00 16 00 00 00 00 00 00 0
			tradingWith = c;
			c.tradingWith = this;
			int offset = 4;
			tradeNum = 1;
			Converter.ToBytes( tradeState = 1, tempBuff, ref offset );
			Converter.ToBytes( Guid, tempBuff, ref offset );
			c.Send( OpCodes.SMSG_TRADE_STATUS, tempBuff, offset );
			for(int t = 0;t < 7;t++ )
				tradeItems[ t ] = -1;
		}
		//	La personne choisit par le trader recoit :
		public void BeginTrade()
		{
			int offset = 4;
			Converter.ToBytes( tradeState = 2, tempBuff, ref offset );
			tradingWith.Send( OpCodes.SMSG_TRADE_STATUS, tempBuff, offset );
			tradingWith.TradeState = 2;
			tradeNum = 5;
			Send( OpCodes.SMSG_TRADE_STATUS, tempBuff, offset );
			for(int t = 0;t < 7;t++ )
				tradeItems[ t ] = -1;
		}

		public void AcceptTrade()
		{
			TradeState = 3;
			int offset = 4;
			if ( tradingWith != null )
			{
				if ( tradingWith.TradeState == 3 )
				{
					int n1 = 0;
					int n2 = 0;
					for(int t = 0;t < 7;t++ )
					{
						if ( tradeItems[ t ] != -1 )
							n1++;
						if ( tradingWith.TradeItems[ t ] != -1 )
							n2++;
					}
					if ( n2 > FreeSlot() || n1 > tradingWith.FreeSlot() )
					{//	anulation car pas de place
						Converter.ToBytes( tradeNum, tempBuff, ref offset );
						tradingWith.Send( OpCodes.SMSG_TRADE_STATUS, tempBuff, offset );
						return;
					}
					for(int t = 0;t < 7;t++ )
					{
						if ( tradeItems[ t ] != -1 )
						{
							tradingWith.PutObjectInBackpack( Items[ tradeItems[ t ] ], true );
							DestroyItem( (Slots)tradeItems[ t ], false );	
							tradeItems[ t ] = -1;
						}
						if ( tradingWith.tradeItems[ t ] != -1 )
						{
							PutObjectInBackpack( tradingWith.Items[ tradingWith.tradeItems[ t ] ], true );
							tradingWith.DestroyItem( (Slots)tradingWith.tradeItems[ t ], false );
							tradingWith.tradeItems[ t ] = -1;
						}
					}
					Copper += (uint)tradingWith.tradeGold;
					Copper -= (uint)tradeGold;
					tradingWith.Copper += (uint)tradeGold;
					tradingWith.Copper -= (uint)tradingWith.tradeGold;
					offset = 4;
					Character c = tradingWith;
					Converter.ToBytes( 8, tempBuff, ref offset );
					c.Send( OpCodes.SMSG_TRADE_STATUS, tempBuff, offset );
					Send( OpCodes.SMSG_TRADE_STATUS, tempBuff, offset );
					this.ItemsUpdate();
					tradingWith.ItemsUpdate();

					tradeNum = 7;
					tradingWith.TradeUpdate();
					TradeUpdate();

					tradingWith.ReleaseTrade();
					ReleaseTrade();


					return;
				}
				offset = 4;
				Converter.ToBytes( 4, tempBuff, ref offset );
				tradingWith.Send( OpCodes.SMSG_TRADE_STATUS, tempBuff, offset );
			}

		}
		public void CancelTrade()
		{
			if ( tradingWith != null )
			{
				int offset = 4;
				Converter.ToBytes( 3, tempBuff, ref offset );
				tradingWith.Send( OpCodes.SMSG_TRADE_STATUS, tempBuff, offset );
				tradingWith = null;
			}
		}
		public void UnacceptTrade()
		{
			TradeState = 9;
			if ( tradingWith == null )
				return;
			int offset = 4;
			if ( tradingWith.TradeState == 9 )
			{
				tradingWith.ReleaseTrade();
				ReleaseTrade();
			}
			offset = 4;
			Converter.ToBytes( 4, tempBuff, ref offset );
			tradingWith.Send( OpCodes.SMSG_TRADE_STATUS, tempBuff, offset );			
		}
		public void ReleaseTrade()
		{
			TradeState = 0;
			for(int t = 0;t < tradeItems.Length;t++ )
				tradeItems[ t ] = -1;
			tradingWith = null;
		}
		/// 01 BA 21 01 
		/// 01 00 00 00 00 50 00 00 00 
		/// 00 00 00 00 
		/// 00 BC 11 00 00 00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
		/// 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
		/// 02 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
		/// 03 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
		/// 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 05 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 06 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
		/// 
		/// 01 BE 21 01 
		/// 01 05 00 00 00 00 00 00 00 
		/// 00 00 00 00 00 00 00 00 
		/// 00 26 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 27 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 03 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 05 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 06 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
		/// 
		/// 
		/// 01 C3 21 01 
		/// 01 01 00 00 00 00 00 00 00 
		/// 00 00 00 00 00 00 00 00 
		/// 00 00 28 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
		/// 
		/// 
		/// //01 BA 21 01 
		///01 00 00 00 00 00 00 00 
		///00 00 00 00 
		///00 
		///00 9F 00 00 00 00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
		///01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
		///02 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
		///03 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
		///04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
		///05 27 0C 00 00 00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
		///06 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 

		/// 01 00 00 00 00 00 00 00  
		/// 00 00 00 00 00 
		/// 00 3A 09 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
		/// 01
		/// <summary>
		/// 01 BA 21 01 
		/// 01 00 00 00 00 00 00 00 
		/// 00 00 00 00 00 
		/// 00 16 08 00 00 00 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
		/// 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
		/// 02 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
		/// 03 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
		/// 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
		/// 05 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
		/// 06 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
		/// 
		/// 01 BA 21 01 
		/// 01 00 00 00 00 50 00 00 00 
		/// 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
		///01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 02 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 03 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 04 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 05 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 06 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00

		void TradeUpdate( )
		{
			if ( tradingWith == null )
				return;
			int offset = 4;
			Converter.ToBytes( (byte)1, tempBuff, ref offset );			
			Converter.ToBytes( tradeNum, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );			
			Converter.ToBytes( tradeGold, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			for(int t = 0;t < 7;t++ )
			{
				Converter.ToBytes( (byte)t, tempBuff, ref offset );
				int n = tradeItems[ t ];
				if ( n == -1 )					
					Converter.ToBytes( 0, tempBuff, ref offset );
				else
					Converter.ToBytes( Items[ n ].Id, tempBuff, ref offset );
				Converter.ToBytes( 0, tempBuff, ref offset );
				if ( n == -1 )
					Converter.ToBytes( 0, tempBuff, ref offset );
				else
					Converter.ToBytes( Items[ n ].MaxCount, tempBuff, ref offset );
				for(int i = 0;i < 12;i++ )
					Converter.ToBytes( 0, tempBuff, ref offset );
			}
			
			tradingWith.Send( OpCodes.SMSG_TRADE_STATUS_EXTENDED, tempBuff, offset );
		}
		public void TradeItem( int num, Slots from )
		{
			tradeItems[ num ] = (int)from;
			TradeUpdate();			
		}

		public void ClearTradeItem( int num )
		{
			tradeItems[ num ] = -1;
			TradeUpdate();			

		}

		public void TradeGold( int amount )
		{
			if ( tradingWith == null )
			{
				this.CancelTrade();
				return;
			}
			tradeGold = amount;
			TradeUpdate();
		}
		#endregion

		#region ITEMS
		void UseItem( byte a, int slot )
		{
			if ( slot > Items.Length )
				return;
			
			Item i = Items[ slot ];
			if ( i == null )
				return;
			for(int t = 0;t < 5;t++ )
			{
				Item.SpecialAbility sa = i.Spells( t );
				if ( sa != null )
				{
					if ( sa.Trigger == 0 )
					{
						#region cast creation
						BaseAbility ba;
						
						ba = (BaseAbility)Abilities.abilities[sa.Spell.Id];
						
						/*	if (sa.Spell.Id == 0)
								Console.WriteLine("SpellError 0001: Not id given by CMSG_SPELL_CAST");
							else Console.WriteLine("SpellError 0002: Not able to create BaseAbility" + "ID:" + sa.Spell.Id);
						*/		
						
						if (ba is SpellTemplate)
						{
							SpellTemplate st;
							
							st = (SpellTemplate)ba;
							this.cast.castingtime = st.CastingTime(this);
							this.cast.cool = st.CoolDown(this);
							this.cast.id = st.Id;
							this.cast.manacost = st.GetManaCost(this);
							this.cast.type = 0;
							this.cast.baseability = st;
							
							//Console.WriteLine("SpellError 0004: Error in Mobile.cast assigment for SpellTemplate" + "ID:" + sa.Spell.Id);
							
						}
						else
						{
							
							this.cast.castingtime = ba.CastingTime(this);
							this.cast.cool = ba.CoolDown(this);
							this.cast.id = ba.Id;
							this.cast.manacost = 0;
							this.cast.type = 0;
							this.cast.baseability = ba;
							
							//	Console.WriteLine("SpellError 0005: Error in Mobile.cast assigment for BaseAbility" + "ID:" + sa.Spell.Id);
							
						}
					}
					#endregion
					
					int offset = 4;
				//	Converter.ToBytes( cast.id, b, ref offset );					
					Converter.ToBytes( Item.GUID, tempBuff, ref offset );
					Converter.ToBytes( cast.id, tempBuff, ref offset );
					this.Send(OpCodes.SMSG_ITEM_COOLDOWN, tempBuff,offset);
					this.SpellExecutionStart(cast,this,true);
					if ( i.ObjectClass == 0 && i.SubClass == 0 )
						this.ConsumeItemByIdUpTo( i.Id, 1 );
				}
			}
		}
		

		void OnLootMoney()
		{
			if ( currentObjectLooted == null )
				return;
			int t = 0;
			foreach( Item i in currentObjectLooted.Treasure )
			{
				if ( i is Money )
				{
					if ( GroupMembers != null && GroupMembers.Count > 0 )//	If grouped and I'm the group leader
					{
						int am = i.MaxCount;
						am /= GroupMembers.Members.Count;
						foreach( Member member in GroupMembers.Members )
						{
							member.Char.Copper += (uint)am;
							member.Char.SendSmallUpdate( new int[] { (int)UpdateFields.PLAYER_FIELD_COINAGE }, new object[] { member.Char.Copper } );
						}
					}
					else
					{
						this.Copper += (uint)i.MaxCount;
						this.SendSmallUpdate( new int[] { (int)UpdateFields.PLAYER_FIELD_COINAGE }, new object[] { Copper } );
					}
					i.MaxCount = 0;
					
					currentObjectLooted.Treasure[ t ] = null;
					Object m = account.FindObjectByGuid( LootOwner );
					if ( m != null )
					{
						if ( m is Mobile )
							( m as Mobile ).LootMoney = 0;
						else
							if ( m is BaseChest )
							( m as BaseChest ).LootMoney = 0;
					}
					break;
				}
				t++;
			}
		}
 
		public void LootCreature( UInt64 guid )
		{
			Mobile m = account.FindMobileByGuid( guid );

			if ( m != null )
			{
				ArrayList al = new ArrayList();
				int offset = 4;
				lootOwner = Guid;
				if ( m.Treasure.Length > 0 )
				{
					LootOwner = guid;
					currentObjectLooted = m;
					
					int nObj = currentObjectLooted.Treasure.Length;
					Converter.ToBytes( guid, tempBuff, ref offset );
					int h = 0;
					if ( nObj == 0 &&  m.LootMoney <= 0 )
					{
						Converter.ToBytes( 0x2, tempBuff, ref offset );
						Converter.ToBytes( (short)0, tempBuff, ref offset );
						Send( OpCodes.SMSG_LOOT_RESPONSE, tempBuff, offset );
						return;
					}
					if ( m.LootMoney > 0 )
					{
						Converter.ToBytes( (byte)0x01, tempBuff, ref offset );
						Converter.ToBytes( m.LootMoney, tempBuff, ref offset );
						//nObj++;
					}
					else
					{
						Converter.ToBytes( (byte)0x02, tempBuff, ref offset );
						Converter.ToBytes( 0, tempBuff, ref offset );
					}

					Converter.ToBytes( (byte)nObj, tempBuff, ref offset );

					
					foreach( Item i in currentObjectLooted.Treasure )
					{
						if ( i !=  null )
						{
							if ( i.IsQuestItem )
							{
								bool ok = false;
								for(int t = 0;t < 20;t++ )
									if ( activeQuests[ t ] != null )
									{
										if ( activeQuests[ t ].HaveDeliveryObj )
										{
											if ( activeQuests[ t ].NeedItem( i ) )
											{
												ok = true;												
												break;
											}
										}
									}
								if ( ok )
								{
									Converter.ToBytes( (byte)h++, tempBuff, ref offset );
									Converter.ToBytes( (int)i.Id, tempBuff, ref offset );
									Converter.ToBytes( (int)i.MaxCount, tempBuff, ref offset );
									Converter.ToBytes( (int)i.Model, tempBuff, ref offset );
									Converter.ToBytes( (int)0, tempBuff, ref offset );
									Converter.ToBytes( (int)0, tempBuff, ref offset );
									Converter.ToBytes( (byte)0, tempBuff, ref offset );//	1 message "still rolled for", 2 unlootable, 
									//	continue;
								}
								else
									h++;
							}
							else
							{
								Converter.ToBytes( (byte)h++, tempBuff, ref offset );
								Converter.ToBytes( (int)i.Id, tempBuff, ref offset );
								Converter.ToBytes( (int)i.MaxCount, tempBuff, ref offset );
								Converter.ToBytes( (int)i.Model, tempBuff, ref offset );
								Converter.ToBytes( (int)0, tempBuff, ref offset );
								Converter.ToBytes( (int)0, tempBuff, ref offset );
								Converter.ToBytes( (byte)0, tempBuff, ref offset );//	1 message "still rolled for", 2 unlootable, 
							}
						}
						else
						{
							Converter.ToBytes( (byte)h++, tempBuff, ref offset );
							Converter.ToBytes( (int)0, tempBuff, ref offset );
							Converter.ToBytes( (int)0, tempBuff, ref offset );
							Converter.ToBytes( (int)0, tempBuff, ref offset );
							Converter.ToBytes( (int)0, tempBuff, ref offset );
							Converter.ToBytes( (int)0, tempBuff, ref offset );
							Converter.ToBytes( (byte)0, tempBuff, ref offset );//	1 message "still rolled for", 2 unlootable, 
						}
					}

					Send( OpCodes.SMSG_LOOT_RESPONSE, tempBuff, offset );
				
					return;
				}
				else
				{
					Converter.ToBytes( guid, tempBuff, ref offset );					
					//	Converter.ToBytes( (byte)0x02, tempBuff, ref offset );
					//	Converter.ToBytes( 0, tempBuff, ref offset );
					Converter.ToBytes( 2, tempBuff, ref offset );
					//	Converter.ToBytes( (byte)0, tempBuff, ref offset );
					//	Converter.ToBytes( (byte)0, tempBuff, ref offset );
					Converter.ToBytes( (short)0, tempBuff, ref offset );
					Send( OpCodes.SMSG_LOOT_RESPONSE, tempBuff, offset );
				}
			}			
		}
		public void SetAmmo( int id )
		{
			if ( id == 0 )
			{
				if ( ammoType != 0 )
				{
					ammoType = id;
					SendSmallUpdate( new int[] { (int)UpdateFields.PLAYER_AMMO_ID }, new object[]{ (int)0 } );
				}
				return;
			}
			Item i = World.CreateItemInPoolById( id );
			if ( i.ReqLevel > Level )
			{
				InventoryFailed( 1, (ulong)i.ReqLevel );
				return;
			}
			ammoType = id;
			SendSmallUpdate( new int[] { (int)UpdateFields.PLAYER_AMMO_ID }, new object[]{ (int)id } );
		}
		public void CreateAndAddObject( string item, bool refresh )
		{
			CreateAndAddObject( item, 1, refresh );
		}
		public void CreateAndAddObject( string item, int n, bool refresh )
		{
			Slots s = this.FindAFreeSlot();
			if ( s == Slots.None )
			{
				InventoryFailed( 48, 0 );
				//SendMessage( "No more room !" );
			}
			else
			{
				ConstructorInfo ct = Utility.FindConstructor( item, Utility.externAsm[ "item" ] );
				Item i = null;
				if ( ct == null )
				{
					SendMessage( "Unknow item " + item );
					return;
				}
				i = (Item)ct.Invoke( null );
				PutObjectInBackpack( i, n, refresh );
			}
		}
		public void CreateAndAddObject( string item )
		{
			CreateAndAddObject( item, true );
		}
		public void CreateAndAddObject( string item, int n )
		{
			Slots sl = this.FindAFreeSlot();
			if ( sl == Slots.None )
			{
				InventoryFailed( 48, 0 );
				return;
			}
			CreateAndAddObject( item, true );
			for(int t = 0;t < n - 2;t++ )
			{
				Slots s = this.FindAFreeSlot();
				if ( s == Slots.None )
				{
					InventoryFailed( 48, 0 );
					return;
				}
				CreateAndAddObject( item, false );
			}
			sl = this.FindAFreeSlot();
			if ( sl == Slots.None )
			{
				InventoryFailed( 48, 0 );
				return;
			}
			CreateAndAddObject( item, true );
		}

		public void SwapItem( byte to1, byte to2, byte from1, byte from2 )
		{
			Slots to;
			Slots from;
			if ( to1 == 0xff )
				to = (Slots)to2;
			else
				to = (Slots)( to2 + 24 + 16 + ( ( to1 - 19 ) * 16 ) );
			if ( from1 == 0xff )
				from = (Slots)from2;
			else
				from = (Slots)( from2 + 24 + 16 + ( ( from1 - 19 ) * 16 ) );
			SwapInv( from, to );
		}
		//	1 not enough level
		//	2 You are skilled enough
		//	3 That Item cannot be equip in that slot
		//	4 that bag is full
		//	5 cant put bag into another bag
		//	6 only ammo can go there
		//	7 you dont have the requiered profenciency to use that item
		//	8 no equipement slot available for that item
		//	9 you can never use that item
		//	10 you can never use that item
		//	11 no equipement slot available for that item
		//	12 cannot equip that with two handed weap
		//	13 you cannot duelèwield that item
		//	14 this item doesnt go in that bag
		//	15 this item doesnt go in that bag
		//	16 you cannot carry more of that object
		//	17 no equipement slot available for that item
		//	18 this item cannot stack
		//	19 this item connot be equiped
		//	20 this item connot be swaped
		//	21 that slot is empty
		//	22 the item was not found
		//	23 you cant drop a soul bound item
		//	24 out of range
		//	25 tryed to split more than item in stack
		//	26 couldnt split that item
		//	27 that bag is full
		//	28 you dont have enough money
		//	29 not a bag
		//	30 you can only do that with empty bag
		//	31 you dont own that item
		//	32 you can only equipe one quiver
		//	33 you must purchase that bag slot first
		//	34 you are too far away from bank
		//	35 item is locked
		//	36 you cant do that while dead
		//	37 you cant do that right now
		//	38 that bag is full
		//	39 you can only equip one quiver
		//	40 you can only equip one ammo puch
		//	41 stackable item cannot be wrapped
		//	42 equiped item cannot be wrapped
		//	43 wrapped item cannot be wrapped
		//	44 bound item cannot be wrapped
		//	45 unique item cannot be wrapped
		//	46 bags item cannot be wrapped
		//	47 already loot
		//	48 inventory is full
		//	49 your bank is full
		//	50 the item is curently sold
		//	51 that bag is full
		//	52 the item was not found
		//	53 the item cannot stack
		//	54 that bag is full
		//	55 that item is currently sold out
		//	 56 that object is busy
		//	57 you cant do that while in combat
		//	58 that bag is full
		//	59 that bag is full
		//	60 that bag is full
		//	61 that bag is full
		//	62 that bag is full
		public bool CanEquip( Item i )
		{
			if ( i.InventoryType == InventoryTypes.None )
			{
				InventoryFailed( 3, i.ReqLevel, i.Guid );
				return false;
			}
			if ( i.ReqLevel > Level )
			{
				InventoryFailed( 1, i.ReqLevel, i.Guid );
				return false;
			}
			if ( Items[ (int)Slots.MainHand ] != null && Items[ (int)Slots.MainHand ].InventoryType == InventoryTypes.TwoHanded )
			{
				if ( i.InventoryType == InventoryTypes.Shield || i.InventoryType == InventoryTypes.OffHand )
				{
					InventoryFailed( 12, i.Guid );
					return false;
				}
			}

			if ( Item.skillIdAssoc[ i.ObjectClass * 100 + i.SubClass ] != null )
			{
				if ( !this.HaveSkill( (int)Item.skillIdAssoc[ i.ObjectClass * 100 + i.SubClass ] ) )
				{
					InventoryFailed( 7, i.Guid );
					return false;
				}
			}
			else
				Console.WriteLine( "No skill associated to {0} {1} {2}", i.Name, i.ObjectClass, i.SubClass );
			if ( i.InventoryType == InventoryTypes.MainGauche && Items[ (int)Slots.MainHand ] != null )
			{
				if ( Items[ (int)Slots.MainHand ].InventoryType == InventoryTypes.TwoHanded )
				{
					InventoryFailed( 12, i.Guid );
					return false;
				}
			}
			return true;
		}


		public bool CanEquip( Item i, Item f )
		{
			if ( i == null || f == null )
				return false;
			if ( i.InventoryType == InventoryTypes.None )
			{
				InventoryFailed( 3, i.ReqLevel, i.Guid, f.Guid );
				return false;
			}
			if ( i.ReqLevel > Level )
			{
				InventoryFailed( 1, i.ReqLevel, i.Guid, f.Guid );
				return false;
			}
			if ( Items[ (int)Slots.MainHand ] != null && Items[ (int)Slots.MainHand ].InventoryType == InventoryTypes.TwoHanded )
			{
				if ( i.InventoryType == InventoryTypes.Shield || i.InventoryType == InventoryTypes.OffHand )
				{
					InventoryFailed( 12, i.Guid, f.Guid );
					return false;
				}
			}		

			int val = i.ObjectClass * 100 + i.SubClass;
			if ( Item.skillIdAssoc[ val ] != null )
			{				
				if ( !this.HaveSkill( (int)Item.skillIdAssoc[ val ] ) )
				{
					InventoryFailed( 7, i.Guid, f.Guid );
					return false;
				}
			}
			else
				Console.WriteLine( "No skill associated to {0} ", i.Name );
			return true;
		}

		public void InventoryFailed( int from )
		{
			int offset = 4;
			Converter.ToBytes( (byte)from, tempBuff, ref offset );
			Send( OpCodes.SMSG_INVENTORY_CHANGE_FAILURE, tempBuff, offset );
		}
		public void InventoryFailed( int from, int g )
		{
			int offset = 4;
			Converter.ToBytes( (byte)from, tempBuff, ref offset );
			Converter.ToBytes( g, tempBuff, ref offset );
			Send( OpCodes.SMSG_INVENTORY_CHANGE_FAILURE, tempBuff, offset );
		}
		public void InventoryFailed( int from, int l, UInt64 g, UInt64 a )
		{
			int offset = 4;
			Converter.ToBytes( (byte)from, tempBuff, ref offset );
			Converter.ToBytes( l, tempBuff, ref offset );
			Converter.ToBytes( g, tempBuff, ref offset );
			Converter.ToBytes( a, tempBuff, ref offset );
			Send( OpCodes.SMSG_INVENTORY_CHANGE_FAILURE, tempBuff, offset );
		}
		public void InventoryFailed( int from, UInt64 g )
		{
			int offset = 4;
			Converter.ToBytes( (byte)from, tempBuff, ref offset );
			Converter.ToBytes( g, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( (byte)0, tempBuff, ref offset );
			Send( OpCodes.SMSG_INVENTORY_CHANGE_FAILURE, tempBuff, offset );
		}
		public void InventoryFailed( int from, int g, UInt64 f )
		{
			int offset = 4;
			Converter.ToBytes( (byte)from, tempBuff, ref offset );
			Converter.ToBytes( g, tempBuff, ref offset );
			Converter.ToBytes( f, tempBuff, ref offset );			
			Send( OpCodes.SMSG_INVENTORY_CHANGE_FAILURE, tempBuff, offset );
		}
		public void InventoryFailed( int from, UInt64 g, UInt64 f )
		{
			int offset = 4;
			Converter.ToBytes( (byte)from, tempBuff, ref offset );
			Converter.ToBytes( g, tempBuff, ref offset );
			Converter.ToBytes( f, tempBuff, ref offset );
			Converter.ToBytes( (byte)0, tempBuff, ref offset );
			Send( OpCodes.SMSG_INVENTORY_CHANGE_FAILURE, tempBuff, offset );
		}
		public static int num = 22;
		public void SwapInv( Slots from, Slots to )
		{
			if ( AttackTarget != null )
				StopAttacking();
			if ( Dead )
			{
				if ( to != Slots.None && from != Slots.None )
				{
					Item i = Items[ (int)to ];
					Item f = Items[ (int)from ];
					if ( i != null && f != null )
						InventoryFailed( 36 , i.Guid, f.Guid );
					else
						if ( i != null )
						InventoryFailed( 36 , i.Guid );
					else
						InventoryFailed( 36 , f.Guid );
				}
				else
					if ( to != Slots.None && from == Slots.None )
				{
					Item i = Items[ (int)to ];
					if ( i != null )
						InventoryFailed( 36 , i.Guid );
				}
				else
					if ( to == Slots.None && from != Slots.None )
				{
					Item f = Items[ (int)from ];
					if ( f != null )
						InventoryFailed( 36 , f.Guid );
				}
				return;
			}
			if ( Items[ (int)to ] != null )
			{
				Item i = Items[ (int)to ];
				Item f = Items[ (int)from ];
				if ( (int)to >18 && (int)to < 23 )
				{
					int d = 40 + ( (int)to - 19 ) * 16;
					for(int t = d;t < d + 16;t++ )
						if ( Items[ t ] != null )
						{
							InventoryFailed( 30 , i.Guid, f.Guid );
							return;
						}
				}
				if ( (int)from >18 && (int)from < 23 )
				{
					int d = 40 + ( (int)from - 19 ) * 16;
					for(int t = d;t < d + 16;t++ )
						if ( Items[ t ] != null )
						{
							InventoryFailed( 30 , i.Guid, f.Guid );
							return;
						}
				}
				if ( (int)to < 19 )
				{
					if ( !CanEquip( f, i ) )
						return;
				}
				if ( (int)from < 19 )
				{
					if ( !CanEquip( i, f ) )
						return;
				}				
				if ( i.Id == f.Id )
				{
					if ( i.MaxCount + f.MaxCount <= i.Stackable )
					{
						i.MaxCount += f.MaxCount;
						i.SendTinyUpdate( new int[] { 14 }, new object[] { i.MaxCount }, this );
						DestroyItem( from, true );						
						return;
					}
					else
						if ( i.MaxCount < i.Stackable )
					{
						int d = i.Stackable - i.MaxCount;
						i.MaxCount = i.Stackable;
						f.MaxCount -= d;
						i.SendTinyUpdate( new int[] { 14 }, new object[] { i.MaxCount }, this );
						f.SendTinyUpdate( new int[] { 14 }, new object[] { f.MaxCount }, this );
					}
					else
					{
						Items[ (int)to ] = f;
						Items[ (int)from ] = i;
					}
				}				
				else
				{
					Items[ (int)to ] = f;
					Items[ (int)from ] = i;
				}
				ItemsUpdate( new int[] { (int)from, (int)to } );
				if ( (int)to < 19 || (int)from < 19 )				
					foreach( Character c in account.PlayersNear )
						if ( c.Player.PlayersNear.Contains( this ) )
							ItemsUpdateForOther( c.Player.Handler );
				
			}
			else
			{
				if ( (int)from >18 && (int)from < 23 )
				{
					int d = 40 + ( (int)from - 19 ) * 16;
					for(int t = d;t < d + 16;t++ )
						if ( Items[ t ] != null )
						{
							InventoryFailed( 30 , Items[ (int)from ].Guid );
							return;
						}
				}
				if ( (int)from < 19 )
				{
					if ( !CanEquip( Items[ (int)from ] ) )
						return;
				}
				if ( (int)to < 19 )
				{					
				//	Item i = Items[ (int)to ];
					Item f = Items[ (int)from ];
					if ( to == Slots.OffHand )
					{
						if ( f.IsWeapon && !HaveSpell( 674 ) )
						{
							InventoryFailed( 7, f.Guid );
							return;
						}
					}
					if ( f != null )
					{
						if ( to == Slots.OffHand )
						{
							if ( f.IsWeapon && !HaveSpell( 674 ) )
							{
								InventoryFailed( 7, f.Guid );
								return;
							}
						}
						if ( !CanEquip( f ) )
						{
							return;
						}
					}
				}
				Items[ (int)to ] = Items[ (int)from ];
				DestroyItem( from, false );
				ItemsUpdate( new int[] { (int)from, (int)to } );
				if ( (int)to < 19 || (int)from < 19 )
					foreach( Character c in account.PlayersNear )
						if ( c.Player.PlayersNear.Contains( this ) )
							ItemsUpdateForOther( c.Player.Handler );
			}
		}

		public void Autostore( Slots from, byte s )
		{
			if ( AttackTarget != null )
				StopAttacking();
			Slots where = FindAFreeSlot( s );
			if ( where == Slots.None )
			{//	that bag is full
				InventoryFailed( 51, Items[ (int)from ].Guid );
				return;
			}
			SwapInv( (Slots)from, where );
		}


		public void AutoEquip( Slots from )
		{
			if ( AttackTarget != null )
				StopAttacking();
			Item i = Items[ (int)from ];
			if ( i == null )
			{
				Console.WriteLine("Item in {0} missing", (int)from );
				return;
			}
				
			Slots where = i.CanBeEquipedIn;
			if ( i.IsContainer )
			{
				where = Slots.None;
				for( int t = 19;t < 23;t++ )
					if ( Items[ t ] == null )
					{
						where = (Slots)t;
						break;
					}
				if ( where == Slots.None )
				{
					InventoryFailed( 17, i.Guid );
					return;
				}
			}
			else
			{
				if ( where == Slots.OffHand )
				{
					if ( i.IsWeapon && !HaveSpell( 674 ) )
					{
						InventoryFailed( 7, i.Guid );
						return;
					}
				}
				if ( !CanEquip( i ) )
					return;			
			}
			if ( where != Slots.None )
				SwapInv( from, where );
		}

		public void DestroyItem( Slots it, bool deleteAfter )
		{
			if ( this.AttackTarget != null )
				this.StopAttacking();
			if ( deleteAfter )
				DestroyObject( Items[ (int)it ].Guid );

			if ( (int)it < 24 + 16 )
			{
				int offset = 4;
				Converter.ToBytes( (short)1, tempBuff, ref offset );
				Converter.ToBytes( (int)0, tempBuff, ref offset );
				Converter.ToBytes( Guid, tempBuff, ref offset );
				//Converter.ToBytes( (byte)0x1C, tempBuff, ref offset );
				ResetBitmap();

				int last = 1;
				if ( (int)it < 24 )
					setUpdateValue( last = (int)UpdateFields.PLAYER_VISIBLE_ITEM_1_0 + (int)it * 12, 0 );
				setUpdateValue( last = (int)UpdateFields.PLAYER_FIELD_INV_SLOT_HEAD + ( 2 * (int)it ), (UInt64)0  );
				FlushUpdateData( tempBuff, ref offset, 2 + ( last / 32 ) );//0, 0, 0 );
				account.Handler.Send( 0xA9, tempBuff, offset );	
				if ( (int)it < 19 )
					account.ToAllPlayerNearExceptMe( OpCodes.SMSG_UPDATE_OBJECT, tempBuff, offset );
			}
			else
			{
				int ex = 0;
				Item c = RealSlot( (int)it, ref ex );
				int offset = 4;
				Converter.ToBytes( (short)1, tempBuff, ref offset );
				Converter.ToBytes( (int)0, tempBuff, ref offset );
				Converter.ToBytes( c.Guid, tempBuff, ref offset );
				ResetBitmap();
				setUpdateValue( (int)UpdateFields.CONTAINER_FIELD_SLOT_1 + ( 2 * ex ), (UInt64)0  );
				FlushUpdateData( tempBuff, ref offset, 3 );
				account.Handler.Send( 0xA9, tempBuff, offset );	
			}
			Items[ (int)it ] = null;
		}

		Item RealSlot( int from, ref int ex )
		{
			if ( from >= 24 + 16 )
			{
				ex = ( from - 40 ) % 16;
				return Items[ 19 + ( ( from - 40 ) / 16 ) ];
			}
			return null;
		}
		public void ShowMobileInventory( UInt64 guid )
		{
			foreach( Object o in account.KnownObjects )
			{
				if ( o is Mobile )
				{ 
					Mobile m = o as Mobile;
					if ( m.Guid == guid )
					{
						if ( m is BaseCreature )
						{
							( m as BaseCreature ).SpeakingFrom = DateTime.Now;
							( m as BaseCreature ).AIState = AIStates.Speaking;
						}
						int offset = m.ShowInventory( tempBuff, this );
						account.Handler.Send( OpCodes.SMSG_LIST_INVENTORY, tempBuff, offset );
						return;
					}
				}
			}
		}
		public Slots FindAFreeSlot( byte s )
		{
			if ( s == 0xff )
			{
				for(int t = 23;t < 23 + 16;t++ )
					if ( Items[ t ] == null )
						return (Slots)t;
			}
			else
			{
				Item it = (Item)Items[ s ];
				if ( it != null )
				{
					int start = 24 + 16 + ( ( s - 19 ) * 16 );
					for(int t = start;t < start + it.ContainerSlots;t++ )
						if ( Items[ t ] == null )
							return (Slots)t;
				}
			}
			return Slots.None;
		}
		public Slots FindAFreeSlot()
		{
			for(int t = 23;t < 23 + 16;t++ )
				if ( Items[ t ] == null )
					return (Slots)t;
			for(int i = 19;i < 24;i++ )
			{
				Item it = (Item)Items[ i ];
				if ( it != null )
				{
					int start = 24 + 16 + ( ( i - 19 ) * 16 );
					for(int t = start;t < start + it.ContainerSlots;t++ )
						if ( Items[ t ] == null )
							return (Slots)t;
				}
			}
			return Slots.None;
		}
		public int FreeSlot()
		{
			int n = 0;
			for(int t = 24;t < 24 + 16;t++ )
				if ( Items[ t ] == null )
					n++;
			for(int i = 19;i < 24;i++ )
			{
				Item it = (Item)Items[ i ];
				if ( it != null )
				{
					int start = 24 + 16 + ( ( i - 19 ) * 16 );
					for(int t = start;t < start + it.ContainerSlots;t++ )
						if ( Items[ t ] == null )
							n++;
				}
			}
			return n;
		}
		void Sell( UInt64 to, UInt64 obj )
		{
			Mobile from = account.FindMobileByGuid( to );
			if ( from == null )
				return;
			if ( from is BaseCreature )
			{
				( from as BaseCreature ).SpeakingFrom = DateTime.Now;
				( from as BaseCreature ).AIState = AIStates.Speaking;
			}
			for(int s = 0;s < Items.Length;s++ )
			{
				Item i = (Item)Items[ s ];
				if ( i != null && i.Guid == obj )
				{
					//	Console.WriteLine("{0} {1}", i.SubClass, i.ObjectClass );
					if ( i.IsQuestItem )
					{//	Quest items cannot be sold
						InventoryFailed( 35, obj );
						return;
					}
					int amount = 0;
					if ( i.InventoryType == InventoryTypes.Projectile )
						amount = 0;
					else
						amount = i.MaxCount;
					Copper += (uint)( i.SellPrice * amount );
					DestroyItem( (Slots)s, true );
					SendSmallUpdate( new int[]{ (int)UpdateFields.PLAYER_FIELD_COINAGE }, new object[]{ Copper } );			
					return;
				}
			}			
		}

		public bool PutObjectInBackpack( Item it )
		{
			return PutObjectInBackpack( it, 0, Slots.None, false );
		}
		public bool PutObjectInBackpack( Item it, bool refresh )
		{
			return PutObjectInBackpack( it, 0, Slots.None, refresh );
		}
		public bool PutObjectInBackpack( Item it, int n, bool refresh )
		{
			return PutObjectInBackpack( it, n, Slots.None, refresh );
		}
		public bool PutObjectInBackpack( Item it, int n, Slots at, bool refresh )
		{
			bool put = false;
			if ( at == Slots.None || Items[ (int)at ] != null )
			{
				put = true;
				at = FindAFreeSlot();
			}
			if ( at == Slots.None )
			{
				this.InventoryFailed( 27 );
				return false;
			}
			if ( n == 0 && it.Stackable > 1 )
				it.MaxCount = it.Stackable;
			else
				it.MaxCount = n;
			//	on verifi les quetes en cours pour les deliveries
			CheckDeliveries( it );

			if ( put )
			{
				foreach( Item i in Items )
				{
					if ( i != null && i.Id == it.Id && i.MaxCount + it.MaxCount <= i.Stackable )
					{
						i.MaxCount += n;
						if ( refresh && account != null )
							i.SendTinyUpdate( new int[]{14}, new object[]{ i.MaxCount }, this );
						return true;
					}
				}
			}
			Items[ (int)at ] = it;
			if ( refresh && account != null )
			{
				int offset = 0;
				Converter.ToBytes( 1, tempBuff, ref offset );
				Converter.ToBytes( (byte)0, tempBuff, ref offset );

				it.PrepareUpdateData( tempBuff, ref offset, UpdateType.UpdateFull, this );	
				//ItemsUpdate( tempBuff, ref offset );				

				byte []res = Zip.Compress( tempBuff, 0, offset );
				byte []data = new byte[ res.Length + 8 ];
				Buffer.BlockCopy( res, 0, data, 8, res.Length );
				int t = 4;
				Converter.ToBytes( (int)offset, data, ref t );
				account.Handler.Send( 0x1F6, data, res.Length + 6 );
				ItemsUpdate( new int[] { (int)at } );
			}
			return true;
		}

		void Buy( UInt64 guid, int num, Slots slot, byte n )
		{
			Mobile from = account.FindMobileByGuid( guid );
			if ( from == null )
				return;
			if ( from is BaseCreature )
			{
				( from as BaseCreature ).SpeakingFrom = DateTime.Now;
				( from as BaseCreature ).AIState = AIStates.Speaking;
			}
			Item it = null;
			foreach( Item isell in from.Sells )
				if ( isell.Id == num )
				{
					it = isell;
					break;
				}
			if ( it == null )
				return;
			if ( slot != Slots.None && (int)slot < 25 && ( !CanEquip( it ) || it.CanBeEquipedIn != slot ) )
			{
				InventoryFailed( 3, it.Guid );
				return;
			}
			it = it.Clone();
			if ( /*account.AccessLevel == Account.AccessLevels.PlayerLevel*/true )
			{
				if ( it.BuyPrice > Copper )
				{
					InventoryFailed( 28, it.Guid );
					return;
				}
				Copper -= (uint)it.BuyPrice;
			}
			int amount = 1;
			if ( it.InventoryType == InventoryTypes.Projectile )
				amount = it.Stackable;
			if ( slot != Slots.None && Items[ (int)slot ] != null )
				PutObjectInBackpack( it, amount, Slots.None, true );
			else
				PutObjectInBackpack( it, amount, (Slots)slot, true );
		}

		public void ItemsUpdate( int []slots )
		{
			bool std = false;
			foreach( int i in slots )
			{
				if ( i > 39 )
				{
					int ex = 0;
					Item c = RealSlot( (int)i, ref ex );
					int offset = 4;
					Converter.ToBytes( (short)1, tempBuff, ref offset );
					Converter.ToBytes( (int)0, tempBuff, ref offset );
					Converter.ToBytes( c.Guid, tempBuff, ref offset );
					ResetBitmap();
					if ( Items[ i ] == null )
						setUpdateValue( (int)UpdateFields.CONTAINER_FIELD_SLOT_1 + ( 2 * ex ), (UInt64)0 );
					else
						setUpdateValue( (int)UpdateFields.CONTAINER_FIELD_SLOT_1 + ( 2 * ex ), (UInt64)Items[ i ].Guid );
					FlushUpdateData( tempBuff, ref offset, 3 );
					account.Handler.Send( 0xA9, tempBuff, offset );	
				}
				else 
					std = true;
			}
			if ( std )
				ItemsUpdate();
		}
		
		public void ItemsUpdate()
		{
			itemManaBonus = 0;
			itemHealthBonus = 0;
			int t = 0;// all.Count;
			foreach( Item i in Items )
				if ( i != null )
				{
					t++;
				}
			//byte []tempBuff = new byte[ 107 + 0x12 + 8 * t + 6 + 4 + 6 ];
			int offset = 4;
			Converter.ToBytes( (short)1, tempBuff, ref offset );
			Converter.ToBytes( (int)0, tempBuff, ref offset );
			Converter.ToBytes( Guid, tempBuff, ref offset );
			ResetBitmap();
			int pos = 0;
			int oldArmor = Armor;
			int oldResistFire = ResistFire;
			int oldResistNature = ResistNature;
			int oldResistFrost = ResistFrost;
			int oldResistShadow = ResistShadow;
			int oldResistArcane = ResistArcane;
			int oldResistLight = ResistHoly;
			int strBonus = 0;
			int iqBonus = 0;
			int staminaBonus = 0;
			int agilityBonus = 0;
			int spiritBonus = 0;
			//int manaBonus = 0;
			//int healthBonus = 0;
			ReleaseAllItemAura();
			#region bovie
			ArmorFromItems = 0;
			#endregion
			for( pos = 0;pos < 19;pos++)
			{				
				Item i = Items[ pos ];
				if ( i != null )
				{
					i.SetSpecialEffect( this );
					if ( i.Block > 0 )
						Block += i.Block;
					if ( i.Resistance[ 0 ]  > 0 )
						#region bovie
						ArmorFromItems += i.Resistance[ 0 ];
					#endregion
					if ( i.Resistance[ 2 ]  > 0 )
						this.ResistFire += i.Resistance[ 2 ];
					if ( i.Resistance[ 3 ]  > 0 )
						this.ResistNature += i.Resistance[ 3 ];
					if ( i.Resistance[ 4 ]  > 0 )
						this.ResistFrost += i.Resistance[ 4 ];
					if ( i.Resistance[ 5 ]  > 0 )
						this.ResistShadow += i.Resistance[ 5 ];
					if ( i.Resistance[ 6 ]  > 0 )
						ResistArcane += i.Resistance[ 6 ];
					if ( i.Resistance[ 1 ]  > 0 )
						ResistHoly += i.Resistance[ 1 ];
					if ( i.StrBonus != 0 )
						strBonus+= i.StrBonus;
					if ( i.StaminaBonus != 0 )
						staminaBonus+= i.StaminaBonus;
					if ( i.IqBonus != 0 )
						iqBonus+= i.IqBonus;
					if ( i.SpiritBonus != 0 )
						spiritBonus+= i.SpiritBonus;
					if ( i.AgilityBonus != 0 )
						agilityBonus+= i.AgilityBonus;
					if ( i.ManaBonus != 0 )
						itemManaBonus+= i.ManaBonus;
					if ( i.HealthBonus != 0 )
						itemHealthBonus+= i.HealthBonus;
				}	
			}
			if ( itemHealthBonus != 0 )
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_MAXHEALTH, BaseHitPoints );
			if ( itemManaBonus != 0 )
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_MAXPOWER1 + ManaType, BaseMana );
			
			setUpdateValue( (int)UpdateFields.UNIT_TRAINING_POINTS, (int)Talent );
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_STR, Str + strBonus ); //	Str
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_AGILITY, Agility + agilityBonus ); //	Ag
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_STAMINA, Stamina + staminaBonus );//	Stam
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_SPIRIT, Spirit + spiritBonus ); //	Spirit
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_IQ, Iq + iqBonus ); //	IQ
			
			
			if ( oldArmor != Armor )
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_ARMOR, Armor );
			if ( oldResistLight != ResistHoly )
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_ARMOR + 1, ResistHoly );
			if ( oldResistFire != ResistFire )
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_ARMOR + 2, ResistFire );
			if ( oldResistNature != ResistNature )
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_ARMOR + 3, ResistNature );
			if ( oldResistFrost != ResistFrost )
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_ARMOR + 4, ResistFrost );
			if ( oldResistShadow != ResistShadow )
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_ARMOR + 5, ResistShadow );
			if ( oldResistArcane != ResistArcane )
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_ARMOR + 6, ResistArcane );

			for( pos = 0;pos < 19;pos++)
			{
				Item i = Items[ pos ];
				if ( i != null )
				{
					setUpdateValue( (int)UpdateFields.PLAYER_VISIBLE_ITEM_1_0 + pos * 12, i.Id );
				}
				else
					setUpdateValue( (int)UpdateFields.PLAYER_VISIBLE_ITEM_1_0 + pos * 12, 0 );
			}
			pos = 0;
			int last = 0;
			foreach( Item i in Items )
			{
				if ( i != null )
				{
					setUpdateValue( last = (int)UpdateFields.PLAYER_FIELD_INV_SLOT_HEAD + ( 2 * pos ), i.Guid  );	
				}		
				pos++;
				if ( pos >= 24 + 16 )
					break;
			}

			setUpdateValue( last = (int)UpdateFields.PLAYER_FIELD_COINAGE, copper );

			setUpdateValue( last = (int)UpdateFields.PLAYER_FIELD_POSSTAT0, strBonus );
			setUpdateValue( last = (int)UpdateFields.PLAYER_FIELD_POSSTAT1, agilityBonus );
			setUpdateValue( last = (int)UpdateFields.PLAYER_FIELD_POSSTAT2, staminaBonus );
			setUpdateValue( last = (int)UpdateFields.PLAYER_FIELD_POSSTAT3, iqBonus );
			setUpdateValue( last = (int)UpdateFields.PLAYER_FIELD_POSSTAT4, spiritBonus );
			setUpdateValue( last = (int)UpdateFields.PLAYER_FIELD_NEGSTAT0, strBonus );
			setUpdateValue( last = (int)UpdateFields.PLAYER_FIELD_NEGSTAT1, agilityBonus );
			setUpdateValue( last = (int)UpdateFields.PLAYER_FIELD_NEGSTAT2, staminaBonus );
			setUpdateValue( last = (int)UpdateFields.PLAYER_FIELD_NEGSTAT3, iqBonus );
			setUpdateValue( last = (int)UpdateFields.PLAYER_FIELD_NEGSTAT4, spiritBonus );

			FlushUpdateData( tempBuff, ref offset, 1 + ( last / 32 ) );
			Send( OpCodes.SMSG_UPDATE_OBJECT, tempBuff, offset );	
			return;
		}

		public void ItemsUpdateForOther( PlayerHandler ph )
		{
			int t = 0;// all.Count;
			foreach( Item i in Items )
				if ( i != null )
					t++;
			int offset = 4;
			Converter.ToBytes( (short)1, tempBuff, ref offset );
			Converter.ToBytes( (int)0, tempBuff, ref offset );
			Converter.ToBytes( Guid, tempBuff, ref offset );
			ResetBitmap();
			int pos = 0;
			int last = 1;
			for( pos = 0;pos < 19;pos++)
			{
				Item i = Items[ pos ];
				if ( i != null )
				{
					setUpdateValue( (int)UpdateFields.PLAYER_VISIBLE_ITEM_1_0 + pos * 12, i.Id );
				}
				else
					setUpdateValue( (int)UpdateFields.PLAYER_VISIBLE_ITEM_1_0 + pos * 12, 0 );
			}
			pos = 0;
			for(int j = 0;j < 19;j++ )
			{
				Item i = Items[ j ];
				if ( i != null )
				{
					setUpdateValue( last = (int)UpdateFields.PLAYER_FIELD_INV_SLOT_HEAD + ( 2 * pos ), i.Guid  );	
				}		
				pos++;
			}
			FlushUpdateData( tempBuff, ref offset, 1 + ( last / 32 ) );
			ph.Send( 0xA9, tempBuff, offset );			
			return;
		}

		public void ItemsUpdateForOther( Account acc )
		{
			ItemsUpdateForOther( acc.Handler );
		}

		public void ItemsUpdate( byte []data, ref int offset )
		{
			Converter.ToBytes( (byte)UpdateType.UpdatePartial, data, ref offset );
			Converter.ToBytes( Guid, tempBuff, ref offset );
			//	Converter.ToBytes( (byte)0x1C, tempBuff, ref offset );
			ResetBitmap();
			int pos = 0;
			int last = 1;
			for( pos = 0;pos < 24;pos++)
			{
				Item i = Items[ pos ];
				if ( i != null )
				{
					setUpdateValue( (int)UpdateFields.PLAYER_VISIBLE_ITEM_1_0 + pos * 12, i.Id );
				}
				else
					setUpdateValue( (int)UpdateFields.PLAYER_VISIBLE_ITEM_1_0 + pos * 12, 0 );
			}
			pos = 0;
			foreach( Item i in Items )
			{
				if ( i != null && pos < 40 )
				{
					setUpdateValue( last = (int)UpdateFields.PLAYER_FIELD_INV_SLOT_HEAD + ( 2 * pos ), i.Guid  );	
				}		
				pos++;
			}

			setUpdateValue( last = (int)UpdateFields.PLAYER_FIELD_COINAGE, copper );
			FlushUpdateData( tempBuff, ref offset, 1 + ( last / 32 ) );
			return;
		}
		//	seulement les items visible sont envoyés aux autres joueurs
		public void ItemsUpdateForOther( byte []data, ref int offset )
		{
			Converter.ToBytes( (byte)UpdateType.UpdatePartial, data, ref offset );
			Converter.ToBytes( Guid, tempBuff, ref offset );
			//	Converter.ToBytes( (byte)0x8, tempBuff, ref offset );
			ResetBitmap();
			int pos = 0;
			int last = 1;
			for( pos = 0;pos < 19;pos++)
			{
				Item i = Items[ pos ];
				if ( i != null )
				{
					setUpdateValue( (int)UpdateFields.PLAYER_VISIBLE_ITEM_1_0 + pos * 12, i.Id );
				}
				else
					setUpdateValue( (int)UpdateFields.PLAYER_VISIBLE_ITEM_1_0 + pos * 12, 0 );
			}
			pos = 0;
			for(int t = 0;t < 19;t++ )
			{
				Item i = Items[ t ];
			{
				if ( i != null )
				{
					setUpdateValue( last = (int)UpdateFields.PLAYER_FIELD_INV_SLOT_HEAD + ( 2 * pos ), i.Guid  );	
				}		
				pos++;
			}
			}
			FlushUpdateData( tempBuff, ref offset, 1 + ( last / 32 ) );
			return;
		}
		public int FindAmountOfItemById( int id )
		{
			int amount = 0;
			foreach( Item i in Items )
			{
				if ( i != null )
				{
					if ( i.Id == id )
						amount+=i.MaxCount;
				}
			}
			return amount;
		}
		public void ConsumeItemByIdUpTo( string cl, int amount )
		{
			ConstructorInfo ci = Utility.FindConstructor( cl );
			Item it = (Item)ci.Invoke( null );
			ConsumeItemByIdUpTo( it.Id, amount );
		}
		public void ConsumeItemByIdUpTo( int id, int amount )
		{
			for( int t = 0;t < Items.Length;t++ )
			{
				Item i = Items[ t ];
				if ( i != null )
				{
					if ( i.Id == id )
					{
						if ( i.MaxCount <= amount )
						{
							amount -= i.MaxCount;
							DestroyItem( (Slots)t, true );
							if ( amount == 0 )
								return;
						}
						else
						{
							i.MaxCount -= amount;
							i.SendTinyUpdate( new int[]{ 14 }, new object[] { i.MaxCount }, this );
							return;
						}
					}
				}
			}
			return;
		}
		public bool Equip( Item i, Items.Slots s )
		{
			if ( Items[ (int)s ] == null )
			{
				//i.Equip( this, s );
				Items[ (int)s ] = i;				
				return true;
			}
			return false;
		}

		public void AutostoreLootItem( byte from )
		{
			if ( AttackTarget != null )
				StopAttacking();
			if ( this.currentObjectLooted.Treasure.Length == 0 )
				return;			

		//	int realPos = FindPosInTresorLoot( from );
		//	int t = 0;
		//	SendMessage( realPos.ToString() );
		/*	foreach( Item j in currentObjectLooted.Treasure )
			{
				if ( j == null )
					SendMessage( "Item " + t.ToString() + " null sup " + from.ToString() );
				else
					SendMessage( "Item " + t.ToString() + " " + j.Name + " sup " + from.ToString() );
				t++;
			}*/

			Item i = (Item)currentObjectLooted.Treasure[ from ];
			if ( i != null )
			{				
				if ( PutObjectInBackpack( i, 1, true ) )
				{
					tempBuff[ 4 ] = (byte)from;
					account.ToAllPlayerNear( OpCodes.SMSG_LOOT_REMOVED, tempBuff, 5 );
				
					currentObjectLooted.Treasure[ from ] = null;
					if ( SeeAnyLoot( this, currentObjectLooted.Treasure ) )
					{
						SendSmallUpdate( new int[] { (int)UpdateFields.UNIT_FIELD_FLAGS, (int)UpdateFields.UNIT_DYNAMIC_FLAGS }, new object[] { (int)Flags, DynFlags( this ) } );
					}
				}
			}
		}

		public Item FindItemById( int id )
		{
			foreach( Item i in Items )
				if ( i != null && i.Id == id )
					return i;
			return null;
		}
		public Item FindItemById( int id, out Slots slot )
		{
			slot = Slots.None;
			int t = 0;
			foreach( Item i in Items )
			{
				if ( i != null && i.Id == id )
				{
					slot = (Slots)t;
					return i;
				}
				t++;
			}
			return null;
		}
		public Item FindItemByGuid( UInt64 guid )
		{
			foreach( Item i in Items )
				if ( i != null && i.Guid == guid )
					return i;
			return null;
		}
		public int previousSpellCasted = 0;
		public void ReleaseLoot()
		{
			Object o = FindObjectByGuid( lootOwner );
			if ( o is GameObject )
			{
				GameObject go = o as GameObject;
				if ( go.OnRelease( this ) )
				{

						if ( go.SpawnerLink != null )
						{
							go.SpawnerLink.Release( go );
							//go.SpawnerLink.CurrentAmount--;
						}
					//	World.Remove( go, this );
					
				}
			}
			lootOwner = 0;
			if ( previousSpellCasted != 0 )
			{
				cast.id = previousSpellCasted;
				SpellFaillure( (SpellFailedReason)8 );
				previousSpellCasted = 0;
			}
		}
		public Item FindItemInGameObjectById( UInt64 guid, int id )
		{
			if ( currentObjectLooted == null || this.currentObjectLooted.Treasure.Length == 0 )
				return null;
			if ( lootOwner != guid )
				return null;
			foreach( Item i in currentObjectLooted.Treasure )
			{
				if ( i.Id == id )
					return i;
			}
			return null;
		}
		public void SendItem( int id, UInt64 guid )
		{
			int offset = 4;
			Item i = null;
			if ( guid > 0xF000000000000000 )			
			{
				Mobile m = account.FindMobileByGuid( guid );
				if ( m != null )
					i = m.FindItemById( id );
			}
			else
				if ( ( guid & 0x4000000000000000 ) != 0 )
			{
				i = FindItemByGuid( guid );
				if ( i == null )//	alors c'est un objet sur un autre perso !!!
				{
					foreach( Character c in Player.PlayersNear )
					{
						i = c.FindItemByGuid( guid );
						if ( i != null )
							break;
					}
				}
			}
			else
				if ( ( guid & 0xB000000000000000 ) == 0xB000000000000000 )
				i = World.CreateItemInPoolById( id );
			else
				if ( ( guid & 0xA000000000000000 ) != 0 )
				i = FindItemInGameObjectById( guid, id );
			else
				i = FindItemById( id );

			if ( i == null )
			{
				if ( id == 0x1FE4 )//|| id == 0x40000000 )
				{
					i = new TestStationeryFake();
					i.Guid = 0;
				}
				else
					if ( id == 0x245F )
				{
					i = new DefaultStationeryFake();
					i.Guid = 0;
				}
				else
					if ( id == 18154 )
				{
					i = new BlizzardStationeryFake();
					i.Guid = 0;
				}
				else//	Alors c'est un loot
				{
					i = World.CreateItemInPoolById( id );
				}
			}
			if ( i == null )
			{
				i = new BlizzardStationeryFake();
				i.Guid = 0;
			}
			i.PrepareData( tempBuff, ref offset );
			Player.Handler.Send( (int)OpCodes.SMSG_ITEM_QUERY_SINGLE_RESPONSE, tempBuff, offset );
		}



		public void SendAllItems()
		{
			foreach( Item i in Items )
			{
				if ( i != null )
				{
					int offset = 4;
					i.PrepareData( tempBuff, ref offset );
					Player.Handler.Send( (int)OpCodes.SMSG_ITEM_QUERY_SINGLE_RESPONSE, tempBuff, offset );
				}
			}
			return;
		}
		#endregion

		#region GAMEOBJECTS

		public GameObject InsideFishingZone()
		{
			foreach( Object o in account.KnownObjects )
			{
				if ( o is GameObject )
				{
					GameObject go = (GameObject)o;
					if ( go.Sound[ 0 ] == 1 )
						if ( Distance( o ) < 20f )
							return go;
				}
			}
			return null;
		}
/*
		public class CastMiningSpell : WowTimer
		{
			Character to;
			Object target;
			public CastMiningSpell( Character t, Object targe ) :  base( WowTimer.Priorities.Milisec100 , 2500 )
			{
				to = t;
				target = targe;
				byte []buff = { 0,0, 0,0, 0xD9, 0xDB, 0x74, 0x00, 0x00, 0x00, 0x00, 0x00, 0xD9, 0xDB, 0x74, 0x00, 0x00, 0x00, 0x00, 0x00, 0x44, 0x03, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
				int offset = 4;
				int spell = 2656;
				Converter.ToBytes( t.Guid, buff, ref offset );
				Converter.ToBytes( target.Guid, buff, ref offset );
				Converter.ToBytes( spell, buff, ref offset );
				Converter.ToBytes( 0x100, buff, ref offset );
				Converter.ToBytes( 0, buff, ref offset );
				to.Send( OpCodes.SMSG_SPELL_START, buff );

				Start();
			}
			public override void OnTick()
			{
				int spell = 2656;
				//	Release
				byte []releaseEffect = { 0, 0, 0, 0, 0xED, 0x0E, 0x00, 0x00, 0x01 };
				int offset = 4;
				Converter.ToBytes( spell, releaseEffect, ref offset );
				to.Send( OpCodes.SMSG_CAST_RESULT, releaseEffect );
				//	Instant effet
				byte []effect = { 0, 0, 0, 0, 0xC2, 0x36, 0x21, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF7, 0x36, 0x21, 0x00, 0x00, 0x00, 0x00, 0x00, 0xED, 0x0E, 0x00, 0x00, 0x00, 0x01, 0x01, 0xC2, 0x36, 0x21, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
				offset = 4;
				Converter.ToBytes( to.Guid, effect, ref offset );
				Converter.ToBytes( target.Guid, effect, ref offset );
				Converter.ToBytes( (int)spell, effect, ref offset );
				offset+=4;
				to.Send( OpCodes.SMSG_SPELL_GO, effect );
				//to.TrainerBuyAck( teach );
				
				Stop();
				base.OnTick();
			}
		}
*/
		public void GameObjectUse( UInt64 guid )
		{
			GameObject go = (GameObject)this.FindGameObjectByGuid( guid );
			if ( go == null )
				return;
			if ( !go.OnUse( this ) )
				return;
		//	if ( go.Sound[ 0 ] == 3 && go.Sound[ 1 ] == 0xa )
			{//	Forge
		//		CastMiningSpell aa = new CastMiningSpell( this, this );
			}
		}
		#endregion
	
		#region bovies changes
		public float BaseCritChance
		{
			get
			{
				try
				{
					float critChance = 0;
					Item weapon = activeWeapon;
					if ( weapon == null )
					{				
						weapon = activeWeapon = ChooseWeapon();
					}
					switch (this.Classe)
					{
						
						case Classes.Warrior : critChance = 5f;;
							if (this.Level > 9)
							{
								/* no in talents now... :-(
										if (this.HaveTalent(Talents.AxeSpecialization) && weapon.SubClass == 0 )
											{
												AuraEffect effect1 = (AuraEffect) this.GetTalentEffect(Talents.AxeSpecialization);
												critChance +=effect1.S1;
											}
										*/
								if (this.HaveTalent(Talents.PolearmSpecialization) && weapon.SubClass == 6 )
								{
									AuraEffect effect1 = (AuraEffect) this.GetTalentEffect(Talents.PolearmSpecialization);
									critChance +=effect1.S1;
								}
								if (this.HaveTalent(Talents.Cruelty) && weapon.ObjectClass == 2)
								{
									AuraEffect effect1 = (AuraEffect) this.GetTalentEffect(Talents.Cruelty);
									critChance +=effect1.S1;
								}
							}
							break;
						
						default : critChance = 5;break;
					}
				 
					int skid = weapon.GetSkillId();
					Skill sk2 = this.AllSkills[(ushort)skid];
					return critChance -=(float)(0.04*(sk2.Cap(this) - sk2.CurrentVal(this)));
				}
				catch
				{
					return 0;
				}
			}
		}
		public float BaseDodgeChance
		{
			get
			{
				float dodgeChance = 5;
				
				Skill sk = this.AllSkills[(ushort)DefenseSkill.SkillId];
				switch (this.Classe)
				{
					case Classes.Rogue : dodgeChance = (float)((float)Agility/(1.15 + ((float)this.BaseAgility)/20) - (this.Level*5 - sk.CurrentVal(this))*0.04); break;
					default : dodgeChance = (float)(5 - (this.Level*5 - sk.CurrentVal(this))*0.04);break;
				}
				return dodgeChance;

			}
		}
		public float BaseBlockChance
		{
			get 
			{
				float blockChance = 0;
				
				Skill sk = this.AllSkills[(ushort)DefenseSkill.SkillId];
				blockChance = (float)(5 - (this.Level*5 - sk.CurrentVal(this))*0.04);
				return blockChance;
			}
			
		}
		public float BaseParryChance
		{
			get 
			{
				float parryChance = 0;
				
				Skill sk = this.AllSkills[(ushort)DefenseSkill.SkillId];
				parryChance = (float)(5 - (this.Level*5 - sk.CurrentVal(this))*0.04);
				return parryChance;
			}
		}
		public float BaseMinDamage
		{
			get 
			{
				int damageBonusFromTalents = 0;
				float minDMG = 0;
				if (this.activeWeapon != null)
				{
					minDMG += this.activeWeapon.PhysicalMinDamage + ((float)this.AttackPower/14f)*(float)this.AttackSpeed/1000 + this.MeleeDamageBonus - this.MeleeDamageMalus + this.AllDamageDoneBonus - this.AllDamageDoneMalus;
				}
				minDMG *= 1 + ((float)this.MeleePercentDamageBonus - (float)this.MeleePercentDamageMalus)/100;
				minDMG *= (1+(float)damageBonusFromTalents/100);
				return minDMG;

			}
		}
		public float BaseModDamage
		{
			get
			{
				int damageBonusFromTalents = 0;
				/*	switch ( Classe )
					{
						case Classes.Rogue : break;
						case Classes.Hunter : break;
						case Classes.Warrior : break;
					}*/
				float minDMG = 1;
				if (this.activeWeapon != null)
				{
					minDMG *= 1 + ((float)this.MeleePercentDamageBonus - (float)this.MeleePercentDamageMalus)/100 + this.AllDamageDoneBonus - this.AllDamageDoneMalus;
				}
				minDMG *= (1+(float)damageBonusFromTalents/100)*this.AllDamageDoneModifier;
				return minDMG;

			}
		}
		public float BaseMaxDamage
		{
			get 
			{
				int damageBonusFromTalents = 0;
				/*	switch (this.Classe)
					{
						case Classes.Rogue : break;
						case Classes.Hunter : break;
						case Classes.Warrior : break;
					}*/
				float maxDMG = 0;
				if (this.activeWeapon != null)
				{
					maxDMG += this.activeWeapon.PhysicalMaxDamage + ((float)this.AttackPower/14f)*(float)this.AttackSpeed/1000 + this.MeleeDamageBonus - this.MeleeDamageMalus;
				//	Console.WriteLine(maxDMG);
				}
				maxDMG *= 1 + ((float)this.MeleePercentDamageBonus - (float)this.MeleePercentDamageMalus)/100;
				maxDMG *= (1+(float)damageBonusFromTalents/100);
				return maxDMG;

			}

		}
		#endregion

		#region UPDATES
		public void SendSkillUpdate()
		{
			int []all = new int[ AllSkills.Count * 3 ];
			object []dat = new object[  AllSkills.Count * 3 ];
			int skills = (int)UpdateFields.PLAYER_SKILL_INFO_1_1;
			int t = 0;
			IDictionaryEnumerator Enumerator = AllSkills.GetEnumerator();
			while( Enumerator.MoveNext() )
			{
				ushort sid = (ushort)Enumerator.Key;
				Skill val = (Skill)Enumerator.Value;
				all[ t ] = (int)skills;
				dat[ t ] = (int)val.Id;
				skills++;
				t++;
				all[ t ] = (int)skills;
				dat[ t ] = (int)( (int)val.CurrentVal(this) ) + ( (int)val.Cap( this ) << 16 );
				skills++;
				t++;
				all[ t ] = (int)skills;
				dat[ t ] = (int)0;
				skills++;
				t++;
			}
			this.SendSmallUpdate( all, dat );
		}

		public void toData( ref byte[] data, ref int t )
		{
			char []n = Name.ToCharArray();
			
			byte []temp = BitConverter.GetBytes( Guid );
			foreach( byte b in temp )
				data[ t++ ] = b;
			foreach( char c in n )
				data[ t++ ] = (byte)c;
			data[ t++ ] = 0;
			data[ t++ ] = (byte)race;
			data[ t++ ] = (byte)Classe;
			data[ t++ ] = gender;
			data[ t++ ] = skin;
			data[ t++ ] = face;
			data[ t++ ] = hairStyle;
			data[ t++ ] = hairColour;
			data[ t++ ] = facialHair;
			data[ t++ ] = (byte)Level;
			//data[ t++ ] = outfitID = 1;
			temp = BitConverter.GetBytes( (uint)ZoneId );
			foreach( byte b in temp )
				data[ t++ ] = b;
			temp = BitConverter.GetBytes( (uint)MapId );
			foreach( byte b in temp )
				data[ t++ ] = b;
			temp = BitConverter.GetBytes( X );
			foreach( byte b in temp )
				data[ t++ ] = b;
			temp = BitConverter.GetBytes( Y );
			foreach( byte b in temp )
				data[ t++ ] = b;
			temp = BitConverter.GetBytes( Z );
			foreach( byte b in temp )
				data[ t++ ] = b;
			temp = BitConverter.GetBytes( GuildId );
			foreach( byte b in temp )
				data[ t++ ] = b;
			data[ t++ ] = 02;//unknow;
			temp = BitConverter.GetBytes( PetDisplayId = 1 );
			foreach( byte b in temp )
				data[ t++ ] = b;
			temp = BitConverter.GetBytes( PetLevel );
			foreach( byte b in temp )
				data[ t++ ] = b;
			temp = BitConverter.GetBytes( PetCreatureFamily );
			foreach( byte b in temp )
				data[ t++ ] = b;

			temp = BitConverter.GetBytes( 0 );// unknown
			
			foreach( byte b in temp )
				data[ t++ ] = b;

			for(int i = 0;i < 20;i++ )
			{
				if ( Items[ i ] != null )
				{					
					temp = BitConverter.GetBytes( Items[ i ].Model );
					foreach( byte b in temp )
						data[ t++ ] = b;
					data[ t++ ] = (byte)Items[ i ].InventoryType;
				}
				else
				{
					data[ t++ ] = 0;
					data[ t++ ] = 0;
					data[ t++ ] = 0;
					data[ t++ ] = 0;
					data[ t++ ] = 0;
				}
			}			
		}

		//	au loggin il faut tout envoyer, objets du perso, le perso, tout les mobiles visibles
		public void FullUpdate( ArrayList all )
		{
			int t = all.Count;
			foreach( Item i in Items )
			{
				if ( i != null )
					t++;
			}
			if ( t == 0 )
			{
				account.Handler.Send( new byte[] { 0x0, 0x0D, 0xF6, 0x01, 0x05, 0x00, 0x00, 0x00, 0x78, 0x5E, 0x63, 0x60, 0x00, 0x02, 0x00} );
				return;
			}

			int offset = 0;
			
			Converter.ToBytes( (int)t, tempBuff, ref offset );
			Converter.ToBytes( (byte)0, tempBuff, ref offset );

			foreach( Item i in Items )
			{
				if ( i != null )
					i.PrepareUpdateData( tempBuff, ref offset, UpdateType.UpdateFull, this );
			}

			foreach( Object m in all )
			{
				if ( m != this && m is Character )
				{
					( m as Character ).PrepareUpdateDataForOther( tempBuff, ref offset, UpdateType.UpdateFull, this );						
					//t++;//	compte un de plus pour le item update
					for(int j = 0;j < 24;j++ )
					{
						Item i = ( m as Character ).Items[ j ];
						if ( i != null )
						{
							t++;
							i.PrepareUpdateData( tempBuff, ref offset, UpdateType.UpdateFull, ( m as Character ) );
						}
					}
					//( m as Character ).ItemsUpdateForOther( tempBuff, ref offset );
				}
				else
				{
					m.PrepareUpdateData( tempBuff, ref offset, UpdateType.UpdateFull, false, this );
				}				
			}
			//	PrepareUpdateData( tempBuff, ref offset, UpdateType.UpdateFull );

			int len = t;
			t = 0;
			Converter.ToBytes( (int)len, tempBuff, ref t );
			t = len;
			/*	Debug.WriteLine("1F6 full pour " + Name );
				string f6 = "";
				for(int t1 = 0;t1 < offset;t1++ )
					f6 += tempBuff[ t1 ].ToString( "X2" ) + " ";
				Debug.WriteLine( f6 );
	*/
			byte []res = Zip.Compress( tempBuff, 0, offset );

			byte []data = new byte[ res.Length + 8 ];
			Buffer.BlockCopy( res, 0, data, 8, res.Length );
			
			t = 4;
			Converter.ToBytes( (int)offset, data, ref t );

			account.Handler.Send( 0x1F6, data, res.Length + 6 );
			//foreach( Mobile m in all )
			//	m.MovementHeartBeat( account.Handler, this );
		}
		//	mise a jour partiel, seulement les mobiles
		public void PartialUpdate( ArrayList all )
		{

			int t = all.Count;
			if ( t == 0 )
			{
				//	account.Handler.Send( new byte[] { 0x0, 0x0D, 0xF6, 0x01, 0x05, 0x00, 0x00, 0x00, 0x78, 0x5E, 0x63, 0x60, 0x00, 0x02, 0x00} );
				return;
			}

			int offset = 0;
			
			Converter.ToBytes( (int)t, tempBuff, ref offset );
			Converter.ToBytes( (byte)0, tempBuff, ref offset );

			foreach( Object m in all )
			{
				if ( m == this || !( m is Character ) )
					m.PrepareUpdateData( tempBuff, ref offset, UpdateType.UpdateFull, false, this );
				else
				{
					( m as Character ).PrepareUpdateDataForOther( tempBuff, ref offset, UpdateType.UpdateFull, this );						
					for(int j = 0;j < 24;j++ )
					{
						Item i = ( m as Character ).Items[ j ];
						if ( i != null )
						{
							t++;
							i.PrepareUpdateData( tempBuff, ref offset, UpdateType.UpdateFull, ( m as Character ) );
						}
					}
				}
			}

			int len = t;
			t = 0;
			Converter.ToBytes( (int)len, tempBuff, ref t );
			t = len;
			/*		Console.WriteLine("1F6 partial pour {0}", Name );
					for(int t1 = 0;t1 < offset;t1++ )
						Console.Write("{0} ", tempBuff[ t1 ].ToString( "X2" ) );
					Console.WriteLine("");*/
			byte []res = Zip.Compress( tempBuff, 0, offset );

			byte []data = new byte[ res.Length + 8 ];
			Buffer.BlockCopy( res, 0, data, 8, res.Length );
			t = 4;
			Converter.ToBytes( (int)offset, data, ref t );
			account.Handler.Send( 0x1F6, data, res.Length + 6 );
		}

		public void JustLittleUpdate( int pos, uint val, byte []data, ref int offset )
		{
			data[ offset++ ] = (byte)UpdateType.UpdatePartial;
			Converter.ToBytes( Guid, data, ref offset );
			data[ offset++ ] = (byte)0x1C;
			pos -= 8;
			int l = pos >> 3;
			int m = pos % 8;
			m = 1 << m;
			Buffer.BlockCopy( Object.Blank, 0, data, offset, Object.Blank.Length );
			offset += l;
			data[ offset++ ] = (byte)m;
			offset += ( 111 - l );
			Converter.ToBytes( val, data, ref offset );
		}
		public void SendSmallUpdateFor( UInt64 g, int []pos, object []val )
		{
			int offset = 4;
			tempBuff[ offset++ ] = (byte)1;
			Converter.ToBytes( 0, tempBuff, ref offset );
			tempBuff[ offset++ ] = (byte)UpdateType.UpdatePartial;
			Converter.ToBytes( g, tempBuff, ref offset );
			int max = 2 + ( ( pos[ pos.Length - 1 ] + 1 ) / 32 );
			if ( max > 0x24 )
				max = 0x24;

			tempBuff[ offset++ ] = (byte)max;//0x1C;
			Buffer.BlockCopy( Object.Blank, 0, tempBuff, offset, Object.Blank.Length );
			foreach( int p in pos )
			{
				int rpos  = p;
				int l = rpos >> 3;
				int m = rpos & 0x7;
				m = 0x1 << m;//( 7 - m );								
				tempBuff[ offset + l ] += (byte)m;				
			}
			offset += max * 4;// 112;
			foreach( object o in val )
			{
				Converter.ToBytes( o, tempBuff, ref offset );
			}
			/*Console.WriteLine("ToAllPlayerNear");
			for(int t = 0;t < offset;t++ )
				Console.Write("{0} ", tempBuff[ t ].ToString( "X2" ) );
			Console.WriteLine("");*/
			Send( OpCodes.SMSG_UPDATE_OBJECT, tempBuff, offset );
		}
		public override void SendSmallUpdate( int []pos, object []val )
		{
			int offset = 4;
			tempBuff[ offset++ ] = (byte)1;
			Converter.ToBytes( 0, tempBuff, ref offset );
			tempBuff[ offset++ ] = (byte)UpdateType.UpdatePartial;
			Converter.ToBytes( Guid, tempBuff, ref offset );
			int max = 2 + ( ( pos[ pos.Length - 1 ] + 1 ) / 32 );
			if ( max > 0x24 )
				max = 0x24;

			tempBuff[ offset++ ] = (byte)max;//0x1C;
			Buffer.BlockCopy( Object.Blank, 0, tempBuff, offset, Object.Blank.Length );
			foreach( int p in pos )
			{
				int rpos  = p;
				int l = rpos >> 3;
				int m = rpos & 0x7;
				m = 0x1 << m;//( 7 - m );								
				tempBuff[ offset + l ] += (byte)m;				
			}
			offset += max * 4;// 112;
			foreach( object o in val )
			{
				Converter.ToBytes( o, tempBuff, ref offset );
			}
			/*Console.WriteLine("ToAllPlayerNear");
			for(int t = 0;t < offset;t++ )
				Console.Write("{0} ", tempBuff[ t ].ToString( "X2" ) );
			Console.WriteLine("");*/
			Send( OpCodes.SMSG_UPDATE_OBJECT, tempBuff, offset );
		}

		public override void SendSmallUpdateToPlayerNearMe( UInt64 guid, int []pos, object []val )
		{
			int offset = 4;
			tempBuff[ offset++ ] = (byte)1;
			Converter.ToBytes( 0, tempBuff, ref offset );
			tempBuff[ offset++ ] = (byte)UpdateType.UpdatePartial;
			Converter.ToBytes( guid, tempBuff, ref offset );
			int max = 2 + ( pos[ pos.Length - 1 ] / 32 );
			if ( max > 0x24 )
				max = 0x24;
			tempBuff[ offset++ ] = (byte)max;//0x1C;
			Buffer.BlockCopy( Object.Blank, 0, tempBuff, offset, max * 4 );
			foreach( int p in pos )
			{
				int rpos  = p;
				int l = rpos >> 3;
				int m = rpos & 0x7;
				m = 0x1 << m;//( 7 - m );								
				tempBuff[ offset + l ] += (byte)m;				
			}
			offset += max * 4;// 112;
			foreach( object o in val )
			{
				Converter.ToBytes( o, tempBuff, ref offset );
			}
			account.ToAllPlayerNear( OpCodes.SMSG_UPDATE_OBJECT, tempBuff, offset );
		}
		public override void SendSmallUpdateToPlayerNearMe( int []pos, object []val )
		{
			SendSmallUpdateToPlayerNearMe( Guid, pos, val );
		}


		public void PreparePartielUpdateDataHeader( byte []data, ref int offset )
		{
			Converter.ToBytes( 1, data, ref offset );
			data[ offset++ ] = (byte)0;
			data[ offset++ ] = (byte)UpdateType.UpdatePartial;
			Converter.ToBytes( Guid, data, ref offset );
			ResetBitmap();
			data[ offset++ ] = (byte)0x1C;
		}/*
		public override void PreparePartielUpdateData( byte []data, ref int offset )
		{
			PreparePartielUpdateDataHeader( data, ref offset );
			setUpdateValue( 23,(short)0x00 );//	unknow	
			setUpdateValue( 28,(short)0x00 );//	unknow			
			setUpdateValue( 29,(int)BaseHitPoints );//	unknow			
			setUpdateValue( 131, Model );
			setUpdateValue( 132, Model );
			setUpdateValue( 133, 0x0 );
			setUpdateValue( 139, (float)4.28 );
			setUpdateValue( 140, (float)4.28 );
			setUpdateValue( 155, (int)Str );
			setUpdateValue( 156, (int)Agility );
			setUpdateValue( 157, (int)Stamina );
			setUpdateValue( 158, (int)Iq );
			setUpdateValue( 159, (int)Spirit );
			setUpdateValue( 160, (int)Armor );

			setUpdateValue( 161, (UInt64)0 );
			setUpdateValue( 163, (UInt64)0 );


			setUpdateValue( 165, 0x0 );
			setUpdateValue( 166, 0x0 );
			setUpdateValue( 173, 0x0 );
			setUpdateValue( 174, 0x0 );
			setUpdateValue( 823, 0x0 );
			setUpdateValue( 824, 0x0 );
			setUpdateValue( 825, 0x0 );
			setUpdateValue( 826, 0x0 );
			setUpdateValue( 827, 0x0 );

			FlushUpdateData( data, ref offset, 0, 0, 0 );

			for(int i = 0;i < offset;i++ )
				Console.Write( "{0} ", data[ i ].ToString( "X2" ) );
			Console.WriteLine("");
		}

		*/
		public void PrepareUpdateDataForOther( byte []data, ref int offset, UpdateType type )
		{
			PrepareUpdateData( data, ref offset, type, true, this );
		}

		public override void PrepareUpdateData( byte []data, ref int offset, UpdateType type, bool forOther )
		{
			PrepareUpdateData( data, ref offset, type, false, this );
		}
		public void PrepareUpdateDataForOther( byte []data, ref int offset, UpdateType type, Character f )
		{
			PrepareUpdateData( data, ref offset, type, true, f );
		}
		public override void PrepareUpdateData( byte []data, ref int offset, UpdateType type, bool forOther, Character f )
		{
#if TESTCONSECUTIF
			activateorder = true;
			Object.order = 0;
#endif
			Console.WriteLine("PrepareUpdateData 1");
			int start = offset;
			if ( type == UpdateType.UpdateFull )
				data[ offset++ ] = 2;
			else
			{
				PreparePartielUpdateData( data, ref offset );
				return;
			}			
			Console.WriteLine("PrepareUpdateData 2");
			Converter.ToBytes( Guid, data, ref offset );			
			ResetBitmap();
			Converter.ToBytes( (byte)4, data, ref offset );
			Converter.ToBytes( (int)0, data, ref offset );
			Converter.ToBytes( (int)0, data, ref offset );//	Movement flags
			Converter.ToBytes( X, data, ref offset );
			Converter.ToBytes( Y, data, ref offset );
			Converter.ToBytes( Z, data, ref offset );
			Converter.ToBytes( Orientation, data, ref offset );
			/*	if ( Player.AccessLevel != AccessLevels.PlayerLevel )
						{
							WalkSpeed = RunSpeed = 40f;
						}*/
			Converter.ToBytes( 0f, data, ref offset );

			Converter.ToBytes( WalkSpeed, data, ref offset );
			Converter.ToBytes( RunSpeed, data, ref offset );
			Converter.ToBytes( SwimBackSpeed, data, ref offset );
			Converter.ToBytes( SwimSpeed, data, ref offset );			
			Converter.ToBytes( (float)4.5f, data, ref offset );//	turn rate
			Converter.ToBytes( (float)Math.PI, data, ref offset );//	turn rate
			if ( forOther )
				Converter.ToBytes( (uint)0, data, ref offset );//	Movement flags
			else
				Converter.ToBytes( (uint)1, data, ref offset );//	Movement flags
			Converter.ToBytes( (uint)1, data, ref offset );//	Movement flags

			Converter.ToBytes( 0, data, ref offset );
			Converter.ToBytes( 0, data, ref offset );
			Converter.ToBytes( 0, data, ref offset );
		
			setUpdateValue( Const.OBJECT_FIELD_GUID, Guid );			
			setUpdateValue( Const.OBJECT_FIELD_TYPE, 25 );
			setUpdateValue( Const.OBJECT_FIELD_ENTRY, 0 );
			setUpdateValue( Const.OBJECT_FIELD_SCALE_X, (float)1.0 );
			if ( Summon != null )
			{
				//	setUpdateValue( (int)UpdateFields.UNIT_FIELD_CHARM, Summon.Guid );
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_SUMMON, Summon.Guid );
			}
			Console.WriteLine("PrepareUpdateData 3");
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_HEALTH, HitPoints );			
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_POWER1 + ManaType, Mana );//	unknow			
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_MAXHEALTH, BaseHitPoints );//	unknow		
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_MAXPOWER1 + ManaType, BaseMana );//	unknow		
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_LEVEL, Level );	
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_FACTIONTEMPLATE, (int)Faction );//	unknow	
			//	setUpdateValue( 37,(short)( (int)race << 8 ) );//	unknow
			Console.WriteLine("PrepareUpdateData 4");		
			uint flags = (uint)( ( (uint)race ) + ( (int)Classe  << 8 ) + ( gender << 16 ) + ((uint)(manaType)<<24) );
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_BYTES_0, flags );


			if ( !forOther )
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_FLAGS, Flags ); 
			else
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_FLAGS, Flags ); 
			//	Aura

			foreach( AuraReleaseTimer arts in Auras )
			{
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_AURA + arts.num, (int)arts.ae.Id );

				//	SendSmallUpdateToPlayerNearMe( new int[] { (int)UpdateFields.UNIT_FIELD_AURA + num, (int)UpdateFields.UNIT_FIELD_AURALEVELS, (int)UpdateFields.UNIT_FIELD_AURAAPPLICATIONS, (int)UpdateFields.UNIT_FIELD_AURAFLAGS, (int)UpdateFields.UNIT_FIELD_AURASTATE }, new object[] { (int)ae.Id, ae.Applications, 0, 0xdddddddd, 0x2 } );
			}
			Console.WriteLine("PrepareUpdateData 5");
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_AURALEVELS, 0 );
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_AURAAPPLICATIONS, 0 );
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_AURAFLAGS,  0xdddddddd );
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_AURASTATE, 2 );


			setUpdateValue( (int)UpdateFields.UNIT_FIELD_BASEATTACKTIME, 0x000007D0 );
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_BASEATTACKTIME_01, 0x000007D0 );
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_BOUNDINGRADIUS, (float)0.389 );//	Bounding radius
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_COMBATREACH, (float)0.389 );//0x40400000 ); Combat reach
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_DISPLAYID, Model );//	model, 0x61C
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_NATIVEDISPLAYID, Model );
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_MOUNTDISPLAYID, MountModel );
			Console.WriteLine("PrepareUpdateData 6");

			if ( activeWeapon == null )
			{				
				activeWeapon = ChooseWeapon();
			}			
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_MINDAMAGE, this.BaseMinDamage );//	min damage
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_MAXDAMAGE, this.BaseMaxDamage );//	max damage

			setUpdateValue( (int)UpdateFields.UNIT_FIELD_BYTES_1, (int)StandState );
			if ( !forOther )
				setUpdateValue( (int)UpdateFields.UNIT_DYNAMIC_FLAGS, DynFlags( f ) );			
			Console.WriteLine("PrepareUpdateData 7");			
			if ( !forOther )
			{				
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_STR, (uint)Str ); //	Str
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_AGILITY, (uint)Agility ); //	Ag
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_STAMINA, (uint)Stamina );//	Stam
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_IQ, (uint)Iq ); //	IQ
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_SPIRIT, (uint)Spirit ); //	Spirit
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_ARMOR, (uint)Armor );//	armor


				setUpdateValue( (int)UpdateFields.UNIT_FIELD_ARMOR + 1, (uint)this.ResistHoly );//	semble etre resistance
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_ARMOR + 2,(uint)this.ResistFire );			
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_ARMOR + 3, (uint)this.ResistNature );
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_ARMOR + 4, (uint)this.ResistFrost );
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_ARMOR + 5,(uint)this.ResistShadow );
				setUpdateValue( (int)UpdateFields.UNIT_FIELD_ARMOR + 6,(uint)this.ResistArcane );
			}
			Console.WriteLine("PrepareUpdateData 8");
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_ATTACKPOWER, AttackPower );//	Attack power
			setUpdateValue( (int)UpdateFields.UNIT_FIELD_RANGEDATTACKPOWER, RangedAttackPower );//	Attack power

			if ( Player.AccessLevel == AccessLevels.PlayerLevel )
				setUpdateValue( (int)UpdateFields.PLAYER_FLAGS, 0x00000000 );
			else
				setUpdateValue( (int)UpdateFields.PLAYER_FLAGS, 0x00000008 );

			//	setUpdateValue( (int)UpdateFields.PLAYER_BYTES, 0 );
			uint t1 = (uint)( ((uint)skin) | ((uint)face << 8) | ((uint)hairStyle << 16) | ((uint)this.hairColour << 24) );
			uint t2 = (uint)( 0x0101EE00 + (uint)facialHair );
			setUpdateValue( (int)UpdateFields.PLAYER_BYTES, t1 );
			setUpdateValue( (int)UpdateFields.PLAYER_BYTES_2, t2 );
			//setUpdateValue( (int)UpdateFields.PLAYER_BYTES_3 + 1, 0 );
			Console.WriteLine("PrepareUpdateData 9");			
		
			if ( !forOther )
			{
				int questlog = (int)UpdateFields.PLAYER_QUEST_LOG_1_1;
				for (int i = 0 ; i < 20; i++)
				{
					if ( activeQuests[ i ] != null )
					{
						Console.WriteLine("PrepareUpdateData 10");
						setUpdateValue( ( questlog + ( i * 3 ) ), (UInt32)activeQuests[ i ].Id );
						if ( activeQuests[ i ].HaveDeliveryObj )
						{							
							setUpdateValue( ( questlog + 1 + ( i * 3 ) ), (UInt32)activeQuests[ i ].DeliveryCurrentAmount() );
						}
						else
							setUpdateValue( ( questlog + 1 + ( i * 3 ) ), (UInt32)activeQuests[ i ].NpcObjCurrentAmount( activeQuests[ i ].Id ) );
						setUpdateValue( ( questlog + 2 + ( i * 3 ) ), (UInt32)0 );
						Console.WriteLine("PrepareUpdateData 11");
					}
					else
					{
						Console.WriteLine("PrepareUpdateData 12");
						setUpdateValue( ( questlog + ( i * 3 ) ), (UInt32)0 );
						setUpdateValue( ( questlog + 1 + ( i * 3 ) ), (UInt32)0 );
						setUpdateValue( ( questlog + 2 + ( i * 3 ) ), (UInt32)0 );
						Console.WriteLine("PrepareUpdateData 13");
					}
				}
				int mrealxp = Mobile.xpNeeded[ Level ];
				if ( Level > 1 )
				{
					Console.WriteLine("PrepareUpdateData 14");
					uint realxp = (uint)( Exp - Mobile.xpNeeded[ Level - 1 ] );
					mrealxp = ( Mobile.xpNeeded[ Level ] - Mobile.xpNeeded[ Level - 1 ] );
					setUpdateValue( (int)UpdateFields.PLAYER_XP, (UInt32)realxp ); //	xp max 342
					Console.WriteLine("PrepareUpdateData 15");
				}
				else
					setUpdateValue( (int)UpdateFields.PLAYER_XP, (UInt32)Exp ); //	xp max 342
				Console.WriteLine("PrepareUpdateData 16");
				setUpdateValue( (int)UpdateFields.PLAYER_NEXT_LEVEL_XP, mrealxp ); //	xp max 342

				int skills = (int)UpdateFields.PLAYER_SKILL_INFO_1_1;
				Console.WriteLine("PrepareUpdateData 17");
				IDictionaryEnumerator Enumerator = AllSkills.GetEnumerator();
				while( Enumerator.MoveNext() )
				{
					ushort sid = (ushort)Enumerator.Key;
					Skill val = (Skill)Enumerator.Value;
					setUpdateValue( skills, (int)val.Id );
					setUpdateValue( skills+1, (short)val.CurrentVal(this) );
					setUpdateValue( skills+1, (short)val.Cap( this ) );
					setUpdateValue( skills+2, (int)0 );
					skills+=3;
				}
				Console.WriteLine("PrepareUpdateData 18");
				//		setUpdateValue( 728, 0 );
				
				setUpdateValue( (int)UpdateFields.PLAYER_CHARACTER_POINTS1, (int)Talent );
				if ( CumulativeAuraEffects[ EffectTypes.FindMineral ] != null && CumulativeAuraEffects[ EffectTypes.FindMineral ] is int )
					setUpdateValue( (int)UpdateFields.PLAYER_TRACK_RESOURCES, (int)CumulativeAuraEffects[ EffectTypes.FindMineral ] );
				
				setUpdateValue( (int)UpdateFields.PLAYER_BLOCK_PERCENTAGE, this.BaseBlockChance);
				setUpdateValue( (int)UpdateFields.PLAYER_DODGE_PERCENTAGE, this.BaseDodgeChance);
				setUpdateValue( (int)UpdateFields.PLAYER_PARRY_PERCENTAGE, this.BaseParryChance);
				setUpdateValue( (int)UpdateFields.PLAYER_CRIT_PERCENTAGE, this.BaseCritChance);
				Console.WriteLine("PrepareUpdateData 19");
				for (int i = 0 ; i < 32 ; i++)//	ZONE UPDATE
				{
					//zones[ i ] = 0xffffffff;
					setUpdateValue( ( (int)UpdateFields.PLAYER_EXPLORED_ZONES_1 + i ), zones[ i ] );
				}

				setUpdateValue( (int)UpdateFields.PLAYER_REST_STATE_EXPERIENCE, 1 );
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_COINAGE, copper );
				
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_POSSTAT0, StrBonusUpdate );
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_POSSTAT1, AgBonusUpdate );
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_POSSTAT2, StaminaBonusUpdate );
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_POSSTAT3, IqBonusUpdate );
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_POSSTAT4, SpiritBonusUpdate );
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_NEGSTAT0, StrMalusUpdate );
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_NEGSTAT1, AgMalusUpdate );
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_NEGSTAT2, StaminaMalusUpdate );
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_NEGSTAT3, IqMalusUpdate );
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_NEGSTAT4, SpiritMalusUpdate );
				
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE + 0, ArmorBonusUpdate );
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE + 1, ArmorBonusUpdate );
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE + 2, HolyResistanceBonusUpdate );
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE + 3, FireResistanceBonusUpdate );
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE + 4, NatureResistanceBonusUpdate );
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE + 5, FrostResistanceBonusUpdate );
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE + 6, ShadowResistanceBonusUpdate );
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE + 7, ArcaneResistanceBonusUpdate );

				
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE + 0, ArmorMalusUpdate );
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE + 1, ArmorMalusUpdate );
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE + 2, HolyResistanceMalusUpdate );
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE + 3, FireResistanceMalusUpdate );
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE + 4, NatureResistanceMalusUpdate );
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE + 5, FrostResistanceMalusUpdate );
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE + 6, ShadowResistanceMalusUpdate );
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE + 7, ArcaneResistanceMalusUpdate );
				Console.WriteLine("PrepareUpdateData 20");
				setUpdateValue( (int)UpdateFields.PLAYER_FIELD_MOD_DAMAGE_DONE_PCT, (float)1f );//this.MeleeDamageBonus + this.AllDamageDoneBonus + this.PhysicalDamageIncrease);
				//setUpdateValue( (int)UpdateFields.PLAYER_FIELD_MOD_DAMAGE_DONE_NEG, (float)0f );//this.MeleeDamageMalus + this.AllDamageDoneMalus);		
				//setUpdateValue( (int)UpdateFields.PLAYER_FIELD_MOD_DAMAGE_DONE_PCT,	(float)3f );
				setUpdateValue( (int)UpdateFields.PLAYER_AMMO_ID, ammoType );//(float)1 );//

				Console.WriteLine("PrepareUpdateData 21");
				FlushUpdateData( data, ref offset, 0x22 );
				Console.WriteLine("PrepareUpdateData 22");
			}
			else
			{
				Console.WriteLine("PrepareUpdateData 23");
				FlushUpdateData( data, ref offset, 0x22 );
			}
			/*			Console.WriteLine("A9");
						for(int i = start;i < offset;i++ )
							Console.Write( "{0} ", data[ i ].ToString( "X2" ) );
						Console.WriteLine("");*/
			/*
						offset = 0;
						Character.A9Reader( data, ref offset );
			
						HexViewer.View( data, 0, offset, false );*/
#if TESTCONSECUTIF
			activateorder = false;
#endif
			Console.WriteLine("PrepareUpdateData fin");
		}
		//public static Hashtable allzones = new Hashtable();
		public void ZoneUpdateRequested( int z )
		{
			int oldZoneId = ZoneId;
			ZoneId = World.mapZones.NearestZoneId( this );
			if ( ZoneId != oldZoneId )
				Player.RefreshMobileList( true );
			//SendMessage("Zone Update " + z.ToString() + " " + ZoneId.ToString() );
			if ( ZoneId == 0 )
				return;
			z =(int) World.zoneIds[ ZoneId ];
			int e = z % 32;
			int n = ( z / 32 );
			if ( n > 31 )
			{
				Console.WriteLine("Strange zone {0}", z );
				return;
			}
			if ( ( zones[ n ] & (uint)( 1 << e ) ) == 0 )
			{
				if ( ZoneId != (int)World.zones[ ZoneId ] ) 
				{
					int offset = 4;
					Converter.ToBytes( ZoneId, tempBuff, ref offset );
					Converter.ToBytes( 100, tempBuff, ref offset );
					Send( OpCodes.SMSG_EXPLORATION_EXPERIENCE, tempBuff, offset );
					EarnXP( 100 );
				}
				zones[ n ] |= (uint)( 1 << e );
				this.SendSmallUpdate( new int[] { (int)UpdateFields.PLAYER_EXPLORED_ZONES_1 + n }, new object[] { zones[ n ] } );
			}
		}

		#endregion

		#region Quest Engine (Delegates activate only "#IF VOLHV" )

		#region Internal ( RealXp, RemoveQuest, AddQuest, FindPlayerQuest ), checked: 24.09.05

		/// <summary>
		/// Recheck XP for level
		/// </summary>
		public int RealXp( int amount, int qlevel ) 
		{ 
			float ratio = 0f; 
			int lev1 = qlevel; 
			int lev2 = Level; 

			if ( lev1 < lev2 - 6 )			ratio = 0.05f; 
			else if ( lev1 == lev2 - 6 )	ratio = 0.1f; 
			else if ( lev1 == lev2 - 5 )	ratio = 0.25f; 
			else if ( lev1 == lev2 - 4 )	ratio = 0.3333f; 
			else if ( lev1 == lev2 - 3 )	ratio = 0.5f; 
			else if ( lev1 == lev2 - 2 )	ratio = 0.6666f; 
			else if ( lev1 == lev2 - 1 )	ratio = 0.75f;    
			else if ( lev1 == lev2 )		ratio = 1f;       
			else ratio = 1.1f; 
          
			return (int)( (float)amount * ratio ); 
		}

		/// <summary>
		/// Remove quest
		/// </summary>
		public void RemoveQuest( byte i ) 
		{ 
			int start = i * 3 + (int)UpdateFields.PLAYER_QUEST_LOG_1_1; 
			activeQuests[ i ] = null;          
			this.SendSmallUpdate( new int[]{ start, start + 1, start + 2 }, new object[] { 0, 0, 0 } ); 
		} 

		/// <summary>
		/// Internal Add Quest to ActiveQuest list
		/// </summary>
		public int AddQuest( ActiveQuest bq ) 
		{ 
			for(int t = 0; t<20; t++ ) 
			{
				if ( activeQuests[ t ] == null ) 
				{ 
					activeQuests[ t ] = bq; 
					return t; 
				} 
			}
			return -1; 
		}

		/// <summary>
		/// Get Active Quest by Id
		/// </summary>
		public ActiveQuest FindPlayerQuest( int id ) 
		{ 
			foreach( ActiveQuest aq in activeQuests ) 
			{ 
				if ( aq == null ) continue; 
				if ( aq.Id == id ) return aq; 
			} 
			return null; 
		}

		/// <summary>
		/// Get Active Quest by System.Type
		/// </summary>
		public ActiveQuest FindPlayerQuest( Type type ) 
		{ 
			foreach( ActiveQuest aq in activeQuests ) 
			{ 
				if ( aq == null ) continue; 
				if ( aq.QuestType == type ) return aq; 
			} 
			return null;
		}

		/// <summary>
		/// Get Active Quest by BaseQuest type
		/// </summary>
		public ActiveQuest FindPlayerQuest( BaseQuest bq ) 
		{ 
			foreach( ActiveQuest aq in activeQuests ) 
			{ 
				if ( aq == null ) continue; 
				if ( aq.Id == bq.Id ) return aq; 
			} 
			return null; 
		}

		#endregion

		#region Have Quest, checked: 04.10.05
		/// <summary>
		/// Check exist quest by System.Type type
		/// </summary>
		public bool HaveQuest( Type t ) 
		{ 
			BaseQuest bq = World.CreateQuestByType( t ); 
			return ( bq == null ) ? false : HaveQuest( bq ); 
		}

		/// <summary>
		/// Check exist quest by BaseQuest type
		/// </summary>
		public bool HaveQuest( BaseQuest bq ) 
		{ 
			return ( bq == null ) ? false : HaveQuest( bq.Id );
		}

		/// <summary>
		/// Check exist quest by id
		/// </summary>
		public bool HaveQuest( int id ) 
		{ 
			bool result = false;
			foreach( ActiveQuest aq in activeQuests )
			{
				if ( aq != null && aq.Id == id )
				{
					result = true;
					break;
				}
			}
			return result;
		}

		#endregion

		#region Gossip, last changed: 01.10.05 +

		#region Packet structure
		//381 - SMSG_GOSSIP_MESSAGE
		//	{
		//		uint64 npcGUID
		//		uint32 npcTextID
		//		uint32 numberOfMenuItems
		//		foreach (numberOfMenuItems)                                                     
		//		{
		//			uint32 menuID
		//			uint8 menuIconType
		//			uint8 onClickType
		//			string menuText
		//		}
		//		unint32 numberOfQuestMenuItems
		//		foreach (numberOfQuestMenuItems)
		//		{
		//			uint32 questMenuID (questID?)
		//			uint32 questMenuIconType
		//			uint32 unknown2 (it is converted to float32, maybe to match that weird float at SMSG_NPC_TEXT_UPDATE? i have no idea)
		//			string questMenuText
		//		}
		//	}
		//menuIconType:
		//	0x00: Gossip
		//	0x01: Vendor
		//	0x02: Taxi
		//	0x03: Trainer
		//	0x04: Healer
		//	0x05: Binder
		//	0x06: Banker
		//	0x07: Petition
		//	0x08: Tabard
		//	0x09: Battlemaster
		//	0x0A: Auctioneer
		//	0x0B: Gossip
		//	0x0C: Gossip
		//onClickType: (tested against 1 only)
		//	0x01: Shows an input dialog on click.
		#endregion

		#region Gossip variables
		private bool _gossipOpened = false;
		public bool GossipOpened 
		{ 
			get 
			{ 
				return _gossipOpened;
			} 
		}
		#endregion

		#region Old, changed: 01.10.05

		/// <summary>
		/// On Responce from client
		/// Gossip Select Option
		/// </summary>
		void GossipSelectOption( UInt64 guid, int num ) 
		{
			Mobile m = this.account.FindMobileByGuid( guid ); 
			( m as BaseCreature ).DialogCharacterSelection( this, ( m as BaseCreature ).npcMenuId, num ); 
		}

		/// <summary>
		/// Close GOSSIP Panel
		/// </summary>
		public void EndGossip() 
		{
			_gossipOpened = false;
			Send( OpCodes.SMSG_GOSSIP_COMPLETE, tempBuff, (int)4 );          
		}

		/// <summary>
		/// OLD Gossip
		/// +Addon: 01.10.05
		/// </summary>
		public void ResponseMessage( Mobile m, int id ) 
		{
			if ( _gossipOpened ) EndGossip();
			int offset = 4; 
			Converter.ToBytes( m.Guid, tempBuff, ref offset ); 
			Converter.ToBytes( id, tempBuff, ref offset ); 
			Converter.ToBytes( 0, tempBuff, ref offset ); 
			Converter.ToBytes( 0, tempBuff, ref offset ); 
			Send( OpCodes.SMSG_GOSSIP_MESSAGE, tempBuff, offset ); 
			( m as BaseCreature ).npcMenuId = id; 
		} 
		/// <summary>
		/// OLD Gossip
		/// +Addon: 01.10.05
		/// </summary>
		public void ResponseMessage( Mobile m, int id, NpcMenu menu ) 
		{ 
			if ( _gossipOpened ) EndGossip();
			int offset = 4; 
			Converter.ToBytes( m.Guid, tempBuff, ref offset ); 
			Converter.ToBytes( id, tempBuff, ref offset ); 
			Converter.ToBytes( menu.Menu.Count, tempBuff, ref offset ); 
			for(int t = 0;t < menu.Menu.Count;t++ ) 
			{ 
				Converter.ToBytes( t, tempBuff, ref offset ); 
				Converter.ToBytes( (short)menu.Icon[ t ], tempBuff, ref offset ); 
				Converter.ToBytes( menu.Menu[ t ], tempBuff, ref offset );       
				Converter.ToBytes( (byte)0, tempBuff, ref offset ); 
			} 
			Converter.ToBytes( 0, tempBuff, ref offset ); 
			Send( OpCodes.SMSG_GOSSIP_MESSAGE, tempBuff, offset ); 
			( m as BaseCreature ).npcMenuId = id; 
		}
		/// <summary>
		/// OLD Gossip
		/// +Addon: 01.10.05
		/// </summary>
		public void ResponseMessage( Mobile m, int id, int icon, string str ) 
		{
			if ( _gossipOpened ) EndGossip();
			( m as BaseCreature ).npcMenuId = id; 
			//65 01 00 00 00 00 00 00 
			//44 00 00 00 
			//0B 00 00 00 
			//00 00 00 00 
			//01 00 00 00 
			//41 75 63 74 69 6F 6E 20 48 6F 75 73 65 00 
			//01 00 00 00 
			//08 00 00 00 
			//54 68 65 20 62 61 6E 6B 73 00 
			//02 00 00 00 
			//02 00 00 00 
			//54 68 65 20 44 65 65 70 72 75 6E 20 54 72 61 6D 00 
			//03 00 00 00 
			//01 00 00 00 
			//54 68 65 20 69 6E 6E 73 00 04 00 00 00 03 00 00 00 47 72 79 70 68 6F 6E 20 6D 61 73 74 65 72 73 00 05 00 00 00 02 00 00 00 47 75 69 6C 64 20 6D 61 73 74 65 72 73 00 06 00 00 00 03 00 00 00 4D 61 69 6C 62 6F 78 65 73 00 07 00 00 00 02 00 00 00 54 68 65 20 73 74 61 62 6C 65 20 6D 61 73 74 65 72 73 00 08 00 00 00 02 00 00 00 57 65 61 70 6F 6E 73 20 54 72 61 69 6E 65 72 73 00 09 00 00 00 02 00 00 00 43 6C 61 73 73 20 74 72 61 69 6E 65 72 73 00 0A 00 00 00 02 00 00 00 50 72 6F 66 65 73 73 69 6F 6E 20 74 72 61 69 6E 65 72 73 00 00 00 00 00 

			int offset = 4; 
			Converter.ToBytes( m.Guid, tempBuff, ref offset ); 
			Converter.ToBytes( id, tempBuff, ref offset ); 
			Converter.ToBytes( 1, tempBuff, ref offset ); 
			Converter.ToBytes( 0, tempBuff, ref offset ); 
			Converter.ToBytes( (short)icon, tempBuff, ref offset ); 
			Converter.ToBytes( str, tempBuff, ref offset );       
			Converter.ToBytes( (byte)0, tempBuff, ref offset ); 
			Converter.ToBytes( 0, tempBuff, ref offset ); 
			Send( OpCodes.SMSG_GOSSIP_MESSAGE, tempBuff, offset ); 
		}

		/// <summary>
		/// OLD Gossip
		/// </summary>
		public void ResponseMessage( Mobile m, int id, string str ) 
		{ 
			ResponseMessage( m, id, 0, str ); 
		} 

		#endregion

		/// <summary>
		/// Gossip dialog
		/// New, support quests
		/// changed: 01.10.05
		/// </summary>
		public void SendGossip( Mobile from, int textId, GMenu gMenu, GQMenu gqMenu )
		{
			if ( _gossipOpened ) EndGossip();

			int offset = 4; 
			Converter.ToBytes( (ulong)from.Guid,			tempBuff, ref offset );	// npcGuId
			Converter.ToBytes( (uint)textId,				tempBuff, ref offset );	// TextId
			
			if ( gMenu != null && gMenu.Count > 0 )
			{
				Converter.ToBytes( (int)gMenu.Count,		tempBuff, ref offset );	// Amount of menu items
				GMenuItem[] items = gMenu.Items;
				for ( int i = 0; i< items.Length; i++ )
				{
					GMenuItem item = items[i];
					Converter.ToBytes( (uint)item.MenuId,	tempBuff, ref offset );	// Menu Id
					Converter.ToBytes( (byte)item.Icon,		tempBuff, ref offset );	// Icon Type
					Converter.ToBytes( (byte)item.InputBox,	tempBuff, ref offset );	// Box for input code
					Converter.ToBytes( (string)item.Text,	tempBuff, ref offset );	// Text for menu
					Converter.ToBytes( (byte)0,				tempBuff, ref offset );
				}
			}
			else Converter.ToBytes( (int)0,					tempBuff, ref offset );

			if ( gqMenu != null && gqMenu.Count > 0 ) // Responce OpCodes.CMSG_QUESTGIVER_QUERY_QUEST
			{
				Converter.ToBytes( (int)gqMenu.Count,		tempBuff, ref offset );	// Amount
				GQMenuItem[] items = gqMenu.Items;
				for ( int i = 0; i< items.Length; i++ )
				{
					GQMenuItem item = items[i];
					Converter.ToBytes( (uint)item.MenuId,	tempBuff, ref offset );	// Quest menu id / QuestId
					Converter.ToBytes( (uint)item.Icon,		tempBuff, ref offset );	// IconType
					Converter.ToBytes( (uint)0,				tempBuff, ref offset );	// padding (always 0)
					Converter.ToBytes( (string)item.Text,	tempBuff, ref offset );	// text for menu
					Converter.ToBytes( (byte)0,				tempBuff, ref offset );
				}
			}
			else Converter.ToBytes( (int)0,					tempBuff, ref offset );	// Amount
			Converter.ToBytes( (int)0,						tempBuff, ref offset );	// Unknown (0)
			
			Send( OpCodes.SMSG_GOSSIP_MESSAGE, tempBuff, offset );
			( from as BaseCreature ).npcMenuId = textId;
		}

		#endregion

		#region Quest Done, checked: 04.10.05
		
		/// <summary>
		/// Quest is Done ?
		/// </summary>
		public bool QuestDone( Type t ) 
		{ 
			BaseQuest bq = World.CreateQuestByType( t ); 
			return ( bq == null ) ? false : QuestDone( bq ); 
		}

		/// <summary>
		/// Quest is Done ?
		/// </summary>
		public bool QuestDone( BaseQuest bq ) 
		{          
			return !( questsDone[ bq.Id ] == null );
		}

		/// <summary>
		/// Quest is Done ?
		/// </summary>
		public bool QuestDone( int id ) 
		{          
			return !( questsDone[ id ] == null );
		}

		#endregion

		#region Quest Complete, changed: 01.10.05 +

		#region Packet structure
		//	SMSG_QUESTUPDATE_COMPLETE
		//	{
		//		uint32 questID
		//	}
		//Output: 'Objective Complete.'
		//	Also marks the quest at questlog with (Failed)
		//------------------------------------------------
		//SMSG_QUESTGIVER_QUEST_COMPLETE
		//	{
		//		uint32 questID
		//		uint32 unknown1
		//		uint32 xpReceived
		//		uint32 moneyReceived
		//		uint32 numberOfItemsReceived
		//		foreach (numberOfItemsReceived)
		//		{
		//			uint32 itemID
		//			uint32 unknown2
		//		}
		//	}
		#endregion

		/// <summary>
		/// onEndQuest
		/// changed: 03.10.05
		/// </summary>
		public void SetQuestDone( Type t ) 
		{ 
			if ( t == typeof( BaseQuest ) )
			{
				BaseQuest bq = World.CreateQuestByType( t );
				if ( bq != null ) SetQuestDone( bq );
			}
		}

		/// <summary>
		/// onEndQuest
		/// changed: 01.10.05
		/// </summary>
		public void SetQuestDone( BaseQuest bq ) 
		{
			SetQuestDone( bq, null );
		}

		/// <summary>
		/// onEndQuest
		/// changed: 02.10.05
		/// </summary>
		public void SetQuestDone( BaseQuest bq, Reward[] rewards ) 
		{ 
			int num = 0; 
			foreach( ActiveQuest aq in activeQuests ) 
			{ 
				if ( aq != null && bq.Id == aq.Id ) 
				{ 
					aq.Done = true; 
					if ( bq.Repeatable ) questsDone[ aq.Id ] = null;						// repeat quest support
					else  questsDone[ aq.Id ] = true;										// normal quest done

					QuestUpdateComplete( bq );
					//int offset = 4;
					//Converter.ToBytes( (int)aq.Id, tempBuff, ref offset ); 
					//Send( OpCodes.SMSG_QUESTUPDATE_COMPLETE, tempBuff, offset ); 
					// Output: 'Objective Complete.'
					// Also marks the quest at questlog with (Failed)

					int offset = 4; 
					Converter.ToBytes( (int)aq.Id,			tempBuff, ref offset );			// QuestId
					Converter.ToBytes( (int)0,				tempBuff, ref offset );			// Unknown
					Converter.ToBytes( (int)bq.RewardXp,	tempBuff, ref offset );			// xpReceived
					Converter.ToBytes( (int)bq.RewardGold,	tempBuff, ref offset );			// moneyReceived
					if ( rewards!= null )
					{
						Converter.ToBytes( (int)rewards.Length,	tempBuff, ref offset );		// count rewarded items
						for ( int i=0; i< rewards.Length; i++ )
						{
							Reward rew = rewards[i];
							Converter.ToBytes( (int)rew.Id,		tempBuff, ref offset );		// reward Id
							Converter.ToBytes( (int)rew.Amount,	tempBuff, ref offset );		// reward Amount
						}
					}
					else Converter.ToBytes( (int)0,			tempBuff, ref offset );
					
					Send( OpCodes.SMSG_QUESTGIVER_QUEST_COMPLETE, tempBuff, offset );    
					RemoveQuest( (byte)num );
					break;
				} 
				num++; 
			} 
		}

#if VOLHV
		public static debugEvent deQuestGiverCompleteQuest = null;
#endif
		/// <summary>
		/// on Compleate Quest
		/// </summary>
		public void QuestGiverCompleteQuest( UInt64 guid, int id ) 
		{
#if VOLHV
			if ( deQuestGiverCompleteQuest!=null )
				if( deQuestGiverCompleteQuest( this, guid, id ) ) return;
#endif
			Mobile from = account.FindMobileByGuid( guid ); 
			if ( from != null ) 
			{ 
				( from as BaseCreature ).OnChooseQuest( this, id ); 
			} 
		}
		
		/// <summary>
		/// Quest Completed ?
		/// </summary>
		public bool QuestCompleted( BaseQuest bq ) 
		{
			bool result = false;
			if ( bq != null )
				foreach( ActiveQuest aq in activeQuests ) 
				{
					if ( aq != null && bq.Id == aq.Id )
					{
						result = aq.Completed; 
						break;
					}
				}
			return result; 
		}

		/// <summary>
		/// Quest Completed ?
		/// </summary>
		public bool QuestCompleted( Type t ) 
		{
			if ( t == typeof( BaseQuest ) )
			{
				return QuestCompleted( World.CreateQuestByType( t ) );
			}
			return false;
		}

		#endregion

		#region Quest List, changed: 01.10.05 + 

		#region Packet structure
		//SMSG_QUESTGIVER_QUEST_LIST
		//	{
		//		uint64 npcGUID
		//		char[0x200] headerText
		//		uint32 delayToPlayTheEmote (milliseconds)
		//		uint32 emoteID (only what wad calls EMOTE_ONESHOT?)
		//		uint8 numberOfItems
		//		foreach (numberOfItems)
		//		{
		//			uint32 questID?
		//			uint32 questStatus
		//			uint32 unknown1
		//			char[0x40] text
		//	   }
		//	}
		//questStatus:
		//	0x00: Unknown: sets some boolean to true
		//	0x03: Current Quests
		//	0x04: Current Quests
		//	default: Avaliable Quests
		#endregion
		
		/// <summary>
		/// Quest List (not full), OLD
		/// </summary>
		public void QuestList( Mobile m, int id, NpcQuestMenu menu ) 
		{ 
			int offset = 4; 
			Converter.ToBytes( m.Guid, tempBuff, ref offset ); 
			Converter.ToBytes( menu.Title, tempBuff, ref offset ); 
			Converter.ToBytes( (byte)0, tempBuff, ref offset ); 
			Converter.ToBytes( 0, tempBuff, ref offset ); 
			Converter.ToBytes( 0, tempBuff, ref offset ); 

			Converter.ToBytes( (byte)menu.Menu.Count, tempBuff, ref offset ); 
			for(int t = 0;t < menu.Menu.Count;t++ ) 
			{ 
				Converter.ToBytes( ( menu.Quests[ t ] as BaseQuest ).Id, tempBuff, ref offset ); 
				Converter.ToBytes( 0, tempBuff, ref offset ); 
				Converter.ToBytes( 0, tempBuff, ref offset ); 
				Converter.ToBytes( ( menu.Menu[ t ] as string ), tempBuff, ref offset );       
				Converter.ToBytes( (byte)0, tempBuff, ref offset );             
			} 
			Send( OpCodes.SMSG_QUESTGIVER_QUEST_LIST, tempBuff, offset ); 
			//      ( m as BaseCreature ).npcMenuId = id; 
		} 

		/// <summary>
		/// Quest List
		/// changed: 04.10.05
		/// </summary>
		public void QuestList( Mobile from, string text, qEmote e, BaseQuest[] quests )
		{
			int offset = 4;
			Converter.ToBytes( (ulong)from.Guid,		tempBuff, ref offset );			// npcGuId
			Converter.ToBytes( (string)text,			tempBuff, ref offset );			// HeaderText
			Converter.ToBytes( (byte)0,					tempBuff, ref offset );
			Converter.ToBytes( (int)e.Delay,			tempBuff, ref offset );			// Delay To Play Emote (mili secs)
			Converter.ToBytes( (int)e.emote,			tempBuff, ref offset );			// Emote (Wad use EMOTE_ONESHOT_)
			Converter.ToBytes( (byte)quests.Length,		tempBuff, ref offset );			// Amount of quests only 15 allowed
			foreach ( BaseQuest bq in quests )
			{
				Converter.ToBytes( (int)bq.Id,			tempBuff, ref offset );			// QuestId
				
				int _qStatus = HaveQuest( bq ) ? 0x03 : 0x05;
				Converter.ToBytes( (int)_qStatus,		tempBuff, ref offset );			// QuestStatus, need test
				Converter.ToBytes( (int)0,				tempBuff, ref offset );			// Unknown
				Converter.ToBytes( (string)bq.Name,		tempBuff, ref offset );			// QuestName
				Converter.ToBytes( (byte)0,				tempBuff, ref offset );
			}
			Send( OpCodes.SMSG_QUESTGIVER_QUEST_LIST, tempBuff, offset );
		}

		#endregion

		#region on Quest Accept, checked:24.09.05 de
#if VOLHV
		public static debugEvent deAcceptQuest = null;
#endif
		/// <summary>
		/// on Accept quest
		/// </summary>
		public void AcceptQuest( UInt64 guid, int id ) 
		{
#if VOLHV
			if ( deAcceptQuest!=null )
				if( deAcceptQuest( this, guid, id ) ) return;
#endif
			Mobile m = this.account.FindMobileByGuid( guid ); 
			// Console.WriteLine("{0} accept quest from {1}, id = {2}", this.Name, m.Name, id ); 
			BaseQuest b = null; 
			ActiveQuest bq = new ActiveQuest( b = World.CreateQuestById( id ) ); 

			int pos = AddQuest( bq ); 
			if ( pos == -1 ) return; 
			
			int start = pos * 3 + (int)UpdateFields.PLAYER_QUEST_LOG_1_1; 
			this.SendSmallUpdate( new int[]{ start, start + 1, start + 2 }, new object[] { id, 0, 0 } ); 
			
			b.OnAcceptQuest( this );

			( m as BaseCreature ).OnAcceptQuest( this, id ); 
          
			if ( b.HaveDeliveryObj ) 
			{ 
				foreach( Item it in Items ) 
				{
					if ( it != null ) this.CheckDeliveries( it ); 
				}
			} 
		}

		#endregion

		#region Quest Status, checked: 24.09.05 de

#if VOLHV
		public static debugEvent deQuestStatus = null;
#endif
		/// <summary>
		/// Get Quest status
		/// </summary>
		public void QuestStatus( ulong guid ) 
		{
#if VOLHV
			if ( deQuestStatus!=null )
				if( deQuestStatus( this, guid ) ) return;
#endif
			int i = 4; 
			Converter.ToBytes( guid, tempBuff, ref i ); 
			Mobile mobile = account.FindMobileByGuid( guid );
			if ( mobile != null && mobile is BaseCreature ) 
			{
				BaseCreature bc = (BaseCreature)mobile; 
				DialogStatus dialogStatus = bc.OnDialogStatus( this ); 
				Converter.ToBytes( (int)dialogStatus, tempBuff, ref i ); 
			} 
			else Converter.ToBytes( (int)0, tempBuff, ref i ); //dialog not allowed
			Send( OpCodes.SMSG_QUESTGIVER_STATUS, tempBuff, i );
		} 

		#endregion

		#region Offer Reward, changed: 24.09.05 +

		#region Packet structure
		//SMSG_QUESTGIVER_OFFER_REWARD
		//	{
		//		uint64 npcGUID
		//		uint32 questID
		//		char[0x200] header
		//		char[0x800] description
		//		uint32 unknown1
		//		uint32 numberOfEmotes
		//		foreach (numberOfEmotes)
		//		{
		//			uint32 delayToPlayTheEmote
		//			uint32 emoteID
		//		}
		//		uint32 numberOfRewardChoices
		//		foreach (numberOfRewardChoices)
		//		{
		//			uint32 itemID
		//			uint32 quantity
		//			uint32 modelID
		//		}
		//		uint32 numberOfRewardItems
		//		foreach (numberOfRewardItems)
		//		{
		//			uint32 itemID
		//			uint32 quantity
		//			uint32 modelID
		//		}
		//		uint32 rewardGold
		//		uint32 unknown2
		//		uint32 rewardSpell
		//	}
		#endregion

		/// <summary>
		/// Offer Reward without Emotes, for old support
		/// </summary>
		public void OfferReward( Mobile m, int questId, string title, string text ) 
		{
			OfferReward( m, questId, title, text, null );
		}

		/// <summary>
		/// Full Offer Reward ( with emotes )
		/// </summary>
		public void OfferReward( Mobile m, int questId, string title, string text, qEmote[] emoteList ) 
		{
			BaseQuest bq = World.CreateQuestById( questId ); 

			int i = 4; 
			Converter.ToBytes( (ulong)m.Guid,			tempBuff, ref i);				// ( Guid of questOwner )
			Converter.ToBytes( (int)questId,			tempBuff, ref i);				// ( quest Id )
			Converter.ToBytes( (string)title,			tempBuff, ref i);				// ( Header )
			Converter.ToBytes( (byte)0,					tempBuff, ref i);
			Converter.ToBytes( (string)text,			tempBuff, ref i);				// ( Description )
			Converter.ToBytes( (byte)0,					tempBuff, ref i);
			Converter.ToBytes( (int)1,					tempBuff, ref i);				// Unknown
			//Emotes .. Ok
			if ( emoteList!=null )
			{
				Converter.ToBytes(  (int)emoteList.Length,	tempBuff, ref i);
				for ( int ind=0; ind<emoteList.Length; ind++ ) 
				{
					qEmote em = emoteList[ ind ];
					Converter.ToBytes(  (int)em.Delay,		tempBuff, ref i); 
					Converter.ToBytes(  (int)em.emote,		tempBuff, ref i); 
				}
			}
			else Converter.ToBytes(  (int)0,			tempBuff, ref i); 
			//Reward Choice .. Ok
			if ( bq.HasRewardChoice() ) 
			{ 
				Reward[] list = bq.RewardChoice.Items; 
				Converter.ToBytes( (int)list.Length,		tempBuff, ref i );		// count choice rewards
				for ( int ind=0; ind<list.Length; ind++ ) 
				{ 
					Reward rew = list[ind]; 
					Converter.ToBytes( (int)rew.Id,			tempBuff, ref i );		// id 
					Converter.ToBytes( (int)rew.Amount,		tempBuff, ref i );		// amount 
					Converter.ToBytes( (int)rew.Model,		tempBuff, ref i );		// model 
				} 
			} 
			else Converter.ToBytes( (int)0,				tempBuff, ref i );
			//Rewards .. Ok
			if ( bq.HasReward() )
			{ 
				Reward[] list = bq.Reward.Items; 
				Converter.ToBytes( (int)list.Length,			tempBuff, ref i );		// count rewards 
				for ( int ind=0; ind<list.Length; ind++ ) 
				{ 
					Reward rew = list[ind]; 
					Converter.ToBytes( (int)rew.Id,			tempBuff, ref i );		// id 
					Converter.ToBytes( (int)rew.Amount,		tempBuff, ref i );		// amount 
					Converter.ToBytes( (int)rew.Model,		tempBuff, ref i );		// model 
				} 
			} 
			else Converter.ToBytes( (int)0,				tempBuff, ref i );

			//Other Rewards .. Ok
			Converter.ToBytes( (int)bq.RewardGold,		tempBuff, ref i );		// reward gold 
			Converter.ToBytes( (int)0,					tempBuff, ref i );		// unknown
			Converter.ToBytes( (int)bq.RewardSpell,		tempBuff, ref i );		// reward spell 
			Send( OpCodes.SMSG_QUESTGIVER_OFFER_REWARD, tempBuff, i );

			#region Old
			/* 
			int offset = 4; 
			Converter.ToBytes( m.Guid, tempBuff, ref offset ); 
			Converter.ToBytes( id, tempBuff, ref offset ); 
			Converter.ToBytes( title, tempBuff, ref offset ); 
			Converter.ToBytes( (byte)0, tempBuff, ref offset ); 
			Converter.ToBytes( text, tempBuff, ref offset ); 
			Converter.ToBytes( (byte)0, tempBuff, ref offset ); 
			Converter.ToBytes( 1, tempBuff, ref offset ); 
			Converter.ToBytes( 0, tempBuff, ref offset ); 
			BaseQuest bq = World.CreateQuestById( id ); 
			if ( bq != null ) 
			{ 
				if ( bq.RewardChoice != null ) 
				{ 
					Converter.ToBytes( bq.RewardChoice.Length, tempBuff, ref offset ); 
					foreach( Reward r in bq.RewardChoice ) 
					{ 
						Converter.ToBytes( r.Id, tempBuff, ref offset ); 
						Converter.ToBytes( r.Amount, tempBuff, ref offset ); 
						Converter.ToBytes( r.Model, tempBuff, ref offset ); 
					} 
				} 
				else 
					Converter.ToBytes( 0, tempBuff, ref offset ); 
			} 
			else 
				Converter.ToBytes( 0, tempBuff, ref offset ); 
			Converter.ToBytes( 0, tempBuff, ref offset ); 
			Converter.ToBytes( 0, tempBuff, ref offset ); 
			Converter.ToBytes( 0, tempBuff, ref offset ); 
			Send( OpCodes.SMSG_QUESTGIVER_OFFER_REWARD, tempBuff, offset );
			*/
			#endregion
		}

		#endregion

		#region On Choice Reward, changed: 02.10.05 de

#if VOLHV
		public static debugEvent deChooseReward = null;
#endif
		/// <summary>
		/// onChooseReward
		/// also need add support for repeatable
		/// </summary>
		public void ChooseReward( UInt64 g, int id, int sel ) 
		{   
#if VOLHV
			if ( deChooseReward!=null )
				if( deChooseReward( this, g, id, sel ) ) return;
#endif
			BaseQuest bq = World.CreateQuestById( id ); 
			if ( bq != null ) 
			{ 
				// Xp earn .. Ok
				if ( bq.RewardXp > 0 ) this.EarnXP( RealXp( bq.RewardXp, bq.IdealLevel ) ); 
				// Gold earn .. Ok
				if ( bq.RewardGold > 0 ) this.Copper += (uint)bq.RewardGold; 
				// Spell earn .. Ok
				if ( bq.RewardSpell > 0 )
				{
					if ( !this.HaveSpell( bq.RewardSpell ) )
					{
						this.LearnSpell( bq.RewardSpell );
					}
				}
				ArrayList rews = new ArrayList();
				// Reward Items earn .. Ok
				if ( bq.HasReward() )
				{ 
					foreach ( Reward rew in bq.Reward.Items )
					{
						Item it = rew.CreateItem();
						if ( it!= null )
						{
							this.PutObjectInBackpack( it, rew.Amount, true ); 
							rews.Add( rew );
						}
					}
				}
				// Reward Choice Item earn .. Ok
				if ( bq.HasRewardChoice() )
				{ 
					int cnt = bq.ChoiceRewardAmount( sel );
					if ( cnt > 0 )
					{
						Item it = bq.ChoiceRewardCreate( sel );
						if ( it != null ) 
						{
							this.PutObjectInBackpack( it, cnt, true ); 
							rews.Add( new Reward( it.Id, cnt ) );
						}
					}
				}

				SetQuestDone( bq, (Reward[])rews.ToArray( typeof( Reward ) ) ); // repeatable support

				// Remove Delivery Obj .. Ok
				if ( bq.HaveDeliveryObj ) 
				{ 
					foreach( DeliveryObjective d in bq.DeliveryObjectives.Items ) 
					{ 
						this.ConsumeItemByIdUpTo( d.Id, d.Amount ); 
					}
				}

				if ( _gossipOpened ) EndGossip(); // correction for close gossip dialog
			} 
		}

		#endregion

		#region Quest Details, changed: 24.09.05 +

		#region Packet structure
		//SMSG_QUESTGIVER_QUEST_DETAILS
		//	{
		//		uint64 npcGUID
		//		uint32 questID
		//		char[0x200] header
		//		char[0x800] description
		//		char[0x800] details
		//		uint32 unknown1 //same variable of unknown1 at SMSG_QUESTGIVER_OFFER_REWARD
		//		uint32 numberOfRewardChoices
		//		foreach (numberOfRewardChoices)
		//		{
		//			uint32 itemID
		//			uint32 quantity
		//			uint32 modelID
		//		}
		//		uint32 numberOfRewardItems
		//		foreach (numberOfRewardItems)
		//		{
		//			uint32 itemID
		//			uint32 quantity
		//			uint32 modelID
		//		}
		//		uint32 rewardGold
		//		uint32 rewardSpell
		//		uint32 numberOfEmotes
		//		foreach (numberOfEmotes)
		//		{
		//			uint32 emoteID
		//			uint32 delayToPlayTheEmote
		//		}
		//	}
		#endregion

		/// <summary>
		/// Responce Quest Complete
		/// need changes?, old?, not changed
		/// </summary>
		public void ResponseQuestComplete( Mobile m, int id, string title, string text ) 
		{       
			int offset = 4; 
			Converter.ToBytes( (ulong)m.Guid,	tempBuff, ref offset ); 
			Converter.ToBytes( (string)text,	tempBuff, ref offset ); 
			Converter.ToBytes( (byte)0,			tempBuff, ref offset ); 
			Converter.ToBytes( (int)0,			tempBuff, ref offset ); 
			Converter.ToBytes( (int)0,			tempBuff, ref offset ); 
			Converter.ToBytes( (int)id,			tempBuff, ref offset ); 
			Converter.ToBytes( (int)0,			tempBuff, ref offset ); 
			Converter.ToBytes( (int)0,			tempBuff, ref offset ); 
			Converter.ToBytes( (byte)0,			tempBuff, ref offset ); 
			Converter.ToBytes( (string)title,	tempBuff, ref offset ); 
			Converter.ToBytes( (byte)0,			tempBuff, ref offset ); 
			Send( OpCodes.SMSG_QUESTGIVER_QUEST_DETAILS, tempBuff, offset ); 
          
		}

		/// <summary>
		/// Responce Quest Complete
		/// Old support (without emotes)
		/// </summary>
		public void ResponseQuestDetails( Mobile m, int questId, string title, string desc, string details ) 
		{       
			ResponseQuestDetails( m, questId, title, desc, details, null );
		}

		/// <summary>
		/// Responce Quest Details
		/// With emotes
		/// </summary>
		public void ResponseQuestDetails( Mobile m, int questId, string title, string desc, string details, qEmote[] emoteList  ) 
		{ 
			BaseQuest bq = World.CreateQuestById( questId );
			int i = 4; 
			Converter.ToBytes( (ulong)m.Guid,			tempBuff, ref i );			// ( Mobile.Guid )
			Converter.ToBytes( (int)questId,			tempBuff, ref i );			// ( Quest Id )
			Converter.ToBytes( (string)title,			tempBuff, ref i );			// ( Title )
			Converter.ToBytes( (byte)0,					tempBuff, ref i ); 
			Converter.ToBytes( (string)desc,			tempBuff, ref i );			// ( Description )
			Converter.ToBytes( (byte)0,					tempBuff, ref i ); 
			Converter.ToBytes( (string)details,			tempBuff, ref i );			// ( Details )
			Converter.ToBytes( (byte)0,					tempBuff, ref i ); 
			Converter.ToBytes( (int)1,					tempBuff, ref i );			// Unknown
			//Choice Rewards .. Ok
			if ( bq.HasRewardChoice() ) 
			{ 
				Reward[] list = bq.RewardChoice.Items; 
				Converter.ToBytes( (int)list.Length,		tempBuff, ref i );		// ( count Choice rewards )
				for ( int ind=0; ind<list.Length; ind++ ) 
				{ 
					Reward rew = list[ind]; 
					Converter.ToBytes( (int)rew.Id,			tempBuff, ref i );		// ( id )
					Converter.ToBytes( (int)rew.Amount,		tempBuff, ref i );		// ( amount )
					Converter.ToBytes( (int)rew.Model,		tempBuff, ref i );		// ( model )
				} 
			} 
			else Converter.ToBytes( (int)0,				tempBuff, ref i );
			//Rewards .. Ok
			if ( bq.HasReward() ) 
			{ 
				Reward[] list = bq.Reward.Items; 
				Converter.ToBytes( (int)list.Length,		tempBuff, ref i );		// ( count rewards )
				for ( int ind=0; ind<list.Length; ind++ ) 
				{ 
					Reward rew = list[ind]; 
					Converter.ToBytes( (int)rew.Id,			tempBuff, ref i );		// ( id )
					Converter.ToBytes( (int)rew.Amount,		tempBuff, ref i );		// ( amount )
					Converter.ToBytes( (int)rew.Model,		tempBuff, ref i );		// ( model )
				} 
			} 
			else Converter.ToBytes( (int)0,				tempBuff, ref i );
			//Other Rewards
			Converter.ToBytes( (int)bq.RewardGold,			tempBuff, ref i );		// ( reward gold )
			Converter.ToBytes( (int)bq.RewardSpell,			tempBuff, ref i );		// ( reward spell )
			//Emotes .. Ok
			if ( emoteList!=null )
			{
				Converter.ToBytes(  (int)emoteList.Length,	tempBuff, ref i);		// ( count emotes )
				for ( int ind=0; ind<emoteList.Length; ind++ ) 
				{
					qEmote em = emoteList[ ind ];
					Converter.ToBytes(  (int)em.Delay,		tempBuff, ref i);		// ( Delay Msecs )
					Converter.ToBytes(  (int)em.emote,		tempBuff, ref i);		// ( Emote )
				}
			}
			else Converter.ToBytes(  (int)0,			tempBuff, ref i); 

			Send( OpCodes.SMSG_QUESTGIVER_QUEST_DETAILS, tempBuff, i ); 

			#region Old code
			/* 
			int offset = 4; 
			Converter.ToBytes( m.Guid, tempBuff, ref offset ); 
			Converter.ToBytes( id, tempBuff, ref offset ); 

			Converter.ToBytes( title, tempBuff, ref offset ); 
			Converter.ToBytes( (byte)0, tempBuff, ref offset ); 
			Converter.ToBytes( desc, tempBuff, ref offset ); 
			Converter.ToBytes( (byte)0, tempBuff, ref offset ); 
			Converter.ToBytes( details, tempBuff, ref offset ); 
			Converter.ToBytes( (byte)0, tempBuff, ref offset ); 

			Converter.ToBytes( 1, tempBuff, ref offset ); 
			Converter.ToBytes( 0, tempBuff, ref offset ); 
			Converter.ToBytes( 0, tempBuff, ref offset ); 
			Converter.ToBytes( 0, tempBuff, ref offset ); 
			Converter.ToBytes( 0, tempBuff, ref offset ); 
			Converter.ToBytes( 0, tempBuff, ref offset ); 
			Send( OpCodes.SMSG_QUESTGIVER_QUEST_DETAILS, tempBuff, offset );*/ 
			#endregion
		} 

		#endregion

		#region Npc Text Querry, need changes, checked:24.09.05 +, de, need expand

		#region Packet structure
		//	384 - SMSG_NPC_TEXT_UPDATE
		//	{
		//		uint32 npcTextID
		//		8x
		//		{
		//			float probability?
		//			string text1
		//			string text2
		//			uint32 languageID
		//			3x
		//			{
		//				uint32 Delay
		//				uint32 emoteID
		//			}
		//		}
		//	}
		#endregion

#if VOLHV
		public static debugEvent deNpcTextQuery = null;
#endif
		/// <summary>
		/// NPC Text Querry (not for quest Engine)
		/// need changes, not changed
		/// </summary>
		public void NpcTextQuery( int id, UInt64 guid ) 
		{ 
#if VOLHV
			if ( deNpcTextQuery!=null )
				if( deNpcTextQuery( this, id, guid ) ) return;
#endif			
			//01 23 80 01 
			//50 24 00 00 
			//00 00 00 00 
			//47 72 65 65 74 69 6E 67 73 20 24 4E 2E 00 
			Mobile m = this.account.FindMobileByGuid( guid ); 
			string resp = ""; 
			if ( ( m.NpcFlags & (int)NpcActions.SpiritHealer ) != 0 ) 
				resp = "Return me to life"; 
			else 
				resp = ( m as BaseCreature ).QueryNpcText( id ); 
			int offset = 4; 
			//   byte []buff = { 0x01, 0x23, 0x80, 0x01, 0x50, 0x24, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x47, 0x72, 0x65, 0x65, 0x74, 0x69, 0x6E, 0x67, 0x73, 0x20, 0x24, 0x4E, 0x2E, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }; 
			Converter.ToBytes( id, tempBuff, ref offset ); 
			Converter.ToBytes( 0, tempBuff, ref offset ); 
			Converter.ToBytes( resp, tempBuff, ref offset ); 
			Converter.ToBytes( (byte)0, tempBuff, ref offset ); 
			Send( OpCodes.SMSG_NPC_TEXT_UPDATE, tempBuff, offset ); 
		}

		#endregion

		#region Quest Giver onHello, checked: 24.09.05 de

#if VOLHV
		public static debugEvent deQuestGiverHello = null;
#endif
		/// <summary>
		/// on Quest Giver Hello
		/// checked
		/// </summary>
		public void QuestGiverHello( UInt64 guid ) 
		{
#if VOLHV
			if ( deQuestGiverHello!=null )
				if( deQuestGiverHello( this, guid ) ) return;
#endif
			Mobile m = this.account.FindMobileByGuid( guid ); 
			if ( m == null ) 
			{ 
				SendMessage( "Missing quest giver hello command !!!" ); 
				return; 
			} 
			( m as BaseCreature ).OnHello( this );
			/*
			//   int id = 0; 
			string message = ""; 
			if ( message != "" ) 
			{ 
				// SMSG_QUESTGIVER_QUEST_LIST 
				//FA 1C 15 00 00 00 00 00 
				//52 65 61 64 79 20 66 6F 72 20 71 75 65 73 74 73 3F 00 
				//00 00 00 00 00 00 00 00 
				//02 40 0F 00 
				//00 00 00 00 00 00 00 00 00 
				//   Mill 
				//4D 69 6C 6C 79 27 73 20 48 61 72 76 65 73 74 00 
				//41 0F 00 00 00 00 00 00 00 00 00 00 
				//   Grape Manifest 
				//47 72 61 70 65 20 4D 61 6E 69 66 65 73 74 00 
			} //*/
		}

		#endregion

		#region Quest Querry, changed: 01.10.05 +, de
		
		#region Packet structure
		//SMSG_QUEST_QUERY_RESPONSE - 93
		//	{
		//		uint32 questID
		//		uint32 levelMin
		//		uint32 levelMax
		//		uint32 category (zone)
		//		uint32 type
		//		uint32 faction1
		//		uint32 reputationRequired1
		//		uint32 faction2?
		//		uint32 reputationRequired2?
		//		uint32 nextQuest
		//		uint32 rewardGold
		//		uint32 rewardSpell
		//		uint32 sourceItem
		//		uint32 questFlags
		//		4x
		//		{
		//			uint32 rewardItemX
		//			uint32 rewardItemAmountX
		//		}
		//		6x
		//		{
		//			uint32 rewardChoiceX
		//			uint32 rewardChoiceAmountX
		//		}
		//		uint32 mapID
		//		float X
		//		float Y
		//		uint32 unknown1
		//		char[0x200] questName
		//		char[0x800] questDescription
		//		char[0x800] questDetails
		//		char[0x200] questSecondDescription
		//		4x
		//		{
		//			uint32 objectiveNpcIDX
		//			uint32 ObjectiveNpcAmountX
		//			uint32 objectiveItemDeliverIDX
		//			uint32 objectiveItemDeliverAmountX
		//		}
		//		char[0x100] npcObjectiveCustomDescription1
		//		char[0x100] npcObjectiveCustomDescription2
		//		char[0x100] npcObjectiveCustomDescription3
		//		char[0x100] npcObjectiveCustomDescription4
		//	}
		#endregion

#if VOLHV
		public static debugEvent deQuestQuery = null;
#endif
		/// <summary>
		/// Quest Querry 
		/// </summary>
		public void QuestQuery( int id ) 
		{ 
#if VOLHV
			if ( deQuestQuery!=null )
				if( deQuestQuery( this, id ) ) return;
#endif
			int offset = 4; 
			BaseQuest bq = World.CreateQuestById( id );
			if ( bq != null ) 
			{ 
				Converter.ToBytes( (int)bq.Id,				tempBuff, ref offset );			// Id quest			//Ok
				Converter.ToBytes( (int)bq.MinLevel,		tempBuff, ref offset );			// Min level		//Ok
				Converter.ToBytes( (int)bq.IdealLevel,		tempBuff, ref offset );			// Ave Level		//Ok
				Converter.ToBytes( (int)bq.Zone,			tempBuff, ref offset );			// Zone Id			//Ok
				Converter.ToBytes( (int)bq.QuestType,		tempBuff, ref offset );			// QuestType		//Ok

				#region Faction1
				if ( bq.Faction1!=null )
				{
					FactionLimit fl = bq.Faction1;
					Converter.ToBytes( (int)fl.Faction,		tempBuff, ref offset );			// Faction1			//Ok, need test
					Converter.ToBytes( (int)fl.Reputation,	tempBuff, ref offset );			// Reputation		//Ok, need test
				}
				else
				{
					Converter.ToBytes( (uint)0,				tempBuff, ref offset );
					Converter.ToBytes( (uint)0,				tempBuff, ref offset );
				}
				#endregion
				
				#region Faction2
				if ( bq.Faction2!=null )
				{
					FactionLimit fl = bq.Faction2;
					Converter.ToBytes( (int)fl.Faction,		tempBuff, ref offset );			// Faction2			//Ok, need test
					Converter.ToBytes( (int)fl.Reputation,	tempBuff, ref offset );			// Reputation		//Ok, need test
				}
				else
				{
					Converter.ToBytes( (uint)0,				tempBuff, ref offset );
					Converter.ToBytes( (uint)0,				tempBuff, ref offset );
				}
				#endregion
				
				Converter.ToBytes( (int)bq.NextQuest,		tempBuff, ref offset );			// Next QuestId		//Ok
				Converter.ToBytes( (int)bq.RewardGold,		tempBuff, ref offset );			// Reward Gold		//Ok
				Converter.ToBytes( (int)bq.RewardSpell,		tempBuff, ref offset );			// Reward Spell		//Ok
				Converter.ToBytes( (int)bq.SourceItemId,	tempBuff, ref offset );			// Source Item Id	//Ok, need test
				Converter.ToBytes( (int)bq.QuestFlags,		tempBuff, ref offset ); 
				
				#region Rewards
				Reward[] rews = bq.Reward.Items;
				for ( int i=0; i < 4; i++ ) // 4x2x(int) Reward Items
				{
					if ( bq.HasReward() && rews.Length > i )
					{
						Reward rew = rews[i];
						Converter.ToBytes( (int)rew.Id,		tempBuff, ref offset );			// Item Id			//Ok
						Converter.ToBytes( (int)rew.Amount,	tempBuff, ref offset );			// Item Amount		//Ok
					}
					else
					{
						Converter.ToBytes( (int)0,			tempBuff, ref offset );
						Converter.ToBytes( (int)0,			tempBuff, ref offset );
					}

				}
				#endregion
				
				#region Choice Rewards
				Reward[] crews = bq.RewardChoice.Items;
				for ( int i=0; i < 6; i++ ) // 6x2x(int) Reward Choice Items
				{
					if ( bq.HasRewardChoice() && crews.Length > i )
					{
						Reward rew = crews[i];
						Converter.ToBytes( (int)rew.Id,		tempBuff, ref offset );			// Item Id			//Ok
						Converter.ToBytes( (int)rew.Amount,	tempBuff, ref offset );			// Item Amount		//Ok
					}
					else
					{
						Converter.ToBytes( (int)0,			tempBuff, ref offset );
						Converter.ToBytes( (int)0,			tempBuff, ref offset );
					}

				}
				#endregion
				
				#region Minimap positions
				if ( bq.MiniMapPos!=null )
				{
					Position pos = bq.MiniMapPos;
					Converter.ToBytes( (int)pos.MapId,		tempBuff, ref offset );			//MapId				//Ok
					Converter.ToBytes( (float)pos.X,		tempBuff, ref offset );			// X				//Ok
					Converter.ToBytes( (float)pos.Y,		tempBuff, ref offset );			// Y				//Ok
				}
				else
				{
					Converter.ToBytes( (int)0,				tempBuff, ref offset );
					Converter.ToBytes( (float)0,			tempBuff, ref offset );
					Converter.ToBytes( (float)0,			tempBuff, ref offset );
				}
				#endregion
				
				Converter.ToBytes( (int)0,					tempBuff, ref offset );			// Unknown			//?, need test
				Converter.ToBytes( (string)bq.Name,			tempBuff, ref offset );			// Title			//Ok
				Converter.ToBytes( (byte)0,					tempBuff, ref offset );
				Converter.ToBytes( (string)bq.Desc,			tempBuff, ref offset );			// Description		//Ok
				Converter.ToBytes( (byte)0,					tempBuff, ref offset );
				Converter.ToBytes( (string)bq.Details,		tempBuff, ref offset );			// First Details	//Ok
				Converter.ToBytes( (byte)0,					tempBuff, ref offset );
				Converter.ToBytes( (string)bq.Details2,		tempBuff, ref offset );			// Second Details2	//Ok, need test
				Converter.ToBytes( (byte)0,					tempBuff, ref offset );
				
				string[] obj_descr = new string[4] { "", "", "", "" };						// names for NPCObjectives	//Ok

				#region Npc Objectives + Delivery Objectives
				NPCObjective[] nobj = bq.NPCObjectives.Items;
				DeliveryObjective[] dobj = bq.DeliveryObjectives.Items;
				
				for ( int i=0; i < 4; i++ ) // 4x( 2x(int) ObjectiveNPC + 2x(int) ObjectiveDelivery )
				{
					if ( bq.HaveNPCObj && nobj.Length > i )
					{
						NPCObjective obj_ = nobj[i];
						obj_descr[i] = obj_.Descr;
						Converter.ToBytes( (int)obj_.Id, tempBuff, ref offset );			// ObjectiveNPC_Id			//Ok
						Converter.ToBytes( (int)obj_.Amount, tempBuff, ref offset );		// ObjectiveNPC_Amount		//Ok
					}
					else
					{
						Converter.ToBytes( (int)0, tempBuff, ref offset );
						Converter.ToBytes( (int)0, tempBuff, ref offset );
					}
					if ( bq.HaveDeliveryObj && dobj.Length > i )
					{
						DeliveryObjective obj_ = dobj[i];
						Converter.ToBytes( (int)obj_.Id, tempBuff, ref offset );			// ObjectiveDelivery_Id		//Ok
						Converter.ToBytes( (int)obj_.Amount, tempBuff, ref offset );		// ObjectiveDelivery_Amount	//Ok
					}
					else
					{
						Converter.ToBytes( (int)0, tempBuff, ref offset );
						Converter.ToBytes( (int)0, tempBuff, ref offset );
					}
				}
				#endregion
				
				#region Custom Npc descriptions
				if( obj_descr[0].Length > 0 ) Converter.ToBytes( (string)obj_descr[0],	tempBuff, ref offset );			// Objective custom description 1	//Ok
				Converter.ToBytes( (byte)0,					tempBuff, ref offset );
				if( obj_descr[1].Length > 0 ) Converter.ToBytes( (string)obj_descr[1],	tempBuff, ref offset );			// Objective custom description 2	//Ok
				Converter.ToBytes( (byte)0,					tempBuff, ref offset );
				if( obj_descr[2].Length > 0 ) Converter.ToBytes( (string)obj_descr[2],	tempBuff, ref offset );			// Objective custom description 3	//Ok
				Converter.ToBytes( (byte)0,					tempBuff, ref offset );
				if( obj_descr[3].Length > 0 ) Converter.ToBytes( (string)obj_descr[3],	tempBuff, ref offset );			// Objective custom description 4	//Ok
				Converter.ToBytes( (byte)0,					tempBuff, ref offset );
				#endregion

				Send( OpCodes.SMSG_QUEST_QUERY_RESPONSE, tempBuff, offset ); 
			}

			#region Old
			/*
			int offset = 4; 
			BaseQuest bq = World.CreateQuestById( id ); 
			if ( bq != null ) 
			{ 
				Converter.ToBytes( bq.Id, tempBuff, ref offset ); 
				Converter.ToBytes( bq.MinLevel, tempBuff, ref offset ); 
				Converter.ToBytes( bq.IdealLevel, tempBuff, ref offset ); 
				Converter.ToBytes( bq.Zone, tempBuff, ref offset ); 
				Converter.ToBytes( 0, tempBuff, ref offset ); 
				Converter.ToBytes( 0, tempBuff, ref offset ); 
				Converter.ToBytes( 0, tempBuff, ref offset ); 
				Converter.ToBytes( 0, tempBuff, ref offset ); 
				Converter.ToBytes( 0, tempBuff, ref offset ); 
				if ( bq.NextQuest != 0 ) 
				{ 
					//BaseQuest bq2 = World.CreateQuestByType( bq.NextQuest ); 
					//if ( bq2 != null ) 
					Converter.ToBytes( bq.NextQuest, tempBuff, ref offset ); 
				} 
				else 
					Converter.ToBytes( 0, tempBuff, ref offset ); 
				Converter.ToBytes( 0, tempBuff, ref offset ); 
				Converter.ToBytes( 0, tempBuff, ref offset ); 
				Converter.ToBytes( 0, tempBuff, ref offset ); 
				Converter.ToBytes( bq.QuestFlags, tempBuff, ref offset ); 
				int nr = 16; 
				if ( bq.RewardChoice != null && bq.RewardChoice.Length > 0 ) 
				{ 
					foreach( Reward rew in bq.RewardChoice ) 
					{ 
						nr-=2; 
						Converter.ToBytes( rew.Id, tempBuff, ref offset ); 
						Converter.ToBytes( rew.Amount, tempBuff, ref offset ); 
					} 
				} 
				for(int t = 0;t < 8;t++ ) 
					Converter.ToBytes( 0, tempBuff, ref offset ); 

				for(int t = 0;t < nr;t++ ) 
					Converter.ToBytes( 0, tempBuff, ref offset ); 
				if ( bq.Name != null ) 
				{ 
					Converter.ToBytes( bq.Name, tempBuff, ref offset ); 
					Converter.ToBytes( (byte)0, tempBuff, ref offset ); 
				} 
				if ( bq.Desc != null ) 
				{ 
					Converter.ToBytes( bq.getDesc( this ), tempBuff, ref offset ); 
					Converter.ToBytes( (byte)0, tempBuff, ref offset ); 
				} 
				if ( bq.Details != null ) 
				{ 
					Converter.ToBytes( bq.Details, tempBuff, ref offset ); 
					Converter.ToBytes( (byte)0, tempBuff, ref offset ); 
				} 
				Converter.ToBytes( (byte)0, tempBuff, ref offset ); 
				int nh = 15; 
				if ( bq.KillObjectives != null ) 
				{ 
					foreach( KillObjective ko in bq.KillObjectives ) 
					{ 
						Converter.ToBytes( ko.Id, tempBuff, ref offset ); 
						Converter.ToBytes( ko.Amount, tempBuff, ref offset ); 
						nh-=2; 
					} 
				} 
				Converter.ToBytes( 0, tempBuff, ref offset ); 
				Converter.ToBytes( 0, tempBuff, ref offset ); 
             
             
				if ( bq.DeliveryObjectives != null ) 
				{ 
					foreach( DeliveryObjective dob in bq.DeliveryObjectives ) 
					{ 
						Converter.ToBytes( dob.Id, tempBuff, ref offset ); 
						Converter.ToBytes( dob.Amount, tempBuff, ref offset ); 
						nh-=2; 
					} 
				} 

				for(int t = 0;t < nh;t++ ) 
					Converter.ToBytes( 0, tempBuff, ref offset ); 
				//for(int t = 0;t < offset;t++ )  Console.Write("{0} ", tempBuff[ t ].ToString( "X2" ) ); 
				Send( OpCodes.SMSG_QUEST_QUERY_RESPONSE, tempBuff, offset );
			}//*/
			#endregion
		}

		#endregion

		#region Check Deliveries, checked: 24.09.05 +, de
	
		#region Packet structure
		//SMSG_QUESTUPDATE_ADD_ITEM
		//	{
		//		uint32 itemID
		//		uint32 currentCount
		//	}
		//Output: '%s: %d/%d'
		#endregion

#if VOLHV
		public static debugEvent deCheckDeliveries = null;
#endif
		/// <summary>
		/// Check Deliveries for quests
		/// </summary>
		public void CheckDeliveries( Item it ) 
		{
#if VOLHV
			if ( deCheckDeliveries!=null )
				if( deCheckDeliveries( this, it ) ) return;
#endif
			for ( int t=0; t<20; t++ ) 
			{
				if ( activeQuests[ t ] != null && activeQuests[ t ].HaveDeliveryObj ) 
				{
					int n = activeQuests[ t ].IncreaseDelivery( it ); 
					if ( n > 0 ) 
					{ 
						int start = t * 3 + (int)UpdateFields.PLAYER_QUEST_LOG_1_1; 
						this.SendSmallUpdate( new int[]{ start + 1 }, new object[] { n } ); 

						int offset = 4; 
						Converter.ToBytes( (int)it.Id,			tempBuff, ref offset ); 
						Converter.ToBytes( (int)it.MaxCount,	tempBuff, ref offset ); 

						Send( OpCodes.SMSG_QUESTUPDATE_ADD_ITEM, tempBuff, offset ); 
						break; 
					}                   
				} 
			}
		}
		
		#endregion

		#region Check Kills, checked: 24.09.05 +, de

		#region Packet structure
		//SMSG_QUESTUPDATE_ADD_KILL
		//	{
		//		uint32 questID
		//		uint32 npcID
		//		uint32 currentKills
		//		uint32 totalKills
		//		uint64 killerGUID?
		//	}
		//Output: '%s slain: %d/%d'
		#endregion

#if VOLHV
		public static debugEvent deCheckKills = null;
#endif
		/// <summary>
		/// Check Kill count for mob killing
		/// </summary>
		public void CheckKills( Mobile mob ) 
		{ 
#if VOLHV
			if ( deCheckKills!=null )
				if( deCheckKills( this, mob ) ) return;
#endif
			for(int t = 0;t < 20;t++ ) 
			{
				if ( activeQuests[ t ] != null && activeQuests[ t ].HaveNPCObj ) 
				{ 
					int n = activeQuests[ t ].IncreaseNpcObj( mob ); 
					if ( n > 0 ) 
					{ 
						//  CB 00 00 00 A9 03 00 00 0F 00 00 00 0F 00 00 00 B2 01 00 00 00 00 00 00 
						int start = t * 3 + (int)UpdateFields.PLAYER_QUEST_LOG_1_1; 
						this.SendSmallUpdate( new int[]{ start + 1 }, new object[] { n } ); 
							
						int offset = 4; 
						Converter.ToBytes( (int)activeQuests[ t ].Id,								tempBuff, ref offset ); 
						Converter.ToBytes( (int)mob.Id,												tempBuff, ref offset ); 
						Converter.ToBytes( (int)activeQuests[ t ].NpcObjCurrentAmount( mob ),		tempBuff, ref offset ); 
						Converter.ToBytes( (int)activeQuests[ t ].NpcObjAmount( mob ),				tempBuff, ref offset ); 
						Converter.ToBytes( (ulong)mob.Guid,											tempBuff, ref offset ); 
						
						Send( OpCodes.SMSG_QUESTUPDATE_ADD_KILL, tempBuff, offset ); 
						break; 
					}                
				} 
			} 
		}

		#endregion

		#region Unused Packets: 24.09.05
		//
		//SMSG_QUESTGIVER_REQUEST_ITEMS
		//	{
		//		uint64 npcGUID
		//		uint32 questID
		//		char[0x200] header
		//		char[0x800] description
		//		uint32 delayToPlayTheEmote
		//		uint32 emoteID
		//		uint32 unknown1 //same variable of unknown1 at SMSG_QUESTGIVER_OFFER_REWARD
		//		uint32 requiredGold
		//		uint32 numberOfRequiredItems
		//		foreach (numberOfRequiredItems)
		//		{
		//			uint32 itemID
		//			uint32 quantity
		//			uint32 modelID
		//		}
		//		uint32 unknown2
		//		uint32 unknown3
		//		uint32 unknown4
		//		uint32 unknown5
		//	}
		//Notes:
		//if ((unknown2 != 0) && (unknown3 != 0) && (unknown4 != 0) && (unknown5 != 0))
		//	{
		//		enable the "Continue" button
		//	}
		//
		//--------------------------------------------------------------------------------
		//
		//SMSG_QUESTGIVER_QUEST_INVALID
		//	{
		//		uint32 invalidReason
		//	}
		//invalidReason:
		//	0x01: 'You are not high enough level for that quest.'
		//	0x06: 'That quest is not available to your race'
		//	0x0C: 'You can only be on one timed quest at a time'
		//	0x0D: 'You are already on that quest'
		//	0x13: 'You don',27h,'t have the required items with you.  Check storage.'
		//	0x15: 'You don',27h,'t have enough money for that quest'
		//	default: 'You don',27h,'t meet the requirements for that quest'
		//
		//--------------------------------------------------------------------------------
		//
		//SMSG_QUEST_CONFIRM_ACCEPT
		//	{
		//		uint32 questID?
		//		char[0x400] questName
		//		uint64 playerGUID
		//	}
		//Output: [Confirm Dialog] playerName + 'is starting' + questName + 'Would you like to as well?'
		//

		#endregion

		#region Error Results ( public ) changed: 02.10.05
		//SMSG_QUESTUPDATE_FAILEDTIMER
		//	{
		//		uint32 questID
		//	}
		//Output: '%s failed.'
		/// <summary>
		/// Quest Update failed Timer
		/// created: 01.10.05
		/// </summary>
		public void QuestUpdateFailedTimer( BaseQuest bq )
		{
			int offset = 4;
			Converter.ToBytes( (int)bq.Id, tempBuff, ref offset ); 
			Send( OpCodes.SMSG_QUESTUPDATE_FAILEDTIMER, tempBuff, offset ); 
		}
		//=====================================================================
		//SMSG_QUESTUPDATE_FAILED
		//	{
		//		uint32 questID
		//	}	
		//Output: '%s failed.'
		/// <summary>
		/// Quest Update failed
		/// created: 01.10.05
		/// </summary>
		public void QuestUpdateFailed( BaseQuest bq )
		{
			int offset = 4; 
			Converter.ToBytes( (int)bq.Id, tempBuff, ref offset ); 
			Send( OpCodes.SMSG_QUESTUPDATE_FAILED, tempBuff, offset ); 
		}
		//=====================================================================
		//SMSG_QUESTUPDATE_COMPLETE
		//	{
		//		uint32 questID
		//	}	
		//Output: 'Objective Complete.'
		//Also marks the quest at questlog with (Failed)
		/// <summary>
		/// Quest update compleate
		/// created: 04.10.05
		/// </summary>
		public void QuestUpdateComplete( BaseQuest bq )
		{
			int offset = 4;
			Converter.ToBytes( (int)bq.Id, tempBuff, ref offset ); 
			Send( OpCodes.SMSG_QUESTUPDATE_COMPLETE, tempBuff, offset ); 
		}
		//=====================================================================
		//SMSG_QUESTLOG_FULL
		//	{
		//	}
		//Output: 'Your quest log is full.'
		/// <summary>
		/// Quest Log is full
		/// created: 01.10.05
		/// </summary>
		public void QuestLogIsFull()
		{
			Send( OpCodes.SMSG_QUESTLOG_FULL, tempBuff, (int)4 ); 
		}
		//=====================================================================
		//SMSG_QUESTGIVER_QUEST_FAILED
		//	{
		//		uint32 questID
		//		uint32 failedReason
		//	}
		//failedReason:
		//	0x04: '%s failed: Inventory is full.'
		//	0x10: '%s failed: Duplicate item found.'
		//	0x31: '%s failed: Inventory is full.'
		//	default: '%s failed.'
		/// <summary>
		/// Failed result quest
		/// created: 01.10.05
		/// </summary>
		public void QuestFailed( qFailedReason reason )
		{
			int offset = 4; 
			Converter.ToBytes( (int)reason, tempBuff, ref offset ); 
			Send( OpCodes.SMSG_QUESTGIVER_QUEST_FAILED, tempBuff, offset ); 
		}
		//=====================================================================
		//SMSG_QUESTGIVER_QUEST_INVALID
		//	{
		//		uint32 invalidReason
		//	}
		//invalidReason:
		//	0x01: 'You are not high enough level for that quest.'
		//	0x06: 'That quest is not available to your race'
		//	0x0C: 'You can only be on one timed quest at a time'
		//	0x0D: 'You are already on that quest'
		//	0x13: 'You don',27h,'t have the required items with you.  Check storage.'
		//	0x15: 'You don',27h,'t have enough money for that quest'
		//	default: 'You don',27h,'t meet the requirements for that quest'

		/// <summary>
		/// Invalid result quest
		/// created: 01.10.05
		/// </summary>
		public void QuestInvalid( qInvalidReason reason )
		{
			int offset = 4; 
			Converter.ToBytes( (int)reason, tempBuff, ref offset ); 
			Send( OpCodes.SMSG_QUESTGIVER_QUEST_INVALID, tempBuff, offset ); 
		}
		#endregion

		#region Quest Querry Creature/GO/Item changed 04.10.05 de
#if VOLHV
		public static debugEvent deQuestQueryForCreature = null;
#endif
		/// <summary>
		/// Responce from client - request to do quest event
		/// </summary>
		public void QuestQueryForCreature( UInt64 guidFrom, int questId ) 
		{ 
#if VOLHV
			if ( deQuestQueryForCreature!=null )
				if( deQuestQueryForCreature( this, guidFrom, questId ) ) return;
#endif
			Mobile m = Player.FindMobileByGuid( guidFrom );
			if ( m != null && m is BaseCreature )
			{
				( m as BaseCreature ).OnChooseQuest( this, (int)questId );
				return;
			}
		}
		#endregion

		#endregion

		#region PETS
		void PetAction( ushort ability, byte b, UInt64 g )
		{
			if ( Summon == null )
				return;
			byte a;
			if ( b < 10 )
				a = (byte)ability;
			else
			{
				Mobile at = Summon.AttackTarget;
				if ( Summon.AttackTarget == null && Selection is Mobile )
					Summon.AttackTarget = Selection as Mobile;
				if ( Summon.AttackTarget == null )
					Summon.AttackTarget = Summon;
				Summon.AISpellAttack( ability );
				Summon.AttackTarget = at;
				return;
			}
			if ( b == 6 )
			{
				switch( a )
				{
					case 0:
						( Summon as BaseCreature ).AIStance = AIStances.Passive;
						break;
					case 1:
						( Summon as BaseCreature ).AIStance = AIStances.Defensive;
						break;
					case 2:
						( Summon as BaseCreature ).AIStance = AIStances.Agressive;
						break;
				}
			}
			else
				if ( b == 7 )
			{
				switch( a )
				{
					case 0:
						( Summon as BaseCreature ).AIState = AIStates.Pause1;
						break;
					case 1:
						( Summon as BaseCreature ).AIState = AIStates.Follow;
						break;
					case 2:
						( Summon as BaseCreature ).OnGetHit( this.Player.FindMobileByGuid( g ) );
						break;
					case 3:
						this.DismissPet( Summon.Guid );
						break;
				}
			}
		}
		void SetPetAction( UInt64 guid, uint a, uint b, uint c, uint d )
		{
			petActions[ a ] = (int)b;
			petActions[ c ] = (int)d;
		}
		void SetPetAction( UInt64 guid, int pos, uint id )
		{
			petActions[ pos ] = (int)id;
		}
		void DismissPet( UInt64 guid )
		{
			if ( Summon != null )
			{
				Summon.Delete();
				World.Remove( Summon, this );
				Summon = null;
				int offset = 4;
				Converter.ToBytes( 1, tempBuff, ref offset );
				Converter.ToBytes( (byte)0, tempBuff, ref offset );				
				PrepareUpdateData( tempBuff, ref offset , UpdateType.UpdateFull, false );
				Send( OpCodes.SMSG_UPDATE_OBJECT, tempBuff, offset );
				this.ItemsUpdate();
			}
		}

		public void SendPetActionBar()
		{
			if ( petActions == null )
			{
				petActions = new int[ 11 ];
				petActions[ 0 ] = 0x00000000;
				petActions[ 1 ] = 0x02000000;
				petActions[ 2 ] = 0x03000000;
				petActions[ 3 ] = 0x04000000;
				petActions[ 4 ] = 0x05000000;
				petActions[ 5 ] = 0x06000000;
				petActions[ 6 ] = 0x06000001;
				petActions[ 7 ] = 0x06000002;				
				petActions[ 8 ] = 0x07000000;
				petActions[ 9 ] = 0x07000001;
				petActions[ 10 ] = 0x07000002;
			}
			int offset = 4;
			Converter.ToBytes( Summon.Guid, tempBuff, ref offset );
			Converter.ToBytes( 0x257, tempBuff, ref offset );
			foreach( int pa in petActions )
				Converter.ToBytes( pa, tempBuff, ref offset );
			Converter.ToBytes( (byte)Summon.KnownAbilities.Count, tempBuff, ref offset );
			IDictionaryEnumerator Enumerator = Summon.KnownAbilities.GetEnumerator();
			while (Enumerator.MoveNext())
			{
				int spell = (int)Enumerator.Key;
				Converter.ToBytes( (ushort)spell, tempBuff, ref offset );
			}
			Send( OpCodes.SMSG_PET_SPELLS, tempBuff, offset );
		}
		#endregion

		#region PVP
		public UInt64 Duel = 0;
		public bool IsInDuel
		{
			get { if ( gu != null ) return true; return false; }
		}

		private class DuelTimer : WowTimer
		{
			Character from;
			Character vs;
			UInt64 flag;
			bool combatStarted = false;
			float x;
			float y;
			float z;
			
			public DuelTimer( Character c1, Character c2, UInt64 f ) : base( WowTimer.Priorities.Milisec100 , 3000, "DuelTimer" )
			{
				from = c1;
				vs = c2;
				flag = f;
				x = c1.X;
				y = c1.Y;
				z = c1.Z;
				Start();
			}
			public override void OnTick()
			{
				if ( !combatStarted )
				{
					from.SendSmallUpdate( new int []{ 176, 177, 186 }, new object[] { 0, 0, 1 } );
					from.SendSmallUpdateFor( vs.Guid, new int []{ 176, 177, 186 }, new object[] { 0, 0, 2 } );
					vs.SendSmallUpdate( new int []{ 176, 177, 186 }, new object[] { 0, 0, 2 } );
					vs.SendSmallUpdateFor( from.Guid, new int []{ 176, 177, 186 }, new object[] { 0, 0, 1 } );
					vs.Duel = flag;
					from.Duel = flag;
					combatStarted = true;
				}
				else
				{
					if ( from.gu == null || vs.gu == null )
					{
						base.Stop();
					}
					else
					{
						if ( from.Player == null || from.Distance( x, y, z ) > 60 * 60 )
						{
							from.OnDeath( vs );
							base.Stop();
							return;
						}
						if ( vs.Player == null || vs.Distance( x, y, z ) > 60 * 60 )
						{
							vs.OnDeath( from );
							base.Stop();
							return;
						}
					}
				}
				base.OnTick ();
			}
		}
		DuelTimer dt;
		void SendDuelArbitrer( UInt64 g )
		{
			int offset = 4;
			if ( guowner == this )
			{
				//	for the owner
				this.MakeThePacket( g, gu, guowner );
				
				Converter.ToBytes( g, tempBuff, ref offset );
				Send( OpCodes.SMSG_GAMEOBJECT_SPAWN_ANIM, tempBuff, offset );
				// for the target
				gu.MakeThePacket( g, guowner, gu );
				offset = 4;
				Converter.ToBytes( g, tempBuff, ref offset );
				gu.Send( OpCodes.SMSG_GAMEOBJECT_SPAWN_ANIM, tempBuff, offset );				
			}

			if ( guowner != this )
			{
				offset = 4;
				Converter.ToBytes( 0xbb8, tempBuff, ref offset );
				Send((OpCodes)695, tempBuff, offset );
				guowner.Send((OpCodes)695, tempBuff, offset );
				dt = new DuelTimer( guowner, this, g );
			}
		//	from.SendSmallUpdate( new int[] { 178, 179 }, new object[] { low, high } );

			/*byte []buf = new byte[] { 0, 0, 0, 0, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x57, 0x5C, 0x00, 0x00, 0x00, 0x10, 0x00, 0xF0, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0xEA, 0x00, 0x00, 0x00 };
			int offset = 10;
			Converter.ToBytes( g, buf, ref offset );
			Send( OpCodes.SMSG_UPDATE_OBJECT, buf, buf.Length );
			from.Send( OpCodes.SMSG_UPDATE_OBJECT, buf, buf.Length );*/
		}
		#endregion

		#region HANDLERS
	/*	public void Mana2Rage()
		{
			c.ManaType = 1;
			int[] numArray1 = new int[3] { 0x17 + c.ManaType, 0x1d + c.ManaType, 36 } ;
			object[] objArray1 = new object[3] { c.Rage, c.BaseRage,((int)c.Race)|((int)c.Classe << 8)|(((int)c.Gender) << 16)|(((int)c.ManaType) << 24)};
			c.SendSmallUpdateToPlayerNearMe( numArray1, objArray1 );
		}
		*/
		enum FriendResults
		{
			Friend_DB_ERROR                               = 0x00,
			Friend_LIST_FULL                              = 0x01,
			Friend_ONLINE                                 = 0x02,
			Friend_OFFLINE                                = 0x03,
			Friend_NOT_FOUND                              = 0x04,
			Friend_REMOVED                                = 0x05,
			Friend_ADDED_ONLINE                           = 0x06,
			Friend_ADDED_OFFLINE                          = 0x07,
			Friend_ALREADY                                = 0x08,
			Friend_SELF                                   = 0x09,
			Friend_ENEMY                                  = 0x0A,
			Friend_IGNORE_FULL                            = 0x0B,
			Friend_IGNORE_SELF                            = 0x0C,
			Friend_IGNORE_NOT_FOUND                       = 0x0D,
			Friend_IGNORE_ALREADY                         = 0x0E,
			Friend_IGNORE_ADDED                           = 0x0F,
			Friend_IGNORE_REMOVED                         = 0x10
		}
		public void AddFriend( string fname )
		{
			int offset = 4;
			
			Character c = null;
			FriendResults status = FriendResults.Friend_ADDED_ONLINE;
			if ( Name == fname )
			{
				Converter.ToBytes( (byte)FriendResults.Friend_SELF, tempBuff, ref offset );
				Converter.ToBytes( Guid, tempBuff, ref offset );
			}
			else
			{
				foreach( Character ch in World.allConnectedChars )
				{
					if ( ch.Name == fname )
					{
						c = ch;
						break;
					}
				}

				if ( c == null )
				{
					foreach( Account acc in World.allAccounts )
					{
						foreach( Character ch in acc.characteres )
						{
							if ( ch.Name == fname )
							{
								c = ch;
								status = FriendResults.Friend_ADDED_OFFLINE;
								break;
							}
						}
						if ( c != null )
							break;
					}
				}

				if ( c != null )
				{
					Converter.ToBytes( (byte)status, tempBuff, ref offset );
					Converter.ToBytes( c.Guid, tempBuff, ref offset );
					Converter.ToBytes( c.ZoneId, tempBuff, ref offset );
					Converter.ToBytes( c.Level, tempBuff, ref offset );
					Converter.ToBytes( (int)c.Classe, tempBuff, ref offset );
					friends.Add( c );
				}
				else
				{
					Converter.ToBytes( (byte)FriendResults.Friend_NOT_FOUND, tempBuff, ref offset );
					Converter.ToBytes( Guid, tempBuff, ref offset );
				}
			}
			Send( OpCodes.SMSG_FRIEND_STATUS, tempBuff, offset );
		}
		public void SendFriendList()
		{
			int offset = 4;
			Converter.ToBytes( friends.Count, tempBuff, ref offset );
			foreach( Character ch in friends )
			{
				Converter.ToBytes( ch.Guid, tempBuff, ref offset );
				if ( ch.Player != null && ch.Player.realylogged  )
				{
					Converter.ToBytes( (byte)FriendResults.Friend_ONLINE, tempBuff, ref offset );
					Converter.ToBytes( ch.ZoneId, tempBuff, ref offset );
					Converter.ToBytes( ch.Level, tempBuff, ref offset );
					Converter.ToBytes( (int)ch.Classe, tempBuff, ref offset );
				}
				else
					Converter.ToBytes( (byte)FriendResults.Friend_OFFLINE, tempBuff, ref offset );
			}
			Send( OpCodes.SMSG_FRIEND_LIST, tempBuff, offset );
		}
		DateTime lastAreaTrigger = DateTime.Now;
		public void AreaTrigger( int areaId )
		{
			this.ZoneId = areaId;
			//SendMessage("Area " + areaId.ToString() );
			TimeSpan ts = DateTime.Now.Subtract( lastAreaTrigger );
			if ( ts.TotalSeconds > 6 )
				onAreaTrigger( this, areaId );
		}
		void WhoIsRequest()
		{
			int offset = 4;
			Converter.ToBytes( World.allConnectedChars.Count, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );

			foreach( Character ch in World.allConnectedChars )
			{
				Converter.ToBytes( ch.Name, tempBuff, ref offset );
				Converter.ToBytes( (short)0, tempBuff, ref offset );
				Converter.ToBytes( (int)ch.Level, tempBuff, ref offset );
				Converter.ToBytes( (int)ch.Classe, tempBuff, ref offset );
				Converter.ToBytes( (int)ch.Race, tempBuff, ref offset );
				Converter.ToBytes( (int)ch.ZoneId, tempBuff, ref offset );
				Converter.ToBytes( (int)0, tempBuff, ref offset );
			}
			Send( OpCodes.SMSG_WHO, tempBuff, offset );
		}
		int FindPosInTresorLoot( int from )
		{
			int realFrom = 0;			
			for( realFrom = 0;realFrom < currentObjectLooted.Treasure.Length;realFrom++ )
			{
				Item i = currentObjectLooted.Treasure[ realFrom ];
				if ( i !=  null )
				{
					if ( i.IsQuestItem )
					{
						for(int t = 0;t < 20;t++ )
							if ( activeQuests[ t ] != null )
							{
								if ( activeQuests[ t ].HaveDeliveryObj )
								{
									if ( activeQuests[ t ].NeedItem( i ) )
									{
										if ( from == 0 )
											return realFrom;
										from--;
										break;
									}
								}
							}
					}
					else
					{
						if ( from == 0 )
							return realFrom;
						from--;//	Not a quest item
					}
				}
				else
				{
					if ( from == 0 )
						return realFrom;
					from--;//	Not a quest item
				}
			}
			return realFrom - 1;
		}

		public bool SeeAnyLoot( Mobile killedBy, Item []treasure )
		{			
			if ( killedBy != this )
				return false;
			if ( killedBy.LootMoney > 0 )
				return true;
			foreach( Item i in treasure )
			{
				if ( i !=  null )
				{
					if ( i.IsQuestItem )
					{
						bool ok = false;
						for(int t = 0;t < 20;t++ )
							if ( activeQuests[ t ] != null )
							{
								if ( activeQuests[ t ].HaveDeliveryObj )
								{
									if ( activeQuests[ t ].NeedItem( i ) )
									{
										return true;
									}
								}
							}
						if ( !ok )
						{
							continue;
						}
					}
					else
					{
						return true;
					}
				}
				else
					return true;
			}	
			return false;
		}
		void GossipHello( UInt64 guid )
		{
			Mobile m = this.account.FindMobileByGuid( guid );
			string message = "";
			//	int id = 0;
			( m as BaseCreature ).OnGossipHello( this );
		}/*
		public void GossipHello( UInt64 guid )
		{
			Mobile mob = account.FindMobileByGuid( guid );
			if ( mob == null )
				return;
			if ( ( mob.NpcFlags & (int)NpcActions.SpiritHealer ) != 0 )
			{
				int offset = 4;
				Converter.ToBytes( guid, tempBuff, ref offset );
				Converter.ToBytes( (int)0x244, tempBuff, ref offset );
				Converter.ToBytes( 1, tempBuff, ref offset );
				Converter.ToBytes( 0, tempBuff, ref offset );
				Converter.ToBytes( (short)4, tempBuff, ref offset );
				Converter.ToBytes( "Return me to life", tempBuff, ref offset );		
				Converter.ToBytes( (byte)0, tempBuff, ref offset );
				Converter.ToBytes( 0, tempBuff, ref offset );
				Send( OpCodes.SMSG_GOSSIP_MESSAGE, tempBuff, offset );
			}
		}
		*/
		public void SpiritHealerResurect( UInt64 guid )
		{
			int offset = 4;
			Converter.ToBytes( guid, tempBuff, ref offset );
			Send( OpCodes.SMSG_SPIRIT_HEALER_CONFIRM, tempBuff, offset );
			//this.ReclaimCorps();
		}
		void Kick()
		{
			int offset = 4;
			Converter.ToBytes( Guid, tempBuff, ref offset );
			Converter.ToBytes( 1, tempBuff, ref offset );
			Converter.ToBytes( 1, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( (int)1, tempBuff, ref offset );
			Converter.ToBytes( "bye", tempBuff, ref offset );		
			Converter.ToBytes( (byte)0, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			Send( OpCodes.SMSG_GOSSIP_MESSAGE, tempBuff, offset );
		}
		/*
		public void SwitchManatypeToRage()
		{
			this.SendSmallUpdateToPlayerNearMe( new int[] { (int)UpdateFields.UNIT_FIELD_POWER1 + ManaType, (int)UpdateFields.UNIT_FIELD_MAXPOWER1 + ManaType }, new object[] { 0, 0 } );
			this.ManaType = 1;
			this.ChangeBattleStance( StandStates.BearForm );
			uint flags = (uint)( ( (uint)race ) + ( (int)Classe  << 8 ) + ( gender << 16 ) + ((uint)(manaType)<<24) );
			this.SendSmallUpdateToPlayerNearMe( new int[] { (int)UpdateFields.UNIT_FIELD_POWER1 + ManaType, (int)UpdateFields.UNIT_FIELD_BYTES_0, (int)UpdateFields.UNIT_FIELD_MAXPOWER1 + ManaType }, new object[] { Mana, BaseMana, flags } );
		}
		public void SwitchManatypeToMana()
		{
			this.ManaType = 0;
			this.SendSmallUpdateToPlayerNearMe( new int[] { (int)UpdateFields.UNIT_FIELD_POWER1 + ManaType, (int)UpdateFields.UNIT_FIELD_MAXPOWER1 + ManaType }, new object[] { Mana, BaseMana } );
		}
		public void SwitchManatypeToEnergy()
		{
			this.ManaType = 3;
			this.SendSmallUpdateToPlayerNearMe( new int[] { (int)UpdateFields.UNIT_FIELD_POWER1 + ManaType, (int)UpdateFields.UNIT_FIELD_MAXPOWER1 + ManaType }, new object[] { Mana, BaseMana } );
		}*/
		//in Character 
		public void SwitchManatypeToRage() 
		{ 
			base.ManaType =1; 
			int[] numArray1 = new int[3] { 0x17 + 1, 0x1d + 1, 36 } ; 
			object[] objArray1 = new object[3] { base.Rage, base.BaseRage,((int)Race)|((int)base.Classe << 8)|(((int)Gender) << 16)|(((int)1/*base.ManaType*/) << 24)}; 
			base.SendSmallUpdateToPlayerNearMe(numArray1, objArray1); 
		} 
		public void SwitchManatypeToEnergy() 
		{ 
			base.ManaType = 3; 
			int[] numArray1 = new int[3] { 0x17 + 3, 0x1d + 3, 36 } ; 
			object[] objArray1 = new object[3] { base.Energy, base.BaseEnergy,((int)Race)|((int)base.Classe << 8)|(((int)Gender) << 16)|(((int)3/*base.ManaType*/) << 24)}; 
			base.SendSmallUpdateToPlayerNearMe(numArray1, objArray1); 
		} 
		public void SwitchManatypeToMana() 
		{ 
			base.ManaType = 0; 
			int[] numArray1 = new int[3] { 0x17, 0x1d, 36 } ; 
			object[] objArray1 = new object[3] { base.Mana, base.BaseMana,((int)Race)|((int)base.Classe << 8)|(((int)Gender) << 16)|(((int)0/*base.ManaType*/) << 24)}; 
			base.SendSmallUpdateToPlayerNearMe(numArray1, objArray1); 
		}
		public void CopyAllParameters(Character from) 
		{ 
			//Skills 
			AllSkills.Clear(); 
			IDictionaryEnumerator enumerator = from.AllSkills.GetEnumerator(); 
			while (enumerator.MoveNext()) 
			{ 
				AllSkills.Add( (ushort)enumerator.Key, (Skill)enumerator.Value);             
			} 
			//Abilities 
			KnownAbilities.Clear(); 
			enumerator = from.KnownAbilities.GetEnumerator(); 
			while (enumerator.MoveNext()) 
			{ 
				KnownAbilities.Add( enumerator.Key, enumerator.Value);             
			} 
			//Items 
			
			for(int i=0; i<from.Items.Length; i++) 
			{ 
				if (from.Items[i] != null) 
				{ 
					ConstructorInfo info = HelperTools.Utility.FindConstructor( from.Items[i].GetType().Name); 
					Item newitem = (Item)info.Invoke(null); 
					Items[i] = newitem; 
				}    
				else
					Items[ i ] = null;
			} 
			//Mobile fields       
			Classe = from.Classe; 
			ManaType = from.ManaType; 
			BaseHitPoints = from.BaseHitPoints; 
			HitPoints = from.HitPoints;
			Mana = from.Mana;
			BaseMana = from.BaseMana;          
			BaseAgility = from.BaseAgility; 
			BaseEnergy = from.BaseEnergy; 
			BaseFocus = from.BaseFocus; 
			BaseIq = from.BaseIq; 
			BaseRage = from.BaseRage; 
			BaseSpirit = from.BaseSpirit; 
			BaseStamina = from.BaseStamina; 
			BaseStr = from.BaseStr; 
			Exp = from.Exp; 
			Faction = from.Faction; 
			Level = from.Level; 
			Model = from.Model;          
			Orientation = from.Orientation; 
			RunSpeed = from.RunSpeed; 
			WalkSpeed = from.WalkSpeed; 
			Speed = from.Speed; 

			//Local fields 
			gender = (byte)from.Gender; 
			skin = (byte)from.Skin; 
			face = (byte)from.Face; 
			hairStyle = (byte)from.HairStyle; 
			hairColour = (byte)from.HairColour; 
			race = from.Race; 
			facialHair = (byte)from.FacialHair;                      
		} 

		public override void ChangeRunSpeed( float newspeed )
		{
			base.ChangeRunSpeed( newspeed );
			UpdateRunSpeed();
		}

		public void UpdateRunSpeed()
		{
			int offset = 4;
			Converter.ToBytes( Guid, tempBuff, ref offset );
			Converter.ToBytes( RunSpeed, tempBuff, ref offset );
			ToAllPlayerNear( OpCodes.SMSG_FORCE_RUN_SPEED_CHANGE, tempBuff, offset );
		}

		public void ForceSpeedAck()
		{
		}


		public void SendLootDetails( UInt64 gu, Object lootTarget, int lootMoney )
		{
			currentObjectLooted = lootTarget;
			int offset = 4;
		//	byte []buff = new byte[ 4 + 8 + 1 + 4 + 3 + ( ( loot.Count + 1 ) * ( 7 * 4 + 2 ) ) ];
			Converter.ToBytes( gu, tempBuff, ref offset );
			if ( ( currentObjectLooted.Treasure.Length == 0 ) &&  lootMoney <= 0 )
			{
				Converter.ToBytes( 0x2, tempBuff, ref offset );
				Converter.ToBytes( (short)0, tempBuff, ref offset );
				Send( OpCodes.SMSG_LOOT_RESPONSE, tempBuff, offset );
				return;
			}
			if ( lootMoney > 0 )
			{
				Converter.ToBytes( (byte)0x01, tempBuff, ref offset );
				Converter.ToBytes( lootMoney, tempBuff, ref offset );
			}
			else
			{
				Converter.ToBytes( (byte)0x02, tempBuff, ref offset );
				Converter.ToBytes( 0, tempBuff, ref offset );
			}
			if ( currentObjectLooted.Treasure.Length > 0 )
			{
				Converter.ToBytes( (byte)( currentObjectLooted.Treasure.Length ), tempBuff, ref offset );
				int h = 0;
				foreach( Item i in currentObjectLooted.Treasure )
				{
					if ( i != null )
					{
						if ( i.IsQuestItem )
						{
							bool ok = false;
							for(int t = 0;t < 20;t++ )
								if ( activeQuests[ t ] != null )
								{
									if ( activeQuests[ t ].HaveDeliveryObj )
									{
										if ( activeQuests[ t ].NeedItem( i ) )
										{
											ok = true;												
											break;
										}
									}
								}
							if ( ok )
							{//	ajoute du vide
								Converter.ToBytes( (byte)h++, tempBuff, ref offset );
								Converter.ToBytes( (int)i.Id, tempBuff, ref offset );
								Converter.ToBytes( (int)i.MaxCount, tempBuff, ref offset );
								Converter.ToBytes( (int)i.Model, tempBuff, ref offset );
								Converter.ToBytes( (int)0, tempBuff, ref offset );
								Converter.ToBytes( (int)0, tempBuff, ref offset );
								Converter.ToBytes( (byte)0, tempBuff, ref offset );//	
								continue;
							}
							else h++;
						}
						else
						{
							Converter.ToBytes( (byte)h++, tempBuff, ref offset );
							Converter.ToBytes( (int)i.Id, tempBuff, ref offset );
							Converter.ToBytes( (int)i.MaxCount, tempBuff, ref offset );
							Converter.ToBytes( (int)i.Model, tempBuff, ref offset );
							Converter.ToBytes( (int)0, tempBuff, ref offset );
							Converter.ToBytes( (int)0, tempBuff, ref offset );
							Converter.ToBytes( (byte)0, tempBuff, ref offset );
						}
					}
					else
					{
						Converter.ToBytes( (byte)h++, tempBuff, ref offset );
						Converter.ToBytes( (int)0, tempBuff, ref offset );
						Converter.ToBytes( (int)0, tempBuff, ref offset );
						Converter.ToBytes( (int)0, tempBuff, ref offset );
						Converter.ToBytes( (int)0, tempBuff, ref offset );
						Converter.ToBytes( (int)0, tempBuff, ref offset );
						Converter.ToBytes( (byte)0, tempBuff, ref offset );
					}
				}

			}
			/*for(int t = 0;t < buff.Length ;t++)
					Console.Write("{0} ", buff[t].ToString("X2") );
				Console.WriteLine("");*/
			Send( OpCodes.SMSG_LOOT_RESPONSE, tempBuff, offset );
		}
	/*	public override Object FindObjectByGuid( UInt64 guid )
		{
			return account.FindObjectByGuid( guid );
		}*/
		public void ChangeStandState( int state )
		{
			StandState = (StandStates)state;
			this.SendSmallUpdateToPlayerNearMe( new int[] { (int)UpdateFields.UNIT_FIELD_BYTES_1 }, new object[] { state } );
		}
		public void ChangeBattleStance( StandStates st )
		{
			int t = (int)StandState;
			t = t & 0xffff;
			t += (int)st;
			StandState = (StandStates)t;
			this.SendSmallUpdateToPlayerNearMe( new int[] { (int)UpdateFields.UNIT_FIELD_BYTES_1 }, new object[] { t } );
		}
		public void EarnXP( int amount )
		{
			if ( Level >= 60 )
				return;
			Exp += (uint)amount;
			int offset;
			if ( Exp > Mobile.xpNeeded[ Level ] )
			{
				while( Level < 60 && Exp > Mobile.xpNeeded[ Level ] )
				{
					Level++;
					//					SendSmallUpdate( new int[] { (int)UpdateFields.UNIT_FIELD_LEVEL, (int)UpdateFields.PLAYER_XP, (int)UpdateFields.PLAYER_NEXT_LEVEL_XP }, new object[] { Level, Exp, Mobile.xpNeeded[ Level ] } );
					//00 32 D4 01 02 00 00 00 0C 00 00 00 0B 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 02 00 00 00 01 00 00 00 02 00 00 00 01 00 00 00 01 00 00 00 
					offset = 4;
					int gainHp = 0; 
					int gainMana = 0; 
					float gainStr = 0f; 
					float gainAg = 0f; 
					float gainStam = 0f; 
					float gainInt = 0f; 
					float gainSpirit = 0f;
					if ( onLevelUp != null )
						onLevelUp( this, Level, ref gainHp, ref gainMana, ref gainStr, ref gainAg, ref gainStam, ref gainInt, ref gainSpirit );
					this.BaseAgility += gainAg;
					this.BaseHitPoints += gainHp;
					this.HitPoints = BaseHitPoints - 1;
					this.BaseIq += gainInt;
					this.BaseSpirit += gainSpirit;
					this.BaseMana += gainMana;
					if ( ManaType != 1 )
						this.Mana = this.BaseMana - 1;
					this.BaseStr += gainStr;
					this.BaseStamina += gainStam;
					Converter.ToBytes( Level, tempBuff, ref offset );
					Converter.ToBytes( gainHp, tempBuff, ref offset );//	hp
					Converter.ToBytes( gainMana, tempBuff, ref offset );//	mana
					Converter.ToBytes( 0, tempBuff, ref offset );//	unkn
					Converter.ToBytes( 0, tempBuff, ref offset );
					Converter.ToBytes( 0, tempBuff, ref offset );
					Converter.ToBytes( 0, tempBuff, ref offset );
					Converter.ToBytes( (int)gainStr, tempBuff, ref offset );// str
					Converter.ToBytes( (int)gainAg, tempBuff, ref offset );// ag
					Converter.ToBytes( (int)gainStam, tempBuff, ref offset );// stam
					Converter.ToBytes( (int)gainInt, tempBuff, ref offset );//	int
					Converter.ToBytes( (int)gainSpirit, tempBuff, ref offset );// spirit
					Send( OpCodes.SMSG_LEVELUP_INFO, tempBuff, offset );
					if ( Level > 9 )
						Talent++;
					//	this.SendSmallUpdate( new int[] { (int)UpdateFields.UNIT_FIELD_HEALTH, (int)UpdateFields.UNIT_FIELD_POWER1  + this.ManaType, (int)UpdateFields.UNIT_FIELD_MAXHEALTH, (int)UpdateFields.UNIT_FIELD_MAXPOWER1 + this.ManaType, (int)UpdateFields.UNIT_FIELD_LEVEL,  (int)UpdateFields.UNIT_FIELD_STR, (int)UpdateFields.UNIT_FIELD_AGILITY, (int)UpdateFields.UNIT_FIELD_STAMINA, (int)UpdateFields.UNIT_FIELD_IQ, (int)UpdateFields.UNIT_FIELD_SPIRIT, (int)952/*UpdateFields.UNIT_TRAINING_POINTS*/ }, new object[] { this.HitPoints, this.Mana, this.BaseHitPoints, this.BaseMana, Level, Str, this.Agility, this.Stamina, this.Iq, this.Spirit, Talent } );

					offset = 4;
					Converter.ToBytes( 1, tempBuff, ref offset );
					Converter.ToBytes( (byte)0, tempBuff, ref offset );				
					PrepareUpdateData( tempBuff, ref offset , UpdateType.UpdateFull, false );
					Send( OpCodes.SMSG_UPDATE_OBJECT, tempBuff, offset );
					this.ItemsUpdate();
				}
			}
			else
				if ( Level > 1 && Exp < Mobile.xpNeeded[ Level - 1 ] )
			{
				while( Level > 1 && Exp < Mobile.xpNeeded[ Level - 1 ] )
				{
					Level--;
					SendSmallUpdate( new int[] { (int)UpdateFields.UNIT_FIELD_LEVEL, (int)UpdateFields.PLAYER_XP, (int)UpdateFields.PLAYER_NEXT_LEVEL_XP }, new object[] { Level, Exp, Mobile.xpNeeded[ Level ] } );
				}
			}
			else
			{
				if ( Level > 1 )
				{
					uint realxp = (uint)( Exp - Mobile.xpNeeded[ Level - 1 ] );
					uint mrealxp = (uint)( Mobile.xpNeeded[ Level ] - Mobile.xpNeeded[ Level - 1 ] );
					SendSmallUpdate( new int[] { (int)UpdateFields.PLAYER_XP, (int)UpdateFields.PLAYER_NEXT_LEVEL_XP }, new object[] { realxp, mrealxp } );
				}
				else
					SendSmallUpdate( new int[] { (int)UpdateFields.PLAYER_XP }, new object[] { Exp } );

//				SendSmallUpdate( new int[] { (int)UpdateFields.PLAYER_XP }, new object[] { Exp } );
			}
			offset = 4;
			Converter.ToBytes( Guid, tempBuff, ref offset );
			Converter.ToBytes( amount, tempBuff, ref offset );
			Converter.ToBytes( (byte)0, tempBuff, ref offset );
			Converter.ToBytes( 0x32, tempBuff, ref offset );
			Converter.ToBytes( (float)1.0f, tempBuff, ref offset );
			Send( OpCodes.SMSG_LOG_XPGAIN, tempBuff, offset );
		}
		public void MeetingStoneInfo()
		{
			int offset = 4;
			Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			this.Send( OpCodes.SMSG_MEETING_STONE_INFO, tempBuff, offset );
		}

		void OnTextEmote( int n, UInt64 guid )
		{
			Character c = null;
			if ( guid == 0 || guid == Guid )
				c = this;
			else
				c = account.FindPlayerNearByGuid( guid );
			if ( c == null )
				return;
			//byte []ret = new byte[ 4 + 4 + 4 + 8 + c.Name.Length ];
			int offset = 4;
			/*Converter.ToBytes( Guid, tempBuff, ref offset );
			Converter.ToBytes( n, tempBuff, ref offset );
			Converter.ToBytes( c.Name.Length, tempBuff, ref offset );
			Converter.ToBytes( c.Name, tempBuff, ref offset );
			account.ToAllPlayerNearExceptMe( OpCodes.SMSG_TEXT_EMOTE, tempBuff, offset );
			offset = 4;*/
			if ( World.Emote[ n ] != null )
				Converter.ToBytes( World.Emote[ n ], tempBuff, ref offset );
			else
				Converter.ToBytes( 1, tempBuff, ref offset );

			Converter.ToBytes( Guid, tempBuff, ref offset );
			account.ToAllPlayerNearExceptMe( OpCodes.SMSG_EMOTE, tempBuff, offset );
		}
		public enum ChatMsgType
		{
			CHAT_MSG_SAY                                  = 0x00,
			CHAT_MSG_PARTY                                = 0x01,
			// unknown
			CHAT_MSG_GUILD                                = 0x03,
			CHAT_MSG_OFFICER                              = 0x04,
			CHAT_MSG_YELL                                 = 0x05,
			CHAT_MSG_WHISPER                              = 0x06,
			CHAT_MSG_WHISPER_INFORM                       = 0x07,
			CHAT_MSG_EMOTE                                = 0x08,
			CHAT_MSG_TEXT_EMOTE                           = 0x09,
			CHAT_MSG_SYSTEM                               = 0x0A,
			CHAT_MSG_MONSTER_SAY                          = 0x0B,
			CHAT_MSG_MONSTER_YELL                         = 0x0C,
			CHAT_MSG_MONSTER_EMOTE                        = 0x0D,
			CHAT_MSG_CHANNEL                              = 0x0E,
			CHAT_MSG_CHANNEL_JOIN                         = 0x0F,
			CHAT_MSG_CHANNEL_LEAVE                        = 0x10,
			CHAT_MSG_CHANNEL_LIST                         = 0x11,
			CHAT_MSG_CHANNEL_NOTICE                       = 0x12,
			CHAT_MSG_CHANNEL_NOTICE_USER                  = 0x13,
			CHAT_MSG_AFK                                  = 0x14,
			CHAT_MSG_DND                                  = 0x15,
			CHAT_MSG_COMBAT_LOG                           = 0x16,
			CHAT_MSG_IGNORED                              = 0x17,
			CHAT_MSG_SKILL                                = 0x18,
			CHAT_MSG_LOOT                                 = 0x19,
		};
		void SendMessageTo( Character c, string txt, int langue )
		{
			SendMessageTo( c, ChatMsgType.CHAT_MSG_SAY, txt, langue );
		}
		void SendMessageTo( Character c, ChatMsgType chat, string txt, int langue )
		{
			int offset = 4;
			bool understand = false;
			switch( langue )
			{
				case 7://	Common
					if ( c.HaveSkill( 98 ) )
						understand = true;
					break;
				case 1://	Orcish
					if ( c.HaveSkill( 109 ) )
						understand = true;
					break;
				case 13://	Gnomish
					if ( c.HaveSkill( 313 ) )
						understand = true;
					break;
				case 33://	Gutter
					if ( c.HaveSkill( 673 ) )
						understand = true;
					break;
				case 3://	Tauren
					if ( c.HaveSkill( 115 ) )
						understand = true;
					break;
				case 14://	Troll
					if ( c.HaveSkill( 315 ) )
						understand = true;
					break;
				case 2://	Elf
					if ( c.HaveSkill( 113 ) )
						understand = true;
					break;
				case 6://	Dwarf
					if ( c.HaveSkill( 111 ) )
						understand = true;
					break;
			}
			if ( understand )
			{
				tempBuff[ offset++ ] = (byte)chat;//type, CHAT_MSG_SAY, CHAT_MSG_CHANNEL, CHAT_MSG_WHISPER, CHAT_MSG_YELL, CHAT_MSG_PARTY
				Converter.ToBytes( langue, tempBuff, ref offset );
			}
			else
			{
				tempBuff[ offset++ ] = (byte)chat;//type
				Converter.ToBytes( langue, tempBuff, ref offset );
			}
			Converter.ToBytes( Guid, tempBuff, ref offset );
			Converter.ToBytes( Guid, tempBuff, ref offset );
			
			//		string tx = txt + " ( " + r.ToString() + " )";
			//		r = (ushort)( r << 1 );
			Converter.ToBytes( txt.Length + 1, tempBuff, ref offset );
			Converter.ToBytes( txt, tempBuff, ref offset );
			Converter.ToBytes( (short)1, tempBuff, ref offset );// Togle afk
			int len = offset;

			c.Send( OpCodes.SMSG_MESSAGECHAT, tempBuff, len );
	
		}

		void MessageHandler( string txt, ChatMsgType chat, int langue )
		{////00 07 00 00 00 0A 00 00 00 00 00 00 00 0A 00 00 00 00 00 00 00 04 00 00 00 7A 6F 62 00 03 
			if ( txt.StartsWith( "." ) )
				OnCommand( txt );
			else
			{				
				switch( chat )
				{
					case ChatMsgType.CHAT_MSG_SAY:
					{
						SendMessageTo( this, chat, txt, langue );
						if ( account.PlayersNear.Count == 0 )
							return;
						foreach( Character c in account.PlayersNear )
						{
							if ( c.Player.PlayersNear.Contains( this ) )
								SendMessageTo( c, txt, langue );
						}
						
					}
						break;
					case ChatMsgType.CHAT_MSG_PARTY:
					{
						foreach( Member member in GroupMembers.Members )
						{
							SendMessageTo( member.Char, chat, txt, langue );
						}
					}
						break;
				}
			}

			//account.ToAllPlayerNear( OpCodes.SMSG_MESSAGECHAT, tempBuff, offset );
		}

		public void Login( Account acc )
		{
			account = acc;
			guowner = null;
			gu = null;			
			ZoneId = World.mapZones.NearestZoneId( this );
		}
		public void Loggout()
		{
			account = null;
		}
		public void OnLogin()
		{
			if ( Dead )
			{
				X = this.CorpseLocationX;
				Y = this.CorpseLocationY;
				Z = this.CorpseLocationZ;
				MapId = this.CorpseMapId;
				OnDeath( this );
			}
			//path = World.AllocateTrajet();
			if ( Summon != null )
			{
				Summon.X = X;
				Summon.Y = Y;
				Summon.Z = Z;
				Summon.MapId = MapId;
				Summon.Freeze = false;
				Player.RefreshMobileList( true );
			}
			internalTimer = new InternalHeartBeatTimer( this );
			internalTimer.Start();
			if ( onLogin != null )
			{
				onLogin( this );
			}
			logged = true;
			System.Collections.ICollection keys = this.KnownAbilities.Keys;
			/*foreach(int i in keys) It crash
			{
				if(this.KnownAbilities[i] != null)
					if ( SpellTemplate.SpellEffects[ i ] != null)
					{
						if ( SpellTemplate.SpellEffects[i] is PermanentSpellEffect)
						{
							PermanentSpellEffect pse = (PermanentSpellEffect)SpellTemplate.SpellEffects[ i ];
							pse( (BaseAbility)Abilities.abilities[i], this );
						}
					}
			}*/
			keys = this.TalentList.Keys;
			foreach(int i in keys)
			{
				if(this.KnownAbilities[i] != null)
					if ( SpellTemplate.SpellEffects[ i ] != null)
					{
						if ( SpellTemplate.SpellEffects[i] is PermanentSpellEffect)
						{
							PermanentSpellEffect pse = (PermanentSpellEffect)SpellTemplate.SpellEffects[ i ];
							pse( (BaseAbility)Abilities.abilities[i], this );
						}
					}
			}

		}
		bool OnTrainningAck()
		{
			if ( onTrainningAck != null )
				return onTrainningAck( this );
			return true;
		}
		bool antiOverflow = false;
		public void OnLogout()
		{
			if ( antiOverflow )
				return;
			antiOverflow = true;
			if ( Summon != null )
			{
				Summon.X = -2000.0f;
				Summon.Y = -2000.0f;
				Summon.Z = 1000f;
				Summon.MapId = 2;
				Summon.Freeze = true;
				/*
				Summon.Delete();
				if ( World.allMobiles.Contains( Summon ) )
					World.allMobiles.Remove( Summon );*/
			}
			if ( this.combatTimer != null )
				combatTimer.Stop();
			if ( SpellTimer != null )
				SpellTimer.Stop();
			if ( this.internalTimer != null )
				internalTimer.Stop();
			if ( onLogout != null )
				onLogout( this );
			antiOverflow = false;
		}

		public void OnCreateCharacter()
		{
			if ( onCreateCharacter != null )
				onCreateCharacter( this );
		}
		void SendName( UInt64 guid )
		{		
			Character c = null;
			if ( guid == Guid )
				c = this;
			else
				c = account.FindPlayerNearByGuid( guid );
			if ( c == null )
				return;
			byte []namequery = new byte[ 4 + 8 + c.Name.Length + 1 + 12 ];
			int	t = 4;
			Converter.ToBytes( c.Guid, namequery, ref t );
			Converter.ToBytes( c.Name, namequery, ref t );
			Converter.ToBytes( (byte)0, namequery, ref t );
			Converter.ToBytes( (int)c.Race, namequery, ref t );
			Converter.ToBytes( (int)c.Gender, namequery, ref t );
			Converter.ToBytes( (int)c.Classe, namequery, ref t );
			Send( OpCodes.SMSG_NAME_QUERY_RESPONSE, namequery );
		}

		GameObject FindGameObjectByGuid( UInt64 guid )
		{
			foreach( Object o in this.account.KnownObjects )
			{
				if ( o is GameObject )
				{
					GameObject go = (GameObject)o;
					if ( go.Guid == guid )
						return go;
				}
			}
			return null;
		}

		void GameObjectQuery( int id, UInt64 guid )
		{
			int offset = 4;
			GameObject go = FindGameObjectByGuid( guid );
			if ( go == null )
				return;
			Converter.ToBytes( go.Id, tempBuff, ref offset );
			Converter.ToBytes( go.ObjectType, tempBuff, ref offset );
			Converter.ToBytes( go.Model, tempBuff, ref offset );
			Converter.ToBytes( go.Name, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			for(int t = 0;t < go.Sound.Length;t++ )
				Converter.ToBytes( go.Sound[ t ], tempBuff, ref offset );
			for(int t = go.Sound.Length;t < 16;t++ )
				Converter.ToBytes( 0, tempBuff, ref offset );
	//	HexViewer.View( tempBuff, 0, offset );
			Send( OpCodes.SMSG_GAMEOBJECT_QUERY_RESPONSE, tempBuff, offset );
		}

		void JoinChannel( byte []from, int off )
		{
			string channelName = "";
			for(int t = off; from[ t ] != 0;t++ )
				channelName += "" + (char)from[ t ];
			byte []data = new byte[ 11 + channelName.Length ];
			int offset = 4;
			Converter.ToBytes( (byte)2, data, ref offset );
			Converter.ToBytes( channelName, data, ref offset );
			Converter.ToBytes( (byte)0, data, ref offset );
			Converter.ToBytes( 1, data, ref offset );
			Player.Handler.Send( OpCodes.SMSG_CHANNEL_NOTIFY, data );
		}

		public override void OnGetHit(  Mobile by, bool sp, int damageAmount )
		{
			base.OnGetHit( by, sp, damageAmount );
		}

		
		
		 void HeartBeat()
		{		
			if ( account.TestIfLoggout() )
				return;
			//if ( account.justLogged )
			//	return;
			//base.ManaRegeneration();
			int dirtyMana = Mana;
			int dirtyHp = HitPoints;
			if ( onHeartBeat != null )
				if ( onHeartBeat( this ) && ( !InCombat || this.ManaType == 3 ) )
				{
					if ( Dead )
					{
						lastHeartBeat = DateTime.Now;
						return;
					}

					if ( ManaType == 1 && Mana > 0 )
					{
						TimeSpan ts = DateTime.Now.Subtract( lastHeartBeat );
						Mana -= (int)ts.TotalSeconds * 10;
						if ( Mana < 0 )
							Mana = 0;
					}
					else
						if ( Mana < BaseMana && ManaType == 3 )
					{
						TimeSpan ts = DateTime.Now.Subtract( lastHeartBeat );
						Mana += (int) ( ts.TotalSeconds * 12 );
						if ( Mana > BaseMana )
							Mana = BaseMana;
					}
					else
					if ( Mana < BaseMana && ManaType != 1 )
					{
						TimeSpan ts = DateTime.Now.Subtract( lastHeartBeat );
						Mana += (int) ( ts.TotalSeconds * (double)BaseMana * ManaRegenerationModifier / 30 );
						if ( Mana > BaseMana )
							Mana = BaseMana;
					}
					if ( HitPoints < BaseHitPoints && !InCombat )
					{
						TimeSpan ts = DateTime.Now.Subtract( lastHeartBeat );
						HitPoints += (int)( ts.TotalSeconds * (double)BaseHitPoints * HealthRegenerationModifier / 40 );
						if ( HitPoints > BaseHitPoints )
							HitPoints = BaseHitPoints;
					}
				}
			if ( dirtyMana != Mana && dirtyHp != HitPoints )
			{
				this.SendSmallUpdateToPlayerNearMe( new int[]{ 22, 23 + ManaType }, new object[] { HitPoints, Mana } );
			}
			else
				if ( dirtyMana != Mana )
			{
				this.SendSmallUpdateToPlayerNearMe( new int[]{ 23 + ManaType }, new object[] { Mana } );
			}
			else
				if ( dirtyHp != HitPoints )
			{
				this.SendSmallUpdateToPlayerNearMe( new int[]{ 22 }, new object[] { HitPoints } );
			}
			lastHeartBeat = DateTime.Now;
			return;
		}

		void SpawnerQuery( UInt64 guid, int id )
		{
			int offset = 4;
			Converter.ToBytes( id, tempBuff, ref offset );
			Converter.ToBytes( "Spawner", tempBuff, ref offset );
			Converter.ToBytes( (byte)0, tempBuff, ref offset );
			//Converter.ToBytes( m.Name, tempBuff, ref offset );
			Converter.ToBytes( (byte)0, tempBuff, ref offset );
			Converter.ToBytes( (byte)0, tempBuff, ref offset );//	name3
			Converter.ToBytes( (byte)0, tempBuff, ref offset );//	name4
/*			if ( m.Guild != null )
			{
				Converter.ToBytes( m.Guild, tempBuff, ref offset );//	Guild
				Converter.ToBytes( (byte)0, tempBuff, ref offset );
			}
			else*/
				Converter.ToBytes( (byte)0, tempBuff, ref offset );
		//	Converter.ToBytes( m.Flags1, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
		/*	if ( (int)( m.NpcType & 2 ) > 0 )
				Converter.ToBytes( 7, tempBuff, ref offset );
			else*/
				Converter.ToBytes( 0, tempBuff, ref offset );
			//Converter.ToBytes( m.NpcType, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
		//	Converter.ToBytes( m.Unk4, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );

			Send( OpCodes.SMSG_CREATURE_QUERY_RESPONSE, tempBuff, offset );
		}
		void CreatureQuery( UInt64 guid, int id )
		{
			Mobile m = null;
			if ( (ulong)( guid & 0xf100000000000000 ) == 0xF100000000000000 )
				SpawnerQuery( guid, id );
			else
				m = this.Player.FindMobileByGuid( guid );
			if ( m == null )
			{
			//	Console.WriteLine( "Unknow guid {0}", guid.ToString( "X16" ) );
				return;
			}
			int offset = 4;
			Converter.ToBytes( id, tempBuff, ref offset );
			Converter.ToBytes( m.Name, tempBuff, ref offset );
			Converter.ToBytes( (byte)0, tempBuff, ref offset );
			if ( m.Name2 != null )
			{
				Converter.ToBytes( m.Name2, tempBuff, ref offset );
				Converter.ToBytes( (byte)0, tempBuff, ref offset );
			}
			else
				Converter.ToBytes( (byte)0, tempBuff, ref offset );
			Converter.ToBytes( (byte)0, tempBuff, ref offset );//	name3
			Converter.ToBytes( (byte)0, tempBuff, ref offset );//	name4
			if ( m.Guild != null )
			{
				Converter.ToBytes( m.Guild, tempBuff, ref offset );//	Guild
				Converter.ToBytes( (byte)0, tempBuff, ref offset );
			}
			else
			Converter.ToBytes( (byte)0, tempBuff, ref offset );
			Converter.ToBytes( m.Flags1, tempBuff, ref offset );
			if ( (int)( m.NpcType & 2 ) > 0 )
				Converter.ToBytes( 7, tempBuff, ref offset );
			else
				Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( m.NpcType, tempBuff, ref offset );
			Converter.ToBytes( m.Unk4, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );

			Send( OpCodes.SMSG_CREATURE_QUERY_RESPONSE, tempBuff, offset );
		}
		public bool deadEndTeleportLoop = false;
		void MoveHandler( float x, float y, float z, float orientation )
		{
			//deadEndTeleportLoop = false;
			if ( gu != null && dt == null && guowner == this )
			{
				CancelDuel( Duel );
			}
		//	if ( this.combatTimer != null )
		//		combatTimer.Restart();//	si on bouge ça remet a zero le timer de combat !
			SetPosition( x, y, z, orientation );			
		}

		public void SendMessage( string cmd )
		{
			int offset = 4;
			Converter.ToBytes( 0xa, tempBuff, ref offset );
			Converter.ToBytes( (byte)0, tempBuff, ref offset );
			Converter.ToBytes( Guid, tempBuff, ref offset );
			Converter.ToBytes( cmd.Length + 1, tempBuff, ref offset );
			Converter.ToBytes( cmd, tempBuff, ref offset );
			Converter.ToBytes( (short)0, tempBuff, ref offset );
			Player.Handler.Send( 0x96, tempBuff, offset );
		}
		
		public static Character FindByGUID( UInt64 g )
		{
			foreach( Character c in allCharacters )
			{
				if ( c.Guid == g )
					return c;				
			}
			return null;
		}


		public void TrainAbility( int ab )
		{
			TrainAbility( new int[] { ab } );
		}
		public class Action
		{
			public byte place;
			public ushort action;
			public byte type;
			public byte other;
			public Action( GenericReader gr )
			{
				Deserialize( gr );
			}
			public Action( byte p, ushort a, byte t, byte o )
			{
				place = p;
				action = a;
				type = t;
				other = o;
			}
			public void Change( byte p, ushort a, byte t, byte o )
			{
				place = p;
				action = a;
				type = t;
				other = o;
			}
			
			public void Serialize( GenericWriter gw )
			{
				gw.Write( place );
				gw.Write( action );
				gw.Write( type );
				gw.Write( other );
			}
			public void Deserialize( GenericReader gr )
			{
				place = gr.ReadByte();
				action = (ushort)gr.ReadShort();
				type = gr.ReadByte();
				other = gr.ReadByte();
			}
		}
		public void AddToActionBar( byte place, ushort id, byte other, byte type )
		{
			Action found = null;
			foreach( Action act in actionBar )
			{
				if ( act.action == id )
				{
					found = act;
					break;
				}
			}
			if ( id == 0 )
			{
				if ( found != null )
					actionBar.Remove( found );
				return;
			}
			if ( found != null )
				found.Change( place, (ushort)id, (byte)type, (byte)other );
			else
				actionBar.Add( new Action( place, (ushort)id, (byte)type, (byte)other ) );
		}
		public void ActionBarAdd( int ab )
		{
			AddToActionBar( (byte)0, (ushort)ab,  (byte)0,  (byte)0 );
		}
		public void SendAllSpells()
		{		
			//Handler.Send( new byte[]{ 0x00, 0x7F, 0x2A, 0x01, 0x00, 0x1E, 0x00, 0x37, 0x0C, 0x00, 0x00, 0x6B, 0x00, 0x00, 0x00, 0xCC, 0x0A, 0x00, 0x00, 0x99, 0x09, 0x00, 0x00, 0x4E, 0x00, 0x00, 0x00, 0xC4, 0x00, 0x00, 0x00, 0x9C, 0x04, 0x00, 0x00, 0xC6, 0x00, 0x00, 0x00, 0xC9, 0x00, 0x00, 0x00, 0x76, 0x23, 0x00, 0x00, 0x75, 0x23, 0x00, 0x00, 0x21, 0x22, 0x00, 0x00, 0x9C, 0x23, 0x00, 0x00, 0xCA, 0x00, 0x00, 0x00, 0xEE, 0x02, 0x00, 0x00, 0xC0, 0x3F, 0x00, 0x00, 0x9C, 0x02, 0x00, 0x00, 0xAC, 0x1C, 0x00, 0x00, 0xCB, 0x19, 0x00, 0x00, 0x51, 0x00, 0x00, 0x00, 0xCB, 0x00, 0x00, 0x00, 0x6D, 0x50, 0x00, 0x00, 0x6F, 0x50, 0x00, 0x00, 0x70, 0x50, 0x00, 0x00, 0x71, 0x50, 0x00, 0x00, 0x4B, 0x00, 0x00, 0x00, 0xCC, 0x0A, 0x00, 0x00, 0x08, 0x01, 0x00, 0x00, 0x0A, 0x01, 0x00, 0x00, 0x07, 0x0A, 0x00, 0x00, 0x00, 0x00 } );
			int offset = 4;
			Converter.ToBytes( (byte)0, tempBuff, ref offset );
			Converter.ToBytes( (short)KnownAbilities.Count, tempBuff, ref offset );
			IDictionaryEnumerator Enumerator = KnownAbilities.GetEnumerator();
			while (Enumerator.MoveNext())
			{
				int spell = (int)Enumerator.Key;
				//int place = (int)Enumerator.Value;
				Converter.ToBytes( spell, tempBuff, ref offset );
			}
			account.Handler.Send( OpCodes.SMSG_INITIAL_SPELLS, tempBuff, offset );
		}

		public void SendAllActionButtons()
		{
			int offset = 4;
			foreach( Action act in actionBar )
			{
		/*		if ( act.place == -1 )
					Converter.ToBytes( 0, tempBuff, ref offset );
				else*/
				{
					//offset = 4 + place * 4;
					Converter.ToBytes( (ushort)act.action, tempBuff, ref offset );
					Converter.ToBytes( act.type, tempBuff, ref offset );
					Converter.ToBytes( act.other, tempBuff, ref offset );
				}
			}
			account.Handler.Send( OpCodes.SMSG_ACTION_BUTTONS, tempBuff, 0x1E4 );
		}
		void SetSelection( UInt64 guid )
		{
			if ( guid < 0xF100000000000000 )
				selection = account.FindMobileByGuid( guid );
			selection = account.FindObjectByGuid( guid );
		}
		#endregion

		#region COMMANDS


		private class TestTimer : WowTimer
		{
			Character from;
			Mobile to;
			int c = 0;
			public TestTimer( Character c, Mobile f ) : base( WowTimer.Priorities.Milisec100 , 1000, "TestTimer" )
			{
				from = c;
				to = f;
				float ax = ( c.X - to.X );
				float ay = ( c.Y - to.Y );
				float az = ( c.Z - to.Z );
				float dist = (float)Math.Sqrt( ax * ax + ay * ay + az * az );
				from.SendMessage( "dist = " + dist.ToString() );
				Start();
			}
			public override void OnTick()
			{
				float x;
				float y;
				float z;
				to.moveVector.Get( out x, out y, out z );
				from.SendMessage( "X = " + x.ToString() + ", Y = " + y.ToString() + ", Z = " + z.ToString() );
			//	from.SendMessage( "temps = " + c.ToString() );
				c++;
				base.OnTick ();
			}
		}

		
		public void DestroyObject( UInt64 guid )				
		{
			
			byte []b = { 0x00, 0x0A, 0xAA, 0x00, 0x6E, 0x36, 0x05, 0x00, 0x00, 0x00, 0x00, 0x00 };
			int t = 4;
			Converter.ToBytes( guid, b, ref t );

			Send( OpCodes.SMSG_DESTROY_OBJECT, b, t );
		}

		public static string FirstParam( string str )
		{
			string []fname = str.Split( new char[] { '\t', '(', ')', ' ', '\'', ':', '\"', '-', '/', '\\' } );
			if ( fname.Length >= 0 )
				if ( fname[ 0 ].Length > 0 )
					return fname[ 0 ];
				else
					if ( fname.Length >= 1 && fname[ 1 ].Length > 0 )
					return fname[ 1 ];
				else
					if ( fname.Length >= 2 && fname[ 2 ].Length > 0 )
					return fname[ 2 ];
			return "";
		}
		public static string SecondParam( string str )
		{
			string []fname = str.Split( new char[] { '\t', '(', ')', ' ', '\'', ':', '\"', '-', '/', '\\' } );
			if ( fname.Length > 1 )
				return fname[ 1 ];
			return "";
		}	
		public static string ThirdParam( string str )
		{
			string []fname = str.Split( new char[] { '\t', '(', ')', ' ', '\'', ':', '\"', '-', '/', '\\' } );
			if ( fname.Length > 2 )
				return fname[ 2 ];
			return "";
		}	
		public static string FourthParam( string str )
		{
			string []fname = str.Split( new char[] { '\t', '(', ')', ' ', '\'', ':', '\"', '-', '/', '\\' } );
			if ( fname.Length > 3 )
				return fname[ 3 ];
			return "";
		}	
		void ImportWad()
		{
			Console.WriteLine( "Converting creature file..." );
			int etat = 0;
			int line = 0;
			int err = 0;
			int n = 0;
			int gos = 0;
			int gob = 0;
			Hashtable i = new Hashtable();
			i[ "mapid" ] = (ushort)0;

		//	ConstructorInfo ct;// = Utility.FindConstructor( "Spawner" );
			TextReader tx = new StreamReader( "world.save" );
			while( err < 100 )
			{
				string str = tx.ReadLine();
				line++;
				
				if ( str == null )
					break;
				if ( str.Length == 0 )
					continue;
				if ( str.StartsWith( "[" ) )
				{
					etat = 1;
					if ( i[ "type" ] != null )
					{						
						
						if ( (int)i[ "type" ] == 5 )// Game Obj
						{
							if ( GameObjectDescription.all[ (int)i[ "entry" ] ] != null )
							{
								GameObjectSpawner bc = new GameObjectSpawner();
								int goid = (int)i[ "entry" ];
								i[ "entry" ] = null;
								if ( GameObjectDescription.all[ goid ] == null )
								{
									Console.WriteLine( "Game object {0} unknown !", goid );
									continue;
								}
								bc.Init( goid, (int)1, null );
								World.Add( bc, (float)i[ "x" ], (float)i[ "y" ], (float)i[ "z" ], (ushort)i[ "mapid" ] );
								bc.Orientation = (float)i[ "o" ];
								if ( i[ "rx" ] != null )
								{
									bc.RotationX = (float)i[ "rx" ];
									bc.RotationY = (float)i[ "ry" ];
									bc.RotationZ = (float)i[ "rz" ];
									bc.Facing = (float)i[ "ro" ];
								}
								gos++;
								i[ "mapid" ] = (ushort)0;
								i[ "type" ] = null;
							}
							else
								Console.WriteLine("Unknown Game object {0}", (int)i[ "entry" ] );
							i[ "mapid" ] = (ushort)0;
						}
						else				
						if ( i[ "spawngobjid" ] != null )
						{
							GameObjectSpawner bc = new GameObjectSpawner();
							int goid = (int)i[ "spawngobjid" ];
							i[ "spawngobjid" ] = null;
							if ( GameObjectDescription.all[ goid ] == null )
							{
								Console.WriteLine( "Game object {0} unknown !", goid );
								continue;
							}
							bc.Init( goid, (int)i[ "spawntime" ], null );
							World.Add( bc, (float)i[ "x" ], (float)i[ "y" ], (float)i[ "z" ], (ushort)i[ "mapid" ] );
							bc.Orientation = (float)i[ "o" ];
							if ( i[ "rx" ] != null )
							{
								bc.RotationX = (float)i[ "rx" ];
								bc.RotationY = (float)i[ "ry" ];
								bc.RotationZ = (float)i[ "rz" ];
								bc.Facing = (float)i[ "ro" ];
							}
							gos++;
							i[ "mapid" ] = (ushort)0;
						}
						else
							if ( i[ "spawnid" ] != null )
						{
							MobileSpawner bc = new MobileSpawner();
							ConstructorInfo mob = World.MobilePool( (int)i[ "spawnid" ] );
							if ( mob == null )
							{
								Console.WriteLine("creature id {0} unknown", (int)i[ "spawnid" ] );								
							}
							else
							{
								BaseCreature b = (BaseCreature)mob.Invoke( null );
								bc.Model = b.Model;
								bc.Id = 99999999 - b.Id;
								if ( (int)i[ "spawntime" ] <= 0 )
									Console.WriteLine("Invalid spawntime {0}" , (int)i[ "spawntime" ] );
								else
								{
									bc.Init( mob, b.Id, (int)i[ "spawntime" ], (int)i[ "spawnnumber" ] );
									World.Add( bc, (float)i[ "x" ], (float)i[ "y" ], (float)i[ "z" ], (ushort)i[ "mapid" ] );
									bc.Orientation = (float)i[ "o" ];
							//		for(int t = 0;t < bc.Amount;t++ )
							//			bc.ForceRespawn();
									i[ "spawngobjid" ] = null;
								}
								i = new Hashtable();
								i[ "mapid" ] = (ushort)0;
							
								n++;
							}
						}
					}
				}
				else
					if ( etat == 1 )
				{
					if ( str.StartsWith( "//" ) )
						continue;					
					string []spl = str.Split( new Char [] { '=' } );
					if ( spl.Length != 2 )	
					{
						Console.WriteLine( "{0} : {1}","Syntaxe Error, line " + line.ToString(), str );
					}
					else
					{
						string tag = spl[ 0 ].ToLower();
						string val = spl[ 1 ];
						if ( val.EndsWith( " " ) )
							val = val.Substring( 0, val.Length - 1 );
#if !DEBUG
						try
#endif
						{
							switch( tag )
							{		
								case "model":								
									i[ "model" ] = (int)Convert.ToInt32( val );
									break;	
								case "type":								
									i[ "type" ] = (int)Convert.ToInt32( val );
									break;	
								case "entry":								
									i[ "entry" ] = (int)Convert.ToInt32( val );
									break;	
								case "gflag":								
									i[ "gflag" ] = (int)Convert.ToInt32( val );
									break;	
								case "map":								
									i[ "mapid" ] = (ushort)Convert.ToInt32( val );
									break;	
								case "rotation":		
									string[]st = val.Split( new char[]{ ' ' } );
									i[ "rx" ] = (float)Convert.ToSingle( st[ 0 ] );
									i[ "ry" ] = (float)Convert.ToSingle( st[ 1 ] );
									i[ "rz" ] = (float)Convert.ToSingle( st[ 2 ] );
									i[ "ro" ] = (float)Convert.ToSingle( st[ 3 ] );
									break;
								case "spawntime":
									string second = SecondParam( val );
									string first2 = FirstParam( val );
									int sec = Convert.ToInt32( second );
									if ( sec <= 10 )
										sec = 20;
									i[ "spawntime" ] = sec;
									break;			
								case "spawn":
									second = SecondParam( val );
									first2 = FirstParam( val );
									i[ "spawnid" ] = (int)Convert.ToInt32( first2 );
									i[ "spawnnumber" ] = (int)Convert.ToInt32( second );
									break;		
								case "spawn_gobj":
									second = SecondParam( val );
									first2 = FirstParam( val );
									i[ "spawngobjid" ] = (int)Convert.ToInt32( first2 );
									i[ "spawnnumber" ] = (int)1;//Convert.ToInt32( second );
									break;				
								case "xyz":
									string[]stro = val.Split( new char[]{ ' ' } );
									i[ "x" ] = (float)Convert.ToDouble( stro[ 0 ] );
									i[ "y" ] = (float)Convert.ToDouble( stro[ 1 ] );
									i[ "z" ] = (float)Convert.ToDouble( stro[ 2 ] );
									i[ "o" ] = (float)Convert.ToDouble( stro[ 3 ] );
									break;					
								default:
									break;
							}		
						}
#if !DEBUG
						catch( Exception e )
						{							
							Console.WriteLine( "Exception {0}", e.Message );
							Console.WriteLine( "Line {0}", line );
						}
#endif
					}
				}
				
			}			
			SendMessage( n.ToString() + " spawn point created" );
			SendMessage( gob.ToString() + " game objects created" );
			SendMessage( gos.ToString() + " game objects spawn point created" );
			SendMessage( "I'm now importing the spawn points... this could take several minutes..." );
			World.AdjustSpawners();
			SendMessage( "Spawn points imported" );
		}		


		class GMInvisibilityAura : AuraEffect
		{
			public GMInvisibilityAura() : base( 885,0, 38, 99, 1, 0, 200, 0, 0, 0, 0, Resistances.Arcane,DispelType.None, 200, 3000, 100, 0xffffff, 0, 18, 101, 0x03 )
			{
			}
		}

		static void OnGMInvisibilityEnded( Mobile c )
		{
			c.Visible = InvisibilityLevel.Visible;
		}

		public override void Mount( Mobile m )
		{
			if ( m == Summon )
			{
				//	Summon.Freeze = true;
				Summon.Visible = InvisibilityLevel.True;
				DestroyObject( Summon.Guid );
				Player.KnownObjects.Remove( Summon );	
				this.MountModel = Summon.Model;
			}
			else
				MountModel = m.Model;
			int offset = 4;
			Converter.ToBytes( 1, tempBuff, ref offset );
			Converter.ToBytes( (byte)0, tempBuff, ref offset );				
			PrepareUpdateData( tempBuff, ref offset , UpdateType.UpdateFull, false );
			Send( OpCodes.SMSG_UPDATE_OBJECT, tempBuff, offset );
			this.ItemsUpdate();
			Aura aura = new Aura();
			aura.OnRelease = new Aura.AuraReleaseDelegate( this.OnUnMount );
			AddAura( mountedIdAuraEffect = (AuraEffect)World.MountsList[ m.Id ], aura );
		}

		public override void OnUnMount( Mobile c )
		{
			int offset = 4;
			if ( Summon != null )
			{
				Summon.Visible = InvisibilityLevel.Visible;
				Summon.X = X;
				Summon.Y = Y;
				Summon.Z = Z;
				Summon.Orientation = Orientation;
			//	Summon.Freeze = false;
				Player.RefreshMobileList( true );				
			}
			this.MountModel = 0;
			offset = 4;
			Converter.ToBytes( 1, tempBuff, ref offset );
			Converter.ToBytes( (byte)0, tempBuff, ref offset );				
			PrepareUpdateData( tempBuff, ref offset , UpdateType.UpdateFull, false );
			Send( OpCodes.SMSG_UPDATE_OBJECT, tempBuff, offset );
			this.ItemsUpdate();
			//base.OnUnMount( c );
			this.ReleaseAura( mountedIdAuraEffect );
		}

		void UnMount()
		{
			OnUnMount( null );
			/*
			if ( Summon != null )
			{
				Summon.Visible = InvisibilityLevel.Visible;
				Summon.X = X;
				Summon.Y = Y;
				Summon.Z = Z;
				Summon.Orientation = Orientation;
			//	Summon.Freeze = false;
				Player.RefreshMobileList();				
			}
			this.ReleaseAura( mountedIdAuraEffect );
			this.MountModel = 0;
			int offset = 4;
			Converter.ToBytes( 1, tempBuff, ref offset );
			Converter.ToBytes( (byte)0, tempBuff, ref offset );				
			PrepareUpdateData( tempBuff, ref offset , UpdateType.UpdateFull, false );
			Send( OpCodes.SMSG_UPDATE_OBJECT, tempBuff, offset );
			offset = 4;
			Converter.ToBytes( 1, tempBuff, ref offset );
			Converter.ToBytes( (byte)0, tempBuff, ref offset );				
			PrepareUpdateData( tempBuff, ref offset , UpdateType.UpdateFull, true );
			this.ToAllPlayerNearExceptMe( OpCodes.SMSG_UPDATE_OBJECT, tempBuff, offset );
			this.ItemsUpdate();			*/
		}

		public ArrayList team1 = new ArrayList();
		public ArrayList team2 = new ArrayList();
		public bool testCombatStarted = false;
		class MobBalance : WowTimer
		{
			Character to;
			public MobBalance( Character from ) :  base( WowTimer.Priorities.Milisec100 , 1000, "MobBalance" )
			{
				to = from;
				Start();
			}
			public override void OnTick()
			{
				for(int j = 0;j < 4;j++ )
				{
					for(int t = 0;t < to.team1.Count;t++ )
					{
						if ( ( to.team1[ t ] as BaseCreature ).Dead )
						{
							to.team1.RemoveAt( t );
							break;
						}
					}
					for(int t = 0;t < to.team2.Count;t++ )
					{
						if ( ( to.team2[ t ] as BaseCreature ).Dead )
						{
							to.team2.RemoveAt( t );
							break;
						}
					}
				}
				to.SendMessage( "Team1 alive : " + to.team1.Count );
				to.SendMessage( "Team2 alive : " + to.team2.Count );
				if ( to.team1.Count == 0 )
				{
					to.SendMessage( "Team1 loose, team2 alive : " + to.team2.Count );
					to.testCombatStarted =false;
					Stop();
					foreach( Mobile m in to.team2 )
						m.Kill();
					to.team2.Clear();
				}
				if ( to.team2.Count == 0 )
				{
					to.SendMessage( "Team2 loose, team1 alive : " + to.team1.Count );
					to.testCombatStarted =false;
					Stop();
					foreach( Mobile m in to.team1 )
						m.Kill();
					to.team1.Clear();
				}
				base.OnTick();
			}
		}

/*		public void CancelDuel()
		{
			if ( flag != 0 )
				CancelDuel( flag );
			else
			{
				int offset = 4;
				Converter.ToBytes( (byte)0, tempBuff, ref offset );
				Send( OpCodes.SMSG_DUEL_COMPLETE, tempBuff, offset );
				gu.Send( OpCodes.SMSG_DUEL_COMPLETE, tempBuff, offset );
				guowner = null;
				gu.guowner = null;
				gu.gu = null;
				gu = null;
			}
		}*/

		void CancelDuel( UInt64 g )
		{
			int offset = 4;
			Converter.ToBytes( g, tempBuff, ref offset );
			Send( OpCodes.SMSG_GAMEOBJECT_DESPAWN_ANIM, tempBuff, offset );
			gu.Send( OpCodes.SMSG_GAMEOBJECT_DESPAWN_ANIM, tempBuff, offset );
			Send( OpCodes.SMSG_DESTROY_OBJECT, tempBuff, offset );
			gu.Send( OpCodes.SMSG_DESTROY_OBJECT, tempBuff, offset );
			offset = 4;
			Converter.ToBytes( (byte)0, tempBuff, ref offset );
			Send( OpCodes.SMSG_DUEL_COMPLETE, tempBuff, offset );
			gu.Send( OpCodes.SMSG_DUEL_COMPLETE, tempBuff, offset );
			Duel = gu.Duel = 0;
			guowner = null;
			gu.guowner = null;
			gu.gu = null;
			gu = null;
			dt = null;			
		}
		public Character gu;
		public void Deturn()
		{
			byte []buff = new byte[ 24 ];
			int offset = 4;
			gu.gu = this;
			Duel = Object.GUID++;
			gu.Duel = Duel;
			Converter.ToBytes( Duel, buff, ref offset );
			Converter.ToBytes( Guid, buff, ref offset );
			( gu as Character ).Send( (OpCodes)0x0167, buff, offset );
			Send( (OpCodes)0x0167, buff, offset );
		}

		public void MakeThePacket( UInt64 g, Character with, Character from )
		{
byte []buff = new byte[]{
		0x03, 0x00, 0x00, 0x00, 0x00, 0x02, 0x1F, 0x68, 0x29, 0x00, 0x00, 0x10, 0x00, 0xF0, 0x05, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3E, 0x54, 0x0B,	0xC6, 0x04, 0x71, 0xDE, 0xC2, 0x1D, 
		0x3D, 0xA5, 0x42, 0xBC, 0x69, 0x99, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x66, 0xD1, 0x08, 0x00, 0x68, 0x09, 0x43, 0x35, 0x00, 0x10, 0x00, 0xF0, 0x1C, 0x64, 0x5E,	0x62, 0x38, 0xC3, 0x14, 0x08, 0x01, 
		0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x9C, 0x64, 0x5E, 0x62, 0x7C, 0xA1, 0x14, 0x08, 0x01, 0x00, 0x00, 0x00, 0x01, 0x5F, 0x71,	0xEF, 0x00, 0x1F, 0x68, 0x29, 0x00, 
		0x00, 0x10, 0x00, 0xF0, 0x21, 0x00, 0x00, 0x00, 0xB0, 0x54, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F, 0x65, 0x77, 0xE4, 0x00, 0x13, 0x03, 0x00, 0x00, 0xE5, 0x64,	0x10, 0x3F, 0x35, 0x64, 0x53, 0x3F, 
		0x01, 0x00, 0x00, 0x00, 0x3E, 0x54, 0x0B, 0xC6, 0x04, 0x71, 0xDE, 0xC2, 0x1D, 0x3D, 0xA5, 0x42, 0xBC, 0x69, 0x99, 0x3F, 0x01, 0x00, 0x00, 0x00, 0x10, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 
		0x00, 0x65, 0x77, 0xE4, 0x00, 0x00, 0x00, 0x00, 0x00, 0x24, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
		0x0C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
		0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
		0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
		0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,	0x1F, 0x68, 0x29, 0x00, 0x00, 0x10, 
		0x00, 0xF0, 0x00, 0x36, 0xB7, 0xE3, 0x00, 0x00, 0x00, 0x00, 0x00, 0x24, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
		0x00, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
		0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
		0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,	0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
		0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,	0x00, 0x00, 0x1F, 0x68, 0x29, 0x00, 0x00, 0x10, 0x00, 0xF0
			};

					
			int t = 6;
			Converter.ToBytes( g, buff, ref t );
			t = 92;
			Converter.ToBytes( g, buff, ref t );
			t = 112;
			Converter.ToBytes( (uint)( from.Guid & 0xffffffff ), buff, ref t );
			t = 161;
			Converter.ToBytes( with.Guid, buff, ref t );
			t = 0x13a;
			Converter.ToBytes( g, buff, ref t );
			t++;
			Converter.ToBytes( Guid, buff, ref t );
			t = buff.Length - 8;
			Converter.ToBytes( g, buff, ref t );
			t = 23;
			Converter.ToBytes( X + 1, buff, ref t );
			Converter.ToBytes( Y + 1, buff, ref t );
			Converter.ToBytes( Z, buff, ref t );


			byte []res = Zip.Compress( buff, 0, buff.Length );
			byte []data = new byte[ res.Length + 8 ];
			int offset = 4;	
			Buffer.BlockCopy( res, 0, data, 8, res.Length );			
			Converter.ToBytes( buff.Length, data, ref offset );
			account.Handler.Send( 0x1F6, data, res.Length + 6 );
		}

		public static void OnCastInvisibility( BaseAbility ba, Mobile c, Mobile m )
		{
		
		}
		void ImportSpawner()
		{
			TextReader tr = new StreamReader( "./exportspawners.csv" );
			while( true )
			{
				string str = tr.ReadLine();
				if ( str == null )
					break;
				string []strs = str.Split( new char[] { ';' } );
				int _id = Convert.ToInt32( strs[ 0 ] );
				if ( _id != 0 )
					_id = 9999999 - _id;
				ushort _mapId = Convert.ToUInt16( strs[ 1 ] );
				float _x = Convert.ToSingle( strs[ 2 ] );
				float _y = Convert.ToSingle( strs[ 3 ] );
				float _z = Convert.ToSingle( strs[ 4 ] );
				float _orientation = Convert.ToSingle( strs[ 5 ] );
				int _ZoneId = Convert.ToInt32( strs[ 6 ] );
				int _Model = Convert.ToInt32( strs[ 7 ] );				
				int _Frequency = Convert.ToInt32( strs[ 8 ] );
				int _Amount = Convert.ToInt32( strs[ 9 ] );
				float _rx = Convert.ToSingle( strs[ 10 ] );
				float _ry = Convert.ToSingle( strs[ 11 ] );
				float _rz = Convert.ToSingle( strs[ 12 ] );
				float _f = Convert.ToSingle( strs[ 13 ] );
				UInt64 _guid = Convert.ToUInt64( strs[ 14 ] );
				int _type = Convert.ToInt32( strs[ 15 ] );
				if ( _type == 0 )
				{
					MobileSpawner bs = new MobileSpawner();
					bs.Id = _id;
					bs.X = _x;
					bs.Y = _y;
					bs.Z = _z;
					bs.MapId = _mapId;
					bs.Orientation = _orientation;
					bs.Amount = _Amount;
					bs.Frequency = _Frequency;
					bs.Model = _Model;
					bs.RealX = _rx;
					bs.RealY = _ry;
					bs.RealZ = _rz;
					bs.TrajetGuid = _guid;
					World.allSpawners.Add( bs );
				}
				else
				{
					GameObjectSpawner bs = new GameObjectSpawner();
					bs.Id = _id;
					bs.X = _x;
					bs.Y = _y;
					bs.Z = _z;
					bs.MapId = _mapId;
					bs.Orientation = _orientation;
					bs.Frequency = _Frequency;
					bs.Model = _Model;
					bs.Facing = _f;
					bs.RotationX = _rx;
					bs.RotationY = _ry;
					bs.RotationZ = _rz;
					World.allSpawners.Add( bs );
				}
			}
			tr.Close();
		}
		void ExportSpawner()
		{
			TextWriter tw = new StreamWriter( "./exportspawners.csv" );
			foreach( BaseSpawner bs in World.allSpawners )
			{
				string str = "";
				if ( bs.Id > 0 )
				{			
					str += ( 99999999 - bs.Id ).ToString() + ";";
				}
				else
					str += bs.Id.ToString() + ";";
				str += 
					bs.MapId.ToString() + ";" +
					bs.X.ToString() + ";" +
					bs.Y.ToString() + ";" + 
					bs.Z.ToString() + ";" +
					bs.Orientation.ToString() + ";" +
					bs.ZoneId.ToString() + ";" +
					bs.Model.ToString() + ";" +					
					bs.Frequency.ToString() + ";";
				if ( bs is MobileSpawner )
				{
					MobileSpawner ms = (MobileSpawner)bs;
					str += ms.Amount.ToString() + ";" +
						ms.RealX.ToString() + ";" +
						ms.RealY.ToString() + ";" +
						ms.RealZ.ToString() + ";" +
						"0;" + // facing
						ms.TrajetGuid.ToString() + ";";
				}
				else
				{
					GameObjectSpawner gos = (GameObjectSpawner)bs;
					str += "0;" +//	amount						
						gos.RotationX.ToString() + ";" +
						gos.RotationY.ToString() + ";" +
						gos.RotationZ.ToString() + ";" +
						gos.Facing.ToString() + ";" +
						"0;";// guid
				}
				tw.WriteLine( str );
			}
			tw.Close();
			
			foreach( Trajet trajet in World.trajets )
			{
				tw = new StreamWriter( "./exports/path" + trajet.Guid.ToString() + ".csv" );
				int t = 0;
				foreach( Coord c in trajet )
				{
					string str = t.ToString()+ ";" + c.x.ToString() + ";" + c.y.ToString() + ";" + c.z.ToString() + ";";
					if ( c is Intersection )
					{
						int p = 0;
						int n = 0;
						c.previous.TrajetNum( ref p, ref n );
						str += World.trajets[ p ].Guid.ToString() + ";" + n.ToString() + ";";
						c.next.TrajetNum( ref p, ref n );
						str += World.trajets[ p ].Guid.ToString() + ";" + n.ToString() + ";";
					}
					tw.WriteLine( str );
				}
				tw.Close();
			}
		}
		public Character guowner;
		void PrepareInv( byte []data, int off )
		{
			if ( guowner != null )
			{
				SendMessage( "You have already requested a duel !" );
				return;
			}
			UInt64 g = BitConverter.ToUInt64( data, off + 12 );
			gu = (Character)this.Player.FindMobileByGuid( g );
			if ( gu.guowner != null )
			{
				SendMessage( "The target have already requested a duel !" );
				return;
			}
			guowner = this;
			gu.guowner = this;
			Deturn();
			return;
		}

		static AuraEffect gmInvisibilityAura = new GMInvisibilityAura();
		//TestTimer testTimer;
		GameObject startTrajetFlag = null;
		uint ff = 1;


		void OnCommand( string cmd )
		{
			if ( Player.AccessLevel == AccessLevels.PlayerLevel )
			{
				string lower = cmd.ToLower();
				if ( lower.StartsWith( ".help" ) )
				{
					SendMessage( "Command lists" );
					SendMessage( ".whois" );
					SendMessage( ".mount" );
					SendMessage( ".unmount" );
				}
				else
					if ( lower.StartsWith( ".whois" ) )
				{					
					foreach( Account a in World.allConnectedAccounts )
					{
						if ( a.SelectedChar != null )
							SendMessage( a.SelectedChar.Name + " is online at ( " + a.SelectedChar.X.ToString() + "; " + a.SelectedChar.Y.ToString() + "; "+ a.SelectedChar.Z.ToString() + ") " );
					}
					SendMessage( "User online : " + World.allConnectedAccounts.Count.ToString() );
				}
				else
					if ( lower.StartsWith( ".mount" ) )
				{
					if ( selection != null && selection is Mobile )
					{
						if ( World.MountsList[ ( selection as Mobile ).Id ] != null )
							Mount( selection as Mobile );
					}
				}
				else
					if ( lower.StartsWith( ".unmount" ) )
				{
					if ( this.MountModel != 0 )
						UnMount();
				}				
			}
			else			
			if ( Player.AccessLevel == AccessLevels.Admin )
			{
				string lower = cmd.ToLower();
				if ( lower.StartsWith( ".importspawner" ) )
				{
					ImportSpawner();
				}
				else
					if ( lower.StartsWith( ".exportspawner" ) )
				{
					ExportSpawner();
				}
				else
					if ( lower.StartsWith( ".import" ) )
				{
					ImportWad();
				}
				else
					if ( lower.StartsWith( ".help" ) )
				{
					SendMessage( "Command lists" );
					SendMessage( ".help" );
					SendMessage( ".Addnpc [MobName|MobId] [amount] [faction]" );
					SendMessage( ".AddItem ItemName [amount]" );
					SendMessage( ".Addgo GameObjectNumber" );
					SendMessage( ".AddSpawner [MobName|MobId] amount frequency" );
					SendMessage( ".AddGoSpawner GameObjectId frequency [classname]" );
					SendMessage( ".kill" );
					SendMessage( ".nuke" );
					SendMessage( ".info" );
					SendMessage( ".where" );
					SendMessage( ".remove" );
					SendMessage( ".set xp Amount" );
					SendMessage( ".set faction FactionNumber" );
					SendMessage( ".set godmode [on/off]" );
					SendMessage( ".set turbo [on/off]" );
					SendMessage( ".password NewPassword" );
					SendMessage( ".grant [account|selected char] AccessLevel" );
					SendMessage( ".go LocationName | [ X Y Z MapId ]" );
					SendMessage( ".addlocation LocationName" );
					SendMessage( ".restart XMinutes" );
					SendMessage( ".whois" );
					SendMessage( ".broadcast Message" );
					SendMessage( ".hide" );
					SendMessage( ".unhide" );
					SendMessage( ".docgen" );
					SendMessage( ".removego" );
					SendMessage( ".armagedon" );
					SendMessage( ".mount" );
					SendMessage( ".unmount" );
				}
				else
					if ( lower.StartsWith( ".mount" ) )
				{
					if ( selection != null && selection is Mobile )
					{
						if ( World.MountsList[ ( selection as Mobile ).Id ] != null )
							Mount( selection as Mobile );

					}
				}
				else
					if ( lower.StartsWith( ".test" ) )
				{
					string []tt = cmd.Split( new char[]{ ' ' } );
					if ( tt.Length != 3 )
					{
						SendMessage( "Usage : .test MobName1 MobName2" );
						return;
					}
					if ( testCombatStarted )
					{
						SendMessage( "A fight test is not finished yet !!" );
						return;
					}
					//tt[ 1 ] = "SilverwingWarrior";
					//tt[ 2 ] = "RazorHillGrunt";
					ConstructorInfo ct1 = Utility.FindConstructor( tt[ 1 ] , Utility.externAsm[ "creatures" ] );
					ConstructorInfo ct2 = Utility.FindConstructor( tt[ 2 ] , Utility.externAsm[ "creatures" ] );
					
					testCombatStarted = true;
					
					for(int t = 0;t < 50;t++ )
					{
						BaseCreature bc = (BaseCreature)ct1.Invoke( null );	
						bc.Faction = Factions.Alliance;
						World.Add( bc, -13210f + (float)( Utility.Random( 50 ) - 25 ), 267.6f+ (float)( Utility.Random( 50 ) - 25 ), 22f, 0 );
						team1.Add( bc );
						bc = (BaseCreature)ct2.Invoke( null );	
						bc.Faction = Factions.Horde;
						World.Add( bc, -13210f + (float)( Utility.Random( 50 ) - 25 ), 287.6f+ (float)( Utility.Random( 50 ) - 25 ), 22f, 0 );
						team2.Add( bc );
					}
					MobBalance mb = new MobBalance( this );

					
				}
				else
					if ( lower.StartsWith( ".." ) )
				{
					string []ss = lower.Split( new char[] { ' ' } );
					ff = (uint)Convert.ToInt32( ss[ 1 ] );
					SendMessage("num = " + ff.ToString("X8" ));
					/*	if ( selection is Mobile )
							( selection as Mobile ).SendSmallUpdateToPlayerNearMe( new int[] { (int)UpdateFields.UNIT_DYNAMIC_FLAGS }, new object[] { ff } );
					*/
					SendSmallUpdate( new int[]{ (int)UpdateFields.UNIT_FIELD_FACTIONTEMPLATE }, new object[]{ ff } );				
				}
				else
					if ( lower.StartsWith( ".close" ) )
				{
					MainConsole.StopAllThread();
				}
				else
					if ( lower.StartsWith( ".mars" ) )
				{/*
					

					Hashtable hy = null;
					hy = World.mapZones.GetZoneHash( MapId, ZoneId, X, Y );//(Hashtable)World.mapZones.Azeroth[  MapId * 1024 + ZoneId ];
					for(float x = X - 16;x < X + 16;x+=MapZones.UNITSIZE )
					{
						for(float y = Y - 16;y < Y + 16;y++ )
						{
							int coordy = (int)( y / ( MapZones.UNITSIZE * 0.5f ) );
							int coordx = (int)( x / MapZones.UNITSIZE );
							bool decal = false;;
							if ( (int)( coordy & 1  ) == 1 )
							{
								decal = true;
								coordx -= (int)( MapZones.UNITSIZE * 0.5f );							
							}
							uint cx = (uint)( coordx + 0x8000 );
							uint cy = (uint)( coordy + 0x8000 );
							object o = hy[ (uint)( ( coordx << 16 ) + coordy ) ];
							if ( o != null )
							{
								float xx = (float)coordx * ( MapZones.UNITSIZE );
								float yy = (float)coordy * MapZones.UNITSIZE * 0.5f;
								if ( decal )
								{
									xx += MapZones.UNITSIZE * 0.5f;
								}
								GameObject go = World.Add( 621682, xx, yy, (float)o, MapId );
								World.allSpawners[ linkedSpawner ].Bind( go );								
							}
						}
					}
					account.RefreshMobileList( true );*/


					MapPoint mp = World.mapZones.NearestPoint( null, MapId, ZoneId, X, Y );
					SendMessage( "X=" + mp.x.ToString() + " Y=" + mp.y.ToString() );
					GameObject go = World.Add( 621682, mp.x , mp.y, mp.z, 0, MapId );
					World.allSpawners[ linkedSpawner ].Bind( go );	
					account.RefreshMobileList( true );
					//MainConsole.StopAllThread();
					//	Mobile.GetDirection( this, selection as Mobile );
					//		return;
					//	p.Kill();
					//for(float xxa = X - 10;xxa < 
					//string []ss = lower.Split( new char[] { ' ' } );
					//uint xff = (uint)Convert.ToUInt32( ss[ 1 ] );

					//	Items[ 24 ].SendSmallUpdate( new int[]{ (int)UpdateFields.ITEM_FIELD_FLAGS }, new object[]{ xff }, this );				
					
					/*
				Converter.ToBytes( cast.id, tempBuff, ref offset );
				Converter.ToBytes( (byte)1, tempBuff, ref offset );
				ToAllPlayerNear( OpCodes.SMSG_CAST_RESULT, tempBuff, offset );
				offset = 4;*/
					/*Converter.ToBytes( 6, tempBuff, ref offset );
					Converter.ToBytes( (byte)2, tempBuff, ref offset );
					Converter.ToBytes( (byte)xff, tempBuff, ref offset );
					Converter.ToBytes( msg, tempBuff, ref offset );
					ToAllPlayerNear( OpCodes.SMSG_CAST_RESULT, tempBuff, offset );*/
					cast.id = 8613;
					cast.type = 2;
					
					//SpellFaillure( ( SpellFailedReason )xff );
					/*		int ff2 = (int)Convert.ToInt32( ss[ 2 ] );
							SendMessage("num = " + xff.ToString("X8" ));
					
							int offset = 4;
							Converter.ToBytes( 1, tempBuff, ref offset );
							Converter.ToBytes( xff, tempBuff, ref offset );
							Converter.ToBytes( ff2, tempBuff, ref offset );
							if ( selection is Mobile )
								this.Send( OpCodes.SMSG_SET_FACTION_STANDING, tempBuff, offset );
						*/		
					//	ReputationAdjustments[ World.FactionAssociated[ Factions.Stormwind ] ] = (int)xff;
					//	this.Player.RefreshFactionReactions();
					//	( selection as Mobile ).SendSmallUpdateToPlayerNearMe( new int[] { (int)UpdateFields.UNIT_FIELD_FLAGS }, new object[] { ff } );
					
				}
				else
					if ( lower.StartsWith( ".mare" ) )
				{
					/*	if ( selection ==null )
							return;
						string []ss = lower.Split( new char[] { ' ' } );
						int ff1 = Convert.ToInt32( ss[ 1 ] );
				//		int ff2 = Convert.ToInt32( ss[ 2 ] );
						SendMessage("num = " + ff1.ToString("X8" ));
						int offset = 4;
						Converter.ToBytes( selection.Guid, tempBuff, ref offset );
						Converter.ToBytes( ff1, tempBuff, ref offset );
						this.Send( OpCodes.SMSG_AI_REACTION, tempBuff, offset );
						return;*/
					/*	if ( selection is Mobile )
							( selection as Mobile ).SendSmallUpdateToPlayerNearMe( new int[] { (int)UpdateFields.PLAYER_FLAGS }, new object[] { ff } );
					*/
					/*	for(int z = 0;z < 32;z++ )
							zones[ z ] = 0;
						for(int z = 0; z < 32 * 32;z++)
						{
							if ( z >= ff1 && z < ff2 )
							{
								int e = z % 32;
								int n = ( z / 32 );
								zones[ n ] |= (uint)( 1 << ( e ) );
							}
						}
						for(int z = 0;z < 32;z++ )
						{
							this.SendSmallUpdate( new int[] { (int)UpdateFields.PLAYER_EXPLORED_ZONES_1 + z }, new object[] { zones[ z ] } );	
						}*/
				}
				else
					if ( lower.StartsWith( ".marb" ) )
				{
					string []ss = lower.Split( new char[] { ' ' } );
					ff = (uint)Convert.ToInt32( ss[ 1 ] );
					SendMessage("num = " + ff.ToString("X8" ));
					if ( selection is Mobile )
						( selection as Mobile ).SendSmallUpdateToPlayerNearMe( new int[] { (int)UpdateFields.PLAYER_FIELD_BYTES }, new object[] { ff } );
					
				}
				else
					if ( lower.StartsWith( ".marf" ) )
				{
					string []ss = lower.Split( new char[] { ' ' } );
					ff = (uint)Convert.ToInt32( ss[ 1 ] );
					SendMessage("num = " + ff.ToString("X8" ));
					if ( selection is Mobile )
						( selection as Mobile ).SendSmallUpdateToPlayerNearMe( new int[] { (int)UpdateFields.UNIT_NPC_FLAGS }, new object[] { ff } );
					
				}
					/*else
					if ( lower.StartsWith( ".s" ) )
					{
						string []ss = lower.Split( new char[] { ' ' } );
						SpellFaillure( (Server.SpellFailedReason)Convert.ToInt32( ss[ 1 ] ) );
					}*/
					/*	else
								if ( lower.StartsWith( ".s" ) )
							{
								string []ss = lower.Split( new char[] { ' ' } );
								if ( ss.Length > 1 )
									ff |= (uint)( 1 << Convert.ToInt32( ss[ 1 ] ) );
								if ( selection is Character )
									( selection as Character ).SendSmallUpdateToPlayerNearMe( new int[] { (int)UpdateFields.UNIT_FIELD_FLAGS }, new object[] { ff } );
								else
									( selection as Mobile ).SendSmallUpdateToPlayerNearMe( new int[] { (int)UpdateFields.UNIT_FIELD_FLAGS }, new object[] { ff } );
								Console.WriteLine("rage = {0}", ff.ToString("X8" ));
							}	
							else
							if ( lower.StartsWith( ".u" ) )
							{
								string []ss = lower.Split( new char[] { ' ' } );
								if ( ss.Length > 1 )
									ff &= (uint)0xffffffff ^ (uint)( 1 << Convert.ToInt32( ss[ 1 ] ) );
								if ( selection is Character )
									( selection as Character ).SendSmallUpdateToPlayerNearMe( new int[] { (int)UpdateFields.UNIT_FIELD_FLAGS }, new object[] { ff } );
								else
									( selection as Mobile ).SendSmallUpdateToPlayerNearMe( new int[] { (int)UpdateFields.UNIT_FIELD_FLAGS }, new object[] { ff } );
					
								Console.WriteLine("rage = {0}", ff.ToString("X8" ));
							}		*/				
					
				else
					if ( lower.StartsWith( ".unmount" ) )
				{
					if ( this.MountModel != 0 )
						UnMount();
				}	
				else
					if ( lower.StartsWith( ".set faction" ) )
				{
					string []tt = cmd.Split( new char[]{ ' ' } );
					if ( selection is Mobile )
					{
						if ( tt.Length == 3 )
						{
							int fac = Convert.ToInt32( tt[ 2 ] );
							( selection as Mobile ).SendSmallUpdateToPlayerNearMe( new int[]{ (int)UpdateFields.UNIT_FIELD_FACTIONTEMPLATE }, new object[]{ (int)fac } );
						}
						else
							SendMessage("Usage : .set faction FACTION_NUMBER" );
					}
					else
						SendMessage("You must select a mobile first !" );

				}	
					
				else
					if ( lower.StartsWith( ".removego" ) )
				{					
					Object nearest = null;
					float nearestdist = float.MaxValue;
					foreach( Object o in World.allGameObjects )
					{
						float dist = Distance( o );
						if ( dist < nearestdist )
						{
							nearestdist = dist;
							nearest = o;
						}
					}
					if ( nearest != null )
						World.Remove( nearest, this );
				}
				else
					if ( lower.StartsWith( ".docgen" ) )
				{		
					SendMessage("Documentation is being generated, please wait.");
					Console.WriteLine( "Documentation is being generated, please wait." );
					DateTime startTime = DateTime.Now;
					Docs.Document();
					DateTime endTime = DateTime.Now;
					Console.WriteLine("Documentation has been completed. The entire process took {0:F1} seconds.", (endTime - startTime).TotalSeconds );
					SendMessage("Documentation has been completed. The entire process took " + (endTime - startTime).TotalSeconds.ToString( "F1" ) + " seconds." );
					return;
				}
				else
					if ( lower == ".hide" )
				{					
					this.Visible = InvisibilityLevel.GM;
					AuraEffect st = gmInvisibilityAura;
					Aura aura = new Aura();
					aura.OnRelease = new Aura.AuraReleaseDelegate( OnGMInvisibilityEnded );
					AddAura( st, aura );
				}
				else
					if ( lower.StartsWith( ".unhide" ) )
				{					
					this.Visible = InvisibilityLevel.Visible;
					this.ReleaseAura( gmInvisibilityAura );
				}
				else
					if ( lower.StartsWith( ".whois" ) )
				{					
					foreach( Account a in World.allConnectedAccounts )
					{
						if ( a.SelectedChar != null )
							SendMessage( a.Username.ToString() + " : " + a.SelectedChar.Name + " is online at ( " + a.SelectedChar.X.ToString() + "; " + a.SelectedChar.Y.ToString() + "; "+ a.SelectedChar.Z.ToString() + ") " );
						else
							SendMessage( a.Username.ToString() + " : [loggout]" );
					}
					SendMessage( "User online : " + World.allConnectedAccounts.Count.ToString() );
				}
				else
					if ( lower.StartsWith( ".broadcast " ) )
				{
					string tt = cmd.Remove( 0, 11 );
					foreach( Account a in World.allConnectedAccounts )
					{
						if ( a.SelectedChar != null )
							SendMessage( a.Username.ToString() + ", " + tt );
					}						
				}
				else
					if ( lower.StartsWith( ".restart " ) )
				{
					string []tt = cmd.Split( new char[]{ ' ' } );
					if ( tt.Length == 2 )
					{
						World.Restart( Convert.ToInt32( tt[ 1 ] ) );
					}
					else
						SendMessage( "Usage : .restart minutes" );
				}
				else
					if ( lower.StartsWith( ".addlocation " ) )
				{
					string []tt = cmd.Split( new char[]{ ' ' } );
					if ( tt.Length == 2 )
					{
						TextReader tr = new StreamReader( "./scripts/Globals/Locations.cs" );
						string txt = tr.ReadToEnd();
						tr.Close();
						TextWriter tw = new StreamWriter( "./scripts/Globals/Locations.cs" );
						int i = txt.IndexOf( "#region Locations" );
						string ne = "\t\t\tWorld.Locations[ \"" + tt[ 1 ] + "\" ] = new Position( " + X.ToString() + "f, " + Y.ToString() + "f, " + Z.ToString() + "f, 0 );" + tw.NewLine;
						tw.Write( txt.Substring( 0, i + "#region Locations".Length ) );
						tw.Write( tw.NewLine + ne );
						tw.Write( txt.Substring( i + "#region Locations".Length ) );
						//	txt.Insert( i + "#region Locations".Length + 2, ne );
						//	tw.Write( txt );
						tw.Close();
						SendMessage( "Done : " + ne );
					}
					else
						SendMessage( "Usage : .addlocation LocationName" );
				}
				else
					if ( lower.StartsWith( ".zone" ) )
				{
					string []tt = cmd.Split( new char[]{ ' ' } );
					this.ZoneUpdateRequested( Convert.ToInt32( tt[ 1 ] ) );
				}
				else
					if ( lower.StartsWith( ".grant " ) )
				{
					string acclevel = lower.Remove( 0, 7 );
					string []tt = acclevel.Split( new char[]{ ' ' } );
					Account acc = null;
					if ( tt.Length == 1 )
					{
						if ( selection is Character )
						{
							acclevel = tt[ 0 ];
							acc = ( selection as Character ).Player;
						}
						else
						{
							SendMessage( "Can only be used on character" );
							return;
						}
					}
					else
					{
						if ( tt.Length > 2 || tt.Length == 0 )
						{
							SendMessage( "Usage : .grant [Account] AccessLevel" );
							return;
						}
						acclevel = tt[ 1 ];
						acc = World.allAccounts.FindByUserName( tt[ 0 ].ToUpper() );
						if ( acc == null )
						{
							SendMessage( tt[ 0 ] + " account not found !" );
							return;
						}
					}
					if ( acclevel == "admin" )
					{
						SendMessage( "The account " + acc.Username + " is now an administrator" );
						acc.AccessLevel = AccessLevels.Admin;
					}
					else
						if ( acclevel == "gm" )
					{
						SendMessage( "The account " + acc.Username + " is now a game master" );
						acc.AccessLevel = AccessLevels.GM;
					}
					else
						if ( acclevel == "player" )
					{
						SendMessage( "The account " + acc.Username + " have now player access level" );
						acc.AccessLevel = AccessLevels.PlayerLevel;
					}
					else
						SendMessage( acclevel + " is not a valid access level !" );					
				}
				else
					if ( lower.StartsWith( ".password " ) )
				{
					string []tt = cmd.Split( new char[]{ ' ' } );
					if ( tt.Length < 2 )
					{
						SendMessage( "Usage : .password NewPassword" );
						return;
					}
					Player.Password = tt[ 1 ];
					SendMessage( "Your new password is : " + tt[ 1 ] );
					SendMessage( "Don't forget it !" );
				}
				else
					if ( lower.StartsWith( ".info" ) )
				{
					if ( selection != null )
					{
						string ret = "";
						if ( selection is BaseSpawner )
						{
							( selection as BaseSpawner ).DisplayInfo( this );
							//		ret += "Spawner for " + ( selection as BaseSpawner ).Name;
							//		SendMessage( ret );
							return;
						}
						else
							if ( selection is Character )
							ret += "Player : ";
						else
							if ( ( selection as Mobile ).SummonedBy != null )
							ret += "Summoned creature : ";
						else							
							ret += "Creature : ";
						Mobile mob = ( selection as Mobile );
						ret += mob.Name + " Faction : " + mob.Faction.ToString();
						SendMessage( ret );
						ret = "Pos : " + mob.X.ToString() + ", " + mob.Y.ToString() + ", " + selection.Z.ToString() + ", " + selection.MapId.ToString();
						SendMessage( ret );
						ret = "HitPoints : " + mob.HitPoints.ToString() + " / " + mob.BaseHitPoints.ToString();
						SendMessage( ret );
						ret = "Mana : " + mob.Mana.ToString() + " / " + mob.BaseMana.ToString();
						SendMessage( ret );
						ret = "Level : " + mob.Level.ToString() + " / " + mob.Exp.ToString() + " Xp";
						SendMessage( ret );
					}
					else
						SendMessage( "You must select a mobile before" );
				}
				else
					if ( lower.StartsWith( ".kill" ) )
				{
					if ( selection != null && selection is Mobile )
					{
						( selection as Mobile ).LooseHits( this, ( selection as Mobile ).HitPoints, true );
					}
				}
				else
					if ( lower.StartsWith( ".addgospawner" ) )
				{
					GameObjectSpawner bc = null;
					string []tt = cmd.Split( new char[]{ ' ' } );
					if ( tt.Length == 3 )
					{
						
						try
						{
							if ( Utility.FindConstructor( tt[ 1 ] ) != null )
							{
								ConstructorInfo cttest = Utility.FindConstructor( tt[ 1 ] );
								GameObject go = (GameObject)cttest.Invoke( null );
								if ( go.DefaultModel == 0 )
								{
									SendMessage( "This class does not implement the DefaultModel property !" );
									return;
								}
								bc = new GameObjectSpawner();
								bc.Init( tt[ 1 ], Convert.ToInt32( tt[ 2 ] ) );
								World.Add( bc, X, Y, Z, MapId );
							}
							else
							{
								bc = new GameObjectSpawner();
								int id = Convert.ToInt32( tt[ 1 ] );
								bc.Init( id, Convert.ToInt32( tt[ 2 ] ) );
								World.Add( bc, X, Y, Z, MapId );
							}



						}
						catch( Exception )
						{
						}
					}
					else
						if ( tt.Length == 4 )
					{
						try
						{
							bc = new GameObjectSpawner();
							int id = Convert.ToInt32( tt[ 1 ] );
							bc.Init( id, Convert.ToInt32( tt[ 2 ] ), tt[ 3 ] );
							World.Add( bc, X, Y, Z, MapId );
						}
						catch( Exception )
						{
						}
					}
					else
						SendMessage( "usage : .addgospawner gameobjectname frequency [gameobjectclass]" );
					if ( bc != null )//	Ajoute le spawner dans la liste des autres spawnpoints
					{
						if ( this.linkedSpawner == -1 )//	No spawner near the player
						{
								
						}
						else
						{
							int num = World.allSpawners.Count - 1;
							ArrayList al = new ArrayList();
							World.regSpawners[ num ] = al;
							for(int t = 0;t < num;t++ )
							{
								BaseSpawner bs2 = World.allSpawners[ t ] as BaseSpawner;
								if ( bc.MapId != bs2.MapId )
									continue;
								if ( bc.QuickDistance( bs2 ) < 150 * 150 )
									al.Add( t );
							}
								
							foreach( int i in al )
							{
								( World.regSpawners[ i ] as ArrayList ).Add( num );
							}
						}
					}
				}
				else
					if ( lower.StartsWith( ".armagedon" ) )
				{
					MobileList newMobs = new MobileList();
					int n = 0;
					foreach( Mobile m in World.allMobiles )
						if ( m is Character )
						{
							newMobs.Add( m );
						}
						else
							n++;
					n += World.allSpawners.Count;
					LinkedSpawner = -1;
					World.allSpawners.Clear();
					World.allMobiles = newMobs;
					Player.RefreshMobileList( true );
					SendMessage( n.ToString() + " mobs/spawners removed !" );
				}					
				else
					if ( lower.StartsWith( ".nuke" ) )
				{
					MobileList newMobs = new MobileList();
					int n = 0;
					foreach( Mobile m in World.allMobiles )
						if ( m is Character )//|| m is BaseSpawner )
						{
							newMobs.Add( m );
						}
						else
							n++;

					World.allSpawners.Clear();
					World.allMobiles = newMobs;
					SendMessage( n.ToString() + " mobs removed !" );
					
				}
				else
					if ( lower.StartsWith( ".set godmode on" ) )
				{
					if ( selection != null && selection is Mobile )
					{
						( selection as Mobile ).GodMode = true;
					}
					else
						GodMode = true;
				}
				else
					if ( lower.StartsWith( ".set godmode off" ) )
				{
					if ( selection != null && selection is Mobile )
					{
						( selection as Mobile ).GodMode = false;
					}
					else
						GodMode = false;
				}
				else
					if ( lower.StartsWith( ".set turbo on" ) )
				{
					RunSpeed = 40f;
					this.ChangeRunSpeed( 40f );
				}
				else
					if ( lower.StartsWith( ".set turbo off" ) )
				{
					RunSpeed = 7f;
					this.ChangeRunSpeed( 7f );
					/*
						int offset = 4;
						Converter.ToBytes( 1, tempBuff, ref offset );
						Converter.ToBytes( (byte)0, tempBuff, ref offset );
						WalkSpeed = 4.777f;
						RunSpeed = 7f;
						this.PrepareUpdateData( tempBuff, ref offset , UpdateType.UpdateFull, false );
						this.Send( OpCodes.SMSG_UPDATE_OBJECT, tempBuff, offset );*/
				}
				else
					if ( lower.StartsWith( ".guid" ) )
				{
					if ( selection == null )
						SendMessage( "Guid : " + Guid.ToString( "X16" ) );
					else
						SendMessage( "Guid : " + selection.Guid.ToString( "X16" ) );
						
				}
				else
					if ( lower.StartsWith( ".addspawner" ) )
				{
					string []tt = cmd.Split( new char[]{ ' ' } );
					if ( tt.Length == 4 )
					{
						ConstructorInfo ct = null;
						try
						{
							MobileSpawner bc = new MobileSpawner();

							try
							{
								int mid = (int)Convert.ToInt32( tt[ 1 ] );
								ct = World.MobilePool( mid );
							}
							catch(Exception)
							{
								ct = Utility.FindConstructor( tt[ 1 ], Utility.externAsm[ "creatures" ] );
								if ( ct == null )
									ct = Utility.FindConstructor( tt[ 1 ] );
							}

							BaseCreature b = (BaseCreature)ct.Invoke( null );
							float rec = float.MaxValue;
							foreach( BaseSpawner bs in World.allSpawners )
							{
								float xx = X - bs.X;
								float yy = Y - bs.Y;
								xx *= xx;
								yy *= yy;
								xx += xx;
								if ( xx < rec && bs.MapId == MapId )
								{
									rec = xx;
									bc.ZoneId = bs.ZoneId;
									bc.MapId = bs.MapId;
								}
							}
							//MapPoint mp = World.mapZones.NearestPoint( bc.MapId, bc.ZoneId, X, Y );
							bc.RealX = X;
							bc.RealY = Y;
							bc.RealZ = Z;
							bc.Model = b.Model;
							bc.Id = 99999999 - b.Id;
							bc.Orientation = Orientation;							
							bc.Init( ct, b.Id, Convert.ToInt32( tt[ 3 ] ), Convert.ToInt32( tt[ 2 ] ) );
							World.Add( bc, X, Y, Z, MapId );
							if ( this.linkedSpawner == -1 )//	No spawner near the player
							{
								
							}
							else
							{
								int num = World.allSpawners.Count - 1;
								ArrayList al = new ArrayList();
								World.regSpawners[ num ] = al;
								for(int t = 0;t < num;t++ )
								{
									BaseSpawner bs2 = World.allSpawners[ t ] as BaseSpawner;
									if ( bc.MapId != bs2.MapId )
										continue;
									if ( bc.QuickDistance( bs2 ) < 150 * 150 )
										al.Add( t );
								}
								
								foreach( int i in al )
								{
									( World.regSpawners[ i ] as ArrayList ).Add( num );
								}
							}

							bc.ForceRespawn();
							Player.RefreshMobileList( true );
						}
						catch( Exception )
						{
						}
					}
					else
						SendMessage( "usage : .addspawner mobname amount frequency" );
				}
				else
					if ( lower.StartsWith( ".set xp" ) )
				{
					string []tt = cmd.Split( new char[]{ ' ' } );
					if ( tt.Length == 3 )
					{
						Character c = selection as Character;
						if ( c == null )
							c = this;
						try 
						{
							uint a = Convert.ToUInt32( tt[ 2 ] ) - c.Exp;
							c.EarnXP( (int)a );
						}
						catch( Exception )
						{
							this.SendMessage( "usage : .set xp amount" );
						}
					}
				}
				else
					if ( lower.StartsWith( ".debug" ) )
				{
					if ( selection != null )
					{
						if ( selection is BaseCreature )
						{
							BaseCreature bc = selection as BaseCreature;
							if ( bc.DebugSniffer != null )
							{
								bc.DebugSniffer = null;
								SendMessage( "Debug Off" );
								return;
							}
							else
							{
								bc.DebugSniffer = this;
								SendMessage( "Debug On" );
							}
						}
					}
				}
					#region TRAJETS !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
				else
					if ( lower.StartsWith( ".hidepath" ) )
				{
					ArrayList toRemove = new ArrayList();
					foreach( GameObject go in World.allGameObjects )
						if ( go.Id >= 621680 && go.Id <= 621683 )
							toRemove.Add( go );
					foreach( GameObject go in toRemove )
						World.allGameObjects.Remove( go );
					this.account.RefreshMobileList( true );
				}
				else
					if ( lower.StartsWith( ".showpath" ) )
				{
					foreach( Trajet tr in World.trajets )
					{
						bool start = true;
						foreach( Coord c in tr )
						{
							GameObject go;
							if ( Distance( c.x, c.y, c.z ) < 400 * 400 )
							{
								if ( c is Intersection )
								{
									go = World.Add( 621682, c.x, c.y, c.z, MapId );
								}
								else
								{					
									if ( start )
										go = World.Add( 621681, c.x, c.y, c.z, MapId );							
									else
										go = World.Add( 621680, c.x, c.y, c.z, MapId );							
								}
							}
							start = false;
						}
					}
					this.account.RefreshMobileList( true );
				}
				else
					if ( lower.StartsWith( ".delpath" ) )
				{
					if ( startTrajetFlag != null )
						DestroyObject( startTrajetFlag.Guid );
					World.RemoveTrajet( path );
					path.Clear();
					path = null;//World.AllocateTrajet();					
					SendMessage( "Path is removed" );
				}
				else
					if ( lower.StartsWith( ".startpath" ) )
				{		
					if ( selection is MobileSpawner )
					{
						World.trajets.Dirty = true;
						if ( startTrajetFlag != null )
							DestroyObject( startTrajetFlag.Guid );
						path = World.AllocateTrajet();
						( selection as MobileSpawner ).TrajetGuid = path.Guid;
						startTrajetFlag = World.Add( 621681, X, Y, Z, MapId );
						foreach( Object o in this.KnownObjects )
							if ( o is BaseCreature )
							{
								if ( ( o as BaseCreature ).SpawnerLink == selection )
								{
									( o as BaseCreature ).Freeze = true;
								}
							}
						//startTrajetFlag.Decay = DateTime.Now.Add( TimeSpan.FromMinutes( 15.0 ) );
						SendMessage( "Start a new path for the spawner" );
					}
					else
						SendMessage( "You must select a spawner before starting a new path" );
				}
				else
					if ( lower.StartsWith( ".endpath" ) )
				{					
					if ( startTrajetFlag != null )
					{
						World.Remove( startTrajetFlag, this );				
					}
					if ( path != null && path.Count > 1 )
					{
						path[ 0 ].previous = path[ path.Count - 1 ];
						path[ path.Count - 1 ].next = path[ 0 ];
					}
					foreach( Object o in this.KnownObjects )
						if ( o is BaseCreature )
						{
							if ( ( o as BaseCreature ).SpawnerLink == selection )
							{
								( o as BaseCreature ).Freeze = true;
							}
						}										
					path = null;			
					SendMessage( "Path loop completed" );
				}

					#endregion TRAJETS !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
				else
					if ( lower.StartsWith( ".cast " ) )
				{
					string []tt = cmd.Split( new char[]{ ' ' } );
					if ( selection != null && selection is Mobile )
					{
						try
						{
							int i = Convert.ToInt32( tt[ 1 ] );
							( selection as Mobile ).FakeCast( i, this );
						}
						catch( Exception )
						{
							SendMessage( "Invalid spell id !" );
						}
					}
					else
						SendMessage( "You must target a mobile !" );
				}
				else
					if ( lower.StartsWith( ".additem " ) )
				{					
					string []tt = cmd.Split( new char[]{ ' ' } );
					if ( tt.Length == 3 )
					{
						try 
						{
							CreateAndAddObject( tt[ 1 ], Convert.ToInt32( tt[ 2 ] ) );
						}
						catch( Exception )
						{
							this.SendMessage( "usage : .additem ItemName [number]" );
						}
					}
					else
						if ( tt.Length == 2 )
						CreateAndAddObject( tt[ 1 ] );
					else
						this.SendMessage( "usage : .additem ItemName [number]" );
				}
				else
					if ( lower.StartsWith( ".addgo " ) )
				{

					try
					{
						cmd = cmd.Remove( 0, 7 );
						string []tt = cmd.Split( new char[]{ ' ' } );
						int i = Convert.ToInt32( tt[ 0 ] );
						if ( GameObjectDescription.all[ i ]== null )
						{
							SendMessage( "Unknow Game object " + i.ToString() );
							return;
						}
						GameObject go = null;
						if ( World.GameObjectsAssociated.Exist( i ) )
						{
							go = World.Add( i, Utility.ClassName( World.GameObjectsAssociated[ i ].ToString() ), X, Y, Z, MapId );
							go.Id = i;
						}
						else
							go = World.Add( i, X, Y, Z, MapId );
						if ( this.linkedSpawner == -1 )
						{
							SendMessage( "You cannot place a game object here, first place a spawner !" );
						}
						else
						{
							World.allSpawners[ linkedSpawner ].Bind( go );
							account.RefreshMobileList( true );
						}
					}
					catch( Exception )
					{
					}
				}
				else
					if ( lower.StartsWith( ".where" ) )
				{
					SendMessage( "X = " + X.ToString() + ", Y = " + Y.ToString() + ", Z = " + Z.ToString() + " mapId = " + this.MapId.ToString() );					
				}
				else
					if ( lower == ".remove" )
				{
					if ( selection != null )
					{
						selection.Delete();
						
						if ( selection.Guid > 0xF100000000000000 )
						{
							World.allSpawners.Remove( selection as BaseSpawner );
							SendMessage( "Spawnpoint deleted" );
							this.linkedSpawner = -1;
							
						}
						else
						{
							World.allMobiles.Remove( selection as Mobile );
							SendMessage( ( selection as Mobile ).Name + " deleted" );
						}
						account.HeartBeat();
					}
				}
				else
					if ( lower.StartsWith( ".addnpc " ) )
				{
					//SendMessage( cmd );
					string []cmds = cmd.Split( new char[]{ ' ' } );
					if ( cmds.Length < 2 )
					{
						SendMessage( "Usage : .addnpc NpcName [howmany]" );
						return;
					}
					Factions fact = Factions.NoFaction;
					
					int n = 1;
					if ( cmds.Length == 3 )
					{
						try
						{
							n = Convert.ToInt32( cmds[ 2 ] );
						}
						catch(Exception)
						{
						}
					}
					if ( cmds.Length == 4 )
					{
						try
						{
							fact = (Factions)Convert.ToInt32( cmds[ 3 ] );
						}
						catch(Exception)
						{
						}
					}
					for(int t = 0;t < n;t++ )
					{
						ConstructorInfo ct = null;
						try
						{
							int mid = (int)Convert.ToInt32( cmds[ 1 ] );
							ct = World.MobilePool( mid );
						}
						catch(Exception)
						{
							ct = Utility.FindConstructor( cmds[ 1 ] , Utility.externAsm[ "creatures" ] );
							if ( ct == null )
								ct = Utility.FindConstructor( cmds[ 1 ] );
						}

						if ( ct == null )
						{
							SendMessage( cmds[ 1 ] + " is not a valid Npc !!!" );
							return;
						}
						BaseCreature bc = null;
						try
						{
							bc =  (BaseCreature)ct.Invoke( null );
						}
						catch( Exception e )
						{
							//			Console.WriteLine( "{0}\n{1}\n{2}\n", e.Message, e.Source, e.StackTrace );
							SendMessage( e.Message );
							SendMessage( e.Source );
							SendMessage( e.StackTrace );
							return;
						}
						bc.X = X;
						bc.Y = Y;
						bc.Z = Z;
						bc.ZoneId = ZoneId;
						bc.MapId = MapId;
						bc.InitStats();
						float nearest = float.MaxValue;
						BaseSpawner nearSpawner = null;
						foreach( BaseSpawner bs in World.allSpawners )
							if ( bs.Distance( this ) < nearest )
							{
								nearest = bs.Distance( this );
								nearSpawner = bs;
							}
						if ( nearSpawner != null )
							nearSpawner.Bind( bc );
						World.allMobiles.Add( bc, true );	
						if ( fact != Factions.NoFaction )
							bc.Faction = fact;
						Player.RefreshMobileList( true );
					}
				}
				else
					if ( lower.StartsWith( ".move" ) )
				{
					byte []b4 = new byte[] {0x00, 0x31, 0x96, 0x00, 0x0A, 0x00, 0x00, 0x00, 0x00, 0x32, 0x36, 0x21, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1D, 0x00, 0x00, 0x00, 0x57, 0x65, 0x6C, 0x63, 0x6F, 0x6D, 0x65, 0x20, 0x74, 0x6F, 0x20, 0x57, 0x6F, 0x72, 0x6C, 0x64, 0x20, 0x6F, 0x66, 0x20, 0x57, 0x61, 0x72, 0x63, 0x72, 0x61, 0x66, 0x74, 0x00, 0x00};
					int offset = 9;
					Converter.ToBytes( Guid, b4, ref offset );
					Player.Handler.Send( 0x96, b4 );

					foreach( Mobile m in World.allMobiles )
						if ( !( m is Character ) )
							m.MovementHeartBeat( account.Handler, this );
				}
				else
					if ( lower.StartsWith( ".save" ) )
				{
					MainConsole.world.SaveGame();
				}
				else
					if ( lower.StartsWith( ".load" ) )
				{
				}
				else
					/*					if (lower.StartsWith( ".stest" ))
									{
										ConstructorInfo ct1 = Utility.FindConstructor( "RazorHillGrunt" , Utility.externAsm );
										for(int i = 0;i < 400;i+=30 )
										for(int t = i;t < i + 30;t++ )
										{
											BaseCreature bc = (BaseCreature)ct1.Invoke( null );	
											bc.Faction = (Factions)t;
											bc.Name = "Faction " + t.ToString();
											bc.Id = t + 65000;
											World.Add( bc, -13234f + (float)( t / 30 ) * 2, 238f+ (float)( t % 30 ) * 2, 22f, 0 );
											bc.Freeze = true;						
										}
									}
									else*/
					if ( lower.StartsWith( ".mark" ) )
				{
					mark = new Position( X, Y, Z, MapId );
					SendMessage( "Mark at " + X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() + ", " + MapId.ToString() );
				}
				else
					if ( lower.StartsWith( ".recall" ) )
				{
					if ( mark == null )
						SendMessage( "You must mark a location first !" );
					else
						Teleport( mark.X, mark.Y, mark.Z, mark.MapId );
				}
				else
					if ( lower.StartsWith( ".go " ) )
				{	
					cmd = cmd.Remove( 0, 4 );
					string []val = cmd.Split( new char[]{' '} );
					if ( !( val.Length != 4 || val.Length != 2 ) )
					{
						SendMessage( "Need at 1 or 4 parameters !" );
						SendMessage( "usage : .go X Y Z MapId or .go Location" );
						return;
					}
					if ( val.Length == 1 && World.Locations[ val[ 0 ] ] == null )
					{
						SendMessage( val[ 0 ] + " is an unknown location" );
						return;
					}
					if ( val.Length == 1 )
					{
						Position pos = (Position)World.Locations[ val[ 0 ] ];
						Teleport( pos.X, pos.Y, pos.Z, pos.MapId );
					}
					else
						Teleport( Convert.ToSingle( val[ 0 ] ), 
							Convert.ToSingle( val[ 1 ] ), Convert.ToSingle( val[ 2 ] ),
							Convert.ToInt32( val[ 3 ] ) );
		
				}
				else
					if ( onCommand != null && !onCommand( this, cmd ) )
					return;
				else
					SendMessage( "Unknown command !" );
			}
		}

		#endregion

		#region TRAINING
		public class CastTrainerSpell : WowTimer
		{
			BaseAbility teach;
			Character to;
			Mobile teacher;
			public CastTrainerSpell( BaseAbility i, Character t, Mobile teachr ) :  base( WowTimer.Priorities.Milisec100 , 500, "CastTrainerSpell" )
			{
				to = t;
				teach = i;
				teacher = teachr;				
				byte []buff = { 0,0, 0,0, 0xD9, 0xDB, 0x74, 0x00, 0x00, 0x00, 0x00, 0x00, 0xD9, 0xDB, 0x74, 0x00, 0x00, 0x00, 0x00, 0x00, 0x44, 0x03, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
				//int offset = 4;
				int spell = 0;
				if ( i is Teach )
					spell = ( i as Teach ).TeachId;
				else
					spell = i.Id;
				/*
				Converter.ToBytes( t.Guid, buff, ref offset );
				Converter.ToBytes( teacher.Guid, buff, ref offset );
				Converter.ToBytes( spell, buff, ref offset );
				Converter.ToBytes( 0x100, buff, ref offset );
				Converter.ToBytes( 0, buff, ref offset );
				to.Send( OpCodes.SMSG_SPELL_START, buff );
*/
				teacher.FakeCast( spell, t );
				Start();
			}
			public override void OnTick()
			{
				int spell = 0;
				if ( teach is Teach )
					spell = ( teach as Teach ).TeachId;
				else
					spell = teach.Id;
				//	Release
			/*	byte []releaseEffect = { 0, 0, 0, 0, 0xED, 0x0E, 0x00, 0x00, 0x01 };
				int offset = 4;
				Converter.ToBytes( spell, releaseEffect, ref offset );
				to.Send( OpCodes.SMSG_CAST_RESULT, releaseEffect );
				//	Instant effet
				byte []effect = { 0, 0, 0, 0, 0xC2, 0x36, 0x21, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF7, 0x36, 0x21, 0x00, 0x00, 0x00, 0x00, 0x00, 0xED, 0x0E, 0x00, 0x00, 0x00, 0x01, 0x01, 0xC2, 0x36, 0x21, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
				offset = 4;
				Converter.ToBytes( to.Guid, effect, ref offset );
				Converter.ToBytes( teacher.Guid, effect, ref offset );
				Converter.ToBytes( (int)teach.Id, effect, ref offset );
				offset+=4;
				to.Send( OpCodes.SMSG_SPELL_GO, effect );*/
				to.TrainerBuyAck( teach );
				
				Stop();
				base.OnTick();
			}
		}

		public override void LearnSpell( int id )
		{
			int offset = 4;
			Converter.ToBytes( id, tempBuff, ref offset );
			account.Handler.Send( OpCodes.SMSG_LEARNED_SPELL, tempBuff, offset );				
			base.LearnSpell( id );
		}

		public override void UnLearnSpell(  int id )
		{
			int offset = 4;
			Converter.ToBytes( (ushort)id, tempBuff, ref offset );
			Send( OpCodes.SMSG_REMOVED_SPELL, tempBuff, offset );	
			base.UnLearnSpell( id );
		}
		public void TrainerBuyAck( BaseAbility teach )
		{
			if ( !OnTrainningAck() )
				return;
			int id = 0;
			if ( teach is Teach )
				LearnSpell( id = ( teach as Teach ).TeachId );
			else
				LearnSpell( id = teach.Id );				
			castTrainerSpell = null;
			BaseAbility ba = null;
			if ( teach is Teach )
				ba = (BaseAbility)Abilities.abilities[ ( teach as Teach ).TeachId ];
			else
				ba = (BaseAbility)teach;
			//	apprentissage des sorts liés
			ArrayList addon = (ArrayList)CustomSpellHandlers.spellAddons[ id ];
			if ( addon != null && addon.Count > 0 )
				foreach( int sp in addon )
					LearnSpell( sp );

			int price = 0;
			if ( onSpellPrice != null )
				price = onSpellPrice( this, id );
			if ( price == 0 )
				price = CustomSpellHandlers.SpellCost( id );

			Copper -= (uint)price;

			if ( ba is Profession )
			{
				Profession prof = (Profession)ba;
				if ( onLearn != null )
				{
					if ( onLearn( this, prof.Level, prof.ProfessionType ) )
						prof.OnLearn( this );
				}
				else			
					prof.OnLearn( this );
				Skill sk = AllSkills[ (ushort)prof.Id ];


				if ( sk != null )//	met a jour avec le skill connu
				{
					int start = sk.Index;
					sk = prof.Clone( sk.Current, (ushort)start );
					AllSkills[ (ushort)prof.Id ] = sk;
					SendSmallUpdate( new int[]{ start, start + 1, start + 2, (int)UpdateFields.PLAYER_FIELD_COINAGE }, new object[]{ (int)sk.Id, (short)sk.CurrentVal(this), (short)sk.Cap( this ), (int)0, Copper } );
					return;
				}
				else
				{//	Ajoute la nouvelle profession/Skill					
					int start = Profession.Slots( nProfessions );					
					nProfessions++;
					AllSkills[ (ushort)prof.Id ] = sk = prof.Clone( 1, (ushort)start );
					SendSmallUpdate( new int[]{ start, start + 1, start + 2, (int)UpdateFields.PLAYER_FIELD_COINAGE }, new object[]{ (int)sk.Id, (short)sk.CurrentVal(this), (short)sk.Cap( this ), (int)0, Copper } );
					return;
				}
			}
			SendSmallUpdate( new int[]{ (int)UpdateFields.PLAYER_FIELD_COINAGE }, new object[]{ Copper } );			
		}

		CastTrainerSpell castTrainerSpell;
		public void TrainerBuy( UInt64 guid, int id )
		{
			if ( castTrainerSpell != null )
				return;
			Mobile m = account.FindMobileByGuid( guid );
			if ( m == null )
				return;
			if ( m is BaseCreature )
			{
				( m as BaseCreature ).SpeakingFrom = DateTime.Now;
				( m as BaseCreature ).AIState = AIStates.Speaking;
			}
		//	id = ( test[ (short)id ] as BaseAbility ).Id;
			foreach( int t in m.Trains )
			{
				if ( t == id )
				{			
					BaseAbility ba = (BaseAbility)Abilities.abilities[ id ];
					if ( ba is Teach )
					{
						Teach teach = (Teach)Abilities.abilities[ id ];
						if ( teach == null )
						{
					//		Console.WriteLine( "{0} possede un sort qui n'existe pas {1}", m.Name, t );
							continue;
						}
						castTrainerSpell = new CastTrainerSpell( teach, this, m );
					}
					else
						if ( ba is Ability )
					{
						castTrainerSpell = new CastTrainerSpell( ba, this, m );
					}
				}
			}
		}

		/*public bool HaveAbility( BaseAbility ba )
		{
			if ( AllSkills[ (ushort)ba.Id ] != null )
				return true;
			return false;
		}*/


		/*
		 * 
		 2D 00 00 00 00 00 00 00 00 00 00 00 
		 0E 00 00 00 
		 15 0A 00 00 00 E8 03 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
		 16 0A 00 00 01 94 11 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 0F 0A 00 00 00 00 00 00 00 00 00 00 
		 F1 0C 00 00 01 14 05 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 0F 0A 00 00 00 00 00 00 00 00 00 00 
		 F2 0C 00 00 01 20 03 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 0F 0A 00 00 00 00 00 00 00 00 00 00 
		 F3 0C 00 00 01 B8 0B 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 10 0A 00 00 00 00 00 00 00 00 00 00 
		 F4 0C 00 00 01 D6 06 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 0F 0A 00 00 00 00 00 00 00 00 00 00 
		 F5 0C 00 00 01 D0 07 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 10 0A 00 00 00 00 00 00 00 00 00 00 
		 F0 0D 00 00 01 E0 2E 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 10 0A 00 00 00 00 00 00 00 00 00 00 
		 0C 0E 00 00 01 B2 0C 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 10 0A 00 00 00 00 00 00 00 00 00 00 
		 73 27 00 00 01 77 4C 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 08 28 00 00 00 00 00 00 00 00 00 00 
		 74 27 00 00 01 64 19 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 EC 0D 00 00 00 00 00 00 00 00 00 00 
		 09 28 00 00 01 A0 8C 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 EC 0D 00 00 00 00 00 00 00 00 00 00 
		 30 3A 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 
		 1A 3F 00 00 01 E0 2E 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 08 28 00 00 00 00 00 00 00 00 00 00 
		 48 65 6C 6C 6F 21 20 52 65 61 64 79 20 66 6F 72 20 73 6F 6D 65 20 74 72 61 69 6E 69 6E 67 3F 00
		 
		*/

		public void PrepareTrainerListTeachProfession( int t, ref int offset, Teach teach )
		{
			Profession prof = (Profession)Abilities.abilities[ teach.TeachId ];
			int price = 0;
			if ( onSpellPrice != null )
				price = onSpellPrice( this, teach.Id );
			if ( price == 0 )
				price = CustomSpellHandlers.SpellCost( teach.TeachId );

			int regSpell = CustomSpellHandlers.SpellPrerequisites( teach.TeachId );
			Converter.ToBytes( (int)t, tempBuff, ref offset );	
			if ( nProfessions == 0 && prof.Level == ProfessionLevels.Apprentice )
				Converter.ToBytes( (byte)0x00, tempBuff, ref offset );
			else
			{
				if ( regSpell != 0 && !HaveSpell( regSpell ) )
					Converter.ToBytes( (byte)0x01, tempBuff, ref offset );
				else
				if ( nProfessions == 0 && prof.Level == ProfessionLevels.Apprentice && AllSkills[ (ushort)prof.Id ] == null )//	 si il a une profession mais pas celle du skill
					Converter.ToBytes( (byte)0x00, tempBuff, ref offset );
				else
				{
					if ( AllSkills[ (ushort)prof.Id ] != null )//	si il possede ce skill il faut verifier a quel niveau
					{
						Profession sk = (Profession)AllSkills[ (ushort)prof.Id ];
						if ( (int)sk.Level >= (int)prof.Level )
							Converter.ToBytes( (byte)0x02, tempBuff, ref offset );
						else
							if ( (int)sk.Level + 1 == (int)prof.Level )
							Converter.ToBytes( (byte)0x00, tempBuff, ref offset );
						else
							Converter.ToBytes( (byte)0x01, tempBuff, ref offset );
					}
					else
						if ( nProfessions == 2 )//	deja deux profession, pas possible d'en prendre 3
						Converter.ToBytes( (byte)0x00, tempBuff, ref offset );
					else
					{//	Il n'a pas la profession et il lui reste un slot, il ne peut acceder qu'a apprentit
						if ( nProfessions == 1 && prof.Level == ProfessionLevels.Apprentice )
							Converter.ToBytes( (byte)0x00, tempBuff, ref offset );
						else
							Converter.ToBytes( (byte)0x01, tempBuff, ref offset );
					}

				}
			}
			Converter.ToBytes( price, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( (byte)0/*reqLevel*/, tempBuff, ref offset );						
			Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );// learn spell
			Converter.ToBytes( regSpell, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
		}

		public override bool HaveSkill( int id )
		{
			if ( AllSkills[ (ushort)id ] == null )
				return false;
			return true;
		}

		public void PrepareTrainerListTeachCraftTemplate( int t, ref int offset, Teach teach )
		{
			int price = 0;
			if ( onSpellPrice != null )
				price = onSpellPrice( this, teach.Id );
			if ( price == 0 )
				price = CustomSpellHandlers.SpellCost( teach.TeachId );
			int regSpell = CustomSpellHandlers.SpellPrerequisites( teach.TeachId );

			if ( Abilities.abilities[ teach.TeachId ] is CraftTemplate )
			{
				Converter.ToBytes( (int)t, tempBuff, ref offset );
				CraftTemplate ability = (CraftTemplate)Abilities.abilities[ teach.TeachId ];
				if ( ability == null )
					return;								
				if ( !HaveSpell( ability ) )
				{
					if ( HaveSkill( regSpell ) )
					{
						if ( Copper >= price )
							Converter.ToBytes( (byte)0x00, tempBuff, ref offset );
						else
							Converter.ToBytes( (byte)0x01, tempBuff, ref offset );
					}		
					else
						Converter.ToBytes( (byte)0x01, tempBuff, ref offset );			
				}
				else
					Converter.ToBytes( (byte)0x02, tempBuff, ref offset );
			}

			Converter.ToBytes( price, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( (byte)0, tempBuff, ref offset );						
			Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );// learn spell
			Converter.ToBytes( regSpell, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
		}

		public void PrepareTrainerListTeachSpellTemplate( int t, ref int offset, Teach teach )
		{			
			SpellTemplate ability = (SpellTemplate)Abilities.abilities[ teach.TeachId ];
			if ( ability == null )
				return;			
			Converter.ToBytes( (int)t, tempBuff, ref offset );
			
			int reqLevel = ability.RequieredLevel;
			int price = 0;
			if ( onSpellPrice != null )
				price = onSpellPrice( this, teach.TeachId );
			if ( price == 0 )
				price = CustomSpellHandlers.SpellCost( teach.TeachId );

			if ( !HaveSpell( teach.TeachId ) )
			{				
				if ( Level >= reqLevel )
				{
					if ( Copper >= price )
						Converter.ToBytes( (byte)0x00, tempBuff, ref offset );
					else
						Converter.ToBytes( (byte)0x01, tempBuff, ref offset );
				}
				else
					Converter.ToBytes( (byte)0x01, tempBuff, ref offset );
			}
			else
				Converter.ToBytes( (byte)0x02, tempBuff, ref offset );//	already known

			Converter.ToBytes( price, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( (byte)reqLevel, tempBuff, ref offset );						
			Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );// learn spell
			Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
		}

		public void PrepareTrainerListTeach( int t, ref int offset, Teach teach )
		{			
			if ( teach == null )
				return;

			if ( Abilities.abilities[ teach.TeachId ] is Profession )
				PrepareTrainerListTeachProfession( t, ref offset, teach );
			else
				if ( Abilities.abilities[ teach.TeachId ] is CraftTemplate )
				PrepareTrainerListTeachCraftTemplate( t, ref offset, teach );
			else					
				if (  Abilities.abilities[ teach.TeachId ] is SpellTemplate )
				PrepareTrainerListTeachSpellTemplate( t, ref offset, teach );
		}

		public void TrainerList( UInt64 guid )
		{
			Mobile m = account.FindMobileByGuid( guid );
			if ( m == null || m.Trains == null )
				return;
			if ( m is BaseCreature )
			{
				( m as BaseCreature ).SpeakingFrom = DateTime.Now;
				( m as BaseCreature ).AIState = AIStates.Speaking;
			}
			int offset = 4;
			Converter.ToBytes( guid, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			Converter.ToBytes( m.Trains.Length, tempBuff, ref offset );
			int nreal = 0;

			foreach( int t in m.Trains )
			{
				// Ability is Teach
				if ( Abilities.abilities[ t ] is Teach )
				{
					PrepareTrainerListTeach( t, ref offset, Abilities.abilities[ t ] as Teach );
					nreal++;
				}
				else
					if ( Abilities.abilities[ t ] is CraftTemplate )
				{
					CraftTemplate ct = (CraftTemplate)Abilities.abilities[ t ];
					Converter.ToBytes( (ushort)t, tempBuff, ref offset );
					Converter.ToBytes( (int)0x01000000, tempBuff, ref offset );
					Converter.ToBytes( 0, tempBuff, ref offset );
					Converter.ToBytes( 0, tempBuff, ref offset );
					Converter.ToBytes( (byte)0, tempBuff, ref offset );
					Converter.ToBytes( (byte)0, tempBuff, ref offset );
					Converter.ToBytes( (byte)0, tempBuff, ref offset );
					Converter.ToBytes( (byte)0, tempBuff, ref offset );						
					Converter.ToBytes( 0, tempBuff, ref offset );
					Converter.ToBytes( 0, tempBuff, ref offset );// learn spell
					Converter.ToBytes( 0, tempBuff, ref offset );
					Converter.ToBytes( 0, tempBuff, ref offset );
					Converter.ToBytes( 0, tempBuff, ref offset );

					nreal++;
				}
				else
					if ( Abilities.abilities[ t ] is Ability )
				{
					Ability ct = (Ability)Abilities.abilities[ t ];
					Converter.ToBytes( (ushort)t, tempBuff, ref offset );
					Converter.ToBytes( (int)0x01000000, tempBuff, ref offset );
					Converter.ToBytes( 0, tempBuff, ref offset );
					Converter.ToBytes( 0, tempBuff, ref offset );
					Converter.ToBytes( (byte)0, tempBuff, ref offset );
					Converter.ToBytes( (byte)0, tempBuff, ref offset );
					Converter.ToBytes( (byte)0, tempBuff, ref offset );
					Converter.ToBytes( (byte)0, tempBuff, ref offset );						
					Converter.ToBytes( 0, tempBuff, ref offset );
					Converter.ToBytes( 0, tempBuff, ref offset );// learn spell
					Converter.ToBytes( 0, tempBuff, ref offset );
					Converter.ToBytes( 0, tempBuff, ref offset );
					Converter.ToBytes( 0, tempBuff, ref offset );

					nreal++;
				}

			}
			int len = offset;
			offset = 16;
			Converter.ToBytes( nreal, tempBuff, ref offset );
		/*	for(int j = 0;j < len;j++ )
				Console.Write("{0} ", tempBuff[ j ].ToString( "X2") );*/
			account.Handler.Send( OpCodes.SMSG_TRAINER_LIST, tempBuff, len );
		}
		#endregion
		#region PACKET MANAGEMENT
		Coord lastCoordTrajet = null;
		public void ManagePacket( int code, byte []data, ref int after, int len )
		{
			switch( code )
			{
				case (int)OpCodes.MSG_MOVE_START_FORWARD :
							
				case (int)OpCodes.MSG_MOVE_FALL_LAND:
				case (int)OpCodes.MSG_MOVE_JUMP:  
				case (int)OpCodes.MSG_MOVE_START_BACKWARD: case (int)OpCodes.MSG_MOVE_SET_FACING:
				case (int)OpCodes.MSG_MOVE_STOP: case (int)OpCodes.MSG_MOVE_START_STRAFE_LEFT: 
				case (int)OpCodes.MSG_MOVE_START_STRAFE_RIGHT: case (int)OpCodes.MSG_MOVE_STOP_STRAFE:
				case (int)OpCodes.MSG_MOVE_START_TURN_LEFT: case (int)OpCodes.MSG_MOVE_START_TURN_RIGHT:  
				case (int)OpCodes.MSG_MOVE_STOP_TURN: case (int)OpCodes.MSG_MOVE_START_PITCH_UP :
				case (int)OpCodes.MSG_MOVE_START_PITCH_DOWN: case (int)OpCodes.MSG_MOVE_STOP_PITCH : 
				case (int)OpCodes.MSG_MOVE_SET_RUN_MODE: case (int)OpCodes.MSG_MOVE_SET_WALK_MODE:
				case (int)OpCodes.MSG_MOVE_SET_PITCH: case (int)OpCodes.MSG_MOVE_START_SWIM:
				case (int)OpCodes.MSG_MOVE_STOP_SWIM: 


					// 00 30 EE 00 
					//00 00 01 20 00 00 6B 8C 09 00 
					//F8 6F 33 45 
					//42 F5 41 C4 
					//5D 6D 20 43 
					//AC 6A 73 40 
					//BA 00 00 00 00 00 00 00 CD F4 49 BF FF 51 1D BF 00 00 E0 40 .@ 
				case (int)OpCodes.MSG_MOVE_HEARTBEAT:
				{
					if ( code == (int)OpCodes.MSG_MOVE_START_TURN_LEFT ||
						code == (int)OpCodes.MSG_MOVE_SET_FACING || 
						code == (int)OpCodes.MSG_MOVE_START_TURN_RIGHT )
						deadEndTeleportLoop = false;
					//	TimeSpan ts = DateTime.Now.Subtract( lastUpdate );
					//	if ( ts.TotalSeconds > 2 )
					Player.RefreshMobileList( false );
					Player.realylogged = true;
					if ( AutoShot != null )
						AutoShot.Restart();
					Player.MvtToAllPlayerNear( code, data, after, len + 2 );
					float x = BitConverter.ToSingle( data, after + 14 );
					float y = BitConverter.ToSingle( data, after + 18 );
					float z = BitConverter.ToSingle( data, after + 22 );
					float orientation = BitConverter.ToSingle( data, after + 26 );
					MoveHandler( x, y, z, orientation );
					if ( code != (int)OpCodes.MSG_MOVE_FALL_LAND && path != null )
					{
						if ( path.Count > 0 )
						{
							int ne = path.Count - 1;
							float xx = path[ ne ].x - x;
							float yy = path[ ne ].y - y;
							float zz = path[ ne ].z - z;
							if ( xx + yy + zz != 0 )
							{
								SendMessage( "Pos x="+x.ToString()+"; y="+y.ToString()+"; z="+z.ToString() );
								Coord l = lastCoordTrajet;
								lastCoordTrajet = new Coord( x, y, z, lastCoordTrajet, null );
								l.next = lastCoordTrajet;
								path.Add( lastCoordTrajet, l );
							}
						}
						else
						{
							lastCoordTrajet = new Coord( x, y, z, null, null );
							path.Add( lastCoordTrajet );
						}
					}
					else
						if ( code == (int)OpCodes.MSG_MOVE_START_STRAFE_RIGHT || code == (int)OpCodes.MSG_MOVE_START_STRAFE_LEFT )
					{
						if ( IsCasting )
						{
							CancelCast();
						}
					}

					break;
				}
				case (int)OpCodes.CMSG_USE_ITEM:
					UseItem( data[ after + 6 ], BitConverter.ToInt32( data, after + 7 ) );
					break;
				case (int)OpCodes.CMSG_DUEL_CANCELLED:
				{
					CancelDuel( BitConverter.ToUInt64( data, after + 6 ) );
					break;
				}
				case (int)OpCodes.CMSG_DUEL_ACCEPTED:
				{
					SendDuelArbitrer( BitConverter.ToUInt64( data, after + 6 ) );
					break;
				}
				case (int)OpCodes.CMSG_ENABLE_PVP:
				{
					break;
				}
				case (int)OpCodes.CMSG_CANCEL_AUTO_REPEAT_SPELL:
				{
					OnCancelAutoCastSpell();
					break;
				}

				case (int)OpCodes.CMSG_CAST_SPELL:
					if ( taxiOn )
					{
						SpellFaillure( SpellFailedReason.YourAreInFligth );
					}
					else
					{
						if ( BitConverter.ToInt32( data, after + 6 ) == 7266 )
							PrepareInv( data, after );
						ushort type = BitConverter.ToUInt16( data, after + 10 );
						OnCastSpellCMSG(data,after,type);
					}
					break;
				case (int)OpCodes.CMSG_ATTACKSWING:
					AttackSwing( BitConverter.ToUInt64( data, after + 6 ) );
					break;
				case (int)OpCodes.CMSG_CANCEL_CAST:
					CancelCast();
					break;
				case (int)OpCodes.CMSG_SET_SELECTION:
					SetSelection( BitConverter.ToUInt64( data, after + 6 ) );
					//						SendNullAction( code );
					break;
				case (int)OpCodes.CMSG_STANDSTATECHANGE:
					ChangeStandState( BitConverter.ToInt32( data, after + 6 ) );
					break;
				case (int)OpCodes.CMSG_GAMEOBJECT_QUERY:
					GameObjectQuery( BitConverter.ToInt32( data, after + 6 ), (UInt64)BitConverter.ToUInt64( data, after + 10 ) );
					break;
				case (int)OpCodes.CMSG_SET_TARGET:
					Target = (UInt64)BitConverter.ToInt64( data, after + 6 );
					//	SendNullAction( code );
					break;
				case (int)OpCodes.CMSG_LIST_INVENTORY:
					ShowMobileInventory( (UInt64)BitConverter.ToInt64( data, after + 6 ) );
					//SendNullAction( code );
					break;
				case (int)OpCodes.CMSG_BUY_ITEM:
					Buy( BitConverter.ToUInt64( data, after + 6 ), BitConverter.ToInt32( data, after + 14 ), Slots.None, data[ after + 19 ] );						
					break;
				case (int)OpCodes.CMSG_SELL_ITEM:
					Sell( BitConverter.ToUInt64( data, after + 6 ), BitConverter.ToUInt64( data, after + 14 ) );						
					break;

				case 0x020B:
					//SendNullAction( code );
					break;
				case (int)OpCodes.CMSG_SET_ACTIVE_MOVER://	Account update
					//	SendNullAction( code );
					break;
				case 0x211://	CMSG_GMTICKET
					Player.Handler.Send( 0x212, new byte[]{ 0x00, 0x06 , 0x12 , 0x02 , 0x01 , 0x00 , 0x00 , 0x00 } );
					break;
				case 0x1CE://	Query time							
					byte []buffTime = { 0,0,0,0, 0x90,0xE0,0x22,0x42};
					Player.Handler.Send( (int)OpCodes.SMSG_QUERY_TIME_RESPONSE, buffTime );
					break;
				case 0x1FF://	Looking for Group						
					//SendNullAction( code );
					break;
				case (int)OpCodes.CMSG_NAME_QUERY:
					SendName( BitConverter.ToUInt64( data, after + 6 ) );
					break;
				case (int)OpCodes.CMSG_MESSAGECHAT:
					//00 00 00 00 00 00 07 00 00 00 7A 6F 62 00 
				{
					string cmd = "";
					for(int t = 0;data[ after + t + 14 ] != 0;t++ )
						cmd += "" + (char)data[ after + t + 14 ];
					MessageHandler( cmd, (Character.ChatMsgType)BitConverter.ToInt32( data, after + 6 ), BitConverter.ToInt32( data, after + 10 ) );						
					break;
				}
				case 0x284:// MSG_QUERY_NEXT_MAIL_TIME
					Player.Handler.Send( OpCodes.MSG_QUERY_NEXT_MAIL_TIME, new byte[]{ 0,0,0,0, 0x00, 0x0 , 0x0 , 0x0 } );
					break;
				case 0xFB://	CMSG_NEXT_CINEMATIC_CAMERA
					break;
				case 0xFC://	CMSG_COMPLETE_CINEMATIC
					break;
				case 0xFE://	CMSG_TUTORIAL_FLAG
					//	Trace();
					break;
				case 0xFF://	CMSG_TUTORIAL_CLEAR
					break;
				case (int)OpCodes.CMSG_JOIN_CHANNEL://	CMSG_JOIN_CHANNEL
					JoinChannel( data, after + 6 );
					this.Player.Handler.debloque = true;
					break;
				case 0x1F4://	CMSG_ZONEUPDATE		
					ZoneUpdateRequested( BitConverter.ToInt32( data, after + 6 ) );
					break;
				case 0x56://	CMSG_ITEM_QUERY_SINGLE
					SendItem( BitConverter.ToInt32( data, after + 6 ), BitConverter.ToUInt64( data, after + 10 ) );
					break;
				case (int)OpCodes.CMSG_LOOT_MONEY:
					OnLootMoney();
					break;
				case (int)OpCodes.CMSG_CREATURE_QUERY:
					CreatureQuery( (UInt64)BitConverter.ToInt64( data, after + 10 ), BitConverter.ToInt32( data, after + 6 ) );
					break;
				case (int)OpCodes.CMSG_LOOT_RELEASE:
					ReleaseLoot();
					break;
				case (int)OpCodes.CMSG_AUTOSTORE_LOOT_ITEM:
					AutostoreLootItem( data[ after + 6 ] );
					break;
				case (int)OpCodes.CMSG_LOOT:
					LootCreature( BitConverter.ToUInt64( data, after + 6 ) );
					break;
				case (int)OpCodes.CMSG_SETSHEATHED:
					Sheathed = BitConverter.ToInt32( data, after + 6 );
					break;
				case (int)OpCodes.CMSG_QUESTGIVER_QUERY_QUEST:
					QuestQueryForCreature( BitConverter.ToUInt64( data, after + 6 ), BitConverter.ToInt32( data, after + 14 ) );
					break;
				case (int)OpCodes.CMSG_QUESTGIVER_STATUS_QUERY:
					QuestStatus( BitConverter.ToUInt64( data, after + 6 ) );
					break;
				case (int)OpCodes.CMSG_QUESTGIVER_HELLO:
					QuestGiverHello( BitConverter.ToUInt64( data, after + 6 ) );
					break;
				case (int)OpCodes.CMSG_NPC_TEXT_QUERY:
					NpcTextQuery( BitConverter.ToInt32( data, after + 6 ), BitConverter.ToUInt64( data, after + 10 ) );
					break;	
				case (int)OpCodes.CMSG_GOSSIP_SELECT_OPTION:
					GossipSelectOption( BitConverter.ToUInt64( data, after + 6 ), BitConverter.ToInt32( data, after + 14 ) );
					break;	
				case (int)OpCodes.CMSG_QUESTGIVER_ACCEPT_QUEST:
					AcceptQuest( BitConverter.ToUInt64( data, after + 6 ), BitConverter.ToInt32( data, after + 14 ) );
					break;
				case (int)OpCodes.CMSG_QUESTLOG_REMOVE_QUEST:
					RemoveQuest( data[ after + 6 ] );
					break;
				case (int)OpCodes.CMSG_QUESTGIVER_COMPLETE_QUEST:
					QuestGiverCompleteQuest( BitConverter.ToUInt64( data, after + 6 ), BitConverter.ToInt32( data, after + 14 ) );
					break;
				case (int)OpCodes.CMSG_QUEST_QUERY:
					QuestQuery( BitConverter.ToInt32( data, after + 6 ) );
					break;
				case (int)OpCodes.CMSG_QUESTGIVER_CHOOSE_REWARD:
					ChooseReward( BitConverter.ToUInt64( data, after + 6 ), BitConverter.ToInt32( data, after + 14 ), BitConverter.ToInt32( data, after + 18 ) );
					break;
				case (int)OpCodes.CMSG_GAMEOBJ_USE:
					GameObjectUse( BitConverter.ToUInt64( data, after + 6 ) );
					break;
				case (int)OpCodes.CMSG_ATTACKSTOP:
					if ( Player == null )
						return;
					StopAttacking();
					break;
				case 0x20A://	CMSG_REQUEST_ACCOUNT_DATA
					break;
				case (int)OpCodes.CMSG_SWAP_INV_ITEM:
					SwapInv( (Slots)data[ after + 6 ], (Slots)data[ after + 7 ] );
					break;
				case (int)OpCodes.CMSG_SWAP_ITEM:
					SwapItem( data[ after + 6 ], data[ after + 7 ], data[ after + 8 ], data[ after + 9 ] );
					break;
				case (int)OpCodes.CMSG_DESTROYITEM:
					DestroyItem( Item.SlotNum( data[ after + 6 ], data[ after + 7 ] ), true );
					break;
				case (int)OpCodes.CMSG_AUTOEQUIP_ITEM:
					AutoEquip( Item.SlotNum( data[ after + 6 ], data[ after + 7 ] ) );
					break;
				case (int)OpCodes.CMSG_AUTOSTORE_BAG_ITEM:
					Autostore( Item.SlotNum( data[ after + 6 ], data[ after + 7 ] ), data[ after + 8 ] );
					break;
				case (int)OpCodes.CMSG_INITIATE_TRADE:
					InitiateTrade( BitConverter.ToUInt64( data, after + 6 ) );
					break;
				case (int)OpCodes.CMSG_BEGIN_TRADE:
					BeginTrade();
					break;
				case (int)OpCodes.CMSG_SET_TRADE_ITEM:
					TradeItem( data[ after + 6 ], Item.SlotNum( data[ after + 7 ], data[ after + 8 ] ) );
					break;
				case (int)OpCodes.CMSG_CLEAR_TRADE_ITEM:
					ClearTradeItem( (int)data[ after + 6 ] );
					break;				
				case (int)OpCodes.CMSG_SET_TRADE_GOLD:
					TradeGold( BitConverter.ToInt32( data, after + 6 ) );
					break;
				case (int)OpCodes.CMSG_LOGOUT_REQUEST:
				{
					Player.Handler.Send( OpCodes.SMSG_LOGOUT_RESPONSE, new byte[]{ 0x00, 0x06 , 0x12 , 0x02 , 00, 00, 00, 00, 00 } );
					Player.LoggoutStartTimer();
					break;
				}
				case (int)OpCodes.CMSG_SET_ACTION_BUTTON:
					AddToActionBar( data[ after + 6 ], BitConverter.ToUInt16( data, after + 7 ), data[ after + 9 ], data[ after + 10 ] );
					break;

				case (int)OpCodes.CMSG_TRAINER_LIST:
					TrainerList( BitConverter.ToUInt64( data, after + 6 ) );
					break;
				case (int)OpCodes.CMSG_TRAINER_BUY_SPELL:
					TrainerBuy( BitConverter.ToUInt64( data, after + 6 ), BitConverter.ToInt32( data, after + 14 ) );						
					break;

				case (int)OpCodes.CMSG_UNLEARN_SKILL:
					SendMessage( "Not available yet !" );
					break;
				case (int)OpCodes.CMSG_SET_AMMO:
					SetAmmo( BitConverter.ToInt32( data, after + 6 ) );
					break;
				case (int)OpCodes.CMSG_TEXT_EMOTE:
					OnTextEmote( BitConverter.ToInt32( data, after + 6 ), BitConverter.ToUInt64( data, after + 14 ) );
					break;
				case (int)OpCodes.CMSG_RECLAIM_CORPSE:
					ReclaimCorps();
					break;
				case (int)OpCodes.MSG_CORPSE_QUERY:
					CorpseQuery();
					break;
				case (int)OpCodes.CMSG_REPOP_REQUEST:
					OnRepop();
					break;
				case (int)OpCodes.CMSG_CANCEL_TRADE:
					CancelTrade();
					break;
				case (int)OpCodes.CMSG_ACCEPT_TRADE:
					AcceptTrade();
					break;
				case (int)OpCodes.CMSG_UNACCEPT_TRADE:
					UnacceptTrade();
					break;
				case (int)OpCodes.CMSG_LEAVE_CHANNEL:
					Player.Handler.SendNullAction( (int)OpCodes.SMSG_CHANNEL_NOTIFY );
					break;
				case (int)OpCodes.CMSG_MEETING_STONE_INFO:
					MeetingStoneInfo();
					break;
				case (int)OpCodes.CMSG_CANCEL_AURA:
					CancelAura(  BitConverter.ToInt32( data, after + 6 ) );
					break;
				case (int)OpCodes.CMSG_PET_ACTION:
					PetAction( BitConverter.ToUInt16( data, after + 0xe ), data[ after + 17 ], BitConverter.ToUInt64( data, after + 18 ) );
					break;
				case (int)OpCodes.CMSG_PET_SET_ACTION:
					if ( len == 0x14 )
						SetPetAction( BitConverter.ToUInt64( data, after + 6 ), BitConverter.ToInt32( data, after + 0xe ), BitConverter.ToUInt32( data, after + 0x12 ) );
					else
						SetPetAction( BitConverter.ToUInt64( data, after + 6 ), BitConverter.ToUInt32( data, after + 0xe ), BitConverter.ToUInt32( data, after + 0x12 ), BitConverter.ToUInt32( data, after + 0x16 ), BitConverter.ToUInt32( data, after + 0x1A ) );
					break;
				case (int)OpCodes.CMSG_PET_ABANDON:
					DismissPet( BitConverter.ToUInt64( data, after + 6 ) );
					break;
				case (int)OpCodes.MSG_MOVE_WORLDPORT_ACK:
					TeleportAck();
					break;
				case (int)OpCodes.CMSG_GROUP_INVITE:
					string name = "";
					for(int t = 0;data[ after + t + 6 ] != 0;t++ )
						name += "" + (char)data[ after + t + 6 ];
					GroupInvite( name );
					break;
				case (int)OpCodes.CMSG_LEARN_TALENT:
					LearnTalent( BitConverter.ToInt32( data, after + 6 ), BitConverter.ToInt32( data, after + 10 ) );
					break;
				case (int)OpCodes.CMSG_GROUP_ACCEPT:	
					GroupAccept();
					break;
				case (int)OpCodes.CMSG_GROUP_DISBAND:	
					QuitGroup();
					break;
				case (int)OpCodes.CMSG_GROUP_UNINVITE:	
					string uname = "";
					for(int t = 0;data[ after + t + 6 ] != 0;t++ )
						uname += "" + (char)data[ after + t + 6 ];
					GroupUninvite( uname );
					break;
				case (int)OpCodes.CMSG_GROUP_SET_LEADER:	
					string lname = "";
					for(int t = 0;data[ after + t + 6 ] != 0;t++ )
						lname += "" + (char)data[ after + t + 6 ];
					GroupSetLeader( lname );
					break;
				case (int)OpCodes.CMSG_GROUP_DECLINE:	
					GroupDecline();
					break;							
				case (int)OpCodes.CMSG_FORCE_RUN_SPEED_CHANGE_ACK:
					ForceSpeedAck();
					break;
				case (int)OpCodes.CMSG_AREATRIGGER:
					if (Character.onAreaTrigger != null)
						AreaTrigger( BitConverter.ToInt32( data, after + 6 ) );
					break;
				case (int)OpCodes.CMSG_TAXINODE_STATUS_QUERY:
					Taxi.OnCMSG_TAXINODE_STATUS_QUERY( this );
					break;
				case (int)OpCodes.CMSG_TAXIQUERYAVAILABLENODES:
					Taxi.OnCMSG_TAXIQUERYAVAILABLENODES( this );
					break;
				case (int)OpCodes.CMSG_ACTIVATETAXI:
					Taxi.OnCMSG_ACTIVATETAXI( this,BitConverter.ToUInt32( data, after + 14 ),BitConverter.ToUInt32( data, after + 18 ));
					//		HexViewer.View( data, after, length );
					break;
				case (int)OpCodes.CMSG_CANCEL_CHANNELLING:
					ChannelEnd();
					break;
				case (int)OpCodes.CMSG_BINDER_ACTIVATE:
					//	UInt64 fromg = BitConverter.ToUInt64( data, after + 12 );
					//	Mobile from = Player.FindMobileByGuid( fromg );
					//	Character.onBinderActivate( loggedChar, from, BitConverter.ToInt32( data, after + 6 ) );
					break;
				case (int)OpCodes.CMSG_GOSSIP_HELLO:
				{
					UInt64 fromh = BitConverter.ToUInt64( data, after + 6 );
					GossipHello( fromh );
					break;
				}
				case (int)OpCodes.CMSG_BUY_ITEM_IN_SLOT:
				{
					UInt64 fromseller = BitConverter.ToUInt64( data, after + 6 );
					int itemid = BitConverter.ToInt32( data, after + 0xe );
					byte slot = data[ after + 0x1A ];
					byte n = data[ after + 0x1B ];
					Buy( fromseller, itemid, (Slots)slot, n );
					break;
				}
				case (int)OpCodes.CMSG_LOOT_METHOD:
				{
					SetLootMethod( BitConverter.ToInt32( data, after + 0x6 ) );
					break;
				}
				case (int)OpCodes.CMSG_FRIEND_LIST:
				{
					SendFriendList();
					break;
				}
				case (int)OpCodes.CMSG_WHO:
				{
					WhoIsRequest();
					break;
				}
				case (int)OpCodes.CMSG_ADD_FRIEND:
				{
					string addf = "";
					for(int t = 0;data[ after + t + 6 ] != 0;t++ )
						addf += "" + (char)data[ after + t + 6 ];
					AddFriend( addf );
					break;
				}
				case (int)OpCodes.CMSG_SPIRIT_HEALER_ACTIVATE:
				{
					ReclaimCorps();
					break;
				}
							
				default:
					if ( code != 0x2CE )
						Console.WriteLine( "{2} : Receive unknown command {0} ({1})", (OpCodes)code, code.ToString( "X4" ), Name );
					if ( code > 0x330 )
					{							
						Console.WriteLine("");
						Console.WriteLine("{0} kicked", Player.Username );
						Player.Loggout( Guid );
						//Player.StopPacketHandler();							
						Player.Handler.Dispose();
					}
						
					break;
			}
		}
		#endregion
		#region DEATH_SYSTEM
		public void ReclaimCorps()
		{
			onCharacterReclaimCorps( this );
			Mobile c = account.FindMobileByGuid( this.corpsGuid );
			HitPoints = BaseHitPoints / 2;
			Mana = BaseHitPoints / 2;
			if ( c != null )
			{
				c.SpawnerLink.Release( c );
				c.Delete();
				World.allMobiles.Remove( c );
				account.HeartBeat();
			}
			this.SendSmallUpdateToPlayerNearMe( new int[] { 22, 23, 46, 79, 111, 121, 127, 131, 180 }, new object[] { BaseHitPoints / 10, 0, 0x1008, 0, 0, 0, 0xdddddddd, 0x2, 0 } );

			Send( OpCodes.CMSG_CHANNEL_SET_OWNER, new byte[]{ 0,0,0,0, 0,0,0,0,0,0,0 }, 11 );
	}
		void CorpseQuery()
		{
			//00 17 16 02    01 00 00 00   00   3C C0 0B C6 9C 42 0B C3 44 4D A7 42 00 00 00 00 
			int offset = 4;
			Converter.ToBytes( (byte)1, tempBuff, ref offset );
			Converter.ToBytes( (int)CorpseMapId, tempBuff, ref offset );																			
			Converter.ToBytes( CorpseLocationX, tempBuff, ref offset );
			Converter.ToBytes( CorpseLocationY, tempBuff, ref offset );
			Converter.ToBytes( CorpseLocationZ, tempBuff, ref offset );
			Converter.ToBytes( (int)CorpseMapId, tempBuff, ref offset );
			this.Send( OpCodes.MSG_CORPSE_QUERY, tempBuff, offset );
			//00 12 D5 01  9D 00 00 00 00 00 00 00 3C C0 0B C6 9C 42 0B C3 
			offset = 4;
			Converter.ToBytes( Guid, tempBuff, ref offset );
			Converter.ToBytes( CorpseLocationX, tempBuff, ref offset );
			Converter.ToBytes( CorpseLocationY, tempBuff, ref offset );
			this.Send( OpCodes.MSG_MINIMAP_PING, tempBuff, offset );			
		}
		public override void OnDeath( Mobile by )
		{
			if ( Duel != 0 )
			{				
				this.ReleaseAllAura();
				int offset = 4;
				if ( gu != null )
				{
					Converter.ToBytes( (byte)0, tempBuff, ref offset );
					Converter.ToBytes( gu.Name, tempBuff, ref offset );
					Converter.ToBytes( (byte)0, tempBuff, ref offset );
					Converter.ToBytes( Name, tempBuff, ref offset );
					Converter.ToBytes( (byte)0, tempBuff, ref offset );
					Send( OpCodes.SMSG_DUEL_WINNER, tempBuff, offset );
					gu.Send( OpCodes.SMSG_DUEL_WINNER, tempBuff, offset );
					offset = 4;
					Converter.ToBytes( (byte)1, tempBuff, ref offset );
					Send( OpCodes.SMSG_DUEL_COMPLETE, tempBuff, offset );
					gu.Send( OpCodes.SMSG_DUEL_COMPLETE, tempBuff, offset );
					offset = 4;
					Converter.ToBytes( Duel, tempBuff, ref offset );
					Send( OpCodes.SMSG_GAMEOBJECT_DESPAWN_ANIM, tempBuff, offset );
					gu.Send( OpCodes.SMSG_GAMEOBJECT_DESPAWN_ANIM, tempBuff, offset );
					Send( OpCodes.SMSG_DESTROY_OBJECT, tempBuff, offset );
					gu.Send( OpCodes.SMSG_DESTROY_OBJECT, tempBuff, offset );
					this.HitPoints = this.BaseHitPoints / 4;
					this.SendSmallUpdateToPlayerNearMe( new int[] { (int)UpdateFields.UNIT_DYNAMIC_FLAGS, 178, 179, 186 } , new object[] { 0, 0, 0, 0 } );				
					gu.SendSmallUpdateToPlayerNearMe( new int[] { (int)UpdateFields.UNIT_DYNAMIC_FLAGS, 178, 179, 186 } , new object[] { 0, 0, 0, 0 } );				
					Aura aura = new Aura();
					this.AddAura( ( Abilities.abilities[ 7267 ] as AuraEffect ), aura, true );
					offset = 4;
					gu.Send( OpCodes.SMSG_CANCEL_COMBAT, tempBuff, offset );
					Send( OpCodes.SMSG_CANCEL_COMBAT, tempBuff, offset );	
					gu.Duel = 0;
					gu.guowner = null;
					gu.gu = null;
				}
				Duel = 0;				
				guowner = null;				
				gu = null;
				dt.Stop();
				dt = null;
				return;
			}
			this.NextAttackEffects.Clear();
			by.NextAttackEffects.Clear();
			if ( Summon != null )
				DismissPet( Summon.Guid );
			ReleaseAllAura();
			corpsGuid = 0;
			CorpseLocationX = X;
			CorpseLocationY = Y;
			CorpseLocationZ = Z;
			CorpseMapId = MapId;
			foreach( Object ch in this.KnownObjects )
				if ( ch is Character && ch != this )
					( ch as Character ).Player.RefreshMobileList( false );

			if ( by != null )
				by.XpEarn( this );
			this.SendSmallUpdateToPlayerNearMe( new int [] { (int)UpdateFields.UNIT_FIELD_HEALTH, (int)UpdateFields.UNIT_FIELD_FLAGS }, new object[] { 0, 0x4008 } );
		}
		float pendingTeleportX;
		float pendingTeleportY;
		float pendingTeleportZ;
		float pendingTeleportO;
		int pendingTeleportMapId;
		public void Teleport( float x, float y, float z, int mapid )
		{		
			if ( deadEndTeleportLoop )
				return;			
			if ( MapId == mapid )//|| mapid > 1 )
			{
				Teleport( x, y, z );
				return;
			}
			deadEndTeleportLoop = true;
			pendingTeleportX = x;
			pendingTeleportY = y;
			pendingTeleportZ = z;
			pendingTeleportO = Orientation;
			pendingTeleportMapId = mapid;
	//		Console.WriteLine("Teleport to {0} {1} {2} {3}", x, y, z, mapid );
			
			
			int offset = 4;
			Converter.ToBytes( (uint)0, tempBuff, ref offset );
			Send( OpCodes.SMSG_TRANSFER_PENDING, tempBuff, offset );			
			offset = 4;
			Converter.ToBytes( (int)mapid, tempBuff, ref offset );
			Converter.ToBytes( x, tempBuff, ref offset );
			Converter.ToBytes( y, tempBuff, ref offset );
			Converter.ToBytes( z, tempBuff, ref offset );
			Converter.ToBytes( Orientation, tempBuff, ref offset );
			Send( OpCodes.SMSG_NEW_WORLD, tempBuff, offset );
		//	Thread.Sleep( 10000 );
		//	this.ForcePosition(x,y,z,this.Orientation);
		}
		public void TeleportAck()
		{			
			Player.justLogged = true;
			//Thread.Sleep( 5000 );
			MapId = (ushort)pendingTeleportMapId;
			X = pendingTeleportX;
			Y = pendingTeleportY;
			Z = pendingTeleportZ;
			Orientation = pendingTeleportO;
			int offset = 4;			
			Converter.ToBytes( (int)1, tempBuff, ref offset );
			Converter.ToBytes( (byte)0, tempBuff, ref offset );
			PrepareUpdateData( tempBuff, ref offset, UpdateType.UpdateFull, false );
			Send( OpCodes.SMSG_UPDATE_OBJECT, tempBuff, offset );
			ItemsUpdate();
			lastAreaTrigger = DateTime.Now;
			/*
			ArrayList toRemove = new ArrayList();
			foreach( Object o in Player.KnownObjects )
			{
				if ( o is Mobile && o != this )
					toRemove.Add( o );
			}
			foreach( Mobile m in toRemove )
			{
				if ( m.LastSeen == this )
					m.LastSeen = null;
				DestroyObject( m.Guid );
				Player.KnownObjects.Remove( m );
			}
			Player.KnownObjects.Clear();
			Player.justLogged = true;
			//Teleport( best.X, best.Y, best.Z );
			
			account.RefreshMobileList();*/

		}
		public void Teleport( float x, float y, float z )
		{	
			if ( deadEndTeleportLoop )
				return;
			deadEndTeleportLoop = true;	
			X = x;
			Y = y;
			Z = z;
			int offset = 4;
			Converter.ToBytes( (UInt64)Guid, tempBuff, ref offset );
			Converter.ToBytes( (UInt64)0, tempBuff, ref offset );
			Converter.ToBytes( X, tempBuff, ref offset );
			Converter.ToBytes( Y, tempBuff, ref offset );
			Converter.ToBytes( Z, tempBuff, ref offset );
			Converter.ToBytes( Orientation, tempBuff, ref offset );
			account.ToAllPlayerNear( OpCodes.MSG_MOVE_TELEPORT, tempBuff, offset );
			this.ForcePosition(x,y,z,this.Orientation);
		}
		public void OnRepop()
		{
			onCharacterRepop( this );
			if ( corpsGuid == 0 )
			{
				ArrayList toRemove = new ArrayList();
				foreach( Object o in Player.KnownObjects )
				{
					if ( o is Mobile && o != this && !(( o as Mobile ).Dead ) )
						toRemove.Add( o );
				}
				foreach( Mobile m in toRemove )
				{
					if ( m.LastSeen == this )
						m.LastSeen = null;
					DestroyObject( m.Guid );
					Player.KnownObjects.Remove( m );
				}
				Corps corps = World.Add( this, X, Y, Z, MapId );	
				corpsGuid = corps.Guid;
				float rec = float.MaxValue;
				Position best = null;
				//Player.KnownObjects.Add( corps );
				//FullUpdate( Player.KnownObjects );
			/*	int offset = 4;			
				Converter.ToBytes( (int)1, tempBuff, ref offset );
				Converter.ToBytes( (byte)0, tempBuff, ref offset );
				corps.PrepareUpdateData( tempBuff, ref offset, UpdateType.UpdateFull, true );
				Send( OpCodes.SMSG_UPDATE_OBJECT, tempBuff, offset );*/

				foreach( Position pos in World.Cemetery )
				{
					float dist = QuickDistance( pos );
					if ( dist < rec )
					{
						rec = dist;
						best = pos;
					}
				}
				if ( best != null )
				{
					Teleport( best.X, best.Y, best.Z );
					/*foreach( Object o in account.KnownObjects )
					{
						Console.WriteLine("know avant {0}", o.Guid.ToString( "X16" ) );
					}*/
					account.RefreshMobileList( true );
					/*foreach( Object o in account.KnownObjects )
					{
						Console.WriteLine("know after {0}", o.Guid.ToString( "X16" ) );
					}*/
				}
				if ( this.Race == Races.NightElf )
					this.SendSmallUpdateToPlayerNearMe( new int[] { 22, 79, 111, 121, 127, 130, 180 }, new object[] { 1, 20585, 0, 0, 0xdddddddd, 0x2, 0x10 } );
				else
					this.SendSmallUpdateToPlayerNearMe( new int[] { 22, 79, 111, 121, 127, 130, 180 }, new object[] { 1, 8326, 0, 0, 0xdddddddd, 0x2, 0x10 } );
				this.account.ToAllPlayerNear( OpCodes.SMSG_UPDATE_AURA_DURATION, new byte [] { 0, 0, 0, 0, 0x20, 0xff, 0xff, 0xff, 0xff }, 9 );
				ItemsUpdate();
			}			
			//Teleport( -8935.325195f, -188.646271f, 80.416466f );
			//account.RefreshMobileList();
		}
		#endregion

		#region TOOLS

		public override bool CanSee( Object obj )
		{		
			if ( obj is GameObject )
				return ( obj as GameObject ).SeenBy( this );
			Mobile m = obj as Mobile;
			if ( !this.Dead && (uint)( m.NpcFlags & (uint)NpcActions.SpiritHealer ) > 0 )
				return false;
			if ( m is Character )
			{
				if ( m.Dead && m.Distance( this ) < 30 * 30 )
					return false;
				if ( !( m as Character ).Player.Realylogged )
					return false;																				
			}
			#region Visibility spell and gm hide ability
			if ( m != this && m.Visible != InvisibilityLevel.Visible )
			{
				if ( m.Visible == InvisibilityLevel.GM )
					return false;
				if ( m.Visible == InvisibilityLevel.Lesser )
				{
					if ( !( this.CanSeeLesserInvisibility || 
						this.CanSeeMediumInvisibility || 
						this.CanSeeMediumInvisibility ) )
						return false;
				}
				if ( m.Visible == InvisibilityLevel.Medium )
				{
					if ( !( this.CanSeeMediumInvisibility || 
						this.CanSeeMediumInvisibility ) )
						return false;
				}
				if ( m.Visible == InvisibilityLevel.Greater )
				{
					if ( !this.CanSeeMediumInvisibility )
						return false;
				}
			}
			#endregion
			if ( this.Dead )
			{
				if ( m.Distance( this ) < 100 * 100 )
					return true;
			}
			else
				if ( m.Distance( this ) < 200 * 200 )
				return true;
			return false;
		}
		void Send( byte []b )
		{
			account.Handler.Send( b );
		}
		public void Send( OpCodes op, byte []b, int len )
		{
			account.Handler.Send( op, b, len );
		}
		public void Send( OpCodes op, byte []b )
		{
			account.Handler.Send( op, b, b.Length );
		}
		public static bool GetBit( byte [] ba, int t )
		{
			return true ?  ( ((int)ba[ ( t / 8 ) ]) & ( 1 << ( ( t % 8 ) ) ) ) != 0 : false;
		}
		public static bool GetBit( BitArray ba, int t )
		{
			return ba.Get( t );
		}

/*
		public static void ObjectA9Reader( byte []data, ref int offset, int typeA9, int type2, int type3 )
		{
			int passe;
			int len;
			int decalBit;
			
		//	Console.WriteLine("Passe pour Item {0}", ( passe = data[ offset ] ).ToString( "X2" ) );
			passe = data[ offset ];
			offset++;
			len = passe * 4;//112;	

			int bitmapstart = offset;
			byte []bitMap2 = new byte[ len ];
			for(int t = 0;t < len;t++ )
			{
				Console.Write("{0}     ", ( t * 8 ).ToString( "000" ) );
			}
			Console.WriteLine( "" );
			for(int t = 0;t < len;t++ )
			{
				bitMap2[ t ] = data[ offset ];
				Console.Write("{0}      ", data[ offset ].ToString( "X2" ) );				
				offset++;
			}
			Console.WriteLine( "" );
			BitArray bitMap = new BitArray( bitMap2 );
			for(int t = 0;t < len * 8;t++ )
			{
				if ( bitMap.Get( t ) )
					Console.Write( "1" );
				else
					Console.Write( "0" );
			}
			Console.WriteLine( "" );
			//		offset++;

			if ( type2 == 0 && type3 == 1 && ( typeA9 == 0 ) )
				offset += 0xc;

			for(int t = 0;t < bitMap.Length;t++ )
			{
				//if ( t == 0xa * 8 )
				//	Console.WriteLine("");
				if ( typeA9 == (int)UpdateType.UpdatePartial )
					decalBit = -8;
				if ( t < 57 )
				{
					if ( type2==0 && type3 == 1 )//&& typeA9 != 4 )
					{
						decalBit = 0;
						if ( t == 0 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("OBJECT_GUID={0}", Converter.ToUInt64( data, ref offset ).ToString( "X16" ) );
						else
							if ( t == 1 && bitMap.Get( t + decalBit ) )
						{
						}
							//	Console.WriteLine("Unknown 1={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 2 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Id ={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 3 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknown 3={0}", Converter.ToUInt32( data, ref offset ).ToString( "X4" ) );
						else
							if ( t == 4 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("OBJECT_FIELD_SCALE_X={0}", Converter.ToFloat( data, ref offset ) );
						else
							if ( t == 6 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Guid 6={0}", Converter.ToUInt64( data, ref offset ).ToString( "X16" ) );
						else
							if ( t == 8 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknown int 8={0}", Converter.ToUInt64( data, ref offset ).ToString( "X16" ) );
						else
							if ( t == 10 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknow 10={0}", Converter.ToFloat( data, ref offset ) );
						else
							if ( t == 11 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknown 11={0}", Converter.ToFloat( data, ref offset ) );
						else
							if ( t == 12 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknow 12={0}", Converter.ToFloat( data, ref offset ) );
						else
							if ( t == 14 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("ITEM_FIELD_STACK_COUNT 14={0}", Converter.ToUInt32( data, ref offset ) );
						else
							if ( t == 15 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknown Y (15)={0}", Converter.ToFloat( data, ref offset ) );
						else
							if ( t == 16 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknow Z (16)={0}", Converter.ToFloat( data, ref offset ) );
						else
							if ( t == 17 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknown (17)={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 21 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("ITEM_FIELD_FLAGS 21={0}", Converter.ToUInt32( data, ref offset ) );
						else
							if ( t == 22 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Hp (22)={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 23 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Mana (23)={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 24 && bitMap.Get( t + decalBit ) )//en typeA9 = 4
							Console.WriteLine("Mana (24)={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 28 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Max Hp (28)={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 29 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("MaxMana(29)={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 30 && bitMap.Get( t + decalBit ) )//en typeA9 = 4
							Console.WriteLine("MaxMana(30)={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 32 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknown(32)={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 33 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknown(33)={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 34 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Level(34)={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 35 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Faction(35)={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 36 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknown 36={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 37 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknown 37={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 41 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknown 41={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 42 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknown 42={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 44 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknown 44={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 45 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknown 45={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 46 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknown 46={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 48 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknown 48 (seulement en full )={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 53 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknown 53 {0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( bitMap.Get( t + decalBit ) )
							Console.WriteLine("Type A9 = {0}, T2=0, T3=1, Empty {1}", typeA9, t );
					}
				}
			}
		}

		public static void A9Reader( byte []data, ref int offset )
		{
			int decalBit = 0;
			//int offset = 9;
			byte type = 0;
			int type2 = 0;
			int type3 = 0;
			int typeA9 = 0;
			UInt64 guid = 0;
			float x = 0;
			float y = 0;
			float z = 0;

			//Console.WriteLine("0={0}", ( pretype = Converter.ToByte( data, ref offset ) ) );
			Console.WriteLine("Type={0}", (UpdateType)( type = Converter.ToByte( data, ref offset ) ) );
			Console.WriteLine("GUID={0}", ( guid = Converter.ToUInt64( data, ref offset ) ).ToString( "X16" ) );
			if ( guid == 0x45 )
				Console.WriteLine("");
			int len = 0;
			if ( type == 2 )
			{
				typeA9 = data[ offset++ ];
				Console.WriteLine("Type A9={0}", typeA9 );
				Console.WriteLine("Unknown={0}", Converter.ToInt32( data, ref offset ) );
				Console.WriteLine("Movement mask={0}", Converter.ToInt32( data, ref offset ) );

				Console.WriteLine("X={0}", x = Converter.ToFloat( data, ref offset ) );
				Console.WriteLine("Y={0}", y = Converter.ToFloat( data, ref offset ) );
				Console.WriteLine("Z={0}", z = Converter.ToFloat( data, ref offset ) );
				Console.WriteLine("Orientation={0}", Converter.ToFloat( data, ref offset ) );

				//if ( len == 1 )
				//	offset += 12;
				//if ( typeA9 != 1 )
			{
				Console.WriteLine("RunSpeed={0}", Converter.ToFloat( data, ref offset ) );
				Console.WriteLine("WalkSpeed={0}",Converter.ToFloat( data, ref offset ) );
				Console.WriteLine("SwimSpeed={0}", Converter.ToFloat( data, ref offset ) );
				Console.WriteLine("SwimBackSpeed={0}", Converter.ToFloat( data, ref offset ) );

				Console.WriteLine("vitesse={0}", Converter.ToFloat( data, ref offset ) );
				Console.WriteLine("rotationSpeed={0}", Converter.ToFloat( data, ref offset ) );
				Console.WriteLine("new 1.3.1={0}", Converter.ToFloat( data, ref offset ) );
				Console.WriteLine("unknown2={0}", type2 = Converter.ToInt32( data, ref offset ) );
				Console.WriteLine("unknown3={0}", type3 = Converter.ToInt32( data, ref offset ) );
			}

				//Console.WriteLine("f1={0}", Converter.ToFloat( data, ref offset ) );
				//Console.WriteLine("f2={0}", Converter.ToFloat( data, ref offset ) );
				//	if ( typeA9 != 1 )
		
				offset+=0xc;
			}


			if ( x == 0f && y == 0f && z == 0f && type == 2 )
			{
				ObjectA9Reader( data, ref offset, typeA9, type2, type3 );
				return;
			}
			if ( typeA9 == 4 )
				len = 109;
			if ( typeA9 == 3 )
				len = 25;
			if ( typeA9 == 1 )
				len = 12;
			if ( type == 0 )
			{
				len = 107;
			}

			if ( type2 == 1 )
			{
				len = 109;				
			}
			byte passe = 0;
			if ( type2 == 0 && type3 == 0 && typeA9 == 0 )
			{
				Console.WriteLine("Passe {0}", ( passe = data[ offset ] ).ToString( "X2" ) );
				offset++;
				len = passe * 4;//112;				
			}
			if ( typeA9 == 4 )
			{
				Console.WriteLine("Passe {0}", ( passe = data[ offset ] ).ToString( "X2" ) );
				offset++;
				len = ( passe ) * 4;//112;				
			}
			if ( type2 == 0 && type3 == 1 && typeA9 == 3 )
			{
				len = 0x19;//0x9 + 0x12;				
			}
			if ( type2 == 0 && type3 == 1 && typeA9 == 1 )
			{
				Console.WriteLine("Passe {0}", ( passe = data[ offset ] ).ToString( "X2" ) );
				offset++;
				len = 4;
			}
			if ( type2 == 0 && type3 == 0 && typeA9 == 1 )
			{
				len = 0x19;
			}
			if ( type2 == 0 && type3 == 1 && typeA9 == 2 )
			{
				Console.WriteLine("Passe {0}", ( passe = data[ offset ] ).ToString( "X2" ) );
				offset++;
				len = 8;
			}
			if ( type2 == 0 && type3 == 1 && typeA9 == 3 )
			{
				Console.WriteLine("Passe {0}", ( passe = data[ offset ] ).ToString( "X2" ) );
				offset++;
				len = 24;
			}
			if ( type2 == 0 && type3 == 1 && typeA9 == 5 )
			{
				Console.WriteLine("Passe {0}", ( passe = data[ offset ] ).ToString( "X2" ) );
				offset++;
				len = 4;
			}
			if ( (UpdateType)typeA9 == UpdateType.UpdateMovement )
			{
				len = 4;
			}
			if ( type2 == 0 && type3 == 0 && typeA9 == 0 && passe == 6 )
			{
				len = 24;
			}
			if ( type2 == 0 && type3 == 0 && typeA9 == 0 && passe == 2 )
			{
				len = 8;
			}
			if ( typeA9 == 7 )
			{
				Console.WriteLine("Passe {0}", ( passe = data[ offset ] ).ToString( "X2" ) );
				offset++;
				len = passe * 4;//112;	
			}
			int bitmapstart = offset;
			byte []bitMap2 = new byte[ len ];
			for(int t = 0;t < len;t++ )
			{
				Console.Write("{0}     ", ( t * 8 ).ToString( "000" ) );
			}
			Console.WriteLine( "" );
			for(int t = 0;t < len;t++ )
			{
				bitMap2[ t ] = data[ offset ];
				Console.Write("{0}      ", data[ offset ].ToString( "X2" ) );				
				offset++;
			}
			Console.WriteLine( "" );
			BitArray bitMap = new BitArray( bitMap2 );
			for(int t = 0;t < len * 8;t++ )
			{
				if ( bitMap.Get( t ) )
					Console.Write( "1" );
				else
					Console.Write( "0" );
			}
			Console.WriteLine( "" );
			//		offset++;

			if ( type2 == 0 && type3 == 1 && ( typeA9 == 0 ) )
				offset += 0xc;

			for(int t = 0;t < bitMap.Length;t++ )
			{
				//if ( t == 0xa * 8 )
				//	Console.WriteLine("");
				//if ( typeA9 == (int)UpdateType.UpdatePartial )
				//	decalBit = -8;
				if ( t < 410 )
				{
					if ( type != 0 )
					{
						decalBit = 0;
					//	if ( typeA9 == 4 )
					//		decalBit = -8;
						if ( t + decalBit < 0 )
							continue;
						if ( t == Const.OBJECT_FIELD_GUID && bitMap.Get( t + decalBit ) )
							Console.WriteLine("OBJECT_GUID={0}", Converter.ToUInt64( data, ref offset ).ToString( "X16" ) );
						else
							if ( t == 1 && bitMap.Get( t + decalBit ) )
						{
							//	suite guid
						}
						else
							if ( t == 2 && bitMap.Get( t + decalBit ) )
						{
							Console.WriteLine("OBJECT_FIELD_TYPE={0}"
								, Converter.ToUInt32( data, ref offset ).ToString( "X8" ));
						}
						else
							if ( t == Const.OBJECT_FIELD_ENTRY && bitMap.Get( t + decalBit ) )
							Console.WriteLine("OBJECT_FILED_ENTRY={0}", Converter.ToUInt32( data, ref offset ) );
						else
							if ( t == Const.OBJECT_FIELD_SCALE_X && bitMap.Get( t + decalBit ) )
							Console.WriteLine("OBJECT_FIELD_SCALE_X={0}", Converter.ToFloat( data, ref offset ) );
					
						else
							if ( bitMap.Get( t + decalBit ) )
							Console.WriteLine("{0} {1} = {2}", (UpdateFields)t, t, Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
					}
					else
					{///////////	PARTIAL
						decalBit = 0;
						if ( t == 0 && bitMap.Get( t ) )
							Console.WriteLine("OBJECT_GUID={0}", Converter.ToUInt64( data, ref offset ).ToString( "X16" ) );
						else
							if ( t == 1 && bitMap.Get( t + decalBit ) )
						{
							Console.WriteLine("Guid? 2={0}"
								, Converter.ToUInt16( data, ref offset ).ToString( "X4" ));
						}
						else
							if ( t == 2 && bitMap.Get( t + decalBit ) )
						{
							Console.WriteLine("UnknownPartial2={0}"
								, Converter.ToByte( data, ref offset ).ToString( "X2" ) );
						}
						else
							if ( t == 3 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("UnknownPartial3={0}", Converter.ToByte( data, ref offset ).ToString( "X2" ) );
						else
							if ( t == 4 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("UnknownPartial4={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 5 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unk 5={0}", Converter.ToUInt32( data, ref offset ) );
						else
							if ( t == 8 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("HitPoints={0}", Converter.ToUInt32( data, ref offset ) );
						else
							if ( t == 12 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Level={0}", Converter.ToUInt32( data, ref offset ) );
						else
							if ( t == 22 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Hit Points={0}", Converter.ToUInt32( data, ref offset ) );
						else
							if ( t == 23 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("23={0}", Converter.ToUInt32( data, ref offset ) );
						else
							if ( t == 24 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Mana/Ennergy/Rage/Stamina24={0}", Converter.ToUInt32( data, ref offset ) );
						else
							if ( t == 25 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Base HitPoints25={0}", Converter.ToUInt32( data, ref offset ) );
						else
							if ( t == 26 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Base Power126={0}", Converter.ToUInt32( data, ref offset ) );
						else
							if ( t == 27 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Base Power127={0}", Converter.ToUInt32( data, ref offset ) );
						else
							if ( t == 28 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknow 28={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 29 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknow 29={0}", Converter.ToUInt32( data, ref offset ) );
						else
							if ( t == 30 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Max Mana/Rage/Ennergy(30)={0}", Converter.ToUInt32( data, ref offset ).ToString( "X4" ) );
						else
							if ( t == 31 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknown 31={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 32 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Mana/Ennergy/Rage/Stamina={0}", Converter.ToUInt32( data, ref offset ) );
						else
							if ( t == 36 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Base HitPoints={0}", Converter.ToUInt32( data, ref offset ) );
						else
							if ( t == 37 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Base Power1={0}", Converter.ToUInt32( data, ref offset ) );

						else

							if ( t == 33 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknown 33={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 34 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknown 34={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 35 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknown 35={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 38 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Base Power2={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 42 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Classe={0}", (Classes)Converter.ToByte( data, ref offset ) );
						else
							if ( t == 43 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Gender={0}", Converter.ToByte( data, ref offset ) );
						else
							if ( t == 44 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Mana Type={0}", Converter.ToByte( data, ref offset ) );
						else
							if ( t == 46 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("ukn 46={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 47 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Aura 1 47={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 48 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Aura 2 48={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 54 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknown 54={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 55 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknown 55={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( t == 56 && bitMap.Get( t + decalBit ) )
							Console.WriteLine("Unknown 56={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
						else
							if ( bitMap.Get( t + decalBit ) )
							Console.WriteLine("{0} {1} = {2}", (UpdateFields)t, t, Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
					}
				}
				else
					if ( t < 500 && bitMap.Get( t + decalBit ) )
					Console.WriteLine("Unknown {0} {1}={2}", (UpdateFields)t, t, Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
				else
					if ( t > 195 && t < 268 )
				{
					int indice = t - 202;
					if ( ( t % 2 ) == 0 && bitMap.Get( t + decalBit ) )
						Console.WriteLine("OBJECT_GUID{0}Low={1}", t, Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
					else
						if ( ( t % 2 ) == 1 && bitMap.Get( t + decalBit ) )
						Console.WriteLine("OBJECT_GUID{0}High={1}", t, Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
				}
				else
					if ( t >= (int)UpdateFields.PLAYER_SKILL_INFO_1_1 && t < 720 + 232 && bitMap.Get( t + decalBit ) )
				{
					int k = t - (int)UpdateFields.PLAYER_SKILL_INFO_1_1;

					if ( ( k % 3 ) == 0 )
						Console.WriteLine("Skills {0}", Converter.ToUInt32( data, ref offset ).ToString( "X4" ) );
					else
						if ( ( k % 3 ) == 1 )			
					{
						Console.WriteLine("Value {0}", Converter.ToUInt16( data, ref offset ).ToString( "X4" ) );
						Console.WriteLine("Max {0}", Converter.ToUInt16( data, ref offset ).ToString( "X4" ) );
					}
				
					else
						if ( ( k % 3 ) == 2 )
						Console.WriteLine("Unk {0}", Converter.ToUInt32( data, ref offset ).ToString( "X4" ) );
				}
				else
					if ( t == 723 && bitMap.Get( t + decalBit ) )
					Console.WriteLine("Unknown 726={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
				else
					if ( t == 724 && bitMap.Get( t + decalBit ) )
					Console.WriteLine("Unknown 726={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
				else
					if ( t == 725 && bitMap.Get( t + decalBit ) )
					Console.WriteLine("Unknown 726={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );				
	
				else
					if ( t == 829 + 232 )
				{
					if ( bitMap.Get( t + decalBit ) )
						Console.WriteLine("XP Rate={1}", t, Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
				}
				else
					if ( t == 830 + 232 && bitMap.Get( t + decalBit ) )
					Console.WriteLine("Copper(830 + 232)={0}", Converter.ToUInt32( data, ref offset ) );
				else
					if ( t == 831 && bitMap.Get( t + decalBit ) )
					Console.WriteLine("Unknown 831={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
				else
					if ( t == 832 && bitMap.Get( t + decalBit ) )
					Console.WriteLine("Unknown 832={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
				else
					if ( t == 833 && bitMap.Get( t + decalBit ) )
					Console.WriteLine("Unknown 833={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
				else
					if ( t == 834 && bitMap.Get( t + decalBit ) )
					Console.WriteLine("Unknown 834={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
				else
					if ( t == 835 && bitMap.Get( t + decalBit ) )
					Console.WriteLine("Unknown 835={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
				else
					if ( t == 855 && bitMap.Get( t + decalBit ) )
					Console.WriteLine("XP={0}", Converter.ToUInt32( data, ref offset ) );
				else
					if ( t == 862 && bitMap.Get( t + decalBit ) )
					Console.WriteLine("862={0}", Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
				else
					if ( t == 869 && bitMap.Get( t + decalBit ) )
					Console.WriteLine("Attack bonus ratio={0}", Converter.ToFloat( data, ref offset ) );
				else
					if ( t == 877 && bitMap.Get( t + decalBit ) )
					Console.WriteLine("Ammo type ={0}", Converter.ToInt32( data, ref offset ) );
				else
					if ( bitMap.Get( t + decalBit ) )
					Console.WriteLine("Unknown {0} {1}={2}", (UpdateFields)t, t, Converter.ToUInt32( data, ref offset ).ToString( "X8" ) );
			}
		}

		public void Trace()
		{
			byte []b4 = new byte[] {0x00, 0x31, 0x96, 0x00, 0x0A, 0x00, 0x00, 0x00, 0x00, 0x32, 0x36, 0x21, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1D, 0x00, 0x00, 0x00, 0x57, 0x65, 0x6C, 0x63, 0x6F, 0x6D, 0x65, 0x20, 0x74, 0x6F, 0x20, 0x57, 0x6F, 0x72, 0x6C, 0x64, 0x20, 0x6F, 0x66, 0x20, 0x57, 0x61, 0x72, 0x63, 0x72, 0x61, 0x66, 0x74, 0x00, 0x00};
			int offset = 9;
			Converter.ToBytes( Guid, b4, ref offset );
			Player.Handler.Send( 0x96, b4 );
		}
		public static void F6Reader( byte []data )
		{
			int offset = 0;
			int len = BitConverter.ToInt32( data, 0 );
			offset+=5;
			for(int t = 0;t < len;t++ )
			{
				Console.WriteLine( "------------- 1F6 part {0} -------------", t );
				A9Reader( data, ref offset );				
			}
		}
		public static void F6Reader( string a )
		{
			string []spl = a.Split( new char[]{ ' ' } );
			byte []b = new byte[ spl.Length ];
			int t = 0;
			
			foreach( string s in spl )
			{
				if ( s.Length == 0 )
					continue;
				b[ t++ ] = Convert.ToByte( s, 16 );				
			}
			F6Reader( b );
		}
		public static void CompressedF6Reader( string a )
		{
			string []spl = a.Split( new char[]{ ' ' } );
			byte []b = new byte[ spl.Length ];
			int t = 0;
			
			foreach( string s in spl )
			{
				if ( s.Length == 0 )
					continue;
				b[ t++ ] = Convert.ToByte( s, 16 );				
			}
			byte []decomp = Zip.DeCompress( b );
			F6Reader( decomp );
		}*/
		#endregion

		#region SPELLS
		public override bool OnCastSpellCMSG(byte[] data,int after,ushort type)
		{
			if ( firstHitCombatTimer != null || combatTimer != null )
			{
				StopAttacking();
			}
			return base.OnCastSpellCMSG( data, after, type );
		}
		void CancelAura( int id )
		{
			if(!this.ChannelEnd(id)) 
				ReleaseAura( (AuraEffect)Abilities.abilities[ id ] );
		}
		public override void ItemTargetCastSpell(UInt64 targetGuid, int spell, ushort type )
		{

			StopAttacking();
			Item target = FindItemByGuid( targetGuid );
			if ( target == null )
				return;
			if ( HaveSpell( spell ) )
			{
				#region cast creation
			{
				BaseAbility ba;
				try
				{
					ba = (BaseAbility)Abilities.abilities[spell];
				}
				catch
				{
					if (spell == 0)
						Console.WriteLine("SpellError 0001: Not id given by CMSG_SPELL_CAST");
					else Console.WriteLine("SpellError 0002: Not able to create BaseAbility" + "ID:" + spell);
					return;
				}
				if (ba is SpellTemplate)
				{
					SpellTemplate st;
					try
					{
						st = (SpellTemplate)ba;
					}
					catch
					{
						Console.WriteLine("SpellError 0003: Not able to cast BaseAbility to SpellTemplate" + "ID:" + spell);
						return;
					}
					try
					{
						this.cast.castingtime = st.CastingTime(this);
						this.cast.cool = st.CoolDown(this);
						this.cast.id = st.Id;
						this.cast.manacost = st.GetManaCost(this);
						this.cast.type = type;
						this.cast.baseability = st;
					}
					catch
					{
						Console.WriteLine("SpellError 0004: Error in Mobile.cast assigment for SpellTemplate" + "ID:" + spell);
						return;
					}
				}
				else
				{
					try
					{
						this.cast.castingtime = ba.CastingTime(this);
						this.cast.cool = ba.CoolDown(this);
						this.cast.id = ba.Id;
						this.cast.manacost = 0;
						this.cast.type = type;
						this.cast.baseability = ba;
					}
					catch
					{
						Console.WriteLine("SpellError 0005: Error in Mobile.cast assigment for BaseAbility" + "ID:" + spell);
						return;
					}
				}
			}
				#endregion
				base.SetTarget( type, spell, target );
			}
		}

		public override void OnSpellCasted(  Object target )
		{
			if ( onSpellCasted != null )
				if ( onSpellCasted( this, cast.id, target ) )
					return;
			Profession prof = null;
			BaseAbility ba = (BaseAbility)Abilities.abilities[ cast.id ];
			if ( ba is CraftTemplate )
				( ba as CraftTemplate ).Create(cast, this );
			else
				switch( cast.id )
				{
					case 7620://	Fishing
					case 7731:
					case 7732:
					case 18248:
						prof = (Profession)this.AllSkills[ 356 ];
						prof.UseFishing( cast, this );
						break;
					case 2575:					
					case 2576:
					case 2577://	Mining						
					case 2578:
					case 2579:
					case 13611:					
						prof = (Profession)this.AllSkills[ 186 ];
						prof.UseMining(cast, this, (GameObject)target );
						break;
					case 2366:
					case 2368://	Herborist
					case 3570:
					case 11993:
						prof = (Profession)this.AllSkills[ 0xB6 ];
						prof.UseHerbalist(cast, this, (GameObject)target );
						break;	
					case 8613://	Skinning
					case 8617:
					case 8618:
					case 10768:			
					case 393:
							prof = (Profession)this.AllSkills[ 393 ];
							prof.UseSkinning(cast, this, (Mobile)target );
						
						break;
/*					case 0x9F6://	Cooking
					case 0xc1E:
					case 0xd55:
					case 0x4754:
						prof = (Profession)this.AllSkills[ 185 ];
						prof.UseCooking( this, (GameObject)target );
						break;
					case 0xFC4://	Enginering
					case 0xFC5:
					case 0xFC6:
					case 0x3170:
						prof = (Profession)this.AllSkills[ 202 ];
						prof.UseEnginering( this, (GameObject)target );
						break;
					case 0x1CF3://	Enchanting
					case 0x1CF4:
					case 0x1CF5:
					case 0x3660:
						prof = (Profession)this.AllSkills[ 333 ];
						prof.UseEnchanting( this, (GameObject)target );
						break;
					case 0x83C://	Leatherworking
					case 0xC20:
					case 0xEE3:
					case 0x29A6:
						prof = (Profession)this.AllSkills[ 0xA5 ];
						prof.UseLeatherworking( this, (GameObject)target );
						break;
					case 0xCC9://	FirstAid
					case 0xCCA:
					case 0x1EF4:
					case 0x2A5E:
						prof = (Profession)this.AllSkills[ 129 ];
						prof.UseFirstAid( this, (GameObject)target );
						break;
					case 0xF44://	Tailoring
					case 0xF45:
					case 0xF46:
					case 0x2F94:
						prof = (Profession)this.AllSkills[ 197 ];
						prof.UseTailoring( this, (GameObject)target );
						break;*/
					case 0xA61://	Smelt casted
						( Abilities.abilities[ 0xA61 ] as CraftTemplate ).Create(cast, this );
						break;
					default:
						if ( ba is SpellTemplate )
						{
							base.OnSpellTemplateResults( ba,  target );
							SpellSuccess();
							break;
						}
						SpellSuccess();
						break;
						
				}
			
		}
			#region AURA
		public override PermanentAura AddPermanentAura( AuraEffect ae, Aura a )
		{
			PermanentAura paura = new PermanentAura(a,ae.Id);
			this.permanentAura.Add(paura);
			this.AdjustBonii();
			return paura;
		}

		public void AdjustBonii()
		{
			HitPoints += HealthBonus;
			Mana += ManaBonus;
#if TESTCONSECUTIF
			activateorder = true;
			Object.order = 0;
#endif
			SendSmallUpdate( new int[] { 
											 (int)UpdateFields.UNIT_FIELD_HEALTH,
											 (int)UpdateFields.UNIT_FIELD_POWER1 + ManaType,
											 (int)UpdateFields.UNIT_FIELD_MAXHEALTH,
											 (int)UpdateFields.UNIT_FIELD_MAXPOWER1 + ManaType,
												(int)UpdateFields.UNIT_FIELD_BASEATTACKTIME,
												(int)UpdateFields.UNIT_FIELD_BASEATTACKTIME + 1,
												
										   
											 (int)UpdateFields.UNIT_FIELD_STR,
											 (int)UpdateFields.UNIT_FIELD_AGILITY,
											 (int)UpdateFields.UNIT_FIELD_STAMINA,
										     (int)UpdateFields.UNIT_FIELD_SPIRIT,
											 (int)UpdateFields.UNIT_FIELD_IQ,											 
											 (int)UpdateFields.UNIT_FIELD_ARMOR,
											 (int)UpdateFields.UNIT_FIELD_ARMOR + 1,
											 (int)UpdateFields.UNIT_FIELD_ARMOR + 2,
											 (int)UpdateFields.UNIT_FIELD_ARMOR + 3,
											 (int)UpdateFields.UNIT_FIELD_ARMOR + 4,
											 (int)UpdateFields.UNIT_FIELD_ARMOR + 5,
											 (int)UpdateFields.UNIT_FIELD_ARMOR + 6, 
											 (int)UpdateFields.UNIT_FIELD_ATTACKPOWER,
											 (int)UpdateFields.UNIT_FIELD_ATTACK_POWER_MODS,
											 
											 (int)UpdateFields.PLAYER_FIELD_POSSTAT0,
											 (int)UpdateFields.PLAYER_FIELD_POSSTAT0 + 1,
											 (int)UpdateFields.PLAYER_FIELD_POSSTAT0 + 2,
											 (int)UpdateFields.PLAYER_FIELD_POSSTAT0 + 3,
											 (int)UpdateFields.PLAYER_FIELD_POSSTAT0 + 4,

											 (int)UpdateFields.PLAYER_FIELD_NEGSTAT0,
											 (int)UpdateFields.PLAYER_FIELD_NEGSTAT0 + 1,
											 (int)UpdateFields.PLAYER_FIELD_NEGSTAT0 + 2,
											 (int)UpdateFields.PLAYER_FIELD_NEGSTAT0 + 3,
											 (int)UpdateFields.PLAYER_FIELD_NEGSTAT0 + 4,

											 (int)UpdateFields.PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE,
											 (int)UpdateFields.PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE + 1,
											 (int)UpdateFields.PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE + 2,
											 (int)UpdateFields.PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE + 3,
											 (int)UpdateFields.PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE + 4,
											 (int)UpdateFields.PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE + 5,
											 (int)UpdateFields.PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE + 6  }, 

				new object[] { HitPoints, Mana, BaseHitPoints, BaseMana,
								 this.AttackSpeed,this.AttackSpeed,// this.AttackPowerBonus,
								 Str, Agility, Stamina, Iq, Spirit, Armor, ResistHoly, ResistFire, ResistNature, ResistFrost, ResistShadow, ResistArcane,								 
								 this.AttackPower,this.AttackPowerBonus,
								 StrBonus, AgBonus, StaminaBonus, IQBonus, SpiritBonus, StrMalus, AgMalus, StaminaMalus, IQMalus, SpiritMalus, 
								 ArmorBonus, 
								 HolyResistanceBonus, FireResistanceBonus, NatureResistanceBonus, FrostResistanceBonus, ShadowResistanceBonus, ArcaneResistanceBonus,
								 HolyResistanceMalus, FireResistanceMalus, NatureResistanceMalus, FrostResistanceMalus, ShadowResistanceMalus, ArcaneResistanceMalus,
			} );
#if TESTCONSECUTIF
			activateorder = false;
			Object.order = 0;
#endif			
		}
			#endregion

		#endregion

		#region COMBAT
		public /*override */void FaitFace( Mobile from )
		{
			Orientation = (float)Math.Atan2( from.Y - Y, from.X - X );
		}

		class CombatTimer : WowTimer
		{
			Character from;
			public UInt64 target;
			public CombatTimer( UInt64 targ, Character c, int delay ) : base( WowTimer.Priorities.Milisec100 , delay, "CombatTimer" )
			{
				target = targ;
				from = c;
				Start();
			}
			public override void OnTick()
			{
				from.OnCombatTick( this );
				base.OnTick ();
			}
		}
		private class FirstHitCombatTimer : WowTimer
		{
			Character from;
			public FirstHitCombatTimer( Character c ) : base( WowTimer.Priorities.Milisec100 , 100, "FirstHitCombatTimer" )
			{
				from = c;
				Start();
			}
			public override void OnTick()
			{
				//Stop();
				from.OnFirstHit();
				base.OnTick();
			}
		}
	//	Mobile AttackTarget;
		
		CombatTimer combatTimer;
		FirstHitCombatTimer firstHitCombatTimer;
		byte []tooFar = { 0x00, 0x02, 0x45, 0x01 };

		public void StopAttacking()
		{
			if ( firstHitCombatTimer != null )
			{
				firstHitCombatTimer.Stop();
				firstHitCombatTimer = null;
			}
			if ( combatTimer != null )
			{
				combatTimer.Stop();
				combatTimer = null;
			}
			if ( AttackTarget == null )
				return;
			int offset = 4;
			Converter.ToBytes( Guid, tempBuff, ref offset );
			Converter.ToBytes( AttackTarget.Guid, tempBuff, ref offset );
			Converter.ToBytes( 0, tempBuff, ref offset );
			account.ToAllPlayerNear( OpCodes.SMSG_ATTACKSTOP, tempBuff, offset );
			AttackTarget = null;
		}
		public class HandsFighting : Item
		{
			public HandsFighting()
			{
				SetDamage( 0.2f, 0.5f, Resistances.Armor );
				Delay = 2000;
			}
		}
		public static HandsFighting handToHand = new HandsFighting();

		public override Item ChooseWeapon()
		{
			Item weapon = Items[ (int)Slots.MainHand ];	
			if ( weapon == null )
			{
				weapon = Items[ (int)Slots.OffHand ];
				if ( weapon == null || weapon.PhysicalMinDamage == 0 )
				{
					weapon = Items[ (int)Slots.Ranged ];
					if ( weapon == null )
						return handToHand;
					else
						return weapon;
				}
			}			
			else
				return weapon;
			return Character.handToHand;
		}
		
		public override int AttackSwing( UInt64 target )
		{				
			if ( target > 0xF100000000000000 )
				return 0;
			Mobile m = account.FindMobileByGuid( target );
			if ( m == null )
				return 0;
			int offset = 4;
			AttackTarget = m;
			Converter.ToBytes( Guid, tempBuff, ref offset );
			Converter.ToBytes( target, tempBuff, ref offset );
			account.ToAllPlayerNear( OpCodes.SMSG_ATTACKSTART, tempBuff, offset );

			activeWeapon = ChooseWeapon();
			

			SetDamage( activeWeapon.PhysicalMinDamage, activeWeapon.PhysicalMaxDamage );
			
			if ( firstHitCombatTimer != null || combatTimer != null )
				return 0;//	deja un timer en place
			firstHitCombatTimer = new FirstHitCombatTimer( this );
			return 0;
		}

		int compteur;
		public void OnFirstHit()
		{
			if ( AttackTarget == null )
			{
				StopAttacking();
				return;
			}
//#if DEBUG
			//Console.WriteLine("Reputation {0}/{1}", this.Reputation( AttackTarget ) );
//#endif
			if ( AttackTarget is BaseCreature )
				AttackTarget.UpdateXYZ();
			if ( Mobile.GetDirection( this as Mobile, AttackTarget ) != Pos.Front )
			{
				account.ToAllPlayerNear( OpCodes.SMSG_ATTACKSWING_BADFACING, tempBuff, 4 );
				return;
			}
			float dist = Distance( AttackTarget );
			if ( dist < 11 * ( AttackTarget.CombatReach + CombatReach ) )
			{				
				lastDistance = dist;
				if ( firstHitCombatTimer != null )
					firstHitCombatTimer.Stop();
				firstHitCombatTimer = null;
				FaitFace( AttackTarget );
				int amountAbsorbed = 0;
				int amountBlocked = 0;
				Hit( AttackTarget, ref amountAbsorbed, ref amountBlocked );
				//Hit( AttackTarget );
				combatTimer = new CombatTimer( AttackTarget.Guid, this, activeWeapon.Delay / 3 );
			}
			else
			{
				compteur++;
				if ( compteur % 10 == 1 )
				{
				/*	SendMessage( "" + X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() + " / " +
						AttackTarget.X.ToString() + ", " + AttackTarget.Y.ToString() + ", " + AttackTarget.Z.ToString() + " dist = " + Distance( AttackTarget ).ToString() );*/
					account.ToAllPlayerNear( OpCodes.SMSG_ATTACKSWING_NOTINRANGE, tooFar, 4 );
				}
			}

		}
		public float lastDistance;
		byte []hitBuffer = { 0x00, 0x3F, 0x4A, 0x01, 0x06, 0x00, 0x00, 0x00, 0x9B, 0x36, 0x21, 0x00, 0x00, 0x00, 0x00, 0x00, 0x91, 0x14, 0x21, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0A, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x20, 0x41, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0xE8, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
		DateTime last = DateTime.Now;
		//static int aaa = 0;
		void OnCombatTick( CombatTimer from )
		{
			combatTimer.Delay = activeWeapon.Delay;
			if ( AttackTarget == null || from.target != AttackTarget.Guid )
			{
				StopAttacking();
				from.Stop();
				return;
			}
			TimeSpan ts = DateTime.Now.Subtract( last );

			if ( AttackTarget == null )
			{
				StopAttacking();
				return;
			}
			if ( AttackTarget.Dead )
			{
				StopAttacking();
				AttackTarget = null;
			}
			if ( AttackTarget is BaseCreature )
				AttackTarget.UpdateXYZ();
			if ( Mobile.GetDirection( this as Mobile, AttackTarget ) != Pos.Front )
			{
				account.ToAllPlayerNear( OpCodes.SMSG_ATTACKSWING_BADFACING, tempBuff, 4 );
				return;
			}
			float dist = Distance( AttackTarget );
			
			lastDistance = dist;

			if ( dist < 11 * ( AttackTarget.CombatReach + CombatReach ) )
			{
				
				if(this.AttackTarget != null)
				{
					ArrayList arr1 = new ArrayList();
					foreach(NextAttackEffect nae in this.NextAttackEffects)
					{
						
						bool ok = false;
						this.OnSpellTemplateResults(nae.spell,this.AttackTarget);
						this.NextAttackSpellGo( nae );
						this.SpellSuccess();
						if(nae.onEffect is NextAttackEffectDelegate)
						{
							NextAttackEffectDelegate naed = (NextAttackEffectDelegate)nae.onEffect;
							ok = naed(nae.spell,this,this.AttackTarget,nae.number);
						}
						if(nae.onEffect is NextAttackEffectDelegateMultiple)
						{
							ArrayList all = new ArrayList();
							NextAttackEffectDelegateMultiple naed = (NextAttackEffectDelegateMultiple)nae.onEffect;
							ok = naed(nae.spell,this,this.AttackTarget,all, nae.number);
						}
						if(ok)
							arr1.Add(nae);
						else nae.number++;
					}
					foreach(NextAttackEffect nae in arr1)
						this.NextAttackEffects.Remove(nae);
					arr1.Clear();
				}
				FaitFace( AttackTarget );
				int amountBlocked = 0;
				int amountAbsorbed = 0;
				int degats = Hit( AttackTarget, ref amountBlocked, ref amountAbsorbed );
				int offset = 4;
				if ( degats <= 0 )
					Converter.ToBytes( 0x1, tempBuff, ref offset );
				else
				{
					if ( this.Items[ (int)Slots.OffHand ] == null ||
						this.Items[ (int)Slots.OffHand ].IsShield ||
						Utility.Random( 2 ) == 0 )
						Converter.ToBytes( 0xE2, tempBuff, ref offset );
					else
						Converter.ToBytes( 0x2E2, tempBuff, ref offset );
				}
	
				Converter.ToBytes( Guid, tempBuff, ref offset );
				Converter.ToBytes( AttackTarget.Guid, tempBuff, ref offset );
				if ( degats < 0 )
					Converter.ToBytes( 0, tempBuff, ref offset );
				else
					Converter.ToBytes( degats, tempBuff, ref offset );
				Converter.ToBytes( (byte)1, tempBuff, ref offset );
				Converter.ToBytes( 0, tempBuff, ref offset );
				if ( degats > 0 )
					Converter.ToBytes( (float)degats/*DamageType*/, tempBuff, ref offset );
				else
					Converter.ToBytes( 0, tempBuff, ref offset );

				//		Converter.ToBytes( 0/*DamageType*/, tempBuff, ref offset );
				//		float ang = (float)Math.Atan2( AttackTarget.Y - Y, AttackTarget.X - X );
				if ( degats < 0 )
					Converter.ToBytes( 0, tempBuff, ref offset );
				else
					Converter.ToBytes( degats, tempBuff, ref offset );
				//	Converter.ToBytes( amountAbsorbed, tempBuff, ref offset );// damage absorbed 
				//	Converter.ToBytes( 0, tempBuff, ref offset ); // new victim state
				Converter.ToBytes( 0, tempBuff, ref offset ); // additional spell damage id
				Converter.ToBytes( 0, tempBuff, ref offset ); // additional spell damage id
				#region Degats types
				if ( degats >= 0 )
					Converter.ToBytes( 1, tempBuff, ref offset );
				else
					if ( degats == -1 )
					Converter.ToBytes( 2, tempBuff, ref offset );// dodge
				else
					if ( degats == - 2 )
					Converter.ToBytes( 9, tempBuff, ref offset );// parry
				else
					if ( degats == - 3 )
					Converter.ToBytes( 4, tempBuff, ref offset );// interrupted
				else
					if ( degats == - 4 || amountBlocked > 0 )
					Converter.ToBytes( 5, tempBuff, ref offset );// block
				else
					if ( degats == - 5 )
					Converter.ToBytes( 6, tempBuff, ref offset );// evade
				else
					if ( degats == - 6 )
					Converter.ToBytes( 7, tempBuff, ref offset );// immune
				else
					if ( degats == - 7 )
					Converter.ToBytes( 8, tempBuff, ref offset );// deflect

				#endregion
		
				if ( degats == 0 )
					Converter.ToBytes( 0xffffffff, tempBuff, ref offset );
				else
					Converter.ToBytes( 0, tempBuff, ref offset );
				Converter.ToBytes( 0, tempBuff, ref offset );
				Converter.ToBytes( 0, tempBuff, ref offset );
				ToAllPlayerNear( OpCodes.SMSG_ATTACKERSTATEUPDATE, tempBuff, offset );					

				AttackTarget.LooseHits( this, degats, true );
			}
			else
				account.ToAllPlayerNear( OpCodes.SMSG_ATTACKSWING_NOTINRANGE, tooFar, 4 );

			if ( AttackTarget.Dead )
			{
				int off = 4;
				Converter.ToBytes( Guid, tempBuff, ref off );
				Converter.ToBytes( AttackTarget.Guid, tempBuff, ref off );
				account.ToAllPlayerNear( OpCodes.SMSG_ATTACKSTOP, tempBuff, off );
				StopAttacking();
				AttackTarget = null;
			}
		}
		#endregion

		#region PACKET MANAGER
		public override void ToAllPlayerNear( OpCodes code, byte []data )
		{
			account.ToAllPlayerNear( code, data );
		}
		public override void ToAllPlayerNear( OpCodes code, byte []data, int len )
		{
			account.ToAllPlayerNear( code, data, len );
		}
		public override void ToAllPlayerNear( OpCodes code, byte []data, int after, int len )
		{
			account.ToAllPlayerNear( code, data, after, len );
		}
		public override void ToAllPlayerNearExceptMe( OpCodes code, byte []data, int after, int len )
		{
			account.ToAllPlayerNearExceptMe( code, data, after, len );
		}
		public override void ToAllPlayerNearExceptMe( OpCodes code, byte []data, int len )
		{
			account.ToAllPlayerNearExceptMe( code, data, len );
		}
		#endregion

		#region GROUP
		public void SetLootMethod( int method )
		{

		}
		
		Group group = new Group();
		public Group GroupMembers
		{
			get { return group; }
		}
		public ArrayList pendingGroupRequest = new ArrayList();

		void GroupInvite( string name )
		{
			foreach( Character c in account.PlayersNear )
				if ( c.Name == name )
				{
					int offset = 4;
					Converter.ToBytes( Name, tempBuff, ref offset );
					Converter.ToBytes( (byte)0, tempBuff, ref offset );
					c.Send( OpCodes.SMSG_GROUP_INVITE, tempBuff, offset );
					offset = 4;
					Converter.ToBytes( 1, tempBuff, ref offset );
					Converter.ToBytes( Name, tempBuff, ref offset );
					Converter.ToBytes( (byte)0, tempBuff, ref offset );
					Converter.ToBytes( 2, tempBuff, ref offset );
					Converter.ToBytes( 3, tempBuff, ref offset );
					c.Send( OpCodes.SMSG_PARTY_COMMAND_RESULT, tempBuff, offset );		
					if ( group == null || group.Count == 0 )
					{
						group = new Group();
						group.Add( this, 0x101 );
					}
					World.PendingGroup.Add( c );
					World.PendingGroup.Add( this );
					return;
				}
		}
		void GroupAccept()
		{
			for(int t = 0;t < World.PendingGroup.Count;t+=2 )
			{
				if ( World.PendingGroup[ t ] == this )
				{
					Character ch = (Character)World.PendingGroup[ t + 1 ];
					group = ch.GroupMembers;
					group.Add( this );
					World.PendingGroup.Remove( ch );
					World.PendingGroup.Remove( this );
				}
			}
		}
		void GroupDecline()
		{
			for(int t = 0;t < World.PendingGroup.Count;t+=2 )
			{
				if ( World.PendingGroup[ t ] == this )
				{
					int offset = 4;
					Converter.ToBytes( Name, tempBuff, ref offset );
					Converter.ToBytes( (byte)0, tempBuff, ref offset );
					( World.PendingGroup[ t + 1 ] as Character ).Send( OpCodes.SMSG_GROUP_DECLINE, tempBuff, offset );
					World.PendingGroup.RemoveAt( t );
					World.PendingGroup.RemoveAt( t );
					return;
				}
			}
		}
		void GroupSetLeader( string name )
		{
			foreach( Character c in account.PlayersNear )
				if ( c.Name == name )
					group.PromoteLeader( c );
		}
		public void QuitGroup()
		{
			if ( group == null )
				return;
			group.Quit( this );
			group = null;
		}
		public void GroupUninvite( string name )
		{
			foreach( Character c in account.PlayersNear )
				if ( c.Name == name )
					c.QuitGroup();					
		}
		#endregion

		#region TALENTS
		public override void LearnTalent( int num, int lev )
		{
			if ( Talent <= 0 )
				return;
			if ( TalentDescription.all[ num ] != null )
			{
				base.LearnTalent( num, lev );
				TalentDescription td = (TalentDescription)TalentDescription.all[ num ];
				if ( lev > 0 )
				{					
					UnLearnSpell( td.AuraFXId( lev - 1 ) );
					//PermanentAura.Remove( td.AuraFX( lev - 1 ) );
				}
			
			//	PermanentAura.Add( td.AuraFX( lev ) );
				Talent--;
				//Console.WriteLine( "{0} learn {1} at level {2}", this.Name, td.AuraFXId( lev ), lev );
				LearnSpell( td.AuraFXId( lev ) );
				///// Why this Bovie ??? the talent do not increase in all the case !
				/*
				if ( SpellTemplate.SpellEffects[ td.AuraFXId( lev )] != null )
				{
					if (!(SpellTemplate.SpellEffects[ td.AuraFXId( lev )] is PermanentSpellEffect))
					{
						LearnSpell( td.AuraFXId( lev ) );
					}
				}
				*/

				/*offset = 4;
				Converter.ToBytes( td.AuraFXId( lev ), tempBuff, ref offset );
				Send( OpCodes.SMSG_LEARNED_SPELL, tempBuff, offset );*/
				this.SendSmallUpdate( new int[] { (int)/*952*/UpdateFields.PLAYER_CHARACTER_POINTS1 }, new object[] { Talent } );
			}
			else
				Console.WriteLine( "{0} learn {1} at level {2}", Name, num, lev );
		}
		#endregion
	}
}
