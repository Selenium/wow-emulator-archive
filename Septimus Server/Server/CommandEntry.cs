namespace Server
{
    using System;

    public class CommandEntry : IComparable
    {
        // Methods
        public CommandEntry(string command, CommandEventHandler handler, AccessLevel accessLevel)
        {
            this.m_Command = command;
            this.m_Handler = handler;
            this.m_AccessLevel = accessLevel;
        }

        public int CompareTo(object obj)
        {
            if (obj == this)
            {
                return 0;
            }
            if (obj == null)
            {
                return 1;
            }
            CommandEntry entry1 = (obj as CommandEntry);
            if (entry1 == null)
            {
                throw new ArgumentException();
            }
            return this.m_Command.CompareTo(entry1.m_Command);
        }


        // Properties
        public AccessLevel AccessLevel
        {
            get
            {
                return this.m_AccessLevel;
            }
        }

        public string Command
        {
            get
            {
                return this.m_Command;
            }
        }

        public CommandEventHandler Handler
        {
            get
            {
                return this.m_Handler;
            }
        }


        // Fields
        private AccessLevel m_AccessLevel;
        private string m_Command;
        private CommandEventHandler m_Handler;
    }
}

