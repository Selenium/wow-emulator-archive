using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.World;
namespace WorldScripts.ChatCommands
{
	/// <summary>
	/// Summary description for scale.
	/// </summary>
	[ChatCmdHandler()]
	public class Flags
	{
		[ChatCmdAttribute("Flag", "flag <int>")]
		static bool OnFlag(WorldClient client, string input)
		{
			if(client.Player.AccessLvl < ACCESSLEVEL.ADMIN)
			{
				Chat.System(client, "You do not have access to this command");
				return true;
			}			
			string[] split = input.Split(' ');
			if(split.Length != 2)
				return false;
			uint flag = 0;
			try
			{
				if(split[1].StartsWith("0x"))
					flag = uint.Parse(split[1].Substring(2), System.Globalization.NumberStyles.HexNumber);
				else
					flag = uint.Parse(split[1]);
			}
			catch(Exception)
			{
				Chat.System(client, "Invalid Flag.");
				return true;
			}
			client.Player.Flags += flag;
			client.Player.UpdateData();
			Chat.System(client, "You have set flag +"+flag+" for you");
			return true;
		}		
	}
}