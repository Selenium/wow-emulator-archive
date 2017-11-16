namespace Server.Network
{
    using System;

    public sealed class DeathStatus : Packet
    {
        // Methods
        static DeathStatus()
        {
            DeathStatus.Dead = new DeathStatus(true);
            DeathStatus.Alive = new DeathStatus(false);
        }

        public DeathStatus(bool dead) : base(44, 2)
        {
            this.m_Stream.Write(((byte) (dead ? 0 : 2)));
        }

        public static DeathStatus Instantiate(bool dead)
        {
            if (!dead)
            {
                return DeathStatus.Alive;
            }
            return DeathStatus.Dead;
        }


        // Fields
        public static readonly DeathStatus Alive;
        public static readonly DeathStatus Dead;
    }
}

