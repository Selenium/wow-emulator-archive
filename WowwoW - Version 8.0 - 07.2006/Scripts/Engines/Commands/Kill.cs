using System;
using Server;

// Created by TUM 11.05.05

namespace Server.Scripts.Commands
{
	public class Kill : IInitialize
	{
		public static void Initialize()
		{
			Commands.Register( "Kill", AccessLevels.GM, new CommandEventHandler( Kill_OnCommand ), TargetType.AnyMobile);
		}

		private static bool Kill_OnCommand( CommandEventArgs e )
		{
			e.Target.LooseHits(e.Player, e.Target.BaseHitPoints);
			return true;
		}
	}
}