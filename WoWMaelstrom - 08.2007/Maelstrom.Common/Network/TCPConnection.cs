using System;
using System.Net;
using System.Net.Sockets;

namespace Maelstrom.Network
{
	/// <summary>
	/// Provides a TCP connection that encapsulates asynchronous sends and receives.
	/// </summary>
	public class TCPConnection: IDisposable
	{
		private TCPServer m_Server;
		private Socket m_Socket;
		private AsyncCallback m_AsyncReceive;
		private AsyncCallback m_AsyncSend;

		private bool m_Connected = false;

		#region Server

		public TCPServer Server
		{
			get {return m_Server;}
		}

		#endregion
		#region Socket

		public Socket Socket
		{
			get {return m_Socket;}
		}

		#endregion
		#region Connected

		public bool Connected
		{
			get	
			{
				return ((m_Socket != null) && m_Connected);
			}
		}

		#endregion
        
		#region AsyncReceive

		private void AsyncReceive(IAsyncResult Result)
		{
			try
			{
				if (Connected)
				{
					int ReceivedAmount = m_Socket.EndReceive(Result);
					if (Connected) //Because of the nature of async sockets, we have to check twice,
								   //once before we try perform a receive, and again after we have
								   //performed the receive.
					{
						OnDataReceived((byte[])Result.AsyncState,(uint)ReceivedAmount);
					}
				}
			}
			catch
			{
				Dispose(); //If we have any exceptions we just dispose of the connection.
			}
		}

		#endregion
		#region AsyncSend

		private void AsyncSend(IAsyncResult Result)
		{
			try
			{
				if (Connected)
				{
					m_Socket.EndSend(Result);
					if (Connected)
					{
						OnDataSent((byte[])Result.AsyncState);
					}
				}
			}
			catch
			{
				Dispose(); //If we have any exceptions we just dispose of the connection.
			}
		}

		#endregion
		#region OnDataReceived

		protected virtual void OnDataReceived(byte[] Buffer, uint Amount) {}

		#endregion
		#region OnDataSent

		protected virtual void OnDataSent(byte[] Buffer) {}

		#endregion

		#region Receive

		/// <summary>
		/// Receives a given amount of bytes from the TCP stream.
		/// </summary>
		/// <param name="Amount">The amount of bytes to receive from the client.</param>
		public void Receive(uint Amount)
		{
			try
			{
				if (Connected)
				{
					byte[] Buffer = new byte[Amount];
					m_Socket.BeginReceive(Buffer,0,(int)Amount,SocketFlags.None,m_AsyncReceive,Buffer);
				}
			}
			catch
			{
				Dispose();
			}
		}

		#endregion
		#region Send

		/// <summary>
		/// Sends a series of bytes to the client.
		/// </summary>
		/// <param name="Buffer">The bytes to sent to the client.</param>
		public void Send(byte[] Buffer)
		{
			try
			{
				if (Connected)
				{
					m_Socket.BeginSend(Buffer,0,Buffer.Length,SocketFlags.None,m_AsyncSend,Buffer);
				}
			}
			catch
			{
				Dispose();
			}
		}

		#endregion

		/// <summary>
		/// Constructs a new instance of the TCPConnection class, binding the given client socket to it.
		/// </summary>
		/// <param name="Server">The server that this TCPConnection instance belongs to.</param>
		/// <param name="Socket">The client socket to associate with this TCPConnection instance.</param>
		public TCPConnection(TCPServer Server, Socket Socket)
		{
			m_Server = Server;
			m_Socket = Socket;
			m_AsyncReceive = new AsyncCallback(AsyncReceive);
			m_AsyncSend = new AsyncCallback(AsyncSend);

			m_Connected = true;
			m_Server.RaiseClientConnected(this);
		}

		/// <summary>
		/// Disposes of this TCPConnection instance, disconnecting the client.
		/// </summary>
		public void Dispose()
		{
			if (Connected)
			{
				m_Connected = false;

				m_Server.RaiseClientDisconnected(this);
				
				m_Socket.Shutdown(SocketShutdown.Both);
				m_Socket.Close();
			}

			m_Socket = null;
		}
	}
}
