using System;
using System.Net;

namespace Maelstrom.Remoting
{
	using Maelstrom.Remoting.Interfaces;

	/// <summary>
	/// Provides the server-side object to deal with inter-component communication for the Redirect Server.
	/// </summary>
	internal sealed class RemoteRedirectServer: MarshalByRefObject, IRedirectServer
	{
		#region RegisterClientHandlerServer

		public void RegisterClientHandlerServer(IPAddress Address, ushort Port)
		{
			ClientHandlerManager.RegisterClientHandlerServer(Address,Port);
		}

		#endregion
		#region UpdateClientHandlerServerUserCount

		public void UpdateClientHandlerServerUserCount(IPAddress Address, ushort Port, uint UserCount)
		{
			ClientHandlerManager.UpdateClientHandlerServerUserCount(Address,Port,UserCount);
		}

		#endregion
		#region GetUserCount

		public uint GetUserCount()
		{
			return ClientHandlerManager.UserCount;
		}

		#endregion
	}
}
