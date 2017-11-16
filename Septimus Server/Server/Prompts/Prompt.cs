namespace Server.Prompts
{
    using Server;
    using System;

    public abstract class Prompt
    {
        // Methods
        public Prompt()
        {
            do
            {
                this.m_Serial = (++Prompt.m_Serials);
            }
            while ((this.m_Serial == 0));
        }

        public virtual void OnCancel(Mobile from)
        {
        }

        public virtual void OnResponse(Mobile from, string text)
        {
        }


        // Properties
        public int Serial
        {
            get
            {
                return this.m_Serial;
            }
        }


        // Fields
        private int m_Serial;
        private static int m_Serials;
    }
}

