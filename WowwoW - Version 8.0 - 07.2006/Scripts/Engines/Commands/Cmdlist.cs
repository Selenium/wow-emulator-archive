/*****************************************
 * 
 * 
 * Create by ShaiHulud (ShaiDeath)
 * This script only beta version and may be bugged
 * 
 * *************************************/
using System;
using Server;
using System.Collections;

namespace Server.Scripts.Commands
{
	public class cmdlist : IInitialize
	{
		public static void Initialize()
		{
			Commands.Register( "cmdlist", AccessLevels.GM, new CommandEventHandler( cmdlist_OnCommand ) );			
		}

		private static bool cmdlist_OnCommand( CommandEventArgs e )
		{
			e.Player.SendMessage("Server commands list: ");
			foreach (DictionaryEntry entry in Server.Scripts.Commands.Commands.Entries)
			{
				if (entry.Key is String)
				{
					if (e.AccessLevel<= e.Player.Player.AccessLevel)
					{
						e.SendMessage("." + (string)entry.Key);
					}
				}

			}
			e.SendMessage("End of commands list.");
			return true;
		}
	}
}