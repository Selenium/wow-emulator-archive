#include "Client.h"
#include "Packets.h"
#include "GameMechanics.h"
#include "Globals.h"
#include "Spell.h"
long StartRaceStats_2[9][5]={
	{0,0,0,0,0}, //blank
	{20,20,20,20,21}, //human
	{23,17,22,17,23}, //orc
	{22,16,23,19,19}, //dwarf
	{17,25,19,20,20}, //nightelf
	{19,18,21,18,25}, //undead
	{25,15,22,15,22}, //tauren
	{15,23,19,24,20}, //gnome
	{21,22,21,16,21} //troll
};
long StartClassStats_2[12][7]={
	{0,0,0,0,0,0,0}, //blank
	{3,0,2,0,0,80,0}, //warrior
	{2,0,2,0,2,70,80}, //paladin
	{0,3,1,0,2,46,85}, //hunter
	{1,3,1,0,1,45,0}, //rogue
	{0,0,0,2,4,30,100}, //priest
	{0,0,0,0,0,0,0}, //blank
	{1,0,1,1,3,50,75}, //shaman
	{0,0,0,3,3,30,100}, //mage
	{0,0,1,2,3,60,110}, //warlock
	{0,0,0,0,0,0,0}, //blank
	{1,0,0,2,3,54,70} //druid
};

void GameMechanics::RageForGettingHit(CPlayer *pPlayer, CWoWObject *pAttacker, unsigned long dmg)
{
	// Calculate rage
	if (dmg <= 0) return;
	if (pPlayer->Data.Class == CLASS_WARRIOR
		|| pPlayer->Data.MorphState == UNIT_BEARFORM)
	{
		// RageForGettingHit = damage / (1.5 * level)

		unsigned long NewRage;
		if(pAttacker->type == OBJ_CREATURE)
		{
			NewRage=(unsigned long)(pPlayer->Data.CurrentStats.Rage+(dmg * 10 / (1.5 * ((CCreature*)pAttacker)->pTemplate->Data.Level)));
		} else {
			NewRage=(unsigned long)(pPlayer->Data.CurrentStats.Rage+(dmg * 10 / (1.5 * ((CPlayer*)pAttacker)->Data.Level)));
		}
		pPlayer->DataObject.SetRage((NewRage>1000)?1000:NewRage); // maximum of 1000
		pPlayer->UpdateObject();
	}
}

void GameMechanics::RageForHitting(CPlayer *pPlayer, CWoWObject *pAttacker, unsigned long dmg)
{
	if (dmg <= 0) return;
	// ===== CALCULATE RAGE ===== //
	if (pPlayer->Data.Class == CLASS_WARRIOR
		|| pPlayer->Data.MorphState == UNIT_BEARFORM)
	{
		// RageForGettingHit = damage / (1.5 * level)
		//FP001
		unsigned long NewRage;
		if(pAttacker->type == OBJ_CREATURE)
		{
			NewRage=(unsigned long)(pPlayer->Data.CurrentStats.Rage+(dmg * 10 / (0.5 * ((CCreature*)pAttacker)->pTemplate->Data.Level)));
		} else {
			NewRage=(unsigned long)(pPlayer->Data.CurrentStats.Rage+(dmg * 10 / (0.5 * ((CPlayer*)pAttacker)->Data.Level)));
		}
		pPlayer->DataObject.SetRage((NewRage>1000)?1000:NewRage); // maximum of 1000
		pPlayer->UpdateObject();
	}
}

void GameMechanics::GiveXP(CPlayer *pPlayer, long exp)
{
	pPlayer->AddExp(exp);
}

long GameMechanics::CalculateKillXP(CCreature *pCreature, CPlayer *pPlayer, long *OrigExp)
// Please Note: "OrigExp" is meant to pass back the pre-rest value of OrigExp for logging purposes.
{
	long Exp = 0;
	if(!pCreature->pTemplate) return 0; // get nothing for killing...why would this be null anyway?
	if (pPlayer->Data.Level == pCreature->pTemplate->Data.Level)
		Exp = pCreature->pTemplate->Data.Level * 5 + 45;
	else if (pPlayer->Data.Level < pCreature->pTemplate->Data.Level)
		Exp = (long)((pPlayer->Data.Level * 5 + 45) * (1 + 0.05 * (pCreature->pTemplate->Data.Level - pPlayer->Data.Level)));
	else if (pPlayer->Data.Level > pCreature->pTemplate->Data.Level)
	{
		float zerodif; // float to ensure float division
		if (pPlayer->Data.Level > 59) zerodif = 17;
		else if (pPlayer->Data.Level > 54) zerodif = 16;
		else if (pPlayer->Data.Level > 49) zerodif = 15;
		else if (pPlayer->Data.Level > 44) zerodif = 14;
		else if (pPlayer->Data.Level > 39) zerodif = 13;
		else if (pPlayer->Data.Level > 29) zerodif = 12;
		else if (pPlayer->Data.Level > 19) zerodif = 11;
		else if (pPlayer->Data.Level > 15) zerodif = 9;
		else if (pPlayer->Data.Level > 11) zerodif = 8;
		else if (pPlayer->Data.Level > 9) zerodif = 7;
		else if (pPlayer->Data.Level > 7) zerodif = 6;
		else zerodif = 5;
		Exp = (long)((pPlayer->Data.Level * 5 + 45) * (1.0 - (pPlayer->Data.Level - pCreature->pTemplate->Data.Level) / zerodif));
	}
	if (Exp == 0)
		Exp = pCreature->pTemplate->Data.Level * 5 + 45;		// failsafe
	if (Exp < 0)
		Exp = 0;
	// check if mob is elite, if so * 2 xp
	if (pCreature->pTemplate->Data.Elite == 1)
		Exp <<= 1; // *= 2;

	if(OrigExp) *OrigExp=Exp;
	switch(pPlayer->Data.RestState)
	{
	case RESTEDSTATE_RESTED:
		{
			unsigned long CurrentRest=(unsigned long)pPlayer->Data.RestAmount;
			if(Exp>=(long)CurrentRest) //take everything out
			{
				Exp=Exp+CurrentRest;
				pPlayer->DataObject.SetRestAmount(0);
				pPlayer->DataObject.SetRestState(RESTEDSTATE_NORMAL);
			}
			else
			{
				pPlayer->DataObject.SetRestAmount((float)(CurrentRest-Exp));
				Exp <<= 1; // *=2
			}
		}
		break;
	case RESTEDSTATE_TIRED50:
		Exp >>= 1; // /=2
		break;
	case RESTEDSTATE_EXHAUSTED:
		Exp >>= 2; // /=4
		break;
	}
	return Exp;

	/*	EventManager.AddEvent(*pPlayer, 0, EVENT_PLAYER_GAINEXP, &Exp, sizeof(Exp));
	SendLootablePacket(pPlayer);*/
}

void GameMechanics::SendSpiritHealerGossipMenu(CClient *pClient, CCreature *pCreature)
{
	CPacket pkg;
	pkg.Reset(SMSG_GOSSIP_MESSAGE);
	pkg << pCreature->guid << CREATUREGUID_HIGH;
	pkg << (unsigned long)580;		// npc text
	pkg << (unsigned long)2;
	pkg << (unsigned long)97;	// SH Heal handler
	pkg << (unsigned char)0;
	pkg << (unsigned char)0;
	pkg << "Return me to life.";
	pkg << (unsigned long)100;	// Default for close gossip
	pkg << (unsigned char)0;
	pkg << (unsigned char)0;
	pkg << "Goodbye.";
	pClient->Send(&pkg);

	return;
}

void GameMechanics::SpiritHealerTextQuery(CClient *pClient, CCreature *pCreature)
{
	char msg[] = "It is not yet your time. I shall aid your journey back to the realm of the living... for a price.";	// Default SH text

	CPacket pkg;
	pkg.Reset(SMSG_NPC_TEXT_UPDATE);
	pkg << 580;		// SH Npc text is 580.
	pkg << (unsigned long)0;
	pkg << msg;
	pkg << msg;
	pClient->Send(&pkg);
}

float GameMechanics::CalculateDamage(CWoWObject *pAttacker, CWoWObject *pVictim, long &flags, long &victimflags, float &absorbed)
{
	absorbed = 0.0f;
	// miss
	if (!(rand() % 4))
	{
		flags |= 0x01;
		victimflags = 0x01;
		return 0.0f;
	}

	long diff = 0;
	float rv = 0;

	if(pAttacker->type == OBJ_PLAYER)
	{
		diff = long(((CPlayer*)pAttacker)->Data.DamageMin - ((CPlayer*)pAttacker)->Data.DamageMax);
		if (diff)
			rv = (((CPlayer*)pAttacker)->Data.DamageMax + (rand() % diff));
		else
			rv = ((CPlayer*)pAttacker)->Data.DamageMin;
		long strmultiplier = ((CPlayer*)pAttacker)->AttackPowerBonus();
		rv += strmultiplier;
	}

	if(pAttacker->type == OBJ_CREATURE)
	{
		diff = long(((CCreature*)pAttacker)->pTemplate->Data.DamageMin - ((CCreature*)pAttacker)->pTemplate->Data.DamageMax);
		if (diff)
			rv = (float)(((CCreature*)pAttacker)->pTemplate->Data.DamageMax + (rand() % diff));
		else
			rv = (float)((CCreature*)pAttacker)->pTemplate->Data.DamageMin;
	}

	victimflags = 0x01;
	flags = 0x22;

	// Check for critical hit, only for player atm!
	if(pAttacker->type == OBJ_PLAYER)
	{
		if ((rand() % 10000) < (100.0f*((CPlayer*)pAttacker)->Data.CritPct)) //critical hit!
		{
			flags = 0x2E;
			rv += rv + (((CPlayer*)pAttacker)->Data.Level * 2);
		}
	}

	// Block
	if(pAttacker->type == OBJ_PLAYER)
	{
		if(((CPlayer*)pAttacker)->Data.CurrentStats.Block > 0)
		{
			rv-=((CPlayer*)pAttacker)->Data.CurrentStats.Block;		// this needs to be revised
			// set victim flags
			absorbed = (float)((CPlayer*)pAttacker)->Data.CurrentStats.Block;
			return rv;
		}
	}

	// Dodge
	float ClassModifier = 20.0f;
	long DodgePct = 0;

	if(pAttacker->type == OBJ_PLAYER)
	{
		if(((CPlayer*)pAttacker)->Data.Class == CLASS_ROGUE)
			ClassModifier = 14.5f;
		if(((CPlayer*)pAttacker)->Data.Class == CLASS_HUNTER)
			ClassModifier = 26.5f;
		// Find defense skill value
		int i=0;
		long DefenseSkill = 0;
		while(((CPlayer*)pAttacker)->Data.Skills[i].SkillID)
		{
			if(((CPlayer*)pAttacker)->Data.Skills[i].SkillID == SKILL_DEFENSE)
			{
				DefenseSkill = ((CPlayer*)pAttacker)->Data.Skills[i].CurrentLevel;
				break;
			}
			i++;
		}
		long MobLevel = 0;
		if(pVictim->type == OBJ_CREATURE)
			MobLevel = ((CCreature*)pVictim)->pTemplate->Data.Level;
		else
			MobLevel = ((CPlayer*)pVictim)->Data.Level;
		/*
		* Defense contribution = (350 - 300) * 0.04 = 2%
		* Agility contribution = (150 / 20) = 7.5%
		* 2% items + 0% talents + 2% Defense modifier + 7.5% agility contribution = 11.5% Dodge versus level 60 mobs
		*/
		//     * Dodge% = contribution from items + contribution from talents + ((Defense skill - mob level * 5) * 0.04) + (AGI / Class Modifier)
		long Agility = ((CPlayer*)pAttacker)->Data.CurrentStats.Agility;
		DodgePct = ((DefenseSkill - MobLevel * 5) / 25) + (long)(Agility / ClassModifier); // was "Agility - ClassModifier"...
	} else {
		long MobLevel = 0;
		if(pVictim->type == OBJ_CREATURE)
			MobLevel = ((CCreature*)pVictim)->pTemplate->Data.Level;
		else
			MobLevel = ((CPlayer*)pVictim)->Data.Level;

		//     * Dodge% = contribution from items + contribution from talents + ((Defense skill - mob level * 5) * 0.04) + (AGI / Class Modifier)
		// long Agility = ((CPlayer*)pAttacker)->Data.CurrentStats.Agility;
		DodgePct = ((((CCreature*)pAttacker)->pTemplate->Data.Level - MobLevel * 5)) / 25; // * 0.04f;
	}
	/*if(DodgePct > 90.0f)
	{
	// Dodge
	victimflags = 0x02;
	return 0.0f;
	}*/

	// Damage reduction because of armor

	float DamageReduction = 0;

	if(pVictim->type == OBJ_PLAYER)
	{
		unsigned long totalArmor=((CPlayer*)pVictim)->Data.CurrentStats.Armor + 2*((CPlayer*)pVictim)->Data.CurrentStats.Agility;
		if(pAttacker->type == OBJ_CREATURE)
			DamageReduction = (float)totalArmor / (float)(totalArmor+400+85*((CCreature*)pAttacker)->pTemplate->Data.Level);
		else
			DamageReduction = (float)totalArmor / (float)(totalArmor+400+85*((CPlayer*)pAttacker)->Data.Level);

		DamageReduction = (DamageReduction >= 0.75f)?0.75f:DamageReduction;
		rv*=(1.0f-DamageReduction);
		absorbed = rv*DamageReduction;
	} else {
		unsigned long totalArmor=((CCreature*)pVictim)->pTemplate->Data.Armor + 2*((CCreature*)pVictim)->pTemplate->Data.Level;
		if(totalArmor > 0)
		{
			if(pAttacker->type == OBJ_CREATURE)
				DamageReduction = (float)totalArmor / (float)(totalArmor+400+85*((CCreature*)pAttacker)->pTemplate->Data.Level);
			else
				DamageReduction = (float)totalArmor / (float)(totalArmor+400+85*((CPlayer*)pAttacker)->Data.Level);

			DamageReduction = (DamageReduction >= 0.75f)?0.75f:DamageReduction;
			rv*=(1.0f-DamageReduction);
			absorbed = rv*DamageReduction;
		}
	}

	// Check resistances and absorbed damage and shiat :P

	if(rv <= 0)
	{
		// If damage <= 0 then it's a miss.
		rv = 0.0f;
		absorbed = 0.0f;
		flags |= 0x01;
		victimflags = 0x01;
		return 0.0f;
	}

	return rv;
}

void GameMechanics::AttackSwing(CWoWObject *pAttacker, CWoWObject *pVictim)
{
	// Find targets and their type
	unsigned long AttackerType, VictimType;
	AttackerType = pAttacker->type;
	VictimType = pVictim->type;

	float AbsorbedDamage = 0;
	long Flags = 0;
	long VictimFlags = 0;

	long damage = (long)CalculateDamage(pAttacker,pVictim, Flags, VictimFlags, AbsorbedDamage);
	if(pAttacker->type==OBJ_PLAYER)
	{
		if(((CPlayer*)pAttacker)->NextAttackSpell)
		{
			((CPlayer*)pAttacker)->NextAttackSpell->NextAttackBaseDmg = damage;
			((CPlayer*)pAttacker)->NextAttackSpell->CastSpellStart(*((CPlayer*)pAttacker)->NextAttackData);
			((CPlayer*)pAttacker)->ClearNextAttackSpell();
			return;
		}
	}
	if(VictimType == OBJ_PLAYER)
	{
		((CPlayer*)pVictim)->TakeDamage(NULL,damage,false);
		((CPlayer*)pVictim)->CheckForSkillUpdate(true);
		RageForGettingHit(((CPlayer*)pVictim),(CCreature*)pAttacker,damage);
	}
	else if(VictimType == OBJ_CREATURE)
	{
		((CCreature*)pVictim)->TakeDamage(pAttacker,damage,false);
	}
	else
	{
		Debug.Logf("Error: Player tried to attack object of type %i!",VictimType);
	}

	if(AttackerType == OBJ_PLAYER)
	{
		Packets::AttackStart(((CPlayer*)pAttacker)->pClient,pVictim->guid,0);
		RageForHitting(((CPlayer*)pAttacker),pAttacker,damage);
		((CPlayer*)pAttacker)->CheckForSkillUpdate(false);
	}
	pAttacker->bIsInCombat = true;
	pVictim->bIsInCombat = true;

	long TotalDamage = damage+(long)AbsorbedDamage;

	// Build packet
	CPacket pkg;
	pkg.Reset(SMSG_ATTACKERSTATEUPDATE);
	pkg << Flags;		// flag
	/*pkg << (unsigned char)0xFF << pAttacker->guid << (unsigned long)0;
	pkg << (unsigned char)0xFF << pVictim->guid << (unsigned long)0;*/
	Packets::PackGuid(pkg,pAttacker->guid,PLAYERGUID_HIGH);
	Packets::PackGuid(pkg,pVictim->guid,PLAYERGUID_HIGH);
	pkg << (unsigned long)TotalDamage;
	pkg << (unsigned char)1;
	pkg << (unsigned long)0;
	pkg << (float)TotalDamage;
	pkg << (unsigned long)TotalDamage;
	pkg << (unsigned long)AbsorbedDamage;		// Absorbed
	pkg << (long)0; // Spell Link
	pkg << (long)VictimFlags; // 2 dodge, 3 parry, 4 interrupt, 5 block, 6 evade, 7 immune, 8 deflect
	pkg << (unsigned long)0xFFFFFFFF;		// if blocked damage, this is 0
	pkg << (unsigned long)0;
	pkg << (unsigned long)0;

	Packets::SendRegion(pkg,pAttacker);

	// Check for death
	if(pVictim->dead)
	{
		// Set not in combat
		pAttacker->bIsInCombat = false;
		pVictim->bIsInCombat = false;
		if(pAttacker->type == OBJ_PLAYER)
			Packets::AttackStop(((CPlayer*)pAttacker)->pClient,pAttacker->guid,0);
		if(pVictim->type == OBJ_PLAYER)
			Packets::AttackStop(((CPlayer*)pVictim)->pClient,pAttacker->guid,0);
	}
}
