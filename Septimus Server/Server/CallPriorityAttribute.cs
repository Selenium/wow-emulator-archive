namespace Server
{
    using System;

    [AttributeUsage(AttributeTargets.Method)]
    public class CallPriorityAttribute : Attribute
    {
        // Methods
        public CallPriorityAttribute(int priority)
        {
            this.m_Priority = priority;
        }


        // Properties
        public int Priority
        {
            get
            {
                return this.m_Priority;
            }
            set
            {
                this.m_Priority = value;
            }
        }


        // Fields
        private int m_Priority;
    }
}

