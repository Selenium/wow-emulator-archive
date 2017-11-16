namespace WorldServer
{
    using System;

    internal class Program
    {
        private static void Main()
        {
            ConfigParser.LoadConfig();
            DatabaseManager manager = new DatabaseManager();
            if (!manager.Connect(DatabaseConfig.IP.ToString(), DatabaseConfig.Port, DatabaseConfig.Database, DatabaseConfig.User, DatabaseConfig.Password))
            {
                Console.WriteLine("Could not connect to MySql database");
                Console.ReadKey();
            }
            else
            {
                manager = new DatabaseManager();
                if (!manager.Connect(DatabaseConfig.Realm_IP.ToString(), DatabaseConfig.Realm_Port, DatabaseConfig.Realm_Database, DatabaseConfig.Realm_User, DatabaseConfig.Realm_Password))
                {
                    Console.WriteLine("Could not connect to MySql database(realm)");
                    Console.ReadKey();
                }
                else
                {
                    manager.CloseConnection();
                    StaticCore.Connect();
                    StaticCore.GetRealmType();
                    StaticCore.SetAccountsOutWorld();
                    StaticCore.ZeroRealmPlayers();
                    ServerBase.StartCore();
                    new Network().StartServer();
                }
            }
        }
    }
}

