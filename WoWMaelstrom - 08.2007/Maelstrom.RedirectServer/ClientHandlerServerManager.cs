using System;
using System.Net;
using System.Collections;

namespace Maelstrom
{
	/// <summary>
	/// Manages the internal list of registered client handler servers, as well as providing methods for user counts, etc.
	/// </summary>
	public sealed class ClientHandlerServerManager
	{
		private static Hashtable m_ClientHandlerServers = Hashtable.Synchronized(new Hashtable());

		#region UserCount

		/// <summary>
		/// Provides the number of total users logged in across all Client Handler servers.
		/// </summary>
		public static uint UserCount
		{
			get
			{
				return 0;
			}
		}

		#endregion

		#region RegisterClientHandlerServer

		internal static void RegisterClientHandlerServer(IPAddress Address, ushort Port)
		{
			Console.WriteLine("[REDIRECT]: Registering Client Handler Server at {0}:{1}.",Address.ToString(),Port);
			
			ClientHandlerServerInfo Info = new ClientHandlerServerInfo(Address,Port);
			m_ClientHandlerServers.Add(Address.ToString()+":"+Port.ToString(),Info);
		}

		#endregion
		#region UpdateClientHandlerServerUserCount

		internal static void UpdateClientHandlerServerUserCount(IPAddress Address, ushort Port, uint UserCount)
		{
			Console.WriteLine("[REDIRECT]: Updating Client Handler Server at {0}:{1} with user count {2}.",Address.ToString(),Port,UserCount);
		}

		#endregion
	}
}
