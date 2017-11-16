#include "GenericBattleground.h"

void SetupGenericBGs()
{
	GenericBattleground::Initialize();
}

void GenericBattleground::Initialize()
{
	CREATE_HOOK(kp1, KillPlayerHook, AB_MAP, &GenericBattleground::OnKillPlayer)
	CREATE_HOOK(kp2, KillPlayerHook, WSG_MAP, &GenericBattleground::OnKillPlayer)
	CREATE_HOOK(kp3, KillPlayerHook, AV_MAP, &GenericBattleground::OnKillPlayer)
	CREATE_HOOK(kp4, KillPlayerHook, EOTS_MAP, &GenericBattleground::OnKillPlayer)
	CREATE_HOOK(af1, ArenaFinishHook, ALL_MAPS, &GenericBattleground::OnArenaFinish)
}

void GenericBattleground::OnArenaFinish(Player * pPlayer, uint32 type, ArenaTeam * pTeam, bool victory, bool rated)
{
	if(!victory)
		return;

	uint32 badges = 1 + type;
	if(rated)
	{
		uint32 r = RandomUInt(100);
		if(r < 15)
		{
			badges = badges * 2;
			pPlayer->BroadcastMessage("You have earned double gold from this rated arena match!");
		}
	}

	pPlayer->BroadcastMessage("Congratulations on your victory. You will receive %u gold.", badges);

	uint32 reward = badges * 10000;
	pPlayer->ModUnsigned32Value(PLAYER_FIELD_COINAGE, reward);
}

void GenericBattleground::OnKillPlayer(Player * pPlayer, Player * pVictim)
{
	if(!pPlayer->GetGroup())
	{
		pPlayer->BroadcastMessage("You've been awarded 1 gold for slaying %s", pVictim->GetName());
		pPlayer->ModUnsigned32Value(PLAYER_FIELD_COINAGE, 10000);
		return;
	}

	std::vector<Player*> GroupMembers;
	std::set<Player*> PotentialHealers;
	pPlayer->GetGroup()->Lock();
	for(uint8 i = 0; i < pPlayer->GetGroup()->GetSubGroupCount(); i++)
	{
		SubGroup * pSubGroup = pPlayer->GetGroup()->GetSubGroup(i);
		if(!pSubGroup) continue;

		GroupMembersSet::iterator itr = pSubGroup->GetGroupMembersBegin();
		for(; itr != pSubGroup->GetGroupMembersEnd(); itr++)
		{
			PlayerInfo * pi = *itr;
			if(!pi) continue;

			Player * tPlr = pi->m_loggedInPlayer;
			if(!tPlr) 
				continue;

			// Ineligible due to distance.
			if(tPlr->GetDistance2dSq(pPlayer) > 80.0f && tPlr != pPlayer)
				continue;

			// Ineligible due to lack of damage.
			if(!tPlr->CombatStatus.DidDamageTo(pVictim->GetGUID()))
			{
				PotentialHealers.insert(tPlr);
				continue;
			}
			
			GroupMembers.push_back(pi->m_loggedInPlayer);
		}
	}

	// Loop over it again for the healers.
	for(std::set<Player*>::iterator itr2 = PotentialHealers.begin(); itr2 != PotentialHealers.end(); itr2++)
	{
		Player * pHealer = (*itr2);
		if(!pHealer) continue;

		// Giant waste of CPU power inc
		for(std::vector<Player*>::iterator itr3 = GroupMembers.begin(); itr3 != GroupMembers.end(); itr3++)
		{
			Player * pGroupMember = (*itr3);
			if(pHealer->CombatStatus.DidHeal(pGroupMember->GetLowGUID()))
			{
				GroupMembers.push_back(pHealer);
				break;
			}
		}
	}

	// Pick a number, any number!
	if(GroupMembers.size() > 0)
	{
		uint32 reward = RandomUInt(GroupMembers.size() - 1);
		GroupMembers[reward]->ModUnsigned32Value(PLAYER_FIELD_COINAGE, 10000);
		GroupMembers[reward]->BroadcastMessage("You've been awarded 1 gold for slaying %s.", pVictim->GetName());
	}
	pPlayer->GetGroup()->Unlock();
}

void GenericBattleground::GiveBadge(Player * pPlayer)
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

