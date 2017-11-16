using System;
using System.Xml;

namespace WoWDaemon.Loader
{

	public class Config
	{
		protected XmlDocument m_document = new XmlDocument();
		string m_file;
		public Config(string file)
		{
			m_file = file;
			try
			{
				m_document.Load(file);
			}
			catch(Exception)
			{
				SetDefaultValues();
				Save();
				return;
			}
		}

		public XmlDocument Document
		{
			get { return m_document;}
		}

		public void Save()
		{
			m_document.Save(m_file);
		}

		public virtual void SetDefaultValues()
		{
		}
	}

	public class RealmListConfig : Config
	{
		public RealmListConfig(string file) : base(file)
		{
		}

		public override void SetDefaultValues()
		{
			XmlElement child;
			XmlElement root = m_document.CreateElement("RealmListConfig");
			child = m_document.CreateElement("Address");
			child.InnerText = "any";
			root.AppendChild(child);

			child = m_document.CreateElement("Port");
			child.InnerText = "3724";
			root.AppendChild(child);

			child = m_document.CreateElement("UpdatePort");
			child.InnerText = "3725";
			root.AppendChild(child);

			child = m_document.CreateElement("Password");
			child.InnerText = "";
			root.AppendChild(child);

			child = m_document.CreateElement("ExternalHost");
			child.InnerText = "";
			root.AppendChild(child);

			m_document.AppendChild(root);
		}

		public string Address
		{
			get 
			{
				try
				{
					return m_document["RealmListConfig"]["Address"].InnerText;
				}
				catch(Exception)
				{
					return "any";
				}
			}
		}

		public int Port
		{
			get 
			{ 
				try
				{
					return int.Parse(m_document["RealmListConfig"]["Port"].InnerText);
				}
				catch(Exception)
				{
					return 3724;
				}
			}
		}

		public int UpdatePort
		{
			get 
			{ 
				try
				{
					return int.Parse(m_document["RealmListConfig"]["UpdatePort"].InnerText);
				}
				catch(Exception)
				{
					return 3725;
				}
			}
		}

		public string ExternalHost
		{
			get 
			{
				try
				{
					return m_document["LoginServerConfig"]["ExternalHost"].InnerText;
				}
				catch(Exception)
				{
					return "any";
				}
			}
		}

		public string Password
		{
			get
			{
				try
				{
					return m_document["RealmListConfig"]["Password"].InnerText;
				}
				catch(Exception)
				{
					return string.Empty;
				}
			}
		}
	}


	public class WorldServerConfig : Config
	{
		public WorldServerConfig(string file) : base(file)
		{
		}

		public override void SetDefaultValues()
		{
			XmlElement child;
			XmlElement root = m_document.CreateElement("WorldServerConfig");
			child = m_document.CreateElement("Address");
			child.InnerText = "any";
			root.AppendChild(child);

			child = m_document.CreateElement("Port");
			child.InnerText = "9003";
			root.AppendChild(child);

			child = m_document.CreateElement("Scripts");
			child.InnerText = "scripts/world/";
			root.AppendChild(child);
			m_document.AppendChild(root);

			child = m_document.CreateElement("ScriptReference");
			child.InnerText = "System.dll";
			root.AppendChild(child);
			child = m_document.CreateElement("ScriptReference");
			child.InnerText = "WoWDaemon.Common.dll";
			root.AppendChild(child);
			child = m_document.CreateElement("ScriptReference");
			child.InnerText = "WoWDaemon.Database.dll";
			root.AppendChild(child);
			child = m_document.CreateElement("ScriptReference");
			child.InnerText = "WoWDaemon.WorldServer.dll";
			root.AppendChild(child);

		}

		public string Address
		{
			get 
			{
				try
				{
					return m_document["WorldServerConfig"]["Address"].InnerText;
				}
				catch(Exception)
				{
					return "any";
				}
			}
		}

		public int Port
		{
			get 
			{ 
				try
				{
					return int.Parse(m_document["WorldServerConfig"]["Port"].InnerText);
				}
				catch(Exception)
				{
					return 9000;
				}
			}
		}


		public string Scripts
		{
			get
			{
				try
				{
					return m_document["WorldServerConfig"]["Scripts"].InnerText;
				}
				catch(Exception)
				{
					return "scripts/world/";
				}
			}
		}
	}

	public class LoginServerConfig : Config
	{
		public LoginServerConfig(string file) : base(file)
		{
		}

		public override void SetDefaultValues()
		{
			XmlElement child;
			XmlElement root = m_document.CreateElement("LoginServerConfig");
			child = m_document.CreateElement("ServerName");
			child.InnerText = "John Doh's Server";
			root.AppendChild(child);

			child = m_document.CreateElement("Address");
			child.InnerText = "any";
			root.AppendChild(child);

			child = m_document.CreateElement("ExternalHost");
			child.InnerText = "";
			root.AppendChild(child);

			child = m_document.CreateElement("Port");
			child.InnerText = "9001";
			root.AppendChild(child);

			child = m_document.CreateElement("RedirectPort");
			child.InnerText = "9002";
			root.AppendChild(child);

			child = m_document.CreateElement("Scripts");
			child.InnerText = "scripts/login/";
			root.AppendChild(child);

			child = m_document.CreateElement("ScriptReference");
			child.InnerText = "System.dll";
			root.AppendChild(child);
			child = m_document.CreateElement("ScriptReference");
			child.InnerText = "WoWDaemon.Common.dll";
			root.AppendChild(child);
			child = m_document.CreateElement("ScriptReference");
			child.InnerText = "WoWDaemon.Database.dll";
			root.AppendChild(child);
			child = m_document.CreateElement("ScriptReference");
			child.InnerText = "WoWDaemon.LoginServer.dll";
			root.AppendChild(child);


			XmlElement server = m_document.CreateElement("WorldServer");
			XmlComment comment = m_document.CreateComment("Use 'local' to start up a worldserver in the same process.");
			server.AppendChild(comment);
			comment = m_document.CreateComment("For remote server type address[:port] like 123.123.123.123:5123");
			server.AppendChild(comment);
			child = m_document.CreateElement("Address");
			child.InnerText = "local";
			server.AppendChild(child);
			
			comment = m_document.CreateComment("Use 'all' to set this server to handle all the worldmaps in the database.");
			server.AppendChild(comment);
			comment = m_document.CreateComment("Otherwise type the ids like so: 1 2 3 4 5");
			server.AppendChild(comment);
			child = m_document.CreateElement("Worldmaps");
			child.InnerText = "all";
			server.AppendChild(child);

			root.AppendChild(server);

			server = m_document.CreateElement("RealmList");
			child = m_document.CreateElement("ClassType");
			child.InnerText = "WoWDaemon.Login.RealmListUpdater";
			server.AppendChild(child);
			child = m_document.CreateElement("Address");
			child.InnerText = "local";
			server.AppendChild(child);
			child = m_document.CreateElement("Password");
			child.InnerText = string.Empty;
			server.AppendChild(child);
			root.AppendChild(server);
			m_document.AppendChild(root);
		}

		public string ServerName
		{
			get 
			{
				try
				{
					return m_document["LoginServerConfig"]["ServerName"].InnerText;
				}
				catch(Exception)
				{
					return "John Error's Server";
				}
			}
		}

		public string Address
		{
			get 
			{
				try
				{
					return m_document["LoginServerConfig"]["Address"].InnerText;
				}
				catch(Exception)
				{
					return "any";
				}
			}
		}

		public string ExternalHost
		{
			get 
			{
				try
				{
					return m_document["LoginServerConfig"]["ExternalHost"].InnerText;
				}
				catch(Exception)
				{
					return "any";
				}
			}
		}

		public int Port
		{
			get 
			{ 
				try
				{
					return int.Parse(m_document["LoginServerConfig"]["Port"].InnerText);
				}
				catch(Exception)
				{
					return 9001;
				}
			}
		}

		public int RedirectPort
		{
			get 
			{ 
				try
				{
					return int.Parse(m_document["LoginServerConfig"]["RedirectPort"].InnerText);
				}
				catch(Exception)
				{
					return 9002;
				}
			}
		}

		public string Scripts
		{
			get
			{
				try
				{
					return m_document["LoginServerConfig"]["Scripts"].InnerText;
				}
				catch(Exception)
				{
					return "scripts/login/";
				}
			}
		}
	}
}
