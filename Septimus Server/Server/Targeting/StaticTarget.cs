namespace Server.Targeting
{
    using Server;
    using System;

    public class StaticTarget : IPoint3D, IPoint2D
    {
        // Methods
        public StaticTarget(Point3D location, int itemID)
        {
            this.m_Location = location;
            this.m_ItemID = (itemID & 16383);
            this.m_Location.Z += TileData.ItemTable[this.m_ItemID].CalcHeight;
        }


        // Properties
        [CommandProperty(AccessLevel.Counselor)]
        public TileFlag Flags
        {
            get
            {
                return TileData.ItemTable[this.m_ItemID].Flags;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public int ItemID
        {
            get
            {
                return this.m_ItemID;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Point3D Location
        {
            get
            {
                return this.m_Location;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public string Name
        {
            get
            {
                return TileData.ItemTable[this.m_ItemID].Name;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public int X
        {
            get
            {
                return this.m_Location.X;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public int Y
        {
            get
            {
                return this.m_Location.Y;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public int Z
        {
            get
            {
                return this.m_Location.Z;
            }
        }


        // Fields
        private int m_ItemID;
        private Point3D m_Location;
    }
}

