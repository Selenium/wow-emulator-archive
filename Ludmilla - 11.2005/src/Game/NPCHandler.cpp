#include "StdAfx.h"

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


//////////////////////////////////////////////////////////////
/// This function handles MSG_TABARDVENDOR_ACTIVATE:
//////////////////////////////////////////////////////////////
void WorldSession::HandleTabardVendorActivateOpcode( WorldPacket & recv_data )
{
    uint64 guid;
    recv_data >> guid;

	QuestPacketHandler::getSingleton().SendTabardList( this, guid );
}


//////////////////////////////////////////////////////////////
/// This function handles CMSG_BANKER_ACTIVATE:
//////////////////////////////////////////////////////////////
void WorldSession::HandleBankerActivateOpcode( WorldPacket & recv_data )
{
    uint64 guid;
    recv_data >> guid;

	QuestPacketHandler::getSingleton().SendBankerList( this, guid );
}


//////////////////////////////////////////////////////////////
/// This function handles CMSG_TRAINER_LIST
//////////////////////////////////////////////////////////////
void WorldSession::HandleTrainerListOpcode( WorldPacket & recv_data )
{
    
	Log::getSingleton( ).outString( "WORLD: CMSG_TRAINER_LIST" );
	uint64 guid;
    recv_data >> guid;


	QuestPacketHandler::getSingleton().SendTrainerList( this, guid, "" );
}


//////////////////////////////////////////////////////////////
/// This function handles CMSG_TRAINER_BUY_SPELL:
//////////////////////////////////////////////////////////////
void WorldSession::HandleTrainerBuySpellOpcode( WorldPacket & recv_data )
{
    
	Log::getSingleton( ).outString( "WORLD: CMSG_TRAINER_BUY_SPELL" );
	WorldPacket data;
    uint64 guid;
    uint32 spellId, playerGold, price;

    recv_data >> guid >> spellId;
    playerGold = GetPlayer()->GetMoney();

	SpellEntry *proto = sSpellStore.LookupEntry(spellId);
	if (proto == NULL) return;

	SpellEntry *triggerProto = sSpellStore.LookupEntry(proto->EffectTriggerSpell[0]);
	if (triggerProto == NULL) return;

	price = sWorld.mPrices[proto->spellLevel];
    if ( playerGold >= price && !GetPlayer()->HasSpell (triggerProto->Id))
    {
		//GetPlayer()->AddSpell (spellId);

		Creature *Teacher = objmgr.GetObject<Creature>(guid);
		if(Teacher != NULL)
		{
			Log::getSingleton().outDebug("Trainer found!");
			Spell *spell = new Spell(Teacher, proto, false, 0);
			SpellCastTargets targets;
			targets.m_unitTarget = GetPlayer()->GetGUID();
			spell->prepare(&targets);
		}

		data.Initialize( SMSG_TRAINER_BUY_SUCCEEDED );
		data << guid << spellId;
	    	SendPacket( &data );

		///////////Spell being in spellbook immediately start////////////
		//data.clear();
		//data.Initialize (SMSG_LEARNED_SPELL);
		//data << spellId;
		//SendPacket( &data );
		///////////Spell being in spellbook immediately end//////////////

		///////////Training animation start//////////////////////
		//data.clear();
		//data.Initialize(SMSG_SPELL_GO);

		//data << GetPlayer()->GetGUID() << GetPlayer()->GetGUID();
		//data << uint32(476);
	
		//data << uint16(0x0101);
		//data << guid;
		//data << uint8(0);
		//data << uint16(0x0002);
		//data << guid;
		//GetPlayer()->SendMessageToSet(&data, true);
		///////////Training animation end////////////////////////

		data.clear();
		data.Initialize( SMSG_SPELLLOGEXECUTE );
	        data << guid;
	        data << spellId;
	        data << uint32(1);
	        data << uint32(0x24);
	        data << uint32(1);
	        data << GetPlayer()->GetGUID();
	        WPAssert(data.size() == 32);
	        SendPacket( &data );

        GetPlayer()->SetMoney (GetPlayer()->GetMoney() - price);
    }
}


//////////////////////////////////////////////////////////////
/// This function handles CMSG_PETITION_SHOWLIST:
//////////////////////////////////////////////////////////////
void WorldSession::HandlePetitionShowListOpcode( WorldPacket & recv_data )
{
    uint64 guid;
    recv_data >> guid;

	QuestPacketHandler::getSingleton().SendPetitionList( this, guid );
}


//////////////////////////////////////////////////////////////
/// This function handles MSG_AUCTION_HELLO:
//////////////////////////////////////////////////////////////
void WorldSession::HandleAuctionHelloOpcode( WorldPacket & recv_data )
{
    uint64 guid;
    recv_data >> guid;

	QuestPacketHandler::getSingleton().SendAuctionerList( this, guid );
}

//////////////////////////////////////////////////////////////
/// This function handles CMSG_GOSSIP_HELLO:
//////////////////////////////////////////////////////////////
void WorldSession::HandleGossipHelloOpcode( WorldPacket & recv_data )
{
    Log::getSingleton( ).outString( "WORLD: Received CMSG_GOSSIP_HELLO" );

    uint64 guid;
    recv_data >> guid;

	NPCGossipMenu *pMenu;
	pMenu = GetPlayer()->GetPreviousGossipMenu();
	GetPlayer()->SetPreviousGossipMenu( NULL, 0 );

	if ( (pMenu) && (GetPlayer()->_GossipMenu != pMenu)) delete pMenu;

	Creature *pCreature = objmgr.GetObject<Creature>( guid );
	QuestScriptBackend::getSingleton().scriptCallGossipHello( GetPlayer(), pCreature );
}

//////////////////////////////////////////////////////////////
/// This function handles CMSG_GOSSIP_SELECT_OPTION:
//////////////////////////////////////////////////////////////
void WorldSession::HandleGossipSelectOptionOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    uint32 option;
    uint64 guid;
	NPCGossipMenu *pMenu;
	std::string Code;


	GossipData pOpt;

	pOpt.iDataSender = 0;
	pOpt.iDataSub    = 0;

	pMenu = GetPlayer()->GetPreviousGossipMenu();
	GetPlayer()->SetPreviousGossipMenu( NULL, 0 );

    recv_data >> guid >> option;

	if ( pMenu )
	{
		if (pMenu->m_Items[ option - GetPlayer()->GetPreviousGossipMenuMove() ].bInputBox)
			recv_data >> Code;

		pOpt = pMenu->GetOptionUserData( option - GetPlayer()->GetPreviousGossipMenuMove() );
	}

	Creature *pCreature = objmgr.GetObject<Creature>( guid );

    Log::getSingleton( ).outDetail("WORLD: CMSG_GOSSIP_SELECT_OPTION '%d' \n", option, guid );

	if (Code.length())
		QuestScriptBackend::getSingleton().scriptCallGossipSelectWithCode( GetPlayer(), pCreature, option, pOpt, (char*)Code.c_str()); else
		QuestScriptBackend::getSingleton().scriptCallGossipSelect( GetPlayer(), pCreature, option, pOpt );

	if ( (pMenu) && (GetPlayer()->_GossipMenu != pMenu)) delete pMenu;
}

//////////////////////////////////////////////////////////////
/// This function handles CMSG_SPIRIT_HEALER_ACTIVATE:
//////////////////////////////////////////////////////////////
void WorldSession::HandleSpiritHealerActivateOpcode( WorldPacket & recv_data )
{
	QuestPacketHandler::getSingleton().SendSpiritHealerList( this, 0x00 );
}


void WorldSession::HandleBinderActivateOpcode( WorldPacket & recv_data )
{
	QuestPacketHandler::getSingleton().SendInnkeeperList( this, 0x00 );
}


