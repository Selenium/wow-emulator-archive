namespace Server.Gumps
{
    using Server.Network;
    using System;

    public class GumpRadio : GumpEntry
    {
        // Methods
        static GumpRadio()
        {
            GumpRadio.m_LayoutName = Gump.StringToBuffer("radio");
        }

        public GumpRadio(int x, int y, int inactiveID, int activeID, bool initialState, int switchID)
        {
            this.m_X = x;
            this.m_Y = y;
            this.m_ID1 = inactiveID;
            this.m_ID2 = activeID;
            this.m_InitialState = initialState;
            this.m_SwitchID = switchID;
        }

        public override void AppendTo(DisplayGumpFast disp)
        {
            disp.AppendLayout(GumpRadio.m_LayoutName);
            disp.AppendLayout(this.m_X);
            disp.AppendLayout(this.m_Y);
            disp.AppendLayout(this.m_ID1);
            disp.AppendLayout(this.m_ID2);
            disp.AppendLayout(this.m_InitialState);
            disp.AppendLayout(this.m_SwitchID);
        }

        public override string Compile()
        {
            object[] objArray1 = new object[6];
            objArray1[0] = this.m_X;
            objArray1[1] = this.m_Y;
            objArray1[2] = this.m_ID1;
            objArray1[3] = this.m_ID2;
            objArray1[4] = (this.m_InitialState ? 1 : 0);
            objArray1[5] = this.m_SwitchID;
            return string.Format("{{ radio {0} {1} {2} {3} {4} {5} }}", objArray1);
        }


        // Properties
        public int ActiveID
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

        public int InactiveID
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

        public bool InitialState
        {
            get
            {
                return this.m_InitialState;
            }
            set
            {
                base.Delta(ref this.m_InitialState, value);
            }
        }

        public int SwitchID
        {
            get
            {
                return this.m_SwitchID;
            }
            set
            {
                base.Delta(ref this.m_SwitchID, value);
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
        private int m_ID1;
        private int m_ID2;
        private bool m_InitialState;
        private static byte[] m_LayoutName;
        private int m_SwitchID;
        private int m_X;
        private int m_Y;
    }
}

