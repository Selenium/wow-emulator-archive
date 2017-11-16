using System;
using WoWDaemon.Common;

namespace WoWDaemon.Login
{
	public interface IRealmListUpdater
	{
		bool Connected
		{
			get;
		}
		void UpdateRealmList(string Description, string IP, int Users);
		void Close();
	}
	/// <summary>
	/// Summary description for RealmListUpdater.
	/// </summary>
	public class RealmListUpdater : IRealmListUpdater
	{
		ClientBase m_client;
		string Password = string.Empty;
		public RealmListUpdater(ClientBase client)
		{
			m_client = client;
			client.RecievedDataHandler += OnData;
		}

		public RealmListUpdater(ClientBase client, string pwd)
		{
			m_client = client;
			client.RecievedDataHandler += OnData;
			Password = pwd;
		}

		~RealmListUpdater()
		{
			m_client.RecievedDataHandler -= OnData;
		}

		public virtual bool Connected
		{
			get
			{
				return m_client.Connected;
			}
		}

		public virtual void OnData(ClientBase client, byte[] data)
		{
		}

		public virtual void UpdateRealmList(string Description, string IP, int Users)
		{
			BinWriter w = new BinWriter();
			w.Write(0);
			w.Write(Password);
			w.Write(Description);
			w.Write(IP);
			w.Write(Users);
			w.Set(0, (int)w.BaseStream.Length-4);
			m_client.Send(w.GetBuffer(), w.BaseStream.Length);
		}

		public virtual void Close()
		{
			m_client.Close("Closed");
		}
		}
}
