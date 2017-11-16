// Copyright (C) 2004 WoWD Team

#ifndef WOWSERVER_GROUP_H
#define WOWSERVER_GROUP_H

#define MAXGROUPSIZE 5

class Group
{
public:
    Group()
    {
        m_count = 0;
        m_leaderGuid = 0;
        m_lootMethod = 0;
        m_looterGuid = 0;
        m_grouptype = 0;
    }

    ~Group()
    {
    }

    void Create(const uint64 &guid, const char * name)
    {
        AddMember(guid, name);

        m_leaderGuid = guid;
        m_leaderName = name;
    }

    void AddMember(uint64 guid, const char* name)
    {
        ASSERT(m_count < MAXGROUPSIZE-1);

        m_members[m_count].guid = guid;
        m_members[m_count].name = name;

        m_count++;
    }

    uint32 RemoveMember(const uint64 &guid);
    void ChangeLeader(const uint64 &guid);

    bool IsFull() const { return m_count == MAXGROUPSIZE; }

    void SendUpdate();
    void Disband();

    const uint64& GetLeaderGUID() const { return m_leaderGuid; }
//    const char* GetLeaderName() const { return m_leaderName.c_str(); }

    void SetLootMethod(uint32 method) { m_lootMethod = method; }
    void SetLooterGuid(const uint64 &guid) { m_looterGuid = guid; }

    uint32 GetLootMethod() const { return m_lootMethod; }
    const uint64 & GetLooterGuid() const { return m_looterGuid; }

    uint32 GetMembersCount() const { return m_count; }
    const uint64& GetMemberGUID(uint32 i) const { ASSERT(i < m_count); return m_members[i].guid; }

protected:

    typedef struct
    {
        std::string name;
        uint64 guid;
    } MemberSlot;

    MemberSlot m_members[MAXGROUPSIZE];

    uint64 m_leaderGuid;
    std::string m_leaderName;

    uint32 m_count;
    uint16 m_grouptype;

    uint32 m_lootMethod;
    uint64 m_looterGuid;
};



#endif
