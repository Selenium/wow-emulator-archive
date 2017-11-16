namespace Server.Network
{
    using Server;
    using System;

    public sealed class EquipUpdate : Packet
    {
        // Methods
        public EquipUpdate(Item item) : base(46, 15)
        {
            Serial serial1;
            Mobile mobile1;
            if ((item.Parent is Mobile))
            {
                serial1 = ((Mobile) item.Parent).Serial;
            }
            else
            {
                Console.WriteLine("Warning: EquipUpdate on item with !(parent is Mobile)");
                serial1 = Serial.Zero;
            }
            int num1 = item.Hue;
            if ((item.Parent is Mobile))
            {
                mobile1 = ((Mobile) item.Parent);
                if (mobile1.SolidHueOverride >= 0)
                {
                    num1 = mobile1.SolidHueOverride;
                }
            }
            this.m_Stream.Write(Serial.op_Implicit(item.Serial));
            this.m_Stream.Write(((short) item.ItemID));
            this.m_Stream.Write(((byte) 0));
            this.m_Stream.Write(((byte) item.Layer));
            this.m_Stream.Write(Serial.op_Implicit(serial1));
            this.m_Stream.Write(((short) num1));
        }

    }
}

