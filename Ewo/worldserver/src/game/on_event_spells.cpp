// Copyright (C) 2006 Team Evolution
#include "on_event_spells.h"
#include "Character.h"
#include "globals.h"

//!!shield value can be negative too fro persistent shields!!
float	Health_Shield_List::absorb_dmg(float dmg,uint8 dmg_type)
{
	float dmg_remain = dmg;
	uint32 dmg_flag = 1 << dmg_type;
	Health_Shield_Node *kur=first;
	while(kur)
	{
//		if(kur->expires_at<G_cur_time_ms && (kur->dmg_type_flags & dmg_type))
		if(kur->dmg_type_flags & dmg_flag)
		{
			if(kur->flags1 & HEALTH_SHIELD_FLAG_DMG_PRC_RECALC)
				kur->shield_remain = dmg*kur->dmg_pct;
			if(kur->mana_conversion)
			{
				float dmg_can_absorb = owner->power/kur->mana_conversion;
				if(kur->shield_remain < dmg_can_absorb)
					dmg_can_absorb = kur->shield_remain;
				if(dmg_can_absorb<dmg_remain)
				{
					owner->power -= dmg_can_absorb*kur->mana_conversion;
					kur->shield_remain = 0;
					owner->power = 0;
					dmg_remain -= dmg_can_absorb;
					if(!(kur->flags1 & HEALTH_SHIELD_FLAG_PERSISTENT_INSTANT))
					{
						Health_Shield_Node *next=kur->next;
						//remove the shield
						owner->affect_list->del(kur->parent_spell_list_node);
						kur=next;
						continue;
					}
				}
				else
				{
					owner->power -= dmg_remain*kur->mana_conversion;
					kur->shield_remain -= dmg_remain;
					return 0;
				}
			}
			else
			{
				if(dmg_remain<kur->shield_remain)
				{
					if(!(kur->flags1 & HEALTH_SHIELD_FLAG_PERSISTENT_INSTANT))
						kur->shield_remain -= dmg_remain;
					return 0;
				}
				else
				{
					dmg_remain -= kur->shield_remain;
					kur->shield_remain = 0;
					if(!(kur->flags1 & HEALTH_SHIELD_FLAG_PERSISTENT_INSTANT))
					{
						Health_Shield_Node *next=kur->next;
						//remove the shield
						owner->affect_list->del(kur->parent_spell_list_node);
						kur=next;
						continue;
					}
				}
			}
		}
		kur=kur->next;
	}
	return dmg_remain;
}

void On_event_spell_list::trigger_event_spells_char(uint64 suggested_target)
{
	for(uint32 i=0;i<len;i++)
		if(G_random.mt_random() % 100 <= slots[i].spell_cast_chance)
		{
			((Character*)(owner))->instant_spell.char_instant_cast(slots[i].spell_id,suggested_target);
			slots[i].spell_casts_remaining--;
			if(slots[i].spell_casts_remaining==0)
				del(i);
		}
}

void On_event_spell_list::trigger_event_spells_char_on_cast(uint64 suggested_target,uint32 spell_id)
{
	for(uint32 i=0;i<len;i++)
		if(spell_id==slots[i].trigger_on_event_param_only && G_random.mt_random() % 100 <= slots[i].spell_cast_chance)
		{
			((Character*)(owner))->instant_spell.char_instant_cast(slots[i].spell_id,suggested_target);
			slots[i].spell_casts_remaining--;
			if(slots[i].spell_casts_remaining==0)
				del(i);
		}
}


void On_event_spell_list::trigger_event_spells_cr(uint64 suggested_target)
{
	for(uint32 i=0;i<len;i++)
		if(G_random.mt_random() % 100 <= slots[i].spell_cast_chance)
		{
printf("!!!creature is trying to cast an on_struck instant spell on attacker\n");
			G_instant_spell_instance.cr_instant_cast(((creature*)(owner_cr)),slots[i].spell_id,suggested_target);
			slots[i].spell_casts_remaining--;
			if(slots[i].spell_casts_remaining==0)
				del(i);
		}
}

void On_event_spell_list::trigger_event_spells_cr_on_cast(uint64 suggested_target,uint32 spell_id)
{
	for(uint32 i=0;i<len;i++)
		if(G_random.mt_random() % 100 <= slots[i].spell_cast_chance)
		{
			G_instant_spell_instance.cr_instant_cast(((creature*)(owner_cr)),slots[i].spell_id,suggested_target);
			slots[i].spell_casts_remaining--;
			if(slots[i].spell_casts_remaining==0)
				del(i);
		}
}