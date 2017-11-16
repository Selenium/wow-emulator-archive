using System;
using System.Diagnostics;

namespace Server.Konsole.Sockets
{
	/// <summary>
	/// Summary description for TelnetHelper.
	/// </summary>
	public class SocketHelper
	{

		public static void ShowError(object type, Exception ex)
		{
			ShowError(type, ex, EventLogEntryType.Error);
		}

		public static void ShowError(object type, Exception ex, EventLogEntryType errortype)
		{
			string type_name = string.Empty;
			switch (errortype) 
			{
				case EventLogEntryType.Error: type_name = "Error"; break;
				case EventLogEntryType.FailureAudit: type_name = "FailureAudit"; break;
				case EventLogEntryType.Information: type_name = "Information"; break;
				case EventLogEntryType.SuccessAudit: type_name = "SuccessAudit"; break;
				case EventLogEntryType.Warning: type_name = "Warning"; break;
			}

			Console.WriteLine("Socket Exception: {0}\r\nType:{1}\r\nLocation:{2}\r\nMessage:{3}\r\nStack:{4}", DateTime.Now, type_name, type.GetType().ToString(), ex.Message, ex.StackTrace);

		}

	}
}
