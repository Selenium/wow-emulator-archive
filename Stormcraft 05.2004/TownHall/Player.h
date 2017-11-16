#pragma once
#include <sys/timeb.h>
#include "stdafx.h"
#include "WoWObject.h"
#include "UpdateObject.h"
#include "Item.h"

struct _TutorialFlags
{
	char Unknown[0x20];
};

struct _SkillInfo
{
	unsigned short SkillID;
	unsigned short CurrentLevel;
	unsigned short MaxLevel;
	unsigned short Bonus;
	unsigned long Unknown;
};

struct _QuestInfo
{
	unsigned long QuestID;
	unsigned long State;
};

struct PlayerStats
{
	long HitPoints;
	long Mana;
	long Focus;
	long Energy;
	long Rage;

	long Strength;
	long Agility;
	long Stamina;
	long Intellect;
	long Spirit;

	long Armor;
	long ResistHoly;
	long ResistFire;
	long ResistNature;
	long ResistFrost;
	long ResistShadow;
};

// contains ONLY what is saved to disk. NO POINTERS. info that is not to be
// saved should be a member of the class itself... (ex: current target)
struct PlayerData
{
	char Name[15];
	unsigned long Zone;
	unsigned long Continent;
	_Location Loc;
	float Facing;
	float walkspeed;
	float runspeed;
	float swimspeed;
	unsigned char Race;
	unsigned char Class;
	bool Female;
	unsigned char Appearance[5];
	unsigned char Level;
	unsigned long Items[120];// note: theres only 69 total items currently, but we'll keep this 120 in case of expansions etc
	unsigned long Model;
	unsigned long Size;
	unsigned char ManaType; // corresponds to the bar type mana,rage,energy,focus

	_Location BindLoc;
	unsigned long BindContinent;

	PlayerStats NormalStats;
	PlayerStats CurrentStats;

	_TutorialFlags TutorialFlags;

	unsigned long Copper;

	unsigned long DamageMin;
	unsigned long DamageMax;
	long MeleeBonus;
	unsigned long AttackSpeed;

	//long Armor;

	int Exp;
	unsigned long NextLevelExp;
	// for testing
	unsigned char TestCode;
	bool PvP;
	bool RecentPvP;
	bool ResurrectionSickness;// <-- should be a duration or something if its being saved
	BYTE StatusFlags;
	char StatusReason[100];
	unsigned short LFG;

	unsigned long MountModel;
	bool bSummoned;

	unsigned char StandState;
	unsigned char WeaponMode;

	unsigned long TalentPoints;
	unsigned long SkillPoints;

	unsigned long GuildID;
	unsigned long GuildRank;
	unsigned long GuildTimestamp;

	unsigned long PartyID;
	unsigned long PartyRank;

	// keeping extra for future expansion
	_SkillInfo Skills[200]; 
	_QuestInfo Quests[100];
	unsigned long Spells[200];
};

class CPlayer: public CWoWObject, public CUpdateObject
{
	// CUpdateObject funcs
	/*unsigned long AddCreateObjectData(char *buffer);
	void PreCreateObject();
	void PostCreateObject();*/
	unsigned long AddCreateObjectDataNotMe(char *buffer);
	void PreCreateObjectNotMe();
	void PostCreateObjectNotMe();

	unsigned long AddCreateObjectDataOnlyMe(char *buffer);
	void PreCreateObjectOnlyMe();
	void PostCreateObjectOnlyMe();
public:

	void CreateObject(unsigned long guid, bool reset = true) {throw "DO NOT USE CreateObject(guid,reset) on Player objects!";};
	inline void CreateObject(bool reset = true) 
	{
		CUpdateObject::CreateObjectNotMe(guid, false);
		CUpdateObject::CreateObjectOnlyMe(guid, reset);
	};
	inline void CreateObjectNotMe(bool reset = true) {CUpdateObject::CreateObjectNotMe(guid, reset);};
	inline void CreateObjectOnlyMe(bool reset = true) {CUpdateObject::CreateObjectOnlyMe(guid, reset);};
	inline void UpdateObject(bool reset = true) {CUpdateObject::UpdateObject(guid, PLAYERGUID_HIGH, reset);};
	inline void UpdateObjectOnlyMe(bool reset = true) {CUpdateObject::UpdateObjectOnlyMe(guid, PLAYERGUID_HIGH, reset);};
	bool ValidateSpell(long target, short spell);
	void ResetFlags();
	void PvPToggle();
	void RezSickness();
	void Regenerate();
	void UseMana(int type, short id);
	long CalculateDmg(int type, short id, int & flag);
	CPlayer(void);
	~CPlayer(void);

	PlayerData Data;
#ifndef ACCOUNTLESS
	unsigned long AccountID;
#endif
	unsigned long TargetID;
	//unsigned long sitting;
	unsigned long animation;
	_timeb LastAttack;
	void Clear();
	void New(const char *Name, unsigned char *Attributes);
	void Delete();

	float Distance(CPlayer &Player);
	float Distance(class CCreature &Creature);
	float Distance(_Location &Loc);
	
	unsigned long GetCharListData(char *buffer);
	unsigned long GetPlayerInfoData(char *buffer, bool Create=true);
	unsigned long GetOtherPlayerInfoData(char *buffer, bool Create=true);

	void ObjectNears(CWoWObject &Object);
	void ObjectUpdates(CWoWObject &Object);
	void ObjectFades(CWoWObject &Object);

	class CClient *pClient;

	void ProcessEvent(struct WoWEvent &Event);

	void ApplySpellEffect(unsigned long SpellID, unsigned long Effect);
	void sendSpellMsg(long damage, unsigned long spell, bool heal);

	void DestroyItem(int slot);
	inline int GetOpenBackpackSlot();

	void UpdateHP();
	void UpdateHPMP();
	void AddExp(int exp);
};

long getPower(unsigned long spell, unsigned long effect);
