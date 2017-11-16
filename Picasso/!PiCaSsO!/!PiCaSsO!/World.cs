/*
 * Copyright (C) 2006 by pAbLoPiCaSsO and Blumster
 *
 * This program is not free. You may not redistribute it. There will be no
 * warranty for this product.
 */

using System;
using System.Net;
namespace Server
{
	public class World
	{
		public static string Version = "Alpha 0.01";
        public static string Path = "./";
		public static int RealmserverPort = 3724;
		public static int WorldPort = 8085;
        public static int ServerPort = WorldPort;
		public static int HTTPPort = 8080;
		public static IPHostEntry DNS = Dns.Resolve("localhost");
        public static string ServerName = "!PiCaSsO! Test-Server";
        public static int Exit;
        public delegate void OnGetActualTime(ref int year, ref int month, ref int day, ref int dayOfTheWeek, ref int hour, ref int minute);
        public static OnGetActualTime onGetActualTime;

        public static int FindUserByUsername(string username)
        {
            for (int t = 0; t < Database.Data.AccNb-1; t++)
            {
                if (Database.Data.AccountArray.user[t] == username)
                    return t;
            }
         return -1;
        }
        public static uint GetActualTime()
        {
            DateTime n = DateTime.Now;
            int year = n.Year - 2000;
            int month = n.Month - 1;
            int day = n.Day - 1;
            int dayOfTheWeek = (int)n.DayOfWeek;
            int hour = n.Hour;
            int minute = n.Minute;
            if (onGetActualTime != null)
            {
                onGetActualTime(ref year, ref month, ref day, ref dayOfTheWeek, ref hour, ref minute);
            }
            return (uint)(minute | (hour << 6) | ((int)dayOfTheWeek << 11) | ((day) << 14) | ((year) << 18) | ((month) << 20));
        }
	}
}
