namespace Server
{
    using System;

    public class CrashedEventArgs : EventArgs
    {
        // Methods
        public CrashedEventArgs(Exception e)
        {
            this.m_Exception = e;
        }


        // Properties
        public bool Close
        {
            get
            {
                return this.m_Close;
            }
            set
            {
                this.m_Close = value;
            }
        }

        public Exception Exception
        {
            get
            {
                return this.m_Exception;
            }
        }


        // Fields
        private bool m_Close;
        private Exception m_Exception;
    }
}

