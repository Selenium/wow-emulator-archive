namespace Server.Network
{
    using Server;
    using System;

    public sealed class DamagePacket : Packet
    {
        // Methods
        public DamagePacket(Mobile m, int amount) : base(191)
        {
            base.EnsureCapacity(11);
            this.m_Stream.Write(((short) 34));
            this.m_Stream.Write(((byte) 1));
            this.m_Stream.Write(Serial.op_Implicit(m.Serial));
            if (amount > 255)
            {
                amount = 255;
            }
            else if (amount < 0)
            {
                amount = 0;
            }
            this.m_Stream.Write(((byte) amount));
        }

    }
}

