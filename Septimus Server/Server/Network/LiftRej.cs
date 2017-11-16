namespace Server.Network
{
    using System;

    public sealed class LiftRej : Packet
    {
        // Methods
        public LiftRej(LRReason reason) : base(39, 2)
        {
            this.m_Stream.Write(((byte) reason));
        }

    }
}

