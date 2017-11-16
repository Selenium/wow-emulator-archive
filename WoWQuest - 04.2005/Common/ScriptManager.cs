#define SUPPORT_CSHARP
#define SUPPORT_VB
//#define SUPPORT_MCPP
//#define SUPPORT_VJSHARP

using System;
using System.IO;
using System.Collections;
using System.Collections.Specialized;
using System.Reflection;
using System.CodeDom;
using System.CodeDom.Compiler;


namespace WoWDaemon.Common
{
	public abstract class ScriptManager
	{
		public ScriptManager()
		{
		}

		public static ScriptManager GetScriptManager()
		{
			return new DefaultScriptManager();
		}

		private static bool hasBaseType(Type type)
		{
			if(type.BaseType == typeof(ScriptManager))
				return true;
			if(type.BaseType == typeof(object))
				return false;
			return hasBaseType(type.BaseType);
		}

		private static ScriptManager GetScriptManagerFromAssembly(Assembly asm)
		{
			foreach(Type type in asm.GetTypes())
			{
				if(type.IsClass == false)
					continue;
				if(hasBaseType(type))
				{					
					return (ScriptManager)asm.CreateInstance(type.FullName);
				}
			}
			throw new Exception("Failed to find a class in assembly(" + asm + ") that inherited ScriptManager");
		}

		public static ScriptManager LoadFromDLL(string dll)
		{
			return GetScriptManagerFromAssembly(Assembly.LoadFile(dll));
		}

		public abstract void AddReference(string module);

		public abstract bool LoadScripts(Type scriptAssemblyType, bool getsubdirs, string path, out string error);
		public abstract void UnloadScripts(string path);
		public abstract void UnloadAllScripts();
	}

	/// <summary>
	/// Summary description for ScriptManager.
	/// </summary>
	internal class DefaultScriptManager : ScriptManager
	{
		CompilerParameters m_params;
		public DefaultScriptManager()
		{
			m_params = new CompilerParameters();
			m_params.GenerateInMemory = true;
			m_params.GenerateExecutable = false;
			m_params.WarningLevel = 4;
		}

		public override void AddReference(string module)
		{
			m_params.ReferencedAssemblies.Add(module);
		}

		
		HybridDictionary ScriptAssemblies = new HybridDictionary();

		private bool CheckPath(string path, out string error)
		{
			error = string.Empty;
			if(ScriptAssemblies.Count == 0)
				return true;
			IEnumerator e = ScriptAssemblies.Keys.GetEnumerator();
			while(e.MoveNext())
			{
				string compiled = (string)e.Current;
				if(compiled.StartsWith(path))
				{
					error = "Sub directory " + compiled + " has already been compiled. Please unload it first.";
					return false;
				}
				if(path.StartsWith(compiled))
				{
					error = "Parent directory " + compiled + " has already been compiled.";
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// return true if it added an assembly
		/// </summary>
		/// <param name="provider"></param>
		/// <param name="asm"></param>
		/// <param name="path"></param>
		/// <param name="reportFile"></param>
		/// <param name="error"></param>
		/// <returns></returns>
		private bool AddAssembly(CodeDomProvider provider, IScriptAssembly asm, string path, bool getsubdirs, out string error)
		{
			error = string.Empty;
			string[] files;
			if(getsubdirs)
				files = GetFiles(path, "*." + provider.FileExtension);
			else
				files = GetFilesNoSub(path, "*." + provider.FileExtension);

			if(files.Length == 0)
				return false;
			CompilerResults results = Compile(provider, files);
			if(results.Errors.Count > 0)
			{
				ReportErrors(path, provider.FileExtension + "errors.log", results, out error);
				return false;
			}
			asm.AddAssembly(results.CompiledAssembly);
			return true;
		}

		/// <summary>
		/// Loads all script from a directory and optionally it's sub directorys
		/// </summary>
		/// <param name="scriptAssemblyType">Needs to inherit IScriptAssembly</param>
		/// <param name="getsubdirs">if true it will search sub directories</param>
		/// <param name="path">Path to scripts</param>
		/// <param name="error">returns the error if LoadScripts returns false</param>
		/// <returns>Returns true if no errors occured.</returns>
		public override bool LoadScripts(Type scriptAssemblyType, bool getsubdirs, string path, out string error)
		{
			error = string.Empty;

			if(scriptAssemblyType.GetInterface(typeof(IScriptAssembly).ToString()) == null)
			{
				error = scriptAssemblyType.ToString() + " does not implemented " + typeof(IScriptAssembly).ToString();
				return false;
			}

			DirectoryInfo dir;
			try
			{
				dir = new DirectoryInfo(path);
			}
			catch(ArgumentException e)
			{
				error = e.Message + " " + path;
				return false;
			}
			if(dir.Exists == false)
				return true;
			//string shortpath = path;
			string shortpath = dir.FullName;
			path = dir.FullName;
			if(getsubdirs)
			{
				if(!CheckPath(path, out error))
					return false;
			}
			else if(ScriptAssemblies.Contains(path))
			{
				error = "There's already a script assembly on that path.";
				return false;
			}

			IScriptAssembly asm = (IScriptAssembly)Activator.CreateInstance(scriptAssemblyType);
			int assemblies = 0;
			string[] assemblyfiles = GetFilesNoSub(shortpath, "*.dll");
			foreach (string afile in assemblyfiles) { 
				try {
					Assembly sassembly = Assembly.LoadFile(afile);
					asm.AddAssembly(sassembly);
					assemblies++;
					Console.WriteLine("SCRIPT: " + scriptAssemblyType.Name + " loaded the script assembly: " + afile);
				} catch (Exception e) {
					error = e.ToString();
					return false;
				}
			}

			//#region Old ScriptCode
			
#if SUPPORT_CSHARP
			if(!AddAssembly(new Microsoft.CSharp.CSharpCodeProvider(), asm, shortpath, getsubdirs, out error))
			{
				if(error != string.Empty)
					return false;
			}
			else
				assemblies++;
#endif
#if SUPPORT_VB
			if(!AddAssembly(new Microsoft.VisualBasic.VBCodeProvider(), asm, shortpath, getsubdirs, out error))
			{
				if(error != string.Empty)
					return false;
			}
			else
				assemblies++;
#endif
#if SUPPORT_MCPP
			if(!AddAssembly(new Microsoft.MCpp.MCppCodeProvider(), asm, shortpath, getsubdirs, out error))
			{
				if(error != string.Empty)
					return false;
			}
			else
				assemblies++;
#endif
#if SUPPORT_VJSHARP
			if(!AddAssembly(new Microsoft.VJSharp.VJSharpCodeProvider(), asm, shortpath, getsubdirs, out error))
			{
				if(error != string.Empty)
					return false;
			}
			else
				assemblies++;
#endif
			
			//#endregion

			if(assemblies > 0)
			{
				if(asm.Load(out error) == false)
					return false;
				ScriptAssemblies[path] = asm;
			}
			return true;
		}

		public override void UnloadScripts(string path)
		{
			DirectoryInfo dir = new DirectoryInfo(path);
			if(dir.Exists == false)
				return;
			path = dir.FullName;
			IScriptAssembly asm = (IScriptAssembly)ScriptAssemblies[path];
			if(asm == null)
				return;
			asm.Unload();
			asm = null;
			ScriptAssemblies.Remove(path);
			System.GC.Collect();
		}

		public override void UnloadAllScripts()
		{
			IDictionaryEnumerator e = ScriptAssemblies.GetEnumerator();
			while(e.MoveNext())
			{
				((IScriptAssembly)e.Value).Unload();
			}
			ScriptAssemblies.Clear();
			System.GC.Collect();
		}

		string[] GetFiles(string path, string searchPattern)
		{
			ArrayList files = new ArrayList();
			string[] subDirs;
			try
			{
				subDirs = Directory.GetDirectories(path);
			}
			catch(DirectoryNotFoundException)
			{
				return new string[0];
			}

			foreach(string dir in subDirs)
			{
				files.AddRange(GetFiles(dir, searchPattern));
			}
			string[] list;
			try
			{
				list = Directory.GetFiles(path, searchPattern);
			}
			catch(Exception) // mono fix
			{
				list = new string[0];
			}
			files.AddRange(list);
			string[] ret = new string[files.Count];
			files.CopyTo(ret);
			return ret;
		}

		string[] GetFilesNoSub(string path, string searchPattern)
		{
			return Directory.GetFiles(path, searchPattern);
		}

		private CompilerResults Compile(CodeDomProvider provider, string[] files)
		{
			ICodeCompiler compiler = provider.CreateCompiler();
			return compiler.CompileAssemblyFromFileBatch(m_params, files);
		}

		private void ReportErrors(string path, string file, CompilerResults results, out string error)
		{
			string filename = path;
			if(filename.EndsWith("\\") == false && filename.EndsWith("/") == false)
				filename += "/";
			filename += file;
			StreamWriter stream = new StreamWriter(filename);
			StringEnumerator e = results.Output.GetEnumerator();
			while(e.MoveNext())
			{
				stream.WriteLine(e.Current);
			}
			stream.Close();
			error = "Scripts under " + path + " had errors. Log saved in " + filename;
		}
	}
}
