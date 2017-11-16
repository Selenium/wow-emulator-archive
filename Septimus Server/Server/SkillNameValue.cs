namespace Server
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct SkillNameValue
    {
        // Methods
        public SkillNameValue(SkillName name, int value)
        {
            this.m_Name = name;
            this.m_Value = value;
        }


        // Properties
        public SkillName Name
        {
            get
            {
                return this.m_Name;
            }
        }

        public int Value
        {
            get
            {
                return this.m_Value;
            }
        }


        // Fields
        private SkillName m_Name;
        private int m_Value;
    }
}

