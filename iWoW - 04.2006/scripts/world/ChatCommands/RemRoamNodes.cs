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
	public class RemRoamNodes
	{
		[ChatCmdAttribute("RemRoamNodes", "RemRoamNodes")]
		static bool OnRemRoamNodes(WorldClient client, string input)
		{
			if(client.Player.AccessLvl < ACCESSLEVEL.GM)
			{
				Chat.System(client, "You do not have access to this command");
				return true;
			}			
			string[] split = input.Split(' ');
			if(split.Length != 1)
				return false;
//			int level = 0;
			if(client.Player.Selection == null)
			{
				Chat.System(client, "You have to select a mob to do that");
				return true;
			} 
			else 
			{
				if (client.Player.Selection.ObjectType == OBJECTTYPE.UNIT) {
					UnitBase unit = (UnitBase)client.Player.Selection;
					unit.RoamingNodes = null;
					unit.IsRoaming = false;
					return true;

				} 
				else 
				{
					Chat.System(client, "Your must target a mob.");
					return true;
				}
			}
		}		
	}
}
