#include "Setup.h"
#include "Base.h"

class ArchbishopAI : public MoonScriptCreatureAI
{
public:
	ArchbishopAI(Creature* pCreature);
	void OnCombatStart(Unit* mTarget);
	void OnDied(Unit* mKiller);
	void OnTargetDied(Unit* mTarget);
	void AIUpdate();

	MOONSCRIPT_FACTORY_FUNCTION(ArchbishopAI, MoonScriptCreatureAI);
};

