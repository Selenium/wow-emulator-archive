namespace Server
{
    using System;
    using System.Collections;
    using System.Text;

    public class ClientVersion : IComparable, IComparer
    {
        // Methods
        static ClientVersion()
        {
            ClientVersion.m_AllowRegular = true;
            ClientVersion.m_AllowUOTD = true;
            ClientVersion.m_AllowGod = true;
            ClientVersion.m_KickDelay = TimeSpan.FromSeconds(10);
        }

        public ClientVersion(string fmt)
        {
            char ch1;
            this.m_SourceString = fmt;
            try
            {
                fmt = fmt.ToLower();
                ch1 = fmt[0];
                this.m_Major = int.Parse(ch1.ToString());
                ch1 = fmt[2];
                this.m_Minor = int.Parse(ch1.ToString());
                ch1 = fmt[4];
                this.m_Revision = int.Parse(ch1.ToString());
                if ((fmt.Length >= 6) && char.IsWhiteSpace(fmt[5]))
                {
                    this.m_Patch = 0;
                }
                else
                {
                    this.m_Patch = ((fmt[5] - 'a') + '\x01');
                }
                if ((fmt.IndexOf("god") >= 0) || (fmt.IndexOf("gq") >= 0))
                {
                    this.m_Type = ClientType.God;
                    return;
                }
                if (((fmt.IndexOf("third dawn") >= 0) || (fmt.IndexOf("uo:td") >= 0)) || (((fmt.IndexOf("uotd") >= 0) || (fmt.IndexOf("uo3d") >= 0)) || (fmt.IndexOf("uo:3d") >= 0)))
                {
                    this.m_Type = ClientType.UOTD;
                    return;
                }
                this.m_Type = ClientType.Regular;
            }
            catch
            {
                this.m_Major = 0;
                this.m_Minor = 0;
                this.m_Revision = 0;
                this.m_Patch = 0;
                this.m_Type = ClientType.Regular;
                return;
            }
        }

        public ClientVersion(int maj, int min, int rev, int pat, ClientType type)
        {
            this.m_Major = maj;
            this.m_Minor = min;
            this.m_Revision = rev;
            this.m_Patch = pat;
            this.m_Type = type;
            this.m_SourceString = this.ToString();
        }

        public static int Compare(ClientVersion a, ClientVersion b)
        {
            if (ClientVersion.IsNull(a) && ClientVersion.IsNull(b))
            {
                return 0;
            }
            if (ClientVersion.IsNull(a))
            {
                return -1;
            }
            if (ClientVersion.IsNull(b))
            {
                return 1;
            }
            return a.CompareTo(b);
        }

        public int Compare(object x, object y)
        {
            if (ClientVersion.IsNull(x) && ClientVersion.IsNull(y))
            {
                return 0;
            }
            if (ClientVersion.IsNull(x))
            {
                return -1;
            }
            if (ClientVersion.IsNull(y))
            {
                return 1;
            }
            ClientVersion version1 = (x as ClientVersion);
            ClientVersion version2 = (y as ClientVersion);
            if (ClientVersion.IsNull(version1) || ClientVersion.IsNull(version2))
            {
                throw new ArgumentException();
            }
            return version1.CompareTo(version2);
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            ClientVersion version1 = (obj as ClientVersion);
            if (version1 == null)
            {
                throw new ArgumentException();
            }
            if (this.m_Major > version1.m_Major)
            {
                return 1;
            }
            if (this.m_Major < version1.m_Major)
            {
                return -1;
            }
            if (this.m_Minor > version1.m_Minor)
            {
                return 1;
            }
            if (this.m_Minor < version1.m_Minor)
            {
                return -1;
            }
            if (this.m_Revision > version1.m_Revision)
            {
                return 1;
            }
            if (this.m_Revision < version1.m_Revision)
            {
                return -1;
            }
            if (this.m_Patch > version1.m_Patch)
            {
                return 1;
            }
            if (this.m_Patch < version1.m_Patch)
            {
                return -1;
            }
            return 0;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            ClientVersion version1 = (obj as ClientVersion);
            if (version1 == null)
            {
                return false;
            }
            if (((this.m_Major == version1.m_Major) && (this.m_Minor == version1.m_Minor)) && ((this.m_Revision == version1.m_Revision) && (this.m_Patch == version1.m_Patch)))
            {
                return (this.m_Type == version1.m_Type);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ((((this.m_Major ^ this.m_Minor) ^ this.m_Revision) ^ this.m_Patch) ^ this.m_Type);
        }

        public static bool IsNull(object x)
        {
            return object.ReferenceEquals(x, null);
        }

        public static bool operator ==(ClientVersion l, ClientVersion r)
        {
            return (ClientVersion.Compare(l, r) == 0);
        }

        public static bool operator >(ClientVersion l, ClientVersion r)
        {
            return (ClientVersion.Compare(l, r) > 0);
        }

        public static bool operator >=(ClientVersion l, ClientVersion r)
        {
            return (ClientVersion.Compare(l, r) >= 0);
        }

        public static bool operator !=(ClientVersion l, ClientVersion r)
        {
            return (ClientVersion.Compare(l, r) != 0);
        }

        public static bool operator <(ClientVersion l, ClientVersion r)
        {
            return (ClientVersion.Compare(l, r) < 0);
        }

        public static bool operator <=(ClientVersion l, ClientVersion r)
        {
            return (ClientVersion.Compare(l, r) <= 0);
        }

        public override string ToString()
        {
            StringBuilder builder1 = new StringBuilder(16);
            builder1.Append(this.m_Major);
            builder1.Append('.');
            builder1.Append(this.m_Minor);
            builder1.Append('.');
            builder1.Append(this.m_Revision);
            if (this.m_Patch > 0)
            {
                builder1.Append(((char) ((ushort) (97 + (this.m_Patch - 1)))));
            }
            if (this.m_Type != ClientType.Regular)
            {
                builder1.Append(' ');
                builder1.Append(this.m_Type.ToString());
            }
            return builder1.ToString();
        }


        // Properties
        public static bool AllowGod
        {
            get
            {
                return ClientVersion.m_AllowGod;
            }
            set
            {
                ClientVersion.m_AllowGod = value;
            }
        }

        public static bool AllowRegular
        {
            get
            {
                return ClientVersion.m_AllowRegular;
            }
            set
            {
                ClientVersion.m_AllowRegular = value;
            }
        }

        public static bool AllowUOTD
        {
            get
            {
                return ClientVersion.m_AllowUOTD;
            }
            set
            {
                ClientVersion.m_AllowUOTD = value;
            }
        }

        public static TimeSpan KickDelay
        {
            get
            {
                return ClientVersion.m_KickDelay;
            }
            set
            {
                ClientVersion.m_KickDelay = value;
            }
        }

        public int Major
        {
            get
            {
                return this.m_Major;
            }
        }

        public int Minor
        {
            get
            {
                return this.m_Minor;
            }
        }

        public int Patch
        {
            get
            {
                return this.m_Patch;
            }
        }

        public static ClientVersion Required
        {
            get
            {
                return ClientVersion.m_Required;
            }
            set
            {
                ClientVersion.m_Required = value;
            }
        }

        public int Revision
        {
            get
            {
                return this.m_Revision;
            }
        }

        public string SourceString
        {
            get
            {
                return this.m_SourceString;
            }
        }

        public ClientType Type
        {
            get
            {
                return this.m_Type;
            }
        }


        // Fields
        private static bool m_AllowGod;
        private static bool m_AllowRegular;
        private static bool m_AllowUOTD;
        private static TimeSpan m_KickDelay;
        private int m_Major;
        private int m_Minor;
        private int m_Patch;
        private static ClientVersion m_Required;
        private int m_Revision;
        private string m_SourceString;
        private ClientType m_Type;
    }
}

