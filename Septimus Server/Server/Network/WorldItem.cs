namespace Server.Network
{
    using Server;
    using System;

    public sealed class WorldItem : Packet
    {
        // Methods
        public WorldItem(Item item) : base(26)
        {
            base.EnsureCapacity(20);
            Serial serial1 = item.Serial;
            uint num1 = ((uint) serial1.Value);
            int num2 = item.ItemID;
            int num3 = item.Amount;
            Point3D pointd1 = item.Location;
            int num4 = pointd1.m_X;
            int num5 = pointd1.m_Y;
            int num6 = item.Hue;
            int num7 = item.GetPacketFlags();
            int num8 = ((int) item.Direction);
            if (num3 != 0)
            {
                num1 = ((uint) (num1 | -2147483648));
            }
            else
            {
                num1 = ((uint) (num1 & 2147483647));
            }
            this.m_Stream.Write(num1);
            this.m_Stream.Write(((short) (num2 & 32767)));
            if (num3 != 0)
            {
                this.m_Stream.Write(((short) num3));
            }
            num4 &= 32767;
            if (num8 != 0)
            {
                num4 |= 32768;
            }
            this.m_Stream.Write(((short) num4));
            num5 &= 16383;
            if (num6 != 0)
            {
                num5 |= 32768;
            }
            if (num7 != 0)
            {
                num5 |= 16384;
            }
            this.m_Stream.Write(((short) num5));
            if (num8 != 0)
            {
                this.m_Stream.Write(((byte) num8));
            }
            this.m_Stream.Write(((sbyte) pointd1.m_Z));
            if (num6 != 0)
            {
                this.m_Stream.Write(((ushort) num6));
            }
            if (num7 != 0)
            {
                this.m_Stream.Write(((byte) num7));
            }
        }

    }
}

