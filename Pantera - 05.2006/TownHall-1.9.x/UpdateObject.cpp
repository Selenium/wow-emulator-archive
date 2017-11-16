#include "stdafx.h"
#include "Globals.h"
#include "Defines.h"
#include "UpdateObject.h"
#include "Packets.h"

#define BUFFER_SIZE NUM_PLAYER_FIELDS*4+0x120
#define COMPRESSED_UO_PACKETS 1

char updateBuffer[BUFFER_SIZE];
char compressBuffer[BUFFER_SIZE];

unsigned long CUpdateObject::MakeUpdateBlock(char *buffer, bool reset)
{
	buffer[0]=numBlocks;
	memset(&buffer[1], 0, maskSize);
	char *pMask = &buffer[1];
	//char *pValues = &buffer[1+buffer[0]*4]; // was commented
	unsigned long c = 1 + maskSize;
	map<unsigned long, unsigned long>::iterator i;
	for(i = UpdateFields.begin();i != UpdateFields.end();i++)
	{
		pMask[i->first >> 3] |= (1 << (i->first & 0x07));
		*(unsigned long*)&buffer[c] = i->second;
		c += 4;
	}
	//	unsigned long c = UpdateFields.size()*4+1+buffer[0]*4; //was commented
	if(reset)
		UpdateFields.clear();

	return c;
}

void CUpdateObject::SendCompressedUpdate(unsigned long guid, unsigned long len)
{
#if COMPRESSED_UO_PACKETS
	unsigned long size = Compressor.Deflate(updateBuffer, len);
	if(!size)
	{
		Debug.Log("CUpdateObject::SendCompressedUpdate() - deflate failed.");
		return;
	}
	*(unsigned long*)&compressBuffer[0x00] = len;
	size += 4;
	Compressor.GetBuffer(&compressBuffer[0x04]);
#endif

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
#if COMPRESSED_UO_PACKETS
						((CPlayer*)pNode->pObject)->pClient->OutPacket(SMSG_COMPRESSED_UPDATE_OBJECT,compressBuffer,(unsigned short)size);
#else
						((CPlayer*)pNode->pObject)->pClient->OutPacket(SMSG_UPDATE_OBJECT,updateBuffer,(unsigned short)len);
#endif
					pNode=pNode->pNext;
				}
			}
		}
}

void CUpdateObject::SendCompressedUpdateOnlyPlayer(CPlayer *pPlayer, unsigned long guid, unsigned long len)
{
#if COMPRESSED_UO_PACKETS
	unsigned long size = Compressor.Deflate(updateBuffer, len);
	if(!size)
	{
		Debug.Log("CUpdateObject::SendCompressedUpdate() - deflate failed.");
		return;
	}
	*(unsigned long*)&compressBuffer[0x00] = len;
	size += 4;
	Compressor.GetBuffer(&compressBuffer[0x04]);
	pPlayer->pClient->OutPacket(SMSG_COMPRESSED_UPDATE_OBJECT,compressBuffer,(unsigned short)size);
#else
	pPlayer->pClient->OutPacket(SMSG_UPDATE_OBJECT,updateBuffer,(unsigned short)len);
#endif
}


void CUpdateObject::CreateObject(unsigned long guid, bool reset)
{
	PreCreateObject();

	*(unsigned long*)&updateBuffer[0x00] = 1;
	updateBuffer[0x04] = UPDATE_FULL;
	unsigned long c = AddCreateObjectData(&updateBuffer[0x05]) + 5;
	c += MakeUpdateBlock(&updateBuffer[c], reset);
	SendCompressedUpdate(guid, c);
	PostCreateObject();
}

void CUpdateObject::UpdateObject(unsigned long guid, unsigned long guidHigh, bool reset)
{
	*(unsigned long*)&updateBuffer[0x00] = 1;
	updateBuffer[0x04] = 0; // new byte
	updateBuffer[0x05] = UPDATE_PARTIAL;
	int c=Packets::PackGuidBuffer(&updateBuffer[0x06],guid,guidHigh)+6;
	/*
	*(unsigned char*)&updateBuffer[0x06] = 0xFF;
	*(unsigned long*)&updateBuffer[0x07] = guid;
	*(unsigned long*)&updateBuffer[0x0B] = guidHigh;
	SendCompressedUpdate(guid, MakeUpdateBlock(&updateBuffer[0x0F], reset) + 0x0F);
	*/
	SendCompressedUpdate(guid, MakeUpdateBlock(&updateBuffer[c], reset) + c /*0x0F*/);
}
void CUpdateObject::UpdateItem(unsigned long guid, CPlayer *owner, bool reset)
{
 	*(unsigned long*)&updateBuffer[0x00] = 1;
 	updateBuffer[0x04] = 0; // new byte
 	updateBuffer[0x05] = UPDATE_PARTIAL;
 	int c = Packets::PackGuidBuffer(&updateBuffer[0x06],guid,0x0000000)+6;
	int len = MakeUpdateBlock(&updateBuffer[c], reset) + c;
#if COMPRESSED_UO_PACKETS
 	unsigned long size = Compressor.Deflate(updateBuffer, len);
 	if(!size)
 	{
 		Debug.Log("CUpdateObject::SendCompressedUpdate() - deflate failed.");
 		return;
 	}
 	*(unsigned long*)&compressBuffer[0x00] = len;
 	size += 4;
 	Compressor.GetBuffer(&compressBuffer[0x04]);
#endif
#if COMPRESSED_UO_PACKETS
	owner->pClient->OutPacket(SMSG_COMPRESSED_UPDATE_OBJECT,compressBuffer,(unsigned short)size);
#else
	owner->pClient->OutPacket(SMSG_UPDATE_OBJECT,updateBuffer,(unsigned short)len);
#endif
}

void CUpdateObject::UpdateObjectOnlyPlayer(CPlayer *pPlayer, unsigned long guid, unsigned long guidHigh, bool reset)
{
	if (pPlayer->pClient) {
		*(unsigned long*)&updateBuffer[0x00] = 1;
		updateBuffer[0x04] = 0; // new byte
		updateBuffer[0x05] = UPDATE_PARTIAL;
		int c=Packets::PackGuidBuffer(&updateBuffer[0x06],guid,guidHigh)+6;
		SendCompressedUpdateOnlyPlayer(pPlayer, guid, MakeUpdateBlock(&updateBuffer[c], reset) + c);
		/*
		*(unsigned char*)&updateBuffer[0x06] = 0xFF;
		*(unsigned long*)&updateBuffer[0x07] = guid;
		*(unsigned long*)&updateBuffer[0x0B] = guidHigh;
		SendCompressedUpdateOnlyPlayer(pPlayer, guid, MakeUpdateBlock(&updateBuffer[0x0F], reset) + 0x0F);
		*/
	}
}

void CUpdateObject::SendCompressedUpdateNotMe(unsigned long guid, unsigned long len)
{
#if COMPRESSED_UO_PACKETS
	unsigned long size = Compressor.Deflate(updateBuffer, len);
	if(!size)
	{
		Debug.Log("CUpdateObject::SendCompressedUpdateNotMe() - deflate failed.");
		return;
	}
	*(unsigned long*)&compressBuffer[0x00] = len;
	size += 4;
	Compressor.GetBuffer(&compressBuffer[0x04]);
#endif

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
#if COMPRESSED_UO_PACKETS
						((CPlayer*)pNode->pObject)->pClient->OutPacket(SMSG_COMPRESSED_UPDATE_OBJECT,compressBuffer,(unsigned short)size);
#else
						((CPlayer*)pNode->pObject)->pClient->OutPacket(SMSG_UPDATE_OBJECT,updateBuffer,(unsigned short)len);
#endif
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
	c += MakeUpdateBlock(&updateBuffer[c], reset);
	SendCompressedUpdateNotMe(guid, c);
	PostCreateObjectNotMe();
}

void CUpdateObject::UpdateObjectNotMe(unsigned long guid, unsigned long guidHigh, bool reset)
{
	*(unsigned long*)&updateBuffer[0x00] = 1;
	updateBuffer[0x04] = 0;
	updateBuffer[0x05] = UPDATE_PARTIAL;
	/*
	*(unsigned char*)&updateBuffer[0x06] = 0xFF;
	*(unsigned long*)&updateBuffer[0x07] = guid;
	*(unsigned long*)&updateBuffer[0x0B] = guidHigh;
	unsigned long c = MakeUpdateBlock(&updateBuffer[0x0F], reset) + 0x0F;
	SendCompressedUpdateNotMe(guid, c);
	*/
	int c=Packets::PackGuidBuffer(&updateBuffer[0x06],guid,guidHigh)+6;
	SendCompressedUpdateNotMe(guid, MakeUpdateBlock(&updateBuffer[c], reset) + c);
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
	c += MakeUpdateBlock(&updateBuffer[c], reset);
#if COMPRESSED_UO_PACKETS
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
#else
	pPlayer->pClient->OutPacket(SMSG_UPDATE_OBJECT, updateBuffer, (unsigned short)c);
#endif
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
	updateBuffer[0x04] = 0;
	updateBuffer[0x05] = UPDATE_PARTIAL;
	/*
	*(unsigned char*)&updateBuffer[0x06] = 0xFF;
	*(unsigned long*)&updateBuffer[0x07] = guid;
	*(unsigned long*)&updateBuffer[0x0B] = guidHigh;
	unsigned long c = MakeUpdateBlock(&updateBuffer[0x0F], reset) + 0x0F;
	*/
	unsigned long c=Packets::PackGuidBuffer(&updateBuffer[0x06],guid,guidHigh)+6;
	c+=MakeUpdateBlock(&updateBuffer[c], reset);
#if COMPRESSED_UO_PACKETS
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
#else
	pPlayer->pClient->OutPacket(SMSG_UPDATE_OBJECT, updateBuffer, (unsigned short)c);
#endif
}
