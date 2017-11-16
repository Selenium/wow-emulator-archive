// ****************************************************************************
// uvrt
// ****************************************************************************

using System;
using Server;

namespace Server.Konsole.Commands
{
	public class KonsoleStatus : IInitialize
	{
		#region Initialize
		public static void Initialize() 
		{ 
			KonsoleCommands.Register( "Status", new KonsoleCommandEventHandler( Status_OnCommand ) );
			KonsoleCommands.Register( "ST", new KonsoleCommandEventHandler( Status_OnCommand ) );
		}
		#endregion

		#region Commands
		[Category( "[Server]" )]
		[Usage( "Status" )]
		[Aliases( "\tST" )]
		[Description( "\tShow world information" )]
		public static void Status_OnCommand( KonsoleCommandEventArgs e )
		{

			Console.WriteLine("\n--------=[( Statistics )]=--------"); 
			Console.WriteLine("> Accounts:{0}\t",      World.allAccounts.Count ); 
			Console.WriteLine("> Characters:{0}\t",      World.allConnectedChars.Count ); 
			Console.WriteLine("> GameObjects:{0}\t",   World.allGameObjects.Count ); 
			Console.WriteLine("> Mobiles:{0}\t",      World.allMobiles.Count ); 
			Console.WriteLine("--------==================--------\n"); 
		}
		#endregion
	}
}
