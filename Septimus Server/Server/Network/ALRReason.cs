namespace Server.Network
{
    using System;

    public enum ALRReason
    {
        // Fields
        BadComm = -1,
        BadPass = 3,
        Blocked = 2,
        Idle = -2,
        InUse = 1,
        Invalid = 0
    }
}

