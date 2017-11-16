namespace Server
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct Tile
    {
        // Methods
        public Tile(short id, sbyte z)
        {
            this.m_ID = id;
            this.m_Z = z;
        }

        public void Set(short id, sbyte z)
        {
            this.m_ID = id;
            this.m_Z = z;
        }


        // Properties
        public int Height
        {
            get
            {
                if (this.m_ID < 16384)
                {
                    return 0;
                }
                return TileData.ItemTable[(this.m_ID & 16383)].Height;
            }
        }

        public int ID
        {
            get
            {
                return this.m_ID;
            }
        }

        public bool Ignored
        {
            get
            {
                if ((this.m_ID != 2) && (this.m_ID != 475))
                {
                    if (this.m_ID >= 430)
                    {
                        return (this.m_ID <= 437);
                    }
                    return false;
                }
                return true;
            }
        }

        public int Z
        {
            get
            {
                return this.m_Z;
            }
            set
            {
                this.m_Z = ((sbyte) value);
            }
        }


        // Fields
        internal short m_ID;
        internal sbyte m_Z;
    }
}

