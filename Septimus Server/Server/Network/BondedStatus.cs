namespace Server.Network
{
    using Server;
    using System;

    public sealed class BondedStatus : Packet
    {
        // Methods
        public BondedStatus(int val1, Serial serial, int val2) : base(191)
        {
            base.EnsureCapacity(11);
            this.m_Stream.Write(((short) 25));
            this.m_Stream.Write(((byte) val1));
            this.m_Stream.Write(Serial.op_Implicit(serial));
            this.m_Stream.Write(((byte) val2));
        }

    }
}

