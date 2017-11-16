using System;
using System.Net;

namespace Maelstrom.Packages.RedirectServer.Network
{
	using Maelstrom;
	using Maelstrom.Network;

	public class NetworkHandler: IScript
	{
		public static void Initialize()
		{
			RedirectServerListener.ClientConnected += new RedirectTCPEvent(OnClientConnected);			
		}

		private static void OnClientConnected(RedirectServerConnection Connection)
		{
			ClientHandlerServerInfo HandlerServer = ClientHandlerManager.PickServer();
			
			//If we have a valid address, then we send it, otherwise we just skip this part and disconnect
			//the client.
			if (HandlerServer.Address != IPAddress.None)
			{
				Connection.Send(HandlerServer.Address,HandlerServer.Port);
			}

			//Once we have sent the address of the server to the client, we close the connection.
			Connection.Dispose();
		}
	}
}