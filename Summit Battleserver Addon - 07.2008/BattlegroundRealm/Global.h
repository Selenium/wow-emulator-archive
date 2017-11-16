#include "Setup.h"

class Global
{
public:
	static void Initialize();
	static void OnFirstEnterWorld(Player * pPlayer);
	static void EnterWorld(Player * pPlayer);
	static void OnRepopHorde(Player * pPlayer);
	static void OnRepopAlliance(Player * pPlayer);
	static void FixWorld(Player * pPlayer);
};
