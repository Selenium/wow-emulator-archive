namespace WorldServer
{
    using System;

    public enum CHARRESULT
    {
        CREATE_FAILED = 0x30,
        CREATE_MAX_PLAYER_REALM = 0x34,
        CREATE_NAME_IN_USE = 0x31,
        CREATE_NOT_SAME_SIDE = 0x33,
        CREATE_OK = 0x2e,
        DELETE_FAIL = 0x36,
        DELETE_OK = 0x39
    }
}

