using System;
using System.Net;
using System.Net.Sockets;

namespace Maelstrom.Network
{
	/// <summary>
	/// Provides a TCP server that encapsulates asynchronous socket connections.
	/// </summary>
	public class TCPServer: IDisposable
	{
		private const int CONST_CONNECTION_QUEUE = 10; //Indicates how many simultaneous pending connections to queue.

		private Socket m_ServerSocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
		private bool m_Listening = false;
		private AsyncCallback m_AsyncConnect;
		private ushort m_Port;

		#region Port

		public ushort Port
		{
			get {return m_Port;}
		}

		#endregion

		#region AsyncConnect

		private void AsyncConnect(IAsyncResult Result)
		{
			Socket ClientSocket = m_ServerSocket.EndAccept(Result);
			CreateConnection(ClientSocket);

			Accept();
		}

		#endregion
		#region CreateConnection
		
		/// <summary>
		/// Constructs a new TCPConnection instance when a client connects to this TCPServer instance. Override this method
		/// in a child class to use a custom defined TCPConnection subclass.
		/// </summary>
		/// <param name="Socket">The client socket to be associated with the connection being created.</param>
		/// <returns>A TCPConnection instance for this connection.</returns>
		protected virtual TCPConnection CreateConnection(Socket Socket)
		{
			return new TCPConnection(this,Socket);
		}

		#endregion
		#region Accept

		/// <summary>
		/// Accepts the next asynchronous connection in the connection queue for the server socket.
		/// </summary>
		private void Accept()
		{
			m_ServerSocket.BeginAccept(m_AsyncConnect,null);
		}

		#endregion
		#region Listen

		/// <summary>
		/// Starts listening for client connections.
		/// </summary>
		public void Listen()
		{
			if (!m_Listening)
			{
				m_ServerSocket.Listen(CONST_CONNECTION_QUEUE);
				m_Listening = true;

				Accept();
			}
		}

		#endregion

		#region OnClientConnected

		protected virtual void OnClientConnected(TCPConnection Connection) {}

		#endregion
		#region OnClientDisconnected

		protected virtual void OnClientDisconnected(TCPConnection Connection) {}

		#endregion
		
		#region RaiseClientConnected

		/// <summary>
		/// Called when a client connects to the server, and invokes the OnClientConnected method.
		/// </summary>
		/// <param name="Connection">The TCPConnection instance connecting to the server.</param>
		internal void RaiseClientConnected(TCPConnection Connection)
		{
			OnClientConnected(Connection);
		}

		#endregion
		#region RaiseClientDisconnected

		/// <summary>
		/// Called when a client disconnects from the server, and invokes the OnClientDisconnected method.
		/// </summary>
		/// <param name="Connection">The TCPConnection instance disconnecting from the server.</param>
		internal void RaiseClientDisconnected(TCPConnection Connection)
		{
			OnClientDisconnected(Connection);
		}

		#endregion

		/// <summary>
		/// Constructs a new instance of the TCPServer class which listens on any available IP address on a given port.
		/// </summary>
		/// <param name="Port">The port that this TCPServer instance should listen on.</param>
		public TCPServer(ushort Port): this(new IPAddress[1] {IPAddress.Any},Port) {}

		/// <summary>
		/// Constructs a new instance of the TCPServer class which listens on a specific list of IP addresses on a given port.
		/// </summary>
		/// <param name="ListenAddresses">An array of IP Addresses that this TCPServer instance should listen on.</param>
		/// <param name="Port">The port that this TCPServer instance should listen on.</param>
		public TCPServer(IPAddress[] ListenAddresses, ushort Port)
		{
			m_Port = Port;
			m_AsyncConnect = new AsyncCallback(AsyncConnect);

			//TODO: Change some m_ServerSocket properties to better improve networking performance.

			foreach(IPAddress Address in ListenAddresses)
			{
				m_ServerSocket.Bind(new IPEndPoint(Address,Port));
			}
		}
		
		/// <summary>
		/// Disposes of this TCPServer instance, shutting down the connection and disconnecting all clients.
		/// </summary>
		public void Dispose()
		{
			if (m_ServerSocket != null)
			{
				m_ServerSocket.Shutdown(SocketShutdown.Both);
				m_ServerSocket.Close();
				m_ServerSocket = null;
			}
		}
	}
}
