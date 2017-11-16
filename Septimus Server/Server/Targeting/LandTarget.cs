namespace Server.Targeting
{
    using Server;
    using System;

    public class LandTarget : IPoint3D, IPoint2D
    {
        // Methods
        public LandTarget(Point3D location, Map map)
        {
            Tile tile1;
            this.m_Location = location;
            if (map != null)
            {
                this.m_Location.Z = map.GetAverageZ(this.m_Location.X, this.m_Location.Y);
                tile1 = map.Tiles.GetLandTile(this.m_Location.X, this.m_Location.Y);
                this.m_TileID = (tile1.ID & 16383);
            }
        }


        // Properties
        [CommandProperty(AccessLevel.Counselor)]
        public TileFlag Flags
        {
            get
            {
                return TileData.LandTable[this.m_TileID].Flags;
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
                return TileData.LandTable[this.m_TileID].Name;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public int TileID
        {
            get
            {
                return this.m_TileID;
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
        private Point3D m_Location;
        private int m_TileID;
    }
}

