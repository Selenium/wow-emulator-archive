#include "SpellHandler.h"
#include "MsgHandlers.h"
#include "Defines.h"
#include "Globals.h"
#include "Client.h"
#include "Spell.h"
#include "DBCHandler.h"
#include "dbc_structs.h"
#include "GameMechanics.h"
#include "AuraHandler.h"
#include "Event.h"

long AuraHandler::ModStat(CWoWObject* pTarget,long power,int id,bool pos)
{
	if(pTarget->type==OBJ_PLAYER)
	{
		switch(id)
		{
		case 0: // strength
			{
				((CPlayer*)pTarget)->Data.CurrentStats.Strength+=power;
				if(pos) {((CPlayer*)pTarget)->abonus.Str+=power;return ((CPlayer*)pTarget)->abonus.Str;}
				else {((CPlayer*)pTarget)->aminus.Str+=power;return ((CPlayer*)pTarget)->aminus.Str;}
			}
		case 1: // agility
			{
				((CPlayer*)pTarget)->Data.CurrentStats.Agility+=power;
				if(pos) {((CPlayer*)pTarget)->abonus.Ag+=power;return ((CPlayer*)pTarget)->abonus.Ag;}
				else {((CPlayer*)pTarget)->aminus.Ag+=power;return ((CPlayer*)pTarget)->aminus.Ag;}
			}
		case 2: // stamina
			{
				((CPlayer*)pTarget)->Data.CurrentStats.Stamina+=power;
				if(pos) {((CPlayer*)pTarget)->abonus.Sta+=power;return ((CPlayer*)pTarget)->abonus.Sta;}
				else {((CPlayer*)pTarget)->aminus.Sta+=power;return ((CPlayer*)pTarget)->aminus.Sta;}
			}
		case 3: // intellect
			{
				((CPlayer*)pTarget)->Data.CurrentStats.Intellect+=power;
				if(pos) {((CPlayer*)pTarget)->abonus.Int+=power;return ((CPlayer*)pTarget)->abonus.Int;}
				else {((CPlayer*)pTarget)->aminus.Int+=power;return ((CPlayer*)pTarget)->aminus.Int;}
			}
		case 4: // spirit
			{
				((CPlayer*)pTarget)->Data.CurrentStats.Spirit+=power;
				if(pos) {((CPlayer*)pTarget)->abonus.Spi+=power;return ((CPlayer*)pTarget)->abonus.Spi;}
				else { ((CPlayer*)pTarget)->aminus.Spi+=power;return ((CPlayer*)pTarget)->aminus.Spi;}
			}
		}
	}
	return 0; // default value?
}

long AuraHandler::ModStatPct(CWoWObject* pTarget,long power,int id,bool pos)
{
	if(pTarget->type==OBJ_PLAYER)
	{
		switch(id)
		{
		case 0: // strength
			{
				power = (long)ceil((((float)power/100.0)*((CPlayer*)pTarget)->Data.CurrentStats.Strength));
				((CPlayer*)pTarget)->Data.CurrentStats.Strength+=power;
				if(pos) {((CPlayer*)pTarget)->abonus.Str+=power;return ((CPlayer*)pTarget)->abonus.Str;}
				else {((CPlayer*)pTarget)->aminus.Str+=power;return ((CPlayer*)pTarget)->aminus.Str;}
			}
		case 1: // agility
			{
				power = (long)ceil((((float)power/100.0)*((CPlayer*)pTarget)->Data.CurrentStats.Agility));
				((CPlayer*)pTarget)->Data.CurrentStats.Agility+=power;
				if(pos) {((CPlayer*)pTarget)->abonus.Ag+=power;return ((CPlayer*)pTarget)->abonus.Ag;}
				else {((CPlayer*)pTarget)->aminus.Ag+=power;return ((CPlayer*)pTarget)->aminus.Ag;}
			}
		case 2: // stamina
			{
				power = (long)ceil((((float)power/100.0)*((CPlayer*)pTarget)->Data.CurrentStats.Stamina));
				((CPlayer*)pTarget)->Data.CurrentStats.Stamina+=power;
				if(pos) {((CPlayer*)pTarget)->abonus.Sta+=power;return ((CPlayer*)pTarget)->abonus.Sta;}
				else {((CPlayer*)pTarget)->aminus.Sta+=power;return ((CPlayer*)pTarget)->aminus.Sta;}
			}
		case 3: // intellect
			{
				power = (long)ceil((((float)power/100.0)*((CPlayer*)pTarget)->Data.CurrentStats.Intellect));
				((CPlayer*)pTarget)->Data.CurrentStats.Intellect+=power;
				if(pos) {((CPlayer*)pTarget)->abonus.Int+=power;return ((CPlayer*)pTarget)->abonus.Int;}
				else {((CPlayer*)pTarget)->aminus.Int+=power;return ((CPlayer*)pTarget)->aminus.Int;}
			}
		case 4: // spirit
			{
				power = (long)ceil((((float)power/100.0)*((CPlayer*)pTarget)->Data.CurrentStats.Spirit));
				((CPlayer*)pTarget)->Data.CurrentStats.Spirit+=power;
				if(pos) {((CPlayer*)pTarget)->abonus.Spi+=power;return ((CPlayer*)pTarget)->abonus.Spi;}
				else {((CPlayer*)pTarget)->aminus.Spi+=power;return ((CPlayer*)pTarget)->aminus.Spi;}
			}
		}
	}
	return 0;
}

void AuraHandler::ModForm(CWoWObject *pTarget,int id,bool apply)
{
	switch(id)
	{
	case FORM_CAT:
		{
			if(apply)
			{
				((CPlayer*)pTarget)->DataObject.SetModel(0x37C);
				((CPlayer*)pTarget)->DataObject.SetMorphState(UNIT_CATFORM);
				((CPlayer*)pTarget)->UpdateObject();
			}
			else
			{
				((CPlayer*)pTarget)->DataObject.SetModel(((CPlayer*)pTarget)->Data.BaseModel);
				((CPlayer*)pTarget)->DataObject.SetMorphState(0);
				((CPlayer*)pTarget)->UpdateObject();
			}
			break;
		}
	case FORM_TREE:
		Debug.Log("Unsupported Morph Form FORM_TREE");
		break;
	case FORM_TRAVEL:
		{
			if(apply)
			{
				((CPlayer*)pTarget)->DataObject.SetModel(0x278);
				((CPlayer*)pTarget)->SetSpeed(((CPlayer*)pTarget)->Data.runspeed+(float)(0.4*DEFAULT_PLAYER_RUN_SPEED));
				((CPlayer*)pTarget)->DataObject.SetMorphState(UNIT_TRAVELFORM);
				((CPlayer*)pTarget)->UpdateObject();
			}
			else
			{
				((CPlayer*)pTarget)->DataObject.SetModel(((CPlayer*)pTarget)->Data.BaseModel);
				((CPlayer*)pTarget)->SetSpeed(((CPlayer*)pTarget)->Data.runspeed-(float)(0.4*DEFAULT_PLAYER_RUN_SPEED));
				((CPlayer*)pTarget)->DataObject.SetMorphState(0);
				((CPlayer*)pTarget)->UpdateObject();
			}
			break;
		}
	case FORM_AQUA:
		{
			if(apply)
			{
				((CPlayer*)pTarget)->DataObject.SetModel(0x97C);
				((CPlayer*)pTarget)->SetSwimSpeed(((CPlayer*)pTarget)->Data.swimspeed+(float)(0.5*DEFAULT_PLAYER_SWIM_SPEED));
				((CPlayer*)pTarget)->DataObject.SetMorphState(UNIT_AQUATICFORM);
				((CPlayer*)pTarget)->UpdateObject();
			}
			else
			{
				((CPlayer*)pTarget)->DataObject.SetModel(((CPlayer*)pTarget)->Data.BaseModel);
				((CPlayer*)pTarget)->SetSpeed(((CPlayer*)pTarget)->Data.swimspeed-(float)(0.5*DEFAULT_PLAYER_SWIM_SPEED));
				((CPlayer*)pTarget)->DataObject.SetMorphState(0);
				((CPlayer*)pTarget)->UpdateObject();
			}
			break;
		}
	case FORM_BEAR:
		{
			if(apply)
			{
				if(((CPlayer*)pTarget)->Data.Race == RACE_NIGHTELF)
				{
					((CPlayer*)pTarget)->DataObject.SetModel(0x8E9);
				}
				else if(((CPlayer*)pTarget)->Data.Race == RACE_TAUREN)
				{
					((CPlayer*)pTarget)->DataObject.SetModel(0x8F1);
				}
				((CPlayer*)pTarget)->DataObject.SetHP(((CPlayer*)pTarget)->Data.CurrentStats.HitPoints+20);
				((CPlayer*)pTarget)->DataObject.SetMorphState(UNIT_BEARFORM);
				((CPlayer*)pTarget)->UpdateObject();
			}
			else
			{
				((CPlayer*)pTarget)->DataObject.SetModel(((CPlayer*)pTarget)->Data.BaseModel);
				((CPlayer*)pTarget)->DataObject.SetHP(((CPlayer*)pTarget)->Data.CurrentStats.HitPoints-20);
				((CPlayer*)pTarget)->DataObject.SetMorphState(0);
				((CPlayer*)pTarget)->UpdateObject();
			}
			break;
		}
	case FORM_AMBIENT:
		Debug.Log("Unsupported Morph Form FORM_AMBIENT");
		break;
	case FORM_GHOUL:
		Debug.Log("Unsupported Morph Form FORM_GHOUL");
		break;
	case FORM_DIREBEAR:
		{
			if(apply)
			{
				if(((CPlayer*)pTarget)->Data.Race == RACE_NIGHTELF)
				{
					((CPlayer*)pTarget)->DataObject.SetModel(0x8E9);
				}
				else if(((CPlayer*)pTarget)->Data.Race == RACE_TAUREN)
				{
					((CPlayer*)pTarget)->DataObject.SetModel(0x8F1);
				}
				((CPlayer*)pTarget)->DataObject.SetHP(((CPlayer*)pTarget)->Data.CurrentStats.HitPoints+600);
				((CPlayer*)pTarget)->DataObject.SetMorphState(UNIT_DIREBEARFORM);
				((CPlayer*)pTarget)->UpdateObject();
			}
			else
			{
				((CPlayer*)pTarget)->DataObject.SetModel(((CPlayer*)pTarget)->Data.BaseModel);
				((CPlayer*)pTarget)->DataObject.SetHP(((CPlayer*)pTarget)->Data.CurrentStats.HitPoints-600);
				((CPlayer*)pTarget)->DataObject.SetMorphState(0);
				((CPlayer*)pTarget)->UpdateObject();
			}
			break;
		}
	case FORM_CREATUREBEAR:
		Debug.Log("Unsupported Morph Form FORM_CREATUREBEAR");
		break;
	case FORM_GHOSTWOLF:
		Debug.Log("Unsupported Morph Form FORM_GHOSTWOLF");
		break;
	case FORM_BATTLESTANCE:
		{
			if(apply)
			{
				((CPlayer*)pTarget)->DataObject.SetMorphState(UNIT_BATTLESTANCE);
				((CPlayer*)pTarget)->UpdateObject();
			}
			else {
				((CPlayer*)pTarget)->DataObject.SetMorphState(0);
				((CPlayer*)pTarget)->UpdateObject();
			}

			break;
		}
	case FORM_DEFENSIVESTANCE:
		{
			if(apply)
			{
				((CPlayer*)pTarget)->DataObject.SetMorphState(UNIT_DEFENSIVESTANCE);
				((CPlayer*)pTarget)->UpdateObject();
			}
			else {
				((CPlayer*)pTarget)->DataObject.SetMorphState(0);
				((CPlayer*)pTarget)->UpdateObject();
			}
			break;
		}
	case FORM_BERSERKERSTANCE:
		{
			if(apply)
			{
				((CPlayer*)pTarget)->DataObject.SetMorphState(UNIT_BERSERKERSTANCE);
				((CPlayer*)pTarget)->UpdateObject();
			}
			else {
				((CPlayer*)pTarget)->DataObject.SetMorphState(0);
				((CPlayer*)pTarget)->UpdateObject();
			}
			break;
		}
	case FORM_SHADOW:
		Debug.Log("Unsupported Morph Form FORM_SHADOW");
		break;
	case FORM_STEALTH:
		{
			CPacket pkg;
			((CPlayer*)pTarget)->DataObject.SetMorphState(UNIT_STEALTH);
			((CPlayer*)pTarget)->UpdateObject();
			if (apply == false) // Are you sure we should send a cooldown event? TODO...
			{
				pkg.Reset (SMSG_COOLDOWN_EVENT);
				pkg << (unsigned long)1784;// << (unsigned char)0x0F << ((CPlayer*)pTarget)->guid;
				Packets::PackGuid(pkg,((CPlayer*)pTarget)->guid,PLAYERGUID_HIGH);
				((CPlayer*)pTarget)->pClient->Send(&pkg);
			}
			return;
		}
	default:
		{
			Debug.Logf("Unknown Shapeshift Type %i",id);
			break;
		}
	}
}

long AuraHandler::ModResist(CWoWObject* pTarget,long power,int id,bool pos)
{
	if(pTarget->type==OBJ_PLAYER)
	{
		switch(id)
		{
		case DMG_PHYSICAL:
			{
				((CPlayer*)pTarget)->Data.CurrentStats.Armor+=power;
				if(pos){((CPlayer*)pTarget)->abonus.Armor+=power;return ((CPlayer*)pTarget)->abonus.Armor;}
				else {((CPlayer*)pTarget)->aminus.Armor+=power;return ((CPlayer*)pTarget)->aminus.Armor;}
			}
		case DMG_HOLY:
			{
				((CPlayer*)pTarget)->Data.CurrentStats.ResistHoly+=power;
				if(pos){((CPlayer*)pTarget)->abonus.HolyRes+=power;return ((CPlayer*)pTarget)->abonus.HolyRes;}
				else {((CPlayer*)pTarget)->aminus.HolyRes+=power;return ((CPlayer*)pTarget)->aminus.HolyRes;}
			}
		case DMG_FIRE:
			{
				((CPlayer*)pTarget)->Data.CurrentStats.ResistFire+=power;
				if(pos){((CPlayer*)pTarget)->abonus.FireRes+=power;return ((CPlayer*)pTarget)->abonus.FireRes;}
				else {((CPlayer*)pTarget)->aminus.FireRes+=power;return ((CPlayer*)pTarget)->aminus.FireRes;}
			}
		case DMG_NATURE:
			{
				((CPlayer*)pTarget)->Data.CurrentStats.ResistNature+=power;
				if(pos){((CPlayer*)pTarget)->abonus.NatureRes+=power;return ((CPlayer*)pTarget)->abonus.NatureRes;}
				else {((CPlayer*)pTarget)->aminus.NatureRes+=power;return ((CPlayer*)pTarget)->aminus.NatureRes;}
			}
		case DMG_FROST:
			{
				((CPlayer*)pTarget)->Data.CurrentStats.ResistFrost+=power;
				if(pos){((CPlayer*)pTarget)->abonus.FrostRes+=power;return ((CPlayer*)pTarget)->abonus.FrostRes;}
				else {((CPlayer*)pTarget)->aminus.FrostRes+=power;return ((CPlayer*)pTarget)->aminus.FrostRes;}
			}
		case DMG_SHADOW:
			{
				((CPlayer*)pTarget)->Data.CurrentStats.ResistShadow+=power;
				if(pos){((CPlayer*)pTarget)->abonus.ShadowRes+=power;return ((CPlayer*)pTarget)->abonus.ShadowRes;}
				else {((CPlayer*)pTarget)->aminus.ShadowRes+=power;return ((CPlayer*)pTarget)->aminus.ShadowRes;}
			}
		case DMG_ARCANE:
			{
				((CPlayer*)pTarget)->Data.CurrentStats.ResistArcane+=power;
				if(pos){((CPlayer*)pTarget)->abonus.ArcaneRes+=power;return ((CPlayer*)pTarget)->abonus.ArcaneRes;}
				else {((CPlayer*)pTarget)->aminus.ArcaneRes+=power;return ((CPlayer*)pTarget)->aminus.ArcaneRes;}
			}
		}
	}
	return 0;
}

long AuraHandler::ApplyAura(CWoWObject *pPlayer, unsigned long SpellID, unsigned long AuraTime,bool positive)
{
	long AuraSlot;
	if (pPlayer->type == OBJ_PLAYER)
		AuraSlot = ((CPlayer*)pPlayer)->FindFreeAuraSlot(positive);
	else if (pPlayer->type == OBJ_CREATURE)
		AuraSlot = ((CCreature*)pPlayer)->FindFreeAuraSlot(positive);
	else
		return -1;
	if(AuraSlot==-1) return -1;
	for(int l=0;l<64;l++)
	{
		if (pPlayer->type == OBJ_PLAYER)
		{
			if(((CPlayer*)pPlayer)->Field_Aura[l] == SpellID)
			{
				((CPlayer*)pPlayer)->RemoveAura(l);
				AuraSlot = l;
				break;
			}
		}
		if(pPlayer->type == OBJ_CREATURE)
		{
			if(((CCreature*)pPlayer)->Field_Aura[l] == SpellID)
			{
				((CCreature*)pPlayer)->RemoveAura(l);
				AuraSlot = l;
				break;
			}
		}
	}
	if(pPlayer->type == OBJ_PLAYER) ((CPlayer*)pPlayer)->SetAura(AuraSlot,SpellID,SpellID,AuraTime,0,0);
	if(pPlayer->type == OBJ_CREATURE) ((CCreature*)pPlayer)->SetAura(AuraSlot,SpellID,SpellID,AuraTime,0,0);
	return AuraSlot;
}

void AuraHandler::ApplyModifier(unsigned long auraslot, unsigned long ModID, unsigned long SpellID, bool apply, unsigned long Effect,long power, unsigned long time, unsigned long type,CWoWObject *pCaster,CWoWObject *pPlayer)
{
	CPacket pkg;
	SpellRec spellinfo;
	_Modifier mod;
	mod.ModID = (unsigned short)ModID;
	mod.Applied = apply;
	mod.SpellID = SpellID;
	mod.SlotID = (unsigned short)auraslot;
	mod.Effect = Effect;
	mod.power = power;
	mod.time = time;
	mod.type = type;
	mod.pTarget = pPlayer;
	mod.pCaster = pCaster;
	if(apply)
		if(pPlayer->type==OBJ_PLAYER)
			((CPlayer*)pPlayer)->AddModifier(mod);
	DBCManager.Spell.fetchRow(SpellID,&spellinfo);
	switch(ModID)
	{
	case SPELL_AURA_NONE: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_NONE");
		break; }

	case SPELL_AURA_BIND_SIGHT: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_BIND_SIGHT");
		break; }

	case SPELL_AURA_MOD_THREAT: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_THREAT");
		break; }

	case SPELL_AURA_AURAS_VISIBLE: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_AURAS_VISIBLE");
		break; }

	case SPELL_AURA_MOD_RESISTANCE_PCT: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_RESISTANCE_PCT");
		break; }

	case SPELL_AURA_MOD_CREATURE_ATTACK_POWER: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_CREATURE_ATTACK_POWER");
		break; }

	case SPELL_AURA_MOD_TOTAL_THREAT: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_TOTAL_THREAT");
		break; }

	case SPELL_AURA_WATER_WALK: {
		apply ?
			pkg.Reset(SMSG_MOVE_WATER_WALK)
			: pkg.Reset(SMSG_MOVE_LAND_WALK);
		//pkg << (unsigned char)0x0F << pPlayer->guid;
		Packets::PackGuid(pkg,pPlayer->guid,PLAYERGUID_HIGH);
		((CPlayer*)pPlayer)->pClient->Send(&pkg);
		break; }

	case SPELL_AURA_FEATHER_FALL:
	case SPELL_AURA_SAFE_FALL:
		{
		apply ?
			pkg.Reset(SMSG_MOVE_FEATHER_FALL)
			: pkg.Reset(SMSG_MOVE_NORMAL_FALL);
		Packets::PackGuid(pkg,((CPlayer*)pPlayer)->guid,PLAYERGUID_HIGH);
		((CPlayer*)pPlayer)->pClient->Send(&pkg);
		break; }

	case SPELL_AURA_HOVER: {
		apply ?
			pkg.Reset(SMSG_MOVE_SET_HOVER)
			: pkg.Reset(SMSG_MOVE_UNSET_HOVER);
		Packets::PackGuid(pkg,((CPlayer*)pPlayer)->guid,PLAYERGUID_HIGH);
		pkg << 0;
		((CPlayer*)pPlayer)->pClient->Send(&pkg);
		break; }

	case SPELL_AURA_ADD_FLAT_MODIFIER: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_ADD_FLAT_MODIFIER");
		break; }

	case SPELL_AURA_ADD_PCT_MODIFIER: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_ADD_PCT_MODIFIER");
		break; }

	case SPELL_AURA_ADD_TARGET_TRIGGER: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_ADD_TARGET_TRIGGER");
		break; }

	case SPELL_AURA_MOD_TAUNT: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_TAUNT");
		break; }

	case SPELL_AURA_MOD_POWER_REGEN_PERCENT: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_POWER_REGEN_PERCENT");
		break; }

	case SPELL_AURA_ADD_CASTER_HIT_TRIGGER: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_ADD_CASTER_HIT_TRIGGER");
		break; }

	case SPELL_AURA_OVERRIDE_CLASS_SCRIPTS: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_OVERRIDE_CLASS_SCRIPTS");
		break; }

	case SPELL_AURA_MOD_RANGED_DAMAGE_TAKEN: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_RANGED_DAMAGE_TAKEN");
		break; }

	case SPELL_AURA_MOD_RANGED_DAMAGE_TAKEN_PCT: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_RANGED_DAMAGE_TAKEN_PCT");
		break; }

	case SPELL_AURA_MOD_HEALING: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_HEALING");
		break; }

	case SPELL_AURA_IGNORE_REGEN_INTERRUPT: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_IGNORE_REGEN_INTERRUPT");
		break; }

	case SPELL_AURA_MOD_MECHANIC_RESISTANCE: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_MECHANIC_RESISTANCE");
		break; }

	case SPELL_AURA_MOD_HEALING_PCT: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_HEALING_PCT");
		break; }

	case SPELL_AURA_SHARE_PET_TRACKING: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_SHARE_PET_TRACKING");
		break; }

	case SPELL_AURA_MOD_CONFUSE: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_CONFUSE");
		break; }

	case SPELL_AURA_MOD_STUN: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_STUN");
		break; }

	case SPELL_AURA_UNTRACKABLE: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_UNTRACKABLE");
		break; }

	case SPELL_AURA_EMPATHY: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_EMPATHY");
		break; }

	case SPELL_AURA_MOD_OFFHAND_DAMAGE_PCT: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_OFFHAND_DAMAGE_PCT");
		break; }

	case SPELL_AURA_MOD_POWER_COST_PCT: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_POWER_COST_PCT");
		break; }

	case SPELL_AURA_MOD_RANGED_ATTACK_POWER: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_RANGED_ATTACK_POWER");
		break; }

	case SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN");
		break; }

	case SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN_PCT: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN_PCT");
		break; }

	case SPELL_AURA_RANGED_ATTACK_POWER_ATTACKER_BONUS: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_RANGED_ATTACK_POWER_ATTACKER_BONUS");
		break; }

	case SPELL_AURA_MOD_POSSESS_PET: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_POSSESS_PET");
		break; }

	case SPELL_AURA_MOD_INCREASE_SPEED_ALWAYS: {
		apply?((CPlayer*)pPlayer)->SetSpeed(power/100.0f)
			:((CPlayer*)pPlayer)->SetSpeed(100.0f/(power?power:100));
		/*
		unit = WorldGetUnit (GetGUID());
		if (unit != NULL)
		{
			if (apply)
				unit->ModifySpeedMod (mod->GetAmount() / 100.0f);
			else
			{
				if (mod->GetAmount() != 0)
					unit->ModifySpeedMod (100.0f / mod->GetAmount());
				else
					unit->SetSpeedMod (1.0f);
			}
		}
		else
		{
			Debug.Log("ApplyModifier SPELL_AURA_MOD_INCREASE_SPEED_ALWAYS: Unit %X not found", GetGUIDLow());
		}
		*/
		break; }

	case SPELL_AURA_MOD_DAMAGE_DONE: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_DAMAGE_DONE");
		break; }

	case SPELL_AURA_MOD_MOUNTED_SPEED_ALWAYS: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_MOUNTED_SPEED_ALWAYS");
		// Debug.Logf("%d %u %u", mod->GetAmount(), mod->GetMiscValue(), mod->GetMiscValue2());
		// Debug.Logf("%f %f %f", mod->GetAmount(), mod->GetMiscValue(), mod->GetMiscValue2());
		// Debug.Log("ApplyModifier: SPELL_AURA_MOD_MOUNTED_SPEED_ALWAYS: %f", mod->GetAmount());
		break; }

	case SPELL_AURA_MOD_CREATURE_RANGED_ATTACK_POWER: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_CREATURE_RANGED_ATTACK_POWER");
		break; }

	case SPELL_AURA_MOD_INCREASE_ENERGY_PERCENT: {
		unsigned long current = ((CPlayer*)pPlayer)->Data.CurrentStats.Energy;
		apply ?
			((CPlayer*)pPlayer)->DataObject.SetEnergy(current+current/100*power)
			:((CPlayer*)pPlayer)->DataObject.SetEnergy(current-current/(100+power)*100);
		((CPlayer*)pPlayer)->UpdateObject();
		break; }

	case SPELL_AURA_MOD_INCREASE_HEALTH_PERCENT: {
		unsigned long current = ((CPlayer*)pPlayer)->Data.NormalStats.HitPoints;
		apply ?
			((CPlayer*)pPlayer)->DataObject.SetHP(current+current/100*power)
			:((CPlayer*)pPlayer)->DataObject.SetHP(current-current/(100+power)*100);
		((CPlayer*)pPlayer)->UpdateObject();
		break; }

	case SPELL_AURA_MOD_MANA_REGEN_INTERRUPT: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_MANA_REGEN_INTERRUPT");
		break; }

	case SPELL_AURA_MOD_HEALING_DONE: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_HEALING_DONE");
		break; }

	case SPELL_AURA_MOD_HEALING_DONE_PERCENT: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_HEALING_DONE_PERCENT");
		break; }

	case SPELL_AURA_MOD_TOTAL_STAT_PERCENTAGE: {
		short index2 = 0;
		long v;
		if(apply)
		{
			if(power>0)
				v = ModStatPct(pPlayer,power,spellinfo.EffectMiscValue[Effect],true);
			else v = ModStatPct(pPlayer,power,spellinfo.EffectMiscValue[Effect],false);
		}
		else
		{
			if(power>0)
				v = ModStatPct(pPlayer,-(long)power,spellinfo.EffectMiscValue[Effect],true);
			else v = ModStatPct(pPlayer,-(long)power,spellinfo.EffectMiscValue[Effect],false);
		}
		switch(spellinfo.EffectMiscValue[Effect])
		{
		case 0:{
			index2 = (power > 0) ? PLAYER_FIELD_POSSTAT0 : PLAYER_FIELD_NEGSTAT0;
			((CPlayer*)pPlayer)->AddUpdateVal(index2,v);
			((CPlayer*)pPlayer)->AddUpdateVal(UNIT_FIELD_STAT0,((CPlayer*)pPlayer)->Data.CurrentStats.Strength);
			((CPlayer*)pPlayer)->UpdateObject();
			break; }
		case 1:{
			index2 = (power > 0) ? PLAYER_FIELD_POSSTAT1 : PLAYER_FIELD_NEGSTAT1;
			((CPlayer*)pPlayer)->AddUpdateVal(index2,v);
			((CPlayer*)pPlayer)->AddUpdateVal(UNIT_FIELD_STAT1,((CPlayer*)pPlayer)->Data.CurrentStats.Agility);
			((CPlayer*)pPlayer)->UpdateObject();
			break; }
		case 2:{
			index2 = (power > 0) ? PLAYER_FIELD_POSSTAT2 : PLAYER_FIELD_NEGSTAT2;
			((CPlayer*)pPlayer)->AddUpdateVal(index2,v);
			((CPlayer*)pPlayer)->AddUpdateVal(UNIT_FIELD_STAT2,((CPlayer*)pPlayer)->Data.CurrentStats.Stamina);
			((CPlayer*)pPlayer)->UpdateObject();
			break; }
		case 3:{
			index2 = (power > 0) ? PLAYER_FIELD_POSSTAT3 : PLAYER_FIELD_NEGSTAT3;
			((CPlayer*)pPlayer)->AddUpdateVal(index2,v);
			((CPlayer*)pPlayer)->AddUpdateVal(UNIT_FIELD_STAT3,((CPlayer*)pPlayer)->Data.CurrentStats.Intellect);
			((CPlayer*)pPlayer)->UpdateObject();
			break; }
		case 4:{
			index2 = (power > 0) ? PLAYER_FIELD_POSSTAT4 : PLAYER_FIELD_NEGSTAT4;
			((CPlayer*)pPlayer)->AddUpdateVal(index2,v);
			((CPlayer*)pPlayer)->AddUpdateVal(UNIT_FIELD_STAT4,((CPlayer*)pPlayer)->Data.CurrentStats.Spirit);
			((CPlayer*)pPlayer)->UpdateObject();
			break; }
		default:
			Debug.Log("ApplyModifier: SPELL_AURA_MOD_TOTAL_STAT_PERCENTAGE: Invalid EffectMiscValue!");
			break;
		}
		break;
	}

	case SPELL_AURA_MOD_HASTE: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_HASTE");
		break; }

	case SPELL_AURA_FORCE_REACTION: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_FORCE_REACTION");
		break; }

	case SPELL_AURA_MOD_DAMAGE_TAKEN: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_DAMAGE_TAKEN");
		break; }

	case SPELL_AURA_MOD_RANGED_HASTE: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_RANGED_HASTE");
		break; }

	case SPELL_AURA_MOD_RANGED_AMMO_HASTE: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_RANGED_AMMO_HASTE");
		break; }

	case SPELL_AURA_MOD_BASE_RESISTANCE_PCT: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_BASE_RESISTANCE_PCT");
		break; }

	case SPELL_AURA_MOD_RESISTANCE_EXCLUSIVE: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_RESISTANCE_EXCLUSIVE");
		break; }

	case SPELL_AURA_CHARISMA: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_CHARISMA");
		break; }

	case SPELL_AURA_PERSUADED: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_PERSUADED");
		break; }

	case SPELL_AURA_ADD_CREATURE_IMMUNITY: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_ADD_CREATURE_IMMUNITY");
		break; }

	case SPELL_AURA_RETAIN_COMBO_POINTS: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_RETAIN_COMBO_POINTS");
		break; }

	case SPELL_AURA_DAMAGE_SHIELD: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_DAMAGE_SHIELD");
		break; }

	case SPELL_AURA_MOD_STEALTH: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_STEALTH");
		/*
		// Convert float stored into integer field to normal view
		float amountf;
		*((int *)&amountf) = mod->GetAmount();

		// Clip effective stealth level by spell level
		int amount = min (GetLevel() * 5, (int)amountf + 95);

		if (apply)
			m_stealthLevel += amount;
		else
			m_stealthLevel -= amount;

		Debug.Log("ApplyModifier: STEALTH value set to %d", m_stealthLevel);
		*/
		break; }

	case SPELL_AURA_MOD_DETECT: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_DETECT");
		break; }

	case SPELL_AURA_MOD_INVISIBILITY: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_INVISIBILITY");
		break; }

	case SPELL_AURA_MOD_INVISIBILITY_DETECTION: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_INVISIBILITY_DETECTION");
		break; }

	case SPELL_AURA_MOD_POSSESS: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_POSSESS");
		break; }

	case SPELL_AURA_MOD_RESISTANCE: {
		unsigned long index2 = 0;
		long v;
		if(apply)
		{
			if(power>0)
				v = ModResist(pPlayer,power,spellinfo.EffectMiscValue[Effect],true);
			else v = ModResist(pPlayer,power,spellinfo.EffectMiscValue[Effect],false);
		}
		else
		{
			if(power>0)
				v = ModResist(pPlayer,-(long)power,spellinfo.EffectMiscValue[Effect],true);
			else v = ModResist(pPlayer,-(long)power,spellinfo.EffectMiscValue[Effect],false);
		}
		index2=((power>0)?PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE:PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE)+spellinfo.EffectMiscValue[Effect];
		switch(spellinfo.EffectMiscValue[Effect])
		{
		case DMG_PHYSICAL: {
			((CPlayer*)pPlayer)->AddUpdateVal(index2,v);
			((CPlayer*)pPlayer)->AddUpdateVal(UNIT_FIELD_RESISTANCES,((CPlayer*)pPlayer)->Data.CurrentStats.Armor);
			((CPlayer*)pPlayer)->UpdateObject();
			break; }
		case DMG_HOLY: {
			((CPlayer*)pPlayer)->AddUpdateVal(index2,v);
			((CPlayer*)pPlayer)->AddUpdateVal(UNIT_FIELD_RESISTANCES+DMG_HOLY,((CPlayer*)pPlayer)->Data.CurrentStats.ResistHoly);
			((CPlayer*)pPlayer)->UpdateObject();
			break; }
		case DMG_FIRE: {
			((CPlayer*)pPlayer)->AddUpdateVal(index2,v);
			((CPlayer*)pPlayer)->AddUpdateVal(UNIT_FIELD_RESISTANCES+DMG_FIRE,((CPlayer*)pPlayer)->Data.CurrentStats.ResistFire);
			((CPlayer*)pPlayer)->UpdateObject();
			break; }
		case DMG_NATURE: {
			((CPlayer*)pPlayer)->AddUpdateVal(index2,v);
			((CPlayer*)pPlayer)->AddUpdateVal(UNIT_FIELD_RESISTANCES+DMG_NATURE,((CPlayer*)pPlayer)->Data.CurrentStats.ResistNature);
			((CPlayer*)pPlayer)->UpdateObject();
			break; }
		case DMG_FROST: {
			((CPlayer*)pPlayer)->AddUpdateVal(index2,v);
			((CPlayer*)pPlayer)->AddUpdateVal(UNIT_FIELD_RESISTANCES+DMG_FROST,((CPlayer*)pPlayer)->Data.CurrentStats.ResistFrost);
			((CPlayer*)pPlayer)->UpdateObject();
			break; }
		case DMG_SHADOW:{
			((CPlayer*)pPlayer)->AddUpdateVal(index2,v);
			((CPlayer*)pPlayer)->AddUpdateVal(UNIT_FIELD_RESISTANCES+DMG_SHADOW,((CPlayer*)pPlayer)->Data.CurrentStats.ResistShadow);
			((CPlayer*)pPlayer)->UpdateObject();
			break; }
		case DMG_ARCANE:{
			((CPlayer*)pPlayer)->AddUpdateVal(index2,v);
			((CPlayer*)pPlayer)->AddUpdateVal(UNIT_FIELD_RESISTANCES+DMG_ARCANE,((CPlayer*)pPlayer)->Data.CurrentStats.ResistArcane);
			((CPlayer*)pPlayer)->UpdateObject();
			break; }
		}
		break; }

	case SPELL_AURA_PERIODIC_TRIGGER_SPELL: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_PERIODIC_TRIGGER_SPELL");
		break; }

	case SPELL_AURA_PERIODIC_ENERGIZE: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_PERIODIC_ENERGIZE");
		break; }

	case SPELL_AURA_MOD_PACIFY: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_PACIFY");
		break; }

	case SPELL_AURA_MOD_ROOT: {
		apply ? pkg.Reset(SMSG_FORCE_MOVE_ROOT)
			: pkg.Reset(SMSG_FORCE_MOVE_UNROOT);
		Packets::PackGuid(pkg,pPlayer->guid,PLAYERGUID_HIGH);
		Packets::SendRegion(pkg,pPlayer);
		break; }

	case SPELL_AURA_MOD_SILENCE: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_SILENCE");
		/*apply ? m_silenced = true
		: m_silenced = false;
		*/break; }

	case SPELL_AURA_REFLECT_SPELLS: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_REFLECT_SPELLS");
		break; }

	case SPELL_AURA_MOD_STAT: {
		short index2 = 0;
		long v;
		v=(apply?ModStat(pPlayer,power,spellinfo.EffectMiscValue[Effect],(power>0))
			:ModStat(pPlayer,-power,spellinfo.EffectMiscValue[Effect],(power>0)));
		switch(spellinfo.EffectMiscValue[Effect])
		{
		case 0:{
			index2=((power > 0)?PLAYER_FIELD_POSSTAT0:PLAYER_FIELD_NEGSTAT0);
			((CPlayer*)pPlayer)->AddUpdateVal(index2,v);
			((CPlayer*)pPlayer)->AddUpdateVal(UNIT_FIELD_STAT0,((CPlayer*)pPlayer)->Data.CurrentStats.Strength);
			((CPlayer*)pPlayer)->UpdateObject();
			break; }
		case 1:{
			index2=((power > 0)?PLAYER_FIELD_POSSTAT1:PLAYER_FIELD_NEGSTAT1);
			((CPlayer*)pPlayer)->AddUpdateVal(index2,v);
			((CPlayer*)pPlayer)->AddUpdateVal(UNIT_FIELD_STAT1,((CPlayer*)pPlayer)->Data.CurrentStats.Agility);
			((CPlayer*)pPlayer)->UpdateObject();
			break; }
		case 2:{
			index2=((power > 0)?PLAYER_FIELD_POSSTAT2:PLAYER_FIELD_NEGSTAT2);
			((CPlayer*)pPlayer)->AddUpdateVal(index2,v);
			((CPlayer*)pPlayer)->AddUpdateVal(UNIT_FIELD_STAT2,((CPlayer*)pPlayer)->Data.CurrentStats.Stamina);
			((CPlayer*)pPlayer)->UpdateObject();
			break; }
		case 3:{
			index2=((power > 0)?PLAYER_FIELD_POSSTAT3:PLAYER_FIELD_NEGSTAT3);
			((CPlayer*)pPlayer)->AddUpdateVal(index2,v);
			((CPlayer*)pPlayer)->AddUpdateVal(UNIT_FIELD_STAT3,((CPlayer*)pPlayer)->Data.CurrentStats.Intellect);
			((CPlayer*)pPlayer)->UpdateObject();
			break; }
		case 4:{
			index2=((power > 0)?PLAYER_FIELD_POSSTAT4:PLAYER_FIELD_NEGSTAT4);
			((CPlayer*)pPlayer)->AddUpdateVal(index2,v);
			((CPlayer*)pPlayer)->AddUpdateVal(UNIT_FIELD_STAT4,((CPlayer*)pPlayer)->Data.CurrentStats.Spirit);
			((CPlayer*)pPlayer)->UpdateObject();
			break; }
		default:
			Debug.Log("ApplyModifier: SPELL_AURA_MOD_STAT: Invalid EffectMiscValue!");
			break;
		}
		break;
	}

	case SPELL_AURA_PERIODIC_DAMAGE: {
		if(apply)
		{
			long periodicity =spellinfo.EffectAmplitude[Effect];
			AuraEvent *even = new AuraEvent();
			even->SetEventData(SpellID,power,SPELL_AURA_PERIODIC_DAMAGE,spellinfo.School,pCaster,pPlayer,(short)(time/periodicity),periodicity,auraslot,0,0);
			EventManager.AddEvent(*even, periodicity, AURA_EVENT_DOT, 0, 0);
			int i=0;
			if(pPlayer->type==OBJ_PLAYER)
			{
				((CPlayer*)pPlayer)->ClearEvents(EVENT_PLAYER_REMOVE_AURA);
				for(i=0; i<64;i++)
				{
					if(((CPlayer*)pPlayer)->avent[i]==NULL)
					{
						((CPlayer*)pPlayer)->avent[i] = even;
						break;
					}
				}
			}
			else
			{
				((CCreature*)pPlayer)->ClearEvents(EVENT_CREATURE_REMOVE_AURA);
				for(i=0; i<64;i++)
				{
					if(((CCreature*)pPlayer)->avent[i]==NULL)
					{
						((CCreature*)pPlayer)->avent[i] = even;break;
					}
				}
			}
		}
		break; }

	case SPELL_AURA_MOD_SKILL: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_SKILL");
		break; }

	case SPELL_AURA_MOD_INCREASE_SPEED: {
		if(apply)
		{
			((CPlayer*)pPlayer)->SetSpeed(((CPlayer*)pPlayer)->Data.runspeed+(float)(((float)power/100.0f)*DEFAULT_PLAYER_RUN_SPEED));
		}
		else
		{
			((CPlayer*)pPlayer)->SetSpeed(((CPlayer*)pPlayer)->Data.runspeed-(float)(((float)power/100.0f)*DEFAULT_PLAYER_RUN_SPEED));
		}
		break;
	}

	case SPELL_AURA_MOD_INCREASE_MOUNTED_SPEED: {
		if(apply)
		{
			((CPlayer*)pPlayer)->SetSpeed(((CPlayer*)pPlayer)->Data.runspeed+(float)(((float)power/100.0f)*DEFAULT_PLAYER_RUN_SPEED));
		}
		else
		{
			((CPlayer*)pPlayer)->SetSpeed(((CPlayer*)pPlayer)->Data.runspeed-(float)(((float)power/100.0f)*DEFAULT_PLAYER_RUN_SPEED));
		}
		break; }

	case SPELL_AURA_MOD_DECREASE_SPEED: {
		if(apply)
		{
			if(pPlayer->type==OBJ_PLAYER)
				((CPlayer*)pPlayer)->SetSpeed(((CPlayer*)pPlayer)->Data.runspeed-(float)(((float)power/100.0f)*DEFAULT_PLAYER_RUN_SPEED));
			else
			{
				((CCreature*)pPlayer)->MovingSpeed-=(float)(((float)power/100.0f)*7.5f);
				CPacket pkg(SMSG_FORCE_RUN_SPEED_CHANGE);
				Packets::PackGuid(pkg,pPlayer->guid,CREATUREGUID_HIGH);
				pkg <<((CCreature*)pPlayer)->MovingSpeed;
				Packets::SendRegion(pkg,pPlayer);
			}
		}
		else
		{
			if(pPlayer->type==OBJ_PLAYER)
				((CPlayer*)pPlayer)->SetSpeed(((CPlayer*)pPlayer)->Data.runspeed+(float)(((float)power/100.0f)*DEFAULT_PLAYER_RUN_SPEED));
			else
			{
				((CCreature*)pPlayer)->MovingSpeed+=(float)(((float)power/100.0f)*7.5f);
				CPacket pkg(SMSG_FORCE_RUN_SPEED_CHANGE);
				Packets::PackGuid(pkg,pPlayer->guid,CREATUREGUID_HIGH);
				pkg <<((CCreature*)pPlayer)->MovingSpeed;
				Packets::SendRegion(pkg,pPlayer);
			}
		}
		break; }

	case SPELL_AURA_MOD_INCREASE_HEALTH: {
		((CPlayer*)pPlayer)->DataObject.AddMaxHP(apply?power:-power);
		((CPlayer*)pPlayer)->UpdateObject();
		// unsigned long newValue;
		// newValue = Getunsigned longValue(UNIT_FIELD_MAXHEALTH);
		// apply ? newValue += mod->GetAmount() : newValue -= mod->GetAmount();
		// Setunsigned longValue(UNIT_FIELD_MAXHEALTH,newValue);
		break; }

	case SPELL_AURA_MOD_INCREASE_ENERGY: {
		switch(((CPlayer*)pPlayer)->Data.ManaType)
		{
		case 0: // Mana
			((CPlayer*)pPlayer)->DataObject.AddMana(apply?power:-power);
			break;
		case 1: // Rage
			((CPlayer*)pPlayer)->DataObject.AddRage(apply?power:-power);
			break;
		case 3: // Energy
			((CPlayer*)pPlayer)->DataObject.AddEnergy(apply?power:-power);
			break;
		}
		((CPlayer*)pPlayer)->UpdateObject();
		/*unsigned long powerField = 23;
		uint8 powerType = (uint8)(Getunsigned longValue(UNIT_FIELD_BYTES_0) >> 24);
		if(powerType == 0) // Mana
		powerField = UNIT_FIELD_POWER1;
		else if(powerType == 1) // Rage
		powerField = UNIT_FIELD_POWER2;
		else if(powerType == 3) // Energy
		powerField = UNIT_FIELD_POWER4;

		unsigned long newValue = Getunsigned longValue(powerType);
		apply ? newValue += mod->GetAmount() : newValue -= mod->GetAmount();
		Setunsigned longValue(powerType,newValue);
		*/break; }

	case SPELL_AURA_MOD_SHAPESHIFT: {
		ModForm(pPlayer,spellinfo.EffectMiscValue[Effect],apply);
		// check for spell id
		/*SpellEntry *spellInfo = DBCManager.Spell.fetchRow(

		if(!spellInfo)
		{
		Log::getSingleton( ).outError("WORLD: unknown spell id %i\n", spellId);
		break;
		}
		tmpAff = new Affect(spellInfo,parent->GetDuration(),parent->GetCasterGUID());
		for(uint8 i=0;i<3;i++){
		if(spellInfo->Effect[i] == 6){
		unsigned long value = 0;
		unsigned long type = 0;
		unsigned long damage = 0;

		if(spellInfo->EffectBasePoints[i] < 0){
		tmpAff->SetNegative();
		type = 1;
		}

		unsigned long sBasePoints = (unsigned long)sqrt((float)(spellInfo->EffectBasePoints[i]*spellInfo->EffectBasePoints[i]));
		if(spellInfo->EffectApplyAuraName[i] == 3){       // Periodic Trigger Damage
		damage = spellInfo->EffectBasePoints[i]+rand()%spellInfo->EffectDieSides[i]+1;
		//TODO: why the hell it takes uint16?
		tmpAff->SetDamagePerTick((uint16)damage, spellInfo->EffectAmplitude[i]);
		tmpAff->SetNegative();
		}else if(spellInfo->EffectApplyAuraName[i] == 23)// Periodic Trigger Spell
		tmpAff->SetPeriodicTriggerSpell(spellInfo->EffectTriggerSpell[i],spellInfo->EffectAmplitude[i]);
		else{
		if(spellInfo->EffectDieSides[i] != 0)
		value = sBasePoints+rand()%spellInfo->EffectDieSides[i];
		else
		value = sBasePoints;
		if(spellInfo->EffectDieSides[i] <= 1)
		value += 1;
		//TODO: why the hell it takes uint8?
		tmpAff->AddMod((uint8)spellInfo->EffectApplyAuraName[i],value,spellInfo->EffectMiscValue[i],type);
		}
		}
		}
		if(tmpAff){
		parent->SetCoAffect(tmpAff);
		AddAffect(tmpAff);
		}

		*/break; }

	case SPELL_AURA_EFFECT_IMMUNITY: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_EFFECT_IMMUNITY");
		break; }

	case SPELL_AURA_STATE_IMMUNITY: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_STATE_IMMUNITY");
		break; }

	case SPELL_AURA_SCHOOL_IMMUNITY: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_SCHOOL_IMMUNITY");
		break; }

	case SPELL_AURA_DAMAGE_IMMUNITY: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_DAMAGE_IMMUNITY");
		break; }

	case SPELL_AURA_DISPEL_IMMUNITY: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_DISPEL_IMMUNITY");
		break; }

	case SPELL_AURA_PROC_TRIGGER_SPELL: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_PROC_TRIGGER_SPELL");
		// apply ? m_triggerSpell = mod->GetAmount() : m_triggerSpell = 0;
		break; }

	case SPELL_AURA_PROC_TRIGGER_DAMAGE: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_PROC_TRIGGER_DAMAGE");
		// apply ? m_triggerDamage = mod->GetAmount() : m_triggerDamage = 0;
		break; }

	case SPELL_AURA_TRACK_CREATURES: {
		((CPlayer*)pPlayer)->AddUpdateVal(PLAYER_TRACK_CREATURES,apply?spellinfo.EffectMiscValue[Effect]:0);
		((CPlayer*)pPlayer)->UpdateObject();
		// apply ? Setunsigned longValue(PLAYER_TRACK_CREATURES,mod->GetMiscValue()) : Setunsigned longValue(PLAYER_TRACK_CREATURES,0);
		break; }

	case SPELL_AURA_TRACK_RESOURCES: {
		((CPlayer*)pPlayer)->AddUpdateVal(PLAYER_TRACK_RESOURCES,apply?spellinfo.EffectMiscValue[Effect]:0);
		((CPlayer*)pPlayer)->UpdateObject();
		// apply ? Setunsigned longValue(PLAYER_TRACK_RESOURCES,mod->GetMiscValue()) : Setunsigned longValue(PLAYER_TRACK_RESOURCES,0);
		break; }

	case SPELL_AURA_MOD_PARRY_SKILL: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_PARRY_SKILL");
		break; }

	case SPELL_AURA_MOD_PARRY_PERCENT: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_PARRY_PERCENT");
		//unsigned long current = Getunsigned longValue(PLAYER_PARRY_PERCENTAGE);
		//apply ? Setunsigned longValue(PLAYER_PARRY_PERCENTAGE,current+mod->GetAmount()) : Setunsigned longValue(PLAYER_PARRY_PERCENTAGE,current-mod->GetAmount());
		// ModifyParryChance (apply ? mod->GetAmount() : -mod->GetAmount());
		break; }

	case SPELL_AURA_MOD_DODGE_SKILL: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_DODGE_SKILL");
		break; }

	case SPELL_AURA_MOD_DODGE_PERCENT: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_DODGE_PERCENT");
		//unsigned long current = Getunsigned longValue(PLAYER_DODGE_PERCENTAGE);
		//apply ? Setunsigned longValue(PLAYER_DODGE_PERCENTAGE,current+mod->GetAmount()) : Setunsigned longValue(PLAYER_DODGE_PERCENTAGE,current-mod->GetAmount());
		// ModifyDodgeChance (apply ? mod->GetAmount() : -mod->GetAmount());
		break; }

	case SPELL_AURA_MOD_BLOCK_SKILL: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_BLOCK_SKILL");
		break; }

	case SPELL_AURA_MOD_BLOCK_PERCENT: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_BLOCK_PERCENT");
		//unsigned long current = Getunsigned longValue(PLAYER_BLOCK_PERCENTAGE);
		//apply ? Setunsigned longValue(PLAYER_BLOCK_PERCENTAGE,current+mod->GetAmount()) : Setunsigned longValue(PLAYER_BLOCK_PERCENTAGE,current-mod->GetAmount());
		// ModifyBlockChance (apply ? mod->GetAmount() : -mod->GetAmount());
		break; }

	case SPELL_AURA_MOD_CRIT_PERCENT: {
		((CPlayer*)pPlayer)->DataObject.SetCritPct(((CPlayer*)pPlayer)->Data.CritPct+(apply?power:-power));
		((CPlayer*)pPlayer)->UpdateObject();
		//unsigned long current = Getunsigned longValue(PLAYER_CRIT_PERCENTAGE);
		//apply ? Setunsigned longValue(PLAYER_CRIT_PERCENTAGE,current+mod->GetAmount()) : Setunsigned longValue(PLAYER_CRIT_PERCENTAGE,current-mod->GetAmount());
		// ModifyCritChance (apply ? mod->GetAmount() : -mod->GetAmount());
		break; }

	case SPELL_AURA_PERIODIC_LEECH: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_PERIODIC_LEECH");
		break; }

	case SPELL_AURA_MOD_HIT_CHANCE: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_HIT_CHANCE");
		break; }

	case SPELL_AURA_MOD_SPELL_HIT_CHANCE: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_SPELL_HIT_CHANCE");
		break; }

	case SPELL_AURA_TRANSFORM: {
		ModForm(pPlayer,spellinfo.EffectMiscValue[Effect],apply);
		/*if (parent->GetId() == 118) {
		if (apply) {
		//((Modifier *)mod)->SetValue1 (Getunsigned longValue (UNIT_FIELD_DISPLAYID));
		Setunsigned longValue (UNIT_FIELD_DISPLAYID, 856);
		} else {
		Setunsigned longValue (UNIT_FIELD_DISPLAYID, Getunsigned longValue(UNIT_FIELD_NATIVEDISPLAYID));
		if (caster != NULL)
		AddHate (caster, 1.0f);
		}
		}
		if (parent->GetId() == 228) {
		if (apply) {
		//((Modifier *)mod)->SetValue1 (Getunsigned longValue (UNIT_FIELD_DISPLAYID));
		Setunsigned longValue (UNIT_FIELD_DISPLAYID, 304);
		} else {
		Setunsigned longValue (UNIT_FIELD_DISPLAYID, Getunsigned longValue(UNIT_FIELD_NATIVEDISPLAYID));
		if (caster != NULL)
		AddHate (caster, 1.0f);
		}
		}
		if (parent->GetId() == 851) {
		if (apply) {
		//((Modifier *)mod)->SetValue1 (Getunsigned longValue (UNIT_FIELD_DISPLAYID));
		Setunsigned longValue (UNIT_FIELD_DISPLAYID, 856);
		} else {
		Setunsigned longValue (UNIT_FIELD_DISPLAYID, Getunsigned longValue(UNIT_FIELD_NATIVEDISPLAYID));
		if (caster != NULL)
		AddHate (caster, 1.0f);
		}
		}
		if (parent->GetId() == 4060) {
		if (apply) {
		//((Modifier *)mod)->SetValue1 (Getunsigned longValue (UNIT_FIELD_DISPLAYID));
		Setunsigned longValue (UNIT_FIELD_DISPLAYID, 131);
		} else {
		Setunsigned longValue (UNIT_FIELD_DISPLAYID, Getunsigned longValue(UNIT_FIELD_NATIVEDISPLAYID));
		if (caster != NULL)
		AddHate (caster, 1.0f);
		}
		}
		if (parent->GetId() == 5254) {
		if (apply) {
		//((Modifier *)mod)->SetValue1 (Getunsigned longValue (UNIT_FIELD_DISPLAYID));
		Setunsigned longValue (UNIT_FIELD_DISPLAYID, 856);
		} else {
		Setunsigned longValue (UNIT_FIELD_DISPLAYID, Getunsigned longValue(UNIT_FIELD_NATIVEDISPLAYID));
		if (caster != NULL)
		AddHate (caster, 1.0f);
		}
		}
		if (parent->GetId() == 12824) {
		if (apply) {
		//((Modifier *)mod)->SetValue1 (Getunsigned longValue (UNIT_FIELD_DISPLAYID));
		Setunsigned longValue (UNIT_FIELD_DISPLAYID, 856);
		} else {
		Setunsigned longValue (UNIT_FIELD_DISPLAYID, Getunsigned longValue(UNIT_FIELD_NATIVEDISPLAYID));
		if (caster != NULL)
		AddHate (caster, 1.0f);
		}
		}
		if (parent->GetId() == 12825) {
		if (apply) {
		//((Modifier *)mod)->SetValue1 (Getunsigned longValue (UNIT_FIELD_DISPLAYID));
		Setunsigned longValue (UNIT_FIELD_DISPLAYID, 856);
		} else {
		Setunsigned longValue (UNIT_FIELD_DISPLAYID, Getunsigned longValue(UNIT_FIELD_NATIVEDISPLAYID));
		if (caster != NULL)
		AddHate (caster, 1.0f);
		}
		}
		if (parent->GetId() == 12826) {
		if (apply) {
		//((Modifier *)mod)->SetValue1 (Getunsigned longValue (UNIT_FIELD_DISPLAYID));
		Setunsigned longValue (UNIT_FIELD_DISPLAYID, 856);
		} else {
		Setunsigned longValue (UNIT_FIELD_DISPLAYID, Getunsigned longValue(UNIT_FIELD_NATIVEDISPLAYID));
		if (caster != NULL)
		AddHate (caster, 1.0f);
		}
		}
		if (parent->GetId() == 13323) {
		if (apply) {
		//((Modifier *)mod)->SetValue1 (Getunsigned longValue (UNIT_FIELD_DISPLAYID));
		Setunsigned longValue (UNIT_FIELD_DISPLAYID, 856);
		} else {
		Setunsigned longValue (UNIT_FIELD_DISPLAYID, Getunsigned longValue(UNIT_FIELD_NATIVEDISPLAYID));
		if (caster != NULL)
		AddHate (caster, 1.0f);
		}
		}
		if (parent->GetId() == 15534) {
		if (apply) {
		//((Modifier *)mod)->SetValue1 (Getunsigned longValue (UNIT_FIELD_DISPLAYID));
		Setunsigned longValue (UNIT_FIELD_DISPLAYID, 856);
		} else {
		Setunsigned longValue (UNIT_FIELD_DISPLAYID, Getunsigned longValue(UNIT_FIELD_NATIVEDISPLAYID));
		if (caster != NULL)
		AddHate (caster, 1.0f);
		}
		}
		if (parent->GetId() == 17738) {
		if (apply) {
		//((Modifier *)mod)->SetValue1 (Getunsigned longValue (UNIT_FIELD_DISPLAYID));
		Setunsigned longValue (UNIT_FIELD_DISPLAYID, 1141);
		} else {
		Setunsigned longValue (UNIT_FIELD_DISPLAYID, Getunsigned longValue(UNIT_FIELD_NATIVEDISPLAYID));
		if (caster != NULL)
		AddHate (caster, 1.0f);
		}
		}
		*/break; }

	case SPELL_AURA_MOD_SPELL_CRIT_CHANCE: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_SPELL_CRIT_CHANCE");
		break; }

	case SPELL_AURA_MOD_INCREASE_SWIM_SPEED: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_INCREASE_SWIM_SPEED");
		break; }

	case SPELL_AURA_MOD_DAMAGE_DONE_CREATURE: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_DAMAGE_DONE_CREATURE");
		break; }

	case SPELL_AURA_MOD_CHARM: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_CHARM");
		break; }

	case SPELL_AURA_MOD_PACIFY_SILENCE: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_PACIFY_SILENCE");
		break; }

	case SPELL_AURA_MOD_SCALE: {
		float current = ((CPlayer*)pPlayer)->Data.Size;
		apply ? ((CPlayer*)pPlayer)->DataObject.SetSize(current+current/100*10) : ((CPlayer*)pPlayer)->DataObject.SetSize(current-current/110*100);
		((CPlayer*)pPlayer)->UpdateObject();
		break; }

	case SPELL_AURA_PERIODIC_HEALTH_FUNNEL: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_PERIODIC_HEALTH_FUNNEL");
		break; }

	case SPELL_AURA_PERIODIC_MANA_FUNNEL: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_PERIODIC_MANA_FUNNEL");
		break; }

	case SPELL_AURA_PERIODIC_MANA_LEECH: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_PERIODIC_MANA_LEECH");
		break; }

	case SPELL_AURA_MOD_CASTING_SPEED: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_CASTING_SPEED");
		break; }

	case SPELL_AURA_FEIGN_DEATH: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_FEIGN_DEATH");
		break; }

	case SPELL_AURA_MOD_DISARM: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_DISARM");
		break; }

	case SPELL_AURA_MOD_STALKED: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_STALKED");
		break; }

	case SPELL_AURA_SCHOOL_ABSORB: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_SCHOOL_ABSORB");
		break; }

	case SPELL_AURA_MOD_FEAR: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_FEAR");
		break; }

	case SPELL_AURA_EXTRA_ATTACKS: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_EXTRA_ATTACKS");
		break; }

	case SPELL_AURA_MOD_SPELL_CRIT_CHANCE_SCHOOL: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_SPELL_CRIT_CHANCE_SCHOOL");
		break; }

	case SPELL_AURA_MOD_POWER_COST: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_POWER_COST");
		break; }

	case SPELL_AURA_MOD_POWER_COST_SCHOOL: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_POWER_COST_SCHOOL");
		break; }

	case SPELL_AURA_REFLECT_SPELLS_SCHOOL: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_REFLECT_SPELLS_SCHOOL");
		break; }

	case SPELL_AURA_MOD_LANGUAGE: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_LANGUAGE");
		break; }

	case SPELL_AURA_FAR_SIGHT: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_FAR_SIGHT");
		break; }

	case SPELL_AURA_MECHANIC_IMMUNITY: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MECHANIC_IMMUNITY");
		break; }

	case SPELL_AURA_MOUNTED: {
		// Find mount model
		if(apply)
		{
			((CPlayer*)pPlayer)->MountedAuraSlot = auraslot;
			guid_t ctid;
			ctid = DBCManager.Spell.getValue(SpellID, DBC_SPELL_ATTRIBUTE(Effect, SPELL_ATTRIB_MISC));
			guid_t ctguid = DataManager.CreatureTemplates(ctid);
			CCreatureTemplate *pTemplate;
			unsigned long modelid;
			if (!DataManager.RetrieveObject((CWoWObject**)&pTemplate, OBJ_CREATURETEMPLATE, ctguid))
				modelid = 2409;
			else
				modelid = pTemplate->Data.Model;

			((CPlayer*)pPlayer)->DataObject.SetMountModel(modelid);
			((CPlayer*)pPlayer)->UpdateObject();
		}
		else
		{
			((CPlayer*)pPlayer)->MountedAuraSlot = -1;
			((CPlayer*)pPlayer)->DataObject.SetMountModel(0);
			((CPlayer*)pPlayer)->UpdateObject();
		}
		break; }

	case SPELL_AURA_MOD_DAMAGE_PERCENT_DONE: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_DAMAGE_PERCENT_DONE");
		break; }

	case SPELL_AURA_PERIODIC_HEAL: {
		if(apply)
		{
			long periodicity =spellinfo.EffectAmplitude[Effect];
			AuraEvent *even = new AuraEvent();
			even->SetEventData(SpellID,power,SPELL_AURA_PERIODIC_HEAL,spellinfo.School,pCaster,pPlayer,(short)(time/periodicity),periodicity,auraslot,0,0);
			EventManager.AddEvent(*even, periodicity, AURA_EVENT_HOT, 0, 0);int i=0;
			if(pPlayer->type==OBJ_PLAYER)
			{
				((CPlayer*)pPlayer)->ClearEvents(EVENT_PLAYER_REMOVE_AURA);
				for(i=0; i<64;i++)
				{
					if(((CPlayer*)pPlayer)->avent[i]==NULL)
					{
						((CPlayer*)pPlayer)->avent[i] = even;break;
					}
				}
			}
			else
			{
				((CCreature*)pPlayer)->ClearEvents(EVENT_CREATURE_REMOVE_AURA);
				for(i=0; i<64;i++)
				{
					if(((CCreature*)pPlayer)->avent[i]==NULL)
					{
						((CCreature*)pPlayer)->avent[i] = even;break;
					}
				}
			}
		}
		break; }

	case SPELL_AURA_MOD_PERCENT_STAT:
		{
			short index2 = 0;
			long v;
			v = ModStatPct(pPlayer,(apply?power:-power),spellinfo.EffectMiscValue[Effect],(power>0));
			switch(spellinfo.EffectMiscValue[Effect])
			{
			case 0:{
				index2=((power > 0)?PLAYER_FIELD_POSSTAT0:PLAYER_FIELD_NEGSTAT0);
				((CPlayer*)pPlayer)->AddUpdateVal(index2,v);
				((CPlayer*)pPlayer)->AddUpdateVal(UNIT_FIELD_STAT0,((CPlayer*)pPlayer)->Data.CurrentStats.Strength);
				((CPlayer*)pPlayer)->UpdateObject();
				break; }
			case 1:{
				index2=((power > 0)?PLAYER_FIELD_POSSTAT1:PLAYER_FIELD_NEGSTAT1);
				((CPlayer*)pPlayer)->AddUpdateVal(index2,v);
				((CPlayer*)pPlayer)->AddUpdateVal(UNIT_FIELD_STAT1,((CPlayer*)pPlayer)->Data.CurrentStats.Agility);
				((CPlayer*)pPlayer)->UpdateObject();
				break; }
			case 2:{
				index2=((power > 0)?PLAYER_FIELD_POSSTAT2:PLAYER_FIELD_NEGSTAT2);
				((CPlayer*)pPlayer)->AddUpdateVal(index2,v);
				((CPlayer*)pPlayer)->AddUpdateVal(UNIT_FIELD_STAT2,((CPlayer*)pPlayer)->Data.CurrentStats.Stamina);
				((CPlayer*)pPlayer)->UpdateObject();
				break; }
			case 3:{
				index2=((power > 0)?PLAYER_FIELD_POSSTAT3:PLAYER_FIELD_NEGSTAT3);
				((CPlayer*)pPlayer)->AddUpdateVal(index2,v);
				((CPlayer*)pPlayer)->AddUpdateVal(UNIT_FIELD_STAT3,((CPlayer*)pPlayer)->Data.CurrentStats.Intellect);
				((CPlayer*)pPlayer)->UpdateObject();
				break; }
			case 4:{
				index2=((power > 0)?PLAYER_FIELD_POSSTAT4:PLAYER_FIELD_NEGSTAT4);
				((CPlayer*)pPlayer)->AddUpdateVal(index2,v);
				((CPlayer*)pPlayer)->AddUpdateVal(UNIT_FIELD_STAT4,((CPlayer*)pPlayer)->Data.CurrentStats.Spirit);
				((CPlayer*)pPlayer)->UpdateObject();
				break; }
			default:
				break;
			}
			break;
		}

	case SPELL_AURA_SPLIT_DAMAGE: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_SPLIT_DAMAGE");
		break; }

	case SPELL_AURA_WATER_BREATHING: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_WATER_BREATHING");
		break; }

	case SPELL_AURA_MOD_BASE_RESISTANCE: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_BASE_RESISTANCE");
		break; }

	case SPELL_AURA_MOD_REGEN: {
		Debug.Log("ApplyModifier: Supported SPELL_AURA_MOD_REGEN");
		long FoodSlot;
		FoodSlot = ((CPlayer*)pPlayer)->FindFreeRestoreAuraSlot();
		if (FoodSlot == -1)
		{
			((CPlayer*)pPlayer)->pClient->Echo("No free restore aura slots!");
			return;
		}

		((CPlayer*)pPlayer)->RestoreAuras[FoodSlot].SpellID = SpellID;
		((CPlayer*)pPlayer)->RestoreAuras[FoodSlot].FrequencyID = 1000;
		((CPlayer*)pPlayer)->RestoreAuras[FoodSlot].PerTick = 10;
		((CPlayer*)pPlayer)->RestoreAuras[FoodSlot].RemainingTicks = 5;
		((CPlayer*)pPlayer)->RestoreAuras[FoodSlot].Type = RESTORETYPE_HEALTH;

		EventManager.AddEvent(*((CPlayer*)pPlayer),((CPlayer*)pPlayer)->RestoreAuras[FoodSlot].FrequencyID,EVENT_PLAYER_REGENERATESPELL,&FoodSlot,sizeof(FoodSlot));
		// pPlayer->pClient->Echo("Event added!");

		break; }

	case SPELL_AURA_MOD_POWER_REGEN: {
		Debug.Log("ApplyModifier: Supported SPELL_AURA_MOD_POWER_REGEN");
		long FoodSlot;
		FoodSlot = ((CPlayer*)pPlayer)->FindFreeRestoreAuraSlot();
		if (FoodSlot == -1)
		{
			((CPlayer*)pPlayer)->pClient->Echo("No free restore aura slots!");
			return;
		}
		unsigned char mtype=((CPlayer*)pPlayer)->Data.ManaType;
		if(mtype!=0 && mtype!=3)
		{
			Debug.Logf("ApplyModifier: SPELL_AURA_MOD_POWER_REGEN: Invalid Manatype %i",((CPlayer*)pPlayer)->Data.ManaType);
			break;
		}
		((CPlayer*)pPlayer)->RestoreAuras[FoodSlot].SpellID = SpellID;
		((CPlayer*)pPlayer)->RestoreAuras[FoodSlot].FrequencyID = 1000;
		((CPlayer*)pPlayer)->RestoreAuras[FoodSlot].PerTick = 10;
		((CPlayer*)pPlayer)->RestoreAuras[FoodSlot].RemainingTicks = 5;
		((CPlayer*)pPlayer)->RestoreAuras[FoodSlot].Type = (mtype==0)?RESTORETYPE_MANA:RESTORETYPE_ENERGY;

		EventManager.AddEvent(*((CPlayer*)pPlayer),((CPlayer*)pPlayer)->RestoreAuras[FoodSlot].FrequencyID,EVENT_PLAYER_REGENERATESPELL,&FoodSlot,sizeof(FoodSlot));
		break; }

	case SPELL_AURA_CHANNEL_DEATH_ITEM: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_CHANNEL_DEATH_ITEM");
		break; }

	case SPELL_AURA_MOD_DAMAGE_PERCENT_TAKEN: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_DAMAGE_PERCENT_TAKEN");
		break; }

	case SPELL_AURA_MOD_PERCENT_REGEN: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_PERCENT_REGEN");
		break; }

	case SPELL_AURA_PERIODIC_DAMAGE_PERCENT: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_PERIODIC_DAMAGE_PERCENT");
		break; }

	case SPELL_AURA_MOD_ATTACKSPEED: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_ATTACKSPEED");
		break; }

	case SPELL_AURA_MOD_RESIST_CHANCE: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_RESIST_CHANCE");
		break; }

	case SPELL_AURA_MOD_DETECT_RANGE: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_DETECT_RANGE");
		break; }

	case SPELL_AURA_PREVENTS_FLEEING: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_PREVENTS_FLEEING");
		break; }

	case SPELL_AURA_MOD_UNATTACKABLE: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_UNATTACKABLE");
		break; }

	case SPELL_AURA_INTERRUPT_REGEN: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_INTERRUPT_REGEN");
		break; }

	case SPELL_AURA_GHOST: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_GHOST");
		break; }

	case SPELL_AURA_SPELL_MAGNET: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_SPELL_MAGNET");
		break; }

	case SPELL_AURA_MANA_SHIELD: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MANA_SHIELD");
		break; }

	case SPELL_AURA_MOD_SKILL_TALENT: {
		Debug.Log("ApplyModifier: Unsupported SPELL_AURA_MOD_SKILL_TALENT");
		break; }

	case SPELL_AURA_MOD_ATTACK_POWER: {
		if(apply)
		{
			((CPlayer*)pPlayer)->AddUpdateVal(UNIT_FIELD_ATTACK_POWER_MODS,power);
			((CPlayer*)pPlayer)->AddUpdateVal(UNIT_FIELD_ATTACK_POWER,((CPlayer*)pPlayer)->AttackPower()+power);
			((CPlayer*)pPlayer)->UpdateObject();
		}
		else
		{
			((CPlayer*)pPlayer)->AddUpdateVal(UNIT_FIELD_ATTACK_POWER_MODS,-power);
			((CPlayer*)pPlayer)->AddUpdateVal(UNIT_FIELD_ATTACK_POWER,((CPlayer*)pPlayer)->AttackPower()-power);
			((CPlayer*)pPlayer)->UpdateObject();
		}
		break; }

	default:
		{
			Debug.Logf("Unknown effect id %u", SpellID);
		}
	}
}
