using System;
using System.Collections;
using WoWDaemon.Common;
namespace WoWDaemon.World
{
	/// <summary>
	/// Summary description for ObjectManager.
	/// </summary>
	[WorldPacketHandler()]
	public class ObjectManager
	{
		static ObjectManager()
		{
			m_worldObjects = new Hashtable[(int)OBJECTTYPE.MAX];
			for(int i = 0;i < (int)OBJECTTYPE.MAX;i++)
				m_worldObjects[i] = new Hashtable();
		}
		static Queue m_guidpool = new Queue();
		static ulong m_currentGUID = 0;
		static ulong m_currentMax = 0;
		static Hashtable[] m_worldObjects;

		[WorldPacketDelegate(WORLDMSG.INIT_GUIDS)]
		static void OnInitGuids(WORLDMSG msgID, BinReader data)
		{
			try {
				m_currentGUID = data.ReadUInt64();
				m_currentMax = data.ReadUInt64();
				m_guidpool.Enqueue(data.ReadUInt64());
				m_guidpool.Enqueue(data.ReadUInt64());
			} catch (Exception exp) {
				DebugLogger.Log("", exp);
			}
		}

		[WorldPacketDelegate(WORLDMSG.ACQUIRE_GUIDS_REPLY)]
		static void OnAcquireGuids(WORLDMSG msgID, BinReader data)
		{
			try {
				m_guidpool.Enqueue(data.ReadUInt64());
				m_guidpool.Enqueue(data.ReadUInt64());
			} catch (Exception exp) {
				DebugLogger.Log("", exp);
			}
		}

		public static ulong NextGUID()
		{
			ulong guid = m_currentGUID++;
			try {
				if(m_currentGUID == m_currentMax)
				{
					m_currentGUID = (ulong)m_guidpool.Dequeue();
					m_currentMax = (ulong)m_guidpool.Dequeue();
					WorldServer.Send(new WorldPacket(WORLDMSG.ACQUIRE_GUIDS));
				}
			} catch (Exception exp) {
				DebugLogger.Log("", exp);
			}
			return guid;
		}

		public static void AddWorldObject(WorldObject obj)
		{
			try {
				m_worldObjects[(int)obj.ObjectType][obj.GUID] = obj;
			} catch (Exception exp) {
				DebugLogger.Log("", exp);
			}
		}
		
		public static void RemoveWorldObject(WorldObject obj)
		{
			try {
				m_worldObjects[(int)obj.ObjectType].Remove(obj.GUID);
			} catch (Exception exp) {
				DebugLogger.Log("", exp);
			}
		}

		public static WorldObject GetWorldObject(OBJECTTYPE type, ulong guid)
		{
			try {
				return (WorldObject)m_worldObjects[(int)type][guid];
			} catch (Exception exp) {
				DebugLogger.Log("", exp);
			}
			return null;
		}

		public static WorldObject GetWorldObjectByGUID(ulong guid)
		{
			try {
				for(int i = 0; i < (int)OBJECTTYPE.MAX;i++)
				{
					if(((WorldObject)m_worldObjects[i][guid]) != null) return (WorldObject)m_worldObjects[i][guid];
				}
			} catch (Exception exp) {
				DebugLogger.Log("", exp);
			}
			return null;
		}

		public static ArrayList GetAllObjects(OBJECTTYPE type)
		{
			try {
				return new ArrayList(m_worldObjects[(int)type].Values);
			} catch (Exception exp) {
				DebugLogger.Log("", exp);
			}
			return null;
		}

		public static void CheckBeforeShutdown()
		{
			try {
				for(int i = 0;i < (int)OBJECTTYPE.MAX;i++)
				{
					if(m_worldObjects[i].Count > 0)
					{
						Console.WriteLine("Still " + m_worldObjects[i].Count + " " + ((OBJECTTYPE)i).ToString() + " in ObjectManager before shutting down.");
					}
				}
			} catch (Exception exp) {
				DebugLogger.Log("", exp);
			}
		}
	}
}
