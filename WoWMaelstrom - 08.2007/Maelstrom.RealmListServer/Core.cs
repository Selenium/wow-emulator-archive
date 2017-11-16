using System;

namespace Maelstrom.RealmListServer
{
	using Maelstrom.Remoting;

	/// <summary>
	/// The Maelstrom Realm List Server Library Core.
	/// </summary>
	public sealed class Core
	{
		private const string CONST_SERVER_NAME = "REMOTE_REALM_LIST_SERVER";
		private const ushort CONST_REMOTE_PORT = 40005;

		private static Network.Server m_Server;

		public static void Initialize()
		{
			#region .NET Remoting Service Setup

			RemotingServer RemoteInterface = new RemotingServer(CONST_SERVER_NAME,CONST_REMOTE_PORT);
			RemoteInterface.RegisterType("RealmListServer",typeof(RemoteRealmListServer));

			RemoteInterface.Enabled = true;

			#endregion

			m_Server = new Network.Server();
		}

		public static void Run(string[] Arguments)
		{	
			m_Server.Listen();
			Console.WriteLine("[REALMLIST]: Realmlist active.");
		}

		public static void Shutdown()
		{
		}
	}
}
