using System;
using System.Collections;
using System.Collections.Specialized;
using WoWDaemon.Common;
using WoWDaemon.Database.DataTables;
namespace WoWDaemon.World
{
	[WorldPacketHandler()]
	public class MapManager
	{
		static HybridDictionary m_maps = new HybridDictionary();
		[WorldPacketDelegate(WORLDMSG.INIT_MAPS)]
		static void InitMaps(WORLDMSG msgID, BinReader data)
		{
			int numMaps = data.ReadInt32();
			for(int i = 0;i < numMaps;i++)
			{
				DBWorldMap map = new DBWorldMap(data);
				int numSpawns = data.ReadInt32();
				map.Spawns = new DBSpawn[numSpawns];
				for(int j = 0;j < numSpawns;j++)
				{
					DBSpawn spawn = new DBSpawn();
					spawn.Deserialize(data);
					spawn.Creature = (DBCreature)DBManager.GetDBObject(typeof(DBCreature), spawn.CreatureID);
					if(spawn.Creature == null)
						Console.WriteLine("Spawn " + spawn.ObjectId + " is missing creature on worldserver.");
					map.Spawns[j] = spawn;
				}
				m_maps[map.ObjectId] = new MapInstance(map);
			}
		}

		public static MapInstance GetMap(uint WorldMapID)
		{
			return (MapInstance)m_maps[WorldMapID];
		}

		public static void Move(WorldObject obj)
		{
			if(obj.MapTile != null)
				obj.MapTile.Map.Move(obj);
		}
        
        internal static void LoadScreen(WorldClient client)
        {
            ServerPacket pkg = new ServerPacket(SMSG.TRANSFER_PENDING);
            pkg.Write((int)0);
            pkg.Finish();
            pkg.AddDestination(client.CharacterID);
            WorldServer.Send(pkg);
        }

		public static void ChangeMap(WorldClient client)
		{
            LoadScreen(client);
			if(client.Player.MapTile == null)
				return;

			MapInstance map = GetMap(client.Player.WorldMapID);
			if(map == null)
			{
				WorldPacket pkg = new WorldPacket(WORLDMSG.CHANGE_MAP);
				pkg.Write(client.CharacterID);
				WorldServer.Send(pkg);
				client.LeaveWorld();
				return;
			}
			else
			{

				client.Player.MapTile.Map.Leave(client.Player);
				client.Player.Continent = (uint)map.Continent;
				map.SetObjectPositionInBounds(client.Player);

                ServerPacket pkg = new ServerPacket(SMSG.NEW_WORLD);
				pkg.Write((byte)client.Player.Continent);
				pkg.Write((byte)0x00);
				pkg.Write((byte)0x00);
				pkg.Write((byte)0x00);
				pkg.Write((float)client.Player.Position.X);
				pkg.Write((float)client.Player.Position.Y);
				pkg.Write((float)client.Player.Position.Z);
				pkg.Write((float)client.Player.Facing);
				pkg.Finish();
				pkg.AddDestination(client.CharacterID);
				WorldServer.Send(pkg);
			}
		}

		[WorldPacketDelegate(CMSG.MOVE_WORLDPORT_ACK)]
		static void OnWorldPortAck(WorldClient client, CMSG msgID, BinReader data)
		{
			if(client.Player.MapTile == null)
			{
				//client.CreatePlayerObject();
				MapInstance map = GetMap(client.Player.WorldMapID);
				if(map == null)
				{
					Console.WriteLine("Error worldserver received MOVE_WORLDPORT_ACK for a worldmap it wasn't handling.");
					client.LeaveWorld();
					return;
				}
				map.Enter(client.Player);
			}
		}

		[WorldPacketDelegate(WORLDMSG.PLAYER_ENTER_WORLD)]
		static void OnPlayerEnterWorld(WORLDMSG msgID, BinReader data)
		{
			uint id = data.ReadUInt32();
			ACCESSLEVEL accesslevel = (ACCESSLEVEL)data.ReadByte();
			DBCharacter c = (DBCharacter)DBManager.GetDBObject(typeof(DBCharacter), id);
			if(c == null)
			{
				Console.WriteLine("Failed to enter world with id " + id + ". WorldServer is missing Character object");
				return;
			}
			WorldClient client = new WorldClient(c);
			MapInstance map = (MapInstance)m_maps[c.WorldMapID];
			if(map == null)
			{
				Console.WriteLine("Worldserver is not handling " + c.WorldMapID + "!");
				client.LeaveWorld();
				return;
			}
			map.SetObjectPositionInBounds(client.Player);
			//client.CreatePlayerObject();
			client.Player.AccessLvl=accesslevel;
			map.Enter(client.Player);
		}

		[WorldPacketDelegate(WORLDMSG.PLAYER_LEAVE_WORLD)]
		static void OnPlayerLeaveWorld(WORLDMSG msgID, BinReader data)
		{
			uint id = data.ReadUInt32();
			WorldClient client = WorldServer.GetClientByCharacterID(id);
			if(client == null)
			{
				Console.WriteLine("Failed to leave world. Client didn't exist on worldserver.");
				return;
			}
			client.LeaveWorld();
		}

		[WorldPacketDelegate(CMSG.MOVE_START_FORWARD)]
		[WorldPacketDelegate(CMSG.MOVE_START_BACKWARD)]
		[WorldPacketDelegate(CMSG.MOVE_STOP)]
		[WorldPacketDelegate(CMSG.MOVE_START_STRAFE_LEFT)]
		[WorldPacketDelegate(CMSG.MOVE_START_STRAFE_RIGHT)]
		[WorldPacketDelegate(CMSG.MOVE_STOP_STRAFE)]
		[WorldPacketDelegate(CMSG.MOVE_JUMP)]
		[WorldPacketDelegate(CMSG.MOVE_START_TURN_LEFT)]
		[WorldPacketDelegate(CMSG.MOVE_START_TURN_RIGHT)]
		[WorldPacketDelegate(CMSG.MOVE_STOP_TURN)]
		[WorldPacketDelegate(CMSG.MOVE_START_PITCH_UP)]
		[WorldPacketDelegate(CMSG.MOVE_START_PITCH_DOWN)]
		[WorldPacketDelegate(CMSG.MOVE_STOP_PITCH)]
		[WorldPacketDelegate(CMSG.MOVE_SET_RUN_MODE)]
		[WorldPacketDelegate(CMSG.MOVE_SET_WALK_MODE)]
			//		[WorldPacketDelegate(CMSG.MOVE_COLLIDE_REDIRECT)]  // Removed Temp by Phaze
			//		[WorldPacketDelegate(CMSG.MOVE_COLLIDE_STUCK)]  // Removed Temp by Phaze
		[WorldPacketDelegate(CMSG.MOVE_START_SWIM)]
		[WorldPacketDelegate(CMSG.MOVE_STOP_SWIM)]
		[WorldPacketDelegate(CMSG.MOVE_SET_FACING)]
		[WorldPacketDelegate(CMSG.MOVE_SET_PITCH)]
		[WorldPacketDelegate(CMSG.MOVE_HEARTBEAT)]
		static void OnMovement(WorldClient client, CMSG msgID, BinReader data)
		{
			if(client.Player.MapTile == null)
				return;
			client.Player.StandState = UNITSTANDSTATE.STANDING; // If sleeping set standstate to standing...
			long pos = data.BaseStream.Position;
			if (data.Length() >= 60) // obj size and pkt size unfortunately
			{
				data.BaseStream.Position += 8; // skipping Guid and Guid_High (added for 1.3.1)
			}
			client.Player.MovementFlags = data.ReadUInt32();
			int unknown1 = data.ReadInt32(); // time tick
			client.Player.Position = data.ReadVector();
			client.Player.Facing = data.ReadSingle();
			int unknown2 = data.ReadInt32(); // new field for 1.3.1 also found in the A9 (map id?)
			data.BaseStream.Position = pos;
			ServerPacket pkg;
			if(client.Player.MapTile.Map.SetObjectPositionInBounds(client.Player))
			{
				client.Player.MapTile.Map.Move(client.Player);
				pkg = new ServerPacket(SMSG.MONSTER_MOVE);
                pkg.Write((char)0xFF);
				pkg.Write(client.Player.GUID);
				pkg.WriteVector(client.Player.Position);
				pkg.Write(client.Player.Facing);
				pkg.Write((byte)0x01);
				pkg.Finish();
				client.Player.MapTile.SendSurrounding(pkg);
				return;
			}

			client.Player.MapTile.Map.Move(client.Player);			
			pkg = new ServerPacket((SMSG)msgID);
			pkg.Write(client.Player.GUID);
			pkg.Write(data.ReadBytes((int)(data.BaseStream.Length-data.BaseStream.Position)));
			pkg.Finish();
			client.Player.MapTile.SendSurrounding(pkg, client.Player);
		}
	}	
}
