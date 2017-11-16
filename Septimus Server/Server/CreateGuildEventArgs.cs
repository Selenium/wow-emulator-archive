namespace Server
{
    using System;

    public class CreateGuildEventArgs : EventArgs
    {
        // Methods
        public CreateGuildEventArgs(int id)
        {
            this.m_Id = id;
        }


        // Properties
        public int Id
        {
            get
            {
                return this.m_Id;
            }
            set
            {
                this.m_Id = value;
            }
        }


        // Fields
        private int m_Id;
    }
}

