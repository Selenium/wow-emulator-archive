namespace WorldServer
{
    using System;

    internal enum PlayerFlags
    {
        PLAYER_FLAGS_AFK = 2,
        PLAYER_FLAGS_DND = 4,
        PLAYER_FLAGS_GHOST = 0x10,
        PLAYER_FLAGS_GM = 8,
        PLAYER_FLAGS_GROUP_LEADER = 1,
        PLAYER_FLAGS_IN_PVP = 0x200,
        PLAYER_FLAGS_RESTING = 0x20,
        PLAYER_FLAGS_UNK = 0x1000,
        PLAYER_FLAGS_UNK2 = 0x2000
    }
}

