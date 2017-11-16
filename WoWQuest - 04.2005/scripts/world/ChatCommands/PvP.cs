using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.World;
namespace WorldScripts.ChatCommands
{
	/// <summary>
	/// Summary description for Cancom.
	/// </summary>
	[ChatCmdHandler()]
	public class PvP
	{
		[ChatCmdAttribute("PvP", "PvP")]
		static bool OnPvP(WorldClient client, string input)
		{
			if( client.Player.AccessLvl <= ACCESSLEVEL.TEMPGM)
			{
				Chat.System(client,"You do not have access to this command");
				return true;
			}
			client.Player.PvP=!client.Player.PvP;
			Chat.System(client, "PvP is now set to "+(client.Player.PvP?"ON":"OFF"));
			return true;
		}
	}
}
