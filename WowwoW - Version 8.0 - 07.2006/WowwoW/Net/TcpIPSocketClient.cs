using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.IO;


namespace Server
{


	public class TcpIPSocketClient  : TcpClient
	{
        
		private int  portNum = 10116 ;        
		string m_Ip;
		bool m_Ready;
		NetworkStream networkStream;
		Thread m_Thread;
		//	protected TcpClient tcpClient;
		public ClientHandler theClientHandler;
	
		public TcpIPSocketClient()
		{			
			
		}
		
		public NetworkStream NetStream
		{
			get { return networkStream; }
		}

		public TcpIPSocketClient( string ip, int port )
		{
			//tcpClient = new TcpClient();
			portNum  = port;
			m_Ready = false;
			m_Ip = ip;

			ThreadStart myThreadDelegate = new ThreadStart( ConnectThread );
			m_Thread = new Thread(myThreadDelegate);
			m_Thread.Start();
		}

		public void CloseSocket()
		{
			m_Thread.Abort();
			networkStream.Close();
			/*tcpClient.*/Close();
			//	Console.WriteLine("Closing connection...");
		}

		public virtual byte[]SS_Hash
		{
			get { return null; }
		}

		public virtual byte [] ProcessDataReceived( byte [] data, ClientHandler ch, int len )
		{
			return null;	
		}

		public virtual string ProcessObjectReceived( MemoryStream stream, string classname )
		{
			return "";	
		}
	
		public void ConnectThread()
		{
			try
			{
				Connect( m_Ip, portNum);
				networkStream = GetStream();
		
				if (networkStream.CanWrite && networkStream.CanRead)
				{
					m_Ready = true;
					String DataToSend = "" ;

					while ( DataToSend != "quit" ) 
					{
						if ( networkStream.DataAvailable )
						{
							// Reads the NetworkStream into a byte buffer.
							byte[] bytes = new byte[ ReceiveBufferSize ];
							int len = (int)networkStream.ReadByte();//(bytes, 0, 1 );//(int) tcpClient.ReceiveBufferSize);
							// Returns the data received from the host to the console.
							int BytesRead = networkStream.Read(bytes, 0, len );//(int) tcpClient.ReceiveBufferSize);
							//Console.WriteLine( "c[ {0} {1} {2}]", len, bytes[ 0 ].ToString(), bytes[ 1 ].ToString() );
							string classname = Encoding.ASCII.GetString(bytes, 0 , BytesRead);
							if ( classname == "(string)" || !classname.StartsWith( "(" ) )
							{
								BytesRead = networkStream.Read(bytes, 0, (int)ReceiveBufferSize - ( len + 1 ) );
								string returndata = Encoding.ASCII.GetString(bytes, 0 , BytesRead);
								if ( returndata.EndsWith( "$Fin$" ) )
									returndata = returndata.Remove( returndata.Length - 5, 5 );
								OnReceived( returndata );
							}
							else
							{								
								OnReceivedData( networkStream, classname.Substring( 1, classname.Length - 2 ), (int) ReceiveBufferSize - ( len + 1 ) );
								// Il reste toujours le marqueur de fin si tout c'est bien passe
								//								BytesRead = networkStream.Read(bytes, 0, 5 );
								//								if ( BytesRead != 5 || bytes[ 0 ] != (byte)'$' || bytes[ 1 ] != (byte)'F' || bytes[ 2 ] != (byte)'i' || bytes[ 3 ] != (byte)'n' || bytes[ 4 ] != (byte)'$' )
								//{
								//									Console.WriteLine( "Protocole error !!! {0}", BytesRead );
								//for(int t= 0;t < BytesRead;t++ )
								//Console.Write( "{0},", bytes[ t ] );
								//}
							}
						}
						else
							Thread.Sleep(50);

					}
					networkStream.Close();
					Close();
				}
				else if (!networkStream.CanRead)
				{
					//			Console.WriteLine("You can not write data to this stream");
					Close();
				}
				else if (!networkStream.CanWrite)
				{             
					//			Console.WriteLine("You can not read data from this stream");
					Close();
				}
			}
			catch(ThreadAbortException )
			{
				Thread.ResetAbort();
			}
			catch (SocketException)
			{
				//		Console.WriteLine("Cant connect to " + m_Ip + " !");
				OnLinkBroken();
			}
			catch (System.IO.IOException) 
			{                                       
				//	Console.WriteLine("Cant connect to " + m_Ip + " !");
				OnLinkBroken();
			}
			catch (Exception ) 
			{
				//	Console.WriteLine(e.ToString());
				OnLinkBroken();
			}
		}
		public virtual void OnReceived( string rec )
		{
		}
		public virtual void OnReceivedData( NetworkStream ns, string classname, int len )
		{
		}
		public virtual void OnLinkBroken()
		{
		}
		public void Send( string rec )
		{
			try
			{
				if ( rec.Length == 0 )
					return;
				while( !m_Ready ) Thread.Sleep(100);	
			
				string classname = "(string)";
				networkStream.WriteByte( (byte)classname.Length );
				char []pc = classname.ToCharArray();
				byte []bs = new byte[ pc.Length ];
				int t = 0;
				foreach( char c in pc )
					bs[ t++ ] = (byte)c;
				networkStream.Write( bs, 0, bs.Length );
				rec += "$Fin$";
				Byte[] sendBytes = Encoding.ASCII.GetBytes( rec );
				networkStream.Write( sendBytes, 0, sendBytes.Length);
			
			}
			catch (SocketException)
			{
				//	Console.WriteLine("Connection lost with " + m_Ip + " !");
				//tcpClient.Close();
				OnLinkBroken();
			}
			catch (System.IO.IOException) 
			{                                       
				//	Console.WriteLine("Connection lost with " + m_Ip + " !");
				//tcpClient.Close();
				OnLinkBroken();
			}
			catch (Exception ) 
			{
				//	Console.WriteLine("Connection lost with " + m_Ip + " !");
				//networkStream.Close();
			
				//tcpClient.Close();			
				//Console.WriteLine(e.ToString());
				OnLinkBroken();
			}
		}
	
	} 
}
