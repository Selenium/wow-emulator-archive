using System;
using System.Text.RegularExpressions;
using System.Collections;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
//using WoWDaemon.Login;
using WoWDaemon.Database.DataTables;
using WoWDaemon.Database;
using WoWDaemon.World;
using WorldScripts.Living;
namespace WorldScripts.ScriptPackets
{
	/// <summary>
	/// Summary description for Spawn.
	/// </summary>
	[ScriptPacketHandler()]
	public class Spawn
	{
		[ScriptPacketHandler(MsgID=0x01)]
		static void OnSpawn(int msgID, BinReader data)
		{
			uint charID = data.ReadUInt32();
			uint creatureID = data.ReadUInt32();
			uint spawnID = data.ReadUInt32();

			WorldClient client = WorldServer.GetClientByCharacterID(charID);
			if(client == null)
				return;

			DBSpawn spawn = (DBSpawn)DBManager.GetDBObject(typeof(DBSpawn), spawnID);
			if (spawn == null)
			{
				Chat.System(client, "no spawn");
				return;
			}

			spawn.Creature = (DBCreature)DBManager.GetDBObject(typeof(DBCreature), creatureID);
			if (spawn.Creature == null)
			{
				Chat.System(client, "no creature");
				return;
			}

			if(spawn.Creature.Script == null)
			{
				Chat.System(client, "Creature script is null that's a nono");
				return;
			}

			spawn.Position = client.Player.Position;
			spawn.Facing = client.Player.Facing;
			spawn.WorldMapID = client.Player.WorldMapID;

			Type scriptType = Type.GetType(spawn.Creature.Script);

			if(scriptType == null)
			{
				Console.WriteLine("Unable to find " + spawn.Creature.Script + " for spawn " + spawn.ObjectId);
				return;
			}

//			Console.WriteLine("ScriptType: >"+scriptType+"<"); 
			UnitBase unit = (UnitBase)Activator.CreateInstance(scriptType, new object[1] { spawn.Creature });
			client.Player.MapTile.Map.CreateSpawn(spawn, unit);
			DBManager.SaveDBObject((DBSpawn)spawn);
//			Chat.System(client, spawn.ObjectId.ToString());
		}
	}
}
