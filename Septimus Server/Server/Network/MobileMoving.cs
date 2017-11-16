namespace Server.Network
{
    using Server;
    using System;

    public sealed class MobileMoving : Packet
    {
        // Methods
        public MobileMoving(Mobile m, int noto) : base(119, 17)
        {
            Point3D pointd1 = m.Location;
            int num1 = m.Hue;
            if (m.SolidHueOverride >= 0)
            {
                num1 = m.SolidHueOverride;
            }
            this.m_Stream.Write(Serial.op_Implicit(m.Serial));
            this.m_Stream.Write(((short) Body.op_Implicit(m.Body)));
            this.m_Stream.Write(((short) pointd1.m_X));
            this.m_Stream.Write(((short) pointd1.m_Y));
            this.m_Stream.Write(((sbyte) pointd1.m_Z));
            this.m_Stream.Write(((byte) m.Direction));
            this.m_Stream.Write(((short) num1));
            this.m_Stream.Write(((byte) m.GetPacketFlags()));
            this.m_Stream.Write(((byte) noto));
        }

    }
}

