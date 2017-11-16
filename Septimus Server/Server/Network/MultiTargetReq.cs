namespace Server.Network
{
    using Server;
    using Server.Targeting;
    using System;
    using System.IO;

    public sealed class MultiTargetReq : Packet
    {
        // Methods
        public MultiTargetReq(MultiTarget t) : base(153, 26)
        {
            this.m_Stream.Write(t.AllowGround);
            this.m_Stream.Write(t.TargetID);
            this.m_Stream.Write(((byte) t.Flags));
            this.m_Stream.Fill();
            this.m_Stream.Seek(18, SeekOrigin.Begin);
            this.m_Stream.Write(((short) t.MultiID));
            Point3D pointd1 = t.Offset;
            this.m_Stream.Write(((short) pointd1.X));
            pointd1 = t.Offset;
            this.m_Stream.Write(((short) pointd1.Y));
            pointd1 = t.Offset;
            this.m_Stream.Write(((short) pointd1.Z));
        }

    }
}

