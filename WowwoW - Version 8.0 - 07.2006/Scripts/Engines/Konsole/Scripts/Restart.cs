// ****************************************************************************
// Shurugwi
// Date: 2005-Aug-20
// Konsole is base on my Original Remote Console design for RunUO in 2002
// ****************************************************************************

using System;
using Server;

namespace Server.Konsole.Commands
{
	public class KonsoleRestart : IInitialize
	{
		#region Initialize
		public static void Initialize() 
		{ 
			KonsoleCommands.Register( "Restart", new KonsoleCommandEventHandler( Restart_OnCommand ) );
			KonsoleCommands.Register( "R", new KonsoleCommandEventHandler( Restart_OnCommand ) );
			KonsoleCommands.Register( "SaveRestart", new KonsoleCommandEventHandler( SaveRestart_OnCommand ) );
			KonsoleCommands.Register( "SR", new KonsoleCommandEventHandler( SaveRestart_OnCommand ) );
		}
		#endregion

		#region Commands
		[Category( "[Server]" )]
		[Usage( "Restart <minutes>" )]
		[Aliases( "\tR" )]
		[Description( "Restarts the server" )]
		public static void Restart_OnCommand( KonsoleCommandEventArgs e )
		{

			if(e.Arguments.Length > 0)
			{
				string arg = e.Arguments[0].ToString();
				if(HelperTools.IsNumeric(arg) )
				{
					string bcMsg = string.Format("Restarting in {0} {1}", arg, int.Parse(arg) > 1 ? "minutes" : "minute");
					Console.WriteLine( bcMsg );
					HelperTools.BroadcastToAll( bcMsg );
					World.Restart( int.Parse(arg) );
				}
				else
				{
					Console.WriteLine("Restart requires a numeric value as parameter.");
					return;
				}
			}
			else
			{
				Console.Write("Restarting now");
				HelperTools.BroadcastToAll("Server is restarting now");
				World.Restart(0);
			}
		}

		[Category( "[Server]" )]
		[Usage( "SaveRestart <minutes>" )]
		[Aliases( "\tSR" )]
		[Description( "Saves then Restarts" )]
		private static void SaveRestart_OnCommand( KonsoleCommandEventArgs e )
		{
			Console.Write("Saving...");
			World.Save();
			Console.WriteLine("done");

			Restart_OnCommand(e);
		}
		#endregion
	}
}
