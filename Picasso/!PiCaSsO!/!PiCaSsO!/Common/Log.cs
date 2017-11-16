/*
 * Copyright (C) 2006 by pAbLoPiCaSsO and Blumster
 *
 * This program is not free. You may not redistribute it. There will be no
 * warranty for this product.
 */

/*using System;
using System.IO;
using System.Globalization;

namespace Server
{
    class Log
    {
    	public static string date = DateTime.Now.ToString("G", DateTimeFormatInfo.InvariantInfo);
    	public static FileStream logfile = new FileStream("Logs/log.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        public static StreamWriter logwriter = new StreamWriter(logfile);


        public static void CloseLog()
        {
            logwriter.Close();
        }

        public static void WriteLogWithout(string text)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        	Console.Write(date);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(": " + text);
            logwriter.Write(date);
            logwriter.WriteLine(": " +text);
        }
        public static void WriteLogWithoutdate(string text)
        {
            Console.WriteLine(text);
            logwriter.WriteLine(text);
        }

        public static void WriteLogWithOne(string text, object arg0)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(date);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(": " + text, arg0);
            logwriter.Write(date);
            logwriter.WriteLine(": " + text, arg0);
        }
        public static void WriteLogWithOneWithoutDate(string text, object arg0)
        {
            Console.WriteLine(text, arg0);
            logwriter.WriteLine(text, arg0);
        }

        public static void WriteLogWithTwo(string text, object arg0, object arg1)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(date);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(": " + text, arg0, arg1);
            logwriter.Write(date);
            logwriter.WriteLine(": " + text, arg0, arg1);
        }

        public static void WriteLogWithThree(string text, object arg0, object arg1, object arg2)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(date);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(": " + text, arg0, arg1, arg2);
            logwriter.Write(date);
            logwriter.WriteLine(": " + text, arg0, arg1, arg2);
        }
    }
}*/

/*
 * Copyright   2006 by !PiCaSsO! Developer Team
 *
 * This program is not free. You may not redistribute it.
 */

using System;
using System.IO;
using System.Globalization;

namespace Server
{
    class Log
    {
        public static string date = DateTime.Now.ToString("G", DateTimeFormatInfo.InvariantInfo);
        public static string date2 = DateTime.Now.ToString("d", DateTimeFormatInfo.InvariantInfo);
        public static string time = DateTime.Now.ToString("T", DateTimeFormatInfo.InvariantInfo);
        public static FileStream logfile = new FileStream("Logs/(" + date2.Replace('/', '-') + ")(" + time.Replace(':', '.') + ").log", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        public static StreamWriter logwriter = new StreamWriter(logfile);


        public static void CloseLog()
        {
            logwriter.Close();
        }

        public static void WriteLogWithout(string text)
        {
            date = DateTime.Now.ToString("G", DateTimeFormatInfo.InvariantInfo);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(date);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(": " + text);
            logwriter.Write(date);
            logwriter.WriteLine(": " + text);
        }
        public static void WriteLogWithoutdate(string text)
        {
            Console.WriteLine(text);
            logwriter.WriteLine(text);
        }

        public static void WriteLogWithOne(string text, object arg0)
        {
            date = DateTime.Now.ToString("G", DateTimeFormatInfo.InvariantInfo);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(date);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(": " + text, arg0);
            logwriter.Write(date);
            logwriter.WriteLine(": " + text, arg0);
        }
        public static void WriteLogWithOneWithoutDate(string text, object arg0)
        {
            Console.WriteLine(text, arg0);
            logwriter.WriteLine(text, arg0);
        }

        public static void WriteLogWithTwo(string text, object arg0, object arg1)
        {
            date = DateTime.Now.ToString("G", DateTimeFormatInfo.InvariantInfo);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(date);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(": " + text, arg0, arg1);
            logwriter.Write(date);
            logwriter.WriteLine(": " + text, arg0, arg1);
        }

        public static void WriteLogWithThree(string text, object arg0, object arg1, object arg2)
        {
            date = DateTime.Now.ToString("G", DateTimeFormatInfo.InvariantInfo);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(date);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(": " + text, arg0, arg1, arg2);
            logwriter.Write(date);
            logwriter.WriteLine(": " + text, arg0, arg1, arg2);
        }
    }
}

