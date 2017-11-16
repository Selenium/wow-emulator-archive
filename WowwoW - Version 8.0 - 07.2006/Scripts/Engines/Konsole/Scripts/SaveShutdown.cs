// ****************************************************************************
// uvrt
// ****************************************************************************

using System;
using Server;
using System.Threading; 
using System.Diagnostics; 

namespace Server.Konsole.Commands
{
	public class KonsoleSaveShutdown : IInitialize
	{
		#region Initialize
		public static void Initialize() 
		{ 
			KonsoleCommands.Register( "SaveShutdown", new KonsoleCommandEventHandler( SaveShutdown_OnCommand ) );
			KonsoleCommands.Register( "SSD", new KonsoleCommandEventHandler( SaveShutdown_OnCommand ) );
		}
		#endregion

		#region Commands
		[Category( "[Server]" )]
		[Usage( "SaveShutdown" )]
		[Aliases( "SSD" )]
		[Description( "\tSave and Shutdown WowwoW" )]
		public static void SaveShutdown_OnCommand( KonsoleCommandEventArgs e )
		{

			Thread.CurrentThread.Priority = ThreadPriority.Highest; 
			Console.WriteLine("Saving..."); 
			World.Save(); 
			Console.WriteLine( "Shutdown..." ); 
			Process proc = Process.GetCurrentProcess(); 
			if (MainConsole.sw1 != null)   MainConsole.sw1.Flush(); 
			proc.Kill();  
		}
		#endregion
	}
}
