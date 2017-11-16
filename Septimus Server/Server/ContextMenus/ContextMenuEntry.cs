namespace Server.ContextMenus
{
    using Server.Network;
    using System;

    public class ContextMenuEntry
    {
        // Methods
        public ContextMenuEntry(int number) : this(number, -1)
        {
        }

        public ContextMenuEntry(int number, int range)
        {
            this.m_Number = number;
            this.m_Range = range;
            this.m_Enabled = true;
            this.m_Color = 65535;
        }

        public virtual void OnClick()
        {
        }


        // Properties
        public int Color
        {
            get
            {
                return this.m_Color;
            }
            set
            {
                this.m_Color = value;
            }
        }

        public bool Enabled
        {
            get
            {
                return this.m_Enabled;
            }
            set
            {
                this.m_Enabled = value;
            }
        }

        public CMEFlags Flags
        {
            get
            {
                return this.m_Flags;
            }
            set
            {
                this.m_Flags = value;
            }
        }

        public int Number
        {
            get
            {
                return this.m_Number;
            }
            set
            {
                this.m_Number = value;
            }
        }

        public ContextMenu Owner
        {
            get
            {
                return this.m_Owner;
            }
            set
            {
                this.m_Owner = value;
            }
        }

        public int Range
        {
            get
            {
                return this.m_Range;
            }
            set
            {
                this.m_Range = value;
            }
        }


        // Fields
        private int m_Color;
        private bool m_Enabled;
        private CMEFlags m_Flags;
        private int m_Number;
        private ContextMenu m_Owner;
        private int m_Range;
    }
}

