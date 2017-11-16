namespace Server.Network
{
    using Server;
    using Server.Mobiles;
    using System;
    using System.Collections;

    public sealed class VendorSellList : Packet
    {
        // Methods
        public VendorSellList(Mobile shopkeeper, Hashtable table) : base(158)
        {
            string text1;
            base.EnsureCapacity(256);
            this.m_Stream.Write(Serial.op_Implicit(shopkeeper.Serial));
            this.m_Stream.Write(((ushort) table.Count));
            foreach (SellItemState state1 in table.Values)
            {
                this.m_Stream.Write(Serial.op_Implicit(state1.Item.Serial));
                this.m_Stream.Write(((ushort) (state1.Item.ItemID & 16383)));
                this.m_Stream.Write(((ushort) state1.Item.Hue));
                this.m_Stream.Write(((ushort) state1.Item.Amount));
                this.m_Stream.Write(((ushort) state1.Price));
                text1 = state1.Item.Name;
                if ((text1 == null) || ((text1 = text1.Trim()).Length <= 0))
                {
                    text1 = state1.Name;
                }
                if (text1 == null)
                {
                    text1 = "";
                }
                this.m_Stream.Write(((ushort) text1.Length));
                this.m_Stream.WriteAsciiFixed(text1, ((ushort) text1.Length));
            }
        }

    }
}

