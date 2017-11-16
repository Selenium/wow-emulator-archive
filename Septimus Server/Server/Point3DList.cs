namespace Server
{
    using System;
    using System.Reflection;

    public class Point3DList
    {
        // Methods
        static Point3DList()
        {
            Point3DList.m_EmptyList = new Point3D[0];
        }

        public Point3DList()
        {
            this.m_List = new Point3D[8];
            this.m_Count = 0;
        }

        public void Add(Point3D p)
        {
            Point3D[] pointdArray1;
            int num1;
            if ((this.m_Count + 1) > this.m_List.Length)
            {
                pointdArray1 = this.m_List;
                this.m_List = new Point3D[(pointdArray1.Length * 2)];
                for (num1 = 0; (num1 < pointdArray1.Length); ++num1)
                {
                    this.m_List[num1] = pointdArray1[num1];
                }
            }
            this.m_List[this.m_Count].m_X = p.m_X;
            this.m_List[this.m_Count].m_Y = p.m_Y;
            this.m_List[this.m_Count].m_Z = p.m_Z;
            ++this.m_Count;
        }

        public void Add(int x, int y, int z)
        {
            Point3D[] pointdArray1;
            int num1;
            if ((this.m_Count + 1) > this.m_List.Length)
            {
                pointdArray1 = this.m_List;
                this.m_List = new Point3D[(pointdArray1.Length * 2)];
                for (num1 = 0; (num1 < pointdArray1.Length); ++num1)
                {
                    this.m_List[num1] = pointdArray1[num1];
                }
            }
            this.m_List[this.m_Count].m_X = x;
            this.m_List[this.m_Count].m_Y = y;
            this.m_List[this.m_Count].m_Z = z;
            ++this.m_Count;
        }

        public void Clear()
        {
            this.m_Count = 0;
        }

        public Point3D[] ToArray()
        {
            int num1;
            if (this.m_Count == 0)
            {
                return Point3DList.m_EmptyList;
            }
            Point3D[] pointdArray1 = new Point3D[this.m_Count];
            for (num1 = 0; (num1 < this.m_Count); ++num1)
            {
                pointdArray1[num1] = this.m_List[num1];
            }
            this.m_Count = 0;
            return pointdArray1;
        }


        // Properties
        public int Count
        {
            get
            {
                return this.m_Count;
            }
        }

        public Point3D this[int index]
        {
            get
            {
                return this.m_List[index];
            }
        }

        public Point3D Last
        {
            get
            {
                return this.m_List[(this.m_Count - 1)];
            }
        }


        // Fields
        private int m_Count;
        private static Point3D[] m_EmptyList;
        private Point3D[] m_List;
    }
}

