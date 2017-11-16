namespace Server.Network
{
    using Server;
    using System;

    public sealed class PathfindMessage : Packet
    {
        // Methods
        public PathfindMessage(IPoint3D p) : base(56, 7)
        {
            this.m_Stream.Write(((short) p.X));
            this.m_Stream.Write(((short) p.Y));
            this.m_Stream.Write(((short) p.Z));
        }

    }
}

