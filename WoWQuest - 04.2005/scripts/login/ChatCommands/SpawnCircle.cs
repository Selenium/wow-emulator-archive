using System;
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
	//[ChatCmdHandler()]
	public class SpawnCircle
	{
		/// <summary>
		/// Spawns a temp mob on a worldmap
		/// </summary>
		/// <param name="client"></param>
		/// <param name="input"></param>
		//[ChatCmdAttribute("spawncircle", "spawncircle <name> <displayid>")]
		static bool OnSpawnCircle(LoginClient client, string input)
		{
			
			if(client.Account.AccessLvl < ACCESSLEVEL.GM)
			{
				Chat.System(client, "You do not have access to this command");
				return true;
			}
			
			string[] split = input.Split('\"');
			if(split.Length == 3)
			{
				split[2] = split[2].TrimStart(' ');
			}
			else if(split.Length == 1)
			{
				split = input.Split(' ');
			}

			if(split.Length != 3)
				return false;
			int displayID = 0;
			try
			{
				if(split[2].StartsWith("0x"))
					displayID = int.Parse(split[2].Substring(2), System.Globalization.NumberStyles.HexNumber);
				else
					displayID = int.Parse(split[2]);
			}
			catch(Exception)
			{
				return false;
			}
			if(displayID == 0)
			{
				Chat.System(client, "You must set a displayID.");
				return true;
			}

			string name = split[1];
			name = name.Replace("'", ""); // bleh!!
			if(name.Length > 20)
				name = name.Substring(0, 20);
			DataObject[] objs;
			try
			{
				objs = DataServer.Database.SelectObjects(typeof(DBCreature), "Name = '" + name + "'");
			}
			catch(Exception)
			{
				Chat.System(client, "Error looking up name in database.");
				return true;
			}

			DBCreature creature;
			if(objs.Length == 0)
			{
				creature = new DBCreature();
				creature.Name = name;
				DataServer.Database.AddNewObject(creature);
			}
			else
				creature = (DBCreature)objs[0];
			
			client.WorldConnection.Send(creature);

			ScriptPacket pkg = new ScriptPacket(SCRMSG.SPAWNCIRCLE);
			pkg.Write(client.Character.ObjectId);
			pkg.Write(creature.ObjectId);
			pkg.Write(displayID);
			client.WorldConnection.Send(pkg);
			return true;
		}
	}
}