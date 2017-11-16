#if !defined(MOB_DB_H)
#define MOB_DB_H

class MobDB
{
	public:
		MobDB();
		~MobDB();
		bool AddMDB(string, DoubleWord);
		bool DelMDB(DoubleWord);
		bool ListMDB();
		bool FindMDB(DoubleWord);

		Database *mdb;
};

#endif
