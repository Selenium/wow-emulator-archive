namespace Server.Network
{
    using Server;
    using Server.Items;
    using System;

    public sealed class CloseSecureTrade : Packet
    {
        // Methods
        public CloseSecureTrade(Container cont) : base(111)
        {
            base.EnsureCapacity(8);
            this.m_Stream.Write(((byte) 1));
            this.m_Stream.Write(Serial.op_Implicit(cont.Serial));
        }

    }
}

