using System;
using System.Net;
namespace WoWDaemon.Common
{
	/// <summary>
	/// Summary description for LocalClientBase.
	/// </summary>
	public class LocalClientBase : ClientBase
	{
		static int localClientNum = 0;
		LocalClientBase m_remoteClient = null;
		bool m_connected = false;
		public LocalClientBase() : base(null)
		{
			localClientNum++;
			m_iep = new IPEndPoint(IPAddress.Parse("255.255.255.255"), localClientNum);

			// Dodgy dodgy dodgy....
			m_packet_header = new PacketBuffer(0);
		}

		public void SetRemoteClient(LocalClientBase client)
		{
			m_remoteClient = client;
			m_connected = true;
		}

		public override void Close(string reason)
		{
			m_connected = false;
			m_sendQueue.Clear();
			m_remoteClient = null;
		}

		public override bool Connected
		{
			get
			{
				return m_connected && m_remoteClient.m_connected;
			}
		}

		public override void SendWork()
		{
		}

		public override void EnqueueSendData(byte[] data)
		{
			if(m_connected)
				m_remoteClient.OnReadData(data);
		}

		/*
		public override byte[] GetNextPacketData()
		{
			if(m_sendQueue.Count > 0)
				return (byte[])m_sendQueue.Dequeue();
			return null;
		}*/

		public override int  PacketDataSize
		{
			get 
			{
				return 0;
			}
		}

		public override int PacketHeaderSize
		{
			get
			{
				return 0;
			}
		}

		public override bool Timedout
		{
			get
			{
				return false;
			}
		}

		public override bool PendingSendData
		{
			get
			{
				return false;
			}
		}
	}
}
