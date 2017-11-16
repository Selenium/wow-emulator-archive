namespace Server.Network
{
    using Server;
    using System;

    public sealed class DragEffect : Packet
    {
        // Methods
        public DragEffect(IEntity src, IEntity trg, int itemID, int hue, int amount) : base(35, 26)
        {
            this.m_Stream.Write(((short) itemID));
            this.m_Stream.Write(((byte) 0));
            this.m_Stream.Write(((short) hue));
            this.m_Stream.Write(((short) amount));
            this.m_Stream.Write(Serial.op_Implicit(src.Serial));
            this.m_Stream.Write(((short) src.X));
            this.m_Stream.Write(((short) src.Y));
            this.m_Stream.Write(((sbyte) src.Z));
            this.m_Stream.Write(Serial.op_Implicit(trg.Serial));
            this.m_Stream.Write(((short) trg.X));
            this.m_Stream.Write(((short) trg.Y));
            this.m_Stream.Write(((sbyte) trg.Z));
        }

    }
}

