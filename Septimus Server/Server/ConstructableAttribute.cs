namespace Server
{
    using System;

    [AttributeUsage(AttributeTargets.Constructor)]
    public class ConstructableAttribute : Attribute
    {
        // Methods
        public ConstructableAttribute()
        {
        }

    }
}

