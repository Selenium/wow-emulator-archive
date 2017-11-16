using System;
using System.Net.Sockets;

namespace Maelstrom.Network
{
	public sealed class RedirectServerListener: TCPServer
	{
		public static event RedirectTCPEvent ClientConnected;
		public static event RedirectTCPEvent ClientDisconnected;

		protected override TCPConnection CreateConnection(Socket Socket)
		{
			//Makes sure that we're using our custom TCPConnection subclass (RedirectServerConnection).
			return new RedirectServerConnection(this,Socket);
		}

		protected override void OnClientConnected(TCPConnection Connection)
		{
			if (ClientConnected != null)
			{
				ClientConnected((RedirectServerConnection)Connection);
			}
			else
			{
				//We are expecting for the networking for the redirect server to be handled within scripts
				//by hooking into the ClientConnected event, therefore if we don't have any events hooked in 
				//we can assume that no protocol has been defined, and therefore we just disconnect the client.

				Connection.Dispose();
			}
		}

		protected override void OnClientDisconnected(TCPConnection Connection)
		{
			if (ClientDisconnected != null)
			{
				ClientDisconnected((RedirectServerConnection)Connection);
			}
		}

		internal RedirectServerListener(ushort Port): base(Port)
		{
		}
	}
}
