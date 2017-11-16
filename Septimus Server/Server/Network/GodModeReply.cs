namespace Server.Network
{
    using System;

    public sealed class GodModeReply : Packet
    {
        // Methods
        public GodModeReply(bool reply) : base(43, 2)
        {
            this.m_Stream.Write(reply);
        }

    }
}

