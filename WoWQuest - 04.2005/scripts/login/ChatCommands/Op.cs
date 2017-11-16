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
	public class Op
	{
		static Op()
		{
		}
		[ChatCmdAttribute("Op", "Op <character> <level>")]
		static bool OnOp(LoginClient client, string input)
		{
			if(client.Account.AccessLvl < ACCESSLEVEL.ADMIN)
			{
				Chat.System(client, "You do not have access to this command");
				return true;
			}
//			return true; //temp til command works
			
		string[] split = input.Split(' ');
 			if(split.Length < 2)
				return false;
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

			ACCESSLEVEL NewAccessLevel;
			try
			{
				NewAccessLevel=(ACCESSLEVEL)Enum.Parse(typeof(ACCESSLEVEL),split[2].ToUpper());
			}
			catch (System.ArgumentException  )
			{
				Chat.System(client, "Invalid Access Level");
				Chat.System(client, "Current Access Levels are: ");
				string Levels = "";
				foreach(string level in Enum.GetNames(typeof(ACCESSLEVEL)))
					Levels+=level+" ";
				Chat.System(client, Levels);
				return true;
			}

			targetClient.Account.AccessLvl=NewAccessLevel;

			if (NewAccessLevel!=ACCESSLEVEL.TEMPGM)
			{
				targetClient.Account.Dirty=true;
				DataServer.Database.SaveObject(targetClient.Account);
			}

			ScriptPacket UpdatePlayer= new ScriptPacket(SCRMSG.ACCESSUPDATE);
			UpdatePlayer.Write(targetClient.Character.ObjectId);
			UpdatePlayer.Write((byte)NewAccessLevel);
			client.WorldConnection.Send(UpdatePlayer);

			Chat.System(client, "Update of "+targetClient.Character.Name+ " to "+NewAccessLevel.ToString()+" Successful!");
			Console.WriteLine(targetClient.Character.Name +" was upgraded to "+NewAccessLevel.ToString()+" by "+client.Character.Name );
			return true;
		}
	}
}
