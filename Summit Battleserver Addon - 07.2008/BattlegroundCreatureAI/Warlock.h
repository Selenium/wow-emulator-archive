#include "Setup.h"
#include "Base.h"

class WarlockAI : public MoonScriptCreatureAI
{
public:
	WarlockAI(Creature* pCreature);

	MOONSCRIPT_FACTORY_FUNCTION(WarlockAI, MoonScriptCreatureAI);

};

