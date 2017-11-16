namespace Server.Network
{
    using Server;
    using System;

    public sealed class MobileHits : Packet
    {
        // Methods
        public MobileHits(Mobile m) : base(161, 9)
        {
            this.m_Stream.Write(Serial.op_Implicit(m.Serial));
            this.m_Stream.Write(((short) m.HitsMax));
            this.m_Stream.Write(((short) m.Hits));
        }

    }
}

