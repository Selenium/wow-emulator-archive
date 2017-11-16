using System;
using System.IO;

namespace ErrorLog
{
	/// <summary>
	/// This class can log errors and events.
	/// </summary>
	public class Log
	{

		public static bool Active = true;
		public static string pathBase = "C:\\EWOW\\";
		public static Exception Error;

		public Log()
		{
		}

		public static void LogError(Exception exp)
		{
			if (!Active) return;
			WriteErrorEvent("error.log", exp.Message, exp.Source, exp.StackTrace);
		}

		public static void WriteEvent(Exception exp)
		{
			if (!Active) return;
			WriteErrorEvent("event.log", exp.Message, exp.Source, exp.StackTrace);
		}
		public static void WriteEvent(string eventString)
		{
			if (!Active) return;
			WriteErrorEvent("event.log", eventString, String.Empty, String.Empty);
		}
		public static void WriteEvent(string fileName, string eventString)
		{
			if (!Active) return;
			WriteErrorEvent(fileName, eventString, String.Empty, String.Empty);
		}

		public static void WriteLog(string logString)
		{
			if (!Active) return;
			WriteErrorEvent("various.log", logString, "LOG", String.Empty);
		}

		public static void WriteErrorEvent(string fileName, string message, string source, string trace)
		{
			if (!Active) return;
			StreamWriter sw = null;
			try
			{
				Directory.CreateDirectory( pathBase );
				string line = DateTime.Now.ToString() + "\t" + message + "\r\n" + trace + "\r\n\r\n";
				sw = new StreamWriter(pathBase + fileName, true, System.Text.Encoding.Default, line.Length);
				sw.Write(line);
				sw.Close();
			}
			catch(Exception exp)
			{Error = exp;}
			finally
			{ 
				if(sw != null)
					sw.Close(); 
			}
		}

		public static void WriteCommandLog(string fileName, string errorDescription, string className, string functionName, int count)
		{
			if (!Active) return;
			StreamWriter sw = null;
			try
			{
				Directory.CreateDirectory( pathBase );
				string line = DateTime.Now.ToString() + "\t" + errorDescription + "\t" + className + "\t" + functionName + "\t" + count + "\r\n\r\n";
				sw = new StreamWriter(pathBase + fileName, true, System.Text.Encoding.Default, line.Length);
				sw.Write(line);
				sw.Close();
				sw = null;

			}
			catch(Exception exp)
			{Error = exp;}
			finally
			{ 
				if(sw != null)
					sw.Close(); 
			}
		}
	}
}
