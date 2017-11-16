// ****************************************************************************
// uvrt
// ****************************************************************************

using System;
using Server;

namespace Server.Konsole.Commands
{
	public class KonsoleCreateAccount : IInitialize
	{
		#region Initialize
		public static void Initialize() 
		{ 
			KonsoleCommands.Register( "CreateAccount", new KonsoleCommandEventHandler( CreateAccount_OnCommand ) );
			KonsoleCommands.Register( "CA", new KonsoleCommandEventHandler( CreateAccount_OnCommand ) );
		}
		#endregion

		#region Commands
		[Category( "[Maintenance]" )]
		[Usage( "CreateAccount" )]
		[Aliases( "\tCA" )]
		[Description( "\tCreate new Account" )]
		public static void CreateAccount_OnCommand( KonsoleCommandEventArgs e )
		{

			Console.Write("Input account name: "); 
			string name = Console.ReadLine(); 
			if ( HelperTools.AccExists( name ) ) 
			{ 
				Console.WriteLine( "This name already exists, try another.." ); 
				return; 
			} 
			Console.Write("Input account password: "); 
			string pass = Console.ReadLine(); 
			Console.Write("Input account plevel (0-player, 1-gm, 2-admin): "); 
			string splevel = Console.ReadLine(); 
			AccessLevels plevel = AccessLevels.PlayerLevel; 
			switch ( splevel ) 
			{ 
				case "2": { plevel = AccessLevels.Admin; break; } 
				case "1": { plevel = AccessLevels.GM; break; } 
				default:  { plevel = AccessLevels.PlayerLevel; break; } 
			} 
			World.allAccounts.Add( new Account( name, pass, plevel ) ); 
			Console.WriteLine( "Account: \"{0}\", pass: \"{1}\", plevel: \"{2}\" created", name, pass, plevel ); 
		}
		#endregion
	}
}
