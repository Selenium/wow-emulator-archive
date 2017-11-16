namespace Server
{
    using System;

    [Flags]
    public enum ItemDelta
    {
        // Fields
        EquipOnly = 2,
        None = 0,
        Properties = 4,
        Update = 1
    }
}

