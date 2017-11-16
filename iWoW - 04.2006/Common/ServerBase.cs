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
	public class ServerBase//<T> where T : ClientBase
	{
		protected Socket m_listen = null;

		protected Hashtable m_clients = Hashtable.Synchronized(new Hashtable());

		public event VoidDelegate OnServerStart;
		public event VoidDelegate OnServerStop;

		public delegate void OnDataHandler(ClientBase client, byte[] data);
		public event OnDataHandler ClientDataHandler;

		protected const int AcceptThreadPoolSize = 10;

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
				m_listen.Listen((int)SocketOptionName.MaxConnections);
			}
			catch(SocketException)
			{
				return false;
			}

			if(OnServerStart != null)
				OnServerStart();

			for (int i = 0; i < AcceptThreadPoolSize; i++)
			{
				m_listen.BeginAccept(new AsyncCallback(acceptCallback), null);
			}

			return true;
		}

		protected void acceptCallback(IAsyncResult result)
		{
			Socket client = m_listen.EndAccept(result);
			IPEndPoint ip = (IPEndPoint)client.RemoteEndPoint;

			if (isBanned(ip.Address))
			{
				client.Close();
			}
			else
			{
				OnAcceptSocket(client);
			}

			m_listen.BeginAccept(new AsyncCallback(acceptCallback), result.AsyncState);
		}

		public virtual void Stop()
		{
			if (m_listen != null && m_listen.Connected)
				m_listen.Close();

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

		public virtual void OnClientData(ClientBase aClient, byte[] data)
		{
			if (ClientDataHandler != null)
			{
				ClientDataHandler(aClient, data);
			}

		}

#if false
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
#endif

		// i'm not actually used by any children.
		public virtual bool isBanned(IPAddress address)
		{
			return false;
		}

		#region Client management

		public virtual void OnAcceptSocket(Socket sock)
		{
			ClientBase client = new ClientBase(sock);
			AddClient(client);
		}

		public void AddClient(ClientBase client)
		{
			client.RecievedDataHandler += OnClientData;
			m_clients.Add(client.RemoteEndPoint.ToString(), client);
		}

		public virtual void RemoveClient(ClientBase client)
		{
			client.RecievedDataHandler -= OnClientData;
			m_clients.Remove(client.RemoteEndPoint.ToString());
		}

		#endregion
#if false
		/// <summary>
		/// Loops through each client and checks for available packet on each.
		/// 
		/// NOT USED!
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
#endif
	}
}
