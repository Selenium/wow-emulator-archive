namespace WorldServer
{
    using System;
    using System.IO;
    using System.Net;

    internal class ConfigParser
    {
        public static void LoadConfig()
        {
            if (!System.IO.File.Exists("config.cfg"))
            {
                StreamWriter writer = new StreamWriter("config.cfg");
                writer.WriteLine("//address of world server");
                writer.WriteLine("//ip:port");
                writer.WriteLine("host=127.0.0.1:8085");
                writer.WriteLine("");
                writer.WriteLine("//mysql connection");
                writer.WriteLine("//ip:port:user:password:database");
                writer.WriteLine("database=127.0.0.1:3306:scarab:pass:scarabworld");
                writer.WriteLine("");
                writer.WriteLine("//mysql connection for realmlist server");
                writer.WriteLine("//ip:port:user:password:database");
                writer.WriteLine("realmdatabase=127.0.0.1:3306:scarab:pass:scarabrealms");
                writer.WriteLine("");
                writer.WriteLine("//realm ID (same as in realm database)");
                writer.WriteLine("realmid=1");
                writer.Close();
                LoadConfig();
                Console.WriteLine("Config file not found\nFile was created with default options");
            }
            else
            {
                string str;
                StreamReader reader = System.IO.File.OpenText("config.cfg");
                while ((str = reader.ReadLine()) != null)
                {
                    string[] strArray2;
                    if (str.ToLower().StartsWith("host="))
                    {
                        string[] strArray = str.ToLower().Split(new char[] { '=' })[1].Split(new char[] { ':' });
                        if (strArray.Length < 2)
                        {
                            continue;
                        }
                        NetworkConfg.IP = IPAddress.Parse(strArray[0]);
                        NetworkConfg.Port = int.Parse(strArray[1]);
                    }
                    if (str.ToLower().StartsWith("database="))
                    {
                        strArray2 = str.ToLower().Split(new char[] { '=' })[1].Split(new char[] { ':' });
                        if (strArray2.Length < 5)
                        {
                            continue;
                        }
                        DatabaseConfig.IP = IPAddress.Parse(strArray2[0]);
                        DatabaseConfig.Port = int.Parse(strArray2[1]);
                        DatabaseConfig.User = strArray2[2];
                        DatabaseConfig.Password = strArray2[3];
                        DatabaseConfig.Database = strArray2[4];
                    }
                    if (str.ToLower().StartsWith("realmid="))
                    {
                        StaticCore.RealmID = int.Parse(str.ToLower().Split(new char[] { '=' })[1]);
                    }
                    if (str.ToLower().StartsWith("realmdatabase="))
                    {
                        strArray2 = str.ToLower().Split(new char[] { '=' })[1].Split(new char[] { ':' });
                        if (strArray2.Length >= 5)
                        {
                            DatabaseConfig.Realm_IP = IPAddress.Parse(strArray2[0]);
                            DatabaseConfig.Realm_Port = int.Parse(strArray2[1]);
                            DatabaseConfig.Realm_User = strArray2[2];
                            DatabaseConfig.Realm_Password = strArray2[3];
                            DatabaseConfig.Realm_Database = strArray2[4];
                        }
                    }
                }
            }
        }
    }
}

