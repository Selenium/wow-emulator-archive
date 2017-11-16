namespace Server
{
    using System;

    public class PaperdollRequestEventArgs : EventArgs
    {
        // Methods
        public PaperdollRequestEventArgs(Mobile beholder, Mobile beheld)
        {
            this.m_Beholder = beholder;
            this.m_Beheld = beheld;
        }


        // Properties
        public Mobile Beheld
        {
            get
            {
                return this.m_Beheld;
            }
        }

        public Mobile Beholder
        {
            get
            {
                return this.m_Beholder;
            }
        }


        // Fields
        private Mobile m_Beheld;
        private Mobile m_Beholder;
    }
}

