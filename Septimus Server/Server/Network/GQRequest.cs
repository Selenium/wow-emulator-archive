namespace Server.Network
{
    using System;

    public sealed class GQRequest : Packet
    {
        // Methods
        public GQRequest() : base(195)
        {
            base.EnsureCapacity(256);
            this.m_Stream.Write(1);
            this.m_Stream.Write(2);
            this.m_Stream.Write(3);
            this.m_Stream.Write(4);
            this.m_Stream.Write(0);
            this.m_Stream.Write(((short) 0));
            this.m_Stream.Write(((short) 6));
            this.m_Stream.Write(((byte) 114));
            this.m_Stream.Write(((byte) 101));
            this.m_Stream.Write(((byte) 103));
            this.m_Stream.Write(((byte) 105));
            this.m_Stream.Write(((byte) 111));
            this.m_Stream.Write(((byte) 110));
            this.m_Stream.Write(7);
            this.m_Stream.Write(((short) 2));
            this.m_Stream.Write(8);
            this.m_Stream.Write(9);
            this.m_Stream.Write(10);
            this.m_Stream.Write(11);
            this.m_Stream.Write(12);
            this.m_Stream.Write(-1);
            this.m_Stream.Write(1);
        }

    }
}

