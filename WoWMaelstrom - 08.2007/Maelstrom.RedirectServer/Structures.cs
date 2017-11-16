using System;
using System.Net;

namespace Maelstrom
{
	#region ClientHandlerServerInfo

	public struct ClientHandlerServerInfo
	{
		public IPAddress Address;
		public ushort Port;
		public uint UserCount;

		public ClientHandlerServerInfo(IPAddress Address, ushort Port)
		{
			this.Address = Address;
			this.Port = Port;
			this.UserCount = 0;
		}
	}

	#endregion
}
