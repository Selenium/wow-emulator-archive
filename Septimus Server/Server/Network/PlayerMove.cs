namespace Server.Network
{
    using Server;
    using System;

    public sealed class PlayerMove : Packet
    {
        // Methods
        public PlayerMove(Direction d) : base(151, 2)
        {
            this.m_Stream.Write(((byte) d));
        }

    }
}

