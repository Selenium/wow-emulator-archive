#include "Globals.h"
#include "Player.h"
#include "Client.h"
#include "DBCHandler.h"
#include "Creature.h"
#include "UpdateBlock.h"
#include "GameObject.h"
#include "Guild.h"
#include "Party.h"
#include "ChatManager.h"
#include "Spell.h"
#include "dbc_structs.h"
#include "QuestFunctions.h"
#include "Quest.h"
#include "GameMechanics.h"
#include "Bag.h"
#include "AuraHandler.h"

long StartRaceStats[9][5]={
	{0,0,0,0,0}, //blank
	{20,20,20,20,21}, //human
	{23,17,22,17,23}, //orc
	{22,16,23,19,19}, //dwarf
	{17,25,19,20,20}, //nightelf
	{19,18,21,18,25}, //undead
	{25,15,22,15,22}, //tauren
	{15,23,19,24,20}, //gnome
	{21,22,21,16,21} //troll
};
long StartClassStats[12][7]={
	{0,0,0,0,0,0,0}, //blank
	{3,0,2,0,0,80,0}, //warrior
	{2,0,2,0,2,70,80}, //paladin
	{0,3,1,0,2,46,85}, //hunter
	{1,3,1,0,1,45,0}, //rogue
	{0,0,0,2,4,30,100}, //priest
	{0,0,0,0,0,0,0}, //blank
	{1,0,1,1,3,50,75}, //shaman
	{0,0,0,3,3,30,100}, //mage
	{0,0,1,2,3,60,110}, //warlock
	{0,0,0,0,0,0,0}, //blank
	{1,0,0,2,3,54,70} //druid
};

CPlayer::CPlayer(void):CWoWObject(OBJ_PLAYER), CUpdateObject(NUM_PLAYER_FIELDS)
{
	DataObject.pObject = this;
	Clear();
	pClient=0;
	pCurrentSpell=0;
	_ftime(&LastAttack);
	EnableAllQuests = false;
	SummonGuid = 0;
}

CPlayer::~CPlayer(void)
{
	list<CChannel *>::iterator i;
	for(i = m_channels.begin(); i != m_channels.end(); i++)
		(*i)->Leave(this,false);
	Delete();
}
long CPlayer::FindOpenQuestSlot()
{
	unsigned long i;
	for(i=0;i<20;i++)
	{
		if (!Data.QuestLogSlots[i].QuestID)
		{
			return i;
		}
	}
	return -1;
}

unsigned long CPlayer::GetCharListData(char *buffer)
{
	unsigned long c=0;
	strcpy(&buffer[c],Data.Name);
	c+=strlen(Data.Name)+1;
	buffer[c++]=Data.Race;
	buffer[c++]=Data.Class;
	buffer[c++]=Data.Female;
	memcpy(&buffer[c],Data.Appearance,5);
	c+=5;
	buffer[c++]=(unsigned char)Data.Level;
	*(unsigned long*)&buffer[c]=Data.Zone;
	c+=4;
	*(unsigned long*)&buffer[c]=Data.Continent;
	c+=4;
	memcpy(&buffer[c],&Data.Loc,sizeof(_Location));
	c+=sizeof(_Location);
	*(unsigned long*)&buffer[c]=Data.GuildID;
	c+=0x04; // guild
	c+=0x04; // unknown
	buffer[c] = RESTEDSTATE_NORMAL;
	c+=0x01; // new byte
	c+=0x0C; // old vals //PET data
	// item model numbers and slots
	for (unsigned char i = 0 ; i < 19 ; i++)
	{
//		if (unsigned long ItemID=Data.Items[i])
		if (CItem *pItem = Data.Items[i])
		{
//			CItem *pItem=0;
//			if (DataManager.RetrieveObject((CWoWObject**)&pItem,ItemID))
//			{
				if(pItem->pTemplateData)
				{
					*(unsigned long*)&buffer[c]=pItem->pTemplateData->DisplayID;
					c+=4;
					buffer[c++]=(char)pItem->pTemplateData->InventoryType;
				}
				else c+=5;
//			}
//			else c+=5;
		}
		else c+=5;
	}
	c+=5;

	return c;
}

void CPlayer::AddSkill(unsigned long SkillID, short CurrentLevel, short MaxLevel, bool Update)
{
	struct _SkillInfo sSkill;
	sSkill.SkillID = SkillID;
	sSkill.CurrentLevel = CurrentLevel;
	sSkill.MaxLevel = MaxLevel;
	sSkill.posStatCurrentLevel = 0;
	sSkill.posStatMaxLevel = 0;
	int i=0;
	while(Data.Skills[i].SkillID)
	{
		if(Data.Skills[i].SkillID==SkillID) break;
		i++;
	}
	Data.Skills[i]=sSkill;
	AddUpdateVal(PLAYER_SKILL_INFO_1_1+i*3, Data.Skills[i].SkillID);
	AddUpdateVal(PLAYER_SKILL_INFO_1_1+i*3+1, ((Data.Skills[i].MaxLevel)<<16)+Data.Skills[i].CurrentLevel);
	AddUpdateVal(PLAYER_SKILL_INFO_1_1+i*3+2, ((Data.Skills[i].posStatMaxLevel)<<16)+Data.Skills[i].posStatCurrentLevel);
	UpdateObject();
	//if (Update) UpdateObjectOnlyMe();
}

void CPlayer::AddModifier(_Modifier mod)
{
	if (mod.SpellID == 0)
		return;	// we don't allow mods without spell
	Modifiers[GetFreeModSlot()] = mod;
}
int CPlayer::GetFreeModSlot()
{
	int i=0;
	while(Modifiers[i].SpellID) i++;
	return i;
}
void CPlayer::ClearNextAttackSpell()
{
	NextAttackSpell=NULL;
	NextAttackData=NULL;
}
void CPlayer::AddNextAttackSpell(CSpell *pSpell,CDataBuffer* data)
{
	NextAttackSpell=pSpell;
	NextAttackData=data;
}
void CPlayer::RemoveModifier(unsigned long SpellID)
{
	for(int i=0;i<64;i++)
	{
		if (Modifiers[i].SpellID==SpellID)
		{
			AuraHandler::ApplyModifier(Modifiers[i].SlotID,Modifiers[i].ModID,Modifiers[i].SpellID,false,
				Modifiers[i].Effect,Modifiers[i].power,Modifiers[i].time,Modifiers[i].type,Modifiers[i].pCaster,
				Modifiers[i].pTarget);
			Modifiers[i].Effect=0;
			Modifiers[i].ModID=0;
			Modifiers[i].pCaster=NULL;
			Modifiers[i].power=0;
			Modifiers[i].pTarget=NULL;
			Modifiers[i].SlotID=0;
			Modifiers[i].SpellID=0;
			Modifiers[i].time=0;
			Modifiers[i].type=0;
			Modifiers[i].Applied = false;
		}
	}
}

void CPlayer::ApplyModifier(_Modifier mod)
{
	if (mod.Applied)
		return;		// don't apply if already applied!
	mod.Applied = true;

	return;
}
void CPlayer::UpdateSkills(bool Create)
{
	int i=0;
	while(Data.Skills[i].SkillID)
	{
		switch(Data.Skills[i].SkillID)
		{
		case 44:
		case 172:
		case 45:
		case 46:
		case 54:
		case 160:
		case 229:
		case 43:
		case 55:
		case 136:
		case 173:
		case 176:
		case 227:
		case 226:
		case 228:
		case 415:
		case 414:
		case 413:
		case 293:
		case 433:
		case 95:		// defense
			{
				Data.Skills[i].MaxLevel=(unsigned short)Data.Level*5;
				if (!Create)
				{
					AddUpdateVal(PLAYER_SKILL_INFO_1_1+i*3, Data.Skills[i].SkillID);
					AddUpdateVal(PLAYER_SKILL_INFO_1_1+i*3+1, ((Data.Skills[i].MaxLevel)<<16)+Data.Skills[i].CurrentLevel);
					AddUpdateVal(PLAYER_SKILL_INFO_1_1+i*3+2, ((Data.Skills[i].posStatMaxLevel)<<16)+Data.Skills[i].posStatCurrentLevel);
				}
			}
			break;
		}
		i++;
	}
	if (!Create) UpdateObjectOnlyMe();

	return;
}
void CPlayer::LevelUpSkill(unsigned long SkillID)
{
	int i=0;
	while(Data.Skills[i].SkillID)
	{
		if(Data.Skills[i].SkillID==SkillID)
		{
			if(Data.Skills[i].CurrentLevel < Data.Skills[i].MaxLevel) Data.Skills[i].CurrentLevel++;
			break;
		}
		i++;
	}
	AddUpdateVal(PLAYER_SKILL_INFO_1_1+i*3, Data.Skills[i].SkillID);
	AddUpdateVal(PLAYER_SKILL_INFO_1_1+i*3+1, ((Data.Skills[i].MaxLevel)<<16)+Data.Skills[i].CurrentLevel);
	AddUpdateVal(PLAYER_SKILL_INFO_1_1+i*3+2, ((Data.Skills[i].posStatMaxLevel)<<16)+Data.Skills[i].posStatCurrentLevel);

	UpdateObjectOnlyMe();
}

void CPlayer::LevelUpSkillInCombat(unsigned long SkillID)
{
	int i=0;
	int chance = 0;
	srand((int) time( NULL));

	while(Data.Skills[i].SkillID)
	{
		if(Data.Skills[i].SkillID==SkillID)
		{
			if(!Data.Skills[i].MaxLevel) return; // in case max==0
			chance = rand() % Data.Skills[i].MaxLevel; // return value 0..MaxLevel-1
			// Data.Skills[i].MaxLevel = Data.Level * 5;
			// this algo makes it ridiculously hard to gain past ~95% of max, is that supposed to happen?
			if(Data.Skills[i].CurrentLevel <= chance) // <= because of n-1 chance (i.e. 74/75 skill)
			{
				Data.Skills[i].CurrentLevel++; // no need to check for boundary: chance can't equal MaxLevel hence this
				//only works if CurrentLevel < MaxLevel ;)

				if (Data.Skills[i].CurrentLevel > Data.Skills[i].MaxLevel)
					Data.Skills[i].CurrentLevel = Data.Skills[i].MaxLevel;
			}
			break;
		}
		i++;
	}
	AddUpdateVal(PLAYER_SKILL_INFO_1_1+i*3, Data.Skills[i].SkillID);
	AddUpdateVal(PLAYER_SKILL_INFO_1_1+i*3+1, ((Data.Skills[i].MaxLevel)<<16)+Data.Skills[i].CurrentLevel);
	AddUpdateVal(PLAYER_SKILL_INFO_1_1+i*3+2, ((Data.Skills[i].posStatMaxLevel)<<16)+Data.Skills[i].posStatCurrentLevel);

	UpdateObjectOnlyMe();
}

_SkillInfo *CPlayer::GetSkill(unsigned long SkillID)
{
	int i=0;
	while(Data.Skills[i].SkillID)
	{
		if(Data.Skills[i].SkillID==SkillID)
		{
			return &Data.Skills[i];
		}
		i++;
	}
	return NULL;
}

void CPlayer::New(const char *Name, unsigned char *Attributes)
{
	//______________________________________________________________
	//Outgoing Data :8086 len=0013 op=0036 int=0000 msglen=000F -- clientconnection::charactercreate
	//      |                 |racclssex  |  |  |  |  |??
	//0000:  73 70 6F 72-6B 00 02 01-00 07 02 05-00 06 00     spork..........
	//name,0x0,race,class,gender,skin,face,hairstyle,haircolour,facialhair,0x0
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
	/* There is *no reason* to do this: all Data is zeroed on creation!
	for(int ib=0;ib<20;ib++)
	{
	Data.Bags[ib] = 0;
	}
	for(int ib=0;ib<120;ib++)
	{
	Data.BagItems[ib] = 0;
	}
	*/
	memset(&Data.TutorialFlags,0xFF,sizeof(Data.TutorialFlags)); //screw the tutorial flags: this just makes them all go away :D
	dead = false;
	armor_buff = false;

	// apply class/race bonuses and penalties to the normal stats.
	// current stats are copied directly from these at the end of
	// character creation
	Data.NormalStats.HitPoints=50;
	Data.NormalStats.Mana=86;
	Data.NormalStats.Rage=1000;
	Data.NormalStats.Focus=100;
	Data.NormalStats.Energy=100;
	Data.NormalStats.Agility=15;
	Data.NormalStats.Strength=15;
	Data.NormalStats.Stamina=19;
	Data.NormalStats.Intellect=15;
	Data.NormalStats.Spirit=19;
	Data.NormalStats.ResistFire=0;
	Data.NormalStats.ResistFrost=0;
	Data.NormalStats.ResistArcane=0;
	Data.NormalStats.ResistShadow=0;
	Data.NormalStats.ResistNature=0;
	Data.NormalStats.ResistHoly=0;
	Data.AttackSpeed=2000;
	Data.DamageMax=0;
	Data.DamageMin=0;
	Data.NextLevelExp=400;
	//	Data.NormalStats.ResistArcane = 0;
	if(Data.Race<=RACE_TROLL)
	{
		Data.NormalStats.Strength=StartRaceStats[Data.Race][0];
		Data.NormalStats.Agility=StartRaceStats[Data.Race][1];
		Data.NormalStats.Stamina=StartRaceStats[Data.Race][2];
		Data.NormalStats.Intellect=StartRaceStats[Data.Race][3];
		Data.NormalStats.Spirit=StartRaceStats[Data.Race][4];
	}
	else return; //invalid!
	if(Data.Class<=CLASS_DRUID)
	{
		Data.NormalStats.Strength+=StartClassStats[Data.Class][0];
		Data.NormalStats.Agility+=StartClassStats[Data.Class][1];
		Data.NormalStats.Stamina+=StartClassStats[Data.Class][2];
		Data.NormalStats.Intellect+=StartClassStats[Data.Class][3];
		Data.NormalStats.Spirit+=StartClassStats[Data.Class][4];
		Data.NormalStats.HitPoints=StartClassStats[Data.Class][5];
		Data.NormalStats.Mana=StartClassStats[Data.Class][6];
	}
	else return; //you are not welcome!
	if (Data.Race == RACE_GNOME) Data.NormalStats.ResistArcane = 10; // Arcane Resistance
	if (Data.Race == RACE_DWARF) Data.NormalStats.ResistFrost=10;
	if (Data.Race == RACE_NIGHTELF) Data.NormalStats.ResistNature=10;
	if (Data.Race == RACE_UNDEAD) Data.NormalStats.ResistShadow=10;
	if (Data.Race == RACE_TAUREN) Data.NormalStats.ResistNature=10;
	//if (Data.Class == CLASS_PALADIN) Data.NormalStats.Focus=10; //mistake?
	if (Data.Class == CLASS_ROGUE) Data.AttackSpeed=1950; //1900 2000
	if (Data.Class == CLASS_PALADIN) Data.AttackSpeed=1800; //1600 2000

	memcpy(Data.Appearance,&Attributes[3],5);
	InCombat = false;
	Data.Loc=RaceStartingPoints[Data.Race].Loc;
	Data.Continent=RaceStartingPoints[Data.Race].Continent;
	Data.Facing=RaceStartingPoints[Data.Race].Facing;
	Data.Zone=RaceStartingPoints[Data.Race].Zone;
	unsigned long Models[9]={1,0x31,0x33,0x35,0x37,0x39,0x3B,0x61B,0x5C6};
	if(Data.Race==RACE_TAUREN) Data.Size=1.3f;
	else Data.Size=1.0f;
	Data.BaseModel=Data.Model=Models[Data.Race]+Data.Female;
	unsigned long Armor=0;
#define SETITEM(id, slot)\
	pItem = new CItem;\
	pItem->New(id, guid);\
	DataManager.NewObject(*pItem);\
	pItem->CreateBag();\
	Data.Items[slot]=pItem;
//	Data.Items[slot]=pItem->guid;
#define SETITEMSTACKED(id, slot, stacked)\
	pItem = new CItem;\
	pItem->New(id, guid);\
	pItem->Data.Count=stacked;\
	DataManager.NewObject(*pItem);\
	pItem->CreateBag();\
	Data.Items[slot]=pItem;
//	Data.Items[slot]=pItem->guid;
	CItem *pItem;
	switch(Data.Class)
	{
	case CLASS_WARRIOR:
		{
			Data.ManaType=1;
			SETITEM(STATICITEMS::WARRIOR_SHORTSWORD, SLOT_MAINHAND);
			SETITEM(STATICITEMS::WARRIOR_SHIELD, SLOT_OFFHAND);
			Armor++;
			if(Data.Race == RACE_HUMAN || Data.Race == RACE_DWARF || Data.Race == RACE_GNOME)
			{
				SETITEM(STATICITEMS::WARRIOR_SHIRT, SLOT_SHIRT);
				SETITEM(STATICITEMS::WARRIOR_PANTS, SLOT_LEGS);
				SETITEM(STATICITEMS::WARRIOR_BOOTS, SLOT_FEET);
				Armor+=3;
			}
			else if(Data.Race == RACE_NIGHTELF)
			{
				SETITEM(STATICITEMS::NE_WARRIOR_SHIRT, SLOT_SHIRT);
				SETITEM(STATICITEMS::NE_WARRIOR_PANTS, SLOT_LEGS);
				SETITEM(STATICITEMS::NE_WARRIOR_BOOTS, SLOT_FEET);
				Armor+=3;
			}
			else
			{
				SETITEM(STATICITEMS::EVIL_WARRIOR_SHIRT, SLOT_SHIRT);
				SETITEM(STATICITEMS::EVIL_WARRIOR_PANTS, SLOT_LEGS);
				Armor+=2;
				if(Data.Race == RACE_ORC || Data.Race == RACE_UNDEAD)
				{
					SETITEM(STATICITEMS::EVIL_WARRIOR_BOOTS, SLOT_FEET);
					Armor++;
				}
			}
		}
		break;
	case CLASS_PALADIN:
		{
			SETITEM(STATICITEMS::PALADIN_HAMMER, SLOT_MAINHAND);
			SETITEM(STATICITEMS::PALADIN_BOOTS, SLOT_FEET);
			Armor++;
			if(Data.Race == RACE_HUMAN)
			{
				SETITEM(STATICITEMS::HUMAN_PALADIN_SHIRT, SLOT_SHIRT);
				SETITEM(STATICITEMS::HUMAN_PALADIN_PANTS, SLOT_LEGS);
				Armor+=2;
			}
			else if(Data.Race == RACE_DWARF)
			{
				SETITEM(STATICITEMS::DWARF_PALADIN_SHIRT, SLOT_SHIRT);
				SETITEM(STATICITEMS::DWARF_PALADIN_PANTS, SLOT_LEGS);
				Armor+=2;
			}
		}
		break;
	case CLASS_HUNTER:
		Data.ManaType=2;
		{
			SETITEM(STATICITEMS::HUNTER_AXE, SLOT_MAINHAND);
			SETITEM(STATICITEMS::HUNTER_SHIELD, SLOT_OFFHAND);
			Armor++;
			switch(Data.Race)
			{
			case RACE_ORC:
				SETITEM(STATICITEMS::ORC_TAUREN_HUNTER_SHIRT, SLOT_SHIRT);
				SETITEM(STATICITEMS::ORC_TAUREN_HUNTER_PANTS, SLOT_LEGS);
				SETITEM(STATICITEMS::ORC_HUNTER_BOOTS, SLOT_FEET);
				Armor+=3;
				SETITEM(STATICITEMS::HUNTER_BOW, SLOT_RANGED);
				SETITEM(STATICITEMS::HUNTER_QUIVER, SLOT_INBACKPACK+3); //SLOT_BAG1); // todo create containers!
				SETITEMSTACKED(STATICITEMS::HUNTER_ARROW, SLOT_INBACKPACK+2, 200); // todo move it into the bag
				break;
			case RACE_DWARF:
				SETITEM(STATICITEMS::DWARF_NIGHTELF_HUNTER_SHIRT, SLOT_SHIRT);
				SETITEM(STATICITEMS::DWARF_NIGHTELF_HUNTER_PANTS, SLOT_LEGS);
				SETITEM(STATICITEMS::DWARF_NIGHTELF_HUNTER_BOOTS, SLOT_FEET);
				Armor+=3;
				SETITEM(STATICITEMS::HUNTER_RIFLE, SLOT_RANGED);
				SETITEM(STATICITEMS::HUNTER_AMMO_POUCH, SLOT_INBACKPACK+3); //SLOT_BAG1); // todo create containers!
				SETITEMSTACKED(STATICITEMS::HUNTER_BULLET, SLOT_INBACKPACK+2, 200); // todo move it into the bag
				break;
			case RACE_NIGHTELF:
				SETITEM(STATICITEMS::DWARF_NIGHTELF_HUNTER_SHIRT, SLOT_SHIRT);
				SETITEM(STATICITEMS::DWARF_NIGHTELF_HUNTER_PANTS, SLOT_LEGS);
				SETITEM(STATICITEMS::DWARF_NIGHTELF_HUNTER_BOOTS, SLOT_FEET);
				Armor+=3;
				SETITEM(STATICITEMS::HUNTER_BOW, SLOT_RANGED);
				SETITEM(STATICITEMS::HUNTER_QUIVER, SLOT_INBACKPACK+3); //SLOT_BAG1); // todo create containers!
				SETITEMSTACKED(STATICITEMS::HUNTER_ARROW, SLOT_INBACKPACK+2,200); // todo move it into the bag
				break;
			case RACE_TAUREN:
				SETITEM(STATICITEMS::ORC_TAUREN_HUNTER_SHIRT, SLOT_SHIRT);
				SETITEM(STATICITEMS::ORC_TAUREN_HUNTER_PANTS, SLOT_LEGS);
				Armor+=2;
				SETITEM(STATICITEMS::HUNTER_RIFLE, SLOT_RANGED);
				SETITEM(STATICITEMS::HUNTER_AMMO_POUCH, SLOT_INBACKPACK+3); //SLOT_BAG1); // todo create containers!
				SETITEMSTACKED(STATICITEMS::HUNTER_BULLET, SLOT_INBACKPACK+2,200); // todo move it into the bag
				break;
			case RACE_TROLL:
				SETITEM(STATICITEMS::TROLL_HUNTER_SHIRT, SLOT_SHIRT);
				SETITEM(STATICITEMS::TROLL_HUNTER_PANTS, SLOT_LEGS);
				Armor+=2;
				SETITEM(STATICITEMS::HUNTER_BOW, SLOT_RANGED);
				SETITEM(STATICITEMS::HUNTER_QUIVER, SLOT_INBACKPACK+3); //SLOT_BAG1); // todo create containers!
				SETITEMSTACKED(STATICITEMS::HUNTER_ARROW, SLOT_INBACKPACK+2,200); // todo move it into the bag
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
			Armor+=3;
		}
		break;
	case CLASS_PRIEST:
		{
			if(Data.Race != RACE_TROLL)
			{
				SETITEM(STATICITEMS::PRIEST_BOOTS, SLOT_FEET);
				Armor++;
			}
			SETITEM(STATICITEMS::PRIEST_MACE, SLOT_MAINHAND);
			SETITEM(STATICITEMS::PRIEST_PANTS, SLOT_LEGS);
			SETITEM(STATICITEMS::PRIEST_SHIRT, SLOT_SHIRT);
			Armor+=2;
			if(Data.Race == RACE_HUMAN || Data.Race == RACE_DWARF)
			{
				SETITEM(STATICITEMS::HUMAN_DWARF_PRIEST_ROBE, SLOT_CHEST);
				Armor++;
			}
			else if(Data.Race == RACE_NIGHTELF)
			{
				SETITEM(STATICITEMS::NIGHTELF_PRIEST_ROBE, SLOT_CHEST);
				Armor++;
			}
			else
			{
				SETITEM(STATICITEMS::UNDEAD_TROLL_PRIEST_ROBE, SLOT_CHEST);
				Armor++;
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
				Armor+=2;
			}
			else if(Data.Race == RACE_TROLL)
			{
				SETITEM(STATICITEMS::TROLL_SHAMAN_SHIRT, SLOT_SHIRT);
				SETITEM(STATICITEMS::TROLL_SHAMAN_PANTS, SLOT_LEGS);
				Armor+=2;
			}
		}
		break;
	case CLASS_MAGE:
		{
			SETITEM(STATICITEMS::MAGE_STAFF, SLOT_MAINHAND);
			SETITEM(STATICITEMS::MAGE_SHIRT, SLOT_SHIRT);
			SETITEM(STATICITEMS::MAGE_PANTS, SLOT_LEGS);
			SETITEM(STATICITEMS::MAGE_BOOTS, SLOT_FEET);
			Armor+=3;
			if(Data.Race == RACE_HUMAN || Data.Race == RACE_GNOME)
			{
				SETITEM(STATICITEMS::HUMAN_GNOME_MAGE_ROBE, SLOT_CHEST);
				Armor++;
			}
			else if(Data.Race == RACE_DWARF)
			{
				SETITEM(STATICITEMS::DWARF_MAGE_ROBE, SLOT_CHEST);
				Armor++;
			}
			else
			{
				SETITEM(STATICITEMS::UNDEAD_TROLL_MAGE_ROBE, SLOT_CHEST);
				Armor++;
			}
		}
		break;
	case CLASS_WARLOCK:
		{
			SETITEM(STATICITEMS::WARLOCK_DAGGER, SLOT_MAINHAND);
			SETITEM(STATICITEMS::WARLOCK_PANTS, SLOT_LEGS);
			SETITEM(STATICITEMS::WARLOCK_BOOTS, SLOT_FEET);
			Armor+=2;
			if(Data.Race == RACE_HUMAN || Data.Race == RACE_GNOME)
			{
				SETITEM(STATICITEMS::HUMAN_GNOME_WARLOCK_ROBE, SLOT_CHEST);
				SETITEM(STATICITEMS::HUMAN_GNOME_WARLOCK_SHIRT, SLOT_SHIRT);
				Armor+=2;
			}
			else
			{
				SETITEM(STATICITEMS::ORC_UNDEAD_WARLOCK_ROBE, SLOT_CHEST);
				Armor++;
			}
		}
		break;
	case CLASS_DRUID:
		{
			SETITEM(STATICITEMS::DRUID_PANTS, SLOT_LEGS);
			Armor++;
			if(Data.Race == RACE_NIGHTELF)
			{
				SETITEM(STATICITEMS::NIGHTELF_DRUID_STAFF, SLOT_MAINHAND);
				SETITEM(STATICITEMS::NIGHTELF_DRUID_ROBE, SLOT_CHEST);
				Armor++;
			}
			else if(Data.Race == RACE_TAUREN)
			{
				SETITEM(STATICITEMS::TAUREN_DRUID_STAFF, SLOT_MAINHAND);
				SETITEM(STATICITEMS::TAUREN_DRUID_ROBE, SLOT_CHEST);
				Armor++;
			}
		}
		break;
	}
	SETITEMSTACKED(STATICITEMS::REFRESHING_SPRING_WATER,SLOT_INBACKPACK,2);
	SETITEMSTACKED(STATICITEMS::DARNASSIAN_BLEU,SLOT_INBACKPACK+1,4);
	SETITEMSTACKED(STATICITEMS::HEARTHSTONE,SLOT_INBACKPACK+4,1);
	SetFaction();
	GenerateFactions();
	Data.ActionButtons[10].action=(unsigned short)STATICITEMS::REFRESHING_SPRING_WATER;
	Data.ActionButtons[10].type=0x87; //item
	Data.ActionButtons[11].action=(unsigned short)STATICITEMS::DARNASSIAN_BLEU;
	Data.ActionButtons[11].type=0x87; //item
#undef SETITEMSTACKED
#undef SETITEM
	//Initial Spells
	unsigned short numspells=2;
	Data.Spells[0]=0x19CB; //Attack
	Data.Spells[1]=0x1C62; // Duel
	Data.ActionButtons[0].action=0x19CB;
	//skill=237
	switch(Data.Class) {
		case CLASS_WARRIOR:
			//Block, Battle Stance, Heroic Strike
			Data.Spells[numspells++]=107;
			Data.Spells[numspells++]=2457;
			Data.Spells[numspells++]=78;
			Data.ActionButtons[1].action=0x004E; //Heroic Strike

			AddSkill(26,1,1,false);    // Arms
			AddSkill(95,1,300,false);    // Defense
			AddSkill(257,1,1,false);   // Protection
			AddSkill(415,1,1,false); // Cloth
			Data.Spells[numspells++]=9078;	// Cloth
			AddSkill(414,1,1,false); // Leather
			Data.Spells[numspells++]=9077;	// Leather
			AddSkill(413,1,1,false); // Mail
			Data.Spells[numspells++]=8737;	// Mail
			AddSkill(433,1,1,false); // Shield
			Data.Spells[numspells++]=9116;	// Shield
			switch(Data.Race) {
		case RACE_HUMAN:
			AddSkill(43,1,300,false);  // Swords
			Data.Spells[numspells++]=201;	// Swords
			AddSkill(54,1,300,false);  // Maces
			Data.Spells[numspells++]=198;	// Maces
			AddSkill(44,1,300,false);  // Axes
			Data.Spells[numspells++]=196;	// Axes
			break;
		case RACE_ORC:
			AddSkill(172,1,300,false); // Axes 2H
			Data.Spells[numspells++]=197;      // Axes 2H
			break;
		case RACE_DWARF:
			AddSkill(44,1,300,false);  // Axes
			Data.Spells[numspells++]=196 ;      // Axes
			AddSkill(172,1,300,false); // Axes 2H
			Data.Spells[numspells++]=197;      // Axes 2H
			AddSkill(54,1,300,false);  // Maces
			Data.Spells[numspells++]=198 ;      // Maces
			break;
		case RACE_NIGHTELF:
			AddSkill(43,1,300,false);  // Swords
			Data.Spells[numspells++]=201 ;      // Swords
			AddSkill(173,1,300,false); // Daggers
			Data.Spells[numspells++]=1180;      // Daggers
			AddSkill(54,1,300,false);  // Maces
			Data.Spells[numspells++]=198 ;      // Maces
			break;
		case RACE_UNDEAD:
			AddSkill(43,1,300,false);  // Swords
			Data.Spells[numspells++]=201 ;      // Swords
			AddSkill(173,1,300,false); // Daggers
			Data.Spells[numspells++]=1180;      // Daggers
			AddSkill(55,1,300,false);  // 2H Swords
			Data.Spells[numspells++]=202;      // 2H Swords
			break;
		case RACE_TAUREN:
			AddSkill(44,1,300,false);  // Axes
			Data.Spells[numspells++]=196;      // Axes
			AddSkill(160,1,300,false); // 2H Maces
			Data.Spells[numspells++]=199;      // 2H Maces
			AddSkill(54,1,300,false);  // Maces
			Data.Spells[numspells++]=198;      // Maces
			break;
		case RACE_GNOME:
			AddSkill(43,1,300,false);  // Swords
			Data.Spells[numspells++]=201;      // Swords
			AddSkill(173,1,300,false); // Daggers
			Data.Spells[numspells++]=1180;      // Daggers
			AddSkill(54,1,300,false);  // Maces
			Data.Spells[numspells++]=198;      // Maces
			break;
		case RACE_TROLL:
			AddSkill(173,1,300,false); // Daggers
			Data.Spells[numspells++]=1180;      // Daggers
			AddSkill(44,1,300,false);  // Axes
			Data.Spells[numspells++]=196;      // Axes
			AddSkill(176,1,300,false); //Thrown
			Data.Spells[numspells++]=2764;      //Thrown
			break;
			}
			break;
		case CLASS_PALADIN:
			//Block, Seal of Righteousness, Holy Light
			Data.Spells[numspells++]=107;
			Data.Spells[numspells++]=20154;
			Data.Spells[numspells++]=635;
			Data.ActionButtons[1].action=0x4EBA; //Seal of Righteousness (alt = 21084)
			Data.ActionButtons[2].action=0x027B; //Holy Light

			AddSkill(95,1,300,false);    // Defense
			AddSkill(594,1,1,false);    // Holy
			AddSkill(56,1,1,false);     // Holy
			AddSkill(267,1,1,false);   // Protection
			AddSkill(184,1,1,false);   // retribution
			AddSkill(54,1,300,false);  // Maces
			Data.Spells[numspells++]=198;	// Maces
			AddSkill(160,1,300,false); // 2H Maces
			Data.Spells[numspells++]=199;	// 2H Maces
			AddSkill(415,1,1,false); // Cloth
			Data.Spells[numspells++]=9078;	// Cloth
			AddSkill(414,1,1,false); // Leather
			Data.Spells[numspells++]=9077;	// Leather
			AddSkill(413,1,1,false); // Mail
			Data.Spells[numspells++]=8737;	// Mail
			AddSkill(433,1,1,false); // Shield
			Data.Spells[numspells++]=9116;	// Shield
			break;
		case CLASS_HUNTER:
			//Auto Shot, Raptor Strike
			Data.Spells[numspells++]=75;
			Data.Spells[numspells++]=2973;
			Data.ActionButtons[1].action=0x0B9D; //Raptor Strike
			Data.ActionButtons[2].action=0x004B; //Auto Shot

			AddSkill(95,1,300,false);    // Defense
			AddSkill(163,1,1,false);    // Marksmanship
			AddSkill(44,1,300,false);  // Axes
			Data.Spells[numspells++]=196;	// Axes
			AddSkill(415,1,1,false); // Cloth
			Data.Spells[numspells++]=9078;	// Cloth
			AddSkill(414,1,1,false); // Leather
			Data.Spells[numspells++]=9077;	// Leather
			AddSkill(142,1,1,false);   // Survival
			AddSkill(51,1,1,false);   // Survival
			switch(Data.Race) {
		case RACE_NIGHTELF:
			AddSkill(45,1,300,false);  // Bows
			Data.Spells[numspells++]=264;      // Bows
			AddSkill(173,1,300,false); // Daggers
			Data.Spells[numspells++]=1180;      // Daggers
			break;
		case RACE_DWARF:
		case RACE_TAUREN:
			AddSkill(46,1,300,false);     // Guns
			Data.Spells[numspells++]=266;     // Guns
			break;
		case RACE_ORC:
		case RACE_TROLL:
			AddSkill(45,1,300,false);  // Bows
			Data.Spells[numspells++]=264 ;      // Bows
			break;
			}
			break;
		case CLASS_ROGUE:
			//Throw, Sinister Strike, Eviscerate
			Data.Spells[numspells++]=2764;
			Data.Spells[numspells++]=1752;
			Data.Spells[numspells++]=2098;
			Data.ActionButtons[1].action=0x06D8; //Sinister Strike
			Data.ActionButtons[2].action=0x0832; //Eviscerate
			Data.ActionButtons[3].action=0x0ACC; //Throw

			AddSkill(253,1,1,false);   // Assasination
			AddSkill(95,1,300,false);    // Defense
			AddSkill(173,1,300,false); // Daggers
			Data.Spells[numspells++]=1180;	// Daggers
			AddSkill(176,1,300,false); // Thrown
			Data.Spells[numspells++]=2567;	// Thrown
			AddSkill(415,1,1,false); // Cloth
			Data.Spells[numspells++]=9078;	// Cloth
			AddSkill(414,1,1,false); // Leather
			Data.Spells[numspells++]=9077;	// Leather
			//skill=38  ;      // combat
			break;
		case CLASS_PRIEST:
			//Shoot, Smite, Lesser Heal
			Data.Spells[numspells++]=5019;
			Data.Spells[numspells++]=585;
			Data.Spells[numspells++]=2050;
			Data.ActionButtons[1].action=0x0249; //Smite
			Data.ActionButtons[2].action=0x0802; //Lesser Heal

			AddSkill(95,1,300,false);    // Defense
			AddSkill(613,1,1,false);   // Discipline
			AddSkill(56,1,1,false);    // Holy
			AddSkill(78,1,1,false);    // Shadow Magic
			AddSkill(54,1,300,false);  // Maces
			Data.Spells[numspells++]=198;	// Maces
			AddSkill(228,1,300,false); // Wands
			Data.Spells[numspells++]=5009;	// Wands
			AddSkill(415,1,1,false); // Cloth
			Data.Spells[numspells++]=9078;	// Cloth
			break;
		case CLASS_SHAMAN:
			//Block, Lightning Bolt, Healing Wave
			Data.Spells[numspells++]=107;
			Data.Spells[numspells++]=403;
			Data.Spells[numspells++]=331;
			Data.ActionButtons[1].action=0x0193; //Lightning Bolt
			Data.ActionButtons[2].action=0x014B; //Healing Wave

			AddSkill(574,1,1,false);   // Balance
			AddSkill(95,1,300,false);    // Defense
			AddSkill(54,1,300,false);  // Maces
			Data.Spells[numspells++]=198;	// Maces
			AddSkill(136,1,300,false); // Staves
			Data.Spells[numspells++]=227;	// Staves
			AddSkill(415,1,1,false); // Cloth
			Data.Spells[numspells++]=9078;	// Cloth
			AddSkill(414,1,1,false); // Leather
			Data.Spells[numspells++]=9077;	// Leather
			AddSkill(433,1,1,false); // Shield
			Data.Spells[numspells++]=9116;	// Shield
			AddSkill(375,1,1,false);   // Elemental Combat
			AddSkill(373,1,1,false);   // Enhancement
			AddSkill(374,1,1,false);   // Restoration
			AddSkill(573,1,1,false);   // Restoration
			//ORC SHAMAN: AddSkill(257,1,1,false);   // Protection
			break;
		case CLASS_MAGE:
			//Shoot, Fireball, Frost Armor
			Data.Spells[numspells++]=5019;
			Data.Spells[numspells++]=133;
			Data.Spells[numspells++]=168;
			Data.ActionButtons[1].action=0x0085; //Fireball
			Data.ActionButtons[2].action=0x00A8; //Frost Armor

			AddSkill(95,1,300,false);    // Defense
			AddSkill(6,1,1,false);     // Frost
			AddSkill(8,1,1,false);     // Fire
			AddSkill(136,1,300,false); // Staves
			Data.Spells[numspells++]=227;	// Staves
			AddSkill(228,1,300,false); // Wands
			Data.Spells[numspells++]=5009;	// Wands
			AddSkill(415,1,1,false); // Cloth
			Data.Spells[numspells++]=9078;	// Cloth
			break;
		case CLASS_WARLOCK:
			//Shoot, Shadow Bolt, Demon Skin
			Data.Spells[numspells++]=5019;
			Data.Spells[numspells++]=686;
			Data.Spells[numspells++]=687;
			Data.ActionButtons[1].action=0x02AE; //Shadow Bolt
			Data.ActionButtons[2].action=0x02AF; //Demon Skin

			AddSkill(78,1,1,false);      //Shadow Magic
			AddSkill(95,1,300,false);   // Defense
			AddSkill(354,1,1,false);  // Demonology
			AddSkill(593,1,1,false);  // Destruction
			AddSkill(173,1,300,false); // Daggers
			Data.Spells[numspells++]=1180;	// Daggers
			AddSkill(228,1,300,false); // Wands
			Data.Spells[numspells++]=5009;	// Wands
			AddSkill(415,1,1,false); // Cloth
			Data.Spells[numspells++]=9078;	// Cloth
			break;
		case CLASS_DRUID:
			//Wrath, Healing Touch
			Data.Spells[numspells++]=5176;
			Data.Spells[numspells++]=5185;
			Data.ActionButtons[1].action=0x1438; //Wrath
			Data.ActionButtons[2].action=0x1441; //Healing Touch

			AddSkill(574,1,1,false);   // Balance
			AddSkill(95,1,300,false);    // Defense
			AddSkill(374,1,1,false);   // Restoration
			AddSkill(573,1,1,false);   // Restoration
			AddSkill(136,1,300,false); // Staves
			Data.Spells[numspells++]=227;	// Staves
			AddSkill(415,1,1,false); // Cloth
			Data.Spells[numspells++]=9078;	// Cloth
			AddSkill(414,1,1,false); // Leather
			Data.Spells[numspells++]=9077;	// Leather
			if(Data.Race==RACE_NIGHTELF)
			{
				AddSkill(173,1,300,false); // Daggers
				Data.Spells[numspells++]=1180;      // Daggers
			}
			else if (Data.Race==RACE_TAUREN)
			{
				AddSkill(54,1,300,false);  // Maces
				Data.Spells[numspells++]=198;      // Maces
			}
			break;
	}
	switch(Data.Race) {
		case RACE_HUMAN:
			Data.Spells[numspells++]=20599;        // Diplomacy
			Data.Spells[numspells++]=20600;        // Perception
			Data.Spells[numspells++]=20597;        // Sword Specialization
			Data.Spells[numspells++]=20598;        // The Human Spirit
			Data.Spells[numspells++]=20864;        // Mace Specialization
			AddSkill(98,300,300,false);   // lang: common
			Data.Spells[numspells++]=668;          // lang: common
			break;
		case RACE_ORC:
			Data.Spells[numspells++]=20574;        // Axe Specialization
			Data.Spells[numspells++]=20572;        // Blood Fury
			Data.Spells[numspells++]=20576;        // Command
			Data.Spells[numspells++]=20573;        // Hardiness
			AddSkill(109,300,300,false);  // lang: orcish
			Data.Spells[numspells++]=669;          // lang: orcish
			break;
		case RACE_DWARF:
			Data.Spells[numspells++]=20595;        // Gun Specialization
			Data.Spells[numspells++]=20594;        // Stoneform
			Data.Spells[numspells++]=20596;        // Frost Resistance
			Data.Spells[numspells++]=2481;         // Find Treasure
			AddSkill(98,300,300,false);     // lang: common
			Data.Spells[numspells++]=668;          // lang: common
			AddSkill(111,300,300,false);  // lang: dwarwen
			Data.Spells[numspells++]=672;          // lang: dwarwen
			break;
		case RACE_NIGHTELF:
			Data.Spells[numspells++]=20585;        // Wisp Spirit
			Data.Spells[numspells++]=20580;        // Shadowmeld
			Data.Spells[numspells++]=20582;        // Quickness
			Data.Spells[numspells++]=20583;        // Nature Resistance
			AddSkill(98,300,300,false);     // lang: common
			Data.Spells[numspells++]=668;          // lang: common
			AddSkill(113,300,300,false);  // lang: darnassian
			Data.Spells[numspells++]=671;          // lang: darnassian
			break;
		case RACE_UNDEAD:
			Data.Spells[numspells++]=20577;        // Cannibalize
			Data.Spells[numspells++]=20579;        // Shadow Resistance
			Data.Spells[numspells++]=5227;         // Underwater Breathing
			Data.Spells[numspells++]=7744;         // Will of the Forsaken
			AddSkill(109,300,300,false);    // lang: orcish
			Data.Spells[numspells++]=669;          // lang: orcish
			AddSkill(673,300,300,false);  // lang: gutterspeak
			Data.Spells[numspells++]=17737;        // lang: gutterspeak
			break;
		case RACE_TAUREN:
			Data.Spells[numspells++]=20552;        // Cultivation
			Data.Spells[numspells++]=20583;        // Nature Resistance
			Data.Spells[numspells++]=20550;        // Endurance
			Data.Spells[numspells++]=20549;        // War Stomp
			AddSkill(109,300,300,false);    // lang: orcish
			Data.Spells[numspells++]=669;          // lang: orcish
			AddSkill(115,300,300,false);  // lang: taurane
			Data.Spells[numspells++]=670;          // lang: taurane
			break;
		case RACE_GNOME:
			Data.Spells[numspells++]=20592;        // Arcane Resistance
			Data.Spells[numspells++]=20593;        // Engineering Specialization
			Data.Spells[numspells++]=20589;        // Escape Artist
			Data.Spells[numspells++]=20591;        // Expansive Mind
			AddSkill(98,300,300,false);     // lang: common
			Data.Spells[numspells++]=668;          // lang: common
			AddSkill(313,300,300,false);  // lang: gnomish
			Data.Spells[numspells++]=7340;         // lang: gnomish
			break;
		case RACE_TROLL:
			Data.Spells[numspells++]=20557;        // Beast Slaying
			Data.Spells[numspells++]=20554;        // Berserking
			Data.Spells[numspells++]=20555;        // Regeneration
			Data.Spells[numspells++]=20558;        // Throwing Specialization
			AddSkill(109,300,300,false);    // lang: orcish
			Data.Spells[numspells++]=669;          // lang: orcish
			AddSkill(315,300,300,false);  // lang: troll
			Data.Spells[numspells++]=7341;         // lang: troll
			break;
	}
	AddSkill(162,1,300,false);    // Unarmed
	Data.Spells[numspells++]=203; // Unarmed

	Data.Spells[numspells++]=6478; //Opening
	Data.Spells[numspells++]=81; //Dodge
	Data.Spells[numspells++]=0; //blank the next one just in case
	UpdateSkills(true);
	Data.UsedTalentPoints=0;
	// end initial spells
	Data.NormalStats.Armor=Armor;
	// make copies of any data that needs to be copied
	Data.CurrentStats=Data.NormalStats;
	Data.CurrentStats.Rage = 0;
	Data.BindContinent=Data.Continent;
	Data.BindLoc=Data.Loc;
	Data.BindZone = Data.Zone;
	string LowerName=Data.Name;
	MakeLower(LowerName);
	DataManager.PlayerNames[LowerName]=guid;

	// PvP stuff
	Data.PvP = false;
	Data.RecentPvP = false;
	Data.ResurrectionSickness = false;

	// Status flags (AFK, DND, GM)
	Data.StatusFlags = STATUS_NORMAL;
	Data.RestState=RESTEDSTATE_NORMAL;

	Data.LFG = 0x00;
	Data.PartyID = 0;
	Data.PartyRank = 0;

	// for testing
	Data.MountModel = 0;

	Data.bSummoned = false;
	Data.Copper = 0;
	Data.CritPct = 3.0f;

//	pItem = NULL;
//	if(DataManager.RetrieveObject((CWoWObject**)&pItem, Data.Items[SLOT_MAINHAND])) {
	if(Data.Items[SLOT_MAINHAND]) {
		if(pItem->pTemplateData) {
			DataObject.SetMinDamage(Data.Items[SLOT_MAINHAND]->pTemplateData->DamageStats[0].Min);
			DataObject.SetMaxDamage(Data.Items[SLOT_MAINHAND]->pTemplateData->DamageStats[0].Max);
			DataObject.SetAttackSpeed(Data.Items[SLOT_MAINHAND]->pTemplateData->WeaponSpeed);
			UpdateObject();
		}
	}
	if(Data.Items[SLOT_RANGED]) {
		if(pItem->pTemplateData) {
			DataObject.SetRangedMinDamage(Data.Items[SLOT_RANGED]->pTemplateData->DamageStats[0].Min);
			DataObject.SetRangedMaxDamage(Data.Items[SLOT_RANGED]->pTemplateData->DamageStats[0].Max);
			DataObject.SetRangedAttackSpeed(Data.Items[SLOT_RANGED]->pTemplateData->WeaponSpeed);
			UpdateObject();
		}
	}
}

void CPlayer::Clear()
{
	CWoWObject::Clear();
	memset(&Data,0,sizeof(PlayerData));
	TargetID=0;
	DuelGuid=0;
	DGuid2=0;
	duelhost=NULL;
	duelpartner=NULL;
	duelstarted=false;
	InCombat=false;
	isregenning=false;
	IsCasting=false;
	summonedCont=0;
	memset(&summonedLoc,0,sizeof(_Location));
	tradingWith=0;
	tradeAccepted = false;
	tradeGold = 0;
	tradeNum = 0;
	tradeState = 0;
	tradingWith = 0;
	inTrade = false;
	memset(tradeItems,0,7*sizeof(int));
	bSheathed=false;
	BuybackItems.clear();
	//	for (unsigned long i = 0 ; i < 40 ; i++)
	//		Items[i].Clear();
}
int CPlayer::SetFaction()
{
	FFaction = 0;
	FTeam = 0;
	switch(Data.Race)
	{
	case RACE_HUMAN:
		FFaction = PLAYERHuman;
		FTeam = Alliance;
		break;
	case RACE_DWARF:
		FFaction = PLAYERDwarf;
		FTeam = Alliance;
		break;
	case RACE_NIGHTELF:
		FFaction = PLAYERNightElf;
		FTeam = Alliance;
		break;
	case RACE_GNOME:
		FFaction = PLAYERGnome;
		FTeam = Alliance;
		break;
	case RACE_ORC:
		FFaction = PLAYEROrc;
		FTeam = Horde;
		break;
	case RACE_UNDEAD:
		FFaction = PLAYERUndead;
		FTeam = Horde;
		break;
	case RACE_TAUREN:
		FFaction = PLAYERTauren;
		FTeam = Horde;
		break;
	case RACE_TROLL:
		FFaction = PLAYERTroll;
		FTeam = Horde;
		break;
	}
	return FFaction;
}
void CPlayer::UpdateReputation(int id)
{
	// you CAN call me with -1, be prepared to die....
	CPacket pkg;
	if(id==-1)
	{
		for(int i=0; i<FACTION_ARRAY_COUNT; i++)
		{
			pkg.Reset(SMSG_SET_FACTION_STANDING);
			pkg << (unsigned long) Data.factionlist[i].Flags;
			pkg << (unsigned long) i;
			pkg << (unsigned long) Data.factionlist[i].Standing;
			pClient->Send(&pkg);
		}
	}
	else
	{
		pkg.Reset(SMSG_SET_FACTION_STANDING);
		pkg << (unsigned long) Data.factionlist[id].Flags;
		pkg << (unsigned long) id;
		pkg << (unsigned long) Data.factionlist[id].Standing;
		pClient->Send(&pkg);
	}
}

void CPlayer::GenerateFactions() // Call this only once: at player creation
{
	FactionEntry fac;
	long oppos,force,forceop;
	if(FTeam == Alliance)	{ oppos = Horde;	force = 891;	forceop=892; }
	else					{ oppos = Alliance;	force = 892;	forceop=891; }
	for(int i = 0; i<DBCManager.Faction.rowcount(); i++)
	{
		if(!DBCManager.Faction.fetchRow(DBCManager.Faction.getIntValueNoKey(i,0),&fac))
			continue;
		if(fac.reputationListID >= 0)
		{
			Data.factionlist[fac.reputationListID].Standing = 0;
			if(fac.faction != 0&&fac.faction!=169)
			{
				if( (fac.faction == FTeam || fac.faction == force) )
				{
					Data.factionlist[fac.reputationListID].Flags = fac.something6;
				}
				else if(fac.faction == oppos || fac.faction == forceop )
				{
					Data.factionlist[fac.reputationListID].Flags = fac.something7;
				}
			}
			else 
			{
				if(fac.something6&&!fac.something7)
				{
					Data.factionlist[fac.reputationListID].Flags = fac.something6;
				}
				else if(fac.something7&&!fac.something6)
				{
					Data.factionlist[fac.reputationListID].Flags = fac.something7;
				}
				else if(fac.something6&&fac.something7)
				{
					if(fac.ID==469)
					{
						if(FTeam == Alliance) Data.factionlist[fac.reputationListID].Flags = fac.something6;
						else if(FTeam==Horde) Data.factionlist[fac.reputationListID].Flags = fac.something7;
					}
					else if(fac.ID==67)
					{
						if(FTeam == Alliance) Data.factionlist[fac.reputationListID].Flags = fac.something7;
						else if(FTeam==Horde) Data.factionlist[fac.reputationListID].Flags = fac.something6;				
					}
					else
					{	
						if(FTeam == Alliance) Data.factionlist[fac.reputationListID].Flags = fac.something6;
						else Data.factionlist[fac.reputationListID].Flags = fac.something7;
					}
				}		
			}
		}
	}
}


unsigned long CPlayer::AddCreateObjectDataNotMe(char *buffer)
{
#define Add(datatype,data) *(datatype*)&buffer[c]=data;c+=sizeof(datatype);
	unsigned long c=0;

	// HEADER
	/*
	Add(unsigned long,guid);
	Add(unsigned long,PLAYERGUID_HIGH);
	*/
	c=Packets::PackGuidBuffer(buffer,guid,PLAYERGUID_HIGH);
	Add(unsigned char,ID_PLAYER);
	// Move Update
	Add(unsigned long, 0);//x04000000); // movement flags
	Add(_Location, Data.Loc);
	Add(float, Data.Facing);
	Add(unsigned long,0);
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
	/* Should I, or should I not? That is the question...
	Add(unsigned long,guid);
	Add(unsigned long,PLAYERGUID_HIGH);
	*/
	c=Packets::PackGuidBuffer(buffer,guid,PLAYERGUID_HIGH);
	Add(unsigned char,ID_PLAYER);
	// Move Update
	Add(unsigned long, 0);//x04000000); // movement flags
	Add(_Location, Data.Loc);
	Add(float, Data.Facing);
	//Add(float, Data.Facing); // weird? - chaos
	Add(unsigned long,0); // test
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
}

void CPlayer::PreCreateObjectOnlyMe()
{
	// add create update values here that only concerns this player like chatfilter and whatnot
}

void CPlayer::PostCreateObjectNotMe()
{
	// create visible items here?
}

void CPlayer::PostCreateObjectOnlyMe()
{
	// create none visible items here?
}

unsigned long CPlayer::GetPlayerInfoData(char *buffer, bool Self, bool Create) // @ enter world
{
#define Add(datatype,data) *(datatype*)&buffer[c]=data;c+=sizeof(datatype);
#define Skip(n) c+=n;
#define Fill(size,value) memset(&buffer[c],value,size);c+=size;
	int c=0;

	// HEADER
	/*Add(unsigned char,0xFF);
	Add(unsigned long,guid);
	Add(unsigned long,0);*/
	Skip(Packets::PackGuidBuffer(buffer,guid,0));
	Add(unsigned char,4);
	/*c+=Packets::PackGuidBuffer(&buffer[c],guid,PLAYERGUID_HIGH);
	Add(unsigned char,4);*/
	if (Create)
	{
		if (Self)
		{
			Add(unsigned char,(unsigned char)0x71);
			Add(unsigned long,(unsigned long)0x2000);
		} else {
			Add(unsigned char,(unsigned char)0x70);
			Add(unsigned long,(unsigned long)0x00);
		}

		Add(unsigned long,(unsigned long)0xB74D85D1);

		Add(_Location, Data.Loc);
		Add(float, Data.Facing);
		Add(unsigned long,0);
		if(Self)
		{
			Add(float,(float)0);
			Add(float,(float)1.0);
			Add(float,(float)0);
			Add(float,(float)0);
		}
		Add(float, Data.walkspeed);// walk speed
		Add(float, Data.runspeed);// runspeed
		Add(float, Data.runspeed/2);// runspeed backwards
		Add(float, Data.swimspeed);// swimspeed
		Add(float, Data.swimspeed);// swimspeed backwards
		Add(float, DEFAULT_PLAYER_TURN_RATE);// turn rate

		Add(unsigned long,0x6297848C);
	}


#undef Fill
#undef Skip
#undef Add

	// PLAYER
	CUpdateBlock block(&buffer[c], NUM_PLAYER_FIELDS);

	block.Add(OBJECT_FIELD_GUID, guid, PLAYERGUID_HIGH);
	block.Add(OBJECT_FIELD_TYPE, HIER_TYPE_PLAYER);
	block.Add(OBJECT_FIELD_SCALE_X, Data.Size);

	block.Add(UNIT_FIELD_HEALTH, Data.CurrentStats.HitPoints);
	block.Add(UNIT_FIELD_POWER1, Data.CurrentStats.Mana);
	block.Add(UNIT_FIELD_POWER2, Data.CurrentStats.Rage);
	block.Add(UNIT_FIELD_POWER3, Data.CurrentStats.Focus);
	block.Add(UNIT_FIELD_POWER4, Data.CurrentStats.Energy);

	block.Add(UNIT_FIELD_MAXHEALTH, Data.NormalStats.HitPoints);
	block.Add(UNIT_FIELD_MAXPOWER1, Data.NormalStats.Mana);
	block.Add(UNIT_FIELD_MAXPOWER2, Data.NormalStats.Rage);
	block.Add(UNIT_FIELD_MAXPOWER3, Data.NormalStats.Focus);
	block.Add(UNIT_FIELD_MAXPOWER4, Data.NormalStats.Energy);

	block.Add(UNIT_FIELD_LEVEL, Data.Level);
	block.Add(UNIT_FIELD_FACTIONTEMPLATE, FFaction); //5); // Need to test in Stormwind...
	// block.Add(UNIT_FIELD_FACTIONTEMPLATE, 5);
	block.Add(UNIT_FIELD_BYTES_0, Data.Race | Data.Class << 8 | Data.Female << 16 | Data.ManaType << 24);

	if(Data.MountModel)
		block.Add(UNIT_FIELD_FLAGS, UNIT_FLAG_MOUNT | UNIT_FLAG_MOUNT_ICON | UNIT_FLAG_SHEATHE);
	else
		block.Add(UNIT_FIELD_FLAGS, 0x1008);
	bSheathed = true;
	// Attack power calculations! Yay!
	unsigned long AtkBonus = AttackPowerBonus();

	block.Add(UNIT_FIELD_BASEATTACKTIME, Data.AttackSpeed);
	block.Add(UNIT_FIELD_BASEATTACKTIME + 1, Data.AttackSpeed);//2000); // unknown
	block.Add(UNIT_FIELD_RANGEDATTACKTIME,Data.RangedAttackSpeed);
	block.Add(UNIT_FIELD_BOUNDINGRADIUS, 0.383f);// Bounding Radius (0.383)
	block.Add(UNIT_FIELD_COMBATREACH, 1.5f); // Combat Reach (1.5)
	block.Add(UNIT_FIELD_DISPLAYID, Data.Model);
	block.Add(UNIT_FIELD_NATIVEDISPLAYID, Data.BaseModel); // added for 0.11
	block.Add(UNIT_FIELD_MOUNTDISPLAYID, Data.MountModel);
	block.Add(UNIT_FIELD_MINDAMAGE, (float)(Data.DamageMin+AtkBonus));
	block.Add(UNIT_FIELD_MAXDAMAGE, (float)(Data.DamageMax+AtkBonus));
	block.Add(UNIT_FIELD_BYTES_1, Data.WeaponMode << 24 | (Data.MorphState << 16) | Data.StandState);
	block.Add(UNIT_DYNAMIC_FLAGS,0x10); // should give you creature stats but works for players only O.o
	block.Add(UNIT_FIELD_STAT0, Data.CurrentStats.Strength); // added from below
	block.Add(UNIT_FIELD_STAT1, Data.CurrentStats.Agility);// added from below
	block.Add(UNIT_FIELD_STAT2, Data.CurrentStats.Stamina);// added from below
	block.Add(UNIT_FIELD_STAT3, Data.CurrentStats.Intellect);// added from below
	block.Add(UNIT_FIELD_STAT4, Data.CurrentStats.Spirit);// added from below

	block.Add(UNIT_FIELD_RESISTANCES, Data.CurrentStats.Armor); // correct
	block.Add(UNIT_FIELD_RESISTANCES+1, Data.CurrentStats.ResistHoly);//Data.CurrentStats.ResistHoly);
	block.Add(UNIT_FIELD_RESISTANCES+2, Data.CurrentStats.ResistFire);
	block.Add(UNIT_FIELD_RESISTANCES+3, Data.CurrentStats.ResistNature);
	block.Add(UNIT_FIELD_RESISTANCES+4, Data.CurrentStats.ResistFrost);
	block.Add(UNIT_FIELD_RESISTANCES+5, Data.CurrentStats.ResistShadow);
	block.Add(UNIT_FIELD_RESISTANCES+6, Data.CurrentStats.ResistArcane);

	block.Add(UNIT_FIELD_ATTACKPOWER, (unsigned long)AttackPower());
	//block.Add(UNIT_ATTACK_POWER_MODS, 0);

	block.Add(UNIT_FIELD_BYTES_2, 0xEEEEEE00);
	block.Add(UNIT_FIELD_RANGEDATTACKPOWER,RangedAttackPower());
	block.Add(UNIT_FIELD_MINRANGEDDAMAGE,Data.RangedDamageMin+RangedAttackPowerBonus());
	block.Add(UNIT_FIELD_MAXRANGEDDAMAGE,Data.RangedDamageMax+RangedAttackPowerBonus());

	block.Add(PLAYER_FLAGS,Data.StatusFlags);
	if(Create)
	{
		block.Add(PLAYER_GUILDID,Data.GuildID);
		block.Add(PLAYER_GUILDRANK,Data.GuildRank);
	}

	block.Add(PLAYER_BYTES, ((unsigned long)Data.Appearance[0]) | ((unsigned long)Data.Appearance[1] << 8) |
		((unsigned long)Data.Appearance[2] << 16) | (Data.Appearance[3] << 24));
	block.Add(PLAYER_BYTES_2, (Data.RestState << 24) | (unsigned char)(Data.StatusFlags & 0xFF) | (Data.Appearance[4] << 8)); // what's in <<16?
	block.Add(PLAYER_BYTES_3, (char)(Data.Female) | (Data.DrunkState << 8) | (Data.PvPRank << 24));

	if(Create)
		block.Add(PLAYER_GUILD_TIMESTAMP,Data.GuildTimestamp); // guild timestamp

	for (unsigned long g = 0 ; g < 60 ; g++)
	{
		block.Add(PLAYER_QUEST_LOG_1_1 + g, 0);
	}

	for	(unsigned long i = 0 ; i < 19 ;	i++)
	{
		if (Data.Items[i])
		{
//			CItem *pItem = NULL;
//			DataManager.RetrieveObject((CWoWObject**)&pItem,Data.Items[i]);
//			block.Add(PLAYER_VISIBLE_ITEM_1_0 + i*12,pItem->Data.nItemTemplate);
			block.Add(PLAYER_VISIBLE_ITEM_1_0 + i*12,Data.Items[i]->Data.nItemTemplate);
		}
	}

	for	(unsigned long i = 0 ; i < 39 ;	i++)
	{
		if (Data.Items[i])
		{
//			block.Add(PLAYER_FIELD_INV_SLOT_HEAD + i*2,	Data.Items[i], ITEMGUID_HIGH);
			block.Add(PLAYER_FIELD_INV_SLOT_HEAD + i*2,	Data.Items[i]->guid, ITEMGUID_HIGH);
		}
	}

	block.Add(PLAYER_XP, Data.Exp);
	block.Add(PLAYER_NEXT_LEVEL_XP, Data.NextLevelExp);
	if(Self)
	{
		for(unsigned long i=0;i<128;i++) //wahaha! skills!
		{
			if(!Data.Skills[i].SkillID) break;
			block.Add(PLAYER_SKILL_INFO_1_1+i*3, Data.Skills[i].SkillID);
			block.Add(PLAYER_SKILL_INFO_1_1+i*3+1, ((Data.Skills[i].MaxLevel)<<16)+Data.Skills[i].CurrentLevel);
			block.Add(PLAYER_SKILL_INFO_1_1+i*3+2, ((Data.Skills[i].posStatMaxLevel)<<16)+Data.Skills[i].posStatCurrentLevel);
		}
		if(Data.Level>9)
			block.Add(PLAYER_CHARACTER_POINTS1, ((Data.Level-9)-Data.UsedTalentPoints)); // talent points
		else block.Add(PLAYER_CHARACTER_POINTS1, 0);
		block.Add(PLAYER_CHARACTER_POINTS2, 40); // professions
		block.Add(PLAYER_CRIT_PERCENTAGE,Data.CritPct);
		for(int i=0; i < 64; i++)
		{
			block.Add(PLAYER_EXPLORED_ZONES_1 + i,Data.ExploredZones[i]);
		}
	}

	block.Add(PLAYER_REST_STATE_EXPERIENCE, (unsigned long)Data.RestAmount);
	block.Add(PLAYER_FIELD_COINAGE, Data.Copper);

	block.Add(PLAYER_FIELD_MOD_DAMAGE_DONE_POS, 0); //these new additions ensure that the melee damage is sent correctly
	block.Add(PLAYER_FIELD_MOD_DAMAGE_DONE_NEG, 0);
	block.Add(PLAYER_FIELD_MOD_DAMAGE_DONE_PCT, 1.00f);

	block.Add(PLAYER_FIELD_BYTES, 0xEEEE0000); //added was missing

	//"Honor System"
	block.Add(PLAYER_FIELD_PVP_TODAY_HONORABLE,0);
	block.Add(PLAYER_FIELD_PVP_YESTERDAY_HONORABLE,0);
	block.Add(PLAYER_FIELD_PVP_LASTWEEK_HONORABLE,0);
	block.Add(PLAYER_FIELD_PVP_THISWEEK_HONORABLE,0);
	block.Add(PLAYER_FIELD_PVP_THISWEEK_POINTS,0);
	block.Add(PLAYER_FIELD_PVP_LIFETIME_HONORABLE,0);
	block.Add(PLAYER_FIELD_PVP_LIFETIME_DISHONORABLE,0);
	block.Add(PLAYER_FIELD_PVP_YESTERDAY_POINTS,0);
	block.Add(PLAYER_FIELD_PVP_LASTWEEK_POINTS,0);
	block.Add(PLAYER_FIELD_PVP_LASTWEEK_STANDING,0);
	block.Add(PLAYER_FIELD_PVP_RANK_PROGRESS,0);

	return block.GetSize() + c;
}

void CPlayer::CreateGhost()
{
	CPacket pkg;
	pkg.Reset(SMSG_CORPSE_RECLAIM_DELAY);
	pkg << (unsigned long)30000;
	pClient->Send(&pkg);		// 30 second delay

	pkg.Reset(SMSG_SPELL_START);
	pkg << (unsigned char)0x0F << pClient->pPlayer->guid;
	pkg << (unsigned char)0x0F << pClient->pPlayer->guid;
	pkg << (unsigned short)8326;
	pkg << (unsigned short)0x00;
	pkg << (unsigned short)0x0F;
	pkg << (unsigned long)0x00;
	pkg << (unsigned long)0x00;
	pClient->Send(&pkg);

	pkg.Reset(SMSG_SPELL_GO);
	pkg << (unsigned char)0x0F << pClient->pPlayer->guid;
	pkg << (unsigned char)0x0F << pClient->pPlayer->guid;
	pkg << (unsigned short)8326;
	pkg << (unsigned short)0x00;
	pkg << (unsigned char)0x0D;
	pkg << (unsigned char)0x01;
	pkg << (unsigned char)0x01;
	pkg << (unsigned long)pClient->pPlayer->guid;
	pkg << (unsigned long)0;
	pkg << (unsigned long)0x00;
	pkg << (unsigned short)0x0200;
	pkg << (unsigned short)0x00;
	pClient->Send(&pkg);

	pkg.Reset(SMSG_UPDATE_AURA_DURATION);
	pkg << (unsigned long)0x20;
	pkg << (unsigned char)0;
	pClient->Send(&pkg);

	pkg.Reset(SMSG_STOP_MIRROR_TIMER);
	pkg << (unsigned long)0;
	pClient->Send(&pkg);

	pkg.Reset(SMSG_STOP_MIRROR_TIMER);
	pkg << (unsigned long)1;
	pClient->Send(&pkg);

	pkg.Reset(SMSG_STOP_MIRROR_TIMER);
	pkg << (unsigned long)2;
	pClient->Send(&pkg);

	Data.CurrentStats.HitPoints=1;
	DataObject.SetMountModel(0);

	AddUpdateVal(UNIT_FIELD_HEALTH, Data.CurrentStats.HitPoints);
	AddUpdateVal(UNIT_FIELD_FLAGS, UNIT_FLAG_WATERWALK | UNIT_FLAG_GHOST | UNIT_FLAG_SHEATHE);
	AddUpdateVal(UNIT_FIELD_AURA+33, 0x5068); // ghost look
	AddUpdateVal(UNIT_FIELD_AURAFLAGS+4, 0xEE); // ghost icon
	AddUpdateVal(UNIT_FIELD_AURASTATE, 0x2);
	AddUpdateVal(UNIT_FIELD_BYTES_1, 0x1000000);
	// SetAura(0,0x5068,0x5068,0,0,0);

	CPacket waterpacket;
	waterpacket.Reset(SMSG_MOVE_WATER_WALK);
	//waterpacket << (unsigned char)0xFF << this->guid << PLAYERGUID_HIGH;
	Packets::PackGuid(waterpacket,guid,PLAYERGUID_HIGH);
	pClient->Send(&waterpacket);

	if(Data.Race == RACE_NIGHTELF)
	{ // Nightelves change to wisps
		AddUpdateVal(UNIT_FIELD_DISPLAYID, 10045);
		SetSpeed(10.0f);
	}
	else
	{
		SetSpeed(8.5f);
	}

	DataObject.SetStatusFlags(STATUS_DEAD);
	pClient->UpdateObject();
}

void CPlayer::DuelPrepare(unsigned long gd)
{
	if(duelhost)
	{
		CPacket pkg(SMSG_CAST_RESULT);
		pkg << (unsigned long)7266;
		pkg << (unsigned char)2;
		pkg << (unsigned char)SPELL_FAIL_TARGET_IS_CURRENTLY_DUELING;
		pClient->Send(&pkg);
	}
	else
	{
		DataManager.RetrieveObject((CWoWObject**)&duelpartner,OBJ_PLAYER,gd);
		if (duelpartner && duelpartner->duelhost)
		{
			CPacket pkg(SMSG_CAST_RESULT);
			pkg << (unsigned long)7266;
			pkg << (unsigned char)2;
			pkg << (unsigned char)SPELL_FAIL_TARGET_IS_CURRENTLY_DUELING;
			pClient->Send(&pkg);
		}
		else
		{
			stopd=false;
			duelpartner->stopd= false;
			dueltick =0;
			duelpartner->dueltick = 0;
			duelhost = this;
			duelpartner->duelhost = this;
			DuelRequest();
		}
	}
}
void CPlayer::DuelRequest()
{
	CPacket pkg;
	float x = (pClient->pPlayer->duelpartner->Data.Loc.X+pClient->pPlayer->Data.Loc.X)/2;
	float y = (pClient->pPlayer->duelpartner->Data.Loc.Y+pClient->pPlayer->Data.Loc.Y)/2;
	CGameObject *df = new CGameObject;
	df->New(pClient->pPlayer,787,0,16,"Duel Flag",x,y,21680);
	DuelGuid = df->guid;
	dloc = df->Data.Loc;
	duelpartner->dloc = df->Data.Loc;
	pkg.Reset(SMSG_GAMEOBJECT_SPAWN_ANIM);
	pkg << DuelGuid << GAMEOBJECTGUID_HIGH;
	pClient->SendRegion(&pkg);
	pkg.Reset(SMSG_DUEL_REQUESTED);
	pkg << DuelGuid << GAMEOBJECTGUID_HIGH;
	pkg << guid << PLAYERGUID_HIGH;
	duelpartner->duelpartner = this;
	duelpartner->pClient->Send(&pkg);
	pClient->Send(&pkg);
}

void CPlayer::AcceptDuel(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	Data >> pClient->pPlayer->DGuid2;
	if(pClient->pPlayer->duelhost != pClient->pPlayer)
	{
		CPacket pkg(SMSG_DUEL_COUNTDOWN);
		pkg<<(unsigned long)3000;
		pClient->Send(&pkg);
		pClient->pPlayer->duelhost->pClient->Send(&pkg);
		EventManager.AddEvent(*(pClient->pPlayer),3000,EVENT_PLAYER_DUEL,0,0);
	}
}
void CPlayer::CancelDuel(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long dguid;
	Data>>dguid;
	CPacket pkg(SMSG_GAMEOBJECT_DESPAWN_ANIM);
	pkg << dguid << GAMEOBJECTGUID_HIGH;
	pClient->Send(&pkg);
	pClient->pPlayer->duelpartner->pClient->Send(&pkg);

	CGameObject *pgo;
	if(DataManager.RetrieveObject((CWoWObject**)&pgo,OBJ_GAMEOBJECT,dguid))
		RegionManager.ObjectRemove(*pgo);

	pkg.Reset(SMSG_DESTROY_OBJECT);
	pkg << dguid << GAMEOBJECTGUID_HIGH;
	pClient->SendRegion(&pkg);

	pkg.Reset(SMSG_DUEL_COMPLETE);
	pkg << (unsigned char)00;
	pClient->Send(&pkg);
	pClient->pPlayer->duelpartner->pClient->Send(&pkg);

	pClient->pPlayer->duelhost = NULL;
	pClient->pPlayer->duelpartner->duelhost = NULL;
	pClient->pPlayer->duelpartner->duelpartner = NULL;
	pClient->pPlayer->duelpartner = NULL;
}
void CPlayer::AddComboPt(CWoWObject *target)
{
	if(combo.target==NULL) 
	{
		combo.target=target;
		combo.pts++;
	}
	else if(combo.target==target)
	{
		combo.pts++;
	}
	else if(combo.target!=target)
	{
		combo.target=target;
		combo.pts=0;
		combo.pts++;
	}
	if(combo.pts>5) combo.pts=5;
	AddUpdateVal(PLAYER_FIELD_COMBO_TARGET,combo.target->guid);
	AddUpdateVal(PLAYER_FIELD_COMBO_TARGET+1,0x00000000);
	AddUpdateVal(PLAYER_FIELD_BYTES,(combo.pts<<8));
	UpdateObject();	
}
void CPlayer::ResetCombo()
{
	combo.pts =0;
	combo.target =NULL;
	AddUpdateVal(PLAYER_FIELD_COMBO_TARGET,0x0000000000000);
	AddUpdateVal(PLAYER_FIELD_COMBO_TARGET+1,0x00000000);
	AddUpdateVal(PLAYER_FIELD_BYTES,(0x00000000));
	UpdateObject();	
}
void CPlayer::StartChannel(unsigned long spellid,unsigned long duration,unsigned long Target)
{
	AddUpdateVal(UNIT_FIELD_CHANNEL_OBJECT,Target);
	AddUpdateVal(UNIT_FIELD_CHANNEL_OBJECT+1,0x0000000);
	AddUpdateVal(UNIT_CHANNEL_SPELL,spellid);
	CPacket pkt(MSG_CHANNEL_START);
	pkt<<spellid;
	pkt<<duration;
	pClient->Send(&pkt);
	UpdateObject();
}
void CPlayer::StopChannel(unsigned long spellid)
{
	AddUpdateVal(UNIT_FIELD_CHANNEL_OBJECT,0);
	AddUpdateVal(UNIT_FIELD_CHANNEL_OBJECT+1,0x0000000);
	AddUpdateVal(UNIT_CHANNEL_SPELL,0);
	CPacket pkt(MSG_CHANNEL_UPDATE);
	pkt<<spellid;
	pkt<<1;
	pClient->Send(&pkt);
	UpdateObject();
}
void CPlayer::CreateCorpse()
{
	CCorpse *pCorpse = new CCorpse;
	pCorpse->New();

	if(!Data.CorpseLoc.X && !Data.CorpseLoc.Y && !Data.CorpseLoc.Z)
	{
		Data.CorpseLoc = Data.Loc;
	}
	strcpy(pCorpse->Data.Name,Data.Name);
	memcpy(pCorpse->Data.Appearance,&Data.Appearance,5);
	memcpy(pCorpse->Data.Items,&Data.Items,120*sizeof(unsigned long));//todo items
	pCorpse->Data.Owner = guid;
	pCorpse->Data.Model = Data.Model;
	pCorpse->Data.Race = Data.Race;
	pCorpse->Data.Loc = Data.CorpseLoc;
	pCorpse->Data.Continent = Data.Continent;
	pCorpse->Data.Facing = Data.Facing;
	pCorpse->Data.Gender = Data.Female;

	RegionManager.ObjectNew(*pCorpse,Data.Continent,Data.Loc.X,Data.Loc.Y);
	DataManager.NewObject(*pCorpse);

	Corpse = pCorpse->guid;
}

void CPlayer::SendResurrectRequest()
{
	CPacket pkg(SMSG_RESURRECT_REQUEST);
	pkg << guid;
	pkg << (long)0;
	pkg << (long)0;
	pkg << (char)0;
	pClient->Send(&pkg);
}

void CPlayer::Resurrect()
{
	Data.CurrentStats.HitPoints = Data.NormalStats.HitPoints >> 1; // /2; This change works provided the HP isn't negative...
	Data.bDead = false;
	dead = false;

	AddUpdateVal(UNIT_FIELD_HEALTH, Data.CurrentStats.HitPoints);
	AddUpdateVal(UNIT_FIELD_FLAGS, UNIT_FLAG_SWIM | UNIT_FLAG_SHEATHE | 0x1008);
	AddUpdateVal(UNIT_FIELD_AURA+32, 0); // ghost look
	AddUpdateVal(UNIT_FIELD_AURAFLAGS+4, 0); // ghost icon
	AddUpdateVal(UNIT_FIELD_AURALEVELS+8, 0xeeeeeeee);
	AddUpdateVal(UNIT_FIELD_AURAAPPLICATIONS+8, 0xeeeeeeee);
	AddUpdateVal(UNIT_FIELD_AURASTATE, 0);
	// RemoveAura(0);

	DataObject.SetDrunkState(0);	// reset drunkenness!

	if(Data.Race == RACE_NIGHTELF)
	{ // Nightelves change back
		AddUpdateVal(UNIT_FIELD_DISPLAYID, Data.Model);
	}
	DataObject.SetStatusFlags(STATUS_NORMAL);
	pClient->UpdateObject();

	CCorpse *pCorpse =  NULL;

	if(!DataManager.RetrieveObject((CWoWObject**)&pCorpse,OBJ_CORPSE,Corpse))
		return;

	pCorpse->Data.Owner=0;
	pCorpse->SpawnBones();
	pClient->UpdateKnownCorpse(*pCorpse);
	Corpse=0;
	Data.CorpseLoc.X = 0;
	Data.CorpseLoc.Y = 0;
	Data.CorpseLoc.Z = 0;

	isregenning = true;

	EventManager.AddEvent(*(pClient->pPlayer),100,EVENT_PLAYER_REGENERATE,0,0);
	EventManager.AddEvent(*(pClient->pPlayer),600000,EVENT_PLAYER_SAVE,0,0);
	//EventManager.AddEvent(*(pClient->pPlayer),60000,EVENT_PLAYER_REZSICKNESS,0,0);

	// Reset waterwalk and speed
	CPacket pkg(SMSG_MOVE_LAND_WALK);
	Packets::PackGuid(pkg,pClient->pPlayer->guid,PLAYERGUID_HIGH);
	//pkg << (unsigned char)0xFF << pClient->pPlayer->guid << 0;
	pClient->Send(&pkg);

	SetSpeed(7.0f);

	pClient->pAccount->Save();
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
	case OBJ_DYNAMICOBJECT:
		pClient->AddKnownDynamicObject(*(CDynamicObject*)&Object);
		break;
pClient->AddKnownGameObject(*(CGameObject*)&Object);
		break;
	case OBJ_GAMEOBJECT:
		pClient->AddKnownGameObject(*(CGameObject*)&Object);
		break;
	case OBJ_CORPSE:
		pClient->AddKnownCorpse(*(CCorpse*)&Object);
		break;
	case OBJ_ITEM:
		pClient->AddKnownItem(*(CItem*)&Object);
		break;
	case OBJ_CREATURE:
		pClient->AddKnownCreature(*(CCreature*)&Object);
		break;
	case OBJ_PLAYER:
		CPlayer *pPlayer = (CPlayer *)&Object;
		if(pPlayer->Data.bDead){ break; }// Send no updates for dead ppl.
		pClient->AddKnownPlayer(*pPlayer);
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
	case OBJ_GAMEOBJECT:
		pClient->UpdateKnownGameObject(*(CGameObject*)&Object);
		break;
	case OBJ_ITEM:
		pClient->UpdateKnownItem(*(CItem*)&Object);
		break;
	case OBJ_CREATURE:
		pClient->UpdateKnownCreature(*(CCreature*)&Object);
		break;
	case OBJ_PLAYER:
		pClient->UpdateKnownPlayer(*(CPlayer*)&Object);
		break;
	case OBJ_CORPSE:
		pClient->UpdateKnownCorpse(*(CCorpse*)&Object);
		break;
	}
}

void CPlayer::ObjectFades(CWoWObject &Object)
{
	if (!pClient)
	{
		//RegionManager.ObjectRemove(*this);
		return;
	}
	switch(Object.type)
	{
		case OBJ_DYNAMICOBJECT:
		pClient->RemoveKnownDynamicObject(*(CDynamicObject*)&Object);
		break;
	case OBJ_GAMEOBJECT:
		pClient->RemoveKnownGameObject(*(CGameObject*)&Object);
		break;
	case OBJ_ITEM:
		pClient->RemoveKnownItem(*(CItem*)&Object);
		break;
	case OBJ_CREATURE:
		pClient->RemoveKnownCreature(*(CCreature*)&Object);
		break;
	case OBJ_PLAYER:
		pClient->RemoveKnownPlayer(*(CPlayer*)&Object);
		break;
	case OBJ_CORPSE:
		pClient->RemoveKnownCorpse(*(CCorpse*)&Object);
		break;
	}
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
		Data.GuildID=0;
		Data.GuildRank=0;
		Data.GuildTimestamp=0;
		Data.GuildOfficerNote[0]=0;
		Data.GuildPublicNote[0]=0;
	}
	BuybackItems.clear();
	CWoWObject::Delete();
}

float CPlayer::Distance(CPlayer &Player)
{
	// distance
	//      ______________________________
	//     /(( X2 - X1 )^2 + (Y2 - Y1) ^2)
	//   \/
	float A=Player.Data.Loc.X-Data.Loc.X;
	float B=Player.Data.Loc.Y-Data.Loc.Y;
	float C=Player.Data.Loc.Z-Data.Loc.Z;
	return sqrtf((A*A)+(B*B)+(C*C));
}


void CPlayer::UseMana(int type, unsigned long id)
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


long CPlayer::CalculateDmg(int type, short id, int &flag, int &victimflags)
{
	// miss
	if (!(rand() % 4))
	{
		flag = 0x22;
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
		long diff = long(Data.DamageMax - Data.DamageMin);
		long rv;
		if (diff)
		{
			rv = (long)(Data.DamageMin + (rand() % diff));
		}
		else
			rv = (long)Data.DamageMin;

		//long strmultiplier = ((Data.CurrentStats.Strength-20)/10);		}
		long strmultiplier = AttackPowerBonus(); //14000 = 14 for conversion, 1000 for millisec

		rv += strmultiplier;

		flag = 0x22;
		victimflags = 0x01;

		if ((rand() % 10000) < (100.0f*Data.CritPct)) //critical hit!
		{
			flag = 0x2E;
			rv += rv + (Data.Level * 2);
			return rv;
		}

		if ((rand() % 10000) < (100.0f*4.0f))	// Dodge
		{
			victimflags = 2;
			return 0;
		}

		if ((rand() % 10000) < (100.0f*4.0f))	// Parry
		{
			victimflags = 3;
			return 0;
		}

		if ((rand() % 10000) < (100.0f*4.0f))	// Block
		{
			victimflags = 5;
			return 0;
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
unsigned long CPlayer::CalcTalentResetCost(unsigned long resetnum)
{
	unsigned long cost;
	if(resetnum ==0 ) cost = 10000;
	else cost = resetnum*5000*10;
	if(cost>=500000) cost = 500000;
	return cost;
}
void CPlayer::BindInitiate()
{
	CPacket pkg(MSG_BINDPOINT_CONFIRM);
	pkg<<guid<<PLAYERGUID_HIGH;
	pClient->Send(&pkg);
}
void CPlayer::TalentResetInitiate()
{
	CPacket pkg;
	pkg.Reset(MSG_TALENT_WIPE_CONFIRM);
	pkg << guid << PLAYERGUID_HIGH;
	pkg << CalcTalentResetCost(Data.TalentResetTimes);
	pClient->Send(&pkg);
}
void CPlayer::MsgTalentReset(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	pClient->pPlayer->Data.Copper-=pClient->pPlayer->CalcTalentResetCost(pClient->pPlayer->Data.TalentResetTimes);
	pClient->pPlayer->Data.TalentResetTimes++;
	pClient->pPlayer->DataObject.SetCoinage(pClient->pPlayer->Data.Copper);
	pClient->pPlayer->UpdateObject();
	CPacket pkg;
	//Clear all spells first
	for(int i=0;i<20;i++)
	{
		if(pClient->pPlayer->Data.Talents[i])
		{	
			for(int j=0;j<200;j++)
			{
				if(pClient->pPlayer->Data.Spells[j] == pClient->pPlayer->Data.Talents[i])
				{
					pClient->pPlayer->Data.Spells[j]=0;
					break; // if you did it properly, you should never have duplicates!
				}
			}
			pkg.Reset(SMSG_REMOVED_SPELL);
			pkg << (unsigned long)pClient->pPlayer->Data.Talents[i];
			pClient->Send(&pkg);
			pClient->pPlayer->Data.Talents[i]=0;
		}
	}
	pClient->pPlayer->Data.UsedTalentPoints = 0;
	pClient->pPlayer->AddUpdateVal(PLAYER_CHARACTER_POINTS1,(pClient->pPlayer->Data.Level - 9));
	pClient->pPlayer->UpdateObject();
}
void CPlayer::DuelTimer(CPlayer* dhost,CPlayer* tduel,unsigned long dguid)
{
	Debug.Log("Timer Called");
	if(!duelstarted)
	{
		if(dhost && tduel)
		{
			dhost->AddUpdateVal(PLAYER_DUEL_ARBITER, dguid, 0);
			dhost->AddUpdateVal(PLAYER_DUEL_TEAM, 1);
			dhost->UpdateObject();
			dhost->AddUpdateVal(PLAYER_DUEL_TEAM, 2);
			dhost->UpdateObjectOnlyPlayer(dhost,tduel->guid,0x00000000,true);
			tduel->AddUpdateVal(PLAYER_DUEL_ARBITER, dguid, 0);
			tduel->AddUpdateVal(PLAYER_DUEL_TEAM, 2);
			tduel->UpdateObject();
			tduel->AddUpdateVal(PLAYER_DUEL_TEAM, 1);
			tduel->UpdateObjectOnlyPlayer(tduel,dhost->guid,0x00000000,true);
			tduel->DuelGuid = dguid;
			dhost->DuelGuid = dguid;
			stopd = false;
			duelstarted = true;
			inbounds = true;
			duelpartner->inbounds = true;
		}
	}
	if(dhost->Distance(dloc)>30.0f)
	{
		if(dhost->inbounds)
		{
			dhost->inbounds = false;
			EventManager.AddEvent(*(dhost),1000,EVENT_PLAYER_DUELFLEE,0,0);
		}
		//dhost->DuelFlee();
	}
	if(tduel->Distance(dloc)>30.0f)
	{
		if(tduel->inbounds)
		{
			tduel->inbounds = false;
			EventManager.AddEvent(*(tduel),1000,EVENT_PLAYER_DUELFLEE,0,0);
		}
		//tduel->DuelFlee();
	}
}
void CPlayer::DuelTick()
{
	if(dueltick==0)
	{
		CPacket pkg;
		pkg.Reset(SMSG_DUEL_OUTOFBOUNDS);
		pClient->Send(&pkg);
	}
	else if(dueltick == 10&&Distance(dloc)>30.0f)
	{
		DuelFlee();
	}
	else if(dueltick<10&&dueltick>1&&Distance(dloc)<30.0f)
	{
		dueltick =0;
		CPacket pkg;
		pkg.Reset(SMSG_DUEL_INBOUNDS);
		pClient->Send(&pkg);
		inbounds = true;
	}
	if(!inbounds) dueltick++;
}
void MsgAttackOn(CClient *pClient, unsigned int msgID, CDataBuffer &Data); // forward dec it here for now

void CPlayer::ProcessEvent(struct WoWEvent &Event)
{
	switch(Event.EventType)
	{
	case EVENT_PLAYER_REDUCEBREATH:
		{
			if(BreathingAir == 1)
			{
				pClient->pPlayer->Breath = 20000;
				return;
			}
			Breath-=1000;
			//pClient->Echo("Breath now: %d",Breath);
			if(Breath == 0)
			{
				// Start losing HP
				EventManager.AddEvent(*this,1000,EVENT_PLAYER_REDUCEHPBREATH,0,0);
			} else {
				EventManager.AddEvent(*this,1000,EVENT_PLAYER_REDUCEBREATH,0,0);
			}
		}
		break;
	case EVENT_PLAYER_REDUCEHPBREATH:
		{
			if(BreathingAir == 1)
			{
				pClient->pPlayer->Breath = 20000;
				return;
			}
			DataObject.AddHP(-20);
			pClient->UpdateObject();
			if (Data.CurrentStats.HitPoints <= 0 && !dead)
			{
				dead = true;
			} else {
				EventManager.AddEvent(*this,1000,EVENT_PLAYER_REDUCEHPBREATH,0,0);
			}
		}
		break;

	case EVENT_PLAYER_DISMOUNT:
		{
			DataObject.SetMountModel(0);
			DataObject.SetFlag(0);
			pClient->UpdateObject();
			bIsFlying = false;
		}
		break;
	case EVENT_PLAYER_GAINEXP:
		{
			int expgain;
			memcpy(&expgain, Event.pEventData, sizeof(expgain));
			AddExp(expgain);
		}
		break;
	case EVENT_PLAYER_REGENERATE:
		Regenerate();
		break;
	case EVENT_PLAYER_REGENERATESPELL:
		{
			long restoreauraslot;
			memcpy(&restoreauraslot, Event.pEventData, sizeof(restoreauraslot));
			// Apply effect...
			switch(RestoreAuras[restoreauraslot].Type)
			{
			case RESTORETYPE_HEALTH:
				{
					DataObject.AddHP(RestoreAuras[restoreauraslot].PerTick);
				}
				break;
			case RESTORETYPE_MANA:
				{
					DataObject.AddMana(RestoreAuras[restoreauraslot].PerTick);
				}
				break;
			case RESTORETYPE_ENERGY:
				{
					DataObject.AddEnergy(RestoreAuras[restoreauraslot].PerTick);
				}
				break;
			}

			RestoreAuras[restoreauraslot].RemainingTicks--;
			if (RestoreAuras[restoreauraslot].RemainingTicks <= 0)
			{
				// None left
				pClient->Echo("Yum yum food is good xD");
			} else {
				// More...
				EventManager.AddEvent(*this,RestoreAuras[restoreauraslot].FrequencyID,EVENT_PLAYER_REGENERATESPELL,&restoreauraslot,sizeof(restoreauraslot));
				// pClient->Echo("More food.. :)");
			}
		}
		break;
	case EVENT_PLAYER_DUEL:
		{
			if(!stopd)
			{
				DuelTimer(duelhost,this,DGuid2);
				EventManager.AddEvent(*(pClient->pPlayer),2000,EVENT_PLAYER_DUEL,0,0);
			}
		}
		break;
	case EVENT_PLAYER_DUELFLEE:
		{
			if(!stopd)
			{
				if(!inbounds)
				{
					DuelTick();
					EventManager.AddEvent(*(this),1000,EVENT_PLAYER_DUELFLEE,0,0);
				}
			}
		}
		break;
	case EVENT_PLAYER_REZSICKNESS:
		RezSickness();
		break;
	case EVENT_PLAYER_PVP:
		PvPToggle();
		break;
	case EVENT_PLAYER_SAVE:
		pClient->pAccount->Save();
		break;
	case EVENT_PLAYER_REMOVE_AURA:
		{
			long aura_value;
			memcpy(&aura_value, Event.pEventData, sizeof(aura_value));
			// Remove the aura
			RemoveAura(aura_value);
			pClient->Echo("Aura worn off!");
			// Data.CurrentStats.Armor = Data.CurrentStats.Armor - aura_value;
			// pClient->Echo("Your Armor buff has worn off.");
			// armor_buff = false;
		}
		break;
	case EVENT_PLAYER_HOTTED:
		{
			long data[6];
			memcpy(&data, Event.pEventData, sizeof(long)*6);
			data[3]++;
			long power = data[0];long id = data[1];int cn=data[3];
			if(Data.CurrentStats.HitPoints + power >Data.NormalStats.HitPoints)
			{
				DataObject.AddHP(Data.NormalStats.HitPoints - Data.CurrentStats.HitPoints);
			}
			else DataObject.AddHP(power);
			UpdateObject();
			SendPeriodicLog(power,id,8,data[5],pCaster,this);		
			if(cn<data[2])
				EventManager.AddEvent(*this,data[4], EVENT_PLAYER_HOTTED, &data, sizeof(long)*6);

		}
		break;
	case EVENT_PLAYER_DOTTED:
		{
			long data[6];
			memcpy(&data, Event.pEventData, sizeof(long)*6);
			data[3]++;
			long power = data[0];long id = data[1];int cn=data[3];
			TakeDamage(NULL,power,true);
			UpdateObject();
			SendPeriodicLog(power,id,3,data[5],pCaster,this);		
			if(cn<data[2])
				EventManager.AddEvent(*this,data[4], EVENT_PLAYER_DOTTED, &data, sizeof(long)*6);
		}
		break;
	case EVENT_PLAYER_END_ATTACK:
		{
			if(dead == false) // any more states that should not allow attacks?
			{
				CDataBuffer data(Event.pEventData, 8);
				MsgAttackOn(pClient, 0, data);
			}
		}
		break;
	case EVENT_PLAYER_TAXI_END:
		{
			pClient->pDataObject->SetMountModel(0);
			pClient->UpdateObject();
		}
		break;
	case EVENT_PLAYER_LOGOUT:
		{
			pClient->CompleteLogout();
		}
		break;
	case EVENT_PLAYER_REST:
		{
			if(Data.RestAmount < Data.NextLevelExp*1.5)
			{
				unsigned long timetonext;
				memcpy(&timetonext, Event.pEventData, sizeof(timetonext));
				DataObject.AddRestAmount(Data.NextLevelExp / 4000.0f); //call me every 4.8 minutes! (8 hours accum. to 10 = one bubble)
				if(Data.RestState!=RESTEDSTATE_RESTED) DataObject.SetRestState(RESTEDSTATE_RESTED);
				if(pClient) pClient->UpdateObject();
				EventManager.AddEvent(*this,timetonext,EVENT_PLAYER_REST,&timetonext,sizeof(timetonext));
			}
		}
		break;
	case EVENT_PLAYER_RAGEDEGENERATE:
		if(Data.CurrentStats.Rage > 0 && !InCombat)
		{
			if (Data.CurrentStats.Rage < 30)
				Data.CurrentStats.Rage = 0;
			else
				Data.CurrentStats.Rage-= 30;

			pClient->pDataObject->SetRage(Data.CurrentStats.Rage);
			pClient->UpdateObject();
			EventManager.AddEvent(*this,3000, EVENT_PLAYER_RAGEDEGENERATE,0,0);
		}
		break;
	}
}

long CPlayer::FindFreeRestoreAuraSlot()
{
	for(int i=0;i<5;i++)
	{
		if (RestoreAuras[i].SpellID == 0)
			return i;
	}
	return -1;
}
void CPlayer::Regenerate()
{
	bool regenning = false;

	_timeb now;
	_ftime(&now);
	if(EventManager.DiffTime(now, LastAttack) < 10000&&Data.Class!=CLASS_ROGUE) // No regen for 10 secs after last attack
		// TODO: Add a general "lastincombat" time
	{
		isregenning = true;
		EventManager.AddEvent(*this,10000,EVENT_PLAYER_REGENERATE,0,0);
		return;
	}
	struct LevelBonus
	{
		float HP;
		long Mana;
	};
	LevelBonus BoniiMult[12]={
		{0.0f,	0}, //blank
		{0.80f,	0}, //warrior
		{0.25f,	8}, //paladin
		{0.25f,	11}, //hunter
		{0.50f,	0}, //rogue
		{0.10f,	13}, //priest
		{0.0f,	0}, //blank
		{0.11f,	17}, //shaman
		{0.10f,	11}, //mage
		{0.11f,	8}, //warlock
		{0.0f,	0}, //blank
		{0.11f,	15} //druid: approximate HP bonus equal to shaman
	};
	if(Data.Class<=CLASS_DRUID)
	{
		//bonus = (Data.Level * 2) - 2; // ADD 2HP / MANA Regen by level

		if (Data.CurrentStats.HitPoints < Data.NormalStats.HitPoints) {
			regenning = true;
			//DataObject.AddHP(PLAYER_REGEN_HPS + bonus);
			DataObject.AddHP((long)(Data.CurrentStats.Spirit*BoniiMult[Data.Class].HP));
		}
		if (Data.CurrentStats.Mana < Data.NormalStats.Mana) {
			regenning = true;
			long adjspirit=0;
			if(Data.Class==CLASS_DRUID || Data.Class==CLASS_SHAMAN) adjspirit=Data.CurrentStats.Spirit/5;
			else adjspirit=Data.CurrentStats.Spirit/4;
			DataObject.AddMana(adjspirit+BoniiMult[Data.Class].Mana);
			//DataObject.AddMana(PLAYER_REGEN_MANA + bonus);
		}
		//TODO: What about Focus?
		if (Data.CurrentStats.Focus < Data.NormalStats.Focus) {
			regenning = true;
			//DataObject.AddFocus(PLAYER_REGEN_MANA + bonus);
			DataObject.AddFocus(PLAYER_REGEN_MANA + (Data.Level * 2) - 2);
		}
		if (Data.CurrentStats.Energy < Data.NormalStats.Energy) {
			regenning = true;
			//DataObject.AddEnergy(PLAYER_REGEN_MANA + bonus);
			DataObject.AddEnergy(20);
		}
	}
	if(UpdateDirty())
		UpdateObject();
	if (regenning) {
		isregenning = true;
		EventManager.AddEvent(*this,2000,EVENT_PLAYER_REGENERATE,0,0);
	}
	else {
		isregenning = false;
	}
}

void CPlayer::RezSickness()
{
	Data.ResurrectionSickness = false;
	pClient->pPlayer->AddUpdateVal(UNIT_FIELD_FLAGS, UNIT_FLAG_SWIM | UNIT_FLAG_SHEATHE);
	pClient->pPlayer->bSheathed = true;

	pClient->Echo("Resurrection sickness has worn off...");
}
void CPlayer::SendPeriodicLog(unsigned long power,unsigned long spellid,unsigned long EffectID,unsigned long School,CWoWObject * Caster,CWoWObject * Target)
{
	CPacket pkg;
	pkg.Reset(SMSG_PERIODICAURALOG);
	Packets::PackGuid(pkg,Target->guid,PLAYERGUID_HIGH);
	Packets::PackGuid(pkg,Caster->guid,PLAYERGUID_HIGH);
	pkg << (unsigned long)spellid;
	pkg << (unsigned long)0x00000001;
	pkg << (unsigned long)EffectID;
	switch(EffectID)
	{
	case 3: { pkg<<power<<School<<(unsigned long)0;break; }
	case 8: {pkg<<power;break;}
	case 24: {pkg<<((CPlayer*)Target)->Data.ManaType;pkg<< power<<(char)00;break;}
	}
	pClient->SendRegion(&pkg);
}
void CPlayer::SendSpellLog(unsigned long power,unsigned long spellid,unsigned long EffectID,CWoWObject * Caster,CWoWObject * Target)
{
	CPacket pkg;
	pkg.Reset(SMSG_SPELLLOGEXECUTE);
	Packets::PackGuid(pkg,Caster->guid,PLAYERGUID_HIGH);
	pkg << (unsigned long)spellid;
	pkg << (unsigned long)0x00000001;
	pkg << (unsigned long)EffectID;
	pkg << (unsigned long)0x0000001;
	pkg<<Target->guid<<CREATUREGUID_HIGH;
	switch(EffectID)
	{
	case 10: {pkg<< power;pkg<<(char)00;break;}
	case 30: {pkg<< power;pkg<<((CPlayer*)Target)->Data.ManaType<<(char)00;break;}
	}
	pClient->SendRegion(&pkg);
}
/*
void Player::BuildPlayerRepop()
{
WorldPacket data;
//1.1.1
SetUInt32Value( UNIT_FIELD_HEALTH, 1 );

SetMovement(MOVE_UNROOT);
SetMovement(MOVE_WATER_WALK);

SetPlayerSpeed(RUN, (float)8.5, true);
SetPlayerSpeed(SWIM, (float)5.9, true);

data.Initialize(SMSG_CORPSE_RECLAIM_DELAY );
data << uint8(0x30) << uint8(0x75) << uint8(0x00) << uint8(0x00);
GetSession()->SendPacket( &data );

data.Initialize(SMSG_SPELL_START );
data << GetGUID() << GetGUID() << uint32(8326);
data << uint16(0) << uint32(0) << uint16(0x02) << uint32(0) << uint32(0);
GetSession()->SendPacket( &data );

data.Initialize(SMSG_UPDATE_AURA_DURATION);
data << uint8(32);
data << uint32(0);
GetSession()->SendPacket( &data );

data.Initialize(SMSG_CAST_RESULT);
data << uint32(8326);
data << uint8(0x00);
GetSession()->SendPacket( &data );

data.Initialize(SMSG_SPELL_GO);
data << GetGUID() << GetGUID() << uint32(8326);
data << uint16(01) << uint8(0) << uint8(0);
data << uint16(0040);
data << GetPositionX();
data << GetPositionY();
data << GetPositionZ();
GetSession()->SendPacket( &data );

data.Initialize(SMSG_SPELLLOGEXECUTE);
data << (uint32)GetGUID() << (uint32)GetGUID();
data << uint32(8326);
data << uint32(1);
data << uint32(0x24);
data << uint32(1);
data << GetGUID();
GetSession()->SendPacket( &data );

data.Initialize(SMSG_STOP_MIRROR_TIMER);
data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);
GetSession()->SendPacket( &data );

data.Initialize(SMSG_STOP_MIRROR_TIMER);
data << uint8(0x01) << uint8(0x00) << uint8(0x00) << uint8(0x00);
GetSession()->SendPacket( &data );

data.Initialize(SMSG_STOP_MIRROR_TIMER);
data << uint8(0x02) << uint8(0x00) << uint8(0x00) << uint8(0x00);
GetSession()->SendPacket( &data );

SetUInt32Value(CONTAINER_FIELD_SLOT_1+29, 8326);
SetUInt32Value(UNIT_FIELD_AURA+32, 8326);
SetUInt32Value(UNIT_FIELD_AURALEVELS+8, 0xeeeeee00);
SetUInt32Value(UNIT_FIELD_AURAAPPLICATIONS+8, 0xeeeeee00);
SetUInt32Value(UNIT_FIELD_AURAFLAGS+4, 12);
SetUInt32Value(UNIT_FIELD_AURASTATE, 2);

SetFlag(PLAYER_FLAGS, 0x10);

//spawn Corpse
SpawnCorpseBody();
}

void Player::ResurrectPlayer()
{
RemoveFlag(PLAYER_FLAGS, 0x10);
setDeathState(ALIVE);
if(getRace() == 4) { // NEs to turn back from Wisp.
DeMorph();
}

// hiding spirit healers to living players
for (Object::InRangeSet::iterator iter = GetInRangeSetBegin();
iter != GetInRangeSetEnd(); iter++)
{
Creature *creat = objmgr.GetObject<Creature>((*iter)->GetGUID());
if (creat && creat->GetUInt32Value(UNIT_FIELD_DISPLAYID) == 5233)
creat->DestroyForPlayer(this);
}
}

void Player::KillPlayer()
{
WorldPacket data;

SetMovement(MOVE_ROOT);

data.Initialize(SMSG_STOP_MIRROR_TIMER);
data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);
GetSession()->SendPacket( &data );

data.Initialize(SMSG_STOP_MIRROR_TIMER);
data << uint8(0x01) << uint8(0x00) << uint8(0x00) << uint8(0x00);
GetSession()->SendPacket( &data );

data.Initialize(SMSG_STOP_MIRROR_TIMER);
data << uint8(0x02) << uint8(0x00) << uint8(0x00) << uint8(0x00);
GetSession()->SendPacket( &data );

setDeathState(CORPSE);
SetFlag( UNIT_FIELD_FLAGS, 0x08 ); //player death animation, also can be used with DYNAMIC_FLAGS
SetFlag( UNIT_DYNAMIC_FLAGS, 0x00 );
CreateCorpse();

if(getRace() == 4) { // NEs
this->SetUInt32Value(UNIT_FIELD_DISPLAYID, 10045);
}
}

void Player::CreateCorpse()
{
Corpse *pCorpse;
uint32 _uf, _pb, _pb2, _cfb1, _cfb2;

pCorpse = objmgr.GetCorpseByOwner(this);
if(!pCorpse)
{
pCorpse = new Corpse();
pCorpse->Create(objmgr.GenerateLowGuid(HIGHGUID_CORPSE), this, GetMapId(), GetPositionX(),
GetPositionY(), GetPositionZ(), GetOrientation());

_uf = GetUInt32Value(UNIT_FIELD_BYTES_0);
_pb = GetUInt32Value(PLAYER_BYTES);
_pb2 = GetUInt32Value(PLAYER_BYTES_2);

uint8 race       = (uint8)(_uf);
uint8 skin       = (uint8)(_pb);
uint8 face       = (uint8)(_pb >> 8);
uint8 hairstyle  = (uint8)(_pb >> 16);
uint8 haircolor  = (uint8)(_pb >> 24);
uint8 facialhair = (uint8)(_pb2);

_cfb1 = ((0x00) | (race << 8) | (0x00 << 16) | (skin << 24));
_cfb2 = ((face) | (hairstyle << 8) | (haircolor << 16) | (facialhair << 24));

pCorpse->SetZoneId( GetZoneId() );
pCorpse->SetUInt32Value( CORPSE_FIELD_BYTES_1, _cfb1 );
pCorpse->SetUInt32Value( CORPSE_FIELD_BYTES_2, _cfb2 );
pCorpse->SetUInt32Value( CORPSE_FIELD_FLAGS, 4 );
pCorpse->SetUInt32Value( CORPSE_FIELD_DISPLAY_ID, GetUInt32Value(UNIT_FIELD_DISPLAYID) );

uint32 iDisplayID;
uint16 iIventoryType;
uint32 _cfi;
for (int i = 0; i < EQUIPMENT_SLOT_END; i++)
{
if(m_items[i])
{
iDisplayID = m_items[i]->GetProto()->DisplayInfoID;
iIventoryType = (uint16)m_items[i]->GetProto()->InventoryType;

_cfi =  (uint16(iDisplayID)) | (iIventoryType)<< 24;
pCorpse->SetUInt32Value(CORPSE_FIELD_ITEM + i,_cfi);
}
}
//save corpse in db for future use
pCorpse->SaveToDB();
Log::getSingleton( ).outError("AddObject at Player.cpp");
objmgr.AddObject(pCorpse);
}
else //Corpse already exist in world, update it
{
pCorpse->SetPosition(GetPositionX(), GetPositionY(), GetPositionZ(), GetOrientation());
}
}

void Player::SpawnCorpseBody()
{
Corpse *pCorpse;

pCorpse = objmgr.GetCorpseByOwner(this);
if(pCorpse && !pCorpse->IsInWorld())
pCorpse->PlaceOnMap();
//Deadknight:hiding every creature except spirit healers
for (Object::InRangeSet::iterator iter = GetInRangeSetBegin();
iter != GetInRangeSetEnd(); iter++)
{
Creature *creat = objmgr.GetObject<Creature>((*iter)->GetGUID());
if (creat && creat->GetUInt32Value(UNIT_FIELD_DISPLAYID) != 5233)
creat->DestroyForPlayer(this);
}
//Deadknight:hiding players except dead
for (Object::InRangeSet::iterator iter = GetInRangeSetBegin();
iter != GetInRangeSetEnd(); iter++)
{
Player *plyr = objmgr.GetObject<Player>((*iter)->GetGUID());
if (plyr && plyr->isAlive())
{
if(!plyr->IsGroupMember(this))
{
plyr->DestroyForPlayer(this);
this->DestroyForPlayer(plyr);
}
}
if (plyr && plyr->isDead())//Deadknight:if removed before add dead people
{
WorldPacket packet,packetR;
UpdateData data,dataR;
Player *plyrR=plyr;

plyr->BuildCreateUpdateBlockForPlayer( &data, this );
data.BuildPacket(&packet);
GetSession()->SendPacket( &packet );

BuildCreateUpdateBlockForPlayer( &dataR, plyrR );
dataR.BuildPacket(&packetR);
plyrR->GetSession()->SendPacket( &packetR );
}
}
}

void Player::SpawnCorpseBones()
{
Corpse *pCorpse;
pCorpse = objmgr.GetCorpseByOwner(this);
if(pCorpse)
{
pCorpse->SetUInt32Value(CORPSE_FIELD_FLAGS, 5);
pCorpse->SetUInt64Value(CORPSE_FIELD_OWNER, 0); // remove corpse owner association
//remove item association
for (int i = 0; i < EQUIPMENT_SLOT_END; i++)
{
if(pCorpse->GetUInt32Value(CORPSE_FIELD_ITEM + i))
pCorpse->SetUInt32Value(CORPSE_FIELD_ITEM + i, 0);
}
pCorpse->DeleteFromDB();
}
//Deadknight:Add creatures nearby
for (Object::InRangeSet::iterator iter = GetInRangeSetBegin();
iter != GetInRangeSetEnd(); iter++)
{
Creature *creat = objmgr.GetObject<Creature>((*iter)->GetGUID());
if (creat && creat->GetUInt32Value(UNIT_FIELD_DISPLAYID) != 5233)
{
WorldPacket packet;
UpdateData data;

creat->BuildCreateUpdateBlockForPlayer( &data, this );
data.BuildPacket(&packet);
GetSession()->SendPacket( &packet );
}
}
//Deadknight:Add players nearby
for (Object::InRangeSet::iterator iter = GetInRangeSetBegin();
iter != GetInRangeSetEnd(); iter++)
{
Player *plyr = objmgr.GetObject<Player>((*iter)->GetGUID());
if (plyr && plyr->isAlive())
{
WorldPacket packet, packetR;
UpdateData data, dataR;
Player *plyrR=plyr;

plyr->BuildCreateUpdateBlockForPlayer( &data, this );
data.BuildPacket(&packet);
GetSession()->SendPacket( &packet );

BuildCreateUpdateBlockForPlayer( &dataR, plyrR );
dataR.BuildPacket(&packetR);
plyrR->GetSession()->SendPacket( &packetR );
}
if(plyr && plyr->isDead())
{
if(!plyr->IsGroupMember(this))
{
plyr->DestroyForPlayer(this);
this->DestroyForPlayer(plyr);
}
}
}
}

void Player::DeathDurabilityLoss(double percent)
{
uint32 pDurability, pNewDurability;

for (int i = 0; i < EQUIPMENT_SLOT_END; i++)
{
if(m_items[i])
{
pDurability =  m_items[i]->GetUInt32Value(ITEM_FIELD_DURABILITY);
if(pDurability)
{
pNewDurability = (uint32)(pDurability*percent);
pNewDurability = (pDurability - pNewDurability);
if(pNewDurability < 0) { pNewDurability = 0; }

m_items[i]->SetUInt32Value(ITEM_FIELD_DURABILITY, pNewDurability);
}
}
}
}


void Player::RepopAtGraveyard()
{
float closestX = 0, closestY = 0, closestZ = 0, closestO = 0; // Make sure we dont get any random numbers, if we have no graveyard you will pop where your corpse is at (dead world).
WorldPacket data;
float curX, curY, curZ;
bool first = true;

ObjectMgr::GraveyardMap::const_iterator itr;
for (itr = objmgr.GetGraveyardListBegin(); itr != objmgr.GetGraveyardListEnd(); itr++)
{
GraveyardTeleport *pGrave = itr->second;
if(pGrave->MapId == GetMapId())
{
curX = pGrave->X;
curY = pGrave->Y;
curZ = pGrave->Z;
if( first || pow(m_positionX-curX,2) + pow(m_positionY-curY,2) <
pow(m_positionX-closestX,2) + pow(m_positionY-closestY,2) )
{
first = false;

closestX = curX;
closestY = curY;
closestZ = curZ;
closestO = pGrave->O;
}
}
}

if(closestX != 0 && closestY != 0 && closestZ != 0) {
WorldPacket data;

// Send new position to client via MSG_MOVE_TELEPORT_ACK
BuildTeleportAckMsg(&data, closestX, closestY, closestZ, 0);
GetSession()->SendPacket(&data);

// Set actual position and update in-range lists
SetPosition(closestX, closestY, closestZ, 0);

//////////////////////////////////
// Now send new position of this player to clients using MSG_MOVE_HEARTBEAT
BuildHeartBeatMsg(&data);
SendMessageToSet(&data, true);

//		SetPosition(closestX, closestY, closestZ, 0);
}

// check for nearby spirit healers, and send update
for (Object::InRangeSet::iterator iter = GetInRangeSetBegin();
iter != GetInRangeSetEnd(); iter++)
{
Creature *creat = objmgr.GetObject<Creature>((*iter)->GetGUID());
if (creat && creat->GetUInt32Value(UNIT_FIELD_DISPLAYID) == 5233)
{
WorldPacket packet;
UpdateData data;

creat->BuildCreateUpdateBlockForPlayer( &data, this );
data.BuildPacket(&packet);
GetSession()->SendPacket( &packet );
}
}
*/

float CPlayer::Distance(CCreature &Creature)
{
	float A=Creature.Data.Loc.X-Data.Loc.X;
	float B=Creature.Data.Loc.Y-Data.Loc.Y;
	float C=Creature.Data.Loc.Z-Data.Loc.Z;
	return sqrtf((A*A)+(B*B)+(C*C));
}

float CPlayer::Distance(_Location &Loc)
{
	float A=Loc.X-Data.Loc.X;
	float B=Loc.Y-Data.Loc.Y;
	float C=Loc.Z-Data.Loc.Z;
	return sqrtf((A*A)+(B*B)+(C*C));
}
void CPlayer::DuelFlee()
{
	CPacket pkg;
	if (DuelGuid != 0)
	{
		if (duelpartner != NULL)
		{	
			stopd = true;
			duelpartner->stopd = true;
			inbounds = false;
			duelpartner->inbounds = false;
			if(IsCasting)
			{
				pCurrentSpell->SpellFail(SPELL_FAIL_INVALID_TARGET);
				pCurrentSpell->Delete();
			}
			if(duelpartner->IsCasting)
			{
				duelpartner->pCurrentSpell->SpellFail(SPELL_FAIL_INVALID_TARGET);
				duelpartner->pCurrentSpell->Delete();
			}
			pkg.Reset(SMSG_CANCEL_COMBAT);
			pClient->Send(&pkg);
			duelpartner->pClient->Send(&pkg);
			Packets::AttackStop(pClient,duelpartner->guid,PLAYERGUID_HIGH);
			Packets::AttackStop(duelpartner->pClient,this->guid,PLAYERGUID_HIGH);
			duelpartner->AddUpdateVal(PLAYER_DUEL_ARBITER, 0);
			duelpartner->AddUpdateVal(PLAYER_DUEL_ARBITER+1, 0);
			duelpartner->AddUpdateVal(PLAYER_DUEL_TEAM, 0);
			duelpartner->pClient->UpdateObject();
			AddUpdateVal(PLAYER_DUEL_ARBITER, 0);
			AddUpdateVal(PLAYER_DUEL_ARBITER+1, 0);
			AddUpdateVal(PLAYER_DUEL_TEAM, 0);
			pClient->UpdateObject();
			ResetAllAuras();
			duelpartner->ResetAllAuras();
			pkg.Reset(SMSG_DUEL_WINNER);
			pkg << (unsigned char)1<<  duelpartner->Data.Name;
			pkg <<Data.Name;
			pkg << (unsigned char)0;
			pClient->SendRegion(&pkg);
			pkg.Reset(SMSG_DUEL_COMPLETE);
			pkg << (unsigned char)00;
			pClient->Send(&pkg);
			duelpartner->pClient->Send(&pkg);
			pkg.Reset(SMSG_GAMEOBJECT_DESPAWN_ANIM);
			pkg << DuelGuid << GAMEOBJECTGUID_HIGH;
			pClient->SendRegion(&pkg);
			CGameObject *pgo;
			if(DataManager.RetrieveObject((CWoWObject**)&pgo,OBJ_GAMEOBJECT,DuelGuid))
				RegionManager.ObjectRemove(*pgo);
			pkg.Reset(SMSG_DESTROY_OBJECT);
			pkg<<DuelGuid<<GAMEOBJECTGUID_HIGH;
			pClient->SendRegion(&pkg);
			Data.bDead = false;
			dead = false;
			duelstarted = false;
			duelpartner->duelstarted = false;
			duelpartner->DuelGuid = 0;
			duelpartner->duelhost = NULL;
			duelpartner->duelpartner = NULL;
			duelpartner->TargetID = 0;
			duelpartner->dueltick = 0;
			dueltick =0;
			TargetID = 0;
		}
		DuelGuid = 0;
		duelhost = NULL;
		duelpartner = NULL;
	}

}
void CPlayer::EndDuel()
{
	CPacket pkg;
	if (DuelGuid != 0)
	{
		if (duelpartner != NULL)
		{
			stopd = true;
			duelpartner->stopd = true;
			inbounds = false;
			duelpartner->inbounds = false;
			if(IsCasting)
			{
				pCurrentSpell->SpellFail(SPELL_FAIL_INVALID_TARGET);
				pCurrentSpell->Delete();
			}
			if(duelpartner->IsCasting)
			{
				duelpartner->pCurrentSpell->SpellFail(SPELL_FAIL_INVALID_TARGET);
				duelpartner->pCurrentSpell->Delete();
			}
			pkg.Reset(SMSG_CANCEL_COMBAT);
			pClient->Send(&pkg);
			duelpartner->pClient->Send(&pkg);

			Packets::AttackStop(pClient,duelpartner->guid,PLAYERGUID_HIGH);
			Packets::AttackStop(duelpartner->pClient,this->guid,PLAYERGUID_HIGH);

			duelpartner->AddUpdateVal(PLAYER_DUEL_ARBITER, 0, 0);
			duelpartner->AddUpdateVal(PLAYER_DUEL_TEAM, 0);
			duelpartner->pClient->UpdateObject(); // We'll update later
			DataObject.SetHP(1);
			AddUpdateVal(PLAYER_DUEL_ARBITER, 0, 0);
			AddUpdateVal(PLAYER_DUEL_TEAM, 0);
			pClient->UpdateObject(); // We'll update later

			ResetAllAuras();
			duelpartner->ResetAllAuras();

			pkg.Reset(SMSG_DUEL_WINNER);
			pkg << (unsigned char)0 << duelpartner->Data.Name;
			pkg << Data.Name;
			pkg << (unsigned char)0;
			pClient->SendRegion(&pkg);
			pkg.Reset(SMSG_DUEL_COMPLETE);
			pkg << (unsigned char)1;
			pClient->Send(&pkg);
			duelpartner->pClient->Send(&pkg);
			pkg.Reset(SMSG_GAMEOBJECT_DESPAWN_ANIM);
			pkg << DuelGuid << GAMEOBJECTGUID_HIGH;
			pClient->SendRegion(&pkg);
			CGameObject *pgo;
			if(DataManager.RetrieveObject((CWoWObject**)&pgo,OBJ_GAMEOBJECT,DuelGuid))
				RegionManager.ObjectRemove(*pgo);

			pkg.Reset(SMSG_DESTROY_OBJECT);
			pkg << DuelGuid << GAMEOBJECTGUID_HIGH;
			pClient->SendRegion(&pkg);
			Data.bDead = false;
			dead = false;
			duelstarted = false;
			duelpartner->duelstarted = false;
			duelpartner->DuelGuid = 0;
			duelpartner->duelhost = NULL;
			duelpartner->duelpartner = NULL;
			duelpartner->TargetID = 0;
			TargetID = 0;
			duelpartner->dueltick = 0;
			dueltick =0;
		}
		DuelGuid = 0;
		duelhost = NULL;
		duelpartner = NULL;
	}
}

void CPlayer::TakeDamage(CCreature *pCreature, unsigned long dmg, bool spelldmg)
{
	if(dmg <= 0) return;
	if(DuelGuid)
	{
		if((Data.CurrentStats.HitPoints - dmg) < 2)
		{
			DataObject.SetHP(1);
			UpdateObject();
			EndDuel();	// Send winner and complete and despawn packets
			return;
		}
	}

	DataObject.AddHP(-((long)dmg));
	if(Data.CurrentStats.HitPoints <= 0)
	{
		if(DuelGuid)
		{
			DataObject.SetHP(Data.NormalStats.HitPoints/4);
			UpdateObject();
			EndDuel();	// Send winner and complete and despawn packets
			return;
		}
		dead = true;
		ClearEvents();
	} else {
		if (IsCasting)
		{
			pCurrentSpell->SpellDelay();
		}
	}
	UpdateObject();
}
void CPlayer::ApplySpellEffect(unsigned long SpellID, unsigned long Effect){}
void CPlayer::HandleSpellEffects(CSpell *pSpell,unsigned long Effect)
{
	return;
	unsigned long SpellID = pSpell->SpellID;

	unsigned long EffectID = DBCManager.Spell.getValue(SpellID, DBC_SPELL_EFFECT(Effect));
	// DO NOT ADD SWITCH ITEMS THAT DO NOT WORK AS THIS IS IN USE NOW
	switch(EffectID)
	{
	case SPELL_EFFECT_WEAPON_DAMAGE:
		{
			//long type = DBCManager.Spell.getValue(SpellID, DBC_SPELL_ATTRIBUTE(Effect, SPELL_ATTRIB_TYPE));
			//long aura = DBCManager.Spell.getValue(SpellID, DBC_SPELL_ATTRIBUTE(Effect, SPELL_ATTRIB_AURA));
			//long power=DBCManager.Spell.getValue(SpellID, DBC_SPELL_ATTRIBUTE(Effect, SPELL_ATTRIB_POWER));
		}
		break;
	case SPELL_EFFECT_INSTAKILL:
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
						if (kill_chance == 1)
						{
							ClearEvents();
							DataObject.SetHP(0);
							UpdateObject();
						}
					}
					break;
				case 6: // target single kill
					{
						sendSpellMsg(9999, SpellID, false); // 9999 look cool but kinda useless :)

						ClearEvents();
						DataObject.SetHP(0);
						UpdateObject();
					}
					break;
					//case 15: // AOE Kill
					//	break;
				}
			}
		}
		break;

	case SPELL_EFFECT_SCHOOL_DAMAGE:
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
								DataObject.AddHP(-power);
								UpdateObject();
								if (Data.CurrentStats.HitPoints <= 0 && !dead)
								{
									dead = true;
									pClient->Echo("You have been slain by %s", ((CPlayer*)pCaster)->Data.Name);
									ClearEvents();
									long Exp = 50 * Data.Level;
									CPlayer *tPlayer = (CPlayer *)pCaster;
									if (tPlayer->Data.Level > Data.Level) {
										Exp -= (Exp * (tPlayer->Data.Level - Data.Level))/5;
										if (Exp < 0)
											Exp = 0;
									}
									if(tPlayer->pClient)
									{
										CPacket pkg;
										pkg.Reset(SMSG_LOG_XPGAIN);
										pkg << guid << PLAYERGUID_HIGH;
										pkg << (long)Exp << (char)0;
										pkg << (long)Exp << (float)1.0;
										tPlayer->pClient->Send(&pkg);
										EventManager.AddEvent(*pCaster, 0, EVENT_PLAYER_GAINEXP, &Exp, sizeof(Exp));
									}
								}
								break;

							case 3: // Damage Over Time (DoT)
								{
									long periodicity = DBCManager.Spell.getValue(SpellID, DBC_SPELL_ATTRIBUTE(Effect, SPELL_ATTRIB_PERIODICITY));
									long durationID = DBCManager.Spell.getValue(SpellID, DBC_SPELL_DURATION_ID);
									//long mintime = DBCManager.SpellDuration.getValue(durationID, DBC_SPELLDURATION_MINTIME);
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
					((CPlayer*)pCaster)->pClient->Echo("You can't attack others unless you set PvP and they are also PvP");
					((CPlayer*)pCaster)->pClient->InterruptCast(SpellID);
				}
			}
			else
			{
				DataObject.AddHP(-power);
				UpdateObject();
				if (Data.CurrentStats.HitPoints <= 0)
				{
					ClearEvents();
					dead = true;
				}
			}
		}
		break;

	case SPELL_EFFECT_TELEPORT:
		{
			long LocID = DBCManager.Spell.getValue(SpellID, 0); // Unknown loc ID yet, we just use the spell ID for now

			switch(LocID)
			{
			case 3561: // StormWind Teleport spell ID
				_Location Loc;
				Loc.X = -9115.70f;
				Loc.Y = 423.28f;
				Loc.Z = 285.10f; // I keep falling
				Packets::TeleportOrNewWorld(pClient,0,Loc);
				/*Data.Loc.X = -9115.70f;
				Data.Loc.Y = 423.28f;
				Data.Loc.Z = 285.10f; // I keep falling
				Data.Continent = 0;
				Data.Zone = 0x9;
				Data.Facing = 0.0f;//north*/
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
			//pClient->OutPacket(SMSG_NEW_WORLD,buf,0x11);
			//RegionManager.ObjectRemove(*this);
		}
		break;

	case SPELL_EFFECT_AURA:
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
							{							// and if the buff are supposed to stack
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
					case 36: // Stances/shapeshifting
						{
							pClient->Echo("Battle stance engaged!");
							DataObject.SetMorphState(UNIT_BATTLESTANCE);		// set battle stance
							/*DataObject.SetMorphState(UNIT_CATFORM);
							DataObject.SetModel(5585);*/
							UpdateObject();										// send update packet
							pClient->UpdateObject();
						}
						break;
					case 78: // Mounts!
						{
							/*pClient->Echo("Mounting you up boi!");
							if (MountedAuraSlot == 0)
							MountedAuraSlot = FindFreeAuraSlot();
							SetAura(MountedAuraSlot, SpellID, SpellID, 0, 0, 0);
							// Find mount model
							unsigned long ctid;
							ctid = DBCManager.Spell.getValue(SpellID, 103);
							unsigned long ctguid = ctid | 0x08000000;
							CCreatureTemplate *pTemplate;
							unsigned long modelid;
							if (!DataManager.RetrieveObject((CWoWObject**)&pTemplate, OBJ_CREATURETEMPLATE, ctguid))
							modelid = 2409;
							else
							modelid = pTemplate->Data.Model;

							DataObject.SetMountModel(modelid);
							UpdateObject();*/
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
									//long mintime = DBCManager.SpellDuration.getValue(durationID, DBC_SPELLDURATION_MINTIME);
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
							((CPlayer*)pCaster)->pClient->Echo("You can't attack others unless you set PvP and they are also PvP");
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
							//long durationID = DBCManager.Spell.getValue(SpellID, DBC_SPELL_DURATION_ID);
							//long mintime = DBCManager.SpellDuration.getValue(durationID, DBC_SPELLDURATION_MINTIME);
							//long maxtime = DBCManager.SpellDuration.getValue(durationID, DBC_SPELLDURATION_MAXTIME);

							switch(bufftype)
							{
							case 0: // Strengh
								break;
							case 1: // Agility
								break;
							case 2: // Stamina
								{
									/*sendSpellMsg(power, SpellID, false);
									DataObject.AddStamina(power);
									UpdateObject();
									long buff_rand = (maxtime - mintime);
									if (!buff_rand)
									buff_rand=1;
									unsigned long buff_time = mintime + (rand() % buff_rand);*/
									//EventManager.AddEvent(*this, buff_time, EVENT_PLAYER_REMOVE_AURA, &power, sizeof(power));
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

	case SPELL_EFFECT_HEAL: // heals
		{
			long power = getPower(SpellID, Effect);
			if (pCaster->type == OBJ_PLAYER)
			{
				if(Data.CurrentStats.HitPoints + power > Data.NormalStats.HitPoints)
					power = Data.NormalStats.HitPoints-Data.CurrentStats.HitPoints;
				DataObject.AddHP(power);
				UpdateObject();
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
					DataObject.AddHP(-power);
					UpdateObject();
					if (Data.CurrentStats.HitPoints <= 0 && !dead)
					{
						dead = true;
						pClient->Echo("You have been slain by %s", ((CPlayer*)pCaster)->Data.Name);
						ClearEvents();
						long Exp = 50 * Data.Level;
						CPlayer *tPlayer = (CPlayer *)pCaster;
						if (tPlayer->Data.Level > Data.Level) {
							Exp -= (Exp * (tPlayer->Data.Level - Data.Level))/5;
							if (Exp < 0)
								Exp = 0;
						}
						if(tPlayer->pClient)
						{
							CPacket pkg;
							pkg.Reset(SMSG_LOG_XPGAIN);
							pkg << guid << PLAYERGUID_HIGH;
							pkg << (long)Exp << (char)0;
							pkg << (long)Exp << (float)1.0;
							tPlayer->pClient->Send(&pkg);
							EventManager.AddEvent(*pCaster, 0, EVENT_PLAYER_GAINEXP, &Exp, sizeof(Exp));
						}
					}
				}
				else if (Effect == 1 && pCaster->type == OBJ_PLAYER)
				{
					((CPlayer*)pCaster)->pClient->Echo("You can't attack others unless you set PvP and they are also PvP");
					((CPlayer*)pCaster)->pClient->InterruptCast(SpellID);
				}
			}
			else
			{
				DataObject.AddHP(-power);
				UpdateObject();
				if (Data.CurrentStats.HitPoints <= 0)
				{
					ClearEvents();
					dead = true;
				}
			}
		}
		break;

	case SPELL_EFFECT_SUMMON_PET:
		{
			//long power = getPower(SpellID, Effect);
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
					DataObject.AddHP(-power);
					UpdateObject();
					if (Data.CurrentStats.HitPoints <= 0 && !dead)
					{
						dead = true;
						char killer[50];
						sprintf(killer, "You have been slain by %s", ((CPlayer*)pCaster)->Data.Name);
						pClient->Echo(killer);
						ClearEvents();
						long Exp = 50 * Data.Level;
						CPlayer *tPlayer = (CPlayer *)pCaster;
						if (tPlayer->Data.Level > Data.Level) {
							Exp -= (Exp * (tPlayer->Data.Level - Data.Level))/5;
							if (Exp < 0)
								Exp = 0;
						}
						if(tPlayer->pClient)
						{
							CPacket pkg;
							pkg.Reset(SMSG_LOG_XPGAIN);
							pkg << guid << PLAYERGUID_HIGH;
							pkg << (long)Exp << (char)0;
							pkg << (long)Exp << (float)1.0;
							tPlayer->pClient->Send(&pkg);
							EventManager.AddEvent(*pCaster, 0, EVENT_PLAYER_GAINEXP, &Exp, sizeof(Exp));
						}
					}
				}
				else if (Effect == 1 && pCaster->type == OBJ_PLAYER)
				{
					((CPlayer*)pCaster)->pClient->Echo("You can't attack others unless you set PvP and they are also PvP");
					((CPlayer*)pCaster)->pClient->InterruptCast(SpellID);
				}
			}
			else
			{
				DataObject.AddHP(-power);
				UpdateObject();
				if (Data.CurrentStats.HitPoints <= 0)
				{
					ClearEvents();
					dead = true;
				}
			}
		}
		break;

	case SPELL_EFFECT_INEBRIATE: //drink
		{
			long power=DBCManager.Spell.getValue(SpellID, DBC_SPELL_ATTRIBUTE(Effect, SPELL_ATTRIB_POWER));
			int State=power+Data.DrunkState;
			if(State<0) State=0;
			else if(State>255) State=255;
			DataObject.SetDrunkState(State); //get drunk
			UpdateObject();
		}
		break;

	default:
		/*
		if (Effect == 1 && pCaster->type == OBJ_PLAYER)
		((CPlayer*)pCaster)->pClient->InterruptCast(SpellID);
		*/
		break;
	}
}

void CPlayer::sendSpellMsg(long damage, unsigned long spell, bool heal)
{
	if (pCaster->type != OBJ_PLAYER)
		return;

	//int school=DBCManager.Spell.getValue(spell, 1); //1 = second column = School
	CPacket pkg;
	pkg.Reset(SMSG_SPELLNONMELEEDAMAGELOG);
	/*pkg << (unsigned char)0xFF << guid << CREATUREGUID_HIGH;  // target
	pkg << (unsigned char)0xFF << pCaster->guid << 0;  // caster*/
	Packets::PackGuid(pkg,guid,CREATUREGUID_HIGH);
	Packets::PackGuid(pkg,pCaster->guid,PLAYERGUID_HIGH);
	pkg << (long)spell;  // spell
	pkg << (long)damage;  //dmg
	pkg << (unsigned long)0x00;
	pkg << (unsigned long)0x00;
	pkg << (unsigned long)0x00;
	pkg << (unsigned long)0x00;

	if(pCaster->type == OBJ_PLAYER)
	{
		((CPlayer*)pCaster)->pClient->SendRegion(&pkg);
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
//		if (Data.Items[i]==0)
		if (Data.Items[i]==NULL)
			return i;
	}
	return -1;
}


bool CPlayer::ValidateSpell(long target, unsigned long spell)
{
#ifndef ACCOUNTLESS
	bool rv = false;

	if (pClient == NULL)
		return rv;
	if (pClient->pAccount == NULL)
		return rv;
	char UserLevel=pClient->pAccount->Data.UserLevel;
	if (UserLevel >= USER_GM)
		rv = true;
	switch(Data.Class) {
		case CLASS_WARRIOR:
			// Heroic Strike R1 and Battle Stance
			if ((spell == 78) || (spell == 2457))
				rv = true;
			break;
		case CLASS_PALADIN:
			// Seal of Righteousness and Holy Light
			if ((spell == 20154) || (spell == 635))
				rv = true;
			break;
		case CLASS_HUNTER:
			// Auto Shot and Raptor Strike
			if ((spell == 75) || (spell == 2973))
				rv = true;
			break;
		case CLASS_ROGUE:
			// Sinister Strike and Eviscerate
			if ((spell == 1752) || (spell == 2098))
				rv = true;
			break;
		case CLASS_PRIEST:
			// Lesser Heal and Smite
			if ((spell == 2050) || (spell == 585))
				rv = true;
			break;
		case CLASS_SHAMAN:
			// Lightning Bolt and Healing Wave
			if ((spell == 403) || (spell == 331))
				rv = true;
			break;
		case CLASS_MAGE:
			// Frost Armor and Fireball
			if ((spell == 168) || (spell == 133))
				rv = true;
			break;
		case CLASS_WARLOCK:
			// Immolate and Demon Skin
			if ((spell == 686) || (spell == 687))
				rv = true;
			break;
		case CLASS_DRUID:
			// Wrath and Healing Touch
			if ((spell == 5176) || (spell == 5185))
				rv = true;
			break;
	}
	return rv;
#else
	return true;
#endif // ACCOUNTLESS
}

void CPlayer::DestroyItem(int slot)
{
//	CItem *pItem = NULL;
//	if(Data.Items[slot] != 0)
	if(Data.Items[slot])
	{
//		if(DataManager.RetrieveObject((CWoWObject**)&pItem, OBJ_ITEM, Data.Items[slot]))
		if(Data.Items[slot])
		{
//			Data.Items[slot] = 0;
//			RegionManager.ObjectRemove(*pItem);
//			pItem->Delete();
			RegionManager.ObjectRemove(*Data.Items[slot]);
			Data.Items[slot]->Delete();
			Data.Items[slot] = NULL;
		}
		else // todo fix containers
//			Data.Items[slot] = 0;
			Data.Items[slot] = NULL;
	}
}

void CPlayer::AddExp(int exp)
{
	if(exp < 0)
	{
		DataObject.AddXP(exp);
		UpdateObjectOnlyMe();
	}
	else if (Data.NextLevelExp > (Data.Exp + exp) && Data.Level < 255)
	{
		DataObject.AddXP(exp);
		UpdateObjectOnlyMe();
	}
	else if (Data.Level < 255)
	{
		// Level up
		PlayerStats OldStats=Data.NormalStats;
		DataObject.SetLevel(Data.Level + 1);
		DataObject.SetXP(Data.Exp+exp-Data.NextLevelExp); // xp "overflow" to next level
		int difficulty=0;
		if(Data.Level==29) difficulty=1;
		if(Data.Level==30) difficulty=3;
		if(Data.Level==31) difficulty=6;
		if(Data.Level>=32) difficulty=5*(Data.Level-30);
		Data.NextLevelExp = (8*Data.Level+difficulty)*(45+5*Data.Level); //formula from wowwiki
		Data.NextLevelExp = ((Data.NextLevelExp+50)/100)*100; //round to nearest 100
		DataObject.SetNextLevelXP(Data.NextLevelExp);
		double GainStat[12][7]={
			{0.0,	0.0,	0.0,	0.0,	0.0,	0.0,	0.0}, //blank
			{1.64,	1.02,	1.52,	0.16,	0.66,	30.0,	0.0}, //warrior
			{1.41,	0.76,	1.25,	1.04,	0.90,	30.0,	45.0}, //paladin
			{0.59,	1.73,	1.24,	0.90,	0.78,	30.0,	45.0}, //hunter
			{1.00,	2.00,	0.790,	0.211,	0.447,	30.0,	0.0}, //rogue
			{0.21,	0.27,	0.42,	1.34,	1.42,	30.0,	35.0}, //priest
			{0.0,	0.0,	0.0,	0.0,	0.0,	0.0,	0.0}, //blank
			{1.03,	0.55,	1.10,	1.00,	1.25,	30.0,	45.0}, //shaman
			{0.17,	0.25,	0.41,	1.75,	1.75,	30.0,	45.0}, //mage
			{0.42,	0.51,	0.72,	1.34,	1.43,	30.0,	45.0}, //warlock
			{0.0,	0.0,	0.0,	0.0,	0.0,	0.0,	0.0}, //blank
			{0.75,	0.68,	0.84,	1.25,	1.42,	30.0,	45.0} //druid
		};
		if(Data.Class<=CLASS_DRUID && Data.Race<=RACE_TROLL)
		{
#define GETSTAT(index) StartRaceStats[Data.Race][index]+StartClassStats[Data.Class][index]+(long)(Data.Level*(GainStat[Data.Class][index]))
			Data.NormalStats.Strength=GETSTAT(0);
			Data.NormalStats.Agility=GETSTAT(1);
			Data.NormalStats.Stamina=GETSTAT(2);
			Data.NormalStats.Intellect=GETSTAT(3);
			Data.NormalStats.Spirit=GETSTAT(4);
#undef GETSTAT
#define GETSTAT(index) StartClassStats[Data.Class][index]+(long)(Data.Level*(GainStat[Data.Class][index]))
			Data.NormalStats.HitPoints=GETSTAT(5);
			Data.NormalStats.Mana=GETSTAT(6);
#undef GETSTAT
		}
		else return;
		DataObject.SetStrength(Data.NormalStats.Strength);
		DataObject.SetAgility(Data.NormalStats.Agility);
		DataObject.SetStamina(Data.NormalStats.Stamina);
		DataObject.SetIntellect(Data.NormalStats.Intellect);
		DataObject.SetSpirit(Data.NormalStats.Spirit);
		UpdateSkills(false);
		if(Data.Level>9)
			AddUpdateVal(PLAYER_CHARACTER_POINTS1, ((Data.Level-9)-Data.UsedTalentPoints)); // talent points
		else AddUpdateVal(PLAYER_CHARACTER_POINTS1, 0); // talent points
		UpdateObjectOnlyMe();
		DataObject.SetMaxHP((Data.NormalStats.Stamina * 10) + (Data.Level * 10));
		//DataObject.AddMaxHP((Data.NormalStats.Stamina * 2) + (Data.Level * 10));
		DataObject.SetHP(Data.NormalStats.HitPoints);
		DataObject.SetMaxMana((Data.NormalStats.Intellect * 15) + (Data.Level * 7));
		//DataObject.AddMaxMana((Data.NormalStats.Intellect * 1) + (Data.Level * 7));
		DataObject.SetMana(Data.NormalStats.Mana);

		DataObject.SetMinDamage(Data.DamageMin);
		DataObject.SetMaxDamage(Data.DamageMax);
		AddUpdateVal(UNIT_FIELD_ATTACKPOWER,(unsigned long)AttackPower());

		DataObject.SetRangedMinDamage(Data.RangedDamageMin);
		DataObject.SetRangedMaxDamage(Data.RangedDamageMax);
		AddUpdateVal(UNIT_FIELD_RANGEDATTACKPOWER,(unsigned long)RangedAttackPower());

		UpdateObject();
		CPacket pkg;
		pkg.Reset(SMSG_LEVELUP_INFO);
		pkg << (unsigned long)Data.Level;
		pkg << (unsigned long)(Data.NormalStats.HitPoints-OldStats.HitPoints);
		pkg << (unsigned long)(Data.NormalStats.Mana-OldStats.Mana);
		pkg << (unsigned long)0 << (unsigned long)0 << (unsigned long)0 << (unsigned long)0;
		pkg << (unsigned long)(Data.NormalStats.Strength-OldStats.Strength);
		pkg << (unsigned long)(Data.NormalStats.Agility-OldStats.Agility);
		pkg << (unsigned long)(Data.NormalStats.Stamina-OldStats.Stamina);
		pkg << (unsigned long)(Data.NormalStats.Intellect-OldStats.Intellect);
		pkg << (unsigned long)(Data.NormalStats.Spirit-OldStats.Spirit);
		pClient->Send(&pkg);
		//pClient->Echo("You gain a Level! Your new Level is %d!", Data.Level);
	}
	else Data.Exp=0;
}

bool CPlayer::Save(FILE *fout)
{
	long size = sizeof(PlayerData);
	fwrite(&Data, size, 1, fout); // todo Data.Items and Data.BagItems dont have to save

	for (int i = 0 ; i < 120 ; i++)
	{
/*
		if (unsigned long ItemID=Data.Items[i])
		{
			CItem *pItem=0;
			if (DataManager.RetrieveObject((CWoWObject**)&pItem,OBJ_ITEM,ItemID))
			{
				if (!pItem->Save(fout))
					return false;
			}
		}*/
		if (CItem *pItem=Data.Items[i]){
			if (!pItem->Save(fout))
				return false;
		}

	}
	for (int i = 0 ; i < 120 ; i++)
	{
/*
		if (unsigned long ItemID=Data.BagItems[i])
		{
			CItem *pItem=0;
			if (DataManager.RetrieveObject((CWoWObject**)&pItem,OBJ_ITEM,ItemID))
			{
				if (!pItem->Save(fout))
					return false;
			}
		}*/
		if (CItem *pItem=Data.BagItems[i]){
			if (!pItem->Save(fout))
				return false;
		}
	}
	for(int l=0;l<20;l++)
	{
		unsigned long Bagguid=Data.Bags[l];
		if (Bagguid)
		{
			// Save bag
			CBag *bag=0;
			if(DataManager.RetrieveObject((CWoWObject**)&bag,OBJ_CONTAINER,Bagguid))
			{
				// Yeay!
				if(!bag->Save(fout))
					return false;
			}
		}
	}
	return true;
}

void CPlayer::DeathDurabilityLoss()
{
	return;	// this is causing some WEIRD side-effects.
//	CItem *pItem;
	for(int i=0;i<SLOT_TABARD;i++)
	{
//		if(DataManager.RetrieveObject((CWoWObject**)&pItem, pClient->pPlayer->Data.Items[i])) //add res of dest item
		if(CItem *pItem = pClient->pPlayer->Data.Items[i]) //add res of dest item
		{
			// Lose 10% durability!
			pItem->ReduceItemDurabilityByPercent((float)DURABILITY_LOSS_DEATH);
			pClient->UpdateKnownItem(*pItem);
		}
	}
	pClient->Echo("You died. Because of this all of your equipped items have suffered a 10 percent durability loss.");
}

bool CPlayer::Load(FILE *fin, unsigned long guid, bool createflag)
{
	long size = sizeof(PlayerData);
	char *buffer = (char*)malloc(size);
	if(buffer == NULL)
	{
		return false;
	}
	if (fread(buffer, size, 1, fin) != 1) {
		return false;
	}
	PlayerData *inData = (PlayerData *)buffer;

	//Clear();
	//CWoWObject::New(); No more guid reshuffling!
	CWoWObject::guid=guid;
	DataManager.SetNextIDIfGreater(guid,OBJ_PLAYER);
	dead = false;
	armor_buff = false;

	memcpy(&Data,inData,sizeof(PlayerData));
	for (int i = 0 ; i < 120 ; i++)
	{
		if (Data.Items[i])
		{
			CItem *pItem = new CItem();
			pItem->Data.Owner = guid;
			if (!pItem->Load(fin,createflag))
				return false;

//			Data.Items[i] = pItem->guid;
			Data.Items[i] = pItem;
			if (i == SLOT_MAINHAND) {
				if(pItem->pTemplateData) {
					DataObject.SetMinDamage(pItem->pTemplateData->DamageStats[0].Min);
					DataObject.SetMaxDamage(pItem->pTemplateData->DamageStats[0].Max);
					DataObject.SetAttackSpeed(pItem->pTemplateData->WeaponSpeed);
				}
			}
		}
	}
	for (int i = 0 ; i < 120 ; i++)
	{
		if (Data.BagItems[i])
		{
			CItem *pItem = new CItem();
			pItem->Data.Owner = guid;
			if (!pItem->Load(fin,createflag))
				return false;
			//DataManager.NewObject(*pItem);
//			Data.BagItems[i] = pItem->guid;
			Data.BagItems[i] = pItem;
		}
	}

	for(int l=0;l<20;l++)
	{
		unsigned long Bagguid=Data.Bags[l];
		if (Bagguid)
		{
			// Load bag
			CBag *bag;
			bag = new CBag;
			if(!bag->Load(fin,createflag))
				return false;
			Data.Bags[l] = bag->guid;
		}
	}
	if (createflag) {
		DataManager.NewObject(*this);
		string LowerName=Data.Name;
		MakeLower(LowerName);
		DataManager.PlayerNames[LowerName]=guid;
	}
	// all players must begin rest phase on load.
	EventsEligible=true;
	unsigned long time_to_rest=1000*6*48; //4.8 minutes
	if(!(Data.StatusFlags & STATUS_ZZZZ))
		time_to_rest<<=2;// *4 (4x slower resting in wilderness)
	EventManager.AddEvent(*this,time_to_rest,EVENT_PLAYER_REST,&time_to_rest,sizeof(time_to_rest));
	free(buffer);
	return true;
}

void CPlayer::SetSpeed(float speed) {
	Data.runspeed = speed;
	CPacket pkg(SMSG_FORCE_RUN_SPEED_CHANGE);
	//pkg << (unsigned char)0xFF << guid << PLAYERGUID_HIGH;
	Packets::PackGuid(pkg,guid,PLAYERGUID_HIGH);
	pkg << speed;
	pClient->SendRegion(&pkg);
}
void CPlayer::SetSwimSpeed(float speed) {
	Data.swimspeed = speed;
	CPacket pkg(SMSG_FORCE_SWIM_SPEED_CHANGE);
	//pkg << (unsigned char)0xFF << guid << PLAYERGUID_HIGH;
	Packets::PackGuid(pkg,guid,PLAYERGUID_HIGH);
	pkg << speed;
	pClient->SendRegion(&pkg);
}

unsigned long CPlayer::AttackPower(void)
{
	switch(Data.Class)
	{
	case CLASS_WARRIOR:
	case CLASS_PALADIN:
		return Data.Level*3 + Data.CurrentStats.Strength*2 - 20;
	case CLASS_ROGUE:
	case CLASS_HUNTER:
		return Data.Level*2 + Data.CurrentStats.Strength + Data.CurrentStats.Agility - 20;
	case CLASS_SHAMAN:
		return Data.Level*2 + Data.CurrentStats.Strength*2 - 20;
	case CLASS_DRUID:
		/* For when forms are done
		# + Character Level * 3 (in Bear Form)
		# + Character Level * 2 + Agility (in Cat Form)
		*/
		return Data.CurrentStats.Strength*2 - 20;
	case CLASS_MAGE:
	case CLASS_PRIEST:
	case CLASS_WARLOCK:
		return Data.CurrentStats.Strength - 10;
	default:
		return 0;
	}
}

unsigned long CPlayer::RangedAttackPower(void)
{
	switch(Data.Class)
	{
	case CLASS_WARRIOR:
	case CLASS_ROGUE:
		return Data.Level + Data.CurrentStats.Agility*2 - 20;
	case CLASS_HUNTER:
		return Data.Level*2 + Data.CurrentStats.Agility*2 - 20;
	default:
		return 0;
	}
}

bool CPlayer::IsFacing(CCreature *pCreature)
{
	float x1;
	float x2;
	float y1;
	float y2;

	x1 = Data.Loc.X;
	y1 = Data.Loc.Y;
	x2 = pCreature->Data.Loc.X;
	y2 = pCreature->Data.Loc.Y;
	//Data.Facing *always* in 0 - 360 degree range (0 to 2 pi)
	float angle = (float)atan2 (y2 - y1, x2 - x1);
	float deviation=float(1.3962634016); //80 degrees
	if(angle < (-deviation)) angle += float(6.28318530718); //360 degrees
	//at the end of all this, the angle is in the range -deviation to (360-deviation), and the deviation will push this to 0-360.
	if((Data.Facing < angle+deviation) && (Data.Facing > angle-deviation)) return true;
	return false;
}

void CPlayer::CheckForSkillUpdate(bool fromvictim)
{
//	CItem *pItem;
	unsigned long skillid;
	unsigned long i;
	bool increaseskill;


	if (fromvictim)
	{
		LevelUpSkillInCombat(95); //defense
		return;
	}

	for(i=SLOT_MAINHAND;i<=SLOT_RANGED;i++)
	{
		// check skill
//		if (DataManager.RetrieveObject((CWoWObject**)&pItem,OBJ_ITEM,Data.Items[i]))
		if (CItem *pItem = Data.Items[i])
		{
			skillid = GetWeaponSkill(pItem);
			if (skillid > 0)
			{
				increaseskill = true;
				// now formula to check if it should update
				// try maybe testing for what weapons was used?
				if (increaseskill)
					LevelUpSkillInCombat(skillid);
			}
		}
	}
	return;
}

void CPlayer::SetAura(unsigned long slot, unsigned long auraid, unsigned long spellid, unsigned long application, unsigned long flags, unsigned long state)
{
	AddUpdateVal(UNIT_FIELD_AURA+slot, auraid );
	Field_Aura[slot] = auraid;
	unsigned long flagslot = slot >> 3;
	unsigned long value = Field_AuraFlags[flagslot];
	value |= 0xFFFFFFFF & (9 << ((slot & 7) << 2));
	AddUpdateVal(UNIT_FIELD_AURAFLAGS + flagslot, value);
	Field_AuraFlags[flagslot] = value;
	UpdateObject();
	CPacket pkg;
	pkg.Reset(SMSG_UPDATE_AURA_DURATION);
	pkg << (unsigned char)slot;
	pkg << (unsigned long)application;	// duration
	pClient->Send(&pkg);
}

void CPlayer::RemoveAura(unsigned long slot)
{
	RemoveModifier(Field_Aura[slot]);
	AddUpdateVal(UNIT_FIELD_AURA + slot, 0);
	Field_Aura[slot] = 0xFFFFFFFF;
	unsigned char flagslot = slot >> 3; // get high bits
	unsigned long value = Field_AuraFlags[flagslot];
	value &= 0xFFFFFFFF ^ (0xF << ((slot & 7) << 2));
	AddUpdateVal(UNIT_FIELD_AURAFLAGS + flagslot, value);
	Field_AuraFlags[flagslot] = value;
	UpdateObject();
	for(int i=0;i<64;i++)
	{
		if(avent[i])
		{
			if(avent[i]->Slot == slot)
			{
				avent[i]->ClearEvents();
				delete avent[i];
				avent[i]=NULL;
				return;
			}
		}
	}
}
void CPlayer::InitAEvents()
{
	for(int i=0;i<64;i++)
	{
		avent[i]=NULL;
	}
}
unsigned long CPlayer::FindFreeAuraSlot(bool positive)
{
	int i;
	if(positive)
	{
		for(i=0;i<32;i++)
		{
			if (Field_Aura[i] == 0xFFFFFFFF)
				return i;
		}
	}
	else
	{
		for(i=32;i<64;i++)
		{
			if (Field_Aura[i] == 0xFFFFFFFF)
				return i;
		}
	}
	return 0;
}

void CPlayer::ResetAllAuras()
{
	for(int l=0;l<64;l++)
		Field_Aura[l] = 0xFFFFFFFF;
	for(int l=0;l<8;l++)
	{
		Field_AuraFlags[l] = 0;
		Field_AuraLevels[l] = 0;
	}
	for(int l=0;l<16;l++)
		Field_AuraApplications[l] = 0;
	Field_AuraState = 0;
	for(int l=0;l<5;l++)
	{
		RestoreAuras[l].SpellID = 0;
		RestoreAuras[l].PerTick = 0;
		RestoreAuras[l].RemainingTicks = 0;
		RestoreAuras[l].Type = 0;
		RestoreAuras[l].FrequencyID = 0;
	}
	abonus.Ag=abonus.Int=abonus.Spi=abonus.Sta=abonus.Str=abonus.ArcaneRes=abonus.Armor=abonus.FireRes=abonus.FrostRes=abonus.NatureRes=abonus.ShadowRes=0;
	aminus.Ag=aminus.Int=aminus.Spi=aminus.Sta=aminus.Str=aminus.ArcaneRes=aminus.Armor=aminus.FireRes=aminus.FrostRes=aminus.NatureRes=aminus.ShadowRes=0;
	for(int i=0;i<64;i++)
	{
		Modifiers[i].Effect=0;
		Modifiers[i].ModID=0;
		Modifiers[i].pCaster=NULL;
		Modifiers[i].power=0;
		Modifiers[i].pTarget=NULL;
		Modifiers[i].SlotID=0;
		Modifiers[i].SpellID=0;
		Modifiers[i].time=0;
		Modifiers[i].type=0;
		Modifiers[i].Applied = false;
	}
}

unsigned long CPlayer::GetWeaponSkill(CItem *pItem)
{
	switch(pItem->pTemplateData->Class)
	{
	case ITEM_CLASS_WEAPON:
		{
			switch(pItem->pTemplateData->SubClass)
			{
			case ITEM_SUBCLASS_WEAPON_AXE: return 44;
			case ITEM_SUBCLASS_WEAPON_AXE2: return 172;
			case ITEM_SUBCLASS_WEAPON_BOW: return 45;
			case ITEM_SUBCLASS_WEAPON_GUN: return 46;
			case ITEM_SUBCLASS_WEAPON_MACE: return 54;
			case ITEM_SUBCLASS_WEAPON_MACE2: return 160;
			case ITEM_SUBCLASS_WEAPON_POLEARM: return 229;
			case ITEM_SUBCLASS_WEAPON_SWORD: return 43;
			case ITEM_SUBCLASS_WEAPON_SWORD2: return 55;
			case ITEM_SUBCLASS_WEAPON_STAFF: return 136;
			case ITEM_SUBCLASS_WEAPON_DAGGER: return 173;
			case ITEM_SUBCLASS_WEAPON_THROWN: return 176;
			case ITEM_SUBCLASS_WEAPON_SPEAR: return 227;
			case ITEM_SUBCLASS_WEAPON_CROSSBOW: return 226;
			case ITEM_SUBCLASS_WEAPON_WAND: return 228;
			default: return 0;
			}
		}
	case ITEM_CLASS_ARMOR:
		{
			switch(pItem->pTemplateData->SubClass)
			{
			case ITEM_SUBCLASS_ARMOR_CLOTH: return 415;
			case ITEM_SUBCLASS_ARMOR_LEATHER: return 414;
			case ITEM_SUBCLASS_ARMOR_MAIL: return 413;
			case ITEM_SUBCLASS_ARMOR_PLATE: return 293;
			case ITEM_SUBCLASS_ARMOR_SHIELD: return 433;
			default: return 0;
			}
		}
	}

	return 0;
	switch(pItem->pTemplateData->Class)
	{
	case ITEM_CLASS_WEAPON:
		{
			switch(pItem->pTemplateData->SubClass)
			{
			case ITEM_SUBCLASS_WEAPON_AXE: return 44;
			case ITEM_SUBCLASS_WEAPON_AXE2: return 172;
			case ITEM_SUBCLASS_WEAPON_BOW: return 45;
			case ITEM_SUBCLASS_WEAPON_GUN: return 46;
			case ITEM_SUBCLASS_WEAPON_MACE: return 54;
			case ITEM_SUBCLASS_WEAPON_MACE2: return 160;
			case ITEM_SUBCLASS_WEAPON_POLEARM: return 229;
			case ITEM_SUBCLASS_WEAPON_SWORD: return 43;
			case ITEM_SUBCLASS_WEAPON_SWORD2: return 55;
			case ITEM_SUBCLASS_WEAPON_STAFF: return 136;
			case ITEM_SUBCLASS_WEAPON_DAGGER: return 173;
			case ITEM_SUBCLASS_WEAPON_THROWN: return 176;
			case ITEM_SUBCLASS_WEAPON_SPEAR: return 227;
			case ITEM_SUBCLASS_WEAPON_CROSSBOW: return 226;
			case ITEM_SUBCLASS_WEAPON_WAND: return 228;
			default: return 0;
			}
		}
	case ITEM_CLASS_ARMOR:
		{
			switch(pItem->pTemplateData->SubClass)
			{
			case ITEM_SUBCLASS_ARMOR_CLOTH: return 415;
			case ITEM_SUBCLASS_ARMOR_LEATHER: return 414;
			case ITEM_SUBCLASS_ARMOR_MAIL: return 413;
			case ITEM_SUBCLASS_ARMOR_PLATE: return 293;
			case ITEM_SUBCLASS_ARMOR_SHIELD: return 433;
			default: return 0;
			}
		}
	}
	return 0;
}

void CPlayer::CheckForNewArea()
{
	if (bIsFlying) return; // can't explore if you're flying on a taxi
	for(std::list<ExplorationArea>::iterator itr = ExploreAreas.begin(); itr != ExploreAreas.end(); ++itr)
	{
		if( Data.Loc.X <= itr->x1 && Data.Loc.X >= itr->x2 && Data.Loc.Y <= itr->y1 && Data.Loc.Y >= itr->y2)
		{
			//Discover a new area!
			int offset = itr->areaFlag / 32;
			unsigned long val = (unsigned long)(1 << (itr->areaFlag % 32));
			unsigned long currfields = Data.ExploredZones[offset];
			if( !(currfields & val) )
			{
				Data.ExploredZones[offset] = (unsigned long)(currfields | val);
				AddUpdateVal(PLAYER_EXPLORED_ZONES_1 + offset, Data.ExploredZones[offset]);
				if(DBCManager.AreaTable.getValue(itr->areaID,10)>0)
				{
					CPacket pkg;
					pkg.Reset(SMSG_EXPLORATION_EXPERIENCE);
					pkg << (unsigned long)itr->areaID;
					pkg << (unsigned long)Data.Level*10+45;	// Exploration XP
					// DataObject.AddXP(Data.Level*10+45);
					pClient->UpdateObject();
					pClient->Send(&pkg);
					unsigned long newxp = Data.Level*10+45;
					GameMechanics::GiveXP(this,newxp);
					return;
				}
				else return;
			}
		}
	}
}

void CPlayer::LoadExploreSystem(void)
{
	ExplorationArea newarea;
	ExploreAreas.clear();
	unsigned long areaid;
	unsigned long overlayid;

	for(unsigned long i=0;i<(unsigned long)DBCManager.WorldMapOverlay.rowcount();i++)
	{
		areaid = DBCManager.WorldMapOverlay.getIntValueNoKey(i, 2);
		overlayid = DBCManager.WorldMapOverlay.getIntValueNoKey(i, 0);

		if (overlayid)
		{
			WorldMapOverlayEntry overlay;
			AreaTableEntry area;
			WorldMapArea zone;

			DBCManager.WorldMapOverlay.fetchRow(overlayid, &overlay);
			DBCManager.AreaTable.fetchRow(areaid, &area);
			DBCManager.WorldMapArea.fetchRow(overlay.worldMapAreaID, &zone);
			if(zone.zoneId != Data.Zone||area.ukn7<=0) continue;
			newarea.areaID = area.ID;
			newarea.areaFlag = area.exploreFlag;

			//TODO: I am not sure about this formula, but is something near it.
			float ry = fabs((zone.y2 - zone.y1)/1000); //originally 1024
			float rx = fabs((zone.x2 - zone.x1)/660);  // originally 768

			newarea.x2 = zone.x1 - (overlay.drawX * rx);
			newarea.y2 = zone.y1 - (overlay.drawY * ry);
			newarea.x1 = newarea.x2 + ((overlay.areaH/2)*rx);
			newarea.y1 = newarea.y2 + ((overlay.areaW/2)*ry);

			ExploreAreas.push_back(newarea);
		}
	}
	CheckForNewArea();
}

void CPlayer::RecomputeAllStats(void)
{
//	CItem *pItem;
	PlayerStats NewStats;
	NewStats=Data.NormalStats;
	NewStats.HitPoints=Data.NormalStats.Stamina*10 + Data.Level*10;
	NewStats.Mana=Data.NormalStats.Intellect*15 + Data.Level*7;

	for(int i=0;i<SLOT_TABARD;i++)
	{
//		if(DataManager.RetrieveObject((CWoWObject**)&pItem, pClient->pPlayer->Data.Items[i])) //add res of dest item
		if(CItem *pItem = pClient->pPlayer->Data.Items[i]) //add res of dest item
		{
			if(pItem->Data.Durability != 0)	// no durability, therefore no effect!
			{
				if(pItem->pTemplateData)
				{
					NewStats.Armor+=pItem->pTemplateData->Resistances.Physical;
					NewStats.ResistFire+=pItem->pTemplateData->Resistances.Fire;
					NewStats.ResistNature+=pItem->pTemplateData->Resistances.Nature;
					NewStats.ResistFrost+=pItem->pTemplateData->Resistances.Frost;
					NewStats.ResistShadow+=pItem->pTemplateData->Resistances.Shadow;
					NewStats.Block+=pItem->pTemplateData->Block;
					for(int attrib=0;attrib<10;attrib++)
					{
						if(!pItem->pTemplateData->Attributes[attrib].ID) break;
						long Value=pItem->pTemplateData->Attributes[attrib].Value;
						switch(pItem->pTemplateData->Attributes[attrib].ID)
						{
						case ATTR_HEALTH:
							NewStats.HitPoints+=Value;
							break;
						case ATTR_AGILITY:
							NewStats.Agility+=Value;
							break;
						case ATTR_STRENGTH:
							NewStats.Strength+=Value;
							break;
						case ATTR_INTELLECT:
							NewStats.Intellect+=Value;
							NewStats.Mana+=Value*10;
							break;
						case ATTR_SPIRIT:
							NewStats.Spirit+=Value;
							break;
						case ATTR_STAMINA:
							NewStats.Stamina+=Value;
							NewStats.HitPoints+=Value*10;
							break;
						}
					}
				}
			}
		}
	}
	DataObject.SetArmor(NewStats.Armor);
	DataObject.SetFireRes(NewStats.ResistFire);
	DataObject.SetNatureRes(NewStats.ResistNature);
	DataObject.SetFrostRes(NewStats.ResistFrost);
	DataObject.SetShadowRes(NewStats.ResistShadow);

	DataObject.SetStrength(NewStats.Strength);
	DataObject.SetAgility(NewStats.Agility);
	DataObject.SetStamina(NewStats.Stamina);
	DataObject.SetIntellect(NewStats.Intellect);
	DataObject.SetSpirit(NewStats.Spirit);
	DataObject.SetHP(NewStats.HitPoints);
	DataObject.SetMaxHP(NewStats.HitPoints);

	long *NewAttribs,*OldAttribs;
	NewAttribs=&NewStats.Strength;
	OldAttribs=&Data.NormalStats.Strength;
	long diff;
#define ADDPOSNEGSTAT(index) diff=NewAttribs[index] - OldAttribs[index];\
	if(diff > 0)\
	{\
	AddUpdateVal(PLAYER_FIELD_POSSTAT0+index,diff);\
	AddUpdateVal(PLAYER_FIELD_NEGSTAT0+index,0);\
	}\
	else if(diff < 0)\
	{\
	AddUpdateVal(PLAYER_FIELD_POSSTAT0+index,0);\
	AddUpdateVal(PLAYER_FIELD_NEGSTAT0+index,diff);\
	}\
	else\
	{\
	AddUpdateVal(PLAYER_FIELD_POSSTAT0+index,0);\
	AddUpdateVal(PLAYER_FIELD_NEGSTAT0+index,0);\
	}
	ADDPOSNEGSTAT(0);
	ADDPOSNEGSTAT(1);
	ADDPOSNEGSTAT(2);
	ADDPOSNEGSTAT(3);
	ADDPOSNEGSTAT(4);
#undef ADDPOSNEGSTAT
}

unsigned long CPlayer::AddSetItem(CItemTemplate *pTemplate, unsigned int count)
{
	if (pTemplate->Data.Stackable > 1)//try stock
	{
		count = AddItem(pTemplate->Data, count);
	}
	if (count)
	{
		CItem *pItem = new CItem;
		pItem->New(pTemplate, pClient->pPlayer->guid);
		DataManager.NewObject(*pItem);
		pItem->CreateBag();
		pItem->Data.Count = count;
		int newSlot=pClient->pPlayer->GetOpenBackpackSlot();
		if(newSlot == -1)
		{
			SendInventoryFailure(pClient, BAG_FULL, pItem->guid, 0, 0, 0);
			return count;
		}
		pClient->AddKnownItem(*pItem);
		pClient->pDataObject->SetItem(newSlot, pItem);
	}
	return 0;
}

unsigned int CPlayer::AddItem(ItemTemplateData &pItemTemplateData, unsigned int count)
{
	const unsigned int MaxStack = pItemTemplateData.Stackable;
	for (int i = SLOT_INBACKPACK ; i < SLOT_INBACKPACK+16 ; i++)
	{
		if (Data.Items[i] && Data.Items[i]->pTemplateData->ItemID == pItemTemplateData.ItemID)
		{
			if(Data.Items[i]->Data.Count < MaxStack)
			{
				unsigned long ItemGuid = Data.Items[i] ? Data.Items[i]->guid : 0;
				unsigned int addedCount = min(count, MaxStack - Data.Items[i]->Data.Count);
				Data.Items[i]->SetItemCount(addedCount + Data.Items[i]->Data.Count);
				Data.Items[i]->UpdateItem(Data.Items[i]->guid, this);
				count -= addedCount;
				if (count == 0) return 0;
			}
		}
	}
	return count;
}
