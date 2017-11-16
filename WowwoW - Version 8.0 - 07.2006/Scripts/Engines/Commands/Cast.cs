using System;
using Server;

// Created by TUM 11.05.05

namespace Server.Scripts.Commands
{
	public class Cast : IInitialize
	{
		public static void Initialize()
		{
			Commands.Register( "Cast", AccessLevels.GM, new CommandEventHandler( Cast_OnCommand ));
		}

		private static bool Cast_OnCommand( CommandEventArgs e )
		{
			if (e.Length == 1)
			{
				try
				{
					e.Player.FakeCast(e.GetInt32(0), e.Target);
					return true;
				}
				catch (Exception)
				{
					e.SendMessage("Invalid spell id or spell needs in target!");
					return false;
				}
			}
			else
			{
				e.SendMessage("Usage: .Cast <Spell Id>");
				return false;
			}
		}
	}
}