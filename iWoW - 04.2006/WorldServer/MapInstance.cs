using System;
using System.Collections;
using WoWDaemon.Common;
using WoWDaemon.Database.DataTables;
namespace WoWDaemon.World
{
	public class MapInstance
	{
		int m_bottomX;
		int m_bottomY;
		int m_topX;
		int m_topY;
		int m_tileSize;
		MapTile[,] m_mapTiles;
		int m_rows;
		int m_columns;
		DBWorldMap m_map;

		private MapTile GetTile(int x, int y)
		{
			if(x >= 0 && x < m_columns && y >= 0 && y < m_rows)
				return m_mapTiles[x,y];
			return null;
		}

		public uint MapID
		{
			get { return m_map.ObjectId;}
		}

		public int Continent
		{
			get { return m_map.Continent;}
		}

		public MapInstance(DBWorldMap map)
		{
			m_map = map;
			m_bottomX = map.BottomX;
			m_bottomY = map.BottomY;
			m_topX = map.TopX;
			m_topY = map.TopY;
			m_tileSize = map.TileSize;
			m_columns = (m_topX-m_bottomX)/m_tileSize;
			m_rows = (m_topY-m_bottomY)/m_tileSize;
			m_mapTiles = new MapTile[m_columns, m_rows];
			for(int i = 0;i < m_columns;i++)
				for(int j = 0;j < m_rows;j++)
				{
					int baseX = m_bottomX+i*m_tileSize;
					int baseY = m_bottomY+j*m_tileSize;
					m_mapTiles[i,j] = new MapTile(this, baseX, baseY, baseX+m_tileSize, baseY+m_tileSize);
				}
			for(int x = 0;x < m_columns;x++)
				for(int y = 0;y < m_rows;y++)
				{
					MapTile tile = m_mapTiles[x,y];
					tile.Adjacents[0] = GetTile(x-1, y+1);
					tile.Adjacents[1] = GetTile(x, y+1);
					tile.Adjacents[2] = GetTile(x+1, y+1);
					
					tile.Adjacents[3] = GetTile(x-1, y);
					tile.Adjacents[4] = tile;
					tile.Adjacents[5] = GetTile(x+1, y);

					tile.Adjacents[6] = GetTile(x-1, y-1);
					tile.Adjacents[7] = GetTile(x, y-1);
					tile.Adjacents[8] = GetTile(x+1, y-1);
				}
			InitSpawns();
		}

		private void InitSpawns()
		{
			int spawns = 0;
			foreach(DBSpawn spawn in m_map.Spawns)
			{
				if(spawn.Creature == null)
				{
					Console.WriteLine("Cannot initialized spawn " + spawn.ObjectId);
					continue;
				}
				Type scriptType = WorldServer.Scripts.GetType(spawn.Creature.Script);
			//	Console.WriteLine(scriptType.BaseType);
				if(scriptType == null)
				{
					Console.WriteLine("Unable to find " + spawn.Creature.Script + " for spawn " + spawn.ObjectId);
					continue;
				}
				try
				{
					UnitBase unit = (UnitBase)Activator.CreateInstance(scriptType, new object[1] { spawn.Creature });
					CreateSpawn(spawn, unit);
					spawns++;

				}
				catch(Exception e)
				{
					Console.WriteLine("Error while initializing spawn " + spawn.ObjectId);
					Console.WriteLine(e.Message);
					Console.WriteLine(e.StackTrace);
				}
			}
			Console.WriteLine("Spawned " + spawns + " to map " + this.MapID + ".");
		}

		public void CreateSpawn(DBSpawn spawn, UnitBase unit) {
			try 
			{
				unit.Position = spawn.Position;
				unit.Facing = spawn.Facing;
				unit.Level = spawn.Level;
				unit.DisplayID = spawn.DisplayID;
				unit.Faction = spawn.Faction;
				unit.Dead = false;
				unit.StandState = UNITSTANDSTATE.STANDING;
				unit.Target = 0;
				unit.Attacking = false;
				unit.Roaming = spawn.Roam;
				unit.Spawn_ID = (int)spawn.ObjectId;

				unit.RespawnTime += (int)Math.Exp(unit.Level/5);
	
				StatManager.CalculateNewStats(unit);

				LootManager.GenerateMobLoot(unit);

				unit.Health = unit.MaxHealth;
				unit.Power = unit.MaxPower;

				//Console.WriteLine("Spawning: " + unit.Name + "(" + unit.Level + ") at " + unit.Position.X + " " + unit.Position.Y + " " + unit.Position.Z);
				Enter(unit);
			}
			catch(Exception e)
			{
				Console.WriteLine("Error while initializing spawn " + spawn.ObjectId);
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
			}
		}

		public MapTile GetTileByLoc(Vector Position)
		{
			return GetTileByLoc((int)Position.X, (int)Position.Y);
		}

		public MapTile GetTileByLoc(int x, int y)
		{
			int column = (x - m_bottomX)/m_tileSize;
			int row = (y - m_bottomY)/m_tileSize;
			if(column >= m_columns)
				column = m_columns-1;
			if(row >= m_rows)
				row = m_rows-1;
			return m_mapTiles[column, row];
		}

		public MapTile[] GetBorderTilesByCount(Vector Position, int borderCount)
		{
			return GetBorderTilesByCount((int)Position.X, (int)Position.Y, borderCount);
		}

		public MapTile[] GetBorderTilesByCount(int xPos, int yPos, int borderCount)
		{
			int column = (xPos - m_bottomX)/m_tileSize;
			int row = (yPos - m_bottomY)/m_tileSize;
			int startX = column-borderCount;
			int startY = row-borderCount;
			int endX = column+borderCount+1;
			int endY = row+borderCount+1;
			if(startX < 0) startX = 0;
			if(startY < 0) startY = 0;
			if(endX > m_columns) endX = m_columns;
			if(endY > m_rows) endY = m_rows;
			int xTiles = endX-startX;
			int yTiles = endY-startY;
			MapTile[] Tiles = new MapTile[xTiles*yTiles];
			for(int i = 0;i < xTiles;i++)
				for(int j = 0;j < yTiles;j++)
					Tiles[i*yTiles+j] = m_mapTiles[startX+i,startY+j];
			return Tiles;
		}

		public MapTile[] GetBorderTilesByRange(Vector Position, int range)
		{
			return GetBorderTilesByCount((int)Position.X, (int)Position.Y, range/m_tileSize);
		}

		public MapTile[] GetBorderTilesByRange(int xPos, int yPos, int range)
		{
			return GetBorderTilesByCount(xPos, yPos, range/m_tileSize);
		}

		public MapTile[] GetTilesInRange(Vector Position, int range)
		{
			return GetTilesInRange((int)Position.X, (int)Position.Y, range);
		}

		public MapTile[] GetTilesInRange(int xPos, int yPos, int range)
		{
				xPos -= m_bottomX;
				yPos -= m_bottomY;
				int startX = (xPos-range)/m_tileSize;
				int startY = (yPos-range)/m_tileSize;
				int endX = ((xPos+range)/m_tileSize)+1;
				int endY = ((yPos+range)/m_tileSize)+1;
				if(endX > m_columns) endX = m_columns;
				if(endY > m_rows) endY = m_rows;
				int xTiles = endX-startX;
				int yTiles = endY-startY;
				MapTile[] Tiles = new MapTile[xTiles*yTiles];
				for(int i = 0;i < xTiles;i++)
					for(int j = 0;j < yTiles;j++)
						Tiles[i*yTiles+j] = m_mapTiles[startX+i,startY+j];
				return Tiles;
		}

		public void Send(ServerPacket pkg, Vector position, float range)
		{
			long pos = pkg.BaseStream.Position;
			foreach(MapTile tile in GetTilesInRange((int)position.X, (int)position.Y, (int)range))
			{
				foreach(PlayerObject player in tile.GetObjects(OBJECTTYPE.PLAYER))
				{
					if(position.Distance(player.Position) < range)
					{
						pkg.AddDestination(player.CharacterID);
					}
				}
			}
			if(pkg.BaseStream.Position > pos)
				WorldServer.Send(pkg);
		}

		public ArrayList GetObjectsInRange(OBJECTTYPE type, Vector position, float range)
		{
			ArrayList objs = new ArrayList();
			foreach(MapTile tile in GetTilesInRange((int)position.X, (int)position.Y, (int)range))
				foreach(WorldObject obj in tile.GetObjects(type))
					if(position.Distance(obj.Position) < range)
						objs.Add(obj);
			return objs;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>Returns true if position was changed</returns>
		public bool SetObjectPositionInBounds(WorldObject obj)
		{
			float x = obj.Position.X;
			float y = obj.Position.Y;
			bool retval = false;
			if(x < m_bottomX)
			{
				x = m_bottomX+1;
				retval = true;
			}
			else if(x > m_topX)
			{
				x = m_topX-1;
				retval = true;
			}
			if(y < m_bottomY)
			{
				y = m_bottomY+1;
				retval = true;
			}
			else if(y > m_topY)
			{
				y = m_topY-1;
				retval = true;
			}
			if(retval)
				obj.Position = new Vector(x, y, obj.Position.Z);
			return retval;
		}

		public void Enter(WorldObject obj)
		{
			MapTile mapTile = GetTileByLoc(obj.Position);
			obj.MapTile = mapTile;
			ServerPacket pkg = MakeCreatePacket(obj);
			bool send = false;
			foreach(MapTile tile in mapTile.Adjacents)
				if(tile != null)
					send |= tile.CreateObject(obj, pkg);
			if(send)
				WorldServer.Send(pkg);
			mapTile.EnterTile(obj);
		}

		public void Leave(WorldObject obj)
		{
			obj.MapTile.LeaveTile(obj);
			foreach(MapTile tile in obj.MapTile.Adjacents)
				if(tile != null)
					tile.DestroyObject(obj);
			obj.MapTile = null;
		}

		private ServerPacket MakeCreatePacket(WorldObject obj)
		{
			BinWriter w = new BinWriter();
			w.Write(0);
			w.Write((uint)0);
            w.Write(2); 
			obj.AddCreateObject(w, false, true);
			int count = 1;
			if(obj.ObjectType == OBJECTTYPE.PLAYER)
			{
				PlayerObject plr = obj as PlayerObject;
				count += plr.Inventory.AddCreateInventory(w, false);
			}
			w.Set(0, count);

			ServerPacket pkg = new ServerPacket(SMSG.COMPRESSED_UPDATE_OBJECT);
			byte[] compressed = ZLib.Compress(w.GetBuffer(), 0, (int)w.BaseStream.Length);
			pkg.Write((int)w.BaseStream.Length);
			pkg.Write(compressed);
			pkg.Finish();
			return pkg;
		}

		internal void Move(WorldObject obj)
		{
			// dunno if we are gonna do the check allowed to move check here.
			// maybe make OnMove and LeaveTile return true or false 
			// if the object is allowed to move

			MapTile newTile = GetTileByLoc(obj.Position);
			MapTile oldTile = obj.MapTile;
			if(newTile == oldTile)
			{
				oldTile.OnMove(obj);
				return;
			}

			ADJACENT adj = oldTile.IsAdjacent(newTile);
			if(adj == ADJACENT.NONE)
			{
				Leave(obj);
				Enter(obj);
				return;
			}

			ServerPacket createObjectPkg = MakeCreatePacket(obj);

			bool sendPkg = false;

			oldTile.LeaveTile(obj);
			// nothing should happen with the object in this switch
			// it's only for creating/destroying objects on the client
			switch(adj)
			{
				case ADJACENT.TOPLEFT:
					oldTile.AdjacentDestroyObject(ADJACENT.TOPRIGHT, obj);
					oldTile.AdjacentDestroyObject(ADJACENT.RIGHT, obj);
					oldTile.AdjacentDestroyObject(ADJACENT.LOWERRIGHT, obj);
					oldTile.AdjacentDestroyObject(ADJACENT.LOWER, obj);
					oldTile.AdjacentDestroyObject(ADJACENT.LOWERLEFT, obj);

					sendPkg = newTile.AdjacentCreateObject(ADJACENT.TOPRIGHT, obj, createObjectPkg) ||
						newTile.AdjacentCreateObject(ADJACENT.TOP, obj, createObjectPkg) ||
						newTile.AdjacentCreateObject(ADJACENT.TOPLEFT, obj, createObjectPkg) ||
						newTile.AdjacentCreateObject(ADJACENT.LEFT, obj, createObjectPkg) ||
						newTile.AdjacentCreateObject(ADJACENT.LOWERLEFT, obj, createObjectPkg);
					break;
				case ADJACENT.TOP:
					oldTile.AdjacentDestroyObject(ADJACENT.LOWERLEFT, obj);
					oldTile.AdjacentDestroyObject(ADJACENT.LOWER, obj);
					oldTile.AdjacentDestroyObject(ADJACENT.LOWERRIGHT, obj);

					sendPkg = newTile.AdjacentCreateObject(ADJACENT.TOPLEFT, obj, createObjectPkg) ||
						newTile.AdjacentCreateObject(ADJACENT.TOP, obj, createObjectPkg) ||
						newTile.AdjacentCreateObject(ADJACENT.TOPRIGHT, obj, createObjectPkg);
					break;
				case ADJACENT.TOPRIGHT:
					oldTile.AdjacentDestroyObject(ADJACENT.TOPLEFT, obj);
					oldTile.AdjacentDestroyObject(ADJACENT.LEFT, obj);
					oldTile.AdjacentDestroyObject(ADJACENT.LOWERLEFT, obj);
					oldTile.AdjacentDestroyObject(ADJACENT.LOWER, obj);
					oldTile.AdjacentDestroyObject(ADJACENT.LOWERRIGHT, obj);

					sendPkg = newTile.AdjacentCreateObject(ADJACENT.TOPLEFT, obj, createObjectPkg) ||
						newTile.AdjacentCreateObject(ADJACENT.TOP, obj, createObjectPkg) ||
						newTile.AdjacentCreateObject(ADJACENT.TOPRIGHT, obj, createObjectPkg) ||
						newTile.AdjacentCreateObject(ADJACENT.RIGHT, obj, createObjectPkg) ||
						newTile.AdjacentCreateObject(ADJACENT.LOWERRIGHT, obj, createObjectPkg);
					break;
				case ADJACENT.LEFT:
					oldTile.AdjacentDestroyObject(ADJACENT.TOPRIGHT, obj);
					oldTile.AdjacentDestroyObject(ADJACENT.RIGHT, obj);
					oldTile.AdjacentDestroyObject(ADJACENT.LOWERRIGHT, obj);

					sendPkg = newTile.AdjacentCreateObject(ADJACENT.TOPLEFT, obj, createObjectPkg) ||
						newTile.AdjacentCreateObject(ADJACENT.LEFT, obj, createObjectPkg) ||
						newTile.AdjacentCreateObject(ADJACENT.LOWERLEFT, obj, createObjectPkg);
					break;
				case ADJACENT.RIGHT:
					oldTile.AdjacentDestroyObject(ADJACENT.TOPLEFT, obj);
					oldTile.AdjacentDestroyObject(ADJACENT.LEFT, obj);
					oldTile.AdjacentDestroyObject(ADJACENT.LOWERLEFT, obj);

					sendPkg = newTile.AdjacentCreateObject(ADJACENT.TOPRIGHT, obj, createObjectPkg) ||
						newTile.AdjacentCreateObject(ADJACENT.RIGHT, obj, createObjectPkg) ||
						newTile.AdjacentCreateObject(ADJACENT.LOWERRIGHT, obj, createObjectPkg);
					break;
				case ADJACENT.LOWERLEFT:
					oldTile.AdjacentDestroyObject(ADJACENT.TOPLEFT, obj);
					oldTile.AdjacentDestroyObject(ADJACENT.TOP, obj);
					oldTile.AdjacentDestroyObject(ADJACENT.TOPRIGHT, obj);
					oldTile.AdjacentDestroyObject(ADJACENT.RIGHT, obj);
					oldTile.AdjacentDestroyObject(ADJACENT.LOWERRIGHT, obj);

					sendPkg = newTile.AdjacentCreateObject(ADJACENT.LOWERRIGHT, obj, createObjectPkg) ||
						newTile.AdjacentCreateObject(ADJACENT.LOWER, obj, createObjectPkg) ||
						newTile.AdjacentCreateObject(ADJACENT.LOWERLEFT, obj, createObjectPkg) ||
						newTile.AdjacentCreateObject(ADJACENT.LEFT, obj, createObjectPkg) ||
						newTile.AdjacentCreateObject(ADJACENT.TOPLEFT, obj, createObjectPkg);
					break;
				case ADJACENT.LOWER:
					oldTile.AdjacentDestroyObject(ADJACENT.TOPLEFT, obj);
					oldTile.AdjacentDestroyObject(ADJACENT.TOP, obj);
					oldTile.AdjacentDestroyObject(ADJACENT.TOPRIGHT, obj);

					sendPkg = newTile.AdjacentCreateObject(ADJACENT.LOWERLEFT, obj, createObjectPkg) ||
						newTile.AdjacentCreateObject(ADJACENT.LOWER, obj, createObjectPkg) ||
						newTile.AdjacentCreateObject(ADJACENT.LOWERRIGHT, obj, createObjectPkg);
					break;
				case ADJACENT.LOWERRIGHT:
					oldTile.AdjacentDestroyObject(ADJACENT.LOWERLEFT, obj);
					oldTile.AdjacentDestroyObject(ADJACENT.LEFT, obj);
					oldTile.AdjacentDestroyObject(ADJACENT.TOPLEFT, obj);
					oldTile.AdjacentDestroyObject(ADJACENT.TOP, obj);
					oldTile.AdjacentDestroyObject(ADJACENT.TOPRIGHT, obj);

					sendPkg = newTile.AdjacentCreateObject(ADJACENT.LOWERLEFT, obj, createObjectPkg) ||
						newTile.AdjacentCreateObject(ADJACENT.LOWER, obj, createObjectPkg) ||
						newTile.AdjacentCreateObject(ADJACENT.LOWERRIGHT, obj, createObjectPkg) ||
						newTile.AdjacentCreateObject(ADJACENT.RIGHT, obj, createObjectPkg) ||
						newTile.AdjacentCreateObject(ADJACENT.TOPRIGHT, obj, createObjectPkg);
					break;
			}
			if(sendPkg)
				WorldServer.Send(createObjectPkg);
			obj.MapTile = newTile;
			newTile.EnterTile(obj);
		}
	}
}
