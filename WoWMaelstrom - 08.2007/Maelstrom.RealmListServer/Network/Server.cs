using System;

namespace Maelstrom.RedirectServer.Network
{
	using Maelstrom.Network;

	public sealed class Server: TCPServer
	{
		public static event RedirectTCPEvent ClientConnected;
		public static event RedirectTCPEvent ClientDisconnected;

		protected override void OnClientConnected(TCPConnection Connection)
		{
			if (ClientConnected != null)
			{
				ClientConnected(Connection);
			}

			//TODO: Select an available Client Handler server from the list of registered servers and send the IP & Port to the client.

			Connection.Dispose(); //Disconnect the connection from this server.
		}

		protected override void OnClientDisconnected(TCPConnection Connection)
		{
			if (ClientDisconnected != null)
			{
				ClientDisconnected(Connection);
			}
		}

		internal Server(): base(5432)	{}
	}
}
