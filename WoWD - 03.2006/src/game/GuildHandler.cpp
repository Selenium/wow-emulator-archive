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
// Ranks by Mangos

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

void WorldSession::HandleGuildQuery(WorldPacket & recv_data)
{
    WorldPacket data;
    
    Guild *pGuild;
    uint32 guildId;
    
    recv_data >> guildId;

    //Player *plyr = GetPlayer();
    //if(!plyr)
    //    return;

    pGuild = objmgr.GetGuild( guildId );

    if(!pGuild)
		return;
	
	pGuild->FillQueryData(&data);
	SendPacket(&data);
}

void WorldSession::HandleCreateGuild(WorldPacket & recv_data)
{
/*    std::string guildName;
    uint64 count;
	int i;
    Player * plyr = GetPlayer();

    if(!plyr)
        return;

    recv_data >> guildName;

    Guild *pGuild = new Guild;

    count = objmgr.GetTotalGuildCount();

	pGuild->SetGuildId( (uint32)(count+1) );
	pGuild->SetGuildName( guildName );
	pGuild->SetGuildRankName("Guild Master", 0);
    pGuild->SetGuildRankName("Officer", 1);
    pGuild->SetGuildRankName("Veteran", 2);  
    pGuild->SetGuildRankName("Member", 3);
    pGuild->SetGuildRankName("Initiate", 4);

	for(i = 5;i < 10;i++)
		pGuild->SetGuildRankName("Unused", i);

	pGuild->SetGuildEmblemStyle( 0xFFFF );
    pGuild->SetGuildEmblemColor( 0xFFFF );
    pGuild->SetGuildBorderStyle( 0xFFFF );
    pGuild->SetGuildBorderColor( 0xFFFF );
	pGuild->SetGuildBackgroundColor( 0xFFFF );

    objmgr.AddGuild(pGuild);

	plyr->SetGuildId( pGuild->GetGuildId() );
	plyr->SetUInt32Value(PLAYER_GUILDID, pGuild->GetGuildId() );
    plyr->SetGuildRank(GUILDRANK_GUILD_MASTER);
    plyr->SetUInt32Value(PLAYER_GUILDRANK,GUILDRANK_GUILD_MASTER);
	pGuild->SetGuildLeaderGuid( plyr->GetGUID() );

    pGuild->AddNewGuildMember( plyr );

    pGuild->SaveToDb();*/
}

void WorldSession::HandleInviteToGuild(WorldPacket & recv_data)
{
    WorldPacket data;
    std::string inviteeName;
 
    recv_data >> inviteeName;
 
    Player *plyr = objmgr.GetPlayer( inviteeName.c_str() );
    Player *inviter = GetPlayer();
    Guild *pGuild = objmgr.GetGuild( inviter->GetGuildId() );
 
    if(!inviter || !plyr)
        return;

    uint32 inviterRank = inviter->GetGuildRank();

	if(!pGuild->HasRankRight(inviterRank,GR_RIGHT_INVITE))
    {
        data.Initialize(SMSG_GUILD_COMMAND_RESULT);
        data << uint8(0x03);
        data << uint8(0);
        data << uint8(0x08);//guild permissions
        SendPacket(&data);
        return;
    }

    //TODO: Add alliance-horde check here!
 
    if(!plyr->IsInGuild() && inviter->IsInGuild())//if everything works
    {
        data.Initialize(SMSG_GUILD_INVITE);
        data << inviteeName;
		data << pGuild->GetGuildName();
		plyr->GetSession()->SendPacket(&data);
        plyr->SetGuildInvitersGuid( inviter->GetGUID() );
    }
}
 
void WorldSession::HandleGuildAccept(WorldPacket & recv_data)
{
    Player *plyr = GetPlayer();

	if(!plyr)
		return;
    
	Player *inviter = objmgr.GetPlayer( plyr->GetGuildInvitersGuid() );
	plyr->UnSetGuildInvitersGuid();

	if(!inviter)
	{
        return;
	}

    Guild *pGuild = objmgr.GetGuild( inviter->GetGuildId() );

    if(!pGuild)
	{
        return;
	}

	plyr->SetGuildId( pGuild->GetGuildId() );
	plyr->SetUInt32Value(PLAYER_GUILDID, pGuild->GetGuildId());
    plyr->SetGuildRank(GUILDRANK_INITIATE);
    plyr->SetUInt32Value(PLAYER_GUILDRANK, GUILDRANK_INITIATE);

    plyr->DeleteFromSignedCharters(0);
    plyr->DeleteAllCharterData();

    pGuild->AddNewGuildMember( plyr );
	plyr->SaveGuild();
	
	WorldPacket data;
	data.Initialize(SMSG_GUILD_EVENT);
    data << uint8(GUILD_EVENT_JOINED);
    data << uint8(1);
    data << plyr->GetName();
	pGuild->SendMessageToGuild(NULL, &data, G_MSGTYPE_ALL);
}
 
void WorldSession::HandleGuildDecline(WorldPacket & recv_data)
{
    WorldPacket data;
 
    Player *plyr = GetPlayer();
	
	if(!plyr)
		return;

    Player *inviter = objmgr.GetPlayer( (uint64)(plyr->GetGuildInvitersGuid()) );
    plyr->UnSetGuildInvitersGuid(); 
	
	if(!inviter)
		return;
	

    data.Initialize(SMSG_GUILD_DECLINE);
    data << plyr->GetName();
    inviter->GetSession()->SendPacket(&data);
}
void WorldSession::HandleSetGuildInformation(WorldPacket & recv_data)
{
	WorldPacket data;
	std::string NewGuildInfo;
	recv_data >> NewGuildInfo;

	Guild *pGuild = objmgr.GetGuild( GetPlayer()->GetGuildId() );

	if(!pGuild)
		return;

	uint32 plyrRank = GetPlayer()->GetGuildRank();

    if(!pGuild->HasRankRight(plyrRank,GR_RIGHT_EGUILDINFO))
    {
        data.Initialize(SMSG_GUILD_COMMAND_RESULT);
        data << uint8(0x03);
        data << uint8(0);
        data << uint8(0x08);//guild permissions
        SendPacket(&data);
        return;
    }

	pGuild->SetGuildInfo(NewGuildInfo);

	pGuild->FillGuildRosterData(&data);
	GetPlayer()->GetSession()->SendPacket(&data);

	pGuild->UpdateGuildToDb();
}

void WorldSession::HandleGuildInfo(WorldPacket & recv_data)
{
    WorldPacket data;

    Guild *pGuild = objmgr.GetGuild( GetPlayer()->GetGuildId() );

    if(!pGuild)
        return;

    data.Initialize(SMSG_GUILD_INFO);//not sure
    data << pGuild->GetGuildName();
    data << pGuild->GetCreatedYear();
    data << pGuild->GetCreatedMonth();
    data << pGuild->GetCreatedDay();
    data << pGuild->GetGuildMembersCount();
    data << pGuild->GetGuildMembersCount();//accountcount

    SendPacket(&data);
}

void WorldSession::HandleGuildRoster(WorldPacket & recv_data)
{
    WorldPacket data;

    Guild *pGuild = objmgr.GetGuild( GetPlayer()->GetGuildId() );

    if(!pGuild)
        return;

	pGuild->FillGuildRosterData(&data);
	GetPlayer()->GetSession()->SendPacket(&data);
}

void WorldSession::HandleGuildPromote(WorldPacket & recv_data)
{
    WorldPacket data;
    std::string name;
    guildMembers gMember;
    uint32 plyrRank;
    uint32 pTargetRank;
    
    recv_data >> name;

    Player *plyr = GetPlayer();
    
	if(!plyr)
        return;

    Guild *pGuild = objmgr.GetGuild( plyr->GetGuildId() );

    if(!pGuild)
        return;

	guildMembers *pGuildMember = pGuild->GetGuildMember(name);

	if(!pGuildMember)
	{
		data.Initialize(SMSG_GUILD_COMMAND_RESULT);
        data << uint8(0x0C); // cmd quit?
        data << name.c_str();
        data << uint8(0x0A); // <name> is not in your guild.
        SendPacket(&data);
        return;
	}

    plyrRank = plyr->GetGuildRank();
    pTargetRank = pGuildMember->Rank;

    if(!pGuild->HasRankRight(plyrRank,GR_RIGHT_PROMOTE))
    {
        data.Initialize(SMSG_GUILD_COMMAND_RESULT);
        data << uint8(0x03);
        data << uint8(0);
        data << uint8(0x08);//guild permissions
        SendPacket(&data);
        return;
    }

    if( plyr->GetGUID() == pGuildMember->memberGuid )
    {
        sChatHandler.FillSystemMessageData(&data, plyr->GetSession(), "You cant promote yourself!");
        return;
    }

    if( plyrRank >= pTargetRank )
    {
        sChatHandler.FillSystemMessageData(&data, plyr->GetSession(), "You must be a higher ranking guild member than the person you are going to promote!");
        return;
    }

    /*if(pPlayer->Data.GuildRank == GUILDRANK_OFFICER && pClient->pPlayer->Data.GuildRank == GUILDRANK_GM)
	{
		pClient->Echo("Use the /gleader command to change guildmaster.");
		return;
	}*/

    if( (pTargetRank - plyrRank) == 1 )
	{
        sChatHandler.FillSystemMessageData(&data, plyr->GetSession(), "You can only promote up to one rank below yours!");
		return;
	}          
     
    pTargetRank--;
    if(pTargetRank < GUILDRANK_GUILD_MASTER)
        pTargetRank = GUILDRANK_GUILD_MASTER;
	
	pGuildMember->Rank = pTargetRank;

	Player *pTarget = objmgr.GetPlayer( name.c_str() );
	if(pTarget)
	{
		//They Online
		pTarget->SetGuildRank(pTargetRank);
		pTarget->SetUInt32Value(PLAYER_GUILDRANK, pTargetRank);
	}

	//Save new Info to DB
	pGuild->UpdateGuildMembersDB(pGuildMember);

    //check if its unused rank or not

    data.Initialize(SMSG_GUILD_EVENT);
    data << uint8(GUILD_EVENT_PROMOTION);
    data << uint8(3);
	data << plyr->GetName();
    data << name.c_str();
    data << pGuild->GetRankName( pTargetRank );
	pGuild->SendMessageToGuild(NULL, &data, G_MSGTYPE_ALL);
}

void WorldSession::HandleGuildDemote(WorldPacket & recv_data)
{
    WorldPacket data;
    std::string name;
    guildMembers gMember;
    uint32 plyrRank;
    uint32 pTargetRank;
    
    recv_data >> name;

    Player *plyr = GetPlayer();
    
	if(!plyr)
        return;

    Guild *pGuild = objmgr.GetGuild( plyr->GetGuildId() );

    if(!pGuild)
        return;

	guildMembers *pGuildMember = pGuild->GetGuildMember(name);

	if(!pGuildMember)
	{
		data.Initialize(SMSG_GUILD_COMMAND_RESULT);
        data << uint8(0x0C); // cmd quit?
        data << name.c_str();
        data << uint8(0x0A); // <name> is not in your guild.
        SendPacket(&data);
        return;
	}

    plyrRank = plyr->GetGuildRank();
    pTargetRank = pGuildMember->Rank;

    if(!pGuild->HasRankRight(plyrRank,GR_RIGHT_DEMOTE))
    {
        data.Initialize(SMSG_GUILD_COMMAND_RESULT);
        data << uint8(0x03);
        data << uint8(0);
        data << uint8(0x08);//guild permissions
        SendPacket(&data);
        return;
    }

    if( plyr->GetGUID() == pGuildMember->memberGuid )
    {
        sChatHandler.FillSystemMessageData(&data, plyr->GetSession(), "You cant demote yourself!");
        return;
    }

    if( plyrRank >= pTargetRank )
    {
        sChatHandler.FillSystemMessageData(&data, plyr->GetSession(), "You must be a higher ranking guild member than the person you are going to demote!");
        return;
    }

    /*if(pPlayer->Data.GuildRank == GUILDRANK_OFFICER && pClient->pPlayer->Data.GuildRank == GUILDRANK_GM)
	{
		pClient->Echo("Use the /gleader command to change guildmaster.");
		return;
	}*/
   
    if(pTargetRank == pGuild->GetNrRanks()-1)
	{
		sChatHandler.FillSystemMessageData(&data, plyr->GetSession(), "You cannot demote that member any further!");
		return;
	}

	pTargetRank++;
	if(pTargetRank > pGuild->GetNrRanks()-1)
		pTargetRank = pGuild->GetNrRanks()-1;

	pGuildMember->Rank = pTargetRank;

	Player *pTarget = objmgr.GetPlayer( name.c_str() );
	if(pTarget)
	{
		//They Online
		pTarget->SetGuildRank(pTargetRank);
		pTarget->SetUInt32Value(PLAYER_GUILDRANK, pTargetRank);
	}

	//Save new Info to DB
	pGuild->UpdateGuildMembersDB(pGuildMember);

	data.Initialize(SMSG_GUILD_EVENT);
	data << uint8(GUILD_EVENT_DEMOTION);
	data << uint8(3);
	data << plyr->GetName();
	data << name.c_str();
	data << pGuild->GetRankName( pTargetRank );
	pGuild->SendMessageToGuild(NULL, &data, G_MSGTYPE_ALL);
}

void WorldSession::HandleGuildLeave(WorldPacket & recv_data)
{
    Player *plyr = GetPlayer();
	
	if(!plyr)
		return;

    Guild *pGuild = objmgr.GetGuild( plyr->GetGuildId() );

	if(!pGuild)
		return;

	if( pGuild->GetGuildLeaderGuid() == plyr->GetGUID() )
        return;
    
    plyr->SetGuildId(0);
    plyr->SetGuildRank(0);
    plyr->SetUInt32Value(PLAYER_GUILDID,0);
    plyr->SetUInt32Value(PLAYER_GUILDRANK,0);
    pGuild->DeleteGuildMember(plyr->GetGUID());
    pGuild->RemoveGuildMemberFromDb(plyr->GetGUID());
    
	WorldPacket data;
	data.Initialize(SMSG_GUILD_EVENT);
    data << uint8(GUILD_EVENT_LEFT);
    data << uint8(1);
    data << plyr->GetName();
	pGuild->SendMessageToGuild(NULL, &data, G_MSGTYPE_ALL);
}

void WorldSession::HandleGuildRemove(WorldPacket & recv_data)
{
    WorldPacket data;
    std::string name;

    recv_data >> name;
    Player *plyr = objmgr.GetPlayer( name.c_str() );
    Player *pRemover = GetPlayer();

    if(!pRemover || !plyr)
        return;

    Guild *pGuild = objmgr.GetGuild( pRemover->GetGuildId() );

    if(!pGuild)
        return;

    uint32 RemoverRank = pRemover->GetGuildRank();

    if(!pGuild->HasRankRight(RemoverRank,GR_RIGHT_REMOVE))
    {
		//Players not allowed to remove a guild member
		data.Initialize(SMSG_GUILD_COMMAND_RESULT);
        data << uint8(0x03);
        data << uint8(0);
        data << uint8(0x08);//guild permissions
        SendPacket(&data);
		return;
	}

	plyr->SetGuildId(0);
    plyr->SetGuildRank(0);
    plyr->SetUInt32Value(PLAYER_GUILDID,0);
    plyr->SetUInt32Value(PLAYER_GUILDRANK,0);
    pGuild->DeleteGuildMember(plyr->GetGUID());
    pGuild->RemoveGuildMemberFromDb(plyr->GetGUID());

    data.Initialize(SMSG_GUILD_EVENT);
    data << uint8(GUILD_EVENT_REMOVED);
    data << uint8(2);
    data << plyr->GetName();
	data << pRemover->GetName();
	pGuild->SendMessageToGuild(NULL, &data, G_MSGTYPE_ALL);
}

void WorldSession::HandleGuildDisband(WorldPacket & recv_data)
{
    Player *pLeader = GetPlayer();

    if(!pLeader)
        return;

    Guild *pGuild = objmgr.GetGuild( pLeader->GetGuildId() );

    if(!pGuild)
        return;

	if(pLeader->GetGUID() != pGuild->GetGuildLeaderGuid())
		return;

    pGuild->DeleteGuildMembers();
    pGuild->RemoveFromDb();
}

void WorldSession::HandleGuildLeader(WorldPacket & recv_data)
{
    std::string name;
    recv_data >> name;

    Player *pNewLeader = objmgr.GetPlayer( name.c_str() );
    Player *pLeader = GetPlayer();

    if(!pNewLeader || !pLeader)
        return;

    if(pNewLeader == pLeader)
        return;

    Guild *pGuild = objmgr.GetGuild( pLeader->GetGuildId() );
    
	if(!pGuild)
		return;

	if(pLeader->GetGUID() != pGuild->GetGuildLeaderGuid())
		return;

    pLeader->SetUInt32Value(PLAYER_GUILDRANK,GUILDRANK_MEMBER);
    pNewLeader->SetUInt32Value(PLAYER_GUILDRANK,GUILDRANK_GUILD_MASTER);
	pGuild->SetGuildLeaderGuid( pNewLeader->GetGUID() );

    pGuild->UpdateGuildToDb();

	//Maybe theres an event for this
	WorldPacket data;
	//pGuild->FillGuildRosterData(&data);
	data.Initialize(SMSG_GUILD_EVENT);
	data << (uint8)GUILD_EVENT_LEADER_CHANGED;
	data << (uint8)2;
	data << pLeader->GetName();
	data << pNewLeader->GetName();
	
	//SendPacket(&data);
	pGuild->SendMessageToGuild(NULL, &data, G_MSGTYPE_ALL);
}

void WorldSession::HandleGuildMotd(WorldPacket & recv_data)
{
	WorldPacket data;
	std::string motd;

	recv_data >> motd;

	if(motd.size() <= 0)
		return;

    Guild *pGuild = objmgr.GetGuild( GetPlayer()->GetGuildId() );

    if(!pGuild)
        return;

	pGuild->SetGuildMotd(motd);
    
    data.Initialize(SMSG_GUILD_EVENT);
    data << uint8(GUILD_EVENT_MOTD);
    data << uint8(0x01);
	data << pGuild->GetGuildMotd();
	pGuild->SendMessageToGuild(NULL, &data, G_MSGTYPE_ALL);

    pGuild->UpdateGuildToDb();
}

void WorldSession::HandleGuildRank(WorldPacket & recv_data)
{
    WorldPacket data;
	Guild *pGuild;
	std::string rankname;
	uint32 rankId;
	uint32 rights;
    
	pGuild = objmgr.GetGuild(GetPlayer()->GetGuildId());
	if(!pGuild)
	{
        data.Initialize(SMSG_GUILD_COMMAND_RESULT);
        data << uint8(GUILD_CREATE_S);
        data << uint8(0);
        data << uint8(C_R_NOT_IN_GUILD);
		return;
	}
	
    if(GetPlayer()->GetGUID() != pGuild->GetGuildLeaderGuid())
	{
        data.Initialize(SMSG_GUILD_COMMAND_RESULT);
        data << uint8(GUILD_INVITE_S);
        data << uint8(0);
        data << uint8(C_R_DONT_HAVE_PERMISSION);
		return;
	}

	recv_data >> rankId;
	recv_data >> rights;
	recv_data >> rankname;
	
	sLog.outDebug( "WORLD: Changed RankName to %s , Rights to 0x%.4X",rankname.c_str() ,rights );

	pGuild->SetRankName(rankId,rankname);
	pGuild->SetRankRights(rankId,rights);

	pGuild->FillQueryData(&data);
	pGuild->SendMessageToGuild(NULL, &data, G_MSGTYPE_ALL);
	
	data.clear();
	pGuild->FillGuildRosterData(&data);
	pGuild->SendMessageToGuild(NULL, &data, G_MSGTYPE_ALL);

    pGuild->SaveRanksToDb();
}

void WorldSession::HandleGuildAddRank(WorldPacket & recv_data)
{
	WorldPacket data;
	Guild *pGuild;
	std::string rankname;

	pGuild = objmgr.GetGuild(GetPlayer()->GetGuildId());
	if(!pGuild)
	{
		//not in Guild
		data.Initialize(SMSG_GUILD_COMMAND_RESULT);
        data << uint8(GUILD_CREATE_S);
        data << uint8(0);
        data << uint8(C_R_NOT_IN_GUILD);
		return;
	}
	
    if(GetPlayer()->GetGUID() != pGuild->GetGuildLeaderGuid())
	{
		//not GuildMaster
		data.Initialize(SMSG_GUILD_COMMAND_RESULT);
        data << uint8(GUILD_INVITE_S);
        data << uint8(0);
        data << uint8(C_R_DONT_HAVE_PERMISSION);
		return;
	}

	recv_data >> rankname;

	pGuild->CreateRank(rankname,GR_RIGHT_GCHATLISTEN | GR_RIGHT_GCHATSPEAK);

	pGuild->FillQueryData(&data);
	pGuild->SendMessageToGuild(NULL, &data, G_MSGTYPE_ALL);
	
	data.clear();
	//Maybe theres an event for this
	pGuild->FillGuildRosterData(&data);
	pGuild->SendMessageToGuild(NULL, &data, G_MSGTYPE_ALL);

    pGuild->SaveRanksToDb();
}

void WorldSession::HandleGuildDelRank(WorldPacket & recv_data)
{
	WorldPacket data;
	Guild *pGuild;
	
	pGuild = objmgr.GetGuild(GetPlayer()->GetGuildId());	
    if(!pGuild)
	{
		data.Initialize(SMSG_GUILD_COMMAND_RESULT);
        data << uint8(GUILD_CREATE_S);
        data << uint8(0);
        data << uint8(C_R_NOT_IN_GUILD);
		return;
	}
	
	if(GetPlayer()->GetGUID() != pGuild->GetGuildLeaderGuid())
	{
		data.Initialize(SMSG_GUILD_COMMAND_RESULT);
        data << uint8(GUILD_INVITE_S);
        data << uint8(0);
        data << uint8(C_R_DONT_HAVE_PERMISSION);
		return;
	}

	pGuild->DelRank();

	pGuild->FillQueryData(&data);
	pGuild->SendMessageToGuild(NULL, &data, G_MSGTYPE_ALL);
	data.clear();

	//Maybe theres an event for this
	pGuild->FillGuildRosterData(&data);
	pGuild->SendMessageToGuild(NULL, &data, G_MSGTYPE_ALL);

    pGuild->SaveRanksToDb();
}

void WorldSession::HandleGuildSetPublicNote(WorldPacket & recv_data)
{
    WorldPacket data;
	std::string TargetsName;
    std::string publicNote;

	recv_data >> TargetsName;
    recv_data >> publicNote;

	Player *pPlayer = GetPlayer();
    
	if(!pPlayer)
        return;

    Guild *pGuild = objmgr.GetGuild( pPlayer->GetGuildId() );

    if(!pGuild)
        return;

	guildMembers *pGuildMember = pGuild->GetGuildMember(TargetsName);

	if(!pGuildMember)
	{
		data.Initialize(SMSG_GUILD_COMMAND_RESULT);
        data << uint8(0x0C); // cmd quit?
        data << TargetsName.c_str();
        data << uint8(0x0A); // <name> is not in your guild.
        SendPacket(&data);
        return;
	}

    uint32 plyrRank = pPlayer->GetGuildRank();

	if(!pGuild->HasRankRight(plyrRank,GR_RIGHT_EPNOTE))
    {
        data.Initialize(SMSG_GUILD_COMMAND_RESULT);
        data << uint8(0x03);
        data << uint8(0);
        data << uint8(0x08);//guild permissions
        SendPacket(&data);
        return;
    }

    pGuild->SetPublicNote(pGuildMember->memberGuid, publicNote);

	//Save new Info to DB
	pGuild->UpdateGuildMembersDB(pGuildMember);

	//Send Update (this seems to be how blizz does it couldn't find an event for it)
	pGuild->FillGuildRosterData(&data);
	pGuild->SendMessageToGuild(NULL, &data, G_MSGTYPE_ALL);
}

void WorldSession::HandleGuildSetOfficerNote(WorldPacket & recv_data)
{
    WorldPacket data;
	std::string TargetsName;
    std::string officerNote;

	recv_data >> TargetsName;
    recv_data >> officerNote;

	Player *pPlayer = GetPlayer();
    
	if(!pPlayer)
        return;

    Guild *pGuild = objmgr.GetGuild( pPlayer->GetGuildId() );

    if(!pGuild)
        return;

	guildMembers *pGuildMember = pGuild->GetGuildMember(TargetsName);

	if(!pGuildMember)
	{
		data.Initialize(SMSG_GUILD_COMMAND_RESULT);
        data << uint8(0x0C); // cmd quit?
        data << TargetsName.c_str();
        data << uint8(0x0A); // <name> is not in your guild.
        SendPacket(&data);
        return;
	}

    uint32 plyrRank = pPlayer->GetGuildRank();

    if(!pGuild->HasRankRight(plyrRank,GR_RIGHT_EOFFNOTE))
    {
        data.Initialize(SMSG_GUILD_COMMAND_RESULT);
        data << uint8(0x03);
        data << uint8(0);
        data << uint8(0x08);//guild permissions
        SendPacket(&data);
        return;
    }

    pGuild->SetOfficerNote(pGuildMember->memberGuid, officerNote);

	//Save new Info to DB
	pGuild->UpdateGuildMembersDB(pGuildMember);

	//Send Update (this seems to be how blizz does it couldn't find an event for it)
	pGuild->FillGuildRosterData(&data);
	pGuild->SendMessageToGuild(NULL, &data, G_MSGTYPE_ALL);
}

void WorldSession::HandleSaveGuildEmblem(WorldPacket & recv_data)
{
	WorldPacket data;

    Guild *pGuild = objmgr.GetGuild( GetPlayer()->GetGuildId() );
    
    if(!pGuild)
	{
		data.Initialize(MSG_SAVE_GUILD_EMBLEM);
		data <<	uint32(ERR_GUILDEMBLEM_NOGUILD);
		SendPacket(&data);
        return;
	}

	Player *plyr = GetPlayer();
	
	if(!plyr)
		return;

	if(plyr->GetGuildRank() != GUILDRANK_GUILD_MASTER)
	{
		data.Initialize(MSG_SAVE_GUILD_EMBLEM);
		data <<	uint32(ERR_GUILDEMBLEM_NOTGUILDMASTER);
		SendPacket(&data);
        return;
	}
	uint32 Money = plyr->GetUInt32Value(PLAYER_FIELD_COINAGE);
	uint32 Cost = 100000; //10 Gold
	if(Money < Cost)
	{
		data.Initialize(MSG_SAVE_GUILD_EMBLEM);
		data <<	uint32(ERR_GUILDEMBLEM_NOTENOUGHMONEY);
		SendPacket(&data);
        return;
	}
	plyr->SetUInt32Value(PLAYER_FIELD_COINAGE,(Money-Cost));

	uint64 DesignerGuid;
	recv_data >> DesignerGuid;
	
	uint32 emblemPart;
	recv_data >> emblemPart;
	pGuild->SetGuildEmblemStyle( emblemPart );
	recv_data >> emblemPart;
	pGuild->SetGuildEmblemColor( emblemPart );
	recv_data >> emblemPart;
	pGuild->SetGuildBorderStyle( emblemPart );
	recv_data >> emblemPart;
	pGuild->SetGuildBorderColor( emblemPart );
	recv_data >> emblemPart;
	pGuild->SetGuildBackgroundColor( emblemPart );

	data.Initialize(MSG_SAVE_GUILD_EMBLEM);
	data <<	uint32(ERR_GUILDEMBLEM_SUCCESS);
	SendPacket(&data);

	data.clear();
	pGuild->FillQueryData(&data);
	pGuild->SendMessageToGuild(plyr->GetGUID(), &data, G_MSGTYPE_ALL);

	//data.Initialize(SMSG_GUILD_EVENT);
    //data << uint8(GUILD_EVENT_TABARDCHANGE);
    //data << uint8(0x00);
	//data << pGuild->GetGuildMotd();
	//pGuild->SendMessageToGuild(NULL, &data, G_MSGTYPE_ALL);
	
    pGuild->UpdateGuildToDb();
}

// Petition part
void WorldSession::HandlePetitionBuy(WorldPacket & recv_data)
{
 /*   Opcode: CMSG_PETITION_BUY (0x01BD)
    guid npc
    uint32 unk 0
    uint32 unk 0
    uint32 unk 0
    string guild name
    uint32 unk 0
    uint32 unk 0
    uint32 unk 0
    uint32 unk 0
    uint32 unk 0
    uint32 unk 0
    uint32 unk 0
    uint32 unk 0
    uint32 unk 0
    uint32 unk 0
    uint32 unk 0
    uint32 unk 0
    uint32 unk 1*/
    uint8 slot;
    uint32 npcGuid;
    uint32 temp;
    uint32 unk;
    uint32 itemGuid;
    std::string guildName;

    WorldPacket data;
    recv_data >> npcGuid;
    recv_data >> unk;
    recv_data >> temp;
    recv_data >> temp;
    recv_data >> temp;
    recv_data >> guildName;

    Player *plyr = GetPlayer();
    
    if(!plyr)
        return;

    //Dont buy secondtime
    if(plyr->GetSlotByItemID(5863) != 0)
    {
   /*     data.Initialize( SMSG_BUY_FAILED );
		data << uint64(srcguid);
		data << uint32(itemid);
		data << uint8(2); //not enough money
		SendPacket( &data );*/
        return;
    }

    if((slot = plyr->FindFreeInvSlot()) == INVENTORY_NO_SLOT_AVAILABLE)
    {
		plyr->BuildInventoryChangeError(NULL, NULL, INV_ERR_INVENTORY_FULL);
        return;
    }

    itemGuid = objmgr.GenerateLowGuid(HIGHGUID_ITEM);
    Item *item = new Item();
	item->Create(itemGuid, 5863, plyr);
	item->SetUInt32Value(OBJECT_FIELD_TYPE, 3);
	item->SetUInt32Value(ITEM_FIELD_FLAGS, 0x00000001);
	item->SetUInt32Value(ITEM_FIELD_ENCHANTMENT, 11040);
	item->SetUInt32Value(ITEM_FIELD_PROPERTY_SEED, 760411200);
	plyr->AddItemToSlot( slot, item );
    
    guildCharter *gc = new guildCharter;
    gc->itemGuid = itemGuid;
    gc->guildName = guildName;
    gc->leaderGuid = plyr->GetGUID();
    gc->signCount = 0;
    objmgr.AddCharter(gc);
    plyr->SetCharterSigned();

    //Money 10 silver
    uint32 curMoney = 0;
    curMoney = plyr->GetUInt32Value(PLAYER_FIELD_COINAGE);
    curMoney = curMoney - 1000;
    plyr->SetUInt32Value(PLAYER_FIELD_COINAGE, curMoney);
    
    data.Initialize( SMSG_BUY_ITEM );
	data << uint64(npcGuid);
	data << uint32(1) << uint32(0xFFFFFFFD);
    SendPacket(&data);
}

void WorldSession::HandlePetitionShowSignatures(WorldPacket & recv_data)
{
/*    Opcode: CMSG_PETITION_SHOW_SIGNATURES (0x01BE)
    guid item

    Opcode: SMSG_PETITION_SHOW_SIGNATURES (0x01BF)
    guid item
    uint64 player guid
    uint32 Used for wdb (GuildLow)
    uint8 0*/

    WorldPacket data;
    uint64 itemGuid;

    recv_data >> itemGuid;

    Player *plyr = GetPlayer();

    if(!plyr)
        return;

    guildCharter *gc = objmgr.GetGuildCharterByCharterGuid( GUID_LOPART(itemGuid) );
    
    if(!gc)
    {
        sLog.outDebug("Charter Error");
        return;
    }

    data.Initialize(SMSG_PETITION_SHOW_SIGNATURES);
    data << itemGuid;
    data << plyr->GetGUID();
    data << uint32(GUID_LOPART(itemGuid));
    data << gc->signCount;// signer count
    std::list<charterName>::iterator i;
    for(i = gc->signList.begin(); i != gc->signList.end(); i++)
    {
        if(i->signer != 0)
        {
            data << i->signer;
            data << uint32(1);//unk
        }
    }
    SendPacket(&data);
}

void WorldSession::HandlePetitionQuery(WorldPacket & recv_data)
{
 /*   Opcode: CMSG_PETITION_QUERY (0x01C6)
    uint32 20 2B 00 00 unk3 //maybe item thing
    guid item?

    Opcode: SMSG_PETITION_QUERY_RESPONSE
    uint32 20 2B 00 00 unk3
    guid player // does he signed answer
    string guild name
    uint8 0
    uint32 1
    uint32 9
    uint32 9
    9 * uint32 0
    2 * uint8 0*/
    WorldPacket data;
    uint64 itemGuid;
    uint32 charterId;
    int i = 0;

    recv_data >> charterId;
    recv_data >> itemGuid;

    Player *plyr = GetPlayer();

    if(!plyr)
        return;

    guildCharter *gc = objmgr.GetGuildCharterByCharterGuid( GUID_LOPART(itemGuid) );
    
    if(!gc)
    {
        sLog.outDebug("Charter Error");
        return;
    }

/*
[!] SERVER->CLIENT pkt 0x01C7 [len 0x0053]
OFFSET  00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F | 0123456789ABCDEF
--------------------------------------------------------------------------
000010  2C 27 01 00 AB 97 3C 00 00 00 00 00 42 72 69 6E   ,'....<.....Brin  
000020  67 65 72 73 20 6F 66 20 41 6E 61 72 63 68 79 00   gers of Anarchy.  
000030  00 01 00 00 00 09 00 00 00 09 00 00 00 00 00 00   ................  
000040  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00   ................  
000050  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00   ................  
000060  00 00 00                                          ...  
*/
    data.Initialize( SMSG_PETITION_QUERY_RESPONSE );
    data << uint32(charterId);
    data << gc->leaderGuid;
    data << gc->guildName;
    data << uint8(0);
    data << uint32(1);//request signature and sign button
    data << uint32(9);
	data << uint32(9);
    for(i=0;i < 9;i++)
        data << uint32(0);
    data << uint8(0);
    data << uint8(0);
    SendPacket(&data);
}

void WorldSession::HandlePetitionOffer( WorldPacket & recv_data )
{
/*
    Opcode: CMSG_OFFER_PETITION (0x01C3)
    guid 1 item
    guid 2 target

	[!] CLIENT->SERVER pkt 0x01C3 [len 0x0010]
	OFFSET  00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F | 0123456789ABCDEF
	--------------------------------------------------------------------------
	000010  B4 A2 11 4A ED 02 00 40 7C 4F 05 01 00 00 00 00   ...J...@|O...... 
*/
/*
    Opcode: MSG_PETITION_DECLINE (0x01C2)
    guid 2 target

	[!] SERVER->CLIENT pkt 0x01C2 [len 0x0008]
	OFFSET  00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F | 0123456789ABCDEF
	--------------------------------------------------------------------------
	000010  7C 4F 05 01 00 00 00 00                           |O...... 
*/
/*
    Opcode: SMSG_PETITION_SIGN_RESULTS (0x01C1)
    guid 1 item
    guid 3 target
    uint32 0

	[!] SERVER->CLIENT pkt 0x01C1 [len 0x0014]
	OFFSET  00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F | 0123456789ABCDEF
	--------------------------------------------------------------------------
	000010  B4 A2 11 4A ED 02 00 40 7D 4F 05 01 00 00 00 00   ...J...@}O......  
	000020  00 00 00 00                                       .... 
*/

    WorldPacket data;
    uint64 itemGuid;
    uint64 targetGuid;
    //change this to 2B20 to prevent sign from same machine

    recv_data >> itemGuid;
    recv_data >> targetGuid;

    Player *plyr = GetPlayer();

    if(!plyr)
        return;

    Player *pTarget = objmgr.GetPlayer( targetGuid );

    if(!pTarget)
        return;

    //TODO: Add alliance-horde check here!

    guildCharter *gc = objmgr.GetGuildCharterByCharterGuid( GUID_LOPART(itemGuid) );
    if(!gc)
    {
        sLog.outDebug("Charter Error");
        return;
    }

    data.Initialize(SMSG_PETITION_SHOW_SIGNATURES);
    data << itemGuid;
    data << plyr->GetGUID();
    data << uint32(GUID_LOPART(itemGuid));
    data << gc->signCount;// signer count
    std::list<charterName>::iterator i;
    for(i = gc->signList.begin(); i != gc->signList.end(); i++)
    {
        if(i->signer != 0)
        {
            data << i->signer;
            data << uint32(1);
        }
    }
    pTarget->GetSession()->SendPacket( &data );
}

void WorldSession::HandlePetitionSign( WorldPacket & recv_data )
{
  /*  Opcode: CMSG_PETITION_SIGN (0x01C0)
    item guid
    uint8 1

    Opcode: SMSG_PETITION_SIGN_RESULTS (0x01C1)
    item guid
    target guid yeah target guid
    uint32 0*/

    WorldPacket data;
    uint64 itemGuid;
    uint8 unk;

    recv_data >> itemGuid;
    recv_data >> unk;

    Player *plyr = GetPlayer();

    if(!plyr)
        return;
   
    guildCharter *gc = objmgr.GetGuildCharterByCharterGuid( GUID_LOPART(itemGuid) );
    if(!gc)
    {
        sLog.outDebug("Charter Error");
        return;
    }

    Player *pLeader = objmgr.GetPlayer( gc->leaderGuid );

    if(!pLeader)
        return;

    plyr->SetCharterSigned();
    plyr->AddSignedCharter(GUID_LOPART(itemGuid));

    charterName *cn = new charterName;

    cn->signer = plyr->GetGUID();
    gc->signList.push_back(*cn);
    gc->signCount++;

    data.Initialize(SMSG_PETITION_SIGN_RESULTS);
    data << itemGuid;
    data << plyr->GetGUID();
    data << uint32(0);
    SendPacket( &data );
    pLeader->GetSession()->SendPacket( &data );
}

void WorldSession::HandlePetitionTurnInPetition(WorldPacket & recv_data)
{
/*    Opcode: CMSG_TURN_IN_PETITION (0x01C4)
    guid item

    Opcode: SMSG_TURN_IN_PETITION_RESULTS (0x01C5)
    unk uint32 4*/
    WorldPacket data;
    uint64 itemGuid;
    uint32 guildId = 0;

    Player *plyr = GetPlayer();
    if(!plyr)
        return;

    recv_data >> itemGuid;

    guildCharter *gc = objmgr.GetGuildCharterByCharterGuid( GUID_LOPART(itemGuid) );

    if(!gc)
    {
        sLog.outDebug("Charter I64FMT doesn't exist", itemGuid);
        return;
    }

    if(plyr->GetGUID() != gc->leaderGuid)
    {
        data.Initialize(SMSG_TURN_IN_PETITION_RESULTS);
        data << uint32(ERR_PETITION_CREATOR);
        SendPacket( &data );
        return;

		/*
		data.Initialize(SMSG_GUILD_COMMAND_RESULT);
        data << uint32(0);
        data << gc->guildName;
        data << uint32(C_R_DONT_HAVE_PERMISSION);
        SendPacket(&data);
        return;
		*/
    }

    if(gc->signCount != 9)
    {
        data.Initialize(SMSG_TURN_IN_PETITION_RESULTS);
        data << uint32(ERR_PETITION_NOT_ENOUGH_SIGNATURES);
        SendPacket( &data );
        return;
    }

    if(plyr->IsInGuild())
    {
        data.Initialize(SMSG_TURN_IN_PETITION_RESULTS);
        data << uint32(ERR_PETITION_IN_GUILD);
        SendPacket( &data );
        return;
    }

    if(objmgr.GetGuildByGuildName(gc->guildName))
    {
        data.Initialize(SMSG_GUILD_COMMAND_RESULT);
        data << uint32(0);
        data << gc->guildName;
        data << uint32(C_R_GUILD_NAME_EXISTS);
        SendPacket(&data);
        return;
    }

    // dont know hacky or not but only solution for now
    // If everything is fine create guild

	Guild *pGuild = new Guild;

    guildId = pGuild->GetFreeGuildIdFromDb();

	if(guildId == 0)
	{
		printf("Error Getting Free Guild ID");
		delete pGuild;
		return;
	}

	//Guild Setup
	pGuild->SetGuildId( guildId );
	pGuild->SetGuildName( gc->guildName );
    pGuild->CreateRank("Guild Master", GR_RIGHT_ALL);
    pGuild->CreateRank("Officer", GR_RIGHT_ALL);
    pGuild->CreateRank("Veteran", GR_RIGHT_GCHATLISTEN | GR_RIGHT_GCHATSPEAK);  
    pGuild->CreateRank("Member", GR_RIGHT_GCHATLISTEN | GR_RIGHT_GCHATSPEAK);
    pGuild->CreateRank("Initiate", GR_RIGHT_GCHATLISTEN | GR_RIGHT_GCHATSPEAK);
	pGuild->SetGuildEmblemStyle( 0xFFFF );
    pGuild->SetGuildEmblemColor( 0xFFFF );
    pGuild->SetGuildBorderStyle( 0xFFFF );
    pGuild->SetGuildBorderColor( 0xFFFF );
	pGuild->SetGuildBackgroundColor( 0xFFFF );

    objmgr.AddGuild(pGuild);
	
	//Guild Leader Setup
	plyr->SetGuildId( pGuild->GetGuildId() );
	plyr->SetUInt32Value(PLAYER_GUILDID, pGuild->GetGuildId() );
    plyr->SetGuildRank(GUILDRANK_GUILD_MASTER);
    plyr->SetUInt32Value(PLAYER_GUILDRANK,GUILDRANK_GUILD_MASTER);
	pGuild->SetGuildLeaderGuid( plyr->GetGUID() );

    pGuild->AddNewGuildMember( plyr );

	//Other Guild Members Setup
    Player *pMember;
    std::list<charterName>::iterator i;
    for(i = gc->signList.begin(); i != gc->signList.end(); i++)
    {
        pMember = objmgr.GetPlayer(i->signer);
        if(pMember)
        {
	        pMember->SetGuildId( pGuild->GetGuildId() );
	        pMember->SetUInt32Value(PLAYER_GUILDID, pGuild->GetGuildId() );
            pMember->SetGuildRank(GUILDRANK_MEMBER);
            pMember->SetUInt32Value(PLAYER_GUILDRANK,GUILDRANK_MEMBER);

            pGuild->AddNewGuildMember( pMember );

            //Charters
            pMember->DeleteFromSignedCharters( gc->itemGuid );
            pMember->DeleteAllCharterData();

			pMember->SaveGuild();

        }
        else
        {
            pMember = new Player();
            pMember->LoadFromDB(uint32(i->signer));
	        
            pMember->SetGuildId( pGuild->GetGuildId() );
	        pMember->SetUInt32Value(PLAYER_GUILDID, pGuild->GetGuildId() );
            pMember->SetGuildRank(GUILDRANK_MEMBER);
            pMember->SetUInt32Value(PLAYER_GUILDRANK,GUILDRANK_MEMBER);

            pGuild->AddNewGuildMember( pMember );

            //Charters
            pMember->DeleteFromSignedCharters( gc->itemGuid );
            pMember->DeleteAllCharterData();

            pMember->SaveGuild();
            //pMember->SaveCharters();

            delete pMember;
        }
    }    

    //We finished with charter
    objmgr.DeleteCharter(plyr->GetGUID());
    plyr->DeleteFromSignedCharters(0);
    plyr->DeleteAllCharterData();
    //Deleting Charter from inventory
    uint8 charterslot = 0;
    charterslot = uint8(plyr->GetSlotByItemID(5863));
    Item *item = plyr->RemoveItemFromSlot(charterslot);
    item->DeleteFromDB();
    //we deleted item so we dont want character corrupted!
    plyr->SaveToDB();

    pGuild->SaveToDb();
    pGuild->SaveRanksToDb();

    data.Initialize(SMSG_TURN_IN_PETITION_RESULTS);
    data << uint32(0);
    SendPacket( &data );

/*    data.clear();
    data.Initialize(SMSG_GUILD_COMMAND_RESULT);
    data << uint32(0);
    data << gc->guildName;
    data << uint32(C_R_CREATED);
    SendPacket(&data);    */

}

void WorldSession::HandlePetitionRename(WorldPacket & recv_data)
{
    /*MSG_PETITION_RENAME
    guid item
    string guildname*/

    WorldPacket data;
    uint64 itemGuid;
    std::string newGuildName;
    int i = 0;

    Player *plyr = GetPlayer();

    if(!plyr)
        return;

    recv_data >> itemGuid;
    recv_data >> newGuildName;

	guildCharter *gc = objmgr.GetGuildCharterByCharterGuid( GUID_LOPART(itemGuid) );

    if(!gc)
    {
        sLog.outDebug("Charter Error");
        return;
    }

    gc->guildName = newGuildName;

    data.Initialize( SMSG_PETITION_QUERY_RESPONSE );
    data << uint32(GUID_LOPART(itemGuid));
    data << gc->leaderGuid;
    data << gc->guildName;
    data << uint8(0);
    data << uint32(1);//request signature and sign button
    data << uint32(9);
    data << uint32(9);
    for(i=0;i < 9;i++)
        data << uint32(0);
    data << uint8(0);
    data << uint8(0);
    SendPacket(&data);

    data.clear();
    data.Initialize(MSG_PETITION_RENAME);
    data << itemGuid;
    data << newGuildName;
    SendPacket(&data);
}

