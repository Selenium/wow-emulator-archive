using System;
using Server;

// Created by TUM 11.05.05

namespace Server.Scripts.Commands
{
	public class Where : IInitialize
	{
		public static void Initialize()
		{
			Commands.Register( "Where", AccessLevels.PlayerLevel, new CommandEventHandler( Where_OnCommand ) );
		}

		private static bool Where_OnCommand( CommandEventArgs e )
		{
			e.SendMessage("X = {0}, Y = {1}, Z = {2}, mapID = {3}", e.Player.X, e.Player.Y, e.Player.Z, e.Player.MapId);			
			return true;
		}
	}
}
	