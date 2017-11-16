namespace Server.Network
{
    using Server;
    using System;

    public sealed class MovingParticleEffect : ParticleEffect
    {
        // Methods
        public MovingParticleEffect(IEntity from, IEntity to, int itemID, int speed, int duration, bool fixedDirection, bool explodes, int hue, int renderMode, int effect, int explodeEffect, int explodeSound, EffectLayer layer, int unknown) : base(EffectType.Moving, from.Serial, to.Serial, itemID, from.Location, to.Location, speed, duration, fixedDirection, explodes, hue, renderMode, effect, explodeEffect, explodeSound, Serial.Zero, ((int) layer), unknown)
        {
        }

    }
}

