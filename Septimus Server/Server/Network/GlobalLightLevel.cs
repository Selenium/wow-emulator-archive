namespace Server.Network
{
    using System;

    public sealed class GlobalLightLevel : Packet
    {
        // Methods
        static GlobalLightLevel()
        {
            GlobalLightLevel.m_Cache = new GlobalLightLevel[256];
        }

        public GlobalLightLevel(int level) : base(79, 2)
        {
            this.m_Stream.Write(((sbyte) level));
        }

        public static GlobalLightLevel Instantiate(int level)
        {
            byte num1 = ((byte) level);
            GlobalLightLevel level1 = GlobalLightLevel.m_Cache[num1];
            if (level1 == null)
            {
                GlobalLightLevel.m_Cache[num1] = (level1 = new GlobalLightLevel(level));
            }
            return level1;
        }


        // Fields
        private static GlobalLightLevel[] m_Cache;
    }
}

