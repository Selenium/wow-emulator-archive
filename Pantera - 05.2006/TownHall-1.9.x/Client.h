#ifndef CLIENT_H
#define CLIENT_H

#include "stdafx.h"
#include "TCPSocket.h"
#include "Queue.h"
#include "Defines.h"
#include "Player.h"
#include "Account.h"
#include "MsgHandlers.h"
#include "Packet.h"
//typedef void (*fMessageHandler)(class CClient *, struct _InData *);
#include "WowCrypt.h"
#include "Corpse.h"

struct _OutData
{
	char *buffer;
	unsigned short Size;
};

struct _InData
{
	unsigned short OpCode;
	unsigned short Read;
	char Data[1];
};


class CClient
{
public:
	CClient(void);
	~CClient(void);

	fMessageHandler* MessageHandlers;

	unsigned short NextLength;
	unsigned long NextOpCode;
	TCPSocket socket;
	void ProcessIncomingData(_InData *pData);
	time_t LastIncoming;

	bool DestroyMe;
	bool LoggingOut;
	bool LoggedInAndResting;
	Queue<_OutData> Outgoing;
	_OutData DataPending;

	time_t LastCast;
	unsigned long GuildInviteID;
	unsigned long GuildInvitee;

	unsigned long PartyInviteID;
	unsigned long PartyInvitee;

	WowCrypt Crypter;

	void Send(IPacket *pkg);
	void SendRegion(IPacket *pkg);
	void SendRegionNotMe(IPacket *pkg);
	void SendRegion(IPacket *pkg, float maxdist);
	void SendRegionNotMe(IPacket *pkg, float maxdist);

	void OutPacket(unsigned short OpCode, const void *buffer, unsigned short Length);
	void RegionOutPacket(unsigned short OpCode, void *buffer, unsigned short Length);
	void RegionOutPacketNotMe(unsigned short OpCode, void *buffer, unsigned short Length);
	void RegionOutPacket(unsigned short OpCode, void *buffer, unsigned short Length, float maxdist);
	void RegionOutPacketNotMe(unsigned short OpCode, void *buffer, unsigned short Length, float maxdist);

	inline void SendAuthChallenge(unsigned long N) 	{OutPacket(SMSG_AUTH_CHALLENGE,&N,4);	};
	inline void SendAuthResponse(unsigned char N) 	{OutPacket(SMSG_AUTH_RESPONSE,&N,1);	};
	void SendCharacterList();

	void EnterGame(unsigned long nCharacter);
	inline void SaveBindPoint()
	{
		char buffer[0x14];
		memset(buffer,0,0x14);
		memcpy(&buffer[0],&pPlayer->Data.BindLoc,sizeof(_Location));
		*(unsigned long*)&buffer[sizeof(_Location)]=pPlayer->Data.BindContinent;
		*(unsigned long*)&buffer[sizeof(_Location)+4] = pPlayer->Data.BindZone;
		OutPacket(SMSG_BINDPOINTUPDATE,buffer,0x14);
	}
	inline void SendChatBox();
	inline void SendKeyBindings();
	inline void SendTutorialFlags();
	inline void SendInitialSpells();
	inline void SendBuffBar();
	inline void SendCastResult();
	inline void SendActionButtons();
	inline void SendFactionData();
	inline void SendTimeSpeed();

	static void MsgSendIgnoreList(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgAddIgnore(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgDelIgnore(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgSendFriendList(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgAddFriend(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgDelFriend(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
	static void MsgSetActionButton(CClient *pClient, unsigned int msgID, CDataBuffer &Data);

	void RestStart();
	void RestStop();

	void LearnedSpell(unsigned long ID);
	void SendPlayerData(bool Create=false);
	void CompleteLogout();
	void ChannelMessage(unsigned char Channel, const char *message, unsigned long user, const char *channelname, unsigned long Language, unsigned long userhigh=0);

	CAccount *pAccount;
	CPlayer *pPlayer;
	void AddKnownDynamicObject(class CDynamicObject &GObject);
	void RemoveKnownDynamicObject(CDynamicObject &GObject);
	CPlayer::CPlayerDataObject *pDataObject;
	inline void UpdateObject(bool reset = true) {pPlayer->UpdateObject(reset);};
	inline void UpdateObjectNotMe(bool reset = true) {pPlayer->UpdateObjectNotMe(reset);};
	inline void UpdateObjectOnlyMe(bool reset = true) {pPlayer->UpdateObjectOnlyMe(reset);};
	CPlayer *Characters[10];
	unsigned long nCharacters;

	void AddKnownCreature(class CCreature &Creature);
	void AddKnownPlayer(CPlayer &Player);
	void AddKnownItem(class CItem &Item);
	void AddKnownCorpse(class CCorpse &Corpse);
	void AddKnownGameObject(class CGameObject &GObject);

	void UpdateKnownCreature(class CCreature &Creature);
	void UpdateKnownPlayer(CPlayer &Player);
	void UpdateKnownItem(class CItem &Item);
	void UpdateKnownCorpse(class CCorpse &Corpse);
	void UpdateKnownGameObject(class CGameObject &GObject);

	void RemoveKnownPlayer(CPlayer &Player);
	void RemoveKnownCreature(class CCreature &Creature);
	void RemoveKnownItem(class CItem &Item);
	void RemoveKnownCorpse(class CCorpse &Corpse);
	void RemoveKnownGameObject(class CGameObject &GObject);

	void RemoveKnownObject(CWoWObject &Object);

	void Echo(const char *,...);
	void ChannelMsgF(unsigned char channel,const char *format,...);
	void ChatSay(unsigned long Language,const char *Msg);
	void ChatYell(unsigned long Language,const char *Msg);
	//void ChatParty(unsigned long Language,const char *Msg);

	unsigned long LastMoveFlags;
	void Emote(unsigned long who, unsigned long animation, unsigned long code, unsigned long target, char *name, unsigned long targettype);
	void EmoteAnim(unsigned long animation, unsigned long who, unsigned long whohigh);
	void EmoteText(unsigned long who, unsigned long whohigh, unsigned long target, unsigned long targethigh, unsigned long code, char *name);
	void InterruptCast(unsigned long spell);
};

#endif // CLIENT_H
