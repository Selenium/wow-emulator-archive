using System;
using System.Net;

namespace Server.Konsole.Telnet
{
	/// <summary>
	/// Configuration values used by Telnet Scripts
	/// </summary>
	public class TelnetConfig
	{
		/// <summary>
		/// By default only Admins can access the server via Telnet
		/// </summary>
		public static AccessLevels MinimumAccessLevel = AccessLevels.Admin;

		/// <summary>
		/// Default port to use
		/// </summary>
		public static int TelnetPort = 8081;

		/// <summary>
		/// IPAddress to use
		/// </summary>
		public static IPAddress IPAddress = IPAddress.Any;

		/// <summary>
		/// Maximum connections allowed to the telnet console at a time
		/// </summary>
		public static int MaxConnections = 1;

		#region Settings NOT implemented
		/// <summary>
		/// Explicit IPs allowed to connect to the Telnet Server
		/// If this value is null then all IPs are allowed(IPAddress.Any) unless explicitly disallowed
		/// By default all IPs are allowed
		/// </summary>
		/// <example>
		/// public IPAddress[] AllowedTelnetIPs = new IPAddress[]{IPAddress.Parse("127.0.0.1")};
		/// will allow only connections from ip 127.0.0.1
		/// </example>
		/// NOT IMPLEMENTED YET
		public static IPAddress[] AllowedTelnetIPs;

		/// <summary>
		/// Explicit IPs disallowed to connect to the Telnet Server
		/// If this value is null then all IPs are allowed unless explicitly not in the allow list
		/// </summary>
		/// <example>
		/// public IPAddress[] DisallowedTelnetIPs = new IPAddress[]{IPAddress.Parse("127.0.0.1", IPAddress.Parse("111.222.123.221"))};
		/// will allow only connections from ip 127.0.0.1
		/// </example>
		/// NOT IMPLEMENTED YET
		public static IPAddress[] DisallowedTelnetIPs;
		#endregion
	}
}
