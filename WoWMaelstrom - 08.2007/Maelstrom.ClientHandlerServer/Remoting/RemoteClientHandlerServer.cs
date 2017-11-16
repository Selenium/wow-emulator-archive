using System;

namespace Maelstrom.Remoting
{
	using Maelstrom.Remoting.Interfaces;

	/// <summary>
	/// Provides the server-side object to deal with inter-component communication for the Client Handler Server.
	/// </summary>
	internal sealed class RemoteClientHandlerServer: MarshalByRefObject, IClientHandlerServer
	{
	}
}
