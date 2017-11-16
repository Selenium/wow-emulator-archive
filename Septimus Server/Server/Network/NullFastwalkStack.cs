namespace Server.Network
{
    using System;

    public sealed class NullFastwalkStack : Packet
    {
        // Methods
        public NullFastwalkStack() : base(191)
        {
            base.EnsureCapacity(256);
            this.m_Stream.Write(((short) 1));
            this.m_Stream.Write(0);
            this.m_Stream.Write(0);
            this.m_Stream.Write(0);
            this.m_Stream.Write(0);
            this.m_Stream.Write(0);
            this.m_Stream.Write(0);
        }

    }
}

