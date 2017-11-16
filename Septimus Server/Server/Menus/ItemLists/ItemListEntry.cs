namespace Server.Menus.ItemLists
{
    using System;

    public class ItemListEntry
    {
        // Methods
        public ItemListEntry(string name, int itemID) : this(name, itemID, 0)
        {
        }

        public ItemListEntry(string name, int itemID, int hue)
        {
            this.m_Name = name;
            this.m_ItemID = itemID;
            this.m_Hue = hue;
        }


        // Properties
        public int Hue
        {
            get
            {
                return this.m_Hue;
            }
        }

        public int ItemID
        {
            get
            {
                return this.m_ItemID;
            }
        }

        public string Name
        {
            get
            {
                return this.m_Name;
            }
        }


        // Fields
        private int m_Hue;
        private int m_ItemID;
        private string m_Name;
    }
}

