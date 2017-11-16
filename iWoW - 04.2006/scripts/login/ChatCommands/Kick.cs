using System;
using System.Text.RegularExpressions;
using System.Collections;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.Login;
using WoWDaemon.Database.DataTables;
using WoWDaemon.Database;
namespace LoginScripts.ChatCommands
{
	/// <summary>
	/// Summary description for Spawn.
	/// </summary>
	[ChatCmdHandler()]
	public class Kick
	{
		static Kick()
		{
		}
		[ChatCmdAttribute("Kick", "Kick <character>")]
		static bool OnKick(LoginClient client, string input)
		{
			if(client.Account.AccessLvl < ACCESSLEVEL.GM)
			{
				Chat.System(client, "You do not have access to this command");
				return true;
			}
						
			string[] split = input.Split(' ');
//			if(split.Length == 3)
//			{
//				split[2] = split[2].TrimStart(' ');
//			}
  			if(split.Length == 1)
				return false;
//			{
//				split = input.Split(' ');
//			}
			string target=split[1];
			DataObject[] objs = DataServer.Database.SelectObjects(typeof(DBCharacter), "Name = '" + target + "'");
			if(objs.Length == 0)
			{
				Chat.System(client, "No such player.");
				return true;
			}

			LoginClient targetClient = LoginServer.GetLoginClientByCharacterID(objs[0].ObjectId);
			if(targetClient == null || targetClient.Character == null)
			{
				Chat.System(client, "That player is not online.");
				return true;
			}
			string tgtCharacter=targetClient.Character.Name;
			targetClient.Close("");

			Chat.System(client, "Kick of "+tgtCharacter+ " Successful!");
			Console.WriteLine(tgtCharacter+" was kicked by "+client.Character.Name );//+"("+split[2]);

//			ScriptPacket pkg = new ScriptPacket(0x01);
//			pkg.Write(client.Character.ObjectId);
//			pkg.Write(creature.ObjectId);
//			pkg.Write(displayID);
//			pkg.Write(faction);
//			pkg.Write(script);
//			pkg.Write(level);
//			pkg.Write(health);
//			pkg.Write(mana);
//			client.WorldConnection.Send(pkg);
			return true;
		}
	}
}
