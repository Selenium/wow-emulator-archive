namespace Server
{
    using System;

    public class SetAbilityEventArgs : EventArgs
    {
        // Methods
        public SetAbilityEventArgs(Mobile mobile, int index)
        {
            this.m_Mobile = mobile;
            this.m_Index = index;
        }


        // Properties
        public int Index
        {
            get
            {
                return this.m_Index;
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
        private int m_Index;
        private Mobile m_Mobile;
    }
}

