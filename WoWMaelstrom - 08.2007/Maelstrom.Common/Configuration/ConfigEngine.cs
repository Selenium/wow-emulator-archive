using System;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Configuration;

namespace Maelstrom
{
	/// <summary>
	/// Provides a configuration system for reading XML and DBC data through a unified interface.
	/// </summary>
	public sealed class ConfigEngine
	{
		private Assembly m_Assembly;
		private Hashtable m_LoadedFiles = Hashtable.Synchronized(new Hashtable());
		private Hashtable m_LoadedSets = Hashtable.Synchronized(new Hashtable());

		#region DataPath

		public string DataPath
		{
			get 
			{
				return ConfigurationSettings.AppSettings.Get("DataPath");
			}
		}

		#endregion

		#region LoadSet

		public ConfigSet LoadSet(string Name, string[] Files)
		{
			ConfigSet CurrentSet;

			if (m_LoadedSets.ContainsKey(Name))
			{
				CurrentSet = m_LoadedSets[Name] as ConfigSet;
			}
			else
			{
				CurrentSet = new ConfigSet(Name,this);
				m_LoadedSets.Add(Name,CurrentSet);
			}

			foreach(string Filename in Files)
			{
				ConfigFile CurrentConfig = LoadFile(Filename);
				if (CurrentConfig != null)
				{
					CurrentSet.AddConfig(CurrentConfig);
				}
			}

			return CurrentSet;
		}

		#endregion		
		#region LoadFile

		public ConfigFile LoadFile(string Filename)
		{
			ConfigFile CurrentFile;

			if (m_LoadedFiles.ContainsKey(Filename))
			{
				CurrentFile = m_LoadedFiles[Filename] as ConfigFile;
			}
			else
			{
				CurrentFile = new ConfigFile(Filename,this);
				m_LoadedFiles.Add(Filename,CurrentFile);
			}
			
			return CurrentFile;
		}

		#endregion
		#region CacheFile

		public void CacheFile(string Filename)
		{
			LoadFile(Filename);
			Console.WriteLine("  File \"{0}\" loaded.",Filename);
		}

		#endregion
		#region CacheSet

		public void CacheSet(string Name, string[] Files)
		{
		}

		#endregion

		#region Reload

		public void Reload()
		{
			lock(m_LoadedFiles)
			{
				foreach(DictionaryEntry Entry in m_LoadedFiles)
				{
					ConfigFile CurrentFile = (ConfigFile)Entry.Value;
					CurrentFile.Reload();
				}
			}
		}

		#endregion

		public ConfigEngine(Assembly ResourceAssembly)
		{
			Console.WriteLine("* Preloading configuration files:\n");
			m_Assembly = ResourceAssembly;

			//This is a common file, and all servers require it.
			CacheFile(Path.Combine(DataPath,"ServerConfiguration.xml"));
		}
	}
}
