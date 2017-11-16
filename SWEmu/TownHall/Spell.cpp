#include "Spell.h"
#include "Defines.h"
#include "Globals.h"
#include "Player.h"
#include "Creature.h"
#include "SpellHandler.h"

/*//////////////////////////////////////////////*/
//												//
// UNDER CONSTRUCTION: Work in progress			//
//												//
/*//////////////////////////////////////////////*/

CSpell::CSpell(unsigned long SpellID):CWoWObject(OBJ_SPELL)
{
	DBCManager.Spell.fetchRow(SpellID,&SpellInfo);
}

CSpell::~CSpell(void)
{
	CWoWObject::Delete();
}

void CSpell::Clear()
{
	CWoWObject::Clear();
	memset(&SrcLoc,0,sizeof(_Location));
	memset(&DestLoc,0,sizeof(_Location));
	memset(&TargetMap,0,sizeof(TargetMap));
	Caster=CastTime=SpellID=Target=TargetType=TargetFlag=TargetCount=0;
}

void CSpell::New()
{
	Clear();
	CWoWObject::New();
	EventsEligible=true;
}

void CSpell::CastSpellStart(CDataBuffer &Data)
{
	SendStartSpell(Data);

	// TODO: change targetdata read, and move validation up.
	if(!ValidateAction())
	{
		Cancel();
		return;
	}
	pClient->pPlayer->pCurrentSpell = this;
	pClient->pPlayer->IsCasting = true;

	EventManager.AddEvent(*this,CastTime,EVENT_SPELL_CASTSPELL,0,0); // even if the cast time is 0
}

void CSpell::CastSpell()
{
	// long durationID = DBCManager.Spell.getValue(SpellID, DBC_SPELL_DURATION_ID);
	// long durationID = SpellInfo.DurationIndex;
	// long maxtime = DBCManager.SpellDuration.getValue(durationID, DBC_SPELLDURATION_MAXTIME);

	CWoWObject *pTarget = NULL;
	if(SpellInfo.ChannelInterruptFlags!=0) this->SendChannelStart();
	pClient->pPlayer->IsCasting = false;
	SendSpellResult();
	SendSpellGo();

	long mana = SpellInfo.manaCost;
	switch(pClient->pPlayer->Data.Class)
	{
	case CLASS_WARRIOR:
		pClient->pDataObject->AddRage(-mana);
		break;
	case CLASS_ROGUE:
		pClient->pDataObject->AddEnergy(-mana);
		break;
	case CLASS_MAGE:
	case CLASS_PRIEST:
	case CLASS_WARLOCK:
	case CLASS_DRUID:
	case CLASS_SHAMAN:
	case CLASS_HUNTER:
	case CLASS_PALADIN:
		pClient->pDataObject->AddMana(-mana);
		break;
	}

	pClient->UpdateObject();
	EventManager.AddEvent(*pClient->pPlayer,2000,EVENT_PLAYER_REGENERATE,0,0);
	// Take mana from the caster
	// pClient->pPlayer->UseMana(DMGTYPE_SPELL,SpellID);
	// pClient->pPlayer->AddUpdateVal(UNIT_FIELD_POWER1, pClient->pPlayer->Data.CurrentStats.Mana);
	// pClient->UpdateObject();
	if(TargetCount>0)
	for(int i=0; i<TargetCount; i++)
	{
		// Add delay if the spell needs time to travel to the target
		// TODO: Make this spell dependend
		//EventManager.AddEvent(*this,pClient->pPlayer->Distance(*pTarget)/20)*1000,EVENT_SPELL_EFFECTS,&TargetMap[i][0],sizeof(TargetMap[i][0]));
		SendSpellEffects(TargetMap[i].guid);
	}
	else SendSpellEffects(0);

	// add in later for lasting spells
	// if(maxtime > 200000)
	// 	EventManager.AddEvent(*this, maxtime/1000,EVENT_SPELL_CANCEL,0,0);
	// else
	//	EventManager.AddEvent(*this,2000,EVENT_SPELL_CANCEL,0,0);

	//Delete();
}

void CSpell::SendStartSpell(CDataBuffer &Data)
{
	//CWoWObject *pTarget = NULL;
	CPacket pkg;
	pkg.Reset(SMSG_SPELL_START);
	/*
	pkg << (unsigned char)0xFF;
	pkg << (unsigned long)Caster;
	pkg << (unsigned long)PLAYERGUID_HIGH;
	pkg << (unsigned char)0xFF;
	pkg << (unsigned long)Caster;
	pkg << (unsigned long)PLAYERGUID_HIGH;
	*/
	Packets::PackGuid(pkg,Caster,PLAYERGUID_HIGH);
	Packets::PackGuid(pkg,Caster,PLAYERGUID_HIGH);
	pkg << (unsigned long)SpellID;
	pkg << (unsigned short)0x02;
	pkg << (unsigned long)CastTime;
	pkg << TargetFlag;

	switch(TargetFlag)
	{
	case TARGET_FLAG_SELF:
		{
			TargetMap[0].guid = Caster;
			TargetCount = 1;
			Packets::PackGuid(pkg,Caster,PLAYERGUID_HIGH);
			//pkg << (unsigned char)0xFF << (unsigned long)Caster << PLAYERGUID_HIGH;
		}
		break;
	case TARGET_FLAG_UNIT:
		{
			TargetMap[0].guid = Packets::ReadGuid(Data);
			TargetCount = 1;
			Packets::PackGuid(pkg,TargetMap[0].guid,CREATUREGUID_HIGH);
			//pkg << (unsigned char)0xFF << (unsigned long)TargetMap[0][0] << CREATUREGUID_HIGH;
		}
		break;
	case TARGET_FLAG_OBJECT :
		{
			Data >> Target;
			TargetMap[0].guid = Target;
			TargetCount = 1;
			Packets::PackGuid(pkg,Target,GAMEOBJECTGUID_HIGH);
			//pkg << (unsigned char)0xFF << (unsigned long)Target << PLAYERGUID_HIGH;
		}
		break;
	case TARGET_FLAG_ITEM :
		{
			Data >> Target;
			TargetMap[0].guid = Target;
			TargetMap[0].guidhigh = TargetType;
			TargetCount = 1;
			Packets::PackGuid(pkg,Target,ITEMGUID_HIGH);
			//pkg << (unsigned char)0xFF << (unsigned long)Target << PLAYERGUID_HIGH;
		}
		break;
	case TARGET_FLAG_SOURCE_LOCATION :
		{
			Data >> SrcLoc.X >> SrcLoc.Y >> SrcLoc.Z;
			TargetCount = GetTargets(SrcLoc); // dunno if this is correct, we'll find out though :P
			pkg << (float)SrcLoc.X;
			pkg << (float)SrcLoc.Y;
			pkg << (float)SrcLoc.Z;
		}
		break;
	case TARGET_FLAG_DEST_LOCATION :
		{
			Data >> DestLoc.X >> DestLoc.Y >> DestLoc.Z;
			TargetCount = GetTargets(DestLoc);
			pkg << (float)DestLoc.X;
			pkg << (float)DestLoc.Y;
			pkg << (float)DestLoc.Z;
		}
		break;
	case TARGET_FLAG_STRING :
		Debug.Log("SendSpellGo: Unsupported TARGET_FLAG_STRING");
		return;
	default :
		{
			Debug.Logf("Unsupported Target Flag 0x%04X",TargetFlag);
			return;
		}
	}
	pClient->Send(&pkg);
}

void CSpell::SendSpellResult()
{
	char buffer[5];
	memset(buffer,0,5);

	*(unsigned long*)&buffer[0]=SpellID;
	pClient->OutPacket(SMSG_CAST_RESULT,buffer,5);
}

void CSpell::SendSpellGo()
{
	unsigned short flag;
	int c = 0;

	if (TargetFlag == 2)
		flag = 0;
	else
		flag = TargetFlag;

	CPacket pkg;
	pkg.Reset(SMSG_SPELL_GO);
	/*
	pkg << (unsigned char)0xFF;
	pkg << (unsigned long)Caster;
	pkg << (unsigned long)PLAYERGUID_HIGH;
	pkg << (unsigned char)0xFF;
	pkg << (unsigned long)Caster;
	pkg << (unsigned long)PLAYERGUID_HIGH;
	*/
	Packets::PackGuid(pkg,Caster,PLAYERGUID_HIGH);
	Packets::PackGuid(pkg,Caster,PLAYERGUID_HIGH);
	pkg << (unsigned long)SpellID;

	pkg << (unsigned short)0;//0x0500;
	pkg << (unsigned char)TargetCount;

	// Write all target guid's
	for (int i=0; i<TargetCount; i++)
	{
		if (TargetMap[i].guid != 0)
		{
			pkg << (guid_t)TargetMap[i].guid;
			pkg << (guidhigh_t)CREATUREGUID_HIGH;
		}
	}
	pkg << (unsigned char)0;
	pkg << (unsigned short)TargetFlag;

	switch(TargetFlag)
	{
	case TARGET_FLAG_SELF:
		{
			Packets::PackGuid(pkg,Caster,PLAYERGUID_HIGH);
		}
		break;
	case TARGET_FLAG_UNIT:
		{
			Packets::PackGuid(pkg,Target,CREATUREGUID_HIGH);
		}
		break;
	case TARGET_FLAG_OBJECT :
		{
			Packets::PackGuid(pkg,Target,GAMEOBJECTGUID_HIGH);
		}
		break;
	case TARGET_FLAG_ITEM :
		{
			Packets::PackGuid(pkg,Target,ITEMGUID_HIGH);
		}
		break;
	case TARGET_FLAG_SOURCE_LOCATION :
		{
			pkg<<(float)SrcLoc.X;
			pkg<<(float)SrcLoc.Y;
			pkg<<(float)SrcLoc.Z;
		}
		break;
	case TARGET_FLAG_DEST_LOCATION :
		{
			pkg<<(float)DestLoc.X;
			pkg<<(float)DestLoc.Y;
			pkg<<(float)DestLoc.Z;
		}
		break;
	case TARGET_FLAG_STRING :
		Debug.Log("SendSpellGo: Unsupported TARGET_FLAG_STRING");
		return;
	default :
		{
			Debug.Logf("Unsupported Target Flag 0x%04X",TargetFlag);
			return; // Unknown flag, attempt not to crash the client...
		}
	}

	pClient->SendRegion(&pkg);
	return;
}

long CSpell::SendChannelStart()
{
	long maxtime = DBCManager.SpellDuration.getValue(SpellInfo.DurationIndex, DBC_SPELLDURATION_MAXTIME);
	if(TargetCount==1 && pCaster && pCaster->type==OBJ_PLAYER) ((CPlayer*)pCaster)->StartChannel(SpellID,maxtime,TargetMap[0].guid);
	return maxtime;
}

void CSpell::SendNonMeleeDamageLog(long damage)
{
	CPacket pkg(SMSG_SPELLNONMELEEDAMAGELOG);
	int school=SpellInfo.School;
	pkg << Target << TargetType;
	Packets::PackGuid(pkg,Caster,PLAYERGUID_HIGH);
	pkg << SpellID << damage << (char)school << (long)0 << (long)0;
	/*
	char buffer[36];
	memset(buffer,0,36);
	*(unsigned long*)&buffer[0]=Target;
	*(unsigned long*)&buffer[4]=TargetType;
	*(unsigned char*)&buffer[5]=0x0F; // temp fix (disables highguid)
	*(unsigned long*)&buffer[9]=Caster;
	*(unsigned long*)&buffer[13]=SpellID;
	*(unsigned long*)&buffer[17]= damage;
	*(unsigned char*)&buffer[21]= (char)school; //damage type
	*(unsigned long*)&buffer[22]= 0; //damage absorbed
	*(unsigned long*)&buffer[26]= 0; //damage resisted
	*/
	//pClient->OutPacket(SMSG_SPELLNONMELEEDAMAGELOG,buffer,36);
	//pClient->RegionOutPacket(SMSG_SPELLNONMELEEDAMAGELOG,buffer,32/*36*/);
	pClient->SendRegion(&pkg);
}

void CSpell::SendSpellEffects(guid_t target)
{
	CWoWObject *pTarget = NULL;
	DataManager.RetrieveObject(&pTarget,target);
	if(pTarget)
	{
		switch(pTarget->type)
		{
		case OBJ_PLAYER:
			{
				((CPlayer *)pTarget)->pCaster = pClient->pPlayer;
				CSpellHandler::HandleSpellEffects(this,pTarget,pClient->pPlayer);
			}
			break;
		case OBJ_CREATURE:
			{
				((CCreature *)pTarget)->pCaster = pClient->pPlayer;
				CSpellHandler::HandleSpellEffects(this,pTarget,pClient->pPlayer);
			}
		}
	}
	else CSpellHandler::HandleSpellEffects(this,pTarget,pClient->pPlayer);
}
void CSpell::SpellFail()
{
	SpellFail(SPELL_FAILED_FIZZLE);
}

void CSpell::SpellFail(unsigned char reason)
{
	CPacket pkg(SMSG_CAST_RESULT);
	pkg << (unsigned long)SpellID;
	pkg << (unsigned char)2;
	pkg << (unsigned char)reason;
	pClient->Send(&pkg);
}

void CSpell::SpellFail(unsigned char reason, char *msg)
{
	CPacket pkg(SMSG_CAST_RESULT);
	pkg << (unsigned long)SpellID;
	pkg << (unsigned char)2;
	pkg << (unsigned char)reason;
	pkg << msg;
	pClient->Send(&pkg);
}
void CSpell::Cancel()
{
	//	Debug.Logf("CSpell::Cancel");
	char buffer[4];
	memset(buffer,0,4);

	SpellFail(SPELL_FAILED_INTERRUPTED);
	pClient->OutPacket(MSG_CHANNEL_UPDATE,buffer,4);

	if (pClient->pPlayer && pClient->pPlayer->type==OBJ_PLAYER)
	{
		pClient->pPlayer->pCurrentSpell = NULL;
		pClient->pPlayer->IsCasting = false;
	}

	Delete();
}

void CSpell::ProcessEvent(WoWEvent &Event)
{
	if(!pClient->pPlayer) return;
	switch(Event.EventType)
	{
	case EVENT_SPELL_CASTSPELL:
		{
			CastSpell();
			break;
		}
	case EVENT_SPELL_CHANNEL:
		{
			SendSpellGo();
			break;
		}
	case EVENT_SPELL_CANCEL:
		{
			Cancel();
			break;
		}
	case EVENT_SPELL_EFFECTS:
		{
			unsigned long guid;
			memcpy(&guid, Event.pEventData, sizeof(guid));
			SendSpellEffects(guid);
		}
	}
}

long CSpell::getPower(unsigned long spell, unsigned long effect)
{
	long power = SpellInfo.EffectBasePoints[effect];
	long randomness = SpellInfo.EffectDieSides[effect];
	if (randomness<2) return power+randomness;
	else power = (power + (rand() % randomness));
	return power;
}
long CSpell::getComboPower(unsigned long spell, unsigned long effect,unsigned long combopts)
{
	long power = (long)ceilf(combopts*SpellInfo.EffectPointsPerComboPoint[effect])+SpellInfo.EffectBasePoints[effect];
	long randomness = SpellInfo.EffectDieSides[effect];
	if (randomness<2) return power+randomness;
	else power = (power + (rand() % randomness));
	return power;
}

bool CSpell::ValidateAction()
{
	return true;
	if (pClient->pPlayer->Data.ResurrectionSickness)
	{
		pClient->InterruptCast(SpellID);
		pClient->Echo("You can't attack while you have resurrection sickness...please wait");
		return false;
	}

	if (TargetFlag==TARGET_FLAG_UNIT)
	{
		CRegion *pRegion = RegionManager.ObjectRegions[Target];

		if (!pRegion)
		{
			return false;
		}
		if (pRegion->isDisabled) {
			pClient->InterruptCast(SpellID);
			pClient->Echo("This Region is disabled - no fighting will be allowed");
			return false;
		}

		if (!pClient->pPlayer->ValidateSpell(Target,SpellID)) {
			pClient->InterruptCast(SpellID);
			pClient->Echo("You do not have the knowledge to cast this spell or use this ability");
			return false;
		}
	}
	return true;
}

int CSpell::GetTargets(_Location &Loc)
{
	int c=0;
	float radius;
	short index =0;
	if(SpellInfo.Effect[0]==27) index=0;
	else if(SpellInfo.Effect[1]==27) index=1;
	else if(SpellInfo.Effect[2]==27) index=2;
	DBCManager.SpellRadius.getValue(SpellInfo.EffectRadiusIndex[index],1,radius);
	CRegion *pPlayerRegion=RegionManager.ObjectRegions[Caster];
	for (int i = 0 ; i < 3 ; i++)
	{
		for (int j = 0 ; j < 3 ; j++)
		{
			if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
			{
				RegionObjectNode *pNode=pRegion->pList;
				while(pNode)
				{
					if(pNode->pObject->guid != pClient->pPlayer->guid)
					{
						if(pNode->pObject->type==OBJ_PLAYER )
						{
							if (((CPlayer *)pNode->pObject)->Distance(Loc) < radius)
							{
								TargetMap[c].guid = pNode->pObject->guid;
								TargetMap[c].guidhigh = PLAYERGUID_HIGH;
								c+=1;
							}
						}
						if(pNode->pObject->type==OBJ_CREATURE)
						{
							if (((CCreature *)pNode->pObject)->Distance(Loc) < radius)
							{
								pNode->pObject->pCaster = pClient->pPlayer;
								TargetMap[c].guid = pNode->pObject->guid;
								TargetMap[c].guidhigh = CREATUREGUID_HIGH;
								c+=1;
							}
						}
					}
					pNode=pNode->pNext;
				}
			}
		}
	}
	return c;
}

void CSpell::SpellDelay(void)
{
	const UINT64 now = nowinms();
	if (!pEvents || !pEvents->pEvent || (pEvents->pEvent->EventTime < now)) return;     // damage taken after spell casted
	long timeelapsed = (long)(now + CastTime - pEvents->pEvent->EventTime);	// time elapsed from CastSpellStart
	long DelayTime = min(timeelapsed, (long)(CastTime >> 2));               // delay should be up to 25% of cast time
	EventManager.ChangeEventTime(pEvents->pEvent, DelayTime);
	//	pClient->Echo("Time delay %i", DelayTime); //debug info

	CPacket pkg(SMSG_SPELL_DELAYED);
	pkg << (unsigned long)Caster;
	pkg << (unsigned long)PLAYERGUID_HIGH;
	pkg << (unsigned long)DelayTime;
	pkg << (unsigned long)DelayTime;
	pClient->Send(&pkg);
}
