namespace Server
{
    using System;

    public class CastSpellRequestEventArgs : EventArgs
    {
        // Methods
        public CastSpellRequestEventArgs(Mobile m, int spellID, Item book)
        {
            this.m_Mobile = m;
            this.m_Spellbook = book;
            this.m_SpellID = spellID;
        }


        // Properties
        public Mobile Mobile
        {
            get
            {
                return this.m_Mobile;
            }
        }

        public Item Spellbook
        {
            get
            {
                return this.m_Spellbook;
            }
        }

        public int SpellID
        {
            get
            {
                return this.m_SpellID;
            }
        }


        // Fields
        private Mobile m_Mobile;
        private Item m_Spellbook;
        private int m_SpellID;
    }
}

