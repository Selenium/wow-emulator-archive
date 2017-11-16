namespace Server.Network
{
    using Server;
    using System;

    public sealed class UnkD3 : Packet
    {
        // Methods
        public UnkD3(Mobile beholder, Mobile beheld) : base(211)
        {
            base.EnsureCapacity(256);
            this.m_Stream.Write(Serial.op_Implicit(beheld.Serial));
            this.m_Stream.Write(((short) Body.op_Implicit(beheld.Body)));
            this.m_Stream.Write(((short) beheld.X));
            this.m_Stream.Write(((short) beheld.Y));
            this.m_Stream.Write(((sbyte) beheld.Z));
            this.m_Stream.Write(((byte) beheld.Direction));
            this.m_Stream.Write(((ushort) beheld.Hue));
            this.m_Stream.Write(((byte) beheld.GetPacketFlags()));
            this.m_Stream.Write(((byte) Notoriety.Compute(beholder, beheld)));
            this.m_Stream.Write(((short) 0));
            this.m_Stream.Write(((short) 0));
            this.m_Stream.Write(((short) 0));
            this.m_Stream.Write(0);
        }

    }
}

