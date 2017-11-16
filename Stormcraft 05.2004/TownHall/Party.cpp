#include "stdafx.h"
#include "Globals.h"
#include "Defines.h"
#include "Client.h"
#include "Party.h"

map<string, unsigned long> CParty::AllPartys;


CParty *CParty::GetParty(CClient *pClient, bool chk)
{

	CParty *pParty = NULL;
	if(pClient->pPlayer->Data.PartyID == 0 ||
		!DataManager.RetrieveObject((CWoWObject**)&pParty, OBJ_PARTY, pClient->pPlayer->Data.PartyID))
	{
		if (chk)
		{
			char buffer[0x09];
			*(unsigned long*)&buffer[0x00] = 0x00; // bleh
			buffer[0x04] = 0; // string
			*(unsigned long*)&buffer[0x05] = 0x05; // You are not in a Party!
			pClient->OutPacket(SMSG_PARTY_COMMAND_RESULT, buffer, 0x09);
		}
		return NULL;
	}
	return pParty;
}

void CParty::MsgGroupInvite(CClient *pClient, _InData *pData)
{
	char Name[0x10];
	strncpy(Name, pData->Data, 0x0F);
	Name[0x0F]=0;

	int len;
	char buffer[0x50];
	if(pClient->pPlayer->Data.PartyRank == PARTYRANK_INVITE)
	{
		// TODO
		*(unsigned long*)&buffer[0x00] = 0x00; // 
		buffer[0x04] = 0; // string
		*(unsigned long*)&buffer[0x05] = 0x06; // Party permissions, not leader?
		pClient->OutPacket(SMSG_PARTY_COMMAND_RESULT, buffer, 0x05);
		return;
	}

	string name = Name;
	MakeLower(name);
	map<string, unsigned long>::iterator i;
	i = DataManager.PlayerNames.find(name);
	if(i == DataManager.PlayerNames.end())
	{
		*(unsigned long*)&buffer[0x00] = 0x00; // cmd invite
		strcpy(&buffer[0x04], name.c_str());
		len = strlen(name.c_str())+0x05;
		buffer[len-1] = 0;
		*(unsigned long*)&buffer[len] = 0x01; // bad player name
		pClient->OutPacket(SMSG_PARTY_COMMAND_RESULT, buffer, len+4);
		return;
	}
	unsigned long PlayerID = i->second;
	CPlayer *pPlayer = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, PlayerID))
	{
		//pClient->Echo("Internal error: Player not found");
		return;
	}
	if(pPlayer->pClient == NULL)
	{
		*(unsigned long*)&buffer[0x00] = 0x00; // cmd invite
		strcpy(&buffer[0x04], name.c_str());
		len = strlen(name.c_str())+0x05;
		buffer[len-1] = 0;
		*(unsigned long*)&buffer[len] = 0x01; // bad player name
		pClient->OutPacket(SMSG_PARTY_COMMAND_RESULT, buffer, len+4);
		return;
	}

	if(pPlayer->Data.PartyID != 0)
	{
		*(unsigned long*)&buffer[0x00] = 0x00; // cmd invite
		strcpy(&buffer[0x04], name.c_str());
		len = strlen(name.c_str())+0x05;
		buffer[len-1] = 0;
		*(unsigned long*)&buffer[len] = 0x04; // <name> is already in a Party.
		pClient->OutPacket(SMSG_PARTY_COMMAND_RESULT, buffer, len+4);
		return;
	}
	if(pPlayer->pClient->PartyInviteID != 0)
	{
		*(unsigned long*)&buffer[0x00] = 0x00; // cmd invite
		strcpy(&buffer[0x04], name.c_str());
		len = strlen(name.c_str())+0x05;
		buffer[len-1] = 0;
		*(unsigned long*)&buffer[len+4] = 0x08; // <name> has already been invited to a Party.
		pClient->OutPacket(SMSG_PARTY_COMMAND_RESULT, buffer, len+4);
		return;
	}

	// We create the group here
	CParty *pParty = GetParty(pClient, false);
	if(pParty == NULL) // create the group is doesnt exist
	{
		CParty *pParty = new CParty();
		pParty->New(pClient);
		DataManager.NewObject(*pParty);
		CParty::AllPartys[pClient->pPlayer->Data.Name] = pParty->guid;
	}

	pParty = GetParty(pClient, false);
	pParty->Invite(pClient, pPlayer);

}
void CParty::MsgGroupAccept(CClient *pClient, _InData *pData)
{
	if(pClient->PartyInviteID == 0)
	{
		// fixme: tell client it's not invited to shit!
		return;
	}
	CPlayer *pInviter = NULL;
	if(DataManager.RetrieveObject((CWoWObject**)&pInviter, OBJ_PLAYER, pClient->PartyInviteID))
	{
		CParty *pParty = GetParty(pInviter->pClient, false);
        if (pParty != NULL) {
            pParty->Accept(pClient);
        }
	}
	// TODO: The guys that invite him logged off
}
void CParty::MsgGroupCancel(CClient *pClient, _InData *pData)
{	
	char Name[0x10];
	memset(Name, 0x0, 0x10);
	strncpy(Name, pData->Data, 0x0F);
	Name[0x0F]=0;

	int len;
	char buffer[0x50];
	string name = Name;
	MakeLower(name);
	map<string, unsigned long>::iterator i;
	i = DataManager.PlayerNames.find(name);
	if(i == DataManager.PlayerNames.end())
	{
		*(unsigned long*)&buffer[0x00] = 0x00; // cmd invite
		strcpy(&buffer[0x04], name.c_str());
		len = strlen(name.c_str())+0x05;
		buffer[len-1] = 0;
		*(unsigned long*)&buffer[len] = 0x01; // bad player name
		pClient->OutPacket(SMSG_PARTY_COMMAND_RESULT, buffer, len+4);
		return;
	}
	unsigned long PlayerID = i->second;
	CPlayer *pPlayer = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, PlayerID))
	{
		//pClient->Echo("Internal error: Player not found");
		return;
	}
	if(pPlayer->pClient == NULL)
	{
		*(unsigned long*)&buffer[0x00] = 0x00; // cmd invite
		strcpy(&buffer[0x04], name.c_str());
		len = strlen(name.c_str())+0x05;
		buffer[len-1] = 0;
		*(unsigned long*)&buffer[len] = 0x01; // bad player name
		pClient->OutPacket(SMSG_PARTY_COMMAND_RESULT, buffer, len+4);
		return;
	}

	pPlayer->pClient->PartyInviteID = 0;
	pPlayer->pClient->PartyInvitee = 0;
	pPlayer->pClient->OutPacket(SMSG_GROUP_CANCEL,&pClient->pPlayer->Data.Name,strlen(pClient->pPlayer->Data.Name)+1);


}
void CParty::MsgGroupDecline(CClient *pClient, _InData *pData)
{
	if(pClient->PartyInviteID == 0)
	{
		// fixme: tell client it's not invited to shit!
		return;
	}

	CPlayer *pInviter = NULL;
	if(DataManager.RetrieveObject((CWoWObject**)&pInviter, OBJ_PLAYER, pClient->PartyInviteID))
	{
		CParty *pParty = GetParty(pInviter->pClient, false);
        if (pParty != NULL) {
            pParty->Decline(pClient);
        }
	}
}
void CParty::MsgGroupUninvite(CClient *pClient, _InData *pData)
{
	CParty *pParty = GetParty(pClient, true);
	if(pParty == NULL)
		return;
	
	char name[0x10];
	memset(name, 0x0, 0x10);
	strncpy(name, pData->Data, 0x0F);
	name[0x0F]=0;
	pParty->Leave(name);
}
void CParty::MsgGroupUninviteGuid(CClient *pClient, _InData *pData)
{
	CParty *pParty = GetParty(pClient, true);
	if(pParty == NULL)
		return;
    /*
	char name[0x10];
	memset(name, 0x0, 0x10);
	strncpy(name, pData->Data, 0x0F);
	name[0x0F]=0;

	pParty->Leave(name);*/
}
void CParty::MsgGroupSetLeader(CClient *pClient, _InData *pData)
{

	CParty *pParty = GetParty(pClient, true);
	if(pParty == NULL)
		return;

	char name[0x10];
	memset(name, 0x0, 0x10);
	strncpy(name, pData->Data, 0x0F);
	name[0x0F]=0;
	pParty->SetLeader(pClient, name);
}
void CParty::MsgGroupDisband(CClient *pClient, _InData *pData)
{
	CParty *pParty = GetParty(pClient, true);
	if(pParty == NULL)
		return;
	pParty->Disband(pClient);
}
void CParty::MsgLootMethod(CClient *pClient, _InData *pData)
{
	CParty *pParty = GetParty(pClient, true);
	if(pParty == NULL)
		return;
	pParty->Data.LootMethod = *(unsigned long*)&pData->Data[0];
}


CParty::CParty(void):CWoWObject(OBJ_PARTY)
{
}

CParty::~CParty(void)
{
}


void CParty::Clear()
{
	CWoWObject::Clear();
	memset(&Data,0,sizeof(PartyMembers));
}

void CParty::New()
{
	Clear();
	CWoWObject::New();
	EventsEligible=true;
}
void CParty::New(CClient *pClient)
{
	New();
	strncpy(Data.Name,pClient->pPlayer->Data.Name,0x5F);
	Data.Name[0x5F]=0;
	Data.LootMethod = 0x00;
	Data.Members[0] = pClient->pPlayer->guid;
	pClient->pPlayer->Data.PartyID = guid;
	pClient->pPlayer->Data.PartyRank = PARTYRANK_LEADER;
}

void CParty::ProcessEvent(WoWEvent &Event)
{
	if(Event.EventType == EVENT_PARTY_DESTROY)
	{
		DisbandNow();
	}
}

void CParty::Invite(CClient *pClient, CPlayer *pPlayer)
{
	// Dont need to check if its full because the client does ?
	// we pre-add him into the table, if he decline we remove him.
	// This way if the leader invite 3 ppl and the 1st one decline the
	// decline will know there is more invite and wont flush the party
	int j;
	for(j=0; j < 4 ; j++)
	{
		if (Data.Invites[j] == 0)
		{
			Data.Invites[j] = pPlayer->guid; // take the next free slot
		j=3;
		}
	}

	pPlayer->pClient->PartyInviteID = pClient->pPlayer->guid;
	pPlayer->pClient->PartyInvitee = pClient->pPlayer->guid;
	pPlayer->pClient->OutPacket(SMSG_GROUP_INVITE,&pClient->pPlayer->Data.Name,strlen(pClient->pPlayer->Data.Name)+1);
}
void CParty::Accept(CClient *pClient)
{
 	string Name = pClient->pPlayer->Data.Name;

	int len;

	int i;
	int j;
	for(i = 1; i < 5 ; i++)
	{
		if (Data.Members[i] == 0)
		{
			// find the name in the invite list then invite ! :)
			for (j = 0; j < 4; j++)
			{
				if (Data.Invites[j] == pClient->pPlayer->guid)
				{
					Data.Members[i] = Data.Invites[j]; // take the next free slot
					Data.Invites[j] = 0;
					i=4;
					j=3;
				}
			}
		}
	}
	
	for(i = 0; i < 4; i++) // reformat the Invites list
	{
		if (Data.Invites[i] == 0)
		{
			 Data.Invites[i] = Data.Invites[i + 1];
			 Data.Invites[i + 1] = 0;
		}
	}

	
	/*
    if(full != 0)
	{

	pClient->PartyInvitee = 0;
		pClient->PartyInviteID = 0;
		char buffer[0x50];
		*(unsigned long*)&buffer[0x00] = 0x00; // 
		buffer[0x04] = 0; // string
		*(unsigned long*)&buffer[0x05] = 0x03; // Party full
		pClient->OutPacket(SMSG_PARTY_COMMAND_RESULT, buffer, 0x9);
		return;
	}
*/
	pClient->pPlayer->Data.PartyID = guid;
	pClient->pPlayer->Data.PartyRank = PARTYRANK_MEMBER;

	char buffer[0x20];
	CPlayer *pInviter = NULL;
	if(DataManager.RetrieveObject((CWoWObject**)&pInviter, OBJ_PLAYER, pClient->PartyInvitee))
	{
		if(pInviter->pClient != NULL)
		{
			*(unsigned long*)&buffer[0x00] = 0x00; // cmd invite
			strcpy(&buffer[0x04], Name.c_str());
			len = strlen(Name.c_str())+0x05;
			buffer[len-1] = 0;
			*(unsigned long*)&buffer[len] = 0x00; // You have invited <name> blah blah
			pInviter->pClient->OutPacket(SMSG_PARTY_COMMAND_RESULT, buffer, len+4);
		}
	}

	SendGroupList();

	pClient->PartyInvitee = 0;
	pClient->PartyInviteID = 0;
	pClient->pPlayer->Data.LFG = 0;
}

void CParty::Decline(CClient *pClient)
{
	pClient->PartyInviteID = 0;
	CPlayer *pInviter = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pInviter, OBJ_PLAYER, pClient->PartyInvitee))
	{
		pClient->PartyInvitee = 0;
		// player logged off and deleted his character?:)
		return;
	}
	pClient->PartyInvitee = 0;

	if(pInviter->pClient == NULL)
	{
		// player logged off?
		return;
	}

	pInviter->pClient->OutPacket(SMSG_GROUP_DECLINE,&pClient->pPlayer->Data.Name, strlen(pClient->pPlayer->Data.Name)+1);

	CParty *pParty = GetParty(pInviter->pClient, false);
	if(pParty == NULL)
		return;

	int check=0;
	int i;
	for(i = 0; i < 4; i++)
	{
		if (Data.Invites[i] != 0)
		{
			CPlayer *pPlayer = NULL;
			if(DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, Data.Invites[i]))
			{
				if (!strcmp(pPlayer->Data.Name, pClient->pPlayer->Data.Name))
				{
					Data.Invites[i] = 0;
					check=i;
				}
			}
		}
	}

	for(i = check; i < 4; i++)
	{
		if (Data.Invites[i] == 0)
		{
			 Data.Invites[i] = Data.Invites[i + 1];
			 Data.Invites[i + 1] = 0;
		}
	}

	if (Data.Invites[0] == 0) // no member left
	{
		DisbandNow();
	}

}


void CParty::Leave(char *name)
{
	int check=0;
	int i;
	for(i = 0; i < 5; i++)
	{
		if (Data.Members[i] != 0)
		{
			CPlayer *pPlayer = NULL;
			if(DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, Data.Members[i]))
			{
				if (!strcmp(pPlayer->Data.Name, name))
				{
					if(pPlayer->guid == Data.Members[0]) // leader
					{
						if (Data.Members[1] != 0 && Data.Members[2] != 0)
						{
							for(i = 1; i < 5; i++) // set new leader if more than 2 ppl in the group left
							{
								if (Data.Members[i] != 0)
								{
									Data.Members[i - 1] = Data.Members[i];
									Data.Members[i]=0;
								}
							}
						}
						else // if only 1 person in group
						{
							DisbandNow();
							return;
						}
					}
					pPlayer->Data.PartyID = 0;
					pPlayer->Data.PartyRank = 0;
					Data.Members[i] = 0;
					check=i;

					if (pPlayer->pClient != NULL)
					pPlayer->pClient->OutPacket(SMSG_GROUP_UNINVITE,0,0);
					
				}
			}
		}
	}

	if (check != 0)
	{
		for(i = check; i < 5; i++)
		{
			if (Data.Members[i] != 0)
			{
				Data.Members[i - 1] = Data.Members[i];
				Data.Members[i]=0;
			}
		}
	}
	if (Data.Members[1] == 0) // no member left
	{
		DisbandNow();
		return;
	}

	SendGroupList(); // refresh group list
}

void CParty::SetLeader(CClient *pClient, char *Name)
{
	if(!strlen(Name))
		return;

	char buffer[0x68];
	memset(buffer,0,0x68);

	int check=0;
	int i;
	int len;
	string name = Name;
	
	if(pClient->pPlayer->guid != Data.Members[0])
	{
		*(unsigned long*)&buffer[0x00] = 0x03; // dunno, must be !2
		buffer[0x04] = 0; // string
		*(unsigned long*)&buffer[0x05] = 0x06; // Not the Leader !
		pClient->OutPacket(SMSG_PARTY_COMMAND_RESULT, buffer, 0x05);
		return;

	}	
	
	for (i = 0; i < 5 ; i++)
	{
		if(Data.Members[i] != 0)
		{
			CPlayer *pPlayer = NULL;
			if(DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, Data.Members[i]))
			{
				if (!strcmp(pPlayer->Data.Name, Name))
				{
					check = i;
				}
			}
		}
	}

	if (check == 0)
	{
		*(unsigned long*)&buffer[0x00] = 0x00; // cmd quit? dunno what to use, client doesn't care
		strcpy(&buffer[0x04], name.c_str());
		len = strlen(name.c_str())+0x05;
		buffer[len-1] = 0;
		*(unsigned long*)&buffer[len] = 0x05; // <name> is not in your Party.
		pClient->OutPacket(SMSG_PARTY_COMMAND_RESULT, buffer, len+4);
		return;
	}

	CPlayer *pMember = NULL;
	if(DataManager.RetrieveObject((CWoWObject**)&pMember, OBJ_PLAYER, Data.Members[check]))
	{
		Data.Members[check] = Data.Members[0];
		Data.Members[0] = pMember->guid;
		pMember->Data.PartyRank = PARTYRANK_LEADER;
		pClient->pPlayer->Data.PartyRank = PARTYRANK_MEMBER;
	}
	OutPacket(SMSG_GROUP_SET_LEADER,&pMember->Data.Name,strlen(pMember->Data.Name)+1);
	SendGroupList(); // send new leader !
}


void CParty::Disband(CClient *pClient)
{
	char buffer[0x68];
	if(pClient->pPlayer->guid != Data.Members[0])
	{
		*(unsigned long*)&buffer[0x00] = 0x03; // dunno, must be !2
		buffer[0x04] = 0; // string
		*(unsigned long*)&buffer[0x05] = 0x06; // Not the Leader !
		pClient->OutPacket(SMSG_PARTY_COMMAND_RESULT, buffer, 0x05);
		return;

	}
	DisbandNow(); 
}

void CParty::DisbandNow()
{
	unsigned short data = 0x00;
	int i;
	for(i = 0; i < 5; i++)
	{
		if (Data.Members[i] != 0)
		{
			CPlayer *pPlayer = NULL;
			if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, Data.Members[i]))
			{
			#ifdef _DEBUG
				Debug.Log("CParty::Disband() - Unable to retrieve an object found in the member list.");
			#endif
				// since we are deleting the Party who cares!
				continue;
			}
			pPlayer->Data.PartyID = 0;
			pPlayer->Data.PartyRank = 0;
			//SendGroupList();
			OutPacket(SMSG_GROUP_DESTROYED,0,0);
		}
	}
	string name = Data.Name;
	MakeLower(name);
	AllPartys.erase(name);
	DataManager.DeleteObject(*this);
}

void CParty::OutPacket(unsigned short OpCode, void *buffer, unsigned short Length)
{
	int i;
	for (i = 0; i < 5; i++)
	{
		if (Data.Members[i] != 0)
		{
			CPlayer *pPlayer = NULL;
			if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, Data.Members[i]))
			{
			#ifdef _DEBUG
				Debug.Log("CParty::Outpacket() - Unable to retrieve an object found in the member list.");
			#endif
				continue;
			}
			if(pPlayer->pClient != NULL)
			{
				pPlayer->pClient->OutPacket(OpCode, buffer, Length);
			}
		}
	}
}

void CParty::PartyChannel(CClient *pClient, char *msg)
{
	char buffer[2048];
	memset(buffer,0,2048);
	int c = 0;
	buffer[c++]=CHAT_PARTY;
	*(unsigned long*)&buffer[c]=0x00;
	c+=4;
	*(unsigned long*)&buffer[c]=pClient->pPlayer->guid;
	c+=8;
	strncpy(&buffer[c],msg, 2034);
	c+=strlen(msg)+1;
	buffer[2046] = 0;
	buffer[c] = pClient->pPlayer->Data.StatusFlags;
	c++;
	OutPacket(SMSG_MESSAGECHAT,buffer,c);
}
void CParty::SendGroupList()
{
	char buffer[5][0x100];
	memset(buffer,0,0x500);
	int nplayer=0;
	int length[5];
	int i=0;
	int j=0;
	int c;

	for (i = 0 ; i < 5 ; i++)  // build 5 packets for everyone in the party
	{
		c=0;
		if (Data.Members[i] != 0)
		{
			c=4;
			for (int j = 0 ; j < 5 ; j++)  // for everyone in the party except self
			{
				CPlayer *pMember = NULL;
				if(DataManager.RetrieveObject((CWoWObject**)&pMember, OBJ_PLAYER, Data.Members[j]))
				{	
					if (j != i) // never include the own player
					{
						if (pMember->pClient != NULL)
						{
							strcpy(&buffer[i][c],pMember->Data.Name);
							c+=strlen(&buffer[i][c])+1;
							*(unsigned long*)&buffer[i][c]=*(unsigned long*)&pMember->guid;
							c+=4;
							*(unsigned long*)&buffer[i][c]=0x00;
							c+=4;
							*(unsigned long*)&buffer[i][c]=0x01; // connected
							c+=1;
						}
						else
						{
							Leave(pMember->Data.Name); // player crashed !
						}
					}
					else
					{
						nplayer++;
					}
				}
			}
		}
	length[i]=c;
	}

	for (i = 0 ; i < 5 ; i++)  // build 5 packets for everyone in the party
	{
		if (Data.Members[i] != 0)
		{
			*(unsigned long*)&buffer[i][0x00]=nplayer-1; // number of ppl in the group
			//
			*(unsigned long*)&buffer[i][length[i]]=*(unsigned long*)&Data.Members[0]; // group leader
			length[i]+=4;
			*(unsigned long*)&buffer[i][length[i]]=0x00;
			length[i]+=4;
			*(unsigned long*)&buffer[i][length[i]]=*(unsigned long*)&Data.LootMethod; // looting method
			length[i]+=4;
		}
	}

	// send everyone in the Party his "buffer"
	for (i = 0 ; i < 5 ; i++) 
	{ 
		if (Data.Members[i] != 0)
		{
			CPlayer *pMember = NULL;
			if(DataManager.RetrieveObject((CWoWObject**)&pMember, OBJ_PLAYER, Data.Members[i]))
			{
				if (pMember->pClient != NULL)
					pMember->pClient->OutPacket(SMSG_GROUP_LIST,buffer[i],length[i]);
			}
		}
	}
}