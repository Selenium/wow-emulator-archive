#include "StdAfx.h"

#include "../Game/Item.h"
#include "../Game/Opcodes.h"
#include "../Game/Unit.h"
#include "../Game/Spell.h"
#include "../Game/ObjectMgr.h"

//-----------------------------------------------------------------------------
// Build info packet to display red text, errcode chosen from EQUIP_ERROR_.... enum
//-----------------------------------------------------------------------------
void Make_INVENTORY_CHANGE_FAILURE (WorldPacket *pkt, uint8 errcode, Item * item1, Item * item2)
{
	pkt->Initialize (SMSG_INVENTORY_CHANGE_FAILURE);

	// We send Required Level for this Err Code
	if (errcode == EQUIP_ERR_YOU_MUST_REACH_LEVEL_N) {
		ItemPrototype *itemProto = objmgr.GetItemPrototype(item1->GetEntry());
		*pkt << errcode;
		*pkt << uint64 (itemProto->RequiredLevel);
		*pkt << uint64(0);
		*pkt << uint8(0);
	}

	*pkt << errcode;
	*pkt << (item1 ? item1->GetGUID() : uint64(0));
	*pkt << (item2 ? item2->GetGUID() : uint64(0));
	*pkt << uint8(0);
}

//-----------------------------------------------------------------------------
// Build packet for spell cast effect
//-----------------------------------------------------------------------------
void Make_SMSG_SPELL_GO (WorldPacket *pkt, uint32 spellId, Unit *caster, Unit *target)
{
	// Start Spell
	pkt->Initialize(SMSG_SPELL_GO);

	*pkt << caster->GetGUID() << caster->GetGUID();
	*pkt << spellId;
	
	*pkt << uint16(0x0101);
	*pkt << caster->GetGUID();
	*pkt << uint8(0);
	*pkt << uint16(0x0002);
	*pkt << caster->GetGUID();


	/*
	*pkt << uint16(0x0100);

	// Spell targets
	*pkt << uint8(1);					// caster
	*pkt << caster->GetGUID();			// caster GUID

	*pkt << uint8(0);					// ??
	*pkt << (uint16)TARGET_FLAG_UNIT;   // targetmask
	*pkt << target->GetGUID();			// target GUID
	*/
}

void Make_CHAR_CREATION_ERROR_CODE (WorldPacket *pkt, uint8 errcode)
{
	pkt->Initialize(SMSG_CHAR_CREATE);
    *pkt << (uint8)errcode;
}
//--- END ---
