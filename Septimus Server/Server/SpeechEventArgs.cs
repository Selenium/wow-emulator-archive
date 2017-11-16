namespace Server
{
    using Server.Network;
    using System;

    public class SpeechEventArgs : EventArgs
    {
        // Methods
        public SpeechEventArgs(Mobile mobile, string speech, MessageType type, int hue, int[] keywords)
        {
            this.m_Mobile = mobile;
            this.m_Speech = speech;
            this.m_Type = type;
            this.m_Hue = hue;
            this.m_Keywords = keywords;
        }

        public bool HasKeyword(int keyword)
        {
            int num1;
            for (num1 = 0; (num1 < this.m_Keywords.Length); ++num1)
            {
                if (this.m_Keywords[num1] == keyword)
                {
                    return true;
                }
            }
            return false;
        }


        // Properties
        public bool Blocked
        {
            get
            {
                return this.m_Blocked;
            }
            set
            {
                this.m_Blocked = value;
            }
        }

        public bool Handled
        {
            get
            {
                return this.m_Handled;
            }
            set
            {
                this.m_Handled = value;
            }
        }

        public int Hue
        {
            get
            {
                return this.m_Hue;
            }
        }

        public int[] Keywords
        {
            get
            {
                return this.m_Keywords;
            }
        }

        public Mobile Mobile
        {
            get
            {
                return this.m_Mobile;
            }
        }

        public string Speech
        {
            get
            {
                return this.m_Speech;
            }
            set
            {
                this.m_Speech = value;
            }
        }

        public MessageType Type
        {
            get
            {
                return this.m_Type;
            }
        }


        // Fields
        private bool m_Blocked;
        private bool m_Handled;
        private int m_Hue;
        private int[] m_Keywords;
        private Mobile m_Mobile;
        private string m_Speech;
        private MessageType m_Type;
    }
}

