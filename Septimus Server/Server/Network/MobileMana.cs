namespace Server.Network
{
    using Server;
    using System;

    public sealed class MobileMana : Packet
    {
        // Methods
        public MobileMana(Mobile m) : base(162, 9)
        {
            this.m_Stream.Write(Serial.op_Implicit(m.Serial));
            this.m_Stream.Write(((short) m.ManaMax));
            this.m_Stream.Write(((short) m.Mana));
        }

    }
}

