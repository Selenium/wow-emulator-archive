using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using Server;

namespace DDB
{
	/// <summary>
	/// Summary description for ClientHandler.
	/// </summary>
	public class DBClientHandler : SockClient
	{
		public DBClientHandler( Socket sock, Server.RemoveClientDelegate rcd ) : base( sock, rcd )
		{
		}

		public override byte [] ProcessDataReceived( byte []data, int length )
		{
			return null;
		}
	}
}
