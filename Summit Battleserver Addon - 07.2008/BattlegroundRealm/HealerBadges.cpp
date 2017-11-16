#include "Setup.h"

void GiveBadge(Player * pPlayer)
{
	uint32 item_count = 1;
	Item *pReward;
	SlotResult res;
	if( ( pReward = pPlayer->GetItemInterface()->FindItemLessMax(29434, item_count, false) ) == NULL )
	{
		res = pPlayer->GetItemInterface()->FindFreeInventorySlot( ItemPrototypeStorage.LookupEntry(29434) );
		if( !res.Result )
		{
			pPlayer->BroadcastMessage("Could not add badge. Make sure you have room in your inventory.");
			return;
		}

		pReward = objmgr.CreateItem(29434, pPlayer);
		pReward->SetUInt32Value(ITEM_FIELD_STACK_COUNT, item_count);
		pReward->m_isDirty = true;
		if( !pPlayer->GetItemInterface()->SafeAddItem(pReward, res.ContainerSlot, res.Slot) )
		{
			if( !pPlayer->GetItemInterface()->AddItemToFreeSlot(pReward) )
				delete pReward;
		}
		pPlayer->GetSession()->SendItemPushResult(pReward,true,false,true,false,res.ContainerSlot,res.Slot, item_count);
	}
	else
	{
		pReward->m_isDirty = true;
		pReward->ModUnsigned32Value(ITEM_FIELD_STACK_COUNT, item_count);

		res.ContainerSlot = pPlayer->GetItemInterface()->GetBagSlotByGuid(pReward->GetGUID());
		res.Slot = -1;
		pPlayer->GetSession()->SendItemPushResult(pReward,true,false,true,true,res.ContainerSlot,res.Slot, item_count);
	}	
}

void HandleHealingSpells(Player * pPlayer, SpellEntry * pSpell, Unit * pTarget)
{
	if(!pTarget) return;

	// Hey, he's healing in a BG!
	if(pSpell->c_is_flags & SPELL_FLAG_IS_HEALING)
	{
		if(pPlayer->m_bg && pPlayer->m_bg->IsArena())
			return;

		if(!pPlayer->m_bg && pPlayer->GetMapId() != 30)
			return;


		// Ok, let's setup this chance system.
		uint32 Chance = 5;
		SpellCastTime *sd = dbcSpellCastTime.LookupEntry(pSpell->CastingTimeIndex);
		if(sd && sd->CastTime == 0) // Instant casts
		{
			Chance = 2;
		}

		if(pPlayer == (Player*)pTarget || pTarget->GetHealthPct() >= 95)
			return;

		// rewards!
		if(Rand(Chance))
		{
			pPlayer->BroadcastMessage( "You are being awarded one gold for your assistance in healing.",  EVENT_UNK, 5000, 1, 0);
			pPlayer->ModUnsigned32Value(PLAYER_FIELD_COINAGE, 10000);
		}
		return;
	}
}

void SetupHealerBadges()
{
	CREATE_HOOK(psh, PostSpellCastHook, 0xFFFFFFFF, &HandleHealingSpells)
}


