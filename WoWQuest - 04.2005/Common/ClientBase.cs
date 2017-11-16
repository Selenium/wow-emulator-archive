using System;
using System.Net;
using System.Net.Sockets;
using System.Collections;

namespace WoWDaemon.Common
{
	/// <summary>
	/// Summary description for ClientBase.
	/// </summary>
	public class ClientBase
	{
		Socket m_socket;
		
		protected Queue m_sendQueue = Queue.Synchronized(new Queue());
		public byte[] Hash;
		public byte[] key = { 0, 0, 0, 0 };
		public bool Authenticated = false;
		int m_currentSent = 0;
		byte[] m_currentData = null;
		protected byte[] m_header = null;
		//public byte[] m_opcode = null;
		protected IPEndPoint m_iep;

		public override string ToString()
		{
			string[] split = this.GetType().ToString().Split('.');
			return split[split.Length-1] + "(" + m_iep.ToString() + ")";
		}

		public ClientBase(Socket sock, int headerSize)
		{
			m_socket = sock;
			m_socket.Blocking = false;
			m_iep = (IPEndPoint)m_socket.RemoteEndPoint;
			m_header = new byte[headerSize];
			//m_opcode = new byte[4];
			//Console.WriteLine(this + " connected.");
		}

		public ClientBase(Socket sock)
		{
			m_socket = sock;
			m_socket.Blocking = false;
			m_iep = (IPEndPoint)m_socket.RemoteEndPoint;
			m_header = new byte[4];
			//m_opcode = new byte[4];
			//Console.WriteLine(this.GetType().ToString() + "(" + m_iep.ToString() + ") connected.");
		}

		public ClientBase()
		{
		}

		public virtual IPEndPoint RemoteEndPoint
		{
			get
			{
				return m_iep;
			}
		}

		public virtual bool Connected
		{
			get
			{
				try
				{
					if(m_socket.Connected && m_socket.Poll(0, SelectMode.SelectRead))
					{
						byte[] aByte = new byte[1];
						if(m_socket.Receive(aByte, 0, 1, SocketFlags.Peek) != 0)
							return true;
						Close("Disconnected.");
						return false;
					}
				}
				catch(SocketException e)
				{
					OnException(e);
				}
				return m_socket.Connected;
			}
		}

		public virtual bool Timedout
		{
			get
			{
				return false;
			}
		}

		public virtual void Close(string reason)
		{
			//Console.WriteLine(this + " closed: " + reason);
			try
			{
				m_socket.Shutdown(SocketShutdown.Both);
				m_socket.Close();
			}
			catch(Exception){}
		}

		public virtual void OnException(Exception e)
		{
			if(e is SocketException)
				Close(e.Message + " (" + ((SocketException)e).ErrorCode + ")");
			else
				Close(e.Message);
		}

		/// <summary>
		/// Size of the packet data + header
		/// </summary>
		public virtual int PacketSize
		{
			get
			{
				int size = BitConverter.ToInt32(m_header, 0);
				if(size > 0xFFFF || size == 0)
					throw new Exception("Corrupt packet(size=" + string.Format("0x{0:X}", size) + ").");
				return size+m_header.Length;
			}
		}

		public virtual byte[] GetNextPacketData()
		{
			try
			{
				int available = m_socket.Available;
				if(available < m_header.Length)
					return null;
				int rcvd;

				rcvd = m_socket.Receive(m_header, 0, m_header.Length, SocketFlags.Peek);

				if (Authenticated == true)
				{
					Decode(m_header,2);
				}

				if(rcvd <= 0)
				{
					Close("Disconnected.");
					return null;
				}

				int size = PacketSize;
				if(available < size)
					return null;

				/*byte[] data;
				if (Authenticated == true)
				{
					data = new byte[size-4];
					rcvd  = m_socket.Receive(m_opcode,0,4,SocketFlags.None);
					rcvd += m_socket.Receive(data,0,size-4,SocketFlags.None);
					Decode(m_opcode,4);
				}
				else
				{
					data = new byte[size];
					rcvd = m_socket.Receive(data, 0, size, SocketFlags.None);
				}*/
				byte[] data = new byte[size];
				rcvd = m_socket.Receive(data, 0, size, SocketFlags.None);

				if(rcvd <= 0)
				{
					Close("Disconnected.");
					return null;
				}
				return data;
			}
			catch(ObjectDisposedException)
			{
				return null;
			}
			catch(Exception e)
			{
				OnException(e);
				return null;
			}
		}

		#region SendRelated

		public void Send(byte[] data, long size)
		{
			byte[] tmp = new byte[size];
			Array.Copy(data, 0, tmp, 0, size);
			EnqueueSendData(tmp);
		}

		public void Send(byte[] data, int size)
		{
			byte[] tmp = new byte[size];
			Array.Copy(data, 0, tmp, 0, size);
			EnqueueSendData(tmp);
		}

		public void Send(byte[] data)
		{
			EnqueueSendData((byte[])data.Clone());
		}

		public void Encode( byte[] data) 
		{
			for(int t = 0;t < 4;t++ ) 
			{             
				byte a = key[ 3 ]; 
				a = (byte)( Hash[ a ] ^ data[ t ] );
				byte d = key[ 2 ]; 
				a += d; 
				data[ t ] = a; 
				key[ 2 ] = a; 
				a = key[ 3 ]; 
				a++;             
				key[ 3 ] = (byte)( a % 0x28 ); 
			} 
		}

		public void Decode(byte[] data) 
		{
			for(int t = 0;t < 6; t++ ) 
			{
				byte a = key[ 0 ]; 
				key[ 0 ] = data[ t ]; 

				byte b = data[ t ]; 
				b = (byte)( b - a ); 

				byte d = key[ 1 ]; 
				a = Hash[ d ]; 
				a = (byte)( a ^ b ); 
				data[ t ] = a; 

				a = key[ 1 ]; 
				a++; 
				key[ 1 ] = (byte)( a % 0x28 );
			} 
		}

		public void Decode(byte[] data, int size) 
		{
			for(int t = 0;t < size; t++ ) 
			{
				byte a = key[ 0 ]; 
				key[ 0 ] = data[ t ]; 

				byte b = data[ t ]; 
				b = (byte)( b - a ); 

				byte d = key[ 1 ]; 
				a = Hash[ d ]; 
				a = (byte)( a ^ b ); 
				data[ t ] = a; 

				a = key[ 1 ]; 
				a++; 
				key[ 1 ] = (byte)( a % 0x28 );
			} 
		}

		public virtual void EnqueueSendData(byte[] data)
		{
			try
			{

				if (Authenticated == true)
				{
					byte[] pkg = new byte[data.Length];
					Array.Copy(data,pkg,4);
					Encode(pkg);
					if (data.Length>4) // if it contains data, add it to pkg
					{
						Array.Copy(data, 4, pkg, 4, data.Length-4);
					}

					m_sendQueue.Enqueue(pkg);
				}
				else
				{           
					m_sendQueue.Enqueue(data);
				}
				SendWork();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);	
			}
		}

		public virtual bool PendingSendData
		{
			get
			{
				return m_sendQueue.Count > 0;
			}
		}

		public virtual void SendWork()
		{
			if(m_currentData == null)
			{
				if(!PendingSendData)
					return;
				m_currentData = (byte[])m_sendQueue.Dequeue();
				m_currentSent = 0;
			}
			int ret;
			while(true)
			{
				try
				{
					ret = m_socket.Send(m_currentData, m_currentSent, m_currentData.Length, SocketFlags.None);
				}
				catch(ObjectDisposedException) // should not happen
				{
					return;
				}
				catch(SocketException se)
				{
					if(se.ErrorCode == 10035) // A non-blocking socket operation could not complete immediatly
						return;
					OnException(se);
					return;
				}
				catch(Exception e)
				{
					OnException(e);
					return;
				}
				m_currentSent += ret;
				// if not all data has been sent we break and retry some other time
				if(m_currentSent < m_currentData.Length)
					return;
				m_currentData = null;
				m_currentSent = 0;
				if(!PendingSendData) // nothing left todo
					return;
				m_currentData = (byte[])m_sendQueue.Dequeue();
			}
		}
		#endregion
	}
}
