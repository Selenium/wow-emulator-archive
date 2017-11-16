#if !defined(POPULATION_H)
#define POPULATION_H


class Population
{
	public:
		Population();
		~Population();
		bool AddStaticDB(string, QuadWord, Player *);
		bool UpdateStaticDB(QuadWord, Mob *);
		bool DelStaticDB(QuadWord);
		bool ListStaticDB();

		Database *pdb;
};

#endif