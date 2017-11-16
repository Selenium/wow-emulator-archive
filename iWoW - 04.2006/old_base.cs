Index: Common/ClientBase.cs
===================================================================
--- Common/ClientBase.cs	(revision 24)
+++ Common/ClientBase.cs	(working copy)
@@ -10,15 +10,18 @@
 	/// </summary>
 	public class ClientBase
 	{
-		Socket m_socket;
+		protected Socket m_socket;
+		protected ServerBase m_server;
 		
 		protected Queue m_sendQueue = Queue.Synchronized(new Queue());
 		public byte[] Hash;
 		public byte[] key = { 0, 0, 0, 0 };
 		public bool Authenticated = false;
 		int m_currentSent = 0;
-		byte[] m_currentData = null;
-		protected byte[] m_header = null;
+
+		PacketBuffer m_packet_header;
+		PacketBuffer m_packet_data;
+
 		//public byte[] m_opcode = null;
 		protected IPEndPoint m_iep;
 
@@ -28,30 +31,21 @@
 			return split[split.Length-1] + "(" + m_iep.ToString() + ")";
 		}
 
-		public ClientBase(Socket sock, int headerSize)
+		public ClientBase(Socket sock, ServerBase server)
 		{
 			m_socket = sock;
+			m_server = server;
+
+			// Problematic?
 			m_socket.Blocking = false;
-			m_iep = (IPEndPoint)m_socket.RemoteEndPoint;
-			m_header = new byte[headerSize];
-			//m_opcode = new byte[4];
-			//Console.WriteLine(this + " connected.");
-		}
 
-		public ClientBase(Socket sock)
-		{
-			m_socket = sock;
-			m_socket.Blocking = false;
 			m_iep = (IPEndPoint)m_socket.RemoteEndPoint;
-			m_header = new byte[4];
-			//m_opcode = new byte[4];
-			//Console.WriteLine(this.GetType().ToString() + "(" + m_iep.ToString() + ") connected.");
-		}
 
-		public ClientBase()
-		{
+			m_packet_header = new PacketBuffer(PacketHeaderSize);
+			registerRecieveCallback(true);
 		}
 
+		#region Client state
 		public virtual IPEndPoint RemoteEndPoint
 		{
 			get
@@ -101,6 +95,7 @@
 			}
 			catch(Exception){}
 		}
+		#endregion
 
 		public virtual void OnException(Exception e)
 		{
@@ -110,20 +105,34 @@
 				Close(e.Message);
 		}
 
+		#region Packet size calculations
 		/// <summary>
-		/// Size of the packet data + header
+		/// Get the size of just the header. Overridding me is a good idea.
 		/// </summary>
-		public virtual int PacketSize
+		public virtual int PacketHeaderSize
 		{
 			get
 			{
-				int size = BitConverter.ToInt32(m_header, 0);
+				return 4;
+			}
+		}
+
+		/// <summary>
+		/// Size of the packet data + header. May require header to be read in already.
+		/// </summary>
+		public virtual int PacketDataSize
+		{
+			get
+			{
+				int size = BitConverter.ToInt32(m_packet_header.Peek(), 0);
 				if(size > 0xFFFF || size == 0)
 					throw new Exception("Corrupt packet(size=" + string.Format("0x{0:X}", size) + ").");
-				return size+m_header.Length;
+				return size;
 			}
 		}
-
+		#endregion
+		
+#if false
 		public virtual byte[] GetNextPacketData()
 		{
 			try
@@ -183,91 +192,175 @@
 				return null;
 			}
 		}
+#endif
 
-		#region SendRelated
-
-		public void Send(byte[] data, long size)
+		#region Encryption
+		public void Encode(byte[] data)
 		{
-			byte[] tmp = new byte[size];
-			Array.Copy(data, 0, tmp, 0, size);
-			EnqueueSendData(tmp);
+			for (int t = 0; t < 4; t++)
+			{
+				byte a = key[3];
+				a = (byte)(Hash[a] ^ data[t]);
+				byte d = key[2];
+				a += d;
+				data[t] = a;
+				key[2] = a;
+				a = key[3];
+				a++;
+				key[3] = (byte)(a % 0x28);
+			}
 		}
 
-		public void Send(byte[] data, int size)
+		public void Decode(byte[] data)
 		{
-			byte[] tmp = new byte[size];
-			Array.Copy(data, 0, tmp, 0, size);
-			EnqueueSendData(tmp);
+			for (int t = 0; t < 6; t++)
+			{
+				byte a = key[0];
+				key[0] = data[t];
+
+				byte b = data[t];
+				b = (byte)(b - a);
+
+				byte d = key[1];
+				a = Hash[d];
+				a = (byte)(a ^ b);
+				data[t] = a;
+
+				a = key[1];
+				a++;
+				key[1] = (byte)(a % 0x28);
+			}
 		}
 
-		public void Send(byte[] data)
+		public void Decode(byte[] data, int size)
 		{
-			EnqueueSendData((byte[])data.Clone());
+			for (int t = 0; t < size; t++)
+			{
+				byte a = key[0];
+				key[0] = data[t];
+
+				byte b = data[t];
+				b = (byte)(b - a);
+
+				byte d = key[1];
+				a = Hash[d];
+				a = (byte)(a ^ b);
+				data[t] = a;
+
+				a = key[1];
+				a++;
+				key[1] = (byte)(a % 0x28);
+			}
 		}
+		#endregion
 
-		public void Encode( byte[] data) 
+		#region Recieve related
+
+		#region Connection maintenance
+		/// <summary>
+		/// Register a data recieving callback function to read data from the server
+		/// </summary>
+		/// <param name="readHeader">Whether or not we're reading in the header (false == data segment)</param>
+		private void registerRecieveCallback(bool readHeader)
 		{
-			for(int t = 0;t < 4;t++ ) 
-			{             
-				byte a = key[ 3 ]; 
-				a = (byte)( Hash[ a ] ^ data[ t ] );
-				byte d = key[ 2 ]; 
-				a += d; 
-				data[ t ] = a; 
-				key[ 2 ] = a; 
-				a = key[ 3 ]; 
-				a++;             
-				key[ 3 ] = (byte)( a % 0x28 ); 
-			} 
+			PacketBuffer buf = readHeader ? m_packet_header : m_packet_data;
+
+			try
+			{
+				m_socket.BeginReceive(
+					buf.ReadBuffer.Array, buf.ReadBuffer.Offset, buf.ReadBuffer.Count,
+					SocketFlags.None, new AsyncCallback(recieveCallback), readHeader);
+			}
+			catch (Exception e)
+			{
+				OnException(e);
+			}
 		}
 
-		public void Decode(byte[] data) 
+		/// <summary>
+		/// callback for recieving connection data events.
+		/// </summary>
+		private void recieveCallback(IAsyncResult result)
 		{
-			for(int t = 0;t < 6; t++ ) 
+			try
 			{
-				byte a = key[ 0 ]; 
-				key[ 0 ] = data[ t ]; 
+				bool readingHeader = (bool)result.AsyncState;
 
-				byte b = data[ t ]; 
-				b = (byte)( b - a ); 
+				int bytes_read = m_socket.EndReceive(result);
 
-				byte d = key[ 1 ]; 
-				a = Hash[ d ]; 
-				a = (byte)( a ^ b ); 
-				data[ t ] = a; 
+				if (bytes_read == 0)
+				{
+					Close("Remote client closed connection");
+					return;
+				}
 
-				a = key[ 1 ]; 
-				a++; 
-				key[ 1 ] = (byte)( a % 0x28 );
-			} 
+				PacketBuffer buf = readingHeader ? m_packet_header : m_packet_data;
+				buf.BytesRead += bytes_read;
+
+				if (buf.Full)
+				{
+					if (readingHeader)
+					{
+						OnReadHeader(buf.Extract());
+					}
+					else
+					{
+						OnReadData(buf.Extract());
+					}
+
+					registerRecieveCallback(!readingHeader);
+				}
+				else
+				{
+					registerRecieveCallback(readingHeader);
+				}
+			}
+			catch (SocketException e)
+			{
+				OnException(e);
+			}
 		}
+		#endregion
 
-		public void Decode(byte[] data, int size) 
+		#region Interface
+		protected virtual void OnReadHeader(byte[] data)
 		{
-			for(int t = 0;t < size; t++ ) 
-			{
-				byte a = key[ 0 ]; 
-				key[ 0 ] = data[ t ]; 
 
-				byte b = data[ t ]; 
-				b = (byte)( b - a ); 
+		}
 
-				byte d = key[ 1 ]; 
-				a = Hash[ d ]; 
-				a = (byte)( a ^ b ); 
-				data[ t ] = a; 
+		protected virtual void OnReadData(byte[] data)
+		{
 
-				a = key[ 1 ]; 
-				a++; 
-				key[ 1 ] = (byte)( a % 0x28 );
-			} 
 		}
+		#endregion
 
+		#endregion
+
+		#region Send related
+
+		public void Send(byte[] data, long size)
+		{
+			byte[] tmp = new byte[size];
+			Array.Copy(data, 0, tmp, 0, size);
+			EnqueueSendData(tmp);
+		}
+
+		public void Send(byte[] data, int size)
+		{
+			byte[] tmp = new byte[size];
+			Array.Copy(data, 0, tmp, 0, size);
+			EnqueueSendData(tmp);
+		}
+
+		public void Send(byte[] data)
+		{
+			EnqueueSendData((byte[])data.Clone());
+		}
+
 		public virtual void EnqueueSendData(byte[] data)
 		{
 			try
 			{
-
 				if (Authenticated == true)
 				{
 					byte[] pkg = new byte[data.Length];
