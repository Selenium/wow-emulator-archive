using System;

using System.Collections;
using System.Reflection;
using System.Threading;
using System.Diagnostics; 
using System.ComponentModel;

using Server;
using Server.Konsole.Sockets;

namespace Server.Konsole.Telnet
{
	/// <summary>
	/// Summary description for TelnetBootstrap.
	/// </summary>
	public class TelnetBootstrap : IInitialize
	{

		#region Public Variables
		public static WowwoWTelnet telnetlistener;
		#endregion

		#region Initialize
		public static void Initialize() 
		{
			Start();
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Start Telnet Listener
		/// </summary>
		public static void Start()
		{
			if(telnetlistener == null)
			{
				try
				{
					AutoResetEvent asyncOpIsDone = new AutoResetEvent(false);
					ThreadPool.QueueUserWorkItem(new WaitCallback(StartTelnetListener), asyncOpIsDone);

					Console.WriteLine(".-= Telnet Listener started on port {0}, IP {1} =-.", TelnetConfig.TelnetPort.ToString(), TelnetConfig.IPAddress);
				}
				catch(Exception ex)
				{
					Console.WriteLine("Telnet Exception:\r\n{0} \r\n{1}", ex.Message, ex.StackTrace);
				}
			}
			else
			{
				Console.WriteLine("There is already a Telnet listener active.");
			}
		}

		/// <summary>
		/// Stop telnet Listener
		/// </summary>
		/// <param name="state"></param>
		public static void Stop(object state)
		{
			if(telnetlistener == null)
			{
				Console.WriteLine("There is no Telnet Listener active");
			}
			else
			{
				try
				{
					Console.WriteLine("Stopping Telnet Listener...");
					telnetlistener.Stop();
					Console.WriteLine("Telnet Listener stopped");
					telnetlistener = null;
				}
				catch(Exception ex)
				{
					Console.WriteLine("Telnet Exception:\r\n{0} \r\n{1}", ex.Message, ex.StackTrace);
				}
			}
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Async Private method to start the Telnet server
		/// </summary>
		/// <param name="state"></param>
		private static void StartTelnetListener(object state)
		{
			try
			{
				telnetlistener = new WowwoWTelnet();
				telnetlistener.Start();
			}
			catch(Exception ex)
			{
				Console.WriteLine("Telnet Exception:\r\n{0} \r\n{1}", ex.Message, ex.StackTrace);
			}
		}
		#endregion
	}
}
