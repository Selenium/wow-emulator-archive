namespace Server
{
    using Server.Network;
    using System;

    public class AccountLoginEventArgs : EventArgs
    {
        // Methods
        public AccountLoginEventArgs(NetState state, string un, string pw)
        {
            this.m_State = state;
            this.m_Username = un;
            this.m_Password = pw;
        }


        // Properties
        public bool Accepted
        {
            get
            {
                return this.m_Accepted;
            }
            set
            {
                this.m_Accepted = value;
            }
        }

        public string Password
        {
            get
            {
                return this.m_Password;
            }
        }

        public ALRReason RejectReason
        {
            get
            {
                return this.m_RejectReason;
            }
            set
            {
                this.m_RejectReason = value;
            }
        }

        public NetState State
        {
            get
            {
                return this.m_State;
            }
        }

        public string Username
        {
            get
            {
                return this.m_Username;
            }
        }


        // Fields
        private bool m_Accepted;
        private string m_Password;
        private ALRReason m_RejectReason;
        private NetState m_State;
        private string m_Username;
    }
}

