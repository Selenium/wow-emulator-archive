namespace Server.Gumps
{
    using Server.Network;
    using System;

    public class GumpLabelCropped : GumpEntry
    {
        // Methods
        static GumpLabelCropped()
        {
            GumpLabelCropped.m_LayoutName = Gump.StringToBuffer("croppedtext");
        }

        public GumpLabelCropped(int x, int y, int width, int height, int hue, string text)
        {
            this.m_X = x;
            this.m_Y = y;
            this.m_Width = width;
            this.m_Height = height;
            this.m_Hue = hue;
            this.m_Text = text;
        }

        public override void AppendTo(DisplayGumpFast disp)
        {
            disp.AppendLayout(GumpLabelCropped.m_LayoutName);
            disp.AppendLayout(this.m_X);
            disp.AppendLayout(this.m_Y);
            disp.AppendLayout(this.m_Width);
            disp.AppendLayout(this.m_Height);
            disp.AppendLayout(this.m_Hue);
            disp.AppendLayout(base.Parent.Intern(this.m_Text));
        }

        public override string Compile()
        {
            object[] objArray1 = new object[6];
            objArray1[0] = this.m_X;
            objArray1[1] = this.m_Y;
            objArray1[2] = this.m_Width;
            objArray1[3] = this.m_Height;
            objArray1[4] = this.m_Hue;
            objArray1[5] = base.Parent.Intern(this.m_Text);
            return string.Format("{{ croppedtext {0} {1} {2} {3} {4} {5} }}", objArray1);
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
        private int m_Height;
        private int m_Hue;
        private static byte[] m_LayoutName;
        private string m_Text;
        private int m_Width;
        private int m_X;
        private int m_Y;
    }
}

