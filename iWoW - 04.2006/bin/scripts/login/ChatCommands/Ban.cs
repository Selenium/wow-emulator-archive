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
	/// Summary description for Ban.
	/// </summary>
	[ChatCmdHandler()]
	public class Ban
	{
		static Ban()
		{
		}
		[ChatCmdAttribute("Ban", "Usage: Ban <character>|<account>|<IP> [ACCOUNT]")]
		static bool OnBan(LoginClient client, string input)
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
			LoginClient targetClient=null;
			DBAccount targetAccount=null;
			DBBanned targetIP;
			bool foundSomething = false;

			DBCharacter targetChar = (DBCharacter)DataServer.Database.FindObjectByKey(typeof(DBCharacter), target);
			if ((!byAccount) && (targetChar != null))
			{  //Found a character
				targetClient = LoginServer.GetLoginClientByCharacterID(targetChar.ObjectId);
				if (targetClient != null)
				{
					targetAccount = targetClient.Account;
					tgtIP =targetClient.RemoteEndPoint.ToString().Split(':')[0];
				}
				else
				{
					DataObject[] objt = DataServer.Database.SelectObjects(typeof(DBAccount), "Account_ID = '"+targetChar.AccountID+"'");
					if (objt.Length != 0)
						targetAccount = (DBAccount)objt[0];
					foundSomething = true;
				}
			}
			else
				targetAccount = (DBAccount)DataServer.Database.FindObjectByKey(typeof(DBAccount), target);

			if (targetAccount != null)
			{
				if (targetAccount.AccessLvl==ACCESSLEVEL.BANNED)
					Chat.System(client," Account:"+targetAccount.Name+" is already banned");
				else if(client.Account.AccessLvl < targetAccount.AccessLvl)
				{
					Chat.System(client, "You cant ban someone with higher access than you fool!");
					if (targetClient != null)
						Chat.System(targetClient, client.Character.Name+" just tried to ban you!");
					Console.WriteLine(client.Character.Name + " attempted to Ban "+targetClient.Character.Name);
					return true;
				}
				else
				{
					targetAccount.AccessLvl = ACCESSLEVEL.BANNED;
					targetAccount.Dirty=true;
					DataServer.Database.SaveObject(targetAccount);
					Chat.System(client, "Banning Account:"+targetAccount.Name);
					foundSomething = true;
				}
				if (targetClient==null)
					tgtIP=targetAccount.LastIP;
				else
					targetClient.Close("");

			}

//			Chat.System(client,"TgtIP: >"+tgtIP+"<");
			targetIP = (DBBanned)DataServer.Database.FindObjectByKey(typeof(DBBanned), tgtIP);
			if(targetIP != null)
			{
				Chat.System(client,"IP:"+tgtIP+" is already banned");
			}
			else
			{
				targetIP = new DBBanned();
				try
				{
					IPAddress tempIP = IPAddress.Parse(tgtIP);
				}
				catch (Exception)
				{
				}
				finally
				{

					targetIP.BanAddress = tgtIP;
					DateTime tmpDate = DateTime.Now;
					targetIP.BannedDate = tmpDate;
					targetIP.BannedBy = client.Account.Name;
					DataServer.Database.AddNewObject(targetIP);
					Chat.System(client, "Banning IP:"+tgtIP);
					Console.WriteLine("IP:"+tgtIP+" was banned by "+client.Account.Name );
					foundSomething=true;
				}
			}
			if (!foundSomething)
			{
				Chat.System(client,"Could not find anything to ban");
				return false;
			}
			Chat.System(client,"Done");

			return true;
		}
	}
}
