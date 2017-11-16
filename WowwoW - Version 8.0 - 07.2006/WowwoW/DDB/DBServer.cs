using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using Server;

namespace DDB
{
	public delegate void RemoveClientDelegate( SockClient client );
	/// <summary>
	/// Summary description for DBServer.
	/// </summary>
	public class DBServer : IDisposable
	{
		string ip;
		int port;
		Socket listenSocket;
		public static ArrayList clients = new ArrayList();
		IPAddress address;
		AddressFamily addressFamily;
		public int totalSend = 0;
		public int totalReceive = 0;		
		
		public DBServer( string i, int pt )
		{			
			ip = i;
			port = pt;		
			IPHostEntry lipa = Dns.Resolve( i );
			IPEndPoint lep = new IPEndPoint( lipa.AddressList[ 0 ], port );
			addressFamily = lep.Address.AddressFamily;
			address = lep.Address;
			Start();
		}
		public bool Start()
		{
			try 
			{
				listenSocket = new Socket( addressFamily, SocketType.Stream, ProtocolType.Tcp );
				listenSocket.Bind( new IPEndPoint( IPAddress.Any, port ) );
				Console.WriteLine("Listen on port {0}, IP {1}", port, address.ToString() );
				listenSocket.Listen( 1000 );
				listenSocket.BeginAccept( new AsyncCallback( this.OnAccept ), listenSocket );				
			}
			catch(Exception e )
			{
				Console.WriteLine("Failled to list on port {0}\n{1}", port, e.Message );
				listenSocket = null;
				return false;
			}		
			return true;
		}
		public virtual void OnAccept( IAsyncResult ar ) 
		{
			try 
			{	
				Socket newSocket = listenSocket.EndAccept( ar );
				
				if ( newSocket != null ) 
				{
					RemoteSaver newClient = new RemoteSaver( newSocket, new Server.RemoveClientDelegate( this.RemoveClient ) );
					clients.Add( newClient );
					newClient.Start();
				}
			} 
			catch {}
			try 
			{
				listenSocket.BeginAccept( new AsyncCallback( this.OnAccept ), listenSocket );
			} 
			catch
			{
				Dispose();
			}
		}		
		public void RemoveClient( SockClient client )
		{
//			( client as DBClientHandler ).Logout();
			clients.Remove( client );			
		}
		
		//	public abstract void OnAccept( IAsyncResult ar );
		public void Dispose() 
		{			
			while ( clients.Count > 0) 
			{
				(( SockClient )clients[0]).Dispose();
			}
			try 
			{
				listenSocket.Shutdown(SocketShutdown.Both);
			} 
			catch
			{}
			if ( listenSocket != null )
				listenSocket.Close();			
		}		
	}
}
