using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.World;
namespace WorldScripts.ChatCommands
{
	/// <summary>
	/// Summary description for Mountmodel.
	/// </summary>
	//[ChatCmdHandler()]
	public class Mountmodel
	{
		//[ChatCmdAttribute("mountmodel", "mountmodel <displayID>")]
		static bool OnMountModel(WorldClient client, string input)
		{
			if( client.Player.AccessLvl <= ACCESSLEVEL.TEMPGM)
			{
				Chat.System(client,"You do not have access to this command");
				return true;
			}
			string[] split = input.Split(' ');
			if(split.Length != 2)
				return false;
			if(client.Player.MountDisplayID != 0)
			{
				Chat.System(client, "You must '!dismount' first.");
				return true;
			}

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
			client.Player.Flags |= 0x3000;
			client.Player.MountDisplayID = displayID;
			client.Player.UpdateData();
			return true;
		}
	}
}
