namespace Server.Network
{
    using System;

    public sealed class SupportedFeatures : Packet
    {
        // Methods
        static SupportedFeatures()
        {
            SupportedFeatures.m_Value = 32799;
        }

        public SupportedFeatures() : base(185, 3)
        {
            this.m_Stream.Write(((ushort) SupportedFeatures.m_Value));
        }

        public static SupportedFeatures Instantiate()
        {
            if (SupportedFeatures.m_Instance == null)
            {
                SupportedFeatures.m_Instance = new SupportedFeatures();
            }
            return SupportedFeatures.m_Instance;
        }


        // Properties
        public static int Value
        {
            get
            {
                return SupportedFeatures.m_Value;
            }
            set
            {
                SupportedFeatures.m_Value = value;
                SupportedFeatures.m_Instance = null;
            }
        }


        // Fields
        private static SupportedFeatures m_Instance;
        private static int m_Value;
    }
}

