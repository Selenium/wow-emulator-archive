namespace Server.Network
{
    using System;

    public sealed class PlayServerAck : Packet
    {
        // Methods
        static PlayServerAck()
        {
            PlayServerAck.m_AuthID = -1;
        }

        public PlayServerAck(ServerInfo si) : base(140, 11)
        {
            int num1 = ((int) si.Address.Address.Address);
            this.m_Stream.Write(((byte) num1));
            this.m_Stream.Write(((byte) (num1 >> 8)));
            this.m_Stream.Write(((byte) (num1 >> 16)));
            this.m_Stream.Write(((byte) (num1 >> 24)));
            this.m_Stream.Write(((short) si.Address.Port));
            this.m_Stream.Write(PlayServerAck.m_AuthID);
        }


        // Fields
        internal static int m_AuthID;
    }
}

