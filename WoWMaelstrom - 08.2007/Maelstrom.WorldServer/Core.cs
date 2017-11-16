using System;

namespace Maelstrom.WorldServer
{
	using Maelstrom.Remoting;

	/// <summary>
	/// The Maelstrom World Server Library Core.
	/// </summary>
	public sealed class Core
	{
		private const string CONST_SERVER_NAME = "REMOTE_WORLD_SERVER";
		private const ushort CONST_REMOTE_PORT = 40002;

		public static void Initialize()
		{
			#region .NET Remoting Service Setup

			RemotingServer RemoteInterface = new RemotingServer(CONST_SERVER_NAME,CONST_REMOTE_PORT);
			RemoteInterface.RegisterType("WorldServer",typeof(RemoteWorldServer));

			RemoteInterface.Enabled = true;

			#endregion
		}

		public static void Run(string[] Arguments)
		{
		}

		public static void Shutdown()
		{
		}
	}
}
