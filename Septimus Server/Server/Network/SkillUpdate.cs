namespace Server.Network
{
    using Server;
    using System;

    public sealed class SkillUpdate : Packet
    {
        // Methods
        public SkillUpdate(Skills skills) : base(58)
        {
            int num1;
            Skill skill1;
            double num2;
            int num3;
            base.EnsureCapacity((6 + (skills.Length * 9)));
            this.m_Stream.Write(((byte) 2));
            for (num1 = 0; (num1 < skills.Length); ++num1)
            {
                skill1 = skills[num1];
                num2 = skill1.Value;
                num3 = ((int) (num2 * 10));
                if (num3 < 0)
                {
                    num3 = 0;
                }
                else if (num3 >= 65536)
                {
                    num3 = 65535;
                }
                this.m_Stream.Write(((ushort) (skill1.Info.SkillID + 1)));
                this.m_Stream.Write(((ushort) num3));
                this.m_Stream.Write(((ushort) skill1.BaseFixedPoint));
                this.m_Stream.Write(((byte) skill1.Lock));
                this.m_Stream.Write(((ushort) skill1.CapFixedPoint));
            }
            this.m_Stream.Write(((short) 0));
        }

    }
}

