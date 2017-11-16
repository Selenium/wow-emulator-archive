namespace Server.Network
{
    using System;

    public class AttributeNormalizer
    {
        // Methods
        static AttributeNormalizer()
        {
            AttributeNormalizer.m_Maximum = 25;
            AttributeNormalizer.m_Enabled = true;
        }

        public AttributeNormalizer()
        {
        }

        public static void Write(PacketWriter stream, int cur, int max)
        {
            if (AttributeNormalizer.m_Enabled && (max != 0))
            {
                stream.Write(((short) AttributeNormalizer.m_Maximum));
                stream.Write(((short) ((cur * AttributeNormalizer.m_Maximum) / max)));
                return;
            }
            stream.Write(((short) max));
            stream.Write(((short) cur));
        }

        public static void WriteReverse(PacketWriter stream, int cur, int max)
        {
            if (AttributeNormalizer.m_Enabled && (max != 0))
            {
                stream.Write(((short) ((cur * AttributeNormalizer.m_Maximum) / max)));
                stream.Write(((short) AttributeNormalizer.m_Maximum));
                return;
            }
            stream.Write(((short) cur));
            stream.Write(((short) max));
        }


        // Properties
        public static bool Enabled
        {
            get
            {
                return AttributeNormalizer.m_Enabled;
            }
            set
            {
                AttributeNormalizer.m_Enabled = value;
            }
        }

        public static int Maximum
        {
            get
            {
                return AttributeNormalizer.m_Maximum;
            }
            set
            {
                AttributeNormalizer.m_Maximum = value;
            }
        }


        // Fields
        private static bool m_Enabled;
        private static int m_Maximum;
    }
}

