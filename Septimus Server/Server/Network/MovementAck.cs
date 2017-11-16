namespace Server.Network
{
    using Server;
    using System;

    public sealed class MovementAck : Packet
    {
        // Methods
        static MovementAck()
        {
            MovementAck[][] ackArrayArray1 = new MovementAck[8][];
            ackArrayArray1[0] = new MovementAck[256];
            ackArrayArray1[1] = new MovementAck[256];
            ackArrayArray1[2] = new MovementAck[256];
            ackArrayArray1[3] = new MovementAck[256];
            ackArrayArray1[4] = new MovementAck[256];
            ackArrayArray1[5] = new MovementAck[256];
            ackArrayArray1[6] = new MovementAck[256];
            ackArrayArray1[7] = new MovementAck[256];
            MovementAck.m_Cache = ackArrayArray1;
        }

        private MovementAck(int seq, int noto) : base(34, 3)
        {
            this.m_Stream.Write(((byte) seq));
            this.m_Stream.Write(((byte) noto));
        }

        public static MovementAck Instantiate(int seq, Mobile m)
        {
            int num1 = Notoriety.Compute(m, m);
            MovementAck ack1 = MovementAck.m_Cache[num1][seq];
            if (ack1 == null)
            {
                MovementAck.m_Cache[num1][seq] = (ack1 = new MovementAck(seq, num1));
            }
            return ack1;
        }


        // Fields
        private static MovementAck[][] m_Cache;
    }
}

