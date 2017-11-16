namespace Server.Network
{
    using Server;
    using System;

    public sealed class NewSpellbookContent : Packet
    {
        // Methods
        public NewSpellbookContent(Item item, int graphic, int offset, ulong content) : base(191)
        {
            int num1;
            base.EnsureCapacity(23);
            this.m_Stream.Write(((short) 27));
            this.m_Stream.Write(((short) 1));
            this.m_Stream.Write(Serial.op_Implicit(item.Serial));
            this.m_Stream.Write(((short) graphic));
            this.m_Stream.Write(((short) offset));
            for (num1 = 0; (num1 < 8); ++num1)
            {
                this.m_Stream.Write(((byte) (content >> ((num1 * 8) & 63))));
            }
        }

    }
}

