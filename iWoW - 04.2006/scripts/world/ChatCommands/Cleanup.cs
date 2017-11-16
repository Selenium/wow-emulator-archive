using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.World;
namespace WorldScripts.ChatCommands
{
	/// <summary>
	/// Summary description for Cleanup.
	/// </summary>
	[ChatCmdHandler()]
	public class Cleanup
	{
		[ChatCmdAttribute("cleanup", "cleanup <radius>")]
		static bool OnCleanUp(WorldClient client, string input)
		{
			if( client.Player.AccessLvl <= ACCESSLEVEL.TEMPGM)
			{
				Chat.System(client,"You do not have access to this command");
				return true;
			}
			string[] split = input.Split(' ');
			if(split.Length != 2)
				return false;
			float radius;
			try
			{
				radius = float.Parse(split[1]);
			}
			catch(Exception)
			{
				return false;
			}
			if(radius > 300.0f)
				radius = 300.0f;
			foreach(UnitBase unit in client.Player.MapTile.Map.GetObjectsInRange(OBJECTTYPE.UNIT, client.Player.Position, radius))
			{
				unit.SaveAndRemove();
			}
			return true;
		}
	}
}
