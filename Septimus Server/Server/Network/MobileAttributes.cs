namespace Server.Network
{
    using Server;
    using System;

    public sealed class MobileAttributes : Packet
    {
        // Methods
        public MobileAttributes(Mobile m) : base(45, 17)
        {
            this.m_Stream.Write(Serial.op_Implicit(m.Serial));
            this.m_Stream.Write(((short) m.HitsMax));
            this.m_Stream.Write(((short) m.Hits));
            this.m_Stream.Write(((short) m.ManaMax));
            this.m_Stream.Write(((short) m.Mana));
            this.m_Stream.Write(((short) m.StamMax));
            this.m_Stream.Write(((short) m.Stam));
        }

    }
}

