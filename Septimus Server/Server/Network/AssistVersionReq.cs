namespace Server.Network
{
    using System;

    public sealed class AssistVersionReq : Packet
    {
        // Methods
        public AssistVersionReq(int unk) : base(190)
        {
            base.EnsureCapacity(7);
            this.m_Stream.Write(unk);
        }

    }
}

