using System;
using System.IO;

namespace WoWDaemon.Common
{
	/// <summary>
	/// Summary description for DebugLogger.
	/// </summary>
	public class DebugLoggerBase
	{
		public DebugLoggerBase()
		{}

		public void Log(string msg) {
			string message = "INFORMATION: " + msg;
			WriteToFile(message);
			Writer.Flush();

			Console.WriteLine(msg);
		}

		public void Log(string msg, Exception e) {
			string message = "";
			if (msg != "")
				message += "INFORMATION: " + msg + "\r\n";

			message += "ERROR: " + e.ToString();
			WriteToFile(message);
		}

		public static DebugLoggerBase operator + (DebugLoggerBase l, string msg)
		{
			l.Log(msg);
			return l;
		}

		protected StreamWriter m_writer = null;
		
		protected virtual StreamWriter Writer
		{
			get
			{
				if (m_writer != null)
					return m_writer;
				else
				{
					m_writer = new StreamWriter(LogFilename, false);
					return m_writer;
				}
			}
		}

		protected virtual string LogFilename { get { return "BaseDebug.log"; } }

		private void WriteToFile(string msg) {
			
			try {
				Writer.WriteLine("[" + DateTime.Now.ToString() + "] ----------------------------------------------------------");
				Writer.WriteLine(msg);
			} catch {
			} finally{

			}
		}
	}
}
