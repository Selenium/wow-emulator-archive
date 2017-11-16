namespace Server
{
    using Server.Network;
    using System;

    public class OPLInfo : Packet
    {
        // Methods
        public OPLInfo(ObjectPropertyList list) : base(191)
        {
            base.EnsureCapacity(13);
            this.m_Stream.Write(((short) 16));
            this.m_Stream.Write(Serial.op_Implicit(list.Entity.Serial));
            this.m_Stream.Write(list.Hash);
        }

    }
}

