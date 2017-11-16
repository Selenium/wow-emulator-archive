namespace Server
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential), Parsable, PropertyObject, NoSort]
    public struct Rectangle2D
    {
        // Methods
        public Rectangle2D(IPoint2D start, IPoint2D end)
        {
            this.m_Start = new Point2D(start);
            this.m_End = new Point2D(end);
        }

        public Rectangle2D(int x, int y, int width, int height)
        {
            this.m_Start = new Point2D(x, y);
            this.m_End = new Point2D((x + width), (y + height));
        }

        public bool Contains(IPoint2D p)
        {
            if (this.m_Start <= p)
            {
                return (this.m_End > p);
            }
            return false;
        }

        public bool Contains(Point2D p)
        {
            if (((this.m_Start.m_X <= p.m_X) && (this.m_Start.m_Y <= p.m_Y)) && (this.m_End.m_X > p.m_X))
            {
                return (this.m_End.m_Y > p.m_Y);
            }
            return false;
        }

        public bool Contains(Point3D p)
        {
            if (((this.m_Start.m_X <= p.m_X) && (this.m_Start.m_Y <= p.m_Y)) && (this.m_End.m_X > p.m_X))
            {
                return (this.m_End.m_Y > p.m_Y);
            }
            return false;
        }

        public void MakeHold(Rectangle2D r)
        {
            if (r.m_Start.m_X < this.m_Start.m_X)
            {
                this.m_Start.m_X = r.m_Start.m_X;
            }
            if (r.m_Start.m_Y < this.m_Start.m_Y)
            {
                this.m_Start.m_Y = r.m_Start.m_Y;
            }
            if (r.m_End.m_X > this.m_End.m_X)
            {
                this.m_End.m_X = r.m_End.m_X;
            }
            if (r.m_End.m_Y > this.m_End.m_Y)
            {
                this.m_End.m_Y = r.m_End.m_Y;
            }
        }

        public static Rectangle2D Parse(string value)
        {
            int num1 = value.IndexOf('(');
            int num2 = value.IndexOf(',', ((int) (num1 + 1)));
            string text1 = value.Substring((num1 + 1), (num2 - (num1 + 1))).Trim();
            num1 = num2;
            num2 = value.IndexOf(',', ((int) (num1 + 1)));
            string text2 = value.Substring((num1 + 1), (num2 - (num1 + 1))).Trim();
            num1 = num2;
            num2 = value.IndexOf(',', ((int) (num1 + 1)));
            string text3 = value.Substring((num1 + 1), (num2 - (num1 + 1))).Trim();
            num1 = num2;
            num2 = value.IndexOf(')', ((int) (num1 + 1)));
            string text4 = value.Substring((num1 + 1), (num2 - (num1 + 1))).Trim();
            return new Rectangle2D(Convert.ToInt32(text1), Convert.ToInt32(text2), Convert.ToInt32(text3), Convert.ToInt32(text4));
        }

        public void Set(int x, int y, int width, int height)
        {
            this.m_Start = new Point2D(x, y);
            this.m_End = new Point2D((x + width), (y + height));
        }

        public override string ToString()
        {
            object[] objArray1 = new object[4];
            objArray1[0] = this.X;
            objArray1[1] = this.Y;
            objArray1[2] = this.Width;
            objArray1[3] = this.Height;
            return string.Format("({0}, {1})+({2}, {3})", objArray1);
        }


        // Properties
        [CommandProperty(AccessLevel.Counselor)]
        public Point2D End
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
                return (this.m_End.m_Y - this.m_Start.m_Y);
            }
            set
            {
                this.m_End.m_Y = (this.m_Start.m_Y + value);
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public Point2D Start
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
                return (this.m_End.m_X - this.m_Start.m_X);
            }
            set
            {
                this.m_End.m_X = (this.m_Start.m_X + value);
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public int X
        {
            get
            {
                return this.m_Start.m_X;
            }
            set
            {
                this.m_Start.m_X = value;
            }
        }

        [CommandProperty(AccessLevel.Counselor)]
        public int Y
        {
            get
            {
                return this.m_Start.m_Y;
            }
            set
            {
                this.m_Start.m_Y = value;
            }
        }


        // Fields
        private Point2D m_End;
        private Point2D m_Start;
    }
}

