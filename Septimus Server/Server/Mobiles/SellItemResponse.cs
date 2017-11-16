namespace Server.Mobiles
{
    using Server;
    using System;

    public class SellItemResponse
    {
        // Methods
        public SellItemResponse(Item i, int amount)
        {
            this.m_Item = i;
            this.m_Amount = amount;
        }


        // Properties
        public int Amount
        {
            get
            {
                return this.m_Amount;
            }
        }

        public Item Item
        {
            get
            {
                return this.m_Item;
            }
        }


        // Fields
        private int m_Amount;
        private Item m_Item;
    }
}

