namespace Server
{
    using System;
    using System.Collections;

    public class AggressiveActionEventArgs : EventArgs
    {
        // Methods
        static AggressiveActionEventArgs()
        {
            AggressiveActionEventArgs.m_Pool = new Queue();
        }

        private AggressiveActionEventArgs(Mobile aggressed, Mobile aggressor, bool criminal)
        {
            this.m_Aggressed = aggressed;
            this.m_Aggressor = aggressor;
            this.m_Criminal = criminal;
        }

        public static AggressiveActionEventArgs Create(Mobile aggressed, Mobile aggressor, bool criminal)
        {
            AggressiveActionEventArgs args1;
            if (AggressiveActionEventArgs.m_Pool.Count > 0)
            {
                args1 = ((AggressiveActionEventArgs) AggressiveActionEventArgs.m_Pool.Dequeue());
                args1.m_Aggressed = aggressed;
                args1.m_Aggressor = aggressor;
                args1.m_Criminal = criminal;
                return args1;
            }
            return new AggressiveActionEventArgs(aggressed, aggressor, criminal);
        }

        public void Free()
        {
            AggressiveActionEventArgs.m_Pool.Enqueue(this);
        }


        // Properties
        public Mobile Aggressed
        {
            get
            {
                return this.m_Aggressed;
            }
        }

        public Mobile Aggressor
        {
            get
            {
                return this.m_Aggressor;
            }
        }

        public bool Criminal
        {
            get
            {
                return this.m_Criminal;
            }
        }


        // Fields
        private Mobile m_Aggressed;
        private Mobile m_Aggressor;
        private bool m_Criminal;
        private static Queue m_Pool;
    }
}

