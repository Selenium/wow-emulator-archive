namespace Server
{
    using System;

    public class AnimateRequestEventArgs : EventArgs
    {
        // Methods
        public AnimateRequestEventArgs(Mobile m, string action)
        {
            this.m_Mobile = m;
            this.m_Action = action;
        }


        // Properties
        public string Action
        {
            get
            {
                return this.m_Action;
            }
        }

        public Mobile Mobile
        {
            get
            {
                return this.m_Mobile;
            }
        }


        // Fields
        private string m_Action;
        private Mobile m_Mobile;
    }
}

