namespace Server
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Net;
    using System.Text;

    public class Utility
    {
        // Methods
        static Utility()
        {
            Utility.m_Random = new Random();
        }

        public Utility()
        {
        }

        public static ArrayList BuildArrayList(IEnumerable enumerable)
        {
            IEnumerator enumerator1 = enumerable.GetEnumerator();
            ArrayList list1 = new ArrayList();
            while (enumerator1.MoveNext())
            {
                list1.Add(enumerator1.Current);
            }
            return list1;
        }

        public static bool CanMobileFit(int z, Tile[] tiles)
        {
            int num3;
            Tile tile1;
            int num1 = 15;
            int num2 = z;
            for (num3 = 0; (num3 < tiles.Length); ++num3)
            {
                tile1 = tiles[num3];
                if (((num2 + num1) > tile1.Z) && (num2 < (tile1.Z + tile1.Height)))
                {
                    return false;
                }
                if (((num1 == 0) && (tile1.Height == 0)) && (num2 == tile1.Z))
                {
                    return false;
                }
            }
            return true;
        }

        public static int ClipDyedHue(int hue)
        {
            if (hue < 2)
            {
                return 2;
            }
            if (hue > 1001)
            {
                return 1001;
            }
            return hue;
        }

        public static int ClipHairHue(int hue)
        {
            if (hue < 1102)
            {
                return 1102;
            }
            if (hue > 1149)
            {
                return 1149;
            }
            return hue;
        }

        public static int ClipSkinHue(int hue)
        {
            if (hue < 1002)
            {
                return 1002;
            }
            if (hue > 1058)
            {
                return 1058;
            }
            return hue;
        }

        public static int Dice(int numDice, int numSides, int bonus)
        {
            int num2;
            int num1 = 0;
            for (num2 = 0; (num2 < numDice); ++num2)
            {
                num1 += (Utility.Random(numSides) + 1);
            }
            return (num1 + bonus);
        }

        public static string FixHtml(string str)
        {
            if ((str.IndexOf('<') == -1) && (str.IndexOf('>') == -1))
            {
                return str;
            }
            StringBuilder builder1 = new StringBuilder(str);
            builder1.Replace('<', '(');
            builder1.Replace('>', ')');
            return builder1.ToString();
        }

        public static void FixPoints(ref Point3D top, ref Point3D bottom)
        {
            int num1;
            int num2;
            int num3;
            if (bottom.m_X < top.m_X)
            {
                num1 = top.m_X;
                top.m_X = bottom.m_X;
                bottom.m_X = num1;
            }
            if (bottom.m_Y < top.m_Y)
            {
                num2 = top.m_Y;
                top.m_Y = bottom.m_Y;
                bottom.m_Y = num2;
            }
            if (bottom.m_Z < top.m_Z)
            {
                num3 = top.m_Z;
                top.m_Z = bottom.m_Z;
                bottom.m_Z = num3;
            }
        }

        public static void FormatBuffer(TextWriter output, Stream input, int length)
        {
            StringBuilder builder1;
            StringBuilder builder2;
            int num5;
            int num6;
            int num7;
            int num8;
            output.WriteLine("        0  1  2  3  4  5  6  7   8  9  A  B  C  D  E  F");
            output.WriteLine("       -- -- -- -- -- -- -- --  -- -- -- -- -- -- -- --");
            int num1 = 0;
            int num2 = (length >> 4);
            int num3 = (length & 15);
            int num4 = 0;
            while ((num4 < num2))
            {
                builder1 = new StringBuilder(49);
                builder2 = new StringBuilder(16);
                for (num5 = 0; (num5 < 16); ++num5)
                {
                    num6 = input.ReadByte();
                    builder1.Append(num6.ToString("X2"));
                    if (num5 != 7)
                    {
                        builder1.Append(' ');
                    }
                    else
                    {
                        builder1.Append("  ");
                    }
                    if ((num6 >= 32) && (num6 < 128))
                    {
                        builder2.Append(((char) ((ushort) num6)));
                    }
                    else
                    {
                        builder2.Append('.');
                    }
                }
                output.Write(num1.ToString("X4"));
                output.Write("   ");
                output.Write(builder1.ToString());
                output.Write("  ");
                output.WriteLine(builder2.ToString());
                ++num4;
                num1 += 16;
            }
            if (num3 == 0)
            {
                return;
            }
            StringBuilder builder3 = new StringBuilder(49);
            StringBuilder builder4 = new StringBuilder(num3);
            for (num7 = 0; (num7 < 16); ++num7)
            {
                if (num7 < num3)
                {
                    num8 = input.ReadByte();
                    builder3.Append(num8.ToString("X2"));
                    if (num7 != 7)
                    {
                        builder3.Append(' ');
                    }
                    else
                    {
                        builder3.Append("  ");
                    }
                    if ((num8 >= 32) && (num8 < 128))
                    {
                        builder4.Append(((char) ((ushort) num8)));
                    }
                    else
                    {
                        builder4.Append('.');
                    }
                }
                else
                {
                    builder3.Append("   ");
                }
            }
            output.Write(num1.ToString("X4"));
            output.Write("   ");
            output.Write(builder3.ToString());
            output.Write("  ");
            output.WriteLine(builder4.ToString());
        }

        public static object GetArrayCap(Array array, int index)
        {
            return Utility.GetArrayCap(array, index, null);
        }

        public static object GetArrayCap(Array array, int index, object emptyValue)
        {
            if (array.Length > 0)
            {
                if (index < 0)
                {
                    index = 0;
                }
                else if (index >= array.Length)
                {
                    index = (array.Length - 1);
                }
                return array.GetValue(index);
            }
            return emptyValue;
        }

        public static bool InRange(Point3D p1, Point3D p2, int range)
        {
            if (((p1.m_X >= (p2.m_X - range)) && (p1.m_X <= (p2.m_X + range))) && (p1.m_Y >= (p2.m_Y - range)))
            {
                return (p1.m_Y <= (p2.m_Y + range));
            }
            return false;
        }

        public static int InsensitiveCompare(string first, string second)
        {
            return Insensitive.Compare(first, second);
        }

        public static bool InsensitiveStartsWith(string first, string second)
        {
            return Insensitive.StartsWith(first, second);
        }

        public static bool InUpdateRange(IPoint2D p1, IPoint2D p2)
        {
            if (((p1.X >= (p2.X - 18)) && (p1.X <= (p2.X + 18))) && (p1.Y >= (p2.Y - 18)))
            {
                return (p1.Y <= (p2.Y + 18));
            }
            return false;
        }

        public static bool InUpdateRange(Point2D p1, Point2D p2)
        {
            if (((p1.m_X >= (p2.m_X - 18)) && (p1.m_X <= (p2.m_X + 18))) && (p1.m_Y >= (p2.m_Y - 18)))
            {
                return (p1.m_Y <= (p2.m_Y + 18));
            }
            return false;
        }

        public static bool InUpdateRange(Point3D p1, Point3D p2)
        {
            if (((p1.m_X >= (p2.m_X - 18)) && (p1.m_X <= (p2.m_X + 18))) && (p1.m_Y >= (p2.m_Y - 18)))
            {
                return (p1.m_Y <= (p2.m_Y + 18));
            }
            return false;
        }

        public static bool IPMatch(string val, IPAddress ip)
        {
            bool flag1 = true;
            return Utility.IPMatch(val, ip, ref flag1);
        }

        public static bool IPMatch(string val, IPAddress ip, ref bool valid)
        {
            int num1;
            int num2;
            int num3;
            string text1;
            bool flag1;
            int num4;
            int num5;
            int num6;
            char ch1;
            int num7;
            int num8;
            int num9;
            int num10;
            valid = true;
            char[] chArray1 = new char[1];
            chArray1[0] = '.';
            string[] textArray1 = val.Split(chArray1);
            for (num1 = 0; (num1 < 4); ++num1)
            {
                if (num1 >= textArray1.Length)
                {
                    num2 = 0;
                    num3 = 255;
                }
                else
                {
                    text1 = textArray1[num1];
                    if (text1 == "*")
                    {
                        num2 = 0;
                        num3 = 255;
                    }
                    else
                    {
                        num2 = 0;
                        num3 = 0;
                        flag1 = false;
                        num4 = 10;
                        num5 = 10;
                        for (num6 = 0; (num6 < text1.Length); ++num6)
                        {
                            ch1 = text1[num6];
                            if (ch1 == '?')
                            {
                                if (!flag1)
                                {
                                    num2 *= num4;
                                    num2 = num2;
                                }
                                num3 *= num5;
                                num3 += (num5 - 1);
                            }
                            else if (ch1 == '-')
                            {
                                flag1 = true;
                                num3 = 0;
                            }
                            else if ((ch1 == 'x') || (ch1 == 'X'))
                            {
                                num4 = 16;
                                num5 = 16;
                            }
                            else if ((ch1 >= '0') && (ch1 <= '9'))
                            {
                                num7 = (ch1 - '0');
                                if (!flag1)
                                {
                                    num2 *= num4;
                                    num2 += num7;
                                }
                                num3 *= num5;
                                num3 += num7;
                            }
                            else if ((ch1 >= 'a') && (ch1 <= 'f'))
                            {
                                num8 = ('\n' + (ch1 - 'a'));
                                if (!flag1)
                                {
                                    num2 *= num4;
                                    num2 += num8;
                                }
                                num3 *= num5;
                                num3 += num8;
                            }
                            else if ((ch1 >= 'A') && (ch1 <= 'F'))
                            {
                                num9 = ('\n' + (ch1 - 'A'));
                                if (!flag1)
                                {
                                    num2 *= num4;
                                    num2 += num9;
                                }
                                num3 *= num5;
                                num3 += num9;
                            }
                            else
                            {
                                valid = false;
                            }
                        }
                    }
                }
                num10 = ((byte) (ip.Address >> ((num1 * 8) & 63)));
                if ((num10 < num2) || (num10 > num3))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IPMatchClassC(IPAddress ip1, IPAddress ip2)
        {
            return ((ip1.Address & 16777215) == (ip2.Address & 16777215));
        }

        public static bool IsInContact(Tile check, Tile[] tiles)
        {
            int num3;
            Tile tile1;
            int num1 = check.Height;
            int num2 = check.Z;
            for (num3 = 0; (num3 < tiles.Length); ++num3)
            {
                tile1 = tiles[num3];
                if (((num2 + num1) > tile1.Z) && (num2 < (tile1.Z + tile1.Height)))
                {
                    return true;
                }
                if (((num1 == 0) && (tile1.Height == 0)) && (num2 == tile1.Z))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsValidIP(string text)
        {
            bool flag1 = true;
            Utility.IPMatch(text, IPAddress.None, ref flag1);
            return flag1;
        }

        public static bool NumberBetween(double num, int bound1, int bound2, double allowance)
        {
            int num1;
            if (bound1 > bound2)
            {
                num1 = bound1;
                bound1 = bound2;
                bound2 = num1;
            }
            if (num < (bound2 + allowance))
            {
                return (num > (bound1 - allowance));
            }
            return false;
        }

        public static int Random(int count)
        {
            return Utility.m_Random.Next(count);
        }

        public static int Random(int from, int count)
        {
            if (count == 0)
            {
                return from;
            }
            if (count > 0)
            {
                return (from + Utility.m_Random.Next(count));
            }
            return (from - Utility.m_Random.Next(-count));
        }

        public static int RandomAnimalHue()
        {
            return Utility.Random(2301, 18);
        }

        public static int RandomBirdHue()
        {
            return Utility.Random(2101, 30);
        }

        public static int RandomBlueHue()
        {
            return Utility.Random(1301, 54);
        }

        public static bool RandomBool()
        {
            return (Utility.m_Random.Next(2) == 0);
        }

        public static double RandomDouble()
        {
            return Utility.m_Random.NextDouble();
        }

        public static int RandomDyedHue()
        {
            return Utility.Random(2, 1000);
        }

        public static int RandomGreenHue()
        {
            return Utility.Random(1401, 54);
        }

        public static int RandomHairHue()
        {
            return Utility.Random(1102, 48);
        }

        public static int RandomList(params int[] list)
        {
            return list[Utility.m_Random.Next(list.Length)];
        }

        public static int RandomMetalHue()
        {
            return Utility.Random(2401, 30);
        }

        public static int RandomMinMax(int min, int max)
        {
            int num1;
            if (min > max)
            {
                num1 = min;
                min = max;
                max = num1;
            }
            else if (min == max)
            {
                return min;
            }
            return (min + Utility.m_Random.Next(((max - min) + 1)));
        }

        public static int RandomNeutralHue()
        {
            return Utility.Random(1801, 108);
        }

        public static int RandomNondyedHue()
        {
            switch (Utility.Random(6))
            {
                case 0:
                {
                    goto Label_0027;
                }
                case 1:
                {
                    goto Label_002D;
                }
                case 2:
                {
                    goto Label_0033;
                }
                case 3:
                {
                    goto Label_0039;
                }
                case 4:
                {
                    goto Label_003F;
                }
                case 5:
                {
                    goto Label_0045;
                }
            }
            goto Label_004B;
        Label_0027:
            return Utility.RandomPinkHue();
        Label_002D:
            return Utility.RandomBlueHue();
        Label_0033:
            return Utility.RandomGreenHue();
        Label_0039:
            return Utility.RandomOrangeHue();
        Label_003F:
            return Utility.RandomRedHue();
        Label_0045:
            return Utility.RandomYellowHue();
        Label_004B:
            return 0;
        }

        public static int RandomOrangeHue()
        {
            return Utility.Random(1501, 54);
        }

        public static int RandomPinkHue()
        {
            return Utility.Random(1201, 54);
        }

        public static int RandomRedHue()
        {
            return Utility.Random(1601, 54);
        }

        public static int RandomSkinHue()
        {
            return (Utility.Random(1002, 57) | 32768);
        }

        public static int RandomSlimeHue()
        {
            return Utility.Random(2201, 24);
        }

        public static int RandomSnakeHue()
        {
            return Utility.Random(2001, 18);
        }

        public static int RandomYellowHue()
        {
            return Utility.Random(1701, 54);
        }

        public static bool RangeCheck(IPoint2D p1, IPoint2D p2, int range)
        {
            if (((p1.X >= (p2.X - range)) && (p1.X <= (p2.X + range))) && (p1.Y >= (p2.Y - range)))
            {
                return (p2.Y <= (p2.Y + range));
            }
            return false;
        }

        public static bool ToBoolean(string value)
        {
            bool flag1;
            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                return false;
            }
            return flag1;
        }

        public static double ToDouble(string value)
        {
            double num1;
            try
            {
                return Convert.ToDouble(value);
            }
            catch
            {
                return 0;
            }
            return num1;
        }

        public static int ToInt32(string value)
        {
            int num1;
            try
            {
                if (value.StartsWith("0x"))
                {
                    return Convert.ToInt32(value.Substring(2), 16);
                }
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
            return num1;
        }

        public static TimeSpan ToTimeSpan(string value)
        {
            TimeSpan span1;
            try
            {
                return TimeSpan.Parse(value);
            }
            catch
            {
                return TimeSpan.Zero;
            }
            return span1;
        }


        // Properties
        public static Encoding UTF8
        {
            get
            {
                if (Utility.m_UTF8 == null)
                {
                    Utility.m_UTF8 = new UTF8Encoding(false, false);
                }
                return Utility.m_UTF8;
            }
        }

        public static Encoding UTF8WithEncoding
        {
            get
            {
                if (Utility.m_UTF8WithEncoding == null)
                {
                    Utility.m_UTF8WithEncoding = new UTF8Encoding(true, false);
                }
                return Utility.m_UTF8WithEncoding;
            }
        }


        // Fields
        private static Random m_Random;
        private static Encoding m_UTF8;
        private static Encoding m_UTF8WithEncoding;
    }
}

