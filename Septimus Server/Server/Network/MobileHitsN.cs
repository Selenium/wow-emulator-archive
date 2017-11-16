namespace Server.Network
{
    using Server;
    using System;

    public sealed class MobileHitsN : Packet
    {
        // Methods
        public MobileHitsN(Mobile m) : base(161, 9)
        {
            this.m_Stream.Write(Serial.op_Implicit(m.Serial));
            AttributeNormalizer.Write(this.m_Stream, m.Hits, m.HitsMax);
        }

    }
}

