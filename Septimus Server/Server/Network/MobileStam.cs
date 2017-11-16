namespace Server.Network
{
    using Server;
    using System;

    public sealed class MobileStam : Packet
    {
        // Methods
        public MobileStam(Mobile m) : base(163, 9)
        {
            this.m_Stream.Write(Serial.op_Implicit(m.Serial));
            this.m_Stream.Write(((short) m.StamMax));
            this.m_Stream.Write(((short) m.Stam));
        }

    }
}

