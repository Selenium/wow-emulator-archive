namespace Server.Network
{
    using Server.Accounting;
    using System;

    public sealed class ChangeCharacter : Packet
    {
        // Methods
        public ChangeCharacter(IAccount a) : base(129)
        {
            int num2;
            int num3;
            string text1;
            base.EnsureCapacity(305);
            int num1 = 0;
            for (num2 = 0; (num2 < 5); ++num2)
            {
                if (a[num2] != null)
                {
                    ++num1;
                }
            }
            this.m_Stream.Write(((byte) num1));
            this.m_Stream.Write(((byte) 0));
            for (num3 = 0; (num3 < 5); ++num3)
            {
                if (a[num3] != null)
                {
                    text1 = a[num3].Name;
                    if (text1 == null)
                    {
                        text1 = "-null-";
                    }
                    else if ((text1 = text1.Trim()).Length == 0)
                    {
                        text1 = "-empty-";
                    }
                    this.m_Stream.WriteAsciiFixed(text1, 30);
                    this.m_Stream.Fill(30);
                }
                else
                {
                    this.m_Stream.Fill(60);
                }
            }
        }

    }
}

