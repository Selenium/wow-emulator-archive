#include "HookMgr.h"
#include "Setup.h"


#define AB_MAP 529
#define WSG_MAP 489
#define EOTS_MAP 566
#define AV_MAP 30

class GenericBattleground
{
public:
	static void Initialize();
	static void OnKillPlayer(Player * pPlayer, Player * pVictim);
	static void OnArenaFinish(Player * pPlayer, uint32 type, ArenaTeam * pTeam, bool victory, bool rated);

protected:
	static void GiveBadge(Player * pPlayer);
};

