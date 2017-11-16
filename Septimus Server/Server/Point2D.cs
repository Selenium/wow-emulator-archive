namespace Server
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), Parsable]
    public struct Point2D : IPoint2D
    {
        // Methods
        static Point2D()
        {
            Point2D.Zero = new Point2D(0, 0);
        }

        public Point2D(IPoint2D p) : this(p.X, p.Y)
        {
        }

        public Point2D(int x, int y)
        {
            this.m_X = x;
            this.m_Y = y;
        }

        public override bool Equals(object o)
        {
            if ((o == null) || !(o is IPoint2D))
            {
                return false;
            }
            IPoint2D pointd1 = ((IPoint2D) o);
            if (this.m_X == pointd1.X)
            {
                return (this.m_Y == pointd1.Y);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (this.m_X ^ this.m_Y);
        }

        public static bool operator ==(Point2D l, IPoint2D r)
        {
            if (l.m_X == r.X)
            {
                return (l.m_Y == r.Y);
            }
            return false;
        }

        public static bool operator ==(Point2D l, Point2D r)
        {
            if (l.m_X == r.m_X)
            {
                return (l.m_Y == r.m_Y);
            }
            return false;
        }

        public static bool operator >(Point2D l, IPoint2D r)
        {
            if (l.m_X > r.X)
            {
                return (l.m_Y > r.Y);
            }
            return false;
        }

        public static bool operator >(Point2D l, Point2D r)
        {
            if (l.m_X > r.m_X)
            {
                return (l.m_Y > r.m_Y);
            }
            return false;
        }

        public static bool operator >(Point2D l, Point3D r)
        {
            if (l.m_X > r.m_X)
            {
                return (l.m_Y > r.m_Y);
            }
            return false;
        }

        public static bool operator >=(Point2D l, IPoint2D r)
        {
            if (l.m_X >= r.X)
            {
                return (l.m_Y >= r.Y);
            }
            return false;
        }

        public static bool operator >=(Point2D l, Point2D r)
        {
            if (l.m_X >= r.m_X)
            {
                return (l.m_Y >= r.m_Y);
            }
            return false;
        }

        public static bool operator >=(Point2D l, Point3D r)
        {
            if (l.m_X >= r.m_X)
            {
                return (l.m_Y >= r.m_Y);
            }
            return false;
        }

        public static bool operator !=(Point2D l, IPoint2D r)
        {
            if (l.m_X == r.X)
            {
                return (l.m_Y != r.Y);
            }
            return true;
        }

        public static bool operator !=(Point2D l, Point2D r)
        {
            if (l.m_X == r.m_X)
            {
                return (l.m_Y != r.m_Y);
            }
            return true;
        }

        public static bool operator <(Point2D l, IPoint2D r)
        {
            if (l.m_X < r.X)
            {
                return (l.m_Y < r.Y);
            }
            return false;
        }

        public static bool operator <(Point2D l, Point2D r)
        {
            if (l.m_X < r.m_X)
            {
                return (l.m_Y < r.m_Y);
            }
            return false;
        }

        public static bool operator <(Point2D l, Point3D r)
        {
            if (l.m_X < r.m_X)
            {
                return (l.m_Y < r.m_Y);
            }
            return false;
        }

        public static bool operator <=(Point2D l, IPoint2D r)
        {
            if (l.m_X <= r.X)
            {
                return (l.m_Y <= r.Y);
            }
            return false;
        }

        public static bool operator <=(Point2D l, Point2D r)
        {
            if (l.m_X <= r.m_X)
            {
                return (l.m_Y <= r.m_Y);
            }
            return false;
        }

        public static bool operator <=(Point2D l, Point3D r)
        {
            if (l.m_X <= r.m_X)
            {
                return (l.m_Y <= r.m_Y);
            }
            return false;
        }

        public static Point2D Parse(string value)
        {
            int num1 = value.IndexOf('(');
            int num2 = value.IndexOf(',', ((int) (num1 + 1)));
            string text1 = value.Substring((num1 + 1), (num2 - (num1 + 1))).Trim();
            num1 = num2;
            num2 = value.IndexOf(')', ((int) (num1 + 1)));
            string text2 = value.Substring((num1 + 1), (num2 - (num1 + 1))).Trim();
            return new Point2D(Convert.ToInt32(text1), Convert.ToInt32(text2));
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", this.m_X, this.m_Y);
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


        // Fields
        internal int m_X;
        internal int m_Y;
        public static readonly Point2D Zero;
    }
}

