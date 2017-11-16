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


#include "QuestMgr.h"
#include "Player.h"

uint32 QuestMgr::CalcQuestStatus(Creature* quest_giver, Player* plr, QuestRelation* qst)
{
    return CalcQuestStatus(quest_giver, plr, qst->qst, qst->type);
}

uint32 QuestMgr::PlayerMeetsReqs(Player* plr, Quest* qst)
{
    std::list<uint32>::iterator itr;
    uint32 status;

    if (!qst->IsRepeatable())
        status = QMGR_QUEST_AVAILABLE;
    else
        status = QMGR_QUEST_REPEATABLE;

    if (plr->getLevel() < qst->m_quest_level_req)
        status = QMGR_QUEST_AVAILABLELOW_LEVEL;

    for(itr = qst->m_quest_pre_req_quests.begin(); itr != qst->m_quest_pre_req_quests.end(); itr++)
    {
        if (!plr->HasFinishedQuest(*itr))
            status = QMGR_QUEST_NOT_AVAILABLE;
    }

    if (plr->HasFinishedQuest(qst->GetID()))
        status = QMGR_QUEST_NOT_AVAILABLE;

    return status;
}

uint32 QuestMgr::CalcQuestStatus(Creature* quest_giver, Player* plr, Quest* qst, uint8 type)
{
    QuestLogEntry* qle;
    uint32 status = QMGR_QUEST_NOT_AVAILABLE;

    qle = plr->Find_QLE(qst->GetID());

    if (!qle)
    {
        if (type & QUESTGIVER_QUEST_START)
        {
            return PlayerMeetsReqs(plr, qst);
        }
    }
    else
    {
        if (!qle->CanBeFinished())
        {
            return QMGR_QUEST_NOT_FINISHED;
        }
        else
        {
            if (type & QUESTGIVER_QUEST_END) 
            {
                return QMGR_QUEST_FINISHED;                    
            }
            else
            {
                return QMGR_QUEST_NOT_FINISHED;
            }
        }
    }

    return QMGR_QUEST_NOT_AVAILABLE;

}

uint32 QuestMgr::CalcStatus(Creature* quest_giver, Player* plr)
{
    uint32 status = QMGR_QUEST_NOT_AVAILABLE;
    std::list<QuestRelation *>::const_iterator itr;

    if (!quest_giver->HasQuests())
        return status;

    for(itr = quest_giver->QuestsBegin(); itr != quest_giver->QuestsEnd(); itr++) 
        if (CalcQuestStatus(quest_giver, plr, *itr) > status)
            status = CalcQuestStatus(quest_giver, plr, *itr);

    return status;
}


uint32 QuestMgr::ActiveQuestsCount(Creature* quest_giver, Player* plr)
{
    uint32 status = QMGR_QUEST_NOT_AVAILABLE;
    std::list<QuestRelation *>::const_iterator itr;
    map<uint32, uint8> tmp_map;
    uint32 questCount = 0;
    if(quest_giver->HasQuests())
    {
        for(itr = quest_giver->QuestsBegin(); itr != quest_giver->QuestsEnd(); itr++)
        {
            if (CalcQuestStatus(quest_giver, plr, *itr) >= QMGR_QUEST_NOT_FINISHED)
            {
                if (tmp_map.find((*itr)->qst->GetID()) == tmp_map.end())
                {
                    tmp_map.insert(std::map<uint32,uint8>::value_type((*itr)->qst->GetID(), 1));
                    questCount++;
                }
            }
        }
    }

    return questCount;
}

WorldPacket QuestMgr::BuildOfferReward(Quest* qst, Creature* qst_giver)
{
    WorldPacket data;
    std::map<uint32, uint8>::const_iterator itr;

	data.Initialize( SMSG_QUESTGIVER_OFFER_REWARD );

	data << qst_giver->GetGUID();
	data << qst->m_quest_id;
	data << qst->m_quest_title;
	data << qst->m_quest_finished; 

    data << uint8(0x01) << uint8(0x00) << uint8(0x00) << uint8(0x00); //unk1
    data << uint8(0x01) << uint8(0x00) << uint8(0x00) << uint8(0x00); //unk2
    data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00); //unk3
    data << uint8(0x01) << uint8(0x00) << uint8(0x00) << uint8(0x00); //unk4

    data << uint32(qst->m_quest_dynamic_item_reward.size());
    for(itr = qst->m_quest_dynamic_item_reward.begin();
        itr != qst->m_quest_dynamic_item_reward.end(); itr++)
    {
        ItemPrototype *itemProto = objmgr.GetItemPrototype(itr->first);
        //ASSERT(!itemProto);
        // removed assert for testing purposes, until we got a proper db.

        data << uint32(itr->first) << uint32(itr->second);
        if (itemProto)
            data << itemProto->DisplayInfoID;
        else 
            data << uint32(100);
    }
    
    data << uint32(qst->m_quest_static_item_reward.size());
    for(itr = qst->m_quest_static_item_reward.begin();
        itr != qst->m_quest_static_item_reward.end(); itr++)
    {
        ItemPrototype *itemProto = objmgr.GetItemPrototype(itr->first);
        //ASSERT(!itemProto);
        // removed assert for testing purposes, until we got a proper db.

        data << uint32(itr->first) << uint32(itr->second);
        if (itemProto)
            data << itemProto->DisplayInfoID;
        else 
            data << uint32(100);
    }
    
    data << qst->m_quest_copper_reward;
    data << uint8(0x01) << uint8(0x00) << uint8(0x00) << uint8(0x00); //unk
    data << uint32(0); //unk

	return data;
}

WorldPacket QuestMgr::BuildQuestDetails(Quest* qst, Creature* qst_giver)
{
    WorldPacket data;
    std::map<uint32, uint8>::const_iterator itr;

	data.Initialize( SMSG_QUESTGIVER_QUEST_DETAILS );

	data << qst_giver->GetGUID();
	data << qst->m_quest_id;
	data << qst->m_quest_title;
	data << qst->m_quest_description;
	data << qst->m_quest_objective;
	data << uint32 (1); //type?

    data << uint32(qst->m_quest_dynamic_item_reward.size());
    for(itr = qst->m_quest_dynamic_item_reward.begin();
        itr != qst->m_quest_dynamic_item_reward.end(); itr++)
    {
        ItemPrototype *itemProto = objmgr.GetItemPrototype(itr->first);
        //ASSERT(!itemProto);
        // removed assert for testing purposes, until we got a proper db.

        data << uint32(itr->first) << uint32(itr->second);
        if (itemProto)
            data << itemProto->DisplayInfoID;
        else 
            data << uint32(100);
    }
    
    data << uint32(qst->m_quest_static_item_reward.size());
    for(itr = qst->m_quest_static_item_reward.begin();
        itr != qst->m_quest_static_item_reward.end(); itr++)
    {
        ItemPrototype *itemProto = objmgr.GetItemPrototype(itr->first);
        //ASSERT(!itemProto);
        // removed assert for testing purposes, until we got a proper db.

        data << uint32(itr->first) << uint32(itr->second);
        if (itemProto)
            data << itemProto->DisplayInfoID;
        else 
            data << uint32(100);
    }

	data << qst->m_quest_copper_reward;

	data << uint32 (0);
	data << uint32 (4);
	data << uint32 (1);
	data << uint32 (0);
	data << uint32 (0);
	data << uint32 (0);
	data << uint32 (0);
	data << uint32 (0);
	data << uint32 (0);
    data << uint32 (0);

	return data;
}

WorldPacket QuestMgr::BuildRequestItems(Quest* qst, Creature* qst_giver)
{
    WorldPacket data;
    std::map<uint32, uint8>::const_iterator itr;

	data.Initialize( SMSG_QUESTGIVER_REQUEST_ITEMS );
	
    data << qst_giver->GetGUID();
	data << qst->m_quest_id;
	data << qst->m_quest_title;
    data << qst->m_quest_incomplete;

    data << uint32(1);
    data << uint32(0);
    data << uint32(0);
    
    data << qst->m_quest_required_copper; 
    
    data << uint32(qst->m_quest_items.size());
    for(itr = qst->m_quest_items.begin();
        itr != qst->m_quest_items.end(); itr++)
    {
        ItemPrototype *itemProto = objmgr.GetItemPrototype(itr->first);
        //ASSERT(!itemProto);
        // removed assert for testing purposes, until we got a proper db.

        data << uint32(itr->first) << uint32(itr->second);
        if (itemProto)
            data << itemProto->DisplayInfoID;
        else 
            data << uint32(100);
    }

    data << uint32(0);
    data << uint32(0);
    data << uint32(0);
    data << uint32(0);

    return data;
}

WorldPacket QuestMgr::BuildQuestComplete(Quest* qst)
{
    WorldPacket data;    
    
    data.Initialize( SMSG_QUESTGIVER_QUEST_COMPLETE );

    data << qst->GetID();
    data << uint32(3);
    data << uint32(qst->m_quest_xp); //xp
    data << uint32(qst->m_quest_copper_reward);
    data << uint32(0);

    return data;
}

WorldPacket QuestMgr::BuildQuestList(Creature* qst_giver, Player *plr)
{
    list<QuestRelation *>::iterator it;
	WorldPacket data;
    map<uint32, uint8> tmp_map;

	data.Initialize( SMSG_QUESTGIVER_QUEST_LIST );

	data << qst_giver->GetGUID();
	data << ""; //Hello line 
	data << uint32(0);
	data << uint32(0);
	data << uint8(sQuestMgr.ActiveQuestsCount(qst_giver, plr));

	for (it = qst_giver->QuestsBegin(); it != qst_giver->QuestsEnd(); it++)
	{
		if (sQuestMgr.CalcQuestStatus(qst_giver, plr, *it) >= QMGR_QUEST_NOT_FINISHED)
		{
            if (tmp_map.find((*it)->qst->GetID()) == tmp_map.end())
            {
                tmp_map.insert(std::map<uint32,uint8>::value_type((*it)->qst->GetID(), 1));

			    data << (*it)->qst->GetID();
                data << sQuestMgr.CalcQuestStatus(qst_giver, plr, *it);
			    data << uint32(0);
			    data << (*it)->qst->m_quest_title.c_str();
            }
		}
	}

    return data;
}

WorldPacket QuestMgr::BuildQuestUpdateAddKill(Creature* victim, Player* plr, Quest* qst)
{
    WorldPacket data;

    data.Initialize(SMSG_QUESTUPDATE_ADD_KILL);

    data << qst->GetID();
    data << victim->getNameEntry();
    data << uint32(plr->Find_QLE(qst->GetID())->m_killed_mobs.find(victim->getNameEntry())->second);
    data << uint32(qst->m_quest_mobs.find(victim->getNameEntry())->second);
    data << victim->GetGUID();

    return data;
}

WorldPacket QuestMgr::BuildQuestUpdateComplete(Quest* qst)
{
    WorldPacket data;

    data.Initialize(SMSG_QUESTUPDATE_COMPLETE);

    data << qst->GetID();

    return data;
}

void QuestMgr::OnPlayerKill(Player* plr, Creature* victim)
{
    map<uint32, QuestLogEntry *>::iterator itr;
    map<uint32, uint8>::iterator itr2;
    Quest* qst;
    uint32 update_value, offset = 0;

    //loop through all of the player's quests
    for(itr = plr->QuestsBegin(); itr != plr->QuestsEnd(); itr++)
    {
        qst = itr->second->GetQuest();
        //mob in quest's mob list

        if (qst->m_quest_mobs.find(victim->getNameEntry()) != qst->m_quest_mobs.end())
        {
            //quest not finished
            if (qst->m_quest_mobs.find(victim->getNameEntry())->second > 
                itr->second->m_killed_mobs.find(victim->getNameEntry())->second)
            {
                itr->second->m_killed_mobs[victim->getNameEntry()]++; 
                
                ASSERT(plr->GetQuestSlotForEntry(qst->GetID()) != 0);

                update_value = plr->GetUInt32Value(plr->GetQuestSlotForEntry(qst->GetID()) + 1);        
                for(itr2 = qst->m_quest_mobs.begin(); itr2->first != victim->getNameEntry(); itr2++)
                    offset++;
                
                update_value += (1 << (offset*6));
                plr->SetUInt32Value(plr->GetQuestSlotForEntry(qst->GetID()) + 1, update_value);

                plr->GetSession()->SendPacket(&sQuestMgr.BuildQuestUpdateAddKill(victim, plr, qst));
                Log::getSingleton( ).outDebug("WORLD: Sent SMSG_QUESTUPDATE_ADD_KILL");
            }
        }
    }
}

void QuestMgr::OnQuestFinished(Player* plr, Quest* qst)
{
    uint16 quest_slot;
    uint32 new_money;    
    
    //Send complete packet
    plr->GetSession()->SendPacket(&sQuestMgr.BuildQuestUpdateComplete(qst));
    plr->GetSession()->SendPacket(&sQuestMgr.BuildQuestComplete(qst));

    //Modify QLE
    plr->Del_QLE(qst->GetID());

    //Remove from questlog
    quest_slot = plr->GetQuestSlotForEntry(qst->GetID());
    ASSERT(quest_slot != 0);
    plr->SetUInt32Value(quest_slot, 0);
    plr->SetUInt32Value(quest_slot + 1, 0);
    plr->SetUInt32Value(quest_slot + 2, 0);
    
    //Money reward
    new_money = plr->GetUInt32Value(PLAYER_FIELD_COINAGE) + qst->GetCopperReward();
    plr->SetUInt32Value(PLAYER_FIELD_COINAGE, new_money);

    //Xp reward
    plr->GiveXP(qst->GetXP(), 0); //will need a formula for xp gain

    //TODO: item reward

    //Add to finished quests
    if (!qst->IsRepeatable())
        plr->AddToFinishedQuests(qst->GetID());
}

/////////////////////////////////////
//        Quest Management         //
/////////////////////////////////////

void QuestMgr::LoadNPCQuests(Creature *qst_giver)
{
    qst_giver->SetQuestList(this->_GetQuestList<Creature>(qst_giver->getNameEntry()));
}

template <class T> list<QuestRelation *>* QuestMgr::_GetQuestList(uint32 entryid)
{
    std::map<uint32, list<QuestRelation *>* > &olist = _GetList<T>();

    if (olist.find(entryid) == olist.end())
    {
        return NULL;
    }
    else
    {
        return olist.find(entryid)->second;
    }
}

template <class T> void QuestMgr::_AddQuest(uint32 entryid, Quest *qst, uint8 type)
{
    std::map<uint32, list<QuestRelation *>* > &olist = _GetList<T>();
    std::list<QuestRelation *>* nlist;
    QuestRelation *ptr = NULL;

    if (olist.find(entryid) == olist.end())
    {
        nlist = new std::list<QuestRelation *>;

        olist.insert(std::map<uint32, list<QuestRelation *>* >::value_type(entryid, nlist));
    }
    else
    {
        nlist = olist.find(entryid)->second;
    }

	list<QuestRelation *>::iterator it;
	for (it = nlist->begin(); it != nlist->end(); it++)
	{
        if ((*it)->qst == qst)
		{
            ptr = (*it);
			break;
		}
	}

    if (ptr == NULL)
    {
        ptr = new QuestRelation;
        ptr->qst = qst;
        ptr->type = type;

        nlist->push_back(ptr);
    }
    else
    {
        ptr->type |= type;
    }
}

//////////////////////////////////
//        Quest Loading         //
//////////////////////////////////

bool QuestMgr::LoadQuests(char* file)
{
    FILE *f;
    char str[1024];
    string prs, section, subsection, value, val1, val2;
    uint32 currQuest = 0;
    Quest *qst;
	int i = 0;
	char *tok;

    f = fopen(file, "rt");
    if (f == NULL)
    {
        Log::getSingleton().outError("QUESTS: could not open questfile %s.", file);
        return false;
    }

    while(fgets(str,1023,f))
    {
        prs = str;
        _CleanLine(&prs);
        
        if (prs.c_str()[0] == '[')
        {
            if (currQuest)
            {
                this->AddQuest(qst);
            }

            _RemoveChar("[", &prs);
            _RemoveChar("]", &prs);

            if (prs.substr(0, prs.find(" ", 0)) != "Quest")
            {
                sLog.outError("QUESTS: Weird shit happend while loading quests!");
                return false;
            }

            currQuest = atol(prs.substr(prs.find(" ", 0) + 1, prs.length() - prs.find(" ", 0)).c_str());
            qst = new Quest;
            qst->m_quest_id = currQuest;
        }
        else if (currQuest)
        {
            section = prs.substr(0, prs.find("=", 0));
            _RemoveChar(" ", &section);

            if ((int)section.find("{", 0) > 0 )
            {
                subsection = section.substr(section.find("{", 0) + 1, section.length() - 2 - section.find("{", 0));
                section = section.substr(0, section.find("{", 0));
            }
            else
            {
                subsection = "";
            }
            value = prs.substr(prs.find("=", 0) + 1, prs.length() - prs.find("=", 0));
            if (((value != "None") && (section != "")) && (section.c_str()[0] != '_'))
            {
                if (section == "Name")
                    qst->m_quest_title = value.c_str();
                else if (section == "Details")
                    qst->m_quest_description = value.c_str();
                else if (section == "EndText")
                    qst->m_quest_description_2 = value.c_str();
                else if (section == "CompleteText")
                    qst->m_quest_finished = value.c_str();
                else if (section == "IncompleteText")
                    qst->m_quest_incomplete = value.c_str();
                else if (section == "Objectives")
                    qst->m_quest_objective = value.c_str();
                //else if (section == "xp")
                //    qst->m_quest_xp = atol(value.c_str());
                else if (section == "MoneyReward")
                    qst->m_quest_copper_reward = atol(value.c_str());
                //else if (section == "type")
                //    qst->m_quest_objective_type = atol(value.c_str());
                else if (section == "RequiresLevel")
                {
                    //Useless...or so i hear.
                }
                else if (section == "QuestLevel")
                {
                    qst->m_quest_level_req = (uint8)atol(value.c_str());
                    qst->m_quest_level = (uint8)atol(value.c_str());
                }
                else if (section == "OpenedByQuest")
                    qst->m_quest_pre_req_quests.push_back(atol(value.c_str()));
                //else if (section == "srcitem")
                //    qst->m_quest_srcitem = atol(value.c_str());
                else if (section == "NextStoryQuest")
                    qst->m_quest_next_quest = atol(value.c_str());
                else if (section == "Category")
                    qst->m_quest_zone = (uint32)atol(value.c_str());
                else if (section == "ReceiveItem")
                    qst->m_quest_recieve_items.push_back(atol(value.c_str()));
                else if (section == "LearnSpell")
                    qst->m_quest_spells_reward.push_back(atol(value.c_str()));
                //else if (section == "repeatable")
                //    qst->m_quest_repeatable = (bool)atol(value.c_str());
                else if (section == "DescriptiveFlags")
                    qst->m_quest_flags = (uint32)atol(value.c_str());

                else if (section == "KillObjective")
                {
                    _RemoveChar(" ", &value);
                    val1 = value.substr(0, value.find(",", 0));
                    val2 = value.substr(value.find(",", 0) + 1, value.length() - value.find(",", 0));            
                    qst->m_quest_mobs[atol(val1.c_str())] = (uint8)atol(val2.c_str());
                }

                else if (section == "DeliverObjective")
                {
                    _RemoveChar(" ", &value);
                    val1 = value.substr(0, value.find(",", 0));
                    val2 = value.substr(value.find(",", 0) + 1, value.length() - value.find(",", 0));            
                    qst->m_quest_items[atol(val1.c_str())] = (uint8)atol(val2.c_str());
                }

                else if (section == "RewardItem")
                {
                    _RemoveChar(" ", &value);
                    val1 = value.substr(0, value.find(";", 0));
                    val2 = value.substr(value.find(";", 0) + 1, value.length() - value.find(";", 0));            
                    qst->m_quest_static_item_reward[atol(val1.c_str())] = (uint8)atol(val2.c_str());
                }

                else if (section == "RewardItemChoice")
                {
                    _RemoveChar(" ", &value);
                    val1 = value.substr(0, value.find(",", 0));
                    val2 = value.substr(value.find(",", 0) + 1, value.length() - value.find(",", 0));            
                    qst->m_quest_dynamic_item_reward[atol(val1.c_str())] = (uint8)atol(val2.c_str());
                }
                else if (section == "Complexity")
                {
                    // parse it somehow
                }
                else if (section == "ObjectiveText")
                {
                    // parse it somehow
                }
                else if (section == "QuestGiver")
                {
                    if (subsection == "NPC")
                        _AddQuest<Creature>(atol(value.c_str()), qst, 1);
                }
                else if (section == "QuestFinisher")
                {
                    if (subsection == "NPC")
                        _AddQuest<Creature>(atol(value.c_str()), qst, 2);                    
                }
                else if (section == "RequiresRace")
                {
                    // parse it somehow
                }
                else if (section == "RequiresClass")
                {
                    // parse it somehow
                }
                else if (section == "RequiresTradeSkill")
                {
                    // parse it somehow
                }
                else if (section == "ReputationObjective")
                {
                    // parse it somehow
                }
                else if (section == "QuestBehavior")
                {
					tok = strtok((char *)value.c_str(),", ");
					if(!tok)
						break;
					qst->m_quest_behaviour[i] = tok;
					for(i = 1;i < 3;i++)
					{
						tok = strtok(NULL,", ");
						if(tok == NULL)
							break;
						qst->m_quest_behaviour[i] = tok;
					}
					i = 0;
                }
                else if (section == "TimeObjective")
                {
                    // parse it somehow
                }
                else if (section == "ExploreObjective")
                {
                    // parse it somehow
                }
                else if (section == "Location")
                {
                    // parse it somehow
                }
                else
                    printf("%s\n", section.c_str());
            }
        }
    }
    //Save last quest
    this->AddQuest(qst);

    fclose(f);
    return true;
}

void QuestMgr::_CleanLine(std::string *str) 
{
    _RemoveChar("\r", str);
    _RemoveChar("\n", str);

    while (str->c_str()[0] == 32) 
    {
        str->erase(0,1);
    }
}

void QuestMgr::_RemoveChar(char *c, std::string *str) 
{
	string::size_type pos = str->find(c,0);

	while (pos != string::npos) {
		str->erase(pos, 1);
		pos = str->find(c, 0);
	}	
}
