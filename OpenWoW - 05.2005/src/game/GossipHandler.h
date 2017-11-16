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

#ifndef WOWPYTHONSERVER_GOSSIPHANDLER_H
#define WOWPYTHONSERVER_GOSSIPHANDLER_H

#include "MsgHandler.h"

class TextRelation;
class TextOption;
class NPCText;
class GossipHandler : public MsgHandler
{
	public:
		GossipHandler();
		~GossipHandler();

		void HandleMsg( NetworkPacket & recv_data, GameClient *pClient );
		void addTextRelation( TextRelation *pTextRelation );
		void addNPCText( NPCText * pNPCText );
		void addTextOption( TextOption * pTextOption );
		TextRelation * getTextRelation( uint32 NPCID );
		uint32 getTextID(uint32 NPCID);
		NPCText * getNPCText( uint32 NPCTextID );
		TextOption * getTextOption( uint32 OptionID );

	protected:
		// Gossip data 
		//NPC Text RelationShip
		typedef std::map<uint32, TextRelation*> TextRelationMap;
		TextRelationMap mTextRelations;

		//Text Options
		typedef std::map<uint32, TextOption*> TextOptionMap;
		TextOptionMap mTextOptions;

		//NPC Texts
		typedef std::map<uint32, NPCText*> NPCTextMap;
		NPCTextMap mNPCTexts;
};


#endif

