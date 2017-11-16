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
	public class PlayerLevel
	{
		[ChatCmdAttribute("playerlevel", "playerlevel <level>")]
		static bool Onscale(WorldClient client, string input)
		{
			if(client.Player.AccessLvl < ACCESSLEVEL.GM)
			{
				Chat.System(client, "You do not have access to this command");
				return true;
			}			
			string[] split = input.Split(' ');
			if(split.Length != 2)
				return false;
			int level = 0;
			try
			{
				if(split[1].StartsWith("0x"))
					level = int.Parse(split[1].Substring(2), System.Globalization.NumberStyles.HexNumber);
				else
					level = int.Parse(split[1]);
			}
			catch(Exception)
			{
				Chat.System(client, "Invalid level.");
				return true;
			}

			if(level < 1 || level > 60)
			{
				Chat.System(client, "Level cannot be less than 1 or greater than 60");
				return true;
			}
			if(client.Player.Selection == null)
			{
				client.Player.Level = level - 1;
				client.Player.LevelUp();
				Chat.System(client, "You set your level to " + level + ".");
				return true;
			} else {
				if (client.Player.Selection.ObjectType == OBJECTTYPE.PLAYER) {
					PlayerObject pobj = (PlayerObject)client.Player.Selection;
					pobj.Level = level - 1;
					pobj.LevelUp();
					Chat.System(client, "You set " + pobj.Name + " level to " + level + ".");
					return true;

				} else {
					Chat.System(client, "Your must target a player or dont have a target selected to level yourself.");
					return true;
				}
			}
		}		
	}
}
