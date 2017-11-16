namespace Server.Network
{
    using Server;
    using System;

    public sealed class CityInfo
    {
        // Methods
        public CityInfo(string city, string building, int x, int y, int z)
        {
            this.m_City = city;
            this.m_Building = building;
            this.m_Location = new Point3D(x, y, z);
        }


        // Properties
        public string Building
        {
            get
            {
                return this.m_Building;
            }
            set
            {
                this.m_Building = value;
            }
        }

        public string City
        {
            get
            {
                return this.m_City;
            }
            set
            {
                this.m_City = value;
            }
        }

        public Point3D Location
        {
            get
            {
                return this.m_Location;
            }
            set
            {
                this.m_Location = value;
            }
        }

        public int X
        {
            get
            {
                return this.m_Location.X;
            }
            set
            {
                this.m_Location.X = value;
            }
        }

        public int Y
        {
            get
            {
                return this.m_Location.Y;
            }
            set
            {
                this.m_Location.Y = value;
            }
        }

        public int Z
        {
            get
            {
                return this.m_Location.Z;
            }
            set
            {
                this.m_Location.Z = value;
            }
        }


        // Fields
        private string m_Building;
        private string m_City;
        private Point3D m_Location;
    }
}

