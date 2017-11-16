namespace Server.Network
{
    using Server;
    using System;

    public sealed class MessageLocalizedAffix : Packet
    {
        // Methods
        public MessageLocalizedAffix(Serial serial, int graphic, MessageType messageType, int hue, int font, int number, string name, AffixType affixType, string affix, string args) : base(204)
        {
            if (name == null)
            {
                name = "";
            }
            if (affix == null)
            {
                affix = "";
            }
            if (args == null)
            {
                args = "";
            }
            if (hue == 0)
            {
                hue = 946;
            }
            base.EnsureCapacity(((52 + affix.Length) + (args.Length * 2)));
            this.m_Stream.Write(Serial.op_Implicit(serial));
            this.m_Stream.Write(((short) graphic));
            this.m_Stream.Write(((byte) messageType));
            this.m_Stream.Write(((short) hue));
            this.m_Stream.Write(((short) font));
            this.m_Stream.Write(number);
            this.m_Stream.Write(((byte) affixType));
            this.m_Stream.WriteAsciiFixed(name, 30);
            this.m_Stream.WriteAsciiNull(affix);
            this.m_Stream.WriteBigUniNull(args);
        }

    }
}

