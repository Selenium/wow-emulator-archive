namespace Server.Network
{
    using Server;
    using Server.Items;
    using System;

    public sealed class DisplaySecureTrade : Packet
    {
        // Methods
        public DisplaySecureTrade(Mobile them, Container first, Container second, string name) : base(111)
        {
            if (name == null)
            {
                name = "";
            }
            base.EnsureCapacity((18 + name.Length));
            this.m_Stream.Write(((byte) 0));
            this.m_Stream.Write(Serial.op_Implicit(them.Serial));
            this.m_Stream.Write(Serial.op_Implicit(first.Serial));
            this.m_Stream.Write(Serial.op_Implicit(second.Serial));
            this.m_Stream.Write(true);
            this.m_Stream.WriteAsciiFixed(name, 30);
        }

    }
}

