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
	public class Money
	{
		[ChatCmdAttribute("money", "money <qty>")]
		static bool OnMoney(WorldClient client, string input)
		{
			if(client.Player.AccessLvl < ACCESSLEVEL.ADMIN)
			{
				Chat.System(client, "You do not have access to this command");
				return true;
			}			
			string[] split = input.Split(' ');
			if(split.Length != 2)
				return false;
			int money = 0;
			try
			{
				if(split[1].StartsWith("0x"))
					money = int.Parse(split[1].Substring(2), System.Globalization.NumberStyles.HexNumber);
				else
					money = int.Parse(split[1]);
			}
			catch(Exception)
			{
				Chat.System(client, "Invalid moneycount.");
				return true;
			}
			client.Player.Money += money;
			client.Player.UpdateData();
			Chat.System(client, "Your gained " + money + " coins.");
			return true;
		}		
	}
}
