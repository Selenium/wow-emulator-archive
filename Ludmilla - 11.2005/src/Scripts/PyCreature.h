#pragma once

class Player;
class Creature;
class Unit;


///////////////////////////////////////////////////////////////////////////////
//
//
class PyUnit: public Py::PythonExtension<PyUnit>
{
protected:
	Unit * m_obj;

public:
	PyUnit (Unit *un) { m_obj = un; }
	virtual ~PyUnit() {}

	static void init_type(void);

	Unit * GetUnit() { return m_obj; }
	
	Creature * GetCreature() {
		if (m_obj->isUnit())
			return (Creature *)m_obj;
		return NULL;
	}
	
	Player * GetPlayer() {
		if (m_obj->isPlayer())
			return (Player *)m_obj;
		return NULL;
	}

	//----------------------------------------------
	Py::Object ext_CanReachWithAttack (const Py::Tuple& args);

	Py::Object ext_GetLevel (const Py::Tuple& args);
	Py::Object ext_SetLevel (const Py::Tuple& args);

	Py::Object ext_GetRace (const Py::Tuple& args);
	Py::Object ext_GetClass (const Py::Tuple& args);
	Py::Object ext_GetGender (const Py::Tuple& args);

	Py::Object ext_ClearQuestMenu (const Py::Tuple& args);
	Py::Object ext_ClearGossipMenu (const Py::Tuple& args);
	Py::Object ext_SendGossipMenu (const Py::Tuple& args);
	Py::Object ext_SetQuestMenuTitle (const Py::Tuple& args);
	Py::Object ext_AddGossipItem (const Py::Tuple& args);
	Py::Object ext_AddCodedGossipItem (const Py::Tuple& args);
	Py::Object ext_AddNPCQuests (const Py::Tuple& args);
	Py::Object ext_AddAvailableQuest (const Py::Tuple& args);
	Py::Object ext_AddCurrentQuest (const Py::Tuple& args);
	Py::Object ext_GetNPCQuestDialogStatus (const Py::Tuple& args);


	Py::Object ext_IsVendor (const Py::Tuple& args);
	Py::Object ext_IsTrainer (const Py::Tuple& args);
	Py::Object ext_IsGossip (const Py::Tuple& args);
	Py::Object ext_IsQuestGiver (const Py::Tuple& args);
	Py::Object ext_IsTaxi (const Py::Tuple& args);
	Py::Object ext_IsGuildMaster (const Py::Tuple& args);
	Py::Object ext_IsBattleMaster (const Py::Tuple& args);
	Py::Object ext_IsBanker (const Py::Tuple& args);
	Py::Object ext_IsInnkeeper (const Py::Tuple& args);
	Py::Object ext_IsSpiritHealer (const Py::Tuple& args);
	Py::Object ext_IsTabardVendor (const Py::Tuple& args);
	Py::Object ext_IsAuctioner (const Py::Tuple& args);
	Py::Object ext_IsArmorer (const Py::Tuple& args);
	Py::Object ext_SendQuestDetails (const Py::Tuple& args);

	Py::Object ext_QuestComplete (const Py::Tuple& args);
	Py::Object ext_QuestTakable (const Py::Tuple& args);
	Py::Object ext_HasQuest (const Py::Tuple& args);

	Py::Object ext_SendQuestReward (const Py::Tuple& args);
	Py::Object ext_SendQuestRequiredItems (const Py::Tuple& args);

	Py::Object ext_GetFollowingQuest (const Py::Tuple& args);
	Py::Object ext_CloseGossipWindow (const Py::Tuple& args);

	Py::Object ext_finishExplorationQuest (const Py::Tuple& args);

	Py::Object ext_SendVendorList (const Py::Tuple& args);
	Py::Object ext_SendTrainerList (const Py::Tuple& args);
	Py::Object ext_SendTaxiList (const Py::Tuple& args);
	Py::Object ext_SendPetitionList (const Py::Tuple& args);
	Py::Object ext_SendBattleList (const Py::Tuple& args);
	Py::Object ext_SendBankerList (const Py::Tuple& args);
	Py::Object ext_SendInnkeeperList (const Py::Tuple& args);
	Py::Object ext_SendSpiritHealerList (const Py::Tuple& args);
	Py::Object ext_SendTabardList (const Py::Tuple& args);
	Py::Object ext_SendAuctionerList (const Py::Tuple& args);

	Py::Object ext_HasSellTables (const Py::Tuple& args);
	Py::Object ext_SelectById (const Py::Tuple& args);
	Py::Object ext_SendPOI (const Py::Tuple& args);

	Py::Object ext_GetStoredNPCText (const Py::Tuple& args);
	Py::Object ext_GetStoredText (const Py::Tuple& args);
	Py::Object ext_SendSystemMessage (const Py::Tuple& args);
	Py::Object ext_ManageGOQuests (const Py::Tuple& args);

#define DECLARE_GET_MODIFY_SET(PropName) \
	Py::Object ext_Get##PropName (const Py::Tuple& args); \
	Py::Object ext_Modify##PropName (const Py::Tuple& args); \
	Py::Object ext_Set##PropName (const Py::Tuple& args);

	DECLARE_GET_MODIFY_SET(Strength);
	DECLARE_GET_MODIFY_SET(Agility);
	DECLARE_GET_MODIFY_SET(Stamina);
	DECLARE_GET_MODIFY_SET(Intellect);
	DECLARE_GET_MODIFY_SET(Spirit);

	DECLARE_GET_MODIFY_SET(PosStrength);
	DECLARE_GET_MODIFY_SET(PosAgility);
	DECLARE_GET_MODIFY_SET(PosStamina);
	DECLARE_GET_MODIFY_SET(PosIntellect);
	DECLARE_GET_MODIFY_SET(PosSpirit);

	DECLARE_GET_MODIFY_SET(NegStrength);
	DECLARE_GET_MODIFY_SET(NegAgility);
	DECLARE_GET_MODIFY_SET(NegStamina);
	DECLARE_GET_MODIFY_SET(NegIntellect);
	DECLARE_GET_MODIFY_SET(NegSpirit);

	DECLARE_GET_MODIFY_SET(Health);
	DECLARE_GET_MODIFY_SET(Mana);
	DECLARE_GET_MODIFY_SET(Rage);
	DECLARE_GET_MODIFY_SET(Focus);
	DECLARE_GET_MODIFY_SET(Energy);

	DECLARE_GET_MODIFY_SET(MaxHealth);
	DECLARE_GET_MODIFY_SET(MaxMana);
	DECLARE_GET_MODIFY_SET(MaxRage);
	DECLARE_GET_MODIFY_SET(MaxFocus);
	DECLARE_GET_MODIFY_SET(MaxEnergy);

	DECLARE_GET_MODIFY_SET(Armor);
	DECLARE_GET_MODIFY_SET(HolyResist);
	DECLARE_GET_MODIFY_SET(FireResist);
	DECLARE_GET_MODIFY_SET(NatureResist);
	DECLARE_GET_MODIFY_SET(FrostResist);
	DECLARE_GET_MODIFY_SET(ShadowResist);
	DECLARE_GET_MODIFY_SET(ArcaneResist);

	DECLARE_GET_MODIFY_SET(CritChance);
	DECLARE_GET_MODIFY_SET(DodgeChance);
	DECLARE_GET_MODIFY_SET(ParryChance);
	DECLARE_GET_MODIFY_SET(BlockChance);

	DECLARE_GET_MODIFY_SET(AttackPower);
	DECLARE_GET_MODIFY_SET(RangedAttackPower);
	DECLARE_GET_MODIFY_SET(MinDamage);
	DECLARE_GET_MODIFY_SET(MaxDamage);

	Py::Object ext_WalkTo (const Py::Tuple& args);
	Py::Object ext_RunTo (const Py::Tuple& args);
	Py::Object ext_Flee (const Py::Tuple& args);
	Py::Object ext_NextThink (const Py::Tuple& args);

	Py::Object ext_MovementType (const Py::Tuple& args);
	Py::Object ext_RunFlag (const Py::Tuple& args);
	Py::Object ext_CurrentWaypoint (const Py::Tuple& args);
	Py::Object ext_CallAtWaypoint (const Py::Tuple& args);
	
	Py::Object ext_AddHate (const Py::Tuple& args);
	Py::Object ext_GetHate (const Py::Tuple& args);
	Py::Object ext_RemoveHate (const Py::Tuple& args);
	Py::Object ext_ClearHate (const Py::Tuple& args);

	Py::Object ext_Say (const Py::Tuple& args);
	Py::Object ext_Emote (const Py::Tuple& args);
	Py::Object ext_TextEmote (const Py::Tuple& args);
	Py::Object ext_Equip (const Py::Tuple& args);

	Py::Object ext_GetXYZ (const Py::Tuple& args);
	Py::Object ext_IsPlayer (const Py::Tuple& args);
	Py::Object ext_IsNPC (const Py::Tuple& args);

	Py::Object ext_AddSpell (const Py::Tuple& args);
	Py::Object ext_HasSpell (const Py::Tuple& args);
	Py::Object ext_RemoveSpell (const Py::Tuple& args);
	Py::Object ext_GetSkill (const Py::Tuple& args);
	Py::Object ext_SetSkill (const Py::Tuple& args);
	Py::Object ext_PlayerModel (const Py::Tuple& args);
	Py::Object ext_StartupLocation (const Py::Tuple& args);
	Py::Object ext_GetFaction (const Py::Tuple& args);
	Py::Object ext_SetFaction (const Py::Tuple& args);
	Py::Object ext_GetReputation (const Py::Tuple& args);
	Py::Object ext_SetReputation (const Py::Tuple& args);
	Py::Object ext_GetReputationValue (const Py::Tuple& args);
	Py::Object ext_SetReputationValue (const Py::Tuple& args);

	Py::Object ext_SetActionButton (const Py::Tuple& args);
	Py::Object ext_GetSlotByItemID (const Py::Tuple& args);

	Py::Object ext_AddItemToSlot (const Py::Tuple& args);
	Py::Object ext_SetAmmoSlot (const Py::Tuple& args);

	Py::Object ext_GetEntry (const Py::Tuple& args);
	Py::Object ext_GetNpcFlags (const Py::Tuple& args);
	Py::Object ext_SetNpcFlags (const Py::Tuple& args);
	Py::Object ext_GetElite (const Py::Tuple& args);
	Py::Object ext_GetNpcType (const Py::Tuple& args);
	Py::Object ext_GetMinDmg (const Py::Tuple& args);
	Py::Object ext_GetMaxDmg (const Py::Tuple& args);
	Py::Object ext_GetSize (const Py::Tuple& args);

	// Player
	Py::Object ext_isArmed (const Py::Tuple& args);

	// Honor (Temp solution before honor is moved back to core)
	Py::Object ext_SetUpdateFieldValue (const Py::Tuple& args);  // SetUint32
	Py::Object ext_GetUpdateFieldValue (const Py::Tuple& args);  // GetUint32

};


//--- END ---