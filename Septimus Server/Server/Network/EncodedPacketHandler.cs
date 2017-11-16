namespace Server.Network
{
    using System;

    public class EncodedPacketHandler
    {
        // Methods
        public EncodedPacketHandler(int packetID, bool ingame, OnEncodedPacketReceive onReceive)
        {
            this.m_PacketID = packetID;
            this.m_Ingame = ingame;
            this.m_OnReceive = onReceive;
        }


        // Properties
        public bool Ingame
        {
            get
            {
                return this.m_Ingame;
            }
        }

        public OnEncodedPacketReceive OnReceive
        {
            get
            {
                return this.m_OnReceive;
            }
        }

        public int PacketID
        {
            get
            {
                return this.m_PacketID;
            }
        }


        // Fields
        private bool m_Ingame;
        private OnEncodedPacketReceive m_OnReceive;
        private int m_PacketID;
    }
}

