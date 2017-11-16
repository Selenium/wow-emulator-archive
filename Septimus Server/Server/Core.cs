namespace Server
{
    using Server.Network;
    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Threading;

    public class Core
    {
        // Methods
        static Core()
        {
            Core.m_DataDirectories = new ArrayList();
            Core.m_GlobalMaxUpdateRange = 24;
        }

        public Core()
        {
        }

        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            Core.HandleClosed();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            CrashedEventArgs args1;
            Console.WriteLine((e.IsTerminating ? "Error:" : "Warning:"));
            Console.WriteLine(e.ExceptionObject);
            if (!e.IsTerminating)
            {
                return;
            }
            Core.m_Crashed = true;
            bool flag1 = false;
            try
            {
                args1 = new CrashedEventArgs((e.ExceptionObject as Exception));
                EventSink.InvokeCrashed(args1);
                flag1 = args1.Close;
            }
            catch
            {
            }
            if (!flag1 && !Core.m_Service)
            {
                Console.WriteLine("This exception is fatal, press return to exit");
                Console.ReadLine();
            }
        }

        public static string FindDataFile(string path)
        {
            int num1;
            if (Core.m_DataDirectories.Count == 0)
            {
                throw new InvalidOperationException("Attempted to FindDataFile before DataDirectories list has been filled.");
            }
            string text1 = null;
            for (num1 = 0; (num1 < Core.m_DataDirectories.Count); ++num1)
            {
                text1 = Path.Combine(((string) Core.m_DataDirectories[num1]), path);
                if (File.Exists(text1))
                {
                    return text1;
                }
                text1 = null;
            }
            return text1;
        }

        public static string FindDataFile(string format, params object[] args)
        {
            return Core.FindDataFile(string.Format(format, args));
        }

        private static void HandleClosed()
        {
            if (Core.m_Closing)
            {
                return;
            }
            Core.m_Closing = true;
            Console.Write("Exiting...");
            if (!Core.m_Crashed)
            {
                EventSink.InvokeShutdown(new ShutdownEventArgs());
            }
            Core.timerThread.Join();
            Console.WriteLine("done");
        }

        [STAThread]
        public static void Main(string[] args)
        {
            int num1;
            string text1;
            int num2;
            TextWriter[] writerArray1;
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Core.CurrentDomain_UnhandledException);
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(Core.CurrentDomain_ProcessExit);
            bool flag1 = false;
            for (num1 = 0; (num1 < args.Length); ++num1)
            {
                if (Insensitive.Equals(args[num1], "-debug"))
                {
                    flag1 = true;
                }
                else if (Insensitive.Equals(args[num1], "-service"))
                {
                    Core.m_Service = true;
                }
                else if (Insensitive.Equals(args[num1], "-profile"))
                {
                    Core.Profiling = true;
                }
            }
            try
            {
                if (Core.m_Service)
                {
                    if (!Directory.Exists("Logs"))
                    {
                        Directory.CreateDirectory("Logs");
                    }
                    writerArray1 = new TextWriter[2];
                    writerArray1[0] = Console.Out;
                    writerArray1[1] = new FileLogger("Logs/Console.log");
                    Console.SetOut((Core.m_MultiConOut = new MultiTextWriter(writerArray1)));
                }
                else
                {
                    writerArray1 = new TextWriter[1];
                    writerArray1[0] = Console.Out;
                    Console.SetOut((Core.m_MultiConOut = new MultiTextWriter(writerArray1)));
                }
            }
            catch
            {
            }
            Core.m_Thread = Thread.CurrentThread;
            Core.m_Process = Process.GetCurrentProcess();
            Core.m_Assembly = Assembly.GetEntryAssembly();
            if (Core.m_Thread != null)
            {
                Core.m_Thread.Name = "Core Thread";
            }
            if (Core.BaseDirectory.Length > 0)
            {
                Directory.SetCurrentDirectory(Core.BaseDirectory);
            }
            Server.Timer.TimerThread thread1 = new Server.Timer.TimerThread();
            Core.timerThread = new Thread(new ThreadStart(thread1.TimerMain));
            Core.timerThread.Name = "Timer Thread";
            while (!ScriptCompiler.Compile(flag1))
            {
                Console.WriteLine("Scripts: One or more scripts failed to compile or no script files were found.");
                Console.WriteLine(" - Press return to exit, or R to try again.");
                text1 = Console.ReadLine();
                if ((text1 == null) || (text1.ToLower() != "r"))
                {
                    return;
                }
            }
            Region.Load();
            Core.m_MessagePump = new MessagePump(new Listener(Listener.Port));
            Core.timerThread.Start();
            for (num2 = 0; (num2 < Map.AllMaps.Count); ++num2)
            {
                ((Map) Map.AllMaps[num2]).Tiles.Force();
            }
            NetState.Initialize();
            EventSink.InvokeServerStarted();
            try
            {
                while (!Core.m_Closing)
                {
                    Thread.Sleep(1);
                    Mobile.ProcessDeltaQueue();
                    Item.ProcessDeltaQueue();
                    Server.Timer.Slice();
                    Core.m_MessagePump.Slice();
                    NetState.ProcessDisposedQueue();
                    if (Core.Slice != null)
                    {
                        Core.Slice.Invoke();
                    }
                }
            }
            catch (Exception exception1)
            {
                Core.CurrentDomain_UnhandledException(null, new UnhandledExceptionEventArgs(exception1, true));
            }
            if (Core.timerThread.IsAlive)
            {
                Core.timerThread.Abort();
            }
        }

        public static void VerifySerialization()
        {
            int num1;
            Core.m_ItemCount = 0;
            Core.m_MobileCount = 0;
            Core.VerifySerialization(Assembly.GetCallingAssembly());
            for (num1 = 0; (num1 < ScriptCompiler.Assemblies.Length); ++num1)
            {
                Core.VerifySerialization(ScriptCompiler.Assemblies[num1]);
            }
        }

        private static void VerifySerialization(Assembly a)
        {
            Type type1;
            bool flag1;
            bool flag2;
            int num1;
            if (a == null)
            {
                return;
            }
            Type[] typeArray2 = new Type[1];
            typeArray2[0] = typeof(Serial);
            Type[] typeArray1 = typeArray2;
            typeArray2 = a.GetTypes();
            for (num1 = 0; (num1 < typeArray2.Length); ++num1)
            {
                type1 = typeArray2[num1];
                flag1 = type1.IsSubclassOf(typeof(Item));
                if (flag1 || type1.IsSubclassOf(typeof(Mobile)))
                {
                    if (flag1)
                    {
                        ++Core.m_ItemCount;
                    }
                    else
                    {
                        ++Core.m_MobileCount;
                    }
                    flag2 = false;
                    try
                    {
                        if (type1.GetConstructor(typeArray1) == null)
                        {
                            if (!flag2)
                            {
                                Console.WriteLine("Warning: {0}", type1);
                            }
                            flag2 = true;
                            Console.WriteLine("       - No serialization constructor");
                        }
                        if (type1.GetMethod("Serialize", (BindingFlags.NonPublic | (BindingFlags.Public | (BindingFlags.Instance | BindingFlags.DeclaredOnly)))) == null)
                        {
                            if (!flag2)
                            {
                                Console.WriteLine("Warning: {0}", type1);
                            }
                            flag2 = true;
                            Console.WriteLine("       - No Serialize() method");
                        }
                        if (type1.GetMethod("Deserialize", (BindingFlags.NonPublic | (BindingFlags.Public | (BindingFlags.Instance | BindingFlags.DeclaredOnly)))) == null)
                        {
                            if (!flag2)
                            {
                                Console.WriteLine("Warning: {0}", type1);
                            }
                            flag2 = true;
                            Console.WriteLine("       - No Deserialize() method");
                        }
                        if (flag2)
                        {
                            Console.WriteLine();
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }


        // Properties
        public static bool AOS
        {
            get
            {
                return Core.m_AOS;
            }
            set
            {
                Core.m_AOS = value;
            }
        }

        public static Assembly Assembly
        {
            get
            {
                return Core.m_Assembly;
            }
            set
            {
                Core.m_Assembly = value;
            }
        }

        public static string BaseDirectory
        {
            get
            {
                if (Core.m_BaseDirectory == null)
                {
                    try
                    {
                        Core.m_BaseDirectory = Core.ExePath;
                        if (Core.m_BaseDirectory.Length > 0)
                        {
                            Core.m_BaseDirectory = Path.GetDirectoryName(Core.m_BaseDirectory);
                        }
                    }
                    catch
                    {
                        Core.m_BaseDirectory = "";
                    }
                }
                return Core.m_BaseDirectory;
            }
        }

        public static bool Closing
        {
            get
            {
                return Core.m_Closing;
            }
            set
            {
                Core.m_Closing = value;
            }
        }

        public static ArrayList DataDirectories
        {
            get
            {
                return Core.m_DataDirectories;
            }
        }

        public static string ExePath
        {
            get
            {
                if (Core.m_ExePath == null)
                {
                    Core.m_ExePath = Process.GetCurrentProcess().MainModule.FileName;
                }
                return Core.m_ExePath;
            }
        }

        public static int GlobalMaxUpdateRange
        {
            get
            {
                return Core.m_GlobalMaxUpdateRange;
            }
            set
            {
                Core.m_GlobalMaxUpdateRange = value;
            }
        }

        public static MessagePump MessagePump
        {
            get
            {
                return Core.m_MessagePump;
            }
            set
            {
                Core.m_MessagePump = value;
            }
        }

        public static MultiTextWriter MultiConsoleOut
        {
            get
            {
                return Core.m_MultiConOut;
            }
        }

        public static Process Process
        {
            get
            {
                return Core.m_Process;
            }
        }

        public static TimeSpan ProfileTime
        {
            get
            {
                if (Core.m_ProfileStart > DateTime.MinValue)
                {
                    return (Core.m_ProfileTime + (DateTime.Now - Core.m_ProfileStart));
                }
                return Core.m_ProfileTime;
            }
        }

        public static bool Profiling
        {
            get
            {
                return Core.m_Profiling;
            }
            set
            {
                if (Core.m_Profiling == value)
                {
                    return;
                }
                Core.m_Profiling = value;
                if (Core.m_ProfileStart > DateTime.MinValue)
                {
                    Core.m_ProfileTime += (DateTime.Now - Core.m_ProfileStart);
                }
                Core.m_ProfileStart = (Core.m_Profiling ? DateTime.Now : DateTime.MinValue);
            }
        }

        public static int ScriptItems
        {
            get
            {
                return Core.m_ItemCount;
            }
        }

        public static int ScriptMobiles
        {
            get
            {
                return Core.m_MobileCount;
            }
        }

        public static bool Service
        {
            get
            {
                return Core.m_Service;
            }
        }

        public static Thread Thread
        {
            get
            {
                return Core.m_Thread;
            }
        }


        // Fields
        private static bool m_AOS;
        private static Assembly m_Assembly;
        private static string m_BaseDirectory;
        private static bool m_Closing;
        private static bool m_Crashed;
        private static ArrayList m_DataDirectories;
        private static string m_ExePath;
        private static int m_GlobalMaxUpdateRange;
        private static int m_ItemCount;
        private static MessagePump m_MessagePump;
        private static int m_MobileCount;
        private static MultiTextWriter m_MultiConOut;
        private static Process m_Process;
        private static DateTime m_ProfileStart;
        private static TimeSpan m_ProfileTime;
        private static bool m_Profiling;
        private static bool m_Service;
        private static Thread m_Thread;
        public static Slice Slice;
        private static Thread timerThread;
    }
}

