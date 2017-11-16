namespace Server.Network
{
    using Server;
    using System;

    public sealed class PlaySound : Packet
    {
        // Methods
        public PlaySound(int soundID, IPoint3D target) : base(84, 12)
        {
            this.m_Stream.Write(((byte) 1));
            this.m_Stream.Write(((short) soundID));
            this.m_Stream.Write(((short) 0));
            this.m_Stream.Write(((short) target.X));
            this.m_Stream.Write(((short) target.Y));
            this.m_Stream.Write(((short) target.Z));
        }

    }
}

