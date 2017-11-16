namespace Server.Gumps
{
    using Server.Network;
    using System;

    public abstract class GumpEntry
    {
        // Methods
        public GumpEntry()
        {
        }

        public abstract void AppendTo(DisplayGumpFast disp);

        public abstract string Compile();

        protected void Delta(ref bool var, bool val)
        {
            if (var != val)
            {
                var = val;
                if (this.m_Parent != null)
                {
                    this.m_Parent.Invalidate();
                }
            }
        }

        protected void Delta(ref int var, int val)
        {
            if (var != val)
            {
                var = val;
                if (this.m_Parent != null)
                {
                    this.m_Parent.Invalidate();
                }
            }
        }

        protected void Delta(ref string var, string val)
        {
            if (var != val)
            {
                var = val;
                if (this.m_Parent != null)
                {
                    this.m_Parent.Invalidate();
                }
            }
        }


        // Properties
        public Gump Parent
        {
            get
            {
                return this.m_Parent;
            }
            set
            {
                if (this.m_Parent == value)
                {
                    return;
                }
                if (this.m_Parent != null)
                {
                    this.m_Parent.Remove(this);
                }
                this.m_Parent = value;
                this.m_Parent.Add(this);
            }
        }


        // Fields
        private Gump m_Parent;
    }
}

