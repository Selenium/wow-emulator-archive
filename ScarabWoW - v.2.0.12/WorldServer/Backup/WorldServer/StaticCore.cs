namespace WorldServer
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections;

    internal class StaticCore
    {
        public static Hashtable PlayerPositions = new Hashtable();
        private static MySqlDataReader Reader;
        public static DatabaseManager RealmDbManager = new DatabaseManager();
        public static int RealmID = 0;
        public static byte RealmType = 1;

        public static void Connect()
        {
            RealmDbManager.Connect(DatabaseConfig.Realm_IP.ToString(), DatabaseConfig.Realm_Port, DatabaseConfig.Realm_Database, DatabaseConfig.Realm_User, DatabaseConfig.Realm_Password);
        }

        public static void GetRealmType()
        {
            Reader = RealmDbManager.Read("SELECT type FROM realms WHERE id='" + RealmID.ToString() + "'");
            Reader.Read();
            RealmType = Reader.GetByte(0);
            Reader.Close();
        }

        public static void SetAccountsOutWorld()
        {
            RealmDbManager.Write("UPDATE accounts SET inworld=0 WHERE lastrealmid='" + RealmID.ToString() + "'");
        }

        public static void ZeroRealmPlayers()
        {
            RealmDbManager.Write("UPDATE realms SET onlineplayers=0 WHERE id='" + RealmID.ToString() + "'");
        }
    }
}

