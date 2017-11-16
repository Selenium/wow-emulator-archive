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

// Written by DK ask him if you dont understand somewhere

#include "WorldPacket.h"
#include "WorldSession.h"
#include "Opcodes.h"
#include "Log.h"
#include "World.h"
#include "ObjectMgr.h"
#include "Player.h"
#include "UpdateMask.h"
#include "Unit.h"
#include "Chat.h"
#include "Guild.h"

void Guild::SendMessageToGuild(uint64 ExcludePlayer, WorldPacket *data, uint8 Type)
{
	std::list<guildMembers*>::iterator i;
	for (i = m_guildMembers.begin(); i != m_guildMembers.end();++i)
	{
		if(Type == G_MSGTYPE_ALLBUTONE)
		{
			if((*i)->memberGuid == ExcludePlayer)
				continue;
		}

		Player *pMember = objmgr.GetPlayer( (*i)->memberGuid );
		if (!pMember)
			continue;
		
		uint32 MemberRank = pMember->GetGuildRank();
		if(Type == G_MSGTYPE_OFFICERCHAT)
		{
			if(!HasRankRight(MemberRank,GR_RIGHT_OFFCHATLISTEN))
				continue;
		}
		else if(Type == G_MSGTYPE_PUBLICCHAT)
		{
			if(!HasRankRight(MemberRank,GR_RIGHT_GCHATLISTEN))
				continue;
		}
		if(pMember->GetSession())
		{
			pMember->GetSession()->SendPacket(data);
		}
	}
}
void Guild::GuildMemberLogoff(Player *pMember)
{
	//set offline info
	std::list<guildMembers*>::iterator i;
	for (i = m_guildMembers.begin(); i != m_guildMembers.end();++i) 
	{
		if ((*i)->memberGuid == pMember->GetGUID())
		{
			(*i)->lastClass = pMember->getClass();
			(*i)->lastLevel = pMember->getLevel();
			(*i)->lastZone = pMember->GetZoneId();
			(*i)->lastOnline = time(NULL);
			pMember->SaveGuild();
			return;
		}
	}
}
void Guild::AddNewGuildMember(Player *plyr)
{
	guildMembers *gMember;
	gMember = new guildMembers;
	gMember->memberGuid = plyr->GetGUID();
	gMember->memberName = plyr->GetName();
	gMember->Rank = plyr->GetGuildRank();
	gMember->lastClass =plyr->getClass();
	gMember->lastLevel =plyr->getLevel();
	gMember->lastZone =plyr->GetZoneId();
	gMember->publicNote = "";
	gMember->officerNote = "";
	gMember->lastOnline = time(NULL);

	AddGuildMember(gMember);
}

void Guild::DeleteGuildMember(uint64 guid)
{
	std::list<guildMembers*>::iterator i;
	for (i = m_guildMembers.begin(); i != m_guildMembers.end();++i) 
	{
		if ((*i)->memberGuid == guid)
		{
			m_guildMembers.erase(i);
			return;
		}
	}
}

void Guild::DeleteGuildMembers()
{
	Player *plyr;
	std::list<guildMembers*>::iterator i;
	for (i = m_guildMembers.begin(); i != m_guildMembers.end();) 
	{
		plyr = objmgr.GetPlayer( (*i)->memberGuid );

		if(plyr)
		{
			plyr->SetGuildId(0);
			plyr->SetGuildRank(0);
			plyr->SetUInt32Value(PLAYER_GUILDID,0);
			plyr->SetUInt32Value(PLAYER_GUILDRANK,0);
		}
		i++;
	}
	m_guildMembers.clear();
}

guildMembers* Guild::GetGuildMember(uint64 guid)
{
	std::list<guildMembers*>::iterator i;
	for (i = m_guildMembers.begin(); i != m_guildMembers.end();++i) 
	{
		if ((*i)->memberGuid == guid)
		{
			return *i;
		}
	}
	return false;
}

guildMembers* Guild::GetGuildMember(std::string name)
{
	std::list<guildMembers*>::iterator i;
	for (i = m_guildMembers.begin(); i != m_guildMembers.end();++i) 
	{
		if(strcmp((*i)->memberName.c_str(), name.c_str()) == 0)
			return *i;
	}
	return false;
}

void Guild::FillGuildRosterData(WorldPacket *data)
{
	Player *pMember;
	std::list<guildMembers*>::iterator i;
	std::list<RankInfo*>::iterator ritr;

	data->Initialize(SMSG_GUILD_ROSTER);
	*data << GetGuildMembersCount();
	*data << m_motd;
	*data << m_guildInfo;
	*data << (uint32)m_rankList.size();
	for (ritr = m_rankList.begin(); ritr != m_rankList.end();ritr++)
		*data << (*ritr)->rights;
	for (i = m_guildMembers.begin(); i != m_guildMembers.end(); i++) 
	{
		pMember = objmgr.GetPlayer((*i)->memberGuid);
		if (pMember)
		{
			*data << pMember->GetGUID();
			*data << (uint8)1; 
			*data << pMember->GetName();
			*data << pMember->GetGuildRank();
			*data << pMember->getLevel();
			*data << pMember->getClass();
			*data << pMember->GetZoneId();
			*data << (*i)->publicNote;
			*data << (*i)->officerNote;
		}
		else
		{
			*data << (*i)->memberGuid;
			*data << (uint8)0; 
			*data << (*i)->memberName;
			*data << (*i)->Rank;
			*data << (*i)->lastLevel;
			*data << (*i)->lastClass;
			*data << (*i)->lastZone;
			*data << uint32((*i)->lastOnline); //time offline
			*data << (*i)->publicNote;
			*data << (*i)->officerNote;
		}
	}
}

void Guild::BroadCastToGuild(WorldSession *session, std::string msg)
{
	WorldPacket data;

	if (session)
	{
		if(session->GetPlayer())
		{	
			uint32 MemberRank = session->GetPlayer()->GetGuildRank();
			if(!HasRankRight(MemberRank,GR_RIGHT_GCHATSPEAK))
				return;

			data.clear();
			sChatHandler.FillMessageData(&data, session, CHAT_MSG_GUILD, LANG_UNIVERSAL, NULL, msg.c_str());
			SendMessageToGuild(NULL, &data, G_MSGTYPE_PUBLICCHAT);

		}
	}
}

void Guild::OfficerChannelChat(WorldSession *session, std::string msg)
{
	WorldPacket data;

	if (session)
	{
		if(session->GetPlayer())
		{
			uint32 MemberRank = session->GetPlayer()->GetGuildRank();
			if(!HasRankRight(MemberRank,GR_RIGHT_OFFCHATSPEAK))
				return;

			data.clear();
			sChatHandler.FillMessageData(&data, session, CHAT_MSG_OFFICER, LANG_UNIVERSAL, NULL, msg.c_str());
			SendMessageToGuild(NULL, &data, G_MSGTYPE_OFFICERCHAT);
		}
	}
}

void Guild::SetPublicNote(uint64 guid, std::string publicNote)
{
	std::list<guildMembers*>::iterator i;
	for (i = m_guildMembers.begin(); i != m_guildMembers.end();++i) 
	{
		if ((*i)->memberGuid == guid)
		{
			(*i)->publicNote = publicNote;
			break;
		}
	}
}

void Guild::SetOfficerNote(uint64 guid, std::string officerNote)
{
	std::list<guildMembers*>::iterator i;
	for (i = m_guildMembers.begin(); i != m_guildMembers.end();++i) 
	{
		if ((*i)->memberGuid == guid)
		{
			(*i)->officerNote = officerNote;
			break;
		}
	}
}
/*
void Guild::UpdateTabard()
{
	std::list<guildMembers*>::iterator i;
	for (i = m_guildMembers.begin(); i != m_guildMembers.end();++i;) 
	{
		Player *pl = objmgr.GetPlayer( i->memberGuid );
		if (pl)
		{
			uint64 TabardGuid = pl->GetUInt64Value();
		}
	}

	//UpdateData *data = new UpdateData;
	//data->BuildPacket()*/
	/*	CUpdateBlock block;
	char updateBuf[0x80];
	int size;
	char *ptr;
	map<string, unsigned long>::iterator i;
	for(i = Members.begin();i != Members.end();i++)
	{
	CPlayer *pPlayer = NULL;
	if(!DataManager.RetrieveObject((CWoWObject**)&pPlayer, OBJ_PLAYER, i->second))
	{
	#ifdef _DEBUG
	Debug.Log("CGuild::UpdateTabard() - Unable to retrieve an object found in the member list.");
	#endif
	continue;
	}

	pPlayer->Data.GuildTimestamp++;
	if(pPlayer->pClient != NULL)
	{
	block.ResetBlock(updateBuf, 0x80);
	block.AddDataUpdate(PLAYER_MAX_BITS, pPlayer->guid, PLAYERGUID_HIGH);
	block.Add(PLAYER_GUILD_TIMESTAMP, pPlayer->Data.GuildTimestamp);
	if(pPlayer->Data.Items[SLOT_TABARD] != 0)
	block.Add(PLAYER_INV_SLOTS+SLOT_TABARD*2, 0,0);

	ptr = block.GetCompressedData(size);
	if(size)
	{
	pPlayer->pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
	}
	if(pPlayer->Data.Items[SLOT_TABARD] != 0)
	{
	block.ResetBlock(updateBuf, 0x80);
	block.AddDataUpdate(PLAYER_MAX_BITS, pPlayer->guid, PLAYERGUID_HIGH);
	block.Add(PLAYER_INV_SLOTS+SLOT_TABARD*2, pPlayer->Data.Items[SLOT_TABARD], ITEMGUID_HIGH);
	ptr = block.GetCompressedData(size);
	if(size)
	{
	pPlayer->pClient->RegionOutPacket(SMSG_COMPRESSED_UPDATE_OBJECT, ptr, size);
	}
	}
	}
	}
}
*/
void Guild::CreateRank(std::string name,uint32 rights)
{
	if(m_rankList.size() >= MAX_GUILD_RANKS)
		return;

	RankInfo *newrank;

	newrank = new RankInfo;
	newrank->rankid = m_rankList.size();
	newrank->name = name;
	newrank->rights = rights;
	m_rankList.push_back(newrank);
}

std::string Guild::GetRankName(uint32 rankId)
{
	std::list<RankInfo*>::iterator itr;
	if(rankId > m_rankList.size()-1) return NULL;

	for (itr = m_rankList.begin(); itr != m_rankList.end();itr++)
	{
		if ((*itr)->rankid == rankId)
			return (*itr)->name;
	}
	return NULL;
}

uint32 Guild::GetRankRights(uint32 rankId)
{
	std::list<RankInfo*>::iterator itr;
	if(rankId > m_rankList.size()-1) return NULL;

	for (itr = m_rankList.begin(); itr != m_rankList.end();itr++)
	{
		if ((*itr)->rankid == rankId)
			return (*itr)->rights;
	}
	return NULL;
}

void Guild::SetRankName(uint32 rankId, std::string name)
{
	std::list<RankInfo*>::iterator itr;
	if(rankId > m_rankList.size()-1) return;

	for (itr = m_rankList.begin(); itr != m_rankList.end();itr++)
	{
		if ((*itr)->rankid == rankId)
		{
			(*itr)->name = name;
			break;
		}
	}
}

void Guild::SetRankRights(uint32 rankId, uint32 rights)
{
	std::list<RankInfo*>::iterator itr;
	if(rankId > m_rankList.size()-1) return;

	for (itr = m_rankList.begin(); itr != m_rankList.end();itr++)
	{
		if ((*itr)->rankid == rankId)
		{
			(*itr)->rights = rights;
			break;
		}
	}
}

void Guild::FillQueryData(WorldPacket *data)
{
	data->Initialize(SMSG_GUILD_QUERY_RESPONSE);
	*data << GetGuildId();
	*data << GetGuildName();
	std::list<RankInfo*>::iterator itr;
	for (itr = m_rankList.begin(); itr != m_rankList.end();itr++)
		*data << (*itr)->name;
	for (uint32 r = m_rankList.size(); r < MAX_GUILD_RANKS;++r)
		*data << uint8(0);
	*data << GetGuildEmblemStyle();
	*data << GetGuildEmblemColor();
	*data << GetGuildBorderStyle();
	*data << GetGuildBorderColor();
	*data << GetGuildBackgroundColor();
}

void Guild::SaveToDb()
{
	std::stringstream query;
	query << "DELETE FROM guilds WHERE guildId = " << m_guildId;
	sDatabase.Execute( query.str( ).c_str( ) );

	query.rdbuf()->str("");

	query << "INSERT INTO `guilds` VALUES (";
	query << m_guildId << ",'";
	query << m_guildName << "', ";
	query << m_leaderGuid << ", ";
	query << m_emblemStyle << ", ";
	query << m_emblemColor << ", ";
	query << m_borderStyle << ", ";
	query << m_borderColor << ", ";
	query << m_backgroundColor << ", ";
	query << "'" << m_guildInfo << "', ";
	query << "'" << m_motd << "', NOW())";

	sDatabase.Execute( query.str().c_str() );
}

void Guild::UpdateGuildToDb()
{
	std::stringstream query;

	query << "UPDATE guilds SET leaderGuid = " << m_leaderGuid << ", ";
	query << "emblemStyle = " << m_emblemStyle << ", ";
	query << "emblemColor = " << m_emblemColor << ", ";
	query << "borderStyle = " << m_borderStyle << ", ";
	query << "borderColor = " << m_borderColor << ", ";
	query << "backgroundColor = " << m_backgroundColor << ", ";
	query << "guildInfo = '" << m_guildInfo << "', ";
	query << "motd = '" << m_motd << "' ";
	query << "WHERE guildId = " << m_guildId;
	sDatabase.Execute( query.str( ).c_str( ) );
}

void Guild::SaveRanksToDb()
{
	std::stringstream query;

	query << "DELETE FROM guild_ranks WHERE guildId = " << m_guildId;
	sDatabase.Execute( query.str( ).c_str( ) );

	std::list<RankInfo*>::iterator itr;
	for (itr = m_rankList.begin(); itr != m_rankList.end();itr++)
	{
		query.rdbuf()->str("");
		query << "INSERT INTO `guild_ranks` VALUES (";
		query << m_guildId << ", ";
		query << (*itr)->rankid << ", ";
		query << "'" << (*itr)->name << "', ";
		query << (*itr)->rights;
		query << ")";
		sDatabase.Execute( query.str().c_str() );
	}
}
/*
void Guild::SaveGuildMemberToDb(uint64 memberGuid)
{
	std::stringstream query;
	std::list<guildMembers*>::iterator i;

	for (i = m_guildMembers.begin(); i != m_guildMembers.end();++i) 
	{
		if((*i)->memberGuid == memberGuid)
		{
			query << "DELETE FROM playerguilds WHERE playerId = " << (*i)->memberGuid;
			sDatabase.Execute( query.str( ).c_str( ) );
			query.rdbuf()->str("");    

			query << "INSERT INTO `playerguilds` VALUES (" << (*i)->memberGuid << ", " << m_guildId << ", '" << (*i)->memberName << "', " << (*i)->Rank << ", '" << (*i)->publicNote << "', '" << (*i)->officerNote << "', " << (*i)->lastOnline << ")";
			sDatabase.Execute( query.str( ).c_str( ) );
			break;
		}
	}
}
*/

void Guild::UpdateGuildMembersDB(guildMembers *Member)
{
	std::stringstream query;

	query << "UPDATE `playerguilds` SET guildRank = "<< Member->Rank << ", publicNote = '" << Member->publicNote  << "', officerNote = '" << Member->officerNote  << "' WHERE playerId = " << Member->memberGuid;
	sDatabase.Execute( query.str( ).c_str( ) );
}


void Guild::SaveAllGuildMembersToDb()
{
	std::stringstream query;
	std::list<guildMembers*>::iterator i;

	for (i = m_guildMembers.begin(); i != m_guildMembers.end();++i) 
	{
		query << "DELETE FROM playerguilds WHERE playerId = " << (*i)->memberGuid;    
		sDatabase.Execute( query.str( ).c_str( ) );
		query.rdbuf()->str("");    

		query << "INSERT INTO `playerguilds` VALUES (" << (*i)->memberGuid << ", " << m_guildId << ", '" << (*i)->memberName << "', " << (*i)->Rank << ", '" << (*i)->publicNote << "', '" << (*i)->officerNote << "', " << (*i)->lastOnline << ", " << (*i)->lastClass << ", " << (*i)->lastLevel << ", " << (*i)->lastZone << ")";
		sDatabase.Execute( query.str( ).c_str( ) );
	}
}

void Guild::RemoveGuildMemberFromDb(uint64 memberGuid)
{
	std::stringstream query;
	std::list<guildMembers*>::iterator i;

	for (i = m_guildMembers.begin(); i != m_guildMembers.end();++i) 
	{
		if((*i)->memberGuid == memberGuid)
		{
			query << "DELETE FROM playerguilds WHERE playerId = " << (*i)->memberGuid;    
			sDatabase.Execute( query.str( ).c_str( ) );
			break;
		}
	}
}

void Guild::RemoveAllGuildMembersFromDb()
{
	std::stringstream query;
	std::list<guildMembers*>::iterator i;

	for (i = m_guildMembers.begin(); i != m_guildMembers.end();++i) 
	{
		query.rdbuf()->str("");    

		query << "DELETE FROM playerguilds WHERE playerId = " << (*i)->memberGuid;    
		sDatabase.Execute( query.str( ).c_str( ) );
	}
}

void Guild::RemoveFromDb()
{
	std::stringstream query;

	query << "DELETE FROM guilds WHERE guildId = " << m_guildId;    
	sDatabase.Execute( query.str( ).c_str( ) );

	query.rdbuf()->str("");

	query << "DELETE FROM playerguilds WHERE guildId = " << m_guildId;    
	sDatabase.Execute( query.str( ).c_str( ) );

	query.rdbuf()->str("");

	query << "DELETE FROM guild_ranks WHERE guildId = " << m_guildId;
	sDatabase.Execute( query.str( ).c_str( ) );
}

uint32 Guild::GetFreeGuildIdFromDb()
{
	std::stringstream query;
	uint32 guildId = 1;

	query << "SELECT MAX(guildId) FROM guilds";
	QueryResult *result = sDatabase.Query( query.str().c_str() );
	if(result)
	{
		Field *fields = result->Fetch();

		guildId = fields[0].GetUInt32();
		return guildId+1;
	}
	return 0;
}

void Guild::LoadGuildCreationDate()
{
	std::stringstream query;
	Field *fields;

	query << "SELECT DATE_FORMAT(createdate,\"%d\") FROM guilds WHERE guildId =" << m_guildId;
	QueryResult *result1 = sDatabase.Query( query.str().c_str() );
	if(!result1) return;
	fields = result1->Fetch();
	m_createdDay = fields[0].GetUInt32();

	delete result1;

	query.rdbuf()->str("");
	query << "SELECT DATE_FORMAT(createdate,\"%m\") FROM guilds WHERE guildId =" << m_guildId;
	QueryResult *result2 = sDatabase.Query( query.str().c_str() );
	if(!result2) return;
	fields = result2->Fetch();
	m_createdMonth = fields[0].GetUInt32();

	delete result2;

	query.rdbuf()->str("");
	query << "SELECT DATE_FORMAT(createdate,\"%Y\") FROM guilds WHERE guildId =" << m_guildId;
	QueryResult *result3 = sDatabase.Query( query.str().c_str() );
	if(!result3) return;
	fields = result3->Fetch();
	m_createdYear = fields[0].GetUInt32();

	delete result3;
}
