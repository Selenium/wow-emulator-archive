#pragma once
#include "stdafx.h"
#include "TCPSocket.h"
#include "Queue.h"
#include "Index.h"
#include "Defines.h"
#include "Player.h"
#include "Account.h"
#include "MsgHandlers.h"

typedef void (*fMessageHandler)(class CClient *, struct _InData *);

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

	fMessageHandler MessageHandlers[MSG_HANDLERS];

	unsigned short NextLength;
	TCPSocket socket;
	void ProcessIncomingData(_InData *pData);
	time_t LastIncoming;

	bool DestroyMe;
	Queue<_OutData> Outgoing;
	_OutData DataPending;

	time_t LastCast;
	unsigned long GuildInviteID;
	unsigned long GuildInvitee;

	unsigned long PartyInviteID;
	unsigned long PartyInvitee;

	void OutPacket(unsigned short OpCode, void *buffer, unsigned short Length);
	void RegionOutPacket(unsigned short OpCode, void *buffer, unsigned short Length);
	void RegionOutPacketNotMe(unsigned short OpCode, void *buffer, unsigned short Length);
	void RegionOutPacket(unsigned short OpCode, void *buffer, unsigned short Length, float maxdist);
	void RegionOutPacketNotMe(unsigned short OpCode, void *buffer, unsigned short Length, float maxdist);

	inline void SendAuthChallenge(unsigned long N) 	{OutPacket(SMSG_AUTH_CHALLENGE,&N,4);	};
	inline void SendAuthResponse(unsigned char N) 	{OutPacket(SMSG_AUTH_RESPONSE,&N,1);	};
	void SendCharacterList();

	void EnterGame(unsigned long nCharacter);
	inline void SaveBindPoint();
	inline void SendChatBox();
	inline void SendKeyBindings();
	inline void SendTutorialFlags();
	inline void SendInitialSpells();
	inline void SendBuffBar();
	inline void SendActionButtons();
	inline void SendFactionData();
	inline void SendTimeSpeed();

	void LearnedSpell(unsigned long ID);
	void SendPlayerData(bool Create=false);
	void ChannelMessage(unsigned char Channel, const char *message, unsigned long user, const char *channelname, unsigned long Language);

	CAccount *pAccount;
	CPlayer *pPlayer;
	CPlayer *Characters[10];
	unsigned long nCharacters;
	
	void AddKnownCreature(class CCreature &Creature);
	void AddKnownPlayer(CPlayer &Player);
	void AddKnownItem(class CItem &Item);

	void UpdateKnownCreature(class CCreature &Creature);
	void UpdateKnownPlayer(CPlayer &Player);
	void UpdateKnownItem(class CItem &Item);

	void RemoveKnownPlayer(CPlayer &Player);
	void RemoveKnownCreature(class CCreature &Creature);
	void RemoveKnownItem(class CItem &Item);

	void RemoveKnownObject(CWoWObject &Object);

	void UpdateRunSpeed(CPlayer &Player);
	void Echo(const char *,...);
	void ChatSay(unsigned long Language,const char *Msg);
	void ChatYell(unsigned long Language,const char *Msg);
	//void ChatParty(unsigned long Language,const char *Msg);

	unsigned long LastMoveFlags;
	void Emote(unsigned long who, unsigned long animation, unsigned long code, unsigned long target, char *name, int plen, unsigned long targettype);
	void EmoteAnim(unsigned long animation, unsigned long who, unsigned long targettype);
	void EmoteText(unsigned long who, unsigned long target, unsigned long code, char *name, int plen, unsigned long targettype);
	void InterruptCast(unsigned long spell);
};

