namespace Server.Network
{
    using System;

    public sealed class CancelTarget : Packet
    {
        // Methods
        public CancelTarget() : base(108, 19)
        {
            this.m_Stream.Write(((byte) 0));
            this.m_Stream.Write(0);
            this.m_Stream.Write(((byte) 3));
            this.m_Stream.Fill();
        }


        // Properties
        public static Packet Instance
        {
            get
            {
                if (CancelTarget.m_Instance == null)
                {
                    CancelTarget.m_Instance = new CancelTarget();
                }
                return CancelTarget.m_Instance;
            }
        }


        // Fields
        private static Packet m_Instance;
    }
}

