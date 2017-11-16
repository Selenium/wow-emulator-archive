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
#include "GameObject.h"
#include "DynamicObject.h"
#include "Event.h"
void CSpellHandler::MsgCastSpell(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long SpellID;
	unsigned short TargetFlag;
	Data >> SpellID;
	Data >> TargetFlag;
	CSpell *pSpell = new CSpell(SpellID);
	pSpell->New();
	pSpell->SpellID = SpellID;
	pSpell->TargetFlag = TargetFlag;
	pSpell->Caster = pClient->pPlayer->guid;
	pSpell->pClient = pClient;
	pSpell->CastTime = DBCManager.SpellCast.getValue(pSpell->SpellInfo.CastingTimeIndex, 1);
	if((pSpell->SpellInfo.Effect[0]==17||pSpell->SpellInfo.Effect[1]==17||pSpell->SpellInfo.Effect[2]==17)&&pSpell->CastTime==0)
	{
		pClient->pPlayer->AddNextAttackSpell(pSpell,&Data);return;
	}
	pSpell->CastSpellStart(Data);
}

void CSpellHandler::MsgCancelCast(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	if(pClient->pPlayer->pCurrentSpell)
	{
		pClient->pPlayer->pCurrentSpell->Cancel();
	}
}

void CSpellHandler::MsgUseItem(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	char temp1;
	char temp2;
	char slot;
	unsigned long guid;
	CItem *tItem = NULL;

	Data >> temp1 >> slot >> temp2;


//	guid = pClient->pPlayer->Data.Items[slot];
	guid = pClient->pPlayer->Data.Items[slot]->guid;
	if(!DataManager.RetrieveObject((CWoWObject**)&tItem,OBJ_ITEM,guid))
		return;

	CSpell *pSpell = new CSpell(tItem->pTemplateData->SpellStats[0].ID);
	pSpell->New();
	DataManager.NewObject(*pSpell);
	pSpell->Caster = pClient->pPlayer->guid;
	pSpell->pClient = pClient;

	pSpell->SpellID = tItem->pTemplateData->SpellStats[0].ID;
	Data >> pSpell->TargetFlag;

	// Look up cast time
	pSpell->CastTime =DBCManager.SpellCast.getValue(pSpell->SpellInfo.CastingTimeIndex, 1);

	pSpell->CastSpellStart(Data);

	/*
	if (tItem->pTemplateData->Class == 15)
	{
		if (pClient->pPlayer->Data.MountModel > 0)
		{
			pClient->pPlayer->SetAura(0,0,0,0,0,0);
			pClient->pPlayer->DataObject.SetMountModel(0);
			pClient->pPlayer->SetSpeed(DEFAULT_PLAYER_RUN_SPEED);
			pClient->UpdateObject();
		}
		else
			pClient->pPlayer->SetSpeed(DEFAULT_PLAYER_RUN_SPEED*2);
	}
	else pClient->pDataObject->SetItem(slot,0);
	*/
}

void CSpellHandler::CmdLearnSpells(CClient *pClient)
{
	CPacket pkg(SMSG_LEARNED_SPELL); pkg << (unsigned long) 0x000A;	pClient->Send(&pkg); // Blizzard
	pkg.Reset(SMSG_LEARNED_SPELL); pkg << (unsigned long)0x0078; pClient->Send(&pkg); // Cone of Cold
	pkg.Reset(SMSG_LEARNED_SPELL); pkg << (unsigned long)0x0086; pClient->Send(&pkg); // Fire Shield
	pkg.Reset(SMSG_LEARNED_SPELL); pkg << (unsigned long)0x00CD; pClient->Send(&pkg); // Frostbolt
	pkg.Reset(SMSG_LEARNED_SPELL); pkg << (unsigned long)0x014C; pClient->Send(&pkg); // Healing Wave
	pkg.Reset(SMSG_LEARNED_SPELL); pkg << (unsigned long)0x0193; pClient->Send(&pkg); // Lightning Bolt
	pkg.Reset(SMSG_LEARNED_SPELL); pkg << (unsigned long)0x01BD; pClient->Send(&pkg); // Teleport Darkshire
	pkg.Reset(SMSG_LEARNED_SPELL); pkg << (unsigned long)0x1987; pClient->Send(&pkg); // Lightning Cloud
	pkg.Reset(SMSG_LEARNED_SPELL); pkg << (unsigned long)0x1c64; pClient->Send(&pkg); // Arcane Missile
	pkg.Reset(SMSG_LEARNED_SPELL); pkg << (unsigned long)0x1C66; pClient->Send(&pkg); // Arcane Missiles

	pClient->Echo("You have learned new spells");
}

long CSpellHandler::getPower(unsigned long spell, unsigned long effect)
{
	// long power = DBCManager.Spell.getValue(spell, DBC_SPELL_ATTRIBUTE(effect, SPELL_ATTRIB_POWER)) + 1;
	// long randomness = DBCManager.Spell.getValue(spell, DBC_SPELL_ATTRIBUTE(effect, SPELL_ATTRIB_RANDOMNESS));
	long power = 0;
	long randomness = 0;

	if (!randomness)
		randomness = 1;
	power = (power + (rand() % randomness));
	if (power > 25)
		return 25;
	else
		return power;
}

void CSpellHandler::HandleSpellEffects(CSpell *pSpell, CWoWObject *pObject, CWoWObject *pCaster)
{
	unsigned long SpellID=pSpell->SpellID;
	if(pCaster->type == OBJ_PLAYER)	// cooldowns xD
	{
		CPacket pkg1;
		pkg1.Reset(SMSG_SPELL_COOLDOWN);
		Packets::PackGuid(pkg1,pCaster->guid,PLAYERGUID_HIGH);
		//pkg1 << (unsigned char)0xFF << pCaster->guid << PLAYERGUID_HIGH;
		pkg1 << (unsigned long)SpellID;
		if (pSpell->SpellInfo.RecoveryTime > 0)
		{
			pkg1 << (unsigned long)pSpell->SpellInfo.RecoveryTime*100;
			if (((CPlayer*)pCaster)->pClient) ((CPlayer*)pCaster)->pClient->Send(&pkg1);
		}
	}
	int Effect;
	for(Effect=0;Effect<3;Effect++)
	{
		unsigned long EffectID = pSpell->SpellInfo.Effect[Effect];

		switch(EffectID)
		{
		case SPELL_EFFECT_APPLY_AREA_AURA:
			{float radius;
			DBCManager.SpellRadius.getValue(pSpell->SpellInfo.EffectRadiusIndex[Effect],1,radius);
			long time = DBCManager.SpellDuration.getValue(pSpell->SpellInfo.DurationIndex,DBC_SPELLDURATION_MAXTIME);
			long periodicity =pSpell->SpellInfo.EffectAmplitude[Effect];
			((CPlayer*)pCaster)->StartChannel(SpellID,time,pCaster->guid);
			AuraEvent *even = new AuraEvent();
			even->SetEventData(SpellID,pSpell->getPower(SpellID,Effect),EffectID,pSpell->SpellInfo.School,pCaster,NULL,time/periodicity,periodicity,-1,radius,pSpell);
			EventManager.AddEvent(*even,periodicity,AURA_AREA_EVENT_HOT,0,0);
			}break;
		case SPELL_EFFECT_PERSISTENT_AREA_AURA:
			{
			if(pSpell->SpellInfo.EffectApplyAuraName[Effect]==0x3)
			{
			long time = DBCManager.SpellDuration.getValue(pSpell->SpellInfo.DurationIndex,DBC_SPELLDURATION_MAXTIME);
			long periodicity =pSpell->SpellInfo.EffectAmplitude[Effect];
			CDynamicObject *dO = new CDynamicObject();
			dO->Add(pSpell->DestLoc,pCaster,pSpell,Effect);
			dO->AddPeriodicAreaDmg(periodicity,time/periodicity);
			((CPlayer*)pCaster)->StartChannel(SpellID,time,dO->guid);
			}
			}break;
		case SPELL_EFFECT_ADDITIONAL_DMG:
			{
				long diff = long(((CPlayer*)pCaster)->Data.DamageMax - ((CPlayer*)pCaster)->Data.DamageMin);
				long rv;
				if (diff)
					rv = (long)(((CPlayer*)pCaster)->Data.DamageMin + (rand() % diff));
				else
					rv = (long)((CPlayer*)pCaster)->Data.DamageMin;
				long dmg= rv+((CPlayer*)pCaster)->AttackPowerBonus()+pSpell->getPower(SpellID,Effect);
				if (pObject->type == OBJ_PLAYER)
				{
					((CPlayer*)pObject)->sendSpellMsg(dmg,SpellID,false);
					((CPlayer*)pObject)->TakeDamage(((CCreature*)pCaster),dmg,true);
				}
				if (pObject->type == OBJ_CREATURE)
				{
					((CCreature*)pObject)->sendSpellMsg(dmg,SpellID,false);
					((CCreature*)pObject)->TakeDamage(((CPlayer*)pCaster),dmg,true);
				}
			}
			break;
		case SPELL_EFFECT_ADD_COMBO_POINTS:
			{
				((CPlayer*)pCaster)->AddComboPt(pObject);
			}break;
		case SPELL_EFFECT_SUMMON_OBJECT:
			{
				unsigned long id=((pSpell->SpellInfo.EffectMiscValue[Effect]<<8)|0x13);
				CGameObject *go = new CGameObject;
				go->New(id);
			}
			break;
		case SPELL_EFFECT_TELEPORT:
			{			
				switch(pSpell->SpellInfo.Id)
				{
				case 8690: // Hearthstone
					{
						((CPlayer*)pCaster)->Data.Loc = ((CPlayer*)pCaster)->Data.BindLoc;
						((CPlayer*)pCaster)->Data.Zone = ((CPlayer*)pCaster)->Data.BindZone;
						Packets::TeleportOrNewWorld(((CPlayer*)pCaster)->pClient,((CPlayer*)pCaster)->Data.BindContinent);
					}
					break;
				}
			}
			break;
		case SPELL_EFFECT_DUEL:
			{
				((CPlayer*)pCaster)->DuelPrepare(pObject->guid);
			}
			break;
		case SPELL_EFFECT_WEAPON_DAMAGE:
			{
				if (pObject)
				{
					long diff = long(((CPlayer*)pCaster)->Data.DamageMax - ((CPlayer*)pCaster)->Data.DamageMin);
					long rv;
					if (diff)
						rv = (long)(((CPlayer*)pCaster)->Data.DamageMin + (rand() % diff));
					else
						rv = (long)((CPlayer*)pCaster)->Data.DamageMin;
					pSpell->NextAttackBaseDmg=rv;
					long dmg= pSpell->NextAttackBaseDmg+((CPlayer*)pCaster)->AttackPowerBonus()+pSpell->getPower(SpellID,Effect);
					if (pObject->type == OBJ_PLAYER)
					{
						((CPlayer*)pObject)->sendSpellMsg(dmg,SpellID,false);
						((CPlayer*)pObject)->TakeDamage(((CCreature*)pCaster),dmg,true);
					}
					if (pObject->type == OBJ_CREATURE)
					{
						((CCreature*)pObject)->sendSpellMsg(dmg,SpellID,false);
						((CCreature*)pObject)->TakeDamage(((CPlayer*)pCaster),dmg,true);
					}
				}
			}
			break;
		case SPELL_EFFECT_INSTAKILL:
			{
				// Instakill.. does this ever get used?
			}
			break;
		case SPELL_EFFECT_SCHOOL_DAMAGE:
			{
				// School damage
				long power = pSpell->getPower(SpellID, Effect);
				//long type = pSpell->SpellInfo.EffectImplicitTargetA[Effect];
				//long aura = pSpell->SpellInfo.EffectApplyAuraName[Effect];
				if(pSpell->SpellInfo.EffectPointsPerComboPoint[Effect]>0)
				{
					power=pSpell->getComboPower(SpellID,Effect,((CPlayer*)pCaster)->combo.pts);
					((CPlayer*)pCaster)->ResetCombo();
				}
				// Direct damage
				if (pObject->type == OBJ_PLAYER)
				{
					((CPlayer*)pObject)->sendSpellMsg(power,SpellID,false);
					((CPlayer*)pObject)->TakeDamage(((CCreature*)pCaster), power,true);
				}
				if (pObject->type == OBJ_CREATURE)
				{
					((CCreature*)pObject)->sendSpellMsg(power,SpellID,false);
					((CCreature*)pObject)->TakeDamage(((CPlayer*)pCaster), power,true);
				}
			}
			break;
		case SPELL_EFFECT_AURA:
			{
				//Aura apply
				long power = pSpell->getPower(SpellID, Effect);
				long type = pSpell->SpellInfo.EffectImplicitTargetA[Effect];
				long aura = pSpell->SpellInfo.EffectApplyAuraName[Effect];
				long time = DBCManager.SpellDuration.getValue(pSpell->SpellInfo.DurationIndex,DBC_SPELLDURATION_MAXTIME);
				unsigned long AuraSlot=0xFFFFFFFF;
				bool pos=true;
				if(aura==3) pos = false;
				else if(pSpell->SpellInfo.EffectBasePoints[Effect]<0&&aura!=36) pos = false;
				if(!((Effect>0)&&pSpell->SpellInfo.Effect[Effect-1]==6)) // this keeps from applying an aura for
					//different effectz
					AuraSlot = AuraHandler::ApplyAura(pObject,SpellID,time,pos);

				AuraHandler::ApplyModifier(AuraSlot,aura,SpellID,true,Effect,power,time,type,pCaster,pObject);
				if(time>0)
				{
					if (pObject->type == OBJ_PLAYER)
						EventManager.AddEvent(*pObject,time,EVENT_PLAYER_REMOVE_AURA,&AuraSlot,sizeof(AuraSlot));
					if(pObject->type == OBJ_CREATURE)
						EventManager.AddEvent(*pObject,time,EVENT_CREATURE_REMOVE_AURA,&AuraSlot,sizeof(AuraSlot));
				}
			}
			break;
		case SPELL_EFFECT_HEAL:
			{
				// Heal
				long power = pSpell->getPower(SpellID,Effect);
				if(pObject->type == OBJ_PLAYER)
				{
					if(((CPlayer*)pObject)->Data.CurrentStats.HitPoints + power > ((CPlayer*)pObject)->Data.NormalStats.HitPoints)
						power = ((CPlayer*)pObject)->Data.NormalStats.HitPoints - ((CPlayer*)pObject)->Data.CurrentStats.HitPoints;
					((CPlayer*)pObject)->DataObject.AddHP(power);
					((CPlayer*)pObject)->UpdateObject();
					((CPlayer*)pObject)->SendSpellLog(pSpell->getPower(SpellID,Effect),pSpell->SpellID,EffectID,pCaster,pObject);
				}
			}
			break;
		case SPELL_EFFECT_INEBRIATE:
			if (pObject->type == OBJ_PLAYER)
			{
				long power=DBCManager.Spell.getValue(SpellID, DBC_SPELL_ATTRIBUTE(Effect, SPELL_ATTRIB_POWER));
				int State=power+((CPlayer*)pObject)->Data.DrunkState;
				if(State<0) State=0;
				else if(State>255) State=255;
				((CPlayer*)pObject)->DataObject.SetDrunkState(State); //get drunk
				((CPlayer*)pObject)->UpdateObject();
			}
			break;
		case SPELL_EFFECT_SUMMON_CRITTER:	// Summon pet (cat) I think? :S
			{
				// Summon model
				unsigned long ctguid = pSpell->SpellInfo.EffectMiscValue[Effect] | 0x08000000;
				CCreatureTemplate *pTemplate;
				unsigned long modelid;
				if (!DataManager.RetrieveObject((CWoWObject**)&pTemplate, OBJ_CREATURETEMPLATE, ctguid))
					modelid = 2409;
				else
					modelid = pTemplate->Data.Model;
				CCreature *pCreature;
				unsigned long cont=((CPlayer*)pCaster)->Data.Continent;
				_Location loc=((CPlayer*)pCaster)->Data.Loc;
				char petname[64];
				sprintf(petname,"%s's bitch",((CPlayer*)pCaster)->Data.Name);
				pCreature = new CCreature;
				pCreature->New(*pTemplate);
				pCreature->pTemplate=pTemplate;
				pCreature->bIsSummon = true;
				pCreature->summoner = ((CPlayer*)pCaster);
				// pCreature->Data.Level = ((CPlayer*)pCaster)->Data.Level;
				// pCreature->Data.NormalStats.HitPoints = 28+30*pCreature->Data.Level;
				// pCreature->Data.CurrentStats.HitPoints = 28+30*pCreature->Data.Level;
				// pCreature->DataObject.SetHP(28+30*pCreature->Data.Level);
				pCreature->Data.Continent=((CPlayer*)pCaster)->Data.Continent;
				pCreature->Data.Loc=((CPlayer*)pCaster)->Data.Loc;
				// pCreature->Data.Model=modelid;
				pCreature->Data.SpawnLoc=((CPlayer*)pCaster)->Data.Loc;
				pCreature->Data.SpawnFacing=((CPlayer*)pCaster)->Data.Facing;
				pCreature->Data.Facing=((CPlayer*)pCaster)->Data.Facing;

				// pCreature->Data.FactionTemplate = ((CPlayer*)pCaster)->FFaction;
				pCreature->Data.Summoner = ((CPlayer*)pCaster)->guid;
				pCreature->Data.SourceSpell = pSpell->SpellID;
				///pCreature->Data.NPCType=0;
				pCreature->bIsSummon = true;

				DataManager.NewObject(*pCreature);
				((CPlayer*)pCaster)->AddUpdateVal(UNIT_FIELD_SUMMON, pCreature->guid);
				((CPlayer*)pCaster)->AddUpdateVal(UNIT_FIELD_SUMMON+1,CREATUREGUID_HIGH);
				((CPlayer*)pCaster)->UpdateObject();
				((CPlayer*)pCaster)->SummonGuid = pCreature->guid;

				CPacket pkg;
				pkg.Reset(SMSG_PET_SPELLS);
				pkg << pCreature->guid << CREATUREGUID_HIGH << (unsigned long)0x00000000 << (unsigned long)0x00001000
					<< (unsigned long)0x07000002 << (unsigned long)0x07000001;
				pkg << (unsigned long)0x00000000 << (unsigned long)0x00000000
					<< (unsigned long)0x00000000 << (unsigned long)0x00000000;
				pkg << (unsigned long)0x07000000 << (unsigned long)0x06000002;
				pkg << (unsigned long)0x06000001 << (unsigned long)0x06000000;
				(((CPlayer*)pCaster)->pClient)->Send(&pkg);

				RegionManager.ObjectNew(*pCreature,cont,loc.X,loc.Y);
				unsigned long AuraSlot;
				if(pSpell->SpellInfo.EffectBasePoints[Effect]<0)
					AuraSlot = AuraHandler::ApplyAura(((CPlayer*)pCaster),SpellID,0,false);
				else AuraSlot = AuraHandler::ApplyAura(((CPlayer*)pCaster),SpellID,0,true);
			}
			break;
		}
	}
}
