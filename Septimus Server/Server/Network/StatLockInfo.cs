namespace Server.Network
{
    using Server;
    using System;

    public sealed class StatLockInfo : Packet
    {
        // Methods
        public StatLockInfo(Mobile m) : base(191)
        {
            base.EnsureCapacity(12);
            this.m_Stream.Write(((short) 25));
            this.m_Stream.Write(((byte) 2));
            this.m_Stream.Write(Serial.op_Implicit(m.Serial));
            this.m_Stream.Write(((byte) 0));
            int num1 = 0;
            num1 |= (m.StrLock << ((StatLockType) 4));
            num1 |= (m.DexLock << StatLockType.Locked);
            num1 |= m.IntLock;
            this.m_Stream.Write(((byte) num1));
        }

    }
}

