namespace Server
{
    using System;
    using System.Runtime.InteropServices;

    public interface IWeapon
    {
        // Methods
        void GetStatusDamage(Mobile from, out int min, out int max);

        TimeSpan OnSwing(Mobile attacker, Mobile defender);


        // Properties
        int MaxRange { get; }

    }
}

