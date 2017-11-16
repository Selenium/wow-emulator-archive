namespace Server.Network
{
    using System;

    public sealed class ClientVersionReq : Packet
    {
        // Methods
        public ClientVersionReq() : base(189)
        {
            base.EnsureCapacity(3);
        }

    }
}

