/*
 * Copyright (C) 2006 by pAbLoPiCaSsO and Blumster
 *
 * This program is not free. You may not redistribute it. There will be no
 * warranty for this product.
 */

using System;
using System.IO;
using System.Collections;
using System.Reflection;
using Microsoft.CSharp;
using System.CodeDom.Compiler;

namespace Server
{
    class DllBuilder
    {
        static public HelperTools.AssemblyList externAsm = new HelperTools.AssemblyList();
        static DateTime sourcesCodeCRC;
        static bool sourcesCodeDirty;

        public static ArrayList BuildSources(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files;
            DirectoryInfo[] dirs;
            ArrayList fileNames = new ArrayList();

            dirs = dir.GetDirectories("*");
            foreach (DirectoryInfo di in dirs)
            {
                ArrayList ret = BuildSources(path + "/" + di.Name);
                foreach (object o in ret)
                {
                    if (di.LastWriteTime > sourcesCodeCRC)
                    {
                        sourcesCodeDirty = true;
                        sourcesCodeCRC = di.LastWriteTime;
                    }
                    fileNames.Add(o);
                }
            }

            files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                if (file.Extension.EndsWith(".cs"))
                {
                    if (file.LastWriteTime > sourcesCodeCRC)
                    {
                        sourcesCodeDirty = true;
                        sourcesCodeCRC = file.LastWriteTime;
                    }
                    fileNames.Add(file.FullName);
                }
                else
                    if (file.Extension.EndsWith(".cod"))
                    {
                    }
            }
            return fileNames;
        }

        public static int BuildDll(string path, string[] refs)
        {
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            ICodeCompiler compiler = codeProvider.CreateCompiler();
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = false;
            parameters.GenerateInMemory = true;
            parameters.MainClass = "";
            sourcesCodeDirty = false;
            World.Path = AppDomain.CurrentDomain.BaseDirectory;
            string[] fs = path.Split(new char[] { '/' });
            string dllName = fs[fs.Length - 1];
            parameters.OutputAssembly = World.Path + dllName + ".dll";
            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (asm.Location != "")
                {
                    // Console.WriteLine( "Reference {0}", asm.Location );
                    parameters.ReferencedAssemblies.Add(asm.Location);
                }
            }


            if (refs != null)
            {
                DateTime dllDate = DateTime.Now;
                if (File.Exists(parameters.OutputAssembly))
                    dllDate = File.GetLastWriteTime(parameters.OutputAssembly);
                else
                    sourcesCodeDirty = true;
                foreach (string refer in refs)
                {
                    string r = World.Path + refer + ".dll";
                    if (!sourcesCodeDirty && dllDate.CompareTo(File.GetLastWriteTime(r)) < 0)
                        sourcesCodeDirty = true;
                    parameters.ReferencedAssemblies.Add(r);
                    // Console.WriteLine("Add reference {0}", r );
                }
            }
            parameters.IncludeDebugInformation = false;
            ArrayList files = null;
            parameters.WarningLevel = 4;
            parameters.TreatWarningsAsErrors = false;

            if (!sourcesCodeDirty && File.Exists(parameters.OutputAssembly))
            {
                sourcesCodeCRC = File.GetLastWriteTime(parameters.OutputAssembly);

            }
            else
                sourcesCodeDirty = true;
            files = BuildSources(path);
            if (!sourcesCodeDirty)
            {
                externAsm[dllName] = Assembly.LoadFile(parameters.OutputAssembly);
                return 1;
            }
            string[] filenames = (string[])files.ToArray(typeof(string));
            CompilerResults results = compiler.CompileAssemblyFromFileBatch(parameters, filenames);

            if (results.Errors.Count > 0)
            {
                string errors = "Compilation failed:\n";
                foreach (CompilerError err in results.Errors)
                {
                    errors += err.ToString() + "\n";
                }
                Console.WriteLine(errors);
                throw (new Exception(errors));
            }
            externAsm[dllName] = results.CompiledAssembly;
            return 2;
        }
    }
}