#include "Setup.h"

bool HandleMountSpells(Player * pPlayer, SpellEntry * pSpell)
{
	uint32 allowedSpells[] = { 42777, 43688, 17481, 36702, 41252, 24242, 24252 };
	for(uint32 i = 0; i < 8; i++)
	{
		if(pSpell->Id == allowedSpells[i])
		{
			// Arena Teams. ;>
			for(uint32 x = 0; x < 3; x++)
			{
				ArenaTeam * at = pPlayer->m_playerInfo->arenaTeam[x];
				if(!at) continue;

				if(at->m_stat_ranking <= 10)
					return true;
			}
			return false;
		}
	}

	return true;
}

void SetupMounts()
{
	CREATE_HOOK(cs1, CastSpellHook, 0xFFFFFFFF, &HandleMountSpells)
}