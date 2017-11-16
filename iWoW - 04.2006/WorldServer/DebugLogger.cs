using System;
using System.IO;

namespace WoWDaemon.World
{
	/// <summary>
	/// Summary description for DebugLogger.
	/// </summary>
	public class DebugLogger : Common.DebugLoggerBase
	{
		protected override string LogFilename { get { return "WorldDebug.log"; } }

		private static DebugLogger m_logger;

		public static DebugLogger Logger
		{
			get
			{
				if (m_logger == null)
				{
					m_logger = new DebugLogger();
				}

				return m_logger;
			}
		}

		static public void ILog(string s)
		{
			Logger.Log(s);
		}

		static public void ILog(string s, Exception e)
		{
			Logger.Log(s);
		}
	}
}
