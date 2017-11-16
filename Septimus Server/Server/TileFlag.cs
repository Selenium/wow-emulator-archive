namespace Server
{
    using System;

    [Flags]
    public enum TileFlag
    {
        // Fields
        Animation = 16777216,
        Armor = 134217728,
        ArticleA = 16384,
        ArticleAn = 32768,
        Background = 1,
        Bridge = 1024,
        Container = 2097152,
        Damaging = 32,
        Door = 536870912,
        Foliage = 131072,
        Generic = 2048,
        Impassable = 64,
        Internal = 65536,
        LightSource = 8388608,
        Map = 1048576,
        NoDiagonal = 33554432,
        None = 0,
        NoShoot = 8192,
        PartialHue = 262144,
        Roof = 268435456,
        StairBack = 1073741824,
        StairRight = -2147483648,
        Surface = 512,
        Translucent = 8,
        Transparent = 4,
        Unknown1 = 256,
        Unknown2 = 524288,
        Unknown3 = 67108864,
        Wall = 16,
        Weapon = 2,
        Wearable = 4194304,
        Wet = 128,
        Window = 4096
    }
}

