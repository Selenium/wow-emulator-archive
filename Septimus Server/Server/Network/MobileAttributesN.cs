namespace Server.Network
{
    using Server;
    using System;

    public sealed class MobileAttributesN : Packet
    {
        // Methods
        public MobileAttributesN(Mobile m) : base(45, 17)
        {
            this.m_Stream.Write(Serial.op_Implicit(m.Serial));
            AttributeNormalizer.Write(this.m_Stream, m.Hits, m.HitsMax);
            AttributeNormalizer.Write(this.m_Stream, m.Mana, m.ManaMax);
            AttributeNormalizer.Write(this.m_Stream, m.Stam, m.StamMax);
        }

    }
}

