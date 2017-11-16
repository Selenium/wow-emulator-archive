#include "Creature.h"
#include "Globals.h"
#include "UpdateBlock.h"

CCreature::CCreature(void):CWoWObject(OBJ_CREATURE), CUpdateObject(UNIT_MAX_BITS)
{
}

CCreature::~CCreature(void)
{
//	RegionManager.ObjectRemove(*this);
	Delete();
}

void CCreature::Clear()
{
	CWoWObject::Clear();
	memset(&Data,0,sizeof(CreatureData));
	memset(&XP,0,sizeof(XP));
	bMoving = false;
	bAttacking = false;
	Test=0x03;
	dead = false;
}

void CCreature::Delete()
{
	RegionManager.ObjectRemove(*this);
	CWoWObject::Delete();
}

void CCreature::New(unsigned long nTemplate)
{
	Clear();
	CWoWObject::New();
	Data.Template=nTemplate;
	Data.Size=0x3F800000;
	EventsEligible=true;
}

void CCreature::New(CCreatureTemplate &NewTemplate)
{
	Clear();
	CWoWObject::New();
	EventsEligible=true;
	Data.Template=NewTemplate.guid;
	Data.Size=NewTemplate.Data.Size;
	Data.NormalStats=NewTemplate.Data.NormalStats;
	Data.CurrentStats=NewTemplate.Data.NormalStats;
	strcpy(Data.Name,NewTemplate.Data.Name);
	Data.DamageMax=NewTemplate.Data.DamageMax;
	Data.DamageMin=NewTemplate.Data.DamageMin;
	Data.Model=NewTemplate.Data.Model;
	Data.Level=NewTemplate.Data.Level;
	Data.Exp=NewTemplate.Data.Exp;
	Data.RegenPeriodicity=NewTemplate.Data.RegenPeriodicity;
	Data.RegenPerTick=NewTemplate.Data.RegenPerTick;
	Data.NPCType = 0;
	Data.FactionTemplate = 0x1F;
	// set up lootable items (TEMPLATES UNTIL LOOTED)
	//NewTemplate.Data.LootTable;

}

unsigned long CCreature::AddCreateObjectData(char *buffer)
{
#define Add(datatype,data) *(datatype*)&buffer[c]=data;c+=sizeof(datatype);
#define Fill(size,value) memset(&buffer[c],value,size);c+=size;
	unsigned long c=0;
	Add(unsigned long,guid);
	Add(unsigned long,CREATUREGUID_HIGH);
	Add(unsigned char,ID_UNIT);// "unit"
	Add(unsigned long, 0);
	Add(_Location,Data.Loc);
	Add(float,Data.Facing);
	Add(unsigned long,0x40200000);
	Add(unsigned long,0x41000000);
	Add(unsigned long,0x40971C72);
	Add(unsigned long,0x40490FDB);
	Add(unsigned long,0);
	Add(unsigned long,0x1);
	Add(unsigned long,0);
	Add(unsigned long,0);
	Add(unsigned long,0);
#undef Fill
#undef Add
	return c;
}

void CCreature::PreCreateObject()
{
	AddUpdateVal(OBJECT_GUID, guid);
	AddUpdateVal(OBJECT_GUID_HIGH, CREATUREGUID_HIGH);
	AddUpdateVal(OBJECT_HIER_TYPE, HIER_TYPE_UNIT); // 1 << UnitType(0x03) | 1 << ObjectType(0x00)
	AddUpdateVal(OBJECT_ENTRY, Data.Template);
	AddUpdateVal(OBJECT_SCALE, Data.Size);
	AddUpdateVal(UNIT_HEALTH, Data.CurrentStats.HitPoints);
	AddUpdateVal(UNIT_MAX_HEALTH, Data.NormalStats.HitPoints);
	AddUpdateVal(UNIT_LEVEL, Data.Level);
	AddUpdateVal(UNIT_FACTION, Data.FactionTemplate); // FactionTemplate
	AddUpdateVal(UNIT_BYTES_0, 0x20100);
	AddUpdateVal(UNIT_BASEATTACKTIME0, 0x7D0); // attack speed
	AddUpdateVal(UNIT_BASEATTACKTIME1, 0x7D0); // probably other hand attack speed
	AddUpdateVal(UNIT_DISPLAYID,Data.Model);
	AddUpdateVal(UNIT_NPC_FLAGS,Data.NPCType);
}

unsigned long CCreature::GetCreatureInfoData(char *buffer, bool Create)
{
#define Add(datatype,data) *(datatype*)&buffer[c]=data;c+=sizeof(datatype);
#define Skip(n) c+=n;
#define Fill(size,value) memset(&buffer[c],value,size);c+=size;
	int c=0;
	/*
	unsigned char buf[0xe3]={
 0x01,0x00,0x00,0x00,0x02
// id               |   more id...      |type|
,0xBA,0xDC,0x00,0x00,0x00,0x10,0x00,0xF0,0x03
,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00
//                  |                   |                   |
,0x88,0x0A,0xD2,0x44,0x78,0xD3,0xC5,0x44,0x13,0x7B,0xFF,0x42,0x5B,0x8F,0xC4,0x3F
//                  |                   |                   |
,0x88,0x0A,0xD2,0x44,0x78,0xD3,0xC5,0x44,0x13,0x7B,0xFF,0x42,0x5B,0x8F,0xC4,0x3F
//                  |                   |                   |
,0x00,0x00,0x00,0x00,0x00,0x03,0x80,0x08,0x00,0x00,0x00,0x00,0x00,0x00,0x20,0x40
//                  |                   |                   |
,0x00,0x00,0x00,0x41,0x72,0x1C,0x97,0x40,0xDB,0x0F,0x49,0x40,0x00,0x00,0x00,0x00
//                  |                   |                   |
,0x01,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00
//                  |                   |                   |
,0x06,0x3F,0x00,0x4C,0xEF,0x07,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00
//                  |                   |                   |
,0x00,0x00,0x30,0xB0,0x02,0x00,0x00,0x00,0x00
//  id              |                   |                   | name/template     |
,0xBA,0xDC,0x00,0x00,0x00,0x10,0x00,0xF0,0x09,0x00,0x00,0x00,0xEB,0x0F,0x00,0x00
//          size    |
,0x00,0x00,0x80,0x3F,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE
// hps              |  1000             | 10                | 100
,0x08,0x00,0x00,0x00,0xE8,0x03,0x00,0x00,0x0A,0x00,0x00,0x00,0x64,0x00,0x00,0x00
// hps              |  1000             | 10                | 100
,0x08,0x00,0x00,0x00,0xE8,0x03,0x00,0x00,0x0A,0x00,0x00,0x00,0x64,0x00,0x00,0x00
// level            |                   |                   | 
,0x01,0x00,0x00,0x00,0x1F,0x00,0x00,0x00,0x00,0x01,0x02,0x00,0xD0,0x07,0x00,0x00
//                  |  size             | original size?    | model
,0xD0,0x07,0x00,0x00,0x00,0x00,0x80,0x3F,0x00,0x00,0x80,0x3F,0x74,0x04,0x00,0x00
//dmg min?| dmg max?
,0x06,0x00,0x09,0x00
	};
	/**/
	Add(unsigned long,guid);
	Add(unsigned long,0xF0001000);
	if (Create)
	{
		Add(unsigned char,0x03);// "unit"
		Add(unsigned long, 0);
		Add(_Location,Data.Loc);
		Add(float,Data.Facing);
		Add(unsigned long,0x40200000);
		Add(unsigned long,0x41000000);
		Add(unsigned long,0x40971C72);
		Add(unsigned long,0x40490FDB);
		Skip(0x4);
		Add(unsigned long,0x1);
		Skip(0xC);
/*		Add(unsigned char,0x03);// "unit"
		Skip(0x8);
		Add(_Location,Data.Loc);
		Add(float,Data.Facing);
		Add(_Location,Data.Loc);
		Add(float,Data.Facing);
		Skip(0x4);
		Add(unsigned long,0x08800300);
		Skip(0x4);
		Add(unsigned long,0x40200000);
		Add(unsigned long,0x41000000);
		Add(unsigned long,0x40971C72);
		Add(unsigned long,0x40490FDB);
		Skip(0x4);
		Add(unsigned long,0x1);
		Skip(0xC);*/
	}
#undef Fill
#undef Skip
#undef Add

	CUpdateBlock block(&buffer[c], UNIT_MAX_BITS);
	block.Add(OBJECT_GUID, guid);
	block.Add(OBJECT_GUID_HIGH, CREATUREGUID_HIGH);
	block.Add(OBJECT_HIER_TYPE, HIER_TYPE_UNIT); // 1 << UnitType(0x03) | 1 << ObjectType(0x00)
	block.Add(OBJECT_ENTRY, Data.Template);
	block.Add(OBJECT_SCALE, Data.Size);
	block.Add(UNIT_HEALTH, Data.CurrentStats.HitPoints);
	//block.Add(23, Data.CurrentStats.Mana); // no mana in struct?
	/*block.Add(24, Data.CurrentStats.Energy);
	block.Add(25, Data.CurrentStats.Focus);
	block.Add(26, Data.CurrentStats.Rage);*/
	block.Add(UNIT_MAX_HEALTH, Data.NormalStats.HitPoints);
	//block.Add(28, Data.NormalStats.Mana);
	/*block.Add(29, Data.NormalStats.Energy);
	block.Add(30, Data.NormalStats.Focus);
	block.Add(31, Data.NormalStats.Rage);*/
	block.Add(UNIT_LEVEL, Data.Level);
	block.Add(UNIT_FACTION, Data.FactionTemplate); // FactionTemplate
	//block.Add(34, Data.Race | Data.Class << 8 | Data.Female << 16 | Data.ManaType << 24);
	block.Add(UNIT_BYTES_0, 0x20100);
	block.Add(UNIT_BASEATTACKTIME0, 0x7D0); // attack speed
	block.Add(UNIT_BASEATTACKTIME1, 0x7D0); // probably other hand attack speed

	/*block.Add(148,0x3F800000);// Bounding Radius
	block.Add(149,0x3F800000); // Combat Reach*/
	block.Add(UNIT_DISPLAYID,Data.Model);
	//block.Add(153,Data.DamageMin | (Data.DamageMax << 16));
	block.Add(UNIT_NPC_FLAGS,Data.NPCType);
	return block.GetSize() + c;

/*
	Add(unsigned long,0x4C003F06);
	Add(unsigned long,0x7EF);
	Skip(0x8);
	Add(unsigned long,0xB0300000);
	Add(unsigned char,0x2);
	Skip(0x4);




//    id              |                   |                   | name/template     |
//,0xBA,0xDC,0x00,0x00,0x00,0x10,0x00,0xF0,0x09,0x00,0x00,0x00,0xEB,0x0F,0x00,0x00
	Add(unsigned long,guid);
	Add(unsigned long,0xF0001000);
	Add(unsigned long,0x9);
	Add(unsigned long,Data.Template);
//            size    |
//,0x00,0x00,0x80,0x3F,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE,0xEE
	Add(unsigned long,Data.Size);
	Add(unsigned long,0xEEEEEEEE);
	Add(unsigned long,0xEEEEEEEE);
	Add(unsigned long,0xEEEEEEEE);
//   hps              |  1000             | 10                | 100
//,0x08,0x00,0x00,0x00,0xE8,0x03,0x00,0x00,0x0A,0x00,0x00,0x00,0x64,0x00,0x00,0x00
	Add(CreatureStats,Data.CurrentStats);
//   hps              |  1000             | 10                | 100
//,0x08,0x00,0x00,0x00,0xE8,0x03,0x00,0x00,0x0A,0x00,0x00,0x00,0x64,0x00,0x00,0x00
	Add(CreatureStats,Data.NormalStats);
//   level            |                   |                   | 
//,0x01,0x00,0x00,0x00,0x1F,0x00,0x00,0x00,0x00,0x01,0x02,0x00,0xD0,0x07,0x00,0x00
	Add(unsigned long,Data.Level);
	Add(unsigned long,0x1F);
	Add(unsigned long,0x20100);
	Add(unsigned long,0x7D0);
//                    |  size             | original size?    | model
//,0xD0,0x07,0x00,0x00,0x00,0x00,0x80,0x3F,0x00,0x00,0x80,0x3F,0x74,0x04,0x00,0x00
	Add(unsigned long,0x7D0);
	Add(unsigned long,Data.Size);
	Add(unsigned long,Data.Size);
	Add(unsigned long,Data.Model);
//  dmg min?| dmg max?
//,0x06,0x00,0x09,0x00
	Add(unsigned short,Data.DamageMin);
	Add(unsigned short,Data.DamageMax);
/**/

//	return c;

}

void CCreature::ProcessEvent(struct WoWEvent &Event)
{
	switch(Event.EventType)
	{
	case EVENT_CREATURE_DESPAWN:
		// note: this cant/wont free the memory but once we start using CSpawnPoint,
		// we can actually use delete pCreature;
		RegionManager.ObjectRemove(*this);
		EventManager.AddEvent(*this,180000,EVENT_CREATURE_RESPAWN,0,0);
		break;
	case EVENT_CREATURE_REGENERATE:
		Regenerate();
		break;
	case EVENT_CREATURE_ATTACK:
		Attack();
		break;
	case EVENT_CREATURE_FOLLOW_TARGET:
		FollowTarget();
		break;
	case EVENT_CREATURE_RESPAWN:
		ReSpawn();
		break;
	case EVENT_CREATURE_UPDATELOC:
		{
		long remaining = UpdateLoc();		
		if (remaining > 0) {
			EventManager.AddEvent(*this,remaining,EVENT_CREATURE_UPDATELOC,0,0);
		}
		}
		break;
	case EVENT_CREATURE_DOTTED:
		{
		long power;
		memcpy(&power, Event.pEventData, sizeof(power));
		Data.CurrentStats.HitPoints -= power;
		if (Data.CurrentStats.HitPoints <= 0 && !dead)
		{
				ClearEvents();
				bAttacking = false;
				bMoving = false;
				dead = true;
				EventManager.AddEvent(*this,30000,EVENT_CREATURE_DESPAWN,0,0);
				EventManager.AddEvent(*pCaster, 0, EVENT_PLAYER_GAINEXP, &Data.Exp, sizeof(Data.Exp));
				CPlayer *pPlayer=NULL;
				if (DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,TargetID)) {
					SendLootablePacket(pPlayer);
				}
		}
		else 
		{
			if (!bAttacking)
				Attack();
		}
		if (!bMoving && !dead)
			RegionManager.ObjectResend(*this);
		}
		break;
	}
}




void CCreature::Regenerate()
{
	bool bResend = false;
	if (Data.CurrentStats.HitPoints < Data.NormalStats.HitPoints) {
		Data.CurrentStats.HitPoints += CREATURE_REGEN_HPS;
		if (Data.CurrentStats.HitPoints > Data.NormalStats.HitPoints) {
			Data.CurrentStats.HitPoints = Data.NormalStats.HitPoints;
		}
		bResend = true;
	}
	if (Data.CurrentStats.Energy < Data.NormalStats.Energy) {
		Data.CurrentStats.Energy += CREATURE_REGEN_ENERGY;
		if (Data.CurrentStats.Energy > Data.NormalStats.Energy) {
			Data.CurrentStats.Energy = Data.NormalStats.Energy;
		}
		bResend = true;
	}
	if (bResend) {
		RegionManager.ObjectResend(*this);
	}
	EventManager.AddEvent(*this,10000,EVENT_CREATURE_REGENERATE,0,0);

}

float CCreature::Distance(_Location Loc)
{
	float A=Loc.X-Data.Loc.X;
	float B=Loc.Y-Data.Loc.Y;
	float C=Loc.Z-Data.Loc.Z;
	return sqrt((A*A)+(B*B)+(C*C));
}

void CCreature::FacePlayer(CPlayer *player)
{
	float x1;
	float x2;
	float y1;
	float y2;

	x1 = Data.Loc.X;
	y1 = Data.Loc.Y;
	x2 = player->Data.Loc.X;
	y2 = player->Data.Loc.Y;
	float angle = (float)atan2 (y2 - y1, x2 - x1);
	Data.Facing = angle;

	char buffer[0x39];
	memset(buffer, 0, sizeof(buffer));
	*(unsigned long*)&buffer[0x00]=guid;
	*(unsigned long*)&buffer[0x04]=0xF0001000;
	*(_Location*)&buffer[0x08]=Data.Loc;
	//*(unsigned long*)&buffer[0x14] = 0; // unknown
	buffer[0x18] = 3; // Face player, we could use 4 and add the angle here instead but whatever let the client calc the angle as well
	*(unsigned long*)&buffer[0x19] = player->guid;
	//*(unsigned long*)&buffer[0x1D] = 0; // the high 32bits of guid
	//*(unsigned long*)&buffer[0x21] = 0; // flags
	//*(unsigned long*)&buffer[0x25] = 0; // length of time for the move(s)
	*(unsigned long*)&buffer[0x29] = 1; // NumPoints
	*(_Location*)&buffer[0x2D]=Data.Loc;

	player->pClient->RegionOutPacket(SMSG_MONSTER_MOVE, buffer, 0x39);
}

#define ATTACK_DISTANCE 4.0f
#define CREATURE_RUN_SPEED 9.0f

void CCreature::Attack()
{
	bool bspell = false;
	bool bmelee = false;
	bool bmove = false;
	int dmg = 0;

	if (Data.CurrentStats.HitPoints <= 0)
		return;

	CPlayer *pPlayer=NULL;
	if (DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,TargetID)) {
		if (pPlayer->pClient == NULL)
			return;
		
		if (!bAttacking) {
			EventManager.AddEvent(*this,1000,EVENT_CREATURE_FOLLOW_TARGET,0,0);
			bAttacking = true;
		}
		// Now we must decide what to do...
		if (!(rand() % 8))
			bspell = true;
		else
			bmelee = true;

		if (bspell) {
			dmg = CastSpell(pPlayer,0x193);
		}
		else if (bmelee) {

			float dist = Distance(pPlayer->Data.Loc);
			if (dist < ATTACK_DISTANCE)
				dmg = MeleeAttack(pPlayer);
			else
			{
				if (!bMoving) {
					Move(&(pPlayer->Data.Loc),CREATURE_RUN_SPEED);
				}
				bmove = true;
			}
		}
		pPlayer->Data.CurrentStats.HitPoints -= dmg;
		if ((long)(pPlayer->Data.CurrentStats.HitPoints) <= 0) {
			pPlayer->ClearEvents();
			bMoving = false;
			bAttacking = false;
			ClearEvents();
			EventManager.AddEvent(*this,10000,EVENT_CREATURE_REGENERATE,0,0);
		}
		else {
			EventManager.AddEvent(*this,2000,EVENT_CREATURE_ATTACK,0,0);
		}
		if (dmg > 0) {
			char buffer[0x90];
			CUpdateBlock block;
			block.ResetBlock(buffer, 0x90);
			block.AddDataUpdate(PLAYER_MAX_BITS, pPlayer->guid, PLAYERGUID_HIGH);
			block.Add(UNIT_HEALTH, pPlayer->Data.CurrentStats.HitPoints);
			int size = 0;
			char *ptr = block.GetCompressedData(size);
			if(size)
				pPlayer->pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
		}
	}
}

void CCreature::ObjectFades(CWoWObject &Object)
{
	if (Object.guid==TargetID)
		TargetID=0;
}

int CCreature::CastSpell(CPlayer *pPlayer, unsigned short spell)
{
	if (Data.CurrentStats.HitPoints <= 0)
		return -1;
	if (pPlayer->pClient == NULL)
		return -1;

	FacePlayer(pPlayer);

	int flag=0;
	long dmg = pPlayer->CalculateDmg(DMGTYPE_SPELL,spell, flag);  
	unsigned char buffer[0x36];
	unsigned char buffer2[0x2C];

	memset(buffer,0,0x36);
	*(unsigned long*)&buffer[0x00]=guid;
	*(unsigned long*)&buffer[0x04]=0xF0001000;  // who is dishing out dmg
	*(unsigned long*)&buffer[0x08]=guid;
	*(unsigned long*)&buffer[0x0C]=0xF0001000;  // who is dishing out dmg
	*(unsigned short*)&buffer[0x10]=spell; // spell
	*(unsigned short*)&buffer[0x14]=0x80;
	*(unsigned char*)&buffer[0x16]=0x01;
	*(unsigned long*)&buffer[0x17]=pPlayer->guid;
	*(unsigned short*)&buffer[0x20]=0x42;
	*(unsigned long*)&buffer[0x22]=pPlayer->guid;
	*(_Location*)&buffer[0x2A]=Data.Loc;

	memset(buffer2,0,0x2C);
	*(unsigned long*)&buffer2[0x00]=0x11;
	*(unsigned long*)&buffer2[0x04]=guid;  // who is dishing out dmg
	*(unsigned long*)&buffer2[0x08]=0xF0001000;  // who is dishing out dmg
	*(unsigned long*)&buffer2[0x0C]=pPlayer->guid;  // to whom
	*(unsigned short*)&buffer2[0x14]=spell; // spell
	*(unsigned long*)&buffer2[0x18]=0x0C;
	*(unsigned char*)&buffer2[0x1E]=0x40;
	*(unsigned char*)&buffer2[0x1F]=0x41;
	*(unsigned long*)&buffer2[0x24]=dmg;   // how much dmg

	CRegion *pPlayerRegion=RegionManager.ObjectRegions[pPlayer->guid];
	if (!pPlayerRegion)
	{
		pPlayer->pClient->OutPacket(SMSG_SPELL_GO,buffer,0x36);
		pPlayer->pClient->OutPacket(SMSG_ATTACKERSTATEUPDATEDEBUGINFOSPELL,buffer2,0x2C);
		return dmg;
	}
	for (int i = 0 ; i < 3 ; i++) {
		for (int j = 0 ; j < 3 ; j++)
		{
			if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
			{
				RegionObjectNode *pNode=pRegion->pList;
				while(pNode)
				{
					if (pNode->pObject->type==OBJ_PLAYER)
					{
						if (pPlayer->pClient->pPlayer->Distance(*((CPlayer*)pNode->pObject))<SPELLDIST) {
							((CPlayer*)pNode->pObject)->pClient->OutPacket(SMSG_SPELL_GO,buffer,0x36);
							((CPlayer*)pNode->pObject)->pClient->OutPacket(SMSG_ATTACKERSTATEUPDATEDEBUGINFOSPELL,buffer2,0x2C);							
						}
					}
					pNode=pNode->pNext;
				}
			}
		}
	}
	return dmg;
}

int CCreature::MeleeAttack(CPlayer *pPlayer)
{
	if (Data.CurrentStats.HitPoints <= 0)
		return -1;
	if (pPlayer->pClient == NULL)
		return -1;

	FacePlayer(pPlayer);
	long dmg=0;
	int flag=0;
	if (Data.DamageMin == 4 && Data.Level != 1) 
	{
		dmg = pPlayer->CalculateDmg(DMGTYPE_WEAPON,0, flag);  
	}
	else 
	{
		dmg = CalculateDmg(DMGTYPE_WEAPON,0, flag);  
	}

	unsigned char buffer1[0x39];
	unsigned char buffer2[0x2C];

	memset(buffer1,0,0x39);
	*(unsigned char*)&buffer1[0x00]=flag;  // bit flag // same as player for miss ?
	*(unsigned char*)&buffer1[0x01]=0x00;  // can turn on and off attacking
	*(unsigned char*)&buffer1[0x02]=0x00;  // unknown
	*(unsigned char*)&buffer1[0x03]=0x00;  // unknown
	*(unsigned long*)&buffer1[0x04]=guid;  // who is dishing out dmg
	*(unsigned long*)&buffer1[0x08]=0xF0001000;  // who is dishing out dmg
	*(unsigned long*)&buffer1[0x0C]=pPlayer->guid;
	*(unsigned long*)&buffer1[0x14]=dmg;  // dmg shown in main window
	
	*(unsigned char*)&buffer1[0x18]=0x01;  // DamageCount
	*(unsigned long*)&buffer1[0x1D]=0x412DDDDE; // damageFloat
	*(unsigned long*)&buffer1[0x21]=dmg;  // dmg shown in rt window
	*(unsigned long*)&buffer1[0x25]=0x00; // DamageAbsorbed
	
	*(unsigned long*)&buffer1[0x29]=VS_WOUND;  // if not 1 - doesnt show up
	*(unsigned long*)&buffer1[0x2D] = 0x3E8; // victimRoundDuration
	*(unsigned long*)&buffer1[0x31]=0x00; // "spellDamageAdded"
	*(unsigned long*)&buffer1[0x35]=0x00;  // "spellAddedDamage" if not 0 (then spell dmg) and dont show - assumes 1D will show
	//*(unsigned long*)&buffer1[0x39]=0x00;   // visual effect

	memset(buffer2,0,0x2C);
	*(unsigned long*)&buffer2[0x00]=0x11;
	*(unsigned long*)&buffer2[0x04]=guid;  // who is dishing out dmg
	*(unsigned long*)&buffer2[0x08]=0xF0001000;  // who is dishing out dmg
	*(unsigned long*)&buffer2[0x0C]=pPlayer->guid;  // to whom
	*(unsigned short*)&buffer2[0x14]=0x00; // spell
	*(unsigned long*)&buffer2[0x18]=0x0C;
	*(unsigned char*)&buffer2[0x1E]=0x40;
	*(unsigned char*)&buffer2[0x1F]=0x41;
	*(unsigned long*)&buffer2[0x24]=dmg;   // how much dmg

	CRegion *pPlayerRegion=RegionManager.ObjectRegions[pPlayer->guid];
	if (!pPlayerRegion)
	{
		pPlayer->pClient->OutPacket(SMSG_ATTACKERSTATEUPDATE,buffer1,0x39);
		pPlayer->pClient->OutPacket(SMSG_ATTACKERSTATEUPDATEDEBUGINFOSPELL,buffer2,0x2C);
		return dmg;
	}
	for (int i = 0 ; i < 3 ; i++) {
		for (int j = 0 ; j < 3 ; j++)
		{
			if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
			{
				RegionObjectNode *pNode=pRegion->pList;
				while(pNode)
				{
					if (pNode->pObject->type==OBJ_PLAYER)
					{
						if (pPlayer->pClient->pPlayer->Distance(*((CPlayer*)pNode->pObject))<SPELLDIST) {
							((CPlayer*)pNode->pObject)->pClient->OutPacket(SMSG_ATTACKERSTATEUPDATE,buffer1,0x39);
							((CPlayer*)pNode->pObject)->pClient->OutPacket(SMSG_ATTACKERSTATEUPDATEDEBUGINFOSPELL,buffer2,0x2C);							
						}
					}
					pNode=pNode->pNext;
				}
			}
		}
	}
	return dmg;
}

// This doesnt work - Tamino please take a look
#define MOVE_DISTANCE 9.0f

void CCreature::FollowTarget()
{
	if ((long)Data.CurrentStats.HitPoints <= 0)
		return;

	CPlayer *pPlayer=NULL;
	if (DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,TargetID)) {
		if (pPlayer->pClient == NULL)
			return;

		if (bMoving) {
			if ((pPlayer->Data.Loc.X != MovingDestLoc.X) ||
				(pPlayer->Data.Loc.Y != MovingDestLoc.Y) ||
				(pPlayer->Data.Loc.Z != MovingDestLoc.Z)) {
				UpdateLoc();
				ClearEvents(EVENT_CREATURE_UPDATELOC);
				Move(&(pPlayer->Data.Loc),CREATURE_RUN_SPEED);
			}
		}
		else {
			float dist = Distance(pPlayer->Data.Loc);
			if (dist >= ATTACK_DISTANCE) {
				Move(&(pPlayer->Data.Loc),CREATURE_RUN_SPEED);
			}
		}
		EventManager.AddEvent(*this,1000,EVENT_CREATURE_FOLLOW_TARGET,0,0);
	}
}


void CCreature::ReSpawn()
{
	EventsEligible=true;
	bMoving = false;
	bAttacking = false;
	dead = false;
	Data.Loc.X = Data.SpawnLoc.X;
	Data.Loc.Y = Data.SpawnLoc.Y;
	Data.Loc.Z = Data.SpawnLoc.Z;
	Data.Facing = Data.SpawnFacing;
	Data.CurrentStats.HitPoints = Data.NormalStats.HitPoints;
	RegionManager.ObjectNew(*this,Data.Continent,Data.Loc.X,Data.Loc.Y);
	EventManager.AddEvent(*this,10000,EVENT_CREATURE_REGENERATE,0,0);
}

void CCreature::ApplySpellEffect(unsigned long SpellID, unsigned long Effect)
{
	unsigned long EffectID = DBCManager.Spell.getValue(SpellID, DBC_SPELL_EFFECT(Effect));

//	char test[32];
//	sprintf(test, "%d",EffectID);
//	MessageBox(NULL,test,"test",MB_OK);
	// DO NOT ADD SWITCH ITEMS THAT DO NOT WORK AS THIS IS IN USE NOW
	switch(EffectID)
	{
		case 2: // direct damage (school damage)
		{
			long power = getPower(SpellID, Effect);
			
			Data.CurrentStats.HitPoints -= power;
			sendSpellMsg(power, SpellID, false);
	
			if (Data.CurrentStats.HitPoints <= 0 && !dead)
			{
				ClearEvents();
				bAttacking = false;
				bMoving = false;
				dead = true;
				EventManager.AddEvent(*this,30000,EVENT_CREATURE_DESPAWN,0,0);
				EventManager.AddEvent(*pCaster, 0, EVENT_PLAYER_GAINEXP, &Data.Exp, sizeof(Data.Exp));
				CPlayer *pPlayer=NULL;
				if (DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,TargetID)) {
					SendLootablePacket(pPlayer);
				}
			}
			else 
			{
				if (!bAttacking)
					Attack();
			}
			if (!bMoving && !dead)
				RegionManager.ObjectResend(*this);
		}
		break;
				
		case 6: // Apply Aura (Buffs, DoT)
		{
			long power = getPower(SpellID, Effect);
			long type = DBCManager.Spell.getValue(SpellID, DBC_SPELL_ATTRIBUTE(Effect, SPELL_ATTRIB_TYPE));
			long aura = DBCManager.Spell.getValue(SpellID, DBC_SPELL_ATTRIBUTE(Effect, SPELL_ATTRIB_AURA));

			switch(type)
			{
			case 6:  // school dmg
				{
					switch(aura)
						{
						case 3: // Damage Over Time (DoT)
							{
							long periodicity = DBCManager.Spell.getValue(SpellID, DBC_SPELL_ATTRIBUTE(Effect, SPELL_ATTRIB_PERIODICITY));
							long durationID = DBCManager.Spell.getValue(SpellID, DBC_SPELL_DURATION_ID);
							long mintime = DBCManager.SpellDuration.getValue(durationID, DBC_SPELLDURATION_MINTIME);
							long maxtime = DBCManager.SpellDuration.getValue(durationID, DBC_SPELLDURATION_MAXTIME);
							if (periodicity)// TODO
							{
								unsigned long dmg_tick = (maxtime / periodicity); // Guessing tick wont be float putting it in sec
								for (unsigned long i = 0 ; i < dmg_tick ; i++) {
									EventManager.AddEvent(*this, (i * periodicity), EVENT_CREATURE_DOTTED, &power, sizeof(power));
									}
								}
							}
							break;
						} // switch aura
				} // case 6
				break;
			}
		}
		break;

		case 10: // heals
		{
			long power = getPower(SpellID, Effect);

			if ((Data.CurrentStats.HitPoints + power) >= Data.NormalStats.HitPoints)
			{
				power = Data.NormalStats.HitPoints - Data.CurrentStats.HitPoints;
				Data.CurrentStats.HitPoints = Data.NormalStats.HitPoints;
			}
			else
				Data.CurrentStats.HitPoints += power;

			RegionManager.ObjectResend(*this);
			sendSpellMsg(power, SpellID, true);
		}
		break;

		case 36: // ranged shots
		{
			long power = getPower(SpellID, Effect);
			if (power <= 0)
				power = 12;
			
			Data.CurrentStats.HitPoints -= power;
			sendSpellMsg(power, SpellID, false);
	
			if (Data.CurrentStats.HitPoints <= 0 && !dead)
			{
				ClearEvents();
				bAttacking = false;
				bMoving = false;
				dead = true;
				EventManager.AddEvent(*this,30000,EVENT_CREATURE_DESPAWN,0,0);
				EventManager.AddEvent(*pCaster, 0, EVENT_PLAYER_GAINEXP, &Data.Exp, sizeof(Data.Exp));
				CPlayer *pPlayer=NULL;
				if (DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,TargetID)) {
					SendLootablePacket(pPlayer);
				}
			}
			else 
			{
				if (!bAttacking)
					Attack();
			}
			if (!bMoving && !dead)
				RegionManager.ObjectResend(*this);
		}
		break;

		case 58: // additional ranged shots
		{
			long power = getPower(SpellID, Effect);
			if (power <= 0)
				power = 12;
			
			Data.CurrentStats.HitPoints -= power;
			sendSpellMsg(power, SpellID, false);
	
			if (Data.CurrentStats.HitPoints <= 0 && !dead)
			{
				ClearEvents();
				bAttacking = false;
				bMoving = false;
				dead = true;
				EventManager.AddEvent(*this,30000,EVENT_CREATURE_DESPAWN,0,0);
				EventManager.AddEvent(*pCaster, 0, EVENT_PLAYER_GAINEXP, &Data.Exp, sizeof(Data.Exp));
				CPlayer *pPlayer=NULL;
				if (DataManager.RetrieveObject((CWoWObject**)&pPlayer,OBJ_PLAYER,TargetID)) {
					SendLootablePacket(pPlayer);
				}
			}
			else 
			{
				if (!bAttacking)
					Attack();
			}
			if (!bMoving && !dead)
				RegionManager.ObjectResend(*this);
		}
		break;

		default:
			if (Effect == 1 && pCaster->type == OBJ_PLAYER)
				((CPlayer*)pCaster)->pClient->InterruptCast(SpellID);
			break;
	}
}

void CCreature::sendSpellMsg(long damage, unsigned long spell, bool heal)
{
	if (pCaster->type != OBJ_PLAYER)
		return;
	unsigned char buffer[0x3D];
	memset(buffer,0,0x24);
	*(unsigned long*)&buffer[0]=pCaster->guid;
	*(unsigned long*)&buffer[8]=pCaster->guid;
	*(unsigned long*)&buffer[0x10]=spell;
	buffer[0x14]=2;
	buffer[0x1A]=2;
	*(unsigned long*)&buffer[0x1C]=pCaster->guid;

	memset(buffer,0,5);
	*(unsigned long*)&buffer[0x0]=spell;

	memset(buffer,0,0x36);
	*(unsigned long*)&buffer[0]=pCaster->guid;
	*(unsigned long*)&buffer[8]=pCaster->guid;
	*(unsigned long*)&buffer[0x10]=spell;
	*(unsigned short*)&buffer[0x14]=0x82;
	buffer[0x16]=1;
	*(unsigned long*)&buffer[0x17]=guid;
	*(unsigned short*)&buffer[0x1F]=0x4200;
	*(unsigned long*)&buffer[0x22]=guid;
	*(_Location*)&buffer[0x2A]=((CPlayer*)pCaster)->Data.Loc;
	
	
	unsigned char buffer1[0x39];
	unsigned char buffer2[0x2C];
	memset(buffer1,0,0x39);
	*(unsigned char*)&buffer1[0x01]=0x00;  // can turn on and off attacking
	*(unsigned char*)&buffer1[0x02]=0x00;  // unknown
	*(unsigned char*)&buffer1[0x03]=0x00;  // unknown
	*(unsigned long*)&buffer1[0x04]=pCaster->guid;  // who is dishing out dmg
	*(unsigned long*)&buffer1[0x0C]=guid; // to whom
	*(unsigned long*)&buffer1[0x10]=SpellUnknown;
	*(unsigned long*)&buffer1[0x14]=damage;  // dmg shown in main window
	
	*(unsigned long*)&buffer1[0x18]=0x01;  // DamageCount
	*(unsigned long*)&buffer1[0x1D]=0x41880000; // damageFloat
	*(unsigned long*)&buffer1[0x21]=0x00;  // dmg shown in rt window - note psycho: If you put damage here you get the dmg message in double (Your fireball hit taget for 10, You hit target for 10)
	*(unsigned long*)&buffer1[0x25]=0x00; // DamageAbsorbed

	*(unsigned long*)&buffer1[0x29]=VS_WOUND;  // if not 1 - doesnt show up
	*(unsigned long*)&buffer1[0x2D]=0xFFFFFFFF; // victimRoundDuration
	*(unsigned long*)&buffer1[0x31]=0x00;  // put additional dmg here (ex: You hit target for an additional dmg of 5
	*(unsigned long*)&buffer1[0x35]=(unsigned short)spell; // if not 0 (then spell dmg) and dont show - assumes 1D will show
	//*(unsigned long*)&buffer1[0x39]=0x00;   // visual effect

	memset(buffer2,0,0x2C);
	// bit flag
	if (heal == true)
	{
		*(unsigned char*)&buffer1[0x00]=0x24;
		*(unsigned long*)&buffer2[0x00]=0x12;
	}
	else
	{
		*(unsigned char*)&buffer1[0x00]=0x22;
		*(unsigned long*)&buffer2[0x00]=0x11;
	}
	
	*(unsigned long*)&buffer2[0x04]=pCaster->guid;   // who is dishing out dmg
	*(unsigned long*)&buffer2[0x0C]=guid; // to whom
	*(unsigned long*)&buffer2[0x10]=SpellUnknown;
	*(unsigned short*)&buffer2[0x14]=(unsigned short)spell; // spell
	*(unsigned long*)&buffer2[0x18]=damage;
	*(unsigned char*)&buffer2[0x1E]=0x40;
	*(unsigned char*)&buffer2[0x1F]=0x41;
	*(unsigned long*)&buffer2[0x24]=damage;   // how much dmg

	CRegion *pPlayerRegion=RegionManager.ObjectRegions[pCaster->guid];
	if (!pPlayerRegion)
	{
		((CPlayer*)pCaster)->pClient->OutPacket(SMSG_SPELL_GO,buffer,0x36);
		((CPlayer*)pCaster)->pClient->OutPacket(SMSG_ATTACKERSTATEUPDATE,buffer1,0x39);
		((CPlayer*)pCaster)->pClient->OutPacket(SMSG_ATTACKERSTATEUPDATEDEBUGINFOSPELL,buffer2,0x2C);
		return;
	}

	for (int i = 0 ; i < 3 ; i++) 
	{
		for (int j = 0 ; j < 3 ; j++)
		{
			if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
			{
				RegionObjectNode *pNode=pRegion->pList;
				while(pNode)
				{
					if (pNode->pObject->type==OBJ_PLAYER)
					{
						if ((((CPlayer*)pCaster)->Distance(*(CPlayer*)pNode->pObject)) < SPELLDIST)
						{
							((CPlayer*)pNode->pObject)->pClient->OutPacket(SMSG_SPELL_GO,buffer,0x36);
							((CPlayer*)pNode->pObject)->pClient->OutPacket(SMSG_ATTACKERSTATEUPDATE,buffer1,0x39);
							((CPlayer*)pNode->pObject)->pClient->OutPacket(SMSG_ATTACKERSTATEUPDATEDEBUGINFOSPELL,buffer2,0x2C);
						}
					}
					pNode=pNode->pNext;
				}
			}
		}
	}
}
/*
void CCreature::MoveToPPoint(const int pPointID)
{
	PPoint point;

	if (PPoints.GetPPoint(pPointID, point))
	{
		_Location loc;

		loc.X = point.x;
		loc.Y = point.y;
		loc.Z = point.z;

		Move(&loc, CREATURE_RUN_SPEED-6.0f);
	}
}
/**/
long CCreature::Move(_Location *loc, float speed)
{
	if (Data.CurrentStats.HitPoints <= 0)
		return 0;

	unsigned char buffer[0x31];

/*
________________Walking______________________________________________
DIRECTION UNKNOWN Data len=0035 op=00DA int=0000 msglen=0031 -- MonsterMoveEvent

0000:  60 65 00 00-00 10 00 F0-B4 A6 0A 45-49 C4 C5 43  `e.....=¦ª.EI-+C
0010:  40 3E 2E 42-67 BA 06 00-00 00 00 00-00 DC 23 00  @>.Bg¦......._#.
0020:  00 01 00 00-00 74 4B 0B-45 92 53 C0-43 FB CF 21  .....tK.EÆS+Cv-!
0030:  42         -           -           -             B               
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

________________Running______________________________________________
DIRECTION UNKNOWN Data len=0035 op=00DA int=0000 msglen=0031 -- MonsterMoveEvent

0000:  45 6A 00 00-00 10 00 F0-E0 FB 08 45-80 93 CA 43  Ej.....=av.EÇô-C
0010:  4F 38 64 42-E3 B6 06 00-00 00 00 00-00 C7 04 00  O8dBp¦.......¦..
0020:  00 01 00 00-00 90 21 09-45 91 8C CB-43 42 0C 64  .....É!.Eæî-CB.d
0030:  42         -           -           -             B               
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
*/
	int timet;
	float distance = Distance(*loc);

	timet = (int)((distance/speed)*1000);
	memset(buffer,0,sizeof(buffer));
	*(unsigned long*)&buffer[0x00]=guid;
	*(unsigned long*)&buffer[0x04]=0xF0001000;
	*(_Location*)&buffer[0x08]=Data.Loc;
	*(unsigned char*)&buffer[0x14]=0xE3;  // no idea
	*(unsigned char*)&buffer[0x15]=0xB6;  // no idea
	*(unsigned char*)&buffer[0x16]=0x06;  // no idea
	*(int*)&buffer[0x1D]=timet;  // believe this is speed (possibly time in millisecs)
	*(unsigned long*)&buffer[0x21]=0x01;
	*(_Location*)&buffer[0x25]=*loc;

	CRegion *pPlayerRegion=RegionManager.ObjectRegions[guid];
	if (!pPlayerRegion)
	{
		return timet;
	}
	for (int i = 0 ; i < 3 ; i++) {
		for (int j = 0 ; j < 3 ; j++)
		{
			if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
			{
				RegionObjectNode *pNode=pRegion->pList;
				while(pNode)
				{
					if (pNode->pObject->type==OBJ_PLAYER)
					{
						((CPlayer*)pNode->pObject)->pClient->OutPacket(SMSG_MONSTER_MOVE,buffer,sizeof(buffer));
					}
					pNode=pNode->pNext;
				}
			}
		}
	}
	bMoving = true;
	_ftime(&(MovingStart));
	MovingDestLoc = *loc;
	MovingSpeed = speed;
	MovingDistance = distance;
	EventManager.AddEvent(*this,timet,EVENT_CREATURE_UPDATELOC,0,0);
	return timet;
}

long CCreature::UpdateLoc()
{
	if (Data.CurrentStats.HitPoints <= 0)
		return 0;

	if (!bMoving)
		return 0;

	_timeb now;
	_ftime(&now);
	long elapsed = CEventManager::DiffTime(now,MovingStart);
	float final_distance = MovingDistance;
	long required_time = (long)(final_distance/MovingSpeed);

	if (elapsed >= required_time) {
		Data.Loc.X = MovingDestLoc.X;
		Data.Loc.Y = MovingDestLoc.Y;
		Data.Loc.Z = MovingDestLoc.Z;
		bMoving = false;
		MovingSpeed = 0;
		MovingDistance = 0;
		RegionManager.ObjectMovement(*this,Data.Loc.X,Data.Loc.Y);
		return 0;
	}
	else {
		// we didnt reach our endpt yet... so calculate partial 
		float dist = (float)elapsed * (float)MovingSpeed;
		float x = MovingDestLoc.X - Data.Loc.X;
		float xbar = fabs(x);
		float y = MovingDestLoc.Y - Data.Loc.Y;
		float ybar = fabs(y);
		float z = MovingDestLoc.Z - Data.Loc.Z;
		float zbar = fabs(z);

		Data.Loc.X += (x/(xbar+ybar+zbar))*dist;
		Data.Loc.Y += (y/(xbar+ybar+zbar))*dist;
		Data.Loc.Z += (z/(xbar+ybar+zbar))*dist;
		RegionManager.ObjectMovement(*this,Data.Loc.X,Data.Loc.Y);
		return required_time - elapsed;
	}
}


bool CCreature::StoringData(ObjectStorage &Storage)
{
	if (!guid || !Data.SpawnPoint)
		return false;
	Storage.Allocate(sizeof(AccountData));
	memcpy(Storage.Data,&Data,sizeof(AccountData));
	return true;
}

bool CCreature::LoadingData(ObjectStorage &Storage)
{
	if (!guid)
		return false;
	memcpy(&Data,Storage.Data,sizeof(CreatureTemplateData));
	return true;	
}

void CCreature::ApplySpell(CWoWObject &Caster, unsigned long SpellID, unsigned long Unknown)
{
	// hate AI could be done per effect later but we'll just use this for now
	if (Caster.type==OBJ_PLAYER)
	{
		FacePlayer((CPlayer*)&Caster);
		TargetID=Caster.guid;
	}
	CWoWObject::ApplySpell(Caster,SpellID,Unknown);

}


void CCreature::SendLootablePacket(CPlayer *pPlayer)
{
//	unsigned char buffer1[0x10];
	unsigned char buffer2[0x38];
	unsigned char buffer3[0x40];
/*  Dont know what this does
<Lax> DIRECTION UNKNOWN Data len=0014 op=01E6 int=0000 msglen=0010 -- OnUnitCombatEvent
<Lax> 0000:  F5 45 01 00-00 00 00 00-B8 6A 00 00-00 10 00 F0  )E......+j.....=
*/
/*	memset(buffer1,0,0x10);
	*(unsigned long*)&buffer1[0x00]=pPlayer->guid;
	*(unsigned long*)&buffer1[0x08]=guid;
	*(unsigned long*)&buffer1[0x0C]=0xF0001000;
*/
/*
DIRECTION UNKNOWN Data len=003C op=00E7 int=0000 msglen=0038 -- OnUnitMoveEventNoActive
0000:  B8 6A 00 00-00 10 00 F0-00 00 00 00-00 00 00 00  +j.....=........
0010:  B4 A1 0B 45-CF FD F3 43-87 B6 1C 42-40 CE 9D 40  ¦í.E-²=Cç¦.B@+¥@
0020:  B4 A1 0B 45-CF FD F3 43-87 B6 1C 42-40 CE 9D 40  ¦í.E-²=Cç¦.B@+¥@
0030:  00 00 00 00-00 02 80 08-           -             ......Ç.        
*/
	memset(buffer2,0,0x1C);
	*(unsigned long*)&buffer2[0x00]=guid;
	*(unsigned long*)&buffer2[0x04]=0xF0001000;
	*(unsigned long*)&buffer2[0x08]=0x00;//MOVEFLAG_ROOTED | MOVEFLAG_TIME_VALID;// move flags
	*(_Location*)&buffer2[0x0C]=Data.Loc;
	*(float *)&buffer2[0x18]=Data.Facing;



/*______________________________________________________________
Decompressed Data msglen=009C

0000:  02 00 00 00-00 B8 6A 00-00 00 10 00-F0 06|00 00  .....+j.....=...
0010:  43 00 00 00-40 00 00 00-00 00 00 00-00 00 00 00  C...@...........
0020:  00 00 00 00-02 00|00 00-00 00|00 00-00 00|00 00  ................
0030:  00 00|00 08-0E 00|01 00-00 00*00 F5-45 01 00 00  ...........)E...

16-17 target = 0
22 hp = 0
54 flags = 0xE0800
177 or 178? - 0x01
*/

	CUpdateBlock block;
	block.ResetBlock(buffer3, 0x40);
	block.AddDataUpdate(UNIT_MAX_BITS, guid, CREATUREGUID_HIGH);
	block.Add(UNIT_HEALTH, 0); // hp
	block.Add(UNIT_FLAGS, 0x000E0000);// flags
	block.Add(UNIT_DYNAMIC_FLAGS, 1); // dyn flags

	int size = 0;
	char *ptr = block.GetCompressedData(size);
	if(!size)
		return;

	CRegion *pPlayerRegion=RegionManager.ObjectRegions[guid];
	if (!pPlayerRegion)
	{
		return;
	}
	for (int i = 0 ; i < 3 ; i++) {
		for (int j = 0 ; j < 3 ; j++)
		{
			if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
			{
				RegionObjectNode *pNode=pRegion->pList;
				while(pNode)
				{
					if (pNode->pObject->type==OBJ_PLAYER)
					{
						((CPlayer*)pNode->pObject)->pClient->OutPacket(SMSG_COMPRESSED_UPDATE_OBJECT,ptr,size);
					}
					pNode=pNode->pNext;
				}
			}
		}
	}
}
long CCreature::CalculateDmg(int type, short id, int &flag)
{
	// miss
	if (!(rand() % 4))
	{
		flag |= 0x01;
		return 0;
	}
	
	if (type == DMGTYPE_SPELL)
	{	
		long min_dmg = DBCManager.Spell.getValue(id, DBC_SPELL_MINDMG) + 1;
		long max_dmg = DBCManager.Spell.getValue(id, DBC_SPELL_MAXDMG);

		if (!max_dmg)
			max_dmg=1;
		long rv = min_dmg + (rand() % max_dmg);
		if (!min_dmg)
			return 0;
		return rv;
		
	}
	else if (type == DMGTYPE_WEAPON)
	{
		long diff = Data.DamageMax - Data.DamageMin;
		long rv;
		if (diff)
		{
			rv = Data.DamageMin + (rand() % diff);
		}
		else
			rv = Data.DamageMin;

		flag |= 0x02;

		if ((rand() % 100) < 3)
		{
			flag |= 0x08;
			rv += rv + (Data.Level * 2);
		}
		return rv;
	}
	
	return 0;
}
/*
DDWORD Guid
BYTE Count
if(Count == 0)
{
	BYTE Error;
		Errors:
		0 - Vendor has no Inventory
		1 - I don't think he likes you very much.
		2 - You are too far away
		3 - Vendor is dead
		4 - You can't shop while dead.
}
else
{
	for Count
		DWORD Unknown
		DWORD Cache Entry
		DWORD DisplayID
		DWORD Count
		DWORD Value
		DWORD Unknown
		DWORD Unknown // Value shown in left corner of Icon
}
*/
#define SMSG_LIST_INVENTORY -1
void CCreature::ListInventory(CClient *pClient)
{
	DWORD count = MerchantInv.size();
	if(count == 0)
	{
		char buf[0xA];
		*(unsigned long*)&buf[0x00]=guid;
		*(unsigned long*)&buf[0x04]=0xF0001000;
		buf[0x08] = 0;
		buf[0x09] = 0; // Error - Vendor has no inventory
		pClient->OutPacket(SMSG_LIST_INVENTORY, buf, 0xA);
		return;
	}
	if(dead)
	{
		char buf[0xA];
		*(unsigned long*)&buf[0x00]=guid;
		*(unsigned long*)&buf[0x04]=0xF0001000;
		buf[0x08] = 0;
		buf[0x09] = 3; // Error - Vendor is dead
		pClient->OutPacket(SMSG_LIST_INVENTORY, buf, 0xA);
		return;
	}
	if(pClient->pPlayer->dead)
	{
		char buf[0xA];
		*(unsigned long*)&buf[0x00]=guid;
		*(unsigned long*)&buf[0x04]=0xF0001000;
		buf[0x08] = 0;
		buf[0x09] = 4; // Error - Can't shop while dead
		pClient->OutPacket(SMSG_LIST_INVENTORY, buf, 0xA);
		return;
	}
	int bufsize = 0x8+1+(0x4*7*count);
	char* buffer = (char*)malloc(bufsize);
	*(unsigned long*)&buffer[0x00]=guid;
	*(unsigned long*)&buffer[0x04]=0xF0001000;
	buffer[0x08] = (unsigned char)count;

	char *ptr = &buffer[0x09];
	for(list<unsigned long>::iterator i = MerchantInv.begin();i != MerchantInv.end();i++)
	{
		CItemTemplate *pTemplate;
		if(DataManager.RetrieveObject((CWoWObject**)&pTemplate, OBJ_ITEMTEMPLATE, *i))
		{
			*(unsigned long*)&ptr[0x00]=1; // Some kind of flag that makes it buyable?
			*(unsigned long*)&ptr[0x04]=pTemplate->guid;
			*(unsigned long*)&ptr[0x08]=pTemplate->Data.DisplayID;
			*(unsigned long*)&ptr[0x0C]=pTemplate->Data.MaxStack; // Count
			*(unsigned long*)&ptr[0x10]=pTemplate->Data.BuyPrice; // Value
			*(unsigned long*)&ptr[0x14]=0;
			*(unsigned long*)&ptr[0x18]=0;
			ptr += 0x1C;
		}
		else
		{
			pClient->Echo("Internal error: Unable to find merchant item template.");
			return;
		}
	}
	pClient->OutPacket(SMSG_LIST_INVENTORY, buffer, bufsize);
	free(buffer);
}

void CCreature::BuyItem(CClient *pClient, unsigned long nItem)
{
	// should check if the merchant has the item but whateve

	CItemTemplate *pTemplate;
	if(!DataManager.RetrieveObject((CWoWObject**)&pTemplate, OBJ_ITEMTEMPLATE, nItem))
	{
		pClient->Echo("Unable to find the item you want to buy.");
		return;
	}

	int newSlot = -1;
	for (int i = SLOT_INBACKPACK ; i < SLOT_INBACKPACK+16 ; i++)
	{
		if (pClient->pPlayer->Data.Items[i]==0)
		{
			newSlot = i;
			break;
		}
	}
	if(newSlot == -1)
	{
		
		pClient->Echo("Your backpack is full.");
		return;
	}

	CItem *pItem = new CItem;
	pItem->New(pTemplate->guid, pClient->pPlayer->guid);
	DataManager.NewObject(*pItem);
	RegionManager.ObjectNew(*pItem, pClient->pPlayer->Data.Continent, pClient->pPlayer->Data.Loc.X, pClient->pPlayer->Data.Loc.Y);
	pClient->pPlayer->Data.Items[newSlot] = pItem->guid;
	char buffer[0x90];
	CUpdateBlock block;
	block.ResetBlock(buffer, 0x90);
	block.AddDataUpdate(PLAYER_MAX_BITS, pClient->pPlayer->guid, PLAYERGUID_HIGH);
	block.Add(PLAYER_INV_SLOTS+newSlot*2, pItem->guid, ITEMGUID_HIGH);
	int size;
	char *ptr = block.GetCompressedData(size);
	if(size)
		pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
}

void CFlyPathMob::ListInventory(CClient *pClient)
{
	DWORD count = FlyPaths.size();
	if(count == 0)
	{
		char buf[0xA];
		*(unsigned long*)&buf[0x00]=guid;
		*(unsigned long*)&buf[0x04]=0xF0001000;
		buf[0x08] = 0;
		buf[0x09] = 0; // Error - Vendor has no inventory
		pClient->OutPacket(SMSG_LIST_INVENTORY, buf, 0xA);
		return;
	}
	if(dead)
	{
		char buf[0xA];
		*(unsigned long*)&buf[0x00]=guid;
		*(unsigned long*)&buf[0x04]=0xF0001000;
		buf[0x08] = 0;
		buf[0x09] = 3; // Error - Vendor is dead
		pClient->OutPacket(SMSG_LIST_INVENTORY, buf, 0xA);
		return;
	}
	if(pClient->pPlayer->dead)
	{
		char buf[0xA];
		*(unsigned long*)&buf[0x00]=guid;
		*(unsigned long*)&buf[0x04]=0xF0001000;
		buf[0x08] = 0;
		buf[0x09] = 4; // Error - Can't shop while dead
		pClient->OutPacket(SMSG_LIST_INVENTORY, buf, 0xA);
		return;
	}
	int bufsize = 0x8+1+(0x4*7*count);
	char* buffer = (char*)malloc(bufsize);
	*(unsigned long*)&buffer[0x00]=guid;
	*(unsigned long*)&buffer[0x04]=0xF0001000;
	buffer[0x08] = (unsigned char)count;

	char *ptr = &buffer[0x09];
	for(CFlyPathMob::FlyPathsIterator i = FlyPaths.begin();i != FlyPaths.end();i++)
	{
		*(unsigned long*)&ptr[0x00]=1; // Some kind of flag that makes it buyable?
		*(unsigned long*)&ptr[0x04]=i->first;
		*(unsigned long*)&ptr[0x08]=0xE0; // DisplayID(Icon)
		*(unsigned long*)&ptr[0x0C]=1; // Count
		*(unsigned long*)&ptr[0x10]=1; // Value
		*(unsigned long*)&ptr[0x14]=0;
		*(unsigned long*)&ptr[0x18]=0;
		ptr += 0x1C;
	}
	pClient->OutPacket(SMSG_LIST_INVENTORY, buffer, bufsize);
	free(buffer);
}

void CFlyPathMob::BuyItem(CClient *pClient, unsigned long nItem)
{
	if(pClient->pPlayer->Data.MountModel != 0)
	{
		pClient->Echo("You must 'dismount' first.");
		return;
	}

	CFlyPath path;
	_Location loc = pClient->pPlayer->Data.Loc;
	nItem = nItem-STATICITEMS::FLYPATH_ITEM1;
	float incVal = 10.0f * nItem;
	if(incVal < 10.0f)
		incVal = 10.0f;
	loc.Z += incVal;
	loc.X += incVal;
	path.Add(loc);
	
	loc.Z += incVal;
	loc.Y += incVal;
	path.Add(loc);

	loc.Z += incVal;
	loc.X += incVal;
	path.Add(loc);

	loc.Z += incVal;
	loc.Y += incVal;
	path.Add(loc);

//	loc.Y += incVal;
	loc.X -= incVal;
//	path.Add(loc);

	loc.Z -= incVal;
//	loc.Y -= incVal;
	path.Add(loc);

	loc.Z -= incVal;
	loc.X -= incVal;
	path.Add(loc);

//	loc.Z -= incVal;
//	loc.Y -= incVal;
//	path.Add(loc);

	path.CalcLength();

	loc = pClient->pPlayer->Data.Loc;
	DWORD count = path.Count();
	unsigned short bufsize = 0x25+(count * 0x0C);
	char* buffer = (char*)malloc(bufsize);
	memset(buffer, 0, bufsize);
	*(unsigned long*)&buffer[0x00] = pClient->pPlayer->guid;
	//*(unsigned long*)&buffer[0x04] = 0;
	*(_Location*)&buffer[0x08] = loc;
	*(float*)&buffer[0x14] = pClient->pPlayer->Data.Facing;
	//buffer[0x18] = 0;
	*(unsigned long*)&buffer[0x19] = 0x300;
	int time = path.MoveTime(10.0f, loc);
	*(int*)&buffer[0x1D] = time;
	*(unsigned long*)&buffer[0x21] = count;
	//*(unsigned char*)&buffer[0x25] = 0x02;
	char *ptr = &buffer[0x25];
	for(FLYPATH_ITER i = path.First();i != path.Last();i++)
	{
		*(_Location*)ptr = i->second;
		ptr += 0x0C;
	}

	char buf[0x90];
	CUpdateBlock block;
	char *update;
	int size;

	pClient->pPlayer->Data.MountModel = 0x03A7;
	block.ResetBlock(buf, 0x90);
	block.AddDataUpdate(PLAYER_MAX_BITS, pClient->pPlayer->guid, PLAYERGUID_HIGH);
	block.Add(UNIT_FLAGS, 0x0010300C);
	block.Add(UNIT_MOUNT_DISPLAYID, 0x03A7);
	update = block.GetCompressedData(size);
	if(size)
		pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, update, size);
	pClient->RegionOutPacket(SMSG_MONSTER_MOVE, buffer, bufsize);
	free(buffer);

	pClient->Echo("Fly! Fly like the wind!!");
	EventManager.AddEvent(*(pClient->pPlayer), time+500, EVENT_PLAYER_TAXI_END, NULL, 0);
	//pClient->Echo("Flypaths are currently out of order.");
}