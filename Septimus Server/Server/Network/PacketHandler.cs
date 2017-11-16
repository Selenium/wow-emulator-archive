namespace Server.Network
{
    using System;

    public class PacketHandler
    {
        // Methods
        public PacketHandler(int packetID, int length, bool ingame, OnPacketReceive onReceive)
        {
            this.m_PacketID = packetID;
            this.m_Length = length;
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

        public int Length
        {
            get
            {
                return this.m_Length;
            }
        }

        public OnPacketReceive OnReceive
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

        public ThrottlePacketCallback ThrottleCallback
        {
            get
            {
                return this.m_ThrottleCallback;
            }
            set
            {
                this.m_ThrottleCallback = value;
            }
        }


        // Fields
        private bool m_Ingame;
        private int m_Length;
        private OnPacketReceive m_OnReceive;
        private int m_PacketID;
        private ThrottlePacketCallback m_ThrottleCallback;
    }
}

