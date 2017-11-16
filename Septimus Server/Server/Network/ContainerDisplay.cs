namespace Server.Network
{
    using Server;
    using Server.Items;
    using System;

    public sealed class ContainerDisplay : Packet
    {
        // Methods
        public ContainerDisplay(Container c) : base(36, 7)
        {
            this.m_Stream.Write(Serial.op_Implicit(c.Serial));
            this.m_Stream.Write(((short) c.GumpID));
        }

    }
}

