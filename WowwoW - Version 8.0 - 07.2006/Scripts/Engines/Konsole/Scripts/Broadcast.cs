// ****************************************************************************
// Shurugwi
// Date: 2005-Aug-20
// Konsole is base on my Original Remote Console design for RunUO in 2002
// ****************************************************************************

using System;
using Server;

namespace Server.Konsole.Commands
{
	public class KonsoleBroadcast : IInitialize
	{
		#region Initialize
		public static void Initialize() 
		{ 
			KonsoleCommands.Register( "Broadcast", new KonsoleCommandEventHandler( Broadcast_OnCommand ) );
			KonsoleCommands.Register( "B", new KonsoleCommandEventHandler( Broadcast_OnCommand ) );
		}
		#endregion

		#region Commands
		[Category( "[Server]" )]
		[Usage( "Broadcast <text>" )]
		[Aliases( "\tB" )]
		[Description( "Broadcasts text to all" )]
		public static void Broadcast_OnCommand( KonsoleCommandEventArgs e )
		{

			if(e.Arguments.Length > 0)
			{
				string arg = e.Arguments[0].ToString();
				HelperTools.BroadcastToAll(arg);
				Console.WriteLine("Broadcast complete.");
			}
			else
			{
				Console.WriteLine("Usage: Broadcast <text>");
			}
		}
		#endregion
	}
}
