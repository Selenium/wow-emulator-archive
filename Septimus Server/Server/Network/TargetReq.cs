namespace Server.Network
{
    using Server.Targeting;
    using System;

    public sealed class TargetReq : Packet
    {
        // Methods
        public TargetReq(Target t) : base(108, 19)
        {
            this.m_Stream.Write(t.AllowGround);
            this.m_Stream.Write(t.TargetID);
            this.m_Stream.Write(((byte) t.Flags));
            this.m_Stream.Fill();
        }

    }
}

