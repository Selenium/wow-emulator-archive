#include "stdafx.h"
#include "../Shared/Namespace.h"
#include "PyHandlers.h"

#if 0
#	define PyEval_AcquireLock_Macro	PyEval_AcquireLock()
#	define PyEval_ReleaseLock_Macro	PyEval_ReleaseLock()
#else
#	define PyEval_AcquireLock_Macro	
#	define PyEval_ReleaseLock_Macro	
#endif

//-----------------------------------------------------------------------------
// Global variables for all project
Py::Dict * g_AiGlobals = NULL;

PyInterpreterState * g_pyInterpState;


AuraHandlerMap g_auraMap;

//-----------------------------------------------------------------------------
//
class LudmillaPy: public Py::ExtensionModule<LudmillaPy>
{
public:
	LudmillaPy():
	  Py::ExtensionModule<LudmillaPy>("Ludmilla")
	  {
		  // Damn crap forgot to init this shit
		  PyUnit::init_type();
		  //PyCreature::init_type();

		  add_varargs_method ("RegisterAIModule", &LudmillaPy::ext_RegisterAIModule,
			  "(creatureId, modulePath) Registers script module for specific creature Id.");

		  add_varargs_method ("RegisterGossipModule", &LudmillaPy::ext_RegisterGossipModule,
			  "(npcId, modulePath, showlog) Registers gossip script module for specific npc Id.");

		  add_varargs_method ("RegisterItemHandlerModule", &LudmillaPy::ext_RegisterItemHandlerModule,
			  "(itemId, modulePath, showlog) Registers handler script module for specific item Id.");

		  add_varargs_method ("RegisterGOHandlerModule", &LudmillaPy::ext_RegisterGOHandlerModule,
			  "(goId, modulePath, showlog) Registers handler script module for specific go Id.");

		  add_varargs_method ("RegisterAreaTriggerModule", &LudmillaPy::ext_RegisterAreaTriggerModule,
			  "(triggerId, modulePath, showlog) Registers handler script module for specific trigger Id.");

		  add_varargs_method ("RegisterSpellClass", &LudmillaPy::ext_RegisterSpellClass,
			  "(spellClass) Registers class with handler functions for specific spell Id.");

		  add_varargs_method ("RegisterStoredNPCText", &LudmillaPy::ext_RegisterNPCTextAssoc,
			  "(blockid, npcId, npctextId) Sets a default text for a specified action.");

		  add_varargs_method ("RegisterStoredText", &LudmillaPy::ext_RegisterDefaultTextAssoc,
			  "(blockid, npcId, text) Sets a default text for some action. See an example");

		  add_varargs_method ("RequireServerBuild", &LudmillaPy::ext_RequireServerBuild,
			  "(ver) Returns true if the specified Ludmilla ver. is compatible with this one.");

		  //add_varargs_method ("GetHealth", &LudmillaPy::ext_GetHealth, "");

		  //add_varargs_method("string", &example_module::ex_string, "string( s ) = return string");
		  //add_varargs_method("sum", &example_module::ex_sum, "sum(arglist) = sum of arguments");
		  //add_varargs_method("test", &example_module::ex_test, "test(arglist) runs a test suite");
		  //add_varargs_method("range", &example_module::new_r, "range(start,stop,stride)");
		  //add_keyword_method("kw", &example_module::ex_keyword, "kw()");

		  initialize( "Ludmilla is base module for all scripts in the world." );
	  }

	  virtual ~LudmillaPy() {}

	  Py::Object ext_RegisterAIModule (const Py::Tuple &param);

	  Py::Object ext_RegisterGossipModule (const Py::Tuple &param);
	  Py::Object ext_RegisterItemHandlerModule (const Py::Tuple &param);
	  Py::Object ext_RegisterGOHandlerModule (const Py::Tuple &param);
	  Py::Object ext_RegisterAreaTriggerModule (const Py::Tuple &param);

	  Py::Object ext_RegisterSpellClass (const Py::Tuple &param);
	  Py::Object ext_RegisterAuraHandler (const Py::Tuple &param);
	  Py::Object ext_RegisterNPCTextAssoc (const Py::Tuple &param);
	  Py::Object ext_RegisterDefaultTextAssoc (const Py::Tuple &param);
	  Py::Object ext_RequireServerBuild (const Py::Tuple &param);
	  
private:
};

//-----------------------------------------------------------------------------
//
// Here go implementation functions
//
//-----------------------------------------------------------------------------


char *GetTextAssoc(unsigned int creatureId, unsigned int AssocId)
{
	if (AssocId > ASSOC_TEXT_ENTRIES) return NULL;

	TextAssocMap::iterator	iter = g_TextAssocEntries[AssocId].find (creatureId);
	if (iter == g_TextAssocEntries[AssocId].end()) return NULL;

	return (char*)iter->second.c_str();
}

uint32 GetNPCTextAssoc(unsigned int creatureId, unsigned int AssocId)
{
	if (AssocId > ASSOC_TEXT_ENTRIES) return NULL;

	NPCTextAssocMap::iterator	iter = g_NPCTextAssocEntries[AssocId].find (creatureId);
	if (iter == g_NPCTextAssocEntries[AssocId].end()) return NULL;
	return iter->second;
}

AIModuleInfo *GetAIModule (unsigned int creatureId)
{
	AIModuleInfoMap::iterator	iter = g_AiMap.find (creatureId);
	if (iter == g_AiMap.end()) return NULL;
	return iter->second;
}

GossipModuleInfo *GetGossipModule (unsigned int objId)
{
	GossipModuleInfoMap::iterator	iter = g_GossipMap.find (objId);
	if (iter == g_GossipMap.end()) return NULL;
	return iter->second;
}

QuestItemModuleInfo *GetQuestItemModule (unsigned int objId)
{
	QuestItemModuleInfoMap::iterator	iter = g_ItemMap.find (objId);
	if (iter == g_ItemMap.end()) return NULL;
	return iter->second;
}

QuestGOModuleInfo *GetQuestGOModule (unsigned int objId)
{
	QuestGOModuleInfoMap::iterator	iter = g_GOMap.find (objId);
	if (iter == g_GOMap.end()) return NULL;
	return iter->second;
}

QuestTriggerModuleInfo *GetQuestTriggerModule (unsigned int objId)
{
	QuestTriggerModuleInfoMap::iterator	iter = g_TriggerMap.find (objId);
	if (iter == g_TriggerMap.end()) return NULL;
	return iter->second;
}

//-----------------------------------------------------------------------------
SpellHandlerInfo *GetSpellHandler (unsigned int spellId)
{
	SpellHandlerInfoMap::iterator	iter = g_spellMap.find (spellId);
	if (iter == g_spellMap.end()) return NULL;
	return iter->second;
}

//-----------------------------------------------------------------------------
extern "C" void _init_scripts_module()
{
#if defined(PY_WIN32_DELAYLOAD_PYTHON_DLL)
	Py::InitialisePythonIndirectPy::Interface();
#endif
	static LudmillaPy * static_lud_python = new LudmillaPy;
}

//-----------------------------------------------------------------------------
void InitScripting()
{
	Py_NoSiteFlag = 1;

	PyEval_InitThreads();
	Py_Initialize();

	_init_scripts_module();

	g_AiGlobals = new Py::Dict();
	g_pyInterpState = PyInterpreterState_New();

	// import sys
	// sys.path.append ("./scripts")
	// 
	PyObject	*p = PyImport_ImportModuleEx ("sys", **g_AiGlobals, NULL, NULL);
	Py::Module	mod_sys (p);
	Py::List	path = mod_sys.getAttr ("path");
	path.append (Py::String ("Scripts"));
	path.append (Py::String ("Scripts/sys"));
	path.append (Py::String ("../../Scripts"));
	path.append (Py::String ("../../Scripts/sys"));
	Py_XDECREF (p);

	Log::getSingleton().outBasic ("[Python] AI module...");
	p = PyImport_ImportModuleEx ("startup_ai", **g_AiGlobals, NULL, NULL);
	if (PyErr_Occurred() != NULL) {
		PyErr_Print(); PyErr_Clear();
	}
	Py_XDECREF (p);

	Log::getSingleton().outBasic ("[Python] Gossip/Quest module...");
	p = PyImport_ImportModuleEx ("startup_qm", **g_AiGlobals, NULL, NULL);
	if (PyErr_Occurred() != NULL) {
		PyErr_Print(); PyErr_Clear();
	}
	Py_XDECREF (p);

	Log::getSingleton().outBasic ("[Python] Spells module...");
	p = PyImport_ImportModuleEx ("startup_spells", **g_AiGlobals, NULL, NULL);
	if (PyErr_Occurred() != NULL) {
		PyErr_Print(); PyErr_Clear();
	}
	Py_XDECREF (p);
    
	Log::getSingleton().outBasic ("[Python] Races and Classes module...");
	p = PyImport_ImportModuleEx ("player_class", **g_AiGlobals, NULL, NULL);
	if (PyErr_Occurred() != NULL) {
		PyErr_Print(); PyErr_Clear();
	}
	Py_XDECREF (p);

    Log::getSingleton().outBasic ("[Python] Executables module...");
	p = PyImport_ImportModuleEx ("executables", **g_AiGlobals, NULL, NULL);
	if (PyErr_Occurred() != NULL) {
		PyErr_Print(); PyErr_Clear();
	}
	Py_XDECREF (p);
    
	Log::getSingleton().outBasic ("[Python] Functions module...");
	p = PyImport_ImportModuleEx ("functions", **g_AiGlobals, NULL, NULL);
	if (PyErr_Occurred() != NULL) {
		PyErr_Print(); PyErr_Clear();
	}
	Py_XDECREF (p);

	Log::getSingleton().outBasic ("[Python] scripting initialized ->>>");
	Log::getSingleton().outBasic ("");

	PyEval_ReleaseLock_Macro;
}

//-----------------------------------------------------------------------------
void ShutdownScripting()
{
	Py_Finalize();
	Log::getSingleton().outBasic ("[Python] scripting shut down ->>>");
	Log::getSingleton().outBasic ("");
}

//-----------------------------------------------------------------------------
void RestartScripting()
{
	// Get exclusive access to Python
	//PyThreadState *tstate = PyThreadState_New (g_pyInterpState);
	//PyEval_AcquireThread (tstate);
	//PyEval_AcquireLock_Macro;

	Log::getSingleton().outBasic ("");
	Log::getSingleton().outBasic ("[Python] Restarting scripting...");

	for (int iI = 0; iI < ASSOC_TEXT_ENTRIES; iI++)
	{
		for (TextAssocMap::iterator i = g_TextAssocEntries[iI].begin(); i != g_TextAssocEntries[iI].end(); i++)
			i->second.clear();

		g_TextAssocEntries[iI].clear();
		g_NPCTextAssocEntries[iI].clear();
	}

	for (AIModuleInfoMap::iterator i = g_AiMap.begin(); i != g_AiMap.end(); i++)
		delete i->second;
	g_AiMap.clear();

	for (GossipModuleInfoMap::iterator i = g_GossipMap.begin(); i != g_GossipMap.end(); i++)
		delete i->second;
	g_GossipMap.clear();

	for (QuestItemModuleInfoMap::iterator i = g_ItemMap.begin(); i != g_ItemMap.end(); i++)
		delete i->second;
	g_ItemMap.clear();

	for (QuestGOModuleInfoMap::iterator i = g_GOMap.begin(); i != g_GOMap.end(); i++)
		delete i->second;
	g_GOMap.clear();

	for (QuestTriggerModuleInfoMap::iterator i = g_TriggerMap.begin(); i != g_TriggerMap.end(); i++)
		delete i->second;
	g_TriggerMap.clear();

	for (SpellHandlerInfoMap::iterator i = g_spellMap.begin(); i != g_spellMap.end(); i++)
		delete i->second;
	g_spellMap.clear();

	for (AuraHandlerMap::iterator i = g_auraMap.begin(); i != g_auraMap.end(); i++)
		if (i->second != NULL)
		{
			Py_DECREF (i->second);
			delete i->second;
		}
	g_auraMap.clear();

	// Now reimport main modules
	//
	PyObject * p;

	Log::getSingleton().outBasic ("[Python] Refreshing AI scripts");
	p = PyImport_ImportModuleEx ("startup_ai", **g_AiGlobals, NULL, NULL);
	PyImport_ReloadModule (p);
	if (PyErr_Occurred() != NULL) {
		PyErr_Print(); PyErr_Clear();
	}
	Py_XDECREF (p);

	Log::getSingleton().outBasic ("[Python] Refreshing Gossip/Quest scripts");
	p = PyImport_ImportModuleEx ("startup_qm", **g_AiGlobals, NULL, NULL);
	PyImport_ReloadModule (p);
	if (PyErr_Occurred() != NULL) {
		PyErr_Print(); PyErr_Clear();
	}
	Py_XDECREF (p);

	Log::getSingleton().outBasic ("[Python] Refreshing Spells scripts");
	p = PyImport_ImportModuleEx ("startup_spells", **g_AiGlobals, NULL, NULL);
	PyImport_ReloadModule (p);
	if (PyErr_Occurred() != NULL) {
		PyErr_Print(); PyErr_Clear();
	}
	Py_XDECREF (p);

	Log::getSingleton().outBasic ("[Python] Refreshing Races and Classes scripts");
	p = PyImport_ImportModuleEx ("player_class", **g_AiGlobals, NULL, NULL);
	PyImport_ReloadModule (p);
	if (PyErr_Occurred() != NULL) {
		PyErr_Print(); PyErr_Clear();
	}
	Py_XDECREF (p);

	Log::getSingleton().outBasic ("[Python] Refreshing Executables");
	p = PyImport_ImportModuleEx ("executables", **g_AiGlobals, NULL, NULL);
	PyImport_ReloadModule (p);
	if (PyErr_Occurred() != NULL) {
		PyErr_Print(); PyErr_Clear();
	}
	Py_XDECREF (p);
    
	Log::getSingleton().outBasic ("[Python] Refreshing Functions");
	p = PyImport_ImportModuleEx ("functions", **g_AiGlobals, NULL, NULL);
	PyImport_ReloadModule (p);
	if (PyErr_Occurred() != NULL) {
		PyErr_Print(); PyErr_Clear();
	}
	Py_XDECREF (p);

	//PyEval_ReleaseThread (tstate);
	//PyThreadState_Delete (tstate);
	//PyEval_ReleaseLock_Macro;
}

//-----------------------------------------------------------------------------
void * InitThreadScripting()
{
	PyThreadState *tstate = PyThreadState_New (g_pyInterpState);
	//PyEval_AcquireThread (tstate);
	return (void *)tstate;
}

//-----------------------------------------------------------------------------
void ShutdownThreadScripting (void *state)
{
	PyThreadState *tstate = (PyThreadState *)state;
	//PyEval_ReleaseThread (tstate);
	PyThreadState_Delete (tstate);
}

//-----------------------------------------------------------------------------
// symbol required for the debug version
extern "C"
void InitScripting_d()
{
	InitScripting(); 
}

//-----------------------------------------------------------------------------
Py::Callable * _getModuleFunc (Py::Module & module, char * name)
{
	if (module.hasAttr (name)) {
		return new Py::Callable (module.getAttr (name));
	}
	return NULL;
}

//-----------------------------------------------------------------------------
Py::Object LudmillaPy::ext_RequireServerBuild (const Py::Tuple &param)
{
	param.verify_length (1);
	Py::Int			Build (param[0]);

	if ( (int)Build > VERREVISION ) return Py::Int( 0 );

	if ( VERREVISION - (int)Build > BACK_COMPAT )
		return Py::Int( 0 ); else
		return Py::Int( 1 );
}

//-----------------------------------------------------------------------------
Py::Object LudmillaPy::ext_RegisterAIModule (const Py::Tuple &param)
{
	param.verify_length (3);

	Py::Int			pyCreatureId (param[0]);
	Py::String		pymoduleName (param[1]);
	Py::Int			ShowLog      (param[2]);
	string		moduleName = pymoduleName.as_std_string();

	AIModuleInfoMap::iterator	iter = g_AiMap.find (pyCreatureId);
	if (iter != g_AiMap.end())
		delete iter->second;

	if (ShowLog)
		printf ("Registered module '%s' for creature Id %d\n", moduleName.c_str(), (int)pyCreatureId);

	
	//Py::Module		module (p);
	//Py::Dict		modDict (module.getDict());
	AIModuleInfo	*info = new AIModuleInfo;
	
	Py::List		fromList;
	fromList.append (Py::String ("*"));
	
	PyObject	*p = PyImport_ImportModuleEx (
		(char *)moduleName.c_str(),
		**g_AiGlobals, NULL, //*info->modLocals, 
		*fromList
		);
	if (p == NULL && PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
		delete info;
		return Py::None();
	}

	Py::Module	module (p);
	//Py::Dict	mdict (module.getDict());

	info->Name = moduleName;

	info->func_OnAttacked = _getModuleFunc (module, "OnAttacked");
	info->func_OnTakeDamage = _getModuleFunc (module, "OnTakeDamage");
	info->func_OnThink = _getModuleFunc (module, "OnThink");
	info->func_OnInitNpc = _getModuleFunc (module, "OnInitNpc");
	info->func_OnWaypoint = _getModuleFunc (module, "OnWaypoint");

	//info->pModule = module;

	g_AiMap[(unsigned int)pyCreatureId] = info;

	return Py::None();
}


//---------------------------------------------------------------------
Py::Object LudmillaPy::ext_RegisterNPCTextAssoc (const Py::Tuple &param)
{
	param.verify_length (3);

	Py::Int			pyAssocId (param[0]);
	Py::Int			pyObjId (param[1]);
	Py::Int 		pyNtId  (param[2]);
	uint32          preassoc;

	if ((unsigned int)pyAssocId > ASSOC_TEXT_ENTRIES)
		return Py::None();

	if ( (preassoc = GetNPCTextAssoc( (unsigned int)pyObjId, (unsigned int)pyAssocId )) != 0)
		printf ("  QM WARNING: Association for NPC '%u', BANK '%u' already exists to NPCTEXT '%u' !\n", (unsigned int)pyObjId, (unsigned int)pyAssocId, preassoc);
	

	if ( !GetGossipModule( (unsigned int)pyObjId ) )
	{
		CreatureTemplate *pCreature = objmgr.GetCreatureTemplate( (unsigned int)pyObjId, false);

		if (pCreature)
			printf("  QM WARNING: NPC '%u' : '%s/%s', not added to any category in QM Startup Sequence.\n", (unsigned int)pyObjId, pCreature->Name.c_str(), pCreature->Guild.c_str()); else
			printf("  QM WARNING: NPC '%u' not added to any category in QM Startup Sequence.\n", (unsigned int)pyObjId);
	}

	g_NPCTextAssocEntries[(unsigned int)pyAssocId][(unsigned int)pyObjId] = (unsigned int)pyNtId;

	return Py::None();
}

Py::Object LudmillaPy::ext_RegisterDefaultTextAssoc (const Py::Tuple &param)
{
	param.verify_length (3);

	Py::Int			pyAssocId (param[0]);
	Py::Int			pyObjId (param[1]);
	Py::String		pyText  (param[2]);
	char			*preassoc;

	if ((unsigned int)pyAssocId > ASSOC_TEXT_ENTRIES)
		return Py::None();

	if ( (preassoc = GetTextAssoc( (unsigned int)pyObjId, (unsigned int)pyAssocId )) != NULL)
		printf ("  QM WARNING: Association for NPC '%u', BANK '%u' already exists to TEXT \"%s\" !\n", (unsigned int)pyObjId, (unsigned int)pyAssocId, preassoc);

	if ( !GetGossipModule( (unsigned int)pyObjId ) )
	{
		CreatureTemplate *pCreature = objmgr.GetCreatureTemplate( (unsigned int)pyObjId, false);

		if (pCreature)
			printf("  QM WARNING: NPC '%u' : '%s/%s', not added to any category in QM Startup Sequence.\n", (unsigned int)pyObjId, pCreature->Name.c_str(), pCreature->Guild.c_str()); else
			printf("  QM WARNING: NPC '%u' not added to any category in QM Startup Sequence.\n", (unsigned int)pyObjId);
	}

	g_TextAssocEntries[(unsigned int)pyAssocId][(unsigned int)pyObjId] = pyText;

	return Py::None();
}

	 

//---------------------------------------------------------------------
Py::Object LudmillaPy::ext_RegisterGossipModule (const Py::Tuple &param)
{
	param.verify_length (3);

	Py::Int			pyObjId (param[0]);
	Py::String		pymoduleName (param[1]);
	Py::Int			ShowLog (param[2]);
	string		moduleName = pymoduleName.as_std_string();

	if (ShowLog)
	{
		if (pyObjId != 0)
			printf ("Registered module '%s' for NPC Id %d\n", moduleName.c_str(), (int)pyObjId); else
			printf ("Registered default module '%s' for NPCs\n", moduleName.c_str());
	}

	GossipModuleInfo *info      = GetGossipModule( (unsigned int)pyObjId );
	CreatureTemplate *pCreature;

	if (pyObjId != 0)
		pCreature = objmgr.GetCreatureTemplate( (unsigned int)pyObjId, false); else
		pCreature = NULL;

	if ( info )
	{
		if (pCreature)
			printf("  QM WARNING: NPC '%u' : '%s/%s', already registered with module '%s'.\n", (unsigned int)pyObjId, pCreature->Name.c_str(), pCreature->Guild.c_str(), info->Name.c_str()); else
			printf("  QM WARNING: NPC '%u', already registered with module '%s'.\n", (unsigned int)pyObjId, info->Name.c_str());
	}

/*	if (pCreature)
	{
		if ( ((pCreature->NPCFlags & 1) != 1) && ((pCreature->NPCFlags & 2) != 2))
			printf("  QM WARNING: NPC '%u' : '%s/%s', is missing a Gossip/QM flag!\n", (unsigned int)pyObjId, pCreature->Name.c_str(), pCreature->Guild.c_str());
	}*/

	GossipModuleInfoMap::iterator	iter = g_GossipMap.find (pyObjId);
	if (iter != g_GossipMap.end())
		delete iter->second;

	info = new GossipModuleInfo;
	
	Py::List		fromList;
	fromList.append (Py::String ("*"));
	
	PyObject	*p = PyImport_ImportModuleEx (
		(char *)moduleName.c_str(),
		**g_AiGlobals, NULL,  
		*fromList
		);

	if (p == NULL && PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
		delete info;
		return Py::None();
	}

	Py::Module	module (p);

	info->Name = moduleName;

	info->func_OnGossipHello = _getModuleFunc (module, "OnHello");
	info->func_OnQuestAccept = _getModuleFunc (module, "OnQuestAccept");
	info->func_OnGossipSelect = _getModuleFunc (module, "OnGossipSelect");
	info->func_OnGossipSelectCode = _getModuleFunc (module, "OnGossipSelectCode");
	info->func_OnQuestSelect = _getModuleFunc (module, "OnQuestSelect");
	info->func_OnQuestComplete = _getModuleFunc (module, "OnQuestComplete");
	info->func_OnChooseReward = _getModuleFunc (module, "OnChooseReward");
	info->func_OnDialogStatus = _getModuleFunc (module, "OnDialogStatus");

	g_GossipMap[(unsigned int)pyObjId] = info;

	return Py::None();
}

//---------------------------------------------------------------------
Py::Object LudmillaPy::ext_RegisterItemHandlerModule (const Py::Tuple &param)
{
	param.verify_length (3);

	Py::Int			pyObjId (param[0]);
	Py::String		pymoduleName (param[1]);
	Py::Int			ShowLog (param[2]);
	string		moduleName = pymoduleName.as_std_string();

	QuestItemModuleInfoMap::iterator	iter = g_ItemMap.find (pyObjId);
	if (iter != g_ItemMap.end())
		delete iter->second;
	if (ShowLog)
	{
		if (pyObjId != 0)
			printf ("Registered module '%s' for Item Id %d\n", moduleName.c_str(), (int)pyObjId); else
			printf ("Registered default module '%s' for Items\n", moduleName.c_str());
	}

	QuestItemModuleInfo	*info = new QuestItemModuleInfo;
	
	Py::List		fromList;
	fromList.append (Py::String ("*"));
	
	PyObject	*p = PyImport_ImportModuleEx (
		(char *)moduleName.c_str(),
		**g_AiGlobals, NULL,  
		*fromList
		);

	if (p == NULL && PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
		delete info;
		return Py::None();
	}

	Py::Module	module (p);

	info->Name = moduleName;

	info->func_OnQuestItemSelect = _getModuleFunc (module, "OnItemQuestSelect");
	info->func_OnQuestItemAccept = _getModuleFunc (module, "OnItemQuestAccept");

	g_ItemMap[(unsigned int)pyObjId] = info;

	return Py::None();
}

//---------------------------------------------------------------------
Py::Object LudmillaPy::ext_RegisterGOHandlerModule (const Py::Tuple &param)
{
	param.verify_length (3);

	Py::Int			pyObjId (param[0]);
	Py::String		pymoduleName (param[1]);
	Py::Int			ShowLog (param[2]);
	string		moduleName = pymoduleName.as_std_string();

	QuestGOModuleInfoMap::iterator	iter = g_GOMap.find (pyObjId);
	if (iter != g_GOMap.end())
		delete iter->second;
	if (ShowLog)
	{
		if (pyObjId != 0)
			printf ("Registered module '%s' for GameObject Id %d\n", moduleName.c_str(), (int)pyObjId); else
			printf ("Registered default module '%s' for GameObjects\n", moduleName.c_str());
	}

	QuestGOModuleInfo	*info = new QuestGOModuleInfo;
	
	Py::List		fromList;
	fromList.append (Py::String ("*"));
	
	PyObject	*p = PyImport_ImportModuleEx (
		(char *)moduleName.c_str(),
		**g_AiGlobals, NULL,  
		*fromList
		);

	if (p == NULL && PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
		delete info;
		return Py::None();
	}

	Py::Module	module (p);

	info->Name = moduleName;

	info->func_OnQuestGOSelect = _getModuleFunc (module, "OnGOSelect");
	info->func_OnQuestGOAccept = _getModuleFunc (module, "OnGOQuestAccept");
	info->func_OnQuestGOChooseReward = _getModuleFunc (module, "OnGOChooseReward");

	g_GOMap[(unsigned int)pyObjId] = info;

	return Py::None();
}

//---------------------------------------------------------------------
Py::Object LudmillaPy::ext_RegisterAreaTriggerModule (const Py::Tuple &param)
{
	param.verify_length (3);

	Py::Int			pyObjId (param[0]);
	Py::Int			ShowLog (param[2]);
	Py::String		pymoduleName (param[1]);
	string		moduleName = pymoduleName.as_std_string();

	QuestTriggerModuleInfoMap::iterator	iter = g_TriggerMap.find (pyObjId);
	if (iter != g_TriggerMap.end())
		delete iter->second;

	if (ShowLog)
	{
		if (pyObjId != 0)
			printf ("Registered module '%s' for Area Trigger Id %d\n", moduleName.c_str(), (int)pyObjId); else
			printf ("Registered default module '%s' for Area Triggers\n", moduleName.c_str());
	}

	QuestTriggerModuleInfo	*info = new QuestTriggerModuleInfo;
	
	Py::List		fromList;
	fromList.append (Py::String ("*"));
	
	PyObject	*p = PyImport_ImportModuleEx (
		(char *)moduleName.c_str(),
		**g_AiGlobals, NULL,  
		*fromList
		);

	if (p == NULL && PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
		delete info;
		return Py::None();
	}

	Py::Module	module (p);

	info->Name = moduleName;

	info->func_OnAreaTriggerSelect = _getModuleFunc (module, "OnAreaTrigger");

	g_TriggerMap[(unsigned int)pyObjId] = info;

	return Py::None();
}



//-----------------------------------------------------------------------------
void Call_Unit_OnGossipHello (Unit *self, Unit *player)
{
	GossipModuleInfo *pDefInfo = GetGossipModule ( 0 );
	GossipModuleInfo *pModInfo = GetGossipModule (self->GetEntry());

	if (pModInfo == NULL) pModInfo = pDefInfo;
	if (pModInfo == NULL) return;
	if (pModInfo->func_OnGossipHello == NULL) pModInfo = pDefInfo;
	if (pModInfo->func_OnGossipHello == NULL) return;

	PyEval_AcquireLock_Macro;
	Py::ExtensionObject<PyUnit> pySelf (new PyUnit (self));
	Py::ExtensionObject<PyUnit>	pyPlayer (new PyUnit (player));

	Py::Tuple args (2);
	args[0] = pySelf;
	args[1] = pyPlayer;

	Py::Object result (pModInfo->func_OnGossipHello->apply (args));
	if (PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
	}
	PyEval_ReleaseLock_Macro;
}

uint32 Call_Unit_OnDialogStatus (Unit *self, Unit *player)
{
	GossipModuleInfo *pDefInfo = GetGossipModule ( 0 );
	GossipModuleInfo *pModInfo = GetGossipModule (self->GetEntry());

	if (pModInfo == NULL) pModInfo = pDefInfo;
	if (pModInfo == NULL) return 0;
	if (pModInfo->func_OnDialogStatus == NULL) pModInfo = pDefInfo;
	if (pModInfo->func_OnDialogStatus == NULL) return 0;
	
	PyEval_AcquireLock_Macro;
	Py::ExtensionObject<PyUnit> pySelf (new PyUnit (self));
	Py::ExtensionObject<PyUnit>	pyPlayer (new PyUnit (player));

	Py::Tuple args (2);
	args[0] = pySelf;
	args[1] = pyPlayer;

	Py::Object result (pModInfo->func_OnDialogStatus->apply (args));
	if (PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
	}
	PyEval_ReleaseLock_Macro;

	return Py::Int( result );
}

void Call_Unit_OnChooseReward (Unit *self, Unit *player, uint32 questid, uint32 optid)
{
	GossipModuleInfo *pDefInfo = GetGossipModule ( 0 );
	GossipModuleInfo *pModInfo = GetGossipModule (self->GetEntry());

	if (pModInfo == NULL) pModInfo = pDefInfo;
	if (pModInfo == NULL) return;
	if (pModInfo->func_OnChooseReward == NULL) pModInfo = pDefInfo;
	if (pModInfo->func_OnChooseReward == NULL) return;
	
	PyEval_AcquireLock_Macro;
	Py::ExtensionObject<PyUnit> pySelf (new PyUnit (self));
	Py::ExtensionObject<PyUnit>	pyPlayer (new PyUnit (player));

	Py::Tuple args (4);
	args[0] = pySelf;
	args[1] = pyPlayer;
	args[2] = Py::Int( (int) questid );
	args[3] = Py::Int( (int) optid );

	Py::Object result (pModInfo->func_OnChooseReward->apply (args));
	if (PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
	}
	PyEval_ReleaseLock_Macro;
}

void Call_Unit_OnGossipSelect (Unit *self, Unit *player, uint32 senderMenu, uint32 action)
{
	GossipModuleInfo *pDefInfo = GetGossipModule ( 0 );
	GossipModuleInfo *pModInfo = GetGossipModule (self->GetEntry());

	if (pModInfo == NULL) pModInfo = pDefInfo;
	if (pModInfo == NULL) return;
	if (pModInfo->func_OnGossipSelect == NULL) pModInfo = pDefInfo;
	if (pModInfo->func_OnGossipSelect == NULL) return;
	
	PyEval_AcquireLock_Macro;
	Py::ExtensionObject<PyUnit> pySelf (new PyUnit (self));
	Py::ExtensionObject<PyUnit>	pyPlayer (new PyUnit (player));

	Py::Tuple args (4);
	args[0] = pySelf;
	args[1] = pyPlayer;
	args[2] = Py::Int( (int) senderMenu );
	args[3] = Py::Int( (int) action );

	Py::Object result (pModInfo->func_OnGossipSelect->apply (args));
	if (PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
	}
	PyEval_ReleaseLock_Macro;
}

void Call_Unit_OnGossipSelectCode (Unit *self, Unit *player, uint32 senderMenu, uint32 action, char *code)
{
	GossipModuleInfo *pDefInfo = GetGossipModule ( 0 );
	GossipModuleInfo *pModInfo = GetGossipModule (self->GetEntry());

	if (pModInfo == NULL) pModInfo = pDefInfo;
	if (pModInfo == NULL) return;
	if (pModInfo->func_OnGossipSelectCode == NULL) pModInfo = pDefInfo;
	if (pModInfo->func_OnGossipSelectCode == NULL) return;
	
	PyEval_AcquireLock_Macro;
	Py::ExtensionObject<PyUnit> pySelf (new PyUnit (self));
	Py::ExtensionObject<PyUnit>	pyPlayer (new PyUnit (player));

	Py::Tuple args (5);
	args[0] = pySelf;
	args[1] = pyPlayer;
	args[2] = Py::Int( (int) senderMenu );
	args[3] = Py::Int( (int) action );
	args[4] = Py::String( code );

	Py::Object result (pModInfo->func_OnGossipSelectCode->apply (args));
	if (PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
	}
	PyEval_ReleaseLock_Macro;
}

void Call_Unit_OnQuestAccept (Unit *self, Unit *player, uint32 questid)
{
	GossipModuleInfo *pDefInfo = GetGossipModule ( 0 );
	GossipModuleInfo *pModInfo = GetGossipModule (self->GetEntry());

	if (pModInfo == NULL) pModInfo = pDefInfo;
	if (pModInfo == NULL) return;
	if (pModInfo->func_OnQuestAccept == NULL) pModInfo = pDefInfo;
	if (pModInfo->func_OnQuestAccept == NULL) return;
	
	PyEval_AcquireLock_Macro;
	Py::ExtensionObject<PyUnit> pySelf (new PyUnit (self));
	Py::ExtensionObject<PyUnit>	pyPlayer (new PyUnit (player));

	Py::Tuple args (3);
	args[0] = pySelf;
	args[1] = pyPlayer;
	args[2] = Py::Int( (int) questid );

	Py::Object result (pModInfo->func_OnQuestAccept->apply (args));
	if (PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
	}
	PyEval_ReleaseLock_Macro;
}

void Call_Unit_OnQuestComplete (Unit *self, Unit *player, uint32 questid)
{
	GossipModuleInfo *pDefInfo = GetGossipModule ( 0 );
	GossipModuleInfo *pModInfo = GetGossipModule (self->GetEntry());

	if (pModInfo == NULL) pModInfo = pDefInfo;
	if (pModInfo == NULL) return;
	if (pModInfo->func_OnQuestComplete == NULL) pModInfo = pDefInfo;
	if (pModInfo->func_OnQuestComplete == NULL) return;
	
	PyEval_AcquireLock_Macro;
	Py::ExtensionObject<PyUnit> pySelf (new PyUnit (self));
	Py::ExtensionObject<PyUnit>	pyPlayer (new PyUnit (player));

	Py::Tuple args (3);
	args[0] = pySelf;
	args[1] = pyPlayer;
	args[2] = Py::Int( (int) questid );

	Py::Object result (pModInfo->func_OnQuestComplete->apply (args));
	if (PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
	}
	PyEval_ReleaseLock_Macro;
}



void Call_Unit_OnQuestSelect (Unit *self, Unit *player, uint32 questid)
{
	GossipModuleInfo *pDefInfo = GetGossipModule ( 0 );
	GossipModuleInfo *pModInfo = GetGossipModule (self->GetEntry());

	if (pModInfo == NULL) pModInfo = pDefInfo;
	if (pModInfo == NULL) return;
	if (pModInfo->func_OnQuestSelect == NULL) pModInfo = pDefInfo;
	if (pModInfo->func_OnQuestSelect == NULL) return;
	
	PyEval_AcquireLock_Macro;
	Py::ExtensionObject<PyUnit> pySelf (new PyUnit (self));
	Py::ExtensionObject<PyUnit>	pyPlayer (new PyUnit (player));

	Py::Tuple args (3);
	args[0] = pySelf;
	args[1] = pyPlayer;
	args[2] = Py::Int( (int) questid );

	Py::Object result (pModInfo->func_OnQuestSelect->apply (args));
	if (PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
	}
	PyEval_ReleaseLock_Macro;
}

void Call_Item_OnSelect (Item *item, Unit *player, uint32 questid)
{
	QuestItemModuleInfo *pDefInfo = GetQuestItemModule ( 0 );
	QuestItemModuleInfo *pModInfo = GetQuestItemModule (item->GetEntry());

	if (pModInfo == NULL) pModInfo = pDefInfo;
	if (pModInfo == NULL) return;
	if (pModInfo->func_OnQuestItemSelect == NULL) pModInfo = pDefInfo;
	if (pModInfo->func_OnQuestItemSelect == NULL) return;


	PyEval_AcquireLock_Macro;
	Py::ExtensionObject<PyUnit>	pyPlayer (new PyUnit (player));

	Py::Tuple args (4);
	args[0] = Py::Int ( (int)item->GetGUIDLow() );
	args[1] = Py::Int ( (int)item->GetGUIDHigh() );
	args[2] = pyPlayer;
	args[3] = Py::Int ( (int) questid );

	Py::Object result (pModInfo->func_OnQuestItemSelect->apply (args));

	if (PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
	}
	PyEval_ReleaseLock_Macro;
}

void Call_Item_OnQuestAccept (Item *item, Unit *player, uint32 questid)
{
	QuestItemModuleInfo *pDefInfo = GetQuestItemModule ( 0 );
	QuestItemModuleInfo *pModInfo = GetQuestItemModule (item->GetEntry());

	if (pModInfo == NULL) pModInfo = pDefInfo;
	if (pModInfo == NULL) return;
	if (pModInfo->func_OnQuestItemAccept == NULL) pModInfo = pDefInfo;
	if (pModInfo->func_OnQuestItemAccept == NULL) return;
	
	PyEval_AcquireLock_Macro;
	Py::ExtensionObject<PyUnit>	pyPlayer (new PyUnit (player));

	Py::Tuple args (4);
	args[0] = Py::Int ( (int)item->GetGUIDLow() );
	args[1] = Py::Int ( (int)item->GetGUIDHigh() );
	args[2] = pyPlayer;
	args[3] = Py::Int ( (int) questid );

	Py::Object result (pModInfo->func_OnQuestItemAccept->apply (args));
	if (PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
	}
	PyEval_ReleaseLock_Macro;
}

void Call_Obj_OnSelect (GameObject *go, Unit *player)
{
	QuestGOModuleInfo *pDefInfo = GetQuestGOModule ( 0 );
	QuestGOModuleInfo *pModInfo = GetQuestGOModule (go->GetEntry());

	if (pModInfo == NULL) pModInfo = pDefInfo;
	if (pModInfo == NULL) return;
	if (pModInfo->func_OnQuestGOSelect == NULL) pModInfo = pDefInfo;
	if (pModInfo->func_OnQuestGOSelect == NULL) return;

	PyEval_AcquireLock_Macro;
	Py::ExtensionObject<PyUnit>	pyPlayer (new PyUnit (player));

	Py::Tuple args (3);
	args[0] = Py::Int ( (int)go->GetGUIDLow() );
	args[1] = Py::Int ( (int)go->GetGUIDHigh() );
	args[2] = pyPlayer;

	Py::Object result (pModInfo->func_OnQuestGOSelect->apply (args));
	if (PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
	}
	PyEval_ReleaseLock_Macro;
}

void Call_Trigger_OnSelect (Unit *player, uint32 atid, uint32 questid)
{
	QuestTriggerModuleInfo *pDefInfo = GetQuestTriggerModule ( 0 );
	QuestTriggerModuleInfo *pModInfo = GetQuestTriggerModule (atid);

	if (pModInfo == NULL) pModInfo = pDefInfo;
	if (pModInfo == NULL) return;
	if (pModInfo->func_OnAreaTriggerSelect == NULL) pModInfo = pDefInfo;
	if (pModInfo->func_OnAreaTriggerSelect == NULL) return;

	PyEval_AcquireLock_Macro;
	Py::ExtensionObject<PyUnit>	pyPlayer (new PyUnit (player));

	Py::Tuple args (3);
	args[0] = pyPlayer;
	args[1] = Py::Int( (int) atid );
	args[2] = Py::Int( (int) questid );

	Py::Object result (pModInfo->func_OnAreaTriggerSelect->apply (args));
	if (PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
	}
	PyEval_ReleaseLock_Macro;
}


void Call_Obj_OnChooseReward (GameObject *self, Unit *player, uint32 questid, uint32 optid)
{
	QuestGOModuleInfo *pDefInfo = GetQuestGOModule ( 0 );
	QuestGOModuleInfo *pModInfo = GetQuestGOModule (self->GetEntry());

	if (pModInfo == NULL) pModInfo = pDefInfo;
	if (pModInfo == NULL) return;
	if (pModInfo->func_OnQuestGOChooseReward == NULL) pModInfo = pDefInfo;
	if (pModInfo->func_OnQuestGOChooseReward == NULL) return;
	
	PyEval_AcquireLock_Macro;
	Py::ExtensionObject<PyUnit>	pyPlayer (new PyUnit (player));

	Py::Tuple args (5);
	args[0] = Py::Int ( (int)self->GetGUIDLow() );
	args[1] = Py::Int ( (int)self->GetGUIDHigh() );
	args[2] = pyPlayer;
	args[3] = Py::Int( (int) questid );
	args[4] = Py::Int( (int) optid );

	Py::Object result (pModInfo->func_OnQuestGOChooseReward->apply (args));
	if (PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
	}
	PyEval_ReleaseLock_Macro;
}

void Call_Obj_OnQuestAccept (GameObject *self, Unit *player, uint32 questid)
{
	QuestGOModuleInfo *pDefInfo = GetQuestGOModule ( 0 );
	QuestGOModuleInfo *pModInfo = GetQuestGOModule (self->GetEntry());

	if (pModInfo == NULL) pModInfo = pDefInfo;
	if (pModInfo == NULL) return;
	if (pModInfo->func_OnQuestGOAccept == NULL) pModInfo = pDefInfo;
	if (pModInfo->func_OnQuestGOAccept == NULL) return;
	
	PyEval_AcquireLock_Macro;
	Py::ExtensionObject<PyUnit>	pyPlayer (new PyUnit (player));

	Py::Tuple args (4);
	args[0] = Py::Int ( (int)self->GetGUIDLow() );
	args[1] = Py::Int ( (int)self->GetGUIDHigh() );
	args[1] = pyPlayer;
	args[2] = Py::Int( (int) questid );

	Py::Object result (pModInfo->func_OnQuestGOAccept->apply (args));
	if (PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
	}
	PyEval_ReleaseLock_Macro;
}
//-----------------------------------------------------------------------------
void Call_Unit_OnAttacked (Unit *self, Unit *attacker)
{
	AIModuleInfo *pModInfo = GetAIModule (self->GetEntry());
	if (pModInfo == NULL) return;
	if (pModInfo->func_OnAttacked == NULL) return;
	
	PyEval_AcquireLock_Macro;
	Py::ExtensionObject<PyUnit> pySelf (new PyUnit (self));
	Py::ExtensionObject<PyUnit>	pyAttacker (new PyUnit (attacker));

	Py::Tuple args (2);
	args[0] = pySelf;
	args[1] = pyAttacker;

	Py::Object result (pModInfo->func_OnAttacked->apply (args));
	if (PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
	}
	PyEval_ReleaseLock_Macro;
}

//-----------------------------------------------------------------------------
void Call_Unit_OnTakeDamage (Unit *self, Unit *attacker)
{
	AIModuleInfo *pModInfo = GetAIModule (self->GetEntry());
	if (pModInfo == NULL) return;
	if (pModInfo->func_OnTakeDamage == NULL) return;

	PyEval_AcquireLock_Macro;
	Py::ExtensionObject<PyUnit> pySelf (new PyUnit (self));
	Py::ExtensionObject<PyUnit>	pyAttacker (new PyUnit (attacker));

	Py::Tuple args (2);
	args[0] = pySelf;
	args[1] = pyAttacker;

	Py::Object result (pModInfo->func_OnTakeDamage->apply (args));
	if (PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
	}
	PyEval_ReleaseLock_Macro;
}

//-----------------------------------------------------------------------------
void Call_Unit_OnThink (Unit *self, uint32 param)
{
	AIModuleInfo *pModInfo = GetAIModule (self->GetEntry());
	if (pModInfo == NULL) return;
	if (pModInfo->func_OnThink == NULL) return;

	PyEval_AcquireLock_Macro;
	Py::ExtensionObject<PyUnit> pySelf (new PyUnit (self));

	Py::Tuple args (2);
	args[0] = pySelf;
	args[1] = Py::Int ((int)param);

	Py::Object result (pModInfo->func_OnThink->apply (args));
	if (PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
	}
	PyEval_ReleaseLock_Macro;
}

//-----------------------------------------------------------------------------
void Call_Unit_OnInitNpc (Unit *self)
{
	AIModuleInfo *pModInfo = GetAIModule (self->GetEntry());
	if (pModInfo == NULL) return;
	if (pModInfo->func_OnInitNpc == NULL) return;

	PyEval_AcquireLock_Macro;
	Py::ExtensionObject<PyUnit> pySelf (new PyUnit (self));

	Py::Tuple args (1);
	args[0] = pySelf;

	Py::Object result (pModInfo->func_OnInitNpc->apply (args));
	if (PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
	}
	PyEval_ReleaseLock_Macro;
}

//-----------------------------------------------------------------------------
void Call_Unit_OnWaypoint (Unit *self, int value)
{
	AIModuleInfo *pModInfo = GetAIModule (self->GetEntry());
	if (pModInfo == NULL) return;
	if (pModInfo->func_OnInitNpc == NULL) return;

	PyEval_AcquireLock_Macro;

	Py::ExtensionObject<PyUnit> pySelf (new PyUnit (self));
	Py::Int pyValue (value);

	Py::Tuple args (2);
	args[0] = pySelf;
	args[1] = pyValue;

	Py::Object result (pModInfo->func_OnWaypoint->apply (args));
	if (PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
	}
	PyEval_ReleaseLock_Macro;
}

//-----------------------------------------------------------------------------
Py::Callable * _getObjectFunc (Py::Object & obj, char * name)
{
	if (obj.hasAttr (name)) {
		return new Py::Callable (obj.getAttr (name));
	}
	return NULL;
}

//-----------------------------------------------------------------------------
Py::Object LudmillaPy::ext_RegisterSpellClass (const Py::Tuple &param)
{
	param.verify_length (2);

	Py::Int		pySpellId (param[0]);
	Py::Object	pyObj (param[1]);

	SpellHandlerInfoMap::iterator	iter = g_spellMap.find (pySpellId);
	if (iter != g_spellMap.end())
		delete iter->second;

	printf ("Registered handler class for Spell Id %d\n", (int)pySpellId);

	SpellHandlerInfo	*info = new SpellHandlerInfo;

	info->pyObject = pyObj;
	info->func_OverrideCastTime		= _getObjectFunc (pyObj, "OverrideCastTime");
	info->func_OverrideSpellRadius	= _getObjectFunc (pyObj, "OverrideSpellRadius");;
	info->func_OverrideDuration		= _getObjectFunc (pyObj, "OverrideDuration");;
	info->func_OverrideManaCost		= _getObjectFunc (pyObj, "OverrideManaCost");;
	info->func_CanCast				= _getObjectFunc (pyObj, "CanCast");;
	info->func_SpellEffect			= _getObjectFunc (pyObj, "SpellEffect");;

	g_spellMap[(unsigned int)pySpellId] = info;

	return Py::None();
}

//-----------------------------------------------------------------------------
uint32 Call_Spell_CanCast (uint32 spellId, Unit *caster, Unit *target)
{
	SpellHandlerInfo *pModInfo = GetSpellHandler (spellId);
	if (pModInfo == NULL) return 0;	// can cast
	if (pModInfo->func_CanCast == NULL) return 0; // can cast

	PyEval_AcquireLock_Macro;

	Py::ExtensionObject<PyUnit> pyCaster (new PyUnit (caster));
	Py::ExtensionObject<PyUnit>	pyTarget (new PyUnit (target));

	Py::Tuple args (2);
	//args[0] = pModInfo->pyObject;
	args[0] = pyCaster;
	args[1] = pyTarget;

	pModInfo->pyObject.increment_reference_count();
	Py::Object result (pModInfo->func_CanCast->apply (args));
	if (PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
		
		PyEval_ReleaseLock_Macro;
		return 0; // can cast
	}
	PyEval_ReleaseLock_Macro;
	return Py::Int (result);
}

//-----------------------------------------------------------------------------
bool Call_Spell_SpellEffect (uint32 spellId, Unit *caster, Unit *target)
{
	SpellHandlerInfo *pModInfo = GetSpellHandler (spellId);
	if (pModInfo == NULL) return false;
	if (pModInfo->func_SpellEffect == NULL) return false;

	PyEval_AcquireLock_Macro;
	Py::ExtensionObject<PyUnit> pyCaster (new PyUnit (caster));
	Py::ExtensionObject<PyUnit>	pyTarget (new PyUnit (target));

	Py::Tuple args (2);
	//args[0] = pModInfo->pyObject;
	args[0] = pyCaster;
	args[1] = pyTarget;

	pModInfo->pyObject.increment_reference_count();
	Py::Object result (pModInfo->func_SpellEffect->apply (args));
	if (PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
		return false;
	}

	PyEval_ReleaseLock_Macro;
	return true;
}

//-----------------------------------------------------------------------------
//
// AURA HANDLERS REGISTRATION AND CALLING INTERFACE
//
//-----------------------------------------------------------------------------
PyObject * GetAuraHandler (unsigned int auraId)
{
	AuraHandlerMap::iterator	iter = g_auraMap.find (auraId);
	if (iter == g_auraMap.end()) return NULL;
	return iter->second;
}

//-----------------------------------------------------------------------------
Py::Object LudmillaPy::ext_RegisterAuraHandler (const Py::Tuple &param)
{
	param.verify_length (2);

	Py::Int		pyAuraId (param[0]);
	Py::Object	pyHandler (param[1]);

	AuraHandlerMap::iterator	iter = g_auraMap.find (pyAuraId);
	if (iter != g_auraMap.end())
		delete iter->second;

	printf ("Registered handler func for Aura Id %d\n", (int)pyAuraId);

	g_auraMap[(unsigned int)pyAuraId] = *pyHandler;

	return Py::None();
}

//-----------------------------------------------------------------------------
bool Call_Aura_ApplyModifier (uint32 auraId, Unit *caster, Unit *target, bool apply,
							  int32 amount, int32 value1, int32 value2)
{
	PyObject * pyHandler_ = GetAuraHandler (auraId);
	if (pyHandler_ == NULL) return false;

	PyEval_AcquireLock_Macro;

	Py::ExtensionObject<PyUnit> pyCaster (new PyUnit (caster));
	Py::ExtensionObject<PyUnit>	pyTarget (new PyUnit (target));

	Py::Tuple args (6);
	args[0] = pyCaster;
	args[1] = pyTarget;
	args[2] = Py::Int ((int32)apply);
	args[3] = Py::Int (amount);
	args[4] = Py::Int (value1);
	args[5] = Py::Int (value2);

	Py::Callable pyHandler (pyHandler_);
	pyHandler.increment_reference_count();
	Py::Object result (pyHandler.apply (args));

	if (PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
		return false;
	}

	PyEval_ReleaseLock_Macro;
	return true;
}

//-----------------------------------------------------------------------------
//
//  BY RACE AND BY CLASS INITIALIZATION
//
//-----------------------------------------------------------------------------
void _Call_RaceClassInit (char *funcName, Unit *p, bool oneTimeInit)
{
	PyEval_AcquireLock_Macro;

	Py::ExtensionObject<PyUnit> pyPlayer (new PyUnit (p));

	Py::Tuple args (2);
	args[0] = pyPlayer;
	args[1] = Py::Int ( int(oneTimeInit) );

	PyObject	*pyo = PyImport_ImportModuleEx ("player_class", **g_AiGlobals, NULL, NULL);
	Py::Module	module (pyo);
	Py_XDECREF (pyo);

	Py::Callable pyProc (module.getAttr (funcName));
	Py::Object result (pyProc.apply (args));
	if (PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
	}
	PyEval_ReleaseLock_Macro;
}

//-----------------------------------------------------------------------------
void Call_PlayerStats_ByRace  (Unit *p, bool oneTimeInit)
{
	uint8	rc = p->GetRace();
	switch (rc)
	{
	case RACE_DWARF: _Call_RaceClassInit ("Dwarf", p, oneTimeInit); break;
	case RACE_GNOME: _Call_RaceClassInit ("Gnome", p, oneTimeInit); break;
	case RACE_HUMAN: _Call_RaceClassInit ("Human", p, oneTimeInit); break;
	case RACE_NIGHT_ELF: _Call_RaceClassInit ("NightElf", p, oneTimeInit); break;
	case RACE_ORC: _Call_RaceClassInit ("Orc", p, oneTimeInit); break;
	case RACE_TAUREN: _Call_RaceClassInit ("Tauren", p, oneTimeInit); break;
	case RACE_TROLL: _Call_RaceClassInit ("Troll", p, oneTimeInit); break;
	case RACE_UNDEAD: _Call_RaceClassInit ("Undead", p, oneTimeInit); break;
	}
}

//-----------------------------------------------------------------------------
void Call_PlayerStats_ByClass (Unit *p, bool oneTimeInit)
{
	uint8	cls = p->GetClass();
	switch (cls)
	{
	case CLASS_WARRIOR : _Call_RaceClassInit ("Warrior", p, oneTimeInit); break;
	case CLASS_PALADIN : _Call_RaceClassInit ("Paladin", p, oneTimeInit); break;
	case CLASS_HUNTER  : _Call_RaceClassInit ("Hunter", p, oneTimeInit); break;
	case CLASS_ROGUE   : _Call_RaceClassInit ("Rogue", p, oneTimeInit); break;
	case CLASS_PRIEST  : _Call_RaceClassInit ("Priest", p, oneTimeInit); break;
	case CLASS_SHAMAN  : _Call_RaceClassInit ("Shaman", p, oneTimeInit); break;
	case CLASS_MAGE    : _Call_RaceClassInit ("Mage", p, oneTimeInit); break;
	case CLASS_WARLOCK : _Call_RaceClassInit ("Warlock", p, oneTimeInit); break;
	case CLASS_DRUID   : _Call_RaceClassInit ("Druid", p, oneTimeInit); break;
	}	
}

//-----------------------------------------------------------------------------
uint32 _Call_Functions (char *funcName, Unit *self, Unit *victim)
{
	PyEval_AcquireLock_Macro;

	Py::ExtensionObject<PyUnit> pySelf (new PyUnit (self));
	Py::ExtensionObject<PyUnit>	pyVictim (new PyUnit (victim));

	Py::Tuple args (2);
	args[0] = pySelf;
	args[1] = pyVictim;

	PyObject	*pyo = PyImport_ImportModuleEx ("functions", **g_AiGlobals, NULL, NULL);
	Py::Module	module (pyo);
	Py_XDECREF (pyo);

	Py::Callable pyProc (module.getAttr (funcName));
	Py::Object result (pyProc.apply (args));
	if (PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
	}
	PyEval_ReleaseLock_Macro;

	return uint32 (Py::Int (result));
}

//-----------------------------------------------------------------------------
void _Call_Executables (char *funcName, Unit *self, Unit *victim)
{
	PyEval_AcquireLock_Macro;

	Py::ExtensionObject<PyUnit> pySelf (new PyUnit (self));
	Py::ExtensionObject<PyUnit>	pyVictim (new PyUnit (victim));

	Py::Tuple args (2);
	args[0] = pySelf;
	args[1] = pyVictim;

	PyObject	*pyo = PyImport_ImportModuleEx ("executables", **g_AiGlobals, NULL, NULL);
	Py::Module	module (pyo);
	Py_XDECREF (pyo);

	Py::Callable pyProc (module.getAttr (funcName));
	Py::Object result (pyProc.apply (args));
	if (PyErr_Occurred() != NULL) {
		PyErr_Print();
		PyErr_Clear();
	}
	PyEval_ReleaseLock_Macro;

}

//-----------------------------------------------------------------------------
uint32 Call_CalcXP (Unit *self, Unit *victim)
{
	return _Call_Functions ("CalcXP", self, victim);
}
//-----------------------------------------------------------------------------
uint32 Call_CalcDR (Unit *self, Unit *victim)
{
	return _Call_Functions ("CalcDR", self, victim);
}
//-----------------------------------------------------------------------------
void Call_CalcReputation (Unit *killer, Unit *victim)
{
	return _Call_Executables ("CalcReputation", killer, victim);
}
//-----------------------------------------------------------------------------
void Call_CalcHonor (Unit *self, Unit *victim)
{
	return _Call_Executables ("CalcCP", self, victim);
}

//--- END ---