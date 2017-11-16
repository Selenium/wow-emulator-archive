using System;
using System.Collections;
using System.Net;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace eWoW
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
				foreach(string n in timerRemove)timers.Remove(n);
				timerRemove=null;
			}

			IDictionaryEnumerator pe=timers.GetEnumerator();
			while(pe.MoveNext())
			{
				TimerData t=pe.Value as TimerData;
				if(t.tickRun <= Const.Tick)
				{
					t.func();
					if(timers==null)break;

					if(t.tickCont>0)
						t.tickRun+=t.tickCont;
					else
					{
						if(timerRemove==null)timerRemove=new ArrayList();
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
			if(tmout==0)return;

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
				Log("Disconnect");

				timers.Clear();
				timers=null;

				NetWork.Remove(this);
				sock.Close();
				sock=null;
			}
		}


		public virtual void Log(string fmt, params object[] obs)
		{
			if(remote==null)remote=sock.RemoteEndPoint.ToString();
			Const.Log(remote, fmt, obs);
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
				int tick=Const.Tick+100;
				while(!Stop)
				{
					Const.SyncTick();
					if(tick <= Const.Tick)break;
					cRead.Clear();
					cWrite.Clear();

					foreach(ISocket s in sockets)
					{
						if(s.NeedWrite())
						{
							cWrite.Add(s.sock);
						} 
						else 
						{
							cRead.Add(s.sock);
						}
					}
					if(cRead.Count>0)
					{
						if(cWrite.Count>0)
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
						if(cWrite.Count>0)
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
						if(cRead.Contains( s.sock ))nr.Add( s );
						if(cWrite.Contains( s.sock ))nw.Add( s );
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

				ArrayList n=sockets.Clone() as ArrayList;
				foreach(ISocket s in n)
				{
					s.CheckTimeout();
				}
			}
		}

		public static void Add(ISocket s)
		{
			if(s.sock==null)return;
			sockets.Add(s);
		}

		public static void Remove(ISocket s)
		{
			sockets.Remove(s);
		}
	}

	public abstract class SocketClient : ISocket
	{
		ByteArrayBuilder result=null;
		protected ByteArray inPacket=null;

		public SocketClient()
		{
		}

		public SocketClient(Socket sock)
		{
			this.sock=sock;
		}

		public override bool NeedWrite()
		{
			return result!=null;
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
					sz=1024;
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
				Send( OnRecv(b, sz) );
			}
		}

		public override void RunSend()
		{
			if(result==null)return;
			int sz=sock.Send(result);
			if( sz <= 0 )
			{
				Dispose();
				return;
			}
			if(result.Length > sz)
			{
				result.Remove(0, sz);
				return;
			}
			result=null;
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


		public abstract byte[] OnRecv(byte[] b, int len);

		public void Send(byte[] b)
		{
			if(b==null)return;
			if(result==null)result=new ByteArrayBuilder();
			result.Add(b);
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
			Log("start port={0}", group);
		}

		void DoRecv(byte[] b, int sz)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			MemoryStream ms=new MemoryStream(b, 5, sz-5, false);

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

		public override byte[] OnRecv(byte[] b, int sz) 
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
