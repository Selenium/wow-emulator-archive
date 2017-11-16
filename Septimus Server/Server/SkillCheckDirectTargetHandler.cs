namespace Server
{
    using System;
    using System.Runtime.CompilerServices;

    public delegate bool SkillCheckDirectTargetHandler(Mobile from, SkillName skill, object target, double chance);

}

