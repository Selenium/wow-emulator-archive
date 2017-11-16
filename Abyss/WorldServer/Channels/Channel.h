// (c) AbyssX Group
#if !defined(CHANNEL_H)
#define CHANNEL_H
#ifdef CHANNELS

class IRCPlayer;

class Channel
{
private:
	map<QuadWord,int> mPlayerModes;
	list<Player *> mPlayers;
	list<QuadWord> mBannedPlayers;
	list<IRCPlayer *> mIRCPlayers;
	int mChanModes;
	string mName;
	string mPassword;
	Player *mOwner;
public:
	typedef list<Player *>::iterator ChanPlayerIterator;
	typedef list<IRCPlayer *>::iterator ChanIRCPlayerIterator;
	typedef list<QuadWord>::iterator ChanBannedPlayerIterator;
	Channel(string name, Player *first);
	string GetName();
	int GetPlayerCount();
	ChanPlayerIterator GetPlayersStart();
	ChanPlayerIterator GetPlayersEnd();
	int GetBannedPlayerCount();
	ChanBannedPlayerIterator GetBannedPlayersStart();
	ChanBannedPlayerIterator GetBannedPlayersEnd();
	int GetIRCPlayerCount();
	ChanIRCPlayerIterator GetIRCPlayersStart();
	ChanIRCPlayerIterator GetIRCPlayersEnd();
	int GetModes();
	int GetPlayerMode(QuadWord pGUID);
	int GetTotalPlayerCount() {return GetIRCPlayerCount() + GetPlayerCount(); }
	int AddPlayer(Player *p, string pass);
	bool RemovePlayer(Player *p,bool remove=true);
	bool AddBannedPlayer(QuadWord pGUID);
	bool RemoveBannedPlayer(QuadWord pGUID);
	int AddIRCPlayer(IRCPlayer *p, string pass);
	bool RemoveIRCPlayer(IRCPlayer *p);
	bool SetPlayerMode(QuadWord pGUID,int mode);
	void SetChannelMode(int mode);
	void SetPassword(string password) { mPassword = password; }
	string GetPassword() { return mPassword; }
	Player *GetOwner() { return mOwner; }
	int SetOwner(Player *first, Player *second)
	{
		if(mOwner != first)
			return 1;
		
		Channel::ChanPlayerIterator i;
		for (i=mPlayers.begin(); i!=mPlayers.end(); i++)
		{
			if (second == (*i))
			{
				mOwner = second;
				mPlayerModes[second->GetObjectGuid()] |= CM_PLAYER_MODERATOR;
				mPlayerModes[second->GetObjectGuid()] &= ~CM_PLAYER_MUTED;
				return 0;
			}
		}
		return 2;
	}
	~Channel();
};

#endif
#endif
