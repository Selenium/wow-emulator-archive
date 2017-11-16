namespace Server.Network
{
    using Server.HuePickers;
    using System;

    public sealed class DisplayHuePicker : Packet
    {
        // Methods
        public DisplayHuePicker(HuePicker huePicker) : base(149, 9)
        {
            this.m_Stream.Write(huePicker.Serial);
            this.m_Stream.Write(((short) 0));
            this.m_Stream.Write(((short) huePicker.ItemID));
        }

    }
}

