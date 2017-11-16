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

#include "Quest.h"
#include "Log.h"
#include "QuestMgr.h"

Quest::Quest() 
{
    m_quest_flags = 0;
    m_quest_copper_reward = 0;
    m_quest_id = 0;
    m_quest_objective_type = 0;

    m_quest_title = "title text missing";
    m_quest_description = "description text missing";
    m_quest_description_2 = "";
    m_quest_objective = "objective text missing";
    m_quest_incomplete = "incomplete text missing"; //tmp
    m_quest_finished = "finished text missing"; //tmp
    m_quest_level = 0;
    m_quest_repeatable = false;

    // Quest Objectives
    m_quest_objective_type = 0;
    m_quest_required_copper = 0;

    // Quest Requisitions
    m_quest_level_req = 0;

    // Quest Rewards
    m_quest_copper_reward = 0;
    m_quest_xp = 100;

    m_quest_zone = 0;

    m_quest_srcitem = 0;
    m_quest_faction = 0;
    m_quest_elite = 0;
    m_quest_next_quest = 0;
}


//Pakcet Building
/////////////////

WorldPacket Quest::BuildQueryResponse()
{
    WorldPacket data;
    int i;
    uint32 items[4];
    uint32 mobs[4];
    
    memset(items, 0, sizeof(uint32)*4);
    memset(mobs, 0, sizeof(uint32)*4);
   
    map<uint32, uint8>::iterator iter;

    data.Initialize(SMSG_QUEST_QUERY_RESPONSE);

    data << uint32(this->m_quest_id);
    data << uint32(this->m_quest_level_req);
    data << uint32(this->m_quest_level);
    data << uint32(this->m_quest_zone);

    data << uint32(0); //unk
    data << uint32(0); //unk - might be faction
    data << uint32(0); //unk
    data << uint32(0); //unk
    
    data << uint32(0); //unk
    data << uint32(this->m_quest_next_quest);
    data << uint32(this->m_quest_copper_reward);
    data << uint32(0); //unk

    data << uint32(this->m_quest_srcitem);
    data << uint32(this->m_quest_flags);

    for(iter = m_quest_dynamic_item_reward.begin(), i = 0;
        iter != m_quest_dynamic_item_reward.end() && i < 4; iter++, i++)
    {
        data << uint32(iter->first) << uint32(iter->second);
    }

    for(;i<4;i++)
        data << uint32(0) << uint32(0);

    for(iter = m_quest_static_item_reward.begin(), i = 0;
        iter != m_quest_static_item_reward.end() && i < 4; iter++, i++)
    {
        data << uint32(iter->first) << uint32(iter->second);
    }

    for(;i<4;i++)
        data << uint32(0) << uint32(0);

    data << uint32(0) << uint32(0); //unk
    data << uint32(0) << uint32(0); //unk
    data << uint32(0) << uint32(0); //unk
    data << uint32(0) << uint32(0); //unk

    data << this->m_quest_title.c_str();
    data << this->m_quest_objective.c_str();
    data << this->m_quest_description.c_str();
    data << this->m_quest_description_2.c_str();

    for(iter = m_quest_mobs.begin(), i = 0;
        iter != m_quest_mobs.end() && i < 4; iter++, i++)
    {
        mobs[i] = iter->first;
    }

    for(iter = m_quest_items.begin(), i = 0;
        iter != m_quest_items.end() && i < 4; iter++, i++)
    {
        items[i] = iter->first;
    }

    for(i = 0; i<4; i++)
    {
        if (mobs[i] == 0)
            data << mobs[i] << uint32(0);
        else
            data << mobs[i] << uint32(m_quest_mobs[mobs[i]]);

        if (items[i] == 0)
            data << items[i] << uint32(0);
        else
            data << items[i] << uint32(m_quest_items[items[i]]);
    }

    data << uint32(0); //unk

    return data;
}


/*****************
 * QuestLogEntry *
 *****************/

void QuestLogEntry::Init(Quest* quest, uint64 quest_giver)
{
    map<uint32, uint8>::iterator itr;

    m_quest = quest;
    m_questgiver = quest_giver;

    for(itr = quest->m_quest_mobs.begin(); itr != quest->m_quest_mobs.end(); itr++)
    {
        this->m_killed_mobs.insert(std::map<uint32, uint8>::value_type(itr->first, 0));
    }

    for(itr = quest->m_quest_items.begin(); itr != quest->m_quest_items.end(); itr++)
    {
        this->m_killed_mobs.insert(std::map<uint32, uint8>::value_type(itr->first, 0));
    }
}

bool QuestLogEntry::CanBeFinished()
{
    std::map<uint32, uint8>::const_iterator iter;
    for(iter = GetQuest()->m_quest_mobs.begin();
        iter != GetQuest()->m_quest_mobs.end(); iter++)
    {
        if (iter->second != this->m_killed_mobs[iter->first])
            return false;
    }

    for(iter = GetQuest()->m_quest_items.begin();
        iter != GetQuest()->m_quest_items.end(); iter++)
    {
        if (iter->second != this->m_picked_items[iter->first])
            return false;
    }

    return true;
}

void QuestLogEntry::AddMob(uint32 entryid, uint8 count)
{
    if (entryid == 0)
        return;

    this->m_killed_mobs[entryid] = count;
}

void QuestLogEntry::AddItem(uint32 entryid, uint8 count)
{
    if (entryid == 0)
        return;

    this->m_picked_items[entryid] = count;
}
