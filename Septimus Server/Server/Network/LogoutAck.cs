namespace Server.Network
{
    using System;

    public sealed class LogoutAck : Packet
    {
        // Methods
        public LogoutAck() : base(209, 2)
        {
            this.m_Stream.Write(((byte) 1));
        }

    }
}

