namespace Server.Network
{
    using Server;
    using System;

    public sealed class FollowMessage : Packet
    {
        // Methods
        public FollowMessage(Serial serial1, Serial serial2) : base(21, 9)
        {
            this.m_Stream.Write(Serial.op_Implicit(serial1));
            this.m_Stream.Write(Serial.op_Implicit(serial2));
        }

    }
}

