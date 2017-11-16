using System;
using System.IO;
using System.Text;

using Server.Konsole.Telnet;
using Server.Konsole.Sockets;

namespace Server.Konsole
{
	public class ConsoleHook : TextWriter
	{
		public TextWriter ConsoleOut;

		public override Encoding Encoding 
		{ 
			get { return Encoding.ASCII; } 
		} 

		public ConsoleHook()
		{
			ConsoleOut = Console.Out;
			ConsoleOut.WriteLine(".-= Console Hook Installed =-.");
		}

		public override void WriteLine(string value)
		{
			if(Telnet.TelnetBootstrap.telnetlistener != null)
			{
				for(int i = 0; i < Telnet.TelnetBootstrap.telnetlistener.listener.TCPClients.Length; i++)
				{
					if(TelnetBootstrap.telnetlistener.listener.TCPClients[i] != null && 
						Telnet.TelnetBootstrap.telnetlistener.listener.TCPClients[i].Connected &&
						Telnet.TelnetBootstrap.telnetlistener.listener.TCPClients[i].Authenticated)
					{
						Telnet.TelnetBootstrap.telnetlistener.listener.TCPClients[i].WriteLine(value);
					}
				}
			}
			ConsoleOut.WriteLine(value);
		}

		public override void Write(string value)
		{
			if(Telnet.TelnetBootstrap.telnetlistener != null)
			{
				for(int i = 0; i < Telnet.TelnetBootstrap.telnetlistener.listener.TCPClients.Length; i++)
				{
					if(Telnet.TelnetBootstrap.telnetlistener.listener.TCPClients[i] != null && 
						Telnet.TelnetBootstrap.telnetlistener.listener.TCPClients[i].Connected &&
						Telnet.TelnetBootstrap.telnetlistener.listener.TCPClients[i].Authenticated)
					{
						Telnet.TelnetBootstrap.telnetlistener.listener.TCPClients[i].Write(value);
					}
				}
			}
			ConsoleOut.Write(value);
		}
	}
}


 


