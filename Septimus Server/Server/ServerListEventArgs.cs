namespace Server
{
    using Server.Accounting;
    using Server.Network;
    using System;
    using System.Collections;
    using System.Net;

    public class ServerListEventArgs : EventArgs
    {
        // Methods
        public ServerListEventArgs(NetState state, IAccount account)
        {
            this.m_State = state;
            this.m_Account = account;
            this.m_Servers = new ArrayList();
        }

        public void AddServer(string name, IPEndPoint address)
        {
            this.AddServer(name, 0, TimeZone.CurrentTimeZone, address);
        }

        public void AddServer(string name, int fullPercent, TimeZone tz, IPEndPoint address)
        {
            this.m_Servers.Add(new ServerInfo(name, fullPercent, tz, address));
        }


        // Properties
        public IAccount Account
        {
            get
            {
                return this.m_Account;
            }
        }

        public bool Rejected
        {
            get
            {
                return this.m_Rejected;
            }
            set
            {
                this.m_Rejected = value;
            }
        }

        public ArrayList Servers
        {
            get
            {
                return this.m_Servers;
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
        private IAccount m_Account;
        private bool m_Rejected;
        private ArrayList m_Servers;
        private NetState m_State;
    }
}

