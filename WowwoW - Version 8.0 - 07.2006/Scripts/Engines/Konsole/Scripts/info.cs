// ****************************************************************************
// uvrt
// ****************************************************************************

using System;
using Server;
using System.Threading; 
using System.Diagnostics; 
using System.ComponentModel; 

namespace Server.Konsole.Commands
{
	public class KonsoleInfo : IInitialize
	{
		#region Initialize
		public static void Initialize() 
		{ 
			KonsoleCommands.Register( "Info", new KonsoleCommandEventHandler( Info_OnCommand ) );
			KonsoleCommands.Register( "I", new KonsoleCommandEventHandler( Info_OnCommand ) );
		}
		#endregion

		#region Commands
		[Category( "[Server]" )]
		[Usage( "Info" )]
		[Aliases( "\tI" )]
		[Description( "\t\tShows WowwoW Usage Info" )]
		public static void Info_OnCommand( KonsoleCommandEventArgs e )
		{

			try 
			{ 
				Process[] list = Process.GetProcessesByName("WowwoW"); 
				foreach (Process p in list) 
				{ 
					Console.WriteLine("\n--------=[( Usage Information )]=--------"); 
					Console.WriteLine("> Handles total:\t{0}",            p.HandleCount); 
					Console.WriteLine("> Threads total:\t{0}",            p.Threads.Count); 
					Console.WriteLine("> Physical Memory:\t{0}",         p.WorkingSet / 1024 + "k"); 
					Console.WriteLine("> Peak Physical Memory:\t{0}",      p.PeakWorkingSet / 1024 + "k"); 
					Console.WriteLine("> Virtual Memory:\t{0}",            p.VirtualMemorySize / 1024 + "k"); 
					Console.WriteLine("> Peak Virtual Memory:\t{0}",      p.PeakVirtualMemorySize / 1024 + "k"); 
					Console.WriteLine("> NonPaged Memory:\t{0}",         p.NonpagedSystemMemorySize / 1024 + "k"); 
					Console.WriteLine("> Paged Memory:\t\t{0}",            p.PagedMemorySize / 1024 + "k"); 
					Console.WriteLine("> Private Memory: \t{0}",         p.PrivateMemorySize / 1024 + "k"); 
					Console.WriteLine("> Total Processor Time:\t{0}",      p.TotalProcessorTime); 
					Console.WriteLine("> User Processor Time:\t{0}",      p.UserProcessorTime); 
					Console.WriteLine("--------=========================--------\n");  
				} 
			} 
			catch 
			{ 
				Console.WriteLine( "Could not find 'WoWWoW' process" ); 
			}
		}
		#endregion
	}
}
