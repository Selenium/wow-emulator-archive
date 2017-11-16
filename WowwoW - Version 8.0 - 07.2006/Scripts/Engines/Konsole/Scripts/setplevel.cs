// ****************************************************************************
// uvrt
// ****************************************************************************

using System;
using Server;

namespace Server.Konsole.Commands
{
	public class KonsoleSetPLevel : IInitialize
	{
		#region Initialize
		public static void Initialize() 
		{ 
			KonsoleCommands.Register( "SetPLevel", new KonsoleCommandEventHandler( SetPLevel_OnCommand ) );
			KonsoleCommands.Register( "SPL", new KonsoleCommandEventHandler( SetPLevel_OnCommand ) );
		}
		#endregion

		#region Commands
		[Category( "[Maintenance]" )]
		[Usage( "SetPLevel" )]
		[Aliases( "SPL " )]
		[Description( "\tchanges the account level" )]
		
		
		public static void SetPLevel_OnCommand( KonsoleCommandEventArgs e )
		{
		
		Console.Write("Input acc name: "); 
		
		string acc = Console.ReadLine(); 
		if ( acc.Length <= 0 ) return; 
		
		Account a = HelperTools.GetAccByName( acc ); 
		if ( a == null ) return; 
		Console.WriteLine("Current plevel: {0}", a.AccessLevel ); 
			Console.Write("Input account plevel (0-player, 1-gm, 2-admin): "); 
          
			string plevel = Console.ReadLine(); 
			if ( plevel.Length <= 0 ) return; 

			switch ( plevel ) 
			{ 
				case "2": a.AccessLevel = AccessLevels.Admin; break; 
				case "1": a.AccessLevel = AccessLevels.GM; break; 
				default: a.AccessLevel = AccessLevels.PlayerLevel; break; 
			} 
			Console.WriteLine( "User: \"{0}\"; plevel: \"{1}\"", a.Username, a.AccessLevel ); 
		
		}
	
		#endregion 
	}
}
