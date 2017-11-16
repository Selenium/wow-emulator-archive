namespace Server.Network
{
    using Server;
    using System;

    public sealed class MobileUpdate : Packet
    {
        // Methods
        public MobileUpdate(Mobile m) : base(32, 19)
        {
            int num1 = m.Hue;
            if (m.SolidHueOverride >= 0)
            {
                num1 = m.SolidHueOverride;
            }
            this.m_Stream.Write(Serial.op_Implicit(m.Serial));
            this.m_Stream.Write(((short) Body.op_Implicit(m.Body)));
            this.m_Stream.Write(((byte) 0));
            this.m_Stream.Write(((short) num1));
            this.m_Stream.Write(((byte) m.GetPacketFlags()));
            this.m_Stream.Write(((short) m.X));
            this.m_Stream.Write(((short) m.Y));
            this.m_Stream.Write(((short) 0));
            this.m_Stream.Write(((byte) m.Direction));
            this.m_Stream.Write(((sbyte) m.Z));
        }

    }
}

