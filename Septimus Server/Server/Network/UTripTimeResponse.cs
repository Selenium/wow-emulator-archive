namespace Server.Network
{
    using System;

    public sealed class UTripTimeResponse : Packet
    {
        // Methods
        public UTripTimeResponse(int unk) : base(202, 6)
        {
            this.m_Stream.Write(((byte) unk));
            this.m_Stream.Write(Environment.TickCount);
        }

    }
}

