//////////////////////////////////////////////////////////////////////
//  Skill Handler
//
//  Receives all messages with Skill management opcodes
//////////////////////////////////////////////////////////////////////

// Copyright (C) 2004 Team Python
// Copyright (C) 2004, 2005 Team WSD
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

#include "SkillHandler.h"
#include "NetworkInterface.h"
#include "Opcodes.h"
#include "Log.h"
#include "Character.h"
#include "WorldServer.h"
#include "Database.h"
#include "UpdateMask.h"

SkillHandler::SkillHandler()
{

}

SkillHandler::~SkillHandler()
{

}

void SkillHandler::HandleMsg( NetworkPacket & recv_data, GameClient *pClient )
{
	NetworkPacket data;
    char f[256];
    sprintf(f, "WORLD: Skill/Talent Opcode: 0x%.4X", recv_data.opcode);
    LOG.outString( f );
	switch (recv_data.opcode)
	{
    case CMSG_LEARN_TALENT:
		{
			//TODO: Add required points in tree
			TALENT **Talents =  WORLDSERVER.GetTalentDatabase();
			uint32 talent_id, requested_rank;		
			uint32 length;
			recv_data >> talent_id >> requested_rank;
			
			uint32 Class = pClient->getCurrentChar()->getClass();
			uint32 CorrectPoints =  pClient->getCurrentChar()->getUpdateValue(PLAYER_CHARACTER_POINTS1);

			if(CorrectPoints == 0)
			{
				//NO POINTS
			}
			else
			{
				if (requested_rank >= Talents[talent_id][Class].MaxRank)
				{
					 //Max Allowed rank Reached, do nothing
				}
				else
				{
					//Send data if all OK
					length = 4;
					data.Initialize(length, SMSG_LEARNED_SPELL);
					data << Talents[talent_id][Class].Ranks[requested_rank].Byte1;
					data << Talents[talent_id][Class].Ranks[requested_rank].Byte2; 
					data << Talents[talent_id][Class].Ranks[requested_rank].Byte3; 
					data << Talents[talent_id][Class].Ranks[requested_rank].Byte4;
					pClient->SendMsg(&data);
					data.Clear();

					//check if rank is > 0 the  send REMOVE SPELL
					if(requested_rank > 0)
					{
						length = 2;
						data.Initialize(length, SMSG_REMOVED_SPELL);
						data << uint8(Talents[talent_id][Class].Ranks[requested_rank-1].Byte1);
						data << uint8(Talents[talent_id][Class].Ranks[requested_rank-1].Byte2); 
						pClient->SendMsg(&data);
						data.Clear();
					}
					//UPDATE OBJECT
					pClient->getCurrentChar()->setUpdateValue(PLAYER_CHARACTER_POINTS1, pClient->getCurrentChar()->getUpdateValue(PLAYER_CHARACTER_POINTS1) - 1);
				}
			
			}
		}break;
		default: {}break;
    }
	
}

