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
	unsigned long TemplateID;
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
	unsigned long hitguid;
	short dmg;
};

struct CreatureData
{
	// char Name[64];
	unsigned long SpawnPoint; // creatures with no spawn point will not be saved
	unsigned long Template;
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
	bool isRegenning;
	unsigned long Summoner;
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
	/* Bur: AI Framework Variables Here */
	bool AI_Moving;
	// _Location AI_movingto;
	bool AI_Busy;
	void AI_Initialize();
	bool AI_Update();
	bool AI_ScriptPresent;
	bool AI_Initialized;
	void AI_TalkHandler(CClient *pClient, char* msg);
	void AI_Say(CClient *pClient, char *msg, bool OnlyToThatPlayer);
	void AI_Emote(CClient *pClient, unsigned long emote);
	void AI_Aggro(CClient *pClient);
	void AI_WalkInProximity(CClient *pClient);
	void AI_Attack(CClient *pClient);
	void AI_Protect(CClient *pClient);
	void AI_Activate();
	void AI_Deactivate();
	bool AI_Activated;
	bool AI_KeepActive();
	void AI_ProcessEvent(CWoWObject *pSource, int MessageID, unsigned long Param1, unsigned long Param2);
	void AI_SetFaction();
	bool AI_IsHostile(CWoWObject *pP);
	char AI_Hostile;
	//int AI_GossipType;
	map<char, _AIAction> AI_Actions;
	unsigned char AI_ActionCount;
	unsigned char AI_CurrentPoint;
	float AI_CreatureMoveSpeed;
	string AI_TalkText;
	unsigned long AI_TalkEmote;
	bool AI_CanTalk;
	bool AI_AgroNPC;
	short AI_AgroScale;
	int AI_UpdateFrequency;
	unsigned long AI_Tagger;
	char AI_HasCalledForHelp;
	bool bIsSummon;

	/* Bur: End AI-Related stuff */
	void InitAEvents();
	inline void CreateObject(bool reset = true) {CUpdateObject::CreateObject(guid, reset);};
	inline void UpdateObject(bool reset = true) {CUpdateObject::UpdateObject(guid, CREATUREGUID_HIGH, reset);};
	inline void UpdateObjectOnlyPlayer(CPlayer *pPlayer, bool reset = true)
	{
		CUpdateObject::UpdateObjectOnlyPlayer(pPlayer,guid, CREATUREGUID_HIGH, reset);
	};
	long GetHitListGuid();
	void AddToHitList(CWoWObject *pObject, int dmg);
	void SendLootablePacket(CPlayer *pPlayer, bool lootable=true);
	bool LoadingData(ObjectStorage &Storage);
	bool StoringData(ObjectStorage &Storage);
	unsigned long DataStorageSize() {return sizeof(CreatureData);};
	long UpdateLoc();
	void MoveToPPoint(const int pPointID);
	long Move(_Location *loc, float speed);
	void SetAura(unsigned long slot, unsigned long auraid, unsigned long spellid, unsigned long application, unsigned long flags, unsigned long state);
	void RemoveAura(unsigned long slot);
	unsigned long FindFreeAuraSlot(bool positive);
	long FindFreeRestoreAuraSlot();
	unsigned long MountedAuraSlot;
	unsigned long SummonGuid;
	unsigned long Field_Aura[64];
	unsigned long Field_AuraFlags[8];
	unsigned long Field_AuraLevels[8];
	unsigned long Field_AuraApplications[16];
	unsigned long Field_AuraState;
	_RestoreAura RestoreAuras[5];
	void ResetAllAuras();
	void SendPeriodicLog(unsigned long power,unsigned long spellid,unsigned long EffectID,unsigned long School,CWoWObject * Caster,CWoWObject * Target);
	void ReSpawn();
	void FollowTarget();
	void CheckTravelDistance();
	int MeleeAttack(CWoWObject *pObject);
	int CastSpell(CPlayer *pPlayer, unsigned short spell);
	void FacePlayer(CPlayer *player);
	void FaceObject(CWoWObject *pObject);
	long FirstPoint;
	long CurrentPoint;
	void Attack();
	void Move();
	void Regenerate();
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
	virtual void New(unsigned long nTemplate);

	virtual void New(CCreatureTemplate &NewTemplate);

	unsigned long GetCreatureInfoData(char *buffer, bool Create=true);

	void ObjectFades(CWoWObject &Object);

	void ProcessEvent(struct WoWEvent &Event);
	unsigned long TargetID;

	void ApplySpell(CWoWObject &Caster, unsigned long SpellID, unsigned long Unknown);
	void ApplySpellEffect(unsigned long SpellID, unsigned long Effect);
	void HandleSpellEffects(CSpell *pSpell,unsigned long Effect);
	void sendSpellMsg(long damage, unsigned long spell, bool heal);

	virtual void ListInventory(CClient *pClient);
	virtual void BuyItem(CClient *pClient, unsigned long nItem, unsigned long nStacked);
	map<char,CItemTemplate *> LootedItems; //slot, item
	bool bMoving;
	bool bAttacking;
	bool bLooted;
	bool bIsTaxi; // used so that there isn't any confusion about this...
	_Location MovingDestLoc;
	_timeb MovingStart;
	float MovingSpeed;
	float MovingDistance;
	CreatureXP XP[10];		// For now this can be expanded later, especially since most creatures wont need >2 or 3
	char PetAction1;
	char PetAction2;
	char PetAction3;
	CPlayer *summoner;
	/*unsigned */short DefaultGossip; // this can be set to -1, so it cannot be unsigned!
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
