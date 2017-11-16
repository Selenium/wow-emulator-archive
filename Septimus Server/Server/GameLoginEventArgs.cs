namespace Server
{
    using Server.Network;
    using System;

    public class GameLoginEventArgs : EventArgs
    {
        // Methods
        public GameLoginEventArgs(NetState state, string un, string pw)
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

        public CityInfo[] CityInfo
        {
            get
            {
                return this.m_CityInfo;
            }
            set
            {
                this.m_CityInfo = value;
            }
        }

        public string Password
        {
            get
            {
                return this.m_Password;
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
        private CityInfo[] m_CityInfo;
        private string m_Password;
        private NetState m_State;
        private string m_Username;
    }
}

