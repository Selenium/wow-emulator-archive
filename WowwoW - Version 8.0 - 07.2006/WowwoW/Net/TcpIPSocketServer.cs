using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections;
using System.Threading;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Reflection.Emit;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Server;
using HelperTools;

namespace Server
{





	public class ClientConnectionPool 
	{
		// Creates a synchronized wrapper around the Queue.
		private  Queue SyncdQ = Queue.Synchronized( new Queue() );
      
		public  void Enqueue(ClientHandler client) 
		{
			SyncdQ.Enqueue(client) ;
		}
        
		public  ClientHandler Dequeue() 
		{
			return (ClientHandler) ( SyncdQ.Dequeue() ) ;
		}
        
		public  int Count 
		{
			get { return SyncdQ.Count ; }
		}

		public object SyncRoot 
		{
			get { return SyncdQ.SyncRoot ; }
		}
        
	} // class ClientConnectionPool
        
public class ClientService 
{        
    int numOfThread;
    
    private ClientConnectionPool ConnectionPool  ;
    private bool ContinueProcess = false ;
    private Thread [] ThreadTask;
      
	public ClientService(ClientConnectionPool ConnectionPool, int nThread ) 
	{
		numOfThread = nThread;
		ThreadTask = new Thread[ nThread ];
		this.ConnectionPool = ConnectionPool ;
	}      

	public void Start() 
	{
		ContinueProcess = true ;
		// Start threads to handle Client Task
		for ( int i = 0 ; i < ThreadTask.Length ; i++) 
		{
			ThreadTask[i] = new Thread( new ThreadStart(this.Process) );
			ThreadTask[i].Start() ;
		}
	}
        
	private  void Process()  
	{
		while ( ContinueProcess ) 
		{	
			ClientHandler client  = null ;
			lock( ConnectionPool.SyncRoot ) 
			{
				if  ( ConnectionPool.Count > 0 )
					client = ConnectionPool.Dequeue() ;	        
			}		                         
			if ( client != null ) 
			{
				client.Process() ; // Provoke client
				// if client still connect, schedulor later processingle it 
				if ( client.Alive ) 
					ConnectionPool.Enqueue( client ) ;
				/*else
					Console.WriteLine("dequeue client#{0}",client.m_Num );*/
			}
                    
			Thread.Sleep(50) ;
		}       
		//Console.WriteLine( "Client service ended" );
	}
        
	public  void Stop() 
	{
		ContinueProcess = false ;        
		for ( int i = 0 ; i < ThreadTask.Length ; i++) 
		{
			if ( ThreadTask[i] != null &&  ThreadTask[i].IsAlive )  
				ThreadTask[i].Join();
		}
                        
		// Close all client connections
		while ( ConnectionPool.Count > 0 ) 
		{
			ClientHandler client = ConnectionPool.Dequeue() ;
			client.Close() ; 
		//	Console.WriteLine("Client connection is closed!") ;
		}
	}
        
} // class ClientService

public class SynchronousSocketListener 
{       
	private  int  portNum = 10116 ;
	int numOfThread;
	string handler;
	bool stop = false;
	public ClientService ClientTask;
	
	public SynchronousSocketListener( int nThread, int port, string handle )
	{
		handler = handle;
		numOfThread = nThread;
		portNum = port;
	}
	public void Stop()
	{
		stop = true;
		ClientTask.Stop();
	}
	public void StartListening() 
	{		
		
	    
		// Client Connections Pool
		ClientConnectionPool ConnectionPool = new ClientConnectionPool()  ;          
	    
		// Client Task to handle client requests
		ClientTask = new ClientService( ConnectionPool, numOfThread ) ;
	    
		ClientTask.Start() ;


		TcpListener listener = null;
		listener = new TcpListener( IPAddress.Any, portNum );
		try 
		{
			listener.Start();
	    
			int ClientNbr = 0 ;

			// Start listening for connections.
			Console.WriteLine("Port {0} waiting for a connection...", portNum );
			while ( !stop ) 
			{
		//		Thread.Sleep(50);
				//System.Net.Sockets.Socket socket = listener.AcceptSocket();
	//			TcpClient tcpHandler = listener.AcceptTcpClient();
				//TcpClientBis t2 = (TcpClientBis)Convert.ChangeType( tcpHandler, typeof(TcpClientBis));
	            TcpClientBis tcpHandler = new TcpClientBis( listener.AcceptSocket() );// socket ); 
				
				if (  tcpHandler != null)  
				{
					
					if ( tcpHandler.ReceiveBufferSize == 0 )
					{
						Console.WriteLine( "Socket error !" );
						tcpHandler.Close();
					}
	//				Console.WriteLine("Client#{0} accepted on port {1}", ++ClientNbr, portNum ) ;
	                ++ClientNbr;
					// An incoming connection needs to be processed.
					ConnectionPool.Enqueue( new ClientHandler( tcpHandler, ClientNbr-1, handler  ) ) ;
	                        
					// --TestingCycle ;
				}
				else 
					break;                
			}
			listener.Stop();
	        
			// Stop client requests handling
			ClientTask.Stop() ;
		}
		catch (Exception e) 
		{
			Console.WriteLine(e.ToString());
		}		
	}
}

	public class TcpClientBis : TcpClient
	{
		public TcpClientBis( System.Net.Sockets.Socket socket )
		{
			this.Client = socket;
			this.NoDelay = true;
			this.ReceiveTimeout = 5000;
			this.SendTimeout = 5000;
			this.ReceiveBufferSize = 32768;
			this.SendBufferSize = 32768;
		}

		public IPAddress IP
		{
			get { return ( (IPEndPoint) Client.RemoteEndPoint ).Address; }
		}
		public int Port
		{
			get { return ( (IPEndPoint) Client.RemoteEndPoint ).Port; }
		}
		public IPAddress SourceIP
		{
			get { return ( (IPEndPoint) Client.LocalEndPoint ).Address; }
		}
	}

	public class ClientHandler 
	{
		public int m_State;
		private TcpClientBis ClientSocket ;
		private NetworkStream networkStream ;
		bool ContinueProcess = false ;
		private byte[] bytes; 		// Data buffer for incoming data.
		int length = 0;
		private StringBuilder sb =  new StringBuilder(); // Received data string.
		public int m_Num;
		TcpIPSocketClient theClient;
		string handler;

		public ClientHandler ( TcpClientBis _ClientSocket, int num, string handle ) 
		{
			handler = handle;
			m_Num = num;			
			ClientSocket = _ClientSocket ;
			//ClientSocket.ReceiveTimeout = 5000 ; // 100 miliseconds
			networkStream = ClientSocket.GetStream();
			bytes = new byte[ ClientSocket.ReceiveBufferSize ];
			ContinueProcess = true ;
			m_State = 0;
			//System.Net.Sockets.Socket ip = ClientSocket.Sock;
			if ( handle == "PlayerHandler" )
			{
				this.Send( new byte[] { 0x0, 0x06, 0xec, 0x01, 0x71, 0x2c, 0x7e, 0x88 } );
			}
		}

		public IPAddress IP
		{
			get { return ClientSocket.IP; }
		}
		public int Port
		{
			get { return ClientSocket.Port; }
		}
		public IPAddress SourceIP
		{
			get { return ClientSocket.SourceIP; }
		}
		public  void Process() 
		{
			try 
			{								
				if ( networkStream.DataAvailable )
				{
//					Console.WriteLine("Client #{0} processing", m_Num );
					int len = networkStream.Read( bytes, 0, (int) bytes.Length );
					if ( len > 0 ) 
					{
						length+=len;
					//	Console.Write( "Data {0}, ", len );
					//	HexViewer.View( bytes, 0, len );
					//	Console.WriteLine("");		
						ProcessDataReceived();
					}
				}
			//	else
			//		ProcessDataReceived();
			}                        
			catch  ( IOException ) 
			{ 
				// All the data has arrived; put it in response.
				ProcessDataReceived();
				networkStream.Flush();
			}	  
			catch  ( SocketException ) 
			{
				networkStream.Close() ;
				ClientSocket.Close();			
				ContinueProcess = false ; 				
				Console.WriteLine( "Conection is broken!");
			}             

	
		}  // Process()  
		public static ConstructorInfo FindConstructor( string cls )
		{
			char []sep = {'.'};
			string []classname = cls.Split( sep );
			Module[] moduleArray;            
			moduleArray = Assembly.GetAssembly( typeof( ClientHandler ) ).GetModules( false );   
			Module myModule = moduleArray[ 0 ];
			Type[] tArray;
			tArray = myModule.FindTypes(Module.FilterTypeName, classname[ classname.Length - 1 ] );
				
			ConstructorInfo []m = tArray[ 0 ].GetConstructors();//GetMethods( BindingFlags.Public|BindingFlags.Instance|BindingFlags.DeclaredOnly
			
			foreach( ConstructorInfo method in m )
			{
				ParameterInfo []param = method.GetParameters();
				if ( param.Length == 0 )
					return method;
			}
			return null;
		}        
		private void ProcessDataReceived() 
		{
			if ( theClient == null )//&& data.StartsWith( "new " ) )
			{
				ConstructorInfo ctr = FindConstructor( handler );
				theClient = (TcpIPSocketClient)ctr.Invoke( null );
				theClient.theClientHandler = this;
			}

			byte []ret = theClient.ProcessDataReceived( bytes, this, length );
			if ( ret != null )
				Send( ret );		
			length = 0;
		}
		public void Close() 
		{
			Console.WriteLine( "Closing connection" );
			networkStream.Close() ;
			ClientSocket.Close();        
		}
		public void Send( string str )
		{
			try
			{
				if ( str.Length <= 0 )
					return;
				StringBuilder response = new StringBuilder();
				response.Append( str );
				byte[] sendBytes = Encoding.ASCII.GetBytes( response.ToString() );
			//	HexViewer.View( sendBytes, 0, sendBytes.Length );
				networkStream.Write( sendBytes, 0, sendBytes.Length );    
			}
			catch(Exception)
			{
			}
		}
		public void Send( byte [] str )
		{
			try
			{
				networkStream.Write( str, 0, str.Length );
			}
			catch( Exception )
			{
			//	Console.WriteLine( "Connection broken with {0}", this.IP.Address.ToString() );
			}
		}
		public void Send( byte [] str, int length )
		{
			try
			{
				networkStream.Write( str, 0, length );
			}
			catch( Exception )
			{
				//Console.WriteLine( "Connection broken with {0}", this.IP.Address.ToString() );
			}
		}

		public NetworkStream NetStream
		{
			get { return networkStream; }
		}        
		public  bool Alive 
		{
			get { return  ContinueProcess ;	}
		}     
	} // class ClientHandler 
}
