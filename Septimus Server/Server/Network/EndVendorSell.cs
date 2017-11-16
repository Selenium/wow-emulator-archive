namespace Server.Network
{
    using Server;
    using System;

    public sealed class EndVendorSell : Packet
    {
        // Methods
        public EndVendorSell(Mobile Vendor) : base(59, 8)
        {
            this.m_Stream.Write(((ushort) 8));
            this.m_Stream.Write(Serial.op_Implicit(Vendor.Serial));
            this.m_Stream.Write(((byte) 0));
        }

    }
}

