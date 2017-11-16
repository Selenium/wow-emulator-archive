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
		protected Socket m_socket;
		
		protected Queue m_sendQueue = Queue.Synchronized(new Queue());
		public byte[] Hash;
		public byte[] key = { 0, 0, 0, 0 };
		public bool Authenticated = false;

		// For sending... should be rewritten :)
		byte[] m_currentData;
		int m_currentSent = 0;

		protected PacketBuffer m_packet_header;
		protected PacketBuffer m_packet_data;

		//public byte[] m_opcode = null;
		protected IPEndPoint m_iep;

		public delegate void OnDataHandler(ClientBase client, byte[] data);
		public event OnDataHandler RecievedDataHandler;

		public override string ToString()
		{
			string[] split = this.GetType().ToString().Split('.');
			return split[split.Length-1] + "(" + m_iep.ToString() + ")";
		}

		public ClientBase(Socket sock)
		{
			m_socket = sock;

			// Problematic?
			if (m_socket != null)
			{
				m_socket.Blocking = false;

				m_iep = (IPEndPoint)m_socket.RemoteEndPoint;
			
				m_packet_header = new PacketBuffer(PacketHeaderSize);
				registerRecieveCallback(true);
			}
		}

		#region Client state
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
		#endregion

		public virtual void OnException(Exception e)
		{
			if(e is SocketException)
				Close(e.Message + " (" + ((SocketException)e).ErrorCode + ")");
			else
				Close(e.Message);
		}

		#region Packet size calculations
		/// <summary>
		/// Get the size of just the header. Overridding me is a good idea.
		/// </summary>
		public virtual int PacketHeaderSize
		{
			get
			{
				return 4;
			}
		}

		/// <summary>
		/// Size of the packet data. May require header to be read in already.
		/// </summary>
		public virtual int PacketDataSize
		{
			get
			{
				int size = BitConverter.ToInt32(m_packet_header.Peek(), 0);
				if(size > 0xFFFF || size == 0)
					throw new Exception("Corrupt packet(size=" + string.Format("0x{0:X}", size) + ").");
				return size;
			}
		}
		#endregion
		
#if false
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
#endif

		#region Encryption
		public void Encode(byte[] data)
		{
			for (int t = 0; t < 4; t++)
			{
				byte a = key[3];
				a = (byte)(Hash[a] ^ data[t]);
				byte d = key[2];
				a += d;
				data[t] = a;
				key[2] = a;
				a = key[3];
				a++;
				key[3] = (byte)(a % 0x28);
			}
		}

		public void Decode(byte[] data)
		{
			for (int t = 0; t < 6 && t < data.Length; t++)
			{
				byte a = key[0];
				key[0] = data[t];

				byte b = data[t];
				b = (byte)(b - a);

				byte d = key[1];
				a = Hash[d];
				a = (byte)(a ^ b);
				data[t] = a;

				a = key[1];
				a++;
				key[1] = (byte)(a % 0x28);
			}
		}

		public void Decode(byte[] data, int size)
		{
			for (int t = 0; t < size; t++)
			{
				byte a = key[0];
				key[0] = data[t];

				byte b = data[t];
				b = (byte)(b - a);

				byte d = key[1];
				a = Hash[d];
				a = (byte)(a ^ b);
				data[t] = a;

				a = key[1];
				a++;
				key[1] = (byte)(a % 0x28);
			}
		}
		#endregion

		#region Recieve related

		#region Connection maintenance
		/// <summary>
		/// Register a data recieving callback function to read data from the server
		/// </summary>
		/// <param name="readHeader">Whether or not we're reading in the header (false == data segment)</param>
		private void registerRecieveCallback(bool readHeader)
		{
			PacketBuffer buf = readHeader ? m_packet_header : m_packet_data;

			try
			{
				m_socket.BeginReceive(
					buf.ReadBuffer.Array, buf.ReadBuffer.Offset, buf.ReadBuffer.Count,
					SocketFlags.None, new AsyncCallback(recieveCallback), readHeader);
			}
			catch (Exception e)
			{
				OnException(e);
			}
		}

		/// <summary>
		/// callback for recieving connection data events.
		/// </summary>
		private void recieveCallback(IAsyncResult result)
		{
			try
			{
				bool readingHeader = (bool)result.AsyncState;

				int bytes_read = m_socket.EndReceive(result);

				if (bytes_read == 0)
				{
					Close("Remote client closed connection");
					return;
				}

				PacketBuffer buf = readingHeader ? m_packet_header : m_packet_data;
				buf.BytesRead += bytes_read;

//				System.Console.WriteLine("in {0} recieveCallback() - read in {1} bytes. -> {2}",
//					this.ToString(), bytes_read, buf.BytesRead);
				if (buf.Full)
				{
					if (readingHeader)
					{
						if (Authenticated)
						{
							Decode(m_packet_header.Peek());
						}
//						System.Console.WriteLine("in {0} Finished reading header. Data {1}, {2}", this,
//							m_packet_header, BitConverter.ToInt32(m_packet_header.Peek(), 0));

						m_packet_data = new PacketBuffer(PacketDataSize);
						OnReadHeader(buf.Peek());
					}
					else
					{
//						System.Console.WriteLine("in {0} Finished reading data, size {1}", this, buf.BytesRead);
						byte[] packet_header = m_packet_header.Extract();
						byte[] packet_data = m_packet_data.Extract();
						
						byte[] buffer = new byte[packet_header.Length + packet_data.Length];
						packet_header.CopyTo(buffer, 0);
						packet_data.CopyTo(buffer, packet_header.Length);

						OnReadData(buffer);
					}

					registerRecieveCallback(!readingHeader);
				}
				else
				{
					registerRecieveCallback(readingHeader);
				}
			}
			catch (SocketException e)
			{
				OnException(e);
			}
		}
		#endregion

		#region Interface
		protected virtual void OnReadHeader(byte[] data)
		{

		}

		protected virtual void OnReadData(byte[] data)
		{
			if (RecievedDataHandler != null)
			{
				RecievedDataHandler(this, data);
			}
		}
		#endregion

		#endregion

		#region Send related

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
