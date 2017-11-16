// (c) AbyssX Group
#include "../WorldEnvironment.h"

#ifdef GROUPS

template <class GroupsHandler> GroupsHandler *Singleton<GroupsHandler>::msSingleton = 0;

GroupsHandler::GroupsHandler()
{
}

GroupsHandler::~GroupsHandler()
{
}

DoubleWord GroupsHandler::HandlePackets(Client *cli, Packet *pack)
{
	switch (pack->GetOpCode())
	{
		case CMSG_GROUP_INVITE:
				HandlerMSG_GROUP_INVITE(cli, pack);
				return 1;
				break;
		case CMSG_GROUP_UNINVITE:
				HandlerMSG_GROUP_UNINVITE(cli, pack);
				return 1;
				break;
		case CMSG_GROUP_UNINVITE_GUID:
				HandlerMSG_GROUP_UNINVITE_GUID(cli, pack);
				return 1;
				break;
		case CMSG_GROUP_ACCEPT:
				HandlerMSG_GROUP_ACCEPT(cli, pack);
				return 1;
				break;
		case CMSG_GROUP_DECLINE:
				HandlerMSG_GROUP_DECLINE(cli, pack);
				return 1;
				break;
		case CMSG_GROUP_DISBAND:
				HandlerMSG_GROUP_DISBAND(cli, pack);
				return 1;
				break;
		case CMSG_LOOT_METHOD:
				HandlerMSG_LOOT_METHOD(cli, pack);
				return 1;
				break;
		case CMSG_GROUP_SET_LEADER:
				HandlerMSG_GROUP_SET_LEADER(cli, pack);
				return 1;
				break;
	}

	return 0;
}

void GroupsHandler::AddPlayer(Player *host, Player *ply, Packet *pack)
{
	static DoubleWord partys = 1;

	list<GroupsData *>::iterator it;
		
	GroupsData *gp = new GroupsData();

	if (host && !ply)
	{
		gp->mMemberName = host->GetName().c_str();
		gp->mMemberGuid = host->GetObjectGuid();
		gp->mLeaderGuid = host->GetObjectGuid();
		gp->mLootMasterGuid = host->GetObjectGuid();
		gp->mLootMethod = 2;
		gp->mIs_Leader = true;
		gp->mPartyid = partys;
		host->SetParty(gp);
		partys++;
	}

	if (host && ply)
	{
		gp->mMemberName = ply->GetName().c_str();
		gp->mMemberGuid = ply->GetObjectGuid();
		gp->mLeaderGuid = host->GetObjectGuid();
		gp->mLootMasterGuid = host->GetObjectGuid();
		gp->mLootMethod = 2;
		gp->mIs_Leader = false;
		gp->mPartyid = host->GetParty()->mPartyid;
		ply->SetParty(gp);
	}
	
	mGroups.push_back(gp);

	if (ply)
	{
		for (it = mGroups.begin(); it != mGroups.end(); it++)
		{
			if ((*it)->mPartyid == gp->mPartyid)
			{
				Player *p = PlayersHandler::GetSingleton().FindPlayer((*it)->mMemberGuid);
				if (p)
					GetPartyList(p);
			}
		}
	}
}

void GroupsHandler::GetPartyList(Player *ply)
{		
	Packet retpack;

	list<GroupsData *>::iterator it;

	if (ply)
	{
		DoubleWord membercount = 0;

		for (it = mGroups.begin(); it != mGroups.end();it++)
		{
			if ((*it)->mPartyid == ply->GetParty()->mPartyid)
				membercount++;
		}

		retpack.Build(SMSG_GROUP_LIST);
		if(membercount > 0)
			retpack.AddDoubleWord(membercount-1);
		else
			retpack.AddDoubleWord(0);
		
		for (it = mGroups.begin(); it != mGroups.end(); it++)
		{
			if ((*it)->mPartyid == ply->GetParty()->mPartyid && (*it)->mMemberGuid != ply->GetObjectGuid())
			{
				retpack.AddBytes((Byte *)(*it)->mMemberName.c_str(), (Word)strlen((*it)->mMemberName.c_str()));
				retpack.AddByte(0x00);
				retpack.AddQuadWord((*it)->mMemberGuid);
				retpack.AddByte(0x00);
			}
		}

		retpack.AddQuadWord(ply->GetParty()->mLeaderGuid);
		retpack.AddByte(ply->GetParty()->mLootMethod);
		retpack.AddQuadWord(ply->GetParty()->mLootMasterGuid);

		if (ply->GetClient())
			WorldServer::GetSingleton().WriteData(ply->GetClient(),&retpack);
	} 
}

void GroupsHandler::HandlerMSG_GROUP_INVITE(Client *cli, Packet *pack)
{
	std::string name;
	name = (char *)pack->GetBytes(0x00);
	int count = 0;

	list<GroupsData *>::iterator it;

	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Player *InvitedPlayer = PlayersHandler::GetSingleton().FindPlayer(name.c_str());

	if (!ply)
		return; //Shouldn't Happens.

	if (!InvitedPlayer)
	{
		WorldServer::GetSingleton().AnnounceTo(cli,"Player %s not found.", name.c_str());
		return;
	}

	if (ply->GetParty())
	{
		if (ply->GetParty()->mIs_Leader == false)
		{
			WorldServer::GetSingleton().AnnounceTo(cli,"You can´t invite players if you aren´t the Leader.");
			return;
		}

		for (it = mGroups.begin();it != mGroups.end();it++)
		{
			if ((*it)->mPartyid == ply->GetParty()->mPartyid)
				count++;
		}
	
		if (count >= 5)
		{
			WorldServer::GetSingleton().AnnounceTo(cli,"You can´t invite more players, the group is currently full.");
			return;
		}
	}
	
	if (ply->GetCurrentMap() != InvitedPlayer->GetCurrentMap())
	{
		WorldServer::GetSingleton().AnnounceTo(cli,"You can´t invite players from another continents.");
		return;
	}
	
	if (InvitedPlayer->GetParty())
	{
		WorldServer::GetSingleton().AnnounceTo(cli,"You can´t invite a player, that is already in a group.");
		return;
	}
	
	if (PlayersHandler::GetSingleton().DistBetween(ply, InvitedPlayer) >= 50.0f)
	{
		WorldServer::GetSingleton().AnnounceTo(cli,"You can´t invite a player, that is out of the maximum range.");
		return;
	}
	
	InvitedPlayer->SetHostTrack(ply->GetObjectGuid());
	
	Packet retpack;
	retpack.Build(SMSG_GROUP_INVITE);
	retpack.AddBytes((Byte *)ply->GetName().c_str(), (Word)strlen(ply->GetName().c_str()));
	retpack.AddByte(0x00);
	if (InvitedPlayer->GetClient())
		WorldServer::GetSingleton().WriteData(InvitedPlayer->GetClient(), &retpack);
}
void GroupsHandler::HandlerMSG_GROUP_UNINVITE(Client *cli, Packet *pack)
{
	string name = (char *)pack->GetBytes(0x00);
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Player *ply2 = PlayersHandler::GetSingleton().FindPlayer(name.c_str());

	list<GroupsData *>::iterator it;

	if (!ply || !ply2)
		return; // This Shouldn´t Happens.

	if(!ply->GetParty())
		return;

	DoubleWord ID = ply->GetParty()->mPartyid;

	if(ply->GetParty()->mIs_Leader)
		RemoveFromGroup(ply2);

	for (it = mGroups.begin(); it != mGroups.end(); it++)
	{
		if ((*it)->mPartyid == ID)
		{
			Player *p = PlayersHandler::GetSingleton().FindPlayer((*it)->mMemberGuid);
			if (p)
				GetPartyList(p);
		}
	}
}
void GroupsHandler::HandlerMSG_GROUP_UNINVITE_GUID(Client *cli, Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Player *ply2 = PlayersHandler::GetSingleton().FindPlayer(pack->GetQuadWord(0x00));

	list<GroupsData *>::iterator it;

	if (!ply || !ply2)
		return; // This Shouldn´t Happens.
	
	if(ply->GetParty()->mIs_Leader)
		RemoveFromGroup(ply2);

	for (it = mGroups.begin(); it != mGroups.end(); it++)
	{
		if ((*it)->mPartyid == ply->GetParty()->mPartyid)
		{
			Player *p = PlayersHandler::GetSingleton().FindPlayer((*it)->mMemberGuid);
			if (p)
				GetPartyList(p);
		}
	}
}
void GroupsHandler::HandlerMSG_GROUP_ACCEPT(Client *cli, Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Player *Host;

	if (!ply)
		return; //Shouldn´t Happens.

	Host = PlayersHandler::GetSingleton().FindPlayer(ply->GetHostTrack());

	if (!Host)
		return; //Shouldn't Happens.

	if (!Host->GetParty())
		AddPlayer(Host, NULL, pack);

	if (!ply->GetParty())
		AddPlayer(Host, ply, pack);
}

void GroupsHandler::HandlerMSG_GROUP_DECLINE(Client *cli, Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Packet Decline;

	Player *Host;

	if (!ply)
		return; // Shouldn't Happens.

	Host = PlayersHandler::GetSingleton().FindPlayer(ply->GetHostTrack());

	if (!Host)
	{
		WorldServer::GetSingleton().AnnounceTo(cli, "Player not found.");
		ply->SetHostTrack(0x00);
		return;
	}
	
	WorldServer::GetSingleton().AnnounceTo(Host->GetClient(), "The Player does not wish to group with you.");

	ply->SetHostTrack(0x00);
	
}

void GroupsHandler::HandlerMSG_GROUP_DISBAND(Client *cli, Packet *pack)
{
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Packet retpack;

	if (!ply)
		return; //Shouldn´t Happens.

	if (ply->GetParty())
		RemoveFromGroup(ply);
}

void GroupsHandler::HandlerMSG_LOOT_METHOD(Client *cli, Packet *pack)
{
	list<GroupsData *>::iterator it;

	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);

	if (!ply)
		return; //Shouldn´t Happens.

	if (!ply->GetParty())
		return; //Shouldn´t Happens.

	for (it = mGroups.begin(); it != mGroups.end(); it++)
	{
		if ((*it)->mPartyid == ply->GetParty()->mPartyid)
		{
			Player *p = PlayersHandler::GetSingleton().FindPlayer((*it)->mMemberGuid);
			if (p)
			{	p->GetParty()->mLootMethod = pack->GetByte(0x00);
				p->GetParty()->mLootMasterGuid = pack->GetQuadWord(0x04);
				GetPartyList(p);
			}
		}
	}
}

void GroupsHandler::HandlerMSG_GROUP_SET_LEADER(Client *cli, Packet *pack)
{
	string name = (char *)pack->GetBytes(0x00);
	Player *ply = PlayersHandler::GetSingleton().FindPlayer(cli);
	Player *ply2 = PlayersHandler::GetSingleton().FindPlayer(name.c_str());
	Packet Lpack;

	list<GroupsData *>::iterator it;

	if (!ply || !ply2)
		return; // This Shouldn´t Happens.
	
	if (!ply->GetParty() || !ply2->GetParty())
		return; // This Shouldn´t Happens.

	ply2->GetParty()->mIs_Leader = true;
	ply2->GetParty()->mLeaderGuid = ply2->GetParty()->mMemberGuid;
	ply2->GetParty()->mLootMasterGuid = ply2->GetParty()->mMemberGuid;
	ply2->GetParty()->mLootMethod = 2;
	
	ply->GetParty()->mIs_Leader = false;

	Lpack.Build(SMSG_GROUP_SET_LEADER);
	Lpack.AddBytes((Byte *)ply2->GetName().c_str(), (Word)strlen(ply2->GetName().c_str()));
	Lpack.AddByte(0x00);

	for (it = mGroups.begin(); it != mGroups.end(); it++)
	{
		if ((*it)->mPartyid == ply->GetParty()->mPartyid)
		{
			Player *p = PlayersHandler::GetSingleton().FindPlayer((*it)->mMemberGuid);
			if (p)
			{
				p->GetParty()->mLeaderGuid = ply2->GetParty()->mMemberGuid;
				p->GetParty()->mLootMasterGuid = ply2->GetParty()->mMemberGuid;
				p->GetParty()->mLootMethod = ply2->GetParty()->mLootMethod;
				GetPartyList(p);
				if (p->GetClient())
					WorldServer::GetSingleton().WriteData(p->GetClient(),&Lpack);
			}
		}
	}
}

void GroupsHandler::SendToGroup(Packet *pack, Player *ply, int mode)
{
	list<GroupsData *>::iterator it;

	if (mode == 0) //Sends the Packet to Everyone.
	{
		for (it = mGroups.begin(); it != mGroups.end();it++)
		{
			if ((*it)->mPartyid == ply->GetParty()->mPartyid)
			{
				Player *p = PlayersHandler::GetSingleton().FindPlayer((*it)->mMemberGuid);
				if (p)
					if (p->GetClient())
						WorldServer::GetSingleton().WriteData(p->GetClient(),pack);
			}
		}
	}
	
	if (mode == 1) //Sends the Packet to Everyone Except Leader.
	{
		for (it = mGroups.begin(); it != mGroups.end();it++)
		{
			if ((*it)->mPartyid == ply->GetParty()->mPartyid && (*it)->mIs_Leader == false)
			{
				Player *p = PlayersHandler::GetSingleton().FindPlayer((*it)->mMemberGuid);
				if (p)
					if (p->GetClient())
						WorldServer::GetSingleton().WriteData(p->GetClient(),pack);
			}
		}
	}

	if (mode == 2) //Sends the Packet just to the Leader.
	{
		for (it = mGroups.begin();it != mGroups.end();it++)
		{
			if ((*it)->mPartyid == ply->GetParty()->mPartyid && (*it)->mIs_Leader == true)
			{
				Player *p = PlayersHandler::GetSingleton().FindPlayer((*it)->mMemberGuid);
				if (p)
					if (p->GetClient())
						WorldServer::GetSingleton().WriteData(p->GetClient(),pack);
			}
		}
	}

	if (mode == 3) //Sends the Packet to Everyone Minus SELF!
	{
		for (it = mGroups.begin();it != mGroups.end();it++)
		{
			if ((*it)->mPartyid == ply->GetParty()->mPartyid && (*it)->mIs_Leader == true)
			{
				if ((*it)->mMemberGuid != ply->GetObjectGuid())
				{
					Player *p = PlayersHandler::GetSingleton().FindPlayer((*it)->mMemberGuid);
					if (p)
						if (p->GetClient())
							WorldServer::GetSingleton().WriteData(p->GetClient(),pack);
				}
			}
		}
	}
}

void GroupsHandler::RemoveFromGroup(Player *ply)
{
	list<GroupsData *>::iterator it;

	DoubleWord count = 0;
	DoubleWord loop = 0;
	Packet retpack;
	QuadWord LeaderGUID = 0x0000000000000000;

	if (ply->GetParty())
	{
		if (ply->GetParty()->mIs_Leader == true)
		{
			ply->GetParty()->mIs_Leader = false;

			for (it = mGroups.begin(); it != mGroups.end(); it++)
			{
				if ((*it)->mPartyid == ply->GetParty()->mPartyid)
				{
					if (loop == 1)
					{
						(*it)->mIs_Leader = true;
						(*it)->mLeaderGuid = (*it)->mMemberGuid;
						(*it)->mLootMasterGuid = (*it)->mMemberGuid;
						LeaderGUID = (*it)->mLeaderGuid;
							
						Player *Leader = PlayersHandler::GetSingleton().FindPlayer((*it)->mMemberGuid);
						if (Leader)
						{
							retpack.Build(SMSG_GROUP_SET_LEADER);
							retpack.AddBytes((Byte *)Leader->GetName().c_str(), (Word)strlen(Leader->GetName().c_str()));
							retpack.AddByte(0x00);
							if (Leader->GetClient())
								WorldServer::GetSingleton().WriteData(Leader->GetClient(),&retpack);
						}
					}
					else
					{
						(*it)->mLeaderGuid = LeaderGUID;

						Player *Member = PlayersHandler::GetSingleton().FindPlayer((*it)->mMemberGuid);
						if (Member)
						{
							Player *Leader = PlayersHandler::GetSingleton().FindPlayer(LeaderGUID);

							if (Leader)
							{
								retpack.Build(SMSG_GROUP_SET_LEADER);
								retpack.AddBytes((Byte *)Leader->GetName().c_str(), (Word)strlen(Leader->GetName().c_str()));
								retpack.AddByte(0x00);
								if (Member->GetClient())
									WorldServer::GetSingleton().WriteData(Member->GetClient(),&retpack);
							}
						}
					}
				loop++;
				}
			}

			ply->GetParty()->mLeaderGuid = LeaderGUID;
			ply->GetParty()->mLootMasterGuid = LeaderGUID;
		}

		DoubleWord PID = ply->GetParty()->mPartyid;		

		retpack.Build(SMSG_GROUP_DESTROYED);
		if (ply->GetClient())
			WorldServer::GetSingleton().WriteData(ply->GetClient(),&retpack);
			
		ply->SetParty(NULL);

		for (it = mGroups.begin(); it != mGroups.end();it)
		{
			if ((*it)->mMemberGuid == ply->GetObjectGuid())
			{
				delete *it;
				mGroups.erase(it++);
				break;	
			}
			else
				it++;
		}
		
		for (it = mGroups.begin(); it != mGroups.end(); it++)
		{
			if ((*it)->mPartyid == PID)
				count++;
		}

		for (it = mGroups.begin(); it != mGroups.end(); it++)
		{
			if ((*it)->mPartyid == PID)
			{
				Player *p = PlayersHandler::GetSingleton().FindPlayer((*it)->mMemberGuid);

				if (p)
				{
					if (count > 1)
						GetPartyList(p);
					else
					{
						retpack.Build(SMSG_GROUP_DESTROYED);
						if (p->GetClient())
							WorldServer::GetSingleton().WriteData(p->GetClient(),&retpack);

						p->SetParty(NULL);
				
						for (it = mGroups.begin(); it != mGroups.end();it)
						{
							if ((*it)->mMemberGuid == p->GetObjectGuid())
							{
								delete (*it);
								mGroups.erase(it++);
								break;	
							}
							else
								it++;
						}
					}
				}
			}
		}
	}
}

void GroupsHandler::ShareXP(Player *ply, DoubleWord XP)
{
	list<GroupsData *>::iterator it;
	Packet retpack;
	ObjectUpdate objupd;

	if (ply->GetParty())
	{
		int count = 0;
		int sharedxp = 0;

		for (it = mGroups.begin(); it != mGroups.end();it++)
		{
			if ((*it)->mPartyid == ply->GetParty()->mPartyid)
			count++;
		}

		if (count < 1)
		return;
		
		sharedxp = (XP/count);

		for (it = mGroups.begin(); it != mGroups.end();it++)
		{
			if ((*it)->mPartyid == ply->GetParty()->mPartyid && (*it)->mMemberGuid != ply->GetObjectGuid())
			{
				Player *p = PlayersHandler::GetSingleton().FindPlayer((*it)->mMemberGuid);
				if (p)
				{
					p->SetExperiencePoints(p->GetExperiencePoints()+sharedxp);
						
					if (p->GetExperiencePoints() >= p->GetExperienceNextLevel())
						p->LevelUP();
		
					if (p->GetClient())
					{
						retpack.Build(SMSG_LOG_XPGAIN);
						retpack.AddQuadWord(0x00);
						retpack.AddDoubleWord(sharedxp);
						retpack.AddDoubleWord(0x00);
						retpack.AddByte(0x00);
	
						WorldServer::GetSingleton().WriteData(p->GetClient(), &retpack);
	
						//Sending The Update of Player Experience :)
						Packets::UpdateObjectHeader(p, &retpack);
	
						objupd.Clear();
						objupd.Touch(ObjectUpdate::UPDOBJECT);
						objupd.Touch(ObjectUpdate::UPDUNIT);
						objupd.Touch(ObjectUpdate::UPDPLAYER);
			
						objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_HEALTH, p->GetHealth());
						objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_MAXHEALTH, p->GetMaximumHealth());
						objupd.AddField(ObjectUpdate::UPDUNIT, UNIT_FIELD_LEVEL, p->GetLevel());
						objupd.AddField(ObjectUpdate::UPDPLAYER, PLAYER_XP, p->GetExperiencePoints());
						objupd.AddField(ObjectUpdate::UPDPLAYER, PLAYER_NEXT_LEVEL_XP, p->GetExperienceNextLevel());
	
						retpack.AddObjectUpdate(&objupd);
						WorldServer::GetSingleton().SendToPlayersInRange(&retpack, p);
					}
				}
			}
		}
	}

}

void GroupsHandler::ShareMONEY(Player *ply, DoubleWord MONEY)
{
	list<GroupsData *>::iterator it;
	Packet retpack;
	ObjectUpdate objupd;

	if (ply->GetParty())
	{
		int count = 0;
		int sharedmoney = 0;

		for (it = mGroups.begin(); it != mGroups.end();it++)
		{
			if ((*it)->mPartyid == ply->GetParty()->mPartyid)
			count++;
		}

		if (count < 1)
		return;
		
		sharedmoney = (MONEY/count);

		for (it = mGroups.begin(); it != mGroups.end();it++)
		{
			if ((*it)->mPartyid == ply->GetParty()->mPartyid)
			{
				Player *p = PlayersHandler::GetSingleton().FindPlayer((*it)->mMemberGuid);
				if (p)
				{
					p->SetMoney(p->GetMoney() + sharedmoney);
		
					if (p->GetClient())
					{
						retpack.Build(SMSG_LOOT_MONEY_NOTIFY);
						retpack.AddDoubleWord(sharedmoney);

						WorldServer::GetSingleton().WriteData(p->GetClient(),&retpack);

						//Sending The Update of Player Experience :)
						Packets::UpdateObjectHeader(p, &retpack);
	
						objupd.Clear();
						objupd.Touch(ObjectUpdate::UPDOBJECT);
						objupd.Touch(ObjectUpdate::UPDUNIT);
						objupd.Touch(ObjectUpdate::UPDPLAYER);
			
						objupd.AddField(ObjectUpdate::UPDPLAYER, PLAYER_FIELD_COINAGE, p->GetMoney());
	
						retpack.AddObjectUpdate(&objupd);
						WorldServer::GetSingleton().SendToPlayersInRange(&retpack, p);
					}
				}
			}
		}
	}

}

bool GroupsHandler::CompareRanges(Player *ply)
{
	list<GroupsData *>::iterator it;
	if (ply->GetParty())
	{
		for (it = mGroups.begin(); it != mGroups.end();it++)
		{
			if ((*it)->mPartyid == ply->GetParty()->mPartyid)
			{
				Player *p = PlayersHandler::GetSingleton().FindPlayer((*it)->mMemberGuid);
				if (p)
				{
					if (PlayersHandler::GetSingleton().DistBetween(ply,p) > MAX_GROUP_RANGE)
					{
						return true;
						break;
					}
				}
			}
		}
	}

	return false;
}

#endif