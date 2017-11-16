using System;
using System.IO;

namespace WoWDaemon.Login
{
	/// <summary>
	/// Summary description for DebugLogger.
	/// </summary>
	public class DebugLogger : Common.DebugLoggerBase
	{
		protected override string LogFilename { get { return "LoginDebug.log"; } }

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
	}
}
