namespace Server.Gumps
{
    using Server.Network;
    using System;

    public class GumpBackground : GumpEntry
    {
        // Methods
        static GumpBackground()
        {
            GumpBackground.m_LayoutName = Gump.StringToBuffer("resizepic");
        }

        public GumpBackground(int x, int y, int width, int height, int gumpID)
        {
            this.m_X = x;
            this.m_Y = y;
            this.m_Width = width;
            this.m_Height = height;
            this.m_GumpID = gumpID;
        }

        public override void AppendTo(DisplayGumpFast disp)
        {
            disp.AppendLayout(GumpBackground.m_LayoutName);
            disp.AppendLayout(this.m_X);
            disp.AppendLayout(this.m_Y);
            disp.AppendLayout(this.m_GumpID);
            disp.AppendLayout(this.m_Width);
            disp.AppendLayout(this.m_Height);
        }

        public override string Compile()
        {
            object[] objArray1 = new object[5];
            objArray1[0] = this.m_X;
            objArray1[1] = this.m_Y;
            objArray1[2] = this.m_GumpID;
            objArray1[3] = this.m_Width;
            objArray1[4] = this.m_Height;
            return string.Format("{{ resizepic {0} {1} {2} {3} {4} }}", objArray1);
        }


        // Properties
        public int GumpID
        {
            get
            {
                return this.m_GumpID;
            }
            set
            {
                base.Delta(ref this.m_GumpID, value);
            }
        }

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
        private int m_GumpID;
        private int m_Height;
        private static byte[] m_LayoutName;
        private int m_Width;
        private int m_X;
        private int m_Y;
    }
}

