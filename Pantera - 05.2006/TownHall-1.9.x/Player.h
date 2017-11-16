#ifndef PLAYER_H
#define PLAYER_H

#include <sys/timeb.h>
#include "stdafx.h"
#include "WoWObject.h"
#include "UpdateObject.h"
#include "DataBuffer.h"
#include "Item.h"
#include <list>
#include <deque>
#include <map>
#include "Event.h"
#define FACTION_ARRAY_COUNT 64 // defined in the game in fact as 64 total factions
class CChannel;
struct Combopts
{
	unsigned long pts;
	CWoWObject *target;
};
struct AuraStatMinus
{
	long Str;
	long Ag;
	long Sta;
	long Int;
	long Spi;
	long Armor;
	long HolyRes;
	long FireRes;
	long NatureRes;
	long FrostRes;
	long ShadowRes;
	long ArcaneRes;
};
struct AuraStatBonus
{
	long Str;
	long Ag;
	long Sta;
	long Int;
	long Spi;
	long Armor;
	long HolyRes;
	long FireRes;
	long NatureRes;
	long FrostRes;
	long ShadowRes;
	long ArcaneRes;
};
// Exploration System
struct ExplorationArea
{
	unsigned long areaID;
	unsigned long areaFlag;
	float x1;
	float x2;
	float y1;
	float y2;
};

struct _FactionInfo
{
	// unsigned long ID; // Completely made up.
	// unsigned long ReputationListID; // Index determines this already.
	unsigned char Flags; // shorten to char
	unsigned long Standing;
};

struct _TutorialFlags
{
	unsigned char Unknown[0x20];
};

struct _SkillInfo
{
	unsigned long SkillID;
	unsigned short CurrentLevel;
	unsigned short MaxLevel;
	unsigned short posStatCurrentLevel; //????
	unsigned short posStatMaxLevel;
};

struct _QuestInfo
{
	unsigned long QuestID;
	char State;
	char Rewarded;
};

struct _QuestLogSlot
{
	unsigned long QuestID;
	unsigned long State;
	short QuestMobCount[3];
	short QuestItemCount[3];
	long QuestMobKills[3];
	long Timer;
	long Explored;
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
	long Block;
	long ResistArcane;
	long ResistFire;
	long ResistNature;
	long ResistFrost;
	long ResistShadow;
	long ResistHoly;
};

struct ActionButton
{
	unsigned short action;
	unsigned char type;
	unsigned char misc;
};

struct BuybackItem
{
	unsigned long guid;
	unsigned long SellPrice;
};

// contains ONLY what is saved to disk. NO POINTERS. info that is not to be
// saved should be a member of the class itself... (ex: current target)
struct PlayerData
{
	char Name[15];
	unsigned long Zone;
	unsigned long BindZone;
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
	unsigned long Level;
//	unsigned long Items[120];// note: theres only 69 total items currently, but we'll keep this 120 in case of expansions etc
	CItem* Items[120];// note: theres only 69 total items currently, but we'll keep this 120 in case of expansions etc
	unsigned long Bags[20];	// Point-of-fact: you can have 20 bags (4 in bagslots, 16 in backpack, I think)
//	unsigned long BagItems[120];	// mmm 20 slots per bag x 4 bags this should be more than enough
	CItem* BagItems[120];	// mmm 20 slots per bag x 4 bags this should be more than enough
	unsigned long Model;
	unsigned long BaseModel;
	float Size;
	unsigned char ManaType; // corresponds to the bar type mana,rage,energy,focus
	// int factsize; // bur: this isnt needed anymore
	_Location BindLoc;
	unsigned long BindContinent;
	unsigned long Talents[20];
	unsigned int TalentResetTimes;
	PlayerStats NormalStats;
	PlayerStats CurrentStats;

	_TutorialFlags TutorialFlags;

	unsigned long Copper;

	float DamageMin;
	float DamageMax;
	unsigned long AttackSpeed;
	unsigned long MeleeWeaponSkillID;

	float RangedDamageMin;
	float RangedDamageMax;
	unsigned long RangedAttackSpeed;
	unsigned long RangedWeaponSkillID;

	float CritPct;

	//long Armor;

	int Exp;
	int NextLevelExp;
	bool PvP;
	bool RecentPvP;
	bool ResurrectionSickness;// <-- should be a duration or something if its being saved
	unsigned long StatusFlags;
	float RestAmount;
	BYTE RestState;
	BYTE DrunkState;
	BYTE PvPRank;
	char StatusReason[100];
	unsigned short LFG;

	unsigned long MountModel;
	bool bSummoned;

	_Location CorpseLoc;
	bool bDead;

	unsigned char StandState;
	unsigned char MorphState;
	unsigned char WeaponMode;
	//This is never used O.o
	//unsigned long TalentPoints;
	unsigned long SkillPoints;

	unsigned long GuildID;
	unsigned long GuildRank;
	unsigned long GuildTimestamp;
	char GuildPublicNote[256];
	char GuildOfficerNote[256];
	_FactionInfo factionlist[FACTION_ARRAY_COUNT];
	unsigned long PartyID;
	unsigned long PartyRank;

	// keeping extra for future expansion
	_SkillInfo Skills[140];
	unsigned long QuestCounter;
	_QuestInfo Quests[1000]; // 1000 quests seems about right. If it is insufficient
	// we can use a different loading system.
	_QuestLogSlot QuestLogSlots[19];
	unsigned long KnownTaxiNodes[8];
	short UsedTalentPoints;
	unsigned long Spells[200];
	unsigned long Friends[50];
	unsigned long ExtFriends[200]; //people who have me on their friends
	unsigned long Ignore[50];
	unsigned long ExtIgnore[200]; //people who have ignored me
	ActionButton ActionButtons[120];
	unsigned char PlayedIntro;
	unsigned long LastLogon;
	unsigned char AccountData0[300];
	unsigned char AccountData1[1200];
	unsigned char AccountData2[300];
	unsigned char AccountData3[300];
	unsigned char AccountData4[1350];
	unsigned short AccountDataLen[5];
	unsigned long ExploredZones[64];
};
struct _AuraSlot
{
	unsigned long auraid;
	unsigned long spellid;
	unsigned long appliation;
	unsigned long flags;
	unsigned long state;
};

class CPlayer: public CWoWObject, public CUpdateObject
{
	// CUpdateObject funcs
	unsigned long AddCreateObjectDataNotMe(char *buffer);
	void PreCreateObjectNotMe();
	void PostCreateObjectNotMe();

	unsigned long AddCreateObjectDataOnlyMe(char *buffer);
	void PreCreateObjectOnlyMe();
	void PostCreateObjectOnlyMe();
public:
	void DuelPrepare(unsigned long gd);
	void DuelRequest();
	void DuelTimer(CPlayer* dhost,CPlayer* tduel,unsigned long dguid);
	void TalentResetInitiate();
	unsigned long CalcTalentResetCost(unsigned long resetnum);
	static void AcceptDuel(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void CancelDuel(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	void BindInitiate();
	static void MsgTalentReset(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	void CreateObject(unsigned long guid, bool reset = true) {throw "DO NOT USE CreateObject(guid,reset) on Player objects!";};
	inline void CreateObject(bool reset = true)
	{
		CUpdateObject::CreateObjectNotMe(guid, false);
		CUpdateObject::CreateObjectOnlyMe(guid, reset);
	};
	inline void CreateObjectNotMe(bool reset = true) {CUpdateObject::CreateObjectNotMe(guid, reset);};
	inline void CreateObjectOnlyMe(bool reset = true) {CUpdateObject::CreateObjectOnlyMe(guid, reset);};
	inline void UpdateObject(bool reset = true) {CUpdateObject::UpdateObject(guid, PLAYERGUID_HIGH, reset);};
	inline void UpdateObjectNotMe(bool reset = true) {CUpdateObject::UpdateObjectNotMe(guid, PLAYERGUID_HIGH, reset);};
	inline void UpdateObjectOnlyMe(bool reset = true) {CUpdateObject::UpdateObjectOnlyMe(guid, PLAYERGUID_HIGH, reset);};
	bool ValidateSpell(long target, unsigned long spell);
	void SetAura(unsigned long slot, unsigned long auraid, unsigned long spellid, unsigned long application, unsigned long flags, unsigned long state);
	void RemoveAura(unsigned long slot);
	unsigned long FindFreeAuraSlot(bool positive);
	long FindFreeRestoreAuraSlot();
	unsigned long MountedAuraSlot;
	unsigned long SummonGuid;
	/*
	UNIT_FIELD_AURA                         =   47,  //  64 AURA
	UNIT_FIELD_AURAFLAGS                    =  111,  //  8  AURAFLAGS
	UNIT_FIELD_AURALEVELS                   =  119,  //  8  AURALEVELS
	UNIT_FIELD_AURAAPPLICATIONS             =  127,  //  16 AURAAPPLICATIONS
	UNIT_FIELD_AURASTATE                    =  143,  //  1  UINT32
	*/

	unsigned long Field_Aura[64];
	unsigned long Field_AuraFlags[8];
	unsigned long Field_AuraLevels[8];
	unsigned long Field_AuraApplications[16];
	unsigned long Field_AuraState;
	AuraStatBonus abonus;
	AuraStatMinus aminus;
	_Modifier Modifiers[192];
	int GetFreeModSlot();
	void AddModifier(_Modifier mod);
	void RemoveModifier(unsigned long SpellID);
	void ApplyModifier(_Modifier mod);
	void AddNextAttackSpell(CSpell *pSpell,CDataBuffer* data);
	void ClearNextAttackSpell();
	CSpell *NextAttackSpell;
	CDataBuffer *NextAttackData;
	void AddComboPt(CWoWObject*);
	void ResetCombo();
	Combopts combo;
	void StartChannel(unsigned long spellid,unsigned long duration,unsigned long Target);
	void StopChannel(unsigned long spellid);
	_RestoreAura RestoreAuras[5];
	void SendSpellLog(unsigned long power,unsigned long spellid,unsigned long EffectID,CWoWObject * Caster,CWoWObject * Target);
	void SendPeriodicLog(unsigned long power,unsigned long spellid,unsigned long EffectID,unsigned long School,CWoWObject * Caster,CWoWObject * Target);
	void ResetAllAuras();
	std::list<ExplorationArea> ExploreAreas;
	void ResetFlags();
	void PvPToggle();
	void RezSickness();
	void Regenerate();
	void DeathDurabilityLoss();
	void UseMana(int type, unsigned long id);
	long CalculateDmg(int type, short id, int & flag, int &victimflags);
	long FindOpenQuestSlot();
	inline void ClearQuestLogSlot(unsigned long slotnumber) { memset(&Data.QuestLogSlots[slotnumber],0,sizeof(_QuestLogSlot)); };
	bool Save(FILE *fout);
	bool Load(FILE *fin,unsigned long guid,bool createflag=true);
	void SetSpeed(float speed);
	void SetSwimSpeed(float speed);
	bool bIsFlying;
	bool canbreathe;
	CPlayer(void);
	~CPlayer(void);
	void UpdateReputation(int id);
	int SetFaction();
	void GenerateFactions();
	void DuelTick();
	PlayerData Data;
	long FTeam;
	long FFaction;
#ifndef ACCOUNTLESS
	unsigned long AccountID;
#endif
	unsigned long TargetID;
	unsigned long LootID;
	float SwimStartHeight;
	unsigned long Breath;
	char BreathingAir;

	/*********DUEL************/
	unsigned long DuelGuid;
	unsigned long DGuid2;
	int dueltick;
	CPlayer *duelhost;
	CPlayer *duelpartner;
	_Location dloc;
	bool duelstarted,stopd,inbounds;
	/*************************/
	//unsigned long sitting;
	bool InCombat;
	_timeb LastAttack;
	std::list<CChannel*> m_channels;
	std::deque<BuybackItem> BuybackItems;
	std::list<CMail*> Mails;
	bool EnableAllQuests;
	void Clear();
	void New(const char *Name, unsigned char *Attributes);
	void Delete();

	float Distance(CPlayer &Player);
	float Distance(class CCreature &Creature);
	float Distance(_Location &Loc);

	void AddSkill(unsigned long SkillID, short CurrentLevel, short MaxLevel, bool Update=true);
	void LevelUpSkill(unsigned long SkillID);
	void LevelUpSkillInCombat(unsigned long SkillID);
	void UpdateSkills(bool Create);
	_SkillInfo *GetSkill(unsigned long SkillID);

	void JoinedChannel(CChannel *c) { m_channels.push_back(c); }
	void LeftChannel(CChannel *c) { m_channels.remove(c); }

	unsigned long GetCharListData(char *buffer);
	unsigned long GetPlayerInfoData(char *buffer, bool Self, bool Create=true);
	void LoadExploreSystem(void);
	void CheckForNewArea(void);
	void ObjectNears(CWoWObject &Object);
	void ObjectUpdates(CWoWObject &Object);
	void ObjectFades(CWoWObject &Object);

	class CClient *pClient;
	class CSpell *pCurrentSpell;
	void InitAEvents();
	void ProcessEvent(struct WoWEvent &Event);
	AuraEvent* avent[64];
	void ApplySpellEffect(unsigned long SpellID, unsigned long Effect);
	void sendSpellMsg(long damage, unsigned long spell, bool heal);
	void TakeDamage(CCreature *pCreature, unsigned long dmg, bool spelldmg);

	void HandleSpellEffects(CSpell *pSpell,unsigned long Effect);

	void DestroyItem(int slot);
	int GetOpenBackpackSlot();
	void EndDuel();
	void DuelFlee();
	void CreateGhost();
	void CreateCorpse();
	void SendResurrectRequest();
	void Resurrect();
	unsigned long Corpse;

	bool IsFacing(CCreature *pCreature);
	void RecomputeAllStats(void);
	void AddExp(int exp);
	unsigned long AttackPower(void);
	unsigned long AttackPowerBonus(void) { return AttackPower()*Data.AttackSpeed/14000; /*14000 = 14 for conversion, 1000 for millisec*/ }
	unsigned long RangedAttackPower(void);
	unsigned long RangedAttackPowerBonus(void) { return RangedAttackPower()*Data.RangedAttackSpeed/14000; /*14000 = 14 for conversion, 1000 for millisec*/ }
	void CheckForSkillUpdate(bool fromvictim);
	unsigned long GetWeaponSkill(CItem *pItem);
	class CPlayerDataObject
	{
	public:
		CPlayer *pObject;
#define ADDLONG(name, updateVal, saveto) \
	inline void name(long val)\
		{\
		saveto = val;\
		pObject->AddUpdateVal(updateVal, val);\
		}
#define ADDULONG(name, updateVal, saveto) \
	inline void name(unsigned long val)\
		{\
		saveto = val;\
		pObject->AddUpdateVal(updateVal, val);\
		}
#define ADDFLOAT(name, updateVal, saveto) \
	inline void name(float val)\
		{\
		saveto = val;\
		pObject->AddUpdateVal(updateVal, val);\
		}
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

		ADDFLOAT(SetSize, OBJECT_FIELD_SCALE_X, pObject->Data.Size);

		ADDLONG(SetHP, UNIT_FIELD_HEALTH, pObject->Data.CurrentStats.HitPoints);
		ADDLONG(SetMana, UNIT_FIELD_POWER1, pObject->Data.CurrentStats.Mana);
		ADDLONG(SetRage, UNIT_FIELD_POWER2, pObject->Data.CurrentStats.Rage);
		ADDLONG(SetFocus, UNIT_FIELD_POWER3, pObject->Data.CurrentStats.Focus);
		ADDLONG(SetEnergy, UNIT_FIELD_POWER4, pObject->Data.CurrentStats.Energy);

		ADDINCLONG(AddHP, UNIT_FIELD_HEALTH, pObject->Data.CurrentStats.HitPoints, pObject->Data.NormalStats.HitPoints);
		ADDINCLONG(AddMana, UNIT_FIELD_POWER1, pObject->Data.CurrentStats.Mana, pObject->Data.NormalStats.Mana);
		ADDINCLONG(AddRage, UNIT_FIELD_POWER2, pObject->Data.CurrentStats.Rage, pObject->Data.NormalStats.Rage);
		ADDINCLONG(AddFocus, UNIT_FIELD_POWER3, pObject->Data.CurrentStats.Focus, pObject->Data.NormalStats.Focus);
		ADDINCLONG(AddEnergy, UNIT_FIELD_POWER4, pObject->Data.CurrentStats.Energy, pObject->Data.NormalStats.Energy);

		ADDLONG(SetMaxHP, UNIT_FIELD_MAXHEALTH, pObject->Data.NormalStats.HitPoints);
		ADDLONG(SetMaxMana, UNIT_FIELD_MAXPOWER1, pObject->Data.NormalStats.Mana);
		ADDLONG(SetMaxRage, UNIT_FIELD_MAXPOWER2, pObject->Data.NormalStats.Rage);
		ADDLONG(SetMaxFocus, UNIT_FIELD_MAXPOWER3, pObject->Data.NormalStats.Focus);
		ADDLONG(SetMaxEnergy, UNIT_FIELD_MAXPOWER4, pObject->Data.NormalStats.Energy);

		ADDINCLONG2(AddMaxHP, UNIT_FIELD_MAXHEALTH, pObject->Data.NormalStats.HitPoints);
		ADDINCLONG2(AddMaxMana, UNIT_FIELD_MAXPOWER1, pObject->Data.NormalStats.Mana);
		ADDINCLONG2(AddMaxRage, UNIT_FIELD_MAXPOWER2, pObject->Data.NormalStats.Rage);
		ADDINCLONG2(AddMaxFocus, UNIT_FIELD_MAXPOWER3, pObject->Data.NormalStats.Focus);
		ADDINCLONG2(AddMaxEnergy, UNIT_FIELD_MAXPOWER4, pObject->Data.NormalStats.Energy);

		ADDULONG(SetLevel, UNIT_FIELD_LEVEL, pObject->Data.Level);

		ADDLONG(SetArmor, UNIT_FIELD_RESISTANCES, pObject->Data.CurrentStats.Armor);
		ADDLONG(SetFireRes, UNIT_FIELD_RESISTANCES+2, pObject->Data.CurrentStats.ResistFire);
		ADDLONG(SetNatureRes, UNIT_FIELD_RESISTANCES+3, pObject->Data.CurrentStats.ResistNature);
		ADDLONG(SetFrostRes, UNIT_FIELD_RESISTANCES+4, pObject->Data.CurrentStats.ResistFrost);
		ADDLONG(SetShadowRes, UNIT_FIELD_RESISTANCES+5, pObject->Data.CurrentStats.ResistShadow);

		ADDLONG(SetStrength, UNIT_FIELD_STAT0, pObject->Data.CurrentStats.Strength);
		ADDLONG(SetAgility, UNIT_FIELD_STAT1, pObject->Data.CurrentStats.Agility);
		ADDLONG(SetStamina, UNIT_FIELD_STAT2, pObject->Data.CurrentStats.Stamina);
		ADDLONG(SetIntellect, UNIT_FIELD_STAT3, pObject->Data.CurrentStats.Intellect);
		ADDLONG(SetSpirit, UNIT_FIELD_STAT4, pObject->Data.CurrentStats.Spirit);

		ADDINCLONG2(AddStrength, UNIT_FIELD_STAT0, pObject->Data.CurrentStats.Strength);
		ADDINCLONG2(AddAgility, UNIT_FIELD_STAT1, pObject->Data.CurrentStats.Agility);
		ADDINCLONG2(AddStamina, UNIT_FIELD_STAT2, pObject->Data.CurrentStats.Stamina);
		ADDINCLONG2(AddIntellect, UNIT_FIELD_STAT3, pObject->Data.CurrentStats.Intellect);
		ADDINCLONG2(AddSpirit, UNIT_FIELD_STAT4, pObject->Data.CurrentStats.Spirit);

		ADDFLOAT(SetCritPct, PLAYER_CRIT_PERCENTAGE, pObject->Data.CritPct);

		//ADDULONG(SetAttackSpeed, UNIT_FIELD_BASEATTACKTIME, pObject->Data.DamageMin);
		inline void SetAttackSpeed(unsigned long val)
		{
			pObject->Data.AttackSpeed = val;
			pObject->AddUpdateVal(UNIT_FIELD_BASEATTACKTIME, val);
			pObject->AddUpdateVal(UNIT_FIELD_BASEATTACKTIME+1, val);
		}
		//ADDFLOAT(SetMinDamage, UNIT_FIELD_MINDAMAGE, pObject->Data.DamageMin);
		//ADDFLOAT(SetMaxDamage, UNIT_FIELD_MAXDAMAGE, pObject->Data.DamageMax);
		inline void SetMinDamage(float val)
		{
			pObject->Data.DamageMin = val;
			pObject->AddUpdateVal(UNIT_FIELD_MINDAMAGE, val+(float)pObject->AttackPowerBonus());
		}
		inline void SetMaxDamage(float val)
		{
			pObject->Data.DamageMax = val;
			pObject->AddUpdateVal(UNIT_FIELD_MAXDAMAGE, val+(float)pObject->AttackPowerBonus());
		}

		inline void SetRangedAttackSpeed(unsigned long val)
		{
			pObject->Data.RangedAttackSpeed = val;
			pObject->AddUpdateVal(UNIT_FIELD_RANGEDATTACKTIME, val);
		}
		inline void SetRangedMinDamage(float val)
		{
			pObject->Data.RangedDamageMin = val;
			pObject->AddUpdateVal(UNIT_FIELD_MINRANGEDDAMAGE, val+(float)pObject->RangedAttackPowerBonus());
		}
		inline void SetRangedMaxDamage(float val)
		{
			pObject->Data.RangedDamageMax = val;
			pObject->AddUpdateVal(UNIT_FIELD_MAXRANGEDDAMAGE, val+(float)pObject->RangedAttackPowerBonus());
		}

		ADDULONG(SetModel, UNIT_FIELD_DISPLAYID, pObject->Data.Model);
		ADDULONG(SetCoinage, PLAYER_FIELD_COINAGE, pObject->Data.Copper);

		inline void SetMountModel(unsigned long model)
		{
			if(model != pObject->Data.MountModel)
			{
				pObject->Data.MountModel = model;
				pObject->AddUpdateVal(UNIT_FIELD_MOUNTDISPLAYID, model);
				if(model)
					pObject->AddUpdateVal(UNIT_FIELD_FLAGS, UNIT_FLAG_MOUNT | UNIT_FLAG_MOUNT_ICON | UNIT_FLAG_SWIM | UNIT_FLAG_SHEATHE);
				else
					pObject->AddUpdateVal(UNIT_FIELD_FLAGS, UNIT_FLAG_SWIM | UNIT_FLAG_SHEATHE | 0x1008);
				pObject->bSheathed = true;
			}
		};

		inline void SetStatusFlags(unsigned long flags)
		{
			pObject->Data.StatusFlags = flags;
			pObject->AddUpdateVal(PLAYER_FLAGS, pObject->Data.StatusFlags);
		};

		inline unsigned long GetStatusFlags()
		{
			return pObject->Data.StatusFlags;
		};

		inline void SetRestState(BYTE newState)
		{
			pObject->Data.RestState = newState;
			pObject->AddUpdateVal(PLAYER_BYTES_2, (pObject->Data.RestState << 24) | (unsigned char)(pObject->Data.StatusFlags & 0xFF) | (pObject->Data.Appearance[4] << 8));
		};

		inline void SetPvPRank(BYTE newRank)
		{
			pObject->Data.PvPRank = newRank;
			pObject->AddUpdateVal(PLAYER_BYTES_3, (char)(pObject->Data.Female) | (pObject->Data.DrunkState << 8) | (pObject->Data.PvPRank << 24));
		};

		inline void SetDrunkState(BYTE newDrunkenness)
		{
			pObject->Data.DrunkState = newDrunkenness;
			pObject->AddUpdateVal(PLAYER_BYTES_3, (char)(pObject->Data.Female) | (pObject->Data.DrunkState << 8) | (pObject->Data.PvPRank << 24));
		};

		inline void SetFlag(unsigned long flag)
		{
			pObject->Data.StatusFlags |= flag;
			pObject->AddUpdateVal(PLAYER_FLAGS, pObject->Data.StatusFlags);
		};

		inline void ClearFlag(unsigned long flag)
		{
			pObject->Data.StatusFlags &= (~flag);
			pObject->AddUpdateVal(PLAYER_FLAGS, pObject->Data.StatusFlags);
		};

		inline void ToggleFlag(unsigned long flag)
		{
			pObject->Data.StatusFlags ^= flag;
			pObject->AddUpdateVal(PLAYER_FLAGS, pObject->Data.StatusFlags);
		};

		inline void SetStandState(unsigned long state)
		{
			pObject->Data.StandState = (unsigned char)state & 0xF;
			pObject->AddUpdateVal(UNIT_FIELD_BYTES_1, (pObject->Data.WeaponMode << 24) | (pObject->Data.MorphState << 16) | pObject->Data.StandState);
		};

		inline void SetMorphState(unsigned long state)
		{
			pObject->Data.MorphState = (unsigned char)state;
			pObject->AddUpdateVal(UNIT_FIELD_BYTES_1, (pObject->Data.WeaponMode << 24) | (pObject->Data.MorphState << 16) | pObject->Data.StandState);
		};

		inline void SetWeaponMode(unsigned long mode)
		{
			pObject->Data.WeaponMode = (unsigned char)mode;
			pObject->AddUpdateVal(UNIT_FIELD_BYTES_1, (pObject->Data.WeaponMode << 24) | (pObject->Data.MorphState << 16) | pObject->Data.StandState);
		};
/*
		inline void SetItem(int slot, unsigned long guid)
		{
			pObject->Data.Items[slot] = guid;
			pObject->AddUpdateVal(PLAYER_FIELD_INV_SLOT_HEAD+slot*2, guid, guid ? ITEMGUID_HIGH : 0);
			if (slot < 19)
			{
				if (guid!=0)
				{
					CItem *pItem = NULL;
					if (DataManager.RetrieveObject((CWoWObject**)&pItem, pObject->Data.Items[slot]))
						pObject->AddUpdateVal(PLAYER_VISIBLE_ITEM_1_0+slot*12, pItem->Data.nItemTemplate);
					else
						pObject->AddUpdateVal(PLAYER_VISIBLE_ITEM_1_0+slot*12, 0);
				}
				else
				{
					pObject->AddUpdateVal(PLAYER_VISIBLE_ITEM_1_0+slot*12, 0);
				}
			}
		};*/

		inline void SetItem(int slot, CItem *const pItem)
		{
			unsigned long ItemGuid = pItem ? pItem->guid : 0;
			pObject->Data.Items[slot] = pItem;
			pObject->AddUpdateVal(PLAYER_FIELD_INV_SLOT_HEAD+slot*2, ItemGuid, ItemGuid ? ITEMGUID_HIGH : 0);
			if (slot < 19)
			{
				if (ItemGuid!=0)
				{
//					CItem *pItem = NULL;
//					if (DataManager.RetrieveObject((CWoWObject**)&pItem, pObject->Data.Items[slot]))
					if (pItem)
						pObject->AddUpdateVal(PLAYER_VISIBLE_ITEM_1_0+slot*12, pItem->Data.nItemTemplate);
					else
						pObject->AddUpdateVal(PLAYER_VISIBLE_ITEM_1_0+slot*12, 0);
				}
				else
				{
					pObject->AddUpdateVal(PLAYER_VISIBLE_ITEM_1_0+slot*12, 0);
				}
			}
		}

		inline void SetBagItem(const int slot, CItem *const pItem)
		{
			unsigned long ItemGuid = pItem ? pItem->guid : 0;
			pObject->Data.BagItems[slot] = pItem;
//			pObject->AddUpdateVal(PLAYER_FIELD_INV_SLOT_HEAD+slot*2, ItemGuid, ItemGuid ? ITEMGUID_HIGH : 0);
		}

		static inline unsigned char GetBagItemSlot(unsigned char bag, unsigned char bagSlot){
			return bagSlot + 20*(bag - SLOT_BAG1);
		}

		ADDLONG(SetXP, PLAYER_XP, pObject->Data.Exp);
		ADDLONG(SetNextLevelXP, PLAYER_NEXT_LEVEL_XP, pObject->Data.NextLevelExp);

		ADDINCLONG2(AddXP, PLAYER_XP, pObject->Data.Exp);
		ADDINCLONG2(AddNextLevelXP, PLAYER_NEXT_LEVEL_XP, pObject->Data.NextLevelExp);
		inline void SetRestAmount(float val)
		{
			pObject->Data.RestAmount=val;
			pObject->AddUpdateVal(PLAYER_REST_STATE_EXPERIENCE, (unsigned long)val);
		}
		inline void AddRestAmount(float val)
		{
			pObject->Data.RestAmount+=val;
			pObject->AddUpdateVal(PLAYER_REST_STATE_EXPERIENCE, (unsigned long)pObject->Data.RestAmount);
		}

		ADDULONG(SetGuildID, PLAYER_GUILDID, pObject->Data.GuildID);
		ADDULONG(SetGuildRank, PLAYER_GUILDRANK, pObject->Data.GuildRank);
		ADDULONG(SetGuildTimestamp, PLAYER_GUILD_TIMESTAMP, pObject->Data.GuildTimestamp);
		// to be used with UpdateObjectNotMe
		inline void TogglePVP()
		{
			SetStatusFlags(GetStatusFlags() ^ STATUS_PVP);
			pObject->Data.PvP = !pObject->Data.PvP;
			pObject->Data.RecentPvP = true;
			// pObject->AddUpdateVal(UNIT_FIELD_FACTIONTEMPLATE, !pObject->Data.PvP || pObject->Data.ResurrectionSickness ? 5 : 1);
		};
		inline void SetFaction(long val) {
			pObject->AddUpdateVal(UNIT_FIELD_FACTIONTEMPLATE, val);
		};
#undef ADDINCLONG
#undef ADDLONG
#undef ADDULONG
#undef ADDFLOAT
	};
	CPlayerDataObject DataObject;
	bool isregenning;
	bool IsCasting;
	unsigned long summonedCont;
	_Location summonedLoc;
	unsigned long tradingWith;
	int tradeNum;
	int tradeGold;
	int tradeState;
	int tradeItems[7];
	bool tradeAccepted;
	bool inTrade;
	bool bSheathed;
	unsigned long AddSetItem(CItemTemplate *pTemplate, unsigned int count);
	unsigned int AddItem(ItemTemplateData &pItemTemplateData, unsigned int count);
};

long getPower(unsigned long spell, unsigned long effect);

#endif // PLAYER_H
