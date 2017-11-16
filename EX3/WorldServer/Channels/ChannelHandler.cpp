// (c) AbyssX Group
#include "../WorldEnvironment.h"

#ifdef CHANNELS

ChannelHandler::ChannelHandler()
{
}

ChannelHandler::~ChannelHandler()
{
}

DoubleWord ChannelHandler::HandlePackets(Client *cli, Packet *pack)
{
	switch (pack->GetOpCode())
	{
			case CMSG_CHANNEL_LIST:
				HandlerMSG_CHANNEL_LIST(cli, pack);
				return 1;
				break;
			case CMSG_JOIN_CHANNEL:
				HandlerMSG_JOIN_CHANNEL(cli, pack);
				return 1;
				break;
			case CMSG_LEAVE_CHANNEL:
				HandlerMSG_LEAVE_CHANNEL(cli, pack);
				return 1;
				break;
			case CMSG_CHANNEL_PASSWORD:
				HandlerMSG_CHANNEL_PASSWORD(cli, pack);
				return 1;
				break;
			case CMSG_CHANNEL_SET_OWNER:
				HandlerMSG_CHANNEL_SET_OWNER(cli, pack);
				return 1;
				break;
			case CMSG_CHANNEL_OWNER:
				HandlerMSG_CHANNEL_OWNER(cli, pack); // Unsupported
				return 1;
				break;
			case CMSG_CHANNEL_MODERATOR:
				HandlerMSG_CHANNEL_MODERATOR(cli, pack);
				return 1;
				break;
			case CMSG_CHANNEL_UNMODERATOR:
				HandlerMSG_CHANNEL_UMODERATOR(cli, pack);
				return 1;
				break;
			case CMSG_CHANNEL_MUTE:
				HandlerMSG_CHANNEL_MUTE(cli, pack);
				return 1;
				break;
			case CMSG_CHANNEL_UNMUTE:
				HandlerMSG_CHANNEL_UNMUTE(cli, pack);
				return 1;
				break;
			//	HandlerMSG_CHANNEL_INVITE(cli, &pack); // Unsupported
			case CMSG_CHANNEL_KICK:
				HandlerMSG_CHANNEL_KICK(cli, pack);
				return 1;
				break;
			case CMSG_CHANNEL_BAN:
				HandlerMSG_CHANNEL_BAN(cli, pack);
				return 1;
				break;
			case CMSG_CHANNEL_UNBAN:
				HandlerMSG_CHANNEL_UNBAN(cli, pack);
				return 1;
				break;
			case CMSG_CHANNEL_ANNOUNCEMENTS:
				HandlerMSG_CHANNEL_ANNOUNCEMENTS(cli, pack);
				return 1;
				break;
			case CMSG_CHANNEL_MODERATE:
				HandlerMSG_CHANNEL_MODERATE(cli, pack);
				return 1;
				break;
	}

	return 0;
}

void ChannelHandler::HandlerMSG_JOIN_CHANNEL(Client *cli,Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Byte *cName = pack->GetBytes(0x00);
	Packet retPack;
	if(strlen((char *)cName) == 1)
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x02);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		retPack.AddDoubleWord(0x00);
		WorldServer::GetSingleton().WriteData(cli, &retPack);

		WorldServer::GetSingleton().AnnounceTo(cli,"You may not join 1-length channels.");

		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x03);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}
	Byte *pass = pack->GetBytes((Word)strlen((char *)cName)+1);
	int join = mChannelManager->PlayerJoinChannel(ply,(char *)cName,(char *)pass);
	if(join == 0)
	{
		bool owner = false;
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x00);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		retPack.AddQuadWord(ply->GetObjectGuid());
		WorldServer::GetSingleton().WriteData(cli,&retPack);

		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x02);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		if(mChannelManager->GetChannel((char *)cName)->GetPlayerCount() == 1)
		{
			retPack.AddByte(0x00);
			owner = true;
		}
		else
			retPack.AddByte(0x01);
		retPack.AddByte(0x00);
		retPack.AddByte(0x00);
		retPack.AddByte(0x00);
		WorldServer::GetSingleton().WriteData(cli, &retPack);

		Channel::ChanPlayerIterator i;

		for (i=mChannelManager->GetChannel((char *)cName)->GetPlayersStart(); i!=mChannelManager->GetChannel((char *)cName)->GetPlayersEnd(); i++)
		{
			if ((ply != (*i)) && (mChannelManager->GetChannel((char *)cName)->GetModes() & CM_CHANNEL_ANNOUNCE))
			{
				retPack.Build(SMSG_CHANNEL_NOTIFY);
				retPack.AddByte(0x00);
				retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
				retPack.AddQuadWord(ply->GetObjectGuid());
				WorldServer::GetSingleton().WriteData((*i)->GetClient(),&retPack);
			}
		}

		if(owner)
		{
			retPack.Build(SMSG_CHANNEL_NOTIFY);
			retPack.AddByte(0x08);
			retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
			retPack.AddQuadWord(ply->GetObjectGuid());
			WorldServer::GetSingleton().WriteData(cli,&retPack);
		}
	}
	else if(join == 1)
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x17);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		retPack.AddQuadWord(ply->GetObjectGuid());
		WorldServer::GetSingleton().WriteData(cli,&retPack);
	}
	else if(join == 2)
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x13);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli, &retPack);
	}
	else if(join == 3)
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x04);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli, &retPack);
	}
}

void ChannelHandler::HandlerMSG_LEAVE_CHANNEL(Client *cli,Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Byte *cName = pack->GetBytes(0x00);
	Packet retPack;
	if(mChannelManager->PlayerLeftChannel(ply,(char *)cName))
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x03);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);

		if(mChannelManager->ChanExists((char *)cName))
		{
			Channel::ChanPlayerIterator i;

			for (i=mChannelManager->GetChannel((char *)cName)->GetPlayersStart(); i!=mChannelManager->GetChannel((char *)cName)->GetPlayersEnd(); i++)
			{
				if ((ply != (*i)) && (mChannelManager->GetChannel((char *)cName)->GetModes() & CM_CHANNEL_ANNOUNCE))
				{
					retPack.Build(SMSG_CHANNEL_NOTIFY);
					retPack.AddByte(0x01);
					retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
					retPack.AddQuadWord(ply->GetObjectGuid());
					WorldServer::GetSingleton().WriteData((*i)->GetClient(),&retPack);
				}
			}

			if(mChannelManager->GetChannel((char *)cName)->GetOwner() == ply) 
			{
				mChannelManager->GetChannel((char *)cName)->SetOwner(ply,(*mChannelManager->GetChannel((char *)cName)->GetPlayersStart()));
				for (i=mChannelManager->GetChannel((char *)cName)->GetPlayersStart(); i!=mChannelManager->GetChannel((char *)cName)->GetPlayersEnd(); i++)
				{
					if ((ply != (*i)) && (mChannelManager->GetChannel((char *)cName)->GetModes() & CM_CHANNEL_ANNOUNCE))
					{
						retPack.Build(SMSG_CHANNEL_NOTIFY);
						retPack.AddByte(0x08);
						retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
						retPack.AddQuadWord(mChannelManager->GetChannel((char *)cName)->GetOwner()->GetObjectGuid());
						WorldServer::GetSingleton().WriteData((*i)->GetClient(),&retPack);
					}
				}
			}

		}
	}
	else
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x05);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
	}
}
void ChannelHandler::HandlerMSG_CHANNEL_PASSWORD(Client *cli,Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Byte *cName = pack->GetBytes(0x00);
	Byte *pass = pack->GetBytes((Word)strlen((char *)cName)+1);
	Packet retPack;
	if(!mChannelManager->ChanExists((char *)cName))
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x05);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	Channel *chan = mChannelManager->GetChannel((char *)cName);
	if(chan->GetOwner() != ply)
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x0A);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}
	
	if(strlen((char *)pass) == 0)
		chan->SetChannelMode(chan->GetModes() & ~CM_CHANNEL_PASSWORDED);
	else
		chan->SetChannelMode(chan->GetModes() | CM_CHANNEL_PASSWORDED);

	chan->SetPassword((char *)pass);

	Channel::ChanPlayerIterator i;

	for (i=chan->GetPlayersStart(); i!=chan->GetPlayersEnd(); i++)
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x07);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		retPack.AddQuadWord(ply->GetObjectGuid());
		retPack.AddBytes(pass,(Word)strlen((char *)pass));
		retPack.AddByte(0x00);
		WorldServer::GetSingleton().WriteData((*i)->GetClient(),&retPack);
	}
}

void ChannelHandler::HandlerMSG_CHANNEL_SET_OWNER(Client *cli,Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Byte *cName = pack->GetBytes(0x00);
	Byte *second = pack->GetBytes((Word)strlen((char *)cName)+1);
	Player *secp = PlayersHandler::GetSingleton().FindPlayer((char *)second);
	Packet retPack;

	if(!mChannelManager->ChanExists((char *)cName))
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x05);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	Channel *chan = mChannelManager->GetChannel((char *)cName);
	if(chan->GetOwner() != ply)
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x0A);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	if(secp == NULL)
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x09);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		retPack.AddBytes(second,(Word)strlen((char *)second)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	int ret = chan->SetOwner(ply,secp);
	if(ret == 0)
	{
		Channel::ChanPlayerIterator i;
		for (i=chan->GetPlayersStart(); i!=chan->GetPlayersEnd(); i++)
		{
			retPack.Build(SMSG_CHANNEL_NOTIFY);
			retPack.AddByte(0x08);
			retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
			retPack.AddQuadWord(secp->GetObjectGuid());
			WorldServer::GetSingleton().WriteData((*i)->GetClient(),&retPack);
		}
	}
	else if(ret == 1)
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x0A);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
	}
	else if(ret == 2)
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x09);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		retPack.AddBytes(second,(Word)strlen((char *)second)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
	}
}
void ChannelHandler::HandlerMSG_CHANNEL_OWNER(Client *cli,Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Byte *cName = pack->GetBytes(0x00);
	Packet retPack;

	if(!mChannelManager->ChanExists((char *)cName))
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x05);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	Channel *chan = mChannelManager->GetChannel((char *)cName);
	if(chan->GetOwner() == NULL)
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x05);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
	}
	else
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x0B);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		retPack.AddBytes((Byte *)(chan->GetOwner()->GetName().c_str()),(Word)strlen(chan->GetOwner()->GetName().c_str())+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
	}
}

void ChannelHandler::HandlerMSG_CHANNEL_MODERATOR(Client *cli,Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Byte *cName = pack->GetBytes(0x00);
	Byte *second = pack->GetBytes((Word)strlen((char *)cName)+1);
	Player *secp = PlayersHandler::GetSingleton().FindPlayer((char *)second);
	Packet retPack;

	if(!mChannelManager->ChanExists((char *)cName))
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x05);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	Channel *chan = mChannelManager->GetChannel((char *)cName);
	if(chan->GetOwner() != ply)
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x0A);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	if(secp == NULL)
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x09);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		retPack.AddBytes(second,(Word)strlen((char *)second)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	if(chan->SetPlayerMode(secp->GetObjectGuid(),chan->GetPlayerMode(secp->GetObjectGuid()) | CM_PLAYER_MODERATOR))
	{
		Channel::ChanPlayerIterator i;
		for (i=chan->GetPlayersStart(); i!=chan->GetPlayersEnd(); i++)
		{
			retPack.Build(SMSG_CHANNEL_NOTIFY);
			retPack.AddByte(0x0C);
			retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
			retPack.AddQuadWord(secp->GetObjectGuid());
			retPack.AddByte(0x01);
			retPack.AddByte(0x02);
			WorldServer::GetSingleton().WriteData((*i)->GetClient(),&retPack);
		}
	}
	else
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x09);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		retPack.AddBytes(second,(Word)strlen((char *)second)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
	}	
}

void ChannelHandler::HandlerMSG_CHANNEL_UMODERATOR(Client *cli,Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Byte *cName = pack->GetBytes(0x00);
	Byte *second = pack->GetBytes((Word)strlen((char *)cName)+1);
	Player *secp = PlayersHandler::GetSingleton().FindPlayer((char *)second);
	Packet retPack;

	if(!mChannelManager->ChanExists((char *)cName))
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x05);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	Channel *chan = mChannelManager->GetChannel((char *)cName);
	if(chan->GetOwner() != ply)
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x0A);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	if(secp == NULL)
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x09);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		retPack.AddBytes(second,(Word)strlen((char *)second)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	if(chan->SetPlayerMode(secp->GetObjectGuid(),chan->GetPlayerMode(secp->GetObjectGuid()) & ~CM_PLAYER_MODERATOR))
	{
		Channel::ChanPlayerIterator i;
		for (i=chan->GetPlayersStart(); i!=chan->GetPlayersEnd(); i++)
		{
			retPack.Build(SMSG_CHANNEL_NOTIFY);
			retPack.AddByte(0x0C);
			retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
			retPack.AddQuadWord(secp->GetObjectGuid());
			retPack.AddByte(0x02);
			retPack.AddByte(0x01);
			WorldServer::GetSingleton().WriteData((*i)->GetClient(),&retPack);
		}
	}
	else
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x09);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		retPack.AddBytes(second,(Word)strlen((char *)second)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
	}
}

void ChannelHandler::HandlerMSG_CHANNEL_MUTE(Client *cli,Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Byte *cName = pack->GetBytes(0x00);
	Byte *second = pack->GetBytes((Word)strlen((char *)cName)+1);
	Player *secp = PlayersHandler::GetSingleton().FindPlayer((char *)second);
	Packet retPack;

	if(!mChannelManager->ChanExists((char *)cName))
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x05);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	Channel *chan = mChannelManager->GetChannel((char *)cName);
	if(!(chan->GetPlayerMode(ply->GetObjectGuid()) & CM_PLAYER_MODERATOR))
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x06);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}
	
	if(chan->GetOwner() == secp && secp != ply)
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x0A);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	if(secp == NULL)
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x09);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		retPack.AddBytes(second,(Word)strlen((char *)second)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	if(chan->SetPlayerMode(secp->GetObjectGuid(),chan->GetPlayerMode(secp->GetObjectGuid()) | CM_PLAYER_MUTED))
	{
		Channel::ChanPlayerIterator i;
		for (i=chan->GetPlayersStart(); i!=chan->GetPlayersEnd(); i++)
		{
			retPack.Build(SMSG_CHANNEL_NOTIFY);
			retPack.AddByte(0x0C);
			retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
			retPack.AddQuadWord(secp->GetObjectGuid());
			retPack.AddByte(0x04);
			retPack.AddByte(0x01);
			WorldServer::GetSingleton().WriteData((*i)->GetClient(),&retPack);
		}
	}
	else
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x09);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		retPack.AddBytes(second,(Word)strlen((char *)second)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
	}
}
void ChannelHandler::HandlerMSG_CHANNEL_UNMUTE(Client *cli,Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Byte *cName = pack->GetBytes(0x00);
	Byte *second = pack->GetBytes((Word)strlen((char *)cName)+1);
	Player *secp = PlayersHandler::GetSingleton().FindPlayer((char *)second);
	Packet retPack;

	if(!mChannelManager->ChanExists((char *)cName))
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x05);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	Channel *chan = mChannelManager->GetChannel((char *)cName);
	if(!(chan->GetPlayerMode(ply->GetObjectGuid()) & CM_PLAYER_MODERATOR))
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x06);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	if(chan->GetOwner() == secp && secp != ply)
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x0A);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	if(secp == NULL)
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x09);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		retPack.AddBytes(second,(Word)strlen((char *)second)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	if(chan->SetPlayerMode(secp->GetObjectGuid(),chan->GetPlayerMode(secp->GetObjectGuid()) & ~CM_PLAYER_MUTED))
	{
		Channel::ChanPlayerIterator i;
		for (i=chan->GetPlayersStart(); i!=chan->GetPlayersEnd(); i++)
		{
			retPack.Build(SMSG_CHANNEL_NOTIFY);
			retPack.AddByte(0x0C);
			retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
			retPack.AddQuadWord(secp->GetObjectGuid());
			retPack.AddByte(0x01);
			retPack.AddByte(0x04);
			WorldServer::GetSingleton().WriteData((*i)->GetClient(),&retPack);
		}
	}
	else
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x09);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		retPack.AddBytes(second,(Word)strlen((char *)second)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
	}
}

void ChannelHandler::HandlerMSG_CHANNEL_KICK(Client *cli,Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Byte *cName = pack->GetBytes(0x00);
	Byte *second = pack->GetBytes((Word)strlen((char *)cName)+1);
	Player *secp = PlayersHandler::GetSingleton().FindPlayer((char *)second);
	Packet retPack;

	if(!mChannelManager->ChanExists((char *)cName))
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x05);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	Channel *chan = mChannelManager->GetChannel((char *)cName);
	if(!(chan->GetPlayerMode(ply->GetObjectGuid()) & CM_PLAYER_MODERATOR))
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x06);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	if(chan->GetOwner() == secp && secp != ply)
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x0A);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	if(secp == NULL)
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x09);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		retPack.AddBytes(second,(Word)strlen((char *)second)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	if(chan->RemovePlayer(secp))
	{
		Channel::ChanPlayerIterator i;
		for (i=chan->GetPlayersStart(); i!=chan->GetPlayersEnd(); i++)
		{
			retPack.Build(SMSG_CHANNEL_NOTIFY);
			retPack.AddByte(0x12);
			retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
			retPack.AddQuadWord(ply->GetObjectGuid());
			retPack.AddQuadWord(secp->GetObjectGuid());
			WorldServer::GetSingleton().WriteData((*i)->GetClient(),&retPack);
		}
	}
	else
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x09);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		retPack.AddBytes(second,(Word)strlen((char *)second)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
	}
}

void ChannelHandler::HandlerMSG_CHANNEL_BAN(Client *cli,Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Byte *cName = pack->GetBytes(0x00);
	Byte *second = pack->GetBytes((Word)strlen((char *)cName)+1);
	Player *secp = PlayersHandler::GetSingleton().FindPlayer((char *)second);
	Packet retPack;

	if(!mChannelManager->ChanExists((char *)cName))
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x05);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	Channel *chan = mChannelManager->GetChannel((char *)cName);
	if(!(chan->GetPlayerMode(ply->GetObjectGuid()) & CM_PLAYER_MODERATOR))
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x06);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	if(secp == NULL)
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x09);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		retPack.AddBytes(second,(Word)strlen((char *)second)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	if(chan->GetOwner()->GetObjectGuid() == secp->GetObjectGuid() && secp != ply)
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x0A);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	if(chan->AddBannedPlayer(secp->GetObjectGuid()))
	{
		Channel::ChanPlayerIterator i;
		for (i=chan->GetPlayersStart(); i!=chan->GetPlayersEnd(); i++)
		{
			retPack.Build(SMSG_CHANNEL_NOTIFY);
			retPack.AddByte(0x14);
			retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
			retPack.AddQuadWord(ply->GetObjectGuid());
			retPack.AddQuadWord(secp->GetObjectGuid());
			WorldServer::GetSingleton().WriteData((*i)->GetClient(),&retPack);
		}
	}
	else
	{
		WorldServer::GetSingleton().AnnounceTo(cli,"That player is already banned.");
	}
}

void ChannelHandler::HandlerMSG_CHANNEL_UNBAN(Client *cli,Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Byte *cName = pack->GetBytes(0x00);
	Byte *second = pack->GetBytes((Word)strlen((char *)cName)+1);
	Player *secp = PlayersHandler::GetSingleton().FindPlayer((char *)second);
	Packet retPack;

	if(!mChannelManager->ChanExists((char *)cName))
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x05);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	Channel *chan = mChannelManager->GetChannel((char *)cName);
	if(!(chan->GetPlayerMode(ply->GetObjectGuid()) & CM_PLAYER_MODERATOR))
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x06);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	if(secp == NULL)
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x09);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		retPack.AddBytes(second,(Word)strlen((char *)second)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}

	if(chan->RemoveBannedPlayer(secp->GetObjectGuid()))
	{
		Channel::ChanPlayerIterator i;
		for (i=chan->GetPlayersStart(); i!=chan->GetPlayersEnd(); i++)
		{
			retPack.Build(SMSG_CHANNEL_NOTIFY);
			retPack.AddByte(0x15);
			retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
			retPack.AddQuadWord(ply->GetObjectGuid());
			retPack.AddQuadWord(secp->GetObjectGuid());
			WorldServer::GetSingleton().WriteData((*i)->GetClient(),&retPack);
		}
	}
	else
	{
		WorldServer::GetSingleton().AnnounceTo(cli,"That player isnt banned.");
	}
}

void ChannelHandler::HandlerMSG_CHANNEL_LIST(Client *cli,Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Byte *cName = pack->GetBytes(0x00);
	Packet retPack;
	
	if(!mChannelManager->ChanExists((char *)cName))
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x05);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}
	Channel *chan = mChannelManager->GetChannel((char *)cName);

	retPack.Build(SMSG_CHANNEL_LIST);
	retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
	retPack.AddBytes((Byte *)chan->GetPassword().c_str(),(Word)strlen((char *)chan->GetPassword().c_str()));
	retPack.AddByte(0x00);
	retPack.AddDoubleWord(chan->GetPlayerCount());
	
	Channel::ChanPlayerIterator i;
	for (i=chan->GetPlayersStart(); i!=chan->GetPlayersEnd(); i++)
	{
		retPack.AddQuadWord((*i)->GetObjectGuid());
		Byte flags=0x00;
		if(chan->GetPlayerMode((*i)->GetObjectGuid()) & (CM_PLAYER_MUTED))
			flags |= 0x04;
		if(chan->GetPlayerMode((*i)->GetObjectGuid()) & (CM_PLAYER_MODERATOR))
			flags |= 0x02;
		retPack.AddByte(flags);
	}
	WorldServer::GetSingleton().WriteData(cli,&retPack);
}


void ChannelHandler::HandlerMSG_CHANNEL_ANNOUNCEMENTS(Client *cli,Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Byte *cName = pack->GetBytes(0x00);
	Packet retPack;
	
	if(!mChannelManager->ChanExists((char *)cName))
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x05);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}
	Channel *chan = mChannelManager->GetChannel((char *)cName);
	
	Byte op;
	if(chan->GetModes() & CM_CHANNEL_ANNOUNCE)
	{
		chan->SetChannelMode(chan->GetModes() & ~CM_CHANNEL_ANNOUNCE);
		op = 0x0E;
	}
	else
	{
		chan->SetChannelMode(chan->GetModes() | CM_CHANNEL_ANNOUNCE);
		op = 0x0D;
	}

	Channel::ChanPlayerIterator i;
	for (i=chan->GetPlayersStart(); i!=chan->GetPlayersEnd(); i++)
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(op);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		retPack.AddQuadWord(ply->GetObjectGuid());
		WorldServer::GetSingleton().WriteData((*i)->GetClient(),&retPack);
	}
}

void ChannelHandler::HandlerMSG_CHANNEL_MODERATE(Client *cli,Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Byte *cName = pack->GetBytes(0x00);
	Packet retPack;
	
	if(!mChannelManager->ChanExists((char *)cName))
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x05);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}
	Channel *chan = mChannelManager->GetChannel((char *)cName);

	if(!(chan->GetPlayerMode(ply->GetObjectGuid()) & CM_PLAYER_MODERATOR))
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(0x06);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		WorldServer::GetSingleton().WriteData(cli,&retPack);
		return;
	}
	
	Byte op;
	if(chan->GetModes() & CM_CHANNEL_MODERATED)
	{
		chan->SetChannelMode(chan->GetModes() & ~CM_CHANNEL_MODERATED);
		op = 0x10;
	}
	else
	{
		chan->SetChannelMode(chan->GetModes() | CM_CHANNEL_MODERATED);
		op = 0x0F;
	}

	Channel::ChanPlayerIterator i;
	for (i=chan->GetPlayersStart(); i!=chan->GetPlayersEnd(); i++)
	{
		retPack.Build(SMSG_CHANNEL_NOTIFY);
		retPack.AddByte(op);
		retPack.AddBytes(cName,(Word)strlen((char *)cName)+1);
		retPack.AddQuadWord(ply->GetObjectGuid());
		WorldServer::GetSingleton().WriteData((*i)->GetClient(),&retPack);
	}
}

#endif