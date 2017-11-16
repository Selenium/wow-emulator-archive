namespace Server.Gumps
{
    using Server.Network;
    using System;

    public class GumpButton : GumpEntry
    {
        // Methods
        static GumpButton()
        {
            GumpButton.m_LayoutName = Gump.StringToBuffer("button");
        }

        public GumpButton(int x, int y, int normalID, int pressedID, int buttonID, GumpButtonType type, int param)
        {
            this.m_X = x;
            this.m_Y = y;
            this.m_ID1 = normalID;
            this.m_ID2 = pressedID;
            this.m_ButtonID = buttonID;
            this.m_Type = type;
            this.m_Param = param;
        }

        public override void AppendTo(DisplayGumpFast disp)
        {
            disp.AppendLayout(GumpButton.m_LayoutName);
            disp.AppendLayout(this.m_X);
            disp.AppendLayout(this.m_Y);
            disp.AppendLayout(this.m_ID1);
            disp.AppendLayout(this.m_ID2);
            disp.AppendLayout(((int) this.m_Type));
            disp.AppendLayout(this.m_Param);
            disp.AppendLayout(this.m_ButtonID);
        }

        public override string Compile()
        {
            object[] objArray1 = new object[7];
            objArray1[0] = this.m_X;
            objArray1[1] = this.m_Y;
            objArray1[2] = this.m_ID1;
            objArray1[3] = this.m_ID2;
            objArray1[4] = this.m_Type;
            objArray1[5] = this.m_Param;
            objArray1[6] = this.m_ButtonID;
            return string.Format("{{ button {0} {1} {2} {3} {4} {5} {6} }}", objArray1);
        }


        // Properties
        public int ButtonID
        {
            get
            {
                return this.m_ButtonID;
            }
            set
            {
                base.Delta(ref this.m_ButtonID, value);
            }
        }

        public int NormalID
        {
            get
            {
                return this.m_ID1;
            }
            set
            {
                base.Delta(ref this.m_ID1, value);
            }
        }

        public int Param
        {
            get
            {
                return this.m_Param;
            }
            set
            {
                base.Delta(ref this.m_Param, value);
            }
        }

        public int PressedID
        {
            get
            {
                return this.m_ID2;
            }
            set
            {
                base.Delta(ref this.m_ID2, value);
            }
        }

        public GumpButtonType Type
        {
            get
            {
                return this.m_Type;
            }
            set
            {
                Gump gump1;
                if (this.m_Type != value)
                {
                    this.m_Type = value;
                    gump1 = base.Parent;
                    if (gump1 != null)
                    {
                        gump1.Invalidate();
                    }
                }
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
        private int m_ButtonID;
        private int m_ID1;
        private int m_ID2;
        private static byte[] m_LayoutName;
        private int m_Param;
        private GumpButtonType m_Type;
        private int m_X;
        private int m_Y;
    }
}

