namespace Server
{
    using System;

    public class StatMod
    {
        // Methods
        public StatMod(StatType type, string name, int offset, TimeSpan duration)
        {
            this.m_Type = type;
            this.m_Name = name;
            this.m_Offset = offset;
            this.m_Duration = duration;
            this.m_Added = DateTime.Now;
        }

        public bool HasElapsed()
        {
            if (this.m_Duration == TimeSpan.Zero)
            {
                return false;
            }
            return ((DateTime.Now - this.m_Added) >= this.m_Duration);
        }


        // Properties
        public string Name
        {
            get
            {
                return this.m_Name;
            }
        }

        public int Offset
        {
            get
            {
                return this.m_Offset;
            }
        }

        public StatType Type
        {
            get
            {
                return this.m_Type;
            }
        }


        // Fields
        private DateTime m_Added;
        private TimeSpan m_Duration;
        private string m_Name;
        private int m_Offset;
        private StatType m_Type;
    }
}

