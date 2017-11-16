#include "stdafx.h"
#include "GameObject.h"
#include "UpdateBlock.h"
#include "Player.h"
#include "Packets.h"

CGameObject::CGameObject(void):CWoWObject(OBJ_GAMEOBJECT), CUpdateObject(NUM_GAMEOBJECT_FIELDS)
{
}

CGameObject::~CGameObject(void)
{
	Delete();
}

void CGameObject::Clear()
{
	CWoWObject::Clear();
	memset(&Data,0,sizeof(GameObjectData));
	pTemplate=NULL;
}

void CGameObject::Delete()
{
	CPacket pkg(SMSG_DESTROY_OBJECT);
	pkg << guid;
	pkg << GAMEOBJECTGUID_HIGH;
	SendRegion(&pkg);

	RegionManager.ObjectRemove(*this);

	CWoWObject::Delete();
}
void CGameObject::New(CPlayer *pPlayer,unsigned long model, unsigned long flags, unsigned long type,char * name,float x,float y,int objid)
{
	Clear();
	CWoWObject::New();
	EventsEligible=true;

	pTemplate=new CGameObjectTemplate;
	pTemplate->New(name);
	Data.Facing		= pPlayer->Data.Facing;
	Data.Loc		= pPlayer->Data.Loc;Data.Loc.X =x;Data.Loc.Y = y;
	Data.Continent	= pPlayer->Data.Continent;
	pTemplate->Data.Model=model;
	pTemplate->Data.Flags=flags;
	pTemplate->Data.GType=type;
	if(objid>0) Data.TemplateID = objid;
	// Data.Owner		= pPlayer->guid;
	// Data.Model		= model;
	// Data.Flags		= flags;
	// Data.Type		= type;
	Data.Faction	= 5;
	Data.Size		= 1;
	// _ftime(&Data.TimeStamp);
	DataManager.NewObject(*pTemplate);

	RegionManager.ObjectNew(*this,Data.Continent,Data.Loc.X,Data.Loc.Y);
}
void CGameObject::New(CPlayer *pPlayer,unsigned long model, unsigned long flags, unsigned long type)
{
	Clear();
	CWoWObject::New();
	EventsEligible=true;

	pTemplate=new CGameObjectTemplate;
	pTemplate->New("Unnamed GameObject");
	Data.Facing		= pPlayer->Data.Facing;
	Data.Loc		= pPlayer->Data.Loc;
	Data.Continent	= pPlayer->Data.Continent;
	pTemplate->Data.Model=model;
	pTemplate->Data.Flags=flags;
	pTemplate->Data.Type=type;
	// Data.Owner		= pPlayer->guid;
	// Data.Model		= model;
	// Data.Flags		= flags;
	// Data.Type		= type;
	Data.Faction	= 5;
	Data.Size		= 1;
	// _ftime(&Data.TimeStamp);
	DataManager.NewObject(*pTemplate);

	RegionManager.ObjectNew(*this,Data.Continent,Data.Loc.X,Data.Loc.Y);
}

void CGameObject::New(unsigned long TemplateID)
{
	Clear();
	CWoWObject::New();
	EventsEligible=true;
	if(!DataManager.RetrieveObject((CWoWObject **)&pTemplate,OBJ_GAMEOBJECTTEMPLATE,TemplateID)) return;
	// Data.Model		= pTemplate->Data.Model;
	// Data.Flags		= pTemplate->Data.Flags;
	// Data.Type		= pTemplate->Data.GType;
	Data.Faction	= pTemplate->Data.Faction;
	Data.Size		= pTemplate->Data.Size;
	Data.TemplateID = TemplateID;
	// _ftime(&Data.TimeStamp);
}

unsigned long CGameObject::AddCreateObjectData(char *buffer)
{
#define Add(datatype,data) *(datatype*)&buffer[c]=data;c+=sizeof(datatype);
#define Fill(size,value) memset(&buffer[c],value,size);c+=size;
	unsigned long c=0;
	// HEADER
	Add(unsigned long, guid);
	Add(unsigned long, GAMEOBJECTGUID_HIGH);

	Add(unsigned char, ID_GAMEOBJECT);
	Add(unsigned long, 0);

	Add(_Location, Data.Loc);
	Add(float, Data.Facing);
	Add(unsigned long, 0);
	Add(unsigned long, 0x00067CBA);
	Add(unsigned long, 0x352514C0);
	Add(unsigned long, CORPSEGUID_HIGH);
	Add(unsigned long, 0x61ED042C);
	Add(unsigned long, 0x0815B8EA);
	Add(unsigned long, 1);
	Add(unsigned long, 0);
	Add(unsigned long, 0);
	Add(unsigned long, 0x61ED04AC);
	Add(unsigned long, 0x08159688);
	Add(unsigned long, 1);
#undef Fill
#undef Add
	return c;
}

void CGameObject::PreCreateObject()
{

}

unsigned long CGameObject::GetGameObjectInfoData(char *buffer, bool Create)
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
	Add(unsigned char,0x05);
	Add(unsigned char,0x50);
	Add(_Location,Data.Loc);
	Add(float,Data.Facing);

	Add(unsigned long, 0x6297848C);

#undef Fill
#undef Add
#undef Skip

	CUpdateBlock block(&buffer[c], NUM_GAMEOBJECT_FIELDS);

	block.Add(OBJECT_FIELD_GUID, guid, GAMEOBJECTGUID_HIGH);
	block.Add(OBJECT_FIELD_TYPE, HIER_TYPE_GAMEOBJECT);
	block.Add(OBJECT_FIELD_ENTRY,Data.TemplateID);//Data.ObjectID);
	// block.Add(OBJECT_FIELD_ENTRY,pTemplate->guid);
	block.Add(OBJECT_FIELD_SCALE_X, Data.Size);
	//block.Add(OBJECT_FIELD_CREATED_BY, Data.Owner, PLAYERGUID_HIGH);
	block.Add(GAMEOBJECT_DISPLAYID, pTemplate->Data.Model);
	block.Add(GAMEOBJECT_FLAGS, pTemplate->Data.Flags);
	block.Add(GAMEOBJECT_ROTATION, Data.Rotation[0]);
	block.Add(GAMEOBJECT_ROTATION+1, Data.Rotation[1]);
	block.Add(GAMEOBJECT_ROTATION+2, Data.Rotation[2]);
	block.Add(GAMEOBJECT_ROTATION+3, Data.Rotation[3]);

	block.Add(GAMEOBJECT_STATE,1);
	//	block.Add(GAMEOBJECT_TIMESTAMP, 0xE35B5E54);
	block.Add(GAMEOBJECT_POS_X,Data.Loc.X);
	block.Add(GAMEOBJECT_POS_Y,Data.Loc.Y);
	block.Add(GAMEOBJECT_POS_Z,Data.Loc.Z);
	block.Add(GAMEOBJECT_FACING,Data.Facing);

	block.Add(GAMEOBJECT_FACTION,pTemplate->Data.Faction);
	if (!pTemplate->Data.GType)
	{
		block.Add(GAMEOBJECT_TYPE_ID, 0);
	} else {
		block.Add(GAMEOBJECT_TYPE_ID, pTemplate->Data.GType);
	}

	return block.GetSize() + c;
}

void CGameObject::SendRegion(IPacket *pkg)
{
	CRegion *pCorpseRegion=RegionManager.ObjectRegions[guid];
	if (!pCorpseRegion)
		return;

	for (int i = 0 ; i < 3 ; i++)
		for (int j = 0 ; j < 3 ; j++)
		{
			if (CRegion *pRegion=pCorpseRegion->Adjacent[i][j])
			{
				RegionObjectNode *pNode=pRegion->pList;
				while(pNode)
				{
					if(pNode->pObject->type == OBJ_PLAYER)
						((CPlayer*)pNode->pObject)->pClient->Send(pkg);
					pNode=pNode->pNext;
				}
			}
		}
}

void CGameObject::ProcessEvent(struct WoWEvent &Event)
{
	switch(Event.EventType)
	{
	case EVENT_GAMEOBJECT_RESPAWN:
		RegionManager.ObjectNew(*this,Data.Continent,Data.Loc.X,Data.Loc.Y);
		break;
	}
}
