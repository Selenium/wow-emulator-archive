#include "stdafx.h"
#include "../Shared/Namespace.h"
#include "PyHandlers.h"


/* Text Association */
NPCTextAssocMap	g_NPCTextAssocEntries[ASSOC_TEXT_ENTRIES];
uint32 GetNPCTextAssoc (unsigned int creatureId, unsigned int AssocId);

TextAssocMap g_TextAssocEntries[ASSOC_TEXT_ENTRIES];
char *GetTextAssoc (unsigned int creatureId, unsigned int AssocId);

/**/
GossipModuleInfoMap	g_GossipMap;
QuestItemModuleInfoMap	g_ItemMap;
QuestGOModuleInfoMap g_GOMap;
QuestTriggerModuleInfoMap g_TriggerMap;

//--- END ---