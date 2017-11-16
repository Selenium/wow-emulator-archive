// (c) AbyssX Group
#include "../WorldEnvironment.h"
#ifdef CHANNELS

Channel::Channel(string name, Player *first)
{
	// LogManager::GetSingleton().Log("Channels.log", "Channel %s created.\n",name.c_str());
	mName = name;
	mOwner = first;
	mChanModes = CM_CHANNEL_ANNOUNCE;
	mPassword = "";
}

string Channel::GetName()
{
	return mName;
}

int Channel::GetPlayerCount()
{
	return (int)mPlayers.size();
}

Channel::ChanPlayerIterator Channel::GetPlayersStart()
{
	return mPlayers.begin();
}

Channel::ChanPlayerIterator Channel::GetPlayersEnd()
{
	return mPlayers.end();
}

int Channel::GetBannedPlayerCount()
{
	return (int)mBannedPlayers.size();
}

Channel::ChanBannedPlayerIterator Channel::GetBannedPlayersStart()
{
	return mBannedPlayers.begin();
}

Channel::ChanBannedPlayerIterator Channel::GetBannedPlayersEnd()
{
	return mBannedPlayers.end();
}

int Channel::GetIRCPlayerCount()
{
	return (int)mIRCPlayers.size();
}

Channel::ChanIRCPlayerIterator Channel::GetIRCPlayersStart()
{
	return mIRCPlayers.begin();
}

Channel::ChanIRCPlayerIterator Channel::GetIRCPlayersEnd()
{
	return mIRCPlayers.end();
}

int Channel::GetModes()
{
	return mChanModes;
}

int Channel::GetPlayerMode(QuadWord pGUID)
{
	return mPlayerModes[pGUID];
}

int Channel::AddPlayer(Player *p,string pass)
{
	if(mChanModes & CM_CHANNEL_PASSWORDED)
		if(mPassword != pass)
			return 3;
	Channel::ChanPlayerIterator j;
	for (j=mPlayers.begin(); j!=mPlayers.end(); j++)
	{
		if (p == (*j))
		{
//			// LogManager::GetSingleton().Log("Channels.log", "Channel %s: player %s could not be added: Existing.\n",mName.c_str(),p->GetName());
			return 1;
		}
	}

	Channel::ChanBannedPlayerIterator i;
	for (i=mBannedPlayers.begin(); i!=mBannedPlayers.end(); i++)
	{
		if (p->GetObjectGuid() == (*i))
		{
//			// LogManager::GetSingleton().Log("Channels.log", "Channel %s: player %s could not be added: Banned.\n",mName.c_str(),p->GetName());
			return 2;
		}
	}

	mPlayers.push_back(p);
	mPlayerModes[p->GetObjectGuid()] = 0x00;
	p->AddChannel(this);
	if(mOwner == p)
		mPlayerModes[p->GetObjectGuid()] = 0x01;
	// LogManager::GetSingleton().Log("Channels.log", "Channel %s: player %s added.\n",mName.c_str(),p->GetName().c_str());
	return 0;
}

bool Channel::RemovePlayer(Player *p,bool remove)
{
	Channel::ChanPlayerIterator i;

	for (i=mPlayers.begin(); i!=mPlayers.end(); i++)
	{
		if (p == (*i))
		{
			mPlayers.remove(p);
			mPlayerModes.erase(p->GetObjectGuid());
			if(remove) p->RemoveChannel(this);
			// LogManager::GetSingleton().Log("Channels.log", "Channel %s: player %s removed.\n",mName.c_str(),p->GetName().c_str());
			return true;
		}
	}
	// LogManager::GetSingleton().Log("Channels.log", "Channel %s: player %s could not be removed.\n",mName.c_str(),p->GetName().c_str());
	return false;
}

bool Channel::AddBannedPlayer(QuadWord p)
{
	Channel::ChanBannedPlayerIterator i;

	for (i=mBannedPlayers.begin(); i!=mBannedPlayers.end(); i++)
	{
		if (p == (*i))
		{
			// LogManager::GetSingleton().Log("Channels.log", "Channel %s: banned player with GUID %X could not be added: Existing.\n",mName.c_str(),p);
			return false;
		}
	}
	mBannedPlayers.push_back(p);
	// LogManager::GetSingleton().Log("Channels.log", "Channel %s: banned player with GUID %X added.\n",mName.c_str(),p);
	return true;
}

bool Channel::RemoveBannedPlayer(QuadWord p)
{
	Channel::ChanBannedPlayerIterator i;

	for (i=mBannedPlayers.begin(); i!=mBannedPlayers.end(); i++)
	{
		if (p == (*i))
		{
			mBannedPlayers.remove(p);
			// LogManager::GetSingleton().Log("Channels.log", "Channel %s: banned player with GUID %X removed.\n",mName.c_str(),p);
			return true;
		}
	}
	// LogManager::GetSingleton().Log("Channels.log", "Channel %s: banned player with GUID %X could not be removed.\n",mName.c_str(),p);
	return false;
}

int Channel::AddIRCPlayer(IRCPlayer *p,string pass)
{
#ifdef IRCPLAYERS
	if(mChanModes & CM_CHANNEL_PASSWORDED)
		if(mPassword != pass)
			return 3;
	Channel::ChanIRCPlayerIterator j;
	for (j=mIRCPlayers.begin(); j!=mIRCPlayers.end(); j++)
	{
		if (p == (*j))
		{
			// LogManager::GetSingleton().Log("Channels.log", "Channel %s: player %s could not be added: Existing.\n",mName.c_str(),p->GetName().c_str());
			return 1;
		}
	}

	Channel::ChanBannedPlayerIterator i;
	for (i=mBannedPlayers.begin(); i!=mBannedPlayers.end(); i++)
	{
		if (p->GetObjectGuid() == (*i))
		{
			// LogManager::GetSingleton().Log("Channels.log", "Channel %s: player %s could not be added:Banned.\n",mName.c_str(),p->GetName().c_str());
			return 2;
		}
	}

	mIRCPlayers.push_back(p);
	mPlayerModes[p->GetObjectGuid()] = 0x00;
	// LogManager::GetSingleton().Log("Channels.log", "Channel %s: player %s could not be added: Added.\n",mName.c_str(),p->GetName().c_str());
#endif
	return 0;
}

bool Channel::RemoveIRCPlayer(IRCPlayer *p)
{
#ifdef IRCPLAYERS
	Channel::ChanIRCPlayerIterator i;

	for (i=mIRCPlayers.begin(); i!=mIRCPlayers.end(); i++)
	{
		if (p == (*i))
		{
			mIRCPlayers.remove(p);
			mPlayerModes.erase(p->GetObjectGuid());
			// LogManager::GetSingleton().Log("Channels.log", "Channel %s: player %s removed.\n",mName.c_str(),p->GetName().c_str());
			return true;
		}
	}
	// LogManager::GetSingleton().Log("Channels.log", "Channel %s: player %s could not be removed.\n",mName.c_str(),p->GetName().c_str());
#endif
	return false;
}

bool Channel::SetPlayerMode(QuadWord pGUID,int mode)
{
	if(mPlayerModes.count(pGUID) == 0)
		return false;
	// LogManager::GetSingleton().Log("Channels.log", "Channel %s: player with GUID %X modes set: Mute: %s Moderator: %s.\n",mName.c_str(),pGUID,(mode & CM_PLAYER_MUTED) ? "true" : "false",(mode & CM_PLAYER_MODERATOR) ? "true" : "false");
	mPlayerModes[pGUID] = mode;
	return true;
}

void Channel::SetChannelMode(int mode)
{
	// LogManager::GetSingleton().Log("Channels.log", "Channel %s: modes set: Moderated: %s Passworded: %s Announce: %s.\n",mName.c_str(),(mode & CM_CHANNEL_MODERATED) ? "true" : "false",(mode & CM_CHANNEL_PASSWORDED) ? "true" : "false",(mode & CM_CHANNEL_ANNOUNCE) ? "true" : "false");
	mChanModes = mode;
}

Channel::~Channel()
{
	// LogManager::GetSingleton().Log("Channels.log", "Channel %s destroyed .\n",mName.c_str());
}

#endif
