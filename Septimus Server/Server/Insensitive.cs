namespace Server
{
    using System;
    using System.Collections;

    public class Insensitive
    {
        // Methods
        static Insensitive()
        {
            Insensitive.m_Comparer = CaseInsensitiveComparer.Default;
        }

        private Insensitive()
        {
        }

        public static int Compare(string a, string b)
        {
            return Insensitive.m_Comparer.Compare(a, b);
        }

        public static bool Contains(string a, string b)
        {
            if (((a == null) || (b == null)) || (a.Length < b.Length))
            {
                return false;
            }
            a = a.ToLower();
            b = b.ToLower();
            return (a.IndexOf(b) >= 0);
        }

        public static bool EndsWith(string a, string b)
        {
            if (((a == null) || (b == null)) || (a.Length < b.Length))
            {
                return false;
            }
            return (Insensitive.m_Comparer.Compare(a.Substring((a.Length - b.Length)), b) == 0);
        }

        public static bool Equals(string a, string b)
        {
            if ((a == null) && (b == null))
            {
                return true;
            }
            if (((a == null) || (b == null)) || (a.Length != b.Length))
            {
                return false;
            }
            return (Insensitive.m_Comparer.Compare(a, b) == 0);
        }

        public static bool StartsWith(string a, string b)
        {
            if (((a == null) || (b == null)) || (a.Length < b.Length))
            {
                return false;
            }
            return (Insensitive.m_Comparer.Compare(a.Substring(0, b.Length), b) == 0);
        }


        // Properties
        public static IComparer Comparer
        {
            get
            {
                return Insensitive.m_Comparer;
            }
        }


        // Fields
        private static IComparer m_Comparer;
    }
}

