using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace Maelstrom.Remoting
{
	public sealed class RemotingServer
	{
		private TcpServerChannel m_RemoteChannel;
		private bool m_Enabled = false;

		#region Enabled

		public bool Enabled
		{
			get {return m_Enabled;}
			set
			{
				if (m_Enabled != value)
				{
					if (value)
					{
						ChannelServices.RegisterChannel(m_RemoteChannel);
					}
					else
					{
						ChannelServices.UnregisterChannel(m_RemoteChannel);
					}

					m_Enabled = value;
				}
			}
		}

		#endregion

		public void RegisterType(string Name, Type Type)
		{
			RemotingConfiguration.RegisterWellKnownServiceType(Type,Name,WellKnownObjectMode.Singleton);
		}

		public RemotingServer(string Name, ushort Port)
		{
			m_RemoteChannel = new TcpServerChannel(Name,Port);
		}
	}
}
