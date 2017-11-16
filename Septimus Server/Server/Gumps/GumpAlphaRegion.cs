namespace Server.Gumps
{
    using Server.Network;
    using System;

    public class GumpAlphaRegion : GumpEntry
    {
        // Methods
        static GumpAlphaRegion()
        {
            GumpAlphaRegion.m_LayoutName = Gump.StringToBuffer("checkertrans");
        }

        public GumpAlphaRegion(int x, int y, int width, int height)
        {
            this.m_X = x;
            this.m_Y = y;
            this.m_Width = width;
            this.m_Height = height;
        }

        public override void AppendTo(DisplayGumpFast disp)
        {
            disp.AppendLayout(GumpAlphaRegion.m_LayoutName);
            disp.AppendLayout(this.m_X);
            disp.AppendLayout(this.m_Y);
            disp.AppendLayout(this.m_Width);
            disp.AppendLayout(this.m_Height);
        }

        public override string Compile()
        {
            object[] objArray1 = new object[4];
            objArray1[0] = this.m_X;
            objArray1[1] = this.m_Y;
            objArray1[2] = this.m_Width;
            objArray1[3] = this.m_Height;
            return string.Format("{{ checkertrans {0} {1} {2} {3} }}", objArray1);
        }


        // Properties
        public int Height
        {
            get
            {
                return this.m_Height;
            }
            set
            {
                base.Delta(ref this.m_Height, value);
            }
        }

        public int Width
        {
            get
            {
                return this.m_Width;
            }
            set
            {
                base.Delta(ref this.m_Width, value);
            }
        }

        public int X
        {
            get
            {
                return this.m_X;
            }
            set
            {
                base.Delta(ref this.m_X, value);
            }
        }

        public int Y
        {
            get
            {
                return this.m_Y;
            }
            set
            {
                base.Delta(ref this.m_Y, value);
            }
        }


        // Fields
        private int m_Height;
        private static byte[] m_LayoutName;
        private int m_Width;
        private int m_X;
        private int m_Y;
    }
}

