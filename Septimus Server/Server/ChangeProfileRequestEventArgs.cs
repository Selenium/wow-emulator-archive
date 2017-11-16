namespace Server
{
    using System;

    public class ChangeProfileRequestEventArgs : EventArgs
    {
        // Methods
        public ChangeProfileRequestEventArgs(Mobile beholder, Mobile beheld, string text)
        {
            this.m_Beholder = beholder;
            this.m_Beheld = beheld;
            this.m_Text = text;
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

        public string Text
        {
            get
            {
                return this.m_Text;
            }
        }


        // Fields
        private Mobile m_Beheld;
        private Mobile m_Beholder;
        private string m_Text;
    }
}

