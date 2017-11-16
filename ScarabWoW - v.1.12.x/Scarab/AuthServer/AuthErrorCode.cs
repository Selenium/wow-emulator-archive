namespace AuthServer
{
    using System;

    public enum AuthErrorCode
    {
        LOGIN_ALREADYONLINE = 6,
        LOGIN_BADVERSION = 9,
        LOGIN_BANNED = 3,
        LOGIN_DBBUSY = 8,
        LOGIN_DOWNLOADFILE = 10,
        LOGIN_FAILED = 1,
        LOGIN_NOTIME = 7,
        LOGIN_OK = 0,
        LOGIN_PARENTALCONTROL = 15,
        LOGIN_UNKNOWN_ACCOUNT = 4,
        REALM_LIST_FAILED = 0x24,
        REALM_LIST_INVALID = 0x25,
        REALM_LIST_REALM_NOT_FOUND = 0x26,
        REALM_LIST_RECIEVING = 0x22,
        REALM_LIST_SUCCESS = 0x23
    }
}

