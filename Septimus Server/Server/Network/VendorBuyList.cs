namespace Server.Network
{
    using Server;
    using Server.Items;
    using Server.Mobiles;
    using System;
    using System.Collections;

    public sealed class VendorBuyList : Packet
    {
        // Methods
        public VendorBuyList(Mobile vendor, ArrayList list) : base(116)
        {
            int num1;
            BuyItemState state1;
            string text1;
            base.EnsureCapacity(256);
            Container container1 = (vendor.FindItemOnLayer(Layer.ShopBuy) as Container);
            this.m_Stream.Write(Serial.op_Implicit(((container1 == null) ? Serial.MinusOne : container1.Serial)));
            this.m_Stream.Write(((byte) list.Count));
            for (num1 = 0; (num1 < list.Count); ++num1)
            {
                state1 = ((BuyItemState) list[num1]);
                this.m_Stream.Write(state1.Price);
                text1 = state1.Description;
                if (text1 == null)
                {
                    text1 = "";
                }
                this.m_Stream.Write(((byte) (text1.Length + 1)));
                this.m_Stream.WriteAsciiNull(text1);
            }
        }

    }
}

