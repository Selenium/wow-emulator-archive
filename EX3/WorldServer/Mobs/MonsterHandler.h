#if !defined(MONSTERHANDLER_H)
#define MONSTERHANDLER_H

#ifdef MOBS

class MonsterHandler : public Singleton<MonsterHandler>
{
	public:
		MonsterHandler();
		~MonsterHandler();

		ObjectManager<Mob *> mMobs;

		DoubleWord HandlePackets(Client *, Packet *);

		void MobInRange(Client *cli, Mob *mob);
		void MobOutOfRange(Client *cli, Mob *mob);
		void SpawnMob(char *info, Player *ply);
		void MonsterSpawned(Mob *, Player *, bool);
		void RemoveMonster(QuadWord, Player *);
		Mob *FindMob(QuadWord);
		Mob *FindMob(DoubleWord);
		Mob *FindMob(const char *);

		Float DistBetween(Player *, Mob *);
		void RespawnMob(Mob *);

		void LoadMobs();

		MobDB Mob_DB;
		Population POP;

		void HandlerMSG_CREATURE_QUERY(Client *, Packet *);

		void UpdateRegion(Mob *mob);
};

#endif

#endif