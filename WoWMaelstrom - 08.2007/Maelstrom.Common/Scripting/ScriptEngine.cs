using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.Collections;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

namespace Maelstrom
{
	public sealed class ScriptEngine
	{
		private Assembly m_ScriptAssembly;
		private ArrayList m_Filenames = new ArrayList();
		private ConfigEngine m_ConfigEngine;

		#region GetScriptType

		private Type GetScriptType(string Name)
		{
			if (m_ScriptAssembly != null)
			{
				Type ScriptType = m_ScriptAssembly.GetType(Name,false,false);
				if (ScriptType != null)
				{
					if (CheckType(ScriptType))
					{
						return ScriptType;
					}
				}
			}

			return null;
		}

		#endregion

		#region Create

		/// <summary>
		/// Constructs a new instance of a script class with the given name.
		/// </summary>
		/// <param name="ScriptName">The class name of the script to create an instance of.</param>
		/// <returns>An instance of the given script, or null if the script is invalid.</returns>
		public IScript Create(string ScriptName)
		{
			return Create(ScriptName,new object[0]);
		}

		/// <summary>
		/// Constructs a new instance of a script class with the given name and parameters.
		/// </summary>
		/// <param name="ScriptName">The class name of the script to create an instance of.</param>
		/// <param name="Parameters">The parameters for the constructor to the class.</param>
		/// <returns>An instance of the given script, or null if the script or parameters are invalid.</returns>
		public IScript Create(string ScriptName, params object[] Parameters)
		{
			Type ScriptType = GetScriptType(ScriptName);
			if (ScriptType != null)
			{
				Type[] ParamTypes = new Type[Parameters.Length];
				for(int i=0;i<=Parameters.Length-1;i++)
				{
					ParamTypes[i] = Parameters[i].GetType();
				}
				
				ConstructorInfo Constructor = ScriptType.GetConstructor(ParamTypes);
				if (Constructor != null)
				{
					return (IScript)Constructor.Invoke(Parameters);
				}
			}

			return null;
		}

		#endregion
		#region ExecuteStaticMethod

		public object ExecuteStaticMethod(string ScriptName, string MethodName)
		{
			return ExecuteStaticMethod(ScriptName,MethodName,new object[0]);
		}

		public object ExecuteStaticMethod(string ScriptName, string MethodName, params object[] Parameters)
		{
			Type ScriptType = GetScriptType(ScriptName);
			if (ScriptType != null)
			{
				Type[] ParamTypes = new Type[Parameters.Length];
				for(int i=0;i<=Parameters.Length-1;i++)
				{
					ParamTypes[i] = Parameters[i].GetType();
				}

				MethodInfo Method = ScriptType.GetMethod(MethodName,BindingFlags.Public | BindingFlags.Static,null,ParamTypes,null);
				if (Method != null)
				{
					return Method.Invoke(null,Parameters);
				}
			}

			return null;
		}

		#endregion

		#region Compile

		private CompilerResults Compile()
		{
			CSharpCodeProvider Provider = new CSharpCodeProvider();
			ICodeCompiler Compiler = Provider.CreateCompiler();

			CompilerParameters Parameters = new CompilerParameters();
			Parameters.GenerateInMemory = true;
			Parameters.GenerateExecutable = false;
			Parameters.OutputAssembly = "";

			Parameters.ReferencedAssemblies.Add("System.DLL");
			Parameters.ReferencedAssemblies.Add("System.Data.DLL");
			Parameters.ReferencedAssemblies.Add("System.Drawing.DLL");
			Parameters.ReferencedAssemblies.Add("System.XML.DLL");

			//Add references to all the Maelstrom libraries (this allows scripts to have access to all these libraries if they need).
			Parameters.ReferencedAssemblies.Add("Maelstrom.Common.DLL");
			Parameters.ReferencedAssemblies.Add("Maelstrom.ClientHandlerServer.DLL");
			Parameters.ReferencedAssemblies.Add("Maelstrom.ObjectServer.DLL");
			Parameters.ReferencedAssemblies.Add("Maelstrom.RedirectServer.DLL");
			Parameters.ReferencedAssemblies.Add("Maelstrom.RealmListServer.DLL");
			Parameters.ReferencedAssemblies.Add("Maelstrom.WorldServer.DLL");

			string[] Filenames = new string[m_Filenames.Count];
			m_Filenames.CopyTo(Filenames);

			CompilerResults CompileResult = Compiler.CompileAssemblyFromFileBatch(Parameters,Filenames);

			if (!CompileResult.Errors.HasErrors)
			{
				m_ScriptAssembly = CompileResult.CompiledAssembly;
			}

			return CompileResult;
		}

		#endregion
		#region InitializeScripts

		/// <summary>
		/// Initializes all scripts within the scripting engine.
		/// </summary>
		public void InitializeScripts()
		{
			//TODO: Add the ability to prioritize initialization through an attribute on the method.
			if (m_ScriptAssembly != null)
			{
				Type[] ScriptTypes = m_ScriptAssembly.GetTypes();
				foreach(Type ScriptType in ScriptTypes)
				{
					ExecuteStaticMethod(ScriptType.FullName,"Initialize");
				}
			}
		}

		#endregion
		#region CheckType

		private bool CheckType(Type Type)
		{
			Type[] Interfaces = Type.GetInterfaces();
			foreach(Type Interface in Interfaces)
			{
				//We only have access to classes that implement the IScript interface.
				if (Interface.Equals(typeof(IScript)))
				{
					return true;
				}
			}

			return false;
		}

		#endregion
		
		#region LoadPackage

		private uint LoadPackage(string Filename)
		{
			string PackagePath = Path.GetDirectoryName(Filename);

			ConfigFile PackageConfig = m_ConfigEngine.LoadFile(Filename);
			ConfigElement[] PackageElements = PackageConfig["package"];

			Console.WriteLine("  [{0}] : {1}",PackageElements[0].GetString("id"),PackageElements[0].GetString("name"));
			Console.WriteLine("  - Path: {0}",PackagePath);
			Console.WriteLine();

			ConfigElement[] FileGroups = PackageElements[0].GetSubElements("files");
			if (FileGroups.Length > 0)
			{
				ConfigElement[] PackageFiles = FileGroups[0].GetSubElements("file");
				foreach(ConfigElement PackageFile in PackageFiles)
				{
					string PackageFilename = PackageFile.GetString("file_Column");
					string PackageFilePath = Path.Combine(PackagePath,PackageFilename);

					if (!m_Filenames.Contains(PackageFilePath))
					{
						m_Filenames.Add(PackageFilePath);
					}
					else
					{
						Console.WriteLine("   Note: File \"{0}\" has already been declared in a previous package.",PackageFilePath);
					}
				}

				return (uint)PackageFiles.Length;
			}

			return 0;
		}

		#endregion

		public ScriptEngine(ConfigEngine ConfigEngine, string[] PathList)
		{
			Console.WriteLine("* Loading Server Script packages:\n");
			m_ConfigEngine = ConfigEngine;

			#region Loading of Package List

			ArrayList PackageList = new ArrayList();
			foreach(string Path in PathList)
			{
				string[] TempFiles = Utilities.FindFiles(Path,"Package.xml",true);

				foreach(string File in TempFiles)
				{
					//We don't want duplicate files.
					if (!PackageList.Contains(File))
					{
						PackageList.Add(File);
					}
				}
			}

			#endregion
			
			uint ScriptCount = 0;
			#region Loading of Packages in Package List
			
			foreach(string Package in PackageList)
			{
				ScriptCount += LoadPackage(Package);
			}

			#endregion

			if (ScriptCount > 0)
			{
				#region Script Compilation

				Console.WriteLine("  {0} Packages loaded containing {1} source files, compiling...",PackageList.Count,ScriptCount);
				CompilerResults Result = Compile();

				int ErrorCount = 0;
				int WarningCount = 0;
				foreach(CompilerError Error in Result.Errors)
				{
					if (!Error.IsWarning)
					{
						ErrorCount++;
					}
					else
					{
						WarningCount++;
					}
				}

				if (ErrorCount > 0)
				{
					Console.WriteLine("  [Compilation failed, errors: {0}, warnings: {1}]",ErrorCount,WarningCount);

					StringBuilder ErrorString = new StringBuilder();
					ErrorString.Append("One or more errors or warnings occured during the script compilation process, please rectify them and restart Maelstrom:\n\n");
					
					foreach (CompilerError Error in Result.Errors)
					{
						if (!Error.IsWarning)
						{
							if (Error.FileName == "")
							{
								ErrorString.Append("File: Server Core\n");
							}
							else
							{
								ErrorString.Append("File: "+Error.FileName+"\n");
								ErrorString.Append("Location: "+Error.Column+", "+Error.Line+"\n");
							}
						
							ErrorString.Append("Error: "+Error.ErrorText+"\n");
						}
					}

					throw new Exception(ErrorString.ToString());
				}
				else
				{
					Console.WriteLine("  [Compilation completed successfully, warnings: {0}]",WarningCount);
				}

				#endregion
			}
			else
			{
				Console.WriteLine("  {0} Packages loaded containing no scripts.",PackageList.Count);
			}
		}
	}
}
