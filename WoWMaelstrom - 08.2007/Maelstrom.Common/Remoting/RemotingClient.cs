using System;
using System.Net;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace Maelstrom.Remoting
{
	public sealed class RemotingClient
	{
		private static TcpClientChannel m_RemoteChannel;

		static RemotingClient()
		{
			//I believe we only require one TcpClientChannel per Process/AppDomain, so we ensure that it is
			//constructed statically.
			m_RemoteChannel = new TcpClientChannel();
			ChannelServices.RegisterChannel(m_RemoteChannel);
		}

		/// <summary>
		/// Retrieves a transparent remote proxy object from a .NET remoting service at the given IP address, port, and with the appropriate name and type.
		/// </summary>
		/// <param name="Address">The address where the .NET remoting service can be found, or IPAddress.Loopback for the local host.</param>
		/// <param name="Port">The port where the .NET remoting service can be found.</param>
		/// <param name="Name">The registered name for the server object.</param>
		/// <param name="Type">The type of the server object.</param>
		/// <returns>A proxy object of the specified type which can be used to transparently communicate with the remote server.</returns>
		public static object GetServerObject(IPAddress Address, ushort Port, string Name, Type Type)
		{
			string AddressString = "tcp://"+Address.ToString()+":"+Port.ToString()+"/"+Name;
			
			return Activator.GetObject(Type,AddressString);
		}
	}
}
