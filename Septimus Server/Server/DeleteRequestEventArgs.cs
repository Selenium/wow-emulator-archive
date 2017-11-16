namespace Server
{
    using Server.Network;
    using System;

    public class DeleteRequestEventArgs : EventArgs
    {
        // Methods
        public DeleteRequestEventArgs(NetState state, int index)
        {
            this.m_State = state;
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

        public NetState State
        {
            get
            {
                return this.m_State;
            }
        }


        // Fields
        private int m_Index;
        private NetState m_State;
    }
}

