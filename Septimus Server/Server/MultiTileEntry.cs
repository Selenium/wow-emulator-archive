namespace Server
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct MultiTileEntry
    {
        // Methods
        public MultiTileEntry(short itemID, short xOffset, short yOffset, short zOffset, int flags)
        {
            this.m_ItemID = itemID;
            this.m_OffsetX = xOffset;
            this.m_OffsetY = yOffset;
            this.m_OffsetZ = zOffset;
            this.m_Flags = flags;
        }


        // Fields
        public int m_Flags;
        public short m_ItemID;
        public short m_OffsetX;
        public short m_OffsetY;
        public short m_OffsetZ;
    }
}

