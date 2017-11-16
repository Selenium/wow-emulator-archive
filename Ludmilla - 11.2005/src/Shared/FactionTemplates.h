#pragma once

#define FACTION_FIGHT_ALL(f)         ((gFactionTemplates[f] & 0x900) != 0)
#define FACTION_FIGHT_ALLIANCE(f)    ((gFactionTemplates[f] & 0xA00) != 0)
#define FACTION_FIGHT_HORDE(f)       ((gFactionTemplates[f] & 0xC00) != 0)
#define FACTION_FIGHT_ENV(f)         ((gFactionTemplates[f] & 0x800) != 0)

#define FACTION_ALL_FRIENDLY(f)      ((gFactionTemplates[f] & 0x090) != 0)
#define FACTION_ALLIANCE_FRIENDLY(f) ((gFactionTemplates[f] & 0x0A0) != 0)
#define FACTION_HORDE_FRIENDLY(f)    ((gFactionTemplates[f] & 0x0C0) != 0)
#define FACTION_ENV_FRIENDLY(f)      ((gFactionTemplates[f] & 0x080) != 0)

#define FACTION_ALL_HOSTILE(f)       ((gFactionTemplates[f] & 0x001) != 0)
#define FACTION_ALLIANCE_HOSTILE(f)  ((gFactionTemplates[f] & 0x002) != 0)
#define FACTION_HORDE_HOSTILE(f)     ((gFactionTemplates[f] & 0x004) != 0)
#define FACTION_ENV_HOSTILE(f)       ((gFactionTemplates[f] & 0x008) != 0)

extern uint16 gFactionTemplates[1555];

void initFactionTemplates();
