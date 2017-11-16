using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.World;
using WoWDaemon.Database.DataTables;
using WoWDaemon.Database;

namespace WorldScripts.ChatCommands
{
	/// <summary>
	/// Summary description for Experience.
	/// </summary>
	/// 

	
	[ChatCmdHandler()]
	public class MobCommands
	{
		
		[ChatCmdAttribute("level", "level <level>")]
		static bool OnLevel(WorldClient client, string input)
		{
			if(client.Player.AccessLvl < ACCESSLEVEL.TEMPGM)
			{
				Chat.System(client, "You do not have access to this command");
				return true;
			}
			string[] split = input.Split(' ');
			if(split.Length != 2)
				return false;
			int level = 0;
			try
			{
				if(split[1].StartsWith("0x"))
					level = int.Parse(split[1].Substring(2), System.Globalization.NumberStyles.HexNumber);
				else
					level = int.Parse(split[1]);
			}
			catch(Exception)
			{
				Chat.System(client, "Invalid level.");
				return true;
			}

			if(level < 1 | level > 255)
			{
				Chat.System(client, "level must be between 1 and 255!");
				return true;
			}

			if(client.Player.Selection == null)
			{
				Chat.System(client, "You must have a valid object targeted!");
				return true;
			}

			LivingObject mob = ((LivingObject)client.Player.Selection);
			string mob_name = mob.Name;
			Chat.System(client, "Setting " + mob_name + " ( " + client.Player.Selection.GUID + " )  level to " + level);
			mob.Level = level;
			StatManager.CalculateNewStats(mob);
			mob.Health = mob.MaxHealth;
			mob.Power = mob.MaxPower;
			mob.UpdateData();
			return true;
		}


		[ChatCmdAttribute("title", "title \"<title>\" ")]
		static bool OnTitle(WorldClient client, string input)
		{
			if(client.Player.AccessLvl < ACCESSLEVEL.TEMPGM)
			{
				Chat.System(client, "You do not have access to this command");
				return true;
			}

			char[] delim= new char[2];
			delim[0]='\"';
			delim[1]='^';
			string[] split = input.Split(delim);
			
/*
			DataObject[] obj = DataServer.Database.SelectObjects(typeof(DBVendor), "GUID='"+client.Character.Selected+"'");
			if (obj==null || obj.Length==0)
			{
				Chat.System(client, "Vendor not found");
				return true;
			}
			DBVendor vendor = (DBVendor)obj[0];
			DBSpawn spawn = DataServer.Database.FindObjectByKey(typeof(DBSpawn), vendor.SpawnID);
*/
			UnitBase target = ((UnitBase)client.Player.Selection);
			if (target == null)
			{
				Chat.System(client, "Please select a mob or NPC first.");
				return false;
			}
			
			DBSpawn spawn = (DBSpawn)DBManager.GetDBObject(typeof(DBSpawn), (uint)target.Spawn_ID);
			if (spawn == null)
			{
				Chat.System(client, "Please select a mob or NPC first.");
				return false;
			}

			spawn.Creature = (DBCreature)DBManager.GetDBObject(typeof(DBCreature), spawn.CreatureID);
			if (spawn.Creature == null)
			{
				Chat.System(client, "Could not find creature");
				return false;
			}

			if (split.Length!=1)
				spawn.Creature.Title=split[1];

			else
			{
				split=input.Split(' ');
				if (split.Length==1) return false;
				spawn.Creature.Title=split[1];
			}
			DBManager.SaveDBObject(spawn.Creature);
			ServerPacket w = new ServerPacket(SMSG.CREATURE_QUERY_RESPONSE);
//			BinWriter w = new Binwriter(); //LoginClient.NewPacket(SMSG.CREATURE_QUERY_RESPONSE);
			w.Write(spawn.Creature.ObjectId);
			w.Write(spawn.Creature.Name);
			w.Write(spawn.Creature.Name1);
			w.Write(spawn.Creature.Name2);
			w.Write(spawn.Creature.Name3);
			w.Write(spawn.Creature.Title);
			w.Write(spawn.Creature.Flags);
			w.Write(spawn.Creature.CreatureType);
			w.Write(spawn.Creature.CreatureFamily);
			w.Write(0); // unknown
			w.Finish();
			client.Player.MapTile.Map.Send(w, target.Position, 250f);
//			return true;


			target.SaveAndRemove();
			Type scriptType = Type.GetType(spawn.Creature.Script);
			//	Console.WriteLine(scriptType.BaseType);
			if(scriptType == null)
			{
				Console.WriteLine("Unable to find " + spawn.Creature.Script + " for spawn " + spawn.ObjectId);
			}

			UnitBase unit = (UnitBase)Activator.CreateInstance(scriptType, new object[1] { spawn.Creature });
			client.Player.MapTile.Map.CreateSpawn(spawn, unit);
			return true;
		}
	}
}

       
