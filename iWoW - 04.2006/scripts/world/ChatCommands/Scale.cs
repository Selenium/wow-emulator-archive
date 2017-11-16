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
	public class scale
	{
		[ChatCmdAttribute("scale", "scale <Size>")]
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
			float size = 0;
			try
			{
				if(split[1].StartsWith("0x"))
					size = float.Parse(split[1].Substring(2), System.Globalization.NumberStyles.HexNumber);
				else
					size = float.Parse(split[1]);
			}
			catch(Exception)
			{
				Chat.System(client, "Invalid size.");
				return true;
			}

			if(size < .1 | size > 6)
			{
				Chat.System(client, "size cannot be less than .1 or greater than 6");
				return true;
			}
			if(client.Player.Selection == null)
			{
				Chat.System(client, "You must have a valid object targeted!");
				return true;
			}

			LivingObject Mob = ((LivingObject)client.Player.Selection);
			string Mob_name = Mob.Name;
			Chat.System(client, "Setting " + Mob_name + "'s (" + client.Player.Selection.GUID + ") Scale to " + size);
			Mob.Scale = size;
			Mob.UpdateData();
			return true;

		}		
	}
}
