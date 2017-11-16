namespace Server.Gumps
{
    using Server.Network;
    using System;

    public class GumpItem : GumpEntry
    {
        // Methods
        static GumpItem()
        {
            GumpItem.m_LayoutName = Gump.StringToBuffer("tilepic");
            GumpItem.m_LayoutNameHue = Gump.StringToBuffer("tilepichue");
        }

        public GumpItem(int x, int y, int itemID) : this(x, y, itemID, 0)
        {
        }

        public GumpItem(int x, int y, int itemID, int hue)
        {
            this.m_X = x;
            this.m_Y = y;
            this.m_ItemID = itemID;
            this.m_Hue = hue;
        }

        public override void AppendTo(DisplayGumpFast disp)
        {
            disp.AppendLayout(((this.m_Hue == 0) ? GumpItem.m_LayoutName : GumpItem.m_LayoutNameHue));
            disp.AppendLayout(this.m_X);
            disp.AppendLayout(this.m_Y);
            disp.AppendLayout(this.m_ItemID);
            if (this.m_Hue != 0)
            {
                disp.AppendLayout(this.m_Hue);
            }
        }

        public override string Compile()
        {
            if (this.m_Hue == 0)
            {
                return string.Format("{{ tilepic {0} {1} {2} }}", this.m_X, this.m_Y, this.m_ItemID);
            }
            object[] objArray1 = new object[4];
            objArray1[0] = this.m_X;
            objArray1[1] = this.m_Y;
            objArray1[2] = this.m_ItemID;
            objArray1[3] = this.m_Hue;
            return string.Format("{{ tilepichue {0} {1} {2} {3} }}", objArray1);
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

        public int ItemID
        {
            get
            {
                return this.m_ItemID;
            }
            set
            {
                base.Delta(ref this.m_ItemID, value);
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
        private int m_ItemID;
        private static byte[] m_LayoutName;
        private static byte[] m_LayoutNameHue;
        private int m_X;
        private int m_Y;
    }
}

