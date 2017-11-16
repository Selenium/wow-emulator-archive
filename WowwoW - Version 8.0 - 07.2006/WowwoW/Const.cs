/*
 * Created by SharpDevelop.
 * User: BIOSTAT26
 * Date: 18/01/2005
 * Time: 13:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Server
{

	public enum AdditionalsEffects
	{
		Combustion = 0x15af54,
	}
	public enum UpdateType
	{
		UpdatePartial                   =0x0,
		UpdateMovement                  =0x1,
		UpdateFull                      =0x2,
		UpdateOutOfRange              =0x3,
		UpdateInRange                  =0x4
	}
	public enum DispelType : int
	{

		None = 0,
		Magic =	1,
		Curse =	2,
		Disease = 3,
		Poison = 4,
		Stealth	= 5,
		Invisibility = 6,
		All = 7,
		Special = 8,
		Frenzy = 9
	};
	public enum Resistances : int
	{

		Armor = 0,
		Light = 1,
		Fire = 2,
		Nature = 3,
		Frost = 4,
		Shadow = 5,
		Arcane = 6
	};

	public enum Factions : int
	{
		NoFaction = 0,
		Player_Human = 1,
		Player_Orc = 2,
		Player_Dwarf = 3,
		Player_Elf = 4,
		Player_Undead = 5,
		Player_Tauren = 6,		
		Player_Troll = 7,			
		Player_Gnome = 11,	
		
		
		
		
	
		Stormwind = 12,
		
		BlacksmithingArmorSmithing = 13,
		BlacksmithingAxeSmithing = 14,
		BlacksmithingHammerSmithing = 15,
		BlacksmithingSwordSmithing = 16,
		BlacksmithingGnomeSmithing = 17,
		BlacksmithingGoblinSmithing = 18,
		BlacksmithingDragonScaleSmithing = 19,
		BlacksmithingElementalSmithing = 20,
		BlacksmithingTribalSmithing = 21,
		ArgentDawn = 22,
		
		GnomereganExiles = 23,
		CaerDarrow = 25,
		FrostwolfClan = 26,
		BattlegroundNeutral = 27,
		
		
		
		
		Prey = 31,
		Beast = 32,		
		ShatterspearTrolls = 33,
		Shendralar = 34,
		Friend = 35,
		RavasawrTrainers = 36,
		ThoriumBrotherhood = 37,
		ThundermawFurbolgs = 38,
		WildHammerClan = 39,
		WinterSaberTrainers = 40,
		StormpikeGuard = 41,
		HydraxianWaterlords = 42,
		Ravenholdt = 43,
		EvilBeast = 44,
		IronForge = 57,
		Monster = 60,
		Gadgetzan = 61,
		MoroGai = 62,
		Everlook = 63,
		SteamWheedleCartel = 64,


		Ratchet = 69,
		Ogrimmar = 85,
		Undercity = 98,
		ThunderBluff = 105,
		Syndicate = 108,
		


		Alliance = 115,
		BloodsailBuccaneers = 119,
		BootyBay = 121,
		Darnasus = 124,
		DarkspearTrolls = 126,
		GellisClanCentaur = 132,
		MagranClanCentaure = 133,
		Horde=6

	};
	/*
		PlayerHuman = 1,
		PlayerOrc = 2,
		PlayerDwarf = 3,
		PlayerNightElf = 4, 
		PlayerUndead = 5,
		PlayerTauren = 6,
		Creature = 7,
		PlayerGnome = 8, 
		PlayerTroll = 9,
		Stormwind = 11,
		Monster = 14,
		DefiasBrotherhood = 15,
		GnollRiverpaw=16,
		GnollRedridge=17,
		GnollShadowhide=18,
		Murloc=19,
		UndeadScourge=20,
		BootyBay=21,
		Beast=22,
		Worgen=24,
		Kobold=25,
		TrollBloodscalp=26,
		TrollSkullsplitter=27,
		Prey=28,
		DefiasBrotherhoodTraitor=30,
		Friendly=31,
		Trogg=32,
		TrollFrostmane=33,
		OrcBlackrock=34,
		Villian=35,
		Victim=36,
		Ogre=38,
		KurzensMercenaries=39,
		Escortee=40,
		VentureCompany=41,
		DragonflightGreen=44,
		LostOnes=45,
		BlacksmithingArmorsmithing=46,
		Ironforge=47,
		DwarfDarkIron=48,
		HumanNightWatch=49,
		DragonflightRed=50,
		GnollMosshide=51,
		OrcDragonmaw=52,
		GnomeLeper=53,
		GnomereganExiles=54,
		Leopard=55,
		ScarletCrusade=56,
		GnollRothide=57,
		Naga=60,
		Dalaran=61,
		ForlornSpirit=62,
		Darkhowl=63,
		Grell=64,
		Furbolg=65,
		HordeGeneric=66,
		Horde=67,
		Undercity=68,
		Darnassus=69,
		Syndicate=70,
		HillsbradMilitia=71,
		Demon=73,
		Elemental=74,
		Spirit=75,
		Orgrimmar=76,
		Treasure=77,
		GnollMudsnout=78,
		HIllsbradSouthshoreMayor=79,
		DragonflightBlack=80,
		ThunderBluff=81,
		TrollWitherbark=82,
		LeatherworkingElemental=83,
		QuilboarRazormane=84,
		QuilboarBristleback=85,
		LeatherworkingDragonscale=86,
		BloodsailBuccaneers=87,
		Blackfathom=88,
		Makrura=89,
		CentaurKolkar=90,
		CentaurGalak=91,
		CentaurGelkis=92,
		CentaurMagram=93,
		Maraudine=94,
		HumanTheramore=108,
		QuilboarRazorfen=109,
		QuilboarDeathshead=111,
		Alliance = 115,
		Enemy=128,
		Ambient=148,
		NethergardeCaravan=168,
		SteamwheedleCartel=169,
		AllianceGeneric=189,
		Nethergarde=209,
		WailingCaverns=229,
		Silithid=249,
		AllianceRedTeam=269,
		AllianceBlueTeam=270,
		BlacksmithingWeaponsmithing=289,
		Scorpid=309,
		Titan=311,
		TaskmasterFizzule=329,
		Ravenholdt=349,
		Blackfathom2 = 350,
		Gadgetzan=369,
		GnomereganBug=389,
		Harpy=409,
		Basilisk = 410,
		TimbermawFurbolgs = 414,
		BurningBlade=429,
		ShadowsilkPoacher=449,
		Ratchet=470,
		DwarfWildhammer=471,
		GoblinDarkIronBarPatron=489,
		HordeRedTeam=509,
		HordeBlueTeam=510,
		Giant=511,
		ArgentDawn=529,
		DarkspearTrolls=530,
		DragonflightBronze=531,
		DragonflightBlue=532,
		LeatherworkingTribal=549,
		EngineeringGoblin=550,
		EngineeringGnome=551,
		BlacksmithingHammersmithing=569,
		BlacksmithingAxesmithing=570,
		BlacksmithingSwordsmithing=571,
		TrollVilebranch=572,
		SouthseaFreebooters=573,
		CaerDarrow=574,
		FurbolgUncorrupted=575,
		Everlook=577,
		WintersaberTrainers=589,
		CenarionCircle=609,
		ShatterspearTrolls=629,
		RavasaurTrainers=630,
	};*/

	/// <summary>
	/// Description of Const.	
	/// </summary>
	public class Const
	{
		static int  tick=0;
		static int  tickLast=Environment.TickCount;
		public static int Tick 
		{
			get 
			{
				return tick;
			}
		}
		public static int []spellcost = 
{
	1,
	5,
	10, 
	25, 
	50, 
	75,
	100,//	6
	150,
	200,
	300,
	400,
	500,
	600,//	12
	800,
	1000,
	1300,
	1600,
	1900,
	2200,
	2600,
	3000,//20
	3300,
	3600,
	3900,
	4200,
	4500,
	4800,
	5100,
	5500,//	28
	6000,
	6500,
	7000,
	7500,
	8000,
	8500,
	9000,
	9500,//	36
	10000,
	10500,
	11000,
	11500,
	12000,
	12500,
	13000,
	13500,//	44
	14000,
	14500,
	15000,
	15500,
	16000,
	16500,
	17000,
	17500,//	52
	18000,
	18500,
	20000,
	2100,
	22000,
	25000,
	30000,
	35000//60
};
		public static void SyncTick()
		{
			int t = Environment.TickCount;
			if( tickLast > t)
				tickLast = t;

			tick += Environment.TickCount - tickLast;
			tickLast = t;
		}
		public static uint ITEMGUID_HIGH = 0x40000000;
		public static uint CONTAINERGUID_HIGH = 0x40000000;
		public static uint CREATUREGUID_HIGH = 0xF0001000;
		public static uint PLAYERGUID_HIGH = 0;


		public static int PlayerMaxBits						= 0x26 * 4 * 8;
		public static int ObjectType_OBJECT					= (int)1;
		public static int ObjectType_ITEM					= 2;
		public static int ObjectType_CONTAINER				= 4;
		public static int ObjectType_MOBILE					= 8;
		public static int ObjectType_PLAYER					= 16;
		public static int ObjectType_GAMEOBJECT				= 32;
		public static int ObjectType_DYNAMICOBJECT			= 64;
		public static int ObjectType_CORPSE					= 128;
		public static int ObjectType_AIGROUP				= 256;
		public static int ObjectType_AREATRIGGER			= 512;
		
		public static int UPDATE_BLOCKS						= 872;
		public static int UNIT_BLOCKS 						= 5;
		public static int PLAYER_BLOCKS 					= 27;		

		public static int OBJECT_START 						= 0;
		public static int OBJECT_FIELD_GUID					= 0 + OBJECT_START;
		public static int OBJECT_FIELD_TYPE					= 2 + OBJECT_START;
		public static int OBJECT_FIELD_ENTRY				= 3 + OBJECT_START;
		public static int OBJECT_FIELD_SCALE_X				= 4 + OBJECT_START;
		public static int OBJECT_FIELD_PADDING				= 5 + OBJECT_START;
		public static int OBJECT_END						= 6 + OBJECT_START;

		public static int ITEM_START = OBJECT_END;
		public static int ITEM_FIELD_OWNER					= 0x00 + ITEM_START;
		public static int ITEM_FIELD_CONTAINED				= 0x02 + ITEM_START;
		public static int ITEM_FIELD_CREATOR				= 0x04 + ITEM_START;
		public static int ITEM_FIELD_GIFTCREATOR			= 0x06 + ITEM_START;
		public static int ITEM_FIELD_STACK_COUNT			= 0x08 + ITEM_START;
		public static int ITEM_FIELD_DURATION				= 0x09 + ITEM_START;
		public static int ITEM_FIELD_SPELL_CHARGES			= 0x0A + ITEM_START;
		public static int ITEM_FIELD_FLAGS					= 0x0F + ITEM_START;
		public static int ITEM_FIELD_ENCHANTMENT			= 0x10 + ITEM_START;
		public static int ITEM_FIELD_PROPERTY_SEED			= 0x25 + ITEM_START;
		public static int ITEM_FIELD_RANDOM_PROPERTIES_ID	= 0x26 + ITEM_START;
		public static int ITEM_FIELD_ITEM_TEXT_ID			= 0x27 + ITEM_START;
		public static int ITEM_DURABILITY					= 0x28 + ITEM_START;	// added for 0.10.0
		public static int ITEM_MAXDURABILITY				= 0x29 + ITEM_START;	// added for 0.10.0
		public static int ITEM_END							= 0x2A + ITEM_START;

		public static int CONTAINER_START = ITEM_END;
		public static int CONTAINER_FIELD_NUM_SLOTS			= 0x00 + CONTAINER_START;
		public static int CONTAINER_ALIGN_PAD				= 0x01 + CONTAINER_START;
		public static int CONTAINER_FIELD_SLOT_1			= 0x02 + CONTAINER_START;
		public static int CONTAINER_END						= 0x2A + CONTAINER_START;

		public static int UNIT_START = OBJECT_END;
		public static int UNIT_CHARM					= 0x00 + UNIT_START; //2
		public static int UNIT_CHARM_HIGH				= 0x01 + UNIT_START;
		public static int UNIT_SUMMON					= 0x02 + UNIT_START; //2
		public static int UNIT_SUMMON_HIGH				= 0x03 + UNIT_START;
		public static int UNIT_CHARMEDBY				= 0x04 + UNIT_START; //2
		public static int UNIT_CHARMEDBY_HIGH			= 0x05 + UNIT_START;
		public static int UNIT_SUMMONEDBY				= 0x06 + UNIT_START; //2
		public static int UNIT_SUMMONBY_HIGH			= 0x07 + UNIT_START;
		public static int UNIT_CREATEDBY				= 0x08 + UNIT_START; //2
		public static int UNIT_CREATEDBY_HIGH			= 0x09 + UNIT_START; //2
		public static int UNIT_TARGET					= 0x00A + UNIT_START; //2
		public static int UNIT_TARGET_HIGH				= 0x0B +  UNIT_START; //2
		public static int UNIT_COMBO_TARGET				= 0x00C + UNIT_START; //2
		public static int UNIT_COMBO_TARGET_HIGH		= 0x0D  + UNIT_START; //2
		public static int UNIT_CHANNEL_OBJECT			= 0x0E + UNIT_START; //2
		public static int UNIT_CHANNEL_OBJECT_HIGH		= 0x0F  + UNIT_START; //2
		public static int UNIT_HEALTH					= 0x10 + UNIT_START; //1
		public static int UNIT_MANA						= 0x11 + UNIT_START; //1
		public static int UNIT_RAGE						= 0x12 + UNIT_START; //1
		public static int UNIT_FOCUS					= 0x13 + UNIT_START; //1
		public static int UNIT_ENERGY					= 0x14 + UNIT_START; //1
		public static int UNIT_MAXHEALTH				= 0x15 + UNIT_START; //1
		public static int UNIT_MAX_MANA					= 0x16 + UNIT_START; //1
		public static int UNIT_MAX_RAGE					= 0x017 + UNIT_START; //1
		public static int UNIT_MAX_FOCUS				= 0x018 + UNIT_START; //1
		public static int UNIT_MAX_ENERGY				= 0x019 + UNIT_START; //1
		public static int UNIT_LEVEL					= 0x01A + UNIT_START; //1
		public static int UNIT_FACTION					= 0x01B + UNIT_START; //1
		public static int UNIT_BYTES_0					= 0x01C + UNIT_START; //1

		public static int UNIT_STRENGTH					= 35;
		public static int UNIT_AGILITY					= 36;
		public static int UNIT_STAMINA					= 37;
		public static int UNIT_INTELLECT				=	38;
		public static int UNIT_SPIRIT					=	39;
		public static int UNIT_BASE_STRENGTH			=	40;
		public static int  UNIT_BASE_AGILITY			=	41;
		public static int  UNIT_BASE_STAMINA			=	42;
		public static int  UNIT_BASE_INTELLECT			=	43;
		public static int  UNIT_BASE_SPIRIT				= 44;
		public static int  UNIT_VIRTUAL_ITEMSLOTDISPLAY	= 45;
		public static int  UNIT_VIRTUAL_ITEMINFO		= 	48;
		public static int  UNIT_FLAGS					=	54;
		public static int  UNIT_COINAGE					= 55;
		public static int  UNIT_AURA					=	56;
		public static int UNIT_AURA_LEVELS			=	112;
		public static int UNIT_AURA_APPLICATIONS=			122;
		public static int UNIT_AURA_FLAGS		=			132;
		public static int UNIT_AURA_STATE			=		139;
		public static int UNIT_BASEATTACKTIME0		=	140;
		public static int UNIT_BASEATTACKTIME1		=	141;
		public static int UNIT_RESISTANCE			=		142;
		public static int UNIT_RESISTANCE_PHYSICAL	=	142;
		public static int UNIT_RESISTANCE_HOLY		=	143;
		public static int UNIT_RESISTANCE_FIRE		=	144;
		public static int UNIT_RESISTANCE_NATURE	=		145;
		public static int UNIT_RESISTANCE_FROST		=	146;
		public static int UNIT_RESISTANCE_SHADOW	=		147;
		public static int UNIT_BOUNDING_RADIUS		=	148;
		public static int UNIT_COMBAT_REACH			=	149;
		public static int UNIT_WEAPON_REACH			=	150;
		public static int UNIT_DISPLAYID			=		151;
		public static int UNIT_MOUNT_DISPLAYID		=	152;
		public static int UNIT_MIN_DAMAGE			=		153;
		public static int UNIT_MAX_DAMAGE			=		154;
		public static int UNIT_MOD_DAMAGE_DONE		=	155;
		public static int UNIT_RESISTANCE_BUFF_POSITIVE=	161;
		public static int UNIT_RESISTANCE_BUFF_NEGATIVE	=167;
		public static int UNIT_RESISTANCE_ITEM_MODS	=	173;
		public static int UNIT_BYTES_1				=	179;
		public static int UNIT_PET_NUMBER			=		180;
		public static int UNIT_PET_NAME_TIMESTAMP	=		181;
		public static int UNIT_PET_EXPERIENCE		=		182;
		public static int UNIT_PET_NEXT_LEVEL_EXP	=		183;
		public static int UNIT_DYNAMIC_FLAGS		=		184;
		public static int UNIT_EMOTE_STATE			=	185;
		public static int UNIT_CHANNEL_SPELL		=		186;
		public static int UNIT_MOD_CAST_SPEED		=		187;
		public static int UNIT_CREATED_BY_SPELL		=	188;
		public static int UNIT_NPC_FLAGS			=		189;
		public static int UNIT_BYTES_2				=	190;
		public static int UNIT_ATTACKPOWER			=	191;
		public static int UNIT_ATTACKPOWERMODIFER	=		192;
		public static int UNIT_PADDING				=	193;
		public static int UNIT_MAX_BITS				=	194;

		public static int PLAYER_GUILD_ID			=		198;
		public static int PLAYER_GUILD_RANK			=	199;
		public static int PLAYER_BYTES_1				=	200;
		//public static int PLAYER_BYTES_2				=	201;
		public static int PLAYER_INV_SLOTS				=	204;
		public static int PLAYER_BASE_MANA				= 818;
		

		public static int PLAYER_SELECTION				=	166;
		public static int PLAYER_DUEL_ARBITER			=		168;
		public static int PLAYER_GUILDID			=			170;
		public static int PLAYER_GUILDRANK			=		171;
		public static int PLAYER_BYTES				=		172;
		public static int PLAYER_BYTES_2			=			173;
		public static int PLAYER_BYTES_3			=			174;
		public static int PLAYER_DUEL_TEAM			=		175;
		public static int PLAYER_GUILD_TIMESTAMP	=			176;
		public static int PLAYER_FIELD_PAD_0		=			177;
		public static int PLAYER_FIELD_INV_SLOT_HEAD=				178;
		public static int PLAYER_FIELD_PACK_SLOT_1	=			224;
		public static int PLAYER_FIELD_BANK_SLOT_1	=			256;
		public static int PLAYER_FIELD_BANKBAG_SLOT_1	=			304;
		public static int PLAYER_FIELD_VENDORBUYBACK_SLOT	=		316;
		public static int PLAYER_FARSIGHT				=		318;
		public static int PLAYER__FIELD_COMBO_TARGET	=			320;
		public static int PLAYER_FIELD_BUYBACK_NPC		=		322			;
		public static int PLAYER_XP						=	324;
		public static int PLAYER_NEXT_LEVEL_XP			=		325;
		public static int PLAYER_SKILL_INFO_1_1			=		326;
		public static int PLAYER_QUEST_LOG_1_1			=		710;
		public static int PLAYER_CHARACTER_POINTS1		=		770;
		public static int PLAYER_CHARACTER_POINTS2		=		771;
		public static int PLAYER_TRACK_CREATURES		=		772;
		public static int PLAYER_TRACK_RESOURCES		=		773;
		public static int PLAYER_CHAT_FILTERS			=		774;
		public static int PLAYER_BLOCK_PERCENTAGE		=		775;
		public static int PLAYER_DODGE_PERCENTAGE		=		776;
		public static int PLAYER_PARRY_PERCENTAGE		=		777;
		public static int PLAYER_CRIT_PERCENTAGE		=		778;
		public static int PLAYER_EXPLORED_ZONES_1		=		779;
		public static int PLAYER_UNKNOW_810				=		810;
		public static int PLAYER_REST_STATE_EXPERIENCE	=		811;
		public static int PLAYER_FIELD_COINAGE			=		812;
		public static int PLAYER_FIELD_POSSTAT0			=		813;
		public static int PLAYER_FIELD_POSSTAT1			=		814;
		public static int PLAYER_FIELD_POSSTAT2			=		815;
		public static int PLAYER_FIELD_POSSTAT3			=		816;
		public static int PLAYER_FIELD_POSSTAT4			=		817;
		public static int PLAYER_FIELD_NEGSTAT0			=		818;
		public static int PLAYER_FIELD_NEGSTAT1			=		819;
		public static int PLAYER_FIELD_NEGSTAT2			=		820;
		public static int PLAYER_FIELD_NEGSTAT3			=		821;
		public static int PLAYER_FIELD_NEGSTAT4			=		822;
		public static int PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE	=	823;
		public static int PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE	=	830;
		public static int PLAYER_UNKNOW_831	=		831;
		public static int PLAYER_UNKNOW_832	=		831;
		public static int PLAYER_UNKNOW_833	=		833;
		public static int PLAYER_UNKNOW_834	=		834;
		public static int PLAYER_UNKNOW_835	=		835;
		public static int PLAYER_FIELD_MOD_DAMAGE_DONE_POS	=		837;
		public static int PLAYER_FIELD_MOD_DAMAGE_DONE_NEG	=		844;
		public static int PLAYER_FIELD_MOD_DAMAGE_DONE_PCT	=		851;
		public static int PLAYER_UNKNOW_855	=		855;
		public static int PLAYER_FIELD_BYTES				=	858	;																	// deleted PLAYER_FIELD_ATTACKPOWERMODPOS (1) and PLAYE_FIELD_ATTACKPOWERMODNEG (1)
		public static int PLAYER_AMMO_ID					=	859;
		public static int PLAYER_FIELD_PVP_MEDALS			=	860	;		
		public static int PLAYER_FIELD_BUYBACK_ITEM_ID		=	861;
		public static int PLAYER_FIELD_BUYBACK_RANDOM_PROPERTIES_ID=	862;
		public static int PLAYER_FIELD_BUYBACK_SEED		=		863;
		public static int PLAYER_FIELD_BUYBACK_PRICE	=			864;
		public static int PLAYER_FIELD_PADDING			=		865;
		public static int PLAYER_END					=	866;

		/*
		public static int UNIT_VIRTUAL_ITEM_SLOT_DISPLAY	= 0x01D + UNIT_START; //3
		public static int UNIT_VIRTUAL_ITEM_INFO			= 0x020 + UNIT_START; //6
		public static int UNIT_FIELD_FLAGS					= 0x026 + UNIT_START; //1
		public static int UNIT_FIELD_AURA		 			= 0x027 + UNIT_START; //38h
		public static int UNIT_FIELD_AURALEVELS				= 0x05F + UNIT_START; //0Ah
		public static int UNIT_FIELD_AURAAPPLICATIONS		= 0x069 + UNIT_START; //0Ah
		public static int UNIT_FIELD_AURAFLAGS				= 0x073 + UNIT_START; //7
		public static int UNIT_FIELD_AURASTATE				= 0x07A + UNIT_START; //1
		public static int UNIT_FIELD_BASEATTACKTIME			= 0x07B + UNIT_START; //2
		public static int UNIT_FIELD_BOUNDINGRADIUS			= 0x07D + UNIT_START; //1
		public static int UNIT_FIELD_COMBATREACH			= 0x07E + UNIT_START; //1
		public static int UNIT_FIELD_DISPLAYID				= 0x07F + UNIT_START; //1   // was WEAPONREACH in 0.9.1
		public static int UNIT_FIELD_NATIVEDISPLAYID		= 0x080 + UNIT_START; //1	// was DISPLAYID in 0.9.1
		public static int UNIT_FIELD_MOUNTDISPLAYID			= 0x081 + UNIT_START; //1
		public static int UNIT_FIELD_MINDAMAGE				= 0x082 + UNIT_START; //1
		public static int UNIT_FIELD_MAXDAMAGE				= 0x083 + UNIT_START; //1
		public static int UNIT_FIELD_BYTES_1				= 0x084 + UNIT_START; //1
		public static int UNIT_FIELD_PETNUMBER				= 0x085 + UNIT_START; //1
		public static int UNIT_FIELD_PET_NAME_TIMESTAMP		= 0x086 + UNIT_START; //1
		public static int UNIT_FIELD_PETEXPERIENCE			= 0x087 + UNIT_START; //1
		public static int UNIT_FIELD_PETNEXTLEVELEXP		= 0x088 + UNIT_START; //1
		public static int UNIT_DYNAMIC_FLAGS				= 0x089 + UNIT_START; //1
		public static int UNIT_CHANNEL_SPELL				= 0x08A + UNIT_START; //1
		public static int UNIT_MOD_CAST_SPEED				= 0x08B + UNIT_START; //1
		public static int UNIT_CREATED_BY_SPELL				= 0x08C + UNIT_START; //1
		public static int UNIT_NPC_FLAGS		 			= 0x08D + UNIT_START; //1
		public static int UNIT_NPC_EMOTESTATE				= 0x08E + UNIT_START; //1
		public static int UNIT_TRAINING_POINTS				= 0x08F + UNIT_START; //1
		public static int UNIT_FIELD_STAT0					= 0x090 + UNIT_START; //1
		public static int UNIT_FIELD_STAT1					= 0x091 + UNIT_START; //1
		public static int UNIT_FIELD_STAT2					= 0x092 + UNIT_START; //1
		public static int UNIT_FIELD_STAT3					= 0x093 + UNIT_START; //1
		public static int UNIT_FIELD_STAT4					= 0x094 + UNIT_START; //1
		public static int UNIT_FIELD_RESISTANCES			= 0x095 + UNIT_START; //7
		public static int UNIT_FIELD_ATTACKPOWER			= 0x09C + UNIT_START; //1
		public static int UNIT_FIELD_BASE_MANA				= 0x09D + UNIT_START; //1
		public static int UNIT_ATTACK_POWER_MODS			= 0x09E + UNIT_START; //1	// added for 0.10.0
		public static int UNIT_FIELD_PADDING				= 0x09F + UNIT_START; //1		// added for 0.10.0
*/
		public static int UNIT_END							= 0x0A0 + UNIT_START;


		public static int PLAYER_START = UNIT_END;									// so all this is offset 2 int32's for 0.10.0


		public static int GAMEOBJECT_START = OBJECT_END;
		public static int GAMEOBJECT_DISPLAYID			= 0x00 + GAMEOBJECT_START; //1
		public static int GAMEOBJECT_FLAGS				= 0x01 + GAMEOBJECT_START; //1
		public static int GAMEOBJECT_ROTATION				= 0x02 + GAMEOBJECT_START; //4
		public static int GAMEOBJECT_STATE				= 0x06 + GAMEOBJECT_START; //1
		public static int GAMEOBJECT_TIMESTAMP			= 0x07 + GAMEOBJECT_START; //1
		public static int GAMEOBJECT_POS_X				= 0x08 + GAMEOBJECT_START; //1
		public static int GAMEOBJECT_POS_Y				= 0x09 + GAMEOBJECT_START; //1
		public static int GAMEOBJECT_POS_Z				= 0x00A + GAMEOBJECT_START; //1
		public static int GAMEOBJECT_FACING				= 0x00B + GAMEOBJECT_START; //1
		public static int GAMEOBJECT_DYN_FLAGS			= 0x00C + GAMEOBJECT_START; //1
		public static int GAMEOBJECT_FACTION				= 0x00D + GAMEOBJECT_START; //1
		public static int GAMEOBJECT_TYPE_ID				= 0x00E + GAMEOBJECT_START; //1
		public static int GAMEOBJECT_LEVEL				= 0x00F + GAMEOBJECT_START; //1
		public static int GAMEOBJECT_END					= 0x010 + GAMEOBJECT_START;
		
		public static int DYNAMICOBJECT_START = GAMEOBJECT_END;
		public static int DYNAMICOBJECT_CASTER			= 0x00 + DYNAMICOBJECT_START;
		public static int DYNAMICOBJECT_BYTES			= 0x02 + DYNAMICOBJECT_START;
		public static int DYNAMICOBJECT_SPELLID			= 0x03 + DYNAMICOBJECT_START;
		public static int DYNAMICOBJECT_RADIUS			= 0x04 + DYNAMICOBJECT_START;
		public static int DYNAMICOBJECT_POS_X			= 0x05 + DYNAMICOBJECT_START;
		public static int DYNAMICOBJECT_POS_Y			= 0x06 + DYNAMICOBJECT_START;
		public static int DYNAMICOBJECT_POS_Z			= 0x07 + DYNAMICOBJECT_START;
		public static int DYNAMICOBJECT_FACING			= 0x08 + DYNAMICOBJECT_START;
		public static int DYNAMICOBJECT_PAD				= 0x09 + DYNAMICOBJECT_START;
		public static int DYNAMICOBJECT_END				= 0x0A + DYNAMICOBJECT_START;
		
		
		public static int CORPSE_START = GAMEOBJECT_END;
		public static int CORPSE_FIELD_OWNER				= 0x00 + CORPSE_START;
		public static int CORPSE_FIELD_FACING			= 0x02 + CORPSE_START;
		public static int CORPSE_FIELD_POS_X				= 0x03 + CORPSE_START;
		public static int CORPSE_FIELD_POS_Y				= 0x04 + CORPSE_START;
		public static int CORPSE_FIELD_POS_Z				= 0x05 + CORPSE_START;
		public static int CORPSE_FIELD_DISPLAY_ID		= 0x06 + CORPSE_START;
		public static int CORPSE_FIELD_ITEM0				= 0x07 + CORPSE_START;
		public static int CORPSE_FIELD_ITEM1				= 0x08 + CORPSE_START;
		public static int CORPSE_FIELD_ITEM2				= 0x09 + CORPSE_START;
		public static int CORPSE_FIELD_ITEM3				= 0x0A + CORPSE_START;
		public static int CORPSE_FIELD_ITEM4				= 0x0B + CORPSE_START;
		public static int CORPSE_FIELD_ITEM5				= 0x0C + CORPSE_START;
		public static int CORPSE_FIELD_BYTES_1			= 0x1A + CORPSE_START;
		public static int CORPSE_FIELD_BYTES_2			= 0x1B + CORPSE_START;
		public static int CORPSE_FIELD_GUILD				= 0x1C + CORPSE_START;
		public static int CORPSE_FIELD_FLAGS				= 0x1D + CORPSE_START;

		public const int SMSG_MESSAGECHAT			= 0x96;
	}
}
