/*****************************************
 * 
 * 
 * Create by ShaiHulud (ShaiDeath)
 * This script only beta version and may be bugged
 * 
 * *************************************/
using System;
using System.Collections;
using Server;
using Server.Scripts;

using Server.Scripts.Properties;

namespace Server.Scripts.Commands
{
	public class Props : IInitialize
	{
		public static void Initialize()
		{
			Commands.Register( "Props", AccessLevels.GM, new CommandEventHandler( Props_OnCommand ), TargetType.AnyMobile );
		}

		private static bool Props_OnCommand( CommandEventArgs e )
		{
			e.Player.SendMessage(e.Target.Name + " property list: ");
			if (e.Target is Character)
			{
				e.Player.SendMessage("[Character propertes]");
				foreach (DictionaryEntry entry in Server.Scripts.Properties.CharacterProperties.GetEntries)
				{
					if ((entry.Key is String) && (Server.Scripts.Properties.CharacterProperties.GetAccessLevel((string)entry.Key)<=e.Player.Player.AccessLevel))
					{
						string val = Server.Scripts.Properties.CharacterProperties.GetValue(e.Target, (string)(entry.Key));
						e.Player.SendMessage((string)entry.Key + " : " + val);
					}
				}
			}
			e.Player.SendMessage("[Mobile propertes]");
			foreach (DictionaryEntry entry in Server.Scripts.Properties.MobileProperties.GetEntries)
			{
				if ((entry.Key is String) && (Server.Scripts.Properties.CharacterProperties.GetAccessLevel((string)entry.Key)<=e.Player.Player.AccessLevel))
				{
					string val = Server.Scripts.Properties.MobileProperties.GetValue(e.Target, (string)(entry.Key));
					e.Player.SendMessage((string)entry.Key + " : " + val);
				}
			}
			e.Player.SendMessage("End of property list.");
			return true;
		}

	}
}