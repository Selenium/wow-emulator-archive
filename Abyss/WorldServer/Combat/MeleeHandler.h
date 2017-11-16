// (c) AbyssX Group
#if !defined(MELEEHANDLER_H)
#define MELEEHANDLER_H

#ifdef COMBAT

#include "../WorldEnvironment.h"

class MeleeHandler : public Singleton<MeleeHandler>
{
	public:
		MeleeHandler();
		~MeleeHandler();
		
		DoubleWord DamageCalculation(Player *);
		DoubleWord DamageCalculation(Mob *);
		DoubleWord HandlePackets(Client *, Packet *);
		
		void DoCombat(Player *player, Packet *pack, Mob *monster, Player *victim);
		void PlayerVSMob(Player *,Mob *,DoubleWord);
		void PlayerVSPlayer(Player *, Player *,DoubleWord);
		void MobVSPlayer(Player *,Mob *,DoubleWord);
		void LevelGain(Player *, Mob *);
		void StopAttack(Client *cli, QuadWord GUID1, QuadWord GUID2);

		int MobHP;
		int PlayerHP;
		DoubleWord mPower;
		DoubleWord mRetroPower;
		DoubleWord mMobExperience;
		ObjectUpdate objupd;

		bool PvPSystem;
		
		void HandlerMSG_ATTACKSWING(Client *, Packet *);
		void HandlerMSG_ATTACKSTOP(Client *, Packet *);
};

struct PVM
{
	Player *ply;
	Mob *mob;
};

struct MVP
{
	Player *ply;
	Mob *mob;
};

struct PVP
{
	Player *ply1;
	Player *ply2;
};

#endif

#endif