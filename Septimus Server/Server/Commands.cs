namespace Server
{
    using System;
    using System.Collections;

    public class Commands
    {
        // Methods
        static Commands()
        {
            Commands.m_CommandPrefix = "[";
            Commands.m_BadCommandIngoreLevel = AccessLevel.Player;
            Commands.m_Entries = new Hashtable(CaseInsensitiveHashCodeProvider.Default, CaseInsensitiveComparer.Default);
        }

        public Commands()
        {
        }

        public static bool Handle(Mobile from, string text)
        {
            int num1;
            string text1;
            string[] textArray1;
            string text2;
            CommandEntry entry1;
            CommandEventArgs args1;
            if (text.StartsWith(Commands.m_CommandPrefix))
            {
                text = text.Substring(Commands.m_CommandPrefix.Length);
                num1 = text.IndexOf(' ');
                if (num1 >= 0)
                {
                    text2 = text.Substring((num1 + 1));
                    text1 = text.Substring(0, num1);
                    textArray1 = Commands.Split(text2);
                }
                else
                {
                    text2 = "";
                    text1 = text.ToLower();
                    textArray1 = new string[0];
                }
                entry1 = ((CommandEntry) Commands.m_Entries[text1]);
                if (entry1 != null)
                {
                    if (from.AccessLevel >= entry1.AccessLevel)
                    {
                        if (entry1.Handler != null)
                        {
                            args1 = new CommandEventArgs(from, text1, text2, textArray1);
                            entry1.Handler.Invoke(args1);
                            EventSink.InvokeCommand(args1);
                        }
                    }
                    else
                    {
                        if (from.AccessLevel <= Commands.m_BadCommandIngoreLevel)
                        {
                            return false;
                        }
                        from.SendMessage("You do not have access to that command.");
                    }
                }
                else
                {
                    if (from.AccessLevel <= Commands.m_BadCommandIngoreLevel)
                    {
                        return false;
                    }
                    from.SendMessage("That is not a valid command.");
                }
                return true;
            }
            return false;
        }

        public static void Register(string command, AccessLevel access, CommandEventHandler handler)
        {
            Commands.m_Entries[command] = new CommandEntry(command, handler, access);
        }

        public static string[] Split(string value)
        {
            char ch1;
            char[] chArray1 = value.ToCharArray();
            ArrayList list1 = new ArrayList();
            int num1 = 0;
            int num2 = 0;
            while ((num1 < chArray1.Length))
            {
                ch1 = chArray1[num1];
                if (ch1 == '\"')
                {
                    ++num1;
                    num2 = num1;
                    while ((num2 < chArray1.Length))
                    {
                        if ((chArray1[num2] == '\"') && (chArray1[(num2 - 1)] != '\\'))
                        {
                            break;
                        }
                        ++num2;
                    }
                    list1.Add(value.Substring(num1, (num2 - num1)));
                    num1 = (num2 + 2);
                    continue;
                }
                if (ch1 != ' ')
                {
                    num2 = num1;
                    while ((num2 < chArray1.Length))
                    {
                        if (chArray1[num2] == ' ')
                        {
                            break;
                        }
                        ++num2;
                    }
                    list1.Add(value.Substring(num1, (num2 - num1)));
                    num1 = (num2 + 1);
                    continue;
                }
                ++num1;
            }
            return ((string[]) list1.ToArray(typeof(string)));
        }


        // Properties
        public static AccessLevel BadCommandIgnoreLevel
        {
            get
            {
                return Commands.m_BadCommandIngoreLevel;
            }
            set
            {
                Commands.m_BadCommandIngoreLevel = value;
            }
        }

        public static string CommandPrefix
        {
            get
            {
                return Commands.m_CommandPrefix;
            }
            set
            {
                Commands.m_CommandPrefix = value;
            }
        }

        public static Hashtable Entries
        {
            get
            {
                return Commands.m_Entries;
            }
        }


        // Fields
        private static AccessLevel m_BadCommandIngoreLevel;
        private static string m_CommandPrefix;
        private static Hashtable m_Entries;
    }
}

