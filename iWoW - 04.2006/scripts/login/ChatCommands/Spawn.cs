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
	public class Spawn
	{
		static Spawn()
		{
		}
		[ChatCmdAttribute("createtest", "createtest <name> <displayid> [<level>] [<faction>] [<roam>] [<title>]")]
		[ChatCmdAttribute("createbank", "createbank <name> <displayid> [<level>] [<faction>] [<roam>] [<title>]")]
		[ChatCmdAttribute("createtabard", "createtabard <name> <displayid> [<level>] [<faction>] [<roam>] [<title>]")]
		[ChatCmdAttribute("createtrainer", "createtrainer <name> <displayid> [<level>] [<faction>] [<roam>] [<title>]")]
		[ChatCmdAttribute("createtalker", "createtalker <name> <displayid> [<level>] [<faction>] [<roam>] [<title>]")]
		[ChatCmdAttribute("createquester", "createquester <name> <displayid> [<level>] [<faction>] [<roam>] [<title>]")]
		[ChatCmdAttribute("createvendor", "createvendor <name> <displayid> [<level>] [<faction>] [<roam>] [<title>]")]
		[ChatCmdAttribute("createtaxi", "createtaxi <name> <displayid> [<level>] [<faction>] [<roam>] [<title>]")]
		[ChatCmdAttribute("spawn", "spawn <name> <displayid> [<level>] [<faction>] [<roam>] [<title>] [<health>]")]
		static bool OnSpawn(LoginClient client, string input)
		{
			if(client.Account.AccessLvl < ACCESSLEVEL.TEMPGM)
			{
				Chat.System(client, "You do not have access to this command");
				return true;
			}
			bool isVendor=false;
			char[] delim= new char[2];
			delim[0]='\"';
			delim[1]='^';
			string[] split = input.Split(delim);
			string script = "WorldScripts.Living.";
// Rewritten by Phaze so that only the first 2 parameters are necessary, and has defaults for the rest
			string name="";
			int displayID = 0;
			int level=1;
			int health=1;
			int mana=1;
			int faction=14;
			uint npc_flags=0;
//			string facString="monster";
			string subName="";
			bool bWalking=true;
			string cmd = "";
			string input2="";

			if(split.Length == 3)
			{
				cmd=split[0].TrimEnd(delim); 
				cmd=split[0].TrimEnd(' '); 
				name = split[1];
				input2 = "cmd name"+split[2];

			}
			else if(split.Length == 1)
			{
				split = input.Split(' ');
				if (split.Length==1) {return false;}
				cmd=split[0];
				name=split[1];
				input2 = input;
			}
			else
				return false;

			split = input2.Split(' ');

			if(split.Length > 2)
			{
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

				if(cmd.Length>6)
					isVendor=true;

				if(split.Length > 3)
				{
					level = int.Parse(split[3]);
					if ( level == 0 )
						level = 1;
					if(split.Length>4)
					{
//						facString=split[4];
// New code so that faction can be assigned by name or number - Phaze
						FACTION NewFaction;
						try
						{
							NewFaction=(FACTION)Enum.Parse(typeof(FACTION),split[4].ToUpper());
						}
						catch (System.ArgumentException  )
						{
							Chat.System(client, "Invalid Faction");
							Chat.System(client, "Available Factions are: ");
							string Factions = "";
							foreach(string eFaction in Enum.GetNames(typeof(FACTION)))
								Factions+=eFaction+", ";
							Chat.System(client, Factions);
							return true;
						}
						faction=(int)NewFaction;

						if(split.Length>5)
						{
							try
							{
								bWalking=bool.Parse(split[5]);
							}
							catch(Exception)
							{
								Chat.System(client, "Walking must be either TRUE or FALSE");
								return true;
							}
							if(split.Length>6)
							{
								subName=split[6];
								if(split.Length >7)
									health = int.Parse(split[7]);
//									script += split[7];
							}
						}
					}
				}
			if ( health < 2 )
				health = 25+50*level;

			}
			else
				return false;
			if(isVendor)
			{
				switch (cmd.ToLower())
				{
					case "createtalker":
						npc_flags=1;
						Chat.System(client, "Creating Talker: "+name);
						break;
					case "createquester":
						npc_flags=2;
						Chat.System(client, "Creating Quester: "+name);
						break;
					case "createvendor":
						npc_flags=4;
						subName="Merchant";
						Chat.System(client, "Creating Vendor: "+name);
						break;
					case "createtrainer":
						npc_flags=80;
						subName="Trainer";
						Chat.System(client, "Creating Trainer: "+name);
						break;
					case "createtaxi":
						npc_flags=200;
						subName="Taxi Vendor";
						Chat.System(client, "Creating Taxi Vendor: "+name);
						break;
					case "createtabard":
						npc_flags=512; //512 for tabard
						subName="Tabard Vendor";
						Chat.System(client, "Creating Tabard Vendor: "+name);
						break;
					case "createbank":
						npc_flags=128; // This was for testing...  Phaze
						subName="Banker";
						Chat.System(client, "Creating Banker: "+name);
						break;
					case "createtest":
						npc_flags=96; // This was for testing...  Phaze
						subName="Test Vendor 96";
						Chat.System(client, "Creating Test Vendor: "+name);
						break;

				}
				if (faction==14) {faction=0;}
				script+="VendorBase";
				health=1000;
				bWalking=false;
			}
			else
				script += "MonsterBase";

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
				creature.Script = script;
				creature.Title = subName;
				creature.Roam = bWalking;
				creature.NPCFlags = npc_flags;
				DataServer.Database.AddNewObject(creature);
			}
			else
				creature = (DBCreature)objs[0];

			DBSpawn spawn = new DBSpawn();
			spawn.Creature = creature;
			spawn.CreatureID = creature.ObjectId;
			spawn.Level = level;
			spawn.Health = health;
			spawn.Power = mana;
			spawn.DisplayID = displayID;
			spawn.Faction = faction;
			spawn.Roam = bWalking;
			DataServer.Database.AddNewObject(spawn);
			
			client.WorldConnection.Send(creature);
			client.WorldConnection.Send(spawn);

			ScriptPacket pkg = new ScriptPacket(SCRMSG.SPAWN);
			pkg.Write(client.Character.ObjectId);
			pkg.Write(creature.ObjectId);
			pkg.Write(spawn.ObjectId);
			client.WorldConnection.Send(pkg);
			return true;
		}

	}
}
