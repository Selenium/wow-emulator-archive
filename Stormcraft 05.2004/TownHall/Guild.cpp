#include "stdafx.h"
#include "Globals.h"
#include "Defines.h"
#include "Client.h"
#include "Guild.h"
#include "UpdateBlock.h"

map<string, unsigned long> CGuild::AllGuilds;


CGuild *CGuild::GetGuild(CClient *pClient)
{
	
	CGuild *pGuild = NULL;
	if(pClient->pPlayer->Data.GuildID == 0 ||
		!DataManager.RetrieveObject((CWoWObject**)&pGuild, pClient->pPlayer->Data.GuildID))
	{
		char buffer[0x09];
		*(unsigned long*)&buffer[0x00] = 0x00; // bleh
		buffer[0x04] = 0; // string
		*(unsigned long*)&buffer[0x05] = 0x09; // You are not in a guild!
		pClient->OutPacket(SMSG_GUILD_COMMAND_RESULT, buffer, 0x09);
		return NULL;
	}
	return pGuild;
}

void CGuild::MsgGuildInvite(CClient *pClient, _InData *pData)
{
	CGuild *pGuild = GetGuild(pClient);
	if(pGuild == NULL)
		return;
	char name[0x10];
	strncpy(name, pData->Data, 0x0F);
	name[0x0F]=0;
	pGuild->Invite(pClient, name);
}

void CGuild::MsgGuildAccept(CClient *pClient, _InData *pData)
{
	CGuild *pGuild = NULL;
	if(pClient->GuildInviteID == 0 ||
		!DataManager.RetrieveObject((CWoWObject**)&pGuild, pClient->GuildInviteID))
	{
		// fixme: tell client it's not invited to shit!
		return;
	}
	pGuild->Accept(pClient);
}

void CGuild::MsgGuildDecline(CClient *pClient, _InData *pData)
{
	CGuild *pGuild = NULL;
	if(pClient->GuildInviteID == 0 ||
		!DataManager.RetrieveObject((CWoWObject**)&pGuild, pClient->GuildInviteID))
	{
		// fixme: tell client it's not invited to shit!
		return;
	}
	pGuild->Decline(pClient);
}

void CGuild::MsgGuildInfo(CClient *pClient, _InData *pData)
{
	CGuild *pGuild = GetGuild(pClient);
	if(pGuild == NULL)
		return;
	pGuild->ShowInfo(pClient);
}

void CGuild::MsgGuildRoster(CClient *pClient, _InData *pData)
{
	CGuild *pGuild = GetGuild(pClient);
	if(pGuild == NULL)
		return;
	pGuild->ShowRoster(pClient);
}

void CGuild::MsgGuildPromote(CClient *pClient, _InData *pData)
{
	CGuild *pGuild = GetGuild(pClient);
	if(pGuild == NULL)
		return;
	char name[0x10];
	strncpy(name, pData->Data, 0x0F);
	name[0x0F]=0;
	pGuild->Promote(pClient, name);
}

void CGuild::MsgGuildDemote(CClient *pClient, _InData *pData)
{
	CGuild *pGuild = GetGuild(pClient);
	if(pGuild == NULL)
		return;
	char name[0x10];
	strncpy(name, pData->Data, 0x0F);
	name[0x0F]=0;
	pGuild->Demote(pClient, name);
}

void CGuild::MsgGuildLeave(CClient *pClient, _InData *pData)
{
	CGuild *pGuild = GetGuild(pClient);
	if(pGuild == NULL)
		return;
	pGuild->Leave(pClient);
}

void CGuild::MsgGuildRemove(CClient *pClient, _InData *pData)
{
	CGuild *pGuild = GetGuild(pClient);
	if(pGuild == NULL)
		return;
	char name[0x10];
	strncpy(name, pData->Data, 0x0F);
	name[0x0F]=0;
	pGuild->Kick(pClient, name);
}

void CGuild::MsgGuildDisband(CClient *pClient, _InData *pData)
{
	CGuild *pGuild = GetGuild(pClient);
	if(pGuild == NULL)
		return;
	pGuild->Disband(pClient);
}

void CGuild::MsgGuildLeader(CClient *pClient, _InData *pData)
{
	CGuild *pGuild = GetGuild(pClient);
	if(pGuild == NULL)
		return;
	if(pData->Data[0] == 0)
	{
		pGuild->ShowLeader(pClient);
		return;
	}
	char name[0x10];
	memset(name, 0x0, 0x10);
	strncpy(name, pData->Data, 0x0F);
	name[0x0F]=0;
	pGuild->SetLeader(pClient, name);
}

void CGuild::MsgGuildMotd(CClient *pClient, _InData *pData)
{
	CGuild *pGuild = GetGuild(pClient);
	if(pGuild == NULL)
		return;
	char name[0x60];
	strncpy(name, pData->Data, 0x5F);
	name[0x5F]=0;
	pGuild->SetMotd(pClient, name);
}

void CGuild::MsgGuildQuery(CClient *pClient, _InData *pData)
{
	CGuild *pGuild = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pGuild, *(unsigned long*)pData->Data))
	{
#ifdef _DEBUG
		Debug.Log("Player requested a none existing guild cache.");
#endif
		return;
	}
	pGuild->Query(pClient);
}

void CGuild::MsgTabardVendorActivate(CClient *pClient, _InData *pData)
{
	pClient->OutPacket(MSG_TABARDVENDOR_ACTIVATE, pData->Data, 0x08);
}

void CGuild::MsgSaveGuildEmblem(CClient *pClient, _InData *pData)
{
	int error = 0;
	CGuild *pGuild = GetGuild(pClient);
	if(pGuild == NULL)
	{
		error = 2;
		pClient->OutPacket(MSG_SAVE_GUILD_EMBLEM, &error, 4);
		return;
	}
	if(pClient->pPlayer->Data.GuildRank != GUILDRANK_GM)
	{
		error = 4;
		pClient->OutPacket(MSG_SAVE_GUILD_EMBLEM, &error, 4);
	}
	pGuild->Data.EmblemStyle = *(unsigned long*)&pData->Data[0x08];
	pGuild->Data.EmblemColor = *(unsigned long*)&pData->Data[0x0C];
	pGuild->Data.BorderStyle = *(unsigned long*)&pData->Data[0x10];
	pGuild->Data.BorderColor = *(unsigned long*)&pData->Data[0x14];
	pGuild->Data.BackgroundColor = *(unsigned long*)&pData->Data[0x18];
	pClient->OutPacket(MSG_SAVE_GUILD_EMBLEM, &error, 4);
	pGuild->UpdateTabard();
}


CGuild::CGuild(void):CWoWObject(OBJ_GUILD)
{
}

CGuild::~CGuild(void)
{

}


void CGuild::Clear()
{
	CWoWObject::Clear();
	memset(&Data,0,sizeof(GuildData));
	Members.clear();
}

void CGuild::New()
{
	Clear();
	CWoWObject::New();
	EventsEligible=true;
	memberListDirty=false;
}
void CGuild::New(const char *Name, CClient *pClient)
{
	New();
	strncpy(Data.Name,Name,0x5F);
	Data.Name[0x5F]=0;
	strcpy(Data.Motd, "No message set.");
	Data.Leader = pClient->pPlayer->guid;
	string name = pClient->pPlayer->Data.Name;
	MakeLower(name);
	Members[name] = pClient->pPlayer->guid;
	memberListDirty=true;
	pClient->pPlayer->Data.GuildID = guid;
	pClient->pPlayer->Data.GuildRank = GUILDRANK_GM;

	Data.EmblemStyle = -1;
	Data.EmblemColor = -1;
	Data.BorderStyle = -1;
	Data.BorderColor = -1;
	Data.BackgroundColor = -1;
	//EventManager.AddEvent(*this, 6000000, EVENT_GUILD_CLEANUP, NULL, 0);
	CUpdateBlock block;
	char buffer[0x90];
	block.ResetBlock(buffer, 0x90);
	block.AddDataUpdate(PLAYER_MAX_BITS, pClient->pPlayer->guid, PLAYERGUID_HIGH);
	block.Add(PLAYER_GUILD_ID, guid);
	block.Add(PLAYER_GUILD_RANK, GUILDRANK_GM);
	int size;
	char *ptr = block.GetCompressedData(size);
	if(size)
		pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
}

bool CGuild::StoringData(ObjectStorage &Storage)
{
	return false; // no storing yet
	if (!guid)
		return false;
	map<string, unsigned long>::iterator i;
	unsigned int count = 0;
	for(i = Members.begin();i != Members.end();i++)
	{
		Data.Members[count++] = i->second;
	}
	for(;count < MAX_GUILDMEMBERS;count++)
		Data.Members[count] = 0;

	Storage.Allocate(sizeof(GuildData));
	memcpy(Storage.Data,&Data,sizeof(GuildData));
	return true;
}

bool CGuild::LoadingData(ObjectStorage &Storage)
{
	if (!guid)
		return false;
	memcpy(&Data,Storage.Data,sizeof(GuildData));

	int i;
	for(i = 0;i < MAX_GUILDMEMBERS;i++)
	{
		if(Data.Members[i] != 0)
		{
			CPlayer *pPlayer = NULL;
			if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, Data.Members[i]))
			{
			#ifdef _DEBUG
				Debug.Log("CGuild::LoadingData() - Unable to retrieve an object found in the member list.");
			#endif
				continue;
			}

			string name = pPlayer->Data.Name;
			MakeLower(name);
			Members[name] = pPlayer->guid;
		}
	}
	// make sure the leader is around!
	CPlayer *pPlayer = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, Data.Members[i]))
	{
		EventManager.AddEvent(*this, 1, EVENT_GUILD_DESTROY, NULL, 0);
	}
	return true;
}

void CGuild::ProcessEvent(WoWEvent &Event)
{
	if(Event.EventType == EVENT_GUILD_DESTROY)
	{
		DisbandNow();
	}
}

void CGuild::Invite(CClient *pClient, char *Name)
{
	if(!strlen(Name))
		return;
	int len;
#ifdef _DEBUG
	if(pClient->pPlayer->Data.GuildID != guid)
	{
		Debug.Log("CGuild::Invite() GuildID mismatch.");
		return;
	}
#endif

	char buffer[0x50];
	if(pClient->pPlayer->Data.GuildRank > GUILDRANK_INVITE)
	{
		*(unsigned long*)&buffer[0x00] = 0x03; // dunno, must be !2
		buffer[0x04] = 0; // string
		*(unsigned long*)&buffer[0x05] = 0x08; // guild permissions?
		pClient->OutPacket(SMSG_GUILD_COMMAND_RESULT, buffer, 0x09);
		return;
	}
	
	if(Members.size() == MAX_GUILDMEMBERS)
	{
		pClient->Echo("Guild is full. Bug the admins to increase the cap.");
		return;
	}

	string name = Name;
	MakeLower(name);
	map<string, unsigned long>::iterator i;
	i = DataManager.PlayerNames.find(name);
	if(i == DataManager.PlayerNames.end())
	{

		*(unsigned long*)&buffer[0x00] = 0x01; // cmd invite
		strcpy(&buffer[0x04], name.c_str());
		len = strlen(name.c_str())+0x05;
		buffer[len-1] = 0;
		*(unsigned long*)&buffer[len] = 0x0B; // player not found
		pClient->OutPacket(SMSG_GUILD_COMMAND_RESULT, buffer, len+4);
		return;
	}
	unsigned long PlayerID = i->second;
	CPlayer *pPlayer = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, PlayerID))
	{
#ifdef _DEBUG
		// woopsi!
		Debug.Log("CGuild::Invite() - Unable to retrieve a player object that was found in playernames");
#endif
		pClient->Echo("Internal error: Player not found");
		return;
	}
	if(pPlayer->pClient == NULL)
	{
		*(unsigned long*)&buffer[0x00] = 0x01; // cmd invite
		strcpy(&buffer[0x04], name.c_str());
		len = strlen(name.c_str())+0x05;
		buffer[len-1] = 0;
		*(unsigned long*)&buffer[len] = 0x0B; // player not found
		pClient->OutPacket(SMSG_GUILD_COMMAND_RESULT, buffer, len+4);
		return;
	}



	if(pPlayer->Data.GuildID != 0)
	{
		*(unsigned long*)&buffer[0x00] = 0x01; // cmd invite
		strcpy(&buffer[0x04], name.c_str());
		len = strlen(name.c_str())+0x05;
		buffer[len-1] = 0;
		*(unsigned long*)&buffer[len] = 0x03; // <name> is already in a guild.
		pClient->OutPacket(SMSG_GUILD_COMMAND_RESULT, buffer, len+4);
		return;
	}
	if(pPlayer->pClient->GuildInviteID != 0)
	{
		*(unsigned long*)&buffer[0x00] = 0x01; // cmd invite
		strcpy(&buffer[0x04], name.c_str());
		len = strlen(name.c_str())+0x05;
		buffer[len-1] = 0;
		*(unsigned long*)&buffer[len+4] = 0x05; // <name> has already been invited to a guild.
		pClient->OutPacket(SMSG_GUILD_COMMAND_RESULT, buffer, len+4);
		return;
	}

	pPlayer->pClient->GuildInviteID = guid;
	pPlayer->pClient->GuildInvitee = pClient->pPlayer->guid;

	// time to invite the sucker
	strcpy(buffer, pClient->pPlayer->Data.Name);
	len = strlen(pClient->pPlayer->Data.Name)+1;
	buffer[len-1]= 0;
	strcpy(&buffer[len], Data.Name);
	len += strlen(Data.Name)+1;
	buffer[len-1] = 0;
	pPlayer->pClient->OutPacket(SMSG_GUILD_INVITE, buffer, len);
}

void CGuild::Accept(CClient *pClient)
{
	int len;
	if(Members.size() == MAX_GUILDMEMBERS)
	{
		pClient->GuildInvitee = 0;
		pClient->GuildInviteID = 0;
		pClient->Echo("Guild is full. Bug the admins to increase the cap!");
		return;
	}

	string name = pClient->pPlayer->Data.Name;
	MakeLower(name);
	Members[name] = pClient->pPlayer->guid;
	memberListDirty=true;

	pClient->pPlayer->Data.GuildID = guid;
	pClient->pPlayer->Data.GuildRank = GUILDRANK_INITIATE;
	char buffer[0x90];

	CPlayer *pInviter = NULL;
	if(DataManager.RetrieveObject((CWoWObject**)&pInviter, OBJ_PLAYER, pClient->GuildInvitee))
	{
		pClient->pPlayer->Data.GuildTimestamp = pInviter->Data.GuildTimestamp;
		if(pInviter->pClient != NULL)
		{
			*(unsigned long*)&buffer[0x00] = 0x01; // cmd invite
			strcpy(&buffer[0x04], name.c_str());
			len = strlen(name.c_str())+0x05;
			buffer[len-1] = 0;
			*(unsigned long*)&buffer[len] = 0x00; // You have invited <name> blah blah
			pInviter->pClient->OutPacket(SMSG_GUILD_COMMAND_RESULT, buffer, len+4);
		}
	}
	// try to get the leader if the inviter isn't around
	else if(DataManager.RetrieveObject((CWoWObject**)&pInviter, OBJ_PLAYER, Data.Leader))
	{
		pClient->pPlayer->Data.GuildTimestamp = pInviter->Data.GuildTimestamp;
	}


	CUpdateBlock block;
	block.ResetBlock(buffer, 0x90);
	block.AddDataUpdate(PLAYER_MAX_BITS, pClient->pPlayer->guid, PLAYERGUID_HIGH);
	block.Add(PLAYER_GUILD_ID, pClient->pPlayer->Data.GuildID);
	block.Add(PLAYER_GUILD_RANK, pClient->pPlayer->Data.GuildRank);
	block.Add(PLAYER_GUILD_TIMESTAMP, pClient->pPlayer->Data.GuildTimestamp);
	char *ptr = block.GetCompressedData(len);
	if(len)
		pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, len);

	buffer[0x00] = GUILD_EVENT_JOINED;
	buffer[0x01] = 1; // nstrings
	strcpy(&buffer[0x02], name.c_str());
	len = strlen(name.c_str())+0x03;
	buffer[len-1] = 0;
	buffer[0x02] |= ('A' & ~'a'); // hopefully toUpper:)	
	OutPacket(SMSG_GUILD_EVENT, buffer, len);
	pClient->GuildInvitee = 0;
	pClient->GuildInviteID = 0;

	pClient->Echo("Welcome to guild %s. Type '/say tabard' to get your guild tabard.", Data.Name);
	ShowMotd(pClient);
}

void CGuild::Decline(CClient *pClient)
{
	pClient->GuildInviteID = 0;
	CPlayer *pInviter = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pInviter, OBJ_PLAYER, pClient->GuildInvitee))
	{
		pClient->GuildInvitee = 0;
		// player logged off and deleted his character?:)
		return;
	}
	pClient->GuildInvitee = 0;
	if(pInviter->pClient == NULL)
	{
		// player logged off?
		return;
	}
	pInviter->pClient->OutPacket(SMSG_GUILD_DECLINE, pClient->pPlayer->Data.Name, strlen(pClient->pPlayer->Data.Name)+1);
}

void CGuild::Kick(CClient *pClient, char *Name)
{
	if(!strlen(Name))
		return;
	char buffer[0x90];
	int len;
	if(pClient->pPlayer->Data.GuildRank > GUILDRANK_KICK)
	{
		*(unsigned long*)&buffer[0x00] = 0x03; // dunno, must be !2
		buffer[0x04] = 0; // string
		*(unsigned long*)&buffer[0x05] = 0x08; // guild permissions?
		pClient->OutPacket(SMSG_GUILD_COMMAND_RESULT, buffer, 0x09);
		return;
	}

	map<string, unsigned long>::iterator i;
	string name = Name;
	MakeLower(name);
	i = Members.find(name);
	if(i == Members.end())
	{
		*(unsigned long*)&buffer[0x00] = 0x0C; // cmd quit? dunno what to use, client doesn't care
		strcpy(&buffer[0x04], name.c_str());
		len = strlen(name.c_str())+0x05;
		buffer[len-1] = 0;
		*(unsigned long*)&buffer[len] = 0x0A; // <name> is not in your guild.
		pClient->OutPacket(SMSG_GUILD_COMMAND_RESULT, buffer, len+4);
		return;
	}
	if(i->second == Data.Leader)
	{
		// fixme: can't kick leader
		return;
	}
	
	if(i->second == pClient->pPlayer->guid)
	{
		// hmm ok
		Leave(pClient);
		return;
	}

	CPlayer *pPlayer = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, i->second))
	{
#ifdef _DEBUG
		Debug.Log("CGuild::Kick() - Unable to retrieve an object found in the member list.");
#endif
		pClient->Echo("Internal error: Player not found");
		return;
	}

	if(pPlayer->Data.GuildRank <= pClient->pPlayer->Data.GuildRank)
	{
		pClient->Echo("You must be a higher ranking guild member than the person you are going to kick.");
		return;
	}

	pPlayer->Data.GuildID = 0;
	pPlayer->Data.GuildRank = 0;
	pPlayer->Data.GuildTimestamp = 0;
	buffer[0x00] = GUILD_EVENT_REMOVED;
	buffer[0x01] = 2;
	strncpy(&buffer[0x02], pPlayer->Data.Name, 15);
	len = strlen(pPlayer->Data.Name)+3;
	buffer[len-1] = 0;
	strncpy(&buffer[len], pClient->pPlayer->Data.Name, 15);
	len += strlen(pClient->pPlayer->Data.Name);
	buffer[len] = 0;
	OutPacket(SMSG_GUILD_EVENT, buffer, len+1);

	Members.erase(i);
	memberListDirty=true;

	if(pPlayer->pClient != NULL)
	{
		*(unsigned long*)&buffer[0x00] = 0x0C; // cmd quit
		strcpy(&buffer[0x04], Data.Name);
		len = strlen(Data.Name)+0x05;
		buffer[len-1] = 0;
		*(unsigned long*)&buffer[len] = 0x00; // You are no longer a member of <name>
		pPlayer->pClient->OutPacket(SMSG_GUILD_COMMAND_RESULT, buffer, len+4);

		CUpdateBlock block;
		block.ResetBlock(buffer, 0x90);
		block.AddDataUpdate(PLAYER_MAX_BITS, pPlayer->guid, PLAYERGUID_HIGH);
		block.Add(PLAYER_GUILD_ID, pPlayer->Data.GuildID);
		block.Add(PLAYER_GUILD_RANK, pPlayer->Data.GuildRank);
		block.Add(PLAYER_GUILD_TIMESTAMP, pPlayer->Data.GuildTimestamp);
		char *ptr = block.GetCompressedData(len);
		if(len)
			pPlayer->pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, len);
	}
}

void CGuild::Leave(CClient *pClient)
{
	char buffer[0x68];
	if(pClient->pPlayer->guid == Data.Leader)
	{
		*(unsigned long*)&buffer[0x00] = 0x02;
		buffer[0x04] = 0; // string
		*(unsigned long*)&buffer[0x05] = 0x08; // leader can't leave without promoting someone
		pClient->OutPacket(SMSG_GUILD_COMMAND_RESULT, buffer, 0x09);
		return;
	}
	string name = pClient->pPlayer->Data.Name;
	MakeLower(name);
	Members.erase(name);
	memberListDirty=true;
	buffer[0x00] = GUILD_EVENT_LEFT;
	buffer[0x01] = 1;
	strncpy(&buffer[0x02], pClient->pPlayer->Data.Name, 15);
	int len = strlen(pClient->pPlayer->Data.Name)+3;
	buffer[len-1] = 0;
	OutPacket(SMSG_GUILD_EVENT, buffer, len);


	*(unsigned long*)&buffer[0x00] = 0x02; // cmd quit
	strcpy(&buffer[0x04], Data.Name);
	len = strlen(Data.Name)+0x05;
	buffer[len-1] = 0;
	*(unsigned long*)&buffer[len] = 0x00; // You are no longer a member of <name>
	pClient->OutPacket(SMSG_GUILD_COMMAND_RESULT, buffer, len+4);


	pClient->pPlayer->Data.GuildID = 0;
	pClient->pPlayer->Data.GuildRank = 0;
	pClient->pPlayer->Data.GuildTimestamp = 0;

	CUpdateBlock block;
	block.ResetBlock(buffer, 0x80);
	block.AddDataUpdate(PLAYER_MAX_BITS, pClient->pPlayer->guid, PLAYERGUID_HIGH);
	block.Add(PLAYER_GUILD_ID, pClient->pPlayer->Data.GuildID);
	block.Add(PLAYER_GUILD_RANK, pClient->pPlayer->Data.GuildRank);
	block.Add(PLAYER_GUILD_TIMESTAMP, pClient->pPlayer->Data.GuildTimestamp);
	char *ptr = block.GetCompressedData(len);
	if(len)
		pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, len);

}


void CGuild::Leave(CPlayer *pPlayer)
{
	if(pPlayer->guid == Data.Leader)
	{
		DisbandNow();
		return;
	}
	string name = pPlayer->Data.Name;
	MakeLower(name);
	Members.erase(name);
	memberListDirty=true;
	char buffer[0x12];
	buffer[0x00] = GUILD_EVENT_LEFT;
	buffer[0x01] = 1;
	strncpy(&buffer[0x02], pPlayer->Data.Name, 15);
	int len = strlen(pPlayer->Data.Name)+3;
	buffer[0x11] = 0;
	OutPacket(SMSG_GUILD_EVENT, buffer, len);
}

void CGuild::SetLeader(CClient *pClient, char *Name)
{
	if(!strlen(Name))
		return;
	char buffer[0x90];
	int len;
	if(pClient->pPlayer->guid != Data.Leader)
	{
		*(unsigned long*)&buffer[0x00] = 0x03; // dunno, must be !2
		buffer[0x04] = 0; // string
		*(unsigned long*)&buffer[0x05] = 0x08; // guild permissions?
		pClient->OutPacket(SMSG_GUILD_COMMAND_RESULT, buffer, 0x09);
		return;

	}

	map<string, unsigned long>::iterator i;
	string name = Name;
	MakeLower(name);
	i = Members.find(name);
	if(i == Members.end())
	{
		*(unsigned long*)&buffer[0x00] = 0x0C; // cmd quit? dunno what to use, client doesn't care
		strcpy(&buffer[0x04], name.c_str());
		len = strlen(name.c_str())+0x05;
		buffer[len-1] = 0;
		*(unsigned long*)&buffer[len] = 0x0A; // <name> is not in your guild.
		pClient->OutPacket(SMSG_GUILD_COMMAND_RESULT, buffer, len+4);
		return;
	}

	if(i->second == Data.Leader)
	{
		pClient->Echo("Yeah.. maybe in the matrix");
		return;
	}

	CPlayer *pPlayer = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, i->second))
	{
#ifdef _DEBUG
		Debug.Log("CGuild::SetLeader() - Unable to retrieve an object found in the member list.");
#endif
		pClient->Echo("Internal error: Player not found");
		return;
	}
	Data.Leader = pPlayer->guid;
	pPlayer->Data.GuildRank = GUILDRANK_GM;
	pClient->pPlayer->Data.GuildRank = GUILDRANK_OFFICER;
	
	buffer[0x00] = GUILD_EVENT_LEADER_CHANGED;
	buffer[0x01] = 2;
	strncpy(&buffer[0x02], pClient->pPlayer->Data.Name, 15);
	len = strlen(pClient->pPlayer->Data.Name)+3;
	buffer[len-1] = 0;
	strncpy(&buffer[len], pPlayer->Data.Name, 15);
	len += strlen(pPlayer->Data.Name);
	buffer[len] = 0;
	OutPacket(SMSG_GUILD_EVENT, buffer, len+1);

	CUpdateBlock block;
	block.ResetBlock(buffer, 0x90);
	block.AddDataUpdate(PLAYER_MAX_BITS, pClient->pPlayer->guid, PLAYERGUID_HIGH);
	block.Add(PLAYER_GUILD_RANK, pClient->pPlayer->Data.GuildRank);
	char *ptr = block.GetCompressedData(len);
	if(len)
		pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, len);

	if(pPlayer->pClient != NULL)
	{
		block.ResetBlock(buffer, 0x90);
		block.AddDataUpdate(PLAYER_MAX_BITS, pPlayer->guid, PLAYERGUID_HIGH);
		block.Add(PLAYER_GUILD_RANK, pPlayer->Data.GuildRank);
		char *ptr = block.GetCompressedData(len);
		if(len)
			pPlayer->pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, len);
	}
}

void CGuild::ShowLeader(CClient *pClient)
{
	char buffer[0x15];
	CPlayer *pPlayer = NULL;
	if(Data.Leader == pClient->pPlayer->guid)
	{
		pPlayer = pClient->pPlayer;
	}
	else if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, Data.Leader))
	{
#ifdef _DEBUG
		Debug.Log("CGuild::ShowLeader() - Unable to retrieve guild leader object.");
#endif
		pClient->Echo("Internal error: Player not found");
		return;
	}

	buffer[0x00] = GUILD_EVENT_LEADER_IS;
	buffer[0x01] = 1;
	strncpy(&buffer[0x02], pPlayer->Data.Name, 15);
	int len = strlen(pPlayer->Data.Name)+3;
	buffer[len-1] = 0;
	pClient->OutPacket(SMSG_GUILD_EVENT, buffer, len);
}

char *guildrank_names[] =
{
	"Guildmaster",
	"Officer",
	"Veteran",
	"Member",
	"Initiate",
};

void CGuild::Promote(CClient *pClient, char *Name)
{
	if(!strlen(Name))
		return;
	char buffer[0x90];
	int len;
	if(pClient->pPlayer->Data.GuildRank > GUILDRANK_PROMOTE)
	{
		*(unsigned long*)&buffer[0x00] = 0x03; // dunno, must be !2
		buffer[0x04] = 0; // string
		*(unsigned long*)&buffer[0x05] = 0x08; // guild permissions?
		pClient->OutPacket(SMSG_GUILD_COMMAND_RESULT, buffer, 0x09);
		return;
	}

	map<string, unsigned long>::iterator i;
	string name = Name;
	MakeLower(name);
	i = Members.find(name);
	if(i == Members.end())
	{
		*(unsigned long*)&buffer[0x00] = 0x0C; // cmd quit? dunno what to use, client doesn't care
		strcpy(&buffer[0x04], name.c_str());
		len = strlen(name.c_str())+0x05;
		buffer[len-1] = 0;
		*(unsigned long*)&buffer[len] = 0x0A; // <name> is not in your guild.
		pClient->OutPacket(SMSG_GUILD_COMMAND_RESULT, buffer, len+4);
		return;
	}
	if(i->second == pClient->pPlayer->guid)
	{
		pClient->Echo("Yeah.. maybe in the matrix.");
		return;
	}
	
	CPlayer *pPlayer = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, i->second))
	{
#ifdef _DEBUG
		Debug.Log("CGuild::Promote() - Unable to retrieve an object found in the member list.");
#endif
		pClient->Echo("Internal error: Player not found");
		return;
	}

	if(!(pClient->pPlayer->Data.GuildRank < pPlayer->Data.GuildRank))
	{
		pClient->Echo("You must be a higher ranking guild member than the person you are going to promote.");
		return;
	}

	if(pPlayer->Data.GuildRank == GUILDRANK_OFFICER && pClient->pPlayer->Data.GuildRank == GUILDRANK_GM)
	{
		pClient->Echo("Use the /gleader command to change guildmaster.");
		return;
	}

	if(pPlayer->Data.GuildRank-pClient->pPlayer->Data.GuildRank == 1)
	{
		pClient->Echo("You can only promote up to one rank below yours.");
		return;
	}

	pPlayer->Data.GuildRank--;
	if(pPlayer->Data.GuildRank < GUILDRANK_GM)
		pPlayer->Data.GuildRank = 0;

	buffer[0x00] = GUILD_EVENT_PROMOTION;
	buffer[0x01] = 2;
	strncpy(&buffer[0x02], pPlayer->Data.Name, 15);
	len = strlen(pPlayer->Data.Name)+3;
	buffer[len-1] = 0;
	strcpy(&buffer[len], guildrank_names[pPlayer->Data.GuildRank]);
	len += strlen(guildrank_names[pPlayer->Data.GuildRank])+1;
	buffer[len-1] = 0;
	OutPacket(SMSG_GUILD_EVENT, buffer, len);

	if(pPlayer->pClient != NULL)
	{
		CUpdateBlock block;
		block.ResetBlock(buffer, 0x90);
		block.AddDataUpdate(PLAYER_MAX_BITS, pPlayer->guid, PLAYERGUID_HIGH);
		block.Add(PLAYER_GUILD_RANK, pPlayer->Data.GuildRank);
		char *ptr = block.GetCompressedData(len);
		if(len)
			pPlayer->pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, len);
	}
}



void CGuild::Demote(CClient *pClient, char *Name)
{
	if(!strlen(Name))
		return;
	char buffer[0x90];
	int len;
	if(pClient->pPlayer->Data.GuildRank > GUILDRANK_DEMOTE)
	{
		*(unsigned long*)&buffer[0x00] = 0x03; // dunno, must be !2
		buffer[0x04] = 0; // string
		*(unsigned long*)&buffer[0x05] = 0x08; // guild permissions?
		pClient->OutPacket(SMSG_GUILD_COMMAND_RESULT, buffer, 0x09);
		return;
	}

	map<string, unsigned long>::iterator i;
	string name = Name;
	MakeLower(name);
	i = Members.find(name);
	if(i == Members.end())
	{
		*(unsigned long*)&buffer[0x00] = 0x0C; // cmd quit? dunno what to use, client doesn't care
		strcpy(&buffer[0x04], name.c_str());
		len = strlen(name.c_str())+0x05;
		buffer[len-1] = 0;
		*(unsigned long*)&buffer[len] = 0x0A; // <name> is not in your guild.
		pClient->OutPacket(SMSG_GUILD_COMMAND_RESULT, buffer, len+4);
		return;
	}
	if(i->second == pClient->pPlayer->guid)
	{
		pClient->Echo("Yeah.. maybe in the matrix.");
		return;
	}
	
	CPlayer *pPlayer = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, i->second))
	{
#ifdef _DEBUG
		Debug.Log("CGuild::Demote() - Unable to retrieve an object found in the member list.");
#endif
		pClient->Echo("Internal error: Player not found");
		return;
	}

	if(!(pClient->pPlayer->Data.GuildRank < pPlayer->Data.GuildRank))
	{
		pClient->Echo("You must be a higher ranking guild member than the person you are going to demote.");
		return;
	}


	if(pPlayer->Data.GuildRank == GUILDRANK_INITIATE)
	{
		pClient->Echo("You cannot demote that member any further.");
		return;
	}
	pPlayer->Data.GuildRank++;
	if(pPlayer->Data.GuildRank > GUILDRANK_INITIATE)
		pPlayer->Data.GuildRank = GUILDRANK_INITIATE;

	buffer[0x00] = GUILD_EVENT_DEMOTION;
	buffer[0x01] = 2;
	strncpy(&buffer[0x02], pPlayer->Data.Name, 15);
	len = strlen(pPlayer->Data.Name)+3;
	buffer[len-1] = 0;
	strcpy(&buffer[len], guildrank_names[pPlayer->Data.GuildRank]);
	len += strlen(guildrank_names[pPlayer->Data.GuildRank])+1;
	buffer[len-1] = 0;
	OutPacket(SMSG_GUILD_EVENT, buffer, len);

	if(pPlayer->pClient != NULL)
	{
		CUpdateBlock block;
		block.ResetBlock(buffer, 0x90);
		block.AddDataUpdate(PLAYER_MAX_BITS, pPlayer->guid, PLAYERGUID_HIGH);
		block.Add(PLAYER_GUILD_RANK, pPlayer->Data.GuildRank);
		char *ptr = block.GetCompressedData(len);
		if(len)
			pPlayer->pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, len);
	}
}

void CGuild::SetMotd(CClient *pClient, char *motd)
{
	char buffer[0x68];
	if(pClient->pPlayer->Data.GuildRank > GUILDRANK_MOTD)
	{
		*(unsigned long*)&buffer[0x00] = 0x03; // dunno, must be !2
		buffer[0x04] = 0; // string
		*(unsigned long*)&buffer[0x05] = 0x08; // guild permissions?
		pClient->OutPacket(SMSG_GUILD_COMMAND_RESULT, buffer, 0x09);
		return;
	}

	strncpy(Data.Motd, motd, 0x5F);
	Data.Motd[0x5F] = 0;
	if(strlen(Data.Motd))
	{
		buffer[0x00] = GUILD_EVENT_MOTD;
		buffer[0x01] = 1;
		strncpy(&buffer[0x02], Data.Motd, 0x5F);
		buffer[0x67] = 0;
		OutPacket(SMSG_GUILD_EVENT, buffer, strlen(Data.Motd)+3);
	}
}

void CGuild::ShowMotd(CClient *pClient)
{
	char buffer[0x68];
	int len = strlen(Data.Motd);
	if(len > 0)
	{
		buffer[0x00] = GUILD_EVENT_MOTD;
		buffer[0x01] = 1;
		strcpy(&buffer[0x02], Data.Motd);
		len += 3;
		buffer[0x67] = 0;
		pClient->OutPacket(SMSG_GUILD_EVENT, buffer, len);
	}
}

void CGuild::UpdateNumAccounts()
{
	Data.numCharacters = Members.size();
#ifndef ACCOUNTLESS
	map<unsigned long, unsigned long> accounts;
	map<string, unsigned long>::iterator i;
	for(i = Members.begin();i != Members.end();i++)
	{
		CPlayer *pPlayer = NULL;
		if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, i->second))
		{
		#ifdef _DEBUG
			Debug.Log("CGuild::UpdateNumAccounts() - Unable to retrieve an object found in the member list.");
		#endif
			return;
		}
		if(pPlayer->AccountID != 0)
		{
			accounts[pPlayer->AccountID] = pPlayer->AccountID;
		}
	}
	Data.numAccounts = accounts.size();
#endif
	memberListDirty = false;
}

void CGuild::ShowInfo(CClient *pClient)
{
	if(memberListDirty)
	{
		UpdateNumAccounts();
	}

	char buffer[0x74];
	int c = strlen(Data.Name)+1;
	strcpy(buffer, Data.Name);
	*(int*)&buffer[c] = Data.CreatedYear;
	c += 4;
	*(int*)&buffer[c] = Data.CreatedMonth;
	c += 4;
	*(int*)&buffer[c] = Data.CreatedDay;
	c += 4;
	*(int*)&buffer[c] = Data.numCharacters;
	c += 4;
	*(int*)&buffer[c] = Data.numAccounts;
	c += 4;
	pClient->OutPacket(SMSG_GUILD_INFO, buffer, c);
}

void CGuild::ShowRoster(CClient *pClient)
{
	if(memberListDirty)
	{
		UpdateNumAccounts();
	}
	char buffer[0x60+0x08+(0x14*MAX_GUILDMEMBERS)];
	strcpy(buffer, Data.Name);
	unsigned short c = strlen(buffer)+1;
	*(int*)&buffer[c] = Data.numCharacters;
	c += 4;
	*(int*)&buffer[c] = Data.numAccounts;
	c += 4;
	map<string, unsigned long>::iterator i;
	for(i = Members.begin();i != Members.end();i++)
	{
		CPlayer *pPlayer = NULL;
		if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, i->second))
		{
		#ifdef _DEBUG
			Debug.Log("CGuild::ShowRoster() - Unable to retrieve an object found in the member list.");
		#endif
			continue;
		}
		strcpy(&buffer[c], pPlayer->Data.Name);
		c += strlen(pPlayer->Data.Name)+1;
		*(unsigned long*)&buffer[c] = pPlayer->Data.GuildRank;
		c += 4;
	}
	pClient->OutPacket(SMSG_GUILD_ROSTER, buffer, c);
}

void CGuild::Disband(CClient *pClient)
{
	char buffer[0x68];
	if(pClient->pPlayer->guid != Data.Leader)
	{
		*(unsigned long*)&buffer[0x00] = 0x03; // dunno, must be !2
		buffer[0x04] = 0; // string
		*(unsigned long*)&buffer[0x05] = 0x08; // guild permissions?
		pClient->OutPacket(SMSG_GUILD_COMMAND_RESULT, buffer, 0x09);
		return;

	}
	DisbandNow(); 
}

void CGuild::DisbandNow()
{
	unsigned short data = GUILD_EVENT_DISBANDED;
	map<string, unsigned long>::iterator i;
	for(i = Members.begin();i != Members.end();i++)
	{
		CPlayer *pPlayer = NULL;
		if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, i->second))
		{
		#ifdef _DEBUG
			Debug.Log("CGuild::Disband() - Unable to retrieve an object found in the member list.");
		#endif
			// since we are deleting the guild who cares!
			continue;
		}
		pPlayer->Data.GuildID = 0;
		pPlayer->Data.GuildRank = 0;
		pPlayer->Data.GuildTimestamp = 0;
		if(pPlayer->pClient != NULL)
		{
			pPlayer->pClient->OutPacket(SMSG_GUILD_EVENT, &data, 0x02);
			char buffer[0x90];
			CUpdateBlock block;
			block.ResetBlock(buffer, 0x90);
			block.AddDataUpdate(PLAYER_MAX_BITS, pPlayer->guid, PLAYERGUID_HIGH);
			block.Add(PLAYER_GUILD_ID, pPlayer->Data.GuildID);
			block.Add(PLAYER_GUILD_RANK, pPlayer->Data.GuildRank);
			block.Add(PLAYER_GUILD_TIMESTAMP, pPlayer->Data.GuildTimestamp);
			int len;
			char *ptr = block.GetCompressedData(len);
			if(len)
				pPlayer->pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, len);
		}
	}
	string name = Data.Name;
	MakeLower(name);
	AllGuilds.erase(name);
	DataManager.DeleteObject(*this);
}

void CGuild::OutPacket(unsigned short OpCode, void *buffer, unsigned short Length)
{
	map<string, unsigned long>::iterator i;
	for(i = Members.begin();i != Members.end();i++)
	{
		CPlayer *pPlayer = NULL;
		if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, i->second))
		{
		#ifdef _DEBUG
			Debug.Log("CGuild::Outpacket() - Unable to retrieve an object found in the member list.");
		#endif
			continue;
		}
		if(pPlayer->pClient != NULL)
		{
			pPlayer->pClient->OutPacket(OpCode, buffer, Length);
		}
	}
}

void CGuild::Query(CClient *pClient)
{
	char buffer[0x78];
	*(unsigned long*)&buffer[0x00] = guid;
	int c = strlen(Data.Name)+5;
	strcpy(&buffer[0x04], Data.Name);
	*(int*)&buffer[c] = Data.EmblemStyle;
	c += 4;
	*(int*)&buffer[c] = Data.EmblemColor;
	c += 4;
	*(int*)&buffer[c] = Data.BorderStyle;
	c += 4;
	*(int*)&buffer[c] = Data.BorderColor;
	c += 4;
	*(int*)&buffer[c] = Data.BackgroundColor;
	c += 4;
	pClient->OutPacket(SMSG_GUILD_QUERY_RESPONSE, buffer, c);
}

void CGuild::GuildChannel(CClient *pClient, char *msg)
{
	char buffer[2048];
	memset(buffer,0,2048);
	int c = 0;
	buffer[c++]=CHAT_GUILD;
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

void CGuild::OfficerChannel(CClient *pClient, char *msg)
{
	if(pClient->pPlayer->Data.GuildRank == GUILDRANK_GM && !strnicmp(msg, "tabardreset", 11))
	{
		Data.EmblemStyle = -1;
		Data.EmblemColor = -1;
		Data.BorderStyle = -1;
		Data.BorderColor = -1;
		Data.BackgroundColor = -1;
		UpdateTabard();
		return;
	}
	char buffer[2048];
	if(pClient->pPlayer->Data.GuildRank > GUILDRANK_OFFICER)
	{
		*(unsigned long*)&buffer[0x00] = 0x03; // dunno, must be !2
		buffer[0x04] = 0; // string
		*(unsigned long*)&buffer[0x05] = 0x08; // guild permissions?
		pClient->OutPacket(SMSG_GUILD_COMMAND_RESULT, buffer, 0x09);
		return;
	}

	memset(buffer,0,2048);
	int c = 0;
	buffer[c++]=CHAT_OFFICER;
	*(unsigned long*)&buffer[c]=0x00;
	c+=4;
	*(unsigned long*)&buffer[c]=pClient->pPlayer->guid;
	c+=8;
	strncpy(&buffer[c],msg, 2034);
	c+=strlen(msg)+1;
	buffer[2046] = 0;
	buffer[c] = pClient->pPlayer->Data.StatusFlags;
	c++;
	map<string, unsigned long>::iterator i;
	for(i = Members.begin();i != Members.end();i++)
	{
		CPlayer *pPlayer = NULL;
		if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, i->second))
		{
		#ifdef _DEBUG
			Debug.Log("CGuild::OfficerChannel() - Unable to retrieve an object found in the member list.");
		#endif
			continue;
		}
		if(pPlayer->pClient != NULL && pPlayer->Data.GuildRank <= GUILDRANK_OFFICER)
		{
			pPlayer->pClient->OutPacket(SMSG_MESSAGECHAT, buffer, c);
		}
	}
}

void CGuild::UpdateTabard()
{
	CUpdateBlock block;
	char updateBuf[0x80];
	int size;
	char *ptr;
	map<string, unsigned long>::iterator i;
	for(i = Members.begin();i != Members.end();i++)
	{
		CPlayer *pPlayer = NULL;
		if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, i->second))
		{
		#ifdef _DEBUG
			Debug.Log("CGuild::UpdateTabard() - Unable to retrieve an object found in the member list.");
		#endif
			continue;
		}

		pPlayer->Data.GuildTimestamp++;
		if(pPlayer->pClient != NULL)
		{
			block.ResetBlock(updateBuf, 0x80);
			block.AddDataUpdate(PLAYER_MAX_BITS, pPlayer->guid, PLAYERGUID_HIGH);
			block.Add(PLAYER_GUILD_TIMESTAMP, pPlayer->Data.GuildTimestamp);
			if(pPlayer->Data.Items[SLOT_TABARD] != 0)
				block.Add(PLAYER_INV_SLOTS+SLOT_TABARD*2, 0,0);
			
			ptr = block.GetCompressedData(size);
			if(size)
			{
				pPlayer->pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
			}
			if(pPlayer->Data.Items[SLOT_TABARD] != 0)
			{
				block.ResetBlock(updateBuf, 0x80);
				block.AddDataUpdate(PLAYER_MAX_BITS, pPlayer->guid, PLAYERGUID_HIGH);
				block.Add(PLAYER_INV_SLOTS+SLOT_TABARD*2, pPlayer->Data.Items[SLOT_TABARD], ITEMGUID_HIGH);
				ptr = block.GetCompressedData(size);
				if(size)
				{
					pPlayer->pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
				}
			}
		}
	}
}
