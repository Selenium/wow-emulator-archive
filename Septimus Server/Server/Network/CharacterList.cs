namespace Server.Network
{
    using Server;
    using Server.Accounting;
    using System;

    public sealed class CharacterList : Packet
    {
        // Methods
        public CharacterList(IAccount a, CityInfo[] info) : base(169)
        {
            int num2;
            int num3;
            int num4;
            CityInfo info1;
            base.EnsureCapacity((309 + (info.Length * 63)));
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
                if (a[num3] != null)
                {
                    this.m_Stream.WriteAsciiFixed(a[num3].Name, 30);
                    this.m_Stream.Fill(30);
                }
                else
                {
                    this.m_Stream.Fill(60);
                }
            }
            this.m_Stream.Write(((byte) info.Length));
            for (num4 = 0; (num4 < info.Length); ++num4)
            {
                info1 = info[num4];
                this.m_Stream.Write(((byte) num4));
                this.m_Stream.WriteAsciiFixed(info1.City, 31);
                this.m_Stream.WriteAsciiFixed(info1.Building, 31);
            }
            this.m_Stream.Write(((int) ((Core.AOS ? 40 : 8) | CharacterList.m_AdditionalFlags)));
        }


        // Properties
        public static int AdditionalFlags
        {
            get
            {
                return CharacterList.m_AdditionalFlags;
            }
            set
            {
                CharacterList.m_AdditionalFlags = value;
            }
        }


        // Fields
        private static int m_AdditionalFlags;
    }
}

