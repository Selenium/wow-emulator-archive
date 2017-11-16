#include "stdafx.h"

///////////////////////////////////////////////////////////////////////////////
// UNIT - BASE CLASS FOR ALL LIVING
//
Py::Object PyUnit::ext_CanReachWithAttack (const Py::Tuple& args)
{
	args.verify_length (1);
	Py::ExtensionObject<PyUnit>	unit (args[0]);
	return Py::Int (GetUnit()->CanReachWithAttack (unit.extensionObject()->GetUnit()));
}

//-----------------------------------------------------------------------------
#define IMPLEMENT_INT_GETTER(Class,PropName) \
	Py::Object Class::ext_Get##PropName (const Py::Tuple& args) { \
		args.verify_length (0); \
		return Py::Int (GetUnit()->Get##PropName()); \
	}

#define IMPLEMENT_INT_SETTER(Class,PropName) \
	Py::Object Class::ext_Set##PropName (const Py::Tuple& args) { \
	args.verify_length (1); \
	Py::Int	value (args[0]); \
	GetUnit()->Set##PropName (value); \
	return Py::None(); \
	}

#define IMPLEMENT_INT_MODIFIER(Class,PropName) \
	Py::Object Class::ext_Modify##PropName (const Py::Tuple& args) { \
		args.verify_length (1); \
		Py::Int	delta (args[0]); \
		GetUnit()->Modify##PropName (delta); \
		return Py::None(); \
	}

#define INT_GET_SET(Class,PropName) \
	IMPLEMENT_INT_GETTER(Class,PropName) \
	IMPLEMENT_INT_SETTER(Class,PropName)

#define INT_GET_MODIFY_SET(Class,PropName) \
	IMPLEMENT_INT_GETTER(Class,PropName) \
	IMPLEMENT_INT_SETTER(Class,PropName) \
	IMPLEMENT_INT_MODIFIER(Class,PropName)

#define IMPLEMENT_FLOAT_GETTER(Class,PropName) \
	Py::Object Class::ext_Get##PropName (const Py::Tuple& args) { \
	args.verify_length (0); \
	return Py::Float (GetUnit()->Get##PropName()); \
	}

#define IMPLEMENT_FLOAT_SETTER(Class,PropName) \
	Py::Object Class::ext_Set##PropName (const Py::Tuple& args) { \
	args.verify_length (1); \
	Py::Float	value (args[0]); \
	GetUnit()->Set##PropName ((float)value); \
	return Py::None(); \
	}

#define IMPLEMENT_FLOAT_MODIFIER(Class,PropName) \
	Py::Object Class::ext_Modify##PropName (const Py::Tuple& args) { \
	args.verify_length (1); \
	Py::Float	delta (args[0]); \
	GetUnit()->Modify##PropName ((float)delta); \
	return Py::None(); \
	}

#define FLOAT_GET_MODIFY_SET(Class,PropName) \
	IMPLEMENT_FLOAT_GETTER(Class,PropName) \
	IMPLEMENT_FLOAT_SETTER(Class,PropName) \
	IMPLEMENT_FLOAT_MODIFIER(Class,PropName)

//-----------------------------------------------------------------------------
INT_GET_SET(PyUnit, Level)

IMPLEMENT_INT_GETTER(PyUnit, Race)
IMPLEMENT_INT_GETTER(PyUnit, Class)
IMPLEMENT_INT_GETTER(PyUnit, Gender)

INT_GET_MODIFY_SET(PyUnit, Strength)
INT_GET_MODIFY_SET(PyUnit, Agility)
INT_GET_MODIFY_SET(PyUnit, Stamina)
INT_GET_MODIFY_SET(PyUnit, Intellect)
INT_GET_MODIFY_SET(PyUnit, Spirit)

INT_GET_MODIFY_SET(PyUnit, PosStrength)
INT_GET_MODIFY_SET(PyUnit, PosAgility)
INT_GET_MODIFY_SET(PyUnit, PosStamina)
INT_GET_MODIFY_SET(PyUnit, PosIntellect)
INT_GET_MODIFY_SET(PyUnit, PosSpirit)

INT_GET_MODIFY_SET(PyUnit, NegStrength)
INT_GET_MODIFY_SET(PyUnit, NegAgility)
INT_GET_MODIFY_SET(PyUnit, NegStamina)
INT_GET_MODIFY_SET(PyUnit, NegIntellect)
INT_GET_MODIFY_SET(PyUnit, NegSpirit)

INT_GET_MODIFY_SET(PyUnit, Health)
INT_GET_MODIFY_SET(PyUnit, Mana)
INT_GET_MODIFY_SET(PyUnit, Rage)
INT_GET_MODIFY_SET(PyUnit, Focus)
INT_GET_MODIFY_SET(PyUnit, Energy)

INT_GET_MODIFY_SET(PyUnit, MaxHealth)
INT_GET_MODIFY_SET(PyUnit, MaxMana)
INT_GET_MODIFY_SET(PyUnit, MaxRage)
INT_GET_MODIFY_SET(PyUnit, MaxFocus)
INT_GET_MODIFY_SET(PyUnit, MaxEnergy)

INT_GET_MODIFY_SET(PyUnit, Armor)
INT_GET_MODIFY_SET(PyUnit, HolyResist)
INT_GET_MODIFY_SET(PyUnit, FireResist)
INT_GET_MODIFY_SET(PyUnit, NatureResist)
INT_GET_MODIFY_SET(PyUnit, FrostResist)
INT_GET_MODIFY_SET(PyUnit, ShadowResist)
INT_GET_MODIFY_SET(PyUnit, ArcaneResist)

INT_GET_MODIFY_SET(PyUnit, AttackPower)
INT_GET_MODIFY_SET(PyUnit, RangedAttackPower)
FLOAT_GET_MODIFY_SET(PyUnit, MinDamage)
FLOAT_GET_MODIFY_SET(PyUnit, MaxDamage)

//-----------------------------------------------------------------------------
FLOAT_GET_MODIFY_SET(PyUnit, CritChance)
FLOAT_GET_MODIFY_SET(PyUnit, DodgeChance)
FLOAT_GET_MODIFY_SET(PyUnit, ParryChance)
FLOAT_GET_MODIFY_SET(PyUnit, BlockChance)

//-----------------------------------------------------------------------------
void PyUnit::init_type(void)
{
	behaviors().name ("Unit");
	behaviors().doc ("Represents Unit object");

	add_varargs_method ("CanReachWithAttack", &PyUnit::ext_CanReachWithAttack, "(unit) returns if melee attack reaches unit");

	add_varargs_method ("GetLevel", &PyUnit::ext_GetLevel, "returns unit level");
	add_varargs_method ("SetLevel", &PyUnit::ext_SetLevel, "(level) sets unit level");

	add_varargs_method ("GetRace", &PyUnit::ext_GetRace, "returns unit race (can be 0)");
	add_varargs_method ("GetClass", &PyUnit::ext_GetClass, "returns unit class (can be 0)");
	add_varargs_method ("GetGender", &PyUnit::ext_GetGender, "returns unit gender (can be 0)");

#define PYTHONIZE_GET_MODIFY_SET(Class,PropName) \
	add_varargs_method ("Get"#PropName, &Class::ext_Get##PropName, ""); \
	add_varargs_method ("Modify"#PropName, &Class::ext_Modify##PropName, ""); \
	add_varargs_method ("Set"#PropName, &Class::ext_Set##PropName, "");

	PYTHONIZE_GET_MODIFY_SET(PyUnit, Strength);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, Agility);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, Stamina);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, Intellect);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, Spirit);

	PYTHONIZE_GET_MODIFY_SET(PyUnit, PosStrength);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, PosAgility);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, PosStamina);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, PosIntellect);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, PosSpirit);

	PYTHONIZE_GET_MODIFY_SET(PyUnit, NegStrength);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, NegAgility);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, NegStamina);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, NegIntellect);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, NegSpirit);

	PYTHONIZE_GET_MODIFY_SET(PyUnit, Health);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, Mana);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, Rage);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, Focus);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, Energy);

	PYTHONIZE_GET_MODIFY_SET(PyUnit, MaxHealth);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, MaxMana);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, MaxRage);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, MaxFocus);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, MaxEnergy);

	PYTHONIZE_GET_MODIFY_SET(PyUnit, Armor);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, HolyResist);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, FireResist);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, NatureResist);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, FrostResist);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, ShadowResist);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, ArcaneResist);

	PYTHONIZE_GET_MODIFY_SET(PyUnit, AttackPower);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, RangedAttackPower);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, MinDamage);
	PYTHONIZE_GET_MODIFY_SET(PyUnit, MaxDamage);

	add_varargs_method ("GetXYZ", &PyUnit::ext_GetXYZ, "no params - returns (x,y,z) as tuple");
	add_varargs_method ("IsPlayer", &PyUnit::ext_IsPlayer, "no params - returns true if Unit represents Player");
	add_varargs_method ("IsNPC", &PyUnit::ext_IsNPC, "no params - returns true if Unit represents CPU controlled creature");

	add_varargs_method ("WalkTo", &PyUnit::ext_WalkTo, "(Tuple XYZ) Starts walking towards (XYZ)");
	add_varargs_method ("RunTo", &PyUnit::ext_RunTo, "(Tuple XYZ) Starts running towards (XYZ)");
	add_varargs_method ("Flee", &PyUnit::ext_Flee, "(fromUnit, seconds, helpRadius) NPC runs randomly "
		"away fromUnit not responding for damage for N seconds. If in helpRadius happens to appear related "
		"creature (first word of the name compared) then it joins fight");
	add_varargs_method ("NextThink", &PyUnit::ext_NextThink, "(int seconds) Calls OnThink after time passed");

	add_varargs_method ("MovementType", &PyUnit::ext_MovementType, "(int mtype=None) Sets new MTYPE as in GM .npc mtype command. Returns previous MTYPE.");
	add_varargs_method ("RunFlag", &PyUnit::ext_RunFlag, "(int run=None) Sets new run flag - 0 walk, 1 run. Returns previous flag.");
	add_varargs_method ("CurrentWaypoint", &PyUnit::ext_CurrentWaypoint, "(int wp=None) Sets new current waypoint. Returns previous current waypoint.");
	add_varargs_method ("CallAtWaypoint", &PyUnit::ext_CallAtWaypoint, "(int wp, int someValue) When walker reaches waypoint calls OnWaypoint(self, someValue) event.");

	add_varargs_method ("AddHate", &PyUnit::ext_AddHate, "(unit,hate) Adds to NPC some hate to given unit");
	add_varargs_method ("GetHate", &PyUnit::ext_GetHate, "(unit) - Gets amount of hate that NPC feels to given unit");
	add_varargs_method ("RemoveHate", &PyUnit::ext_RemoveHate, "(unit) - Removes all hate from NPC to given unit");
	add_varargs_method ("ClearHate", &PyUnit::ext_ClearHate, "no params - make NPC extremely peaceful until next hate");

	add_varargs_method ("Say", &PyUnit::ext_Say, "(unit, text) Says aloud phrase to unit");
	add_varargs_method ("Emote", &PyUnit::ext_Emote, "(emote) NPC makes a gesture or action");
	add_varargs_method ("Equip", &PyUnit::ext_Equip, "(slot, itemModel, Forced_slot) Equips Item to creature (NPC) (0..2), Slot, ItemID, Forced_slot, see SHEATH");

	add_varargs_method ("AddSpell", &PyUnit::ext_AddSpell, "(spellId) Adds spell to player");
	add_varargs_method ("HasSpell", &PyUnit::ext_HasSpell, "(spellId) Returns true or false whether spell is known");
	add_varargs_method ("RemoveSpell", &PyUnit::ext_RemoveSpell, "(spellId) Removes spell from player");
	add_varargs_method ("GetSkill", &PyUnit::ext_GetSkill, "(skillId) Reads skill level from player, or 0 if not known");
	add_varargs_method ("SetSkill", &PyUnit::ext_SetSkill, "(skillId, level, maxlevel) Sets skill level for player, set to 0 to remove skill");

	add_varargs_method ("PlayerModel", &PyUnit::ext_PlayerModel, "(male, female) Sets model based on gender");
	add_varargs_method ("StartupLocation", &PyUnit::ext_StartupLocation, "(mapId, x, y, z, o) Sets bindpoint and location");
	add_varargs_method ("GetFaction", &PyUnit::ext_GetFaction, "() Gets unit faction");
	add_varargs_method ("SetFaction", &PyUnit::ext_SetFaction, "(faction) Sets unit faction");
	add_varargs_method ("GetReputation", &PyUnit::ext_GetReputation, "(reputationID) Gets unit reputation");
	add_varargs_method ("SetReputation", &PyUnit::ext_SetReputation, "(reputationID, newReputation) Sets unit reputation");
	add_varargs_method ("GetReputationValue", &PyUnit::ext_GetReputationValue, "(reputationID) Gets unit reputationValue");
	add_varargs_method ("SetReputationValue", &PyUnit::ext_SetReputationValue, "(reputationID, newReputationValue) Sets unit reputationValue");

	add_varargs_method ("SetActionButton", &PyUnit::ext_SetActionButton, "(actionbuttonID, spellID) Sets spell to unit action button");
	add_varargs_method ("GetSlotByItemID", &PyUnit::ext_GetSlotByItemID, "(itemID) Gets number of slot in bagpack for given itemID");
	
	add_varargs_method ("SetAmmoSlot", &PyUnit::ext_SetAmmoSlot, "(ammoID) Puts ammo to Ammo Slot");
	add_varargs_method ("AddItemToSlot", &PyUnit::ext_AddItemToSlot, "(slot, item, count) Adds item to player inventory");

	add_varargs_method ("SetUpdateFieldValue", &PyUnit::ext_SetUpdateFieldValue, "(field, value) Sets Value to Player's update field");
	add_varargs_method ("GetUpdateFieldValue", &PyUnit::ext_GetUpdateFieldValue, "(field) Gets Value of Player's update field");

	add_varargs_method ("GetEntry", &PyUnit::ext_GetEntry, "() Returns NPC database entry #");
	add_varargs_method ("GetNpcFlags", &PyUnit::ext_GetNpcFlags, "() Returns NPC Flags value");
	add_varargs_method ("SetNpcFlags", &PyUnit::ext_SetNpcFlags, "(npcflags) Sets new NPC Flags value");
	add_varargs_method ("GetElite", &PyUnit::ext_GetElite, "() Returns NPC eliteness value 0 normal, 1-2 elite, 3 boss, 4 rare");
	add_varargs_method ("GetNpcType", &PyUnit::ext_GetNpcType, "() Returns NPC type 1-beast, 2-dragonkin, 7-humanoid etc");
	add_varargs_method ("GetMinDmg", &PyUnit::ext_GetMinDmg, "() Returns Min damage");
	add_varargs_method ("GetMaxDmg", &PyUnit::ext_GetMaxDmg, "() Returns Max damage");
	add_varargs_method ("GetSize", &PyUnit::ext_GetSize, "() Returns Size of creature");

	add_varargs_method ("ClearQuestMenu"    , &PyUnit::ext_ClearQuestMenu, "() Clears the Quest Menu");
	add_varargs_method ("ClearGossipMenu"	, &PyUnit::ext_ClearGossipMenu, "() Clears the Gossip Menu");
	add_varargs_method ("SendGossipMenu"	, &PyUnit::ext_SendGossipMenu, "(npc, npctext) Sends current buit Menu");
	add_varargs_method ("SetQuestMenuTitle"	, &PyUnit::ext_SetQuestMenuTitle, "(title) Sets the QuestMenu title");

	add_varargs_method ("AddGossipItem"		, &PyUnit::ext_AddGossipItem, "(icon, text, sender, action) Adds a menu entry to gossip menu");
	add_varargs_method ("AddCodedGossipItem", &PyUnit::ext_AddCodedGossipItem, "(icon, text, sender, action) Adds a menu entry to gossip menu with a code popup");

	add_varargs_method ("AddNPCQuests"		, &PyUnit::ext_AddNPCQuests, "(npc) builds the default quest menu from sql");
	add_varargs_method ("AddAvailableQuest"	, &PyUnit::ext_AddAvailableQuest, "(qid) adds an available quest");
	add_varargs_method ("AddCurrentQuest"	, &PyUnit::ext_AddCurrentQuest, "(qid) adds a current quest");
	add_varargs_method ("NPCQuestDialogStatus"	, &PyUnit::ext_GetNPCQuestDialogStatus, "(npc, default) Returns dialog status of quests if not default");



	add_varargs_method ("IsVendor"	, &PyUnit::ext_IsVendor, "() Name speaks for itself");
	add_varargs_method ("IsTrainer"	, &PyUnit::ext_IsTrainer, "() Name speaks for itself");
	add_varargs_method ("IsGossip"	, &PyUnit::ext_IsGossip, "() Name speaks for itself");
	add_varargs_method ("IsQuestGiver"	, &PyUnit::ext_IsQuestGiver, "() Name speaks for itself");
	add_varargs_method ("IsTaxi"	, &PyUnit::ext_IsTaxi, "() Name speaks for itself");
	add_varargs_method ("IsGuildMaster"	, &PyUnit::ext_IsGuildMaster, "() Name speaks for itself");
	add_varargs_method ("IsBattleMaster"	, &PyUnit::ext_IsBattleMaster, "() Name speaks for itself");
	add_varargs_method ("IsBanker"	, &PyUnit::ext_IsBanker, "() Name speaks for itself");
	add_varargs_method ("IsInnkeeper"	, &PyUnit::ext_IsInnkeeper, "() Name speaks for itself");
	add_varargs_method ("IsSpiritHealer"	, &PyUnit::ext_IsSpiritHealer, "() Name speaks for itself");
	add_varargs_method ("IsTabardVendor"	, &PyUnit::ext_IsTabardVendor, "() Name speaks for itself");
	add_varargs_method ("IsAuctioner"	, &PyUnit::ext_IsAuctioner, "() Name speaks for itself");
	add_varargs_method ("IsArmorer"	, &PyUnit::ext_IsArmorer, "() Name speaks for itself");

	add_varargs_method ("SendQuestDetails"	, &PyUnit::ext_SendQuestDetails, "(npc, qid)/(item_lo, item_hi, quid) Send quest qid detaild to player");

	add_varargs_method ("CanCompleteQuest"	, &PyUnit::ext_QuestComplete, "(npc qid) Checks if the quest is finished and reward awaiting");
    add_varargs_method ("CanTakeQuest"	, &PyUnit::ext_QuestTakable, "(qid) Checks if the quest can be taken by player");
    add_varargs_method ("HasQuest"	, &PyUnit::ext_HasQuest, "(qid) Checks if the quest can be taken by player");

	add_varargs_method ("ManageGOQuests"	, &PyUnit::ext_ManageGOQuests, "(goidlo, guidhi) Manages all GO quests.");
	add_varargs_method ("SendQuestReward"	, &PyUnit::ext_SendQuestReward, "(npc, qid) Sends the reward to player");
	add_varargs_method ("SendQuestRequiredItems"	, &PyUnit::ext_SendQuestRequiredItems, "(npc, qid, next_acc) Sends the requested items to player. next_acc is a bool.");

	add_varargs_method ("GetFollowingQuest"	, &PyUnit::ext_GetFollowingQuest, "(npc) Gets the next line related quest");
	add_varargs_method ("CloseGossipWindow"	, &PyUnit::ext_CloseGossipWindow, "() Closes the current gossip window");

	add_varargs_method ("FinishExplorationObjective"	, &PyUnit::ext_finishExplorationQuest, "(qid) Signals the exploration objective to complete");


	add_varargs_method ("SendVendorList"	, &PyUnit::ext_SendVendorList, "(npc) Does what it says");
	add_varargs_method ("SendTrainerList"	, &PyUnit::ext_SendTrainerList, "(npc) Does what it says");
	add_varargs_method ("SendTaxiList"	, &PyUnit::ext_SendTaxiList, "(npc) Does what it says");
	add_varargs_method ("SendGuildManager"	, &PyUnit::ext_SendPetitionList, "(npc) Does what it says");
	add_varargs_method ("SendBattleFieldsList"	, &PyUnit::ext_SendBattleList, "(npc) Does what it says");
	add_varargs_method ("SendBankManager"	, &PyUnit::ext_SendBankerList, "(npc) Does what it says");
	add_varargs_method ("SetBindPoint"	, &PyUnit::ext_SendInnkeeperList, "(npc) Does what it says");
	add_varargs_method ("Resurrect"	, &PyUnit::ext_SendSpiritHealerList, "(npc) Does what it says");
	add_varargs_method ("SendTabardList"	, &PyUnit::ext_SendTabardList, "(npc) Does what it says");
	add_varargs_method ("SendAuctionsList"	, &PyUnit::ext_SendAuctionerList, "(npc) Does what it says");

	add_varargs_method ("HasSellTables"	, &PyUnit::ext_HasSellTables, "() True if npc has sell tables defined in sql.");
	add_varargs_method ("SelectIntByEntry"	, &PyUnit::ext_SelectById, "(defval, [entry, val] ...) Selects an entry by entry id");

	add_varargs_method ("SendPOI"	, &PyUnit::ext_SendPOI, "(flags, x, y, icon, data, name) Sends a POI to player");

	add_varargs_method ("GetStoredNPCText"   , &PyUnit::ext_GetStoredNPCText, "(deftext, bankid) Selects between the given text and a predefined one (if the last is registered)");
	add_varargs_method ("GetStoredText"		 , &PyUnit::ext_GetStoredText, "(deftext, bankid) Selects between the given text and a predefined one (if the last is registered)");	

	add_varargs_method ("SystemMessage"		 , &PyUnit::ext_SendSystemMessage, "(text) Send a specified system message");	

	add_varargs_method ("isArmed"		 , &PyUnit::ext_isArmed, "() Returns if Player is armed or not");

}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_GetXYZ (const Py::Tuple& args)
{
	args.verify_length (0);
	Py::Tuple	xyz(3);
	xyz[0] = Py::Float (GetUnit()->GetPositionX());
	xyz[1] = Py::Float (GetUnit()->GetPositionY());
	xyz[2] = Py::Float (GetUnit()->GetPositionZ());
	return xyz;
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_Say (const Py::Tuple& args)
{
	args.verify_length (3);
	Creature * cr = GetCreature();
	if (cr != NULL)
	{
		Py::ExtensionObject<PyUnit>	receiver (args[0]);
		Py::String text (args[1]);
		Py::Int language (args[2]);

		cr->Say (receiver.extensionObject()->GetUnit(), text.as_std_string().c_str(),
			(Language)(int)language);
	}
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_Emote (const Py::Tuple& args)
{
	args.verify_length (1);
	Unit * cr = GetUnit();

	Py::Int emote (args[0]);
	cr->Emote ((EmoteType)(int)emote);
	
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_WalkTo (const Py::Tuple& args)
{
	args.verify_length (1,2);
	Creature * cr = GetCreature();
	if (cr != NULL) 
	{
		Py::Tuple	xyz (args[0]);
		float	x = (float)Py::Float (xyz[0]);
		float	y = (float)Py::Float (xyz[1]);
		float	z = (float)Py::Float (xyz[2]);

		float	stopDist = 0;
		if (args.size() == 2) {
			Py::Float pyStopDist (args[1]);
			stopDist = (float)pyStopDist;
		}

		cr->AI_MoveTo (x, y, z, false, stopDist);
	}
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_RunTo (const Py::Tuple& args)
{
	args.verify_length (1,2);
	Creature * cr = GetCreature();
	if (cr != NULL) 
	{
		Py::Tuple	xyz (args[0]);
		float	x = (float)Py::Float (xyz[0]);
		float	y = (float)Py::Float (xyz[1]);
		float	z = (float)Py::Float (xyz[2]);

		float	stopDist = 0;
		if (args.size() == 2) {
			Py::Float pyStopDist (args[1]);
			stopDist = (float)pyStopDist;
		}

		cr->AI_MoveTo (x, y, z, true, stopDist);
	}
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_AddHate (const Py::Tuple& args)
{
	args.verify_length (2);
	Py::ExtensionObject<PyUnit>	unit (args[0]);	
	Py::Float hate (args[1]);
	GetUnit()->AddHate (unit.extensionObject()->GetUnit(), (float)hate);
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_GetHate (const Py::Tuple& args)
{
	args.verify_length (1);
	Py::ExtensionObject<PyUnit>	unit (args[0]);	
	return Py::Float (GetUnit()->GetHate (unit.extensionObject()->GetUnit()));
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_RemoveHate (const Py::Tuple& args)
{
	args.verify_length (1);
	Py::ExtensionObject<PyUnit>	unit (args[0]);	
	GetUnit()->RemoveHate (unit.extensionObject()->GetUnit());
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_ClearHate (const Py::Tuple& args)
{
	args.verify_length (0);
	GetUnit()->ClearHate();
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_Flee (const Py::Tuple& args)
{
	args.verify_length (3);
	Creature * cr = GetCreature();
	if (cr != NULL) {
		Py::ExtensionObject<PyUnit>	fromUnit (args[0]);
		Py::Int seconds (args[1]);
		Py::Int helpRadius (args[1]);

		cr->Flee (fromUnit.extensionObject()->GetUnit(), (int)seconds, (int)helpRadius);
	}
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_NextThink (const Py::Tuple& args)
{
	args.verify_length (2);
	Creature * cr = GetCreature();
	if (cr != NULL)
	{
		Py::Int t (args[0]);
		Py::Int p (args[1]);
		cr->NextThink ((uint32)t, (uint32)p);
	}
	return Py::None();
}

//-----------------------------------------------------------------------------

Py::Object PyUnit::ext_Equip (const Py::Tuple& args)
{
	args.verify_length (3);
	Py::Int	slot (args[0]);
	Py::Int	model (args[1]);
    Py::Int	forced_slot (args[2]);

	//GetUnit()->VirtualEquip (int(slot) % 3, int(model), int(forced_slot));
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_MovementType (const Py::Tuple& args)
{
	args.verify_length (0,1);
	Creature::MovementType oldMtype = GetCreature()->GetMovementType();

	if (args.size() == 1) {
		Py::Int	mtype (args[0]);
		GetCreature()->SetMovementType ((Creature::MovementType)((int)mtype));
	}

	return Py::Int ((int)oldMtype);
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_RunFlag (const Py::Tuple& args)
{
	args.verify_length (0,1);
	bool oldRun = GetCreature()->getMoveRunFlag();

	if (args.size() == 1)
	{
		Py::Int	runflag (args[0]);
		GetCreature()->setMoveRunFlag ((int)runflag != 0);
	}

	return Py::Int ((int)oldRun);
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_CurrentWaypoint (const Py::Tuple& args)
{
	args.verify_length (0,1);
	int oldWp = GetCreature()->GetCurrentWaypoint();

	if (args.size() == 1)
	{
		Py::Int	wp (args[0]);
		GetCreature()->SetCurrentWaypoint ((int)wp);
	}

	return Py::Int ((int)oldWp);
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_CallAtWaypoint (const Py::Tuple& args)
{
	args.verify_length (2);

	Py::Int	wp (args[0]);
	Py::Int	someValue (args[1]);

	GetCreature()->CallScriptAtWaypoint ((int)wp, (int)someValue);

	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_IsPlayer (const Py::Tuple& args)
{
	args.verify_length (0);
	if (GetPlayer() != NULL) return Py::Int (1);
	return Py::Int (0);
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_IsNPC (const Py::Tuple& args)
{
	args.verify_length (0);
	if (GetCreature() != NULL) return Py::Int (1);
	return Py::Int (0);
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_AddSpell (const Py::Tuple& args)
{
	args.verify_length (1);
	Player * p = GetPlayer();
	if (p != NULL)
	{
		Py::Int id (args[0]);
		p->AddSpell( (uint32)id );
	}
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_HasSpell (const Py::Tuple& args)
{
	args.verify_length (1);
	Player * p = GetPlayer();
	if (p != NULL)
	{
		Py::Int id (args[0]);
		if (p->HasSpell( (uint32)id ))
			return Py::Int (1);
	}
	return Py::Int (0);
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_RemoveSpell (const Py::Tuple& args)
{
	args.verify_length (1);
	Player * p = GetPlayer();
	if (p != NULL)
	{
		Py::Int id (args[0]);
		p->RemoveSpell( (uint32)id );
	}
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_SetSkill (const Py::Tuple& args)
{
	args.verify_length (3);
	Player * p = GetPlayer();
	if (p != NULL)
	{
		Py::Int id (args[0]);
		Py::Int level (args[1]);
		Py::Int maxSkill (args[2]);
		p->AddSkill( (uint32)id, (uint16)level, (uint16)maxSkill );
	}
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_GetSkill (const Py::Tuple& args)
{
	args.verify_length (1);
	Player * p = GetPlayer();
	uint16 skill = 0;
	if (p != NULL)
	{
		Py::Int id (args[0]);
		skill = p->GetSkill( (uint32)id );
	}
	return Py::Int (skill);
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_PlayerModel (const Py::Tuple& args)
{
	args.verify_length (2);
	Player * p = GetPlayer();
	if (p != NULL)
	{
		Py::Int male (args[0]);
		Py::Int female (args[1]);
		int model = p->GetGender() == 0 ? (int)male : (int)female;

		p->SetUInt32Value (UNIT_FIELD_DISPLAYID, model);
		p->SetUInt32Value (UNIT_FIELD_NATIVEDISPLAYID, model);
	}
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_StartupLocation (const Py::Tuple& args)
{
	args.verify_length (5);
	Player * p = GetPlayer();
	if (p != NULL)
	{
		Py::Int mapId (args[0]);
		Py::Float x (args[1]);
		Py::Float y (args[2]);
		Py::Float z (args[3]);
		Py::Float orient (args[4]);

		p->SetMapId (p->m_bindPointMap = (int)mapId);
		p->SetPosition (p->m_bindPointX = (float)x,
						p->m_bindPointY = (float)y,
						p->m_bindPointZ = (float)z,
						(float)orient, false);
	}
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_GetFaction (const Py::Tuple& args)
{
	args.verify_length (0);
	Player * p = GetPlayer();
	int faction = 0;
	if (p != NULL)
	{
		faction = p->GetFaction();
	}
	return Py::Int (faction);
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_SetFaction (const Py::Tuple& args)
{
	args.verify_length (1);
	Player * p = GetPlayer();
	if (p != NULL)
	{
		Py::Int faction (args[0]);
		p->SetFaction ((int)faction);
	}
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_GetReputation (const Py::Tuple& args)
{
	args.verify_length (1);
	Player * p = GetPlayer();
	int reputation = 0;
	if (p != NULL)
	{
		Py::Int RepID (args[0]);
		if (RepID <= 64)
			reputation = p->m_reputation[RepID];
	}
	return Py::Int (reputation);
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_SetReputation (const Py::Tuple& args)
{
	args.verify_length (2);
	Player * p = GetPlayer();
	if (p != NULL)
	{
		Py::Int RepID (args[0]);
		Py::Int Reputation (args[1]);
		if (RepID <= 64)
			p->m_reputation[RepID] = uint8(Reputation);
	}
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_GetReputationValue (const Py::Tuple& args)
{
	args.verify_length (1);
	Player * p = GetPlayer();
	int reputationValue = 0;
	if (p != NULL)
	{
		Py::Int RepID (args[0]);
		if (RepID <= 64)
			reputationValue = p->m_reputationValues[RepID];
	}
	return Py::Int (reputationValue);
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_SetReputationValue (const Py::Tuple& args)
{
	args.verify_length (2);
	Player * p = GetPlayer();
	if (p != NULL)
	{
		Py::Int RepID (args[0]);
		Py::Int ReputationValue (args[1]);
		if (RepID <= 64)
			p->m_reputationValues[RepID] = uint32(ReputationValue);
	}
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_AddItemToSlot (const Py::Tuple& args)
{
	args.verify_length (3);
	Player * p = GetPlayer();
	if (p != NULL)
	{
		Py::Int slot (args[0]);
		Py::Int itemId (args[1]);
		Py::Int count (args[2]);
		p->AddItemToSlot (uint8(slot), itemId, count);
	}
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_GetEntry (const Py::Tuple& args)
{
	args.verify_length (0);
	Unit * u = GetUnit();
	int entry = 0;
	if (u != NULL)
	{
		entry = u->GetEntry();
	}
	return Py::Int (entry);
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_GetNpcFlags (const Py::Tuple& args)
{
	args.verify_length (0);
	Unit * u = GetUnit();
	int flags = 0;
	if (u != NULL)
	{
		flags = u->GetNpcFlags();
	}
	return Py::Int (flags);
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_SetNpcFlags (const Py::Tuple& args)
{
	args.verify_length (1);
	Unit * u = GetUnit();
	if (u != NULL)
	{
		Py::Int flags (args[0]);
		u->SetNpcFlags (flags);
	}
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_GetElite (const Py::Tuple& args)
{
	args.verify_length (0);
	Unit * u = GetUnit();
	int elite = 0;
	if (u != NULL && u->GetTypeId() == TYPEID_UNIT)
	{
		elite = ((Creature *)u)->GetElite();
	}
	return Py::Int (elite);
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_GetNpcType (const Py::Tuple& args)
{
	args.verify_length (0);
	Unit * u = GetUnit();
	int type = 0;
	if (u != NULL && u->GetTypeId() == TYPEID_UNIT)
	{
		type = ((Creature *)u)->GetNpcType();
	}
	return Py::Int (type);
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_SetActionButton (const Py::Tuple& args)
{
	args.verify_length (2);
	Player * p = GetPlayer();
	if (p != NULL)
	{
		Py::Int actionbuttonID (args[0]);
		Py::Int spellID (args[1]);
		if (actionbuttonID <= 120)
			p->m_actionsButtons[actionbuttonID] = uint32(spellID);
	}

	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_GetSlotByItemID (const Py::Tuple& args)
{
	args.verify_length (1);
	Player * p = GetPlayer();
	int result = 0;
	if (p != NULL)
	{
		Py::Int itemID (args[0]);
		result = (int)p->GetSlotByItemID(itemID);
	}

	return Py::Int (result);
}

Py::Object PyUnit::ext_SetAmmoSlot (const Py::Tuple& args)
{
	args.verify_length (1);
	Player * p = GetPlayer();
	int ammoID = 0;
	if (p != NULL)
	{
		Py::Int ammoID (args[0]);
		p->SetUInt32Value(PLAYER_AMMO_ID, ammoID);
	}

	return Py::None();
}
//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_GetMinDmg (const Py::Tuple& args)
{
	args.verify_length (0);
	Unit * u = GetUnit();
	int minDamage = 0;
	if (u != NULL && u->GetTypeId() == TYPEID_UNIT)
	{
		minDamage = (int32)((Creature *)u)->GetMinDamage();
	}
	return Py::Int (minDamage);
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_GetMaxDmg (const Py::Tuple& args)
{
	args.verify_length (0);
	Unit * u = GetUnit();
	int maxDamage = 0;
	if (u != NULL && u->GetTypeId() == TYPEID_UNIT)
	{
		maxDamage = (int32)((Creature *)u)->GetMaxDamage();
	}
	return Py::Int (maxDamage);
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_ClearQuestMenu (const Py::Tuple& args)
{
	args.verify_length (0);
	Player * p = GetPlayer();
	if (p != NULL)
	{
		p->_QuestMenu->Clear();
	}
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_ClearGossipMenu (const Py::Tuple& args)
{
	args.verify_length (0);
	Player * p = GetPlayer();
	if (p != NULL)
	{
		p->_GossipMenu->Clear();
	}
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_AddCurrentQuest (const Py::Tuple& args)
{
	args.verify_length (1);
	Player * p = GetPlayer();
	if (p != NULL)
	{
		Py::Int questId (args[0]);
		p->_QuestMenu->AddCurrentQuest( questId, DIALOG_STATUS_INCOMPLETE );
	}
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_AddAvailableQuest (const Py::Tuple& args)
{
	args.verify_length (1);
	Player * p = GetPlayer();
	if (p != NULL)
	{
		Py::Int questId (args[0]);
		p->_QuestMenu->AddCurrentQuest( questId, DIALOG_STATUS_AVAILABLE );
	}
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_AddNPCQuests (const Py::Tuple& args)
{
	args.verify_length (1);
	Player * p = GetPlayer();
	if (p != NULL)
	{
		Py::ExtensionObject<PyUnit> fromNPC (args[0]);
		Creature *pNPC = fromNPC.extensionObject()->GetCreature();

		if (pNPC)
			pNPC->prepareQuestMenu( p, p->_QuestMenu );
	}
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_AddGossipItem (const Py::Tuple& args)
{
	args.verify_length (4);
	Player * p = GetPlayer();
	if (p != NULL)
	{
		Py::Int icon (args[0]);
		Py::String text (args[1]);
		Py::Int sender (args[2]);
		Py::Int action (args[3]);

		GossipData data;
		data.iDataSender = sender;
		data.iDataSub    = action;

		p->_GossipMenu->AddMessage( icon, false, text, data);
	}
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_AddCodedGossipItem (const Py::Tuple& args)
{
	args.verify_length (4);
	Player * p = GetPlayer();
	if (p != NULL)
	{
		Py::Int icon (args[0]);
		Py::String text (args[1]);
		Py::Int sender (args[2]);
		Py::Int action (args[3]);

		GossipData data;
		data.iDataSender = sender;
		data.iDataSub    = action;

		p->_GossipMenu->AddMessage( icon, true, text, data);
	}
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_SetQuestMenuTitle (const Py::Tuple& args)
{
	args.verify_length (1);
	Player * p = GetPlayer();
	if (p != NULL)
	{
		Py::String text (args[0]);
		p->_QuestMenu->m_MenuTitle = text;
	}
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_SendGossipMenu (const Py::Tuple& args)
{
	args.verify_length (2);
	Player * p = GetPlayer();
	QEmote qm;

	if (p != NULL)
	{
		Py::ExtensionObject<PyUnit> fromNPC (args[0]);
		Py::Int text (args[1]);
		Creature *pNPC = fromNPC.extensionObject()->GetCreature();

		qm.iDelay = 0;
		qm.iEmote = 0;

		if (pNPC)
			p->sendPreparedGossip( text, qm, pNPC->GetGUID() );
	}
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_GetNPCQuestDialogStatus (const Py::Tuple& args)
{
	args.verify_length (2);
	Player * p = GetPlayer();
	Py::Int status ( DIALOG_STATUS_NONE );

	if (p != NULL)
	{
		Py::ExtensionObject<PyUnit> fromNPC (args[0]);
		Py::Int def (args[1]);
		Creature *pNPC = fromNPC.extensionObject()->GetCreature();

		status = (int) pNPC->getDialogStatus( p, def );
	}
	return status;
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_IsVendor (const Py::Tuple& args)
{
	args.verify_length (0);
	Creature * cr = GetCreature();
	Py::Int isbool ( 0 );

	if (cr != NULL)
		isbool = cr->isVendor();

	return isbool;
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_IsTrainer (const Py::Tuple& args)
{
	args.verify_length (0);
	Creature * cr = GetCreature();
	Py::Int isbool ( 0 );

	if (cr != NULL)
		isbool = cr->isTrainer();

	return isbool;
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_IsGossip (const Py::Tuple& args)
{
	args.verify_length (0);
	Creature * cr = GetCreature();
	Py::Int isbool ( 0 );

	if (cr != NULL)
		isbool = cr->isGossip();

	return isbool;
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_IsQuestGiver (const Py::Tuple& args)
{
	args.verify_length (0);
	Creature * cr = GetCreature();
	Py::Int isbool ( 0 );

	if (cr != NULL)
		isbool = cr->isQuestGiver();

	return isbool;
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_IsTaxi (const Py::Tuple& args)
{
	args.verify_length (0);
	Creature * cr = GetCreature();
	Py::Int isbool ( 0 );

	if (cr != NULL)
		isbool = cr->isTaxi();

	return isbool;
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_IsGuildMaster (const Py::Tuple& args)
{
	args.verify_length (0);
	Creature * cr = GetCreature();
	Py::Int isbool ( 0 );

	if (cr != NULL)
		isbool = cr->isGuildMaster();

	return isbool;
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_IsBattleMaster (const Py::Tuple& args)
{
	args.verify_length (0);
	Creature * cr = GetCreature();
	Py::Int isbool ( 0 );

	if (cr != NULL)
		isbool = cr->isBattleMaster();

	return isbool;
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_IsBanker (const Py::Tuple& args)
{
	args.verify_length (0);
	Creature * cr = GetCreature();
	Py::Int isbool ( 0 );

	if (cr != NULL)
		isbool = cr->isBanker();

	return isbool;
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_IsInnkeeper (const Py::Tuple& args)
{
	args.verify_length (0);
	Creature * cr = GetCreature();
	Py::Int isbool ( 0 );

	if (cr != NULL)
		isbool = cr->isInnkeeper();

	return isbool;
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_IsSpiritHealer (const Py::Tuple& args)
{
	args.verify_length (0);
	Creature * cr = GetCreature();
	Py::Int isbool ( 0 );

	if (cr != NULL)
		isbool = cr->isSpiritHealer();

	return isbool;
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_IsTabardVendor (const Py::Tuple& args)
{
	args.verify_length (0);
	Creature * cr = GetCreature();
	Py::Int isbool ( 0 );

	if (cr != NULL)
		isbool = cr->isTabardVendor();

	return isbool;
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_IsAuctioner (const Py::Tuple& args)
{
	args.verify_length (0);
	Creature * cr = GetCreature();
	Py::Int isbool ( 0 );

	if (cr != NULL)
		isbool = cr->isAuctioner();

	return isbool;
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_IsArmorer (const Py::Tuple& args)
{
	args.verify_length (0);
	Creature * cr = GetCreature();
	Py::Int isbool ( 0 );

	if (cr != NULL)
		isbool = cr->isArmorer();

	return isbool;
}


//-----------------------------------------------------------------------------

Py::Object PyUnit::ext_SendQuestDetails (const Py::Tuple& args)
{
	args.verify_length (2, 3);
	Player * p = GetPlayer();

	if (p != NULL)
	{
		Py::Int questid;
		uint64 guid;

		if (args.length() == 2 )
		{
			Py::ExtensionObject<PyUnit> fromNPC (args[0]);
			questid = args[1];
			guid = fromNPC.extensionObject()->GetUnit()->GetGUID();
		}

		if (args.length() == 3 )
		{
			Py::Int lo (args[0]);
			Py::Int hi (args[1]);

			questid = args[2];
			GUID_LOPART(guid) = (unsigned int)lo;
			GUID_HIPART(guid) = (unsigned int)hi;
		}

		Quest *pQuest = objmgr.GetQuest( (unsigned int)questid );

		if ( guid && pQuest )
			QuestPacketHandler::getSingleton().SendShortQuestDetailsToPlayer( p->GetSession(), pQuest, guid );
	}
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_SendQuestReward (const Py::Tuple& args)
{
	args.verify_length (2);
	Player * p = GetPlayer();

	if (p != NULL)
	{
		Py::ExtensionObject<PyUnit> fromNPC (args[0]);
		Py::Int questid (args[1]);
		Creature *pNPC = fromNPC.extensionObject()->GetCreature();
		Quest *pQuest = objmgr.GetQuest( questid );

		if ( pNPC && pQuest )
			QuestPacketHandler::getSingleton().SendRewardToPlayer( p->GetSession(), pQuest, pNPC->GetGUID() );
	}
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_SendQuestRequiredItems (const Py::Tuple& args)
{
	args.verify_length (3);
	Player * p = GetPlayer();

	if (p != NULL)
	{
		Py::ExtensionObject<PyUnit> fromNPC (args[0]);
		Py::Int questid (args[1]);
		Py::Int butt (args[2]);

		Creature *pNPC = fromNPC.extensionObject()->GetCreature();
		Quest *pQuest = objmgr.GetQuest( questid );

		if ( pNPC && pQuest )
			QuestPacketHandler::getSingleton().SendRequestItemsToPlayer( p->GetSession(), pQuest, pNPC->GetGUID(), (butt!=0) );
	}
	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_QuestComplete (const Py::Tuple& args)
{
	args.verify_length (2);
	Player * p = GetPlayer();

	if (p != NULL)
	{
		Py::ExtensionObject<PyUnit> fromNPC (args[0]);
		Creature *pNPC = fromNPC.extensionObject()->GetCreature();

		Py::Int questid (args[1]);
		Quest *pQuest = objmgr.GetQuest( questid );

		if ( pQuest && pNPC )
		{
			if ( p->isQuestComplete( questid, pNPC ) )
				return Py::Int(1); else
				return Py::Int(0);
		}
	}

	return Py::Int(0);
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_QuestTakable (const Py::Tuple& args)
{
	args.verify_length (1);
	Player * p = GetPlayer();

	if (p != NULL)
	{
		Py::Int questid (args[0]);
		Quest *pQuest = objmgr.GetQuest( questid );

		if ( pQuest )
		{
			if ( p->isQuestTakable( questid ) )
				return Py::Int(1); else
				return Py::Int(0);
		}
	}

	return Py::Int(0);
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_HasQuest (const Py::Tuple& args)
{
	args.verify_length (1);
	Player * p = GetPlayer();

	if (p != NULL)
	{
		Py::Int questid (args[0]);
		Quest *pQuest = objmgr.GetQuest( questid );

		if ( pQuest )
		{
			if ( p->getQuestStatus( questid ) == QUEST_STATUS_INCOMPLETE )
				return Py::Int(1); else
				return Py::Int(0);
		}
	}

	return Py::Int(0);
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_GetFollowingQuest (const Py::Tuple& args)
{
	args.verify_length (2);
	Player * p = GetPlayer();

	if (p != NULL)
	{
		Py::ExtensionObject<PyUnit> fromNPC (args[0]);
		Creature *pNPC = fromNPC.extensionObject()->GetCreature();

		Py::Int qid (args[1]);
		Quest* pQuest = objmgr.GetQuest( qid );

		if ( pNPC && pQuest )
		{
			Quest *prQuest = pNPC->getNextAvailableQuest( p, pQuest );

			if ( prQuest ) return Py::Int( (int) prQuest->m_questId );
		}
	}

	return Py::Int(0);
}


Py::Object PyUnit::ext_CloseGossipWindow (const Py::Tuple& args)
{
	args.verify_length (0);
	Player * p = GetPlayer();

	if (p != NULL)
	{
		QuestPacketHandler::getSingleton().SendCloseGossipToPlayer( p->GetSession() );
	}
	return Py::None();
}

Py::Object PyUnit::ext_finishExplorationQuest (const Py::Tuple& args)
{
	args.verify_length (1);
	Player * p = GetPlayer();

	if (p != NULL)
	{
		Py::Int qid (args[0]);
		Quest* pQuest = objmgr.GetQuest( qid );

		if (pQuest)
			p->finishExplorationQuest(pQuest);

	}
	return Py::None();
}

Py::Object PyUnit::ext_ManageGOQuests (const Py::Tuple& args)
{
	args.verify_length (2);
	Player * p = GetPlayer();

	if (p != NULL)
	{
		Py::Int lo (args[0]);
		Py::Int hi (args[1]);

		uint64 guid;
		GUID_LOPART(guid) = (unsigned int)lo;
		GUID_HIPART(guid) = (unsigned int)hi;

		Py::Int goid (args[0]);
		GameObject* pGO = objmgr.GetObject<GameObject>( guid );

		if (pGO)
			pGO->managePlayerQuests( p );

	}
	return Py::None();
}


Py::Object PyUnit::ext_SendVendorList (const Py::Tuple& args)
{
	args.verify_length (1);
	Player * p = GetPlayer();

	if (p != NULL)
	{
		Py::ExtensionObject<PyUnit> fromNPC (args[0]);
		Creature *pNPC = fromNPC.extensionObject()->GetCreature();

		if ( pNPC )
		{
			QuestPacketHandler::getSingleton().SendVendorList( p->GetSession(), pNPC->GetGUID() );
		}
	}
	return Py::None();
}

Py::Object PyUnit::ext_SendTrainerList (const Py::Tuple& args)
{
	args.verify_length (1, 2);
	Player * p = GetPlayer();

	if (p != NULL)
	{
		Py::ExtensionObject<PyUnit> fromNPC (args[0]);
		Creature *pNPC = fromNPC.extensionObject()->GetCreature();
		Py::String trtext ( "" );

		if (args.length() == 2) trtext = args[1];


		if ( pNPC )
		{
			QuestPacketHandler::getSingleton().SendTrainerList( p->GetSession(), pNPC->GetGUID(), trtext.as_std_string() );
		}
	}
	return Py::None();
}

Py::Object PyUnit::ext_SendTaxiList (const Py::Tuple& args)
{
	args.verify_length (1);
	Player * p = GetPlayer();

	if (p != NULL)
	{
		Py::ExtensionObject<PyUnit> fromNPC (args[0]);
		Creature *pNPC = fromNPC.extensionObject()->GetCreature();

		if ( pNPC )
		{
			QuestPacketHandler::getSingleton().SendTaxiList( p->GetSession(), pNPC->GetGUID() );
		}
	}
	return Py::None();
}

Py::Object PyUnit::ext_SendPetitionList (const Py::Tuple& args)
{
	args.verify_length (1);
	Player * p = GetPlayer();

	if (p != NULL)
	{
		Py::ExtensionObject<PyUnit> fromNPC (args[0]);
		Creature *pNPC = fromNPC.extensionObject()->GetCreature();

		if ( pNPC )
		{
			QuestPacketHandler::getSingleton().SendPetitionList( p->GetSession(), pNPC->GetGUID() );
		}
	}
	return Py::None();
}

Py::Object PyUnit::ext_SendBattleList (const Py::Tuple& args)
{
	args.verify_length (1);
	Player * p = GetPlayer();

	if (p != NULL)
	{
		Py::ExtensionObject<PyUnit> fromNPC (args[0]);
		Creature *pNPC = fromNPC.extensionObject()->GetCreature();

		if ( pNPC )
		{
			QuestPacketHandler::getSingleton().SendBattleList( p->GetSession(), pNPC->GetGUID() );
		}
	}
	return Py::None();
}

Py::Object PyUnit::ext_SendBankerList (const Py::Tuple& args)
{
	args.verify_length (1);
	Player * p = GetPlayer();

	if (p != NULL)
	{
		Py::ExtensionObject<PyUnit> fromNPC (args[0]);
		Creature *pNPC = fromNPC.extensionObject()->GetCreature();

		if ( pNPC )
		{
			QuestPacketHandler::getSingleton().SendBankerList( p->GetSession(), pNPC->GetGUID() );
		}
	}
	return Py::None();
}

Py::Object PyUnit::ext_SendInnkeeperList (const Py::Tuple& args)
{
	args.verify_length (1);
	Player * p = GetPlayer();

	if (p != NULL)
	{
		Py::ExtensionObject<PyUnit> fromNPC (args[0]);
		Creature *pNPC = fromNPC.extensionObject()->GetCreature();

		if ( pNPC )
		{
			QuestPacketHandler::getSingleton().SendInnkeeperList( p->GetSession(), pNPC->GetGUID() );
		}
	}
	return Py::None();
}

Py::Object PyUnit::ext_SendSpiritHealerList (const Py::Tuple& args)
{
	args.verify_length (1);
	Player * p = GetPlayer();

	if (p != NULL)
	{
		Py::ExtensionObject<PyUnit> fromNPC (args[0]);
		Creature *pNPC = fromNPC.extensionObject()->GetCreature();

		if ( pNPC )
		{
			QuestPacketHandler::getSingleton().SendSpiritHealerList( p->GetSession(), pNPC->GetGUID() );
		}
	}
	return Py::None();
}

Py::Object PyUnit::ext_SendTabardList (const Py::Tuple& args)
{
	args.verify_length (1);
	Player * p = GetPlayer();

	if (p != NULL)
	{
		Py::ExtensionObject<PyUnit> fromNPC (args[0]);
		Creature *pNPC = fromNPC.extensionObject()->GetCreature();

		if ( pNPC )
		{
			QuestPacketHandler::getSingleton().SendTabardList( p->GetSession(), pNPC->GetGUID() );
		}
	}
	return Py::None();
}

Py::Object PyUnit::ext_SendAuctionerList (const Py::Tuple& args)
{
	args.verify_length (1);
	Player * p = GetPlayer();

	if (p != NULL)
	{
		Py::ExtensionObject<PyUnit> fromNPC (args[0]);
		Creature *pNPC = fromNPC.extensionObject()->GetCreature();

		if ( pNPC )
		{
			QuestPacketHandler::getSingleton().SendAuctionerList( p->GetSession(), pNPC->GetGUID() );
		}
	}
	return Py::None();
}

Py::Object PyUnit::ext_HasSellTables (const Py::Tuple& args)
{
	args.verify_length (0);
	Creature * cr = GetCreature();

	if (cr != NULL)
	{
		SellTemplateMap::iterator iters = objmgr.m_sellTemplates.find (cr->GetEntry());
		if (iters == objmgr.m_sellTemplates.end()) return Py::Int ( 0 );

		return Py::Int ( 1 );
	}

	return Py::Int ( 0 );
}

Py::Object PyUnit::ext_SelectById (const Py::Tuple& args)
{
	if ((args.length() < 3) || (args.length() % 2 != 1)) 
		return Py::Int(0);

	Creature * cr = GetCreature();
	Py::Int def( 0 );

	if (cr != NULL)
	{
		def = args[0];
		Py::Int setdif( 0 );

		for (unsigned int i = 1; i<args.length(); i++)
		{
			setdif = args[i];
			if (((i+2) % 2) == 1)
				if ( cr->GetEntry() == setdif )
				{
					def = args[i+1];
					break;
				}
		}
	}

	return def;
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_GetStoredNPCText (const Py::Tuple& args)
{
	args.verify_length (2);
	Creature * cr = GetCreature();
	Py::Int text (0);

	if (cr != NULL)
	{
		Py::Int bank (args[0]);
		text = args[1];
		
		uint32 link = GetNPCTextAssoc( cr->GetEntry(), bank );
		if ( link != 0 )
			text = Py::Int( (int)link );
	}

	return text;
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_GetStoredText (const Py::Tuple& args)
{
	args.verify_length (2);
	Creature * cr = GetCreature();
	Py::String text;

	if (cr != NULL)
	{
		Py::Int bank (args[0]);
		text = args[1];
		
		char *psts = GetTextAssoc( cr->GetEntry(), bank );
		if ( psts )
			return Py::String( psts );
	}

	return text;
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_SendPOI (const Py::Tuple& args)
{
	args.verify_length (6);
	Player * p = GetPlayer();

	if (p != NULL)
	{
		Py::Int flags (args[0]);
		Py::Float X (args[1]);
		Py::Float Y (args[2]);
		Py::Int icon (args[3]);
		Py::Int data (args[4]);
		Py::String loc (args[5]);

		QuestPacketHandler::getSingleton().SendPointOfInterest( p->GetSession(), X, Y, icon, flags, data, loc.as_std_string() );
	}

	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_SetUpdateFieldValue (const Py::Tuple& args)
{
	args.verify_length (2);
	Player * p = GetPlayer();
	if (p != NULL)
	{
		Py::Int field (args[0]);
		Py::Int value (args[1]);
		if (field >= 1 && field <=10) {
		switch (field)
		{
		case 1: p->SetUInt32Value(PLAYER_FIELD_SESSION_KILLS, (uint32)value); break;
		case 2: p->SetUInt32Value(PLAYER_FIELD_YESTERDAY_KILLS, (uint32)value); break;
		case 3: p->SetUInt32Value(PLAYER_FIELD_LAST_WEEK_KILLS, (uint32)value); break;
		case 4: p->SetUInt32Value(PLAYER_FIELD_THIS_WEEK_KILLS, (uint32)value); break;
		case 5: p->SetUInt32Value(PLAYER_FIELD_THIS_WEEK_CONTRIBUTION, (uint32)value); break;
		case 6: p->SetUInt32Value(PLAYER_FIELD_LIFETIME_HONORBALE_KILLS, (uint32)value); break;
		case 7: p->SetUInt32Value(PLAYER_FIELD_LIFETIME_DISHONORBALE_KILLS, (uint32)value); break;
		case 8: p->SetUInt32Value(PLAYER_FIELD_YESTERDAY_CONTRIBUTION, (uint32)value); break;
		case 9: p->SetUInt32Value(PLAYER_FIELD_LAST_WEEK_CONTRIBUTION, (uint32)value); break;
		case 10: p->SetUInt32Value(PLAYER_FIELD_LAST_WEEK_RANK, (uint32)value); break;
		}
		}

		if (field >= 11 && field <=19) {

		std::stringstream ss;
		ss.rdbuf()->str("");

		switch (field)
		{
		case 11: ss << "UPDATE honor SET PLAYER_FIELD_SESSION_HONORBALE_KILLS = " << (uint32)value; break;
		case 12: ss << "UPDATE honor SET PLAYER_FIELD_TODAY_CONTRIBUTION = " << (uint32)value; break;
		case 13: ss << "UPDATE honor SET PLAYER_FIELD_LIFETIME_HP = " << (uint32)value; break;
		case 14: ss << "UPDATE honor SET PLAYER_FIELD_THIS_WEEK_DISHONORBALE_KILLS = " << (uint32)value; break;
		case 15: ss << "UPDATE honor SET PLAYER_FIELD_YESTERDAY_DISHONORBALE_KILLS = " << (uint32)value; break;
		case 16: ss << "UPDATE honor SET PLAYER_FIELD_SESSION_DISHONORBALE_KILLS = " << (uint32)value; break;
		case 17: ss << "UPDATE honor SET PLAYER_FIELD_LAST_WEEK_DISHONORBALE_KILLS = " << (uint32)value; break;
		//case 18: ss << "UPDATE honor SET PLAYER_FIELD_LAST_VICTIM_NAME = " << (uint32)value; break;
		//case 19: ss << "UPDATE honor SET PLAYER_FIELD_REPEAT_KILLING_FLAG = " << (uint32)value; break;
		}
		sDatabase.Execute (ss.str().c_str());
		}
	}
	return Py::None();
}
//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_GetUpdateFieldValue (const Py::Tuple& args)
{
	args.verify_length (1);
	Player * p = GetPlayer();
	int value = 0;
	if (p != NULL)
	{
		Py::Int field (args[0]);
		if (field >= 1 && field <=10) {
		switch (field)
		{
		case 1: value = p->GetUInt32Value(PLAYER_FIELD_SESSION_KILLS); break;
		case 2: value = p->GetUInt32Value(PLAYER_FIELD_YESTERDAY_KILLS); break;
		case 3: value = p->GetUInt32Value(PLAYER_FIELD_LAST_WEEK_KILLS); break;
		case 4: value = p->GetUInt32Value(PLAYER_FIELD_THIS_WEEK_KILLS); break;
		case 5: value = p->GetUInt32Value(PLAYER_FIELD_THIS_WEEK_CONTRIBUTION); break;
		case 6: value = p->GetUInt32Value(PLAYER_FIELD_LIFETIME_HONORBALE_KILLS); break;
		case 7: value = p->GetUInt32Value(PLAYER_FIELD_LIFETIME_DISHONORBALE_KILLS); break;
		case 8: value = p->GetUInt32Value(PLAYER_FIELD_YESTERDAY_CONTRIBUTION); break;
		case 9: value = p->GetUInt32Value(PLAYER_FIELD_LAST_WEEK_CONTRIBUTION); break;
		case 10: value = p->GetUInt32Value(PLAYER_FIELD_LAST_WEEK_RANK); break;
		}
		}

		if (field >= 11 && field <=19) {

		std::stringstream ss;
		ss.rdbuf()->str("");

		switch (field)
		{
		case 11: ss << "SELECT PLAYER_FIELD_SESSION_HONORBALE_KILLS FROM honor WHERE guid = " << p->GetGUID(); break;
		case 12: ss << "SELECT PLAYER_FIELD_TODAY_CONTRIBUTION FROM honor WHERE guid = " << p->GetGUID(); break;
		case 13: ss << "SELECT PLAYER_FIELD_LIFETIME_HP FROM honor WHERE guid = " << p->GetGUID(); break;
		case 14: ss << "SELECT PLAYER_FIELD_THIS_WEEK_DISHONORBALE_KILLS FROM honor WHERE guid = " << p->GetGUID(); break;
		case 15: ss << "SELECT PLAYER_FIELD_YESTERDAY_DISHONORBALE_KILLS FROM honor WHERE guid = " << p->GetGUID(); break;
		case 16: ss << "SELECT PLAYER_FIELD_SESSION_DISHONORBALE_KILLS FROM honor WHERE guid = " << p->GetGUID(); break;
		case 17: ss << "SELECT PLAYER_FIELD_LAST_WEEK_DISHONORBALE_KILLS FROM honor WHERE guid = " << p->GetGUID(); break;
		//case 18: ss << "SELECT PLAYER_FIELD_LAST_VICTIM_NAME FROM honor WHERE guid = " << p->GetGUID(); break;
		//case 19: ss << "SELECT PLAYER_FIELD_REPEAT_KILLING_FLAG FROM honor WHERE guid = " << p->GetGUID(); break;
		}
		QueryResult* result = sDatabase.Query( ss.str().c_str() );
		Field *fields = result->Fetch();
		value = fields[0].GetUInt32();
		delete result;
		}
	}
	return Py::Int(value);
}


//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_SendSystemMessage (const Py::Tuple& args)
{
	args.verify_length (1);
	Player * p = GetPlayer();

	if (p != NULL)
	{
		Py::String str (args[0]);

		p->GetSession()->SystemMessage( (char*)str.as_std_string().c_str() );
	}

	return Py::None();
}

//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_GetSize (const Py::Tuple& args)
{
	args.verify_length (0);
	
	Unit * c = GetCreature();
	int size = 0;
	if (c != NULL)
	{
		CreatureTemplate *ct = objmgr.GetCreatureTemplate(c->GetEntry());
		size = ct->Size;
	}

	return Py::Int (size);
}
//-----------------------------------------------------------------------------
Py::Object PyUnit::ext_isArmed (const Py::Tuple& args)
{
	args.verify_length (0);

	Player * p = GetPlayer();
	if (p != NULL)
	{
		if (p->GetItemBySlot(EQUIPMENT_SLOT_MAINHAND))	return Py::Int (1);
		if (p->GetItemBySlot(EQUIPMENT_SLOT_OFFHAND))	return Py::Int (1);
		if (p->GetItemBySlot(EQUIPMENT_SLOT_RANGED))	return Py::Int (1);
	}
	return Py::Int (0);
}

//--- END ---