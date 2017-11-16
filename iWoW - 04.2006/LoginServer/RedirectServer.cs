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
	public class RedirectServer : ServerBase
	{
		public static RedirectServer Instance = new RedirectServer();

		public readonly IPEndPoint DEFAULT_ADDRESS = new IPEndPoint(IPAddress.Any, 9090);

		string Description = "WoWDaemon";
		string DescriptionLocal = "Daemon - Local";

		Hashtable m_realmLists = Hashtable.Synchronized(new Hashtable());

		bool m_shutdown = false;
		bool m_running = false;

		Timer updateTimer = null;

		internal protected bool Start(IPEndPoint iep, string ExternalIP)
		{
			if(m_running == false)
			{
				base.Start(iep);

				m_running = true;
				m_shutdown = false;
				string LoginServerPort = LoginServer.RemoteEndPoint.Port.ToString();
				SetLoginServer(ExternalIP+":"+LoginServerPort);

				Description = LoginServer.ServerName;
				DescriptionLocal = LoginServer.ServerName+" - Local";

				TimerCallback tc = new TimerCallback(UpdateRealmList);
				updateTimer = new Timer(tc, null, 0, 30 * 1000 /* 30 seconds */);
			}
			return true;
		}

		protected virtual void UpdateRealmList(Object state)
		{
			UpdateRealmLists();
		}

		public override void Stop()
		{
			m_shutdown = true;
			base.Stop();

			if (m_realmLists.Count > 0)
			{
				IEnumerator e = m_realmLists.Keys.GetEnumerator();
				while (e.MoveNext())
				{
					RealmListUpdater updater = (RealmListUpdater)e.Current;
					updater.Close();
				}
				m_realmLists.Clear();
			}
			
			m_running = false;
		}

		public override void OnAcceptSocket(Socket sock)
		{
			sock.Send(tehAddress);
			sock.Shutdown(SocketShutdown.Both);
			sock.Close();
		}
		/*
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
			Stop();
		}
		*/

		public void AddRealmList(RealmListUpdater updater)
		{
			m_realmLists[updater] = updater;
		}
		public void RemoveRealmList(RealmListUpdater updater)
		{
			m_realmLists.Remove(updater);
		}

		void UpdateRealmLists()
		{
			lock (this)
			{
				IEnumerator e = new ArrayList(m_realmLists.Keys).GetEnumerator();
				string addr = LoginServer.RemoteEndPoint.ToString();
				while (e.MoveNext())
				{
					RealmListUpdater updater = (RealmListUpdater)e.Current;
					updater.UpdateRealmList(Description, addr, LoginServer.CurrentUsers);
					if (updater.Connected == false)
						RemoveRealmList(updater);
				}
			}
		}

		// more temp crap
		byte[] tehAddress = null;
		/// <summary>
		/// temp crap
		/// </summary>
		/// <param name="address"></param>
		private void SetLoginServer(string address)
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
