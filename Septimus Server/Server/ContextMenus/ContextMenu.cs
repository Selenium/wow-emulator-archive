namespace Server.ContextMenus
{
    using Server;
    using System;
    using System.Collections;

    public class ContextMenu
    {
        // Methods
        public ContextMenu(Mobile from, object target)
        {
            int num1;
            this.m_From = from;
            this.m_Target = target;
            ArrayList list1 = new ArrayList();
            if ((target is Mobile))
            {
                ((Mobile) target).GetContextMenuEntries(from, list1);
            }
            else if ((target is Item))
            {
                ((Item) target).GetContextMenuEntries(from, list1);
            }
            this.m_Entries = ((ContextMenuEntry[]) list1.ToArray(typeof(ContextMenuEntry)));
            for (num1 = 0; (num1 < this.m_Entries.Length); ++num1)
            {
                this.m_Entries[num1].Owner = this;
            }
        }


        // Properties
        public ContextMenuEntry[] Entries
        {
            get
            {
                return this.m_Entries;
            }
        }

        public Mobile From
        {
            get
            {
                return this.m_From;
            }
        }

        public object Target
        {
            get
            {
                return this.m_Target;
            }
        }


        // Fields
        private ContextMenuEntry[] m_Entries;
        private Mobile m_From;
        private object m_Target;
    }
}

