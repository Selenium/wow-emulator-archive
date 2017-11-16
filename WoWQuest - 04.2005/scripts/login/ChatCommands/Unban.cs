using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Collections;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.Login;
using WoWDaemon.Database;
using WoWDaemon.Database.DataTables;

//using WoWDaemon.World;
namespace LoginScripts.ChatCommands
{
	/// <summary>
	/// Summary description for Unban.
	/// </summary>
	[ChatCmdHandler()]
	public class Unban
	{
		static Unban()
		{
		}
		[ChatCmdAttribute("Unban", "Usage: Unban <character>|<account>|<IP> [ACCOUNT]")]
		static bool OnUnban(LoginClient client, string input)
		{
			if(client.Account.AccessLvl < ACCESSLEVEL.ADMIN)
			{
				Chat.System(client, "You do not have access to this command");
				return true;
			}
			
			
			string[] split = input.Split(' ');
			bool byAccount = false;
			switch (split.Length)
			{
				case 1:
					return false;
				case 3:
					if (split[2].ToLower()=="account")
						byAccount=true;
					break;
			}
			string target = split[1];
			string tgtIP = split[1];
			DBAccount targetAccount=null;
			DBBanned targetIP;
			bool foundSomething = false;

			DBCharacter targetChar = (DBCharacter)DataServer.Database.FindObjectByKey(typeof(DBCharacter), target);
			if ((!byAccount) && (targetChar != null))
			{  //Found a character
				DataObject[] objt = DataServer.Database.SelectObjects(typeof(DBAccount), "Account_ID = '"+targetChar.AccountID+"'");
				if (objt.Length != 0)
					targetAccount = (DBAccount)objt[0];
				foundSomething = true;
			}
			else
				targetAccount = (DBAccount)DataServer.Database.FindObjectByKey(typeof(DBAccount), target);

			if (targetAccount != null)
			{
				if (targetAccount.AccessLvl==ACCESSLEVEL.BANNED)
				{
					Chat.System(client,"Unbanning Account:"+targetAccount.Name);
					Console.WriteLine(client.Account.Name+" unbanned account: "+targetAccount.Name);
					targetAccount.AccessLvl=ACCESSLEVEL.NORMAL;
					targetAccount.Dirty=true;
					DataServer.Database.SaveObject(targetAccount);
//					DataServer.Database.WriteDatabaseTable(targetAccount.GetType());

				}
				else Chat.System(client, "Account "+targetAccount.Name+" is not banned");
				tgtIP = targetAccount.LastIP;
				foundSomething = true;
			}
//			Chat.System(client,"TgtIP: >"+tgtIP+"<");
			targetIP = (DBBanned)DataServer.Database.FindObjectByKey(typeof(DBBanned), tgtIP);
			if(targetIP != null)
			{
				Chat.System(client,"Unbanning IP:"+tgtIP);
				Console.WriteLine(client.Account.Name+" unbanned IP: "+tgtIP);
				DataServer.Database.DeleteObject(targetIP);
				foundSomething = true;
			}
			else Chat.System(client,"IP Address:"+tgtIP+" is not banned.");

			if (!foundSomething)
			{
				Chat.System(client,"Could not find anything to unban");
				return false;
			}
			Chat.System(client,"Done");
			return true;
		}
	}
}
