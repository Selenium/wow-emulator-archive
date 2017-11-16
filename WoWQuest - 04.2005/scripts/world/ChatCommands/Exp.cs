using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.World;
using WoWDaemon.Database.DataTables;
using WoWDaemon.Database;

namespace WorldScripts.ChatCommands
{
	/// <summary>
	/// Summary description for Experience.
	/// </summary>
	[ChatCmdHandler()]
	public class exp
	{
		[ChatCmdAttribute("exp", "exp <number>")]
		static bool OnExp(WorldClient client, string input)
		{
			if(client.Player.AccessLvl < ACCESSLEVEL.TEMPGM)
			{
				Chat.System(client, "You do not have access to this command");
				return true;
			}

			string[] split = input.Split(' ');
			if(split.Length != 2)
				return false;
			int level = client.Player.Level;
			int exp = client.Player.Exp;
			try
			{
				if(split[1].StartsWith("0x"))
					exp = int.Parse(split[1].Substring(2), System.Globalization.NumberStyles.HexNumber);
				else
					exp = int.Parse(split[1]);
			}
			catch(Exception)
			{
				Chat.System(client, "Invalid experience amount.");
				return true;
			}

			if(exp == 0)
			{
				Chat.System(client, "Experience cannot be 0!");
				return true;			
			}
			client.Player.GainXp(exp, 0);
			return true;
		}
	}
}

       
