#include "Globals.h"
#include "Player.h"
#include "Client.h"
#include "DBCHandler.h"
#include "Creature.h"
#include "UpdateBlock.h"
#include "Guild.h"
#include "Party.h"

CPlayer::CPlayer(void):CWoWObject(OBJ_PLAYER), CUpdateObject(PLAYER_MAX_BITS)
{
	Clear();
	pClient=0;
	_ftime(&LastAttack);
}

CPlayer::~CPlayer(void)
{
	Delete();
}

unsigned long CPlayer::GetCharListData(char *buffer)
{
	unsigned char c=0;
	strcpy(&buffer[c],Data.Name);
	c+=strlen(Data.Name)+1;
	buffer[c++]=Data.Race;
	buffer[c++]=Data.Class;
	buffer[c++]=Data.Female;
	memcpy(&buffer[c],Data.Appearance,5);
	c+=5;
	buffer[c++]=Data.Level;
	*(unsigned long*)&buffer[c]=Data.Zone;
	c+=4;
	*(unsigned long*)&buffer[c]=Data.Continent;
	c+=4;
	memcpy(&buffer[c],&Data.Loc,sizeof(_Location));
	c+=sizeof(_Location);
	c+=0x04; // old uint
	c+=0x04; // new uint
	c+=0x01; // new byte
	c+=0x0C; // old vals
	// item model numbers and slots
	for (unsigned char i = 0 ; i < 0x13 ; i++)
	{
		if (unsigned long ItemID=Data.Items[i])
		{
			CItem *pItem=0;
			if (DataManager.RetrieveObject((CWoWObject**)&pItem,ItemID))
			{
				CItemTemplate *pItemTemplate=0;
				if (DataManager.RetrieveObject((CWoWObject**)&pItemTemplate,pItem->Data.nItemTemplate))
				{
					*(unsigned long*)&buffer[c]=pItemTemplate->Data.DisplayID;
					c+=4;
					buffer[c++]=(char)pItemTemplate->Data.InvType;
				}
				else c+=5;
			}
			else c+=5;
		}
		else
			c+=5;
	}
	c+=5;

	return c;
}

void CPlayer::New(const char *Name, unsigned char *Attributes)
{
//______________________________________________________________
//Outgoing Data :8086 len=0013 op=0036 int=0000 msglen=000F -- clientconnection::charactercreate
//      |                 |racclssex  |  |  |  |  |??
//0000:  73 70 6F 72-6B 00 02 01-00 07 02 05-00 06 00     spork.......... 
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	Clear();
	CWoWObject::New();
	strcpy(Data.Name,Name);
	Data.Race=Attributes[0];
	Data.Class=Attributes[1];
	Data.Female=(Attributes[2]!=0);
	Data.Level=1;
	Data.walkspeed=DEFAULT_PLAYER_WALK_SPEED;
	Data.runspeed=DEFAULT_PLAYER_RUN_SPEED;
	Data.swimspeed=DEFAULT_PLAYER_SWIM_SPEED;
	Data.TutorialFlags.Unknown[0]=0xFF;
	dead = false;
	armor_buff = false;
	
	// apply class/race bonuses and penalties to the normal stats.
	// current stats are copied directly from these at the end of
	// character creation
	Data.NormalStats.HitPoints=50;
	Data.NormalStats.Mana=86;
	Data.NormalStats.Energy=1000;
	Data.NormalStats.Focus=10;
	Data.NormalStats.Rage=100;
	Data.NormalStats.Agility=20;
	Data.NormalStats.Strength=20;
	Data.NormalStats.Stamina=20;
	Data.NormalStats.Intellect=20;
	Data.NormalStats.Spirit=20;
	Data.NormalStats.ResistFire=0;
	Data.NormalStats.ResistFrost=0;
	Data.NormalStats.ResistHoly=0;
	Data.NormalStats.ResistShadow=0;
	Data.NormalStats.ResistNature=0;

	Data.AttackSpeed=1900;
	Data.DamageMax=12;
	Data.DamageMin=7;
	Data.NextLevelExp=1000;
	
	memcpy(Data.Appearance,&Attributes[3],5);
	
	Data.Loc=RaceStartingPoints[Data.Race].Loc;
	Data.Continent=RaceStartingPoints[Data.Race].Continent;
	Data.Facing=RaceStartingPoints[Data.Race].Facing;
	Data.Zone=RaceStartingPoints[Data.Race].Zone;

	switch(Data.Race)
	{
		case RACE_HUMAN:
			Data.Size=0x3F800000;
//			Data.Loc.X=-8897.70f;
//			Data.Loc.Y=-173.28f;
//			Data.Loc.Z=81.51f;
//			Data.Continent=0;
//			Data.Zone=0x9;
			Data.Model=0x31+Data.Female;
//			Data.Facing=0.0f;//north
			break;
		case RACE_ORC:
			Data.Size=0x3F8CCCCD;
//			Data.Continent=1;
//			Data.Zone=0x16A;
//			Data.Loc.X=307.88f;
//			Data.Loc.Y=-4724.13f;
//			Data.Loc.Z=10.05f;
			Data.Model=0x33+Data.Female;
//			Data.Facing=0.0f;//north
			break;
		case RACE_TROLL:
			Data.Size=0x3F800000;
//			Data.Continent=1;
//			Data.Zone=0x16A;
//			Data.Loc.X=307.88f;
//			Data.Loc.Y=-4724.13f;
//			Data.Loc.Z=10.05f;
			Data.Model=0x5C6+Data.Female;
//			Data.Facing=0.0f;//north
			break;
		case RACE_GNOME:
			//Data.Size=0x3F4CCCCD;
			Data.Size=0x3F800000;
//			Data.Loc.X=-5639.30f;
//			Data.Loc.Y=-493.65f;
//			Data.Loc.Z=396.66f;
//			Data.Continent=0;
//			Data.Zone=0x83;
			Data.Model=0x61B+Data.Female;
//			Data.Facing=0.0f;//north
			break;
		case RACE_DWARF:
			Data.Size=0x3F800000;
//			Data.Loc.X=-5639.30f;
//			Data.Loc.Y=-493.65f;
//			Data.Loc.Z=396.66f;
//			Data.Continent=0;
//			Data.Zone=0x83;
			Data.Model=0x35+Data.Female;
//			Data.Facing=0.0f;//north
			break;
		case RACE_NIGHTELF:
			Data.Size=0x3F800000;
//			Data.Continent=1;
//			Data.Zone=0xBA;
//			Data.Loc.X=9862.68f;
//			Data.Loc.Y=952.69f;
//			Data.Loc.Z=1306.53f;
			Data.Model=0x37+Data.Female;
//			Data.Facing=0.0f;//north
			break;
		case RACE_UNDEAD:
			Data.Size=0x3F800000;
//			Data.Loc.X=2037.08f;
//			Data.Loc.Y=74.16f;
//			Data.Loc.Z=33.98f;
//			Data.Continent=0;
//			Data.Zone=0x55;
			Data.Model=0x39+Data.Female;
//			Data.Facing=0.0f;//north
			break;
		case RACE_TAUREN:
			Data.Size=0x3F800000;
//			Data.Loc.X=-1015.32f;
//			Data.Loc.Y=-45.61f;
//			Data.Loc.Z=69.31f;
//			Data.Continent=1;
//			Data.Zone=0x1D6;
			Data.Model=0x3B+Data.Female;
//			Data.Facing=0.0f;//north
			break;
	}

#define SETITEM(id, slot)\
			pItem = new CItem;\
			pItem->New(id, guid);\
			DataManager.NewObject(*pItem);\
			Data.Items[slot]=pItem->guid;
	CItem *pItem;
	switch(Data.Class)
	{
	case CLASS_WARRIOR:
		{
			Data.ManaType=1;
			SETITEM(STATICITEMS::WARRIOR_SHORTSWORD, SLOT_MAINHAND);
			SETITEM(STATICITEMS::WARRIOR_SHIELD, SLOT_OFFHAND);
			if(Data.Race == RACE_HUMAN || Data.Race == RACE_DWARF || Data.Race == RACE_GNOME)
			{
				SETITEM(STATICITEMS::WARRIOR_SHIRT, SLOT_SHIRT);
				SETITEM(STATICITEMS::WARRIOR_PANTS, SLOT_LEGS);
				SETITEM(STATICITEMS::WARRIOR_BOOTS, SLOT_FEET);
			}
			else if(Data.Race == RACE_NIGHTELF)
			{
				SETITEM(STATICITEMS::NE_WARRIOR_SHIRT, SLOT_SHIRT);
				SETITEM(STATICITEMS::NE_WARRIOR_PANTS, SLOT_LEGS);
				SETITEM(STATICITEMS::NE_WARRIOR_BOOTS, SLOT_FEET);
			}
			else
			{
				SETITEM(STATICITEMS::EVIL_WARRIOR_SHIRT, SLOT_SHIRT);
				SETITEM(STATICITEMS::EVIL_WARRIOR_PANTS, SLOT_LEGS);
				if(Data.Race == RACE_ORC || Data.Race == RACE_UNDEAD)
				{
					SETITEM(STATICITEMS::EVIL_WARRIOR_BOOTS, SLOT_FEET);
				}
			}
		}
		break;
	case CLASS_PALADIN:
		{
			SETITEM(STATICITEMS::PALADIN_HAMMER, SLOT_MAINHAND);
			SETITEM(STATICITEMS::PALADIN_BOOTS, SLOT_FEET);
			if(Data.Race == RACE_HUMAN)
			{
				SETITEM(STATICITEMS::HUMAN_PALADIN_SHIRT, SLOT_SHIRT);
				SETITEM(STATICITEMS::HUMAN_PALADIN_PANTS, SLOT_LEGS);
			}
			else if(Data.Race == RACE_DWARF)
			{
				SETITEM(STATICITEMS::DWARF_PALADIN_SHIRT, SLOT_SHIRT);
				SETITEM(STATICITEMS::DWARF_PALADIN_PANTS, SLOT_LEGS);
			}
		}
		break;
	case CLASS_HUNTER:
		Data.ManaType=2;
		{
			SETITEM(STATICITEMS::HUNTER_AXE, SLOT_MAINHAND);
			SETITEM(STATICITEMS::HUNTER_SHIELD, SLOT_OFFHAND);
			switch(Data.Race)
			{
			case RACE_ORC:
				SETITEM(STATICITEMS::ORC_TAUREN_HUNTER_SHIRT, SLOT_SHIRT);
				SETITEM(STATICITEMS::ORC_TAUREN_HUNTER_PANTS, SLOT_LEGS);
				SETITEM(STATICITEMS::ORC_HUNTER_BOOTS, SLOT_FEET);				
				SETITEM(STATICITEMS::HUNTER_BOW, SLOT_RANGED);
				//SETITEM(STATICITEMS::HUNTER_QUIVER, SLOT_BAG1); // todo create containers!
				//SETITEM(STATICITEMS::HUNTER_ARROW, SLOT_INBACKPACK); // todo move it into the bag
				break;
			case RACE_DWARF:
				SETITEM(STATICITEMS::DWARF_NIGHTELF_HUNTER_SHIRT, SLOT_SHIRT);
				SETITEM(STATICITEMS::DWARF_NIGHTELF_HUNTER_PANTS, SLOT_LEGS);
				SETITEM(STATICITEMS::DWARF_NIGHTELF_HUNTER_BOOTS, SLOT_FEET);

				SETITEM(STATICITEMS::HUNTER_RIFLE, SLOT_RANGED);
				//SETITEM(STATICITEMS::HUNTER_AMMO_POUCH, SLOT_BAG1); // todo create containers!
				//SETITEM(STATICITEMS::HUNTER_BULLET, SLOT_INBACKPACK); // todo move it into the bag
				break;
			case RACE_NIGHTELF:
				SETITEM(STATICITEMS::DWARF_NIGHTELF_HUNTER_SHIRT, SLOT_SHIRT);
				SETITEM(STATICITEMS::DWARF_NIGHTELF_HUNTER_PANTS, SLOT_LEGS);
				SETITEM(STATICITEMS::DWARF_NIGHTELF_HUNTER_BOOTS, SLOT_FEET);

				SETITEM(STATICITEMS::HUNTER_BOW, SLOT_RANGED);
				//SETITEM(STATICITEMS::HUNTER_QUIVER, SLOT_BAG1); // todo create containers!
				//SETITEM(STATICITEMS::HUNTER_ARROW, SLOT_INBACKPACK); // todo move it into the bag
				break;
			case RACE_TAUREN:
				SETITEM(STATICITEMS::ORC_TAUREN_HUNTER_SHIRT, SLOT_SHIRT);
				SETITEM(STATICITEMS::ORC_TAUREN_HUNTER_PANTS, SLOT_LEGS);
				SETITEM(STATICITEMS::HUNTER_RIFLE, SLOT_RANGED);
				//SETITEM(STATICITEMS::HUNTER_AMMO_POUCH, SLOT_BAG1); // todo create containers!
				//SETITEM(STATICITEMS::HUNTER_BULLET, SLOT_INBACKPACK); // todo move it into the bag
				break;
			case RACE_TROLL:
				SETITEM(STATICITEMS::TROLL_HUNTER_SHIRT, SLOT_SHIRT);
				SETITEM(STATICITEMS::TROLL_HUNTER_PANTS, SLOT_LEGS);
				SETITEM(STATICITEMS::HUNTER_BOW, SLOT_RANGED);
				//SETITEM(STATICITEMS::HUNTER_QUIVER, SLOT_BAG1); // todo create containers!
				//SETITEM(STATICITEMS::HUNTER_ARROW, SLOT_INBACKPACK); // todo move it into the bag
				break;
			}
		}
		break;
	case CLASS_ROGUE:
		Data.ManaType=3;
		{
			SETITEM(STATICITEMS::ROGUE_DAGGER, SLOT_MAINHAND);
			switch(Data.Race)
			{
			case RACE_HUMAN:
			case RACE_DWARF:
			case RACE_NIGHTELF:
			case RACE_GNOME:
				SETITEM(STATICITEMS::GOOD_ROGUE_SHIRT, SLOT_SHIRT);
				SETITEM(STATICITEMS::GOOD_ROGUE_PANTS, SLOT_LEGS);
				SETITEM(STATICITEMS::GOOD_ROGUE_BOOTS, SLOT_FEET);
				break;
			case RACE_TROLL:
				SETITEM(STATICITEMS::TROLL_ROGUE_CHEST, SLOT_CHEST);
				SETITEM(STATICITEMS::TROLL_ROGUE_PANTS, SLOT_LEGS);
				SETITEM(STATICITEMS::TROLL_ROGUE_BOOTS, SLOT_FEET);
				break;
			default:
				SETITEM(STATICITEMS::EVIL_ROGUE_CHEST, SLOT_CHEST);
				SETITEM(STATICITEMS::EVIL_ROGUE_PANTS, SLOT_LEGS);
				SETITEM(STATICITEMS::EVIL_ROGUE_BOOTS, SLOT_FEET);
				break;
			}
		}
		break;
	case CLASS_PRIEST:
		{
			if(Data.Race != RACE_TROLL)
			{
				SETITEM(STATICITEMS::PRIEST_BOOTS, SLOT_FEET);
			}
			SETITEM(STATICITEMS::PRIEST_MACE, SLOT_MAINHAND);
			SETITEM(STATICITEMS::PRIEST_PANTS, SLOT_LEGS);
			SETITEM(STATICITEMS::PRIEST_SHIRT, SLOT_SHIRT);
			if(Data.Race == RACE_HUMAN || Data.Race == RACE_DWARF)
			{
				SETITEM(STATICITEMS::HUMAN_DWARF_PRIEST_ROBE, SLOT_CHEST);
			}
			else if(Data.Race == RACE_NIGHTELF)
			{
				SETITEM(STATICITEMS::NIGHTELF_PRIEST_ROBE, SLOT_CHEST);
			}
			else
			{
				SETITEM(STATICITEMS::UNDEAD_TROLL_PRIEST_ROBE, SLOT_CHEST);
			}
		}
		break;
	case CLASS_SHAMAN:
		{
			SETITEM(STATICITEMS::SHAMAN_MACE, SLOT_MAINHAND);
			if(Data.Race == RACE_ORC || Data.Race == RACE_TAUREN)
			{
				SETITEM(STATICITEMS::ORC_TAUREN_SHAMAN_SHIRT, SLOT_SHIRT);
				SETITEM(STATICITEMS::ORC_TAUREN_SHAMAN_PANTS, SLOT_LEGS);
			}
			else if(Data.Race == RACE_TROLL)
			{
				SETITEM(STATICITEMS::TROLL_SHAMAN_SHIRT, SLOT_SHIRT);
				SETITEM(STATICITEMS::TROLL_SHAMAN_PANTS, SLOT_LEGS);
			}
		}
		break;
	case CLASS_MAGE:
		{
			SETITEM(STATICITEMS::MAGE_STAFF, SLOT_MAINHAND);
			SETITEM(STATICITEMS::MAGE_SHIRT, SLOT_SHIRT);
			SETITEM(STATICITEMS::MAGE_PANTS, SLOT_LEGS);
			SETITEM(STATICITEMS::MAGE_BOOTS, SLOT_FEET);
			if(Data.Race == RACE_HUMAN || Data.Race == RACE_GNOME)
			{
				SETITEM(STATICITEMS::HUMAN_GNOME_MAGE_ROBE, SLOT_CHEST);
			}
			else if(Data.Race == RACE_DWARF)
			{
				SETITEM(STATICITEMS::DWARF_MAGE_ROBE, SLOT_CHEST);
			}
			else
			{
				SETITEM(STATICITEMS::UNDEAD_TROLL_MAGE_ROBE, SLOT_CHEST);
			}
		}
		break;
	case CLASS_WARLOCK:
		{
			SETITEM(STATICITEMS::WARLOCK_DAGGER, SLOT_MAINHAND);
			SETITEM(STATICITEMS::WARLOCK_PANTS, SLOT_LEGS);
			SETITEM(STATICITEMS::WARLOCK_BOOTS, SLOT_FEET);
			if(Data.Race == RACE_HUMAN || Data.Race == RACE_GNOME)
			{
				SETITEM(STATICITEMS::HUMAN_GNOME_WARLOCK_ROBE, SLOT_CHEST);
				SETITEM(STATICITEMS::HUMAN_GNOME_WARLOCK_SHIRT, SLOT_SHIRT);
			}
			else
			{
				SETITEM(STATICITEMS::ORC_UNDEAD_WARLOCK_ROBE, SLOT_CHEST);
			}
		}
		break;
	case CLASS_DRUID:
		{
			SETITEM(STATICITEMS::DRUID_PANTS, SLOT_LEGS);
			if(Data.Race == RACE_NIGHTELF)
			{
				SETITEM(STATICITEMS::NIGHTELF_DRUID_STAFF, SLOT_MAINHAND);
				SETITEM(STATICITEMS::NIGHTELF_DRUID_ROBE, SLOT_CHEST);
			}
			else if(Data.Race == RACE_TAUREN)
			{
				SETITEM(STATICITEMS::TAUREN_DRUID_STAFF, SLOT_MAINHAND);
				SETITEM(STATICITEMS::TAUREN_DRUID_ROBE, SLOT_CHEST);
			}
		}
		break;
	}
#undef SETITEM
	// make copies of any data that needs to be copied
	Data.CurrentStats=Data.NormalStats;
	Data.BindContinent=Data.Continent;
	Data.BindLoc=Data.Loc;
	string LowerName=Data.Name;
	MakeLower(LowerName);
	DataManager.PlayerNames[LowerName]=guid;

	// PvP stuff
	Data.PvP = false;
	Data.RecentPvP = false;
	Data.ResurrectionSickness = false;

	// Status flags (AFK, DND, GM)
	Data.StatusFlags = 0x00;

	Data.LFG = 0x00;
	Data.PartyID = 0;
	Data.PartyRank = 0;

	// for testing
	Data.TestCode = 0x07;
	Data.MountModel = 0;

	Data.bSummoned = false;
	Data.Copper = 1;
}

void CPlayer::Clear()
{
	CWoWObject::Clear();
	memset(&Data,0,sizeof(PlayerData));
	TargetID=0;
//	for (unsigned long i = 0 ; i < 40 ; i++)
//		Items[i].Clear();
}


unsigned long CPlayer::AddCreateObjectDataNotMe(char *buffer)
{
#define Add(datatype,data) *(datatype*)&buffer[c]=data;c+=sizeof(datatype);
	unsigned long c=0;

	// HEADER
	Add(unsigned long,guid);
	Add(unsigned long,PLAYERGUID_HIGH);
	Add(unsigned char,ID_PLAYER);
		// Move Update
		Add(unsigned long, 0);//x04000000); // movement flags
		Add(_Location, Data.Loc);
		Add(float, Data.Facing);
		Add(float, Data.walkspeed);// walk speed
		Add(float, Data.runspeed);// runspeed
		Add(float, Data.swimspeed);// swimspeed
		Add(float, DEFAULT_PLAYER_TURN_RATE);// turn rate
	Add(unsigned long,0);
	Add(unsigned long,1);
	Add(unsigned long,0);
	Add(unsigned long,0);
	Add(unsigned long,0);
#undef Add
	return c;
}


unsigned long CPlayer::AddCreateObjectDataOnlyMe(char *buffer)
{
#define Add(datatype,data) *(datatype*)&buffer[c]=data;c+=sizeof(datatype);
	unsigned long c=0;

	// HEADER
	Add(unsigned long,guid);
	Add(unsigned long,PLAYERGUID_HIGH);
	Add(unsigned char,ID_PLAYER);
		// Move Update
		Add(unsigned long, 0);//x04000000); // movement flags
		Add(_Location, Data.Loc);
		Add(float, Data.Facing);
		Add(float, Data.walkspeed);// walk speed
		Add(float, Data.runspeed);// runspeed
		Add(float, Data.swimspeed);// swimspeed
		Add(float, DEFAULT_PLAYER_TURN_RATE);// turn rate
	Add(unsigned long,1);
	Add(unsigned long,1);
	Add(unsigned long,0);
	Add(unsigned long,0);
	Add(unsigned long,0);
#undef Add
	return c;
}

void CPlayer::PreCreateObjectNotMe()
{
	// add create update values here that concerns other players (up to field 250 i think)
	AddUpdateVal(OBJECT_GUID, guid);
	AddUpdateVal(OBJECT_HIER_TYPE, HIER_TYPE_PLAYER); 
	AddUpdateVal(OBJECT_SCALE, Data.Size);
	AddUpdateVal(UNIT_HEALTH, Data.CurrentStats.HitPoints);
	AddUpdateVal(UNIT_MANA, Data.CurrentStats.Mana);
	AddUpdateVal(UNIT_RAGE, Data.CurrentStats.Rage);
	AddUpdateVal(UNIT_FOCUS, Data.CurrentStats.Focus);
	AddUpdateVal(UNIT_ENERGY, Data.CurrentStats.Energy);
	AddUpdateVal(UNIT_MAX_HEALTH, Data.NormalStats.HitPoints);
	AddUpdateVal(UNIT_MAX_MANA, Data.NormalStats.Mana);
	AddUpdateVal(UNIT_MAX_RAGE, Data.NormalStats.Rage);
	AddUpdateVal(UNIT_MAX_FOCUS, Data.NormalStats.Focus);
	AddUpdateVal(UNIT_MAX_ENERGY, Data.NormalStats.Energy);
	AddUpdateVal(UNIT_LEVEL, Data.Level);
	if ((Data.ResurrectionSickness) || (!Data.PvP)) {
		AddUpdateVal(UNIT_FACTION, 5); // Faction template
	}
	else
		AddUpdateVal(UNIT_FACTION, 1);
	AddUpdateVal(UNIT_BYTES_0, Data.Race | Data.Class << 8 | Data.Female << 16 | Data.ManaType << 24);

	if(Data.MountModel)
		AddUpdateVal(UNIT_FLAGS, 0x3000);
	else
		AddUpdateVal(UNIT_FLAGS, 0);

	AddUpdateVal(UNIT_BASEATTACKTIME0, Data.AttackSpeed); // attack speed
	AddUpdateVal(UNIT_BASEATTACKTIME1, 0x7D0); // probably other hand attack speed

	AddUpdateVal(UNIT_BOUNDING_RADIUS,0x3EC41893);// Bounding Radius
	AddUpdateVal(UNIT_COMBAT_REACH,0x3FC00000); // Combat Reach
	AddUpdateVal(UNIT_DISPLAYID,Data.Model);
	AddUpdateVal(UNIT_MOUNT_DISPLAYID,Data.MountModel);

	AddUpdateVal(UNIT_BYTES_1,Data.WeaponMode << 24 | (Data.StandState & 0xF));
	AddUpdateVal(PLAYER_GUILD_ID,Data.GuildID);
	AddUpdateVal(PLAYER_GUILD_RANK,Data.GuildRank);

	AddUpdateVal(PLAYER_BYTES_1, *(unsigned long*)Data.Appearance);
	AddUpdateVal(PLAYER_BYTES_2,Data.StatusFlags | (Data.Appearance[4] << 24));
	AddUpdateVal(PLAYER_GUILD_TIMESTAMP,Data.GuildTimestamp);

	for (unsigned long i = 0 ; i < 19 ; i++)
	{
		if (Data.Items[i])
		{
			AddUpdateVal(PLAYER_INV_SLOTS+i*2, Data.Items[i], ITEMGUID_HIGH);
		}
		/* hopefully with the new update system this won't be nessecery
		else
		{
			block.Add(PLAYER_INV_SLOTS+i*2, 0, 0);
		}
		*/
	}
}

void CPlayer::PreCreateObjectOnlyMe()
{
	// add create update values here that only concerns this player like chatfilter and whatnot
	AddUpdateVal(UNIT_FACTION, 5); // Psycho: dont set yourself other than 5 else you can attack anyone even if they not PVP
	AddUpdateVal(UNIT_STRENGTH, Data.CurrentStats.Strength);
	AddUpdateVal(UNIT_AGILITY, Data.CurrentStats.Agility);
	AddUpdateVal(UNIT_STAMINA, Data.CurrentStats.Stamina);
	AddUpdateVal(UNIT_INTELLECT, Data.CurrentStats.Intellect);
	AddUpdateVal(UNIT_SPIRIT, Data.CurrentStats.Spirit);
	AddUpdateVal(UNIT_BASE_STRENGTH, Data.NormalStats.Strength);
	AddUpdateVal(UNIT_BASE_AGILITY, Data.NormalStats.Agility);
	AddUpdateVal(UNIT_BASE_STAMINA, Data.NormalStats.Stamina);
	AddUpdateVal(UNIT_BASE_INTELLECT, Data.NormalStats.Intellect);
	AddUpdateVal(UNIT_BASE_SPIRIT, Data.NormalStats.Spirit);

	AddUpdateVal(UNIT_COINAGE, 100000);//Data.Copper);
	
	AddUpdateVal(UNIT_RESISTANCE_PHYSICAL,Data.CurrentStats.Armor);
	AddUpdateVal(UNIT_RESISTANCE_HOLY,Data.CurrentStats.ResistHoly);
	AddUpdateVal(UNIT_RESISTANCE_FIRE,Data.CurrentStats.ResistFire);
	AddUpdateVal(UNIT_RESISTANCE_NATURE,Data.CurrentStats.ResistNature);
	AddUpdateVal(UNIT_RESISTANCE_FROST,Data.CurrentStats.ResistFrost);
	AddUpdateVal(UNIT_RESISTANCE_SHADOW,Data.CurrentStats.ResistShadow);
	AddUpdateVal(UNIT_MIN_DAMAGE, Data.DamageMin);
	AddUpdateVal(UNIT_MAX_DAMAGE, Data.DamageMax);
	
	AddUpdateVal(UNIT_MOD_DAMAGE_DONE, Data.MeleeBonus);//block.Add(120,Data.MeleeBonus);
/*
	This needs to be changed
	block.Add(154,Data.NormalStats.Armor);
	block.Add(155,Data.NormalStats.ResistHoly);
	block.Add(156,Data.NormalStats.ResistFire);
	block.Add(157,Data.NormalStats.ResistNature);
	block.Add(158,Data.NormalStats.ResistFrost);
	block.Add(159,Data.NormalStats.ResistShadow);
*/
	for (unsigned long i = 19 ; i < 70 ; i++)
	{
		if (Data.Items[i])
		{
			AddUpdateVal(PLAYER_INV_SLOTS+i*2, Data.Items[i], ITEMGUID_HIGH);
		}
		/* hopefully with the new update system this won't be nessecery
		else
		{
			block.Add(PLAYER_INV_SLOTS+i*2, 0, 0);
		}*/
	}

	AddUpdateVal(PLAYER_XP,Data.Exp);
	AddUpdateVal(PLAYER_NEXT_LEVEL_XP,Data.NextLevelExp);

	AddUpdateVal(PLAYER_BASE_MANA,0x4B0);
}

void CPlayer::PostCreateObjectNotMe()
{
	// create visible items here?
}

void CPlayer::PostCreateObjectOnlyMe()
{
	// create none visible items here?
}

unsigned long CPlayer::GetPlayerInfoData(char *buffer, bool Create)
{
#define Add(datatype,data) *(datatype*)&buffer[c]=data;c+=sizeof(datatype);
#define Skip(n) c+=n;
#define Fill(size,value) memset(&buffer[c],value,size);c+=size;
	int c=0;

	// HEADER
	Add(unsigned long,guid);
	Skip(4);
	if (Create)
	{
		Add(unsigned char,4);
			// Move Update
			Add(unsigned long, 0);//x04000000); // movement flags
			Add(_Location, Data.Loc);
			Add(float, Data.Facing);
			Add(float, Data.walkspeed);// walk speed
			Add(float, Data.runspeed);// runspeed
			Add(float, Data.swimspeed);// swimspeed
			Add(float, DEFAULT_PLAYER_TURN_RATE);// turn rate
		Add(unsigned long,1);
		Add(unsigned long,1);
		Skip(0x0C);
	}

#undef Fill
#undef Skip
#undef Add

	// PLAYER
	CUpdateBlock block(&buffer[c], PLAYER_MAX_BITS);
	block.Add(OBJECT_GUID, guid);
	block.Add(OBJECT_HIER_TYPE, HIER_TYPE_PLAYER); 
	block.Add(OBJECT_SCALE, Data.Size);
	block.Add(UNIT_HEALTH, Data.CurrentStats.HitPoints);
	block.Add(UNIT_MANA, Data.CurrentStats.Mana);
	block.Add(UNIT_RAGE, Data.CurrentStats.Rage);
	block.Add(UNIT_FOCUS, Data.CurrentStats.Focus);
	block.Add(UNIT_ENERGY, Data.CurrentStats.Energy);
	block.Add(UNIT_MAX_HEALTH, Data.NormalStats.HitPoints);
	block.Add(UNIT_MAX_MANA, Data.NormalStats.Mana);
	block.Add(UNIT_MAX_RAGE, Data.NormalStats.Rage);
	block.Add(UNIT_MAX_FOCUS, Data.NormalStats.Focus);
	block.Add(UNIT_MAX_ENERGY, Data.NormalStats.Energy);
	block.Add(UNIT_LEVEL, Data.Level);
	//if ((Data.ResurrectionSickness) || (!Data.PvP)) {
	//	block.Add(33, 5); // Faction template
	//}
	//else
	block.Add(UNIT_FACTION, 5); // Psycho: dont set yourself other than 5 else you can attack anyone even if they not PVP
	block.Add(UNIT_BYTES_0, Data.Race | Data.Class << 8 | Data.Female << 16 | Data.ManaType << 24);
	block.Add(UNIT_STRENGTH, Data.CurrentStats.Strength);
	block.Add(UNIT_AGILITY, Data.CurrentStats.Agility);
	block.Add(UNIT_STAMINA, Data.CurrentStats.Stamina);
	block.Add(UNIT_INTELLECT, Data.CurrentStats.Intellect);
	block.Add(UNIT_SPIRIT, Data.CurrentStats.Spirit);
	block.Add(UNIT_BASE_STRENGTH, Data.NormalStats.Strength);
	block.Add(UNIT_BASE_AGILITY, Data.NormalStats.Agility);
	block.Add(UNIT_BASE_STAMINA, Data.NormalStats.Stamina);
	block.Add(UNIT_BASE_INTELLECT, Data.NormalStats.Intellect);
	block.Add(UNIT_BASE_SPIRIT, Data.NormalStats.Spirit);
	
	if(Data.MountModel)
		block.Add(UNIT_FLAGS, 0x3000);
	else
		block.Add(UNIT_FLAGS, 0);

	block.Add(UNIT_COINAGE, 100000);//Data.Copper);
	
	block.Add(UNIT_BASEATTACKTIME0,Data.AttackSpeed);
	block.Add(UNIT_BASEATTACKTIME1,2000); // unknown
	block.Add(UNIT_RESISTANCE_PHYSICAL,Data.CurrentStats.Armor);
	block.Add(UNIT_RESISTANCE_HOLY,Data.CurrentStats.ResistHoly);
	block.Add(UNIT_RESISTANCE_FIRE,Data.CurrentStats.ResistFire);
	block.Add(UNIT_RESISTANCE_NATURE,Data.CurrentStats.ResistNature);
	block.Add(UNIT_RESISTANCE_FROST,Data.CurrentStats.ResistFrost);
	block.Add(UNIT_RESISTANCE_SHADOW,Data.CurrentStats.ResistShadow);
	block.Add(UNIT_BOUNDING_RADIUS,0x3EC41893);// Bounding Radius
	block.Add(UNIT_COMBAT_REACH,0x3FC00000); // Combat Reach
	block.Add(UNIT_DISPLAYID,Data.Model);
	block.Add(UNIT_MOUNT_DISPLAYID,Data.MountModel);
	block.Add(UNIT_MIN_DAMAGE, Data.DamageMin);
	block.Add(UNIT_MAX_DAMAGE, Data.DamageMax);
	
	block.Add(UNIT_MOD_DAMAGE_DONE, Data.MeleeBonus);//block.Add(120,Data.MeleeBonus);
/*
	This needs to be changed
	block.Add(154,Data.NormalStats.Armor);
	block.Add(155,Data.NormalStats.ResistHoly);
	block.Add(156,Data.NormalStats.ResistFire);
	block.Add(157,Data.NormalStats.ResistNature);
	block.Add(158,Data.NormalStats.ResistFrost);
	block.Add(159,Data.NormalStats.ResistShadow);
*/
	block.Add(UNIT_BYTES_1,Data.WeaponMode << 24 | (Data.StandState & 0xF));

	if(Create)
	{
		block.Add(PLAYER_GUILD_ID,Data.GuildID);
		block.Add(PLAYER_GUILD_RANK,Data.GuildRank);
	}
	block.Add(PLAYER_BYTES_1, *(unsigned long*)Data.Appearance);
	block.Add(PLAYER_BYTES_2,Data.StatusFlags | (Data.Appearance[4] << 24));
	if(Create)
		block.Add(PLAYER_GUILD_TIMESTAMP,Data.GuildTimestamp); // guild timestamp

	for (unsigned long i = 0 ; i < 70 ; i++)
	{
		if (Data.Items[i])
		{
			block.Add(PLAYER_INV_SLOTS+i*2, Data.Items[i], ITEMGUID_HIGH);
		}
		else
		{
			block.Add(PLAYER_INV_SLOTS+i*2, 0, 0);
		}
	}

	block.Add(PLAYER_XP,Data.Exp);
	block.Add(PLAYER_NEXT_LEVEL_XP,Data.NextLevelExp);
		
	block.Add(PLAYER_BASE_MANA,0x4B0);
	return block.GetSize() + c;

}


void CPlayer::ObjectNears(CWoWObject &Object)
{
	if (!pClient)
	{
		RegionManager.ObjectRemove(*this);
		return;
	}
	switch(Object.type)
	{
	case OBJ_ITEM:
		pClient->AddKnownItem(*(CItem*)&Object);
		break;
	case OBJ_CREATURE:
		pClient->AddKnownCreature(*(CCreature*)&Object);
		break;
	case OBJ_PLAYER:
		pClient->AddKnownPlayer(*(CPlayer*)&Object);
		break;
	}
}

void CPlayer::ObjectUpdates(CWoWObject &Object)
{
	if (!pClient)
	{
		RegionManager.ObjectRemove(*this);
		return;
	}
	switch(Object.type)
	{
	case OBJ_ITEM:
		pClient->UpdateKnownItem(*(CItem*)&Object);
		break;
	case OBJ_CREATURE:
		pClient->UpdateKnownCreature(*(CCreature*)&Object);
		break;
	case OBJ_PLAYER:
		pClient->UpdateKnownPlayer(*(CPlayer*)&Object);
		break;
	}
}

void CPlayer::ObjectFades(CWoWObject &Object)
{
	if (!pClient)
	{
		RegionManager.ObjectRemove(*this);
		return;
	}
	switch(Object.type)
	{
	case OBJ_ITEM:
		pClient->RemoveKnownItem(*(CItem*)&Object);
		break;
	case OBJ_CREATURE:
		pClient->RemoveKnownCreature(*(CCreature*)&Object);
		break;
	case OBJ_PLAYER:
		pClient->RemoveKnownPlayer(*(CPlayer*)&Object);
		break;
	}
}


unsigned long CPlayer::GetOtherPlayerInfoData(char *buffer, bool Create)
{
#define Add(datatype,data) *(datatype*)&buffer[c]=data;c+=sizeof(datatype);
#define Skip(n) c+=n;
#define Fill(size,value) memset(&buffer[c],value,size);c+=size;
	int c=0;
	// HEADER
	Add(unsigned long,guid);
	Skip(4);
	if (Create)
	{
		Add(unsigned char,4);
			//Move Update
			Add(unsigned long,0x04000000);//movement flags
			Add(_Location,Data.Loc); 
			Add(float,Data.Facing);
			Add(float,Data.walkspeed);// walk speed
			Add(float,Data.runspeed);// runspeed
			Add(float,Data.swimspeed);// swimspeed
			Add(float,DEFAULT_PLAYER_TURN_RATE);// turn rate
		Add(unsigned long,0);
		Add(unsigned long,1);
		Skip(12);
	}
#undef Fill
#undef Skip
#undef Add

	// PLAYER
	CUpdateBlock block(&buffer[c], PLAYER_MAX_BITS);
	block.Add(OBJECT_GUID, guid);
	block.Add(OBJECT_HIER_TYPE, HIER_TYPE_PLAYER); 
	block.Add(OBJECT_SCALE, Data.Size);
	block.Add(UNIT_HEALTH, Data.CurrentStats.HitPoints);
	block.Add(UNIT_MANA, Data.CurrentStats.Mana);
	block.Add(UNIT_RAGE, Data.CurrentStats.Rage);
	block.Add(UNIT_FOCUS, Data.CurrentStats.Focus);
	block.Add(UNIT_ENERGY, Data.CurrentStats.Energy);
	block.Add(UNIT_MAX_HEALTH, Data.NormalStats.HitPoints);
	block.Add(UNIT_MAX_MANA, Data.NormalStats.Mana);
	block.Add(UNIT_MAX_RAGE, Data.NormalStats.Rage);
	block.Add(UNIT_MAX_FOCUS, Data.NormalStats.Focus);
	block.Add(UNIT_MAX_ENERGY, Data.NormalStats.Energy);
	block.Add(UNIT_LEVEL, Data.Level);
	if ((Data.ResurrectionSickness) || (!Data.PvP)) {
		block.Add(UNIT_FACTION, 5); // Faction template
	}
	else
		block.Add(UNIT_FACTION, 1);
	block.Add(UNIT_BYTES_0, Data.Race | Data.Class << 8 | Data.Female << 16 | Data.ManaType << 24);

	if(Data.MountModel)
		block.Add(UNIT_FLAGS, 0x3000);
	else
		block.Add(UNIT_FLAGS, 0);

	block.Add(UNIT_BASEATTACKTIME0, Data.AttackSpeed); // attack speed
	block.Add(UNIT_BASEATTACKTIME1, 0x7D0); // probably other hand attack speed

	block.Add(UNIT_BOUNDING_RADIUS,0x3EC41893);// Bounding Radius
	block.Add(UNIT_COMBAT_REACH,0x3FC00000); // Combat Reach
	block.Add(UNIT_DISPLAYID,Data.Model);
	block.Add(UNIT_MOUNT_DISPLAYID,Data.MountModel);

	block.Add(UNIT_BYTES_1,Data.WeaponMode << 24 | (Data.StandState & 0xF));

	if(Create)
	{
		block.Add(PLAYER_GUILD_ID,Data.GuildID);
		block.Add(PLAYER_GUILD_RANK,Data.GuildRank);
	}

	block.Add(PLAYER_BYTES_1, *(unsigned long*)Data.Appearance);
	block.Add(PLAYER_BYTES_2,Data.StatusFlags | (Data.Appearance[4] << 24));
	if(Create)
		block.Add(PLAYER_GUILD_TIMESTAMP,Data.GuildTimestamp);

	for (unsigned long i = 0 ; i < 19 ; i++)
	{
		if (Data.Items[i])
		{
			block.Add(PLAYER_INV_SLOTS+i*2, Data.Items[i], ITEMGUID_HIGH);
		}
		else
		{
			block.Add(PLAYER_INV_SLOTS+i*2, 0, 0);
		}
	}
	block.Add(PLAYER_BASE_MANA,0x4B0);

	return block.GetSize() + c;

}

void CPlayer::Delete()
{
	string Name=Data.Name;
	MakeLower(Name);
	DataManager.PlayerNames[Name]=0;
	RegionManager.ObjectRemove(*this);
	if(Data.GuildID != 0)
	{
		CGuild *pGuild;
		if(DataManager.RetrieveObject((CWoWObject**)&pGuild, OBJ_GUILD, Data.GuildID))
			pGuild->Leave(this);
		Data.GuildID = 0;
		Data.GuildRank = 0;
	}
	CWoWObject::Delete();
}

float CPlayer::Distance(CPlayer &Player)
{
	// distance =
	//      ______________________________
	//     /(( X2 - X1 )^2 + (Y2 - Y1) ^2)
	//   \/
	
	float A=Player.Data.Loc.X-Data.Loc.X;
	float B=Player.Data.Loc.Y-Data.Loc.Y;
	return sqrt((A*A)+(B*B));
}


void CPlayer::UseMana(int type, short id)
{
	if (type == DMGTYPE_SPELL)
	{	
		long mana = DBCManager.Spell.getValue(id, DBC_SPELL_COST);
		Data.CurrentStats.Mana -= mana;
		if ((long)(Data.CurrentStats.Mana) < 0) {
			Data.CurrentStats.Mana = 0;
		}
	}
}


long CPlayer::CalculateDmg(int type, short id, int &flag)
{
	// miss
	if (!(rand() % 4))
	{
		flag |= 0x01;
		return 0;
	}
	
	if (type == DMGTYPE_SPELL)
	{	
		long min_dmg = DBCManager.Spell.getValue(id, DBC_SPELL_MINDMG) + 1;
		long max_dmg = DBCManager.Spell.getValue(id, DBC_SPELL_MAXDMG);

		if (!max_dmg)
			max_dmg=1;
		long rv = min_dmg + (rand() % max_dmg);
		if (!min_dmg)
			return 0;
		return rv;
		
	}
	else if (type == DMGTYPE_WEAPON)
	{
		long diff = Data.DamageMax - Data.DamageMin;
		long rv;
		if (diff)
		{
			rv = Data.DamageMin + (rand() % diff);
		}
		else
			rv = Data.DamageMin;

		flag |= 0x02;

		if ((rand() % 100) < 3)
		{
			flag |= 0x08;
			rv += rv + (Data.Level * 2);
		}
		return rv;
	}
//	else if (type == DMGTYPE_WEAPON)
//	{
		// <alita>items need stats first to calculate the damage
//		long rv = rand() % 20;
//		return rv;
//	}
/*	else if (type == DMGTYPE_MELEE)
	{
		// <alita> dunno
		long rv = rand() % 20;
		return rv;
	}*/
	
	return 0;
}


void MsgAttackOn(CClient *pClient, _InData *pData); // forward dec it here for now

void CPlayer::ProcessEvent(struct WoWEvent &Event)
{
	switch(Event.EventType)
	{
	case EVENT_PLAYER_GAINEXP:
		{
			int expgain;
			memcpy(&expgain, Event.pEventData, sizeof(expgain));
			
			CParty *pParty = CParty::GetParty(pClient, false);
			if (pParty == NULL || Data.PvP)
			{
				AddExp(expgain);
			}
			else // split xp in the group
			{
				int i;
				expgain = (expgain * 75 / 100);
				if (expgain > 0)
				{
					for (i = 0; i < 5; i++)
					{
						if (pParty->Data.Members[i] != 0)
						{
							CPlayer *pMember = NULL;
							if(DataManager.RetrieveObject((CWoWObject**)&pMember, OBJ_PLAYER, pParty->Data.Members[i]))
							{
								if (pMember->pClient != NULL)
								{
									pMember->AddExp(expgain);;
								}
								else
								{
									pParty->Leave(pMember->Data.Name);
								}
							}
						}
					}
				}
			}
		}
		break;
	case EVENT_PLAYER_REGENERATE:
		Regenerate();
		break;
	case EVENT_PLAYER_REZSICKNESS:
		RezSickness();
		break;
	case EVENT_PLAYER_PVP:
		PvPToggle();
		break;
	case EVENT_PLAYER_REMOVE_AURA:
		{
		long aura_value;
		memcpy(&aura_value, Event.pEventData, sizeof(aura_value));
        Data.CurrentStats.Armor = Data.CurrentStats.Armor - aura_value;
		pClient->Echo("Your Armor buff has worn off.");
		armor_buff = false;
		}
		break;
	case EVENT_PLAYER_DOTTED:
		{
		long power;
		memcpy(&power, Event.pEventData, sizeof(power));
		Data.CurrentStats.HitPoints -= power;
		if (Data.CurrentStats.HitPoints <= 0 && !dead)
		{
			dead = true;
			char killer[50];
			sprintf(killer, "You have been slain by %s dot", ((CPlayer*)pCaster)->Data.Name);
			pClient->Echo(killer);
			ClearEvents();
			unsigned long expgain = Data.Level * 50;
			EventManager.AddEvent(*pCaster, 0, EVENT_PLAYER_GAINEXP, &expgain, sizeof(expgain));
		}
		UpdateHP();
		}
		break;
	case EVENT_PLAYER_END_ATTACK:
		{
			if(dead == false) // any more states that should not allow attacks?
			{
				char buffer[12];
				memcpy(&buffer[4], Event.pEventData, 8);
				_InData* pData = (_InData*)buffer;
				MsgAttackOn(pClient, pData);
			}
		}
		break;
	case EVENT_PLAYER_TAXI_END:
		{
			pClient->pPlayer->Data.MountModel = 0;
			char buffer[0x90];
			CUpdateBlock block;
			block.ResetBlock(buffer, 0x90);
			block.AddDataUpdate(PLAYER_MAX_BITS, pClient->pPlayer->guid, PLAYERGUID_HIGH);
			block.Add(UNIT_FLAGS, 0);
			block.Add(UNIT_MOUNT_DISPLAYID, 0);
			int size;
			char *ptr = block.GetCompressedData(size);
			if(size != 0)
				pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
		}
		break;
	}
}


void CPlayer::Regenerate()
{
	bool bResend = false;
	long bonus = 0;
	_timeb now;
	_ftime(&now);
	if(EventManager.DiffTime(now, LastAttack) < 20000) // No regen for 20 secs after last attack
	{													// TODO: Add a general "lastincombat" time
		EventManager.AddEvent(*this,10000,EVENT_PLAYER_REGENERATE,0,0);
		return;											
	}
	else if(Data.StandState == UNIT_SITTING)
		bonus = 5;
	else if(Data.StandState == UNIT_SLEEPING)
		bonus = 10;

	bonus = bonus + ((Data.Level * 2) - 2); // ADD 2HP / MANA Regen by level

	char buffer[0x100];
	CUpdateBlock block(0x100, buffer);
	block.AddDataUpdate(PLAYER_MAX_BITS, guid, PLAYERGUID_HIGH);
	if (Data.CurrentStats.HitPoints < Data.NormalStats.HitPoints) {
		Data.CurrentStats.HitPoints += PLAYER_REGEN_HPS + bonus;
		if (Data.CurrentStats.HitPoints > Data.NormalStats.HitPoints) {
			Data.CurrentStats.HitPoints = Data.NormalStats.HitPoints;
		}
		block.Add(UNIT_HEALTH, Data.CurrentStats.HitPoints);
		bResend = true;
	}
	if (Data.CurrentStats.Mana < Data.NormalStats.Mana) {
		Data.CurrentStats.Mana += PLAYER_REGEN_MANA + bonus;
		if (Data.CurrentStats.Mana > Data.NormalStats.Mana) {
			Data.CurrentStats.Mana = Data.NormalStats.Mana;
		}
		block.Add(UNIT_MANA, Data.CurrentStats.Mana);
		bResend = true;
	}
	if (Data.CurrentStats.Rage < Data.NormalStats.Rage) {
		Data.CurrentStats.Rage += PLAYER_REGEN_MANA + bonus;
		if (Data.CurrentStats.Rage > Data.NormalStats.Rage) {
			Data.CurrentStats.Rage = Data.NormalStats.Rage;
		}
		block.Add(UNIT_RAGE, Data.CurrentStats.Rage);
		bResend = true;
	}
	if (Data.CurrentStats.Focus < Data.NormalStats.Focus) {
		Data.CurrentStats.Focus += PLAYER_REGEN_MANA + bonus;
		if (Data.CurrentStats.Focus > Data.NormalStats.Focus) {
			Data.CurrentStats.Focus = Data.NormalStats.Focus;
		}
		block.Add(UNIT_FOCUS, Data.CurrentStats.Focus);
		bResend = true;
	}
	if (Data.CurrentStats.Energy < Data.NormalStats.Energy) {
		Data.CurrentStats.Energy += PLAYER_REGEN_MANA + bonus;
		if (Data.CurrentStats.Energy > Data.NormalStats.Energy) {
			Data.CurrentStats.Energy = Data.NormalStats.Energy;
		}
		block.Add(UNIT_ENERGY, Data.CurrentStats.Energy);
		bResend = true;
	}

	if (bResend) {
		int size;
		char *ptr = block.GetCompressedData(size);
		if(size)
			pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
	}
	EventManager.AddEvent(*this,10000,EVENT_PLAYER_REGENERATE,0,0);
}

void CPlayer::RezSickness()
{
	Data.ResurrectionSickness = false;
	pClient->Echo("Resurrection sickness has worn off...");
}

float CPlayer::Distance(CCreature &Creature)
{
	float A=Creature.Data.Loc.X-Data.Loc.X;
	float B=Creature.Data.Loc.Y-Data.Loc.Y;
	return sqrt((A*A)+(B*B));
}

float CPlayer::Distance(_Location &Loc)
{
	float A=Loc.X-Data.Loc.X;
	float B=Loc.Y-Data.Loc.Y;
	return sqrt((A*A)+(B*B));
}

void CPlayer::ApplySpellEffect(unsigned long SpellID, unsigned long Effect)
{
	unsigned long EffectID = DBCManager.Spell.getValue(SpellID, DBC_SPELL_EFFECT(Effect));
	// DO NOT ADD SWITCH ITEMS THAT DO NOT WORK AS THIS IS IN USE NOW
	switch(EffectID)
	{
		case 1: // InstaKill (Death Touch)
		{
			if (Effect == 1 && pCaster->type == OBJ_PLAYER)
				((CPlayer*)pCaster)->pClient->InterruptCast(SpellID);
			break;
			// too powerful :P
			long kill_type = DBCManager.Spell.getValue(SpellID, DBC_SPELL_ATTRIBUTE(Effect, SPELL_ATTRIB_TYPE));
			long kill_rand = DBCManager.Spell.getValue(SpellID, DBC_SPELL_ATTRIBUTE(Effect, SPELL_ATTRIB_RANDOMNESS));
			// Added random - Spell A24 // Have 1 change of 6 to self kill (Touch of the black claw)
			if (pCaster->type == OBJ_PLAYER) 
			{
				switch(kill_type)
				{
				case 1: // Self kill
					{
					if (!kill_rand)
						kill_rand=1;
					
					unsigned long kill_chance = 1 + (rand() % kill_rand);

					sendSpellMsg(9999, SpellID, false);
					if (kill_chance == 1) {
						Data.CurrentStats.HitPoints = 0;
						ClearEvents();
						UpdateHP();
						}
					}
					break;
				case 6: // target single kill
					{
					sendSpellMsg(9999, SpellID, false); // 9999 look cool but kinda useless :)
					Data.CurrentStats.HitPoints = 0;
					ClearEvents();
					UpdateHP();
					}
					break;
				//case 15: // AOE Kill
				//	break;
				}
			}
		}
		break;

		case 2: // direct damage (school damage)
		{
			long power = getPower(SpellID, Effect);
			long type = DBCManager.Spell.getValue(SpellID, DBC_SPELL_ATTRIBUTE(Effect, SPELL_ATTRIB_TYPE));
			long aura = DBCManager.Spell.getValue(SpellID, DBC_SPELL_ATTRIBUTE(Effect, SPELL_ATTRIB_AURA));

			if (pCaster->type == OBJ_PLAYER) 
			{
				if (Data.PvP && ((CPlayer*)pCaster)->Data.PvP)
				{
					switch(type)
					{
					case 6:  // School dmg
						{
						switch(aura)
							{
							case 0: // Direct Damage
							sendSpellMsg(power, SpellID, false);
							Data.CurrentStats.HitPoints -= power;
							if (Data.CurrentStats.HitPoints <= 0 && !dead)
							{
								dead = true;
								char killer[50];
								sprintf(killer, "You have been slain by %s", ((CPlayer*)pCaster)->Data.Name);
								pClient->Echo(killer);
								ClearEvents();
								unsigned long expgain = Data.Level * 50;
								EventManager.AddEvent(*pCaster, 0, EVENT_PLAYER_GAINEXP, &expgain, sizeof(expgain));
							}
							UpdateHP();
								break;

							case 3: // Damage Over Time (DoT)
								{
								long periodicity = DBCManager.Spell.getValue(SpellID, DBC_SPELL_ATTRIBUTE(Effect, SPELL_ATTRIB_PERIODICITY));
								long durationID = DBCManager.Spell.getValue(SpellID, DBC_SPELL_DURATION_ID);
								long mintime = DBCManager.SpellDuration.getValue(durationID, DBC_SPELLDURATION_MINTIME);
								long maxtime = DBCManager.SpellDuration.getValue(durationID, DBC_SPELLDURATION_MAXTIME);

								unsigned long dmg_tick = (maxtime / periodicity) / 1000; // Guessing tick wont be float putting it in sec
								for (unsigned long i = 0 ; i < dmg_tick ; i++) {
									EventManager.AddEvent(*this, (i * maxtime), EVENT_PLAYER_DOTTED, &power, sizeof(power));
									}
								}
								break;
							} // switch aura
						} // case 6
						break;
					} // switch type
				}
				else if (Effect == 1 && pCaster->type == OBJ_PLAYER)
				{
					((CPlayer*)pCaster)->pClient->Echo("You cant attack others unless you set PvP and they are also PvP");
					((CPlayer*)pCaster)->pClient->InterruptCast(SpellID);
				}
			}
			else
			{
				Data.CurrentStats.HitPoints -= power;
				if (Data.CurrentStats.HitPoints <= 0)
				{
					ClearEvents();
					dead = true;
				}
				RegionManager.ObjectResend(*this);
			}
		}
		break;

		case 5: // Teleport Units
		{
			long LocID = DBCManager.Spell.getValue(SpellID, 0); // Unknown loc ID yet, we just use the spell ID for now

			unsigned long zone = 0x9; // Default HUMAN location / zone
			unsigned long continent = 0;
			float loc_x = -8897.70f;
			float loc_y = -173.28f;
			float loc_z = 81.51f;
			float facing = 0.0f;

			switch(LocID)
			{
			case 3561: // StormWind Teleport spell ID
				Data.Loc.X = -9115.70f;
				Data.Loc.Y = 423.28f;
				Data.Loc.Z = 285.10f; // I keep falling
				Data.Continent = 0;
				Data.Zone = 0x9;
				Data.Facing = 0.0f;//north
				break;
			}
			char buf[0x11];
			memset(buf,0,0x11);
			//Data.Continent=buf[0]=continent;
			//memcpy(&buf[1],&pData->Data[5],0x10);
			//memcpy(&Data.Loc,&buf[1],sizeof(_Location));
			//Data.Facing=facing_loc;
			sendSpellMsg(0, SpellID, false);
			// TODO: Add a delay of 10 sec (spell cast time before sending out the packet)
			pClient->OutPacket(SMSG_NEW_WORLD,buf,0x11);
			RegionManager.ObjectRemove(*this);
		}
		break;

		case 6: // Apply Aura (Buffs, DoT)
		{
			long power = getPower(SpellID, Effect);
			long type = DBCManager.Spell.getValue(SpellID, DBC_SPELL_ATTRIBUTE(Effect, SPELL_ATTRIB_TYPE));
			long aura = DBCManager.Spell.getValue(SpellID, DBC_SPELL_ATTRIBUTE(Effect, SPELL_ATTRIB_AURA));

			if (pCaster->type == OBJ_PLAYER) 
			{
					switch(type)
					{
					case 1: // Beneficial, spell 2A1 (armor) is 1 and spell 134 (Spirit Armor) is 21 not sure why yet
						switch(aura)
						{
						case 22: // AC Buffs + ?
							{
							long durationID = DBCManager.Spell.getValue(SpellID, DBC_SPELL_DURATION_ID);
							long mintime = DBCManager.SpellDuration.getValue(durationID, DBC_SPELLDURATION_MINTIME);
							long maxtime = DBCManager.SpellDuration.getValue(durationID, DBC_SPELLDURATION_MAXTIME);

							if (armor_buff == false)  // we gonna check if the buff casted is more powerfull than the current one
								{					 // and if the buff are supposed to stack
								armor_buff = true;
								Data.CurrentStats.Armor += power;
								long buff_rand = (maxtime - mintime);
								if (!buff_rand)
									buff_rand=1;
								unsigned long buff_time = mintime + (rand() % buff_rand);
								EventManager.AddEvent(*this, buff_time, EVENT_PLAYER_REMOVE_AURA, &power, sizeof(power));
								}
							}
							break;
						//case 29: // Buff attributes ?
						//	break;
						}
						break;
					case 6:  // school dmg
						{
							if (Data.PvP && ((CPlayer*)pCaster)->Data.PvP)
							{	
								switch(aura)
									{
									case 3: // Damage Over Time (DoT)
										{
										long periodicity = DBCManager.Spell.getValue(SpellID, DBC_SPELL_ATTRIBUTE(Effect, SPELL_ATTRIB_PERIODICITY));
										long durationID = DBCManager.Spell.getValue(SpellID, DBC_SPELL_DURATION_ID);
										long mintime = DBCManager.SpellDuration.getValue(durationID, DBC_SPELLDURATION_MINTIME);
										long maxtime = DBCManager.SpellDuration.getValue(durationID, DBC_SPELLDURATION_MAXTIME);
										if (periodicity) // TODO: correctly handle 0 periodicity case
										{
											unsigned long dmg_tick = (maxtime / periodicity); // Guessing tick wont be float putting it in sec
											for (unsigned long i = 0 ; i < dmg_tick ; i++) {
												EventManager.AddEvent(*this, (i * periodicity), EVENT_PLAYER_DOTTED, &power, sizeof(power));
												}
											}
										}
										break;
									} // switch aura
							}
							else if (Effect == 1 && pCaster->type == OBJ_PLAYER)
							{
								((CPlayer*)pCaster)->pClient->Echo("You cant attack others unless you set PvP and they are also PvP");
								((CPlayer*)pCaster)->pClient->InterruptCast(SpellID);
							}
						} // case 6
						break;
					case 21: // Beneficial type (Seal)
						switch(aura)
						{
						case 22: // AC Buffs + Resist ?
							{
							long durationID = DBCManager.Spell.getValue(SpellID, DBC_SPELL_DURATION_ID);
							long mintime = DBCManager.SpellDuration.getValue(durationID, DBC_SPELLDURATION_MINTIME);
							long maxtime = DBCManager.SpellDuration.getValue(durationID, DBC_SPELLDURATION_MAXTIME);
							
							if (armor_buff == false)
								{
								armor_buff = true;
								Data.CurrentStats.Armor += power;
								long buff_rand = (maxtime - mintime);
								if (!buff_rand)
									buff_rand=1;
								unsigned long buff_time = mintime + (rand() % buff_rand);
								EventManager.AddEvent(*this, buff_time, EVENT_PLAYER_REMOVE_AURA, &power, sizeof(power));
								}
							}
							break;
						case 29: // Stats buff
							{
							long bufftype = DBCManager.Spell.getValue(SpellID, DBC_SPELL_ATTRIBUTE(Effect, SPELL_ATTRIB_14));
							long durationID = DBCManager.Spell.getValue(SpellID, DBC_SPELL_DURATION_ID);
							long mintime = DBCManager.SpellDuration.getValue(durationID, DBC_SPELLDURATION_MINTIME);
							long maxtime = DBCManager.SpellDuration.getValue(durationID, DBC_SPELLDURATION_MAXTIME);

							switch(bufftype)
								{
								case 0: // Strengh
									break;
								case 1: // Agility
									break;
								case 2: // Stamina
									{
									sendSpellMsg(power, SpellID, false);
									Data.CurrentStats.Stamina += power;
									long buff_rand = (maxtime - mintime);
									if (!buff_rand)
										buff_rand=1;
									unsigned long buff_time = mintime + (rand() % buff_rand);
									//EventManager.AddEvent(*this, buff_time, EVENT_PLAYER_REMOVE_AURA, &power, sizeof(power));
									CUpdateBlock block;
									char buffer[0x90];
									block.ResetBlock(buffer, 0x90);
									block.AddDataUpdate(PLAYER_MAX_BITS, guid, PLAYERGUID_HIGH);
									block.Add(UNIT_STAMINA, Data.CurrentStats.Stamina);
									int size;
									char *ptr = block.GetCompressedData(size);
									if(size)
										pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
									}
									break;
								case 3: // Intellect
									break;
								case 4: // Spirit
									break;
								}
							}
							break;
						}
						break;
					} // switch type
			}
		}
		break;

		case 10: // heals
		{
			long power = getPower(SpellID, Effect);
			if (pCaster->type == OBJ_PLAYER) 
			{
				if ((Data.CurrentStats.HitPoints + power) >= Data.NormalStats.HitPoints)
				{
					power = Data.NormalStats.HitPoints - Data.CurrentStats.HitPoints;
					Data.CurrentStats.HitPoints = Data.NormalStats.HitPoints;
				}
				else
					Data.CurrentStats.HitPoints += power;

				UpdateHP();
				sendSpellMsg(power, SpellID, true);
			}
		}
		break;
		
		case 36: // ranged shots
		{
			long power = 15; // ?

			if (pCaster->type == OBJ_PLAYER) 
			{
				if (Data.PvP && ((CPlayer*)pCaster)->Data.PvP)
				{
					sendSpellMsg(power, SpellID, false);
					Data.CurrentStats.HitPoints -= power;
					if (Data.CurrentStats.HitPoints <= 0 && !dead)
					{
						dead = true;
						char killer[50];
						sprintf(killer, "You have been slain by %s", ((CPlayer*)pCaster)->Data.Name);
						pClient->Echo(killer);
						ClearEvents();
						unsigned long expgain = Data.Level * 50;
						EventManager.AddEvent(*pCaster, 0, EVENT_PLAYER_GAINEXP, &expgain, sizeof(expgain));
					}
					UpdateHP();
				}
				else if (Effect == 1 && pCaster->type == OBJ_PLAYER)
				{
					((CPlayer*)pCaster)->pClient->Echo("You cant attack others unless you set PvP and they are also PvP");
					((CPlayer*)pCaster)->pClient->InterruptCast(SpellID);
				}
			}
			else
			{
				Data.CurrentStats.HitPoints -= power;
				if (Data.CurrentStats.HitPoints <= 0)
				{
					ClearEvents();
					dead = true;
				}
				RegionManager.ObjectResend(*this);
			}
		}
		break;

		case 56: // summon
		{
			long power = getPower(SpellID, Effect);
			long type = DBCManager.Spell.getValue(SpellID, DBC_SPELL_ATTRIBUTE(Effect, SPELL_ATTRIB_TYPE));
			long model = DBCManager.Spell.getValue(SpellID, DBC_SPELL_ATTRIBUTE(Effect, SPELL_ATTRIB_SPELLLINK));
			
			switch(type)
			{
			case 32: // 
				{
				sendSpellMsg(model, SpellID, false);
				}
				break;
			}
		}
		break;

		case 58: // additional ranged shots
		{
			long power = 15;
			if (pCaster->type == OBJ_PLAYER) 
			{
				if (Data.PvP && ((CPlayer*)pCaster)->Data.PvP)
				{
					sendSpellMsg(power, SpellID, false);
					Data.CurrentStats.HitPoints -= power;
					if (Data.CurrentStats.HitPoints <= 0 && !dead)
					{
						dead = true;
						char killer[50];
						sprintf(killer, "You have been slain by %s", ((CPlayer*)pCaster)->Data.Name);
						pClient->Echo(killer);
						ClearEvents();
						unsigned long expgain = Data.Level * 50;
						EventManager.AddEvent(*pCaster, 0, EVENT_PLAYER_GAINEXP, &expgain, sizeof(expgain));
					}
					UpdateHP();
				}
				else if (Effect == 1 && pCaster->type == OBJ_PLAYER)
				{
					((CPlayer*)pCaster)->pClient->Echo("You cant attack others unless you set PvP and they are also PvP");
					((CPlayer*)pCaster)->pClient->InterruptCast(SpellID);
				}
			}
			else
			{
				Data.CurrentStats.HitPoints -= power;
				if (Data.CurrentStats.HitPoints <= 0)
				{
					ClearEvents();
					dead = true;
				}
				RegionManager.ObjectResend(*this);
			}
		}
		break;

		default:
			if (Effect == 1 && pCaster->type == OBJ_PLAYER)
				((CPlayer*)pCaster)->pClient->InterruptCast(SpellID);
			break;
	}
}

void CPlayer::sendSpellMsg(long damage, unsigned long spell, bool heal)
{
	if (pCaster->type != OBJ_PLAYER)
		return;

	unsigned char buffer[0x3D];
	memset(buffer,0,0x36);
	*(unsigned long*)&buffer[0]=pCaster->guid;
	*(unsigned long*)&buffer[8]=pCaster->guid;
	*(unsigned long*)&buffer[0x10]=spell;
	*(unsigned short*)&buffer[0x14]=0x82;
	buffer[0x16]=1;
	*(unsigned long*)&buffer[0x17]=guid;
	*(unsigned short*)&buffer[0x1F]=0x4200;
	*(unsigned long*)&buffer[0x22]=guid;
	*(_Location*)&buffer[0x2A]=((CPlayer*)pCaster)->Data.Loc;
	
	unsigned char buffer1[0x39];
	unsigned char buffer2[0x2C];
	memset(buffer1,0,0x39);
	*(unsigned char*)&buffer1[0x01]=0x00;  // can turn on and off attacking
	*(unsigned char*)&buffer1[0x02]=0x00;  // unknown
	*(unsigned char*)&buffer1[0x03]=0x00;  // unknown
	*(unsigned long*)&buffer1[0x04]=pCaster->guid;  // who is dishing out dmg
	*(unsigned long*)&buffer1[0x0C]=guid; // to whom
	*(unsigned long*)&buffer1[0x10]=0; // upper 32 bit of player guid
	*(unsigned long*)&buffer1[0x14]=damage;  // dmg shown in main window
	
	// Maybe we can skip this part set DamageCount to 0 when it's a spell /Code
	*(unsigned char*)&buffer1[0x18]=0x01;  // DamageCount
	*(unsigned long*)&buffer1[0x19]=0x00;  // DamageType
	*(unsigned long*)&buffer1[0x1D]=0x00;  // float DamageFloat
	*(unsigned long*)&buffer1[0x21]=0x00;  // dmg shown in rt window - note psycho: If you put damage here you get the dmg message in double (Your fireball hit taget for 10, You hit target for 10)
	*(unsigned long*)&buffer1[0x25]=0x00; // DamageAbsorbed

	*(unsigned long*)&buffer1[0x29]=VS_WOUND;  // VICTIMSTATE
	*(unsigned long*)&buffer1[0x2D]=0xFFFFFFFF;  // victimRoundDuration

	*(unsigned long*)&buffer1[0x31]=0x00;  // "spellDamageAdded" // Addtional dmg go here, probably from special items effect  (You hit xx for an addtional dmg of xx)
	*(unsigned long*)&buffer1[0x35]=spell; // "spellAddedDamage" // if not 0 (then spell dmg) and dont show - assumes 1D will show
											// 2 very confusing variables:) 
											// but by looking at this, the second 
										    // variable is obviously "spellThatAddedDamage"
											// /Code
	//*(unsigned long*)&buffer1[0x39]=0x00;   // "procSpell" // visual effect


	memset(buffer2,0,0x2C);
	// bit flag
	if (heal == true)
	{
		*(unsigned char*)&buffer1[0x00]=0x24;
		*(unsigned long*)&buffer2[0x00]=0x12;
	}
	else
	{
		*(unsigned char*)&buffer1[0x00]=0x22;
		*(unsigned long*)&buffer2[0x00]=0x11;
	}
		
	*(unsigned long*)&buffer2[0x04]=pCaster->guid;   // who is dishing out dmg
	*(unsigned long*)&buffer2[0x0C]=guid; // to whom
	*(unsigned long*)&buffer2[0x10]=SpellUnknown;
	*(unsigned short*)&buffer2[0x14]=spell; // spell
	*(unsigned long*)&buffer2[0x18]=damage;
	*(unsigned char*)&buffer2[0x1E]=0x40;
	*(unsigned char*)&buffer2[0x1F]=0x41;
	*(unsigned long*)&buffer2[0x24]=damage;   // how much dmg

	CRegion *pPlayerRegion=RegionManager.ObjectRegions[pCaster->guid];
	if (!pPlayerRegion)
	{
		((CPlayer*)pCaster)->pClient->OutPacket(SMSG_SPELL_GO,buffer,0x36);
		if (pCaster->guid != guid)
		{
			((CPlayer*)pCaster)->pClient->OutPacket(SMSG_ATTACKERSTATEUPDATE,buffer1,0x39);
			((CPlayer*)pCaster)->pClient->OutPacket(SMSG_ATTACKERSTATEUPDATEDEBUGINFOSPELL,buffer2,0x2C);
		}
		return;
	}
		
	for (int i = 0 ; i < 3 ; i++) 
	{
		for (int j = 0 ; j < 3 ; j++)
		{
			if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
			{
				RegionObjectNode *pNode=pRegion->pList;
				while(pNode)
				{
					if (pNode->pObject->type==OBJ_PLAYER)
					{
						if (Distance(*((CPlayer*)pNode->pObject))<SPELLDIST) 
						{
							((CPlayer*)pNode->pObject)->pClient->OutPacket(SMSG_SPELL_GO,buffer,0x36);
							if (pCaster->guid != guid)
							{
								((CPlayer*)pNode->pObject)->pClient->OutPacket(SMSG_ATTACKERSTATEUPDATE,buffer1,0x39);
								((CPlayer*)pNode->pObject)->pClient->OutPacket(SMSG_ATTACKERSTATEUPDATEDEBUGINFOSPELL,buffer2,0x2C);
							}
						}
					}
					pNode=pNode->pNext;
				}
			}
		}
	}
}

void CPlayer::PvPToggle()
{
	Data.RecentPvP = false;
}

long getPower(unsigned long spell, unsigned long effect)
{
	long power = DBCManager.Spell.getValue(spell, DBC_SPELL_ATTRIBUTE(effect, SPELL_ATTRIB_POWER)) + 1;
	long randomness = DBCManager.Spell.getValue(spell, DBC_SPELL_ATTRIBUTE(effect, SPELL_ATTRIB_RANDOMNESS));

	if (!randomness)
		randomness = 1;
	power = (power + (rand() % randomness));
	if (power > 25)
		return 25;
	else
		return power;
}

void CPlayer::ResetFlags()
{
	// PvP stuff
	Data.PvP = false;
	Data.RecentPvP = false;
	Data.ResurrectionSickness = false;
	dead = false;
	armor_buff = false;
}

int CPlayer::GetOpenBackpackSlot()
{
	for (int i = SLOT_INBACKPACK ; i < SLOT_INBACKPACK+16 ; i++)
	{
		if (Data.Items[i]==0)
			return i;
	}
	return -1;
}



bool CPlayer::ValidateSpell(long target, short spell)
{
#ifndef ACCOUNTLESS
	bool rv = false;

	char UserLevel=pClient->pAccount->Data.UserLevel;
	if (UserLevel >= USER_GM)
		rv = true;
	switch(Data.Class) {
		case CLASS_WARRIOR:
			// Defensive Stance, Whirlwind, Berserker Stance
			if ((spell == 71) || (spell == 000) || (spell == 2458))
				rv = true;
			break;
		case CLASS_PALADIN:
			// Divine Shield, Devotion Aura, and Holy Light
			if ((spell == 642) || (spell == 465) || (spell == 635))
				rv = true;
			break;
		case CLASS_HUNTER:
			// Beast: Tracking, Soothe, Taming
			if ((spell == 1494) || (spell == 1513) || (spell == 1515))
				rv = true;
			break;
		case CLASS_ROGUE:
			// Backstab, stealth, dual wield (which is passive)
			if ((spell == 53) || (spell == 1784))
				rv = true;
			break;
		case CLASS_PRIEST:
			// Sleep, Lesser Heal, Shadow Word: Pain
			if ((spell == 700) || (spell == 2050) || (spell == 589))
				rv = true;
			break;
		case CLASS_SHAMAN:
			// Lightning Bolt, Lightning shield, Restoration
			if ((spell == 403) || (spell == 324) || (spell == 331))
				rv = true;
			break;
		case CLASS_MAGE:
			// Invisibility, Frost Armor, Fireball
			if ((spell == 885) || (spell == 168) || (spell == 133))
				rv = true;
			break;
		case CLASS_WARLOCK:
			// Immolate, Anti-Magic, Infernal
			if ((spell == 348) || (spell == 1399) || (spell == 1413))
				rv = true;
			break;
		case CLASS_DRUID:
			// Polymorph, Rejuvenation, Faerie Fire
			if ((spell == 1168) || (spell == 774) || (spell == 1414))
				rv = true;
			break;
	}
	return rv;
#else
	return true;
#endif
}

void CPlayer::DestroyItem(int slot)
{
	CItem *pItem = NULL;
	if(Data.Items[slot] != 0)
	{
		if(DataManager.RetrieveObject((CWoWObject**)&pItem, OBJ_ITEM, Data.Items[slot]))
		{
			Data.Items[slot] = 0;
			RegionManager.ObjectRemove(*pItem);
			pItem->Delete();
		}
		else // todo fix containers
			Data.Items[slot] = 0;
	}
}

void CPlayer::UpdateHP()
{
	if(!pClient)
		return;
	CUpdateBlock block;
	char buffer[0x90];
	block.ResetBlock(buffer, 0x90);
	block.AddDataUpdate(PLAYER_MAX_BITS, guid, PLAYERGUID_HIGH);
	block.Add(UNIT_HEALTH, Data.CurrentStats.HitPoints);
	int size;
	char *ptr = block.GetCompressedData(size);
	if(size)
		pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
}
void CPlayer::UpdateHPMP()
{
	if(!pClient)
		return;
	CUpdateBlock block;
	char buffer[0x90];
	block.ResetBlock(buffer, 0x90);
	block.AddDataUpdate(PLAYER_MAX_BITS, guid, PLAYERGUID_HIGH);
	block.Add(UNIT_HEALTH, Data.CurrentStats.HitPoints);
	block.Add(UNIT_MANA, Data.CurrentStats.Mana);
	int size;
	char *ptr = block.GetCompressedData(size);
	if(size)
		pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
}

void CPlayer::AddExp(int exp)
{
	CUpdateBlock block;
	char buffer[0x180];
	block.ResetBlock(buffer, 0x180);
	block.AddDataUpdate(PLAYER_MAX_BITS, guid, PLAYERGUID_HIGH);
	if(exp < 0)
	{
		Data.Exp += exp;
		block.Add(PLAYER_XP, Data.Exp);
		pClient->Echo("You lose %d Experience!", exp);
	}
	else if (Data.NextLevelExp > (Data.Exp + exp) && Data.Level < 255)
	{
		Data.Exp += exp;
		block.Add(PLAYER_XP, Data.Exp);
		pClient->Echo("You gain %d Experience!", exp);
	}
	else if (Data.Level < 255)
	{
		// Level up
		Data.Exp = (Data.Exp + exp) - Data.NextLevelExp;
		Data.Level++;
		Data.NextLevelExp += Data.NextLevelExp - (Data.NextLevelExp / 2);
		Data.NormalStats.HitPoints += 10 + (Data.Level * 2);
		Data.CurrentStats.HitPoints += 10 + (Data.Level * 2);
		Data.NormalStats.Mana += (Data.Level * 2);
		Data.CurrentStats.Mana += (Data.Level * 2);
		Data.NormalStats.Strength++;
		Data.NormalStats.Stamina++;
		Data.NormalStats.Agility++;
		Data.NormalStats.Spirit++;
		Data.NormalStats.Intellect++;
		Data.CurrentStats.Strength++;
		Data.CurrentStats.Stamina++;
		Data.CurrentStats.Agility++;
		Data.CurrentStats.Spirit++;
		Data.CurrentStats.Intellect++;
		Data.DamageMin += (Data.Level * 2);
		Data.DamageMax += (Data.Level * 2);
		pClient->Echo("You gain %d Experience!", exp);
		pClient->Echo("You gain a Level! Your new Level is %d!", Data.Level);

		block.Add(UNIT_HEALTH, Data.CurrentStats.HitPoints);
		block.Add(UNIT_MANA, Data.CurrentStats.Mana);
		/*block.Add(UNIT_RAGE, Data.CurrentStats.Rage);
		block.Add(UNIT_FOCUS, Data.CurrentStats.Focus);
		block.Add(UNIT_ENERGY, Data.CurrentStats.Energy);*/
		block.Add(UNIT_MAX_HEALTH, Data.NormalStats.HitPoints);
		block.Add(UNIT_MAX_MANA, Data.NormalStats.Mana);
		/*block.Add(UNIT_MAX_RAGE, Data.NormalStats.Rage);
		block.Add(UNIT_MAX_FOCUS, Data.NormalStats.Focus);
		block.Add(UNIT_MAX_ENERGY, Data.NormalStats.Energy);*/
		block.Add(UNIT_LEVEL, Data.Level);

		block.Add(UNIT_STRENGTH, Data.CurrentStats.Strength);
		block.Add(UNIT_AGILITY, Data.CurrentStats.Agility);
		block.Add(UNIT_STAMINA, Data.CurrentStats.Stamina);
		block.Add(UNIT_INTELLECT, Data.CurrentStats.Intellect);
		block.Add(UNIT_SPIRIT, Data.CurrentStats.Spirit);
		block.Add(UNIT_BASE_STRENGTH, Data.NormalStats.Strength);
		block.Add(UNIT_BASE_AGILITY, Data.NormalStats.Agility);
		block.Add(UNIT_BASE_STAMINA, Data.NormalStats.Stamina);
		block.Add(UNIT_BASE_INTELLECT, Data.NormalStats.Intellect);
		block.Add(UNIT_BASE_SPIRIT, Data.NormalStats.Spirit);

		block.Add(UNIT_MIN_DAMAGE, Data.DamageMin);
		block.Add(UNIT_MAX_DAMAGE, Data.DamageMax);
		block.Add(PLAYER_XP, Data.Exp);
	}
	if(!pClient)
		return;
	int size;
	char *ptr = block.GetCompressedData(size);
	if(size)
		pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
}