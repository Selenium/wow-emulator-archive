namespace Server.ContextMenus
{
    using Server;
    using System;

    public class PaperdollEntry : ContextMenuEntry
    {
        // Methods
        public PaperdollEntry(Mobile m) : base(6123, 18)
        {
            this.m_Mobile = m;
        }

        public override void OnClick()
        {
            if (this.m_Mobile.CanPaperdollBeOpenedBy(base.Owner.From))
            {
                this.m_Mobile.DisplayPaperdollTo(base.Owner.From);
            }
        }


        // Fields
        private Mobile m_Mobile;
    }
}

