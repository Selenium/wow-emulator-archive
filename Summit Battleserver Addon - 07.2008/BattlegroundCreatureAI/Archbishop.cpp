#include "Setup.h"
#include "Archbishop.h"

ArchbishopAI::ArchbishopAI(Creature* pCreature) : MoonScriptCreatureAI(pCreature)
{
	this->SetAIUpdateFreq(_unit->GetUInt32Value(UNIT_FIELD_BASEATTACKTIME));

	// CC Immunity
	_unit->MechanicsDispels[DISPEL_MECHANIC_CHARM] = 1;
	_unit->MechanicsDispels[DISPEL_MECHANIC_FEAR] = 1;
	_unit->MechanicsDispels[DISPEL_MECHANIC_ROOT] = 1;
	_unit->MechanicsDispels[DISPEL_MECHANIC_SLEEP] = 1;
	_unit->MechanicsDispels[DISPEL_MECHANIC_SNARE] = 1;
	_unit->MechanicsDispels[DISPEL_MECHANIC_STUN] = 1;
	_unit->MechanicsDispels[DISPEL_MECHANIC_KNOCKOUT] = 1;
	_unit->MechanicsDispels[DISPEL_MECHANIC_BLEED] = 1;
	_unit->MechanicsDispels[DISPEL_MECHANIC_POLYMORPH] = 1;
	_unit->MechanicsDispels[DISPEL_MECHANIC_BANISH] = 1;
}

void ArchbishopAI::OnCombatStart(Unit* mTarget)
{
	_unit->SendChatMessage(CHAT_MSG_MONSTER_YELL, LANG_UNIVERSAL, "Back, heathens!");

	MoonScriptCreatureAI::OnCombatStart(mTarget);
}

void ArchbishopAI::OnTargetDied(Unit* mTarget)
{
	_unit->SendChatMessage(CHAT_MSG_MONSTER_YELL, LANG_UNIVERSAL, "The light strikes thee down!");

	MoonScriptCreatureAI::OnTargetDied(mTarget);
}

void ArchbishopAI::AIUpdate()
{
	Creature * pCr = (Creature*)_unit;
	if(pCr && pCr->m_spawn)
	{
		if(_unit->CalcDistance(pCr->m_spawn->x, pCr->m_spawn->y, pCr->m_spawn->z) > 100.0f)
		{
			_unit->SendChatMessage(CHAT_MSG_MONSTER_YELL, LANG_UNIVERSAL, "I won't leave the sanctity of my chapel!");
			_unit->GetAIInterface()->WipeHateList();
		}
	}
	MoonScriptCreatureAI::AIUpdate();
}

void ArchbishopAI::OnDied(Unit* mKiller)
{
	_unit->SendChatMessage(CHAT_MSG_MONSTER_SAY, LANG_UNIVERSAL, "The light... I've failed...");
	MoonScriptCreatureAI::OnDied(mKiller);
}

void SetupArchbishop(ScriptMgr * mgr)
{
	mgr->register_creature_script(420, &ArchbishopAI::Create);
}


