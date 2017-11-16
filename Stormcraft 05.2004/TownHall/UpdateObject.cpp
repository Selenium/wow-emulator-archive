#include "stdafx.h"
#include "Globals.h"
#include "Defines.h"
#include "UpdateObject.h"
#define BUFFER_SIZE PLAYER_MAX_BITS*4+0x120
char updateBuffer[BUFFER_SIZE];
char compressBuffer[BUFFER_SIZE];

unsigned long CUpdateObject::MakeUpdateBlock(char *buffer, bool reset)
{
	buffer[0] = (char)(maxField/32 + maxField % 32 ? 1 : 0);
	memset(&buffer[1], 0, buffer[0]*4);
	char *pMask = &buffer[1];
	char *pValues = &buffer[1+buffer[0]*4];
	map<unsigned long, unsigned long>::iterator i;
	for(i = UpdateFields.begin();i != UpdateFields.end();i++)
	{
		pMask[i->first/8] |= (1 << i->first % 8);
		*(unsigned long*)pValues = i->second;
		pValues += 4;
	}
	unsigned long c = UpdateFields.size()*4+1+buffer[0]*4;
	if(reset)
		UpdateFields.clear();
	return c;
}


void CUpdateObject::SendCompressedUpdate(unsigned long guid, unsigned long len)
{
	unsigned long size = Compressor.Deflate(updateBuffer, len);
	if(!size)
	{
		Debug.Log("CUpdateObject::SendCompressedUpdate() - deflate failed.");
		return;
	}
	*(unsigned long*)&compressBuffer[0x00] = len;
	size += 4;
	Compressor.GetBuffer(&compressBuffer[0x04]);

	CRegion *pPlayerRegion=RegionManager.ObjectRegions[guid];
	if (!pPlayerRegion)
	{
		Debug.Log("CUpdateObject::SendCompressedUpdate() - object has no region!");
		return;
	}
	for (int i = 0 ; i < 3 ; i++)
	for (int j = 0 ; j < 3 ; j++)
	{
		if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
		{
			RegionObjectNode *pNode=pRegion->pList;
			while(pNode)
			{
				if(pNode->pObject->type == OBJ_PLAYER)
					((CPlayer*)pNode->pObject)->pClient->OutPacket(SMSG_COMPRESSED_UPDATE_OBJECT,compressBuffer,(unsigned short)size);
				pNode=pNode->pNext;
			}
		}
	}

}


void CUpdateObject::CreateObject(unsigned long guid, bool reset)
{
	PreCreateObject();
	
	*(unsigned long*)&updateBuffer[0x00] = 1;
	updateBuffer[0x04] = UPDATE_FULL;
	unsigned long c = AddCreateObjectData(&updateBuffer[0x05]) + 5;
	c += MakeUpdateBlock(&updateBuffer[c]);
	SendCompressedUpdate(guid, c);
	PostCreateObject();
}

void CUpdateObject::UpdateObject(unsigned long guid, unsigned long guidHigh, bool reset)
{
	*(unsigned long*)&updateBuffer[0x00] = 1;
	updateBuffer[0x04] = UPDATE_PARTIAL;
	*(unsigned long*)&updateBuffer[0x05] = guid;
	*(unsigned long*)&updateBuffer[0x09] = guidHigh;
	SendCompressedUpdate(guid, MakeUpdateBlock(&updateBuffer[0x0D]) + 0x0D);
}

void CUpdateObject::SendCompressedUpdateNotMe(unsigned long guid, unsigned long len)
{
	unsigned long size = Compressor.Deflate(updateBuffer, len);
	if(!size)
	{
		Debug.Log("CUpdateObject::SendCompressedUpdateNotMe() - deflate failed.");
		return;
	}
	*(unsigned long*)&compressBuffer[0x00] = len;
	size += 4;
	Compressor.GetBuffer(&compressBuffer[0x04]);

	CRegion *pPlayerRegion=RegionManager.ObjectRegions[guid];
	if (!pPlayerRegion)
	{
		Debug.Log("CUpdateObject::SendCompressedUpdateNotMe() - object has no region!");
		return;
	}
	for (int i = 0 ; i < 3 ; i++)
	for (int j = 0 ; j < 3 ; j++)
	{
		if (CRegion *pRegion=pPlayerRegion->Adjacent[i][j])
		{
			RegionObjectNode *pNode=pRegion->pList;
			while(pNode)
			{
				if(pNode->pObject->type == OBJ_PLAYER && pNode->pObject->guid != guid)
					((CPlayer*)pNode->pObject)->pClient->OutPacket(SMSG_COMPRESSED_UPDATE_OBJECT,compressBuffer,(unsigned short)size);
				pNode=pNode->pNext;
			}
		}
	}
}

void CUpdateObject::CreateObjectNotMe(unsigned long guid, bool reset)
{
	PreCreateObjectNotMe();
	*(unsigned long*)&updateBuffer[0x00] = 1;
	updateBuffer[0x04] = UPDATE_FULL;
	unsigned long c = AddCreateObjectDataNotMe(&updateBuffer[0x05]) + 5;
	c += MakeUpdateBlock(&updateBuffer[c]);
	SendCompressedUpdateNotMe(guid, c);
	PostCreateObjectNotMe();
}

void CUpdateObject::CreateObjectOnlyMe(unsigned long guid, bool reset)
{
	PreCreateObjectOnlyMe();

	CPlayer *pPlayer;
	if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, guid))
	{
		Debug.Log("CUpdateObject::CreateObjectOnlyMe() - unable to retrieve player obj");
		return;
	}
	if(pPlayer->pClient == NULL)
	{
		Debug.Log("CUpdateObject::CreateObjectOnlyMe() - Player object had no client!");
		return;
	}


	*(unsigned long*)&updateBuffer[0x00] = 1;
	updateBuffer[0x04] = UPDATE_FULL;
	unsigned long c = AddCreateObjectDataOnlyMe(&updateBuffer[0x05]) + 5;
	c += MakeUpdateBlock(&updateBuffer[c]);


	unsigned long size = Compressor.Deflate(updateBuffer, c);
	if(!size)
	{
		Debug.Log("CUpdateObject::CreateObjectOnlyMe() - deflate failed.");
		return;
	}
	*(unsigned long*)&compressBuffer[0x00] = c;
	size += 4;
	Compressor.GetBuffer(&compressBuffer[0x04]);
	pPlayer->pClient->OutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, compressBuffer, (unsigned short)size);


	PostCreateObjectOnlyMe();

}

void CUpdateObject::UpdateObjectOnlyMe(unsigned long guid, unsigned long guidHigh, bool reset)
{
	CPlayer *pPlayer;
	if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, guid))
	{
		Debug.Log("CUpdateObject::UpdateObjectOnlyMe() - unable to retrieve player obj");
		return;
	}
	if(pPlayer->pClient == NULL)
	{
		Debug.Log("CUpdateObject::UpdateObjectOnlyMe() - Player object had no client!");
		return;
	}
	*(unsigned long*)&updateBuffer[0x00] = 1;
	updateBuffer[0x04] = UPDATE_PARTIAL;
	*(unsigned long*)&updateBuffer[0x05] = guid;
	*(unsigned long*)&updateBuffer[0x09] = guidHigh;
	unsigned long c = MakeUpdateBlock(&updateBuffer[0x0D]) + 0x0D;

	unsigned long size = Compressor.Deflate(updateBuffer, c);
	if(!size)
	{
		Debug.Log("CUpdateObject::UpdateObjectOnlyMe() - deflate failed.");
		return;
	}
	*(unsigned long*)&compressBuffer[0x00] = c;
	size += 4;
	Compressor.GetBuffer(&compressBuffer[0x04]);
	pPlayer->pClient->OutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, compressBuffer, (unsigned short)size);
}