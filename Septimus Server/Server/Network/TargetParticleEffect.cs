namespace Server.Network
{
    using Server;
    using System;

    public sealed class TargetParticleEffect : ParticleEffect
    {
        // Methods
        public TargetParticleEffect(IEntity e, int itemID, int speed, int duration, int hue, int renderMode, int effect, int layer, int unknown) : base(EffectType.FixedFrom, e.Serial, Serial.Zero, itemID, e.Location, e.Location, speed, duration, true, false, hue, renderMode, effect, 1, 0, e.Serial, layer, unknown)
        {
        }

    }
}

