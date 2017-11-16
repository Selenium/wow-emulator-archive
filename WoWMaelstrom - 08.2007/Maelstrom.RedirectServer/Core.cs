using System;
using System.IO;
using System.Reflection;

namespace Maelstrom.RedirectServer
{
	using Maelstrom.Network;
	using Maelstrom.Remoting;
	
	/// <summary>
	/// The Maelstrom Redirect Server Library Core.
	/// </summary>
	public sealed class Core
	{
		private static RedirectServerListener m_Server;
		private static ScriptEngine m_ScriptEngine;
		private static ConfigEngine m_ConfigEngine;

		#region CoreAssembly

		private static Assembly CoreAssembly
		{
			get
			{
				return Assembly.GetAssembly(typeof(Core));
			}
		}

		#endregion
		#region ScriptEngine

		public static ScriptEngine ScriptEngine
		{
			get {return m_ScriptEngine;}
		}

		#endregion
		#region ConfigEngine

		public static ConfigEngine ConfigEngine
		{
			get {return m_ConfigEngine;}
		}

		#endregion

		public static void Initialize()
		{
			Console.WriteLine("Redirect Server Core Initialization");
			Console.WriteLine("-----------------------------------");

			#region Configuration Engine Initialization

			m_ConfigEngine = new ConfigEngine(CoreAssembly);
			Console.WriteLine();

			#endregion
			
			ConfigFile ServerConfig = m_ConfigEngine.LoadFile(Path.Combine(m_ConfigEngine.DataPath,"ServerConfiguration.xml"));
			ConfigElement ServerConfigElement = ServerConfig["config","RedirectServer"];
			
			#region Script Engine Initialization

			ConfigElement[] PackageElements = ServerConfigElement.GetSubElements("packages");
			string[] PathList = new string[PackageElements.Length];

			for(int i=0;i<=PackageElements.Length-1;i++)
			{
				PathList[i] = PackageElements[i].GetString("packages_Column");
			}

			m_ScriptEngine = new ScriptEngine(m_ConfigEngine,PathList);

			Console.WriteLine();

			#endregion
			#region .NET Remoting Initialization

			Console.WriteLine("* Redirect Server .NET remoting service has been configured:\n");
			
			ConfigElement[] RemotingElements = ServerConfigElement.GetSubElements("remoting");
			if (RemotingElements.Length != 1)
			{
				//We must have a remoting configuration (and only one), so throw an exception here.
			}

			string RemotingName = RemotingElements[0].GetString("name");
			ushort RemotingPort = RemotingElements[0].GetUInt16("port");

			RemotingServer RemoteInterface = new RemotingServer(RemotingName,RemotingPort);
			RemoteInterface.RegisterType(RemotingName,typeof(RemoteRedirectServer));
			RemoteInterface.Enabled = true;

			Console.WriteLine("  Service Name: {0}\n  Service Port: {1}",RemotingName,RemotingPort);
			Console.WriteLine();

			#endregion

			ushort Port = ServerConfigElement.GetUInt16("port");
			m_Server = new RedirectServerListener(Port);
		}

		public static void Run(string[] Arguments)
		{
			m_ScriptEngine.InitializeScripts(); //We initialize the scripts only when the core starts running.

			m_Server.Listen();
			Console.WriteLine("Redirect Server is listening for client connections on port {0}...",m_Server.Port);
		}

		public static void Shutdown()
		{
			m_Server.Dispose();
		}
	}
}
