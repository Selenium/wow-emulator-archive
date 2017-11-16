namespace Server.Network
{
    using Server;
    using System;

    public sealed class PersonalLightLevelZero : Packet
    {
        // Methods
        public PersonalLightLevelZero(Mobile m) : base(78, 6)
        {
            this.m_Stream.Write(Serial.op_Implicit(m.Serial));
            this.m_Stream.Write(((sbyte) 0));
        }

    }
}

