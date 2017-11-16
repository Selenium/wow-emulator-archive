namespace Server
{
    using Microsoft.CSharp;
    using Microsoft.VisualBasic;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections;
    using System.IO;
    using System.Reflection;

    public class ScriptCompiler
    {
        // Methods
        static ScriptCompiler()
        {
            ScriptCompiler.m_AdditionalReferences = new ArrayList();
            ScriptCompiler.m_TypeCaches = new Hashtable();
        }

        public ScriptCompiler()
        {
        }

        public static bool Compile()
        {
            return ScriptCompiler.Compile(false);
        }

        public static bool Compile(bool debug)
        {
            int num1;
            ArrayList list1;
            Type[] typeArray1;
            int num2;
            MethodInfo info1;
            int num3;
            Type[] typeArray2;
            int num4;
            MethodInfo info2;
            int num5;
            ScriptCompiler.EnsureDirectory("Scripts/");
            ScriptCompiler.EnsureDirectory("Scripts/Output/");
            ScriptCompiler.DeleteFiles("Scripts.CS*.dll");
            ScriptCompiler.DeleteFiles("Scripts.VB*.dll");
            ScriptCompiler.DeleteFiles("Scripts*.dll");
            if (ScriptCompiler.m_AdditionalReferences.Count > 0)
            {
                ScriptCompiler.m_AdditionalReferences.Clear();
            }
            CompilerResults results1 = null;
            CompilerResults results2 = null;
            results1 = ScriptCompiler.CompileCSScripts(debug);
            if ((results1 == null) || !results1.Errors.HasErrors)
            {
                results2 = ScriptCompiler.CompileVBScripts(debug);
            }
            if ((((results1 == null) || !results1.Errors.HasErrors) && ((results2 == null) || !results2.Errors.HasErrors)) && ((results2 != null) || (results1 != null)))
            {
                num1 = 0;
                if ((results1 == null) || (results2 == null))
                {
                    ScriptCompiler.m_Assemblies = new Assembly[1];
                }
                else
                {
                    ScriptCompiler.m_Assemblies = new Assembly[2];
                }
                if (results1 != null)
                {
                    ScriptCompiler.m_Assemblies[num1++] = results1.CompiledAssembly;
                }
                if (results2 != null)
                {
                    ScriptCompiler.m_Assemblies[num1++] = results2.CompiledAssembly;
                }
                Console.Write("Scripts: Verifying...");
                Core.VerifySerialization();
                Console.WriteLine("done ({0} items, {1} mobiles)", Core.ScriptItems, Core.ScriptMobiles);
                list1 = new ArrayList();
                num1 = 0;
                while ((num1 < ScriptCompiler.m_Assemblies.Length))
                {
                    typeArray1 = ScriptCompiler.m_Assemblies[num1].GetTypes();
                    for (num2 = 0; (num2 < typeArray1.Length); ++num2)
                    {
                        info1 = typeArray1[num2].GetMethod("Configure", (BindingFlags.Public | BindingFlags.Static));
                        if (info1 != null)
                        {
                            list1.Add(info1);
                        }
                    }
                    ++num1;
                }
                list1.Sort(new CallPriorityComparer());
                for (num3 = 0; (num3 < list1.Count); ++num3)
                {
                    ((MethodInfo) list1[num3]).Invoke(null, null);
                }
                list1.Clear();
                World.Load();
                for (num1 = 0; (num1 < ScriptCompiler.m_Assemblies.Length); ++num1)
                {
                    typeArray2 = ScriptCompiler.m_Assemblies[num1].GetTypes();
                    for (num4 = 0; (num4 < typeArray2.Length); ++num4)
                    {
                        info2 = typeArray2[num4].GetMethod("Initialize", (BindingFlags.Public | BindingFlags.Static));
                        if (info2 != null)
                        {
                            list1.Add(info2);
                        }
                    }
                }
                list1.Sort(new CallPriorityComparer());
                for (num5 = 0; (num5 < list1.Count); ++num5)
                {
                    ((MethodInfo) list1[num5]).Invoke(null, null);
                }
                return true;
            }
            return false;
        }

        private static CompilerResults CompileCSScripts()
        {
            return ScriptCompiler.CompileCSScripts(false);
        }

        private static CompilerResults CompileCSScripts(bool debug)
        {
            int num1;
            int num2;
            object[] objArray1;
            CSharpCodeProvider provider1 = new CSharpCodeProvider();
            ICodeCompiler compiler1 = provider1.CreateCompiler();
            Console.Write("Scripts: Compiling C# scripts...");
            string[] textArray1 = ScriptCompiler.GetScripts("*.cs");
            if (textArray1.Length == 0)
            {
                Console.WriteLine("no files found.");
                return null;
            }
            string text1 = ScriptCompiler.GetUnusedPath("Scripts.CS");
            CompilerResults results1 = compiler1.CompileAssemblyFromFileBatch(new CompilerParameters(ScriptCompiler.GetReferenceAssemblies(), text1, debug), textArray1);
            ScriptCompiler.m_AdditionalReferences.Add(text1);
            if (results1.Errors.Count > 0)
            {
                num1 = 0;
                num2 = 0;
                foreach (CompilerError error1 in results1.Errors)
                {
                    if (error1.IsWarning)
                    {
                        ++num2;
                        continue;
                    }
                    ++num1;
                }
                if (num1 > 0)
                {
                    Console.WriteLine("failed ({0} errors, {1} warnings)", num1, num2);
                }
                else
                {
                    Console.WriteLine("done ({0} errors, {1} warnings)", num1, num2);
                }
                foreach (CompilerError error2 in results1.Errors)
                {
                    objArray1 = new object[6];
                    objArray1[0] = (error2.IsWarning ? "Warning" : "Error");
                    objArray1[1] = error2.FileName;
                    objArray1[2] = error2.ErrorNumber;
                    objArray1[3] = error2.Line;
                    objArray1[4] = error2.Column;
                    objArray1[5] = error2.ErrorText;
                    Console.WriteLine(" - {0}: {1}: {2}: (line {3}, column {4}) {5}", objArray1);
                }
                return results1;
            }
            Console.WriteLine("done (0 errors, 0 warnings)");
            return results1;
        }

        private static CompilerResults CompileVBScripts()
        {
            return ScriptCompiler.CompileVBScripts(false);
        }

        private static CompilerResults CompileVBScripts(bool debug)
        {
            int num1;
            int num2;
            object[] objArray1;
            VBCodeProvider provider1 = new VBCodeProvider();
            ICodeCompiler compiler1 = provider1.CreateCompiler();
            Console.Write("Scripts: Compiling VB.net scripts...");
            string[] textArray1 = ScriptCompiler.GetScripts("*.vb");
            if (textArray1.Length == 0)
            {
                Console.WriteLine("no files found.");
                return null;
            }
            string text1 = ScriptCompiler.GetUnusedPath("Scripts.VB");
            CompilerResults results1 = compiler1.CompileAssemblyFromFileBatch(new CompilerParameters(ScriptCompiler.GetReferenceAssemblies(), text1, true), textArray1);
            ScriptCompiler.m_AdditionalReferences.Add(text1);
            if (results1.Errors.Count > 0)
            {
                num1 = 0;
                num2 = 0;
                foreach (CompilerError error1 in results1.Errors)
                {
                    if (error1.IsWarning)
                    {
                        ++num2;
                        continue;
                    }
                    ++num1;
                }
                if (num1 > 0)
                {
                    Console.WriteLine("failed ({0} errors, {1} warnings)", num1, num2);
                }
                else
                {
                    Console.WriteLine("done ({0} errors, {1} warnings)", num1, num2);
                }
                foreach (CompilerError error2 in results1.Errors)
                {
                    objArray1 = new object[6];
                    objArray1[0] = (error2.IsWarning ? "Warning" : "Error");
                    objArray1[1] = error2.FileName;
                    objArray1[2] = error2.ErrorNumber;
                    objArray1[3] = error2.Line;
                    objArray1[4] = error2.Column;
                    objArray1[5] = error2.ErrorText;
                    Console.WriteLine(" - {0}: {1}: {2}: (line {3}, column {4}) {5}", objArray1);
                }
                return results1;
            }
            Console.WriteLine("done (0 errors, 0 warnings)");
            return results1;
        }

        private static void DeleteFiles(string mask)
        {
            string[] textArray1;
            string text1;
            string[] textArray2;
            int num1;
            try
            {
                textArray1 = Directory.GetFiles(Path.Combine(Core.BaseDirectory, "Scripts/Output"), mask);
                textArray2 = textArray1;
                for (num1 = 0; (num1 < textArray2.Length); ++num1)
                {
                    text1 = textArray2[num1];
                    try
                    {
                        File.Delete(text1);
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private static void EnsureDirectory(string dir)
        {
            string text1 = Path.Combine(Core.BaseDirectory, dir);
            if (!Directory.Exists(text1))
            {
                Directory.CreateDirectory(text1);
            }
        }

        public static Type FindTypeByFullName(string fullName)
        {
            return ScriptCompiler.FindTypeByFullName(fullName, true);
        }

        public static Type FindTypeByFullName(string fullName, bool ignoreCase)
        {
            int num1;
            Type type1 = null;
            for (num1 = 0; ((type1 == null) && (num1 < ScriptCompiler.m_Assemblies.Length)); ++num1)
            {
                type1 = ScriptCompiler.GetTypeCache(ScriptCompiler.m_Assemblies[num1]).GetTypeByFullName(fullName, ignoreCase);
            }
            if (type1 == null)
            {
                type1 = ScriptCompiler.GetTypeCache(Core.Assembly).GetTypeByFullName(fullName, ignoreCase);
            }
            return type1;
        }

        public static Type FindTypeByName(string name)
        {
            return ScriptCompiler.FindTypeByName(name, true);
        }

        public static Type FindTypeByName(string name, bool ignoreCase)
        {
            int num1;
            Type type1 = null;
            for (num1 = 0; ((type1 == null) && (num1 < ScriptCompiler.m_Assemblies.Length)); ++num1)
            {
                type1 = ScriptCompiler.GetTypeCache(ScriptCompiler.m_Assemblies[num1]).GetTypeByName(name, ignoreCase);
            }
            if (type1 == null)
            {
                type1 = ScriptCompiler.GetTypeCache(Core.Assembly).GetTypeByName(name, ignoreCase);
            }
            return type1;
        }

        public static string[] GetReferenceAssemblies()
        {
            string text2;
            ArrayList list1 = new ArrayList();
            string text1 = Path.Combine(Core.BaseDirectory, "Data/Assemblies.cfg");
            if (File.Exists(text1))
            {
                using (StreamReader reader1 = new StreamReader(text1))
                {
                    while (((text2 = reader1.ReadLine()) != null))
                    {
                        if ((text2.Length <= 0) || text2.StartsWith("#"))
                        {
                            continue;
                        }
                        list1.Add(text2);
                    }
                }
            }
            list1.Add(Core.ExePath);
            list1.AddRange(ScriptCompiler.m_AdditionalReferences);
            return ((string[]) list1.ToArray(typeof(string)));
        }

        private static string[] GetScripts(string type)
        {
            ArrayList list1 = new ArrayList();
            ScriptCompiler.GetScripts(list1, Path.Combine(Core.BaseDirectory, "Scripts"), type);
            return ((string[]) list1.ToArray(typeof(string)));
        }

        private static void GetScripts(ArrayList list, string path, string type)
        {
            string text1;
            int num1;
            string[] textArray1 = Directory.GetDirectories(path);
            for (num1 = 0; (num1 < textArray1.Length); ++num1)
            {
                text1 = textArray1[num1];
                ScriptCompiler.GetScripts(list, text1, type);
            }
            list.AddRange(Directory.GetFiles(path, type));
        }

        public static TypeCache GetTypeCache(Assembly asm)
        {
            if (asm == null)
            {
                if (ScriptCompiler.m_NullCache == null)
                {
                    ScriptCompiler.m_NullCache = new TypeCache(null);
                }
                return ScriptCompiler.m_NullCache;
            }
            TypeCache cache1 = ((TypeCache) ScriptCompiler.m_TypeCaches[asm]);
            if (cache1 == null)
            {
                ScriptCompiler.m_TypeCaches[asm] = (cache1 = new TypeCache(asm));
            }
            return cache1;
        }

        private static string GetUnusedPath(string name)
        {
            int num1;
            string text1 = Path.Combine(Core.BaseDirectory, string.Format("Scripts/Output/{0}.dll", name));
            for (num1 = 2; (File.Exists(text1) && (num1 <= 1000)); ++num1)
            {
                text1 = Path.Combine(Core.BaseDirectory, string.Format("Scripts/Output/{0}.{1}.dll", name, num1));
            }
            return text1;
        }


        // Properties
        public static Assembly[] Assemblies
        {
            get
            {
                return ScriptCompiler.m_Assemblies;
            }
            set
            {
                ScriptCompiler.m_Assemblies = value;
            }
        }


        // Fields
        private static ArrayList m_AdditionalReferences;
        private static Assembly[] m_Assemblies;
        private static TypeCache m_NullCache;
        private static Hashtable m_TypeCaches;
    }
}

