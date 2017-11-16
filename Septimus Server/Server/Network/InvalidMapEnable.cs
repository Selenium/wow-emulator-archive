namespace Server.Network
{
    using System;

    public sealed class InvalidMapEnable : Packet
    {
        // Methods
        public InvalidMapEnable() : base(198, 1)
        {
        }

    }
}

