using System;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Diagnostics;

namespace Server.Konsole.Sockets
{
	/// <summary>
	/// Summary description for TCPClient.
	/// </summary>
	public class TCPClient
	{

		#region Events
		/// <summary>
		/// Read Event
		/// </summary>
		public delegate void ReadEventHandler(object sender, TCPEventArgs e);
		public event ReadEventHandler BeginRead;

		/// <summary>
		/// Disconnect Event
		/// </summary>
		public delegate void DisconnectEventHandler(object sender, TCPEventArgs e);
		public event DisconnectEventHandler BeginDisconnect;
		#endregion

		#region Private Variables
		private Socket _ClientSocket;
		private int _BufferLength = 256;
		private int _ID;

		private byte[] _Buffer;
		private string _Data = string.Empty;

		private Account _Account;
		private bool _Authenticated;
		private int _LoginAttempt = 0;
		#endregion

		#region Properties
		public int LoginAttempt
		{
			get
			{
				return (this._LoginAttempt);
			}
			set
			{
				this._LoginAttempt = value;
			}
		}

		public bool Authenticated
		{
			get
			{
				return (this._Authenticated);
			}
			set
			{
				this._Authenticated = value;
			}
		}

		public Account Account
		{
			get
			{
				return (this._Account);
			}
			set
			{
				this._Account = value;
			}
		}

		public int ID
		{
			get
			{
				return (this._ID);
			}
		}

		public bool Connected 
		{
			get 
			{
				if (this._ClientSocket == null)
				{
					return false;
				}

				return this._ClientSocket.Connected;
			}
		}
		
		public EndPoint RemoteEndPoint
		{
			get 
			{ 
				return this._ClientSocket.RemoteEndPoint;
			}
		}
		#endregion

		#region Constructor
		public TCPClient(Socket client, int id)
		{
			this._ID = id;
			this._ClientSocket = client;
			this._Buffer = new byte[this._BufferLength];

			this._ClientSocket.BeginReceive(this._Buffer, 0, this._Buffer.Length, SocketFlags.None, new AsyncCallback(BeginReceive), this._ClientSocket);
		}
		#endregion

		#region Public Methods
		public void Write(string value) 
		{
			try 
			{
				if ((this._ClientSocket != null) && (this._ClientSocket.Connected)) 
				{
					Byte[] byte_data = Encoding.ASCII.GetBytes(value.ToCharArray());
					this._ClientSocket.Send(byte_data, byte_data.Length, 0);
				}
			} 
			catch(Exception ex) 
			{
				SocketHelper.ShowError(this, ex);
			}
		}

		public void WriteLine(string value) 
		{
			Write(value + "\r\n");
		}

		public void DisconnectSocket() 
		{
			if (this._ClientSocket != null)
			{

				TCPEventArgs args = new TCPEventArgs(null, this._ID, this._ClientSocket.RemoteEndPoint);

				try 
				{
					if (this._ClientSocket.Connected)
					{
						this._ID = -1;
						this._ClientSocket.Shutdown(SocketShutdown.Both);
						System.Threading.Thread.Sleep(10);
						this._ClientSocket.Close();
						this._ClientSocket = null;
					}
				}
				catch (Exception ex)
				{
					SocketHelper.ShowError(this, ex);
				}

				if (BeginDisconnect != null)
				{
					BeginDisconnect(this, args);
				}
			}
		}
		#endregion

		#region Private Methods
		private void BeginReceive(IAsyncResult ar) 
		{
			Socket client = (Socket) ar.AsyncState;

			if (this._ID < 0)
			{
				return;
			}

			try 
			{
				int nBytesRec = client.EndReceive(ar);
				if (nBytesRec > 0) 
				{
					string sReceived = Encoding.ASCII.GetString(this._Buffer, 0, nBytesRec);
					this._Data += sReceived;

					while(this._Data.IndexOf("\n") > 0) 
					{
						if (BeginRead != null)
						{
							BeginRead(this, new TCPEventArgs(this._Data.Substring(0, this._Data.IndexOf("\n")), this._ID, client.RemoteEndPoint));
						}
						this._Data = this._Data.Substring(this._Data.IndexOf("\n") + 1);
					}

					while (this._Data.Length > this._BufferLength) 
					{
						if (BeginRead != null)
						{
							BeginRead(this, new TCPEventArgs(this._Data.Substring(0, this._BufferLength), this._ID, client.RemoteEndPoint));
						}
						this._Data = this._Data.Substring(this._BufferLength + 1);
					}

					if (client.Connected) 
					{
						client.BeginReceive(this._Buffer, 0, this._Buffer.Length, SocketFlags.None, new AsyncCallback(BeginReceive), client);
					}
				}
				else 
				{
					DisconnectSocket();
				}
			} 
			catch( Exception ex ) 
			{
				SocketHelper.ShowError(this, ex);
			}
		}
		#endregion
	}
}























