// Created by: DrNexus
//  Changed by: Volhv
using System;
using System.Collections;
using System.Reflection;

using Server.Items;
using Server.Creatures;

namespace Server
{
	#region Enums, changed: 23.09.05

	#region DialogStatus
	/// <summary>
	/// Dialog status
	/// </summary>
	public enum DialogStatus: byte
	{								 // Symbol,	Color,	Chat,	Number
		ChatUnAvailable			= 0, // x,		x,		no,		num = 0
		QuestUnAvailable		= 1, // !,		White,	no,		num = 1
		ChatAvailable			= 2, // x,		x,		yes,	num = 2
		QuestUnCompleate		= 3, // ?,		White,	no,		num = 3
		RepeatQuestCompleate	= 4, // ?,		Blue,	yes,	num = 4
		SingleQuestAvailable	= 5, // !,		Gold,	yes,	num = 5
		SingleQuestCompleate	= 6, // ?,		Gold,	yes,	num = 6 and 7 (equal)
		None					= 0
	}
	#endregion

	#region Races, Classes, Skills
	public enum qRaces
	{
		Any = 0,
		Horde = 1,
		Alliance = 2,
		Human = 3,
		Dwarf = 4,
		NightElf = 5,
		Gnome = 6,
		Orc = 7,
		Undead = 8,
		Tauren = 9,
		Troll = 10
	}
	public enum qClasses
	{
		Any = 0,
		Warrior = 1,
		Paladin = 2,
		Hunter = 3,
		Rogue = 4,
		Priest = 5,
		Shaman = 7,
		Mage = 8,
		Warlock = 9,
		Druid = 11,
	}
	public enum qSkills
	{
		Balance = 574,
		Fury = 256,
		Holy = 594,
		Lockpicking = 633,
		Pet_Hyena = 654,
		Pet_Owl = 655,
		Pet_Wind_Serpent = 656,
		Language_Gutterspeak = 673,
		Defense = 95,
		Enchanting = 333,
		Mining = 186,
		Swords = 43,
		Two_Handed_Swords = 55,
		Kodo_Riding = 713,
		Racial_Troll = 733,
		Racial_Gnome = 753,
		Racial_Human = 754,
		Daggers = 173,
		GENERIC_DND = 183,
		Retribution = 184,
		Pet_Felhunter = 189,
		Tailoring = 197,
		Pet_Voidwalker = 204,
		Pet_Succubus = 205,
		Pet_Infernal = 206,
		Pet_Wolf = 208,
		Pet_Cat = 209,
		Pet_Bear = 210,
		Pet_Boar = 211,
		Pet_Crocilisk = 212,
		Pet_Carrion_Bird = 213,
		Pet_Crab = 214,
		Pet_Raptor = 217,
		Pet_Tallstrider = 218,
		Racial_Undead = 220,
		Crossbows = 226,
		Wands = 228,
		Polearms = 229,
		Destruction = 593,
		Restoration = 573,
		Pet_Turtle = 251,
		Protection = 257,
		Plate_Mail = 293,
		Protection_ = 267,
		Fire = 8,
		Guns = 46,
		Pet_Talents = 270,
		Language_Common = 98,
		Orc_Racial = 125,
		Language_Troll = 315,
		Language_Demon_Tongue = 139,
		Ram_Riding = 152,
		Demonology = 354,
		Affliction = 355,
		Leatherworking = 165,
		Feral_Combat = 134,
		Enhancement = 373,
		Restoration_ = 374,
		Elemental_Combat = 375,
		Cloth = 415,
		Pet_Scorpid = 236,
		Arcane = 237,
		Raptor_Riding = 533,
		Mechanostrider_Piloting = 553,
		Undead_Horsemanship = 554,
		Pet_Imp = 188,
		Skinning = 393,
		Language_Orcish = 109,
		Tauren_Racial = 124,
		Shield = 433,
		Language_Thalassian = 137,
		Fist_Weapons = 473,
		Language_Titan = 140,
		Wolf_Riding = 149,
		Two_Handed_Maces = 160,
		Assassination = 253,
		Language_Gnomish = 313,
		Discipline = 613,
		Pet_Bat = 653,
		Mail = 413,
		Leather = 414,
		Bows = 45,
		Thrown = 176,
		Frost = 6,
		Arms = 26,
		Combat = 38,
		Subtlety = 39,
		Poisons = 40,
		Axes = 44,
		Beast_Mastery = 50,
		Survival = 51,
		Holy_ = 56,
		Shadow_Magic = 78,
		Dwarven_Racial = 101,
		Language_Dwarven = 111,
		Language_Darnassian = 113,
		Language_Taurahe = 115,
		Dual_Wield = 118,
		Night_Elf_Racial = 126,
		Staves = 136,
		Language_Draconic = 138,
		Language_Old_Tongue = 141,
		Survival_ = 142,
		Horse_Riding = 148,
		Tiger_Riding = 150,
		Swimming = 155,
		Marksmanship = 163,
		Blacksmithing = 164,
		Two_Handed_Axes = 172,
		Pet_Spider = 203,
		Pet_Doomguard = 207,
		Pet_Gorilla = 215,
		Beast_Training = 261,
		Engineering = 202,
		Fishing = 356,
		Alchemy = 171,
		Maces = 54,
		Herbalism = 182,
		First_Aid = 129,
		Cooking = 185,
		Unarmed = 162
	}
	#endregion

	#region QuestType, TypeNpcObj
	/// <summary>
	/// Type of the quest
	/// </summary>
	public enum QuestType:byte
	{
		None	= 0,
		PvP		= 41,
		Life	= 21,
		Elite	= 1,
		Raid	= 62,
		Dungeon	= 81
	}
	/// <summary>
	/// Type of NPCObjective
	/// </summary>
	public enum TypeNpcObj: byte
	{
		Mobile, GameObject
	}
	#endregion

	#endregion 

	#region Special classes, changed: 25.09.05

	#region FactionLimit
	/// <summary>
	/// Allow use Faction+Reputation for Start/End of quests
	/// </summary>
	public class FactionLimit
	{
		private int _faction;
		private int _reputation;
		public FactionLimit( int faction, int reputation ) { _faction = faction; _reputation = reputation; }
		public int Faction { get { return _faction; } }
		public int Reputation { get { return _reputation; } }
	}
	#endregion

	#region DiscoveryAreaArray, SkillsArray
	/// <summary>
	/// Array for correct use Discovery quests
	/// </summary>
	public class DiscoveryAreaArray
	{
		ArrayList _items = new ArrayList();
		public DiscoveryAreaArray() {}
		public void Add( int areaTriggerId )
		{
			if ( !_items.Contains( areaTriggerId ) ) _items.Add( areaTriggerId );
		}
		public int Count { get { return _items.Count; } }
		public int[] Items { get { return (int[])_items.ToArray( typeof( int ) ); } }
		public bool Contains( int val )
		{
			return _items.Contains( val );
		}
	}
	/// <summary>
	/// Array for correct use Skills restriction
	/// </summary>
	public class SkillsArray
	{
		ArrayList _items = new ArrayList();
		public SkillsArray() {}
		public void Add( qSkills skill_needed )
		{
			if ( !_items.Contains( skill_needed ) ) _items.Add( skill_needed );
		}
		public int Count { get { return _items.Count; } }
		public qSkills[] Items { get { return (qSkills[])_items.ToArray( typeof( qSkills ) ); } }
	}
	#endregion

	#region Reward, BaseRewardArray, RewardArray, RewardChoiceArray
	/// <summary>
	/// Reward Item only
	/// now support only Item
	/// </summary>
	public class Reward
	{
		int _amount;
		int _id;
		int _model;
		/// <summary>
		/// Item id and amount
		/// </summary>
		public Reward( int id, int amount )
		{
			_id = id;
			_amount = amount;
		}
		/// <summary>
		/// create one Item by Id number
		/// </summary>
		public Item Create()
		{
			return World.CreateItemInPoolById( _id );
		}
		/// <summary>
		/// Amount of items
		/// </summary>
		public int Amount
		{
			get { return _amount; }
		}
		/// <summary>
		/// Item.Id
		/// </summary>
		public int Id
		{
			get { return _id; }
		}
		/// <summary>
		/// Item.Model 
		/// </summary>
		public int Model
		{
			get
			{
				if ( _model == 0 )
				{
					Item i = Create();
					_model = ( i!=null ? i.Model : 0);//safe check
				}
				return _model;
			}
		}
		/// <summary>
		/// only for Item
		/// </summary>
		public bool ExistsInWorld
		{
			get { return Create() != null;  }
		}

		/// <summary>
		/// Create Item
		/// </summary>
		public Item CreateItem()
		{
			return World.CreateItemInPoolById( _id );
		}
	}

	/// <summary>
	/// base class for rewards
	/// work only after overloads with
	/// +RewardArray
	/// +RewardChoiceArray
	/// </summary>
	public class BaseRewardArray
	{
		private ArrayList _items = new ArrayList();
		private int _max = 0;
		
		/// <summary>
		/// Constructor
		/// </summary>
		public BaseRewardArray( int max ) { _max = max; }

		/// <summary>
		/// Add new Reward [Item]
		/// </summary>
		public void Add( Reward r )
		{
			if ( r.ExistsInWorld ) 
			{
				if ( CanAdd ) _items.Add( r );
			}
			
			else BadIdList.AddItemId( r.Id );
		}
		/// <summary>
		/// Add Reward [Item]
		/// </summary>
		public void Add( int id, int amount )
		{
			Add( new Reward( id, amount ) );
		}

		/// <summary>
		/// Check for normal writed amount of objectives
		/// </summary>
		private bool CanAdd
		{
			get { return Count < _max; }
		}

		/// <summary>
		/// amount in array
		/// </summary>
		public int Count
		{
			get { return _items.Count; }
		}

		/// <summary>
		/// get array items
		/// </summary>
		public Reward[] Items
		{
			get { return (Reward[])_items.ToArray( typeof( Reward ) ); }
		}

		/// <summary>
		/// Create Reward item
		/// </summary>
		public Item RewardItem( int sel )
		{
			Reward r = (Reward)_items[ sel ];
			return ( r!= null ) ? r.CreateItem() : null;
		}

		/// <summary>
		/// get Reward amount
		/// </summary>
		public int RewardAmount( int sel )
		{
			Reward r = (Reward)_items[ sel ];
			return ( r!= null ) ? r.Amount : 0;
		}
	}

	/// <summary>
	/// Correct class for Reward Items
	/// </summary>
	public class RewardArray: BaseRewardArray
	{
		public RewardArray () : base( 4 ) {}
	}

	/// <summary>
	/// Correct class for needed Reward Choice Items
	/// </summary>
	public class RewardChoiceArray: BaseRewardArray
	{
		public RewardChoiceArray(): base( 6 ) {}
	}
	#endregion

	#region NPCObjective, NPCObjectiveArray
	/// <summary>
	/// Npc objective
	/// now support Mobile and GameObjects(not full)
	/// </summary>
	public class NPCObjective
	{
		private int _amount;
		private int _id;
		private string _descr = null;
		private TypeNpcObj _type = TypeNpcObj.Mobile;

		/// <summary>
		/// only for Mobiles
		/// </summary>
		public NPCObjective( int id, int amount )
		{
			_id = id;
			_amount = amount;
		}
		/// <summary>
		/// for Mobiles/GameObj
		/// </summary>
		public NPCObjective( int id, int amount, TypeNpcObj typeObj, string description )
		{
			_id = id;
			_amount = amount;
			_type = typeObj;
			_descr = description;
		}
		/// <summary>
		/// amount of objectives
		/// </summary>
		public int Amount
		{
			get { return _amount; }
		}
		/// <summary>
		/// mobile/go id number
		/// support only mobiles
		/// </summary>
		public int Id
		{
			get 
			{//set high bit (gameObjectId | 0x80000000) - for correct known by client
				return _id; //_type == TypeNpcObj.Mobile ? _id : ( _id | (int)0x80000000 );
			}
		}
		/// <summary>
		/// real id number
		/// </summary>
		public int Id2
		{
			get { return _id; }
		}
		/// <summary>
		/// Mobile exists in world
		/// </summary>
		public bool ExistsInWorld
		{
			get { return World.MobilesPool[ _id ] != null;  } // ?
		}
		/// <summary>
		/// Description for current mob/go
		/// </summary>
		public string Descr
		{
			get  
			{
				if ( _descr == null )
				{
					if ( _type == TypeNpcObj.Mobile )
					{
						Mobile m = ( Mobile )World.MobilePool( _id ).Invoke( null );
						_descr = m.Name;
					}
					else
					{
						_descr = string.Format( "gameobject:{0}", _id );
					}
				}
				return _descr;
			}
		}
		/// <summary>
		/// Current type of objectives
		/// </summary>
		public TypeNpcObj TypeObj
		{
			get { return _type; }
		}
	}

	/// <summary>
	/// Correct class for NPC Objectives
	/// </summary>
	public class NPCObjectiveArray
	{
		private static int _max = 4;
		private ArrayList _items = new ArrayList();
		
		/// <summary>
		/// Constructor
		/// </summary>
		public NPCObjectiveArray() {}
		/// <summary>
		/// Add new NPC Objective
		/// </summary>
		public void Add( NPCObjective npco )
		{
			if ( npco.TypeObj == TypeNpcObj.Mobile )
			{//if Mobile
				if ( npco.ExistsInWorld ) 
				{// exists in world
					if ( CanAdd )//can be added
						_items.Add( npco );
				}
				else BadIdList.AddMobileId( npco.Id );//add to bad statistic list
			}
			//else // GameObject objective (not supported yet)
			//{
			//}
		}
		/// <summary>
		/// only Mobiles
		/// </summary>
		public void Add( int id, int amount )
		{
			Add( new NPCObjective( id, amount ) );
		}
		/// <summary>
		/// any type of objectives
		/// </summary>
		public void Add( int id, int amount, TypeNpcObj typeObj, string description )
		{
			Add( new NPCObjective( id, amount, typeObj, description ) );
		}
		/// <summary>
		/// Check for normal writed amount of objectives
		/// </summary>
		private bool CanAdd
		{
			get { return Count < _max; }
		}
		/// <summary>
		/// Count
		/// </summary>
		public int Count
		{
			get { return _items.Count; }
		}
		/// <summary>
		/// NPC Objectives Mobiles and/or Gameobjects
		/// </summary>
		public NPCObjective[] Items
		{
			get { return (NPCObjective[])_items.ToArray( typeof( NPCObjective ) ); }
		}
		/// <summary>
		/// NPC Objective by id if exist
		/// </summary>
		public NPCObjective GetById( int id )
		{
			NPCObjective result = null;
			foreach ( NPCObjective npc in _items )
			{
				if ( npc.Id2 == id ) { result = npc; break; }
			}
			return result;
		}
	}
	#endregion

	#region DeliveryObjective, DeliveryObjectiveArray
	/// <summary>
	/// Delivery item Objective
	/// now support only Item
	/// </summary>
	public class DeliveryObjective
	{
		int _amount;
		int _id;
		public DeliveryObjective( int id, int amount )
		{
			_id = id;
			_amount = amount;
		}
		public int Amount
		{
			get { return _amount; }
		}
		public int Id
		{
			get { return _id; }
		}
		public bool ExistsInWorld
		{
			get { return World.ItemsPool[ _id ] != null; }// ?
		}
	}

	/// <summary>
	/// base class for rewards
	/// </summary>
	public class DeliveryObjectiveArray
	{
		private static int _max = 4;
		private ArrayList _items = new ArrayList();
		
		/// <summary>
		/// Constructor
		/// </summary>
		public DeliveryObjectiveArray() {}
		/// <summary>
		/// Add new DeliveryObjective
		/// </summary>
		public void Add( DeliveryObjective d )
		{
			if ( d.ExistsInWorld )
			{
				if ( CanAdd ) _items.Add( d );
			}
			else BadIdList.AddItemId( d.Id );
		}
		/// <summary>
		/// Add new DeliveryObjective (Item)
		/// </summary>
		public void Add( int id, int amount )
		{
			Add( new DeliveryObjective( id, amount ) );
		}
		/// <summary>
		/// Check for normal writed amount of objectives
		/// </summary>
		private bool CanAdd
		{
			get { return Count < _max; }
		}
		/// <summary>
		/// Count in array
		/// </summary>
		public int Count
		{
			get { return _items.Count; }
		}
		/// <summary>
		/// Objectives Array
		/// </summary>
		public DeliveryObjective[] Items
		{
			get { return (DeliveryObjective[])_items.ToArray( typeof( DeliveryObjective ) ); }
		}
		/// <summary>
		/// Delivery Objective by id if exist
		/// </summary>
		public DeliveryObjective GetById( int id )
		{
			DeliveryObjective result = null;
			foreach ( DeliveryObjective d in _items )
			{
				if ( d.Id == id ) { result = d; break; }
			}
			return result;
		}
	}
	#endregion

	#endregion

	#region Delegates: 04.10.05
	
	public delegate DialogStatus QuestDialogStatusDelegate( Mobile questOwner, Character c, BaseQuest bq );
	
	#endregion

	/// <summary>
	/// Base class for Quests
	/// </summary>
	public class BaseQuest 
	{
		#region Constructor ( public )
		/// <summary>
		/// Constructor
		/// </summary>
		public BaseQuest() 
		{ 
			if ( World.poolsReady ) InitObjectives();
		}
		#endregion

		#region variables ( Emotions ), created: 09.10.05
		
		public static qEmote[] onStartQuestDefault = null;
		public qEmote[] onStartQuestCustom = null;
		
		public static qEmote[] onEndQuestDefault = null;
		public qEmote[] onEndQuestCustom = null;

		#endregion

		#region variables ( protected ), changed: 01.10.05

		// Id Numbers
		protected int						id = 0;											// ( Id number, unicuum for each quest )
		protected int						npcId = 0;										// ( questOwner Id )
		protected int						zone = 0;										// ( Zone for quest )
		protected int						questFlags = 0x20;								// ( Not Known yet )

		// Text values
		protected string					name = "";										// ( Name )
		protected string					desc = "";										// ( Description )
		protected string					details = "";									// ( Details )
		protected string					details2 = "";									// Added: 23.09.05 (need test, maybe this is second page of description)
		protected string					progressTitle = "";								// ( title on Progress of quest )
		protected string					progressDialog = "";							// ( message on Progress of quest  )
		protected string					finishTitle = "";								// ( title on End of quest )
		protected string					finishDialog = "";								// ( message on End of quest )

		// Rewards
		protected int						rewardXp = 0;									// ( XP rewards )
		protected int						rewardGold = 0;									// ( Gold rewards )
		protected int						rewardSpell = 0;								// Added: 23.09.05
		protected RewardArray				reward = new RewardArray();						// Added: 23.09.05
		protected RewardChoiceArray			rewardChoice = new RewardChoiceArray();			// Added: 23.09.05
		
		// Objectives
		protected NPCObjectiveArray			npcObjectives = new NPCObjectiveArray();		// Added: 23.09.05
		protected DeliveryObjectiveArray	deliveryObjectives = new DeliveryObjectiveArray();	// Added: 23.09.05
		protected DiscoveryAreaArray		discoverigArea = new DiscoveryAreaArray();		// Added: 23.09.05
		protected Position					miniMapPos = null;								// Added: 23.09.05 (for minimap show target of quest; Used: MapId, X, Y )
		protected TimeSpan					completionTime;									// ( Not supported yet )
		protected int						sourceItemId = 0;								// Added: 24.09.05 (need test, npt supported yet)
		protected int						npcTargetId = 0;								// Added: 23.09.05
		protected bool						repeatable = false;								// Added: 01.10.05 (allow repeate quest)

		// Restrictions
		protected int						minLevel = 0;									// ( min level to allow quest )
		protected int						idealLevel = 0;									// ( ideal level to do quest )
		protected int						previousQuest = 0;								// ( for correct checks of chain quests )
		protected int						nextQuest = 0;									// ( needed by client, Not supported yet )
		protected float						minReputation = 0.5f;							// ( minimum reputation for get this quest, need check in Faction support )
		protected SkillsArray				skillsAllowed = new SkillsArray();				// Added: 24.09.05 ( Skills needed for get this quest )
		protected qClasses					classAllowed = qClasses.Any;					// ( Class allowed to get this quest )
		protected qRaces					raceAllowed = qRaces.Any;						// ( Race allowed to get this quest )
		protected QuestType					questType = QuestType.None;						// Added: 23.09.05 (type of quest)
		protected FactionLimit				faction1 = null;								//-Added: 23.09.05 (need test for correct logic)
		protected FactionLimit				faction2 = null;								//-Added: 23.09.05 (need test for correct logic)

		// Debug
		protected bool						questIsBugged = false;							// ( allow to use quest )

		#endregion

		#region Virtual events ( public ), changed: 04.10.05

		/// <summary>
		/// Auto delegate for quest status
		/// </summary>
		public static QuestDialogStatusDelegate onQuestStatus = null;
        
		/// <summary>
		/// Loading after Items and Creatures are loaded
		/// </summary>
		public virtual void InitObjectives()
		{
		}
		/// <summary>
		/// For create items in backpack
		/// </summary>
		public virtual void OnAcceptQuest( Character c ) 
		{
		}
		/// <summary>
		/// Status of quest ( Noneby default )
		/// </summary>
		public virtual DialogStatus QuestStatus( Mobile m, Character c )
		{
			if ( onQuestStatus != null ) return onQuestStatus( m, c, this );
			else return DialogStatus.None;
		}
		/// <summary>
		/// Checks for Race allow
		/// </summary>
		public virtual bool AllowedRace( Character c )
		{
			bool result = true;
			if ( raceAllowed != qRaces.Any )
			{
				qRaces tmp = raceAllowed;
				switch ( c.Race )
				{
					case Races.Dwarf:		result = tmp == qRaces.Dwarf	|| tmp == qRaces.Alliance; break;
					case Races.Gnome:		result = tmp == qRaces.Gnome	|| tmp == qRaces.Alliance; break;
					case Races.Human:		result = tmp == qRaces.Human	|| tmp == qRaces.Alliance; break;
					case Races.NightElf:	result = tmp == qRaces.NightElf || tmp == qRaces.Alliance; break;
					case Races.Orc:			result = tmp == qRaces.Orc		|| tmp == qRaces.Horde; break;
					case Races.Tauren:		result = tmp == qRaces.Tauren	|| tmp == qRaces.Horde; break;
					case Races.Troll:		result = tmp == qRaces.Troll	|| tmp == qRaces.Horde; break;
					case Races.Undead:		result = tmp == qRaces.Undead	|| tmp == qRaces.Horde; break;
				}
			}
			return result;
		}
		/// <summary>
		/// Checks for Class allow
		/// </summary>
		public virtual bool AllowedClass( Character c )
		{
			bool result = true;
			if ( classAllowed != qClasses.Any )
			{
				switch ( c.Classe )
				{
					case Classes.Druid:		result = classAllowed == qClasses.Druid; break;
					case Classes.Hunter:	result = classAllowed == qClasses.Hunter; break;
					case Classes.Mage:		result = classAllowed == qClasses.Mage; break;
					case Classes.Paladin:	result = classAllowed == qClasses.Paladin; break;
					case Classes.Priest:	result = classAllowed == qClasses.Priest; break;
					case Classes.Rogue:		result = classAllowed == qClasses.Rogue; break;
					case Classes.Shaman:	result = classAllowed == qClasses.Shaman; break;
					case Classes.Warlock:	result = classAllowed == qClasses.Warlock; break;
					case Classes.Warrior:	result = classAllowed == qClasses.Warrior; break;
				}
			}
			return result;
		}
		/// <summary>
		/// Checks for Skills Allow
		/// </summary>
		public bool AllowedSkills( Character c )
		{
			bool result = true;
			foreach ( qSkills qs in skillsAllowed.Items ) 
			{ 
				result = result && c.HaveSkill( (int)qs ); 
			}
			return result;
		}
		#endregion

		#region Reward functions ( public ), changed: 24.09.05

		/// <summary>
		/// Have Reward Choice?
		/// </summary>
		public bool HasRewardChoice()
		{
			return rewardChoice.Count > 0;
		}
		/// <summary>
		/// Have Reward?
		/// </summary>
		public bool HasReward()
		{
			return reward.Count > 0;
		}

		/// <summary>
		/// Create Choice reward
		/// </summary>
		public Item ChoiceRewardCreate( int sel )
		{
			return rewardChoice.RewardItem( sel );
		}

		/// <summary>
		/// Get Amount of choice reward
		/// </summary>
		public int ChoiceRewardAmount( int sel )
		{
			return rewardChoice.RewardAmount( sel );
		}

		#endregion

		#region Accessors ( public, get ), changed: 02.10.05

		#region Id Numbers

		/// <summary>
		/// Id number of quest
		/// </summary>
		public int Id
		{
			get { return id; }
		}

		/// <summary>
		/// NPC.Owner.Id for auto fill system
		/// </summary>
		public int NPCId
		{
			get { return npcId; }
		}

		/// <summary>
		/// Zone for quest, showed on client status request 
		/// </summary>
		public int Zone
		{
			get { return zone; }
		}

		/// <summary>
		/// Unknown, unsupported yet
		/// </summary>
		public int QuestFlags
		{
			get { return questFlags; }
		}

		#endregion

		#region Text Values

		/// <summary>
		/// Quest name
		/// </summary>
		public string Name
		{
			get { return name; }
		}

		/// <summary>
		/// Description for quest
		/// </summary>
		public string Desc
		{
			get { return desc; }
		}

		/// <summary>
		/// First Details of Quest
		/// </summary>
		public string Details
		{
			get { return details; }
		}

		/// <summary>
		/// Second Details for quest
		/// </summary>
		public string Details2
		{
			get { return details2; }
		}

		/// <summary>
		/// Progress title
		/// </summary>
		public string ProgressTitle
		{
			get { return progressTitle; }
		}

		/// <summary>
		/// Progress dialog
		/// </summary>
		public string ProgressDialog
		{
			get { return progressDialog; }
		}

		/// <summary>
		/// Finish title
		/// </summary>
		public string FinishTitle
		{
			get { return finishTitle; }
		}

		/// <summary>
		/// Finish dialog
		/// </summary>
		public string FinishDialog
		{
			get { return finishDialog; }
		}

		#endregion

		#region Rewards

		/// <summary>
		/// Reward expirience for quest
		/// </summary>
		public int RewardXp
		{
			get { return rewardXp; }
		}

		/// <summary>
		/// Gold for reward
		/// </summary>
		public int RewardGold
		{
			get { return rewardGold; }
		}

		/// <summary>
		/// Reward spell
		/// Changed
		/// </summary>
		public int RewardSpell
		{
			get { return rewardSpell; }
		}

		/// <summary>
		/// Reward array, contain reward items (always reward [all])
		/// Changed
		/// </summary>
		public RewardArray Reward
		{
			get { return reward; }
		}

		/// <summary>
		/// Reward Choice array, contain rewards (need choice [one of all])
		/// Changed
		/// </summary>
		public RewardChoiceArray RewardChoice
		{
			get { return rewardChoice; }
		}

		#endregion

		#region Objectives

		/// <summary>
		/// NPC Objectives array ( mobs who need kill/walk or Gameobjects for some quests )
		/// Changed
		/// </summary>
		public NPCObjectiveArray NPCObjectives
		{
			get { return npcObjectives; }
		}

		/// <summary>
		/// Delivery objective Items array ( need transfer items to NpcTargetId )
		/// Changed
		/// </summary>
		public DeliveryObjectiveArray DeliveryObjectives
		{
			get { return deliveryObjectives; }
		}

		/// <summary>
		/// Id of AreaTriggers for compleate quest
		/// Changed
		/// </summary>
		public DiscoveryAreaArray DiscoverigArea
		{
			get { return discoverigArea; }
		}

		/// <summary>
		/// Point on the mini map show
		/// Added
		/// </summary>
		public Position MiniMapPos
		{
			get { return miniMapPos; }
		}

		/// <summary>
		/// not supported yet, time for do quest
		/// </summary>
		public TimeSpan CompletionTime
		{
			get { return completionTime; }
		}

		/// <summary>
		/// Item to be sended
		/// </summary>
		public int SourceItemId
		{
			get { return sourceItemId; }
		}

		/// <summary>
		/// NPC.Target.Id for each quests
		/// </summary>
		public int NPCTargetId
		{
			get { return npcTargetId; }
		}

		/// <summary>
		/// Allow repeate quest
		/// </summary>
		public bool Repeatable
		{
			get { return repeatable; }
		}

		#endregion

		#region Restrictions

		/// <summary>
		/// Minimum level for can get quest
		/// </summary>
		public int MinLevel
		{
			get { return minLevel; }
		}

		/// <summary>
		/// Ideal level for quest
		/// </summary>
		public int IdealLevel
		{
			get { return idealLevel; }
		}

		/// <summary>
		/// Quest needed for get this quest
		/// </summary>
		public int PreviousQuest
		{
			get { return previousQuest; }
		}

		/// <summary>
		/// Unsupported correctly yet
		/// </summary>
		public int NextQuest
		{
			get { return nextQuest; }
		}

		/// <summary>
		/// Minimum reputation for get this quest
		/// </summary>
		public float MinReputation
		{
			get { return minReputation; }
		}

		/// <summary>
		/// Skills to get quest
		/// </summary>
		public SkillsArray SkillsAllowed
		{
			get { return skillsAllowed; }
		}

		/// <summary>
		/// Class to get quest
		/// </summary>
		public qClasses ClassAllowed
		{
			get { return classAllowed; }
		}

		/// <summary>
		/// Race to get quest
		/// </summary>
		public qRaces RaceAllowed
		{
			get { return raceAllowed; }
		}

		/// <summary>
		/// Type of Quest
		/// </summary>
		public QuestType QuestType
		{
			get { return questType; }
		}

		/// <summary>
		/// first Faction limit
		/// </summary>
		public FactionLimit Faction1
		{
			get { return faction1; }
		}

		/// <summary>
		/// second Faction limit
		/// </summary>
		public FactionLimit Faction2
		{
			get { return faction2; }
		}

		#endregion

		#region Debug
		/// <summary>
		/// Quest is bugged?
		/// </summary>
		public bool QuestIsBugged
		{
			get { return questIsBugged; }
		}
		#endregion

		#endregion

		#region Types of quest ( public, get ), changed: 23.09.05
		
		/// <summary>
		/// have Discovery objective?
		/// </summary>
		public bool HaveDiscoveryObj
		{ 
			get { return discoverigArea.Count > 0; }
		}

		/// <summary>
		/// have Delivery objective?
		/// </summary>
		public bool HaveDeliveryObj
		{
			get { return deliveryObjectives.Count > 0; }
		}

		/// <summary>
		/// Have TargetId for speak
		/// </summary>
		public bool HaveNPCTargetId
		{
			get { return npcTargetId > 0; }
		}

		/// <summary>
		/// Have NPC Objectives
		/// </summary>
		public bool HaveNPCObj
		{
			get { return npcObjectives.Count > 0; }
		}

		/// <summary>
		/// Delivery to other Npc
		/// is Delivery quest And Have NPCTargetId
		/// </summary>
		public bool DeliveryNotForOwner
		{
			get { return HaveNPCTargetId && HaveDeliveryObj; }
		}

		#endregion

	}
}
