namespace Server.Network
{
    using Server;
    using Server.Items;
    using System;

    public sealed class UpdateSecureTrade : Packet
    {
        // Methods
        public UpdateSecureTrade(Container cont, bool first, bool second) : base(111)
        {
            base.EnsureCapacity(8);
            this.m_Stream.Write(((byte) 2));
            this.m_Stream.Write(Serial.op_Implicit(cont.Serial));
            this.m_Stream.Write((first ? 1 : 0));
            this.m_Stream.Write((second ? 1 : 0));
        }

    }
}

