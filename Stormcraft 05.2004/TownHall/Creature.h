#pragma once
#include "stdafx.h"
#include "WoWObject.h"
#include "CreatureTemplate.h"
#include "ItemTemplate.h"
#include <sys/timeb.h>
#include "FlyPath.h"
#include <list>
#include "UpdateObject.h"

#define MAX_MERCHANTITEMS 14*3

struct CreatureXP
{
	long hitguid;
	long dmg;
};

struct MerchantFilter_t
{
	unsigned long subtype[NUM_ITEMTYPES];
	unsigned long minlevel;
	unsigned long maxlevel;
};

struct CreatureData
{
	char Name[64];
	unsigned long SpawnPoint; // creatures with no spawn point will not be saved
	unsigned long Template;
	unsigned long Continent;
	_Location Loc;
	_Location SpawnLoc;
	float Facing;
	float SpawnFacing;

	CreatureStats CurrentStats;
	CreatureStats NormalStats;

	unsigned short DamageMin;
	unsigned short DamageMax;

	unsigned long Size;
	unsigned long Model;
	unsigned long Level;
	unsigned long Exp;

	unsigned long RegenPerTick;
	unsigned long RegenPeriodicity;

	unsigned long ItemTemplates[10];
	unsigned long NPCType;
	unsigned long FactionTemplate;
	MerchantFilter_t MerchantFilter;
};

class CCreature : public CWoWObject, CUpdateObject
{
	unsigned long AddCreateObjectData(char *buffer);
	void PreCreateObject();
	//void PostCreateObject();
public:

	inline void CreateObject(bool reset = true) {CUpdateObject::CreateObject(guid, reset);};
	inline void UpdateObject(bool reset = true) {CUpdateObject::UpdateObject(guid, CREATUREGUID_HIGH, reset);};

	void SendLootablePacket(CPlayer *pPlayer);
	bool LoadingData(ObjectStorage &Storage);
	bool StoringData(ObjectStorage &Storage);
	unsigned long DataStorageSize() {return sizeof(CreatureData);};
	long UpdateLoc();
	void MoveToPPoint(const int pPointID);
	long Move(_Location *loc, float speed);
	void ReSpawn();
	void FollowTarget();
	int MeleeAttack(CPlayer *pPlayer);
	int CastSpell(CPlayer *pPlayer, unsigned short spell);
	void FacePlayer(CPlayer *player);
	void Attack();
	void Move();
	void Regenerate();
	long CalculateDmg(int type, short id, int &flag);
	CCreature(void);
	~CCreature(void);
	
	CreatureTemplateData Template;
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
	void sendSpellMsg(long damage, unsigned long spell, bool heal);

	inline virtual void AddMerchantItem(unsigned long nTemplate)
	{
		if(MerchantInv.size() < MAX_MERCHANTITEMS)
			MerchantInv.push_back(nTemplate);
	};
	virtual void ListInventory(CClient *pClient);
	virtual void BuyItem(CClient *pClient, unsigned long nItem);
	list<unsigned long> MerchantInv;
	bool bMoving;
	bool bAttacking;
	_Location MovingDestLoc;
	_timeb MovingStart;
	float MovingSpeed;
	float MovingDistance;
	unsigned char Test;
	CreatureXP XP[50];
};

long getPower(unsigned long spell, unsigned long effect);

class CFlyPathMob : public CCreature
{
public:
	void New(unsigned long nTemplate)
	{
		CCreature::New(nTemplate);
		Data.NPCType = NPCTYPE_MERCHANT;
		Data.FactionTemplate = 5;
		FlyPaths[STATICITEMS::FLYPATH_ITEM1] = (CFlyPath*)NULL;
		FlyPaths[STATICITEMS::FLYPATH_ITEM2] = (CFlyPath*)NULL;
		FlyPaths[STATICITEMS::FLYPATH_ITEM3] = (CFlyPath*)NULL;
	}
	void New(CCreatureTemplate &NewTemplate) 
	{ 
		CCreature::New(NewTemplate);
		Data.NPCType = NPCTYPE_MERCHANT;
		Data.FactionTemplate = 5;
		FlyPaths[STATICITEMS::FLYPATH_ITEM1] = (CFlyPath*)NULL;
		FlyPaths[STATICITEMS::FLYPATH_ITEM2] = (CFlyPath*)NULL;
		FlyPaths[STATICITEMS::FLYPATH_ITEM3] = (CFlyPath*)NULL;
	};
	void ListInventory(CClient *pClient);
	void BuyItem(CClient *pClient, unsigned long nItem);
	map<unsigned long, CFlyPath*> FlyPaths;
	typedef map<unsigned long, CFlyPath*>::iterator FlyPathsIterator;
};