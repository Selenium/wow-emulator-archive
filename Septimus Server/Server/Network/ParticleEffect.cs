namespace Server.Network
{
    using Server;
    using System;

    public class ParticleEffect : Packet
    {
        // Methods
        public ParticleEffect(EffectType type, Serial from, Serial to, int itemID, IPoint3D fromPoint, IPoint3D toPoint, int speed, int duration, bool fixedDirection, bool explode, int hue, int renderMode, int effect, int explodeEffect, int explodeSound, Serial serial, int layer, int unknown) : base(199, 49)
        {
            this.m_Stream.Write(((byte) type));
            this.m_Stream.Write(Serial.op_Implicit(from));
            this.m_Stream.Write(Serial.op_Implicit(to));
            this.m_Stream.Write(((short) itemID));
            this.m_Stream.Write(((short) fromPoint.X));
            this.m_Stream.Write(((short) fromPoint.Y));
            this.m_Stream.Write(((sbyte) fromPoint.Z));
            this.m_Stream.Write(((short) toPoint.X));
            this.m_Stream.Write(((short) toPoint.Y));
            this.m_Stream.Write(((sbyte) toPoint.Z));
            this.m_Stream.Write(((byte) speed));
            this.m_Stream.Write(((byte) duration));
            this.m_Stream.Write(((byte) 0));
            this.m_Stream.Write(((byte) 0));
            this.m_Stream.Write(fixedDirection);
            this.m_Stream.Write(explode);
            this.m_Stream.Write(hue);
            this.m_Stream.Write(renderMode);
            this.m_Stream.Write(((short) effect));
            this.m_Stream.Write(((short) explodeEffect));
            this.m_Stream.Write(((short) explodeSound));
            this.m_Stream.Write(Serial.op_Implicit(serial));
            this.m_Stream.Write(((byte) layer));
            this.m_Stream.Write(((short) unknown));
        }

        public ParticleEffect(EffectType type, Serial from, Serial to, int itemID, Point3D fromPoint, Point3D toPoint, int speed, int duration, bool fixedDirection, bool explode, int hue, int renderMode, int effect, int explodeEffect, int explodeSound, Serial serial, int layer, int unknown) : base(199, 49)
        {
            this.m_Stream.Write(((byte) type));
            this.m_Stream.Write(Serial.op_Implicit(from));
            this.m_Stream.Write(Serial.op_Implicit(to));
            this.m_Stream.Write(((short) itemID));
            this.m_Stream.Write(((short) fromPoint.m_X));
            this.m_Stream.Write(((short) fromPoint.m_Y));
            this.m_Stream.Write(((sbyte) fromPoint.m_Z));
            this.m_Stream.Write(((short) toPoint.m_X));
            this.m_Stream.Write(((short) toPoint.m_Y));
            this.m_Stream.Write(((sbyte) toPoint.m_Z));
            this.m_Stream.Write(((byte) speed));
            this.m_Stream.Write(((byte) duration));
            this.m_Stream.Write(((byte) 0));
            this.m_Stream.Write(((byte) 0));
            this.m_Stream.Write(fixedDirection);
            this.m_Stream.Write(explode);
            this.m_Stream.Write(hue);
            this.m_Stream.Write(renderMode);
            this.m_Stream.Write(((short) effect));
            this.m_Stream.Write(((short) explodeEffect));
            this.m_Stream.Write(((short) explodeSound));
            this.m_Stream.Write(Serial.op_Implicit(serial));
            this.m_Stream.Write(((byte) layer));
            this.m_Stream.Write(((short) unknown));
        }

    }
}

