#ifndef GUILD_H
#define GUILD_H

#include "WoWObject.h"

#define MAX_GUILDMEMBERS 100

#define PRIV_GCHAT_LISTEN 0x01
#define PRIV_GCHAT_SPEAK 0x02
#define PRIV_OCHAT_LISTEN 0x04
#define PRIV_OCHAT_SPEAK 0x08
#define PRIV_INVITE 0x10
#define PRIV_REMOVE 0x20
#define PRIV_PROMOTE 0x80
#define PRIV_DEMOTE 0x100
#define PRIV_SET_MOTD 0x1000
#define PRIV_EDIT_PUBLIC_NOTE 0x2000
#define PRIV_VIEW_OFFICER_NOTE 0x4000
#define PRIV_EDIT_OFFICER_NOTE 0x8000

struct RankData
{
	char Name[64];
	unsigned long Privileges;
};

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

	guid_t Leader;
	RankData Ranks[10];
	unsigned long nRanks;
	guid_t Members[MAX_GUILDMEMBERS]; // save the guid, the rest can be stored on the character
};

class CGuild:public CWoWObject
{
	map<string, guid_t> Members;
	bool memberListDirty;
	void UpdateNumAccounts();
public:
	static map<string, guid_t> AllGuilds;
	CGuild(void);
	~CGuild(void);

	GuildData Data;
	bool StoringData(ObjectStorage &Storage);
	bool LoadingData(ObjectStorage &Storage);

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

	static void MsgGuildInvite(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgGuildAccept(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgGuildDecline(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgGuildInfo(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgGuildRoster(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgGuildPromote(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgGuildDemote(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgGuildLeave(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgGuildRemove(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgGuildDisband(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgGuildLeader(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgGuildMotd(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgGuildQuery(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgTabardVendorActivate(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgSaveGuildEmblem(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgGuildRank(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgGuildAddRank(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgGuildDelRank(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgPublicNote(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgOfficerNote(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
};

#endif // GUILD_H
