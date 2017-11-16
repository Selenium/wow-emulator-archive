namespace Server.Network
{
    using System;

    public sealed class SetArrow : Packet
    {
        // Methods
        public SetArrow(int x, int y) : base(186, 6)
        {
            this.m_Stream.Write(((byte) 1));
            this.m_Stream.Write(((short) x));
            this.m_Stream.Write(((short) y));
        }

    }
}

