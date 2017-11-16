using System;
using System.Net;
using System.Net.Sockets;

namespace Maelstrom.Network
{
	public class RedirectServerConnection: TCPConnection
	{
		public void Send(IPAddress Address, ushort Port)
		{
			string ResultString = Address.ToString()+":"+Port.ToString();
			
			//Send the final address to the client, including the null terminator.
			this.Send(Utilities.ToBytes(ResultString,true));
		}

		internal RedirectServerConnection(RedirectServerListener Listener, Socket Socket): base(Listener,Socket)
		{
		}
	}
}
