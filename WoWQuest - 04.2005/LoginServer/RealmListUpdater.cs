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
		void Work();
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
		}

		public RealmListUpdater(ClientBase client, string pwd)
		{
			m_client = client;
			Password = pwd;
		}

		public virtual bool Connected
		{
			get
			{
				return m_client.Connected;
			}
		}

		public virtual void Work()
		{
			try
			{
				if(m_client.PendingSendData)
					m_client.SendWork();
				if(m_client.Connected == false)
					return;
				byte[] data;
				while((data = m_client.GetNextPacketData()) != null)
					OnData(data);
				if(m_client.Connected == false)
					return;
			}
			catch(Exception e)
			{
				m_client.OnException(e);
			}
		}

		public virtual void OnData(byte[] data)
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
