// ****************************************************************************
// uvrt
// ****************************************************************************

using System;
using Server;
using System.Threading; 
using System.Diagnostics; 

namespace Server.Konsole.Commands
{
	public class KonsoleShutdown : IInitialize
	{
		#region Initialize
		public static void Initialize() 
		{ 
			KonsoleCommands.Register( "Shutdown", new KonsoleCommandEventHandler( Shutdown_OnCommand ) );
			KonsoleCommands.Register( "SD", new KonsoleCommandEventHandler( Shutdown_OnCommand ) );
		}
		#endregion

		#region Commands
		[Category( "[Server]" )]
		[Usage( "Shutdown" )]
		[Aliases( "\t\tSD" )]
		[Description( "\tShutdown WowwoW" )]
		public static void Shutdown_OnCommand( KonsoleCommandEventArgs e )
		{

			Thread.CurrentThread.Priority = ThreadPriority.Highest; 
			Console.WriteLine( "Shutdown..." ); 
			Process proc = Process.GetCurrentProcess(); 
			if ( MainConsole.sw1 != null)   MainConsole.sw1.Flush(); 
			proc.Kill(); 
		}
		#endregion
	}
}
