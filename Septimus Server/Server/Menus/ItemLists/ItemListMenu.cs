namespace Server.Menus.ItemLists
{
    using Server.Menus;
    using Server.Network;
    using System;

    public class ItemListMenu : IMenu
    {
        // Methods
        public ItemListMenu(string question, ItemListEntry[] entries)
        {
            this.m_Question = question;
            this.m_Entries = entries;
            do
            {
                this.m_Serial = ItemListMenu.m_NextSerial++;
                this.m_Serial &= 2147483647;
            }
            while ((this.m_Serial == 0));
            this.m_Serial |= -2147483648;
        }

        public virtual void OnCancel(NetState state)
        {
        }

        public virtual void OnResponse(NetState state, int index)
        {
        }

        public void SendTo(NetState state)
        {
            state.AddMenu(this);
            state.Send(new DisplayItemListMenu(this));
        }


        // Properties
        public ItemListEntry[] Entries
        {
            get
            {
                return this.m_Entries;
            }
            set
            {
                this.m_Entries = value;
            }
        }

        public string Question
        {
            get
            {
                return this.m_Question;
            }
        }

        int Server.Menus.IMenu.EntryLength
        {
            get
            {
                return this.m_Entries.Length;
            }
        }

        int Server.Menus.IMenu.Serial
        {
            get
            {
                return this.m_Serial;
            }
        }


        // Fields
        private ItemListEntry[] m_Entries;
        private static int m_NextSerial;
        private string m_Question;
        private int m_Serial;
    }
}

