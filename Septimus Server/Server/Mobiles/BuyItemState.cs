namespace Server.Mobiles
{
    using Server;
    using System;

    public class BuyItemState
    {
        // Methods
        public BuyItemState(string name, Serial cont, Serial serial, int price, int amount, int itemID, int hue)
        {
            this.m_Desc = name;
            this.m_ContSer = cont;
            this.m_MySer = serial;
            this.m_Price = price;
            this.m_Amount = amount;
            this.m_ItemID = itemID;
            this.m_Hue = hue;
        }


        // Properties
        public int Amount
        {
            get
            {
                return this.m_Amount;
            }
        }

        public Serial ContainerSerial
        {
            get
            {
                return this.m_ContSer;
            }
        }

        public string Description
        {
            get
            {
                return this.m_Desc;
            }
        }

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

        public Serial MySerial
        {
            get
            {
                return this.m_MySer;
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
        private int m_Amount;
        private Serial m_ContSer;
        private string m_Desc;
        private int m_Hue;
        private int m_ItemID;
        private Serial m_MySer;
        private int m_Price;
    }
}

