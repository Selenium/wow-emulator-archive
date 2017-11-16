namespace Server
{
    using Server.Network;
    using System;

    public class FastWalkEventArgs
    {
        // Methods
        public FastWalkEventArgs(NetState state)
        {
            this.m_State = state;
            this.m_Blocked = false;
        }


        // Properties
        public bool Blocked
        {
            get
            {
                return this.m_Blocked;
            }
            set
            {
                this.m_Blocked = value;
            }
        }

        public NetState NetState
        {
            get
            {
                return this.m_State;
            }
        }


        // Fields
        private bool m_Blocked;
        private NetState m_State;
    }
}

