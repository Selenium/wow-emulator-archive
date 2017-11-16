using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.Globalization;

namespace WoWDaemon.Common
{
	/// <summary>
	/// Summary description for ServerBase.
	/// </summary>
	public class ServerBase
	{
		public ServerBase()
		{
		}
		Socket m_listen = null;
		protected Hashtable m_clients = Hashtable.Synchronized(new Hashtable());
		Thread m_mainThread = null;
		public event VoidDelegate OnServerStart;
		public event VoidDelegate OnServerStop;

		public IPEndPoint LocalEndPoint
		{
			get
			{
				if(m_listen != null)
					return (IPEndPoint)m_listen.LocalEndPoint;
				return new IPEndPoint(IPAddress.Any, 0);
			}
		}

		public override string ToString()
		{
			string[] split = this.GetType().ToString().Split('.');
			return split[split.Length-1] + "(" + LocalEndPoint.ToString() + ")";
		}


		
		public virtual bool Start(IPEndPoint iep)
		{
			m_listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			try
			{
				m_listen.Bind(iep);
				m_listen.Listen(5);
				m_listen.Blocking = false;
			}
			catch(SocketException)
			{
				return false;
			}
			if(OnServerStart != null)
				OnServerStart();
			m_mainThread = new Thread(new ThreadStart(mainThread));
			m_mainThread.Start();
			return true;
		}

		public virtual void Stop()
		{
			if (m_listen != null && m_listen.Connected)
				m_listen.Close();

			try {
				m_mainThread.Abort();
			} catch (ThreadAbortException) {}

			if(OnServerStop != null)
				OnServerStop();
		}

		public int ClientCount
		{
			get
			{
				return m_clients.Count;
			}
		}

		public ArrayList Clients
		{
			get
			{
				return new ArrayList(m_clients.Values);
			}
		}

		private Socket acceptSocket()
		{
			try
			{
				return m_listen.Accept();
			}
			catch(SocketException e)
			{
				if(e.ErrorCode == 10035) // non-blocking socket operation could not be completed immediately
					return null;
				throw e;
			}
		}

		private void mainThread()
		{
			Socket sock;
			Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
			Exception onclientloopexception = null;
			try
			{
				while(true)
				{
					while((sock = acceptSocket()) != null)
					{
						if(isBanned(((IPEndPoint)sock.RemoteEndPoint).Address))
						{
							sock.Close();
							continue;
						}
						OnAcceptSocket(sock);
					}
					OnClientLoopStart();
					socketLoop();
					//socketSelect();
					OnClientLoopStop();
				}
			} catch (Exception exp) {
				onclientloopexception = exp;
			}
			m_listen.Close();
			if(m_clients.Count > 0)
			{
				IDictionaryEnumerator i = m_clients.GetEnumerator();
				while(i.MoveNext())
				{
					((ClientBase)i.Value).Close("Server shutting down");
				}
			}
			if (onclientloopexception != null && onclientloopexception.GetType() != typeof(ThreadAbortException))
				OnClientLoopException(onclientloopexception);
		}

		public virtual bool isBanned(IPAddress address)
		{
			return false;
		}

		public virtual void OnAcceptSocket(Socket sock)
		{
			AddClient(new ClientBase(sock));
		}

		public void AddClient(ClientBase client)
		{
			m_clients.Add(client.RemoteEndPoint.ToString(), client);
		}

		public virtual void RemoveClient(ClientBase aClient)
		{
			m_clients.Remove(aClient.RemoteEndPoint.ToString());
		}

		public virtual void OnClientData(ClientBase aClient, byte[] data)
		{

		}

		public virtual void OnClientLoopStart() {}
		/// <summary>
		/// Can be used to check timeout for example
		/// </summary>
		/// <param name="aClient"></param>
		public virtual void OnClientLoop(ClientBase aClient) {
			
		}

		public virtual void OnClientLoopStop() {}
		
		public virtual void OnClientLoopException(Exception exp) {}

		/// <summary>
		/// Loops through each client and checks for available packet on each
		/// </summary>
		private void socketLoop()
		{
			try {
				if(m_clients.Count > 0)
				{
					byte[] data;
					ArrayList list = new ArrayList(m_clients.Values);
					IEnumerator e = list.GetEnumerator();
					while(e.MoveNext())
					{
						ClientBase client = (ClientBase)e.Current;
						if(client.PendingSendData)
							client.SendWork();
						if(client.Connected == false)
						{
							RemoveClient(client);
							continue;
						}
						while((data = client.GetNextPacketData()) != null)
						{
							OnClientData(client, data);
						}
						if(client.Connected == false)
						{
							RemoveClient(client);
							continue;
						}
						OnClientLoop(client);
					}
				}
			} catch (Exception exp) {
				OnClientLoopException(exp);
			}
		}
	}
}
