namespace Server.Network
{
    using Server;
    using System;

    public sealed class DisplayProfile : Packet
    {
        // Methods
        public DisplayProfile(bool realSerial, Mobile m, string header, string body, string footer) : base(184)
        {
            if (header == null)
            {
                header = "";
            }
            if (body == null)
            {
                body = "";
            }
            if (footer == null)
            {
                footer = "";
            }
            base.EnsureCapacity((((12 + header.Length) + (footer.Length * 2)) + (body.Length * 2)));
            this.m_Stream.Write(Serial.op_Implicit((realSerial ? m.Serial : Serial.Zero)));
            this.m_Stream.WriteAsciiNull(header);
            this.m_Stream.WriteBigUniNull(footer);
            this.m_Stream.WriteBigUniNull(body);
        }

    }
}

