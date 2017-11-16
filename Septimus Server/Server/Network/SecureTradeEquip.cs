namespace Server.Network
{
    using Server;
    using System;

    public sealed class SecureTradeEquip : Packet
    {
        // Methods
        public SecureTradeEquip(Item item, Mobile m) : base(37, 20)
        {
            this.m_Stream.Write(Serial.op_Implicit(item.Serial));
            this.m_Stream.Write(((short) item.ItemID));
            this.m_Stream.Write(((byte) 0));
            this.m_Stream.Write(((short) item.Amount));
            this.m_Stream.Write(((short) item.X));
            this.m_Stream.Write(((short) item.Y));
            this.m_Stream.Write(Serial.op_Implicit(m.Serial));
            this.m_Stream.Write(((short) item.Hue));
        }

    }
}

