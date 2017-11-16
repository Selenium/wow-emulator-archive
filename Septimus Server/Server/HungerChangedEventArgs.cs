namespace Server
{
    using System;

    public class HungerChangedEventArgs : EventArgs
    {
        // Methods
        public HungerChangedEventArgs(Mobile mobile, int oldValue)
        {
            this.m_Mobile = mobile;
            this.m_OldValue = oldValue;
        }


        // Properties
        public Mobile Mobile
        {
            get
            {
                return this.m_Mobile;
            }
        }

        public int OldValue
        {
            get
            {
                return this.m_OldValue;
            }
        }


        // Fields
        private Mobile m_Mobile;
        private int m_OldValue;
    }
}

