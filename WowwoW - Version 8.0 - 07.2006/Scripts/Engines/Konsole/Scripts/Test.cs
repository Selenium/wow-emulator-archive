// ****************************************************************************
// Shurugwi
// Date: 2005-Aug-20
// Konsole is base on my Original Remote Console design for RunUO in 2002
// ****************************************************************************

using System;
using Server;

namespace Server.Konsole.Commands
{
	public class KonsoleTest : IInitialize
	{
		#region Initialize
		public static void Initialize() 
		{ 
			KonsoleCommands.Register( "Test", new KonsoleCommandEventHandler( Test_OnCommand ) );
			KonsoleCommands.Register( "tt", new KonsoleCommandEventHandler( Test_OnCommand ) );
		}
		#endregion

		#region Commands
		[Category( "[Testing]" )]
		[Usage( "Test" )]
		[Aliases( "\ttt" )]
		[Description( "\t\tTest Console script" )]
		public static void Test_OnCommand( KonsoleCommandEventArgs e )
		{
			Console.WriteLine("LEN: " + e.Length + " TEXT: " + e.ArgString + " ARGS: " + e.Arguments.Length);
			for ( int i = 0; i < e.Length; ++i )
			{
				Console.WriteLine("ARG: " + e.Arguments[i]);
			}
		}
		#endregion
	}
}
