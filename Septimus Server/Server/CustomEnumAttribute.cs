namespace Server
{
    using System;

    [AttributeUsage((AttributeTargets.Enum | (AttributeTargets.Struct | AttributeTargets.Class)))]
    public class CustomEnumAttribute : Attribute
    {
        // Methods
        public CustomEnumAttribute(string[] names)
        {
            this.m_Names = names;
        }


        // Properties
        public string[] Names
        {
            get
            {
                return this.m_Names;
            }
        }


        // Fields
        private string[] m_Names;
    }
}

