#ifndef CREATURE_H
#define CREATURE_H

#include "stdafx.h"
#include "WoWObject.h"
#include "CreatureTemplate.h"
#include "ItemTemplate.h"
#include <sys/timeb.h>
#include "FlyPath.h"
#include <list>
#include <map>
#include "UpdateObject.h"
#include "Event.h"
#define WALK 0
#define RUN 1
#define AISTATE_WANDER 0
#define AISTATE_MOVEATTACK 1
#define AISTATE_STOPPED 2
#define CREATUREUPDATEFREQUENCY 150
#define SPIRITHEALER_GUID 0x0800195B
struct MerchantFilter_t
{
	unsigned long subtype[NUM_ITEMTYPES];
	unsigned long minlevel;
	unsigned long maxlevel;
	unsigned long invtype;
	unsigned long checkInvType;
};

struct CreatureSaveData
{
	// char Name[64];
	// char Guild[64];
	guid_t TemplateID;
	unsigned long Continent;
	_Location Loc;
	float Facing;
	//unsigned long Model;
	//unsigned long Level;
	//unsigned long Exp;
	//long HitPoints;
	//unsigned long DamageMin;
	//unsigned long DamageMax;
	//float Size;
	//unsigned long NPCType;
	//unsigned long FactionTemplate;
	//unsigned int virtualItemDisplay[3];
	//struct CreatureItemInfo virtualItemInfo[3];
	unsigned long FirstPoint;
};

struct CreatureXP
{
	guid_t hitguid;
	short dmg;
};

struct CreatureData
{
	// char Name[64];
	unsigned long SpawnPoint;
	guid_t Template;
	unsigned long Continent;
	_Location Loc;
	_Location SpawnLoc;
	float Facing;
	float SpawnFacing;

	CreatureStats CurrentStats;

	// unsigned long ItemTemplates[10];

	// unsigned int virtualItemDisplay[3];
	// struct CreatureItemInfo virtualItemInfo[3];		// This shit will be moved into templates ;)
	// bool isSaved; everything is saved!
	long LootMoney;
	unsigned long isRegenning; // bool, but it'll take the whole 4 bytes anyway
	guid_t Summoner;
	unsigned long SourceSpell;
	unsigned long SpawnID;
};

struct _AIAction
{
	unsigned char Command;
	_Location Location;
	string Text;
	unsigned long Emote;
	unsigned short Data1;
	unsigned short Data2;
};

class CCreature : public CWoWObject, public CUpdateObject
{
	unsigned long AddCreateObjectData(char *buffer);
	void PreCreateObject();
	//void PostCreateObject();
public:
	void InitAEvents();
	CWoWObject *Target;
	void TagThis(CPlayer *pp);
	void UnTag();
	void SetTarget(CWoWObject * tgt);
	void SetOutOfCombat(CWoWObject *target);
	void SetInCombat(CWoWObject *target);
	void UpdateMovement(unsigned long frequency);
	inline void UpdateObject(bool reset = true) {CUpdateObject::UpdateObject(guid, CREATUREGUID_HIGH, reset);};
	inline void UpdateObjectOnlyPlayer(CPlayer *pPlayer, bool reset = true)
	{
		CUpdateObject::UpdateObjectOnlyPlayer(pPlayer,guid, CREATUREGUID_HIGH, reset);
	};
	void SendLootablePacket(CPlayer *pPlayer, bool lootable=true);
	bool LoadingData(ObjectStorage &Storage);
	bool StoringData(ObjectStorage &Storage);

	void AddToHitList(CWoWObject *pObject, int dmg);
	long GetHitListGuid();
	void GetGoLocation(_Location TargetLocation);
	void StopMoving();
	long getTimeMs();
	long TimeToMove;
	long TimeMoved;
	void AIUpdate(long frequency);
	long getMoveFlags(int runwalk);
	long AIState;
	float getSpeed(int runwalk);
	bool bIsSummon;
	long StartTime;
	long Move(_Location *loc,int runwalk);
	long Move(CWoWObject * tgt,int runwalk);
	void RemoveAllAuras();
	void SetAura(unsigned long slot, unsigned long auraid, unsigned long spellid, unsigned long application, unsigned long flags, unsigned long state);
	void RemoveAura(unsigned long slot);
	long FindFreeAuraSlot(bool positive);
	long FindFreeRestoreAuraSlot();
	long MountedAuraSlot;
	guid_t SummonGuid;
	unsigned long Field_Aura[64];
	unsigned long Field_AuraFlags[8];
	unsigned long Field_AuraLevels[8];
	unsigned long Field_AuraApplications[16];
	unsigned long Field_AuraState;
	_RestoreAura RestoreAuras[5];
	void ResetAllAuras();
	void SendPeriodicLog(unsigned long power,unsigned long spellid,unsigned long EffectID,unsigned long School,CWoWObject * Caster,CWoWObject * Target);
	void ReSpawn();
	void CheckTravelDistance();
	int MeleeAttack(CWoWObject *pObject);
	int CastSpell(CPlayer *pPlayer, unsigned short spell);
	void FaceObject(CWoWObject *pObject);
	long FirstPoint;
	long CurrentPoint;
	void Attack();
	void Regenerate();
	float GetAngle(_Location tg);
	void Wander();
	long CalculateDmg(int type, short id, int &flag);
	void ShowQuestStatus(CClient * pClient);
	void ShowQuestHello(CClient * pClient);
	void TakeDamage(CWoWObject *pObject, unsigned long dmg, bool spelldmg);
	CCreature(void);
	~CCreature(void);
	AuraEvent* avent[64];
	CCreatureTemplate *pTemplate;
	CreatureData Data;
	float Distance(_Location Loc);
	void Delete();
	void Clear();
	virtual void New(guid_t nTemplate);

	virtual void New(CCreatureTemplate &NewTemplate);

	unsigned long GetCreatureInfoData(char *buffer, bool Create=true);

	void ObjectFades(CWoWObject &Object);

	void ProcessEvent(struct WoWEvent &Event);
	guid_t TargetID;

	void ApplySpell(CWoWObject &Caster, unsigned long SpellID, unsigned long Unknown);
	void sendSpellMsg(long damage, unsigned long spell, bool heal);
	guid_t AI_Tagger;
	virtual void ListInventory(CClient *pClient);
	virtual void BuyItem(CClient *pClient, guid_t nItem, unsigned long nStacked);
	void InitGossip();
	map<char,CItemTemplate *> LootedItems; //slot, item
	bool bMoving;
	bool bAttacking;
	bool bLooted;
	bool bIsTaxi; // used so that there isn't any confusion about this...
	_Location LocWhenAttacked;
	_Location MovingStartLoc;
	_Location MovingDestLoc;
	_Location MovingTargetLoc;
	_timeb MovingStart;
	float MovingSpeed;
	float MovingDistance;
	CreatureXP XP[10];		// For now this can be expanded later, especially since most creatures wont need >2 or 3
	char PetAction1;
	char PetAction2;
	char PetAction3;
	_timeb LastWanderTime; // no __timeb32 crap, please
	bool FirstWander;
	CPlayer *summoner;
	short DefaultGossip; // this can be set to -1, so it cannot be unsigned!
	std::list<unsigned long> GossipMenuItems;

	class CCreatureDataObject
	{
	public:
		CCreature *pObject;
#define ADDTYPE(name, updateVal, saveto, type) \
	inline void name(type val)\
		{\
		saveto = val;\
		pObject->AddUpdateVal(updateVal, val);\
		}

#define ADDLONG(name, updateVal, saveto) ADDTYPE(name, updateVal, saveto, long)
#define ADDULONG(name, updateVal, saveto) ADDTYPE(name, updateVal, saveto, unsigned long)
#define ADDFLOAT(name, updateVal, saveto) ADDTYPE(name, updateVal, saveto, float)
#define ADDINCLONG(name, updateVal, saveto, max) \
	inline void name(long val) \
		{\
		saveto += val;\
		if(saveto < 0)\
		saveto = 0;\
			else if(saveto > max)\
			saveto = max;\
			pObject->AddUpdateVal(updateVal, saveto);\
		}
#define ADDINCLONG2(name, updateVal, saveto) \
	inline void name(long val) \
		{\
		saveto += val;\
		pObject->AddUpdateVal(updateVal, saveto);\
		}

		ADDLONG(SetHP, UNIT_FIELD_HEALTH, pObject->Data.CurrentStats.HitPoints);
		ADDLONG(SetMana, UNIT_FIELD_POWER1, pObject->Data.CurrentStats.Mana);
		ADDLONG(SetRage, UNIT_FIELD_POWER2, pObject->Data.CurrentStats.Rage);
		ADDLONG(SetEnergy, UNIT_FIELD_POWER4, pObject->Data.CurrentStats.Energy);

		ADDINCLONG(AddHP, UNIT_FIELD_HEALTH, pObject->Data.CurrentStats.HitPoints, pObject->pTemplate->Data.NormalStats.HitPoints);
		ADDINCLONG(AddMana, UNIT_FIELD_POWER1, pObject->Data.CurrentStats.Mana, pObject->pTemplate->Data.NormalStats.Mana);
		ADDINCLONG(AddRage, UNIT_FIELD_POWER2, pObject->Data.CurrentStats.Rage, pObject->pTemplate->Data.NormalStats.Rage);
		ADDINCLONG(AddEnergy, UNIT_FIELD_POWER4, pObject->Data.CurrentStats.Energy, pObject->pTemplate->Data.NormalStats.Energy);

		ADDLONG(SetMaxHP, UNIT_FIELD_MAXHEALTH, pObject->pTemplate->Data.NormalStats.HitPoints);
		ADDLONG(SetMaxMana, UNIT_FIELD_MAXPOWER1, pObject->pTemplate->Data.NormalStats.Mana);
		ADDLONG(SetMaxRage, UNIT_FIELD_MAXPOWER2, pObject->pTemplate->Data.NormalStats.Rage);
		ADDLONG(SetMaxEnergy, UNIT_FIELD_MAXPOWER4, pObject->pTemplate->Data.NormalStats.Energy);

		ADDINCLONG2(AddMaxHP, UNIT_FIELD_MAXHEALTH, pObject->pTemplate->Data.NormalStats.HitPoints);
		ADDINCLONG2(AddMaxMana, UNIT_FIELD_MAXPOWER1, pObject->pTemplate->Data.NormalStats.Mana);
		ADDINCLONG2(AddMaxRage, UNIT_FIELD_MAXPOWER2, pObject->pTemplate->Data.NormalStats.Rage);
		ADDINCLONG2(AddMaxEnergy, UNIT_FIELD_MAXPOWER4, pObject->pTemplate->Data.NormalStats.Energy);

		inline void SetFlags(unsigned long val)
		{
			pObject->AddUpdateVal(UNIT_FIELD_FLAGS, val);
		};
		inline void SetDynamicFlags(unsigned long val)
		{
			pObject->AddUpdateVal(UNIT_DYNAMIC_FLAGS, val);
		};

#undef ADDINCLONG
#undef ADDLONG
#undef ADDULONG
#undef ADDFLOAT
#undef ADDTYPE
	};
	CCreatureDataObject DataObject;
	void Death(void);
};
long getPower(unsigned long spell, unsigned long effect);

class CTaxiMob : public CCreature
{
public:
	static unsigned long Mask[8];
	CTaxiMob()
	{
		nodeid = 0;
		bIsTaxi=true;
	}

	~CTaxiMob()
	{
	}

	unsigned int nodeid;
};

#endif // CREATURE_H
