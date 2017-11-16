namespace Server.Network
{
    using System;

    public sealed class CurrentTime : Packet
    {
        // Methods
        public CurrentTime() : base(91, 4)
        {
            DateTime time1 = DateTime.Now;
            this.m_Stream.Write(((byte) time1.Hour));
            this.m_Stream.Write(((byte) time1.Minute));
            this.m_Stream.Write(((byte) time1.Second));
        }

    }
}

