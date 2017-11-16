namespace Server.Network
{
    using Server;
    using System;

    public sealed class RemoveItem : Packet
    {
        // Methods
        public RemoveItem(Item item) : base(29, 5)
        {
            this.m_Stream.Write(Serial.op_Implicit(item.Serial));
        }

    }
}

