namespace Server.Network
{
    using Server;
    using System;

    public sealed class LocationEffect : HuedEffect
    {
        // Methods
        public LocationEffect(IPoint3D p, int itemID, int speed, int duration, int hue, int renderMode) : base(EffectType.FixedXYZ, Serial.Zero, Serial.Zero, itemID, p, p, speed, duration, true, false, hue, renderMode)
        {
        }

    }
}

