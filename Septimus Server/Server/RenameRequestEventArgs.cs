namespace Server
{
    using System;

    public class RenameRequestEventArgs : EventArgs
    {
        // Methods
        public RenameRequestEventArgs(Mobile from, Mobile target, string name)
        {
            this.m_From = from;
            this.m_Target = target;
            this.m_Name = name;
        }


        // Properties
        public Mobile From
        {
            get
            {
                return this.m_From;
            }
        }

        public string Name
        {
            get
            {
                return this.m_Name;
            }
        }

        public Mobile Target
        {
            get
            {
                return this.m_Target;
            }
        }


        // Fields
        private Mobile m_From;
        private string m_Name;
        private Mobile m_Target;
    }
}

