namespace WorldServer
{
    using System;
    using System.Net;

    internal class DatabaseConfig
    {
        public static string Database = "scarab";
        public static IPAddress IP = IPAddress.Parse("127.0.0.1");
        public static string Password = "pass";
        public static int Port = 0xcea;
        public static string Realm_Database = "scarab";
        public static IPAddress Realm_IP = IPAddress.Parse("127.0.0.1");
        public static string Realm_Password = "pass";
        public static int Realm_Port = 0xcea;
        public static string Realm_User = "root";
        public static string User = "root";
    }
}

