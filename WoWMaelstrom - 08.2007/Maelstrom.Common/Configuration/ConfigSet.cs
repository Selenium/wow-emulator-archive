using System;
using System.Collections;

namespace Maelstrom
{
	public sealed class ConfigSet
	{
		private string m_Name;
		private ConfigEngine m_Engine;
		private ArrayList m_ConfigFiles = ArrayList.Synchronized(new ArrayList());
		
		public string Name
		{
			get {return m_Name;}
		}

		#region Indexed by Group

		public ConfigElement[] this[string Group]
		{
			get
			{
				lock(m_ConfigFiles)
				{
					ArrayList ResultList = new ArrayList();

					foreach(ConfigFile ConfigFile in m_ConfigFiles)
					{
						ConfigElement[] CurrentElements = ConfigFile[Group];
						foreach (ConfigElement ConfigElement in CurrentElements)
						{
							ResultList.Add(ConfigElement);
						}
					}
				
					ConfigElement[] Result = new ConfigElement[ResultList.Count];
					ResultList.CopyTo(Result,0);

					return Result;
				}
			}
		}

		#endregion
		#region Indexed by Integer

		public ConfigElement this[string Group, ulong Key]
		{
			get
			{
				return this[Group,Key.ToString()];
			}
		}

		#endregion
		#region Indexed by String

		public ConfigElement this[string Group, string Key]
		{
			get
			{
				lock(m_ConfigFiles)
				{
					foreach(ConfigFile ConfigFile in m_ConfigFiles)
					{
						ConfigElement CurrentElement = ConfigFile[Group,Key];
						if (CurrentElement != null)
						{
							return CurrentElement;
						}
					}

					return null;
				}
			}
		}

		#endregion
		#region Indexed by Integer of Specific Property

		public ConfigElement[] this[string Group, string PropertyName, ulong Key]
		{
			get
			{
				return this[Group,PropertyName,Key.ToString()];
			}
		}

		#endregion
		#region Indexed by String of Specific Property

		public ConfigElement[] this[string Group, string PropertyName, string Key]
		{
			get
			{
				lock(m_ConfigFiles)
				{
					ArrayList ResultList = new ArrayList();

					foreach(ConfigFile ConfigFile in m_ConfigFiles)
					{
						ConfigElement[] CurrentElements = ConfigFile[Group,PropertyName,Key];
						foreach (ConfigElement ConfigElement in CurrentElements)
						{
							ResultList.Add(ConfigElement);
						}
					}

					ConfigElement[] Result = new ConfigElement[ResultList.Count];
					ResultList.CopyTo(Result,0);

					return Result;
				}
			}
		}

		#endregion

		#region Reload

		public void Reload()
		{
			lock(m_ConfigFiles)
			{
				foreach(ConfigFile File in m_ConfigFiles)
				{
					File.Reload();
				}
			}
		}

		#endregion

		internal ConfigSet(string Name, ConfigEngine Engine)
		{
			m_Name = Name;
			m_Engine = Engine;
		}

		internal void AddConfig(string Filename)
		{
			ConfigFile ConfigFile = m_Engine.LoadFile(Filename);
			AddConfig(ConfigFile);
		}

		internal void AddConfig(ConfigFile ConfigFile)
		{
			if (!m_ConfigFiles.Contains(ConfigFile))
			{
				m_ConfigFiles.Add(ConfigFile);
			}
		}
	}
}
