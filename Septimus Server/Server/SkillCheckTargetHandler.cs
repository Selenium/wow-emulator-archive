namespace Server
{
    using System;
    using System.Runtime.CompilerServices;

    public delegate bool SkillCheckTargetHandler(Mobile from, SkillName skill, object target, double minSkill, double maxSkill);

}

