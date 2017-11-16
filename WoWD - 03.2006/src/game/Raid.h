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

#ifndef WOWSERVER_RAID_H
#define WOWSERVER_RAID_H

#define MAXRAIDSIZE 40

#include "Chat.h"

struct SubRaidMembers
{
    uint64 memberGuid;
    std::string name;
};

struct RaidGroup
{
    uint8 subGroupMemberCount;
    uint64 subGroupLeaderGuid;
    std::list<SubRaidMembers*> subGroup;
};

class Raid
{
public:
    Raid();
    ~Raid();

    RaidGroup GetRaidGroup(uint8 slot) { return m_raid[slot]; }
    void AddMember(uint64 guid, const char* name, uint8 subGroup);
    void AddMember(uint64 guid, const char* name);
    uint32 RemoveMember(const uint64 &guid);

    void ChangeLeader(const uint64 &guid);
    void ChangeSubGroupLeader(const uint64 &guid, uint8 subGroup);
    void ChangeMemberSubGroup(const uint64 &guid, uint8 subGroup);
    //void AddSubGroupLeader(const uin64 &guid);

    bool IsFull() const { return m_count == MAXRAIDSIZE; }

    void SendUpdate();
    void SendNullUpdate(uint64 guid);
    void Disband();

    const uint64& GetRaidLeaderGUID() const { return m_raidLeaderGuid; }
    void SetRaidLeaderGuid(uint64 leaderGuid) { m_raidLeaderGuid = leaderGuid; }
    void SetRaidLeaderName(const char *leaderName) { m_raidLeaderName = leaderName; }

    void SetLootMethod(uint32 method) { m_lootMethod = method; }
    void SetLooterGuid(const uint64 &guid) { m_looterGuid = guid; }
    uint32 GetLootMethod() const { return m_lootMethod; }
    const uint64 & GetLooterGuid() const { return m_looterGuid; }

    uint32 GetMembersCount() const { return m_count; }

    // XP
    void GiveXPToRaid(uint32 xp, const uint64 &victimguid);

	// raid chat implementation
	void BroadcastToRaid(WorldSession *session, std::string msg);

protected:

    RaidGroup m_raid[8];
   
    uint64 m_raidLeaderGuid;
    std::string m_raidLeaderName;

    uint32 m_count;
    uint8 m_grouptype;

    uint32 m_lootMethod;
    uint64 m_looterGuid;
};



#endif
