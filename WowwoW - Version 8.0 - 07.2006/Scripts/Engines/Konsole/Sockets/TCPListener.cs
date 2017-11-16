using System;
using System.Net;
using System.Collections;
using System.Net.Sockets;

namespace Server.Konsole.Sockets
{
	/// <summary>
	/// Generic TCPServer Listener
	/// </summary>
	public class TCPListener
	{
		#region private Variables
		private Socket listener;
		private int ConnectionCount = 0;

		private int _Port;
		private IPAddress _IPAddress = IPAddress.Any;
		private int _MaxConnections = 5;

		private IPAddress[] _AllowedIPs;
		private IPAddress[] _DisallowedIPs;
		#endregion

		#region public variables
		public TCPClient[] TCPClients;
		#endregion

		#region Properties
		public int Port
		{
			get
			{
				return (this._Port);
			}
		}

		public IPAddress IPAddress
		{
			get
			{
				return this._IPAddress;
			}
		}

		public int MaxConnections
		{
			get
			{
				return this._MaxConnections;
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
		#endregion

		#region Events

		/// <summary>
		/// Read Event
		/// </summary>
		public delegate void ReadEventHandler(object sender, TCPEventArgs e);
		public event ReadEventHandler BeginRead;

		/// <summary>
		/// Connect Event
		/// </summary>
		public delegate void ConnectEventHandler(object sender, TCPEventArgs e);
		public event ConnectEventHandler BeginConnect;

		/// <summary>
		/// Disconnect Event
		/// </summary>
		public delegate void DisconnectEventHandler(object sender, TCPEventArgs e);
		public event DisconnectEventHandler BeginDisconnect;

		#endregion

		#region Constructor
		public TCPListener(int port)
		{
			this._Port = port;
		}

		public TCPListener(int port, int maxconnections)
		{
			this._Port = port;
			this._MaxConnections = maxconnections;
		}

		public TCPListener(IPAddress ipaddress, int port)
		{
			this._Port = port;
			this._IPAddress = ipaddress;
		}

		public TCPListener(IPAddress ipaddress, int port, int maxconnections)
		{
			this._Port = port;
			this._IPAddress = ipaddress;
			this._MaxConnections = maxconnections;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Start TCP listener
		/// </summary>
		public void Start()
		{
			if(listener != null)
			{
				Console.WriteLine("Listener exists. Stop it first.");
				return;
			}

			try 
			{
				TCPClients = new TCPClient[this.MaxConnections];
				listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				listener.Bind(new IPEndPoint(this.IPAddress, this.Port));
				listener.Listen(this.MaxConnections);

				listener.BeginAccept(new AsyncCallback(BeginAccept), listener);

			}
			catch (Exception ex) 
			{
				SocketHelper.ShowError(this, ex);
			}

		}

		/// <summary>
		/// Disconnect all clients and stop listener
		/// </summary>
		public void Stop()
		{
			try
			{
				if (listener != null)
				{
					Disconnect();
					listener.Close();
					listener = null;
				}
			}
			catch (Exception ex)
			{
				SocketHelper.ShowError(this, ex);
			}
		}

		/// <summary>
		/// Disconnect all clients
		/// </summary>
		public void Disconnect()
		{
			for (int i = 0; i < this.MaxConnections; i++) 
			{ 
				Disconnect(i); 
			}
		}

		/// <summary>
		/// Disconnect client
		/// </summary>
		/// <param name="socketid">SocketID of the client connection</param>
		public void Disconnect(int socketid)
		{
			try 
			{
				if ( (socketid < this.MaxConnections) && 
					(this.TCPClients[socketid] != null) && 
					(this.TCPClients[socketid].Connected))
				{
					this.TCPClients[socketid].DisconnectSocket();
				}
			}
			catch (Exception ex) 
			{
				SocketHelper.ShowError(this, ex);
			}
		}

		/// <summary>
		/// Eplicit Socket disconnect
		/// </summary>
		/// <param name="socket"></param>
		public void Disconnect(Socket socket)
		{
			try 
			{
				if (socket.Connected) 
				{
					socket.Shutdown(SocketShutdown.Both);
					System.Threading.Thread.Sleep(10);
					socket.Close();
				}
			} 
			catch (Exception ex) 
			{
				SocketHelper.ShowError(this, ex);
			}
		}

		/// <summary>
		/// Write data to a socket
		/// </summary>
		/// <param name="data">data</param>
		public void Write(int socketid, string data)
		{
			try 
			{
				if ((socketid < this.MaxConnections) && 
					(this.TCPClients[socketid] != null) && 
					(this.TCPClients[socketid].Connected)) 
				{
					this.TCPClients[socketid].Write(data);
				}
			} 
			catch(Exception ex) 
			{
				SocketHelper.ShowError(this, ex);
			}
		}

		/// <summary>
		/// Write a line of data to a socket
		/// </summary>
		/// <param name="socketid">SocketID</param>
		/// <param name="data">data</param>
		public void WriteLine(int socketid, string data)
		{
			Write( socketid, string.Concat(data, "\r\n") );
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Connect Event
		/// </summary>
		/// <param name="ar"></param>
		private void BeginAccept(IAsyncResult ar)
		{
			Socket listener = (Socket)ar.AsyncState;
			Socket client;

			if ((listener != null) && (listener.Handle.ToInt32() != -1))
			{
				try 
				{
					for (int i = 0; i < this.MaxConnections; i++) 
					{
						if (this.TCPClients[i] == null)
						{
							++this.ConnectionCount;
							this.TCPClients[i] = new TCPClient(listener.EndAccept(ar), i);
							this.TCPClients[i].BeginRead += new TCPClient.ReadEventHandler(this.ReadSocket);
							this.TCPClients[i].BeginDisconnect += new TCPClient.DisconnectEventHandler(this.DisconnectSocket);

							if (BeginConnect != null) 
							{
								BeginConnect(this.TCPClients[i], new TCPEventArgs(null, i, this.TCPClients[i].RemoteEndPoint));
							}
							break;
						} 
						else if (i == this.MaxConnections - 1) 
						{
							client = listener.EndAccept(ar);
							
							Console.WriteLine("Socket connection from IP: {0} was rejected. Maximum Telnet connections reached", client.RemoteEndPoint);

							client.Send( System.Text.Encoding.ASCII.GetBytes("Maximum Telnet connections reached"));
							
							client.Shutdown(SocketShutdown.Both);
							System.Threading.Thread.Sleep(10);
							client.Close();
							//Disconnect(client);
						}
					}

					listener.BeginAccept(new AsyncCallback(BeginAccept), listener);
				}
			 
				catch (Exception ex) 
				{
					SocketHelper.ShowError(this, ex);
				}
			}
		}

		/// <summary>
		/// Socket Read Event
		/// </summary>
		private void ReadSocket(object sender, TCPEventArgs e) 
		{
			if (BeginRead != null)
			{
				BeginRead(this, e);
			}
		}

		/// <summary>
		/// Disconnect
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DisconnectSocket(object sender, TCPEventArgs e) 
		{
			this.TCPClients[e.SocketID] = null;
			--this.ConnectionCount;

			if (BeginDisconnect != null)
			{
				BeginDisconnect(this, e);
			}
		}

		#endregion

	}
}
