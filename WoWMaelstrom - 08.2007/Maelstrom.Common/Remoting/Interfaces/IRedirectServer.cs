using System;
using System.Net;

namespace Maelstrom.Remoting.Interfaces
{
	/// <summary>
	/// Provides a remoting interface to the Redirect Server Library.
	/// </summary>
	public interface IRedirectServer
	{
		/// <summary>
		/// Registers a Client Handler Server with the remote Redirect Server.
		/// </summary>
		/// <param name="Address">The address of the client handler server to register.</param>
		/// <param name="Port">The port of the client handler server to register.</param>
		void RegisterClientHandlerServer(IPAddress Address, ushort Port);

		/// <summary>
		/// Updates the number of users logged into a specific Client Handler Server at any one time. This value is used for reporting of users
		/// to the Realm List server, as well as for assigning clients to a Client Handler Server with a low load.
		/// </summary>
		/// <param name="Address">The address of the client handler server being updated.</param>
		/// <param name="Port">The port of the client handler server being updated.</param>
		/// <param name="UserCount">The amount of users currently connected to the client handler server.</param>
		void UpdateClientHandlerServerUserCount(IPAddress Address, ushort Port, uint UserCount);

		/// <summary>
		/// Returns the total amount of users logged into each Login Server, this is used by the Realm List when displaying the
		/// server user count.
		/// </summary>
		/// <returns>The amount of users logged into the realm.</returns>
		uint GetUserCount();
	}
}
