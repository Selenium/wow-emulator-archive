//
// NameTables.h
//

#ifndef __NAMETABLES_H
#define __NAMETABLES_H

struct NameTableEntry
{
    uint32 id;
    const char *name;
};

inline const char* LookupName(uint32 id, NameTableEntry *table)
{
    for(uint32 i = 0; table[i].name != 0; i++)
    {
        if (table[i].id == id)
            return table[i].name;
    }

    return "UNKNOWN";
}

extern NameTableEntry g_worldOpcodeNames[];

#endif