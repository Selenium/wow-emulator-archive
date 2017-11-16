namespace Server
{
    using System;

    [Flags]
    public enum MobileDelta
    {
        // Fields
        Armor = 4096,
        Attributes = 28,
        Body = 2048,
        Direction = 512,
        Flags = 2,
        Followers = 32768,
        GhostUpdate = 16384,
        Gold = 128,
        Hits = 4,
        Hue = 1024,
        Mana = 8,
        Name = 1,
        None = 0,
        Noto = 64,
        Properties = 65536,
        Resistances = 262144,
        Stam = 16,
        Stat = 32,
        StatCap = 8192,
        TithingPoints = 131072,
        WeaponDamage = 524288,
        Weight = 256
    }
}

