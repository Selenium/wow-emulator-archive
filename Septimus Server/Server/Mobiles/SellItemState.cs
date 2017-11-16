namespace Server.Mobiles
{
    using Server;
    using System;

    public class SellItemState
    {
        // Methods
        public SellItemState(Item item, int price, string name)
        {
            this.m_Item = item;
            this.m_Price = price;
            this.m_Name = name;
        }


        // Properties
        public Item Item
        {
            get
            {
                return this.m_Item;
            }
        }

        public string Name
        {
            get
            {
                return this.m_Name;
            }
        }

        public int Price
        {
            get
            {
                return this.m_Price;
            }
        }


        // Fields
        private Item m_Item;
        private string m_Name;
        private int m_Price;
    }
}

