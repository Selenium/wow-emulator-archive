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
#include "Opcodes.h"
#include "Log.h"
#include "Player.h"
#include "World.h"
#include "ObjectMgr.h"
#include "WorldSession.h"
#include "Auth/BigNumber.h"
#include "Auth/Sha1.h"
#include "UpdateData.h"
#include "ExplorationMgr.h"
#include <zlib/zlib.h>

void WorldSession::HandleRepopRequestOpcode( WorldPacket & recv_data )
{
    Log::getSingleton( ).outDebug( "WORLD: Recvd CMSG_REPOP_REQUEST Message" );

    GetPlayer()->BuildPlayerRepop();
    GetPlayer()->RepopAtGraveyard();
}

void WorldSession::HandleAutostoreLootItemOpcode( WorldPacket & recv_data )
{
    uint8 slot = 0;
    uint32 itemid = 0;
	uint32 amt = 1;
    uint8 lootSlot = 0;
    WorldPacket data;
	Item *add;
	uint8 bagslot = 0;

    Creature* pCreature = objmgr.GetObject<Creature>(GetPlayer()->GetLootGUID());
    if (!pCreature)
        return;

    recv_data >> lootSlot;
	lootSlot -=1; //to prevent Slot 0 from been used "Still Rolling for item fix"
	add = GetPlayer()->FindItemLessMax(pCreature->getLootid(lootSlot),pCreature->getLootAmt(pCreature->getLootid(lootSlot)));
	if (!add)
	{
		slot = GetPlayer()->FindFreeInvSlot();
	}
	if ((slot == INVENTORY_NO_SLOT_AVAILABLE) && (!add))
	{
        slot = CONTAINER_NO_SLOT_AVAILABLE;
		bagslot = GetPlayer()->FindBagWithFreeSlots();
		if (bagslot)
			slot = GetPlayer()->FindFreeBagSlot(bagslot);
	}
	if ((slot == CONTAINER_NO_SLOT_AVAILABLE) && (!add))
	{
		//Our User doesn't have a free Slot in there bag
		GetPlayer()->BuildInventoryChangeError(NULL, NULL, INV_ERR_INVENTORY_FULL);
		return;
	}

	if (pCreature->getLootAmt(pCreature->getLootid(lootSlot)) == 0) //Can't sell the item for cash
        return;

    itemid = pCreature->getLootid(lootSlot);
	ItemPrototype* it = objmgr.GetItemPrototype(itemid);
	if(!it)
		return;
	amt = pCreature->getLootAmt(itemid);
	if ((it->Class != 12) || ((it->Class == 12) && (it->MaxCount > 1)))
	{
		pCreature->setLootAmt(itemid,0);
	}
	if (!add)
	{
		sLog.outDebug("AutoLootItem MISC");
        Item *item = new Item();
		ASSERT(item);
		item->Create(objmgr.GenerateLowGuid(HIGHGUID_ITEM), itemid, GetPlayer());
		item->SetUInt32Value(ITEM_FIELD_STACK_COUNT,amt);
		item->SetUInt32Value(ITEM_FIELD_RANDOM_PROPERTIES_ID,pCreature->getLootProp(pCreature->getLootid(lootSlot)));
		if(bagslot)
		{
			Item* bag = GetPlayer()->GetItemBySlot(bagslot);
			bag->pContainer->AddItem(slot, item);
		}
		else
		{
			GetPlayer()->AddItemToSlot(slot, item);
		}
		
		if (it->Field109 > 0)
		{
			RandomProps *rp= sRandomPropStore.LookupEntry(pCreature->getLootProp(pCreature->getLootid(lootSlot)));
			for (int k=0;k<3;k++)
			{
				if (rp->spells[k] != 0)
				{
					item->SetUInt32Value(ITEM_FIELD_ENCHANTMENT + k,rp->spells[k]);
				}
			}
		}
	} else {
		add->SetUInt32Value(ITEM_FIELD_STACK_COUNT,add->GetUInt32Value(ITEM_FIELD_STACK_COUNT) + amt);
	}

    data.Initialize( SMSG_LOOT_REMOVED );
    data << uint8(lootSlot+1);
    SendPacket( &data );

	data.clear();
    data.Initialize( SMSG_ITEM_PUSH_RESULT );

	// Data filling
	data << GetPlayer()->GetGUID();
	data << uint64(0x00000000);
	data << uint8(0x01);			// Goes constant to all
	data << uint8(0x00);
	data << uint8(0x00);
	data << uint8(0x00);
	data << uint8(0xFF);			// Goes constant to all
    data << uint32(itemid);
	data << uint32(0);
	data << uint32(pCreature->getLootProp(pCreature->getLootid(lootSlot)));

    SendPacket( &data );

}

void WorldSession::HandleLootMoneyOpcode( WorldPacket & recv_data )
{
	WorldPacket data;

    uint32 newcoinage = 0;

    Creature* pCreature = objmgr.GetObject<Creature>(GetPlayer()->GetLootGUID());
    if (!pCreature)
        return;

    newcoinage = GetPlayer()->GetUInt32Value(PLAYER_FIELD_COINAGE) + pCreature->getLootMoney();
    pCreature->setLootMoney(0);
    GetPlayer()->SetUInt32Value( PLAYER_FIELD_COINAGE , newcoinage);
}


void WorldSession::HandleLootOpcode( WorldPacket & recv_data )
{
    uint64 guid;
    uint16 tmpDataLen;
    uint8 i, tmpItemsCount = 0;
    WorldPacket data;
	
 	recv_data >> guid;

    Creature* pCreature = objmgr.GetObject<Creature>(guid);
    if (!pCreature)
        return;

	Player *pl = GetPlayer();
    GetPlayer()->SetLootGUID(guid);
	std::map<uint32, QuestLogEntry *>::iterator q;
	std::map<uint32, uint32>::const_iterator lootitr, propitr;
    for(lootitr = pCreature->getLootBegin(); lootitr != pCreature->getLootEnd(); lootitr++)
    {
        if (lootitr->second > 0)
		{
			ItemPrototype* itemProto = objmgr.GetItemPrototype(lootitr->first);
			if (itemProto)
			{
				if (itemProto->Class == 12)
				{
					for( q = pl->QuestsBegin(); q != pl->QuestsEnd();q++)
					{
						std::map<uint32, uint8>::const_iterator it;
						for (it = q->second->GetQuest()->GetTurninItemsBegin(); it != q->second->GetQuest()->GetTurninItemsEnd();it++)
						{
							if ((it->first == itemProto->ItemId) && (pl->Find_QLE(q->second->GetQuest()->GetID())) && (lootitr->second < it->second))
							{
								pCreature->setLootid(tmpItemsCount,lootitr->first);
								tmpItemsCount++;
							}
						}

					}
				}
				else
				{	
					printf("setting loot id %u to %u\n",tmpItemsCount,lootitr->first);
					pCreature->setLootid(tmpItemsCount,lootitr->first);
					tmpItemsCount++;
				}
			}
			else
				printf("item id %u not found\n",lootitr->first);
		}
    }

    tmpDataLen = 14 + tmpItemsCount*22;

    data.Initialize( SMSG_LOOT_RESPONSE );

	uint32 id = 0;
	uint32 amt = 0;
    data << guid;
	// 0 =  Premission Deined | 1 = 4 = 5 = 2 = Death | 3 = Fishing
    data << uint8(1); //loot Type
    data << uint32(pCreature->getLootMoney());
	data << uint8(tmpItemsCount);
    for(i = 0; i < tmpItemsCount; i++)
    {
		id = pCreature->getLootid(i);
		amt = pCreature->getLootAmt(id);
        if (amt > 0)
		{
			ItemPrototype* itemProto = objmgr.GetItemPrototype(id);
			if (itemProto)
			{
				if (itemProto->Class == 12)
				{
					for( q = pl->QuestsBegin(); q != pl->QuestsEnd();q++)
					{
						std::map<uint32, uint8>::const_iterator it;
						for (it = q->second->GetQuest()->GetTurninItemsBegin(); it != q->second->GetQuest()->GetTurninItemsEnd();it++)
						{
							if ((it->first == itemProto->ItemId) && (pl->Find_QLE(q->second->GetQuest()->GetID())) && (lootitr->second < it->second))
							{
								data << uint8(i+1); //Item Slot, must be > 0
								data << uint32(id); //item ID
								data << uint32(amt); //quantity
								data << uint32(itemProto->DisplayInfoID); //Display IconID
								data << uint32(0) << uint32(pCreature->getLootProp(id)) << uint8(0);
							}
						}

					}
				}
				else
				{	
					data << uint8(i+1); //Item Slot, must be > 0
					data << uint32(id); //item ID
					data << uint32(amt); //quantity
					data << uint32(itemProto->DisplayInfoID); //Display IconID
					data << uint32(0) << uint32(pCreature->getLootProp(id)) << uint8(0);
				}
			}
			else
				printf("item id %u not found\n",lootitr->first);
		}
    }
	WPAssert(data.size() == tmpDataLen);
    SendPacket( &data );
}


void WorldSession::HandleLootReleaseOpcode( WorldPacket & recv_data )
{
    uint64 guid;
    WorldPacket data;

    recv_data >> guid;

	Creature* pCreature = objmgr.GetObject<Creature>(guid);
	if (!pCreature)
		return;

    GetPlayer()->SetLootGUID(0);

	if(pCreature->HasFlag(UNIT_DYNAMIC_FLAGS, U_DYN_FLAG_LOOTABLE))
		pCreature->RemoveFlag(UNIT_DYNAMIC_FLAGS, U_DYN_FLAG_LOOTABLE);

    data.Initialize( SMSG_LOOT_RELEASE_RESPONSE );
    data << guid << uint8( 1 );
    SendPacket( &data );
}


void WorldSession::HandleWhoOpcode( WorldPacket & recv_data )
{
    uint64 clientcount = 0;
    int datalen = 8;
    int countcheck = 0;
    WorldPacket data;

    Log::getSingleton( ).outDebug( "WORLD: Recvd CMSG_WHO Message" );

    ObjectMgr::PlayerMap::const_iterator itr;
    for (itr = objmgr.Begin<Player>(); itr != objmgr.End<Player>(); itr++)
    {
        if ( itr->second->GetName() )
        {
            if( GetPlayer()->myFaction == itr->second->myFaction )
            {
                clientcount++;

                datalen = datalen + strlen(itr->second->GetName()) + 1 + 17;
            }
        }
    }
 
    data.Initialize( SMSG_WHO );
    data << uint32( clientcount );
	data << uint32( clientcount );

    for (itr = objmgr.Begin<Player>(); itr != objmgr.End<Player>(); itr++)
    {
        if ( itr->second->GetName() && (countcheck  < clientcount))
        {
            if( GetPlayer()->myFaction == itr->second->myFaction )
            {
                countcheck++;

                data.append(itr->second->GetName() , strlen(itr->second->GetName()) + 1);
				Guild* pguild = objmgr.GetGuild(itr->second->GetGuildId());
				if(pguild)
				{
					data << pguild->GetGuildName().c_str();
				}
				else
				{
					data << uint8(0x00);
				}
                data << uint32( itr->second->getLevel() );
                data << uint32( itr->second->getClass() );
                data << uint32( itr->second->getRace() );
                data << uint32( itr->second->GetZoneId() );
            }
        }
    }

   // WPAssert(data.size() == datalen);
    SendPacket(&data);
}


void WorldSession::HandleLogoutRequestOpcode( WorldPacket & recv_data )
{
    WorldPacket data;

    Log::getSingleton( ).outDebug( "WORLD: Recvd CMSG_LOGOUT_REQUEST Message" );

	Player *pPlayer = GetPlayer();
	if(pPlayer)
	{
		if(pPlayer->m_isResting)	// We are resting so log out instantly
		{
			LogoutPlayer(true);
			return;
		}

		if(pPlayer->DuelingWith != NULL || pPlayer->m_lastDamage > 0)
		{
			//can't quit still dueling or attacking
			data.Initialize( SMSG_LOGOUT_RESPONSE );
			data << uint32(0x1); //Filler
			data << uint8(0); //Logout accepted
			SendPacket( &data );
			return;
		}

		data.Initialize( SMSG_LOGOUT_RESPONSE );
		data << uint32(0); //Filler
		data << uint8(0); //Logout accepted
		SendPacket( &data );

		//stop player from moving
		pPlayer->SetMovement(MOVE_ROOT);
	
		// Set the "player locked" flag, to prevent movement
		if ( !(GetPlayer( )->GetUInt32Value(UNIT_FIELD_FLAGS) & U_FIELD_FLAG_LOCK_PLAYER) )
			GetPlayer( )->SetFlag( UNIT_FIELD_FLAGS, U_FIELD_FLAG_LOCK_PLAYER );

		//make player sit
		pPlayer->SetStandState(STANDSTATE_SIT);
		LogoutRequest(time(NULL));
	}
	/*
	> 0 = You can't Logout Now
	*/
}


void WorldSession::HandlePlayerLogoutOpcode( WorldPacket & recv_data )
{
    WorldPacket data;

    Log::getSingleton( ).outDebug( "WORLD: Recvd CMSG_PLAYER_LOGOUT Message" );

	LogoutPlayer(true);
}


void WorldSession::HandleLogoutCancelOpcode( WorldPacket & recv_data )
{
    WorldPacket data;

    Log::getSingleton( ).outDebug( "WORLD: Recvd CMSG_LOGOUT_CANCEL Message" );

	Player *pPlayer = GetPlayer();
	if(!pPlayer)
		return;

	//Cancel logout Timer
	LogoutRequest(0);

	//tell client about cancel
    data.Initialize( SMSG_LOGOUT_CANCEL_ACK );
    SendPacket( &data );

	//unroot player
	pPlayer->SetMovement(MOVE_UNROOT);

	// Remove the "player locked" flag, to allow movement
	if ( GetPlayer( )->GetUInt32Value(UNIT_FIELD_FLAGS) & U_FIELD_FLAG_LOCK_PLAYER )
		GetPlayer( )->RemoveFlag( UNIT_FIELD_FLAGS, U_FIELD_FLAG_LOCK_PLAYER );

	//make player stand
	pPlayer->SetStandState(STANDSTATE_STAND);

    Log::getSingleton( ).outDebug( "WORLD: sent SMSG_LOGOUT_CANCEL_ACK Message" );
}


void WorldSession::HandleZoneUpdateOpcode( WorldPacket & recv_data )
{
    uint32 newZone,oldZone;
    WPAssert(GetPlayer());
    
    recv_data >> newZone;
    Log::getSingleton( ).outDetail("WORLD: Recvd ZONE_UPDATE: %u", newZone);
	
	if(GetPlayer()->m_isResting)
		GetPlayer()->ExitInn();

    if (GetPlayer()->GetZoneId() == newZone)
        return;

    oldZone = GetPlayer( )->GetZoneId();

    //Setting new zone
    GetPlayer()->SetZoneId((uint16)newZone);
}


void WorldSession::HandleSetTargetOpcode( WorldPacket & recv_data )
{
    uint64 guid ;
    recv_data >> guid;

    if( GetPlayer( ) != 0 ){
        GetPlayer( )->SetTarget(guid);
    }
}


void WorldSession::HandleSetSelectionOpcode( WorldPacket & recv_data )
{
    uint64 guid;
    recv_data >> guid;

    if( GetPlayer( ) != 0 )
        GetPlayer( )->SetSelection(guid);
    else
        return;

    if(GetPlayer( )->GetUInt64Value(PLAYER__FIELD_COMBO_TARGET) != guid){ // if its a new Target set Combo Points Target to 0
        GetPlayer( )->SetUInt64Value(PLAYER__FIELD_COMBO_TARGET,0);
        GetPlayer( )->SetUInt32Value(PLAYER_FIELD_BYTES,((GetPlayer( )->GetUInt32Value(PLAYER_FIELD_BYTES) & ~(0xFF << 8)) | (0x00 << 8)));
    }
}


void WorldSession::HandleStandStateChangeOpcode( WorldPacket & recv_data )
{
    if( GetPlayer( ) != 0 )
    {
        // retrieve current BYTES
        uint32 bytes1 = GetPlayer( )->GetUInt32Value( UNIT_FIELD_BYTES_1 );
        uint8 bytes[4];

//        uint64 guid; no need for it in 0.12
//        recv_data >> guid;

        bytes[0] = uint8(bytes1 & 0xff);
        bytes[1] = uint8((bytes1>>8) & 0xff);
        bytes[2] = uint8((bytes1>>16) & 0xff);
        bytes[3] = uint8((bytes1>>24) & 0xff);

        // retrieve new stand state
        uint8 animstate;
        recv_data >> animstate;

		if ((animstate == 0) && (GetPlayer()->GetEating()))
		{
			GetPlayer()->RemoveAffectById(GetPlayer()->GetEating());
			GetPlayer()->SetEating(0);
		}

        // if (bytes[0] == animstate) break;
        bytes[0] = animstate;

        uint32 newbytes = (bytes[0]) + (bytes[1]<<8) + (bytes[2]<<16) + (bytes[3]<<24);
        GetPlayer( )->SetUInt32Value(UNIT_FIELD_BYTES_1 , newbytes);
    }
}


void WorldSession::HandleFriendListOpcode( WorldPacket & recv_data )
{
    Log::getSingleton( ).outDebug( "WORLD: Recieved CMSG_FRIEND_LIST"  );

    GetPlayer()->SendFriendListData();  
}


void WorldSession::HandleAddFriendOpcode( WorldPacket & recv_data )
{
    Log::getSingleton( ).outDebug( "WORLD: Recieved CMSG_ADD_FRIEND"  );

    std::string friendName = "UNKNOWN";
    recv_data >> friendName;

    unsigned char friendResult = FRIEND_NOT_FOUND;
    uint64 friendGuid = 0;
    uint32 friendArea = 0;
    uint32 friendLevel = 0;
    uint32 friendClass = 0;
	uint8 friendstatus = 0;
    WorldPacket data;
    Player *player = GetPlayer();
    Player *pFriend = NULL;

    friendGuid = objmgr.GetPlayerGUIDByName(friendName.c_str());
    if (friendGuid > 0)
    {
        pFriend = objmgr.GetObject<Player>(friendGuid);
        if( pFriend != NULL )
            friendResult = FRIEND_ADDED_ONLINE;
        else
            friendResult = FRIEND_ADDED_OFFLINE;

    }
    else
    {
        Log::getSingleton( ).outDetail( "WORLD: %s Guid not found ", friendName.c_str() );
    }

    // Send reposnse.
    data.Initialize( SMSG_FRIEND_STATUS );

    if (!strcmp(GetPlayer()->GetName(),friendName.c_str()))
    {
        friendResult = FRIEND_SELF;
        data << (uint8)friendResult << (uint64)friendGuid << friendstatus;
    }
    else
    {
        if (pFriend || friendResult ==  FRIEND_ADDED_ONLINE || friendResult == FRIEND_ONLINE //||
            //friendResult ==  FRIEND_OFFLINE
            //|| FriendResult ==  FRIEND_ADDED_OFFLINE
            )
        {
                data << (uint8)friendResult << (uint64)friendGuid << friendstatus;
                data << pFriend->GetZoneId() << (uint32)pFriend->getLevel() << (uint32)pFriend->getClass();
        }
        else 
        {
            data << (uint8)friendResult << (uint64)friendGuid << friendstatus;
        }

        struct FriendStr fList;
        fList.PlayerGUID = friendGuid;
        fList.Status = 0;
        fList.Area = 0;
        fList.Level = 0;
        fList.Class = 0;
        if(player)
            player->AddFriend(fList);
    }

    SendPacket( &data );
}


void WorldSession::HandleDelFriendOpcode( WorldPacket & recv_data )
{
    uint64 FriendGUID;
    WorldPacket data;

    Log::getSingleton( ).outDebug( "WORLD: Recieved CMSG_DEL_FRIEND"  );
    recv_data >> FriendGUID;

    unsigned char FriendResult = FRIEND_REMOVED;

    int FriendArea = 0;
    int FriendLevel = 0;
    int FriendClass = 0;

    // Send reposnse.
    data.Initialize( SMSG_FRIEND_STATUS );

    data << (uint8)FriendResult << (uint64)FriendGUID;

    Player *player = GetPlayer();
    if(player)
        player->DeleteFriend(FriendGUID);

    SendPacket( &data );
}


void WorldSession::HandleBugOpcode( WorldPacket & recv_data )
{
    uint32 suggestion, contentlen;
    std::string content;
    uint32 typelen;
    std::string type;

    recv_data >> suggestion >> contentlen >> content >> typelen >> type;

    if( suggestion == 0 )
        Log::getSingleton( ).outDebug( "WORLD: Recieved CMSG_BUG [Bug Report]" );
    else
        Log::getSingleton( ).outDebug( "WORLD: Recieved CMSG_BUG [Suggestion]" );

    Log::getSingleton( ).outDebug( type.c_str( ) );
    Log::getSingleton( ).outDebug( content.c_str( ) );
}

void WorldSession::HandleCorpseReclaimOpcode(WorldPacket &recv_data)
{
    Log::getSingleton().outDetail("WORLD: Received CMSG_RECLAIM_CORPSE");

    uint64 guid;
    recv_data >> guid;

    GetPlayer()->SetMovement(MOVE_LAND_WALK);
	GetPlayer()->SetMovement(MOVE_UNROOT);
	
    GetPlayer( )->SetPlayerSpeed(RUN, (float)7.5, true);
    GetPlayer( )->SetPlayerSpeed(SWIM, (float)4.9, true);

    GetPlayer( )->SetUInt32Value(CONTAINER_FIELD_SLOT_1+29, 0);
    GetPlayer( )->SetUInt32Value(UNIT_FIELD_AURA+32, 0);
    GetPlayer( )->SetUInt32Value(UNIT_FIELD_AURALEVELS+8, 0xeeeeeeee);
    GetPlayer( )->SetUInt32Value(UNIT_FIELD_AURAAPPLICATIONS+8, 0xeeeeeeee);
    GetPlayer( )->SetUInt32Value(UNIT_FIELD_AURAFLAGS+4, 0);
    GetPlayer( )->SetUInt32Value(UNIT_FIELD_AURASTATE, 0);

    GetPlayer()->ResurrectPlayer();
    GetPlayer()->SetUInt32Value(UNIT_FIELD_HEALTH, (uint32)(GetPlayer()->GetUInt32Value(UNIT_FIELD_MAXHEALTH)*0.50) );
    GetPlayer()->SpawnCorpseBones();
}

void WorldSession::HandleResurrectResponseOpcode(WorldPacket & recv_data)
{
    Log::getSingleton().outDetail("WORLD: Received CMSG_RESURRECT_RESPONSE");

    if(GetPlayer()->isAlive())
        return;

    WorldPacket data;
    uint64 guid;
    uint8 status;
    recv_data >> guid;
    recv_data >> status;

    if(status != 0)
        return;

    if(GetPlayer()->m_resurrectGUID == 0)
        return;

    GetPlayer( )->SetMovement(MOVE_LAND_WALK);
    GetPlayer( )->SetMovement(MOVE_UNROOT);
    GetPlayer( )->SetPlayerSpeed(RUN, (float)7.5, true);
    GetPlayer( )->SetPlayerSpeed(SWIM, (float)4.9, true);

    GetPlayer( )->SetUInt32Value(CONTAINER_FIELD_SLOT_1+29, 0);
    GetPlayer( )->SetUInt32Value(UNIT_FIELD_AURA+32, 0);
    GetPlayer( )->SetUInt32Value(UNIT_FIELD_AURALEVELS+8, 0xeeeeeeee);
    GetPlayer( )->SetUInt32Value(UNIT_FIELD_AURAAPPLICATIONS+8, 0xeeeeeeee);
    GetPlayer( )->SetUInt32Value(UNIT_FIELD_AURAFLAGS+4, 0);
    GetPlayer( )->SetUInt32Value(UNIT_FIELD_AURASTATE, 0);

    GetPlayer()->ResurrectPlayer();
    GetPlayer()->GetUInt32Value(UNIT_FIELD_HEALTH) > GetPlayer()->m_resurrectHealth ? GetPlayer()->SetUInt32Value(UNIT_FIELD_HEALTH, GetPlayer()->m_resurrectHealth )
    : GetPlayer()->SetUInt32Value(UNIT_FIELD_HEALTH, GetPlayer()->GetUInt32Value(UNIT_FIELD_HEALTH) );
    GetPlayer()->GetUInt32Value(UNIT_FIELD_POWER1) > GetPlayer()->m_resurrectMana ? GetPlayer()->SetUInt32Value(UNIT_FIELD_POWER1, GetPlayer()->m_resurrectMana )
    : GetPlayer()->SetUInt32Value(UNIT_FIELD_POWER1, GetPlayer()->GetUInt32Value(UNIT_FIELD_POWER1) );
    GetPlayer()->SpawnCorpseBones();

    GetPlayer()->BuildTeleportAckMsg(&data, GetPlayer()->m_resurrectX, GetPlayer()->m_resurrectY, GetPlayer()->m_resurrectZ, GetPlayer()->GetOrientation());
    GetPlayer()->GetSession()->SendPacket(&data);
    GetPlayer()->SetPosition(GetPlayer()->m_resurrectX ,GetPlayer()->m_resurrectY ,GetPlayer()->m_resurrectZ,GetPlayer()->GetOrientation());

    GetPlayer()->m_resurrectGUID = 0;
    GetPlayer()->m_resurrectHealth = GetPlayer()->m_resurrectHealth = 0;
    GetPlayer()->m_resurrectX = GetPlayer()->m_resurrectY = GetPlayer()->m_resurrectZ = 0;
}

void WorldSession::HandleSetAmmoOpcode(WorldPacket & recv_data)
{
    uint32 ammoId;
    recv_data >> ammoId;
    GetPlayer()->SetUInt32Value(PLAYER_AMMO_ID,ammoId);

    return;
}

void WorldSession::HandleUpdateAccountData(WorldPacket &recv_data)
{
	/*
    Log::getSingleton().outDetail("WORLD: Received CMSG_UPDATE_ACCOUNT_DATA");

	uint32 uiID, uiDecompressedSize;
	recv_data >> uiID;
	recv_data >> uiDecompressedSize;

	ByteBuffer buff(uiDecompressedSize);

	int err;
	if ( (err = uncompress(const_cast<uint8*>(buff.contents()), &uiDecompressedSize, const_cast<uint8*>(recv_data.contents()) + 8, (recv_data.size() - 8))) == Z_OK)
	{
		std::stringstream ss;
		ss << "UPDATE accounts SET uiconfig" << uiID << "=\"" << buff.contents() << "\" WHERE acct=" << GetAccountId() << " LIMIT 1";
		sDatabase.Execute(ss.str().c_str());
	}
	*/
}

void WorldSession::HandleRequestAccountData(WorldPacket& recv_data)
{
	// this function should get uiconfigX from mysql table
	// and send it to the client.
	// it works, but it crashes server, dunno why, 
	// here seems all to be fine .. but on exit from funct
	// exception is thrown
    Log::getSingleton().outDetail("WORLD: Received CMSG_REQUEST_ACCOUNT_DATA");

	/*WorldPacket data;

	uint32 id;
	recv_data >> id;
	std::stringstream ss;

	ss << "SELECT uiconfig" << id << " FROM accounts WHERE acct=" << GetAccountId();
	QueryResult *result = sDatabase.Query(ss.str().c_str());
	if (result)
	{
		data.Initialize(SMSG_UPDATE_ACCOUNT_DATA);
		std::string res = result->Fetch()->GetString();
		ByteBuffer buf(res.length());
		buf.append(res.c_str(), res.length());
		uint32 destsize = (uint32)res.length();
		data << destsize;
		int err;
		if ( (err = compress(const_cast<uint8*>(data.contents()) + sizeof(uint32), &destsize, buf.contents(), buf.size())) != Z_OK)
		{
			Log::getSingleton().outDetail("Error while compressing ACCOUNT_DATA");
		}
		else SendPacket(&data);
	}*/
}


void WorldSession::HandleSetActionButtonOpcode(WorldPacket& recv_data)
{
	Log::getSingleton( ).outString( "WORLD: Recieved CMSG_SET_ACTION_BUTTON" ); 
	uint8 button, misc, type; 
    uint16 action; 
    recv_data >> button >> action >> misc >> type; 
	Log::getSingleton( ).outString( "BUTTON: %u ACTION: %u TYPE: %u MISC: %u", button, action, type, misc ); 
    if(action==0)
	{
		Log::getSingleton( ).outString( "MISC: Remove action from button %u", button ); 
		//remove the action button from the db
		GetPlayer()->removeAction(button);
	}
	else
	{ 
		if(type==64) 
		{
			Log::getSingleton( ).outString( "MISC: Added Macro %u into button %u", action, button );
			GetPlayer()->addAction(button,action,misc,type);
		} 
		else if(type==0)
		{
			Log::getSingleton( ).outString( "MISC: Added Action %u into button %u", action, button );
			GetPlayer()->addAction(button,action,type,misc);
		} 
	}
}

void WorldSession::HandleSetAtWarOpcode(WorldPacket& recv_data)
{
    uint32 id;
    uint8 state;
    recv_data >> id >> state;
    GetPlayer()->SetFactionState(id, state == 0 ? uint8(1) : uint8(2));
}

void WorldSession::HandleTogglePVPOpcode(WorldPacket& recv_data)
{
	//Waiting zone reader//look at pvp flags
	if (!GetPlayer()->HasFlag(UNIT_FIELD_FLAGS, U_FIELD_FLAG_PVP))
	{
		GetPlayer()->SetFlag(UNIT_FIELD_FLAGS, U_FIELD_FLAG_PVP);
		//GetPlayer()->m_pvp_timer = 300000;//5 minutes
	}
}

void WorldSession::HandleAmmoSetOpcode(WorldPacket & recv_data)
{
	uint32 ammoId;
    recv_data >> ammoId;
    GetPlayer()->SetUInt32Value(PLAYER_AMMO_ID, ammoId);

    return;
}

void WorldSession::HandleGameObjectUse(WorldPacket & recv_data)
{
    WorldPacket data;
    uint64 guid;
    recv_data >> guid;

	Log::getSingleton( ).outDebug("WORLD: CMSG_GAMEOBJ_USE: [GUID %d]", guid);   

    GameObject *obj = objmgr.GetObject<GameObject>(guid);
	if (!obj) return;

    Player *plyr = GetPlayer();
    if(!plyr)
        return;

    uint32 type = 0;
    type = obj->GetUInt32Value(GAMEOBJECT_TYPE_ID);

    if(type == GAMEOBJECT_TYPE_CHAIR)//chair
    {
            WorldPacket data;
            data.Initialize( MSG_MOVE_HEARTBEAT );

            data << GetPlayer()->GetNewGUID();
            data << uint32(0) << uint32(0);
            data << obj->GetPositionX() << obj->GetPositionY() << obj->GetPositionZ() << obj->GetOrientation();
            plyr->SendMessageToSet(&data, true);
            plyr->SetStandState(STANDSTATE_SIT_MEDIUM_CHAIR);
            return;
    }
  /*  if(type == 3) //|| type == 2 || type == 5)//chest
    {
        plyr->SetLootGUID(guid);
    
	    data.Initialize(SMSG_LOOT_RESPONSE);

	    if( obj->FillLoot(&data,plyr) ) 
		    SendPacket(&data);
        return;
	}*/
}

void WorldSession::HandleTutorialFlag( WorldPacket & recv_data )
{
	uint32 iFlag;
	recv_data >> iFlag;

	uint32 wInt = (iFlag / 32);
	uint32 rInt = (iFlag % 32);

	uint32 tutflag = GetPlayer()->GetTutorialInt( wInt );
	tutflag |= (1 << rInt);
	GetPlayer()->SetTutorialInt( wInt, tutflag );

	sLog.outDebug("Received Tutorial Flag Set {%u}.", iFlag);
}


void WorldSession::HandleTutorialClear( WorldPacket & recv_data )
{
	for ( uint32 iI = 0; iI < 8; iI++)
		GetPlayer()->SetTutorialInt( iI, 0xFFFFFFFF );
}


void WorldSession::HandleTutorialReset( WorldPacket & recv_data )
{
	for ( uint32 iI = 0; iI < 8; iI++)
		GetPlayer()->SetTutorialInt( iI, 0x00000000 );
}
