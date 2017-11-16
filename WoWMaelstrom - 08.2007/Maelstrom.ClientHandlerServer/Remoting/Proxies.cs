using System;
using System.Net;
using System.Collections;

namespace Maelstrom.ClientHandlerServer
{
	using Maelstrom.Remoting;
	using Maelstrom.Remoting.Interfaces;

	/// <summary>
	/// Provides a central location for .NET Remoting Proxies used by the Login Server Library.
	/// </summary>
	public sealed class Proxies
	{
		private static IObjectServer m_ObjectServer;
		private static IRedirectServer m_RedirectServer;

		public static IObjectServer ObjectServer
		{
			get {return m_ObjectServer;}
		}

		public static IRedirectServer RedirectServer
		{
			get {return m_RedirectServer;}
		}
        
		internal static void Initialize()
		{
			//TODO: Obtain addresses from some form of configuration...

			m_ObjectServer = (IObjectServer)RemotingClient.GetServerObject(IPAddress.Loopback,40001,"ObjectServer",typeof(IObjectServer));
			m_RedirectServer = (IRedirectServer)RemotingClient.GetServerObject(IPAddress.Loopback,40004,"RedirectServer",typeof(IRedirectServer));
		}
	}
}
