namespace Server.Network
{
    using Server;
    using System;

    public sealed class ServerChange : Packet
    {
        // Methods
        public ServerChange(Mobile m, Map map) : base(118, 16)
        {
            this.m_Stream.Write(((short) m.X));
            this.m_Stream.Write(((short) m.Y));
            this.m_Stream.Write(((short) m.Z));
            this.m_Stream.Write(((byte) 0));
            this.m_Stream.Write(((short) 0));
            this.m_Stream.Write(((short) 0));
            this.m_Stream.Write(((short) map.Width));
            this.m_Stream.Write(((short) map.Height));
        }

    }
}

