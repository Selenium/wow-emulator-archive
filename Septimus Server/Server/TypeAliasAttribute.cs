namespace Server
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class TypeAliasAttribute : Attribute
    {
        // Methods
        public TypeAliasAttribute(params string[] aliases)
        {
            this.m_Aliases = aliases;
        }


        // Properties
        public string[] Aliases
        {
            get
            {
                return this.m_Aliases;
            }
        }


        // Fields
        private string[] m_Aliases;
    }
}

