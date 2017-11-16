namespace Server
{
    using Server.Items;
    using System;

    public class SecureTradeInfo
    {
        // Methods
        public SecureTradeInfo(SecureTrade owner, Mobile m, SecureTradeContainer c)
        {
            this.m_Owner = owner;
            this.m_Mobile = m;
            this.m_Container = c;
            this.m_Mobile.AddItem(this.m_Container);
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

        public SecureTradeContainer Container
        {
            get
            {
                return this.m_Container;
            }
        }

        public Mobile Mobile
        {
            get
            {
                return this.m_Mobile;
            }
        }

        public SecureTrade Owner
        {
            get
            {
                return this.m_Owner;
            }
        }


        // Fields
        private bool m_Accepted;
        private SecureTradeContainer m_Container;
        private Mobile m_Mobile;
        private SecureTrade m_Owner;
    }
}

