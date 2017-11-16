#include "StdAfx.h"
#include "../Shared/PacketBuilder.h"

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
/// This function handles CMSG_SKILL_LEVELUP
//////////////////////////////////////////////////////////////

/*void WorldSession::HandleSkillLevelUpOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    uint32 slot, skill_id, amount, current_points, current_skill, points;
    recv_data >> slot >> skill_id >> amount;
    current_points = GetPlayer( )->GetUInt32Value( PLAYER_SKILL_INFO_1_1+slot+1 );
    current_skill = GetPlayer( )->GetUInt32Value( PLAYER_SKILL_INFO_1_1+slot );
    points = GetPlayer( )->GetUInt32Value( PLAYER_CHARACTER_POINTS2 );
    GetPlayer( )->SetUInt32Value( PLAYER_SKILL_INFO_1_1+slot , ( 0x000001a1 ));
    GetPlayer( )->SetUInt32Value( PLAYER_SKILL_INFO_1_1+slot+1 , ( (current_points & 0xffff) + (amount << 16) ) );
    GetPlayer( )->SetUInt32Value( PLAYER_CHARACTER_POINTS2, points-amount );
    GetPlayer( )->UpdateObject( );
}*/

void WorldSession::HandleLearnTalentOpcode( WorldPacket & recv_data )
{
    WorldPacket data;
    uint32 talent_id, requested_rank;
    recv_data >> talent_id >> requested_rank;

    TalentEntry *talentInfo = sTalentStore.LookupEntry( talent_id );
	if (talentInfo == NULL) {
		GetPlayer()->GetSession()->SystemMessage(
			"InternalError: Cannot find talent %d in database!", talent_id);
		return;
	}

    uint32 CurTalentPoints = GetPlayer()->GetUInt32Value(PLAYER_CHARACTER_POINTS1);

    if(CurTalentPoints == 0)
    {
		GetPlayer()->GetSession()->SystemMessage("You do not have enough Talent Points !");
    }
    else
    {
        uint32 spellid = talentInfo->RankID[requested_rank];
		SpellEntry *proto = sSpellStore.LookupEntry(spellid);
		if (proto == NULL) return;

		std::string spellname = proto->Name;

        if( spellid == 0 || requested_rank > 4)
        {
            Log::getSingleton( ).outDetail("Talent: %d Rank: %d = 0", talent_id, requested_rank);
        }
        else
        {
            if(GetPlayer()->AddSpell (spellid))
            {

				data.Initialize (SMSG_LEARNED_SPELL);
				data << spellid;
				GetPlayer()->GetSession()->SendPacket( &data );

				// Not sure if need to display learn animation when spending talents
				Make_SMSG_SPELL_GO (&data, 476, GetPlayer(), GetPlayer());
				GetPlayer()->SendMessageToSet (&data, true);
				
				// Log to screen and server window
				Log::getSingleton( ).outDetail("Talent:: Talent ID: %d Rank: %d Spell: %d", talent_id, requested_rank, spellid);
				//GetPlayer()->GetSession()->SystemMessage("You spent 1 Talent Point in learning Talent: %s , Rank %d", spellname.c_str(), proto->Rank);
				
				// Update Talent Points
				GetPlayer()->SetUInt32Value(PLAYER_CHARACTER_POINTS1, CurTalentPoints - 1);
				GetPlayer()->SaveToDB();
            }
        }
    }
}
