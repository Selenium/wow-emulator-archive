namespace Server.Network
{
    using System;

    public sealed class ChangeUpdateRange : Packet
    {
        // Methods
        static ChangeUpdateRange()
        {
            ChangeUpdateRange.m_Cache = new ChangeUpdateRange[256];
        }

        public ChangeUpdateRange(int range) : base(200, 2)
        {
            this.m_Stream.Write(((byte) range));
        }

        public static ChangeUpdateRange Instantiate(int range)
        {
            byte num1 = ((byte) range);
            ChangeUpdateRange range1 = ChangeUpdateRange.m_Cache[num1];
            if (range1 == null)
            {
                ChangeUpdateRange.m_Cache[num1] = (range1 = new ChangeUpdateRange(range));
            }
            return range1;
        }


        // Fields
        private static ChangeUpdateRange[] m_Cache;
    }
}

