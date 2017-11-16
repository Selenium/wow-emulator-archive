namespace Server
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Net;

    public class Firewall
    {
        // Methods
        static Firewall()
        {
            string text2;
            object obj1;
            Firewall.m_Blocked = new ArrayList();
            string text1 = "firewall.cfg";
            if (File.Exists(text1))
            {
                using (StreamReader reader1 = new StreamReader(text1))
                {
                    while (((text2 = reader1.ReadLine()) != null))
                    {
                        text2 = text2.Trim();
                        if (text2.Length != 0)
                        {
                            try
                            {
                                obj1 = IPAddress.Parse(text2);
                            }
                            catch
                            {
                                obj1 = text2;
                            }
                            Firewall.m_Blocked.Add(obj1.ToString());
                        }
                    }
                    return;
                }
            }
        }

        public Firewall()
        {
        }

        public static void Add(IPAddress ip)
        {
            if (!Firewall.m_Blocked.Contains(ip))
            {
                Firewall.m_Blocked.Add(ip);
            }
            Firewall.Save();
        }

        public static void Add(object obj)
        {
            if (!(obj is IPAddress) && !(obj is string))
            {
                return;
            }
            if (!Firewall.m_Blocked.Contains(obj))
            {
                Firewall.m_Blocked.Add(obj);
            }
            Firewall.Save();
        }

        public static void Add(string pattern)
        {
            if (!Firewall.m_Blocked.Contains(pattern))
            {
                Firewall.m_Blocked.Add(pattern);
            }
            Firewall.Save();
        }

        public static bool IsBlocked(IPAddress ip)
        {
            int num1;
            bool flag1 = false;
            for (num1 = 0; (!flag1 && (num1 < Firewall.m_Blocked.Count)); ++num1)
            {
                if ((Firewall.m_Blocked[num1] is IPAddress))
                {
                    flag1 = ip.Equals(Firewall.m_Blocked[num1]);
                }
                else if ((Firewall.m_Blocked[num1] is string))
                {
                    flag1 = Utility.IPMatch(((string) Firewall.m_Blocked[num1]), ip);
                }
            }
            return flag1;
        }

        public static void Remove(IPAddress ip)
        {
            Firewall.m_Blocked.Remove(ip);
            Firewall.Save();
        }

        public static void Remove(string pattern)
        {
            Firewall.m_Blocked.Remove(pattern);
            Firewall.Save();
        }

        public static void RemoveAt(int index)
        {
            Firewall.m_Blocked.RemoveAt(index);
            Firewall.Save();
        }

        public static void Save()
        {
            int num1;
            string text1 = "firewall.cfg";
            using (StreamWriter writer1 = new StreamWriter(text1))
            {
                for (num1 = 0; (num1 < Firewall.m_Blocked.Count); ++num1)
                {
                    writer1.WriteLine(Firewall.m_Blocked[num1]);
                }
                return;
            }
        }


        // Properties
        public static ArrayList List
        {
            get
            {
                return Firewall.m_Blocked;
            }
        }


        // Fields
        private static ArrayList m_Blocked;
    }
}

