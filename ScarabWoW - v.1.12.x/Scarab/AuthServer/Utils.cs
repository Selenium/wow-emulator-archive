namespace AuthServer
{
    using System;
    using System.Net;
    using System.Text;

    public class Utils
    {
        public static byte[] Concat(byte[] a, byte[] b)
        {
            int num;
            byte[] buffer = new byte[a.Length + b.Length];
            for (num = 0; num < a.Length; num++)
            {
                buffer[num] = a[num];
            }
            for (num = 0; num < b.Length; num++)
            {
                buffer[num + a.Length] = b[num];
            }
            return buffer;
        }

        public static IPAddress GetIPFromDNS(string DNS)
        {
            return Dns.GetHostEntry(DNS).AddressList[0];
        }

        public static bool IsSameByteArray(byte[] m1, byte[] m2)
        {
            if (m1.Length != m2.Length)
            {
                return false;
            }
            for (int i = 0; i < m1.Length; i++)
            {
                if (m1[i] != m2[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static void konzol(byte[] b)
        {
            int num2;
            int length = b.Length;
            Console.WriteLine("bytes: " + length + "\n");
            StringBuilder builder = new StringBuilder();
            for (num2 = 0; num2 < length; num2++)
            {
                builder.Append(Convert.ToDecimal(b[num2]) + " ");
            }
            builder.AppendLine("\n");
            for (num2 = 0; num2 < length; num2++)
            {
                builder.Append(Convert.ToChar(b[num2]));
            }
            builder.AppendLine();
            Console.WriteLine(builder.ToString());
        }

        public static byte[] Reverse(byte[] from)
        {
            byte[] buffer = new byte[from.Length];
            int num = 0;
            for (int i = from.Length - 1; i >= 0; i--)
            {
                buffer[num++] = from[i];
            }
            return buffer;
        }
    }
}

