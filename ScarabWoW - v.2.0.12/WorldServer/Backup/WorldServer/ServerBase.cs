namespace WorldServer
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
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                Core core = new Core();
                core.CoreID = i;
                AuthCores.Add(core);
                Thread thread = new Thread(new ThreadStart(core.Run));
                thread.Start();
                AuthCoreThreads.Add(thread);
            }
        }
    }
}

