namespace Server.Targeting
{
    using System;

    public enum TargetCancelType
    {
        // Fields
        Canceled = 1,
        Disconnected = 2,
        Overriden = 0,
        Timeout = 3
    }
}

