namespace Server
{
    using System;

    [AttributeUsage(AttributeTargets.Property)]
    public class CommandPropertyAttribute : Attribute
    {
        // Methods
        public CommandPropertyAttribute(AccessLevel level) : this(level, level)
        {
        }

        public CommandPropertyAttribute(AccessLevel readLevel, AccessLevel writeLevel)
        {
            this.m_ReadLevel = readLevel;
            this.m_WriteLevel = writeLevel;
        }


        // Properties
        public AccessLevel ReadLevel
        {
            get
            {
                return this.m_ReadLevel;
            }
        }

        public AccessLevel WriteLevel
        {
            get
            {
                return this.m_WriteLevel;
            }
        }


        // Fields
        private AccessLevel m_ReadLevel;
        private AccessLevel m_WriteLevel;
    }
}

