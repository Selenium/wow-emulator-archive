namespace Server.Network
{
    using Server;
    using System;

    public sealed class ObjectHelpResponse : Packet
    {
        // Methods
        public ObjectHelpResponse(IEntity e, string text) : base(183)
        {
            base.EnsureCapacity((9 + (text.Length * 2)));
            this.m_Stream.Write(Serial.op_Implicit(e.Serial));
            this.m_Stream.WriteBigUniNull(text);
        }

    }
}

