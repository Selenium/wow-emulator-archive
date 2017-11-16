namespace Server.Network
{
    using Server;
    using System;

    public sealed class Swing : Packet
    {
        // Methods
        public Swing(int flag, Mobile attacker, Mobile defender) : base(47, 10)
        {
            this.m_Stream.Write(((byte) flag));
            this.m_Stream.Write(Serial.op_Implicit(attacker.Serial));
            this.m_Stream.Write(Serial.op_Implicit(defender.Serial));
        }

    }
}

