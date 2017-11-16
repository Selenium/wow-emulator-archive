namespace Server.Network
{
    using System;

    public sealed class PopupMessage : Packet
    {
        // Methods
        public PopupMessage(PMMessage msg) : base(83, 2)
        {
            this.m_Stream.Write(((byte) msg));
        }

    }
}

