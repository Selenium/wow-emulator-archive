namespace Server.Network
{
    using System;

    public class ClearWeaponAbility : Packet
    {
        // Methods
        static ClearWeaponAbility()
        {
            ClearWeaponAbility.Instance = new ClearWeaponAbility();
        }

        public ClearWeaponAbility() : base(191)
        {
            base.EnsureCapacity(5);
            this.m_Stream.Write(((short) 33));
        }


        // Fields
        public static readonly Packet Instance;
    }
}

