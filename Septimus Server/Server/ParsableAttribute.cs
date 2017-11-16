namespace Server
{
    using System;

    [AttributeUsage((AttributeTargets.Struct | AttributeTargets.Class))]
    public class ParsableAttribute : Attribute
    {
        // Methods
        public ParsableAttribute()
        {
        }

    }
}

