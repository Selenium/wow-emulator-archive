using System;
using System.Net;
using System.Net.Sockets;
using System.Collections;

using WoWDaemon.Common;
//using WoWDaemon.Login;

namespace WoWDaemon.Realm
{
	/// <summary>
	/// Helps limiting the access to the real RealmProxys
	/// </summary>
	public class RealmProxy
	{
		private RealmProxy()
		{
		}

		public static ClientBase GetProxy(RealmListServer server)
		{
			LocalClientBase ret = new LocalClientBase();
			LocalClientBase realmUpdaterClient = new LocalClientBase();
			ret.SetRemoteClient(realmUpdaterClient);
			realmUpdaterClient.SetRemoteClient(ret);
			server.AddRealmUpdateClient(realmUpdaterClient);
			return ret;
		}

		public static ClientBase GetProxy(IPEndPoint iep)
		{
			Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			sock.Connect(iep);
			if(sock.Connected == false)
				return null;
			return new ClientBase(sock);
		}
	}
}
