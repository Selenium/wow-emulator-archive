//////////////////////////////////////////////////////////////////////
//  Gossip Handler
//
//  Handles Gossip related opcodes
//////////////////////////////////////////////////////////////////////

// Copyright (C) 2005 Team WSD
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

#include "Gossip.h"
#include "GossipHandler.h"
#include "GameClient.h"
#include "Opcodes.h"
#include "WorldServer.h"
#include "Character.h"
#include "Database.h"

using namespace std;

#define world WorldServer::getSingleton()

GossipHandler::GossipHandler(){}


GossipHandler::~GossipHandler()
{

	//NPC Text RelationShip
	for( TextRelationMap::iterator i = mTextRelations.begin( ); i != mTextRelations.end( ); ++i )
	{
		delete i->second;
	}
	mTextRelations.clear( );


	//Text Options
	for( TextOptionMap::iterator i = mTextOptions.begin( ); i != mTextOptions.end( ); ++i )
	{
		delete i->second;
	}
	mTextOptions.clear( );


	//NPC Texts
	for( NPCTextMap::iterator i = mNPCTexts.begin( ); i != mNPCTexts.end( ); ++i )
	{
		delete i->second;
	}
	mNPCTexts.clear( );

}


void GossipHandler::HandleMsg( NetworkPacket & recv_data, GameClient *pClient )
{
	NetworkPacket data;
	char f[256];
	sprintf(f, "WORLD: Gossip Opcode 0x%.4X", recv_data.opcode);
	Log::getSingleton( ).outString( f );
	switch (recv_data.opcode)
	{
		case CMSG_GOSSIP_HELLO:
			{
				uint16 tSize,i;
				uint32 TextID;
				guid cguid;
				recv_data >> cguid.sno >> cguid.type;
				TextID = getTextID(cguid.sno);
				if(TextID == 0)
				{
					//text Id 0 don't exist so maybe they don't want to talk :P
					data.Initialize( 8 , SMSG_NPC_WONT_TALK );
					data << cguid.sno << cguid.type;
					pClient->SendMsg (&data);
					break;
				}
				//TextRelation * pRelation = getTextRelation(cguid.sno);
				NPCText * theText = getNPCText(TextID);
				//Calculate the size 
				tSize = 20 + (8*theText->m_OptionCount);
				TextOption * theOption;
				for(i = 1; i <= theText->m_OptionCount;i++)
				{
					// add option textsize to the size
					theOption = getTextOption(theText->m_OptionID[i]);
					tSize += strlen((char *)theOption->m_OptionText.c_str())+1;
				}

				//Create the Packet
				data.Initialize( tSize, SMSG_GOSSIP_MESSAGE );
				data << cguid.sno << cguid.type;
					data << (uint32)TextID; //TextID
				data << (uint32)theText->m_OptionCount; // Bullet Points Count
				for(i = 1; i <= theText->m_OptionCount;i++)
				{
					theOption = getTextOption(theText->m_OptionID[i]);
						data << (uint32)theOption->m_OptionID; //Bullet Point Number
					data << (uint32)theOption->m_OptionIconID; //Bullet Point IconID
					data.WriteData(theOption->m_OptionText.c_str() , strlen((char *)theOption->m_OptionText.c_str())+1 ); //option text
				}
				data << (uint32)0; 
				pClient->SendMsg (&data);

				//pClient->getCurrentChar()->setUpdateValue(CORPSE_FIELD_ITEM3, 6947);
				//pClient->getCurrentChar()->setUpdateValue(CORPSE_FIELD_ITEM4, (uint32)0xf0001000 );
				//pClient->getCurrentChar()->UpdateObject();

			}break;

		case CMSG_GOSSIP_SELECT_OPTION:
			{
				uint32 option;
				guid cguid;
				recv_data >> cguid.sno >> cguid.type;
				recv_data >> option;
				TextOption * theOption;
				theOption = getTextOption(option);

				// Textid of 0 is Reserved for exiting and SH Comfirm
				if(theOption->m_TextID == 0)
				{
					Unit *pSelection = world.GetValidCreature(cguid.sno);
					if(pSelection != 0)
					{
						if(pSelection->getUpdateValue(UNIT_NPC_FLAGS) == 32) //if the selection is a spirit healer
						{
							// Sh Accept Dialog
							data.Initialize(8,SMSG_SPIRIT_HEALER_CONFIRM);
							data << cguid.sno << cguid.type;
							pClient->SendMsg( &data );
						}
					}

					//close the Gossip Window
					data.Initialize(0,SMSG_GOSSIP_COMPLETE);
					pClient->SendMsg( &data );
					break;
				}

				uint16 TextID,tSize,i;
				//get the Text ID
				TextID = theOption->m_TextID;
				//get the Related text info
				NPCText * theText = getNPCText(TextID);
				//calculate our size
				tSize = 20 + (8*theText->m_OptionCount);
				for(i = 1; i <= theText->m_OptionCount;i++)
				{
					//get each options text and add it to the size
					theOption = getTextOption(theText->m_OptionID[i]);
					tSize += strlen((char *)theOption->m_OptionText.c_str())+1;
				}

				//Create the Packet
				data.Initialize( tSize, SMSG_GOSSIP_MESSAGE );
				data << cguid.sno << cguid.type;
					data << (uint32)TextID; //TextID
				data << (uint32)theText->m_OptionCount; // Bullet Points Count
				//Get each option
				for(i = 1; i <= theText->m_OptionCount;i++)
				{
					theOption = getTextOption(theText->m_OptionID[i]);
						data << (uint32)theOption->m_OptionID; //Bullet Point Number
					data << (uint32)theOption->m_OptionIconID; //Bullet Point IconID
					data.WriteData(theOption->m_OptionText.c_str() , strlen((char *)theOption->m_OptionText.c_str())+1 ); //option text
				}
				data << (uint32)0; //Null Terminator
				pClient->SendMsg (&data);
			}break;

		case CMSG_NPC_TEXT_QUERY:
			{
				uint32 textID, tSize;
				recv_data >> textID;

				/* i don't think this is used but if Spirit healers don't work try it :P
				//this is having to do with spirit healers
				uint32 uField0, uField1;
				recv_data >> uField0 >> uField1;

				Unit pSelection = world.GetValidCreature(uField0);
				if(pSelection != 0)
				{
				if(pSelection.getUpdateValue(UNIT_NPC_FLAGS) == 32) //if the selection is a spirit healer
				{
				pClient->getCurrentChar()->setUpdateValue(UNIT_FIELD_TARGET, uField0);
				pClient->getCurrentChar()->setUpdateValue(UNIT_FIELD_TARGET + 1, uField1);
				}
				}
				*/

				//get the text from the text id
				NPCText * theText = getNPCText(textID);
				//calculate hte size
				tSize = strlen((char *)theText->m_Text.c_str())+9;

				//create the packet
				data.Initialize(tSize, SMSG_NPC_TEXT_UPDATE);
				data << textID << (uint32)0x42c80000; //text id and text display fix ??
				data.WriteData((char *)theText->m_Text.c_str(), strlen((char *)theText->m_Text.c_str())+1);
				pClient->SendMsg( &data );
			}break;

		default:
			break;
	}
}
void GossipHandler::addTextRelation(TextRelation * pTextRelation)
{
	mTextRelations[pTextRelation->m_NPCGUID] = pTextRelation;
}

void GossipHandler::addNPCText(NPCText * pNPCText)
{
	mNPCTexts[pNPCText->m_TextID] = pNPCText;
}

void GossipHandler::addTextOption(TextOption * pTextOption)
{
	mTextOptions[pTextOption->m_OptionID] = pTextOption;
}

TextRelation * GossipHandler::getTextRelation(uint32 NPCID)
{
	if( mTextRelations.find( NPCID ) != mTextRelations.end( ) )
		return mTextRelations[NPCID];
	else
		return mTextRelations[1];
}

uint32 GossipHandler::getTextID(uint32 NPCID)
{
	if( mTextRelations.find( NPCID ) != mTextRelations.end( ) )
	{
		TextRelation *pRelation = mTextRelations[NPCID];
		return pRelation->m_TextID;
	}
	else
		return 0;
}

NPCText * GossipHandler::getNPCText(uint32 NPCTextID)
{
	if( mNPCTexts.find( NPCTextID ) != mNPCTexts.end( ) )
		return mNPCTexts[NPCTextID];
	else
		return mNPCTexts[1];
}

TextOption * GossipHandler::getTextOption(uint32 OptionID)
{
	if( mTextOptions.find( OptionID ) != mTextOptions.end( ) )
		return mTextOptions[OptionID];
	else
		return mTextOptions[1];
}
