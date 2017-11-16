#include "Setup.h"
#include "Warlock.h"

#define SHADOWBOLT 27209
#define IMMOLATE 27215
#define CORRUPTION 27216
#define CURSEOFAGONY 27218
#define SHADOWSHOCK 24458

WarlockAI::WarlockAI(Creature* pCreature) : MoonScriptCreatureAI(pCreature)
{
	this->SetAIUpdateFreq(1000);

	this->SetAllowMelee(false);

	this->AddSpell(SHADOWBOLT, Target_Current, 50.0f, 3.0f, 1);
	this->AddSpell(IMMOLATE, Target_Current, 20.0f, 2.0f, 10);
	this->AddSpell(CORRUPTION, Target_Current, 20.0f, 2.0f, 30);
	this->AddSpell(CURSEOFAGONY, Target_Current, 20.0f, 0.0f, 30);
	this->AddSpell(SHADOWSHOCK, Target_Current, 20.0f, 0.0f, 10);
}

void SetupWarlock(ScriptMgr * mgr)
{
	mgr->register_creature_script(401, &WarlockAI::Create);
}


