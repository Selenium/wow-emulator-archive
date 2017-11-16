/*
 * Copyright (C) 2006 by pAbLoPiCaSsO and Blumster
 *
 * This program is not free. You may not redistribute it. There will be no
 * warranty for this product.
 */

using System.IO;
using System;

namespace Database
{
    interface DataClass
    {

        void Declarations();


    }
    class Data
    {
        public static int AccNb = 0;
        public static int CountLines()
        {
            AccStream.Position = 0;

            do
            {
                accountreader.ReadLine();
                AccNb += 1;
            } while (accountreader.EndOfStream == false);

        return AccNb;
        }

        public static int i = 0;
        public struct Accounts
        {
            public string[] user;
            public string[] pass;
        }
        public struct SS_Hashs
        {
            public byte[] SS_Hash;
        }
        public struct Account
        {
            public bool FirstPacket;
            public string user;
            public string pass;
            public byte[] SS_Hash;
            public System.Net.EndPoint Ip;
            public int Port;
            public byte[] K;
            public byte[] PrepareDataList(ref int t)
            {
                byte[] pack = new byte[2048];
                pack[t++] = (byte)Server.WorldServer.ClientsConnected;
                //foreach (char c in WorldServer.WorldSocket.ClientsConnected)
                //{
                  //  c.toData(ref pack, ref t);
                //}
                return pack;
            }
        }
        public static byte[] PrepareDataList(ref int t)
        {
            byte[] pack = new byte[2048];
            pack[t++] = (byte)0;
            //foreach (Character c in this.characteres)
            //{
            //    c.toData(ref pack, ref t);
            //}
          //Converter.ToBytes((byte)0x00, chardata, ref offset);//Packet initialize
          //Converter.ToBytes((byte)0x00, chardata, ref offset);//Packet initialize
          //Converter.ToBytes((byte)0x3B, chardata, ref offset);//OPCode
           //Converter.ToBytes((byte)0x00, chardata, ref offset);//OPCode
           //Converter.ToBytes((byte)0x01/*PlayerAccount.CharacterCount*/, chardata, ref offset);

            return pack;
        }
        public static FileStream AccStream = new FileStream("Data/Accounts.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        public static StreamReader accountreader = new StreamReader(AccStream);
        public static StreamWriter accountwriter = new StreamWriter(AccStream);
        public static Accounts AccountArray;



        public static void ReadAccounts()
        {
            string tester = "test";
            int AccNumber = CountLines();
            accountwriter.AutoFlush = true;

            
            AccountArray.user = new string[AccNumber];
            AccountArray.pass = new string[AccNumber];
            AccStream.Position = 0;
            while (tester != null)
            {
                AccountArray.user[i] = accountreader.ReadLine();
                tester = AccountArray.user[i];
                AccountArray.pass[i] = accountreader.ReadLine();
                if (tester != null) Server.ColoredConsole.ConsoleWriteGrayWithOne("Loading account {0}...", tester.ToUpperInvariant());
                else Server.ColoredConsole.ConsoleWriteGreenWithOut("Loaded all accounts from database!");
                i += 1;
            }
            
        }
        public static void ReloadAccounts()
        {
            string tester = "test";
            accountwriter.AutoFlush = true;
            int AccNumber = CountLines();

            AccountArray.user = new string[AccNumber];
            AccountArray.pass = new string[AccNumber];
            AccStream.Position = 0;
            while (tester != null)
            {
                AccountArray.user[i] = accountreader.ReadLine();
                tester = AccountArray.user[i];
                AccountArray.pass[i] = accountreader.ReadLine();
                if (tester == null) Server.ColoredConsole.ConsoleWriteGreenWithOut("Reloaded accounts!");
                i += 1;
            }

        }
        public static string username;
        public static Account FindByUserName(string user)
        {
            int AccNumber = CountLines();
            int test = 0;
            while (test <= AccNumber)
            {
                username = AccountArray.user[test].ToUpper();
                if (username == user)
                {
                    Account acc;
                    acc.user = user;
                    acc.pass = AccountArray.pass[test];
                    acc.SS_Hash = null;
                    acc.Ip = null;
                    acc.Port = 0;
                    acc.K = null;
                    acc.FirstPacket = false;
                    return acc;
                }
                test += 1;
                
            }
            Account Null;
            Null.pass = null;
            Null.user = null;
            Null.SS_Hash = null; 
            Null.Ip = null;
            Null.Port = 0;
            Null.K = null;
            Null.FirstPacket = false;
            return Null;

            }
            
            }

        }
    
