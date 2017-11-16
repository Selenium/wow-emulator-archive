using System;
using System.IO;

namespace WoWDaemon.Loader
{
	/// <summary>
	/// Summary description for DebugLogger.
	/// </summary>
	public class DebugLogger : Common.DebugLoggerBase
	{
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
		

		static protected new string LogFilename { get { return "LoaderDebug.log"; } }

	}
}
