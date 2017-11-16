namespace Server.Network
{
    using Server;
    using System;

    public sealed class DisplaySpellbook : Packet
    {
        // Methods
        public DisplaySpellbook(Item book) : base(36, 7)
        {
            this.m_Stream.Write(Serial.op_Implicit(book.Serial));
            this.m_Stream.Write(((short) -1));
        }

    }
}

