using System;
using System.Collections;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;

namespace DDB
{
	/// <summary>
	/// Summary description for DBConnectoid.
	/// </summary>
	public class DBConnectoid
	{
		byte []dataToSend = new byte[ 8196 ];
		byte []dataReceive = new byte[ 8196 ];
		Socket destinationSocket;
		bool disposed = false;

		public DBConnectoid()
		{
		}
		public void ConnectTo( string ip, int port )
		{
			IPHostEntry lipa = Dns.Resolve( ip );
			IPEndPoint lep = new IPEndPoint( lipa.AddressList[ 0 ], port );
			destinationSocket = new Socket( lep.Address.AddressFamily,
				SocketType.Stream,
				ProtocolType.Tcp );
			try
			{									
				destinationSocket.BeginConnect(lep, new AsyncCallback( this.OnConnected ), this );					
			}
			catch (Exception e)
			{
				Dispose();
			}
		}
		public virtual void OnConnected( IAsyncResult ar ) 
		{
			try 
			{
				destinationSocket.EndConnect( ar );					
			} 
			catch 
			{
				Dispose();
			}
		}
		#region GET
		public virtual void OnReceiveGetDataFromDBServer( IAsyncResult ar ) 
		{
			try
			{				
				if ( disposed )
				{
					receiveDone = true;
					return;
				}
				int len = destinationSocket.EndReceive( ar );
				receiveDone = true;
			}
			catch(Exception e)
			{
				Dispose();
			}
		}
		bool sendDone = false;
		bool receiveDone = false;
		
		public byte [] SendGet( byte []buffer )
		{
			try
			{
				int len = buffer.Length;
				destinationSocket.BeginSend( buffer, 0, len, 0,new AsyncCallback( this.OnSendToServerGetDone ),this );
				receiveDone = sendDone = false;
				DateTime timeout = DateTime.Now;
				while( !sendDone )
				{
					Thread.Sleep( 20 );
					TimeSpan ts = DateTime.Now.Subtract( timeout );
					if ( ts.TotalSeconds > 2 )
						return null;
				}
				while( !receiveDone )
				{
					Thread.Sleep( 20 );
					TimeSpan ts = DateTime.Now.Subtract( timeout );
					if ( ts.TotalSeconds > 2 )
						return null;
				}
				byte []ret = new byte[ len - ( 2 + 2 + 8 + 1 ) ];
				Buffer.BlockCopy( dataReceive, ( 2 + 2 + 8 + 1 ), ret, 0, ret.Length );
				return ret;
			}
			catch( Exception )
			{
				Console.WriteLine("Unable to connect to realm server !" );
			}
			return null;
		}
		public void OnSendToServerGetDone( IAsyncResult ar )
		{
			try
			{
				if ( disposed )
				{
					sendDone = true;
					return;			
				}
				int len = destinationSocket.EndSend( ar );
				sendDone = true;
				destinationSocket.BeginReceive( dataReceive, 0, dataReceive.Length,0,
					new AsyncCallback( this.OnReceiveGetDataFromDBServer ), this ); 		
			}
			catch(Exception e)
			{
				Console.WriteLine(e.ToString());
				Dispose();
			}
		}	
		#endregion	
		
		public void OnSendToServerDone( IAsyncResult ar )
		{
			try
			{
				if ( disposed )
				{
					sendDone = true;
					return;			
				}
				int len = destinationSocket.EndSend( ar );	

				sendDone = true;
			}
			catch(Exception e)
			{
				Console.WriteLine(e.ToString());
				Dispose();
			}
		}				
		
		public void Dispose() 
		{
			if ( disposed )
				return;
			disposed = true;
			try 
			{
				destinationSocket.Shutdown( SocketShutdown.Both );
			} 
			catch 
			{}
			
			if ( destinationSocket != null )
				destinationSocket.Close();			
			destinationSocket = null;
		}		
	}
}
