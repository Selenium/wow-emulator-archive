#include "Creature.h"
#include "Globals.h"
#include "UpdateBlock.h"
#include "Party.h"
#include "Spell.h"
#include "Packets.h"
#include "GameMechanics.h"
#include "MsgHandlers.h"
#include "DataManager.h"
#include "Quest.h"
#include "Player.h"
#include "QuestFunctions.h"
#include "dbc_structs.h"

CCreature::CCreature(void):CWoWObject(OBJ_CREATURE), CUpdateObject(UNIT_END)
{
	DataObject.pObject = this;
	pTemplate=NULL;
	bIsTaxi=false;
	bIsSummon = false;
	PetAction1 = 0;
	PetAction2 = 0;
	PetAction3 = 0;
	ResetAllAuras();
	InitAEvents();
}

CCreature::~CCreature(void)
{
	//	RegionManager.ObjectRemove(*this);
	CCreature::Delete();
}

void CCreature::Clear()
{
	CWoWObject::Clear();
	pTemplate=NULL;
	TargetID=0;
	memset(&Data,0,sizeof(CreatureData));
	bMoving = false;
	bAttacking = false;
	bLooted = false;
	bIsSummon = false;
	dead = false;
	LootedItems.clear();
	memset(&XP,0,sizeof(XP));
	CurrentPoint = 0;
}

void CCreature::Delete()
{
	RegionManager.ObjectRemove(*this);
	LootedItems.clear();
	CWoWObject::Delete();
}

void CCreature::New(unsigned long nTemplate)
{
	Clear();
	CWoWObject::New();
	Data.Template=nTemplate;
	//	Data.Size=1.0f;
	EventsEligible=true;
	bIsSummon = false;
}

void CCreature::New(CCreatureTemplate &NewTemplate)
{
	Clear();
	CWoWObject::New();
	EventsEligible=true;
	Data.Template=NewTemplate.guid;
	pTemplate=&NewTemplate;
	//	Data.Size=NewTemplate.Data.Size;
	//	Data.NormalStats=NewTemplate.Data.NormalStats;
	Data.CurrentStats=NewTemplate.Data.NormalStats;
	//	strcpy(Data.Name,NewTemplate.Data.Name);
	/*	Data.DamageMax=NewTemplate.Data.DamageMax;
	Data.DamageMin=NewTemplate.Data.DamageMin;
	Data.Model=NewTemplate.Data.Model;
	Data.Level=NewTemplate.Data.Level;
	Data.Exp=NewTemplate.Data.Exp;
	Data.RegenPeriodicity=NewTemplate.Data.RegenPeriodicity;
	Data.RegenPerTick=NewTemplate.Data.RegenPerTick;
	Data.NPCType = 0;
	Data.FactionTemplate = 0x1F;*/
	// set up lootable items (TEMPLATES UNTIL LOOTED)
	// Sort out gossip menus
	/*		if(pTemplate->Data.NPCFlags == 16388)		// Repairer/armorer
	{
	block.Add(UNIT_NPC_FLAGS,16388);
	return block.GetSize() + c;
	}

	*/	
	Target = NULL;
	DefaultGossip = GOSSIPTYPE_NONE;
	AI_Tagger =0;
	AIState=0;
	TimeToMove=0;
	TimeMoved=0;
	bIsSummon = false;
	bAttacking =false;
	bMoving = false;
	bIsInCombat=false;
	dead=false;
	FirstWander = true;
	InitGossip();
}

void CCreature::InitGossip() {
	if(!pTemplate) return;
	if(bIsTaxi)	// taxi
	{
		DefaultGossip = GOSSIPTYPE_TAXI;
		GossipMenuItems.push_back(GOSSIPTYPE_TAXI);
	}

	if(!strnicmp(pTemplate->Data.Guild,"Innkeeper",9) || !strnicmp(pTemplate->Data.Name,"Innkeeper",9))
		GossipMenuItems.push_back(GOSSIPTYPE_BINDER);

	if(DataManager.TrainerTemplates[Data.Template].size() > 0)
	{
		DefaultGossip = GOSSIPTYPE_TRAIN;
		GossipMenuItems.push_back(GOSSIPTYPE_TRAIN);
	}

	if (DataManager.SellTemplates[Data.Template].size() > 0)
	{
		DefaultGossip = GOSSIPTYPE_TRADE;
		GossipMenuItems.push_back(GOSSIPTYPE_TRADE);
	}

	if (DataManager.CreatureQuestRelation[Data.Template].size() > 0 || DataManager.CreatureInvolvedRelation[Data.Template].size() > 0)
	{
		DefaultGossip = GOSSIPTYPE_QUEST;
		//GossipMenuItems.push_back(GOSSIPTYPE_QUEST);
	}
	if(!strncmp(pTemplate->Data.Guild,"Guild Master",12))
	{
		DefaultGossip = GOSSIPTYPE_GUILD;
		GossipMenuItems.push_back(GOSSIPTYPE_TABARD);
		GossipMenuItems.push_back(GOSSIPTYPE_GUILD);
	}
	if(!strncmp(pTemplate->Data.Guild,"Tabard",6))
	{
		DefaultGossip = GOSSIPTYPE_TABARD;
		GossipMenuItems.push_back(GOSSIPTYPE_TABARD);
	}
}

long CCreature::GetHitListGuid() {
	int hitlist = 0;
	for (int i = 1 ; i < 10 ; i++)
	{
		if((XP[hitlist].hitguid>0)&&(XP[i].hitguid>0))
		{
			if (XP[hitlist].dmg < XP[i].dmg)
			{
				hitlist = i;
			}
		}
		else break;
	}
	return XP[hitlist].hitguid;
}

void CCreature::AddToHitList(CWoWObject *pObject, int dmg) {
	// TODO: FIX THIS

	int hitlist = 0;
	for (int i = 0 ; i < 10 ; i++)
	{
		if (XP[i].hitguid == 0) {
			hitlist = i;
			if(pObject->type == OBJ_PLAYER)
			{
				if (((CPlayer*)pObject)->Data.PartyID != 0)
				{
					XP[hitlist].hitguid = ((CPlayer*)pObject)->Data.PartyID;
				} else {
					XP[hitlist].hitguid = pObject->guid;
				}
			} else {
				XP[hitlist].hitguid = pObject->guid;
			}
			break;
		}
		if (pObject->type == OBJ_PLAYER)
		{
			if(XP[i].hitguid == ((CPlayer*)pObject)->Data.PartyID)
			{
				hitlist = i;
				break;
			} else if(XP[i].hitguid == pObject->guid)
			{
				hitlist = i;
				break;
			}
		} else {
			if (XP[i].hitguid == pObject->guid)
			{
				hitlist = i;
				break;
			}
		}
	}
	XP[hitlist].dmg += dmg;
}

unsigned long CCreature::GetCreatureInfoData(char *buffer, bool Create)
{
#define Add(datatype,data) *(datatype*)&buffer[c]=data;c+=sizeof(datatype);
#define Skip(n) c+=n;
#define Fill(size,value) memset(&buffer[c],value,size);c+=size;
	int c=0;
	// 0x70, 0x800000
	Skip(Packets::PackGuidBuffer(buffer,guid,CREATUREGUID_HIGH));
	if (Create)
	{
		Add(unsigned char, ID_UNIT);
		Add(unsigned char, (TBC?0x78:0x70));

		Add(unsigned long, (TBC?0:0x800000));
		Add(unsigned long, 0xB5771D7F);
		Add(_Location, Data.Loc);
		Add(float, Data.Facing);
		Add(float, 0);
		Add(float,2.5f); //walk
		Add(float,6.0f); //run // 8.0
		Add(float,4.5f); //backswim // 8.0
		Add(float,4.7222223f); //swim
#if TBC
		Add(float,2.0f);
		Add(float,7.0f);
		Add(float,4.5f);
#else
		Add(float,4.7222223f); //backwalk
#endif
		Add(float,3.141593f); //turn
		unsigned long flags2 = 0x800000;
		unsigned char poscount = 0;

		if(flags2 & 0x400000){
			Add(unsigned long, 0x0);
			Add(unsigned long, 0x659);
			Add(unsigned long, 0xB7B);
			Add(unsigned long, 0xFDA0B4);
			Add(unsigned long, poscount);
			for(int i=0;i<poscount+1;i++){
				Add(float,0);
				Add(float,0);
				Add(float,0);
			}
		}
#if TBC
		Add(guid_t, guid);
		Add(guidhigh_t, CREATUREGUID_HIGH);
#else
		Add(unsigned long, (unsigned long)0x6297848C);
#endif
	}

	/*
	*data << (uint32)flags2;
	*data << (uint32)0xB5771D7F;
	*data << (float)m_positionX;
	*data << (float)m_positionY;
	*data << (float)m_positionZ;
	*data << (float)m_orientation;
	*data << (float)0;
	*data << m_walkSpeed;
	*data << m_runSpeed;
	*data << m_backSwimSpeed;
	*data << m_swimSpeed;
	*data << m_backWalkSpeed;
	*data << m_turnRate;
	*//*
	if (Create)
	{
	Add(unsigned char,0x03);// "unit"
	Add(unsigned long, 0);
	Add(unsigned long, 0);
	Add(_Location,Data.Loc);
	Add(float,Data.Facing);
	Add(unsigned long, 0);
	Add(float,2.5f); //walk
	Add(float,8.0f); //run
	Add(float,8.0f); //run again (?)
	Add(float,4.7222223f); //swim
	Add(float,4.7222223f); //swim again (?)
	Add(float,3.141593f); //turn
	Skip(0x4);
	Add(unsigned long,0x1);
	Skip(0xC);
	}*/
#undef Fill
#undef Skip
#undef Add

	CUpdateBlock block(&buffer[c], UNIT_END);
	block.Add(OBJECT_FIELD_GUID, guid, CREATUREGUID_HIGH);
	block.Add(OBJECT_FIELD_TYPE, HIER_TYPE_UNIT);
	block.Add(OBJECT_FIELD_ENTRY, Data.Template);
	block.Add(OBJECT_FIELD_SCALE_X, pTemplate->Data.Size);
	if(!bIsSummon)
	{
		// UNIT_FIELD_BOUNDINGRADIUS	bounding_radius	0.69999999	float
		// UNIT_FIELD_COMBATREACH 	combat_reach	0.60000002	float
		// UNIT_FIELD_NATIVEDISPLAYID
		// UNIT_DYNAMIC_FLAGS
		// UNIT_FIELD_BASE_HEALTH
		// UNIT_FIELD_BASE_MANA
		// UNIT_FIELD_RANGEDATTACKTIME
		// UNIT_FIELD_MINRANGEDDAMAGE
		// UNIT_FIELD_MAXRANGEDDAMAGE
		// UNIT_FIELD_MINDAMAGE
		// UNIT_FIELD_MAXDAMAGE

		block.Add(UNIT_FIELD_HEALTH, Data.CurrentStats.HitPoints);
		block.Add(UNIT_FIELD_POWER1, Data.CurrentStats.Mana);
		block.Add(UNIT_FIELD_POWER2, Data.CurrentStats.Rage);
		block.Add(UNIT_FIELD_POWER3, 0);	// was focus
		block.Add(UNIT_FIELD_POWER4, Data.CurrentStats.Energy);

		block.Add(UNIT_FIELD_MAXHEALTH, pTemplate->Data.NormalStats.HitPoints);
		block.Add(UNIT_FIELD_MAXPOWER1, pTemplate->Data.NormalStats.Mana);
		block.Add(UNIT_FIELD_MAXPOWER2, pTemplate->Data.NormalStats.Rage);
		block.Add(UNIT_FIELD_MAXPOWER3, 0);
		block.Add(UNIT_FIELD_MAXPOWER4, pTemplate->Data.NormalStats.Energy);

		block.Add(UNIT_FIELD_LEVEL, pTemplate->Data.Level);
		block.Add(UNIT_FIELD_FACTIONTEMPLATE, pTemplate->Data.Faction); // FactionTemplate

		/*
		if(pTemplate->Data.Type == 1)
		{
		block.Add(UNIT_FIELD_FLAGS,0x0008);
		}
		*/

		// block.Add(UNIT_FIELD_BYTES_0, 0x20100);
		block.Add(UNIT_FIELD_BYTES_0, 0x20200);
		if(pTemplate->Data.virtualItemDisplay[0])
			block.Add(UNIT_VIRTUAL_ITEM_SLOT_DISPLAY, DataManager.ItemTemplates(pTemplate->Data.virtualItemDisplay[0]));
		if(pTemplate->Data.virtualItemDisplay[1])
			block.Add(UNIT_VIRTUAL_ITEM_SLOT_DISPLAY+1, DataManager.ItemTemplates(pTemplate->Data.virtualItemDisplay[1]));
		if(pTemplate->Data.virtualItemDisplay[2])
			block.Add(UNIT_VIRTUAL_ITEM_SLOT_DISPLAY+2, DataManager.ItemTemplates(pTemplate->Data.virtualItemDisplay[2]));

		if(pTemplate->Data.virtualItemDisplay[0])
		{
			block.Add(UNIT_VIRTUAL_ITEM_INFO, *((unsigned long*)&pTemplate->Data.virtualItemInfo[0]));
			block.Add(UNIT_VIRTUAL_ITEM_INFO+1, *((unsigned long*)&pTemplate->Data.virtualItemInfo[0]+1));
		}
		if(pTemplate->Data.virtualItemDisplay[1])
		{
			block.Add(UNIT_VIRTUAL_ITEM_INFO+2, *(unsigned long*)&pTemplate->Data.virtualItemInfo[0]);
			block.Add(UNIT_VIRTUAL_ITEM_INFO+3, *(unsigned long*)&pTemplate->Data.virtualItemInfo[0]+1);
		}
		if(pTemplate->Data.virtualItemDisplay[2])
		{
			block.Add(UNIT_VIRTUAL_ITEM_INFO+4, *(unsigned long*)&pTemplate->Data.virtualItemInfo[0]);
			block.Add(UNIT_VIRTUAL_ITEM_INFO+5, *(unsigned long*)&pTemplate->Data.virtualItemInfo[0]+1);
		}
		if(pTemplate->guid == SPIRITHEALER_GUID)
		{
			block.Add(UNIT_FIELD_FLAGS,UNIT_FLAG_SPIRITHEALER);
		} else {
			block.Add(UNIT_FIELD_FLAGS,0);
		}
		//block.Add(UNIT_FIELD_FLAGS,0);

		//block.Add(34, Data.Race | Data.Class << 8 | Data.Female << 16 | Data.ManaType << 24);

		block.Add(UNIT_FIELD_BASEATTACKTIME, 2000); // attack speed
		block.Add(UNIT_FIELD_BASEATTACKTIME+1, 2000); // probably other hand attack speed
		block.Add(UNIT_FIELD_RANGEDATTACKTIME,2000);

		/*block.Add(UNIT_FIELD_BOUNDINGRADIUS,1.0f);
		block.Add(UNIT_FIELD_COMBATREACH,1.0f);*/
		block.Add(UNIT_FIELD_BOUNDINGRADIUS, pTemplate->Data.BoundingRadius);
		block.Add(UNIT_FIELD_COMBATREACH,pTemplate->Data.CombatReach);
		block.Add(UNIT_FIELD_DISPLAYID,pTemplate->Data.Model);
		block.Add(UNIT_FIELD_NATIVEDISPLAYID,pTemplate->Data.Model);
		if(pTemplate->Data.Mount > 0)
			block.Add(UNIT_FIELD_MOUNTDISPLAYID,pTemplate->Data.Mount);
		block.Add(UNIT_FIELD_MINDAMAGE,pTemplate->Data.DamageMin);
		block.Add(UNIT_FIELD_MAXDAMAGE,pTemplate->Data.DamageMax);

		block.Add(UNIT_DYNAMIC_FLAGS,0);

		block.Add(UNIT_MOD_CAST_SPEED, 1.0f);

		/*unsigned long npcflags = 0x00;

		if(pTemplate->Data.NPCFlags == NPCTYPE_QUESTGIVER)
		npcflags = NPCTYPE_QUESTGIVER;
		else
		npcflags = pTemplate->Data.NPCFlags;

		if(GossipMenuItems.size() > 0)
		npcflags = NPCTYPE_INFO;
		*/
		block.Add(UNIT_NPC_FLAGS,pTemplate->Data.NPCFlags);
		block.Add(UNIT_FIELD_BASE_MANA,pTemplate->Data.NormalStats.Mana);
		block.Add(UNIT_FIELD_BASE_HEALTH,pTemplate->Data.NormalStats.HitPoints);

		block.Add(UNIT_FIELD_BYTES_2,0x1001);

		block.Add(UNIT_FIELD_MINRANGEDDAMAGE,pTemplate->Data.DamageMin);
		block.Add(UNIT_FIELD_MAXRANGEDDAMAGE,pTemplate->Data.DamageMax);
		return block.GetSize() + c;
	} else {
		block.Add(UNIT_FIELD_SUMMONEDBY,Data.Summoner,PLAYERGUID_HIGH);
		block.Add(UNIT_FIELD_HEALTH, Data.CurrentStats.HitPoints);
		block.Add(UNIT_FIELD_POWER1, Data.CurrentStats.Mana);
		block.Add(UNIT_FIELD_POWER2, Data.CurrentStats.Rage);
		block.Add(UNIT_FIELD_POWER3, 0);		// focus
		block.Add(UNIT_FIELD_POWER4, Data.CurrentStats.Energy);

		block.Add(UNIT_FIELD_MAXHEALTH, pTemplate->Data.NormalStats.HitPoints);
		block.Add(UNIT_FIELD_MAXPOWER1, pTemplate->Data.NormalStats.Mana);
		block.Add(UNIT_FIELD_MAXPOWER2, pTemplate->Data.NormalStats.Rage);
		block.Add(UNIT_FIELD_MAXPOWER3, 0);
		block.Add(UNIT_FIELD_MAXPOWER4, pTemplate->Data.NormalStats.Energy);

		block.Add(UNIT_FIELD_LEVEL, pTemplate->Data.Level);
		block.Add(UNIT_FIELD_FACTIONTEMPLATE, pTemplate->Data.Faction); // FactionTemplate

		block.Add(UNIT_FIELD_BYTES_0, 0x20200); //2048);

		block.Add(UNIT_FIELD_FLAGS,0);

		block.Add(UNIT_FIELD_BASEATTACKTIME, 2000); // attack speed
		block.Add(UNIT_FIELD_BASEATTACKTIME+1, 2000); // probably other hand attack speed
		block.Add(UNIT_FIELD_RANGEDATTACKTIME,2000);


		block.Add(UNIT_FIELD_BOUNDINGRADIUS, pTemplate->Data.BoundingRadius); // 0.7
		block.Add(UNIT_FIELD_COMBATREACH,pTemplate->Data.CombatReach); // 0.6
		block.Add(UNIT_FIELD_DISPLAYID,pTemplate->Data.Model);
		block.Add(UNIT_FIELD_NATIVEDISPLAYID,pTemplate->Data.Model);
		block.Add(UNIT_FIELD_MINDAMAGE,pTemplate->Data.DamageMin);
		block.Add(UNIT_FIELD_MAXDAMAGE,pTemplate->Data.DamageMax);

		block.Add(UNIT_FIELD_PETNUMBER,guid);
		block.Add(UNIT_FIELD_PET_NAME_TIMESTAMP,1000);
		block.Add(UNIT_FIELD_PETEXPERIENCE,0);
		block.Add(UNIT_FIELD_PETNEXTLEVELEXP,1000);
		block.Add(UNIT_CREATED_BY_SPELL, Data.SourceSpell);
		block.Add(UNIT_FIELD_STAT0,22);
		block.Add(UNIT_FIELD_STAT1,22);
		block.Add(UNIT_FIELD_STAT4,27);
		block.Add(UNIT_FIELD_RESISTANCES+0,0);
		block.Add(UNIT_FIELD_RESISTANCES+1,0);
		block.Add(UNIT_FIELD_RESISTANCES+2,0);
		block.Add(UNIT_FIELD_RESISTANCES+3,0);
		block.Add(UNIT_FIELD_RESISTANCES+4,0);
		block.Add(UNIT_FIELD_RESISTANCES+5,0);
		block.Add(UNIT_FIELD_RESISTANCES+6,0);
		block.Add(UNIT_FIELD_BASE_MANA,0);
		block.Add(UNIT_FIELD_ATTACK_POWER,24);
		return block.GetSize() + c;
	}
}
void CCreature::ProcessEvent(struct WoWEvent &Event)
{
	switch(Event.EventType)
	{
	case EVENT_CREATURE_DESPAWN:
		// note: this cant/wont free the memory but once we start using CSpawnPoint,
		// we can actually use delete pCreature;
		RegionManager.ObjectRemove(*this);
		AI_Tagger = 0;
		EventManager.AddEvent(*this,60000,EVENT_CREATURE_RESPAWN,0,0);
		break;
	case EVENT_CREATURE_REGENERATE:
		Regenerate();
		break;
	case EVENT_CREATURE_ATTACK:
		Attack();
		break;
	case EVENT_CREATURE_FOLLOW_TARGET:
		break;
	case EVENT_CREATURE_RESPAWN:
		ReSpawn();
		break;
	case EVENT_CREATURE_WANDER:
		Wander();
		break;
	case EVENT_CREATURE_REPEATEMOTE:
		{
			AddUpdateVal(UNIT_NPC_EMOTESTATE, 0);
			UpdateObject();
		}
		break;
	case EVENT_CREATURE_AIUNBUSY:
		{
		}
		break;
	case EVENT_CREATURE_UPDATELOC:
		{
		}
		break;
	case EVENT_CREATURE_DOTTED:
		{


		}
		break;
	case EVENT_CREATURE_REMOVE_AURA:			
		{
			long aura_value;
			memcpy(&aura_value, Event.pEventData, sizeof(aura_value));
			// Remove the aura
			RemoveAura(aura_value);
		}
		break;
	case EVENT_CREATURE_FACETARGET:
		{
			CWoWObject *tgt;
			if(DataManager.RetrieveObject((CWoWObject**)&tgt,this->TargetID))
			{
				FaceObject(tgt);
			}
			EventManager.AddEvent(*this,50,EVENT_CREATURE_FACETARGET,0,0);
		}
		break;

	}
}

void CCreature::SendPeriodicLog(unsigned long power,unsigned long spellid,unsigned long EffectID,unsigned long School,CWoWObject * Caster,CWoWObject * Target)
{
	CPacket pkg;
	pkg.Reset(SMSG_PERIODICAURALOG);
	Packets::PackGuid(pkg,Target->guid,PLAYERGUID_HIGH);
	Packets::PackGuid(pkg,Caster->guid,PLAYERGUID_HIGH);
	pkg << (unsigned long)spellid;
	pkg << (unsigned long)1;
	pkg << (unsigned long)EffectID;
	switch(EffectID)
	{
	case 3: { pkg<<power<<School<<(unsigned long)0;break; }
	case 8: {pkg<<power;break;}
	case 24: {pkg<<((CPlayer*)Target)->Data.ManaType;pkg<< power<<(char)00;break;}
	}
	Packets::SendRegion(pkg,this);
}
void CCreature::SetAura(unsigned long slot, unsigned long auraid, unsigned long spellid, unsigned long application, unsigned long flags, unsigned long state)
{
	if(slot>=64) return; // bounds check
	AddUpdateVal(UNIT_FIELD_AURA+slot, auraid );
	Field_Aura[slot] = auraid;
	unsigned long flagslot = slot >> 3;
	unsigned long value = Field_AuraFlags[flagslot];
	value |= 0xFFFFFFFF & (9 << ((slot & 7) << 2));
	AddUpdateVal(UNIT_FIELD_AURAFLAGS + flagslot, value);
	Field_AuraFlags[flagslot] = value;
	UpdateObject();
}
void CCreature::ResetAllAuras()
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
}
void CCreature::RemoveAura(unsigned long slot)
{
	if(slot>=64) return; // bounds check
	AddUpdateVal(UNIT_FIELD_AURA + slot, 0);
	Field_Aura[slot] = 0xFFFFFFFF;

	unsigned char flagslot = (unsigned char)(slot >> 3); // get high bits

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
				avent[i] = NULL;
				return;
			}
		}
	}
}
void CCreature::RemoveAllAuras()
{
	for(int i=0;i<64;i++)
	{
		if(Field_Aura[i])
		{
			RemoveAura(i);
		}
	}
}
void CCreature::InitAEvents()
{
	for(int i=0;i<64;i++)
	{
		avent[i]=NULL;
	}
}
long CCreature::FindFreeAuraSlot(bool positive)
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
	return -1;
}
long CCreature::FindFreeRestoreAuraSlot()
{
	for(int i=0;i<5;i++)
	{
		if (RestoreAuras[i].SpellID == 0)
			return i;
	}
	return -1;
}
void CCreature::Regenerate()
{
	if (bAttacking) {
		Data.isRegenning = true;
		EventManager.AddEvent(*this,10000,EVENT_CREATURE_REGENERATE,0,0);
		return;
	}
	bool regenning = false;
	if (Data.CurrentStats.HitPoints < pTemplate->Data.NormalStats.HitPoints) {
		DataObject.AddHP(CREATURE_REGEN_HPS);
		regenning = true;
	}
	if (Data.CurrentStats.Energy < pTemplate->Data.NormalStats.Energy) {
		DataObject.AddEnergy(CREATURE_REGEN_ENERGY);
		regenning = true;
	}
	if (UpdateDirty()) {
		UpdateObject();
	}
	if (regenning) {
		Data.isRegenning = true;
		EventManager.AddEvent(*this,10000,EVENT_CREATURE_REGENERATE,0,0);
	}
	else {
		Data.isRegenning = false;
	}
}

float CCreature::Distance(_Location Loc)
{
	float A=Loc.X-Data.Loc.X;
	float B=Loc.Y-Data.Loc.Y;
	float C=Loc.Z-Data.Loc.Z;
	return sqrtf((A*A)+(B*B)+(C*C));
}
float CCreature::GetAngle(_Location tg)
{
	float angle,x2,y2;
	x2 = tg.X;
	y2 = tg.Y;
	angle = atan2f (y2 - Data.Loc.Y, x2 - Data.Loc.X);
	if(angle < 0) angle+=float(6.28318530718); //360 degrees; Facing is from 0..2pi
	return angle;
}
void CCreature::FaceObject(CWoWObject *pObject)
{
	float angle,x2,y2;

	if(pObject->type == OBJ_PLAYER)
	{
		x2 = ((CPlayer*)pObject)->Data.Loc.X;
		y2 = ((CPlayer*)pObject)->Data.Loc.Y;
	}
	else if(pObject->type == OBJ_CREATURE)
	{
		x2 = ((CCreature*)pObject)->Data.Loc.X;
		y2 = ((CCreature*)pObject)->Data.Loc.Y;
	}
	else
	{
		return; // what are you facing??
	}
	angle = atan2f (y2 - Data.Loc.Y, x2 - Data.Loc.X);
	if(angle < 0) angle+=float(6.28318530718); //360 degrees; Facing is from 0..2pi
	if(Data.Facing!=angle) // angle changed
	{
		Data.Facing = angle;
		CPacket pkg(SMSG_MONSTER_MOVE);
		Packets::PackGuid(pkg,guid,CREATUREGUID_HIGH);
		pkg.Write(Data.Loc);
		pkg << (float)Data.Facing;
		pkg << (unsigned char)0x03;
		pkg<<pObject->guid;
		pkg<<(long)PLAYERGUID_HIGH;
		pkg << (unsigned long)0x0000100;
		pkg << (unsigned long)0;
		pkg << (unsigned long)1;
		pkg.Write(Data.Loc);
		Packets::SendRegion(pkg,pObject);
	}
}

#define ATTACK_DISTANCE 5.0f
#define CREATURE_WANDER_SPEED 2.5f //3.0
#define CREATURE_RUN_SPEED 7.0f //9.0

void CCreature::Attack()
{
	int Damage=0;
	if (Data.CurrentStats.HitPoints <= 0)
		return;
	CPlayer *pPlayer=NULL;
	CCreature *pCreatureTarget=NULL;
	if (DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,TargetID))
	{
		if (pPlayer->pClient == NULL)
			return;
		if(pPlayer->pClient->LoggingOut) //you cannot logout anymore!
		{
			Packets::UnRoot(pPlayer->pClient);
			pPlayer->pClient->pDataObject->SetStandState(UNIT_STANDING);
			pPlayer->pClient->UpdateObject();
			pPlayer->pClient->pPlayer->ClearEvents(EVENT_PLAYER_LOGOUT);
			pPlayer->pClient->LoggingOut=false;
			pPlayer->pClient->OutPacket(SMSG_LOGOUT_CANCEL_ACK,0,0);
			pPlayer->pClient->OutPacket(SMSG_LOGOUT_RESPONSE,"\x01\x00\x00\x00\x00",5); //you can't log out now!
		}
		if(Distance(pPlayer->Data.Loc)<=3.5f) Damage=MeleeAttack(pPlayer);
		if(Damage) pPlayer->TakeDamage(this,Damage,false);
	}
	else if (DataManager.RetrieveObject((CWoWObject**)&pCreatureTarget,OBJ_CREATURE,TargetID))
	{
		if(Distance(pCreatureTarget->Data.Loc)<=3.5f) Damage=MeleeAttack(pCreatureTarget);
		if(Damage) pCreatureTarget->TakeDamage(this,Damage,false);
	}
	EventManager.AddEvent(*this,1500,EVENT_CREATURE_ATTACK,0,0);
}

void CCreature::ObjectFades(CWoWObject &Object)
{
	if (Object.guid==TargetID) {
		TargetID=0;
		bAttacking = false;
		bMoving = false;
		bLooted = false;
	}
}
int CCreature::CastSpell(CPlayer *pPlayer, unsigned short spell)
{
	return 0;
}
void CCreature::UnTag()
{
	AI_Tagger=0;
	DataObject.SetDynamicFlags(0);
	UpdateObject();
}
void CCreature::TagThis(CPlayer *pp)
{
	AI_Tagger = pp->guid;
	DataObject.SetDynamicFlags(UNIT_DYNFLAG_OTHER_TAGGER);
	UpdateObject();
	DataObject.SetDynamicFlags(0x8);
	UpdateObjectOnlyPlayer(pp);
}

void CCreature::TakeDamage(CWoWObject *pObject, unsigned long dmg, bool spelldmg)
{
	if (pObject->type == OBJ_PLAYER&&((CPlayer*)pObject)->duelpartner)
	{
		if((((CPlayer*)pObject)->Data.CurrentStats.HitPoints - dmg) < 2)
		{
			((CPlayer*)pObject)->DataObject.SetHP(1);
			((CPlayer*)pObject)->UpdateObject();
			((CPlayer*)pObject)->EndDuel();	// Send winner and complete and despawn packets
			return;
		}
	}
	else
	{
		if (!dead)
		{
			// *** Subtract HP *** //
			DataObject.AddHP(-((long)dmg));
			AddToHitList(pObject,dmg);
			if(!AI_Tagger)
				if(pObject->type == OBJ_PLAYER)	
					TagThis((CPlayer*)pObject);
			// *** Check for death *** //
			if (Data.CurrentStats.HitPoints <= 0)
			{
				if(pObject->type == OBJ_PLAYER)
					Packets::AttackStop(((CPlayer*)pObject)->pClient, guid, CREATUREGUID_HIGH);
				Death();	// Me dead. :(
				UpdateObject();
				return;
			}
			UpdateObject();
			// Calculate if we should attack back.. we'll assume yes.
			if (!bAttacking)
			{
				if(bMoving)	UpdateMovement(CREATUREUPDATEFREQUENCY);
				SetInCombat(pObject);
				if(AIState!=AISTATE_MOVEATTACK)
				{
					AIState=AISTATE_MOVEATTACK;
					Move(pObject,RUN);
					Attack();
				}
			}
		}

	}
}
void CCreature::SetOutOfCombat(CWoWObject *target)
{
	bAttacking = false;
	bIsInCombat=false;
	CPlayer *ds=NULL;
	ClearEvents();
	target->bIsInCombat=false;
	if(target->type==OBJ_PLAYER)
	{
		ds=(CPlayer*)target;
		unsigned long val=0x1008;
		ds->AddUpdateVal(UNIT_FIELD_FLAGS,val);
		ds->UpdateObject();
	}
	SetTarget(NULL);
}
void CCreature::SetInCombat(CWoWObject *target)
{
	SetTarget(target);
	bAttacking = true;
	bIsInCombat=true;
	LocWhenAttacked=Data.Loc;
	CPlayer *ds=NULL;
	target->bIsInCombat=true;
	if(target->type==OBJ_PLAYER)
	{
		ds= (CPlayer*)target;
		unsigned long val=0x1008;
		ds->AddUpdateVal(UNIT_FIELD_FLAGS,(val|UNIT_FLAG_IN_COMBAT));
		ds->UpdateObject();
	}
}
int CCreature::MeleeAttack(CWoWObject *pObject)
{

	if (Data.CurrentStats.HitPoints <= 0)
		return -1;

	GameMechanics::AttackSwing((CWoWObject*)this,pObject);

	return 0;

	long dmg=0;
	int flag=0;
	int victimflags=0;
	if (pTemplate->Data.DamageMin == 4 && pTemplate->Data.Level != 1)
	{
		// For now we'll assume it's player
		if(pObject->type == OBJ_PLAYER)		// no casting without checking
			dmg = ((CPlayer*)pObject)->CalculateDmg(DMGTYPE_WEAPON,0, flag,victimflags);
	}
	else
	{
		dmg = CalculateDmg(DMGTYPE_WEAPON,0, flag);
	}
	float DamageReduction = 0;
	// damage to player, increase their defence skill level ;) (but make sure player first >.>), same thing for rage.
	if(pObject->type == OBJ_PLAYER)
	{
		((CPlayer*)pObject)->CheckForSkillUpdate(true);
		GameMechanics::RageForGettingHit(((CPlayer*)pObject),(CCreature*)this,dmg);
		((CPlayer*)pObject)->InCombat = true;
		unsigned long totalArmor=((CPlayer*)pObject)->Data.CurrentStats.Armor + 2*((CPlayer*)pObject)->Data.CurrentStats.Agility;
		DamageReduction = (float)totalArmor / (float)(totalArmor+400+85*pTemplate->Data.Level);
		DamageReduction = (DamageReduction >= 0.75f)?0.75f:DamageReduction;
		dmg=(long)(dmg*(1.0f-DamageReduction));
	}
	CPacket pkg;
	pkg.Reset(SMSG_ATTACKERSTATEUPDATE);
	pkg << flag;
	Packets::PackGuid(pkg,guid,CREATUREGUID_HIGH);
	//pkg << (unsigned char)0xFF << guid << CREATUREGUID_HIGH;
	if(pObject->type == OBJ_PLAYER)
	{
		Packets::PackGuid(pkg,pObject->guid,PLAYERGUID_HIGH);
		//pkg << (unsigned char)0xFF << pObject->guid << PLAYERGUID_HIGH;
	} else {
		Packets::PackGuid(pkg,pObject->guid,CREATUREGUID_HIGH);
		//pkg << (unsigned char)0xFF << pObject->guid << CREATUREGUID_HIGH;
	}
	pkg << dmg;
	pkg << (char)1; //Damage Count

	pkg << (long)0; //Damage Type
	pkg << (float)dmg; // Damage Float
	pkg << dmg; // Damage in Rt. Window
	pkg << (long)(dmg*DamageReduction); // Damage Absorbed
	pkg << (long)0; // Spell Link
	pkg << (long)1; // 2 dodge, 3 parry, 4 interrupt, 5 block, 6 evade, 7 immune, 8 deflect
	pkg << (unsigned long)0xFFFFFFFF;		// if blocked damage, this is 0
	pkg << (unsigned long)0;
	pkg << (unsigned long)0;

	/*
	pkg << (long)0; //0x3E8; // victimRoundDuration
	pkg << (long)0; // "spellDamageAdded"
	pkg << (long)0;  // "spellAddedDamage" if not 0 (then spell dmg) and dont show - assumes 1D will show
	pkg << (long)0;   // new val
	*/

	CRegion *pPlayerRegion=RegionManager.ObjectRegions[pObject->guid];
	if (!pPlayerRegion && pObject->type == OBJ_PLAYER && ((CPlayer*)pObject)->pClient)
	{
		((CPlayer*)pObject)->pClient->Send(&pkg);
		return dmg;
	}
	for (int i = 0 ; i < 3 ; i++) {
		for (int j = 0 ; j < 3 ; j++)
		{
			if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
			{
				RegionObjectNode *pNode=pRegion->pList;
				while(pNode)
				{
					if (pNode->pObject->type==OBJ_PLAYER && ((CPlayer*)pNode->pObject)->pClient)
					{
						if (((CPlayer*)pNode->pObject)->Distance(*((CPlayer*)pNode->pObject))<SPELLDIST) {
							((CPlayer*)pNode->pObject)->pClient->Send(&pkg);
						}
					}
					pNode=pNode->pNext;
				}
			}
		}
	}
	return dmg;
}

void CCreature::AIUpdate(long frequency)
{
	switch(AIState)
	{
	case AISTATE_WANDER: // We Are Wandering so we need to update our location constantly
		{
			UpdateMovement(frequency);	
		}
		break;
	case AISTATE_MOVEATTACK:
		{
			Debug.Logf("AI Update Frequency = %d",frequency);
			UpdateMovement(frequency);
			if(Target)
			{
				float distt=RegionManager.Distance(MovingTargetLoc,((CPlayer*)Target)->Data.Loc);
				if(distt>1.0f)
				{
					// Target has moved so we have to follow dont we :P
					Move(Target,RUN);
				}
				CheckTravelDistance();
			}
		}
		break;
	}
}
#define WANDER_DISTANCE 20
#define MAX_HEIGHT_CHANGE 20.0f

void CCreature::Wander()
{
	if (bIsTaxi)
		return;	// we don't want taxis wandering
	if (!strncmp(pTemplate->Data.Name,"Spirit Healer",13))
		return;
	if (pTemplate->Data.NPCFlags != NPCTYPE_NONE)
		return;	// stops npcs that you can interact with from wandering
	if (pTemplate->Data.Type == 10)
		return;	// hopefully this should stop horses wandering....
	if (!strncmp(pTemplate->Data.Name,"Horse",5))
		return;
	if (Data.CurrentStats.HitPoints <= 0)	return;
	_timeb now;_ftime(&now);
	if(FirstWander) { 
		FirstWander=false;
		LastWanderTime=now;
		CEventManager::RemoveTime(LastWanderTime,CREATUREUPDATEFREQUENCY);
	}
	unsigned long freq = CEventManager::DiffTime(now,LastWanderTime);
	if(freq>CREATUREUPDATEFREQUENCY) {AIUpdate(freq);LastWanderTime=now;}
	else return;
	if(bAttacking||bMoving||bIsInCombat) return; //we can't move while attacking!
	for(int i=0;i<5;i++)
	{
		_Location newloc;
		int change = rand() % WANDER_DISTANCE;
		if (rand()&1)//%2)
			change = -change;
		newloc.X = Data.Loc.X + change;

		change = rand() % WANDER_DISTANCE;
		if (rand()&1)//%2)
			change = -change;
		newloc.Y = Data.Loc.Y + change;

		newloc.Z = Data.Loc.Z;
		CContinent *pContinent=RegionManager.Continents[Data.Continent];
		if(pContinent)
		{
			float Z=pContinent->HeightAt(newloc.X,newloc.Y);
			if(Z)
			{
				if(fabs(Z-Data.Loc.Z)>MAX_HEIGHT_CHANGE) continue; //sorry...try again. 20 height diff. too much.
				newloc.Z=Z;
			}
		}
		AIState = AISTATE_WANDER;
		Move(&newloc,WALK);
		return;
	}
}

void CCreature::CheckTravelDistance()
{
	if (Distance(LocWhenAttacked) > 40.0f)
	{
		// STOP attacking, and return to your position maggot!
		CPlayer *pPlayer;
		if (DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, TargetID))
		{
			pPlayer->ClearEvents();
			TargetID = 0;
			bMoving = false;
			bAttacking = false;
			bLooted = false;
			ClearEvents();
			Data.isRegenning = true;
			EventManager.AddEvent(*this,10000,EVENT_CREATURE_REGENERATE,0,0);
			Move(&LocWhenAttacked,RUN);
			SetOutOfCombat(pPlayer);
			Debug.Log("AI: Returning to original spawn.");
		}
		return;
	}
}

void CCreature::ReSpawn()
{
	EventsEligible=true;
	bMoving = false;
	bAttacking = false;
	bLooted=false;
	dead = false;
	AI_Tagger = 0;
	Data.Loc.X = Data.SpawnLoc.X;
	Data.Loc.Y = Data.SpawnLoc.Y;
	Data.Loc.Z = Data.SpawnLoc.Z;
	Data.Facing = Data.SpawnFacing;
	Data.CurrentStats.HitPoints = pTemplate->Data.NormalStats.HitPoints;
	RegionManager.ObjectNew(*this,Data.Continent,Data.Loc.X,Data.Loc.Y);
}
void CCreature::sendSpellMsg(long damage, unsigned long spell, bool heal)
{
	if (pCaster->type != OBJ_PLAYER)
		return;
	CPacket pkg;
	pkg.Reset(SMSG_SPELLNONMELEEDAMAGELOG);
	Packets::PackGuid(pkg,guid,CREATUREGUID_HIGH); // target
	Packets::PackGuid(pkg,pCaster->guid,PLAYERGUID_HIGH); // caster
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
long CCreature::getTimeMs()
{
	unsigned long time_in_ms = 0;
	struct timeb tp;
	ftime(&tp);
	time_in_ms = tp.time * 1000 + tp.millitm;
	return time_in_ms;
}
long CCreature::getMoveFlags(int runwalk)
{
	switch(runwalk)
	{
	case WALK:
		{
			return 0x00000000;
		}
	case RUN:
		{
			return 0x00000100;
		}
	}
	return -1;
}
float CCreature::getSpeed(int runwalk)
{
	switch(runwalk)
	{
	case WALK: return 2.5f;
	case RUN: return 7.0f; 
		// Actually i debuged smsg_monster_move and realised it is not 7.0f but 6.0f
		// but it doesnt match our player speed so for now am gonna keep it 7.0 otherwise
		// creatures fall a lot behind
	}
	return 0; // -1
}
long CCreature::Move(CWoWObject * tgt,int runwalk)
{
	if (Data.CurrentStats.HitPoints <= 0)
		return 0;
	MovingStartLoc = Data.Loc;
	CPlayer *pp=NULL;
	pp=(CPlayer*)tgt;
	unsigned long timet=0;
	GetGoLocation(pp->Data.Loc);
	float distance = Distance(MovingDestLoc);
	timet = (unsigned long)((distance/getSpeed(runwalk))*1000.0f);
	StartTime=getTimeMs();
	CPacket pkg;
	pkg.Reset(SMSG_MONSTER_MOVE);
	Packets::PackGuid(pkg,guid,CREATUREGUID_HIGH);
	pkg.Write(Data.Loc);
	pkg << (unsigned long)StartTime;
	pkg << (unsigned char)03;
	pkg<<pp->guid;
	pkg<<PLAYERGUID_HIGH;
	pkg <<getMoveFlags(runwalk);
	pkg << (unsigned long)timet;
	pkg << (unsigned long)1;
	pkg.Write(MovingDestLoc);
	if(pp->pClient) pp->pClient->SendRegion(&pkg);
	bMoving = true;
	MovingDistance = distance;
	TimeToMove=timet;
	TimeMoved=0;
	return timet;
}
long CCreature::Move(_Location *loc,int runwalk)
{
	if (Data.CurrentStats.HitPoints <= 0)
		return 0;
	if(bMoving) return 0;
	unsigned long timet=0;
	MovingStartLoc=Data.Loc;
	float distance = Distance(*loc);
	timet = (unsigned long)((distance/getSpeed(runwalk))*1000.0f);
	StartTime=getTimeMs();
	CPacket pkg;
	pkg.Reset(SMSG_MONSTER_MOVE);
	Packets::PackGuid(pkg,guid,CREATUREGUID_HIGH);
	pkg.Write(Data.Loc);
	pkg << (unsigned long)StartTime;
	pkg << (unsigned char)0;
	pkg <<getMoveFlags(runwalk);
	pkg << (unsigned long)timet;
	pkg << (unsigned long)1;
	pkg.Write(*loc);
	Packets::SendRegion(pkg,this);
#ifdef _DEBUG
	Debug.LogBuffer(pkg.GetData(),pkg.GetLength(),"Packet: ");
#endif
	bMoving = true;
	MovingDestLoc = *loc;
	MovingDistance = distance;
	TimeToMove=timet;
	TimeMoved=0;
	return timet;
}
bool CCreature::StoringData(ObjectStorage &Storage)
{
	if (!guid/* || !Data.SpawnPoint*/)
		return false;
	Storage.Allocate(sizeof(CreatureData));
	memcpy(Storage.Data,&Data,sizeof(CreatureData));
	return true;
}

bool CCreature::LoadingData(ObjectStorage &Storage)
{
	if (!guid)
		return false;
	memcpy(&Data,Storage.Data,sizeof(CreatureData));
	DataManager.RetrieveObject((CWoWObject**)&pTemplate,OBJ_CREATURETEMPLATE,Data.Template);
	InitGossip();
	return true;
}
void CCreature::ApplySpell(CWoWObject &Caster, unsigned long SpellID, unsigned long Unknown)
{
	// hate AI could be done per effect later but we'll just use this for now
	if (Caster.type==OBJ_PLAYER)
	{
		FaceObject(&Caster);
		TargetID=Caster.guid;
	}
	CWoWObject::ApplySpell(Caster,SpellID,Unknown);
}

void CCreature::SendLootablePacket(CPlayer *pPlayer, bool lootable)
{
	DataObject.SetHP(0);
	if (lootable) {
		DataObject.SetFlags(0xE0000);
		DataObject.SetDynamicFlags(1);
		Data.LootMoney = (rand()%(10*pTemplate->Data.Level));
	}
	else {
		DataObject.SetFlags(0x00000);
		DataObject.SetDynamicFlags(0);
		Data.LootMoney = 0;
	}
	UpdateObject();
}

long CCreature::CalculateDmg(int type, short id, int &flag)
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
		long diff = pTemplate->Data.DamageMax - pTemplate->Data.DamageMin;
		long rv;
		if (diff)
		{
			rv = pTemplate->Data.DamageMin + (rand() % diff);
		}
		else
			rv = pTemplate->Data.DamageMin;

		flag |= 0x02;

		if ((rand() % 100) < 3) //critical hit!
		{
			flag |= 0x08;
			//rv += rv + (Data.Level * 2);
			rv += (rv >> 1); // rv >> 1 = rv/2
		}
		return rv;
	}

	return 0;
}
/*
DDWORD Guid
BYTE Count
if(Count == 0)
{
BYTE Error;
Errors:
0 - Vendor has no Inventory
1 - I don't think he likes you very much.
2 - You are too far away
3 - Vendor is dead
4 - You can't shop while dead.
}
else
{
for Count
DWORD Unknown
DWORD Cache Entry
DWORD DisplayID
DWORD Count
DWORD Value
DWORD Unknown
DWORD Unknown // Value shown in left corner of Icon
}
*/
void CCreature::ListInventory(CClient *pClient)
{
	DWORD count = DataManager.SellTemplates[pTemplate->guid].size();
	if(count == 0)
	{
		char buf[0xA];
		*(unsigned long*)&buf[0x00]=guid;
		*(unsigned long*)&buf[0x04]=CREATUREGUID_HIGH;
		buf[0x08] = 0;
		buf[0x09] = 0; // Error - Vendor has no inventory
		pClient->OutPacket(SMSG_LIST_INVENTORY, buf, 0xA);
		return;
	}
	if(dead)
	{
		char buf[0xA];
		*(unsigned long*)&buf[0x00]=guid;
		*(unsigned long*)&buf[0x04]=CREATUREGUID_HIGH;
		buf[0x08] = 0;
		buf[0x09] = 3; // Error - Vendor is dead
		pClient->OutPacket(SMSG_LIST_INVENTORY, buf, 0xA);
		return;
	}
	if(pClient->pPlayer->dead)
	{
		char buf[0xA];
		*(unsigned long*)&buf[0x00]=guid;
		*(unsigned long*)&buf[0x04]=CREATUREGUID_HIGH;
		buf[0x08] = 0;
		buf[0x09] = 4; // Error - Can't shop while dead
		pClient->OutPacket(SMSG_LIST_INVENTORY, buf, 0xA);
		return;
	}
	int bufsize = 0x8+1+(0x4*7*count);
	char* buffer = (char*)malloc(bufsize);
	*(unsigned long*)&buffer[0x00]=guid;
	*(unsigned long*)&buffer[0x04]=CREATUREGUID_HIGH;
	buffer[0x08] = (unsigned char)count;

	char *ptr = &buffer[0x09];
	for(list<unsigned long>::iterator i = DataManager.SellTemplates[pTemplate->guid].begin();i != DataManager.SellTemplates[pTemplate->guid].end();i++)
	{
		CItemTemplate *pTemplate;
		if(DataManager.RetrieveObject((CWoWObject**)&pTemplate, OBJ_ITEMTEMPLATE, *i))
		{
			*(unsigned long*)&ptr[0x00]=1; // Some kind of flag that makes it buyable?
			*(unsigned long*)&ptr[0x04]=pTemplate->guid;
			*(unsigned long*)&ptr[0x08]=pTemplate->Data.DisplayID;
			*(unsigned long*)&ptr[0x0C]=pTemplate->Data.MaxStack; // Count
			*(unsigned long*)&ptr[0x10]=pTemplate->Data.BuyPrice; // Value
			*(long*)&ptr[0x14]=-1; // originally 0
			*(long*)&ptr[0x18]=1; // originally 0
			ptr += 0x1C;
		}
		else
		{
			pClient->Echo("Internal error: Unable to find merchant item template.");
			return;
		}
	}
	pClient->OutPacket(SMSG_LIST_INVENTORY, buffer, bufsize);
	free(buffer);
}

void CCreature::BuyItem(CClient *pClient, guid_t nItem, unsigned long nStacked)
{
	// should check if the merchant has the item but whateve

	CItemTemplate *pTemplate;
	if(!DataManager.RetrieveObject((CWoWObject**)&pTemplate, OBJ_ITEMTEMPLATE, nItem))
	{
		pClient->OutPacket(SMSG_BUY_FAILED,0,0);
		return;
	}

	if ((nStacked*pTemplate->Data.BuyPrice) > pClient->pPlayer->Data.Copper)
	{
		SendInventoryFailure(pClient,BAG_NOT_ENOUGH_GOLD+1,0,0,0,0);
		//pClient->Echo("You don't have enough money to buy that item");
		return;
	}
	unsigned int buyedcount = nStacked - pClient->pPlayer->AddSetItem(pTemplate, nStacked);
	if (buyedcount == 0) return; //nothing buyed
	/*
	int newSlot = pClient->pPlayer->GetOpenBackpackSlot();
	if(newSlot == -1)
	{
	SendInventoryFailure(pClient,BAG_FULL,0,0,0,0);
	//pClient->Echo("Your backpack is full.");
	return;
	}

	CItem *pItem = new CItem;
	pItem->New(pTemplate, pClient->pPlayer->guid);
	pItem->Data.Count=nStacked;
	DataManager.NewObject(*pItem);
	//RegionManager.ObjectNew(*pItem, pClient->pPlayer->Data.Continent, pClient->pPlayer->Data.Loc.X, pClient->pPlayer->Data.Loc.Y);
	pClient->AddKnownItem(*pItem);
	pClient->pPlayer->DataObject.SetItem(newSlot, pItem);
	*/
	//	pClient->pPlayer->Data.Copper -= nStacked*(pTemplate->Data.BuyPrice);
	AddItemLoot(pClient->pPlayer,nItem,nStacked);
	pClient->pPlayer->Data.Copper -= buyedcount*(pTemplate->Data.BuyPrice);
	pClient->pPlayer->DataObject.SetCoinage(pClient->pPlayer->Data.Copper);
	pClient->pPlayer->UpdateObject();
}
void CCreature::SetTarget(CWoWObject *tgt)
{
	Target=tgt;
	if(tgt) TargetID = tgt->guid;
	else TargetID=0;
}
void CCreature::StopMoving()
{
	if(!bMoving) return;
	bMoving =false;
	AIState = AISTATE_STOPPED;
	CPacket pkg;
	pkg.Reset(SMSG_MONSTER_MOVE);
	Packets::PackGuid(pkg,guid,CREATUREGUID_HIGH);
	pkg.Write(Data.Loc);
	pkg<<getTimeMs();
	pkg<<(char)1;
	Packets::SendRegion(pkg,this);
}
void CCreature::GetGoLocation(_Location TargetLocation)
{
	MovingTargetLoc = TargetLocation;
	_Location loc = TargetLocation;	
	//float angle = GetAngle(loc);
	float dist = Distance(TargetLocation);
	// mult is the ratio of the desired distance to the current distance
	float mult = (pTemplate->Data.CombatReach)/dist; // BoundingRadius...maybe...
	// multiply current distances by the ratio to get a reduced target value in X and Y
	loc.X -= mult*(loc.X-Data.Loc.X);
	loc.Y -= mult*(loc.Y-Data.Loc.Y);
	MovingDestLoc.X = loc.X+0.5f;
	MovingDestLoc.Y= loc.Y+0.5f;
	CContinent *pContinent=RegionManager.Continents[Data.Continent];
	if(pContinent)
	{
		float Z=pContinent->HeightAt(MovingDestLoc.X,MovingDestLoc.Y);
		if(Z)
		{
			MovingDestLoc.Z=Z;
		}
	}
}
void CCreature::UpdateMovement(unsigned long frequency)
{
	if (Data.CurrentStats.HitPoints <= 0)
		return;
	if (!bMoving)
		return;
	CContinent *pContinent=RegionManager.Continents[Data.Continent];
	CPlayer *pp=NULL;
	if(Target) {if(Target->type==OBJ_PLAYER) pp = (CPlayer*)Target;}
	TimeMoved=getTimeMs()-StartTime;
	if(TimeMoved >= TimeToMove) //We are There dog :p
	{
		Data.Loc.X = MovingDestLoc.X;
		Data.Loc.Y = MovingDestLoc.Y;
		Data.Loc.Z = MovingDestLoc.Z;  
		bMoving = false;
	}
	else // partial
	{
		float mod = (float)TimeMoved/(float)TimeToMove;
		Data.Loc.X = MovingStartLoc.X +(MovingDestLoc.X - MovingStartLoc.X)*mod;
		Data.Loc.Y = MovingStartLoc.Y +(MovingDestLoc.Y - MovingStartLoc.Y)*mod;
		Data.Loc.Z = MovingStartLoc.Z +(MovingDestLoc.Z - MovingStartLoc.Z)*mod;                          
	}
	if(pContinent)
	{
		float Z=pContinent->HeightAt(Data.Loc.X,Data.Loc.Y);
		if(Z)
		{
			Data.Loc.Z=Z;
		}
	}
	RegionManager.ObjectMovement(*this,Data.Loc.X,Data.Loc.Y);		

}
void CCreature::Death(void)
{
	if (!dead) {
		StopMoving();
		RemoveAllAuras();
		if(Target) SetOutOfCombat(Target);
		ClearEvents();
		bAttacking = false;
		bMoving = false;
		bLooted = false;
		dead = true;
		EventManager.AddEvent(*this,60000,EVENT_CREATURE_DESPAWN,0,0);
		CParty *pParty = NULL;
		if (DataManager.RetrieveObject((CWoWObject**)&pParty, OBJ_PARTY,  GetHitListGuid()))
		{
			pParty->PartyExp(this);
			CPlayer *pLooter = pParty->GetLooter();
			if (pLooter)
				SendLootablePacket(pLooter);
		}
		else
		{
			CPlayer *pPlayer=NULL;
			if (DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,GetHitListGuid())) {
				if (AI_Tagger != pPlayer->guid)
				{
					dead = true;
					AI_Tagger = 0;
					return;
				}
				AI_Tagger = 0;
				AddCreatureKill(pPlayer, guid);
				long OrigExp;
				long Exp=GameMechanics::CalculateKillXP((CCreature*)this, pPlayer,&OrigExp);
				Packets::LogGainXP(pPlayer->pClient,guid,OrigExp,Exp);
				GameMechanics::GiveXP(pPlayer,Exp);
				UnTag();
				SendLootablePacket(pPlayer,true);
			}
		}
		memset(&XP,0,sizeof(XP));
	}
	dead = true;
}

void CCreature::ShowQuestStatus(CClient * pClient)
{
	/*
	structure of SMSG_QUESTGIVER_STATUS:
	uint64 VendorGUID
	ulong questid
	*/
	/*	unsigned char buffer[0x0C];

	memset(buffer,0,0x0C);
	*(unsigned long*)&buffer[0x00]=guid;  // Vendor GUID
	*(unsigned long*)&buffer[0x04]=CREATUREGUID_HIGH;  // Vendor GUID
	*(unsigned long*)&buffer[0x08]=0x01; // Number of items
	pClient->OutPacket(SMSG_QUESTGIVER_STATUS, buffer, 0x0C);
	*/
	CPacket pkg;
	pkg.Reset(SMSG_QUESTGIVER_STATUS);
	pkg << guid << CREATUREGUID_HIGH;
	// pkg << 5;
	unsigned long dialogstatus;
	unsigned long finalstatus = 0;
	unsigned long questguid;
	CQuestInfo *pQuest;

	for(std::list<unsigned long>::iterator i=DataManager.CreatureQuestRelation[Data.Template].begin();i!=DataManager.CreatureQuestRelation[Data.Template].end();i++)
	{
		questguid = (*i);
		if (!DataManager.RetrieveObject((CWoWObject**)&pQuest, OBJ_QUESTINFO, questguid))
		{
			// quest not found
			continue;
		}
		dialogstatus = GetDialogStatus(this, pClient, questguid);
		if (dialogstatus == DIALOG_STATUS_REWARD)
		{
			pkg << (unsigned long)dialogstatus;
			pClient->Send(&pkg);
			return;
		}
		if (dialogstatus == DIALOG_STATUS_INCOMPLETE)
		{
			pkg << (unsigned long)dialogstatus;
			pClient->Send(&pkg);
			return;
		}
		if (dialogstatus > 0)
			if (finalstatus != DIALOG_STATUS_AVAILABLE)
				finalstatus = dialogstatus;
	}
	pkg << (unsigned long)finalstatus;
	pClient->Send(&pkg);
}

void CCreature::ShowQuestHello(CClient * pClient)
{
	/*
	structure of SMSG_QUESTGIVER_QUEST_DETAILS:
	uint64 VendorGUID
	ulong questid
	string(null) title
	string(null) description
	string(null) objectives
	ulong value 1
	ulong number of choice rewards (pick one of these...)
	for each choice:
	{
	ulong item id
	ulong item count
	ulong item model
	}
	ulong number of item rewards (all the items that will automatically be rewarded)
	for each item:
	{
	ulong item id
	ulong item count
	ulong item model
	}
	ulong gold reward
	ulong spell reward
	ulong num of emotes (emotes performed by the questgiver?)
	for each emote:
	{
	ulong delay (msecs)
	ulong emote
	}
	*/
	CPacket pkg;
	pkg.Reset(SMSG_QUESTGIVER_QUEST_LIST);
	pkg << guid << CREATUREGUID_HIGH;

	CQuestInfo *pQuest;
	unsigned long counter = 0;
	unsigned long questguid = 0;
	unsigned long questid;
	unsigned long questcount;
	unsigned long creaturetemplate=Data.Template;
	questcount = (unsigned char)DataManager.CreatureQuestRelation[creaturetemplate].size();

	std::list<unsigned long>::iterator i;

	unsigned long incompleted = 0;

	for(i=DataManager.CreatureQuestRelation[creaturetemplate].begin();i!=DataManager.CreatureQuestRelation[creaturetemplate].end();i++)
	{
		questguid = (*i);
		if (!CanTakeQuest(pClient, questguid))
			questcount--;
	}

	for(i=DataManager.CreatureInvolvedRelation[creaturetemplate].begin();i!=DataManager.CreatureInvolvedRelation[creaturetemplate].end();i++)
	{
		questguid = (*i);
		unsigned long qs=GetQuestStatus(pClient, questguid);
		if (qs == QUEST_STATUS_COMPLETE)
			questcount++;
		else if (qs==QUEST_STATUS_INCOMPLETE)
			incompleted=questguid;
	}

	// look up text!
	if(!questcount)
	{
		if(incompleted)
		{
			CQuestInfo *pIncomplete = NULL;
			if(!DataManager.RetrieveObject((CWoWObject **)&pIncomplete,incompleted,OBJ_QUESTINFO) || !(pIncomplete->Data.incompletetext[0]))
				pkg << "You haven't finished my quest yet; what are you doing running back here so fast?";
			else pkg.Write(pIncomplete->Data.incompletetext);
		}
		else
			pkg << "No quests at the moment!";
	}
	else
	{
		if (pTemplate->Data.QuestGiverText)
			pkg << pTemplate->Data.QuestGiverText;
		else
			pkg << "Greetings, $N. Here are your quests!";
	}
	pkg << (unsigned long)0;
	pkg << (unsigned long)0;

	pkg << (unsigned char)questcount;

	if(questcount == 1)
	{
		// Don't bother showing a menu go straight to the details.
		for(i=DataManager.CreatureQuestRelation[creaturetemplate].begin();i!=DataManager.CreatureQuestRelation[creaturetemplate].end();i++)
		{
			questguid = (*i);
			if (CanTakeQuest(pClient, questguid))
			{
				SendSmallQuestDetails(pClient,this->guid,(*i));
				return;
			}
		}
	}

	for(i=DataManager.CreatureQuestRelation[creaturetemplate].begin();i!=DataManager.CreatureQuestRelation[creaturetemplate].end();i++)
	{
		questguid = (*i);
		if (CanTakeQuest(pClient, questguid))
		{
			questid = (*i);
			pkg << (unsigned long)questguid;
			pkg << (unsigned long)0x05;
			pkg << (unsigned long)0x00;
			if (!DataManager.RetrieveObject((CWoWObject**)&pQuest, OBJ_QUESTINFO, questguid))
				pkg << "Quest not found in DB!";
			else
				pkg << pQuest->Data.title;
		}
		counter++;
	}

	for(i=DataManager.CreatureInvolvedRelation[creaturetemplate].begin();i!=DataManager.CreatureInvolvedRelation[creaturetemplate].end();i++)
	{
		questguid = (*i);
		if (GetQuestStatus(pClient, questguid) == QUEST_STATUS_COMPLETE)
		{
			questid = (*i);
			pkg << (unsigned long)questguid;
			pkg << (unsigned long)0x03;
			pkg << (unsigned long)0x00;
			if (!DataManager.RetrieveObject((CWoWObject**)&pQuest, OBJ_QUESTINFO, questguid))
				pkg << "Quest not found in DB!";
			else
				pkg << pQuest->Data.title;
		}
		counter++;
	}
	pClient->Send(&pkg);

	/*
	CPacket pkg(SMSG_QUESTGIVER_QUEST_DETAILS);
	pkg << guid << CREATUREGUID_HIGH;
	pkg << (unsigned long)33;  // Quest ID
	pkg << "Wolves Across the Border";		// title
	pkg << "Bring 8 pieces of Tough Wolf Meat to Eagan Peltskinner outside Northshire Abbey.";		// objectives
	pkg << "I hate those nasty timber wolves!  But I sure like eating wolf steaks...  Bring me tough wolf meat and I will exchange it for something you'll find useful.$B$BTough wolf meat is gathered from hunting the timber wolves and young wolves wandering the Northshire countryside.";	// details
	pkg << (unsigned long)0x01;					// Accept active?
	pkg << (unsigned long)2;					// No. of rewards
	// loop this:
	pkg << (unsigned long)1;				// no of items
	pkg << (unsigned long)6070;				// item id
	// end loop
	pkg << (unsigned long)1;
	pkg << (unsigned long)80;

	pkg << (unsigned long)0;			// item rewards;
	pkg << (unsigned long)0;			// reward gold
	pkg << (unsigned long)0;			// unknown
	pkg << (unsigned long)0;			// no. of mobs

	pClient->Send(&pkg);*/
	/*
	if (questinfo.title != NULL)
	pkg << questinfo.title;
	else
	pkg << "No Title";
	if (questinfo.description != NULL)
	pkg << questinfo.description;
	else
	pkg << "No Description";
	if (questinfo.objective != NULL)
	pkg << questinfo.objective;
	else
	pkg << "No Objective";
	pkg << (unsigned long)0x01;
	pkg << (unsigned long)0x00;
	pkg << (unsigned long)0x00;
	pkg << (unsigned long)0x00;
	pkg << (unsigned long)0x00;
	pkg << (unsigned long)0x04;
	pkg << (unsigned long)0x01;
	pkg << (unsigned long)0x00;
	pkg << (unsigned long)0x01;
	pkg << (unsigned long)0x00;
	pkg << (unsigned long)0x00;
	pkg << (unsigned long)0x00;
	pkg << (unsigned long)0x00;
	pkg << (unsigned long)0x00;
	pClient->Send(&pkg);*/
}

unsigned long CTaxiMob::Mask[8];
