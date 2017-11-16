namespace Server.Gumps
{
    using System;

    public class TextRelay
    {
        // Methods
        public TextRelay(int entryID, string text)
        {
            this.m_EntryID = entryID;
            this.m_Text = text;
        }


        // Properties
        public int EntryID
        {
            get
            {
                return this.m_EntryID;
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
        private int m_EntryID;
        private string m_Text;
    }
}

