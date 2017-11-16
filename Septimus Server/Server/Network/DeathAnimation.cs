namespace Server.Network
{
    using Server;
    using System;

    public sealed class DeathAnimation : Packet
    {
        // Methods
        public DeathAnimation(Mobile killed, Item corpse) : base(175, 13)
        {
            this.m_Stream.Write(Serial.op_Implicit(killed.Serial));
            this.m_Stream.Write(Serial.op_Implicit(((corpse == null) ? Serial.Zero : corpse.Serial)));
            this.m_Stream.Write(0);
        }

    }
}

