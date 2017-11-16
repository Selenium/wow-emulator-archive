namespace Server.Network
{
    using Server;
    using Server.Accounting;
    using System;

    public sealed class CharacterListUpdate : Packet
    {
        // Methods
        public CharacterListUpdate(IAccount a) : base(134)
        {
            int num2;
            int num3;
            Mobile mobile1;
            base.EnsureCapacity(304);
            int num1 = 0;
            for (num2 = 0; (num2 < 5); ++num2)
            {
                if (a[num2] != null)
                {
                    ++num1;
                }
            }
            this.m_Stream.Write(((byte) num1));
            for (num3 = 0; (num3 < 5); ++num3)
            {
                mobile1 = a[num3];
                if (mobile1 != null)
                {
                    this.m_Stream.WriteAsciiFixed(mobile1.Name, 30);
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

