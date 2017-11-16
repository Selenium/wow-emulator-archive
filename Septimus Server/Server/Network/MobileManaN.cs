namespace Server.Network
{
    using Server;
    using System;

    public sealed class MobileManaN : Packet
    {
        // Methods
        public MobileManaN(Mobile m) : base(162, 9)
        {
            this.m_Stream.Write(Serial.op_Implicit(m.Serial));
            AttributeNormalizer.Write(this.m_Stream, m.Mana, m.ManaMax);
        }

    }
}

