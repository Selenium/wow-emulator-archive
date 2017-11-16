namespace Server.Network
{
    using Server;
    using Server.Mobiles;
    using System;
    using System.Collections;

    public sealed class VendorBuyContent : Packet
    {
        // Methods
        public VendorBuyContent(ArrayList list) : base(60)
        {
            int num1;
            BuyItemState state1;
            base.EnsureCapacity(((list.Count * 19) + 5));
            this.m_Stream.Write(((short) list.Count));
            for (num1 = (list.Count - 1); (num1 >= 0); --num1)
            {
                state1 = ((BuyItemState) list[num1]);
                this.m_Stream.Write(Serial.op_Implicit(state1.MySerial));
                this.m_Stream.Write(((ushort) (state1.ItemID & 16383)));
                this.m_Stream.Write(((byte) 0));
                this.m_Stream.Write(((ushort) state1.Amount));
                this.m_Stream.Write(((short) (num1 + 1)));
                this.m_Stream.Write(((short) 1));
                this.m_Stream.Write(Serial.op_Implicit(state1.ContainerSerial));
                this.m_Stream.Write(((ushort) state1.Hue));
            }
        }

    }
}

