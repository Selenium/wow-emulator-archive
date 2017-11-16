using System;
using Server;

// Created by TUM 11.05.05

namespace Server.Scripts.Commands
{
	public class Password : IInitialize
	{
		public static void Initialize()
		{
			Commands.Register( "Password", AccessLevels.PlayerLevel, new CommandEventHandler( Password_OnCommand ) );
		}

		private static bool Password_OnCommand( CommandEventArgs e )
		{
			if ( e.Length == 1 )
			{
				e.Player.Player.Password = e.GetString(0);
				e.SendMessage("Your new password is: {0}", e.GetString(0));
				e.SendMessage("Don't forget it!");
				return true;

			}
			else
			{
				e.SendMessage("Usage : .password <NewPassword>");
				return false;
			}			
		}
	}
}