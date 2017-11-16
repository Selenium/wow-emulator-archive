namespace Server.Network
{
    using Server;
    using System;

    public sealed class BoltEffect : Packet
    {
        // Methods
        public BoltEffect(IEntity target, int hue) : base(192, 36)
        {
            this.m_Stream.Write(((byte) 1));
            this.m_Stream.Write(Serial.op_Implicit(target.Serial));
            this.m_Stream.Write(Serial.op_Implicit(Serial.Zero));
            this.m_Stream.Write(((short) 0));
            this.m_Stream.Write(((short) target.X));
            this.m_Stream.Write(((short) target.Y));
            this.m_Stream.Write(((sbyte) target.Z));
            this.m_Stream.Write(((short) target.X));
            this.m_Stream.Write(((short) target.Y));
            this.m_Stream.Write(((sbyte) target.Z));
            this.m_Stream.Write(((byte) 0));
            this.m_Stream.Write(((byte) 0));
            this.m_Stream.Write(((short) 0));
            this.m_Stream.Write(false);
            this.m_Stream.Write(false);
            this.m_Stream.Write(hue);
            this.m_Stream.Write(0);
        }

    }
}

