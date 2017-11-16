namespace Server
{
    using System;

    [Flags]
    public enum MapRules
    {
        // Fields
        BeneficialRestrictions = 4,
        FeluccaRules = 0,
        FreeMovement = 2,
        HarmfulRestrictions = 8,
        Internal = 1,
        None = 0,
        TrammelRules = 14
    }
}

