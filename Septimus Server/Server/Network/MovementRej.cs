namespace Server.Network
{
    using Server;
    using System;

    public sealed class MovementRej : Packet
    {
        // Methods
        public MovementRej(int seq, Mobile m) : base(33, 8)
        {
            this.m_Stream.Write(((byte) seq));
            this.m_Stream.Write(((short) m.X));
            this.m_Stream.Write(((short) m.Y));
            this.m_Stream.Write(((byte) m.Direction));
            this.m_Stream.Write(((sbyte) m.Z));
        }

    }
}

