// (c) AbyssX Group
#include "../WorldEnvironment.h"

#define PI 3.14159265

// Constructor: Mob.
Mob::Mob(QuadWord objectGuid, const char *name) : Unit(objectGuid, name)
{
}

void Respawn(void *Param) 
{ 
	Mob *mob;
	mob = (Mob *)Param;
	mob->RespawnMOB();
}

void Mob::RespawnMOB()
{
	Packet pack;
	RegionList regionList;
	RegionList::RegionListIterator i;
	Region::PlayerIterator j;
	Player *p;

	SetDeadState(false);
	SetHealth(GetMaximumHealth());
	SetStandState(0x00);
	SetDynamicFlags(0x00);

	Packets::NewObjectHeader(this,&pack);
	Packets::NewObjectData(this,&pack);

	regionList = GetCurrentRegionList();
	
	for (i = regionList.Begin(); i != regionList.End(); i++)
	{
		for (j = (*i)->PlayerBegin(); j != (*i)->PlayerEnd(); j++)
		{
			p = (Player *) *j;
			if (!p->GetClient())
				continue;
			WorldServer::GetSingleton().WriteData(p->GetClient(), &pack);
		}
	}

}

void Mob::Death(Player *ply)
{
	Packet retpack;
	ObjectUpdate objupd;

	SetHealth(0);
	SetDeadState(true);

	SetStandState(0x07);
	SetUnitFlags(0xE0000);
	SetDynamicFlags(1);

	SetMoney(1 + ((rand() % 10) * ply->GetLevel()));

	Packets::UpdateObjectHeader(this, &retpack);
	
	objupd.Clear();
	objupd.Touch(ObjectUpdate::UPDOBJECT);
	objupd.Touch(ObjectUpdate::UPDUNIT);
	
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_BYTES_1,
	((DoubleWord)0x00              << 24) |
	((DoubleWord)0x00              << 16) |
	((DoubleWord)0x00              <<  8) |
	((DoubleWord)GetStandState() <<  0));

	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_DYNAMIC_FLAGS, GetDynamicFlags());
	objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_FLAGS, GetUnitFlags());
	
	retpack.AddObjectUpdate(&objupd);

	WorldServer::GetSingleton().SendToPlayersInRange(&retpack, ply);

#ifdef EVENTSYSTEM
	EventSystem::GetSingleton().AddTimer(60000,Respawn,(void *)this, OBJ_MONSTER, GetObjectGuid());
#endif
}

DoubleWord Mob::FollowPlayer(Player *ply)
{
	Packet movepak;
	DoubleWord TIME = 1250;
    
	if (MonsterHandler::GetSingleton().DistBetween(ply,this) > MAX_ATTACK_RANGE)
	{
		Float xChange = ply->GetXCoordinate()-GetXCoordinate();
		Float yChange = ply->GetYCoordinate()-GetYCoordinate();
		Float msecs = (sqrt((xChange*xChange)+(yChange*yChange))) * 1000 /(RUN_SPEED);
		TIME = ((DoubleWord)msecs);

		movepak.Build(SMSG_MONSTER_MOVE);
		movepak.AddQuadWord(GetObjectGuid());
		movepak.AddFloat(GetXCoordinate());
		movepak.AddFloat(GetYCoordinate());
		movepak.AddFloat(GetZCoordinate());
		movepak.AddFloat(GetFacing());
		movepak.AddDoubleWord(0x00);
		movepak.AddByte(0x00);
		movepak.AddDoubleWord(TIME);
		movepak.AddDoubleWord(1);
		movepak.AddFloat(ply->GetXCoordinate());
		movepak.AddFloat(ply->GetYCoordinate());
		movepak.AddFloat(ply->GetZCoordinate());
	
		SetXCoordinate(ply->GetXCoordinate());
		SetYCoordinate(ply->GetYCoordinate());
		SetZCoordinate(ply->GetZCoordinate());

		MonsterHandler::GetSingleton().UpdateRegion(this);
		WorldServer::GetSingleton().SendToPlayersInRange(&movepak, this);
	}

	return (TIME*2);		
}

void Mob::GetBack()
{
	Packet movepak;
	DoubleWord TIME = 0;
    
	if (!GetAttackState() && GetXCoordinate() != mCoordz.X && GetYCoordinate() != mCoordz.Y && GetZCoordinate() != mCoordz.Z && !GetDeadState())
	{
		Float xChange = GetXCoordinate()-mCoordz.X;
		Float yChange = GetYCoordinate()-mCoordz.Y;
		Float msecs = (sqrt((xChange*xChange)+(yChange*yChange))) * 1000 /(RUN_SPEED);
		TIME = ((DoubleWord)msecs);

		movepak.Build(SMSG_MONSTER_MOVE);
		movepak.AddQuadWord(GetObjectGuid());
		movepak.AddFloat(GetXCoordinate());
		movepak.AddFloat(GetYCoordinate());
		movepak.AddFloat(GetZCoordinate());
		movepak.AddFloat(GetFacing());
		movepak.AddDoubleWord(0x00);
		movepak.AddByte(0x00);
		movepak.AddDoubleWord(TIME);
		movepak.AddDoubleWord(1);
		movepak.AddFloat(mCoordz.X);
		movepak.AddFloat(mCoordz.Y);
		movepak.AddFloat(mCoordz.Z);
	
		SetXCoordinate(mCoordz.X);
		SetYCoordinate(mCoordz.Y);
		SetZCoordinate(mCoordz.Z);

		MonsterHandler::GetSingleton().UpdateRegion(this);
		WorldServer::GetSingleton().SendToPlayersInRange(&movepak, this);
	}
}