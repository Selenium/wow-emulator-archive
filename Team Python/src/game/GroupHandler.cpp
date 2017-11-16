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

#include "GroupHandler.h"
#include "NetworkInterface.h"
#include "Opcodes.h"
#include "Log.h"
#include "Character.h"
#include "WorldServer.h"
#include "Database.h"
#include <string.h>

GroupHandler::GroupHandler( ) {

}

GroupHandler::~GroupHandler( ) {

}


void GroupHandler::HandleMsg( wowWData & recv_data, GameClient *pClient )
{
    wowWData data;
	char f[256];
    sprintf(f, "WORLD: Group Opcode 0x%.4X", recv_data.opcode);
    Log::getSingleton( ).outString( f );
    switch (recv_data.opcode)
    {
		case CMSG_GROUP_INVITE:
			{
				Group *tempGroup;
				std::string membername;
				recv_data >> membername;
				GameClient * tempClient;
				Character * tempChar;
				tempClient = WorldServer::getSingleton().GetClientByName((char *)membername.c_str());
				if (tempClient == NULL) {
					data.clear();
					data.Initialise(sizeof(uint32) + 1 + strlen(membername.c_str()) + sizeof(uint32),SMSG_PARTY_COMMAND_RESULT);
					data << uint32( 0x0 );
					data.writeData((char *)membername.c_str() , strlen(membername.c_str()) + 1 );
					data << uint32( 0x00000001 );
					pClient->SendMsg( &data );
					break;
				}
				if ((pClient->getCurrentChar()->IsInGroup()) && (strcmp(pClient->getCurrentChar()->GetGroupLeader(),pClient->getCharacterName()) != 0)) {
					data.clear();
					data.Initialise(sizeof(uint32) + 1 + sizeof(uint32),SMSG_PARTY_COMMAND_RESULT);
					data << uint32( 0 ) << uint8( 0 );
					data << uint32( 0x00000006 );
					pClient->SendMsg( &data );			
					break;
				}

				tempGroup = WorldServer::getSingleton().GetGroupByLeader(pClient->getCurrentChar()->GetGroupLeader());
				if (tempGroup != NULL) {
					if (tempGroup->IsFull()) {
						data.Initialise(sizeof(uint32) + 1 + sizeof(uint32),SMSG_PARTY_COMMAND_RESULT);
						data << uint32( 0 ) << uint8( 0 );
						data << uint32( 0x00000003 );
						pClient->SendMsg( &data );
						break;
					}
				}
				tempChar = tempClient->getCurrentChar();
				if (tempChar->IsInGroup()) {
					data.clear();
					data.Initialise(sizeof(uint32) + 1 + strlen(membername.c_str()) + sizeof(uint32),SMSG_PARTY_COMMAND_RESULT);
					data << uint32( 0x0 );
					data.writeData((char *)membername.c_str() , strlen(membername.c_str()) + 1 );
					data << uint32( 0x00000004 );
					pClient->SendMsg( &data );
					break;
				}
				if (tempChar->IsInvited()) {
					break;
				}

				data.Initialise(strlen(pClient->getCharacterName()) + 1, SMSG_GROUP_INVITE);
				data.writeData(pClient->getCharacterName(), strlen(pClient->getCharacterName()) +1);
				if (WorldServer::getSingleton().SendMessageToPlayer(&data, (char *)membername.c_str()) == 0) {
					data.clear();
					data.Initialise(sizeof(uint32) + 1 + strlen(membername.c_str()) + sizeof(uint32),SMSG_PARTY_COMMAND_RESULT);
					data << uint32( 0x0 );
					data.writeData((char *)membername.c_str() , strlen(membername.c_str()) + 1 );
					data << uint32( 0x00000001 );
					
					pClient->SendMsg( &data );
				}
				else {
					data.clear();
					data.Initialise(sizeof(uint32) + 1 + strlen(membername.c_str()) + sizeof(uint32),SMSG_PARTY_COMMAND_RESULT);
					data << uint32( 0x0 );
					data.writeData((char *)membername.c_str() , strlen(membername.c_str()) + 1 );
					data << uint32( 0x00000000 );
					
					pClient->SendMsg( &data );

					tempChar->SetLeader(pClient->getCharacterName());
					tempChar->SetInvited();
				}
			}break;
/*		case CMSG_GROUP_CANCEL:
			{
				


			}break;
*/
		case CMSG_GROUP_ACCEPT:
			{

				
				GameClient * tempClient;
				Character * tempChar;
				Character * CurrentChar;
				CurrentChar = pClient->getCurrentChar();
				tempClient = WorldServer::getSingleton().GetClientByName(CurrentChar->GetGroupLeader());
				if (!tempClient)
					break;
				tempChar = tempClient->getCurrentChar();
				


				if (!CurrentChar->IsInvited()) {
					break;
				}

				CurrentChar->UnSetInvited();

				if ( (tempChar->IsInGroup()) && ( STRCASECMP(tempChar->GetGroupLeader(),tempClient->getCharacterName()) == 0) ) {

					CurrentChar->SetInGroup();
					Group *tempGroup;
					tempGroup = WorldServer::getSingleton().GetGroupByLeader(CurrentChar->GetGroupLeader());
					if (tempGroup != NULL) {
						tempGroup->AddMember(pClient->getCharacterName(), CurrentChar->getGUID(),0);
						tempGroup->SendUpdate();
					}

				}
				else if (!tempChar->IsInGroup()) {
					tempChar->SetInGroup();
					tempChar->SetLeader(tempClient->getCharacterName());
					CurrentChar->SetInGroup();
					//Creating Group
					Group * pTempGroup = new Group;
					pTempGroup->Create(tempClient->getCharacterName(),tempChar->getGUID());
					//adding leader
					pTempGroup->AddMember(tempClient->getCharacterName(), tempChar->getGUID(), 1);					
					//adding our client
					pTempGroup->AddMember(pClient->getCharacterName(), CurrentChar->getGUID(), 0);
					WorldServer::getSingleton().AddGroup(pTempGroup);
					pTempGroup->SendUpdate();
				}
				
			}break;
		case CMSG_GROUP_DECLINE:
			{
				if (!pClient->getCurrentChar()->IsInvited()) {
					break;
				}
				pClient->getCurrentChar()->UnSetInvited();
				data.Initialise(strlen(pClient->getCharacterName()) + 1, SMSG_GROUP_DECLINE);
				data.writeData(pClient->getCharacterName(), strlen(pClient->getCharacterName()) +1);
				WorldServer::getSingleton().SendMessageToPlayer(&data, (char *)pClient->getCurrentChar()->GetGroupLeader());
			}break;
		case CMSG_GROUP_UNINVITE:
			{
				std::string membername;
				GameClient *tempClient;
				Group *tempGroup;
				recv_data >> membername;

				
				tempClient = WorldServer::getSingleton().GetClientByName((char *)membername.c_str());
				if (tempClient == NULL) {
					data.Initialise(sizeof(uint32) + 1 + strlen(membername.c_str()) + sizeof(uint32),SMSG_PARTY_COMMAND_RESULT);
					data << uint32( 0x0 );
					data.writeData((char *)membername.c_str() , strlen(membername.c_str()) + 1 );
					data << uint32( 0x00000001 );
					pClient->SendMsg( &data );
					break;

				}
				if 	((!pClient->getCurrentChar()->IsInGroup()) || (strcmp(pClient->getCurrentChar()->GetGroupLeader(), pClient->getCharacterName()) != 0)) {
					data.Initialise(sizeof(uint32) + 1 + sizeof(uint32),SMSG_PARTY_COMMAND_RESULT);
					data << uint32( 0x0 ) << uint8( 0 );
					data << uint32( 0x00000006 );
					pClient->SendMsg( &data );
					break;
				}


				if 	((!tempClient->getCurrentChar()->IsInGroup()) || (strcmp(tempClient->getCurrentChar()->GetGroupLeader(),pClient->getCurrentChar()->GetGroupLeader()) != 0)) {
					data.Initialise(sizeof(uint32) + 1 + strlen(membername.c_str()) + sizeof(uint32),SMSG_PARTY_COMMAND_RESULT);
					data << uint32( 0x0 );
					data.writeData((char *)membername.c_str() , strlen(membername.c_str()) + 1 );
					data << uint32( 0x00000002 );
					pClient->SendMsg( &data );
					break;
				}
				tempGroup = WorldServer::getSingleton().GetGroupByLeader(pClient->getCurrentChar()->GetGroupLeader());
				if (tempGroup->DelMember((char *)membername.c_str()) > 1) {
					tempGroup->SendUpdate();
				}
				else {
					pClient->getCurrentChar()->UnSetInGroup();
					WorldServer::getSingleton().DelGroup(tempGroup);
					data.Initialise(0,SMSG_GROUP_DESTROYED);
					pClient->SendMsg( &data );
				}
				tempClient->getCurrentChar()->UnSetInGroup();
				data.Initialise(0,SMSG_GROUP_UNINVITE);
				tempClient->SendMsg( &data );
			}break;
//		case CMSG_GROUP_UNINVITE_GUID:
//			{

//			}break;
		case CMSG_GROUP_SET_LEADER:
			{
				std::string membername;
				GameClient *tempClient;
				Group *tempGroup;
				recv_data >> membername;

				tempClient = WorldServer::getSingleton().GetClientByName((char *)membername.c_str());
				if (tempClient == NULL) {
					data.Initialise(sizeof(uint32) + 1 + strlen(membername.c_str()) + sizeof(uint32),SMSG_PARTY_COMMAND_RESULT);
					data << uint32( 0x0 );
					data.writeData((char *)membername.c_str() , strlen(membername.c_str()) + 1 );
					data << uint32( 0x00000001 );
					pClient->SendMsg( &data );
					break;

				}
				if ((!pClient->getCurrentChar()->IsInGroup()) || (strcmp(pClient->getCurrentChar()->GetGroupLeader(), pClient->getCharacterName()) != 0)) {
					//error player is not leader
					break;
				}
				if ((!tempClient->getCurrentChar()->IsInGroup()) || (strcmp(tempClient->getCurrentChar()->GetGroupLeader(),pClient->getCharacterName()) != 0)) {
					//error player not in group
					break;
				}
				tempGroup = WorldServer::getSingleton().GetGroupByLeader(pClient->getCurrentChar()->GetGroupLeader());
				if (tempGroup == NULL) {
					//shouldn't get here
					break;
				}

				tempGroup->ChangeLeader((char *)membername.c_str());

			}break;
		case CMSG_GROUP_DISBAND:
			{
/*				Group *tempGroup;
				if ((!pClient->getCurrentChar()->IsInGroup()) || (strcmp(pClient->getCurrentChar()->GetGroupLeader(), pClient->getCharacterName()) != 0)) {
					//error player is not leader
					break;
				}
				tempGroup = WorldServer::getSingleton().GetGroupByLeader(pClient->getCurrentChar()->GetGroupLeader());
				if (tempGroup == NULL) {
					//shouldn't get here
					break;
				}
				tempGroup->Disband();
				WorldServer::getSingleton().DelGroup(tempGroup);
*/
				if (!pClient->getCurrentChar()->IsInGroup()) {
					//error he's not in a group
					break;
				}
				pClient->getCurrentChar()->UnSetInGroup();
				Group *tempGroup;
				tempGroup = WorldServer::getSingleton().GetGroupByLeader(pClient->getCurrentChar()->GetGroupLeader());
				if (tempGroup->DelMember((char *)pClient->getCharacterName()) > 1) {
					tempGroup->SendUpdate();
				}
				else {
					tempGroup->Disband();
					WorldServer::getSingleton().DelGroup(tempGroup);
					data.Initialise(0,SMSG_GROUP_DESTROYED);
					pClient->SendMsg( &data );
				}
				data.clear();
				data.Initialise(0,SMSG_GROUP_UNINVITE);
				pClient->SendMsg( &data );
			}break;
		case CMSG_LOOT_METHOD:
			{
				uint32 lootmethod;
				uint32 lootmaster;
				Group *tempGroup;
				recv_data >> lootmethod >> lootmaster;
				tempGroup = WorldServer::getSingleton().GetGroupByLeader(pClient->getCurrentChar()->GetGroupLeader());
				if (tempGroup == NULL) {
					//shouldn't get here
					break;
				}
				tempGroup->lootmethod = lootmethod;
				tempGroup->looterguid = lootmaster;
				tempGroup->SendUpdate();
			}break;
	}
}

