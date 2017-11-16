namespace Server.Network
{
    using Server;
    using System;

    public sealed class ChangeCombatant : Packet
    {
        // Methods
        public ChangeCombatant(Mobile combatant) : base(170, 5)
        {
            this.m_Stream.Write(Serial.op_Implicit(((combatant != null) ? combatant.Serial : Serial.Zero)));
        }

    }
}

