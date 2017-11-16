namespace Server.Network
{
    using Server;
    using System;

    public sealed class SkillChange : Packet
    {
        // Methods
        public SkillChange(Skill skill) : base(58)
        {
            base.EnsureCapacity(13);
            double num1 = skill.Value;
            int num2 = ((int) (num1 * 10));
            if (num2 < 0)
            {
                num2 = 0;
            }
            else if (num2 >= 65536)
            {
                num2 = 65535;
            }
            this.m_Stream.Write(((byte) 223));
            this.m_Stream.Write(((ushort) skill.Info.SkillID));
            this.m_Stream.Write(((ushort) num2));
            this.m_Stream.Write(((ushort) skill.BaseFixedPoint));
            this.m_Stream.Write(((byte) skill.Lock));
            this.m_Stream.Write(((ushort) skill.CapFixedPoint));
        }

    }
}

