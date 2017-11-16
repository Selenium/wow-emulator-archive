namespace Server.Network
{
    using System;

    public sealed class ScrollMessage : Packet
    {
        // Methods
        public ScrollMessage(int type, int tip, string text) : base(166)
        {
            if (text == null)
            {
                text = "";
            }
            base.EnsureCapacity((10 + text.Length));
            this.m_Stream.Write(((byte) type));
            this.m_Stream.Write(tip);
            this.m_Stream.Write(((ushort) text.Length));
            this.m_Stream.WriteAsciiFixed(text, text.Length);
        }

    }
}

