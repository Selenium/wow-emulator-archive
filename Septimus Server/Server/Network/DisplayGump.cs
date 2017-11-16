namespace Server.Network
{
    using Server.Gumps;
    using System;

    public sealed class DisplayGump : Packet
    {
        // Methods
        public DisplayGump(Gump g, string layout, string[] text) : base(176)
        {
            int num1;
            string text1;
            int num2;
            if (layout == null)
            {
                layout = "";
            }
            base.EnsureCapacity(256);
            this.m_Stream.Write(g.Serial);
            this.m_Stream.Write(g.TypeID);
            this.m_Stream.Write(g.X);
            this.m_Stream.Write(g.Y);
            this.m_Stream.Write(((ushort) (layout.Length + 1)));
            this.m_Stream.WriteAsciiNull(layout);
            this.m_Stream.Write(((ushort) text.Length));
            for (num1 = 0; (num1 < text.Length); ++num1)
            {
                text1 = text[num1];
                if (text1 == null)
                {
                    text1 = "";
                }
                num2 = ((ushort) text1.Length);
                this.m_Stream.Write(((ushort) num2));
                this.m_Stream.WriteBigUniFixed(text1, num2);
            }
        }

    }
}

