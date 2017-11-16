namespace Server.Network
{
    using Server;
    using System;

    public sealed class TargetEffect : HuedEffect
    {
        // Methods
        public TargetEffect(IEntity e, int itemID, int speed, int duration, int hue, int renderMode) : base(EffectType.FixedFrom, e.Serial, Serial.Zero, itemID, e.Location, e.Location, speed, duration, true, false, hue, renderMode)
        {
        }

    }
}

