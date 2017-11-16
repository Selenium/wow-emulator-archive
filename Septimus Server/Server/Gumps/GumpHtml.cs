namespace Server.Gumps
{
    using Server.Network;
    using System;

    public class GumpHtml : GumpEntry
    {
        // Methods
        static GumpHtml()
        {
            GumpHtml.m_LayoutName = Gump.StringToBuffer("htmlgump");
        }

        public GumpHtml(int x, int y, int width, int height, string text, bool background, bool scrollbar)
        {
            this.m_X = x;
            this.m_Y = y;
            this.m_Width = width;
            this.m_Height = height;
            this.m_Text = text;
            this.m_Background = background;
            this.m_Scrollbar = scrollbar;
        }

        public override void AppendTo(DisplayGumpFast disp)
        {
            disp.AppendLayout(GumpHtml.m_LayoutName);
            disp.AppendLayout(this.m_X);
            disp.AppendLayout(this.m_Y);
            disp.AppendLayout(this.m_Width);
            disp.AppendLayout(this.m_Height);
            disp.AppendLayout(base.Parent.Intern(this.m_Text));
            disp.AppendLayout(this.m_Background);
            disp.AppendLayout(this.m_Scrollbar);
        }

        public override string Compile()
        {
            object[] objArray1 = new object[7];
            objArray1[0] = this.m_X;
            objArray1[1] = this.m_Y;
            objArray1[2] = this.m_Width;
            objArray1[3] = this.m_Height;
            objArray1[4] = base.Parent.Intern(this.m_Text);
            objArray1[5] = (this.m_Background ? 1 : 0);
            objArray1[6] = (this.m_Scrollbar ? 1 : 0);
            return string.Format("{{ htmlgump {0} {1} {2} {3} {4} {5} {6} }}", objArray1);
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

        public string Text
        {
            get
            {
                return this.m_Text;
            }
            set
            {
                base.Delta(ref this.m_Text, value);
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
        private int m_Height;
        private static byte[] m_LayoutName;
        private bool m_Scrollbar;
        private string m_Text;
        private int m_Width;
        private int m_X;
        private int m_Y;
    }
}

