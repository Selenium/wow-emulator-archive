#pragma once
#include "WoWObject.h"

#define MAX_GUILDMEMBERS 100
struct GuildData
{
	// cache query stuff
	char Name[0x60];
	int EmblemStyle;
	int EmblemColor;
	int BorderStyle;
	int BorderColor;
	int BackgroundColor;
	// end cache query stuff

	// ginfo stuff
	int CreatedYear;
	int CreatedMonth;
	int CreatedDay;
	int numCharacters;
	int numAccounts;

	char Motd[0x60];

	unsigned long Leader;
	unsigned long Members[MAX_GUILDMEMBERS]; // save the guid, the rest can be stored on the character
};

class CGuild:public CWoWObject
{
	map<string, unsigned long> Members;
	bool memberListDirty;
	void UpdateNumAccounts();
public:
	static map<string, unsigned long> AllGuilds;
	CGuild(void);
	~CGuild(void);

	GuildData Data;
	bool StoringData(ObjectStorage &Storage);
	bool LoadingData(ObjectStorage &Storage);
	unsigned long DataStorageSize() {return sizeof(GuildData);};

	void Clear();
	void New();
	void New(const char *Name, CClient *pClient);
	
	void ProcessEvent(struct WoWEvent &Event);

	void OutPacket(unsigned short OpCode, void *buffer, unsigned short Length);

	void Invite(CClient *pClient, char *Name);
	void Accept(CClient *pClient);
	void Decline(CClient *pClient);
	void Kick(CClient *pClient, char *Name);
	void Leave(CClient *pClient);
	void Leave(CPlayer *pPlayer);
	void SetLeader(CClient *pClient, char *Name);
	void ShowLeader(CClient *pClient);
	void Promote(CClient *pClient, char *Name);
	void Demote(CClient *pClient, char *Name);
	void SetMotd(CClient *pClient, char *motd);
	void ShowMotd(CClient *pClient);
	void ShowInfo(CClient *pClient);
	void ShowRoster(CClient *pClient);
	void DisbandNow();
	void Disband(CClient *pClient);
	void Query(CClient *pClient);
	void GuildChannel(CClient *pClient, char *msg);
	void OfficerChannel(CClient *pClient, char *msg);
	void UpdateTabard();

	// msg handlers
	static CGuild* GetGuild(CClient *pClient);
	
	static void MsgGuildInvite(CClient *pClient, _InData *pData);
	static void MsgGuildAccept(CClient *pClient, _InData *pData);
	static void MsgGuildDecline(CClient *pClient, _InData *pData);
	static void MsgGuildInfo(CClient *pClient, _InData *pData);
	static void MsgGuildRoster(CClient *pClient, _InData *pData);
	static void MsgGuildPromote(CClient *pClient, _InData *pData);
	static void MsgGuildDemote(CClient *pClient, _InData *pData);
	static void MsgGuildLeave(CClient *pClient, _InData *pData);
	static void MsgGuildRemove(CClient *pClient, _InData *pData);
	static void MsgGuildDisband(CClient *pClient, _InData *pData);
	static void MsgGuildLeader(CClient *pClient, _InData *pData);
	static void MsgGuildMotd(CClient *pClient, _InData *pData);
	static void MsgGuildQuery(CClient *pClient, _InData *pData);
	static void MsgTabardVendorActivate(CClient *pClient, _InData *pData);
	static void MsgSaveGuildEmblem(CClient *pClient, _InData *pData);
};
