namespace WorldServer
{
    using System;

    internal enum ChatMsgType
    {
        AFK = 20,
        CHANNEL = 14,
        CHANNEL_JOIN = 15,
        CHANNEL_LEAVE = 0x10,
        CHANNEL_LIST = 0x11,
        CHANNEL_NOTICE = 0x12,
        CHANNEL_NOTICE_USER = 0x13,
        DND = 0x15,
        EMOTE = 8,
        GUILD = 3,
        IGNORED = 0x16,
        LOOT = 0x18,
        MONSTER_EMOTE = 13,
        MONSTER_SAY = 11,
        MONSTER_YELL = 12,
        OFFICER = 4,
        PARTY = 1,
        RAID = 2,
        RAID_LEADER = 0x57,
        RAID_WARN = 0x58,
        SAY = 0,
        SKILL = 0x17,
        SYSTEM = 10,
        TEXT_EMOTE = 9,
        WHISPER = 6,
        WHISPER_INFORM = 7,
        YELL = 5
    }
}

