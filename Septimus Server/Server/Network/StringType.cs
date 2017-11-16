namespace Server.Network
{
    using System;

    [Flags]
    public enum StringType
    {
        // Fields
        AppendNull = 4,
        Ascii = 1,
        LittleEndian = 2,
        Unicode = 0
    }
}

