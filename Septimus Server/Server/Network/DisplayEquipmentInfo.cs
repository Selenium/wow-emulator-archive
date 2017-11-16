namespace Server.Network
{
    using Server;
    using System;

    public sealed class DisplayEquipmentInfo : Packet
    {
        // Methods
        public DisplayEquipmentInfo(Item item, EquipmentInfo info) : base(191)
        {
            string text1;
            int num1;
            int num2;
            EquipInfoAttribute[] attributeArray1 = info.Attributes;
            base.EnsureCapacity((((17 + ((info.Crafter == null) ? 0 : ((6 + info.Crafter.Name == null) ? 0 : info.Crafter.Name.Length))) + (info.Unidentified ? 4 : 0)) + (attributeArray1.Length * 6)));
            this.m_Stream.Write(((short) 16));
            this.m_Stream.Write(Serial.op_Implicit(item.Serial));
            this.m_Stream.Write(info.Number);
            if (info.Crafter != null)
            {
                text1 = info.Crafter.Name;
                if (text1 == null)
                {
                    text1 = "";
                }
                num1 = ((ushort) text1.Length);
                this.m_Stream.Write(-3);
                this.m_Stream.Write(((ushort) num1));
                this.m_Stream.WriteAsciiFixed(text1, num1);
            }
            if (info.Unidentified)
            {
                this.m_Stream.Write(-4);
            }
            for (num2 = 0; (num2 < attributeArray1.Length); ++num2)
            {
                this.m_Stream.Write(attributeArray1[num2].Number);
                this.m_Stream.Write(((short) attributeArray1[num2].Charges));
            }
            this.m_Stream.Write(-1);
        }

    }
}

