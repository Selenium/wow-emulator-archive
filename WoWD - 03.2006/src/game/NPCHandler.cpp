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

#include "Common.h"
#include "Database/DatabaseEnv.h"
#include "WorldPacket.h"
#include "WorldSession.h"
#include "Opcodes.h"
#include "Log.h"
#include "World.h"
#include "ObjectMgr.h"
#include "Player.h"
#include "Affect.h"
#include "UpdateMask.h"
#include "QuestMgr.h"

//////////////////////////////////////////////////////////////
/// This function handles MSG_TABARDVENDOR_ACTIVATE:
//////////////////////////////////////////////////////////////
void WorldSession::HandleTabardVendorActivateOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    uint64 guid;
    recv_data >> guid;
    data.Initialize( MSG_TABARDVENDOR_ACTIVATE );
    data << guid;
    SendPacket( &data );
}


//////////////////////////////////////////////////////////////
/// This function handles CMSG_BANKER_ACTIVATE:
//////////////////////////////////////////////////////////////
void WorldSession::HandleBankerActivateOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    uint64 guid;
    recv_data >> guid;

    data.Initialize( SMSG_SHOW_BANK );
    data << guid;
    SendPacket( &data );
}

//////////////////////////////////////////////////////////////
/// This function handles CMSG_TRAINER_LIST
//////////////////////////////////////////////////////////////
void WorldSession::HandleTrainerListOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    uint64 guid;
    uint32 cnt;
	
    recv_data >> guid;
	Trainerspell *strainer = objmgr.GetTrainerspell(GUID_LOPART(guid));

	cnt = 0;
	if(strainer)
	{
		//Log::getSingleton().outString("loading trainer %u with skillines %u, %u, and %u",GUID_LOPART(guid),strainer->skilline1,strainer->skilline2,strainer->skilline3);
        for (unsigned int t = 0;t < sSkillStore.GetNumRows();t++)
        {
			skilllinespell *skill = sSkillStore.LookupEntry(t);
			if ((skill->skilline == strainer->skilline1) || (skill->skilline == strainer->skilline2) || (skill->skilline == strainer->skilline3))
			{
				//Log::getSingleton().outString("skill %u with skillline %u matches",skill->spell,skill->skilline);
				SpellEntry *proto = sSpellStore.LookupEntry(skill->spell);
				if ((proto) && !(proto->Attributes & 64) && !(proto->Attributes & 128) && !(proto->Attributes & 256) && (proto->spellLevel != 0) && (proto->spellLevel <= strainer->maxlvl))
				{
					cnt++;
				}
			}
        }
		data.Initialize( SMSG_TRAINER_LIST ); //set packet size - count = number of spells
		data << guid;
		data << uint32(0) << uint32(cnt);
		//Log::getSingleton().outString("count = %u",cnt);
        for (unsigned int t = 0;t < sSkillStore.GetNumRows();t++)
        {
			skilllinespell *skill = sSkillStore.LookupEntry(t);
			if ((skill->skilline == strainer->skilline1) || (skill->skilline == strainer->skilline2) || (skill->skilline == strainer->skilline3))
			{
				SpellEntry *proto = sSpellStore.LookupEntry(skill->spell);
				if ((proto) && !(proto->Attributes & 64) && !(proto->Attributes & 128) && !(proto->Attributes & 256) && (proto->spellLevel != 0) && (proto->spellLevel <= strainer->maxlvl))
				{
					//Log::getSingleton( ).outString( "WORLD: Grabbing trainer spell %u with skilline %u", skill->spell, skill->skilline);
					data << uint32(skill->spell);
					//data << uint32(10);
					if (GetPlayer()->HasSpell(skill->spell))
					{
						data << uint8(2);
					}
					else
					{
						if (((GetPlayer()->GetUInt32Value( UNIT_FIELD_LEVEL )) < (proto->spellLevel)) || (GetPlayer()->GetUInt32Value( PLAYER_FIELD_COINAGE ) < sWorld.mPrices[proto->spellLevel]))
						{
							data << uint8(1);
						}
						else
						{
							data << uint8(0);
						}
					}
					data << uint32(sWorld.mPrices[proto->spellLevel]) << uint32(0);
					data << uint32(0) << uint8(proto->spellLevel);
					data << uint32(0); // set type
					data << uint32(0); // set required level of a skill line
					data << uint32(0); 
					data << uint32(0) << uint32(0);
					//Log::getSingleton( ).outString( "WORLD: Grabbing trainer spell %u", itr->second->spell);
				}
			}
        }
		data << "Hello! Ready for some training?";
		SendPacket( &data );
	}
    else //Add Trainer to db
    {
        Creature * pCreature = objmgr.GetObject<Creature>(guid);
        if(!pCreature) return;

        CreatureInfo *ci = pCreature->GetCreatureName();
        if(!ci) return;

        //Trainer Templates
	    Trainerspell *TrainSpell;
	    std::stringstream sssql;
	    sssql << "SELECT * FROM trainertemplate WHERE subname='" << ci->SubName << "'\0";
        QueryResult *result = sDatabase.Query(sssql.str().c_str());
	    if(result)
        {
		    sLog.outDebug("Trainer Template Exists");
		    Field *fields = result->Fetch();
    		
		    TrainSpell = new Trainerspell;
		    TrainSpell->Id = GUID_LOPART(guid);
		    TrainSpell->skilline1 = fields[1].GetUInt32();
		    TrainSpell->skilline2 = fields[2].GetUInt32();
		    TrainSpell->skilline3 = fields[3].GetUInt32();
		    //TrainSpell->maxlvl = fields[5].GetUInt32();
		    TrainSpell->maxlvl = pCreature->GetUInt32Value(UNIT_FIELD_LEVEL);
		    TrainSpell->charclass = fields[4].GetUInt32();
		    objmgr.AddTrainerspell(TrainSpell);

		    std::stringstream sssqlins;
		    sssqlins << "INSERT INTO trainer (GUID, skillline1, skillline2,  skillline3, maxlvl, class) VALUES ("
				    << TrainSpell->Id << ", "
				    << TrainSpell->skilline1 << ", "
				    << TrainSpell->skilline2 << ", "
				    << TrainSpell->skilline3 << ", "
				    << TrainSpell->maxlvl << ", "
				    << TrainSpell->charclass << ")\0";
		    sDatabase.Execute(sssqlins.str().c_str());
            delete result;
	    }
    }
}


//////////////////////////////////////////////////////////////
/// This function handles CMSG_TRAINER_BUY_SPELL:
//////////////////////////////////////////////////////////////
void WorldSession::HandleTrainerBuySpellOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    uint64 guid;
    uint32 spellId, playerGold, price;

    uint64 trainer = GetPlayer()->GetSelection();
    recv_data >> guid >> spellId;
    playerGold = GetPlayer( )->GetUInt32Value( PLAYER_FIELD_COINAGE );
    SpellEntry *proto = sSpellStore.LookupEntry(spellId);
	price = sWorld.mPrices[proto->spellLevel];

    if(GetPlayer( )->HasSpell(spellId))
    {
        /* no idea how this works need logs
        data.Initialize( SMSG_TRAINER_BUY_FAILED );
        data << guid << spellId;
        SendPacket( &data );
        */
        return;
    }
    if( playerGold >= price )
    {
        GetPlayer( )->SetUInt32Value( PLAYER_FIELD_COINAGE, playerGold - price );

        // Ignatich: do we really need that spell casting sequence? need to check against logs

        data.Initialize( SMSG_SPELL_START );
        data << GetPlayer()->GetNewGUID();
        data << GetPlayer()->GetNewGUID();
        data << spellId;
        data << uint16(0);
        data << uint32(0);
        data << uint16(2);
        data << GetPlayer()->GetGUID();
//        WPAssert(data.size() == 36);
        SendPacket( &data );

        data.Initialize( SMSG_LEARNED_SPELL );
        data << spellId;
        SendPacket( &data );
        GetPlayer()->addSpell((uint16)spellId);

        data.Initialize( SMSG_SPELL_GO );
        data << GetPlayer()->GetNewGUID();
        data << GetPlayer()->GetNewGUID();
        data << spellId;
        data << uint8(0) << uint8(1) << uint8(1);
        data << GetPlayer()->GetGUID();
        data << uint8(0);
        data << uint16(2);
        data << GetPlayer()->GetGUID();
//        WPAssert(data.size() == 42);
        SendPacket( &data );

        data.Initialize( SMSG_SPELLLOGEXECUTE );
        data << GetPlayer()->GetNewGUID();
        data << spellId;
        data << uint32(1);
        data << uint32(0x24);
        data << uint32(1);
        data << GetPlayer()->GetGUID();
//        WPAssert(data.size() == 32);
        SendPacket( &data );

        data.Initialize( SMSG_TRAINER_BUY_SUCCEEDED );
        data << guid << spellId;
        SendPacket( &data );
    }
}


//////////////////////////////////////////////////////////////
/// This function handles CMSG_PETITION_SHOWLIST:
//////////////////////////////////////////////////////////////
void WorldSession::HandlePetitionShowListOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    uint64 guid;
    uint8 tdata[] = { 0x01, 0x01, 0x00, 0x00, 0x00, 0xE7, 0x16, 0x00, 0x00, 0x21, 0x3F, 0x00, 0x00, 0xE8, 0x03, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00 };
    recv_data >> guid;
    data.Initialize( SMSG_PETITION_SHOWLIST );
    data << guid;
    data.append(tdata,sizeof(tdata));
    SendPacket( &data );
}

//////////////////////////////////////////////////////////////
/// This function handles MSG_AUCTION_HELLO:
//////////////////////////////////////////////////////////////
void WorldSession::HandleAuctionHelloOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    uint64 guid;

    recv_data >> guid;

    data.Initialize( MSG_AUCTION_HELLO );
    data << guid;
    data << uint32(0);

    SendPacket( &data );
}

//////////////////////////////////////////////////////////////
/// This function handles CMSG_GOSSIP_HELLO:
//////////////////////////////////////////////////////////////
void WorldSession::HandleGossipHelloOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    uint64 guid;
    GossipNpc *pGossip;
    list<QuestRelation *>::iterator it;
    map<uint32, uint8> tmp_map;

    recv_data >> guid;
    Creature *qst_giver = objmgr.GetObject<Creature>(guid);

	Log::getSingleton( ).outString( "WORLD: Recieved CMSG_GOSSIP_HELLO from %u",GUID_LOPART(guid) );

    pGossip = objmgr.GetGossipByGuid(GUID_LOPART(guid));

    if (!pGossip)
    {
        if (qst_giver)
        {
            if ((qst_giver->isQuestGiver()) && (sQuestMgr.ActiveQuestsCount(qst_giver, GetPlayer())))
            {            
                // has quests but no gossip...send quest list.
                Log::getSingleton( ).outDebug( "WORLD: Sent SMSG_QUESTGIVER_QUEST_LIST." );
                SendPacket(&sQuestMgr.BuildQuestList(qst_giver ,GetPlayer()));
            }
        }
        return;
    }


    data.Initialize( SMSG_GOSSIP_MESSAGE );
    data << guid;
    data << pGossip->TextID;
    data << pGossip->OptionCount;

    for(uint32 i=0; i<pGossip->OptionCount; i++)
    {
        data << i;
        data << pGossip->pOptions[i].Icon;
        data << pGossip->pOptions[i].OptionText;
    }
 

    if (qst_giver)
    {
        if (qst_giver->isQuestGiver())
        {
            data << uint32(sQuestMgr.ActiveQuestsCount(qst_giver, GetPlayer()));
	        for (it = qst_giver->QuestsBegin(); it != qst_giver->QuestsEnd(); it++)
	        {
		        if (sQuestMgr.CalcQuestStatus(qst_giver, GetPlayer(), *it) >= QMGR_QUEST_NOT_FINISHED)
		        {
                    if (tmp_map.find((*it)->qst->GetID()) == tmp_map.end())
                    {
                        tmp_map.insert(std::map<uint32,uint8>::value_type((*it)->qst->GetID(), 1));

			            data << (*it)->qst->GetID();
                        data << sQuestMgr.CalcQuestStatus(qst_giver, GetPlayer(), *it);
			            data << uint32(0);
			            data << (*it)->qst->GetTitle();
                    }
		        }
	        }
        }
    }
    else
    {
        data << uint32(0);
    }

    Log::getSingleton( ).outString( "WORLD: Sent SMSG_GOSSIP_MESSAGE" );
    SendPacket(&data);
}

//////////////////////////////////////////////////////////////
/// This function handles CMSG_GOSSIP_SELECT_OPTION:
//////////////////////////////////////////////////////////////
void WorldSession::HandleGossipSelectOptionOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    uint32 option;
    uint64 guid;
    GossipNpc *pGossip;

    recv_data >> guid >> option;
    Log::getSingleton( ).outDetail("WORLD: CMSG_GOSSIP_SELECT_OPTION Option %i Guid %.8X\n", option, guid );

    pGossip = objmgr.GetGossipByGuid(GUID_LOPART(guid));

    switch(pGossip->pOptions[option].Special)
    {
    case GOSSIP_POI:
        {

        }break;
    case GOSSIP_SPIRIT_HEALER_ACTIVE:
        {
            data.Initialize( SMSG_SPIRIT_HEALER_CONFIRM );
            data << guid;
            SendPacket( &data );
            data.Initialize( SMSG_GOSSIP_COMPLETE );
            SendPacket( &data );
        }break;
    case GOSSIP_VENDOR:
        {

        }break;
    case GOSSIP_TRAINER:
        {

        }break;
	case GOSSIP_PETITIONER:
		{
			uint8 tdata[] = { 0x01, 0x01, 0x00, 0x00, 0x00, 0xE7, 0x16, 0x00, 0x00, 0x21, 0x3F, 0x00, 0x00, 0xE8, 0x03, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00 };
			data.Initialize( SMSG_PETITION_SHOWLIST );
			data << guid;
			data.append(tdata,sizeof(tdata));
			SendPacket( &data );
		}break;
	case GOSSIP_INNKEEPER:
		{
			data.Initialize( SMSG_BINDER_CONFIRM );
			data << guid;
			SendPacket( &data );
			data.clear();
            data.Initialize( SMSG_GOSSIP_COMPLETE );
            SendPacket( &data );
		}break;
    default: break;
    }

}

//////////////////////////////////////////////////////////////
/// This function handles CMSG_SPIRIT_HEALER_ACTIVATE:
//////////////////////////////////////////////////////////////
void WorldSession::HandleSpiritHealerActivateOpcode( WorldPacket & recv_data )
{
    Affect *aff;

    SpellEntry *spellInfo = sSpellStore.LookupEntry( 2146 );
    if(spellInfo)
    {
        aff = new Affect(spellInfo,600000,GetPlayer()->GetGUID(), GetPlayer());
        GetPlayer( )->AddAffect(aff);
    }

	//Need to make items updateable first so they don't crash server
    GetPlayer( )->DeathDurabilityLoss(0.25);
    GetPlayer( )->SetMovement(MOVE_LAND_WALK);
    GetPlayer( )->SetPlayerSpeed(RUN, (float)7.5, true);
    GetPlayer( )->SetPlayerSpeed(SWIM, (float)4.9, true);

    GetPlayer( )->SetUInt32Value(CONTAINER_FIELD_SLOT_1+29, 0);
    GetPlayer( )->SetUInt32Value(UNIT_FIELD_AURA+32, 0);
    GetPlayer( )->SetUInt32Value(UNIT_FIELD_AURALEVELS+8, 0xeeeeeeee);
    GetPlayer( )->SetUInt32Value(UNIT_FIELD_AURAAPPLICATIONS+8, 0xeeeeeeee);
    GetPlayer( )->SetUInt32Value(UNIT_FIELD_AURAFLAGS+4, 0);
    GetPlayer( )->SetUInt32Value(UNIT_FIELD_AURASTATE, 0);

    GetPlayer( )->ResurrectPlayer();
    GetPlayer( )->SetUInt32Value(UNIT_FIELD_HEALTH, (uint32)(GetPlayer()->GetUInt32Value(UNIT_FIELD_MAXHEALTH)*0.50) );
    GetPlayer( )->SpawnCorpseBones();
}

//////////////////////////////////////////////////////////////
/// This function handles CMSG_NPC_TEXT_QUERY:
//////////////////////////////////////////////////////////////
void WorldSession::HandleNpcTextQueryOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    uint32 textID;
    uint32 uField0, uField1;
    GossipText *pGossip;

    recv_data >> textID;
    Log::getSingleton( ).outDetail("WORLD: CMSG_NPC_TEXT_QUERY ID '%u'", textID );

    recv_data >> uField0 >> uField1;
    GetPlayer()->SetUInt32Value(UNIT_FIELD_TARGET, uField0);
    GetPlayer()->SetUInt32Value(UNIT_FIELD_TARGET + 1, uField1);

    pGossip = objmgr.GetGossipText(textID);
    if(pGossip)
    {
        data.Initialize( SMSG_NPC_TEXT_UPDATE );
        data << textID;
        data << uint8(0x00) << uint8(0x00) << uint8(0x00) << uint8(0x00);
        data << pGossip->Text.c_str();
        SendPacket( &data );
    }
}

void WorldSession::HandleBinderActivateOpcode( WorldPacket & recv_data )
{
	uint64 guid;
	recv_data >> guid;
	Creature* cr = objmgr.GetObject<Creature>(guid);
	Player *pl = GetPlayer();
	pl->SetBindPoint(pl->GetPositionX(),pl->GetPositionY(),pl->GetPositionZ(),pl->GetMapId(),pl->GetZoneId());
	WorldPacket data;
	data.Initialize(SMSG_BINDPOINTUPDATE);
	data << pl->GetBindPositionX();
	data << pl->GetBindPositionY();
	data << pl->GetBindPositionZ();
	data << pl->GetBindMapId();
	data << pl->GetBindZoneId();
    SendPacket( &data );
	data.clear();
	data.Initialize(SMSG_PLAYERBOUND);
	data << guid;
	data << pl->GetBindZoneId();
}
