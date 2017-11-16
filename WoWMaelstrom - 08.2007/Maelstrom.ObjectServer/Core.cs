using System;

namespace Maelstrom.ObjectServer
{
	using Maelstrom.Remoting;
	
	/// <summary>
	/// The Maelstrom Object Server Library Core.
	/// </summary>
	public sealed class Core
	{
		private const string CONST_SERVER_NAME = "REMOTE_OBJECT_SERVER";
		private const ushort CONST_REMOTE_PORT = 40001;

		public static void Initialize()
		{
			#region .NET Remoting Service Setup

			RemotingServer RemoteInterface = new RemotingServer(CONST_SERVER_NAME,CONST_REMOTE_PORT);
			RemoteInterface.RegisterType("ObjectServer",typeof(RemoteObjectServer));

			RemoteInterface.Enabled = true;

			#endregion
		}

		public static void Run(string[] Arguments)
		{
			Proxies.Initialize();
		}

		public static void Shutdown()
		{
		}
	}
}
