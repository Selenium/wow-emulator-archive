namespace Server.Network
{
    using Server;
    using System;
    using System.Collections;

    public sealed class MobileIncoming : Packet
    {
        // Methods
        static MobileIncoming()
        {
            MobileIncoming.m_DupedLayers = new int[256];
        }

        public MobileIncoming(Mobile beholder, Mobile beheld) : base(120)
        {
            int num3;
            Item item1;
            byte num4;
            int num5;
            bool flag1;
            this.m_Beheld = beheld;
            ++MobileIncoming.m_Version;
            ArrayList list1 = beheld.Items;
            int num1 = list1.Count;
            base.EnsureCapacity((23 + (num1 * 9)));
            int num2 = beheld.Hue;
            if (beheld.SolidHueOverride >= 0)
            {
                num2 = beheld.SolidHueOverride;
            }
            this.m_Stream.Write(Serial.op_Implicit(beheld.Serial));
            this.m_Stream.Write(((short) Body.op_Implicit(beheld.Body)));
            this.m_Stream.Write(((short) beheld.X));
            this.m_Stream.Write(((short) beheld.Y));
            this.m_Stream.Write(((sbyte) beheld.Z));
            this.m_Stream.Write(((byte) beheld.Direction));
            this.m_Stream.Write(((short) num2));
            this.m_Stream.Write(((byte) beheld.GetPacketFlags()));
            this.m_Stream.Write(((byte) Notoriety.Compute(beholder, beheld)));
            for (num3 = 0; (num3 < num1); ++num3)
            {
                item1 = ((Item) list1[num3]);
                num4 = ((byte) item1.Layer);
                if ((!item1.Deleted && beholder.CanSee(item1)) && (MobileIncoming.m_DupedLayers[num4] != MobileIncoming.m_Version))
                {
                    MobileIncoming.m_DupedLayers[num4] = MobileIncoming.m_Version;
                    num2 = item1.Hue;
                    if (beheld.SolidHueOverride >= 0)
                    {
                        num2 = beheld.SolidHueOverride;
                    }
                    num5 = (item1.ItemID & 16383);
                    flag1 = (num2 != 0);
                    if (flag1)
                    {
                        num5 |= 32768;
                    }
                    this.m_Stream.Write(Serial.op_Implicit(item1.Serial));
                    this.m_Stream.Write(((short) num5));
                    this.m_Stream.Write(num4);
                    if (flag1)
                    {
                        this.m_Stream.Write(((short) num2));
                    }
                }
            }
            this.m_Stream.Write(0);
        }


        // Fields
        public Mobile m_Beheld;
        private static int[] m_DupedLayers;
        private static int m_Version;
    }
}

