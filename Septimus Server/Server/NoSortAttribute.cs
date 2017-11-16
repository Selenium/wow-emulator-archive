namespace Server
{
    using System;

    [AttributeUsage((AttributeTargets.Struct | AttributeTargets.Class))]
    public class NoSortAttribute : Attribute
    {
        // Methods
        public NoSortAttribute()
        {
        }

    }
}

