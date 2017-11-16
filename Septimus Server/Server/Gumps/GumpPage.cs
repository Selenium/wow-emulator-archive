namespace Server.Gumps
{
    using Server.Network;
    using System;

    public class GumpPage : GumpEntry
    {
        // Methods
        static GumpPage()
        {
            GumpPage.m_LayoutName = Gump.StringToBuffer("page");
        }

        public GumpPage(int page)
        {
            this.m_Page = page;
        }

        public override void AppendTo(DisplayGumpFast disp)
        {
            disp.AppendLayout(GumpPage.m_LayoutName);
            disp.AppendLayout(this.m_Page);
        }

        public override string Compile()
        {
            return string.Format("{{ page {0} }}", this.m_Page);
        }


        // Properties
        public int Page
        {
            get
            {
                return this.m_Page;
            }
            set
            {
                base.Delta(ref this.m_Page, value);
            }
        }


        // Fields
        private static byte[] m_LayoutName;
        private int m_Page;
    }
}

