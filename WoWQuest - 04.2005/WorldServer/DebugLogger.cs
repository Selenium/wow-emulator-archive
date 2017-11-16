using System;
using System.IO;

namespace WoWDaemon.World
{
	/// <summary>
	/// Summary description for DebugLogger.
	/// </summary>
	public class DebugLogger
	{
		public DebugLogger()
		{}

		public static void Log(string msg) {
			string message = "INFORMATION: " + msg;
			WriteToFile(message);
		}

		public static void Log(string msg, Exception e) {
			string message = "";
			if (msg != "")
				message += "INFORMATION: " + msg + "\r\n";

			message += "ERROR: " + e.ToString();
			WriteToFile(message);
		}

		private static void WriteToFile(string msg) {
			StreamWriter writer = null;
			try {
				writer = new StreamWriter("WorldDebug.log", true);
				writer.WriteLine("[" + DateTime.Now.ToString() + "] ----------------------------------------------------------");
				writer.WriteLine(msg);
				writer.WriteLine("----------------------------------------------------------------------------------");
			} catch {
			} finally{
				if (writer != null)
					writer.Close();
			}
		}
	}
}
