namespace Server.Network
{
    using System;

    public sealed class GQCount : Packet
    {
        // Methods
        public GQCount(int unk, int count) : base(203, 7)
        {
            this.m_Stream.Write(((short) unk));
            this.m_Stream.Write(count);
        }

    }
}

