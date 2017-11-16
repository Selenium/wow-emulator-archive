using System;
using Server;

// Created by TUM 11.05.05

namespace Server.Scripts.Commands
{
	public class Guid : IInitialize
	{
		public static void Initialize()
		{
			Commands.Register( "Guid", AccessLevels.GM, new CommandEventHandler( Guid_OnCommand ) );
		}

		private static bool Guid_OnCommand( CommandEventArgs e )
		{
			e.SendMessage("Guid: {0}", e.Player.Guid.ToString("X16"));		
			return true;
		}
	}
}