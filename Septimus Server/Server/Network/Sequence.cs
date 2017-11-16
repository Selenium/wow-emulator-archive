namespace Server.Network
{
    using System;

    public sealed class Sequence : Packet
    {
        // Methods
        public Sequence(int num) : base(123, 2)
        {
            this.m_Stream.Write(((byte) num));
        }

    }
}

