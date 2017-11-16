namespace Server.Network
{
    using Server;
    using System;

    public sealed class PersonalLightLevel : Packet
    {
        // Methods
        public PersonalLightLevel(Mobile m) : this(m, m.LightLevel)
        {
        }

        public PersonalLightLevel(Mobile m, int level) : base(78, 6)
        {
            this.m_Stream.Write(Serial.op_Implicit(m.Serial));
            this.m_Stream.Write(((sbyte) level));
        }

    }
}

