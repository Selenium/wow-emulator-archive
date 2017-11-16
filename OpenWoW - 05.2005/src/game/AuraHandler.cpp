//////////////////////////////////////////////////////////////////////
//  Aura Handler
//  
//  Addon to SpellHandler handles Auras and Seals
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

#include "SpellHandler.h"
#include "NetworkInterface.h"
#include "Opcodes.h"
#include "Log.h"
#include "Character.h"
#include "WorldServer.h"
#include "Database.h"
#include "UpdateMask.h"
#include "Unit.h"
#include "Spell.h"
#include "Character.h"
#include "math.h"
#include "AuraHandler.h"

AuraHandler::AuraHandler()
{
}

AuraHandler::~AuraHandler()
{
}

void AuraHandler::HandleMsg( NetworkPacket & recv_data, GameClient *pClient )
{
	NetworkPacket data;
	NetworkPacket data2;
	char f[256];
	sprintf(f, "WORLD: Spell 0x%.4X", recv_data.opcode);
	LOG.outString( f );
	switch (recv_data.opcode)
	{
	case CMSG_CAST_SPELL:
		{
			guid pguid;
			uint32 spell;
			uint16 flags;
			uint8 hitCount, missCount;
			recv_data >> spell >> flags;
			pguid = pClient->getCurrentChar()->getGUID();
			hitCount = missCount = 0;

			SpellInformation spellInfo;
			//get a hook for the DB
			DatabaseInterface *dbi = DATABASE.createDatabaseInterface();
			//returns a SpellInformation object/struct
			spellInfo = dbi->GetSpellInformation ( spell );
			//clean up used resources
			DATABASE.removeDatabaseInterface( dbi );

			if( spellInfo.spell_type == (uint32)AURA) {
			}
			else if( spellInfo.spell_type == (uint32)SEAL) {
			}
		}
	}
}

int AuraHandler::setAura(Unit *pUnit, uint32 spell)
{
    //return 1;  // test
	uint8 tmpStore = 0x00;
	int found = -1,found2 = -1;
	uint32 auraValue;
	int i;
	for( i = 0; (i < 10) && (found == -1); i++) {
		if (!(pUnit->getUpdateValue(static_cast<uint16>(UNIT_FIELD_AURALEVELS + i)) == 0xeeeeeeee)) {
			found = i;	
		}
	}
	if (found == -1)
		return 0;
	auraValue = pUnit->getUpdateValue(static_cast<uint16>(UNIT_FIELD_AURALEVELS + found));

	for( i = 0; (i < 4) && (found2 == -1); i++)
	{
		if ((uint8)*(&auraValue + i) != 0xee) {
			found2 = i;
			memcpy(&auraValue + i,&tmpStore,1);
		}
	}
	pUnit->setUpdateValue(UNIT_FIELD_AURALEVELS + found, auraValue);
	pUnit->setUpdateValue(UNIT_FIELD_AURAAPPLICATIONS + found, auraValue);
	pUnit->setUpdateValue(UNIT_FIELD_AURA + found*4 + found2, uint32(spell));
	pUnit->m_aura_found = found;
	pUnit->m_aura_found2 = found2;
	return 1;
}
