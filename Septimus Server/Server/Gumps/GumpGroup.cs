namespace Server.Gumps
{
    using Server.Network;
    using System;

    public class GumpGroup : GumpEntry
    {
        // Methods
        static GumpGroup()
        {
            GumpGroup.m_LayoutName = Gump.StringToBuffer("group");
        }

        public GumpGroup(int group)
        {
            this.m_Group = group;
        }

        public override void AppendTo(DisplayGumpFast disp)
        {
            disp.AppendLayout(GumpGroup.m_LayoutName);
            disp.AppendLayout(this.m_Group);
        }

        public override string Compile()
        {
            return string.Format("{{ group {0} }}", this.m_Group);
        }


        // Properties
        public int Group
        {
            get
            {
                return this.m_Group;
            }
            set
            {
                base.Delta(ref this.m_Group, value);
            }
        }


        // Fields
        private int m_Group;
        private static byte[] m_LayoutName;
    }
}

