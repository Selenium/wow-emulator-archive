namespace Server.Network
{
    using System;

    public sealed class TripTimeResponse : Packet
    {
        // Methods
        public TripTimeResponse(int unk) : base(201, 6)
        {
            this.m_Stream.Write(((byte) unk));
            this.m_Stream.Write(Environment.TickCount);
        }

    }
}

