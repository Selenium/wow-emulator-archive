namespace Server
{
    using System;

    public enum ApplyPoisonResult
    {
        // Fields
        Cured = 3,
        HigherPoisonActive = 2,
        Immune = 1,
        Poisoned = 0
    }
}

