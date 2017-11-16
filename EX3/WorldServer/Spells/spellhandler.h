// (c) AbyssX Group
#if !defined(SPELLS_H)
#define SPELLS_H

#ifdef SPELLS

#include "../WorldEnvironment.h"

class Spells : public Singleton<Spells>
{
	public:
		Spells();
		~Spells();

		list<Spell *> mSpells;

		void LoadBasicSpells();
		void CastSpell(Player *, QuadWord TargetGUID, Spell *);
		Spell *FindSpell(DoubleWord);
		DoubleWord HandlePackets(Client *, Packet *);
		void HandlerMSG_CAST_SPELL(Client *, Packet *);
};

#endif

#endif