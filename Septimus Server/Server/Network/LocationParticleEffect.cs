namespace Server.Network
{
    using Server;
    using System;

    public sealed class LocationParticleEffect : ParticleEffect
    {
        // Methods
        public LocationParticleEffect(IEntity e, int itemID, int speed, int duration, int hue, int renderMode, int effect, int unknown) : base(EffectType.FixedXYZ, e.Serial, Serial.Zero, itemID, e.Location, e.Location, speed, duration, true, false, hue, renderMode, effect, 1, 0, e.Serial, 255, unknown)
        {
        }

    }
}

