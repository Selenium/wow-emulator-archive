// ****************************************************************************
// Shurugwi
// Date: 2005-Aug-20
// Konsole is base on my Original Remote Console design for RunUO in 2002
// ****************************************************************************

using System;
using System.Threading;

using Server;

namespace Server.Konsole
{
	class KonsoleListener : IInitialize
	{
		#region ConsoleHook
		public static ConsoleHook konsole;
		#endregion

		#region Initialize
		public static void Initialize()
		{
			StartKonsole();
			Console.WriteLine(".-= Konsole started =-.");
		}
		#endregion

		public static void StartKonsole() 
		{
			Console.WriteLine("[WowwoW <? for help>]");

			AutoResetEvent asyncOpIsDone = new AutoResetEvent(false);
			ThreadPool.QueueUserWorkItem(new WaitCallback(WowwoWKonsole), asyncOpIsDone);
			return;
		}

		static void WowwoWKonsole(object state) 
		{
			if(konsole == null)
			{
				konsole = new ConsoleHook();
				Console.SetOut(konsole);
			}

			string strCommand = Console.ReadLine();

			KonsoleCommands.ProcessKonsoleInput(strCommand);

			StartKonsole();
		}
	}
}