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

#include "SkillHandler.h"
#include "NetworkInterface.h"
#include "Opcodes.h"
#include "Log.h"
#include "Character.h"
#include "WorldServer.h"
#include "Database.h"
#include "UpdateMask.h"

#define world WorldServer::getSingleton()

SkillHandler::SkillHandler()
{

}

SkillHandler::~SkillHandler()
{

}

void SkillHandler::HandleMsg( wowWData & recv_data, GameClient *pClient ) 
{ 
   wowWData data; 
    char f[256]; 
    sprintf(f, "WORLD: Skill/Talent Opcode: 0x%.4X", recv_data.opcode); 
    Log::getSingleton( ).outString( f ); 
   switch (recv_data.opcode) 
   { 
    case CMSG_LEARN_TALENT: 
      { 
         //TODO: Add required points in tree 
         TALENT *Talents =  WorldServer::getSingleton().GetTalentDatabase(); 
         uint32 talent_id, requested_rank;       
         uint32 length; 
         recv_data >> talent_id >> requested_rank; 
          
         uint32 CorrectPoints =  pClient->getCurrentChar()->getUpdateValue(PLAYER_CHARACTER_POINTS1); 

         if(CorrectPoints == 0) 
         { 
            //NO POINTS 
         } 
         else 
         { 
            if(Talents[talent_id].Spell[requested_rank]==0 || requested_rank > 4) 
            { 
               printf("Talent: %d Rank: %d = 0\n", talent_id, requested_rank); 
            } 
            else 
            { 
               //Send data if all OK 
               length = 4; 
               data.Initialise(length, SMSG_LEARNED_SPELL); 
               printf("TalentID: %d Rank: %d Spell: %d\n", talent_id, requested_rank, Talents[talent_id].Spell[requested_rank]); 
               data << Talents[talent_id].Spell[requested_rank]; 
               pClient->SendMsg(&data); 
               data.clear(); 

               //check if rank is > 0 then send REMOVE SPELL 
               if(requested_rank > 0) 
               { 
                  length = 2; 
                  data.Initialise(length, SMSG_REMOVED_SPELL); 
                  data << uint16(Talents[talent_id].Spell[requested_rank-1]); 
                  pClient->SendMsg(&data); 
                  data.clear(); 
               } 
               //UPDATE OBJECT 
               pClient->getCurrentChar()->setUpdateValue(PLAYER_CHARACTER_POINTS1, pClient->getCurrentChar()->getUpdateValue(PLAYER_CHARACTER_POINTS1) - 1); 
            } 
          
         } 
      }break; 
      default: {}break; 
    } 
    
} 