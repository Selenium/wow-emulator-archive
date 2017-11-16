namespace Server.Network
{
    using System;

    public sealed class PingAck : Packet
    {
        // Methods
        static PingAck()
        {
            PingAck.m_Cache = new PingAck[256];
        }

        public PingAck(byte ping) : base(115, 2)
        {
            this.m_Stream.Write(ping);
        }

        public static PingAck Instantiate(byte ping)
        {
            PingAck ack1 = PingAck.m_Cache[ping];
            if (ack1 == null)
            {
                PingAck.m_Cache[ping] = (ack1 = new PingAck(ping));
            }
            return ack1;
        }


        // Fields
        private static PingAck[] m_Cache;
    }
}

