using System;
using System.Reflection;
using System.Collections;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.Database.DataTables;

namespace WoWDaemon.World
{
	/// <summary>
	/// Summary description for WorldScriptAssembly.
	/// </summary>
	public class WorldScriptAssembly : IScriptAssembly
	{
		ArrayList assemblies = new ArrayList();
		Hashtable m_clientPacketDelegates = new Hashtable();
		ArrayList m_registeredClientPackets = new ArrayList();
		Hashtable m_scriptPacketHandlers = new Hashtable();
		Hashtable handlerObjects = new Hashtable();

		public WorldScriptAssembly()
		{

		}

		public void AddAssembly(Assembly assembly)
		{
			assemblies.Add(assembly);
		}

		public void Unload()
		{
			IDictionaryEnumerator e = m_clientPacketDelegates.GetEnumerator();
			while(e.MoveNext())
				WorldPacketManager.UnregisterPacketHandler((CMSG)e.Key, (WorldClientPacketDelegate)e.Value);
			foreach(CMSG msgID in m_registeredClientPackets)
				WorldPacketManager.UnregisterPacketHandler(msgID);
			assemblies.Clear();
			m_clientPacketDelegates.Clear();
			m_registeredClientPackets.Clear();
			m_scriptPacketHandlers.Clear();
			handlerObjects.Clear();
			ChatManager.ClearChatCmds();
		}

		public bool Load(out string error)
		{
			error = string.Empty;
			try
			{
				foreach(Assembly asm in assemblies)
				{
					ObjectUpdateManager.SearchAssemblyForUpdateObjects(asm);
					foreach(Type type in asm.GetTypes())
					{
						if(type.IsClass == false)
							continue;
						if(type.BaseType == typeof(PlayerObject))
						{
							if(PlayerObjectType != typeof(PlayerObject))
							{
								Unload();
								error = "You can only have 1 custom player object in scripts.";
								return false;
							}
							PlayerObjectType = type;
						}
						if(type.IsDefined(typeof(ScriptPacketHandler), true))
							RegisterScriptPacketHandler(type);
						if(type.IsDefined(typeof(WorldPacketHandler), true))
							RegisterClientPacketHandler(type);
						if(type.IsDefined(typeof(ChatCmdHandler), true))
							RegisterChatHandler(type);
					}
				}
			}
			catch(Exception e)
			{
				Unload();
				error = e.Message;
				return false;
			}
			WorldServer.Scripts = this;
			return true;
		}

		private Type PlayerObjectType = typeof(PlayerObject);
		internal PlayerObject GetNewPlayerObject(DBCharacter c)
		{
			return (PlayerObject)Activator.CreateInstance(PlayerObjectType, new object[1] {c});
		}

		public Type GetType(string name)
		{
			foreach(Assembly asm in assemblies)
			{
				Type type = asm.GetType(name);
				if(type != null)
					return type;
			}
			return null;
		}

		internal void OnScriptMessage(int msgID, BinReader data)
		{
			try {
				ScriptPacketDelegate handler = (ScriptPacketDelegate)m_scriptPacketHandlers[msgID];
				if(handler != null) handler(msgID, data);
			} catch (Exception exp) {
				DebugLogger.Log("", exp);
			}
		}

		public void RegisterScriptPacketHandler(int msgID, ScriptPacketDelegate spd)
		{
			if(m_scriptPacketHandlers.Contains(msgID))
			{
				ScriptPacketDelegate dele = (ScriptPacketDelegate)m_scriptPacketHandlers[msgID];
				m_scriptPacketHandlers[msgID] = dele + spd;
			}
			else
				m_scriptPacketHandlers[msgID] = spd;
		}

		public void UnregisterScriptPacketHandler(int msgID, ScriptPacketDelegate spd)
		{
			ScriptPacketDelegate dele = (ScriptPacketDelegate)m_scriptPacketHandlers[msgID];
			m_scriptPacketHandlers[msgID] = dele - spd;
		}


		void RegisterScriptPacketHandler(Type type)
		{
			MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
			foreach(MethodInfo method in methods)
			{
				ScriptPacketHandler[] attribs = (ScriptPacketHandler[])method.GetCustomAttributes(typeof(ScriptPacketHandler), true);
				if(attribs.Length == 0)
					continue;
				if(method.IsStatic)
				{
					foreach(ScriptPacketHandler attrib in attribs)
					{
						ScriptPacketDelegate spd = (ScriptPacketDelegate)Delegate.CreateDelegate(typeof(ScriptPacketDelegate), method);
						RegisterScriptPacketHandler(attrib.MsgID, spd);
					}
				}
				else
				{
					object obj = GetHandlerObject(type);
					foreach(ScriptPacketHandler attrib in attribs)
					{
						ScriptPacketDelegate spd = (ScriptPacketDelegate)Delegate.CreateDelegate(typeof(ScriptPacketDelegate), obj, method.Name);
						RegisterScriptPacketHandler(attrib.MsgID, spd);
					}
				}
			}
		}

		void RegisterClientPacketHandler(Type type)
		{
			WorldPacketHandler[] attribs = (WorldPacketHandler[])type.GetCustomAttributes(typeof(WorldPacketHandler), true);
			foreach(WorldPacketHandler attrib in attribs)
			{
				if(attrib.UseDelegates)
					SearchForClientPacketDelegates(type);
				else
				{
					if(attrib.ClientMessage)
					{
						if(type.GetInterface(typeof(IWorldClientPacketHandler).ToString()) != null)
						{
							object obj = GetHandlerObject(type);
							WorldPacketManager.RegisterPacketHandler((CMSG)attrib.MsgID, (IWorldClientPacketHandler)obj);
							m_registeredClientPackets.Add((CMSG)attrib.MsgID);
						}
					}
				}
			}
		}

		object GetHandlerObject(Type type)
		{
			if(handlerObjects.Contains(type))
				return handlerObjects[type];
			object obj = Activator.CreateInstance(type);
			handlerObjects[type] = obj;
			return obj;
		}

		void RegisterChatHandler(Type type)
		{
			MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
			foreach(MethodInfo info in methods)
			{
				ChatCmdAttribute[] attribs = (ChatCmdAttribute[])info.GetCustomAttributes(typeof(ChatCmdAttribute), true);
				if(attribs.Length == 0)
					continue;
				ChatCmdDelegate ccd;
				if(info.IsStatic)
				{
					ccd = (ChatCmdDelegate)Delegate.CreateDelegate(typeof(ChatCmdDelegate), info);
				}
				else
				{
					object obj = GetHandlerObject(type);
					ccd = (ChatCmdDelegate)Delegate.CreateDelegate(typeof(ChatCmdDelegate), obj, info.Name);
				}
				foreach(ChatCmdAttribute attrib in attribs)
				{
					ChatManager.RegisterChatCommand(attrib.Cmd, attrib.Usage, ccd);
				}
			}
		}


		void SearchForClientPacketDelegates(Type type)
		{	
			try {
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
								WorldPacketManager.RegisterPacketHandler((CMSG)attrib.MsgID, wcpd);
								if(m_clientPacketDelegates.Contains(attrib.MsgID))
								{
									WorldClientPacketDelegate dele = (WorldClientPacketDelegate)m_clientPacketDelegates[attrib.MsgID];
									m_clientPacketDelegates[attrib.MsgID] = dele + wcpd;
								}
								else
									m_clientPacketDelegates[attrib.MsgID] = wcpd;
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
								WorldPacketManager.RegisterPacketHandler((CMSG)attrib.MsgID, wcpd);
								if(m_clientPacketDelegates.Contains(attrib.MsgID))
								{
									WorldClientPacketDelegate dele = (WorldClientPacketDelegate)m_clientPacketDelegates[attrib.MsgID];
									m_clientPacketDelegates[attrib.MsgID] = dele + wcpd;
								}
								else
									m_clientPacketDelegates[attrib.MsgID] = wcpd;
							}
						}
					}
				}
			} catch (Exception exp) {
				DebugLogger.Log("", exp);
			}
		}
	}
}
