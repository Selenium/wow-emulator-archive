namespace Server.Network
{
    using Server;
    using System;

    public sealed class MapChange : Packet
    {
        // Methods
        public MapChange(Mobile m) : base(191)
        {
            base.EnsureCapacity(6);
            this.m_Stream.Write(((short) 8));
            this.m_Stream.Write(((byte) ((m.Map == null) ? 0 : m.Map.MapID)));
        }

    }
}

