/*
 * Copyright (C) 2006 by pAbLoPiCaSsO and Blumster
 *
 * This program is not free. You may not redistribute it. There will be no
 * warranty for this product.
 */

using System;
using System.IO;
using System.Globalization;

namespace Server
{
    public class ColoredConsole
    {
        public static string date = DateTime.Now.ToString("G", DateTimeFormatInfo.InvariantInfo);

        public static void ConsoleWriteDate()
        {
            date = DateTime.Now.ToString("G", DateTimeFormatInfo.InvariantInfo);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(date + ": ");
            Log.logwriter.Write(date + ": ");
            Console.ResetColor();
        }

        public static void ConsoleWriteWhiteWithOut(string text)
        {
            ConsoleWriteDate();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
            Log.logwriter.WriteLine(text);
            Console.ResetColor();
        }

        public static void ConsoleWriteWhiteWithOne(string text, object arg0)
        {
            ConsoleWriteDate();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text, arg0);
            Log.logwriter.WriteLine(text, arg0);
            Console.ResetColor();
        }

        public static void ConsoleWriteErrorWithOut(string text)
        {
            ConsoleWriteDate();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Log.logwriter.WriteLine(text);
            Console.ResetColor();
        }

        public static void ConsoleWriteErrorWithOne(string text, object arg0)
        {
            ConsoleWriteDate();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text, arg0);
            Log.logwriter.WriteLine(text, arg0);
            Console.ResetColor();
        }

        public static void ConsoleWriteBlueWithOut(string text)
        {
            // ConsoleWriteDate();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(text);
            Log.logwriter.WriteLine(text);
            Console.ResetColor();
        }
        
        public static void ConsoleWriteBlueWithOutAndWithDate(string text)
        {
            ConsoleWriteDate();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(text);
            Log.logwriter.WriteLine(text);
            Console.ResetColor();
        }

        public static void ConsoleWriteBlueWithOne(string text, object arg0)
        {
            // ConsoleWriteDate();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(text, arg0);
            Log.logwriter.WriteLine(text, arg0);
            Console.ResetColor();
        }

        public static void ConsoleWriteGreenWithOut(string text)
        {
            ConsoleWriteDate();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Log.logwriter.WriteLine(text);
            Console.ResetColor();
        }

        public static void ConsoleWriteGreenWithOne(string text, object arg0)
        {
            ConsoleWriteDate();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text, arg0);
            Log.logwriter.WriteLine(text, arg0);
            Console.ResetColor();
        }



        public static void ConsoleWriteGrayWithOut(string text)
        {
            ConsoleWriteDate();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(text);
            Log.logwriter.WriteLine(text);
            Console.ResetColor();
        }

        public static void ConsoleWriteGrayWithOne(string text, object arg0)
        {
            ConsoleWriteDate();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(text, arg0);
            Log.logwriter.WriteLine(text, arg0);
            Console.ResetColor();
        }
    }
}