namespace Server.Network
{
    using Server;
    using System;

    public sealed class DisplayPaperdoll : Packet
    {
        // Methods
        public DisplayPaperdoll(Mobile m, string text) : base(136, 66)
        {
            this.m_Stream.Write(Serial.op_Implicit(m.Serial));
            this.m_Stream.WriteAsciiFixed(text, 60);
            this.m_Stream.Write(((byte) (m.Warmode ? 1 : 0)));
        }

    }
}

