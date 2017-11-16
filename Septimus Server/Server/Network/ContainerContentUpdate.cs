namespace Server.Network
{
    using Server;
    using System;

    public sealed class ContainerContentUpdate : Packet
    {
        // Methods
        public ContainerContentUpdate(Item item) : base(37, 20)
        {
            Serial serial1;
            if ((item.Parent is Item))
            {
                serial1 = ((Item) item.Parent).Serial;
            }
            else
            {
                Console.WriteLine("Warning: ContainerContentUpdate on item with !(parent is Item)");
                serial1 = Serial.Zero;
            }
            ushort num1 = ((ushort) item.ItemID);
            if (num1 > 16383)
            {
                num1 = 2519;
            }
            this.m_Stream.Write(Serial.op_Implicit(item.Serial));
            this.m_Stream.Write(((short) num1));
            this.m_Stream.Write(((byte) 0));
            this.m_Stream.Write(((ushort) item.Amount));
            this.m_Stream.Write(((short) item.X));
            this.m_Stream.Write(((short) item.Y));
            this.m_Stream.Write(Serial.op_Implicit(serial1));
            this.m_Stream.Write(((ushort) item.Hue));
        }

    }
}

