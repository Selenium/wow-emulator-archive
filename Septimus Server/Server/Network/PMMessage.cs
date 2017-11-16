namespace Server.Network
{
    using System;

    public enum PMMessage
    {
        // Fields
        CharExists = 2,
        CharInWorld = 5,
        CharNoExist = 1,
        IdleWarning = 7,
        LoginSyncError = 6
    }
}

