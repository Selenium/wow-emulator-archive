namespace Server.Network
{
    using Server;
    using System;

    public sealed class UnicodeMessage : Packet
    {
        // Methods
        public UnicodeMessage(Serial serial, int graphic, MessageType type, int hue, int font, string lang, string name, string text) : base(174)
        {
            if ((lang == null) || (lang == ""))
            {
                lang = "ENU";
            }
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
            base.EnsureCapacity((50 + (text.Length * 2)));
            this.m_Stream.Write(Serial.op_Implicit(serial));
            this.m_Stream.Write(((short) graphic));
            this.m_Stream.Write(((byte) type));
            this.m_Stream.Write(((short) hue));
            this.m_Stream.Write(((short) font));
            this.m_Stream.WriteAsciiFixed(lang, 4);
            this.m_Stream.WriteAsciiFixed(name, 30);
            this.m_Stream.WriteBigUniNull(text);
        }

    }
}

