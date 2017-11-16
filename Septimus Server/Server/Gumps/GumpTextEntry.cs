namespace Server.Gumps
{
    using Server.Network;
    using System;

    public class GumpTextEntry : GumpEntry
    {
        // Methods
        static GumpTextEntry()
        {
            GumpTextEntry.m_LayoutName = Gump.StringToBuffer("textentry");
        }

        public GumpTextEntry(int x, int y, int width, int height, int hue, int entryID, string initialText)
        {
            this.m_X = x;
            this.m_Y = y;
            this.m_Width = width;
            this.m_Height = height;
            this.m_Hue = hue;
            this.m_EntryID = entryID;
            this.m_InitialText = initialText;
        }

        public override void AppendTo(DisplayGumpFast disp)
        {
            disp.AppendLayout(GumpTextEntry.m_LayoutName);
            disp.AppendLayout(this.m_X);
            disp.AppendLayout(this.m_Y);
            disp.AppendLayout(this.m_Width);
            disp.AppendLayout(this.m_Height);
            disp.AppendLayout(this.m_Hue);
            disp.AppendLayout(this.m_EntryID);
            disp.AppendLayout(base.Parent.Intern(this.m_InitialText));
        }

        public override string Compile()
        {
            object[] objArray1 = new object[7];
            objArray1[0] = this.m_X;
            objArray1[1] = this.m_Y;
            objArray1[2] = this.m_Width;
            objArray1[3] = this.m_Height;
            objArray1[4] = this.m_Hue;
            objArray1[5] = this.m_EntryID;
            objArray1[6] = base.Parent.Intern(this.m_InitialText);
            return string.Format("{{ textentry {0} {1} {2} {3} {4} {5} {6} }}", objArray1);
        }


        // Properties
        public int EntryID
        {
            get
            {
                return this.m_EntryID;
            }
            set
            {
                base.Delta(ref this.m_EntryID, value);
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

        public string InitialText
        {
            get
            {
                return this.m_InitialText;
            }
            set
            {
                base.Delta(ref this.m_InitialText, value);
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
        private int m_EntryID;
        private int m_Height;
        private int m_Hue;
        private string m_InitialText;
        private static byte[] m_LayoutName;
        private int m_Width;
        private int m_X;
        private int m_Y;
    }
}

