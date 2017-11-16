namespace Server.Network
{
    using Server;
    using System;
    using System.IO;

    public sealed class SpellbookContent : Packet
    {
        // Methods
        public SpellbookContent(int count, int offset, ulong content, Item item) : base(60)
        {
            base.EnsureCapacity((5 + (count * 19)));
            int num1 = 0;
            this.m_Stream.Write(((ushort) 0));
            ulong num2 = 1;
            int num3 = 0;
            while ((num3 < 64))
            {
                if ((content & num2) != 0)
                {
                    this.m_Stream.Write(((int) (2147483647 - num3)));
                    this.m_Stream.Write(((ushort) 0));
                    this.m_Stream.Write(((byte) 0));
                    this.m_Stream.Write(((ushort) (num3 + offset)));
                    this.m_Stream.Write(((short) 0));
                    this.m_Stream.Write(((short) 0));
                    this.m_Stream.Write(Serial.op_Implicit(item.Serial));
                    this.m_Stream.Write(((short) 0));
                    ++num1;
                }
                ++num3;
                num2 = (num2 << 1);
            }
            this.m_Stream.Seek(3, SeekOrigin.Begin);
            this.m_Stream.Write(((ushort) num1));
        }

    }
}

