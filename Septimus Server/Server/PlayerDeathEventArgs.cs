namespace Server
{
    using System;

    public class PlayerDeathEventArgs : EventArgs
    {
        // Methods
        public PlayerDeathEventArgs(Mobile mobile)
        {
            this.m_Mobile = mobile;
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

