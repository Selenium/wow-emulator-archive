#include "stdafx.h"
#include "Globals.h"
#include "Defines.h"
#include "Client.h"
#include "Guild.h"
#include "UpdateBlock.h"
#include "Packets.h"

map<string, unsigned long> CGuild::AllGuilds;


CGuild *CGuild::GetGuild(CClient *pClient)
{
	CGuild *pGuild = NULL;
	if(pClient->pPlayer->Data.GuildID == 0 ||
		!DataManager.RetrieveObject((CWoWObject**)&pGuild, OBJ_GUILD, pClient->pPlayer->Data.GuildID))
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

void CGuild::MsgGuildInvite(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CGuild *pGuild = GetGuild(pClient);
	if(pGuild == NULL)
		return;
	char name[0x10];
	strncpy(name, Data.Buffer(), 0x0F);
	name[0x0F]=0;
	pGuild->Invite(pClient, name);
}

void CGuild::MsgGuildAccept(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CGuild *pGuild = NULL;
	if(pClient->GuildInviteID == 0 ||
		!DataManager.RetrieveObject((CWoWObject**)&pGuild, OBJ_GUILD, pClient->GuildInviteID))
	{
		// fixme: tell client it's not invited to shit!
		return;
	}
	pGuild->Accept(pClient);
}

void CGuild::MsgGuildDecline(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CGuild *pGuild = NULL;
	if(pClient->GuildInviteID == 0 ||
		!DataManager.RetrieveObject((CWoWObject**)&pGuild, OBJ_GUILD, pClient->GuildInviteID))
	{
		// fixme: tell client it's not invited to shit!
		return;
	}
	pGuild->Decline(pClient);
}

void CGuild::MsgGuildInfo(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CGuild *pGuild = GetGuild(pClient);
	if(pGuild == NULL)
		return;
	pGuild->ShowInfo(pClient);
}

void CGuild::MsgGuildRoster(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CGuild *pGuild = GetGuild(pClient);
	if(pGuild == NULL)
		return;
	pGuild->ShowRoster(pClient);
}

void CGuild::MsgGuildPromote(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CGuild *pGuild = GetGuild(pClient);
	if(pGuild == NULL)
		return;
	char name[0x10];
	strncpy(name, Data.Buffer(), 0x0F);
	name[0x0F]=0;
	pGuild->Promote(pClient, name);
}

void CGuild::MsgGuildDemote(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CGuild *pGuild = GetGuild(pClient);
	if(pGuild == NULL)
		return;
	char name[0x10];
	strncpy(name, Data.Buffer(), 0x0F);
	name[0x0F]=0;
	pGuild->Demote(pClient, name);
}

void CGuild::MsgGuildLeave(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CGuild *pGuild = GetGuild(pClient);
	if(pGuild == NULL)
		return;
	pGuild->Leave(pClient);
}

void CGuild::MsgGuildRemove(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CGuild *pGuild = GetGuild(pClient);
	if(pGuild == NULL)
		return;
	char name[0x10];
	strncpy(name, Data.Buffer(), 0x0F);
	name[0x0F]=0;
	pGuild->Kick(pClient, name);
}

void CGuild::MsgGuildDisband(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CGuild *pGuild = GetGuild(pClient);
	if(pGuild == NULL)
		return;
	pGuild->Disband(pClient);
}

void CGuild::MsgGuildLeader(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CGuild *pGuild = GetGuild(pClient);
	if(pGuild == NULL)
		return;
	if(Data.Buffer()[0] == 0)
	{
		pGuild->ShowLeader(pClient);
		return;
	}
	char name[0x10];
	memset(name, 0x0, 0x10);
	strncpy(name, Data.Buffer(), 0x0F);
	name[0x0F]=0;
	pGuild->SetLeader(pClient, name);
}

void CGuild::MsgGuildMotd(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CGuild *pGuild = GetGuild(pClient);
	if(pGuild == NULL)
		return;
	char name[0x60];
	strncpy(name, Data.Buffer(), 0x5F);
	name[0x5F]=0;
	pGuild->SetMotd(pClient, name);
}

void CGuild::MsgGuildQuery(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CGuild *pGuild = NULL;
	unsigned long id;
	Data >> id;
	if(!DataManager.RetrieveObject((CWoWObject**)&pGuild, OBJ_GUILD, id))
	{
		Debug.Log("CGuild::MsgGuildQuery() - Player requested a non-existing guild.");
		return;
	}
	pGuild->Query(pClient);
}

void CGuild::MsgTabardVendorActivate(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CPacket pkg(MSG_TABARDVENDOR_ACTIVATE, 14);
	pkg.Write(Data.Buffer(), 8);
	pClient->Send(&pkg);
}

void CGuild::MsgSaveGuildEmblem(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	CPacket pkg(MSG_SAVE_GUILD_EMBLEM, 10);
	CGuild *pGuild = GetGuild(pClient);
	unsigned long CreatureGuid,guid_high;
	if(pGuild == NULL)
	{
		pkg << 2;
		pClient->Send(&pkg);
		return;
	}
	if(pClient->pPlayer->Data.GuildRank != GUILDRANK_GM)
	{
		pkg << 4;
		pClient->Send(&pkg);
		return;
	}
	Data >> CreatureGuid >> guid_high; //seller guid; guid_high is always CREATUREGUID_HIGH
	Data >> pGuild->Data.EmblemStyle;
	Data >> pGuild->Data.EmblemColor;
	Data >> pGuild->Data.BorderStyle;
	Data >> pGuild->Data.BorderColor;
	Data >> pGuild->Data.BackgroundColor;
	pkg << 0;
	pClient->pPlayer->DataObject.SetCoinage(pClient->pPlayer->Data.Copper-100000); //costs 10 gold
	pClient->Send(&pkg);
	pGuild->UpdateTabard();
}

void CGuild::MsgGuildRank(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	unsigned long ID;
	string name;
	Data >> ID;
	CGuild *pGuild = GetGuild(pClient);
	if(pGuild == NULL) return;
	if(ID>=pGuild->Data.nRanks) return;
	if(pClient->pPlayer->Data.GuildRank != GUILDRANK_GM) return;
	Data >> pGuild->Data.Ranks[ID].Privileges;
	Data.Read(name);
	strcpy(pGuild->Data.Ranks[ID].Name,name.c_str());
	pGuild->ShowRoster(pClient);
	for(map<string, unsigned long>::iterator i = pGuild->Members.begin();i != pGuild->Members.end();i++)
	{
		CPlayer *pPlayer = NULL;
		if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, i->second))
		{
			Debug.Log("CGuild::MsgGuildRank() - Unable to retrieve an object found in the member list.");
			continue;
		}
		if(pPlayer->pClient) pGuild->Query(pPlayer->pClient);
	}
}

void CGuild::MsgGuildAddRank(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	string name;
	Data.Read(name);
	CGuild *pGuild = GetGuild(pClient);
	if(pGuild == NULL) return;
	if(pGuild->Data.nRanks>=10) return;
	if(pClient->pPlayer->Data.GuildRank != GUILDRANK_GM) return;
	strcpy(pGuild->Data.Ranks[pGuild->Data.nRanks].Name,name.c_str());
	pGuild->Data.nRanks++;
	pGuild->ShowRoster(pClient);
	for(map<string, unsigned long>::iterator i = pGuild->Members.begin();i != pGuild->Members.end();i++)
	{
		CPlayer *pPlayer = NULL;
		if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, i->second))
		{
			Debug.Log("CGuild::MsgGuildAddRank() - Unable to retrieve an object found in the member list.");
			continue;
		}
		if(pPlayer->pClient) pGuild->Query(pPlayer->pClient);
	}
}

void CGuild::MsgGuildDelRank(CClient *pClient, unsigned int msgID, CDataBuffer &Data) //only deletes the last rank
{
	CGuild *pGuild = GetGuild(pClient);
	if(pGuild == NULL) return;
	if(pClient->pPlayer->Data.GuildRank != GUILDRANK_GM) return;
	pGuild->Data.nRanks--;
	pGuild->Data.Ranks[pGuild->Data.nRanks].Name[0]='\0';
	pGuild->Data.Ranks[pGuild->Data.nRanks].Privileges=0;
	pGuild->ShowRoster(pClient);
	for(map<string, unsigned long>::iterator i = pGuild->Members.begin();i != pGuild->Members.end();i++)
	{
		CPlayer *pPlayer = NULL;
		if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, i->second))
		{
			Debug.Log("CGuild::MsgGuildDelRank() - Unable to retrieve an object found in the member list.");
			continue;
		}
		if(pPlayer->pClient) pGuild->Query(pPlayer->pClient);
	}
}

void CGuild::MsgPublicNote(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	string name,msg;
	Data.Read(name);
	Data.Read(msg);
	CGuild *pGuild = GetGuild(pClient);
	if(pGuild == NULL) return;
	if(!((pGuild->Data.Ranks[pClient->pPlayer->Data.GuildRank].Privileges) & PRIV_EDIT_PUBLIC_NOTE)) return;
	MakeLower(name);
	map<string, unsigned long>::iterator i;
	i = DataManager.PlayerNames.find(name);
	if(i == DataManager.PlayerNames.end()) return;
	unsigned long PlayerID = i->second;
	CPlayer *pPlayer = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, PlayerID)) return;
	strcpy(pPlayer->Data.GuildPublicNote,msg.c_str());
	pGuild->ShowRoster(pClient);
}

void CGuild::MsgOfficerNote(CClient *pClient, unsigned int msgID, CDataBuffer &Data)
{
	string name,msg;
	Data.Read(name);
	Data.Read(msg);
	CGuild *pGuild = GetGuild(pClient);
	if(pGuild == NULL) return;
	if(!((pGuild->Data.Ranks[pClient->pPlayer->Data.GuildRank].Privileges) & PRIV_EDIT_OFFICER_NOTE)) return;
	MakeLower(name);
	map<string, unsigned long>::iterator i;
	i = DataManager.PlayerNames.find(name);
	if(i == DataManager.PlayerNames.end()) return;
	unsigned long PlayerID = i->second;
	CPlayer *pPlayer = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, PlayerID)) return;
	strcpy(pPlayer->Data.GuildOfficerNote,msg.c_str());
	pGuild->ShowRoster(pClient);
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
	struct tm *currenttime;
	time_t now;
	now=time(0);
	currenttime=localtime(&now);
	Data.CreatedYear=currenttime->tm_year+1900;
	Data.CreatedMonth=currenttime->tm_mon+1;
	Data.CreatedDay=currenttime->tm_mday;

	memberListDirty=true;

	Data.EmblemStyle = -1;
	Data.EmblemColor = -1;
	Data.BorderStyle = -1;
	Data.BorderColor = -1;
	Data.BackgroundColor = -1;

	strcpy(Data.Ranks[0].Name,"Leader");
	Data.Ranks[0].Privileges=0xFFFF;
	strcpy(Data.Ranks[1].Name,"Officer");
	Data.Ranks[1].Privileges=0x30;
	strcpy(Data.Ranks[2].Name,"Veteran");
	strcpy(Data.Ranks[3].Name,"Member");
	strcpy(Data.Ranks[4].Name,"Initiate");
	Data.nRanks=5;

	pClient->pDataObject->SetGuildID(guid);
	pClient->pDataObject->SetGuildRank(GUILDRANK_GM);
	pClient->UpdateObject();
}

bool CGuild::StoringData(ObjectStorage &Storage)
{
	//return false; // no storing yet
	if (!guid)
		return false;
	map<string, guid_t>::iterator i;
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
				Debug.Log("CGuild::LoadingData() - Unable to retrieve an object found in the member list.");
				continue;
			}
			string name = pPlayer->Data.Name;
			MakeLower(name);
			Members[name] = pPlayer->guid;
			pPlayer->Data.GuildID=guid;
		}
	}
	// make sure the leader is around!
	/*
	CPlayer *pPlayer = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, Data.Members[i]))
	{
	EventManager.AddEvent(*this, 1, EVENT_GUILD_DESTROY, NULL, 0);
	}*/
	CGuild::AllGuilds[Data.Name] = guid;
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
		Debug.Log("CGuild::Invite() - GuildID mismatch.");
		return;
	}
#endif

	char buffer[0x50];
	if(!((Data.Ranks[pClient->pPlayer->Data.GuildRank].Privileges) & PRIV_INVITE))
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
		Debug.Log("CGuild::Invite() - Unable to retrieve a player that was found in playernames");
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

	pClient->pDataObject->SetGuildID(guid);
	pClient->pDataObject->SetGuildRank(Data.nRanks-1);

	char buffer[0x90];

	CPlayer *pInviter = NULL;
	if(DataManager.RetrieveObject((CWoWObject**)&pInviter, OBJ_PLAYER, pClient->GuildInvitee))
	{
		pClient->pDataObject->SetGuildTimestamp(pInviter->Data.GuildTimestamp);
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
		pClient->pDataObject->SetGuildTimestamp(pInviter->Data.GuildTimestamp);
	}

	pClient->UpdateObject();

	buffer[0x00] = GUILD_EVENT_JOINED;
	buffer[0x01] = 1; // nstrings
	strcpy(&buffer[0x02], name.c_str());
	len = strlen(name.c_str())+0x03;
	buffer[len-1] = 0;
	buffer[0x02] |= ('A' & ~'a'); // hopefully toUpper:)
	OutPacket(SMSG_GUILD_EVENT, buffer, len);
	pClient->GuildInvitee = 0;
	pClient->GuildInviteID = 0;

	pClient->Echo("Welcome to guild %s. Type '/say !tabard' to get your guild tabard.", Data.Name);
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
	if(!((Data.Ranks[pClient->pPlayer->Data.GuildRank].Privileges) & PRIV_REMOVE))
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
		Debug.Log("CGuild::Kick() - Unable to retrieve an object found in the member list.");
		pClient->Echo("Internal error: Player not found");
		return;
	}

	if(pPlayer->Data.GuildRank <= pClient->pPlayer->Data.GuildRank)
	{
		pClient->Echo("You must be a higher ranking guild member than the person you are going to kick.");
		return;
	}

	pPlayer->Data.GuildID=0;
	pPlayer->Data.GuildRank=0;
	pPlayer->Data.GuildTimestamp=0;
	pPlayer->Data.GuildOfficerNote[0]=0;
	pPlayer->Data.GuildPublicNote[0]=0;
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

		pPlayer->AddUpdateVal(PLAYER_GUILDID, pPlayer->Data.GuildID);
		pPlayer->AddUpdateVal(PLAYER_GUILDRANK, pPlayer->Data.GuildRank);
		pPlayer->AddUpdateVal(PLAYER_GUILD_TIMESTAMP, pPlayer->Data.GuildTimestamp);
		pPlayer->UpdateObject();
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


	pClient->pDataObject->SetGuildID(0);
	pClient->pDataObject->SetGuildRank(0);
	pClient->pDataObject->SetGuildTimestamp(0);
	pClient->pPlayer->Data.GuildOfficerNote[0]=0;
	pClient->pPlayer->Data.GuildPublicNote[0]=0;
	pClient->UpdateObject();
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

	if(pPlayer->pClient)
	{
		pPlayer->pClient->pDataObject->SetGuildID(0);
		pPlayer->pClient->pDataObject->SetGuildRank(0);
		pPlayer->pClient->pDataObject->SetGuildTimestamp(0);
		pPlayer->pClient->pPlayer->Data.GuildOfficerNote[0]=0;
		pPlayer->pClient->pPlayer->Data.GuildPublicNote[0]=0;
		pPlayer->pClient->UpdateObject();
	}
	else
	{
		pPlayer->Data.GuildID=0;
		pPlayer->Data.GuildRank=0;
		pPlayer->Data.GuildTimestamp=0;
		pPlayer->Data.GuildOfficerNote[0]=0;
		pPlayer->Data.GuildPublicNote[0]=0;
	}
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
		Debug.Log("CGuild::SetLeader() - Unable to retrieve an object found in the member list.");
		pClient->Echo("Internal error: Player not found");
		return;
	}
	Data.Leader = pPlayer->guid;

	pClient->pDataObject->SetGuildRank(GUILDRANK_OFFICER);
	pClient->UpdateObject();

	pPlayer->Data.GuildRank = GUILDRANK_GM;
	if(pPlayer->pClient != NULL)
	{
		pPlayer->AddUpdateVal(PLAYER_GUILDRANK, pPlayer->Data.GuildRank);
		pPlayer->UpdateObject();
	}

	buffer[0x00] = GUILD_EVENT_LEADER_CHANGED;
	buffer[0x01] = 2;
	strncpy(&buffer[0x02], pClient->pPlayer->Data.Name, 15);
	len = strlen(pClient->pPlayer->Data.Name)+3;
	buffer[len-1] = 0;
	strncpy(&buffer[len], pPlayer->Data.Name, 15);
	len += strlen(pPlayer->Data.Name);
	buffer[len] = 0;
	OutPacket(SMSG_GUILD_EVENT, buffer, len+1);
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
		Debug.Log("CGuild::ShowLeader() - Unable to retrieve guild leader object.");
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
	if(!((Data.Ranks[pClient->pPlayer->Data.GuildRank].Privileges) & PRIV_PROMOTE))
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
		Debug.Log("CGuild::Promote() - Unable to retrieve an object found in the member list.");
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
		pPlayer->AddUpdateVal(PLAYER_GUILDRANK, pPlayer->Data.GuildRank);
		pPlayer->UpdateObject();
	}
}

void CGuild::Demote(CClient *pClient, char *Name)
{
	if(!strlen(Name))
		return;
	char buffer[0x90];
	int len;
	if(!((Data.Ranks[pClient->pPlayer->Data.GuildRank].Privileges) & PRIV_DEMOTE))
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
		pClient->Echo("Yeah.. maybe in the matrix."); //player attempted self-promotion
		return;
	}

	CPlayer *pPlayer = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, i->second))
	{
		Debug.Log("CGuild::Demote() - Unable to retrieve an object found in the member list.");
		pClient->Echo("Internal error: Player not found");
		return;
	}

	if(!(pClient->pPlayer->Data.GuildRank < pPlayer->Data.GuildRank))
	{
		pClient->Echo("You must be a higher ranking guild member than the person you are going to demote.");
		return;
	}


	if(pPlayer->Data.GuildRank == Data.nRanks-1)
	{
		pClient->Echo("You cannot demote that member any further.");
		return;
	}
	pPlayer->Data.GuildRank++;
	if(pPlayer->Data.GuildRank > Data.nRanks-1)
		pPlayer->Data.GuildRank = Data.nRanks-1;

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
		pPlayer->AddUpdateVal(PLAYER_GUILDRANK, pPlayer->Data.GuildRank);
		pPlayer->UpdateObject();
	}
}

void CGuild::SetMotd(CClient *pClient, char *motd)
{
	char buffer[0x68];
	if(!((Data.Ranks[pClient->pPlayer->Data.GuildRank].Privileges) & PRIV_SET_MOTD))
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
			Debug.Log("CGuild::UpdateNumAccounts() - Unable to retrieve an object found in the member list.");
			return;
		}
		if(pPlayer->AccountID)
		{
			accounts[pPlayer->AccountID] = pPlayer->AccountID;
		}
	}
	Data.numAccounts = accounts.size();
#endif // ACCOUNTLESS
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
	CPacket pkg;
	pkg.Reset(SMSG_GUILD_ROSTER);
	pkg << (unsigned long)Data.numCharacters;
	pkg << Data.Motd;
	pkg << (uint8)0;	// guild info.
	pkg << (unsigned long)Data.nRanks;
	for(unsigned long r=0;r<Data.nRanks;r++) pkg<<Data.Ranks[r].Privileges;
	map<string, unsigned long>::iterator i;
	for(i = Members.begin();i != Members.end();i++)
	{
		CPlayer *pPlayer = NULL;
		if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, i->second))
		{
			Debug.Log("CGuild::ShowRoster() - Unable to retrieve an object found in the member list.");
			continue;
		}
		pkg << pPlayer->guid << PLAYERGUID_HIGH;
		//Packets::PackGuid(pkg,pPlayer->guid,PLAYERGUID_HIGH);
		pkg << (char)((pPlayer->pClient)?1:0);
		pkg << pPlayer->Data.Name;
		pkg << pPlayer->Data.GuildRank;
		pkg << (char)pPlayer->Data.Level << (char)pPlayer->Data.Class << (long)pPlayer->Data.Zone;
		if(!pPlayer->pClient) pkg << (float)((time(0)-pPlayer->Data.LastLogon)/86400.0f); //expressed as days since last logon
		//else pkg << (char)0;
		pkg << pPlayer->Data.GuildPublicNote;
		pkg << pPlayer->Data.GuildOfficerNote;
		//pkg << (long)0; lastonline
	}
	pClient->Send(&pkg);
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
	map<string, unsigned long>::iterator i;
	for(i = Members.begin();i != Members.end();i++)
	{
		CPlayer *pPlayer = NULL;
		if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, i->second))
		{
			Debug.Log("CGuild::Disband() - Unable to retrieve an object found in the member list.");
			// since we are deleting the guild who cares!
			continue;
		}
		if(pPlayer->pClient != NULL)
		{
			pPlayer->DataObject.SetGuildID(0);
			pPlayer->DataObject.SetGuildRank(0);
			pPlayer->DataObject.SetGuildTimestamp(0);
			pPlayer->Data.GuildOfficerNote[0]=0;
			pPlayer->Data.GuildPublicNote[0]=0;
			pPlayer->UpdateObject();
		}
		else
		{
			pPlayer->Data.GuildID=0;
			pPlayer->Data.GuildRank=0;
			pPlayer->Data.GuildTimestamp=0;
			pPlayer->Data.GuildOfficerNote[0]=0;
			pPlayer->Data.GuildPublicNote[0]=0;
		}
	}
	string name = Data.Name;
	MakeLower(name);
	AllGuilds.erase(name);
	Delete();
}

void CGuild::OutPacket(unsigned short OpCode, void *buffer, unsigned short Length)
{
	map<string, unsigned long>::iterator i;
	for(i = Members.begin();i != Members.end();i++)
	{
		CPlayer *pPlayer = NULL;
		if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, i->second))
		{
			Debug.Log("CGuild::OutPacket() - Unable to retrieve an object found in the member list.");
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
	char buffer[512];
	*(unsigned long*)&buffer[0x00] = guid;
	int c = strlen(Data.Name)+5;
	strcpy(&buffer[0x04], Data.Name);
	for(int r=0;r<10;r++) //fixed 10; even the blanks will be counted
	{
		strcpy(&buffer[c],Data.Ranks[r].Name);
		c+=strlen(Data.Ranks[r].Name)+1;
	}
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
	if(!((Data.Ranks[pClient->pPlayer->Data.GuildRank].Privileges) & PRIV_GCHAT_SPEAK))
	{
		*(unsigned long*)&buffer[0x00] = 0x03; // dunno, must be !2
		buffer[0x04] = 0; // string
		*(unsigned long*)&buffer[0x05] = 0x08; // guild permissions?
		pClient->OutPacket(SMSG_GUILD_COMMAND_RESULT, buffer, 0x09);
		return;
	}
	memset(buffer,0,2048);
	int c = 0;
	buffer[c++]=CHAT_GUILD;
	*(unsigned long*)&buffer[c]=0x00;
	c+=4;
	*(unsigned long*)&buffer[c]=pClient->pPlayer->guid;
	c+=4;
	*(unsigned long*)&buffer[c]=0;
	c+=4;
	//Packets::PackGuidBuffer(&buffer[c],pClient->pPlayer->guid,PLAYERGUID_HIGH);
	*(unsigned long*)&buffer[c]= strlen(msg)+1;
	c+=4;
	strcpy(&buffer[c],msg);
	c+=strlen(msg)+1;
	buffer[c] = (char)pClient->pPlayer->Data.StatusFlags;
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
	if(!((Data.Ranks[pClient->pPlayer->Data.GuildRank].Privileges) & PRIV_OCHAT_SPEAK))
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
	*(unsigned long*)&buffer[c]= strlen(msg)+1;
	c+=4;
	strncpy(&buffer[c],msg, 1536);
	c+=strlen(msg)+1;
	buffer[2046] = 0;
	buffer[c] = (char)pClient->pPlayer->Data.StatusFlags;
	c++;
	map<string, unsigned long>::iterator i;
	for(i = Members.begin();i != Members.end();i++)
	{
		CPlayer *pPlayer = NULL;
		if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, i->second))
		{
			Debug.Log("CGuild::OfficerChannel() - Unable to retrieve an object found in the member list.");
			continue;
		}
		if(pPlayer->pClient != NULL && ((Data.Ranks[pClient->pPlayer->Data.GuildRank].Privileges) & PRIV_OCHAT_LISTEN))
		{
			pPlayer->pClient->OutPacket(SMSG_MESSAGECHAT, buffer, c);
		}
	}
}

void CGuild::UpdateTabard()
{
	map<string, unsigned long>::iterator i;
	for(i = Members.begin();i != Members.end();i++)
	{
		CPlayer *pPlayer = NULL;
		if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, i->second))
		{
			Debug.Log("CGuild::UpdateTabard() - Unable to retrieve an object found in the member list.");
			continue;
		}

		pPlayer->Data.GuildTimestamp++;
		if(pPlayer->pClient != NULL)
		{
			pPlayer->AddUpdateVal(PLAYER_GUILD_TIMESTAMP, pPlayer->Data.GuildTimestamp);
			if(pPlayer->Items[SLOT_TABARD] != 0)
			{
				//pPlayer->AddUpdateVal(PLAYER_FIELD_INV_SLOT_HEAD+SLOT_TABARD*2, 0,0);
				//pPlayer->UpdateObject();
				pPlayer->AddUpdateVal(PLAYER_FIELD_INV_SLOT_HEAD+SLOT_TABARD*2, pPlayer->Items[SLOT_TABARD]->guid, ITEMGUID_HIGH);
			}

			pPlayer->UpdateObject();
		}
	}
}
