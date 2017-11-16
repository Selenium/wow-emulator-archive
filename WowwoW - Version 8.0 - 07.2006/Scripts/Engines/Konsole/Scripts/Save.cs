// ****************************************************************************
// Shurugwi
// Date: 2005-Aug-20
// Konsole is base on my Original Remote Console design for RunUO in 2002
// ****************************************************************************

using System;
using Server;

namespace Server.Konsole.Commands
{
	public class KonsoleSave : IInitialize
	{
		#region Initialize
		public static void Initialize() 
		{ 
			KonsoleCommands.Register( "Save", new KonsoleCommandEventHandler( Save_OnCommand ) );
			KonsoleCommands.Register( "S", new KonsoleCommandEventHandler( Save_OnCommand ) );
			
			// A BeforeSave() save event would have been nice to ensure Save()
			// is not called a second time before completeing or enforce this check in the World.Save() if it is not already
			World.onSave += new World.OnSaveDelegate( On_Save );
		}
		#endregion

		#region Commands
		[Category( "[Server]" )]
		[Usage( "Save" )]
		[Aliases( "\tS" )]
		[Description( "\t\tSave World State" )]
		public static void Save_OnCommand( KonsoleCommandEventArgs e )
		{
			Console.Write("Saving...");
			World.Save();
			Console.WriteLine("done");
		}

		private static void On_Save()
		{
			
		}
		#endregion
	}
}
