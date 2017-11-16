using System;
using System.Reflection;
using System.Collections;
using WoWDaemon.Common;
namespace WoWDaemon.World
{
	public interface IWorldServerPacketHandler
	{
		void HandlePacket(WORLDMSG msgID, BinReader data);
	}

	public interface IWorldClientPacketHandler
	{
		void HandlePacket(WorldClient client, CMSG msgID, BinReader data);
	}

	public delegate void WorldServerPacketDelegate(WORLDMSG msgID, BinReader data);
	public delegate void WorldClientPacketDelegate(WorldClient client, CMSG msgID, BinReader data);
	/// <summary>
	/// All classes that wants to be automaticly registered needs to have this
	/// attribute, whether or not it's IWorldXXXXPacketHandler or WorldXXXXPacketDelegate
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple=true)]
	public class WorldPacketHandler : Attribute
	{
		bool m_useDelegates;
		int  m_msgID;
		bool m_clientMessage;
		public WorldPacketHandler(WORLDMSG msgID)
		{
			m_useDelegates = false;
			m_msgID = (int)msgID;
			m_clientMessage = false;
		}
		public WorldPacketHandler(CMSG msgID)
		{
			m_useDelegates = false;
			m_msgID = (int)msgID;
			m_clientMessage = true;
		}

		public WorldPacketHandler()
		{
			m_useDelegates = true;
		}

		public int MsgID
		{
			get { return m_msgID;}
		}

		public bool UseDelegates
		{
			get { return m_useDelegates;}
		}

		public bool ClientMessage
		{
			get { return m_clientMessage;}
		}
	}

	/// <summary>
	/// Make sure the method has the correct corresponding arguments
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple=true)]
	public class WorldPacketDelegate : Attribute
	{
		int  m_msgID;
		bool m_clientMessage;
		public WorldPacketDelegate(WORLDMSG msgID)
		{
			m_msgID = (int)msgID;
			m_clientMessage = false;
		}
		public WorldPacketDelegate(CMSG msgID)
		{
			m_msgID = (int)msgID;
			m_clientMessage = true;
		}

		public int MsgID
		{
			get { return m_msgID;}
		}

		public bool ClientMessage
		{
			get { return m_clientMessage;}
		}
	}

	/// <summary>
	/// Summary description for WorldPacketManager.
	/// </summary>
	public class WorldPacketManager
	{
		private WorldPacketManager()
		{

		}

		public static void SearchAssemblyForHandlers(Assembly assembly)
		{
			foreach(Type type in assembly.GetTypes())
			{
				if(type.IsClass == false)
					continue;
				WorldPacketHandler[] attribs = (WorldPacketHandler[])type.GetCustomAttributes(typeof(WorldPacketHandler), true);
				foreach(WorldPacketHandler attrib in attribs)
				{
					if(attrib.UseDelegates)
						SearchForDelegates(type);
					else
					{
						if(attrib.ClientMessage)
						{
							if(type.GetInterface(typeof(IWorldClientPacketHandler).ToString()) != null)
							{
								object obj = GetHandlerObject(type);
								RegisterPacketHandler((CMSG)attrib.MsgID, (IWorldClientPacketHandler)obj);
							}
						}
						else
						{
							if(type.GetInterface(typeof(IWorldServerPacketHandler).ToString()) != null)
							{
								object obj = GetHandlerObject(type);
								RegisterPacketHandler((WORLDMSG)attrib.MsgID, (IWorldServerPacketHandler)obj);
							}
						}

					}
				}
			}
		}
		
		static Hashtable handlerObjects = new Hashtable();
		static object GetHandlerObject(Type type)
		{
			if(handlerObjects.Contains(type))
				return handlerObjects[type];
			object obj = Activator.CreateInstance(type);
			handlerObjects[type] = obj;
			return obj;
		}

		static void SearchForDelegates(Type type)
		{			
			MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
			foreach(MethodInfo method in methods)
			{
				WorldPacketDelegate[] attribs = (WorldPacketDelegate[])method.GetCustomAttributes(typeof(WorldPacketDelegate), true);
				if(attribs.Length == 0)
					continue;
				if(method.IsStatic)
				{
					foreach(WorldPacketDelegate attrib in attribs)
					{
						if(attrib.ClientMessage)
						{
							WorldClientPacketDelegate wcpd = (WorldClientPacketDelegate)Delegate.CreateDelegate(typeof(WorldClientPacketDelegate), method);
							RegisterPacketHandler((CMSG)attrib.MsgID, wcpd);
						}
						else
						{
							WorldServerPacketDelegate wspd = (WorldServerPacketDelegate)Delegate.CreateDelegate(typeof(WorldServerPacketDelegate), method);
							RegisterPacketHandler((WORLDMSG)attrib.MsgID, wspd);
						}
					}
				}
				else
				{
					object obj = GetHandlerObject(type);
					foreach(WorldPacketDelegate attrib in attribs)
					{
						if(attrib.ClientMessage)
						{
							WorldClientPacketDelegate wcpd = (WorldClientPacketDelegate)Delegate.CreateDelegate(typeof(WorldClientPacketDelegate), obj, method.Name);
							RegisterPacketHandler((CMSG)attrib.MsgID, wcpd);
						}
						else
						{
							WorldServerPacketDelegate wspd = (WorldServerPacketDelegate)Delegate.CreateDelegate(typeof(WorldServerPacketDelegate), obj, method.Name);
							RegisterPacketHandler((WORLDMSG)attrib.MsgID, wspd);
						}
					}
				}
			}
		}

		static Hashtable worldServerHandlers = new Hashtable();
		static Hashtable worldClientHandlers = new Hashtable();
		static Hashtable worldServerDelegates = new Hashtable();
		static Hashtable worldClientDelegates = new Hashtable();
		public static void RegisterPacketHandler(WORLDMSG msgID, IWorldServerPacketHandler handler)
		{
			if(worldServerHandlers.Contains(msgID))
				throw new Exception("There's already a worldserver packet handler for " + msgID);
			worldServerHandlers[msgID] = handler;
		}

		public static void RegisterPacketHandler(WORLDMSG msgID, WorldServerPacketDelegate wspd)
		{
			if(worldServerDelegates[(int)msgID] != null)
			{
				WorldServerPacketDelegate dele = (WorldServerPacketDelegate)worldServerDelegates[(int)msgID];
				worldServerDelegates[(int)msgID] = dele + wspd;
			}
			else
				worldServerDelegates[(int)msgID] = wspd;
		}

		public static void RegisterPacketHandler(CMSG msgID, IWorldClientPacketHandler handler)
		{
			if(worldClientHandlers.Contains(msgID))
				throw new Exception("There's already a worldclient packet handler for " + msgID);
			worldClientHandlers[msgID] = handler;
		}

		public static void RegisterPacketHandler(CMSG msgID, WorldClientPacketDelegate wcpd)
		{
			if(worldClientDelegates[(int)msgID] != null)
			{
				WorldClientPacketDelegate dele = (WorldClientPacketDelegate)worldClientDelegates[(int)msgID];
				worldClientDelegates[(int)msgID] = dele + wcpd;
			}
			else
				worldClientDelegates[(int)msgID] = wcpd;
		}


		public static void UnregisterPacketHandler(WORLDMSG msgID)
		{
			worldServerHandlers.Remove(msgID);
		}

		public static void UnregisterPacketHandler(WORLDMSG msgID, WorldServerPacketDelegate wspd)
		{
			WorldServerPacketDelegate dele = (WorldServerPacketDelegate)worldServerDelegates[(int)msgID];
			worldServerDelegates[(int)msgID] = dele - wspd;
		}

		public static void UnregisterPacketHandler(CMSG msgID)
		{
			worldClientHandlers.Remove(msgID);
		}

		public static void UnregisterPacketHandler(CMSG msgID, WorldClientPacketDelegate wcpd)
		{
			WorldClientPacketDelegate dele = (WorldClientPacketDelegate)worldClientDelegates[(int)msgID];
			worldClientDelegates[(int)msgID] = dele - wcpd;
		}

		public static void HandlePacket(WORLDMSG msgID, BinReader data)
		{
			try {
				IWorldServerPacketHandler handler = (IWorldServerPacketHandler)worldServerHandlers[msgID];
				if(handler != null)
					handler.HandlePacket(msgID, data);
				WorldServerPacketDelegate wspd = (WorldServerPacketDelegate)worldServerDelegates[(int)msgID];
				if(wspd != null)
					wspd(msgID, data);
			} catch (Exception exp) {
				DebugLogger.Log("", exp);
			}
		}

		public static void HandlePacket(WorldClient client, CMSG msgID, BinReader data)
		{
			try {
				IWorldClientPacketHandler handler = (IWorldClientPacketHandler)worldClientHandlers[msgID];
				if(handler != null)
					handler.HandlePacket(client, msgID, data);
				WorldClientPacketDelegate wcpd = (WorldClientPacketDelegate)worldClientDelegates[(int)msgID];
				if(wcpd != null)
					wcpd(client, msgID, data);
			} catch (Exception exp) {
				DebugLogger.Log("", exp);
			}
		}
	}
}
