namespace Server.Network
{
    using Server;
    using System;

    public sealed class MobileAnimation : Packet
    {
        // Methods
        public MobileAnimation(Mobile m, int action, int frameCount, int repeatCount, bool forward, bool repeat, int delay) : base(110, 14)
        {
            this.m_Stream.Write(Serial.op_Implicit(m.Serial));
            this.m_Stream.Write(((short) action));
            this.m_Stream.Write(((short) frameCount));
            this.m_Stream.Write(((short) repeatCount));
            this.m_Stream.Write(!forward);
            this.m_Stream.Write(repeat);
            this.m_Stream.Write(((byte) delay));
        }

    }
}

