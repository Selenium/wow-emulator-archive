namespace Server.Network
{
    using Server.Gumps;
    using System;
    using System.Collections;
    using System.IO;
    using System.Text;

    public sealed class DisplayGumpFast : Packet
    {
        // Methods
        static DisplayGumpFast()
        {
            DisplayGumpFast.m_Buffer = new byte[48];
            DisplayGumpFast.m_Buffer[0] = 32;
        }

        public DisplayGumpFast(Gump g) : base(176)
        {
            this.m_True = Gump.StringToBuffer(" 1");
            this.m_False = Gump.StringToBuffer(" 0");
            base.EnsureCapacity(1024);
            this.m_Stream.Write(g.Serial);
            this.m_Stream.Write(g.TypeID);
            this.m_Stream.Write(g.X);
            this.m_Stream.Write(g.Y);
            this.m_Stream.Write(((ushort) 65535));
        }

        public void AppendLayout(bool val)
        {
            this.AppendLayout((val ? this.m_True : this.m_False));
        }

        public void AppendLayout(int val)
        {
            string text1 = val.ToString();
            int num1 = (Encoding.ASCII.GetBytes(text1, 0, text1.Length, DisplayGumpFast.m_Buffer, 1) + 1);
            this.m_Stream.Write(DisplayGumpFast.m_Buffer, 0, num1);
            this.m_LayoutLength += num1;
        }

        public void AppendLayout(byte[] buffer)
        {
            int num1 = buffer.Length;
            this.m_Stream.Write(buffer, 0, num1);
            this.m_LayoutLength += num1;
        }

        public void AppendLayoutNS(int val)
        {
            string text1 = val.ToString();
            int num1 = Encoding.ASCII.GetBytes(text1, 0, text1.Length, DisplayGumpFast.m_Buffer, 1);
            this.m_Stream.Write(DisplayGumpFast.m_Buffer, 1, num1);
            this.m_LayoutLength += num1;
        }

        public void WriteText(ArrayList text)
        {
            int num1;
            string text1;
            int num2;
            this.m_Stream.Seek(19, SeekOrigin.Begin);
            this.m_Stream.Write(((ushort) this.m_LayoutLength));
            this.m_Stream.Seek(0, SeekOrigin.End);
            this.m_Stream.Write(((ushort) text.Count));
            for (num1 = 0; (num1 < text.Count); ++num1)
            {
                text1 = ((string) text[num1]);
                if (text1 == null)
                {
                    text1 = "";
                }
                num2 = ((ushort) text1.Length);
                this.m_Stream.Write(((ushort) num2));
                this.m_Stream.WriteBigUniFixed(text1, num2);
            }
        }


        // Fields
        private static byte[] m_Buffer;
        private byte[] m_False;
        private int m_LayoutLength;
        private byte[] m_True;
    }
}

