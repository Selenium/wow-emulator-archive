namespace Server.Network
{
    using System;
    using System.Net;

    public sealed class ServerInfo
    {
        // Methods
        public ServerInfo(string name, int fullPercent, TimeZone tz, IPEndPoint address)
        {
            this.m_Name = name;
            this.m_FullPercent = fullPercent;
            TimeSpan span1 = tz.GetUtcOffset(DateTime.Now);
            this.m_TimeZone = span1.Hours;
            this.m_Address = address;
        }


        // Properties
        public IPEndPoint Address
        {
            get
            {
                return this.m_Address;
            }
            set
            {
                this.m_Address = value;
            }
        }

        public int FullPercent
        {
            get
            {
                return this.m_FullPercent;
            }
            set
            {
                this.m_FullPercent = value;
            }
        }

        public string Name
        {
            get
            {
                return this.m_Name;
            }
            set
            {
                this.m_Name = value;
            }
        }

        public int TimeZone
        {
            get
            {
                return this.m_TimeZone;
            }
            set
            {
                this.m_TimeZone = value;
            }
        }


        // Fields
        private IPEndPoint m_Address;
        private int m_FullPercent;
        private string m_Name;
        private int m_TimeZone;
    }
}

