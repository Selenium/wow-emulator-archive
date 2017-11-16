namespace Server
{
    using System;

    public class VirtueItemRequestEventArgs : EventArgs
    {
        // Methods
        public VirtueItemRequestEventArgs(Mobile beholder, Mobile beheld, int gumpID)
        {
            this.m_Beholder = beholder;
            this.m_Beheld = beheld;
            this.m_GumpID = gumpID;
        }


        // Properties
        public Mobile Beheld
        {
            get
            {
                return this.m_Beheld;
            }
        }

        public Mobile Beholder
        {
            get
            {
                return this.m_Beholder;
            }
        }

        public int GumpID
        {
            get
            {
                return this.m_GumpID;
            }
        }


        // Fields
        private Mobile m_Beheld;
        private Mobile m_Beholder;
        private int m_GumpID;
    }
}

