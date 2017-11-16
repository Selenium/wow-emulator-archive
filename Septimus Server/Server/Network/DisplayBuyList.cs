namespace Server.Network
{
    using Server;
    using System;

    public sealed class DisplayBuyList : Packet
    {
        // Methods
        public DisplayBuyList(Mobile vendor) : base(36, 7)
        {
            this.m_Stream.Write(Serial.op_Implicit(vendor.Serial));
            this.m_Stream.Write(((short) 48));
        }

    }
}

