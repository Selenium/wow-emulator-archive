#include "StdAfx.h"

//-----------------------------------------------------------------------------
void Unit::ApplyModifier(const Modifier *mod, bool apply, Affect* parent)
{
	//Player * player;
	Creature * creature;
	Unit * unit;
	WorldPacket data;

	Unit * caster = WorldGetUnit (parent->GetCasterGUID());
	if (caster != NULL && Call_Aura_ApplyModifier (mod->GetType(), caster, this, 
		apply, mod->GetAmount(), mod->GetMiscValue(), mod->GetMiscValue2()))
	{
		Log::getSingleton().outDebug ("ApplyModifier->SCRIPT: Type=%d Amount=%d V1=%d V2=%d",
			mod->GetType(), mod->GetAmount(), mod->GetMiscValue(), mod->GetMiscValue2());
		return;
	}

	Log::getSingleton().outDebug ("ApplyModifier: Type=%d Amount=%d V1=%d V2=%d",
		mod->GetType(), mod->GetAmount(), mod->GetMiscValue(), mod->GetMiscValue2());

	switch(mod->GetType())
	{
	case SPELL_AURA_NONE: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_NONE");
		break; }

	case SPELL_AURA_BIND_SIGHT: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_BIND_SIGHT");
		break; }

	case SPELL_AURA_MOD_THREAT: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_THREAT");
		break; }

	case SPELL_AURA_AURAS_VISIBLE: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_AURAS_VISIBLE");
		break; }

	case SPELL_AURA_MOD_RESISTANCE_PCT: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_RESISTANCE_PCT");
		break; }

	case SPELL_AURA_MOD_CREATURE_ATTACK_POWER: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_CREATURE_ATTACK_POWER");
		break; }

	case SPELL_AURA_MOD_TOTAL_THREAT: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_TOTAL_THREAT");
		break; }

	case SPELL_AURA_WATER_WALK: {
		apply ?
			data.Initialize(SMSG_MOVE_WATER_WALK)
			: data.Initialize(SMSG_MOVE_LAND_WALK);
		data << GetGUID();
		SendMessageToSet(&data,true);
		break; }

	case SPELL_AURA_FEATHER_FALL: {
		apply ?
			data.Initialize(SMSG_MOVE_FEATHER_FALL)
			: data.Initialize(SMSG_MOVE_NORMAL_FALL);
		data << GetGUID();
		SendMessageToSet(&data,true);
		break; }

	case SPELL_AURA_HOVER: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_HOVER");
		break; }

	case SPELL_AURA_ADD_FLAT_MODIFIER: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_ADD_FLAT_MODIFIER");
		break; }

	case SPELL_AURA_ADD_PCT_MODIFIER: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_ADD_PCT_MODIFIER");
		break; }

	case SPELL_AURA_ADD_TARGET_TRIGGER: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_ADD_TARGET_TRIGGER");
		break; }

	case SPELL_AURA_MOD_TAUNT: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_TAUNT");
		break; }

	case SPELL_AURA_MOD_POWER_REGEN_PERCENT: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_POWER_REGEN_PERCENT");
		break; }

	case SPELL_AURA_ADD_CASTER_HIT_TRIGGER: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_ADD_CASTER_HIT_TRIGGER");
		break; }

	case SPELL_AURA_OVERRIDE_CLASS_SCRIPTS: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_OVERRIDE_CLASS_SCRIPTS");
		break; }

	case SPELL_AURA_MOD_RANGED_DAMAGE_TAKEN: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_RANGED_DAMAGE_TAKEN");
		break; }

	case SPELL_AURA_MOD_RANGED_DAMAGE_TAKEN_PCT: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_RANGED_DAMAGE_TAKEN_PCT");
		break; }

	case SPELL_AURA_MOD_HEALING: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_HEALING");
		break; }

	case SPELL_AURA_IGNORE_REGEN_INTERRUPT: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_IGNORE_REGEN_INTERRUPT");
		break; }

	case SPELL_AURA_MOD_MECHANIC_RESISTANCE: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_MECHANIC_RESISTANCE");
		break; }

	case SPELL_AURA_MOD_HEALING_PCT: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_HEALING_PCT");
		break; }

	case SPELL_AURA_SHARE_PET_TRACKING: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_SHARE_PET_TRACKING");
		break; }

	case SPELL_AURA_MOD_CONFUSE: {
		//Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_CONFUSE");
		break; }

	case SPELL_AURA_MOD_STUN: {
		//Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_STUN");
		if (apply)
			SetTarget (0);
		break; } 

	case SPELL_AURA_UNTRACKABLE: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_UNTRACKABLE");
		break; }

	case SPELL_AURA_EMPATHY: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_EMPATHY");
		break; }

	case SPELL_AURA_MOD_OFFHAND_DAMAGE_PCT: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_OFFHAND_DAMAGE_PCT");
		break; }

	case SPELL_AURA_MOD_POWER_COST_PCT: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_POWER_COST_PCT");
		break; }

	case SPELL_AURA_MOD_RANGED_ATTACK_POWER: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_RANGED_ATTACK_POWER");
		break; }

	case SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN");
		break; }

	case SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN_PCT: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_MELEE_DAMAGE_TAKEN_PCT");
		break; }

	case SPELL_AURA_RANGED_ATTACK_POWER_ATTACKER_BONUS: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_RANGED_ATTACK_POWER_ATTACKER_BONUS");
		break; }

	case SPELL_AURA_MOD_POSSESS_PET: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_POSSESS_PET");
		break; }

	case SPELL_AURA_MOD_INCREASE_SPEED_ALWAYS: {
		unit = WorldGetUnit (GetGUID());
		if (unit != NULL) {
			if (apply)	unit->ModifySpeedMod (mod->GetAmount() / 100.0f);
			else {
				if (mod->GetAmount() != 0)
					unit->ModifySpeedMod (100.0f / mod->GetAmount());
				else
					unit->SetSpeedMod (1.0f);
			}
		} else {
			Log::getSingleton().outDebug ("ApplyModifier SPELL_AURA_MOD_INCREASE_SPEED_ALWAYS: Unit %X not found", GetGUIDLow());
		}
		break; }

	case SPELL_AURA_MOD_DAMAGE_DONE: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_DAMAGE_DONE");
		break; }

	case SPELL_AURA_MOD_MOUNTED_SPEED_ALWAYS: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_MOUNTED_SPEED_ALWAYS");
		break; }

	case SPELL_AURA_MOD_CREATURE_RANGED_ATTACK_POWER: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_CREATURE_RANGED_ATTACK_POWER");
		break; }

	case SPELL_AURA_MOD_INCREASE_ENERGY_PERCENT: {
		uint32 percent = mod->GetAmount();
		uint32 current = GetUInt32Value(UNIT_FIELD_POWER4);
		apply ?
			SetUInt32Value(UNIT_FIELD_POWER4,current+current/100*percent)
		:	SetUInt32Value(UNIT_FIELD_POWER4,current-current/(100+percent)*100);
		break; }

	case SPELL_AURA_MOD_INCREASE_HEALTH_PERCENT: {
		uint32 percent = mod->GetAmount();
		uint32 current = GetUInt32Value(UNIT_FIELD_MAXHEALTH);
		apply ?
			SetUInt32Value(UNIT_FIELD_MAXHEALTH,current+current/100*percent)
		:	SetUInt32Value(UNIT_FIELD_MAXHEALTH,current-current/(100+percent)*100);
		break; }

	case SPELL_AURA_MOD_MANA_REGEN_INTERRUPT: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_MANA_REGEN_INTERRUPT");
		break; }

	case SPELL_AURA_MOD_HEALING_DONE: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_HEALING_DONE");
		break; }

	case SPELL_AURA_MOD_HEALING_DONE_PERCENT: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_HEALING_DONE_PERCENT");
		break; }

	case SPELL_AURA_MOD_TOTAL_STAT_PERCENTAGE: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_TOTAL_STAT_PERCENTAGE");
		break; }

	case SPELL_AURA_MOD_HASTE: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_HASTE");
		break; }

	case SPELL_AURA_FORCE_REACTION: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_FORCE_REACTION");
		break; }

	case SPELL_AURA_MOD_DAMAGE_TAKEN: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_DAMAGE_TAKEN");
		break; }

	case SPELL_AURA_MOD_RANGED_HASTE: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_RANGED_HASTE");
		break; }

	case SPELL_AURA_MOD_RANGED_AMMO_HASTE: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_RANGED_AMMO_HASTE");
		break; }

	case SPELL_AURA_MOD_BASE_RESISTANCE_PCT: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_BASE_RESISTANCE_PCT");
		break; }

	case SPELL_AURA_MOD_RESISTANCE_EXCLUSIVE: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_RESISTANCE_EXCLUSIVE");
		break; }

	case SPELL_AURA_SAFE_FALL: {
		apply ? data.Initialize(SMSG_MOVE_FEATHER_FALL) : data.Initialize(SMSG_MOVE_NORMAL_FALL);
		data << GetGUID();
		SendMessageToSet(&data,true);
		break; }

	case SPELL_AURA_CHARISMA: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_CHARISMA");
		break; }

	case SPELL_AURA_PERSUADED: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_PERSUADED");
		break; }

	case SPELL_AURA_ADD_CREATURE_IMMUNITY: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_ADD_CREATURE_IMMUNITY");
		break; }

	case SPELL_AURA_RETAIN_COMBO_POINTS: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_RETAIN_COMBO_POINTS");
		break; }

	case SPELL_AURA_DAMAGE_SHIELD: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_DAMAGE_SHIELD");
		break; }

	case SPELL_AURA_MOD_STEALTH: {
		//Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_STEALTH");
		
		// Convert float stored into integer field to normal view
		float amountf;
		*((int *)&amountf) = mod->GetAmount();

		// Clip effective stealth level by spell level
		int amount = min (GetLevel() * 5, (int)amountf + 95);

		if (apply)	m_stealthLevel += amount;
		else		m_stealthLevel -= amount;
		
		Log::getSingleton().outDebug ("ApplyModifier: STEALTH value set to %d", m_stealthLevel);
		break; }

	case SPELL_AURA_MOD_DETECT: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_DETECT");
		break; }

	case SPELL_AURA_MOD_INVISIBILITY: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_INVISIBILITY");
		break; }

	case SPELL_AURA_MOD_INVISIBILITY_DETECTION: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_INVISIBILITY_DETECTION");
		break; }

	case SPELL_AURA_MOD_POSSESS: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_POSSESS");
		break; }

	case SPELL_AURA_MOD_RESISTANCE: {
		uint16 index = 0;
		uint16 index2 = 0;
		switch(mod->GetMiscValue())
		{
		case DMG_PHYSICAL: {
			index = UNIT_FIELD_RESISTANCES;
			mod->GetMiscValue2() == 0 ? index2 = PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE : index2 = PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE;
			break; }
		case DMG_HOLY: {
			index = UNIT_FIELD_RESISTANCES + DMG_HOLY;
			mod->GetMiscValue2() == 0 ?
				index2 = PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE + DMG_HOLY :
				index2 = PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE + DMG_HOLY;
			break; }
		case DMG_FIRE: {
			index = UNIT_FIELD_RESISTANCES + DMG_FIRE;
			mod->GetMiscValue2() == 0 ?
				index2 = PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE + DMG_FIRE :
				index2 = PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE + DMG_FIRE;
			break; }
		case DMG_NATURE: {
			index = UNIT_FIELD_RESISTANCES + DMG_NATURE;
			mod->GetMiscValue2() == 0 ?
				index2 = PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE + DMG_NATURE :
				index2 = PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE + DMG_NATURE;
			break; }
		case DMG_FROST: {
			index = UNIT_FIELD_RESISTANCES + DMG_FROST;
			mod->GetMiscValue2() == 0 ?
				index2 = PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE + DMG_FROST :
				index2 = PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE + DMG_FROST;
			break; }
		case DMG_SHADOW:{
			index = UNIT_FIELD_RESISTANCES + DMG_SHADOW;
			mod->GetMiscValue2() == 0 ?
				index2 = PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE + DMG_SHADOW :
			index2 = PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE + DMG_SHADOW;
			break; }
		case DMG_ARCANE:{
			index = UNIT_FIELD_RESISTANCES + DMG_ARCANE;
			mod->GetMiscValue2() == 0 ?
				index2 = PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE + DMG_ARCANE :
				index2 = PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE + DMG_ARCANE;
			break; }
		default:{
			Log::getSingleton().outDetail ("WARNING: Misc Value for SPELL_AURA_MOD_STAT not valid\n");
			return;
			break; }
		}

		if(apply){
			SetUInt32Value(index,GetUInt32Value(index)+mod->GetAmount());
			if (isPlayer())
				SetUInt32Value(index2,GetUInt32Value(index2)+mod->GetAmount());
		}else{
			SetUInt32Value(index,GetUInt32Value(index)-mod->GetAmount());
			if (isPlayer())
				SetUInt32Value(index2,GetUInt32Value(index2)-mod->GetAmount());
		}
		break; }

	case SPELL_AURA_PERIODIC_TRIGGER_SPELL: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_PERIODIC_TRIGGER_SPELL");
		break; }

	case SPELL_AURA_PERIODIC_ENERGIZE: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_PERIODIC_ENERGIZE");
		break; }

	case SPELL_AURA_MOD_PACIFY: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_PACIFY");
		break; }

	case SPELL_AURA_MOD_ROOT: {
		apply ? data.Initialize(MSG_MOVE_ROOT) 
			: data.Initialize(MSG_MOVE_UNROOT);
		data << GetGUID();
		SendMessageToSet(&data,true);
		break; }

	case SPELL_AURA_MOD_SILENCE: {
		apply ? m_silenced = true 
			: m_silenced = false;
		break; }

	case SPELL_AURA_REFLECT_SPELLS: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_REFLECT_SPELLS");
		break; }

	case SPELL_AURA_MOD_STAT: {
		uint16 index = 0;
		uint16 index2 = 0;
		int32 v = mod->GetAmount();

		switch(mod->GetMiscValue())
		{
		case 0:{
			//index = UNIT_FIELD_STAT0;
			ModifyStrength (apply ? v : -v);
			mod->GetMiscValue2() == 0 ? index2 = PLAYER_FIELD_POSSTAT0 : index2 = PLAYER_FIELD_NEGSTAT0;
			break; }
		case 1:{
			//index = UNIT_FIELD_STAT1;
			ModifyAgility (apply ? v : -v);
			mod->GetMiscValue2() == 0 ? index2 = PLAYER_FIELD_POSSTAT1 : index2 = PLAYER_FIELD_NEGSTAT1;
			break; }
		case 2:{
			//index = UNIT_FIELD_STAT2;
			ModifyStamina (apply ? v : -v);
			mod->GetMiscValue2() == 0 ? index2 = PLAYER_FIELD_POSSTAT2 : index2 = PLAYER_FIELD_NEGSTAT2;
			break; }
		case 3:{
			//index = UNIT_FIELD_STAT3;
			ModifyIntellect (apply ? v : -v);
			mod->GetMiscValue2() == 0 ? index2 = PLAYER_FIELD_POSSTAT3 : index2 = PLAYER_FIELD_NEGSTAT3;
			break; }
		case 4:{
			//index = UNIT_FIELD_STAT4;
			ModifySpirit (apply ? v : -v);
			mod->GetMiscValue2() == 0 ? index2 = PLAYER_FIELD_POSSTAT4 : index2 = PLAYER_FIELD_NEGSTAT4;
			break; }
		default:{
			printf("WARNING: Misc Value for SPELL_AURA_MOD_STAT not valid\n");
			return;
			break; }
		}
		if(apply){
			if (isPlayer())
				SetUInt32Value(index2,GetUInt32Value(index2) + v);
		}else{
			if (isPlayer())
				SetUInt32Value(index2,GetUInt32Value(index2) - v);
		}
		break; }

	case SPELL_AURA_PERIODIC_DAMAGE: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_PERIODIC_DAMAGE");
		break; }

	case SPELL_AURA_MOD_SKILL: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_SKILL");
		break; }

	case SPELL_AURA_MOD_INCREASE_SPEED: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_INCREASE_SPEED");
		break; }

	case SPELL_AURA_MOD_INCREASE_MOUNTED_SPEED: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_INCREASE_MOUNTED_SPEED");
		break; }

	case SPELL_AURA_MOD_DECREASE_SPEED: {
		unit = WorldGetUnit (GetGUID());
		if (unit != NULL) {
			if (apply)	unit->ModifySpeedMod (mod->GetAmount() / 100.0f);
			else {
				if (mod->GetAmount() != 0)
					unit->ModifySpeedMod (100.0f / mod->GetAmount());
				else
					unit->SetSpeedMod (1.0f);
			}
		}
		break; }

	case SPELL_AURA_MOD_INCREASE_HEALTH: {
		uint32 newValue;
		newValue = GetUInt32Value(UNIT_FIELD_MAXHEALTH);
		apply ? newValue += mod->GetAmount() : newValue -= mod->GetAmount();
		SetUInt32Value(UNIT_FIELD_MAXHEALTH,newValue);
		break; }

	case SPELL_AURA_MOD_INCREASE_ENERGY: {
		uint32 powerField = 23;
		uint8 powerType = (uint8)(GetUInt32Value(UNIT_FIELD_BYTES_0) >> 24);
		if(powerType == 0) // Mana
			powerField = UNIT_FIELD_POWER1;
		else if(powerType == 1) // Rage
			powerField = UNIT_FIELD_POWER2;
		else if(powerType == 3) // Energy
			powerField = UNIT_FIELD_POWER4;

		uint32 newValue = GetUInt32Value(powerType);
		apply ? newValue += mod->GetAmount() : newValue -= mod->GetAmount();
		SetUInt32Value(powerType,newValue);
		break; }

	case SPELL_AURA_MOD_SHAPESHIFT: {
		Affect* tmpAff;
		uint32 spellId;
		switch(mod->GetMiscValue())
		{
		case FORM_CAT: {
			spellId = 3025;
			break; }
		case FORM_TREE:{
			spellId = 3122;
			break; }
		case FORM_TRAVEL:{
			spellId = 5419;
			break; }
		case FORM_AQUA:{
			spellId = 5421;
			break; }
		case FORM_BEAR:{
			spellId = 1178;
			break; }
		case FORM_AMBIENT:{
			spellId = 0;
			break; }
		case FORM_GHOUL:{
			spellId = 0;
			break; }
		case FORM_DIREBEAR:{
			spellId = 9635;
			break; }
		case FORM_CREATUREBEAR:{
			spellId = 2882;
			break; }
		case FORM_GHOSTWOLF:{
			spellId = 0;
			break; }
		case FORM_BATTLESTANCE:{
			spellId = 0;
			break; }
		case FORM_DEFENSIVESTANCE:{
			spellId = 7376;
			break; }
		case FORM_BERSERKERSTANCE:{
			spellId = 7381;
			break; }
		case FORM_SHADOW:{
			spellId = 0;
			break; }
		case FORM_STEALTH:{
			//spellId = 0;
			// Turn on Sneaky Stance, Switch stealth button to unstealth and switch spellbar
			SetUInt32Value (UNIT_FIELD_BYTES_1, apply? 0x021E0000: 0);
			if (apply == false && isPlayer())
			{
				data.Initialize (SMSG_COOLDOWN_EVENT);
				data << (uint32)1784 << GetGUID();
				((Player*)this)->GetSession()->SendPacket (&data);
			}
			return; }

		default:{
			printf("Unknown Shapeshift Type\n");
			break; }
		}
		// check for spell id
		SpellEntry *spellInfo = sSpellStore.LookupEntry( spellId );

		if(!spellInfo)
		{
			Log::getSingleton( ).outError("WORLD: unknown spell id %i\n", spellId);
			break;
		}
		tmpAff = new Affect(spellInfo,parent->GetDuration(),parent->GetCasterGUID());
		for(uint8 i=0;i<3;i++){
			if(spellInfo->Effect[i] == 6){
				uint32 value = 0;
				uint32 type = 0;
				uint32 damage = 0;
				
				if(spellInfo->EffectBasePoints[i] < 0){
					tmpAff->SetNegative();
					type = 1;
				}

				uint32 sBasePoints = (uint32)sqrt((float)(spellInfo->EffectBasePoints[i]*spellInfo->EffectBasePoints[i]));
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

		break; }

	case SPELL_AURA_EFFECT_IMMUNITY: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_EFFECT_IMMUNITY");
		break; }

	case SPELL_AURA_STATE_IMMUNITY: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_STATE_IMMUNITY");
		break; }

	case SPELL_AURA_SCHOOL_IMMUNITY: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_SCHOOL_IMMUNITY");
		break; }

	case SPELL_AURA_DAMAGE_IMMUNITY: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_DAMAGE_IMMUNITY");
		break; }

	case SPELL_AURA_DISPEL_IMMUNITY: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_DISPEL_IMMUNITY");
		break; }

	case SPELL_AURA_PROC_TRIGGER_SPELL: {
		apply ? m_triggerSpell = mod->GetAmount() : m_triggerSpell = 0;
		break; }

	case SPELL_AURA_PROC_TRIGGER_DAMAGE: {
		apply ? m_triggerDamage = mod->GetAmount() : m_triggerDamage = 0;
		break; }

	case SPELL_AURA_TRACK_CREATURES: {
		apply ? SetUInt32Value(PLAYER_TRACK_CREATURES,mod->GetMiscValue()) : SetUInt32Value(PLAYER_TRACK_CREATURES,0);
		break; }

	case SPELL_AURA_TRACK_RESOURCES: {
		apply ? SetUInt32Value(PLAYER_TRACK_RESOURCES,mod->GetMiscValue()) : SetUInt32Value(PLAYER_TRACK_RESOURCES,0);
		break; }

	case SPELL_AURA_MOD_PARRY_SKILL: {
		break; }

	case SPELL_AURA_MOD_PARRY_PERCENT: {
		//uint32 current = GetUInt32Value(PLAYER_PARRY_PERCENTAGE);
		//apply ? SetUInt32Value(PLAYER_PARRY_PERCENTAGE,current+mod->GetAmount()) : SetUInt32Value(PLAYER_PARRY_PERCENTAGE,current-mod->GetAmount());
		ModifyParryChance (apply ? mod->GetAmount() : -mod->GetAmount());
		break; }

	case SPELL_AURA_MOD_DODGE_SKILL: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_DODGE_SKILL");
		break; }

	case SPELL_AURA_MOD_DODGE_PERCENT: {
		//uint32 current = GetUInt32Value(PLAYER_DODGE_PERCENTAGE);
		//apply ? SetUInt32Value(PLAYER_DODGE_PERCENTAGE,current+mod->GetAmount()) : SetUInt32Value(PLAYER_DODGE_PERCENTAGE,current-mod->GetAmount());
		ModifyDodgeChance (apply ? mod->GetAmount() : -mod->GetAmount());
		break; }

	case SPELL_AURA_MOD_BLOCK_SKILL: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_BLOCK_SKILL");
		break; }

	case SPELL_AURA_MOD_BLOCK_PERCENT: {
		//uint32 current = GetUInt32Value(PLAYER_BLOCK_PERCENTAGE);
		//apply ? SetUInt32Value(PLAYER_BLOCK_PERCENTAGE,current+mod->GetAmount()) : SetUInt32Value(PLAYER_BLOCK_PERCENTAGE,current-mod->GetAmount());
		ModifyBlockChance (apply ? mod->GetAmount() : -mod->GetAmount());
		break; }

	case SPELL_AURA_MOD_CRIT_PERCENT: {
		//uint32 current = GetUInt32Value(PLAYER_CRIT_PERCENTAGE);
		//apply ? SetUInt32Value(PLAYER_CRIT_PERCENTAGE,current+mod->GetAmount()) : SetUInt32Value(PLAYER_CRIT_PERCENTAGE,current-mod->GetAmount());
		ModifyCritChance (apply ? mod->GetAmount() : -mod->GetAmount());
		break; }

	case SPELL_AURA_PERIODIC_LEECH: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_PERIODIC_LEECH");
		break; }

	case SPELL_AURA_MOD_HIT_CHANCE: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_HIT_CHANCE");
		break; }

	case SPELL_AURA_MOD_SPELL_HIT_CHANCE: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_SPELL_HIT_CHANCE");
		break; }

	case SPELL_AURA_TRANSFORM: {
		if (parent->GetId() == 118) {
			if (apply) {
				//((Modifier *)mod)->SetValue1 (GetUInt32Value (UNIT_FIELD_DISPLAYID));
				SetUInt32Value (UNIT_FIELD_DISPLAYID, 856);
			} else {
				SetUInt32Value (UNIT_FIELD_DISPLAYID, GetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID));
				if (caster != NULL)
					AddHate (caster, 1.0f);
			}
		}
		if (parent->GetId() == 228) {
			if (apply) {
				//((Modifier *)mod)->SetValue1 (GetUInt32Value (UNIT_FIELD_DISPLAYID));
				SetUInt32Value (UNIT_FIELD_DISPLAYID, 304);
			} else {
				SetUInt32Value (UNIT_FIELD_DISPLAYID, GetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID));
				if (caster != NULL)
					AddHate (caster, 1.0f);
			}
		}
		if (parent->GetId() == 851) {
			if (apply) {
				//((Modifier *)mod)->SetValue1 (GetUInt32Value (UNIT_FIELD_DISPLAYID));
				SetUInt32Value (UNIT_FIELD_DISPLAYID, 856);
			} else {
				SetUInt32Value (UNIT_FIELD_DISPLAYID, GetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID));
				if (caster != NULL)
					AddHate (caster, 1.0f);
			}
		}
		if (parent->GetId() == 4060) {
			if (apply) {
				//((Modifier *)mod)->SetValue1 (GetUInt32Value (UNIT_FIELD_DISPLAYID));
				SetUInt32Value (UNIT_FIELD_DISPLAYID, 131);
			} else {
				SetUInt32Value (UNIT_FIELD_DISPLAYID, GetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID));
				if (caster != NULL)
					AddHate (caster, 1.0f);
			}
		}
		if (parent->GetId() == 5254) {
			if (apply) {
				//((Modifier *)mod)->SetValue1 (GetUInt32Value (UNIT_FIELD_DISPLAYID));
				SetUInt32Value (UNIT_FIELD_DISPLAYID, 856);
			} else {
				SetUInt32Value (UNIT_FIELD_DISPLAYID, GetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID));
				if (caster != NULL)
					AddHate (caster, 1.0f);
			}
		}
		if (parent->GetId() == 12824) {
			if (apply) {
				//((Modifier *)mod)->SetValue1 (GetUInt32Value (UNIT_FIELD_DISPLAYID));
				SetUInt32Value (UNIT_FIELD_DISPLAYID, 856);
			} else {
				SetUInt32Value (UNIT_FIELD_DISPLAYID, GetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID));
				if (caster != NULL)
					AddHate (caster, 1.0f);
			}
		}
		if (parent->GetId() == 12825) {
			if (apply) {
				//((Modifier *)mod)->SetValue1 (GetUInt32Value (UNIT_FIELD_DISPLAYID));
				SetUInt32Value (UNIT_FIELD_DISPLAYID, 856);
			} else {
				SetUInt32Value (UNIT_FIELD_DISPLAYID, GetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID));
				if (caster != NULL)
					AddHate (caster, 1.0f);
			}
		}
		if (parent->GetId() == 12826) {
			if (apply) {
				//((Modifier *)mod)->SetValue1 (GetUInt32Value (UNIT_FIELD_DISPLAYID));
				SetUInt32Value (UNIT_FIELD_DISPLAYID, 856);
			} else {
				SetUInt32Value (UNIT_FIELD_DISPLAYID, GetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID));
				if (caster != NULL)
					AddHate (caster, 1.0f);
			}
		}
		if (parent->GetId() == 13323) {
			if (apply) {
				//((Modifier *)mod)->SetValue1 (GetUInt32Value (UNIT_FIELD_DISPLAYID));
				SetUInt32Value (UNIT_FIELD_DISPLAYID, 856);
			} else {
				SetUInt32Value (UNIT_FIELD_DISPLAYID, GetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID));
				if (caster != NULL)
					AddHate (caster, 1.0f);
			}
		}
		if (parent->GetId() == 15534) {
			if (apply) {
				//((Modifier *)mod)->SetValue1 (GetUInt32Value (UNIT_FIELD_DISPLAYID));
				SetUInt32Value (UNIT_FIELD_DISPLAYID, 856);
			} else {
				SetUInt32Value (UNIT_FIELD_DISPLAYID, GetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID));
				if (caster != NULL)
					AddHate (caster, 1.0f);
			}
		}
		if (parent->GetId() == 17738) {
			if (apply) {
				//((Modifier *)mod)->SetValue1 (GetUInt32Value (UNIT_FIELD_DISPLAYID));
				SetUInt32Value (UNIT_FIELD_DISPLAYID, 1141);
			} else {
				SetUInt32Value (UNIT_FIELD_DISPLAYID, GetUInt32Value(UNIT_FIELD_NATIVEDISPLAYID));
				if (caster != NULL)
					AddHate (caster, 1.0f);
			}
		}
		break; }

	case SPELL_AURA_MOD_SPELL_CRIT_CHANCE: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_SPELL_CRIT_CHANCE");
		break; }

	case SPELL_AURA_MOD_INCREASE_SWIM_SPEED: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_INCREASE_SWIM_SPEED");
		break; }

	case SPELL_AURA_MOD_DAMAGE_DONE_CREATURE: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_DAMAGE_DONE_CREATURE");
		break; }

	case SPELL_AURA_MOD_CHARM: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_CHARM");
		break; }

	case SPELL_AURA_MOD_PACIFY_SILENCE: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_PACIFY_SILENCE");
		break; }

	case SPELL_AURA_MOD_SCALE: {
			float current = GetFloatValue(OBJECT_FIELD_SCALE_X);
			apply ? SetFloatValue(OBJECT_FIELD_SCALE_X,current+current/100*10) : SetFloatValue(OBJECT_FIELD_SCALE_X,current-current/110*100);
			break; }

	case SPELL_AURA_PERIODIC_HEALTH_FUNNEL: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_PERIODIC_HEALTH_FUNNEL");
		break; }

	case SPELL_AURA_PERIODIC_MANA_FUNNEL: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_PERIODIC_MANA_FUNNEL");
		break; }

	case SPELL_AURA_PERIODIC_MANA_LEECH: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_PERIODIC_MANA_LEECH");
		break; }

	case SPELL_AURA_MOD_CASTING_SPEED: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_CASTING_SPEED");
		break; }

	case SPELL_AURA_FEIGN_DEATH: {
			Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_FEIGN_DEATH");
			break; }

	case SPELL_AURA_MOD_DISARM: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_DISARM");
		break; }

	case SPELL_AURA_MOD_STALKED: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_STALKED");
		break; }

	case SPELL_AURA_SCHOOL_ABSORB: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_SCHOOL_ABSORB");
		break; }

	case SPELL_AURA_MOD_FEAR: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_FEAR");
		break; }

	case SPELL_AURA_EXTRA_ATTACKS: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_EXTRA_ATTACKS");
		break; }

	case SPELL_AURA_MOD_SPELL_CRIT_CHANCE_SCHOOL: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_SPELL_CRIT_CHANCE_SCHOOL");
		break; }

	case SPELL_AURA_MOD_POWER_COST: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_POWER_COST");
		break; }

	case SPELL_AURA_MOD_POWER_COST_SCHOOL: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_POWER_COST_SCHOOL");
		break; }

	case SPELL_AURA_REFLECT_SPELLS_SCHOOL: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_REFLECT_SPELLS_SCHOOL");
		break; }

	case SPELL_AURA_MOD_LANGUAGE: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_LANGUAGE");
		break; }

	case SPELL_AURA_FAR_SIGHT: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_FAR_SIGHT");
		break; }

	case SPELL_AURA_MECHANIC_IMMUNITY: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MECHANIC_IMMUNITY");
		break; }

	case SPELL_AURA_MOUNTED: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOUNTED");
		break; }

	case SPELL_AURA_MOD_DAMAGE_PERCENT_DONE: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_DAMAGE_PERCENT_DONE");
		break; }

	case SPELL_AURA_PERIODIC_HEAL: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_PERIODIC_HEAL");
		break; }

	case SPELL_AURA_MOD_PERCENT_STAT: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_PERCENT_STAT");
		break; }

	case SPELL_AURA_SPLIT_DAMAGE: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_SPLIT_DAMAGE");
		break; }

	case SPELL_AURA_WATER_BREATHING: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_WATER_BREATHING");
		break; }

	case SPELL_AURA_MOD_BASE_RESISTANCE: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_BASE_RESISTANCE");
		break; }

	case SPELL_AURA_MOD_REGEN: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_REGEN");
		break; }

	case SPELL_AURA_MOD_POWER_REGEN: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_POWER_REGEN");
		break; }

	case SPELL_AURA_CHANNEL_DEATH_ITEM: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_CHANNEL_DEATH_ITEM");
		break; }

	case SPELL_AURA_MOD_DAMAGE_PERCENT_TAKEN: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_DAMAGE_PERCENT_TAKEN");
		break; }

	case SPELL_AURA_MOD_PERCENT_REGEN: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_PERCENT_REGEN");
		break; }

	case SPELL_AURA_PERIODIC_DAMAGE_PERCENT: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_PERIODIC_DAMAGE_PERCENT");
		break; }

	case SPELL_AURA_MOD_ATTACKSPEED: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_ATTACKSPEED");
		break; }

	case SPELL_AURA_MOD_RESIST_CHANCE: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_RESIST_CHANCE");
		break; }

	case SPELL_AURA_MOD_DETECT_RANGE: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_DETECT_RANGE");
		break; }

	case SPELL_AURA_PREVENTS_FLEEING: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_PREVENTS_FLEEING");
		break; }

	case SPELL_AURA_MOD_UNATTACKABLE: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_UNATTACKABLE");
		break; }

	case SPELL_AURA_INTERRUPT_REGEN: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_INTERRUPT_REGEN");
		break; }

	case SPELL_AURA_GHOST: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_GHOST");
		break; }

	case SPELL_AURA_SPELL_MAGNET: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_SPELL_MAGNET");
		break; }

	case SPELL_AURA_MANA_SHIELD: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MANA_SHIELD");
		break; }

	case SPELL_AURA_MOD_SKILL_TALENT: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_SKILL_TALENT");
		break; }

	case SPELL_AURA_MOD_ATTACK_POWER: {
		Log::getSingleton().outDebug ("ApplyModifier: Unsupported SPELL_AURA_MOD_ATTACK_POWER");
		break; }

	default: {
		Log::getSingleton().outError("Unknown affect id %u", (uint32)mod->GetType());
			 }
	}
}

//--- END ---
