namespace AuthServer
{
    using System;
    using System.Net;

    internal class DatabaseConfig
    {
        public static string Database = "scarab";
        public static IPAddress IP = IPAddress.Parse("127.0.0.1");
        public static string Password = "pass";
        public static int Port = 0xcea;
        public static string User = "root";
    }
}

