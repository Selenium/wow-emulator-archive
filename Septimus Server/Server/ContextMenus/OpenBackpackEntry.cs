namespace Server.ContextMenus
{
    using Server;
    using System;

    public class OpenBackpackEntry : ContextMenuEntry
    {
        // Methods
        public OpenBackpackEntry(Mobile m) : base(6145)
        {
            this.m_Mobile = m;
        }

        public override void OnClick()
        {
            this.m_Mobile.Use(this.m_Mobile.Backpack);
        }


        // Fields
        private Mobile m_Mobile;
    }
}

