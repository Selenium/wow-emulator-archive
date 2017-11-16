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

#ifndef __QUESTMGR_H
#define __QUESTMGR_H

#include "Quest.h"
#include "ObjectMgr.h"

class QuestMgr :  public Singleton < QuestMgr >
{
public:

    void AddQuest(Quest* quest)
    {
        m_quests[quest->GetID()] = quest;
    }

    Quest* FindQuest(uint32 questid)
    {
        map<uint32, Quest*>::const_iterator itr = m_quests.find(questid);
        if(itr == m_quests.end())
            return NULL;
        else
            return itr->second;
    }

    // Quest Loading
    bool LoadQuests(char* file);

    uint32 PlayerMeetsReqs(Player* plr, Quest* qst);

    uint32 CalcStatus(Creature* quest_giver, Player* plr);
    uint32 CalcQuestStatus(Creature* quest_giver, Player* plr, QuestRelation* qst);
    uint32 CalcQuestStatus(Creature* quest_giver, Player* plr, Quest* qst, uint8 type);
    uint32 ActiveQuestsCount(Creature* quest_giver, Player* plr);

    //Packet Forging...
    WorldPacket BuildOfferReward(Quest* qst, Creature* qst_giver);
    WorldPacket BuildQuestDetails(Quest* qst, Creature* qst_giver);	
    WorldPacket BuildRequestItems(Quest* qst, Creature* qst_giver);
    WorldPacket BuildQuestComplete(Quest* qst);
    WorldPacket BuildQuestList(Creature* qst_giver, Player* plr);

    WorldPacket BuildQuestUpdateAddKill(Creature* victim, Player* plr, Quest* qst);
    WorldPacket BuildQuestUpdateComplete(Quest* qst);

    void OnPlayerKill(Player* plr, Creature* victim);
    void OnQuestFinished(Player* plr, Quest* qst);

    void LoadNPCQuests(Creature *qst_giver);
private:
    
    map<uint32, Quest*> m_quests;

    map<uint32, list<QuestRelation *>* > m_npc_quests;
    map<uint32, list<QuestRelation *>* > m_obj_quests;
    map<uint32, list<QuestRelation *>* > m_itm_quests;

    template <class T> void _AddQuest(uint32 entryid, Quest *qst, uint8 type);

    template <class T> std::map<uint32, list<QuestRelation *>* >& _GetList();
    template<> std::map<uint32, list<QuestRelation *>* >& _GetList<Creature>()
    {
        return m_npc_quests;
    }
    template<> std::map<uint32, list<QuestRelation *>* >& _GetList<GameObject>()
    {
        return m_obj_quests;
    }
    template<> std::map<uint32, list<QuestRelation *>* >& _GetList<Item>()
    {
        return m_itm_quests;
    }

    template <class T> list<QuestRelation *>* _GetQuestList(uint32 entryid);

    // Quest Loading
    void _RemoveChar(char* c, std::string *str);
    void _CleanLine(std::string *str);
};

#define sQuestMgr QuestMgr::getSingleton()

#endif
