namespace Server.Network
{
    using Server;
    using System;

    public sealed class DisplaySignGump : Packet
    {
        // Methods
        public DisplaySignGump(Serial serial, int gumpID, string unknown, string caption) : base(139)
        {
            if (unknown == null)
            {
                unknown = "";
            }
            if (caption == null)
            {
                caption = "";
            }
            base.EnsureCapacity(((16 + unknown.Length) + caption.Length));
            this.m_Stream.Write(Serial.op_Implicit(serial));
            this.m_Stream.Write(((short) gumpID));
            this.m_Stream.Write(((short) unknown.Length));
            this.m_Stream.WriteAsciiFixed(unknown, unknown.Length);
            this.m_Stream.Write(((short) (caption.Length + 1)));
            this.m_Stream.WriteAsciiFixed(caption, (caption.Length + 1));
        }

    }
}

