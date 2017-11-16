namespace Server.Mobiles
{
    using Server;
    using System;

    public class BuyItemResponse
    {
        // Methods
        public BuyItemResponse(Serial serial, int amount)
        {
            this.m_Serial = serial;
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

        public Serial Serial
        {
            get
            {
                return this.m_Serial;
            }
        }


        // Fields
        private int m_Amount;
        private Serial m_Serial;
    }
}

