namespace AuthServer
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
                manager.CloseConnection();
                ServerBase.StartCore();
                new Network().StartServer();
            }
        }
    }
}

