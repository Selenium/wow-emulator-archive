namespace Server.Network
{
    using System;

    public sealed class Weather : Packet
    {
        // Methods
        public Weather(int v1, int v2, int v3) : base(101, 4)
        {
            this.m_Stream.Write(((byte) v1));
            this.m_Stream.Write(((byte) v2));
            this.m_Stream.Write(((byte) v3));
        }

    }
}

