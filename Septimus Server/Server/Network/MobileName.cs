namespace Server.Network
{
    using Server;
    using System;

    public sealed class MobileName : Packet
    {
        // Methods
        public MobileName(Mobile m) : base(152)
        {
            string text1 = m.Name;
            if (text1 == null)
            {
                text1 = "";
            }
            base.EnsureCapacity(37);
            this.m_Stream.Write(Serial.op_Implicit(m.Serial));
            this.m_Stream.WriteAsciiFixed(text1, 30);
        }

    }
}

