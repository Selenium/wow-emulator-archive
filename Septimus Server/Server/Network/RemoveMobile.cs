namespace Server.Network
{
    using Server;
    using System;

    public sealed class RemoveMobile : Packet
    {
        // Methods
        public RemoveMobile(Mobile m) : base(29, 5)
        {
            this.m_Stream.Write(Serial.op_Implicit(m.Serial));
        }

    }
}

