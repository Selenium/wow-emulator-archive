// Copyright (C) 2004 WoW Daemon
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.

#ifndef WOWSERVER_GAMEOBJECT_H
#define WOWSERVER_GAMEOBJECT_H

#include "Object.h"


struct ObjectItem
{
    uint32 itemid;
	int amount;
	uint32 display_id;
};
typedef vector<ObjectItem> GObjectItemVector;

#include <vector>

//-----------------------------------------------------------------------------
// GO Loot templates support data types
//-----------------------------------------------------------------------------
typedef struct {
	uint32	ItemId;
	float	Chance;
} LootGOTemplate;

typedef vector<LootGOTemplate> LootGOTemplateVector;
typedef hash_map<uint32, LootGOTemplateVector *> LootGOTemplateVectorMap;	// key -> obj_id
//-----------------------------------------------------------------------------

class GameObject : public Object
{
public:
    GameObject( );
	~GameObject()
	{
		mQuestIds.clear( );
		mInvolvedQuestIds.clear();
	}

    void Create ( uint32 guidlow, uint32 display_id, uint8 state, uint32 obj_field_entry,
        float scale, uint16 type, uint16 faction, uint32 mapid,
        float x, float y, float z, float ang );

    void Update (int32 p_time);

    void Despawn(uint32 time);

	// -------------

	void managePlayerQuests(Player *pPlayer);

    bool hasQuest(uint32 quest_id);
    bool hasInvolvedQuest(uint32 quest_id);

    void addQuest(uint32 quest_id) { mQuestIds.push_back(quest_id); };
    void addInvolvedQuest(uint32 quest_id) { mInvolvedQuestIds.push_back(quest_id); };

	const char* GetName() const { return m_name.c_str(); };

	// ----------------

    int		getItemAmount(int slot) { return m_ItemAmount[slot]; }
    
	void	setItemAmount(int slot, uint32 value) { m_ItemAmount[slot] = value; }
    
	uint32	getItemId(int slot) { return m_ItemList[slot]; }
    
	bool FillLoot(WorldPacket *data);
	
	bool	hasLoot(){
        bool hasLoot = false;
        for(int i=0;i<10;i++)
            if(m_ItemAmount[i] && m_ItemAmount[i] != 0)
                hasLoot = true;
        return hasLoot;

    }
	
	// GO Looting
	void addItem (uint32 itemid, uint32 amount, uint32 displayid)
    {
		ObjectItem	item;
		
		item.itemid = itemid;
		item.amount = amount;
        item.display_id = displayid;

		item_list.push_back (item);
    }

    // Serialization
    void SaveToDB();
    void LoadFromDB(uint32 guid);
    void DeleteFromDB();
	

protected:
    /// Quest data
    list<uint32> mQuestIds;
    list<uint32> mInvolvedQuestIds;
	
	// GO Looting

	void _generateLoot();    

	GObjectItemVector item_list;

    void _LoadQuests();

    int32 m_RespawnTimer;
    uint32 m_gold;
    uint32 m_ItemList[10],m_ItemAmount[10];
    uint8 m_ItemCount;
    string m_name;
};

struct GameobjectTemplate
{
	uint32	Entry;
	string	Name;
	uint32	Model;
	uint32	Sound[10];
	uint32	Faction;
	uint32	Flags;
	uint32	GType;
	float	Size;
	uint32  Level;
};

#endif

