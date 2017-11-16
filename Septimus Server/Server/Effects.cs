namespace Server
{
    using Server.Network;
    using System;

    public class Effects
    {
        // Methods
        static Effects()
        {
            Effects.m_ParticleSupportType = ParticleSupportType.Detect;
        }

        public Effects()
        {
        }

        public static void PlaySound(IPoint3D p, Map map, int soundID)
        {
            if (soundID == -1)
            {
                return;
            }
            if (map == null)
            {
                return;
            }
            Packet packet1 = null;
            IPooledEnumerable enumerable1 = map.GetClientsInRange(new Point3D(p));
            foreach (NetState state1 in enumerable1)
            {
                state1.Mobile.ProcessDelta();
                if (packet1 == null)
                {
                    packet1 = new PlaySound(soundID, p);
                }
                state1.Send(packet1);
            }
            enumerable1.Free();
        }

        public static void SendBoltEffect(IEntity e)
        {
            Effects.SendBoltEffect(e, true, 0);
        }

        public static void SendBoltEffect(IEntity e, bool sound)
        {
            Effects.SendBoltEffect(e, sound, 0);
        }

        public static void SendBoltEffect(IEntity e, bool sound, int hue)
        {
            Map map1 = e.Map;
            if (map1 == null)
            {
                return;
            }
            if ((e is Item))
            {
                ((Item) e).ProcessDelta();
            }
            else if ((e is Mobile))
            {
                ((Mobile) e).ProcessDelta();
            }
            Packet packet1 = null;
            Packet packet2 = null;
            Packet packet3 = null;
            IPooledEnumerable enumerable1 = map1.GetClientsInRange(e.Location);
            foreach (NetState state1 in enumerable1)
            {
                if (state1.Mobile.CanSee(e))
                {
                    if (Effects.SendParticlesTo(state1))
                    {
                        if (packet1 == null)
                        {
                            packet1 = new TargetParticleEffect(e, 0, 10, 5, 0, 0, 5031, 3, 0);
                        }
                        state1.Send(packet1);
                    }
                    if (packet2 == null)
                    {
                        packet2 = new BoltEffect(e, hue);
                    }
                    state1.Send(packet2);
                    if (sound)
                    {
                        if (packet3 == null)
                        {
                            packet3 = new PlaySound(41, e);
                        }
                        state1.Send(packet3);
                    }
                }
            }
            enumerable1.Free();
        }

        public static void SendLocationEffect(IPoint3D p, Map map, int itemID, int duration)
        {
            Effects.SendLocationEffect(p, map, itemID, duration, 10, 0, 0);
        }

        public static void SendLocationEffect(IPoint3D p, Map map, int itemID, int duration, int speed)
        {
            Effects.SendLocationEffect(p, map, itemID, duration, speed, 0, 0);
        }

        public static void SendLocationEffect(IPoint3D p, Map map, int itemID, int duration, int hue, int renderMode)
        {
            Effects.SendLocationEffect(p, map, itemID, duration, 10, hue, renderMode);
        }

        public static void SendLocationEffect(IPoint3D p, Map map, int itemID, int duration, int speed, int hue, int renderMode)
        {
            Effects.SendPacket(p, map, new LocationEffect(p, itemID, speed, duration, hue, renderMode));
        }

        public static void SendLocationParticles(IEntity e, int itemID, int speed, int duration, int effect)
        {
            Effects.SendLocationParticles(e, itemID, speed, duration, 0, 0, effect, 0);
        }

        public static void SendLocationParticles(IEntity e, int itemID, int speed, int duration, int effect, int unknown)
        {
            Effects.SendLocationParticles(e, itemID, speed, duration, 0, 0, effect, unknown);
        }

        public static void SendLocationParticles(IEntity e, int itemID, int speed, int duration, int hue, int renderMode, int effect, int unknown)
        {
            Map map1 = e.Map;
            if (map1 == null)
            {
                return;
            }
            Packet packet1 = null;
            Packet packet2 = null;
            IPooledEnumerable enumerable1 = map1.GetClientsInRange(e.Location);
            foreach (NetState state1 in enumerable1)
            {
                state1.Mobile.ProcessDelta();
                if (Effects.SendParticlesTo(state1))
                {
                    if (packet1 == null)
                    {
                        packet1 = new LocationParticleEffect(e, itemID, speed, duration, hue, renderMode, effect, unknown);
                    }
                    state1.Send(packet1);
                    continue;
                }
                if (itemID != 0)
                {
                    if (packet2 == null)
                    {
                        packet2 = new LocationEffect(e, itemID, speed, duration, hue, renderMode);
                    }
                    state1.Send(packet2);
                }
            }
            enumerable1.Free();
        }

        public static void SendMovingEffect(IEntity from, IEntity to, int itemID, int speed, int duration, bool fixedDirection, bool explodes)
        {
            Effects.SendMovingEffect(from, to, itemID, speed, duration, fixedDirection, explodes, 0, 0);
        }

        public static void SendMovingEffect(IEntity from, IEntity to, int itemID, int speed, int duration, bool fixedDirection, bool explodes, int hue, int renderMode)
        {
            if ((from is Mobile))
            {
                ((Mobile) from).ProcessDelta();
            }
            if ((to is Mobile))
            {
                ((Mobile) to).ProcessDelta();
            }
            Effects.SendPacket(from.Location, from.Map, new MovingEffect(from, to, itemID, speed, duration, fixedDirection, explodes, hue, renderMode));
        }

        public static void SendMovingParticles(IEntity from, IEntity to, int itemID, int speed, int duration, bool fixedDirection, bool explodes, int effect, int explodeEffect, int explodeSound)
        {
            Effects.SendMovingParticles(from, to, itemID, speed, duration, fixedDirection, explodes, 0, 0, effect, explodeEffect, explodeSound, 0);
        }

        public static void SendMovingParticles(IEntity from, IEntity to, int itemID, int speed, int duration, bool fixedDirection, bool explodes, int effect, int explodeEffect, int explodeSound, int unknown)
        {
            Effects.SendMovingParticles(from, to, itemID, speed, duration, fixedDirection, explodes, 0, 0, effect, explodeEffect, explodeSound, unknown);
        }

        public static void SendMovingParticles(IEntity from, IEntity to, int itemID, int speed, int duration, bool fixedDirection, bool explodes, int hue, int renderMode, int effect, int explodeEffect, int explodeSound, int unknown)
        {
            Effects.SendMovingParticles(from, to, itemID, speed, duration, fixedDirection, explodes, hue, renderMode, effect, explodeEffect, explodeSound, ((EffectLayer) 255), unknown);
        }

        public static void SendMovingParticles(IEntity from, IEntity to, int itemID, int speed, int duration, bool fixedDirection, bool explodes, int hue, int renderMode, int effect, int explodeEffect, int explodeSound, EffectLayer layer, int unknown)
        {
            if ((from is Mobile))
            {
                ((Mobile) from).ProcessDelta();
            }
            if ((to is Mobile))
            {
                ((Mobile) to).ProcessDelta();
            }
            Map map1 = from.Map;
            if (map1 == null)
            {
                return;
            }
            Packet packet1 = null;
            Packet packet2 = null;
            IPooledEnumerable enumerable1 = map1.GetClientsInRange(from.Location);
            foreach (NetState state1 in enumerable1)
            {
                state1.Mobile.ProcessDelta();
                if (Effects.SendParticlesTo(state1))
                {
                    if (packet1 == null)
                    {
                        packet1 = new MovingParticleEffect(from, to, itemID, speed, duration, fixedDirection, explodes, hue, renderMode, effect, explodeEffect, explodeSound, layer, unknown);
                    }
                    state1.Send(packet1);
                    continue;
                }
                if (itemID > 1)
                {
                    if (packet2 == null)
                    {
                        packet2 = new MovingEffect(from, to, itemID, speed, duration, fixedDirection, explodes, hue, renderMode);
                    }
                    state1.Send(packet2);
                }
            }
            enumerable1.Free();
        }

        public static void SendPacket(IPoint3D origin, Map map, Packet p)
        {
            if (map == null)
            {
                return;
            }
            IPooledEnumerable enumerable1 = map.GetClientsInRange(new Point3D(origin));
            foreach (NetState state1 in enumerable1)
            {
                state1.Mobile.ProcessDelta();
                state1.Send(p);
            }
            enumerable1.Free();
        }

        public static void SendPacket(Point3D origin, Map map, Packet p)
        {
            if (map == null)
            {
                return;
            }
            IPooledEnumerable enumerable1 = map.GetClientsInRange(origin);
            foreach (NetState state1 in enumerable1)
            {
                state1.Mobile.ProcessDelta();
                state1.Send(p);
            }
            enumerable1.Free();
        }

        public static bool SendParticlesTo(NetState state)
        {
            if (Effects.m_ParticleSupportType != ParticleSupportType.Full)
            {
                if ((Effects.m_ParticleSupportType == ParticleSupportType.Detect) && (state.Version != null))
                {
                    return (state.Version.Type == ClientType.UOTD);
                }
                return false;
            }
            return true;
        }

        public static void SendTargetEffect(IEntity target, int itemID, int duration)
        {
            Effects.SendTargetEffect(target, itemID, duration, 0, 0);
        }

        public static void SendTargetEffect(IEntity target, int itemID, int speed, int duration)
        {
            Effects.SendTargetEffect(target, itemID, speed, duration, 0, 0);
        }

        public static void SendTargetEffect(IEntity target, int itemID, int duration, int hue, int renderMode)
        {
            Effects.SendTargetEffect(target, itemID, 10, duration, hue, renderMode);
        }

        public static void SendTargetEffect(IEntity target, int itemID, int speed, int duration, int hue, int renderMode)
        {
            if ((target is Mobile))
            {
                ((Mobile) target).ProcessDelta();
            }
            Effects.SendPacket(target.Location, target.Map, new TargetEffect(target, itemID, speed, duration, hue, renderMode));
        }

        public static void SendTargetParticles(IEntity target, int itemID, int speed, int duration, int effect, EffectLayer layer)
        {
            Effects.SendTargetParticles(target, itemID, speed, duration, 0, 0, effect, layer, 0);
        }

        public static void SendTargetParticles(IEntity target, int itemID, int speed, int duration, int effect, EffectLayer layer, int unknown)
        {
            Effects.SendTargetParticles(target, itemID, speed, duration, 0, 0, effect, layer, unknown);
        }

        public static void SendTargetParticles(IEntity target, int itemID, int speed, int duration, int hue, int renderMode, int effect, EffectLayer layer, int unknown)
        {
            if ((target is Mobile))
            {
                ((Mobile) target).ProcessDelta();
            }
            Map map1 = target.Map;
            if (map1 == null)
            {
                return;
            }
            Packet packet1 = null;
            Packet packet2 = null;
            IPooledEnumerable enumerable1 = map1.GetClientsInRange(target.Location);
            foreach (NetState state1 in enumerable1)
            {
                state1.Mobile.ProcessDelta();
                if (Effects.SendParticlesTo(state1))
                {
                    if (packet1 == null)
                    {
                        packet1 = new TargetParticleEffect(target, itemID, speed, duration, hue, renderMode, effect, layer, unknown);
                    }
                    state1.Send(packet1);
                    continue;
                }
                if (itemID != 0)
                {
                    if (packet2 == null)
                    {
                        packet2 = new TargetEffect(target, itemID, speed, duration, hue, renderMode);
                    }
                    state1.Send(packet2);
                }
            }
            enumerable1.Free();
        }


        // Properties
        public static ParticleSupportType ParticleSupportType
        {
            get
            {
                return Effects.m_ParticleSupportType;
            }
            set
            {
                Effects.m_ParticleSupportType = value;
            }
        }


        // Fields
        private static ParticleSupportType m_ParticleSupportType;
    }
}

