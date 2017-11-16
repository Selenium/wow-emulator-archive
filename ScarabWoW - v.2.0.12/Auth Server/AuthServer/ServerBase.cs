namespace AuthServer
{
    using System;
    using System.Collections;
    using System.Threading;

    internal class ServerBase
    {
        public static ArrayList AuthCores = new ArrayList();
        public static ArrayList AuthCoreThreads = new ArrayList();
        public static bool AuthServerRunning = true;

        public static void StartCore()
        {
            Core core = new Core();
            AuthCores.Add(core);
            Thread thread = new Thread(new ThreadStart(core.Run));
            thread.Start();
            AuthCoreThreads.Add(thread);
            DatabaseManager manager = new DatabaseManager();
            manager.Connect(DatabaseConfig.IP.ToString(), DatabaseConfig.Port, DatabaseConfig.Database, DatabaseConfig.User, DatabaseConfig.Password);
            manager.Write("UPDATE accounts SET online=0");
            manager.CloseConnection();
        }
    }
}

