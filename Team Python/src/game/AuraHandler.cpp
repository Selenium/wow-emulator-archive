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

#define world WorldServer::getSingleton()


AuraHandler::AuraHandler()
{

}

AuraHandler::~AuraHandler()
{

}

void AuraHandler::HandleMsg( wowWData & recv_data, GameClient *pClient )
{
	wowWData data;
	wowWData data2;
    char f[256];
    sprintf(f, "WORLD: Spell 0x%.4X", recv_data.opcode);
    Log::getSingleton( ).outString( f );
	switch (recv_data.opcode)
	{
	case CMSG_CAST_SPELL:
			{
				uint64 pguid;
				uint32 spell;
				uint16 flags;
				uint8 hitCount ,missCount;
				recv_data >> spell >> flags;
				pguid = (uint64)pClient->getCurrentChar()->getGUID();
				hitCount = missCount = 0;

				SpellInformation spellInfo;
				DatabaseInterface *dbi = Database::getSingleton().createDatabaseInterface(); //get a hook for the DB
				spellInfo = dbi->GetSpellInformation ( spell ); //returns a SpellInformation object/struct
				Database::getSingleton().removeDatabaseInterface( dbi ); //clean up used resources

				if( spellInfo.spell_type == (uint32)AURA) {



				}else if( spellInfo.spell_type == (uint32)SEAL) {



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
		if (!(pUnit->getUpdateValue(UNIT_FIELD_AURALEVELS + i) == 0xeeeeeeee)) {
			found = i;	
		}
	}
	if (found == -1)
		return 0;
	auraValue = pUnit->getUpdateValue(UNIT_FIELD_AURALEVELS + found);

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
