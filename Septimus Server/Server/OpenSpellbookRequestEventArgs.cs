namespace Server
{
    using System;

    public class OpenSpellbookRequestEventArgs : EventArgs
    {
        // Methods
        public OpenSpellbookRequestEventArgs(Mobile m, int type)
        {
            this.m_Mobile = m;
            this.m_Type = type;
        }


        // Properties
        public Mobile Mobile
        {
            get
            {
                return this.m_Mobile;
            }
        }

        public int Type
        {
            get
            {
                return this.m_Type;
            }
        }


        // Fields
        private Mobile m_Mobile;
        private int m_Type;
    }
}

