namespace Server
{
    using System;

    public class LoginEventArgs : EventArgs
    {
        // Methods
        public LoginEventArgs(Mobile mobile)
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

