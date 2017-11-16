namespace Server.Network
{
    using Server;
    using System;

    public sealed class AsciiMessage : Packet
    {
        // Methods
        public AsciiMessage(Serial serial, int graphic, MessageType type, int hue, int font, string name, string text) : base(28)
        {
            if (name == null)
            {
                name = "";
            }
            if (text == null)
            {
                text = "";
            }
            if (hue == 0)
            {
                hue = 946;
            }
            base.EnsureCapacity((45 + text.Length));
            this.m_Stream.Write(Serial.op_Implicit(serial));
            this.m_Stream.Write(((short) graphic));
            this.m_Stream.Write(((byte) type));
            this.m_Stream.Write(((short) hue));
            this.m_Stream.Write(((short) font));
            this.m_Stream.WriteAsciiFixed(name, 30);
            this.m_Stream.WriteAsciiNull(text);
        }

    }
}

