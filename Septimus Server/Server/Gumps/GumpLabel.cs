namespace Server.Gumps
{
    using Server.Network;
    using System;

    public class GumpLabel : GumpEntry
    {
        // Methods
        static GumpLabel()
        {
            GumpLabel.m_LayoutName = Gump.StringToBuffer("text");
        }

        public GumpLabel(int x, int y, int hue, string text)
        {
            this.m_X = x;
            this.m_Y = y;
            this.m_Hue = hue;
            this.m_Text = text;
        }

        public override void AppendTo(DisplayGumpFast disp)
        {
            disp.AppendLayout(GumpLabel.m_LayoutName);
            disp.AppendLayout(this.m_X);
            disp.AppendLayout(this.m_Y);
            disp.AppendLayout(this.m_Hue);
            disp.AppendLayout(base.Parent.Intern(this.m_Text));
        }

        public override string Compile()
        {
            object[] objArray1 = new object[4];
            objArray1[0] = this.m_X;
            objArray1[1] = this.m_Y;
            objArray1[2] = this.m_Hue;
            objArray1[3] = base.Parent.Intern(this.m_Text);
            return string.Format("{{ text {0} {1} {2} {3} }}", objArray1);
        }


        // Properties
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
        private int m_Hue;
        private static byte[] m_LayoutName;
        private string m_Text;
        private int m_X;
        private int m_Y;
    }
}

