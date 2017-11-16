// Copyright (C) 2004 Team Python
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

#include "ObjectMgr.h"
#include "UpdateMask.h"
#include "WorldServer.h"
#include "Character.h"
#include "Item.h"


//=====================================================================================================================
//  Build and Send Create Player -- Builds and sends all the messages required to Create a player and his items
//
//  pNewChar - Object to use for creation
//  createflag - 1 for current client's player, 0 for another player
//  pReceiver - the character to receive this create message.  If null, send to pNewChar
//=====================================================================================================================
void ObjectMgr::BuildAndSendCreatePlayer(Character *pNewChar, uint32 createflag, Character *pReceiver)
{
    if (!pReceiver) pReceiver = pNewChar;

    std::list<wowWData*> msglist;
    BuildCreatePlayerMsg(pNewChar, &msglist, createflag);

    std::list<wowWData*>::iterator msgitr;
    for (msgitr = msglist.begin(); msgitr != msglist.end(); )
    {
        wowWData *msg = (*msgitr);
        pReceiver->pClient->SendMsg(msg);
        delete msg;
        msgitr = msglist.erase(msgitr);
    }
}

//===================================================================================================================
//  Build Create Player Msg -- Builds a list of messages required to create a player and his items
//  msglist - The std::list of wowWData message
//===================================================================================================================
void ObjectMgr::BuildCreatePlayerMsg(Character *pNewChar, std::list<wowWData*>* msglist, uint32 createflag)
{
    uint16 i=0, invcount=0, maxslots=46, invslots=23;
    UpdateMask playerMask, invUpdateMask;

    SetCreatePlayerBits(&playerMask);

    if (createflag == 1)
    {  
        invslots = 39;
        maxslots = 78;
	    pNewChar->setQuestLogBits(&playerMask);
    }

	for(i = 0; i<maxslots; i+=2)
	{
		if (pNewChar->getGuidBySlot(i/2) != 0) {
			pNewChar->setUpdateValue( PLAYER_FIELD_INV_SLOT_HEAD + i , pNewChar->getGuidBySlot(i/2),  playerMask.updateMask);
			pNewChar->setUpdateValue( PLAYER_FIELD_INV_SLOT_HEAD + i + 1 , 0x00000040,  playerMask.updateMask);
		}
	}

    // Create Item for this player
    for(invcount = 0; invcount < invslots; invcount++)
	{
		if ((pNewChar->getGuidBySlot(invcount) != 0) && (pNewChar->getGuidBySlot(invcount) != 0)){

			invUpdateMask.clear();
			invUpdateMask.setCount(0x02);
			Item* tempitem = new Item;
            wowWData *itemdata = new wowWData;

			invUpdateMask.setBit( OBJECT_FIELD_GUID );
			invUpdateMask.setBit( OBJECT_FIELD_GUID+1 );
			invUpdateMask.setBit( OBJECT_FIELD_TYPE );
			invUpdateMask.setBit( OBJECT_FIELD_ENTRY );
			invUpdateMask.setBit( OBJECT_FIELD_SCALE_X );
			invUpdateMask.setBit( OBJECT_FIELD_PADDING );
			invUpdateMask.setBit( ITEM_FIELD_OWNER );
			invUpdateMask.setBit( ITEM_FIELD_CONTAINED );
			invUpdateMask.setBit( ITEM_FIELD_OWNER +1 );
			invUpdateMask.setBit( ITEM_FIELD_CONTAINED +1 );
			invUpdateMask.setBit( ITEM_FIELD_STACK_COUNT );
			tempitem->Create(pNewChar->getGuidBySlot(invcount),pNewChar->getItemIdBySlot(invcount));
			tempitem->setUpdateValue( OBJECT_FIELD_GUID , pNewChar->getGuidBySlot(invcount) ,invUpdateMask.updateMask);
			tempitem->setUpdateValue( OBJECT_FIELD_GUID+1 , 0x00000040 ,invUpdateMask.updateMask);
			tempitem->setUpdateValue( OBJECT_FIELD_TYPE , 0x00000003 ,invUpdateMask.updateMask);
			tempitem->setUpdateValue( OBJECT_FIELD_ENTRY , pNewChar->getItemIdBySlot(invcount) ,invUpdateMask.updateMask);
			tempitem->setUpdateFloatValue( OBJECT_FIELD_SCALE_X , 1.0f ,invUpdateMask.updateMask);
			tempitem->setUpdateValue( OBJECT_FIELD_PADDING , 0xeeeeeeee ,invUpdateMask.updateMask);
			tempitem->setUpdateValue( ITEM_FIELD_OWNER , pNewChar->getGUID() ,invUpdateMask.updateMask);
			tempitem->setUpdateValue( ITEM_FIELD_CONTAINED , pNewChar->getGUID() ,invUpdateMask.updateMask);
			tempitem->setUpdateValue( ITEM_FIELD_OWNER +1 , 0 ,invUpdateMask.updateMask);
			tempitem->setUpdateValue( ITEM_FIELD_CONTAINED +1 , 0 ,invUpdateMask.updateMask);
			tempitem->setUpdateValue( ITEM_FIELD_STACK_COUNT , 1 ,invUpdateMask.updateMask);

			tempitem->CreateObject(&invUpdateMask, itemdata, 0);
            msglist->push_front(itemdata);
			delete tempitem;
		}
	}

    wowWData *data = new wowWData;
    pNewChar->CreateObject(&playerMask, data, createflag);
    msglist->push_front(data);
}

//===================================================================================================================
//  Set Create Player Bits -- Sets bits required for creating a player in the updateMask.
//  Note:  Doesn't set Quest or Inventory bits
//  updateMask - the updatemask to hold the set bits
//===================================================================================================================
void ObjectMgr::SetCreatePlayerBits(UpdateMask *updateMask)
{
    // Set update mask for player creation
    updateMask->setCount(PLAYER_BLOCKS);
    updateMask->setBit(OBJECT_FIELD_GUID);          
    updateMask->setBit(OBJECT_FIELD_TYPE);
    updateMask->setBit(OBJECT_FIELD_SCALE_X);         
    updateMask->setBit(OBJECT_FIELD_PADDING);
    updateMask->setBit(UNIT_FIELD_HEALTH ); 
    updateMask->setBit(UNIT_FIELD_POWER1  );        
    updateMask->setBit(UNIT_FIELD_POWER2  );
    updateMask->setBit(UNIT_FIELD_POWER3  );        
    updateMask->setBit(UNIT_FIELD_POWER4 );
    updateMask->setBit(UNIT_FIELD_MAXHEALTH  );
    updateMask->setBit(UNIT_FIELD_MAXPOWER1  );        
    updateMask->setBit(UNIT_FIELD_MAXPOWER2  );
    updateMask->setBit(UNIT_FIELD_MAXPOWER3  );        
    updateMask->setBit(UNIT_FIELD_MAXPOWER4 );
    updateMask->setBit(UNIT_FIELD_LEVEL  );            
    updateMask->setBit(UNIT_FIELD_FACTIONTEMPLATE  );
    updateMask->setBit(UNIT_FIELD_BYTES_0 );          
    updateMask->setBit(UNIT_FIELD_FLAGS  );
    updateMask->setBit(UNIT_FIELD_BASEATTACKTIME );   
    updateMask->setBit(UNIT_FIELD_BASEATTACKTIME+1  );
    updateMask->setBit(UNIT_FIELD_BOUNDINGRADIUS );  
    updateMask->setBit(UNIT_FIELD_COMBATREACH   );
    updateMask->setBit(UNIT_FIELD_DISPLAYID  );       
	updateMask->setBit(UNIT_FIELD_NATIVEDISPLAYID  ); // NISHAVEN
    updateMask->setBit(UNIT_FIELD_MINDAMAGE);
    updateMask->setBit(UNIT_FIELD_MAXDAMAGE );
    updateMask->setBit(UNIT_FIELD_BYTES_1 );  
    updateMask->setBit(UNIT_FIELD_MOUNTDISPLAYID);
    updateMask->setBit(UNIT_FIELD_STAT0  );
    updateMask->setBit(UNIT_FIELD_STAT1 );            
    updateMask->setBit(UNIT_FIELD_STAT2 );
    updateMask->setBit(UNIT_FIELD_STAT3  );            
    updateMask->setBit(UNIT_FIELD_STAT4  );	
    updateMask->setBit(PLAYER_BYTES);
    updateMask->setBit(PLAYER_BYTES_2 );
    updateMask->setBit(PLAYER_BYTES_3 );
    updateMask->setBit(PLAYER_XP );                 
    updateMask->setBit(PLAYER_NEXT_LEVEL_XP);
    updateMask->setBit(PLAYER_REST_STATE_EXPERIENCE );         
    updateMask->setBit(PLAYER_FIELD_COINAGE  );	
    updateMask->setBit(PLAYER_FIELD_POSSTAT0  );        
    updateMask->setBit(PLAYER_FIELD_POSSTAT1 );
    updateMask->setBit(PLAYER_FIELD_POSSTAT2 );        
    updateMask->setBit(PLAYER_FIELD_POSSTAT3 );
    updateMask->setBit(PLAYER_FIELD_POSSTAT4 );        
    updateMask->setBit(PLAYER_FIELD_NEGSTAT0 );        
    updateMask->setBit(PLAYER_FIELD_NEGSTAT1 );
    updateMask->setBit(PLAYER_FIELD_NEGSTAT2 );        
    updateMask->setBit(PLAYER_FIELD_NEGSTAT3 );
    updateMask->setBit(PLAYER_FIELD_NEGSTAT4 );            
    updateMask->setBit(UNIT_FIELD_ATTACKPOWER );
//    updateMask->setBit(PLAYER_FIELD_ATTACKPOWERMODPOS );
//    updateMask->setBit(PLAYER_FIELD_ATTACKPOWERMODNEG );
}


void ObjectMgr::SetCreateUnitBits(UpdateMask &npcMask)
{
    npcMask.setCount(UNIT_BLOCKS);
    npcMask.setBit(OBJECT_FIELD_GUID);   
    npcMask.setBit(OBJECT_FIELD_GUID+1);
    npcMask.setBit(OBJECT_FIELD_TYPE);   
    npcMask.setBit(OBJECT_FIELD_ENTRY);
    npcMask.setBit(OBJECT_FIELD_SCALE_X);
    npcMask.setBit(UNIT_FIELD_HEALTH);
    npcMask.setBit(UNIT_FIELD_MAXHEALTH );
    npcMask.setBit(UNIT_FIELD_LEVEL );
    npcMask.setBit(UNIT_FIELD_FACTIONTEMPLATE );
    npcMask.setBit(UNIT_FIELD_FLAGS  );
    npcMask.setBit(UNIT_FIELD_DISPLAYID );
    npcMask.setBit(UNIT_FIELD_MOUNTDISPLAYID );
    npcMask.setBit(UNIT_NPC_FLAGS );
    npcMask.setBit(UNIT_FIELD_COMBATREACH );
    npcMask.setBit(UNIT_FIELD_MAXDAMAGE  );
    npcMask.setBit(UNIT_FIELD_MINDAMAGE );
    npcMask.setBit(UNIT_FIELD_BASEATTACKTIME);
    npcMask.setBit(UNIT_FIELD_BASEATTACKTIME+1);
    npcMask.setBit(UNIT_FIELD_BOUNDINGRADIUS);
}

void ObjectMgr::BuildCreateUnitMsg(Unit *pNewUnit, wowWData *data, Character *pPlayer)
{
    UpdateMask unitMask;
    if (!pNewUnit->isDead())
    {
        SetCreateUnitBits(unitMask);
        if (pNewUnit->CheckQuestgiverFlag(pPlayer, &unitMask, data) == 1)  return;
        pNewUnit->CreateObject(&unitMask, data, 0);
    }
}
