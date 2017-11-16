using System;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Collections;
using System.Runtime.InteropServices;

namespace Loader
{
	using Maelstrom;

	using ClientHandlerServer=Maelstrom.ClientHandlerServer;
	using ObjectServer=Maelstrom.ObjectServer;
	using RealmListServer=Maelstrom.RealmListServer;
	using RedirectServer=Maelstrom.RedirectServer;
	using WorldServer=Maelstrom.WorldServer;

	internal class Loader
	{
		[DllImport("kernel32.dll")]
		private static extern bool SetConsoleTitle(string lpConsoleTitle);

		private static void Initialize()
		{
			Console.WriteLine("-------------------------------------------------------------------------------\n");

			//TODO: Selectively initialize server libraries baed on server configuration.
			#region Library Initialization

			WorldServer.Core.Initialize();
			ObjectServer.Core.Initialize();
			RedirectServer.Core.Initialize();
			RealmListServer.Core.Initialize();
			ClientHandlerServer.Core.Initialize();

			#endregion
		}

		private static void Run(string[] Arguments)
		{
			Console.WriteLine("-------------------------------------------------------------------------------\n");
			
			//TODO: Selectively execute server libraries based on server configuration (for now we are running in a single-process solution).
			#region Library Execution

			WorldServer.Core.Run(Arguments);
			ObjectServer.Core.Run(Arguments);
			RedirectServer.Core.Run(Arguments);
			RealmListServer.Core.Run(Arguments);
			ClientHandlerServer.Core.Run(Arguments);

			#endregion
		}

		private static void Shutdown()
		{
			Console.WriteLine("-------------------------------------------------------------------------------");
		}

		public static void Main(string[] Arguments)
		{
			try
			{
				SetConsoleTitle("Maelstrom World of Warcraft Server Emulator v1.0");

				Console.WriteLine("Maelstrom World of Warcraft Server Emulator version 1.0");
				Console.WriteLine("Copyright (c) 2004 Team Maelstrom\n");

				Console.WriteLine(".NET Common Language Runtime version {0}",RuntimeEnvironment.GetSystemVersion());

				Initialize();

				Run(Arguments);	
			
				//Place the main process thread in a suspended state.
				Thread.Sleep(System.Threading.Timeout.Infinite);
			}
			catch(Exception e)
			{
				Console.WriteLine("-------------------------------------------------------------------------------");

				Console.WriteLine("\nThere has been a critical server error:\n");
				Console.WriteLine(e.Message);

				//Log the error here...
			}
			finally
			{
				//Shutdown cores...
				Shutdown();
			}
		}
	}
}
