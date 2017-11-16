using System;
using System.Collections;
using System.Collections.Specialized;
using WoWDaemon.Common;

namespace WoWDaemon.World
{
	internal enum ADJACENT
	{
		TOPLEFT,
		TOP,
		TOPRIGHT,
		LEFT,
		SAME,
		RIGHT,
		LOWERLEFT,
		LOWER,
		LOWERRIGHT,
		NONE,
	}

	public delegate void MapTileCallback(WorldObject obj);

	public class MapTile
	{
		/*int m_bottomX;
		int m_bottomY;
		int m_topX;
		int m_topY;*/
		internal MapTile[] Adjacents = new MapTile[9];
		HybridDictionary[] m_objects;
		MapInstance m_map;
		public MapInstance Map
		{
			get { return m_map;}
		}
		/// <summary>
		/// Just pulled something out of my ass, we will probably change this
		/// once we start to use it or extend it. Like Corpses might just want to
		/// know when their owner enters it's surrounding tiles or something 
		/// so they would register on a specific guid but it might be better if
		/// that's on the object
		/// </summary>
		///
		MapTileCallback[] OnEnterTile = new MapTileCallback[(int)OBJECTTYPE.MAX];
		MapTileCallback[] OnLeaveTile = new MapTileCallback[(int)OBJECTTYPE.MAX];
		MapTileCallback[] OnMovement = new MapTileCallback[(int)OBJECTTYPE.MAX];

		internal MapTile(MapInstance map, int bottomX, int bottomY, int topX, int topY)
		{
			m_map = map;
			m_objects = new HybridDictionary[(int)OBJECTTYPE.MAX];
			for(int i = 0;i < (int)OBJECTTYPE.MAX;i++)
				m_objects[i] = new HybridDictionary();
			/*m_bottomX = bottomX;
			m_bottomY = bottomY;
			m_topX = topX;
			m_topY = topY;*/
		}

		internal ADJACENT IsAdjacent(MapTile tile)
		{
			if(Adjacents[(int)ADJACENT.TOPLEFT] == tile) return ADJACENT.TOPLEFT;
			if(Adjacents[(int)ADJACENT.TOP] == tile) return ADJACENT.TOP;
			if(Adjacents[(int)ADJACENT.TOPRIGHT] == tile) return ADJACENT.TOPRIGHT;
			if(Adjacents[(int)ADJACENT.LEFT] == tile) return ADJACENT.LEFT;
			if(Adjacents[(int)ADJACENT.SAME] == tile) return ADJACENT.SAME;
			if(Adjacents[(int)ADJACENT.RIGHT] == tile) return ADJACENT.RIGHT;
			if(Adjacents[(int)ADJACENT.LOWERLEFT] == tile) return ADJACENT.LOWERLEFT;
			if(Adjacents[(int)ADJACENT.LOWER] == tile) return ADJACENT.LOWER;
			if(Adjacents[(int)ADJACENT.LOWERRIGHT] == tile) return ADJACENT.LOWERRIGHT;
			return ADJACENT.NONE;
		}

		public ICollection GetObjects(OBJECTTYPE type)
		{
			return m_objects[(int)type].Values;
		}

		public void SendSurrounding(ServerPacket pkg)
		{
			bool send = false;
			foreach(MapTile tile in Adjacents)
			{
				if(tile != null)
				{
					ICollection Players = tile.GetObjects(OBJECTTYPE.PLAYER);
					if(Players.Count > 0)
					{
						send = true;
						foreach(PlayerObject player in Players)
						{
							pkg.AddDestination(player.CharacterID);
						}
					}
				}
			}
			if(send)
				WorldServer.Send(pkg);
		}

		public void SendSurrounding(ServerPacket pkg, PlayerObject notPlayer)
		{
			bool send = false;
			foreach(MapTile tile in Adjacents)
			{
				if(tile != null)
				{
					foreach(PlayerObject player in tile.GetObjects(OBJECTTYPE.PLAYER))
					{
						if(notPlayer.CharacterID != player.CharacterID)
						{
							send = true;
							pkg.AddDestination(player.CharacterID);
						}
					}
				}
			}
			if(send)
				WorldServer.Send(pkg);
		}
		

		public void RegisterOnEnter(OBJECTTYPE type, MapTileCallback callback)
		{
			OnEnterTile[(int)type] += callback;
		}
		public void UnregisterOnEnter(OBJECTTYPE type, MapTileCallback callback)
		{
			OnEnterTile[(int)type] -= callback;
		}

		public void RegisterOnLeave(OBJECTTYPE type, MapTileCallback callback)
		{
			OnLeaveTile[(int)type] += callback;
		}
		public void UnregisterOnLeave(OBJECTTYPE type, MapTileCallback callback)
		{
			OnLeaveTile[(int)type] -= callback;
		}
		public void RegisterOnMovement(OBJECTTYPE type, MapTileCallback callback)
		{
			OnMovement[(int)type] += callback;
		}
		public void UnregisterOnMovement(OBJECTTYPE type, MapTileCallback callback)
		{
			OnMovement[(int)type] -= callback;
		}


		internal void EnterTile(WorldObject obj)
		{
			m_objects[(int)obj.ObjectType][obj.GUID] = obj;
			if(OnEnterTile[(int)obj.ObjectType] != null)
				OnEnterTile[(int)obj.ObjectType](obj);
		}
		
		internal void LeaveTile(WorldObject obj)
		{
			m_objects[(int)obj.ObjectType].Remove(obj.GUID);
			if(OnLeaveTile[(int)obj.ObjectType] != null)
				OnLeaveTile[(int)obj.ObjectType](obj);
		}

		internal void OnMove(WorldObject obj)
		{
			if(OnMovement[(int)obj.ObjectType] != null)
				OnMovement[(int)obj.ObjectType](obj);
		}

		internal bool AdjacentCreateObject(ADJACENT adj, WorldObject obj, ServerPacket objCreationPkg)
		{
			if(Adjacents[(int)adj] != null)
				return Adjacents[(int)adj].CreateObject(obj, objCreationPkg);
			return false;
		}

		internal void AdjacentDestroyObject(ADJACENT adj, WorldObject obj)
		{
			if(Adjacents[(int)adj] != null)
				Adjacents[(int)adj].DestroyObject(obj);
		}

		#region CreateObject
		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj">Object to create for the players on this maptile</param>
		/// <param name="objCreationPkg">creation packet of obj</param>
		/// <returns>Returns true if there was any players to send objCreationPkg to</returns>
		internal bool CreateObject(WorldObject obj, ServerPacket objCreationPkg)
		{
			if(obj.ObjectType == OBJECTTYPE.PLAYER)
			{
				// we might want to change this incase there would be alot 
				// of objects on a single maptile cause it could possibly
				// overgo the packet size limit (which is 0xFFFF or less, not sure)
				// and only send one at a time or X at a time. Hopefully we
				// won't have to since it's compressed...
				bool ret = false;
				BinWriter w = new BinWriter();
				w.Write(1);
				w.Write((uint)0);
                w.Write((uint)0);
				int objcount = 0;
				for(int i = 0;i < (int)OBJECTTYPE.PLAYER;i++)
				{
					if(m_objects[i].Count > 0)
					{
						objcount += m_objects[i].Count;
						foreach(WorldObject anObject in m_objects[i].Values)
						{
							anObject.AddCreateObject(w, false, true);
						}
					}
				}
				if(m_objects[(int)OBJECTTYPE.PLAYER].Count > 0)
				{
					ret = true;
					objcount += m_objects[(int)OBJECTTYPE.PLAYER].Count;
					foreach(PlayerObject plr in m_objects[(int)OBJECTTYPE.PLAYER].Values)
					{
						objCreationPkg.AddDestination(plr.CharacterID);
						plr.AddCreateObject(w, false, true);
						objcount += plr.Inventory.AddCreateInventory(w, false);
					}
				}
				for(int i = ((int)OBJECTTYPE.PLAYER)+1;i < (int)OBJECTTYPE.MAX;i++)
				{
					if(m_objects[i].Count > 0)
					{
						objcount += m_objects[i].Count;
						foreach(WorldObject anObject in m_objects[i].Values)
							anObject.AddCreateObject(w, false, true);
					}
				}
				if(objcount > 0)
				{
					w.Set(0, objcount);
					ServerPacket pkg = new ServerPacket(SMSG.COMPRESSED_UPDATE_OBJECT);
					byte[] compressed = ZLib.Compress(w.GetBuffer(), 0, (int)w.BaseStream.Length);
					pkg.Write((int)w.BaseStream.Length);
					pkg.Write(compressed);
					pkg.Finish();
					pkg.AddDestination((obj as PlayerObject).CharacterID);
					WorldServer.Send(pkg);
				}
				return ret;
			}
			else
			{
				if(m_objects[(int)OBJECTTYPE.PLAYER].Count > 0)
				{
					foreach(PlayerObject plr in m_objects[(int)OBJECTTYPE.PLAYER].Values)
					{
						objCreationPkg.AddDestination(plr.CharacterID);
					}
					return true;
				}
				return false;
			}
		}
		#endregion

		#region DestroyObject
		internal void DestroyObject(WorldObject obj)
		{
			if(m_objects[(int)OBJECTTYPE.PLAYER].Count > 0)
			{
				ServerPacket pkg = new ServerPacket(SMSG.DESTROY_OBJECT);
				pkg.Write(obj.GUID);
				pkg.Finish();

				if(obj.ObjectType == OBJECTTYPE.PLAYER)
				{
					PlayerObject player = obj as PlayerObject;
					foreach(PlayerObject plr in m_objects[(int)OBJECTTYPE.PLAYER].Values)
					{
						pkg.AddDestination(plr.CharacterID);
						player.Inventory.SendDestroyInventory(plr.CharacterID);
					}
				}
				else
				{
					foreach(PlayerObject plr in m_objects[(int)OBJECTTYPE.PLAYER].Values)
					{
						pkg.AddDestination(plr.CharacterID);
					}
				}
				WorldServer.Send(pkg);
			}
		}
		#endregion
	}
}
