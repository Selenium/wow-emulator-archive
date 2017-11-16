namespace Server
{
    using System;

    public class TimedSkillMod : SkillMod
    {
        // Methods
        public TimedSkillMod(SkillName skill, bool relative, double value, DateTime expire) : base(skill, relative, value)
        {
            this.m_Expire = expire;
        }

        public TimedSkillMod(SkillName skill, bool relative, double value, TimeSpan delay) : this(skill, relative, value, (DateTime.Now + delay))
        {
        }

        public override bool CheckCondition()
        {
            return (DateTime.Now < this.m_Expire);
        }


        // Fields
        private DateTime m_Expire;
    }
}

