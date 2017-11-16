namespace Server
{
    using System;

    public class WorldSaveEventArgs : EventArgs
    {
        // Methods
        public WorldSaveEventArgs(bool msg)
        {
            this.m_Msg = msg;
        }


        // Properties
        public bool Message
        {
            get
            {
                return this.m_Msg;
            }
        }


        // Fields
        private bool m_Msg;
    }
}

