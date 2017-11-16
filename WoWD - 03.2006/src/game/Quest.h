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

#ifndef WOWSERVER_QUEST_H
#define WOWSERVER_QUEST_H

#include "Common.h"
#include "Creature.h"
#include "WorldPacket.h"
#include "WorldSession.h"
#include "Opcodes.h"
#include "Database/DatabaseEnv.h"

using namespace std;

class Creature;
class Quest;

enum QUEST_STATUS
{
    QMGR_QUEST_NOT_AVAILABLE            = 0x00,    // There aren't quests avaiable.                   | "No Mark"
    QMGR_QUEST_AVAILABLELOW_LEVEL       = 0x01,    // Quest avaiable, and your level isnt enough.     | "Gray Quotation Mark !"
    QMGR_QUEST_CHAT                     = 0x02,    // Quest avaiable it shows a talk baloon.          | "No Mark"
    QMGR_QUEST_NOT_FINISHED             = 0x03,    // Quest isnt finished yet.                        | "Gray Question ? Mark"
    QMGR_QUEST_REPEATABLE               = 0x04,    // Quest repeatable                                | "Blue Question ? Mark" 
    QMGR_QUEST_AVAILABLE                = 0x05,    // Quest avaiable, and your level is enough        | "Yellow Quotation ! Mark" 
    QMGR_QUEST_FINISHED                 = 0x06,    // Quest has been finished.                        | "Yellow Question  ? Mark"
    //QUEST_ITEM_UPDATE                 = 0x06     // Yellow Question "?" Mark. //Unknown
};

enum QUESTGIVER_QUEST_TYPE
{
    QUESTGIVER_QUEST_START  = 0x01,
    QUESTGIVER_QUEST_END    = 0x02,
};

enum QUEST_TYPE
{
    QUEST_GATHER    = 0x01,
    QUEST_SLAY      = 0x02,
};

class Quest
{
    friend class QuestMgr;
    friend class QuestLogEntry;

public:

    Quest();
    ~Quest() { };

    inline uint32 GetID() { return m_quest_id; };
    inline uint32 GetCopperReward() { return m_quest_copper_reward; }
    inline uint32 GetXP() { return m_quest_xp; }
    inline const char* GetTitle() { return m_quest_title.c_str(); }
    bool IsRepeatable() { return m_quest_repeatable; };
	string GetQuestBehaviour(int slot) { return m_quest_behaviour[slot]; }
    WorldPacket BuildQueryResponse();
	map<uint32,uint8>::iterator GetTurninItemsBegin() { return m_quest_items.begin();};
	map<uint32,uint8>::iterator GetTurninItemsEnd() { return m_quest_items.end();};

private:
    // Quest Properties
    uint32 m_quest_id;
    string m_quest_title;
    string m_quest_description;
    string m_quest_description_2;
    string m_quest_objective;
    string m_quest_incomplete;
    string m_quest_finished;

    uint8 m_quest_level;
    uint32 m_quest_zone;

    uint32 m_quest_srcitem;
    uint32 m_quest_faction;
    uint32 m_quest_elite;
    uint32 m_quest_next_quest;
    uint32 m_quest_flags;
    bool m_quest_repeatable;

    list<uint32> m_quest_recieve_items;

    // Quest Objectives
    uint32 m_quest_objective_type;
    map<uint32,uint8> m_quest_mobs;
    map<uint32,uint8> m_quest_items;
    uint32 m_quest_required_copper;

    // Quest Requisitions
    list<uint32> m_quest_pre_req_quests;
    uint8 m_quest_level_req;

    // Quest Rewards
    uint32 m_quest_copper_reward;
    map<uint32, uint8> m_quest_dynamic_item_reward;
    map<uint32, uint8> m_quest_static_item_reward;
    uint32 m_quest_xp;
    list<uint32> m_quest_spells_reward;

	//Quest Behaviour
	string m_quest_behaviour[3];

};


class QuestLogEntry
{
    friend class QuestMgr;

public:

    QuestLogEntry() {};

    inline Quest* GetQuest() { return m_quest; };
    inline uint64 GetQuestGiver() { return m_questgiver; };

    void AddMob(uint32 entryid, uint8 count);
    void AddItem(uint32 entryid, uint8 count);

    map<uint32,uint8>::iterator GetMobBegin() { return m_killed_mobs.begin(); };
    map<uint32,uint8>::iterator GetMobEnd() { return m_killed_mobs.end(); };
    map<uint32,uint8>::iterator GetItemBegin() { return m_picked_items.begin(); };
    map<uint32,uint8>::iterator GetItemEnd() { return m_picked_items.end(); };

    void Init(Quest* quest, uint64 quest_giver);

    bool CanBeFinished();

private:

    Quest *m_quest;
    uint64 m_questgiver;

    map<uint32,uint8> m_killed_mobs;
    map<uint32,uint8> m_picked_items;
};

#endif
