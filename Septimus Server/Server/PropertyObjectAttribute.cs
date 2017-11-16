namespace Server
{
    using System;

    [AttributeUsage((AttributeTargets.Struct | AttributeTargets.Class))]
    public class PropertyObjectAttribute : Attribute
    {
        // Methods
        public PropertyObjectAttribute()
        {
        }

    }
}

