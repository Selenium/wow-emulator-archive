using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.World;

namespace WorldScripts.ChatCommands
{
	/// <summary>
	/// Summary description for Morph.
	/// </summary>
	[ChatCmdHandler()]
	public class Morph
	{
		[ChatCmdAttribute("morph", "morph <displayID>")]
		static bool OnMorph(WorldClient client, string input)
		{
			if( client.Player.AccessLvl <= ACCESSLEVEL.TEMPGM)
			{
				Chat.System(client,"You do not have access to this command");
				return true;
			}

			string[] split = input.Split(' ');
			if(split.Length != 2)
				return false;
			int displayID = 0;
			try
			{
				if(split[1].StartsWith("0x"))
					displayID = int.Parse(split[1].Substring(2), System.Globalization.NumberStyles.HexNumber);
				else
					displayID = int.Parse(split[1]);
			}
			catch(Exception)
			{
				Chat.System(client, "Invalid displayID.");
				return true;
			}

			if(displayID == 0)
			{
				Chat.System(client, "DisplayID cannot be 0!");
				return true;
			}
			client.Player.DisplayID = displayID;
			client.Player.UpdateData();
			return true;
		}
	}
}
