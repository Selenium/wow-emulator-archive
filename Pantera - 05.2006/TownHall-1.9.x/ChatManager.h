#ifndef CHATMANAGER_H
#define CHATMANAGER_H

#define FUNCTYPE_NONE 0
#define FUNCTYPE_ARGS 1
#define FUNCTYPE_STRING 2
struct MsgHandler
{
	char *cmd;
	int Userlevel;
	void *func;
	unsigned long funcType;
};

typedef void (*MsgFuncNone)(CClient *pClient);
typedef void (*MsgFuncArgs)(CClient *pClient, char** argv, int argc);
typedef void (*MsgFuncString)(CClient *pClient, char *input);

class CChatManager
{
public:
	map<string, unsigned long> Mounts;
	map<string, unsigned long> WeaponInvFilter;
	map<string, unsigned long> ArmourInvFilter;
	map<string, unsigned long> InvTypes;
	map<string, unsigned long> ArmourTypes;
	map<string, unsigned long> WeaponTypes;
	map<string, int> UserLevels;
	map<string, unsigned long> Cloaks;
	map<string, unsigned long> Races;
	CChatManager(void);
	~CChatManager(void);

	static void InitCloaks();
	static void MsgChat(CClient *pClient, unsigned int msgID, CDataBuffer &Data);
};

class CChannel
{
	struct PlayerInfo
	{
		CPlayer *player;
		bool owner, moderator, muted;
	};
	typedef map<CPlayer*,PlayerInfo> PlayerList;
	PlayerList players;
	list<unsigned long> banned;
	string name;
	bool announce, constant, moderate;
	CPlayer *owner;
	string password;
private:
	CPacket *MakeNotifyPacket(CPacket *data, unsigned char code)
	{
		data->Reset(SMSG_CHANNEL_NOTIFY);
		*data << code << name.c_str();
		return data;
	}
	void MakeJoined(CPacket *data, CPlayer *joined) { *MakeNotifyPacket(data,0x00) << joined->guid << PLAYERGUID_HIGH; }
	void MakeLeft(CPacket *data, CPlayer *left) { *MakeNotifyPacket(data,0x01) << left->guid << PLAYERGUID_HIGH; }
	void MakeYouJoined(CPacket *data) { *MakeNotifyPacket(data,0x02) << ((unsigned long)(owner == NULL)?0:owner->guid) << PLAYERGUID_HIGH; } //<< (unsigned long)(players.size() > 1 ? 0x01 : 0x00); }
	void MakeYouLeft(CPacket *data) { MakeNotifyPacket(data,0x03); }
	void MakeWrongPass(CPacket *data) { MakeNotifyPacket(data,0x04); }
	void MakeNotOn(CPacket *data) { MakeNotifyPacket(data,0x05); }
	void MakeNotModerator(CPacket *data) { MakeNotifyPacket(data,0x06); }
	void MakeSetPassword(CPacket *data, CPlayer *who) { *MakeNotifyPacket(data,0x07) << who->guid << PLAYERGUID_HIGH; }
	void MakeChangeOwner(CPacket *data, CPlayer *who) { *MakeNotifyPacket(data,0x08) << who->guid << PLAYERGUID_HIGH; }
	void MakeNotOn(CPacket *data, const char *who) { *MakeNotifyPacket(data,0x09) << who; }
	void MakeNotOwner(CPacket *data) { MakeNotifyPacket(data,0x0A); }
	void MakeWhoOwner(CPacket *data) { *MakeNotifyPacket(data,0x0B) << ((constant || owner == NULL) ? "Nobody" : owner->Data.Name); }
	void MakeModeChange(CPacket *data, CPlayer *who, char moderator, char voice) // 0 - no change, 1 - lost, 2 - got
	{
		MakeNotifyPacket(data,0x0C);
		*data << who->guid << PLAYERGUID_HIGH;
		uint8 byte1 = 0x00, byte2 = 0x00;
		if(moderator == 1) byte1 |= 0x02;
		if(voice == 1) byte1 |= 0x04;

		if(moderator == 2) byte2 |= 0x02;
		if(voice == 2) byte2 |= 0x04;
		*data << byte1 << byte2;
	}
	void MakeEnabledAnnounce(CPacket *data, CPlayer *who) { *MakeNotifyPacket(data,0x0D) << who->guid << PLAYERGUID_HIGH; }
	void MakeDisabledAnnounce(CPacket *data, CPlayer *who) { *MakeNotifyPacket(data,0x0E) << who->guid << PLAYERGUID_HIGH; }
	void MakeAnnounce(CPacket *data, CPlayer *who, bool set) { set ? MakeEnabledAnnounce(data,who) : MakeDisabledAnnounce(data,who); }
	void MakeModerated(CPacket *data, CPlayer *who) { *MakeNotifyPacket(data,0x0F) << who->guid << PLAYERGUID_HIGH; }
	void MakeUnmoderated(CPacket *data, CPlayer *who) { *MakeNotifyPacket(data,0x10) << who->guid << PLAYERGUID_HIGH; }
	void MakeModerate(CPacket *data, CPlayer *who, bool set) { set ? MakeModerated(data,who) : MakeUnmoderated(data,who); }
	void MakeYouCantSpeak(CPacket *data) { MakeNotifyPacket(data,0x11); }
	void MakeKicked(CPacket *data, CPlayer *good, CPlayer *bad) { *MakeNotifyPacket(data,0x12) << bad->guid << PLAYERGUID_HIGH << good->guid << PLAYERGUID_HIGH; }
	void MakeYouAreBanned(CPacket *data) { MakeNotifyPacket(data,0x13); }
	void MakeBanned(CPacket *data, CPlayer *good, CPlayer *bad) { *MakeNotifyPacket(data,0x14) << bad->guid << PLAYERGUID_HIGH << good->guid << PLAYERGUID_HIGH; }
	void MakeUnbanned(CPacket *data, CPlayer *good, CPlayer *bad) { *MakeNotifyPacket(data,0x15) << bad->guid << PLAYERGUID_HIGH << good->guid << PLAYERGUID_HIGH; }
	// 16 unk
	void MakeAlreadyOn(CPacket *data, CPlayer *who) { *MakeNotifyPacket(data,0x17) << who->guid << PLAYERGUID_HIGH; }
	void MakeInvited(CPacket *data, CPlayer *who) { *MakeNotifyPacket(data,0x18) << who->guid << PLAYERGUID_HIGH; }
	void MakeWrongAlliance(CPacket *data, CPlayer *who) { *MakeNotifyPacket(data,0x19) << who->guid << PLAYERGUID_HIGH; }
	//....
	void MakeYouInvited(CPacket *data, CPlayer *who) { *MakeNotifyPacket(data,0x1D) << who->Data.Name; }

	void SendToAll(CPacket *data)
	{
		PlayerList::iterator i;
		for(i = players.begin(); i!=players.end(); i++)
			if(i->first->pClient) i->first->pClient->Send(data);
	}

	void SendToAllButOne(CPacket *data, CPlayer *who)
	{
		PlayerList::iterator i;
		for(i = players.begin(); i!=players.end(); i++)
			if(i->first != who)
				if(i->first->pClient) i->first->pClient->Send(data);
	}

	void SendToOne(CPacket *data, CPlayer *who)
	{
		if(who->pClient) who->pClient->Send(data);
	}

	bool IsOn(CPlayer *who)
	{
		return players.count(who) > 0;
	}

	bool IsBanned(const unsigned long guid)
	{
		list<unsigned long>::iterator i;
		for(i = banned.begin(); i!=banned.end(); i++)
			if(*i == guid)
				return true;
		return false;
	}

	bool IsFirst()
	{
		return !(players.size() > 1);
	}

	void SetOwner(CPlayer *p)
	{
		owner = p;
		if(owner != NULL)
		{
			CPacket data;
			MakeChangeOwner(&data,p);
			SendToAll(&data);
		}
	}

	void SetModerator(CPlayer *p, bool set)
	{
		if(players[p].moderator != set)
		{
			players[p].moderator = set;
			CPacket data;
			MakeModeChange(&data,p,set ? 2 : 1,0);
			SendToAll(&data);
		}
	}

	void SetMute(CPlayer *p, bool set)
	{
		if(players[p].muted != set)
		{
			players[p].muted = set;
			set = !set;
			CPacket data;
			MakeModeChange(&data,p,0,set ? 2 : 1);
			SendToAll(&data);
		}
	}

public:
	CChannel() : name(""), announce(true), constant(false), moderate(false), owner(NULL), password("")
	{
	}
	static map<string, CChannel*> AllChannels;
	void SetName(string newname) { name = newname; }
	string GetName() { return name; }
	bool IsConstant() { return constant; }
	bool IsAnnounce() { return announce; }
	string GetPassword() { return password; }
	void SetConstant(bool nconstant) { constant = nconstant; }
	void SetPassword(string npassword) { password = npassword; }
	void SetAnnounce(bool nannounce) { announce = nannounce; }
	unsigned long GetNumPlayers() { return players.size(); }

	void Join(CPlayer *p, const char *pass);
	void Leave(CPlayer *p, bool send = true);
	void KickOrBan(CPlayer *good, const char *badname, bool ban);
	void Kick(CPlayer *good, const char *badname) { KickOrBan(good,badname,false); }
	void Ban(CPlayer *good, const char *badname) { KickOrBan(good,badname,true); }
	void UnBan(CPlayer *good, const char *badname);
	void Password(CPlayer *p, const char *pass);
	void SetMode(CPlayer *p, const char *p2n, bool mod, bool set);
	void SetOwner(CPlayer *p, const char *newname);
	void GetOwner(CPlayer *p);
	void SetModerator(CPlayer *p, const char *newname) { SetMode(p,newname,true,true); }
	void UnsetModerator(CPlayer *p, const char *newname) { SetMode(p,newname,true,false); }
	void SetMute(CPlayer *p, const char *newname) { SetMode(p,newname,false,true); }
	void UnsetMute(CPlayer *p, const char *newname) { SetMode(p,newname,false,false); }
	void List(CPlayer *p);
	void Announce(CPlayer *p);
	void Moderate(CPlayer *p);
	void Say(CPlayer *p, const char *what);
	void Invite(CPlayer *p, const char *newp);
};

#endif // CHATMANAGER_H
