namespace Server.Gumps
{
    using Server.Network;
    using System;

    public class GumpImage : GumpEntry
    {
        // Methods
        static GumpImage()
        {
            GumpImage.m_LayoutName = Gump.StringToBuffer("gumppic");
            GumpImage.m_HueEquals = Gump.StringToBuffer(" hue=");
        }

        public GumpImage(int x, int y, int gumpID) : this(x, y, gumpID, 0)
        {
        }

        public GumpImage(int x, int y, int gumpID, int hue)
        {
            this.m_X = x;
            this.m_Y = y;
            this.m_GumpID = gumpID;
            this.m_Hue = hue;
        }

        public override void AppendTo(DisplayGumpFast disp)
        {
            disp.AppendLayout(GumpImage.m_LayoutName);
            disp.AppendLayout(this.m_X);
            disp.AppendLayout(this.m_Y);
            disp.AppendLayout(this.m_GumpID);
            if (this.m_Hue != 0)
            {
                disp.AppendLayout(GumpImage.m_HueEquals);
                disp.AppendLayoutNS(this.m_Hue);
            }
        }

        public override string Compile()
        {
            if (this.m_Hue == 0)
            {
                return string.Format("{{ gumppic {0} {1} {2} }}", this.m_X, this.m_Y, this.m_GumpID);
            }
            object[] objArray1 = new object[4];
            objArray1[0] = this.m_X;
            objArray1[1] = this.m_Y;
            objArray1[2] = this.m_GumpID;
            objArray1[3] = this.m_Hue;
            return string.Format("{{ gumppic {0} {1} {2} hue={3} }}", objArray1);
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

        public int Hue
        {
            get
            {
                return this.m_Hue;
            }
            set
            {
                base.Delta(ref this.m_Hue, value);
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
        private int m_Hue;
        private static byte[] m_HueEquals;
        private static byte[] m_LayoutName;
        private int m_X;
        private int m_Y;
    }
}

