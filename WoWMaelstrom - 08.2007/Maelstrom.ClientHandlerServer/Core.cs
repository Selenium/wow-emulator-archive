using System;
using System.Net;

namespace Maelstrom.ClientHandlerServer
{
	using Maelstrom.Remoting;

	/// <summary>
	/// The Maelstrom Login Server Library Core.
	/// </summary>
	public sealed class Core
	{
		private const string CONST_SERVER_NAME = "REMOTE_CLIENT_HANDLER_SERVER";
		private const ushort CONST_REMOTE_PORT = 40003;

		public static void Initialize()
		{
			#region .NET Remoting Service Setup

			RemotingServer RemoteInterface = new RemotingServer(CONST_SERVER_NAME,CONST_REMOTE_PORT);
			RemoteInterface.RegisterType("ClientHandlerServer",typeof(RemoteClientHandlerServer));

			RemoteInterface.Enabled = true;

			#endregion
		}

		public static void Run(string[] Arguments)
		{
			//Proxies.Initialize();
			//Proxies.RedirectServer.RegisterClientHandlerServer(IPAddress.Loopback,5000);
		}

		public static void Shutdown()
		{
		}
	}
}
