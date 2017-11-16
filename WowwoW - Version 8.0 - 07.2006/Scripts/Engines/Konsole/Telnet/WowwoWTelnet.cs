using System;
using System.Net;
using System.Net.Sockets;

using Server.Konsole.Sockets;

namespace Server.Konsole.Telnet
{
	/// <summary>
	/// Summary description for WowwoWTelnet.
	/// </summary>
	public class WowwoWTelnet
	{

		#region Private Variables
		public TCPListener listener;

		private int _Port;
		private IPAddress _IPAddress;
		private int _MaxConnections;
		private IPAddress[] _AllowedIPs;
		private IPAddress[] _DisallowedIPs;
		private AccessLevels _MinAccessLevel;

		private string USER = string.Empty;
		private string PASS = string.Empty;
		#endregion

		#region Properties
		public IPAddress[] DisallowedIPs
		{
			get
			{
				return (this._DisallowedIPs);
			}
			set
			{
				this._DisallowedIPs = value;
			}
		}

		public IPAddress[] AllowedIPs
		{
			get
			{
				return (this._AllowedIPs);
			}
			set
			{
				this._AllowedIPs = value;
			}
		}


		public int MaxConnections
		{
			get
			{
				return (this._MaxConnections);
			}
			set
			{
				this._MaxConnections = value;
			}
		}


		public IPAddress IPAddress
		{
			get
			{
				return (this._IPAddress);
			}
			set
			{
				this._IPAddress = value;
			}
		}


		public int Port
		{
			get
			{
				return (this._Port);
			}
			set
			{
				this._Port = value;
			}
		}

		public AccessLevels MinAccessLevel
		{
			get
			{
				return (this._MinAccessLevel);
			}
			set
			{
				this._MinAccessLevel = value;
			}
		}
		#endregion

		#region Public Methods
		public void Start()
		{
			if(listener != null)
			{
				listener.Start();
			}
			else
			{
				Console.WriteLine("Initialise the TCPListener first");
			}
		}

		public void Stop()
		{
			if(listener != null)
			{
				listener.Stop();
			}
		}
		#endregion

		#region Constructor
		public WowwoWTelnet()
		{
			this._AllowedIPs = TelnetConfig.AllowedTelnetIPs;
			this._DisallowedIPs = TelnetConfig.DisallowedTelnetIPs;
			this._IPAddress = TelnetConfig.IPAddress;
			this._MaxConnections = TelnetConfig.MaxConnections;
			this._MinAccessLevel = TelnetConfig.MinimumAccessLevel;
			this._Port = TelnetConfig.TelnetPort;

			listener = new TCPListener(this._IPAddress, this._Port, this._MaxConnections);

			listener.BeginConnect += new Server.Konsole.Sockets.TCPListener.ConnectEventHandler(listener_BeginConnect);
			listener.BeginDisconnect += new Server.Konsole.Sockets.TCPListener.DisconnectEventHandler(listener_BeginDisconnect);
			listener.BeginRead += new Server.Konsole.Sockets.TCPListener.ReadEventHandler(listener_BeginRead);
		}
		#endregion

		#region Private Methods
		private void listener_BeginConnect(object sender, TCPEventArgs e)
		{
			Console.WriteLine("A new Telnet Client accepted on slot {0} IP: {1}", e.SocketID, e.Endpoint.ToString());
			listener.WriteLine(e.SocketID, "Welcome to WowwoW Telnet Server...\r\nThis is a clear text Telnet server\t** Use at your own risk **\r\nSend <USER> <PASS> for authentication");
		}

		private void listener_BeginDisconnect(object sender, TCPEventArgs e)
		{
			Console.WriteLine("The Telnet client on slot {0} has disconnected", e.SocketID);
		}

		private void listener_BeginRead(object sender, TCPEventArgs e)
		{
			try
			{

				TCPClient client = ((TCPListener)sender).TCPClients[e.SocketID];

				string data = GetData(e.Data);
				string commandValue = string.Empty;

				//Check for quit
				if(data.ToUpper() == "QUIT")
				{
					Console.WriteLine("Goodbye");
					client.DisconnectSocket();
					return;
				}

				//Process the command
				if(!client.Authenticated)
				{
					client.LoginAttempt++;

					string[] vals = data.Split(' ');
					if(vals == null || vals.Length < 2)
					{
						client.WriteLine("Send <USER> <PASS> for authentication");
					}
					else
					{
						Account acc = Konsole.Commands.HelperTools.GetAccByName(vals[0]);

						if(acc != null && acc.Password.ToUpper() == vals[1].ToUpper())
						{
							if(acc.AccessLevel >= TelnetConfig.MinimumAccessLevel)
							{
								client.Authenticated = true;
								client.Account = acc;
								client.WriteLine(string.Concat( "Welcome ", acc.Username, ", you have been authenticated" ));
								Console.WriteLine("Telnet client authenticated: {0}", acc.Username);
							}
							else
							{
								client.WriteLine("Your access level is too low to use the telnet interface");
								Console.WriteLine("Inadequite accesslevel on slot: {0} Account: {1} IP:{2}", e.SocketID, acc.Username, e.Endpoint.ToString());
								client.DisconnectSocket();
								return;
							}
						}
						else
						{
							if(client.LoginAttempt == 3)
							{
								client.WriteLine("Login attempts exceeded. 3 strikes, you're out!");
								client.DisconnectSocket();
								Console.WriteLine("Telnet authentication attempts exceeded on IP: {0}", e.Endpoint.ToString());
								return;
							}
							else
							{
								client.WriteLine("Bad credentials, try again\r\nSend <USER> <PASS> for authentication");
							}
						}
					}
				}
				else
				{
					KonsoleCommands.ProcessKonsoleInput(data);
					Console.WriteLine("[WowwoW <? for help>]");
				}
			}
			catch(Exception ex)
			{
				SocketHelper.ShowError(this, ex);
			}

		}

		private string GetData(string message)
		{
			message = message.Trim();

			while (message.IndexOf((char) 8) >= 0) 
			{
				int index = message.IndexOf((char) 8);
				if (index == 0)
				{
					message = message.Substring(1, message.Length - 1);
				}
				else if (index > 0)
				{
					message = message.Substring(0, index - 1) + message.Substring(index + 1);
				}
			}

			return message;
		}
		#endregion
	}
}
