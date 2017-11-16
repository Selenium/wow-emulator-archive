namespace Server
{
    using System;

    public abstract class PartyCommands
    {
        // Methods
        protected PartyCommands()
        {
        }

        public abstract void OnAccept(Mobile from, Mobile leader);

        public abstract void OnAdd(Mobile from);

        public abstract void OnDecline(Mobile from, Mobile leader);

        public abstract void OnPrivateMessage(Mobile from, Mobile target, string text);

        public abstract void OnPublicMessage(Mobile from, string text);

        public abstract void OnRemove(Mobile from, Mobile target);

        public abstract void OnSetCanLoot(Mobile from, bool canLoot);


        // Properties
        public static PartyCommands Handler
        {
            get
            {
                return PartyCommands.m_Handler;
            }
            set
            {
                PartyCommands.m_Handler = value;
            }
        }


        // Fields
        private static PartyCommands m_Handler;
    }
}

