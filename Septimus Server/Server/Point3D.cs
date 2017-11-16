namespace Server
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), Parsable]
    public struct Point3D : IPoint3D, IPoint2D
    {
        // Methods
        static Point3D()
        {
            Point3D.Zero = new Point3D(0, 0, 0);
        }

        public Point3D(IPoint3D p) : this(p.X, p.Y, p.Z)
        {
        }

        public Point3D(IPoint2D p, int z) : this(p.X, p.Y, z)
        {
        }

        public Point3D(int x, int y, int z)
        {
            this.m_X = x;
            this.m_Y = y;
            this.m_Z = z;
        }

        public override bool Equals(object o)
        {
            if ((o == null) || !(o is IPoint3D))
            {
                return false;
            }
            IPoint3D pointd1 = ((IPoint3D) o);
            if ((this.m_X == pointd1.X) && (this.m_Y == pointd1.Y))
            {
                return (this.m_Z == pointd1.Z);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ((this.m_X ^ this.m_Y) ^ this.m_Z);
        }

        public static bool operator ==(Point3D l, IPoint3D r)
        {
            if ((l.m_X == r.X) && (l.m_Y == r.Y))
            {
                return (l.m_Z == r.Z);
            }
            return false;
        }

        public static bool operator ==(Point3D l, Point3D r)
        {
            if ((l.m_X == r.m_X) && (l.m_Y == r.m_Y))
            {
                return (l.m_Z == r.m_Z);
            }
            return false;
        }

        public static bool operator !=(Point3D l, IPoint3D r)
        {
            if ((l.m_X == r.X) && (l.m_Y == r.Y))
            {
                return (l.m_Z != r.Z);
            }
            return true;
        }

        public static bool operator !=(Point3D l, Point3D r)
        {
            if ((l.m_X == r.m_X) && (l.m_Y == r.m_Y))
            {
                return (l.m_Z != r.m_Z);
            }
            return true;
        }

        public static Point3D Parse(string value)
        {
            int num1 = value.IndexOf('(');
            int num2 = value.IndexOf(',', ((int) (num1 + 1)));
            string text1 = value.Substring((num1 + 1), (num2 - (num1 + 1))).Trim();
            num1 = num2;
            num2 = value.IndexOf(',', ((int) (num1 + 1)));
            string text2 = value.Substring((num1 + 1), (num2 - (num1 + 1))).Trim();
            num1 = num2;
            num2 = value.IndexOf(')', ((int) (num1 + 1)));
            string text3 = value.Substring((num1 + 1), (num2 - (num1 + 1))).Trim();
            return new Point3D(Convert.ToInt32(text1), Convert.ToInt32(text2), Convert.ToInt32(text3));
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", this.m_X, this.m_Y, this.m_Z);
        }


        // Properties
        [CommandProperty(AccessLevel.Counselor)]
        public int X
        {
            get
            {
                return this.m_X;
            }
            set
            {
                this.m_X = value;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public int Y
        {
            get
            {
                return this.m_Y;
            }
            set
            {
                this.m_Y = value;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public int Z
        {
            get
            {
                return this.m_Z;
            }
            set
            {
                this.m_Z = value;
            }
        }


        // Fields
        internal int m_X;
        internal int m_Y;
        internal int m_Z;
        public static readonly Point3D Zero;
    }
}

