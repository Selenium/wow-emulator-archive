namespace Server
{
    using System;

    public class Entity : IEntity, IPoint3D, IPoint2D
    {
        // Methods
        public Entity(Serial serial, Point3D loc, Map map)
        {
            this.m_Serial = serial;
            this.m_Location = loc;
            this.m_Map = map;
        }


        // Properties
        public Point3D Location
        {
            get
            {
                return this.m_Location;
            }
        }

        public Map Map
        {
            get
            {
                return this.m_Map;
            }
        }

        public Serial Serial
        {
            get
            {
                return this.m_Serial;
            }
        }

        public int X
        {
            get
            {
                return this.m_Location.X;
            }
        }

        public int Y
        {
            get
            {
                return this.m_Location.Y;
            }
        }

        public int Z
        {
            get
            {
                return this.m_Location.Z;
            }
        }


        // Fields
        private Point3D m_Location;
        private Map m_Map;
        private Serial m_Serial;
    }
}

