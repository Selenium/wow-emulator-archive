namespace Server.Network
{
    using System;

    public enum DeleteResultType
    {
        // Fields
        BadRequest = 5,
        CharBeingPlayed = 2,
        CharNotExist = 1,
        CharQueued = 4,
        CharTooYoung = 3,
        PasswordInvalid = 0
    }
}

