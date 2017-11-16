namespace Server.Gumps
{
    using Server.Network;
    using System;

    public class GumpHtmlLocalized : GumpEntry
    {
        // Methods
        static GumpHtmlLocalized()
        {
            GumpHtmlLocalized.m_LayoutNameColor = Gump.StringToBuffer("xmfhtmlgumpcolor");
            GumpHtmlLocalized.m_LayoutName = Gump.StringToBuffer("xmfhtmlgump");
        }

        public GumpHtmlLocalized(int x, int y, int width, int height, int number, bool background, bool scrollbar)
        {
            this.m_X = x;
            this.m_Y = y;
            this.m_Width = width;
            this.m_Height = height;
            this.m_Number = number;
            this.m_Background = background;
            this.m_Scrollbar = scrollbar;
        }

        public GumpHtmlLocalized(int x, int y, int width, int height, int number, int color, bool background, bool scrollbar)
        {
            this.m_X = x;
            this.m_Y = y;
            this.m_Width = width;
            this.m_Height = height;
            this.m_Number = number;
            this.m_Background = background;
            this.m_Scrollbar = scrollbar;
            this.m_Color = color;
            this.m_UseColor = true;
        }

        public override void AppendTo(DisplayGumpFast disp)
        {
            disp.AppendLayout((this.m_UseColor ? GumpHtmlLocalized.m_LayoutNameColor : GumpHtmlLocalized.m_LayoutName));
            disp.AppendLayout(this.m_X);
            disp.AppendLayout(this.m_Y);
            disp.AppendLayout(this.m_Width);
            disp.AppendLayout(this.m_Height);
            disp.AppendLayout(this.m_Number);
            disp.AppendLayout(this.m_Background);
            disp.AppendLayout(this.m_Scrollbar);
            if (this.m_UseColor)
            {
                disp.AppendLayout(this.m_Color);
            }
        }

        public override string Compile()
        {
            object[] objArray1;
            if (this.m_UseColor)
            {
                objArray1 = new object[8];
                objArray1[0] = this.m_X;
                objArray1[1] = this.m_Y;
                objArray1[2] = this.m_Width;
                objArray1[3] = this.m_Height;
                objArray1[4] = this.m_Number;
                objArray1[5] = (this.m_Background ? 1 : 0);
                objArray1[6] = (this.m_Scrollbar ? 1 : 0);
                objArray1[7] = this.m_Color;
                return string.Format("{{ xmfhtmlgumpcolor {0} {1} {2} {3} {4} {5} {6} {7} }}", objArray1);
            }
            objArray1 = new object[7];
            objArray1[0] = this.m_X;
            objArray1[1] = this.m_Y;
            objArray1[2] = this.m_Width;
            objArray1[3] = this.m_Height;
            objArray1[4] = this.m_Number;
            objArray1[5] = (this.m_Background ? 1 : 0);
            objArray1[6] = (this.m_Scrollbar ? 1 : 0);
            return string.Format("{{ xmfhtmlgump {0} {1} {2} {3} {4} {5} {6} }}", objArray1);
        }


        // Properties
        public bool Background
        {
            get
            {
                return this.m_Background;
            }
            set
            {
                base.Delta(ref this.m_Background, value);
            }
        }

        public int Color
        {
            get
            {
                return this.m_Color;
            }
            set
            {
                base.Delta(ref this.m_Color, value);
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

        public int Number
        {
            get
            {
                return this.m_Number;
            }
            set
            {
                base.Delta(ref this.m_Number, value);
            }
        }

        public bool Scrollbar
        {
            get
            {
                return this.m_Scrollbar;
            }
            set
            {
                base.Delta(ref this.m_Scrollbar, value);
            }
        }

        public bool UseColor
        {
            get
            {
                return this.m_UseColor;
            }
            set
            {
                base.Delta(ref this.m_UseColor, value);
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
        private bool m_Background;
        private int m_Color;
        private int m_Height;
        private static byte[] m_LayoutName;
        private static byte[] m_LayoutNameColor;
        private int m_Number;
        private bool m_Scrollbar;
        private bool m_UseColor;
        private int m_Width;
        private int m_X;
        private int m_Y;
    }
}

