namespace Server.Network
{
    using Server;
    using System;

    public sealed class MobileStamN : Packet
    {
        // Methods
        public MobileStamN(Mobile m) : base(163, 9)
        {
            this.m_Stream.Write(Serial.op_Implicit(m.Serial));
            AttributeNormalizer.Write(this.m_Stream, m.Stam, m.StamMax);
        }

    }
}

