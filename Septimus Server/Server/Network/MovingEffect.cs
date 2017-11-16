namespace Server.Network
{
    using Server;
    using System;

    public sealed class MovingEffect : HuedEffect
    {
        // Methods
        public MovingEffect(IEntity from, IEntity to, int itemID, int speed, int duration, bool fixedDirection, bool explodes, int hue, int renderMode) : base(EffectType.Moving, from.Serial, to.Serial, itemID, from.Location, to.Location, speed, duration, fixedDirection, explodes, hue, renderMode)
        {
        }

    }
}

