// (c) AbyssX Group
#if !defined(CHANNELMANAGER_H)
#define CHANNELMANAGER_H

#ifdef CHANNELS

class ChannelManager
{
private:
	std::map<std::string,Channel *> mChannels;
	int CreateChannel(std::string name,Player *first){ mChannels[name] = new Channel(name,first); return mChannels[name]->AddPlayer(first,""); }
	void DeleteChan(std::string name) {delete mChannels[name]; mChannels.erase(name);}
public:
	bool ChanExists(std::string name){ return mChannels.count(name)==0 ? false : true; }
	ChannelManager() {}
	int PlayerJoinChannel(Player *p,std::string cName, std::string pass) { return ChanExists(cName) ? mChannels[cName]->AddPlayer(p,pass) : CreateChannel(cName,p); }
	bool PlayerLeftChannel(Player *p,std::string cName, bool remove=true)
	{
		if(ChanExists(cName) && mChannels[cName]->RemovePlayer(p,remove))
		{
			if(mChannels[cName]->GetPlayerCount() == 0)
				DeleteChan(cName);	
			return true;
		}
		return false;
	}
	int IRCPlayerJoinedChannel(IRCPlayer *p, std::string cName, std::string pass)  { return ChanExists(cName) ? mChannels[cName]->AddIRCPlayer(p,pass) : -1; }
	bool IRCPlayerLeftChannel(IRCPlayer *p, std::string cName)
	{
		if(!ChanExists(cName) || !mChannels[cName]->RemoveIRCPlayer(p))
			return false;
		return true;
	}
	bool AddBannedPlayer(QuadWord p, std::string cName)  { return ChanExists(cName) ? mChannels[cName]->AddBannedPlayer(p) : false; }
	bool RemoveBannedPlayer(QuadWord p, std::string cName)
	{
		if(!ChanExists(cName) || !mChannels[cName]->RemoveBannedPlayer(p))
			return false;
		return true;
	}
	Channel *GetChannel(std::string cName) { return ChanExists(cName) ? mChannels[cName] : NULL; }
	~ChannelManager()
	{
		std::map<std::string,Channel *>::iterator i;
		for (i=mChannels.begin(); i!=mChannels.end(); i++)
		{
			Channel *chan;
			chan = (*i).second;
			mChannels.erase(i);
			delete chan;
		}
	}
};

#endif

#endif