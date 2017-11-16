/*****************************************
 * 
 * 
 * Create by ShaiHulud (ShaiDeath)
 * This script only beta version and may be bugged
 * 
 * Based on .learn .money .save Commands by Freundschaft
 * 
 * 
 * *************************************/
using System;
using Server;

namespace Server.Scripts.Commands
{
	public class Learn : IInitialize
	{
		public static void Initialize()
		{
			Commands.Register( "Learn", AccessLevels.GM, new CommandEventHandler( Learn_OnCommand ), TargetType.PlayerOnly );
		}

		private static bool Learn_OnCommand( CommandEventArgs e )
		{
			if ( e.Length == 0 )
			{
				e.SendMessage("Usage: .learn <ID>");
				return false;
			}
			int id = e.GetInt32( 0 );
			e.Target.LearnSpell(Convert.ToInt32(id));
			e.SendMessage("Character \"{0}\" has learned spell with ID = \"{1}\"", e.Target.Name, id );
			return true;
		}
	}
}