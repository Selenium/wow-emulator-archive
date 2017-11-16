/*
 * Created by SharpDevelop.
 * User: BIOSTAT26
 * Date: 22/08/2005
 * Time: 13:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.IO;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using HelperTools;

namespace Server
{
	public delegate void RemoveClientDelegate( SockClient client );
	/// <summary>
	/// Description of SockClient.
	/// </summary>
	public class SockClient : IDisposable
	{
		RemoveClientDelegate removeFromTheServerList;
		public Socket clientSocket;
		//byte []dataToSend = new byte[ 8192 ];
		byte []dataReceive = new byte[ 65536 ];
		bool disposed = false;
	//	public Mutex sendMutex = new Mutex();
		
		MemoryStream ms = new MemoryStream();
		public bool Disposed
		{
			get { return disposed; }
		}

		
		public SockClient( Socket from, RemoveClientDelegate rftsl )
		{
			removeFromTheServerList = rftsl;
			clientSocket = from;
		}

		public void Start()
		{
			clientSocket.BeginReceive( dataReceive, 0, dataReceive.Length,0,
				new AsyncCallback( this.OnReceiveData ), this ); 		
		}
		
		public virtual void OnReceiveData( IAsyncResult ar ) 
		{
			try
			{
				if ( disposed )
					return;			
				int len = clientSocket.EndReceive( ar );		
				if ( len <= 0 )
				{//	VERY IMPORTANT, HERE IS THE CONNECTION CLOSE DETECTION					
					Dispose();
					return;
				}
			//	fromServer.totalReceive += len;
			//	ms.Write( dataReceive, 0, len );
				byte []toSend = ProcessDataReceived( dataReceive, len );
				if ( toSend != null )
				{
					clientSocket.BeginSend( toSend, 0, toSend.Length, 0, new AsyncCallback( this.OnSended ),this );
				}
				else
				{
					clientSocket.BeginReceive( dataReceive, 0, dataReceive.Length,0,
						new AsyncCallback( this.OnReceiveData ), this ); 
				}
			}
			catch(Exception )//e)
			{
			//	Debug.WriteLine(e.Message + e.StackTrace );
				Dispose();
			}
		}
		public virtual byte [] ProcessDataReceived( byte []data, int length )
		{
			return null;
		}
		
		public virtual void Send( byte []toSendBuff, int offset, int len )
		{
			try
			{
				if ( disposed )
					return;	
				byte []newToSend = new byte[ len ];
				
				Buffer.BlockCopy( toSendBuff, offset, newToSend, 0, len );
			//	Console.WriteLine("Send to client");
			//	HexViewer.View( newToSend, 0, len );
				//sendMutex.WaitOne();
				if ( disposed )
					return;		
				clientSocket.BeginSend( newToSend, 0, len, 0, new AsyncCallback( this.OnSended2 ),this );
				//Thread.Sleep( 100 );
			}
			catch(Exception)// e)
			{
			//	Debug.WriteLine(e.Message + e.StackTrace );
				Dispose();
			}
		}
		public virtual void Send( byte []toSendBuff, int len )
		{
			try
			{
				if ( disposed )
					return;	
				byte []newToSend = new byte[ len ];
				Buffer.BlockCopy( toSendBuff, 0, newToSend, 0, len );
				//sendMutex.WaitOne();
				

				clientSocket.BeginSend( newToSend, 0, len, 0, new AsyncCallback( this.OnSended2 ),this );
		//		Thread.Sleep( 50 );
			}
			catch(Exception )//e)
			{
				//Debug.WriteLine(e.Message + e.StackTrace );
				Dispose();
			}
		}
		public virtual void Send( char []toSendBuff, int len )
		{
			try
			{
				if ( disposed )
					return;	
				byte []newToSend = new byte[ len ];
				Buffer.BlockCopy( toSendBuff, 0, newToSend, 0, len );
				clientSocket.BeginSend( newToSend, 0, len, 0, new AsyncCallback( this.OnSended2 ),this );
			}
			catch(Exception )//e)
			{
				//Debug.WriteLine(e.Message + e.StackTrace );
				Dispose();
			}
		}
		public virtual void Send( string str )
		{
			try
			{
				int len = 0;
				if ( disposed )
					return;	
				byte []newToSend = new byte[ str.Length ];
				Converter.ToBytes( str, newToSend, ref len );
				clientSocket.BeginSend( newToSend, 0, len, 0, new AsyncCallback( this.OnSended2 ),this );
			}
			catch(Exception)// e)
			{
				//Debug.WriteLine(e.Message + e.StackTrace );
				Dispose();
			}
		}
		public void OnSended( IAsyncResult ar )
		{
			try
			{				
				if ( disposed )
					return;						
				int len = clientSocket.EndSend( ar );	
				//sendMutex.ReleaseMutex();
				clientSocket.BeginReceive( ( ar.AsyncState as SockClient ).dataReceive, 0, ( ar.AsyncState as SockClient ).dataReceive.Length,0,
					new AsyncCallback( this.OnReceiveData ), ar.AsyncState ); 
			}
			catch
			{
				Dispose();
			}
		}				
		
		public void OnSended2( IAsyncResult ar )
		{
			try
			{
				
				if ( disposed )
					return;		
				int len = clientSocket.EndSend( ar );	
			}
			catch(Exception)// e)
			{
				//Debug.WriteLine(e.Message + e.StackTrace );
				Dispose();
			}
		}	
		public void Dispose() 
		{
			//sendMutex.ReleaseMutex();
			if ( disposed )
				return;
			disposed = true;
			try
			{
				clientSocket.Shutdown( SocketShutdown.Both );
			} 
			catch 
			{}
			
			if ( clientSocket != null )
				clientSocket.Close();
			clientSocket = null;
			if ( removeFromTheServerList != null )
				removeFromTheServerList( this );
		}		
		public IPAddress IP
		{
			get 
			{ 
				try
				{
					if ( disposed )
						return null;
					return ( (IPEndPoint) clientSocket.RemoteEndPoint ).Address; 
				}
				catch
				{
					Dispose();
				}
				return null;
			}
		}
	}
}
