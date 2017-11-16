#include "stdafx.h"
#include "DynamicObject.h"
#include "EventManager.h"
#include "Spell.h"
#include "UpdateBlock.h"
CDynamicObject::CDynamicObject(void):CWoWObject(OBJ_DYNAMICOBJECT),CUpdateObject(DYNAMICOBJECT_END)
{
	Clear();
	CWoWObject::New();
	EventsEligible = true;
	this->ClearTargets();
	elapsed =0;
}

CDynamicObject::~CDynamicObject(void)
{
}
bool CDynamicObject::CanBeHurt(CWoWObject *target)
{
	if(target->type==OBJ_PLAYER)
	{
		if(((CPlayer*)target)->FTeam!=((CPlayer*)caster)->FTeam)
			return true;
	}
	if(target->type==OBJ_CREATURE)
	{
		if(DBCManager.FactionTemplate.getValue(((CPlayer*)caster)->FFaction,4)!=
			DBCManager.FactionTemplate.getValue(((CCreature*)target)->pTemplate->Data.Faction,4))
			return true;
	}
	return false;
}
void CDynamicObject::Add(_Location Loc,CWoWObject *pCaster,CSpell *pSpell,unsigned long Effect)
{
	spell = pSpell;
	caster = pCaster;
	Data.loc = Loc;
	DBCManager.SpellRadius.getValue(pSpell->SpellInfo.EffectRadiusIndex[Effect],1,Data.Radius);
	Data.SpellID = pSpell->SpellID;Data.Effect = Effect;
	RegionManager.ObjectNew(*this,((CPlayer*)pCaster)->Data.Continent,Data.loc.X,Data.loc.Y);
}

unsigned long CDynamicObject::GetDynamicObjectInfoData(char *buffer, bool Create)
{
#define Add(datatype,data) *(datatype*)&buffer[c]=data;c+=sizeof(datatype);
#define Skip(n) c+=n;
#define Fill(size,value) memset(&buffer[c],value,size);c+=size;
	unsigned long c=0;
	// HEADER: 0x50, 0x0
	Skip(Packets::PackGuidBuffer(buffer,guid,GAMEOBJECTGUID_HIGH));
	/*
	Add(unsigned char, 0xFF);
	Add(unsigned long, guid);
	Add(unsigned long, GAMEOBJECTGUID_HIGH);
	*/
	Add(unsigned char,ID_DYNAMICOBJECT);
	Add(unsigned char,(TBC?0x58:0x50));
	Add(_Location,Data.loc);
	Add(float,0);
#if TBC
		Add(unsigned long, guid);
		Add(unsigned long, GAMEOBJECTGUID_HIGH);
#else
		Add(unsigned long, (unsigned long)0x6282A48C);
#endif

#undef Fill
#undef Add
#undef Skip

	CUpdateBlock block(&buffer[c], DYNAMICOBJECT_END);
	block.Add(OBJECT_FIELD_GUID, guid, GAMEOBJECTGUID_HIGH);
	block.Add(OBJECT_FIELD_TYPE, HIER_TYPE_DYNAMICOBJECT);
	block.Add(OBJECT_FIELD_ENTRY,Data.SpellID);
	block.Add(OBJECT_FIELD_SCALE_X, 1.0f);
	block.Add(DYNAMICOBJECT_CASTER,caster->guid,0x00000);
	block.Add(DYNAMICOBJECT_BYTES,0xeeeeee01);
	block.Add(DYNAMICOBJECT_SPELLID,Data.SpellID);
	block.Add(DYNAMICOBJECT_RADIUS,Data.Radius);
	block.Add(DYNAMICOBJECT_POS_X,Data.loc.X);
	block.Add(DYNAMICOBJECT_POS_Y,Data.loc.Y);
	block.Add(DYNAMICOBJECT_POS_Z,Data.loc.Z);
	block.Add(DYNAMICOBJECT_PAD,0xEEEEEEEE);
	return block.GetSize() + c;
}
void CDynamicObject::Remove()
{
	RegionManager.ObjectRemove(*this);
}
void CDynamicObject::AddPeriodicAreaDmg(unsigned long freq,short count)
{
	Data.Freq = freq;Data.count=count;
	EventManager.AddEvent(*this,freq,DYNOBJ_AREA_DOT,0,0);
}
void CDynamicObject::ClearTargets()
{
	for(int i=0;i<200;i++) TargetMap[i]=NULL;
}
void CDynamicObject::ProcessEvent(struct WoWEvent &Event)
{
	switch(Event.EventType)
	{
	case DYNOBJ_AREA_DOT:
		{
			elapsed++;
			spell->TargetCount=GetTargets(Data.loc);
			for(int i=0;i<200;i++)
			{
				if(TargetMap[i]&&!(TargetMap[i]->dead))
				{
					if(TargetMap[i]->type==OBJ_PLAYER&&(((CPlayer*)TargetMap[i])->Distance(Data.loc)<Data.Radius))
					{ unsigned long power = spell->getPower(Data.SpellID,Data.Effect);
						((CPlayer*)TargetMap[i])->TakeDamage(((CCreature*)caster),power,true);
						((CPlayer*)TargetMap[i])->SendPeriodicLog(power,Data.SpellID,0x3,spell->SpellInfo.School,caster,TargetMap[i]);
					}
					else if(TargetMap[i]->type==OBJ_CREATURE&&(((CCreature*)TargetMap[i])->Distance(Data.loc)<Data.Radius))
					{
						unsigned long power = spell->getPower(Data.SpellID,Data.Effect);
						((CCreature*)TargetMap[i])->TakeDamage(caster,spell->getPower(Data.SpellID,Data.Effect),true);
						((CCreature*)TargetMap[i])->SendPeriodicLog(power,Data.SpellID,0x3,spell->SpellInfo.School,caster,TargetMap[i]);
					}
				}
			}
			if(elapsed<Data.count+1)
			{
				EventManager.AddEvent(*this,Data.Freq,DYNOBJ_AREA_DOT, 0,0);
			}
			else
			{
				((CPlayer*)caster)->StopChannel(Data.SpellID);
				Remove();
			}
		}
		break;
	}
}

int CDynamicObject::GetTargets(_Location &Loc)
{
	int c=0;

	CRegion *pPlayerRegion=RegionManager.ObjectRegions[guid];
	if(!pPlayerRegion) return 0;
	for (int i = 0 ; i < 3 ; i++)
	{
		for (int j = 0 ; j < 3 ; j++)
		{
			if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
			{
				RegionObjectNode *pNode=pRegion->pList;
				while(pNode)
				{
					if(pNode->pObject->guid != caster->guid)
					{
						if(pNode->pObject->type==OBJ_PLAYER && CanBeHurt(((CPlayer *)pNode->pObject)))
						{
							if (((CPlayer *)pNode->pObject)->Distance(Loc) < Data.Radius)
								{
									TargetMap[c] = pNode->pObject;
									c+=1;
								}
						}
						if(pNode->pObject->type==OBJ_CREATURE && CanBeHurt(((CCreature *)pNode->pObject)))
						{
							if (((CCreature *)pNode->pObject)->Distance(Loc) < Data.Radius)
							{
								TargetMap[c] = pNode->pObject;
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
void CDynamicObject::SendSpellGo()
{
	unsigned short flag;
	int c = 0;

	if (spell->TargetFlag == 2)
		flag = 0;
	else
		flag = spell->TargetFlag;

	CPacket pkg;
	pkg.Reset(SMSG_SPELL_GO);
	Packets::PackGuid(pkg,caster->guid,PLAYERGUID_HIGH);
	Packets::PackGuid(pkg,caster->guid,PLAYERGUID_HIGH);
	pkg << (unsigned long)Data.SpellID;
	pkg << (unsigned short)0x0500;
	pkg << (unsigned char)spell->TargetCount;
	for (int i=0; i<spell->TargetCount; i++)
	{
		if (TargetMap[i])
		{
			pkg << (unsigned long)TargetMap[i]->guid;
			pkg << (unsigned long)CREATUREGUID_HIGH;
		}
	}
	pkg << (unsigned char)0;
	pkg << (unsigned short)spell->TargetFlag;

	switch(spell->TargetFlag)
	{
	case TARGET_FLAG_SELF:
		{
			pkg << (unsigned long)spell->Target;
			pkg << (unsigned long)0;
		}
		break;
	case TARGET_FLAG_UNIT:
		{
			pkg << (unsigned long)spell->Target;
			pkg << (unsigned long)0;
		}
		break;
	case TARGET_FLAG_OBJECT :
		{
			pkg << (unsigned long)spell->Target;
			pkg << (unsigned long)0;
		}
		break;
	case TARGET_FLAG_ITEM :
		{
			pkg << (unsigned long)spell->Target;
			pkg << (unsigned long)0;
		}
		break;
	case TARGET_FLAG_SOURCE_LOCATION :
		{
			pkg<<(float)Data.loc.X;
			pkg<<(float)Data.loc.Y;
			pkg<<(float)Data.loc.Z;
		}
		break;
	case TARGET_FLAG_DEST_LOCATION :
		{
			pkg<<(float)Data.loc.X;
			pkg<<(float)Data.loc.Y;
			pkg<<(float)Data.loc.Z;
		}
		break;
	case TARGET_FLAG_STRING :
		{
			return;	//TODO: ADD SUPPORT, unknown type.
		}
	default :
		{
			return; // Unknown flag, attempt not to crash the client...
		}
	}

	Packets::SendRegion(pkg,this);
	return;
}
