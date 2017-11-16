// ****************************************************************************
// uvrt
// ****************************************************************************

using System;
using Server;

namespace Server.Konsole.Commands
{
	public class KonsoleAccountList : IInitialize
	{
		#region Initialize
		public static void Initialize() 
		{ 
			KonsoleCommands.Register( "AccountList", new KonsoleCommandEventHandler( AccountList_OnCommand ) );
			KonsoleCommands.Register( "AL", new KonsoleCommandEventHandler( AccountList_OnCommand ) );
		}
		#endregion

		#region Commands
		[Category( "[Maintenance]" )]
		[Usage( "AccountList" )]
		[Aliases( "\tAL " )]
		[Description( "\tshow all accounts" )]
		
	     public static void AccountList_OnCommand(KonsoleCommandEventArgs e)
			{ 
				Console.WriteLine( "Account list:" ); 
				foreach ( Account a in World.allAccounts ) 
				{ 
					Console.WriteLine( "\t\"{0}\"", a.Username ); 
				} 
				Console.WriteLine( "Total: {0} accounts.", World.allAccounts.Count ); 
		 
			} 
		#endregion 
	}
}
