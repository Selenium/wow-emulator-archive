#ifndef PARTY_H
#define PARTY_H

#include "WoWObject.h"

#define MAX_PARTYMEMBERS 5
struct PartyMembers
{
	char Name[0x60]; // for AllPartys
	// cache query stuff
	unsigned long Members[MAX_PARTYMEMBERS]; // save the guid, the rest can be stored on the character
	unsigned long Invites[MAX_PARTYMEMBERS-1]; // save the guid, the rest can be stored on the character
	unsigned long LootMethod;
};

class CParty:public CWoWObject
{
	void UpdateNumAccounts();
public:
	static map<string, unsigned long> AllPartys;
	CParty(void);
	~CParty(void);

	PartyMembers Data;
	void Clear();
	void New();
	void New(CClient *pClient);
	int Count();
	int GetMaxLevel();

	void ProcessEvent(struct WoWEvent &Event);

	void OutPacket(unsigned short OpCode, void *buffer, unsigned short Length);

	void Invite(CClient *pClient, CPlayer *pPlayer);
	void Accept(CClient *pClient);
	void Decline(CClient *pClient);
	void Leave(char *name);
	void SetLeader(CClient *pClient, char *Name);
	void DisbandNow();
	void Disband(CClient *pClient);
	void PartyChannel(CClient *pClient, char *msg);
	void SendGroupList();
	void ShareLoot(int copper);

	static CParty *GetParty(CClient *pClient, bool chk);

	static void MsgGroupInvite(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgGroupCancel(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgGroupAccept(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgGroupDecline(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgGroupUninvite(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgGroupUninviteGuid(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgGroupSetLeader(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgGroupDisband(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgLootMethod(CClient *pClient, unsigned int msgID, CDataBuffer &Data);

	void PartyExp(CCreature * pCreature);
	CPlayer * GetLooter(void);
};

#endif // PARTY_H
