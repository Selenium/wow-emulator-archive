namespace Server
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), PropertyObject, NoSort]
    public struct Rectangle3D
    {
        // Methods
        public Rectangle3D(Point3D start, Point3D end)
        {
            this.m_Start = start;
            this.m_End = end;
        }

        public Rectangle3D(int x, int y, int z, int width, int height, int depth)
        {
            this.m_Start = new Point3D(x, y, z);
            this.m_End = new Point3D((x + width), (y + height), (z + depth));
        }

        public bool Contains(IPoint3D p)
        {
            if ((((p.X >= this.m_Start.X) && (p.X < this.m_End.X)) && ((p.Y >= this.m_Start.Y) && (p.Y < this.m_End.Y))) && (p.Z >= this.m_Start.Z))
            {
                return (p.Z < this.m_End.Z);
            }
            return false;
        }


        // Properties
        [CommandProperty(AccessLevel.Counselor)]
        public int Depth
        {
            get
            {
                return (this.m_End.Z - this.m_Start.Z);
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Point3D End
        {
            get
            {
                return this.m_End;
            }
            set
            {
                this.m_End = value;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public int Height
        {
            get
            {
                return (this.m_End.Y - this.m_Start.Y);
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Point3D Start
        {
            get
            {
                return this.m_Start;
            }
            set
            {
                this.m_Start = value;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public int Width
        {
            get
            {
                return (this.m_End.X - this.m_Start.X);
            }
        }


        // Fields
        private Point3D m_End;
        private Point3D m_Start;
    }
}

