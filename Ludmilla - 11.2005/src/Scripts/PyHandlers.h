#pragma once

//-----------------------------------------------------------------------------

typedef struct AIModuleInfo_t 
{
	string		Name;

	Py::Callable	*func_OnAttacked;
	Py::Callable	*func_OnTakeDamage;
	Py::Callable	*func_OnThink;
	Py::Callable	*func_OnInitNpc;
	Py::Callable	*func_OnWaypoint;

	// not work yet
	//Py::Callable	*func_OnMobApproach;
	// not work yet


	//Py::Module	*pModule;
	//Py::Dict	modLocals;

	~AIModuleInfo_t() 
	{
		if (func_OnAttacked != NULL) delete func_OnAttacked;
		if (func_OnTakeDamage != NULL) delete func_OnTakeDamage;
		if (func_OnThink != NULL) delete func_OnThink;
		if (func_OnInitNpc != NULL) delete func_OnInitNpc;
		if (func_OnWaypoint != NULL) delete func_OnWaypoint;
	}
} AIModuleInfo;

typedef hash_map<unsigned int, AIModuleInfo *> AIModuleInfoMap;
extern AIModuleInfoMap	g_AiMap;

//-----------------------------------------------------------------------------
typedef struct GossipModuleInfo_t 
{
	string		Name;

	// Person (NPC) Callables
	Py::Callable	*func_OnGossipHello;
	Py::Callable	*func_OnQuestAccept;
	Py::Callable	*func_OnGossipSelect;
	Py::Callable	*func_OnGossipSelectCode;
	Py::Callable	*func_OnQuestSelect;
	Py::Callable	*func_OnQuestComplete;
	Py::Callable	*func_OnChooseReward;
	Py::Callable	*func_OnDialogStatus;

	~GossipModuleInfo_t() 
	{
		if (func_OnGossipHello != NULL) delete func_OnGossipHello;
		if (func_OnQuestAccept != NULL) delete func_OnQuestAccept;
		if (func_OnGossipSelect != NULL) delete func_OnGossipSelect;
		if (func_OnGossipSelectCode != NULL) delete func_OnGossipSelectCode;
		if (func_OnQuestSelect != NULL) delete func_OnQuestSelect;
		if (func_OnQuestComplete != NULL) delete func_OnQuestComplete;
		if (func_OnChooseReward != NULL) delete func_OnChooseReward;
		if (func_OnDialogStatus != NULL) delete func_OnDialogStatus;
	}
} GossipModuleInfo;

typedef struct QuestItemModuleInfo_t 
{
	string		Name;

	// Item Callables
	Py::Callable	*func_OnQuestItemSelect;
	Py::Callable	*func_OnQuestItemAccept;

	~QuestItemModuleInfo_t() 
	{
		if (func_OnQuestItemSelect != NULL) delete func_OnQuestItemSelect;
		if (func_OnQuestItemAccept != NULL) delete func_OnQuestItemAccept;
	}

} QuestItemModuleInfo;

typedef struct QuestGOModuleInfo_t 
{
	string		Name;

	// GO Callables
	Py::Callable	*func_OnQuestGOSelect;
	Py::Callable	*func_OnQuestGOAccept;
	Py::Callable	*func_OnQuestGOChooseReward;

	~QuestGOModuleInfo_t() 
	{
		if (func_OnQuestGOSelect != NULL) delete func_OnQuestGOSelect;
		if (func_OnQuestGOAccept != NULL) delete func_OnQuestGOAccept;
		if (func_OnQuestGOChooseReward != NULL) delete func_OnQuestGOChooseReward;
	}

} QuestGOModuleInfo;

typedef struct QuestTriggerModuleInfo_t 
{
	string		Name;

	// AreaTrigger Callables
	Py::Callable	*func_OnAreaTriggerSelect;

	~QuestTriggerModuleInfo_t() 
	{
		if (func_OnAreaTriggerSelect != NULL) delete func_OnAreaTriggerSelect;
	}

} QuestTriggerModuleInfo;

typedef hash_map<unsigned int, uint32> NPCTextAssocMap;
typedef hash_map<unsigned int, string> TextAssocMap;

#define ASSOC_TEXT_ENTRIES 10
extern NPCTextAssocMap	g_NPCTextAssocEntries[ASSOC_TEXT_ENTRIES];
extern TextAssocMap g_TextAssocEntries[ASSOC_TEXT_ENTRIES];

typedef hash_map<unsigned int, GossipModuleInfo *> GossipModuleInfoMap;
extern GossipModuleInfoMap		g_GossipMap;

typedef hash_map<unsigned int, QuestItemModuleInfo *> QuestItemModuleInfoMap;
extern QuestItemModuleInfoMap	g_ItemMap;

typedef hash_map<unsigned int, QuestGOModuleInfo *> QuestGOModuleInfoMap;
extern QuestGOModuleInfoMap		g_GOMap;;

typedef hash_map<unsigned int, QuestTriggerModuleInfo *> QuestTriggerModuleInfoMap;
extern QuestTriggerModuleInfoMap g_TriggerMap;

AIModuleInfo *GetAIModule (unsigned int creatureId);
GossipModuleInfo *GetGossipModule (unsigned int objId);
QuestItemModuleInfo *GetQuestItemModule (unsigned int objId);
QuestGOModuleInfo *GetQuestGOModule (unsigned int objId);
QuestTriggerModuleInfo *GetQuestTriggerModule (unsigned int objId);

//-----------------------------------------------------------------------------
typedef struct SpellHandlerInfo_t
{
	Py::Callable	*func_OverrideCastTime;
	Py::Callable	*func_OverrideSpellRadius;
	Py::Callable	*func_OverrideDuration;
	Py::Callable	*func_OverrideManaCost;
	Py::Callable	*func_CanCast;
	Py::Callable	*func_SpellEffect;

	Py::Object		pyObject;

	~SpellHandlerInfo_t() 
	{
		if (func_OverrideCastTime != NULL) delete func_OverrideCastTime;
		if (func_OverrideSpellRadius != NULL) delete func_OverrideSpellRadius;
		if (func_OverrideDuration != NULL) delete func_OverrideDuration;
		if (func_OverrideManaCost != NULL) delete func_OverrideManaCost;
		if (func_CanCast != NULL) delete func_CanCast;
		if (func_SpellEffect != NULL) delete func_SpellEffect;
	}
} SpellHandlerInfo;

SpellHandlerInfo *GetSpellHandler (unsigned int spellId);
typedef hash_map<unsigned int, SpellHandlerInfo *> SpellHandlerInfoMap;
extern SpellHandlerInfoMap	g_spellMap;

//-----------------------------------------------------------------------------
typedef hash_map<unsigned int, PyObject *> AuraHandlerMap;
extern AuraHandlerMap g_auraMap;

//--- END ---
