using System;
using System.Collections;
using System.Net;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using HelperTools;


namespace Server
{
	public delegate void TimerFunction();
	
	public abstract class ISocket : IDisposable
	{
		public Socket sock=null;
		protected string remote=null;
		protected long tickActive;

		class TimerData 
		{
			public int tickRun;
			public int tickCont;
			public TimerFunction func;
		};
		Hashtable timers=new Hashtable();
		ArrayList timerRemove=null;
		Hashtable timerAdd=null;

		public ISocket()
		{
			tickActive=Const.Tick;
		}

		public virtual bool NeedWrite()
		{ 
			return false; 
		}

		public abstract void RunRecv();
		public virtual void RunSend() 
		{
		}

		public virtual int Timeout()
		{
			return 60*1000;
		}

		public bool Connected()
		{
			return sock!=null;
		}

		public void SetActive()
		{
			tickActive=Const.Tick;
		}

		public void SetTimerFunction(string nm, int ms, TimerFunction func)
		{
			TimerData t=new TimerData();
			t.tickRun=Const.Tick+ms;
			t.tickCont=ms;
			t.func=func;
			if(timerAdd==null)timerAdd=new Hashtable();
			timerAdd[nm]=t;
		}

		public void SetTimeoutFunction(string nm, int ms, TimerFunction func)
		{
			TimerData t=new TimerData();
			t.tickRun=Const.Tick+ms;
			t.tickCont=0;
			t.func=func;
			if(timerAdd==null)timerAdd=new Hashtable();
			timerAdd[nm]=t;
		}

		public void DeleteTimer(string nm)
		{
			if(timerRemove==null)timerRemove=new ArrayList();
			timerRemove.Add(nm);
		}

		public bool HaveTimer(string nm)
		{
			if(timerRemove!=null && timerRemove.Contains(nm))return false;
			if(timerAdd!=null && timerAdd.Contains(nm))return true;
			return timers.Contains(nm);
		}

		public void CheckTimeout()
		{
			if(timerRemove!=null)
			{
				foreach(string n in timerRemove)
					timers.Remove(n);
				timerRemove=null;
			}

			IDictionaryEnumerator pe=timers.GetEnumerator();
			while(pe.MoveNext())
			{
				TimerData t=pe.Value as TimerData;
				if(t.tickRun <= Const.Tick)
				{
					t.func();
					if(timers==null)
						break;

					if(t.tickCont>0)
						t.tickRun+=t.tickCont;
					else
					{
						if(timerRemove==null)
							timerRemove=new ArrayList();
						timerRemove.Add(pe.Key);
					}
				}
			}
			if(timerRemove!=null && timers!=null)
			{
				foreach(string n in timerRemove)timers.Remove(n);
				timerRemove=null;
			}
			if(timerAdd!=null && timers!=null)
			{
				foreach(string n in timerAdd.Keys)
				{
					timers[n]=timerAdd[n];
				}
				timerAdd=null;
			}

			int tmout=Timeout();
			if(tmout==0)
				return;

			if(Const.Tick > tickActive+tmout)
			{
				Dispose();
				return;
			}
		}

		protected virtual void OnDisconnect()
		{
		}

		public void Dispose()
		{
			if(sock!=null)
			{
				OnDisconnect();


				timers.Clear();
				timers=null;

				NetWork.Remove(this);
				sock.Close();
				sock=null;
			}
		}


	};

	public class NetWork
	{
		static ArrayList sockets=new ArrayList();

		public static volatile bool Stop=false;
		public static void Run()
		{
			ArrayList cRead=new ArrayList();
			ArrayList cWrite=new ArrayList();

			while(!Stop)
			{
				if ( MainConsole.sw1 != null )
					MainConsole.sw1.Flush();
				int tick = Const.Tick+1000;
				while(!Stop)
				{
					Const.SyncTick();
					if(tick <= Const.Tick)
						break;
					cRead.Clear();
					cWrite.Clear();

					foreach(ISocket s in sockets)
					{
						if(s.NeedWrite())
						{
							cWrite.Add( s.sock );
						} 
						else 
						{
							cRead.Add( s.sock );
						}
					}
					if( cRead.Count > 0 )
					{
						if( cWrite.Count > 0 )
						{
							Socket.Select(cRead, cWrite, null, tick - Const.Tick);
						} 
						else 
						{
							Socket.Select(cRead, null, null, tick - Const.Tick);
						}
					} 
					else 
					{
						if(cWrite.Count > 0)
						{
							Socket.Select(null, cWrite, null, tick - Const.Tick);
						} 
						else 
						{
							Thread.Sleep(tick - Const.Tick);
							continue;
						}
					}
					Const.SyncTick();
					ArrayList nr=new ArrayList();
					ArrayList nw=new ArrayList();
					foreach(ISocket s in sockets)
					{
						if(cRead.Contains( s.sock ))
							nr.Add( s );
						if(cWrite.Contains( s.sock ))
							nw.Add( s );
					}

					foreach(ISocket s in nr)
					{
						s.SetActive();

						try 
						{
							s.RunRecv();
						}
						catch(SocketException)
						{
							s.Dispose();
						}
					}

					foreach(ISocket s in nw)
					{
						try 
						{
							s.RunSend();
						}
						catch(SocketException)
						{
							s.Dispose();
						}
					}
				}
			}
		}

		public static void Add(ISocket s)
		{
			if(s.sock==null)
				return;
			sockets.Add(s);
		}

		public static void Remove(ISocket s)
		{
			sockets.Remove(s);
		}
	}

	public abstract class SocketClient : ISocket
	{
		protected bool needEncode = false;
		ByteArrayBuilder result=null;
		byte []key = { 0, 0, 0, 0 };
		protected ByteArray inPacket=null;

		public SocketClient()
		{
		}

		public SocketClient(Socket sock)
		{
			this.sock=sock;
		}
		public virtual byte[]SS_Hash
		{
			get { return null; }
		}
		public byte []Key
		{
			set { key = value; }
		}
		public override bool NeedWrite()
		{
			return result!=null;
		}

		public IPAddress IP
		{
			get 
			{
				if ( sock == null || sock.RemoteEndPoint == null )
					return IPAddress.None;
				  return ( (IPEndPoint)sock.RemoteEndPoint ).Address; 
			}
		}
		public int Port
		{
			get 
			{
				if ( sock == null || sock.RemoteEndPoint == null )
					return 0;
				return ( (IPEndPoint)sock.RemoteEndPoint ).Port; 
			}
		}
		public override void RunRecv()
		{
			int sz;
			int cnt=0;

			while(cnt<10) 
			{
				if(sock==null)break;
				sz=sock.Available;
				if(sz==0)
				{
					if(cnt>0)break;
					sz=16388;
				}
				if(sz<0)
				{
					Dispose();
					break;
				}
				cnt++;

				byte[] b=new byte[sz];
				sz=sock.Receive(b);
				if(sz<=0)
				{
					Dispose();
					break;
				}
			//	HexViewer.View( b, 0, sz );
				Send( ProcessDataReceived(b, sz) );
			}
		}

		public Mutex mutex = new Mutex();
		public override void RunSend()
		{
			mutex.WaitOne();
			if(result==null)
				return;
			
			int sz=sock.Send(result);
			if( sz <= 0 )
			{
				Dispose();
				return;
			}
			
			if(result.Length > sz)
			{
			//	HexViewer.View( result, 0, sz );
				result.Remove(0, sz);
				return;
			}
			result=null;
			mutex.ReleaseMutex();
			return;
		}


		public void SetInput(byte[] data)
		{
			inPacket=new ByteArray(data, false);
		}

		public int InputLength
		{
			get
			{
				return inPacket.Length;
			}
		}


		public SocketClient Seek(int pos)
		{
			inPacket.Seek(pos);
			return this;
		}

		public SocketClient Get(out byte i)
		{
			i=inPacket[inPacket.pos]; inPacket.pos++;
			return this;
		}

		public SocketClient Get(out ushort i)
		{
			i=inPacket.GetWord();
			return this;
		}

		public SocketClient Get(out uint i)
		{
			i=inPacket.GetDWord();
			return this;
		}

		public SocketClient Get(out ulong i)
		{
			i=inPacket.GetULong();
			return this;
		}

		public SocketClient Get(out float i)
		{
			i=BitConverter.ToSingle( inPacket.GetArray(4), 0);
			return this;
		}

		public SocketClient Get(out string i)
		{
			i=inPacket.GetString();
			return this;
		}

		public byte[] GetArray(int sz)
		{
			return inPacket.GetArray(sz);
		}


		public abstract byte[] ProcessDataReceived(byte[] b, int len);



		public void Send( byte []buffer, bool noEncode )
		{
			if ( buffer == null )
				return;
			mutex.WaitOne();
			if ( result == null )
				result=new ByteArrayBuilder();
			if ( !noEncode )
				Encode( buffer );
			result.Add( buffer );
			mutex.ReleaseMutex();
		}
		
		public void Send( byte []buffer )
		{
			if ( buffer == null )
				return;
			mutex.WaitOne();
			if ( result == null )
				result=new ByteArrayBuilder();
			if ( needEncode )
				Encode( buffer );

			result.Add( buffer );
			mutex.ReleaseMutex();
		}

		public void Send( int opcode, byte []buffer )
		{
			if ( buffer == null )
				return;
			mutex.WaitOne();
			if ( result == null )
				result=new ByteArrayBuilder();
			buffer[ 1 ] = (byte)( ( buffer.Length - 2 ) & 0xff );
			buffer[ 0 ] = (byte)( ( ( buffer.Length - 2 ) >> 8 ) & 0xff );
			buffer[ 2 ] = (byte)( opcode & 0xff );
			buffer[ 3 ] = (byte)( ( opcode >> 8 ) & 0xff );

			if ( needEncode )
				Encode( buffer );
			result.Add( buffer );
			mutex.ReleaseMutex();
		}
		public void Send( OpCodes opcode, byte []buffer )
		{
			if ( buffer == null )
				return;
			mutex.WaitOne();
			if ( result == null )
				result=new ByteArrayBuilder();
			buffer[ 1 ] = (byte)( ( buffer.Length - 2 ) & 0xff );
			buffer[ 0 ] = (byte)( ( ( buffer.Length - 2 ) >> 8 ) & 0xff );
			buffer[ 2 ] = (byte)( (int)opcode & 0xff );
			buffer[ 3 ] = (byte)( ( (int)opcode >> 8 ) & 0xff );
			if ( needEncode )
				Encode( buffer );
			result.Add( buffer );
			mutex.ReleaseMutex();
		}
		public void Send( int opcode, byte []buffer, int len )
		{
			if ( buffer == null )
				return;
			mutex.WaitOne();
			if ( result == null )
				result=new ByteArrayBuilder();
			byte []nb = null;
			if ( len == buffer.Length )
				nb = buffer;
			else
			{
				nb = new byte[ len ];
				Buffer.BlockCopy( buffer, 0, nb, 0, len );
			}
			len -=2;
			nb[ 1 ] = (byte)( len & 0xff );
			nb[ 0 ] = (byte)( ( len >> 8 ) & 0xff );
			nb[ 2 ] = (byte)( opcode & 0xff );
			nb[ 3 ] = (byte)( ( opcode >> 8 ) & 0xff );
			if ( needEncode )
				Encode( nb );		
			result.Add( nb );
			mutex.ReleaseMutex();
		}
		public void Send( OpCodes opcode, byte []buffer, int len )
		{
			Send( (int)opcode, buffer, len );
		}

	/*	public void PopulateMessageList( byte []data, int offset, bool sens )
		{
			string str = "";
			if ( sens )
				str += "<--" + (Server.OpCodes)BitConverter.ToInt16( data, offset + 2 ) + " ";
			else
				str += "-->" + (Server.OpCodes)BitConverter.ToInt16( data, offset + 2 ) + " ";
			int len = data[ offset + 1 ] + ( data[ offset ] << 8 );
			str += len.ToString( "X4" ) + " ";
			str += BitConverter.ToInt16( data, offset + 2 ).ToString( "X4" ) + " ";
			for(int t = 0; ( t + offset ) < data.Length && t < 36 && t < len + 2;t++ )
				str += data[ t + offset ].ToString( "X2" ) + " ";
			Form1.addMessage( str );
		}*/
		public void Decode( byte []data, int offset, int length )
		{
			//	byte []res = new byte[ length ];
			
			byte []K = SS_Hash;
			for(int t = 0;t < 6;t++)//length;t++ )
			{				
			//	if ( t == 6 )
			//		break;
				byte a = key[ 0 ];
				key[ 0 ] = data[ offset + t ];
				byte b = data[ offset + t ];
				
				b = (byte)( b - a );
				byte d = key[ 1 ];
				a = K[ d ];
				a = (byte)( a ^ b );
				data[ t + offset ] = a;
				//Console.Write( "{0} ", a.ToString( "X2" ) );
				a = key[ 1 ];
				a++;
				key[ 1 ] = (byte)( a % 0x28 );					
			}
		//	PopulateMessageList( data, offset, true );
		}
		
		public  void Decode( byte []data, int length )
		{
			byte []K = SS_Hash;
			for(int t = 0;t < 6;t++)//length;t++ )
			{				
			//	if ( t == 6 )
			//		break;
				byte a = key[ 0 ];
				key[ 0 ] = data[ t ];
				byte b = data[ t ];
				
				b = (byte)( b - a );
				byte d = key[ 1 ];
				a = K[ d ];
				a = (byte)( a ^ b );
				data[ t ] = a;
				//Console.Write( "{0} ", a.ToString( "X2" ) );
				a = key[ 1 ];
				a++;
				key[ 1 ] = (byte)( a % 0x28 );					
			}
		//	PopulateMessageList( data, 0, true );
		}
		public void DecodeSansAff( byte []data, int length )
		{
			//	byte []res = new byte[ length ];
			
			byte []K = SS_Hash;
			for(int t = 0;t < 6;t++)//length;t++ )
			{				
			//	if ( t == 6 )
			//		break;
				byte a = key[ 0 ];
				key[ 0 ] = data[ t ];
				byte b = data[ t ];
				
				b = (byte)( b - a );
				byte d = key[ 1 ];
				a = K[ d ];
				a = (byte)( a ^ b );
				data[ t ] = a;
				//Console.Write( "{0} ", a.ToString( "X2" ) );
				a = key[ 1 ];
				a++;
				key[ 1 ] = (byte)( a % 0x28 );					
			}
		//	PopulateMessageList( data, 0, true );
		}
		public void Encode( byte []data )
		{			
			if ( sock == null )
				return;
			//////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////			///
		/*
			if ( ( data[ 2 ] == 0x3e && data[ 3 ] == 0x01 ) || ( data[ 2 ] == 0xdd && data[ 3 ] == 0x00 ) 
				|| ( data[ 2 ] == 0x4A && data[ 3 ] == 0x01 ) )
			if ( data[ 2 ] != 0x4A )
			{
			}
			else*/
			if ( File.Exists( "debug.txt"  ) )
			{
				Console.Write( "{0}:{1}:{2} {3} --> ", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, this.IP.ToString() );
				for( int t = 0;t < data.Length;t++ )
					Console.Write( "{0} ", data[ t ].ToString( "X2" ) );

				Console.WriteLine("");
			}	
/*
			PopulateMessageList( data, 0, false );
*/
			byte []K = SS_Hash;
			for(int t = 0;t < 4;t++ )
			{				
				byte a = key[ 3 ];
				a = (byte)( K[ a ] ^ data[ t ] );				
				byte d = key[ 2 ];
				a += d;
				data[ t ] = a;
				//Console.Write( "{0} ", a.ToString( "X2" ) );
				key[ 2 ] = a;
				a = key[ 3 ];
				a++;				
				key[ 3 ] = (byte)( a % 0x28 );
			}
			//Console.WriteLine("");
		}


	}


	public enum ServerGroupMessageType 
	{
		GameServerHeartBeat,
		UserQuery,
		UserReply,
		UserLogin,
		UserSetChar,
	};

	public delegate void ServerGroupHandler(ServerGroupMessageType type, Hashtable msg);

	public class ServerGroup : SocketClient
	{
		IPEndPoint target;
		Hashtable  handler=new Hashtable();
		ArrayList  sendids=new ArrayList();

		uint GetID()
		{
			return (uint)Environment.TickCount;
		}

		private ServerGroup(ushort group)
		{
			remote="ServerGroup";
			sock=new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			sock.Bind(new IPEndPoint(IPAddress.Any, group));
			sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, (int)1);

			target=new IPEndPoint(IPAddress.Broadcast, group);

		}

		void DoRecv(byte[] b, int sz)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			MemoryStream ms=new MemoryStream( b, 5, sz-5, false );

			ServerGroupMessageType type=(ServerGroupMessageType)b[0];
			if(!handler.Contains(type))return;

			try 
			{
				Hashtable msg=formatter.Deserialize(ms) as Hashtable;
				ServerGroupHandler h=(ServerGroupHandler)handler[type];

				h(type, msg);
			}
			catch
			{
			}
		}

		public override byte[] ProcessDataReceived(byte[] b, int sz) 
		{
			uint id=BitConverter.ToUInt32(b, 1);
			if(sendids.Contains(id))return null;

			DoRecv(b, sz);
			return null;
		}

		public override int Timeout()
		{
			return 0;
		}

		static ServerGroup group=null;
		void iSend(ServerGroupMessageType type, Hashtable msg)
		{
			ByteArrayBuilder b=new ByteArrayBuilder(false);
			b.Add( (byte)type );

			uint id=GetID();
			sendids.Add(id);
			if(sendids.Count>100)sendids.Remove(0);
			b.Add( id );

			MemoryStream ms=new MemoryStream();
			
			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Serialize(ms, msg);
			b.Add( ms.ToArray() );
			byte[] bs=b;
			
			sock.SendTo(bs, target);

			DoRecv(bs, bs.Length);
		}
		
		public static void Send(ServerGroupMessageType type, Hashtable msg)
		{
			if(group==null)return;
			group.iSend(type, msg);
		}

		public static void SetHandle(ServerGroupMessageType type, ServerGroupHandler handler)
		{
			if(group==null)return;
			if(handler==null)
				group.handler.Remove(type);
			else
				group.handler[ type ]=handler;
		}

		public static void Start(ushort gid)
		{
			if(group!=null)return;
			group=new ServerGroup(gid);
			NetWork.Add(group);
		}



	};


}
