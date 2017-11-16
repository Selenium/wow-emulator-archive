namespace AuthServer
{
    using System;

    public enum AuthOpCode : byte
    {
        AUTH_LOGON_CHALLENGE = 0,
        AUTH_LOGON_PROOF = 1,
        AUTH_RECONNECT_CHALLENGE = 2,
        AUTH_RECONNECT_PROOF = 3,
        REALM_LIST = 0x10,
        XFER_ACCEPT = 50,
        XFER_CANCEL = 0x34,
        XFER_DATA = 0x31,
        XFER_INITIATE = 0x30,
        XFER_RESUME = 0x33
    }
}

