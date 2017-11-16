using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.World;
namespace WorldScripts.ChatCommands
{
	/// <summary>
	/// Summary description for Worldport.
	/// </summary>
	[ChatCmdHandler()]
	public class Worldport
	{
		[ChatCmdAttribute("worldport", "worldport <worldmapid> <x> <y> <z>")]
		static bool OnWorldPort(WorldClient client, string input)
		{
			if( client.Player.AccessLvl <= ACCESSLEVEL.TEMPGM)
			{
				Chat.System(client,"You do not have access to this command");
				return true;
			}
			string[] split = input.Split(' ');
			if(split.Length != 5)
				return false;
			uint worldmapID;
			float x,y,z;
			try
			{
				worldmapID = uint.Parse(split[1]);
				x = float.Parse(split[2]);
				y = float.Parse(split[3]);
				z = float.Parse(split[4]);
			}
			catch(Exception)
			{
				return false;
			}

			if(worldmapID != 1 && worldmapID != 2) // this should probably be done
				// at the loginserver to check if there's such a map and if there's a
				// worldserver for it. but i'm feeling lazy
			{
				Chat.System(client, "That map does not exist or is not allowed to worldport to.");
				return true;
			}
			client.Player.WorldMapID = worldmapID;
			client.Player.Position = new Vector(x, y, z);
			MapManager.ChangeMap(client);
			return true;
		}
	}
}
