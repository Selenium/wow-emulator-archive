namespace Server
{
    using System;

    public class DefaultSkillMod : SkillMod
    {
        // Methods
        public DefaultSkillMod(SkillName skill, bool relative, double value) : base(skill, relative, value)
        {
        }

        public override bool CheckCondition()
        {
            return true;
        }

    }
}

