namespace Server.Network
{
    using Server;
    using System;
    using System.Collections;
    using System.IO;

    public sealed class ContainerContent : Packet
    {
        // Methods
        public ContainerContent(Mobile beholder, Item beheld) : base(60)
        {
            int num4;
            Item item1;
            Point3D pointd1;
            ushort num5;
            ArrayList list1 = beheld.Items;
            int num1 = list1.Count;
            base.EnsureCapacity((5 + (num1 * 19)));
            long num2 = this.m_Stream.Position;
            int num3 = 0;
            this.m_Stream.Write(((ushort) 0));
            for (num4 = 0; (num4 < num1); ++num4)
            {
                item1 = ((Item) list1[num4]);
                if (!item1.Deleted && beholder.CanSee(item1))
                {
                    pointd1 = item1.Location;
                    num5 = ((ushort) item1.ItemID);
                    if (num5 > 16383)
                    {
                        num5 = 2519;
                    }
                    this.m_Stream.Write(Serial.op_Implicit(item1.Serial));
                    this.m_Stream.Write(num5);
                    this.m_Stream.Write(((byte) 0));
                    this.m_Stream.Write(((ushort) item1.Amount));
                    this.m_Stream.Write(((short) pointd1.m_X));
                    this.m_Stream.Write(((short) pointd1.m_Y));
                    this.m_Stream.Write(Serial.op_Implicit(beheld.Serial));
                    this.m_Stream.Write(((ushort) item1.Hue));
                    ++num3;
                }
            }
            this.m_Stream.Seek(num2, SeekOrigin.Begin);
            this.m_Stream.Write(((ushort) num3));
        }

    }
}

