// (c) AbyssX Group
#if !defined(WORLDPORT_DB_H)
#define WORLDPORT_DB_H

class WorldPort_DB : public Singleton<WorldPort_DB>
{
	public:
		WorldPort_DB();
		~WorldPort_DB();
		bool List();
		bool Add(string,DoubleWord,float,float,float);
		bool Del(string);
		void LoadWP();
		void ParseChat(Player *, Client *, char *);

		Database *db;

		list<WorldPort *> mWorldPorts;
};

#endif