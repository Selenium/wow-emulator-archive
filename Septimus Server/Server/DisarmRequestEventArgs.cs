namespace Server
{
    using System;

    public class DisarmRequestEventArgs : EventArgs
    {
        // Methods
        public DisarmRequestEventArgs(Mobile m)
        {
            this.m_Mobile = m;
        }


        // Properties
        public Mobile Mobile
        {
            get
            {
                return this.m_Mobile;
            }
        }


        // Fields
        private Mobile m_Mobile;
    }
}

