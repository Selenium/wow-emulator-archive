namespace Server
{
    using System;

    public class CommandEventArgs : EventArgs
    {
        // Methods
        public CommandEventArgs(Mobile mobile, string command, string argString, string[] arguments)
        {
            this.m_Mobile = mobile;
            this.m_Command = command;
            this.m_ArgString = argString;
            this.m_Arguments = arguments;
        }

        public bool GetBoolean(int index)
        {
            if ((index < 0) || (index >= this.m_Arguments.Length))
            {
                return false;
            }
            return Utility.ToBoolean(this.m_Arguments[index]);
        }

        public double GetDouble(int index)
        {
            if ((index < 0) || (index >= this.m_Arguments.Length))
            {
                return 0;
            }
            return Utility.ToDouble(this.m_Arguments[index]);
        }

        public int GetInt32(int index)
        {
            if ((index < 0) || (index >= this.m_Arguments.Length))
            {
                return 0;
            }
            return Utility.ToInt32(this.m_Arguments[index]);
        }

        public string GetString(int index)
        {
            if ((index < 0) || (index >= this.m_Arguments.Length))
            {
                return "";
            }
            return this.m_Arguments[index];
        }

        public TimeSpan GetTimeSpan(int index)
        {
            if ((index < 0) || (index >= this.m_Arguments.Length))
            {
                return TimeSpan.Zero;
            }
            return Utility.ToTimeSpan(this.m_Arguments[index]);
        }


        // Properties
        public string ArgString
        {
            get
            {
                return this.m_ArgString;
            }
        }

        public string[] Arguments
        {
            get
            {
                return this.m_Arguments;
            }
        }

        public string Command
        {
            get
            {
                return this.m_Command;
            }
        }

        public int Length
        {
            get
            {
                return this.m_Arguments.Length;
            }
        }

        public Mobile Mobile
        {
            get
            {
                return this.m_Mobile;
            }
        }


        // Fields
        private string m_ArgString;
        private string[] m_Arguments;
        private string m_Command;
        private Mobile m_Mobile;
    }
}

