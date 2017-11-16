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
	public class loc
	{
		[ChatCmdAttribute("loc", "loc")]
		static bool OnWorldPort(WorldClient client, string input)
		{
			if( client.Player.AccessLvl <= ACCESSLEVEL.TEMPGM)
			{
				Chat.System(client,"You do not have access to this command");
				return true;
			}
			string[] split = input.Split(' ');
			if(split.Length != 1)
				return false;
			try
			{
				Chat.System(client,"Position x= "+client.Player.Position.X+" y= "+client.Player.Position.Y+" z= "+client.Player.Position.Z+" Facing: "+client.Player.Facing+" Continent: "+client.Player.Continent+" Zone: "+client.Player.Zone);
			}
			catch(Exception)
			{
				return false;
			}
			return true;
		}
	}
}
