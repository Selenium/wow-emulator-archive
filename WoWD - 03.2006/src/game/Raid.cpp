// Copyright (C) 2004 WoW Daemon
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.

#include "Common.h"
#include "Opcodes.h"
#include "WorldPacket.h"
#include "WorldSession.h"
#include "Player.h"
#include "World.h"
#include "ObjectMgr.h"
#include "Raid.h"
#include "Chat.h"


Raid::Raid()
{
	m_raid[0].subGroupMemberCount=0;
	m_raid[1].subGroupMemberCount=0;
	m_raid[2].subGroupMemberCount=0;
	m_raid[3].subGroupMemberCount=0;
	m_raid[4].subGroupMemberCount=0;
	m_raid[5].subGroupMemberCount=0;
	m_raid[6].subGroupMemberCount=0;
	m_raid[7].subGroupMemberCount=0;
	m_count = 0;
	m_raidLeaderGuid = 0;
	m_lootMethod = 0;
	m_looterGuid = 0;
	m_grouptype = 1;
}

Raid::~Raid()
{
}
void Raid::ChangeLeader(const uint64 &guid)
{
	bool LeaderFlag = FALSE;
	uint32 i;
	WorldPacket data;
	std::list<SubRaidMembers*>::iterator itr,itr2;

	Player *player,*pLeader;

	for(i = 0; i < 8; i++)
	{
		for(itr = m_raid[i].subGroup.begin();itr != m_raid[i].subGroup.end();itr++)
		{
			if((*itr)->memberGuid == guid)
			{
				LeaderFlag = TRUE;
				pLeader = objmgr.GetPlayer(guid);
				if(!pLeader)
					return;
				break;
			}
			if(LeaderFlag)
				break;
		}
	}

	if(LeaderFlag == FALSE)
		return;

	m_raidLeaderGuid=guid;
	data.Initialize( SMSG_GROUP_SET_LEADER );
	data << pLeader->GetName();

	for(i = 0; i < 8; i++)
	{
		for(itr2 = m_raid[i].subGroup.begin();itr2 != m_raid[i].subGroup.end();itr2++)
		{
			player = objmgr.GetPlayer( (*itr2)->memberGuid );
			ASSERT( player );

			player->SetLeader( guid );
			player->GetSession()->SendPacket( &data );
		}
	}

	SendUpdate();
}

void Raid::ChangeSubGroupLeader(const uint64 &guid, uint8 subGroup)
{
	uint8 i;
	bool error = FALSE;
	WorldPacket data;
	std::list<SubRaidMembers*>::iterator itr;
	Player *pLeader,*pNewLeader;

	ASSERT(subGroup < 8);
	ASSERT(subGroup > -1);

	for(i = 0; i < 8; i++)
	{
		for(itr = m_raid[i].subGroup.begin();itr != m_raid[i].subGroup.end();itr++)
		{
			if((*itr)->memberGuid == m_raid[i].subGroupLeaderGuid)
			{
				if(i == subGroup)
					break;
				else
				{
					error = TRUE;
					break;
				}
			}
		}
	}

	if(error == TRUE)
		return; //coming subGroup isnt same with players subGroup

	pLeader = objmgr.GetPlayer(m_raid[subGroup].subGroupLeaderGuid);
	if(pLeader)
		pLeader->SetRaidSubGroup(subGroup);

	pNewLeader = objmgr.GetPlayer(guid);
	if(!pNewLeader)
		return;

	m_raid[subGroup].subGroupLeaderGuid = guid;
	pNewLeader->SetRaidSubGroup(subGroup);//not sure what 80 is maybe 81,82,83

	SendUpdate();
}


void Raid::Disband()
{
	uint32 i;
	WorldPacket data;
	Player *player;
	std::list<SubRaidMembers*>::iterator itr;

	data.Initialize( SMSG_GROUP_DESTROYED );
	for(i = 0; i < 8; i++)
	{
		for(itr = m_raid[i].subGroup.begin();itr != m_raid[i].subGroup.end();itr++)
		{
			player = objmgr.GetPlayer( (*itr)->memberGuid );
			ASSERT( player );

			player->UnSetInGroup();
			player->GetSession()->SendPacket( &data );
			SendNullUpdate(player->GetGUID());
		}
	}
	objmgr.RemoveRaid( this );

}

void Raid::SendUpdate()
{
	uint8 i, j;
	Player *player;
	WorldPacket data;
	std::list<SubRaidMembers*>::iterator itr,itr2;

	for( i = 0; i < 8; i ++ )
	{
		for(itr = m_raid[i].subGroup.begin();itr != m_raid[i].subGroup.end();itr++)
		{
			player = objmgr.GetPlayer( (*itr)->memberGuid );
			ASSERT( player );

			data.clear();
			data.Initialize(SMSG_GROUP_LIST);
			data << (uint8)m_grouptype;
			data << player->GetRaidSubGroup();//callers SubGroup
			data << uint32(m_count - 1);

			for( j = 0; j < 8; j++ )//for( j = 0; j < m_count; j++ )
			{
				for(itr2 = m_raid[j].subGroup.begin();itr2 != m_raid[j].subGroup.end();itr2++)
				{
					if((*itr)->memberGuid != (*itr2)->memberGuid)
					{
						data << (*itr2)->name;
						data << (uint32)(*itr2)->memberGuid;
						data << uint32(0) << uint8(1) << j;//if leader 80
					}
				}
			}
			data << (uint64)m_raidLeaderGuid;
			data << (uint8)m_lootMethod;
			data << (uint32)m_looterGuid;
			data << uint32(0);
			data << uint8(2);

			player->GetSession()->SendPacket( &data );
		}
	}
}

void Raid::SendNullUpdate(uint64 guid)
{
	WorldPacket data;
	Player *plyr;

	plyr = objmgr.GetPlayer(guid);
	if(!plyr)
		return;

	data.Initialize(SMSG_GROUP_LIST);
	data << uint8(0);
	data << uint8(0);
	data << uint32(0);
	data << uint64(0);
	plyr->GetSession()->SendPacket(&data);
}

void Raid::AddMember(uint64 guid, const char* name)
{
	ASSERT(m_count < MAXRAIDSIZE-1);

	uint8 i = 0;
	SubRaidMembers *rMember = new SubRaidMembers;

	if(m_count < MAXRAIDSIZE-1)
	{
		for(i = 0; i < 8; i++)
		{
			if(m_raid[i].subGroupMemberCount < 5)
			{
				rMember->memberGuid = guid;
				rMember->name = name;
				m_raid[i].subGroup.push_back(rMember);
				m_raid[i].subGroupMemberCount++;
				m_count++;
				Player *plyr = objmgr.GetPlayer(guid);
				if(plyr)
					plyr->SetRaidSubGroup(i);
			}
		}
	}
}

void Raid::AddMember(uint64 guid, const char* name, uint8 subGroup)
{
	ASSERT(m_count < MAXRAIDSIZE-1);

	SubRaidMembers *rMember = new SubRaidMembers;

	if (m_count < MAXRAIDSIZE-1) 
	{
		if(m_raid[subGroup].subGroupMemberCount < 5)
		{
			rMember->memberGuid = guid;
			rMember->name = name;
			m_raid[subGroup].subGroup.push_back(rMember); 
			m_raid[subGroup].subGroupMemberCount++;
			m_count++;
		}
	}
	Player *plyr = objmgr.GetPlayer(guid);
	if(plyr)
		plyr->SetRaidSubGroup(subGroup);
}

uint32 Raid::RemoveMember(const uint64 &guid)
{
	uint8 i;
	bool leaderFlag = FALSE;
    bool check = false;

	std::list<SubRaidMembers*>::iterator itr;

	if( guid == m_raidLeaderGuid )
	{
		leaderFlag = TRUE;
	}

	for(i = 0; i < 8; i++)
	{
		for(itr = m_raid[i].subGroup.begin();itr != m_raid[i].subGroup.end();++itr)
		{
			if((*itr)->memberGuid == guid)
			{
				m_raid[i].subGroup.erase(itr++);
				m_raid[i].subGroupMemberCount--;
                check = true;
				break;
			}
		}
        if(check == true)
            break;
	}

	m_count--;

	if (leaderFlag)
	{
		itr = m_raid[0].subGroup.begin();		
		ChangeLeader((*itr)->memberGuid);
	}

	SendNullUpdate(guid);

	return m_count;
}

void Raid::ChangeMemberSubGroup(const uint64 &guid, uint8 subGroup)
{
	uint8 i = 0;
	std::list<SubRaidMembers*>::iterator itr;
	bool check = FALSE;

	SubRaidMembers *rMember = new SubRaidMembers;

	for(i = 0; i < 8; i++)
	{
		for(itr = m_raid[i].subGroup.begin();itr != m_raid[i].subGroup.end();++itr)
		{
			if((*itr)->memberGuid == guid)
			{
				if(m_raid[subGroup].subGroupMemberCount < 5)
				{
					Player *pMember = objmgr.GetPlayer((*itr)->memberGuid);
					if(!pMember)
						return;
					pMember->SetRaidSubGroup(subGroup);
					rMember->memberGuid = (*itr)->memberGuid;
					rMember->name = (*itr)->name;
					m_raid[subGroup].subGroup.push_back(rMember);
					m_raid[subGroup].subGroupMemberCount++;
					m_raid[i].subGroup.erase(itr++);
					m_raid[i].subGroupMemberCount--;
					check = TRUE;
					break;
				}
    		}
		}
		if(check)
			break;
	}
	SendUpdate();
}

void Raid::GiveXPToRaid(uint32 xp,const uint64 &victimguid)
{
	uint8 i = 0;
	Player *plyr;
	std::list<SubRaidMembers*>::iterator itr;

	for(i = 0; i < 8; i++)
	{
		for(itr = m_raid[i].subGroup.begin();itr != m_raid[i].subGroup.end();itr++)
		{
			plyr = objmgr.GetPlayer((*itr)->memberGuid);
			if(plyr)
			{
				plyr->GiveXP(xp,victimguid);
			}
		}
	}
}


void Raid::BroadcastToRaid(WorldSession *session, std::string msg)
{
	WorldPacket data;
	uint8 i;
	std::list<SubRaidMembers*>::iterator itr;

	if (session)
	{
		if(session->GetPlayer())
		{
			for(i = 0; i < 8; i++)
			{
				for(itr = m_raid[i].subGroup.begin();itr != m_raid[i].subGroup.end();itr++)
				{
					data.clear();
					sChatHandler.FillMessageData(&data, session, CHAT_MSG_RAID, LANG_UNIVERSAL, NULL, msg.c_str());
					Player *pl = objmgr.GetPlayer((*itr)->memberGuid);
					if (pl)
					{
						if(pl->GetSession())
						{
							pl->GetSession()->SendPacket(&data);
						}
					}
				}
			}
		}
	}
}
