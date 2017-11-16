using System;
using System.Collections;
using System.Collections.Specialized;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Globalization;
using WoWDaemon.Common;

namespace WoWDaemon.Login
{
	/// <summary>
	/// 
	/// </summary>
	public class RedirectServer
	{
		public static readonly IPEndPoint DEFAULT_ADDRESS = new IPEndPoint(IPAddress.Any, 9090);
		static Socket Listener = null;
		static Thread m_thread = null;
		static string AddressString;
		static string AddressStringLocal;
		static string Description = "WoWDaemon";
		static string DescriptionLocal = "Daemon - Local";
		static Hashtable m_realmLists = Hashtable.Synchronized(new Hashtable());
		internal static event VoidDelegate ServerStart;
		internal static event VoidDelegate ServerStop;

		static bool m_shutdown = false;
		static bool m_running = false;
		internal static bool Start(IPEndPoint iep, string ExternalIP)
		{
			if(m_running == false)
			{
				m_running = true;
				m_shutdown = false;
				string LoginServerPort = LoginServer.EndPoint.Port.ToString();
				SetLoginServer(ExternalIP+":"+LoginServerPort);
				Listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				try
				{
					Listener.Bind(iep);
					Listener.Listen(20);
					Listener.Blocking = false;
				}
				catch(SocketException)
				{
					return false;
				}
				AddressString = ExternalIP+":"+iep.Port.ToString();
				AddressStringLocal = Listener.LocalEndPoint.ToString();
				Description = LoginServer.ServerName;
				DescriptionLocal = LoginServer.ServerName+" - Local";
				if(ServerStart != null)
					ServerStart();
				m_thread = new Thread(new ThreadStart(mainThread));
				m_thread.Name = "Redirect server main thread";
				m_thread.Start();
			}
			return true;
		}

		internal static void Stop()
		{
			m_shutdown = true;
		}

		private static Socket acceptSocket()
		{
			try
			{
				return Listener.Accept();
			}
			catch(SocketException e)
			{
				if(e.ErrorCode == 10035) // non-blocking socket operation could not be completed immediately
					return null;
				throw e;
			}
		}
		private static void mainThread()
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
			Socket sock = null;
			DateTime LastUpdate = DateTime.MinValue;
			TimeSpan span;
			try
			{
				while(!m_shutdown)
				{
					while((sock = acceptSocket()) != null)
					{
						try
						{
							sock.Send(tehAddress);
						}
						catch(SocketException) {}

						sock.Shutdown(SocketShutdown.Both);
						sock.Close();
						sock = null;
					}
					EventManager.CheckEvents();
					DateTime now = DateTime.Now;
					span = now.Subtract(LastUpdate);
					if(span.TotalSeconds > 30)
					{
						UpdateRealmLists();
						LastUpdate = now;
					}
					UpdatersWork();
					Thread.Sleep(50);
				}
			}
			catch(ThreadAbortException)
			{
			}
			catch(Exception e)
			{
				Console.WriteLine("RedirectServer:Unhandled exception!");
				Console.WriteLine(e.Message);
				Console.WriteLine(e.StackTrace);
			}
			Listener.Close();
			Listener = null;
			try
			{
				if(sock != null)
					sock.Close();
			}
			catch(Exception) {} // just incase
			if(ServerStop != null)
				ServerStop();
			if(m_realmLists.Count > 0)
			{
				IEnumerator e = m_realmLists.Keys.GetEnumerator();
				while(e.MoveNext())
				{
					RealmListUpdater updater = (RealmListUpdater)e.Current;
					updater.Close();
				}
				m_realmLists.Clear();
			}
			m_running = false;
		}

		public static void AddRealmList(RealmListUpdater updater)
		{
			m_realmLists[updater] = updater;
		}
		public static void RemoveRealmList(RealmListUpdater updater)
		{
			m_realmLists.Remove(updater);
		}
		static void UpdatersWork()
		{
			IEnumerator e = new ArrayList(m_realmLists.Keys).GetEnumerator();
			while(e.MoveNext())
			{
				RealmListUpdater updater = (RealmListUpdater)e.Current;
				updater.Work();
				if(updater.Connected == false)
					RemoveRealmList(updater);
			}
		}
		static void UpdateRealmLists()
		{
			IEnumerator e = new ArrayList(m_realmLists.Keys).GetEnumerator();
			string addr = LoginServer.EndPoint.ToString();
			while(e.MoveNext())
			{
				RealmListUpdater updater = (RealmListUpdater)e.Current;
				updater.UpdateRealmList(Description, addr, LoginServer.CurrentUsers);
				if(updater.Connected == false)
					RemoveRealmList(updater);
			}
		}

		#region Properties
		public static IPEndPoint LocalEndPoint
		{
			get
			{
				if(Listener != null)
					return (IPEndPoint)Listener.LocalEndPoint;
				return DEFAULT_ADDRESS;
			}
		}

		public static bool IsActive
		{
			get
			{
				return Listener != null;
			}
		}
		#endregion

		// more temp crap
		static byte[] tehAddress = null;
		/// <summary>
		/// temp crap
		/// </summary>
		/// <param name="address"></param>
		private static void SetLoginServer(string address)
		{
			if(address == string.Empty)
			{
				tehAddress = null;
				return;
			}
			string tmp = string.Format("{0}\0", address);
			tehAddress = System.Text.ASCIIEncoding.ASCII.GetBytes(tmp);
		}
	}
}
