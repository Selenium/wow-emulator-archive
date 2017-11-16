#pragma once

class GameObject;
class Unit;
class Item;

void InitScripting();
void ShutdownScripting();
void RestartScripting();

void * InitThreadScripting();
void ShutdownThreadScripting	(void *state);

uint32 GetNPCTextAssoc(unsigned int creatureId, unsigned int AssocId);
char *GetTextAssoc(unsigned int creatureId, unsigned int AssocId);

void Call_Unit_OnAttacked (Unit *self, Unit *attacker);
void Call_Unit_OnTakeDamage (Unit *self, Unit *attacker);
void Call_Unit_OnThink (Unit *self, uint32 param);
void Call_Unit_OnInitNpc (Unit *self);
void Call_Unit_OnWaypoint (Unit *self, int value);

uint32 Call_Spell_CanCast (uint32 spellId, Unit *caster, Unit *target);
bool Call_Spell_SpellEffect (uint32 spellId, Unit *caster, Unit *target);
bool Call_Aura_ApplyModifier (uint32 auraId, Unit *caster, Unit *target, bool apply,
							  int32 amount, int32 value1, int32 value2);

void Call_PlayerStats_ByRace (Unit *p, bool oneTimeInit);
void Call_PlayerStats_ByClass (Unit *p, bool oneTimeInit);

// Functions located in Functions.py
uint32 Call_CalcXP (Unit *self, Unit *victim);	// XP Calculation
uint32 Call_CalcDR (Unit *self, Unit *victim);	// DamageReduction (DR) Calculation
void Call_CalcReputation (Unit *self, Unit *victim);	// REPUTATION Calculation
void Call_CalcHonor (Unit *self, Unit *victim);	// HONOR Calculation

// Gossip/QM stuff
void Call_Unit_OnGossipHello (Unit *self, Unit *player);
uint32 Call_Unit_OnDialogStatus (Unit *self, Unit *player);
void Call_Unit_OnChooseReward (Unit *self, Unit *player, uint32 questid, uint32 optid);
void Call_Unit_OnGossipSelect (Unit *self, Unit *player, uint32 senderMenu, uint32 action);
void Call_Unit_OnGossipSelectCode (Unit *self, Unit *player, uint32 senderMenu, uint32 action, char *code);
void Call_Unit_OnQuestAccept (Unit *self, Unit *player, uint32 questid);
void Call_Unit_OnQuestComplete (Unit *self, Unit *player, uint32 questid);
void Call_Unit_OnQuestSelect (Unit *self, Unit *player, uint32 questid);
void Call_Item_OnSelect (Item *item, Unit *player, uint32 questid);
void Call_Item_OnQuestAccept (Item *item, Unit *player, uint32 questid);
void Call_Obj_OnSelect (GameObject *go, Unit *player);
void Call_Trigger_OnSelect (Unit *player, uint32 atid, uint32 questid);
void Call_Obj_OnChooseReward (GameObject *self, Unit *player, uint32 questid, uint32 optid);
void Call_Obj_OnQuestAccept (GameObject *self, Unit *player, uint32 questid);


//--- END --- 