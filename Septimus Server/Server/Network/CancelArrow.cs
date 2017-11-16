namespace Server.Network
{
    using System;

    public sealed class CancelArrow : Packet
    {
        // Methods
        public CancelArrow() : base(186, 6)
        {
            this.m_Stream.Write(((byte) 0));
            this.m_Stream.Write(((short) -1));
            this.m_Stream.Write(((short) -1));
        }

    }
}

