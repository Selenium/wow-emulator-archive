namespace Server
{
    using System;
    using System.Diagnostics;

    public class EventLog
    {
        // Methods
        static EventLog()
        {
            if (!System.Diagnostics.EventLog.SourceExists("RunUO"))
            {
                System.Diagnostics.EventLog.CreateEventSource("RunUO", "Application");
            }
        }

        public EventLog()
        {
        }

        public static void Error(int eventID, string text)
        {
            System.Diagnostics.EventLog.WriteEntry("RunUO", text, EventLogEntryType.Error, eventID);
        }

        public static void Error(int eventID, string format, params object[] args)
        {
            Server.EventLog.Error(eventID, string.Format(format, args));
        }

        public static void Inform(int eventID, string text)
        {
            System.Diagnostics.EventLog.WriteEntry("RunUO", text, EventLogEntryType.Information, eventID);
        }

        public static void Inform(int eventID, string format, params object[] args)
        {
            Server.EventLog.Inform(eventID, string.Format(format, args));
        }

        public static void Warning(int eventID, string text)
        {
            System.Diagnostics.EventLog.WriteEntry("RunUO", text, EventLogEntryType.Warning, eventID);
        }

        public static void Warning(int eventID, string format, params object[] args)
        {
            Server.EventLog.Warning(eventID, string.Format(format, args));
        }

    }
}

