/*
 *  **********  (c) 2005 PavkaM. Ludmilla Project *************
 */

#include "StdAfx.h"
#include "../Shared/PacketBuilder.h"

createFileSingleton( QuestPacketHandler );

/*
===========================================================================
*/

NPCQuestMenu::NPCQuestMenu( std::string Title )
{
	m_QuestsNr   = 0;
	m_MenuTitle  = Title;
}

//-----------------------------------------------------------------------------
NPCQuestMenu::NPCQuestMenu()
{
	m_QuestsNr   = 0;
	m_MenuTitle  = "Ready for Quests?";
}

//-----------------------------------------------------------------------------
NPCQuestMenu::~NPCQuestMenu()
{
	Clear();
}

void NPCQuestMenu::Clear()
{
	for ( int iI=0; iI < m_QuestsNr; iI++) 
	{
		m_Items[iI].sTitle.clear();
	}

	m_QuestsNr = 0;
}

//-----------------------------------------------------------------------------
void NPCQuestMenu::AddCurrentQuest( Quest *pQuest, uint8 icon )
{
	if ( QuestIsInList( pQuest ) ) return;

	m_QuestsNr++;

	m_Items[ ( m_QuestsNr - 1) ].iQuest       = pQuest->m_questId;
	m_Items[ ( m_QuestsNr - 1) ].sTitle       = pQuest->m_title;
	m_Items[ ( m_QuestsNr - 1) ].iIcon        = icon;
	m_Items[ ( m_QuestsNr - 1) ].bCurrent     = true;
}

//-----------------------------------------------------------------------------
void NPCQuestMenu::AddAvailableQuest( Quest *pQuest, uint8 icon )
{
	if ( QuestIsInList( pQuest ) ) return;

	m_QuestsNr++;

	m_Items[ ( m_QuestsNr - 1) ].iQuest       = pQuest->m_questId;
	m_Items[ ( m_QuestsNr - 1) ].sTitle       = pQuest->m_title;
	m_Items[ ( m_QuestsNr - 1) ].iIcon        = icon;
	m_Items[ ( m_QuestsNr - 1) ].bCurrent     = false;
}

void NPCQuestMenu::AddCurrentQuest( uint32 qid, uint8 icon )
{
	Quest *pQuest = objmgr.GetQuest( qid );
	if (pQuest) AddCurrentQuest( pQuest, icon );
}

void NPCQuestMenu::AddAvailableQuest( uint32 qid, uint8 icon )
{
	Quest *pQuest = objmgr.GetQuest( qid );
	if (pQuest) AddAvailableQuest( pQuest, icon );
}

//-----------------------------------------------------------------------------
bool NPCQuestMenu::QuestIsInList( Quest *pQuest )
{
	for ( int iI = 0; iI < m_QuestsNr; iI++)
	{ 
		if ( m_Items[ iI ].iQuest == pQuest->m_questId )
			return true;
	}

	return false;
}

/*
===========================================================================
*/


//-----------------------------------------------------------------------------
NPCGossipMenu::NPCGossipMenu()
{
	m_ItemsNr = 0;
}

//-----------------------------------------------------------------------------
NPCGossipMenu::~NPCGossipMenu()
{
	Clear();
}

void NPCGossipMenu::Clear()
{
	for ( int iI=0; iI < m_ItemsNr; iI++) 
	{
		m_Items[iI].sMessage.clear();
	}

	m_ItemsNr = 0;
}

//-----------------------------------------------------------------------------
void NPCGossipMenu::AddMessage(uint8 icon, bool bInputBox, char* text, GossipData data )
{
	m_ItemsNr++;

	m_Items[ ( m_ItemsNr - 1) ].iIcon		 = icon;
	m_Items[ ( m_ItemsNr - 1) ].sMessage     = text;
	m_Items[ ( m_ItemsNr - 1) ].Data         = data;
	m_Items[ ( m_ItemsNr - 1) ].bInputBox    = bInputBox;
}

//-----------------------------------------------------------------------------
void NPCGossipMenu::AddMessage(uint8 icon, bool bInputBox, std::string text, GossipData data )
{
	m_ItemsNr++;

	m_Items[ ( m_ItemsNr - 1) ].iIcon		 = icon;
	m_Items[ ( m_ItemsNr - 1) ].sMessage     = text;
	m_Items[ ( m_ItemsNr - 1) ].Data         = data;
	m_Items[ ( m_ItemsNr - 1) ].bInputBox    = bInputBox;
}

//-----------------------------------------------------------------------------
void NPCGossipMenu::AddMessage(uint8 icon, bool bInputBox, char* text )
{
	GossipData data;
	data.iDataSender = 0; 
	data.iDataSub    = 0;

	AddMessage(icon, bInputBox, text, data);
}


//-----------------------------------------------------------------------------
GossipData NPCGossipMenu::GetOptionUserData( uint32 OptionId )
{
	int iPs = -1;
	GossipData data;
	data.iDataSender = 0; 
	data.iDataSub    = 0;

	for ( int iI = 0; iI < m_ItemsNr; iI++)
	{
		iPs++;
		if ( iPs == OptionId )
			return m_Items[ iI ].Data;
	}

	return data;
}

/*
===========================================================================
*/

void QuestPacketHandler::SendGossipMenu( WorldSession *Wrld, NPCGossipMenu *gMenu, NPCQuestMenu *qMenu, uint32 TitleTextId, uint64 creatureGUID )
{
	WorldPacket data;

	data.Initialize( SMSG_GOSSIP_MESSAGE );
	data << creatureGUID;
	data << uint32( TitleTextId );
	data << uint32(gMenu->m_ItemsNr);
	
	for ( int iI = 0; iI < gMenu->m_ItemsNr; iI++ )
	{
		data << uint32( iI );
		data << uint8( gMenu->m_Items[iI].iIcon );
		data << uint8( gMenu->m_Items[iI].bInputBox );
		data << gMenu->m_Items[iI].sMessage;
	}

	int Howsy = 0;

	if (qMenu)
	{
		Howsy = qMenu->m_QuestsNr;
		data << uint32(qMenu->m_QuestsNr);

		for ( int iI = 0; iI < qMenu->m_QuestsNr; iI++ )
		{
			data << uint32( qMenu->m_Items[iI].iQuest );
			data << uint32( qMenu->m_Items[iI].iIcon ); 
			data << uint32( qMenu->m_Items[iI].bCurrent );
			data << qMenu->m_Items[iI].sTitle;
		}
	} else data << uint32(0);

    Wrld->SendPacket( &data );
    Log::getSingleton( ).outDebug( "WORLD: Sent SMSG_GOSSIP_MESSAGE" );

	Wrld->GetPlayer()->SetPreviousGossipMenu( gMenu,  Howsy );
}

//-----------------------------------------------------------------------------
void QuestPacketHandler::SendQuestMenu( WorldSession *Wrld, NPCQuestMenu *qMenu, QEmote eEmote, uint64 creatureGUID )
{
	WorldPacket data;

	data.Initialize( SMSG_QUESTGIVER_QUEST_LIST );
	data << creatureGUID;
	data << qMenu->m_MenuTitle;
	data << uint32( eEmote.iDelay ); 
	data << uint32( eEmote.iEmote );
	data << uint8 ( qMenu->m_QuestsNr );

	for ( int iI = 0; iI < qMenu->m_QuestsNr; iI++ )
	{
		data << uint32( qMenu->m_Items[iI].iQuest );
		data << uint32( (qMenu->m_Items[iI].bCurrent)?0x03:0x05 );
		data << uint32(0x00);
		data << qMenu->m_Items[iI].sTitle;
	}

    Wrld->SendPacket( &data );
    Log::getSingleton( ).outDebug( "WORLD: Sent SMSG_QUESTGIVER_QUEST_LIST" );
}


/*
  Close the Gossip Window !
*/

void QuestPacketHandler::SendCloseGossipToPlayer( WorldSession *Wrld )
{
	WorldPacket data;

	data.Initialize( SMSG_GOSSIP_COMPLETE );
    Wrld->SendPacket( &data );

    Log::getSingleton( ).outDebug( "WORLD: Sent SMSG_GOSSIP_COMPLETE" );
}


/*
   Sending the Over-Head Sign to the NPC.
   <Packet structure checked>
*/
void QuestPacketHandler::SendNPCQuestStatus( WorldSession *Wrld, int questStatus, uint64 creatureGUID)
{
	WorldPacket data;

    data.Initialize( SMSG_QUESTGIVER_STATUS );
    data << creatureGUID << uint32(questStatus);

    Wrld->SendPacket( &data );
	Log::getSingleton( ).outDebug( "WORLD: Sent SMSG_QUESTGIVER_STATUS");
}

/*
   Sending Reward Info to the Player
   <Packet structure NOT checked>
*/
void QuestPacketHandler::SendRewardToPlayer( WorldSession *Wrld, Quest *pQuest, uint64 creatureGUID )
{
	WorldPacket data;

	data.Initialize( SMSG_QUESTGIVER_OFFER_REWARD );
	data << creatureGUID;
	data << pQuest->m_questId;
    data << pQuest->m_title;
	data << pQuest->m_details;

    data << uint32(0x01);
	data << uint32(0x00);// emote list !

	ItemPrototype *pItem;

    data << uint32(pQuest->m_choiceRewards);
    for (uint16 i=0; i < pQuest->m_choiceRewards; i++)
        {
			pItem = objmgr.GetItemPrototype(pQuest->m_choiceItemId[i]);
			
            data << uint32(pQuest->m_choiceItemId[i]) << uint32(pQuest->m_choiceItemCount[i]);

			if ( pItem )
				data << uint32(pItem->DisplayInfoID); else
				data << uint32(0);
        }

    data << uint32(pQuest->m_itemRewards);
    for (uint16 i=0; i < pQuest->m_itemRewards; i++)
        {
			pItem = objmgr.GetItemPrototype(pQuest->m_rewardItemId[i]);
            data << uint32(pQuest->m_rewardItemId[i]) << uint32(pQuest->m_rewardItemCount[i]);

			if ( pItem )
				data << uint32(pItem->DisplayInfoID); else
				data << uint32(0);
        }

    data << uint32(pQuest->m_rewardGold);
    data << uint32(0x00);
	data << uint32(pQuest->m_learnSpell);

    Wrld->SendPacket( &data );
    Log::getSingleton( ).outDebug( "WORLD: Sent SMSG_QUESTGIVER_OFFER_REWARD" );
}

/*
   Sending Request Items Info to the Player
   <Packet structure NOT checked>
*/
void QuestPacketHandler::SendRequestItemsToPlayer( WorldSession *Wrld, Quest *pQuest, uint64 creatureGUID, bool Completable)
{
	WorldPacket data;
	uint8 Compl;

	if ( Completable ) Compl = 0x01; else Compl = 0x00;

    data.Initialize( SMSG_QUESTGIVER_REQUEST_ITEMS);
    data << creatureGUID;
    data << pQuest->m_questId;
    data << pQuest->m_title;

	if ( !Completable ) 
	{
		if ( pQuest->m_incompleteText != "" )
			data << pQuest->m_incompleteText; else
			data << pQuest->m_details;
	} else
	{
		if ( pQuest->m_completedText != "" )
			data << pQuest->m_completedText; else
			data << pQuest->m_details;
	}

    // req items with no obj !

	//data << uint32(0x00) << uint32(0x19); 
	//data << uint32(0x00) << uint32(0x00);
	//data << uint32(0x00) << uint32(0x00);
	//data << uint32(0x04) << uint32(0x08) << uint32(0x10);

	// 2 jobs ---------------------------------------------------

	data << uint32(0x00) << uint32(0x01); 
	data << uint32(0x01) << uint32(0x00);

	uint32 Nr = 0;

	for (int iI = 0; iI < 3; iI++) 
		if ( pQuest->m_questItemId[iI] > 0 ) Nr++;

	data << uint32(Nr);

	ItemPrototype *pItem;
	for (int i = 0; i < 4; i++)
       {
		   if ( !pQuest->m_questItemId[i] ) continue;

			pItem = objmgr.GetItemPrototype(pQuest->m_questItemId[i]);
            data << uint32(pQuest->m_questItemId[i]) << uint32(pQuest->m_questItemCount[i]);

			if ( pItem )
				data << uint32(pItem->DisplayInfoID); else
				data << uint32(0);
        }

	data << uint32(0x02) << uint32(0x00);
	data << uint32(0x04) << uint32(0x08) << uint32(0x10);

    Wrld->SendPacket( &data );
    Log::getSingleton( ).outDebug( "WORLD: Sent SMSG_QUESTGIVER_REQUEST_ITEMS" );
}

/*
   Sending Short Quest Info to the Player
   <Packet structure NOT checked>
*/
void QuestPacketHandler::SendShortQuestDetailsToPlayer( WorldSession *Wrld, Quest *pQuest, uint64 creatureGUID )
{
	WorldPacket data;

    uint16 rewardSize =  52;
    rewardSize += pQuest->m_choiceRewards*12;
    rewardSize += pQuest->m_itemRewards*12;

    data.Initialize( SMSG_QUESTGIVER_QUEST_DETAILS );
    data << creatureGUID;
    data << pQuest->m_questId;
    data << pQuest->m_title;
	data << pQuest->m_objectives;
	data << pQuest->m_details;

    data << uint32(0x01); // 0 - accept inactive, 1 - active

	ItemPrototype *pItem;

    data << uint32(pQuest->m_choiceRewards);
    for (uint16 i=0; i < pQuest->m_choiceRewards; i++)
        {
			pItem = objmgr.GetItemPrototype(pQuest->m_choiceItemId[i]);
			
            data << uint32(pQuest->m_choiceItemId[i]) << uint32(pQuest->m_choiceItemCount[i]);

			if ( pItem )
				data << uint32(pItem->DisplayInfoID); else
				data << uint32(0);
        }

    data << uint32(pQuest->m_itemRewards);
    for (uint16 i=0; i < pQuest->m_itemRewards; i++)
        {
			pItem = objmgr.GetItemPrototype(pQuest->m_rewardItemId[i]);
            data << uint32(pQuest->m_rewardItemId[i]) << uint32(pQuest->m_rewardItemCount[i]);

			if ( pItem )
				data << uint32(pItem->DisplayInfoID); else
				data << uint32(0);
        }

    data << uint32(pQuest->m_rewardGold);

	uint32 Nr = 0;

	data << uint32(0);

	for (int iI = 0; iI < 3; iI++) 
		if ( pQuest->m_questMobId[iI] > 0 ) Nr++;

	data << uint32(Nr);

	for (int iI = 0; iI < 3; iI++) 
		if ( pQuest->m_questMobId[iI] > 0 ) 
		{
			data << uint32(pQuest->m_questMobId[iI]) << uint32(pQuest->m_questMobCount[iI]);
		}

    Wrld->SendPacket( &data );
    Log::getSingleton( ).outDebug( "WORLD: Sent SMSG_QUESTGIVER_QUEST_DETAILS" );
}


/*
   Sending Full Quest Info to the Player
   <Packet structure checked>
*/
void QuestPacketHandler::SendFullQuestDetailsToPlayer ( WorldSession *Wrld, Quest *pQuest )
{
	WorldPacket data;

    data.Initialize( SMSG_QUEST_QUERY_RESPONSE );

	data << uint32(pQuest->m_questId)    << uint32(pQuest->m_requiredLevel);
	data << uint32(pQuest->m_questLevel) << uint32(pQuest->m_zone) ;

	data << uint32(pQuest->m_questType);
	data << uint32(pQuest->m_repFaction[0]);
	data << uint32(pQuest->m_repValue[0]);

	data << uint32(pQuest->m_repFaction[1]);
	data << uint32(pQuest->m_repValue[1]);

	data << uint32(pQuest->m_nextQuest);
    data << uint32(pQuest->m_rewardGold);

	data << uint32(pQuest->m_learnSpell);

	data << uint32(pQuest->m_srcItem);
	data << uint32(pQuest->m_questFlags);

	int iTotals = 8;
	int iI;

	for (iI = 0; iI < pQuest->m_itemRewards; iI++)
	{ 
		data << uint32(pQuest->m_rewardItemId[iI]) << uint32(pQuest->m_rewardItemCount[iI]);
		iTotals -= 2;
	}

	for (iI = 0; iI < iTotals; iI++) data << uint32(0x00);

	iTotals = 12;

	for (iI = 0; iI < pQuest->m_choiceRewards; iI++)
	{ 
		data << uint32(pQuest->m_choiceItemId[iI]) << uint32(pQuest->m_choiceItemCount[iI]);
		iTotals -= 2;
	}

	for (iI = 0; iI < iTotals; iI++) data << uint32(0x00);

	data << uint32( pQuest->m_LocMap );
	data << uint32( pQuest->m_LocX );
	data << uint32( pQuest->m_LocY );
	data << uint32( pQuest->m_LocOpt );

    data << pQuest->m_title;
	data << pQuest->m_objectives;
	data << pQuest->m_details;
	data << pQuest->m_secondText;

    data << uint32(pQuest->m_questMobId[0])  << uint32(pQuest->m_questMobCount[0]);
    data << uint32(pQuest->m_questItemId[0]) << uint32(pQuest->m_questItemCount[0]);
    data << uint32(pQuest->m_questMobId[1])  << uint32(pQuest->m_questMobCount[1]);
    data << uint32(pQuest->m_questItemId[1]) << uint32(pQuest->m_questItemCount[1]);
    data << uint32(pQuest->m_questMobId[2])  << uint32(pQuest->m_questMobCount[2]);
    data << uint32(pQuest->m_questItemId[2]) << uint32(pQuest->m_questItemCount[2]);
    data << uint32(pQuest->m_questMobId[3])  << uint32(pQuest->m_questMobCount[3]);
    data << uint32(pQuest->m_questItemId[3]) << uint32(pQuest->m_questItemCount[3]);

	data << pQuest->m_partText[0] << pQuest->m_partText[1];
	data << pQuest->m_partText[2] << pQuest->m_partText[3];

    Wrld->SendPacket( &data );
    Log::getSingleton( ).outDebug( "WORLD: Sent SMSG_QUEST_QUERY_RESPONSE" );
}


/*
   Sending Quest Complete Signal to the Player
   <Packet structure checked>
*/
void QuestPacketHandler::SendQuestCompleteToPlayer( WorldSession *Wrld, Quest *pQuest )
{
	WorldPacket data;

    data.Initialize( SMSG_QUESTGIVER_QUEST_COMPLETE );
	data << uint32(pQuest->m_questId);
	data << uint32(0x03);
	data << uint32( pQuest->GenerateQuestXP( Wrld->GetPlayer() ) );
	data << uint32( pQuest->m_rewardGold );

	uint32 iNr = 0;
	for (int iI=0; iI< 4; iI++)
		if (pQuest->m_rewardItemId[iI] > 0) iNr++;

	data << uint32( iNr );

	for (int iI = 0; iI < 4; iI++)
		if (pQuest->m_rewardItemId[iI] > 0) 
		{
			data << pQuest->m_rewardItemId[iI] << pQuest->m_rewardItemCount[iI];
		}

    Wrld->SendPacket( &data );
    Log::getSingleton( ).outDebug( "WORLD: Sent SMSG_QUESTGIVER_QUEST_COMPLETE" );
}

//-----------------------------------------------------------------------------
void QuestPacketHandler::SendQuestUpdateComplete( WorldSession *Wrld, Quest *pQuest )
{
	WorldPacket data;

    data.Initialize( SMSG_QUESTUPDATE_COMPLETE );
	data << uint32(pQuest->m_questId);
    Wrld->SendPacket( &data );
    Log::getSingleton( ).outDebug( "WORLD: Sent SMSG_QUESTUPDATE_COMPLETE" );
}

//-----------------------------------------------------------------------------
void QuestPacketHandler::SendQuestCompleteToLog( WorldSession *Wrld, Quest *pQuest )
{
	uint16 log_slot   = Wrld->GetPlayer()->getQuestSlot( pQuest->m_questId );
	uint32 kills      = Wrld->GetPlayer()->GetUInt32Value( log_slot + 1 );
	kills            |= 0x01000000;
	Wrld->GetPlayer()->SetUInt32Value( log_slot + 1, kills );
}

//-----------------------------------------------------------------------------
void QuestPacketHandler::SendQuestIncompleteToLog( WorldSession *Wrld, Quest *pQuest )
{
	uint16 log_slot   = Wrld->GetPlayer()->getQuestSlot( pQuest->m_questId );
	uint32 vle1       = Wrld->GetPlayer()->GetUInt32Value( log_slot + 0 );

	Wrld->GetPlayer()->SetUInt32Value( log_slot + 0 , vle1 );
	Wrld->GetPlayer()->SetUInt32Value( log_slot + 1 , 0 );
	Wrld->GetPlayer()->SetUInt32Value( log_slot + 2 , 0 );
}


//-----------------------------------------------------------------------------
void QuestPacketHandler::SendQuestLogFullMessage( WorldSession *Wrld )
{
	WorldPacket data;

	data.Initialize( SMSG_QUESTLOG_FULL );
    Wrld->SendPacket( &data );

    Log::getSingleton( ).outDebug( "WORLD: Sent QUEST_LOG_FULL_MESSAGE" );
}

//-----------------------------------------------------------------------------
void QuestPacketHandler::SendQuestUpdateAddItem( WorldSession *Wrld, Quest *pQuest, uint32 iLogItem, uint32 iLogNr)
{
	WorldPacket data;

	data.Initialize( SMSG_QUESTUPDATE_ADD_ITEM );
	data << pQuest->m_questItemId[iLogItem] << uint32(iLogNr);
	Wrld->SendPacket( &data );
}

//-----------------------------------------------------------------------------
void QuestPacketHandler::SendQuestUpdateAddKill( WorldSession *Wrld, Quest *pQuest, uint64 creatureGUID, uint32 iNrMob, uint32 iLogMob )
{

	WorldPacket data;
    data.Initialize( SMSG_QUESTUPDATE_ADD_KILL );

    data << uint32(pQuest->m_questId);
    data << uint32(pQuest->m_questMobId[ iLogMob ]);
    data << uint32(iNrMob);
    data << uint32(pQuest->m_questMobCount[ iLogMob ]);
    data << creatureGUID;

	if (Wrld != NULL) 
	{
		Wrld->SendPacket(&data);
		Log::getSingleton( ).outDebug( "WORLD: Sent SMSG_QUESTUPDATE_ADD_KILL" );

		// Update Log Slot
		if (Wrld->GetPlayer() != NULL)
		{
			uint16 log_slot   = Wrld->GetPlayer()->getQuestSlot( pQuest->m_questId );
			uint32 kills      = Wrld->GetPlayer()->GetUInt32Value( log_slot + 1 ); 
			kills             = kills + (1 << ( 6 * iLogMob ));
			Wrld->GetPlayer()->SetUInt32Value( log_slot + 1, kills );		
		}
	}
}

//-----------------------------------------------------------------------------
void QuestPacketHandler::SendQuestUpdateSetTimer( WorldSession *Wrld, Quest *pQuest, uint32 TimerValue)
{
	uint16 log_slot   = Wrld->GetPlayer()->getQuestSlot( pQuest->m_questId ); 
	time_t pk		  = time(NULL);
	pk += (TimerValue * 60);
	Wrld->GetPlayer()->SetUInt32Value( log_slot + 2, pk );
}

//-----------------------------------------------------------------------------
void QuestPacketHandler::SendQuestUpdateFailed( WorldSession *Wrld, Quest *pQuest )
{
	WorldPacket data;

	data.Initialize( SMSG_QUESTUPDATE_FAILED );
	data << uint32(pQuest->m_questId);
    Wrld->SendPacket( &data );
    Log::getSingleton( ).outDebug( "WORLD: Sent SMSG_QUESTUPDATE_FAILED" );

/*	uint16 log_slot   = Wrld->GetPlayer()->getQuestSlot( pQuest->m_questId );
	uint32 kills      = Wrld->GetPlayer()->GetUInt32Value( log_slot + 1 );
	kills            |= 0x01000000;
	Wrld->GetPlayer()->SetUInt32Value( log_slot + 1, kills );*/
}

//-----------------------------------------------------------------------------
void QuestPacketHandler::SendQuestUpdateFailedTimer( WorldSession *Wrld, Quest *pQuest )
{
	WorldPacket data;

	data.Initialize( SMSG_QUESTUPDATE_FAILEDTIMER );
	data << uint32(pQuest->m_questId);
    Wrld->SendPacket( &data );
    Log::getSingleton( ).outDebug( "WORLD: Sent SMSG_QUESTUPDATE_FAILEDTIMER" );

/*	uint16 log_slot   = Wrld->GetPlayer()->getQuestSlot( pQuest->m_questId );
	uint32 kills      = Wrld->GetPlayer()->GetUInt32Value( log_slot + 1 );
	kills            |= 0x01000000;
	Wrld->GetPlayer()->SetUInt32Value( log_slot + 1, kills );*/
}

//-----------------------------------------------------------------------------
void QuestPacketHandler::SendSpiritHealerList( WorldSession *Wrld, uint64 creatureGUID)
{
	Log::getSingleton().outDebug("Sent SpiritHealer List !");

    Affect *aff;

	Player *pPlayer = Wrld->GetPlayer();

	// Cast 10min Resurrection Sickness on player
	//
	SpellEntry *spellInfo = sSpellStore.LookupEntry( 15007 );	// zzOLD Rez Sickness was 2146
	if(spellInfo) {
		aff = new Affect(spellInfo, 600000, pPlayer->GetGUID());
		pPlayer->AddAffect(aff);
	}

	pPlayer->DeathDurabilityLoss (0.25);
    pPlayer->ResurrectPlayer();

	QuestPacketHandler::getSingleton().SendCloseGossipToPlayer( Wrld );
}

//-----------------------------------------------------------------------------
void QuestPacketHandler::SendTabardList( WorldSession *Wrld, uint64 creatureGUID)
{
	Log::getSingleton().outDebug("Sent Tabard List !");

    WorldPacket data;

    data.Initialize( MSG_TABARDVENDOR_ACTIVATE );
    data << creatureGUID;
    Wrld->SendPacket( &data );
}

//-----------------------------------------------------------------------------
void QuestPacketHandler::SendBankerList( WorldSession *Wrld, uint64 creatureGUID)
{
	Log::getSingleton().outDebug("Sent Banker List !");

    WorldPacket data;

    data.Initialize( SMSG_SHOW_BANK );
    data << creatureGUID;
    Wrld->SendPacket( &data );
}

//-----------------------------------------------------------------------------
void QuestPacketHandler::SendTrainerList( WorldSession *Wrld, uint64 creatureGUID, std::string trtext)
{
    WorldPacket data;

	Log::getSingleton().outDebug("TRAIN: Sending Trainer List...");

	Creature *cTrainer = objmgr.GetObject<Creature>(creatureGUID);
	if(!cTrainer)
		return;

	Log::getSingleton().outDebug("TRAIN: Trainer found: ID: %d.", cTrainer->GetEntry());

	Trainerspell *strainer = objmgr.GetTrainerspell(cTrainer->GetEntry());//GUID_LOPART(creatureGUID));
	uint32 cnt = 0;
	if(strainer)
	{

		Log::getSingleton().outDebug("TRAIN: Trainer has spells to train.");

        for (unsigned int t = 0;t < sSkillStore.GetNumRows();t++)
        {
			skilllinespell *skill = sSkillStore.LookupEntry(t);
			if (skill == NULL) continue;

			if ((skill->skilline == strainer->skilline01) 
				|| (skill->skilline == strainer->skilline02) 
				|| (skill->skilline == strainer->skilline03) 
				|| (skill->skilline == strainer->skilline04) 
				|| (skill->skilline == strainer->skilline05) 
				|| (skill->skilline == strainer->skilline06) 
				|| (skill->skilline == strainer->skilline07) 
				|| (skill->skilline == strainer->skilline08) 
				|| (skill->skilline == strainer->skilline09) 
				|| (skill->skilline == strainer->skilline10) 
				|| (skill->skilline == strainer->skilline11) 
				|| (skill->skilline == strainer->skilline12) 
				|| (skill->skilline == strainer->skilline13) 
				|| (skill->skilline == strainer->skilline14) 
				|| (skill->skilline == strainer->skilline15) 
				|| (skill->skilline == strainer->skilline16) 
				|| (skill->skilline == strainer->skilline17) 
				|| (skill->skilline == strainer->skilline18) 
				|| (skill->skilline == strainer->skilline19) 
				|| (skill->skilline == strainer->skilline20))
			{
				//Log::getSingleton().outString("skill %u with skillline %u matches",skill->spell,skill->skilline);
				SpellEntry *proto = sSpellStore.LookupEntry(skill->spell);
				if ((proto) && (proto->spellLevel != 0) && (objmgr.TeachSpellID[skill->spell] != NULL))
				{
					cnt++;
				}
			}
        }
		data.Initialize( SMSG_TRAINER_LIST ); //set packet size - count = number of spells
		data << creatureGUID;
		data << uint32(0) << uint32(cnt);
		Log::getSingleton().outString("TRAIN: Spells count: %u", cnt);
        for (unsigned int t = 0;t < sSkillStore.GetNumRows();t++)
        {
			skilllinespell *skill = sSkillStore.LookupEntry(t);
			if (skill == NULL) continue;

			if ((skill->skilline == strainer->skilline01) 
				|| (skill->skilline == strainer->skilline02) 
				|| (skill->skilline == strainer->skilline03)
				|| (skill->skilline == strainer->skilline04)
				|| (skill->skilline == strainer->skilline05)
				|| (skill->skilline == strainer->skilline06)
				|| (skill->skilline == strainer->skilline07)
				|| (skill->skilline == strainer->skilline08)
				|| (skill->skilline == strainer->skilline09)
				|| (skill->skilline == strainer->skilline10)
				|| (skill->skilline == strainer->skilline11)
				|| (skill->skilline == strainer->skilline12)
				|| (skill->skilline == strainer->skilline13)
				|| (skill->skilline == strainer->skilline14)
				|| (skill->skilline == strainer->skilline15)
				|| (skill->skilline == strainer->skilline16)
				|| (skill->skilline == strainer->skilline17)
				|| (skill->skilline == strainer->skilline18)
				|| (skill->skilline == strainer->skilline19)
				|| (skill->skilline == strainer->skilline20))
			{
				SpellEntry *proto = sSpellStore.LookupEntry(skill->spell);
				if ((proto) && (proto->spellLevel != 0) && (objmgr.TeachSpellID[skill->spell] != NULL))
				{
					Log::getSingleton( ).outString( "TRAIN: Grabbing trainer spell %u with skilline %u", skill->spell, skill->skilline);
					data << uint32(objmgr.TeachSpellID[skill->spell]);
					//data << uint32(10);
					if (Wrld->GetPlayer()->HasSpell(skill->spell))
					{
						data << uint8(2);
					}
					else
					{
						if ((Wrld->GetPlayer()->GetLevel() < proto->spellLevel) ||
							(Wrld->GetPlayer()->GetUInt32Value( PLAYER_FIELD_COINAGE ) < 
								sWorld.mPrices[proto->spellLevel]))
						{
							data << uint8(1);
						} else {
							data << uint8(0);
						}
					}
					data << uint32(sWorld.mPrices[proto->spellLevel]) << uint32(0);
					data << uint32(0) << uint8(proto->spellLevel);
					data << uint32(0); // set type
					data << uint32(0); // set required level of a skill line
					data << uint32(0); 
					data << uint32(0) << uint32(0);
				}
			}
        }

		if (trtext == "")
			data << "Greetings $N, ready for some training ?"; else
			data << trtext;

		Log::getSingleton().outDebug("TRAIN: Sent Trainer List !");
		Wrld->SendPacket( &data );
	}
}

//-----------------------------------------------------------------------------
void QuestPacketHandler::SendPetitionList( WorldSession *Wrld, uint64 creatureGUID)
{
	Log::getSingleton().outDebug("Sent Petition List !");

    WorldPacket data;
    unsigned char tdata[21] =
    {
        0x01, 0x01, 0x00, 0x00, 0x00, 0xe7, 0x16, 0x00, 0x00, 0xef, 0x23, 0x00, 0x00, 0xe8, 0x03, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00
    };

    data.Initialize( SMSG_PETITION_SHOWLIST );
    data << creatureGUID;
    data.append( tdata, sizeof(tdata) );
    Wrld->SendPacket( &data );
}

//-----------------------------------------------------------------------------
void QuestPacketHandler::SendAuctionerList( WorldSession *Wrld, uint64 creatureGUID)
{
	Log::getSingleton().outDebug("Sent Auction List !");

    WorldPacket data;

    data.Initialize( MSG_AUCTION_HELLO );
    data << creatureGUID;
    data << uint32(0x00);

    Wrld->SendPacket( &data );
}

//-----------------------------------------------------------------------------
void QuestPacketHandler::SendInnkeeperList( WorldSession *Wrld, uint64 creatureGUID)
{
	WorldPacket data;
	Player *pPlayer = Wrld->GetPlayer();

    Log::getSingleton().outDebug("Sent Inkeeper List !");

    data.Initialize(SMSG_SPELL_START );
	
	data << pPlayer->GetGUID() << pPlayer->GetGUID();
	data << uint32(0x0CD6);
    data << uint16(0) << uint32(0) << uint16(0x02); 
	data << uint32(0x1258C);
	data << uint32(0);
    Wrld->SendPacket( &data );

	Make_SMSG_SPELL_GO (&data, 0x0CD6, pPlayer, pPlayer);
	pPlayer->SendMessageToSet (&data, true);

	QuestPacketHandler::getSingleton().SendCloseGossipToPlayer( Wrld );

	// Update Bind Point

	pPlayer->m_bindPointX    = pPlayer->GetPositionX();
	pPlayer->m_bindPointY    = pPlayer->GetPositionY();
	pPlayer->m_bindPointZ    = pPlayer->GetPositionZ();
	pPlayer->m_bindPointMap  = pPlayer->GetMapId();
	pPlayer->m_bindPointArea = pPlayer->GetZoneId();

	pPlayer->SaveToDB();


	data.Initialize ( SMSG_BINDPOINTUPDATE );
	data << pPlayer->m_bindPointX << pPlayer->m_bindPointY
		 << pPlayer->m_bindPointZ << pPlayer->m_bindPointMap;
	data << pPlayer->m_bindPointArea;
	Wrld->SendPacket (&data);


	data.Initialize ( SMSG_PLAYERBOUND );
	data << pPlayer->GetGUID();
	data << pPlayer->m_bindPointArea;
	Wrld->SendPacket (&data);
}

//-----------------------------------------------------------------------------
void QuestPacketHandler::SendVendorList( WorldSession *Wrld, uint64 creatureGUID)
{
	Log::getSingleton().outDebug("Sent Vendor List !");

    WorldPacket data;

    Creature *unit = objmgr.GetObject<Creature>(creatureGUID);
    if (unit == NULL) return;

    // Find sell-template
	SellTemplateMap::iterator iters = objmgr.m_sellTemplates.find (unit->GetEntry());

	if (iters == objmgr.m_sellTemplates.end()) {
		Log::getSingleton( ).outDetail( "Erm NPC %d (GUID %X) has nothing to sell",
			unit->GetEntry(), unit->GetGUIDLow());
		return;
	}

	SellTemplate & selltemp = *(iters->second);

    data.Initialize( SMSG_LIST_INVENTORY );
    data << creatureGUID;
    data << (uint8)selltemp.size(); // num items

	//
    // each item has seven uint32's
	//
	ItemPrototype * curItem;
    for (uint8 itemcount = 0; itemcount < selltemp.size(); itemcount ++ )
    {
        curItem = objmgr.GetItemPrototype (selltemp[itemcount]);
        
		if( !curItem ) {
            Log::getSingleton( ).outError( "Unit %i has nonexistant item %i!", creatureGUID, selltemp[itemcount] );
            Log::getSingleton( ).outBasic( "WORLD: DID NOT Send SMSG_LIST_INVENTORY Message" );
            for( int a = 0; a < 7; a ++ )
                data << uint32( 0 );
        } else 
        {
            data << uint32 (itemcount + 1);			// index ? doesn't seem to affect anything
            data << uint32 (selltemp[itemcount]);	// item id
            data << uint32 (curItem->DisplayInfoID); // item icon
            data << uint32 (-1);					// number of items available, -1 works for infinity, although maybe just 'cause it's really big
            data << uint32 (curItem->BuyPrice);		// price
            data << uint32 (0);						// ?

            data << uint32 (curItem->GetSellStackSize());
        }
    }

    WPAssert(data.size() == 8 + 1 + selltemp.size() * 7 * 4);
    Wrld->SendPacket( &data );
    Log::getSingleton( ).outDetail( "WORLD: Sent SMSG_LIST_INVENTORY" );
}

//-----------------------------------------------------------------------------
void QuestPacketHandler::SendTaxiList( WorldSession *Wrld, uint64 creatureGUID)
{
	Log::getSingleton().outDebug("Sent Taxi List !");

    uint32 curloc;
    uint8 field;
    uint32 TaxiMask[8];
    uint32 submask;

    curloc = objmgr.GetNearestTaxiNode(
        Wrld->GetPlayer( )->GetPositionX( ),
        Wrld->GetPlayer( )->GetPositionY( ),
        Wrld->GetPlayer( )->GetPositionZ( ),
        Wrld->GetPlayer( )->GetMapId( ) );

    if ( curloc == 0 )
        return;

    field = (uint8)((curloc - 1) / 32);
    submask = 1<<((curloc-1)%32);

    // Check for known nodes
    if ( (Wrld->GetPlayer( )->GetTaximask(field) & submask)
         != submask )
    {
        Wrld->GetPlayer()->SetTaximask(field, (submask | Wrld->GetPlayer( )->GetTaximask(field)) );
        
        WorldPacket msg;
        char buf[256];
        sprintf((char*)buf, "You discovered a new taxi vendor.");
        sChatHandler.FillSystemMessageData(&msg, Wrld->GetPlayer()->GetSession(), buf);
        Wrld->SendPacket( &msg );
        
        WorldPacket update;
        update.Initialize( SMSG_TAXINODE_STATUS );
        update << creatureGUID;
        update << uint8( 1 );
        Wrld->SendPacket( &update );
    }

    // New in 0.12.0
    // A 256bit bitmask representing taxi nodes ... position of the bit = taxinodeID
    memset(TaxiMask, 0, sizeof(TaxiMask));
    if ( !objmgr.GetGlobalTaxiNodeMask( curloc, TaxiMask ) )
        return;
    TaxiMask[field] |= 1 << ((curloc-1)%32);

    WorldPacket data;
    data.Initialize( SMSG_SHOWTAXINODES );
    data << uint32( 1 ) << creatureGUID;
    data << uint32( curloc );
    for (uint8 i=0; i<8; i++)
    {
        TaxiMask[i] &= Wrld->GetPlayer( )->GetTaximask(i);
        data << TaxiMask[i];
    }
    Wrld->SendPacket( &data );

    Log::getSingleton( ).outDebug( "WORLD: Sent SMSG_SHOWTAXINODES" );
}

//-----------------------------------------------------------------------------
void QuestPacketHandler::SendPointOfInterest( WorldSession *Wrld, float X, float Y, uint32 Icon, uint32 Flags, uint32 Data, const std::string locName )
{
    WorldPacket data;

    data.Initialize( SMSG_GOSSIP_POI );
	data << Flags;

	data << X << Y;

	data << uint32(Icon);
	data << uint32(Data);
	data << locName;

	Wrld->SendPacket( &data );

	Log::getSingleton().outDebug("WORLD: Sent SMSG_GOSSIP_POI");
}

void QuestPacketHandler::SendQuestFailedToPlayer( WorldSession *Wrld, uint32 iReason )
{
    WorldPacket data;

    data.Initialize( SMSG_QUESTGIVER_QUEST_FAILED );
	data << iReason;

	Wrld->SendPacket( &data );

	Log::getSingleton().outDebug("WORLD: Sent SMSG_QUESTGIVER_QUEST_FAILED");
}

void QuestPacketHandler::SendQuestInvalid( WorldSession *Wrld, uint32 iReason )
{
    WorldPacket data;

    data.Initialize( SMSG_QUESTGIVER_QUEST_INVALID );
	data << iReason;

	Wrld->SendPacket( &data );

	Log::getSingleton().outDebug("WORLD: Sent SMSG_QUESTGIVER_QUEST_INVALID");
}

//--- END ---