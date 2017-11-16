namespace Server.Network
{
    using Server;
    using System;

    public sealed class MobileStatusCompact : Packet
    {
        // Methods
        public MobileStatusCompact(bool canBeRenamed, Mobile m) : base(17)
        {
            string text1 = m.Name;
            if (text1 == null)
            {
                text1 = "";
            }
            base.EnsureCapacity(43);
            this.m_Stream.Write(Serial.op_Implicit(m.Serial));
            this.m_Stream.WriteAsciiFixed(text1, 30);
            AttributeNormalizer.WriteReverse(this.m_Stream, m.Hits, m.HitsMax);
            this.m_Stream.Write(canBeRenamed);
            this.m_Stream.Write(((byte) 0));
        }

    }
}

