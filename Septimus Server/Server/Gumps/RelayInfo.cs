namespace Server.Gumps
{
    using System;

    public class RelayInfo
    {
        // Methods
        public RelayInfo(int buttonID, int[] switches, TextRelay[] textEntries)
        {
            this.m_ButtonID = buttonID;
            this.m_Switches = switches;
            this.m_TextEntries = textEntries;
        }

        public TextRelay GetTextEntry(int entryID)
        {
            int num1;
            for (num1 = 0; (num1 < this.m_TextEntries.Length); ++num1)
            {
                if (this.m_TextEntries[num1].EntryID == entryID)
                {
                    return this.m_TextEntries[num1];
                }
            }
            return null;
        }

        public bool IsSwitched(int switchID)
        {
            int num1;
            for (num1 = 0; (num1 < this.m_Switches.Length); ++num1)
            {
                if (this.m_Switches[num1] == switchID)
                {
                    return true;
                }
            }
            return false;
        }


        // Properties
        public int ButtonID
        {
            get
            {
                return this.m_ButtonID;
            }
        }

        public int[] Switches
        {
            get
            {
                return this.m_Switches;
            }
        }

        public TextRelay[] TextEntries
        {
            get
            {
                return this.m_TextEntries;
            }
        }


        // Fields
        private int m_ButtonID;
        private int[] m_Switches;
        private TextRelay[] m_TextEntries;
    }
}

