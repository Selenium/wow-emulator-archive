namespace Server.Network
{
    using System;

    public sealed class CloseGump : Packet
    {
        // Methods
        public CloseGump(int typeID, int buttonID) : base(191)
        {
            base.EnsureCapacity(13);
            this.m_Stream.Write(((short) 4));
            this.m_Stream.Write(typeID);
            this.m_Stream.Write(buttonID);
        }

    }
}

