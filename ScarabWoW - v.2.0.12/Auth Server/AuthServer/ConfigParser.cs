namespace AuthServer
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
                writer.WriteLine("//address of realm server");
                writer.WriteLine("//ip:port");
                writer.WriteLine("host=127.0.0.1:3724");
                writer.WriteLine("");
                writer.WriteLine("//mysql connection");
                writer.WriteLine("//ip:port:user:password:database");
                writer.WriteLine("database=127.0.0.1:3306:scarab:pass:scarabrealms");
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
                        string[] strArray2 = str.ToLower().Split(new char[] { '=' })[1].Split(new char[] { ':' });
                        if (strArray2.Length >= 5)
                        {
                            DatabaseConfig.IP = IPAddress.Parse(strArray2[0]);
                            DatabaseConfig.Port = int.Parse(strArray2[1]);
                            DatabaseConfig.User = strArray2[2];
                            DatabaseConfig.Password = strArray2[3];
                            DatabaseConfig.Database = strArray2[4];
                        }
                    }
                }
            }
        }
    }
}

