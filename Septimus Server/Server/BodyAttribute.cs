namespace Server
{
    using System;

    [AttributeUsage(AttributeTargets.Property)]
    public class BodyAttribute : Attribute
    {
        // Methods
        public BodyAttribute()
        {
        }

    }
}

