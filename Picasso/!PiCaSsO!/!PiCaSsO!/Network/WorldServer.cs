/*
 * Copyright (C) 2006 by pAbLoPiCaSsO and Blumster
 *
 * This program is not free. You may not redistribute it. There will be no
 * warranty for this product.
 */

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.Security.Cryptography;
using HelperTools;
using Server;

namespace Server
{
    class WorldServer
    {
        private int _send_i;
        private int _send_j; 
        private byte[] _key = new byte[0];
        public void Encode(byte[] data, Database.Data.Account PlayerAccount)
        {
           
            if (PlayerAccount.SS_Hash == null)
            {
                Console.WriteLine("Missing SS_Hash for that character !!!!!");
                return;
            }
            /*
                        PopulateMessageList( data, 0, false );
            */
            byte[] K = PlayerAccount.SS_Hash;
            for (int t = 0; t < 4; t++)
            {
                byte a = key[3];
                a = (byte)(K[a] ^ data[t]);
                byte d = key[2];
                a += d;
                data[t] = a;
                //Console.Write( "{0} ", a.ToString( "X2" ) );
                key[2] = a;
                a = key[3];
                a++;
                key[3] = (byte)(a % 0x28);
            }
            //Console.WriteLine("");
        }

        public void Decode(byte[] data, int offset, int length, Database.Data.Account acc)
        {
            byte[] K = PlayerAccount.SS_Hash;
            for (int t = 0; t < 6; t++)
            {
                byte a = key[0];
                key[0] = data[offset + t];
                byte b = data[offset + t];

                b = (byte)(b - a);
                byte d = key[1];
                a = K[d];
                a = (byte)(a ^ b);
                data[t + offset] = a;
                a = key[1];
                a++;
                key[1] = (byte)(a % 0x28);
            }
        }
        public void Decode(byte[] data, int length, Database.Data.Account acc)
        {
            byte[] K = PlayerAccount.SS_Hash;
            for (int t = 0; t < 6; t++)//length;t++ )
            {
                //	if ( t == 6 )
                //		break;
                byte a = key[0];
                key[0] = data[t];
                byte b = data[t];

                b = (byte)(b - a);
                byte d = key[1];
                a = K[d];
                a = (byte)(a ^ b);
                data[t] = a;
                //Console.Write( "{0} ", a.ToString( "X2" ) );
                a = key[1];
                a++;
                key[1] = (byte)(a % 0x28);
            }
            //	PopulateMessageList( data, 0, true );
        }
        void SendSMSG_AUTH_CHALLENGE(int ClientID)
        {
            byte[] data = new byte[] { 0x00, 0x06, 0xEC, 0x01, 0x00, 0x10, 0x00, 0x00 };
            SendToOneClient(data, ClientID);
        }
        public void Send(byte[] buffer, bool noEncode, int id)
        {
            if (buffer == null)
                return;
            Send(buffer, 0, buffer.Length, id);
        }
        public virtual void Send(byte[] toSendBuff, int offset, int len, int ClientID)
        {
            try
            {
                byte[] newToSend = new byte[len];
                Buffer.BlockCopy(toSendBuff, offset, newToSend, 0, len);
                Worker_RealmserverSocket[ClientID].BeginSend(newToSend, 0, len, 0, new AsyncCallback(this.OnSended), this);
                ColoredConsole.ConsoleWriteGrayWithOut("Data sent: " + toSendBuff[0] + toSendBuff[1] + toSendBuff[2] + toSendBuff[3] + toSendBuff[4] + toSendBuff[5] + toSendBuff[6] + toSendBuff[7]);
            }
            catch (Exception se)
            {
                Console.WriteLine(se.ToString());
            }
        }
        public static int tempint;
        public static EndPoint IP;
        public static int userNumber;
        public static int LenghtOfDataRecieved = 0;
        public Socket RealmSocket = new Socket(EndPoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        public static AddressFamily addressFamily;
        public static Socket[] Worker_RealmserverSocket = new Socket[10000];
        public static int ClientsConnected = 0;
        public static IPEndPoint EndPoint = new IPEndPoint(IPAddress.Any, World.WorldPort);
        public static string data;
        public static int sockettimer;
        public class SocketPacket
        {
            public System.Net.Sockets.Socket RealmserverSocket;
            public byte[] dataBuffer = new byte[5120];
        }
        public static void Start()
        {
            int i = 0;
            try
            {
                WorldServer nonstatic = new WorldServer();
                nonstatic.RealmSocket.Bind(EndPoint);
                nonstatic.RealmSocket.Listen(4);
                while (true)
                {
                    Thread.Sleep(50);
                    if (i == 0)
                    {
                        ColoredConsole.ConsoleWriteWhiteWithOne("Worldserver listening on port {0}", World.WorldPort);
                        i += 1;
                    }
                    nonstatic.RealmSocket.BeginAccept(new AsyncCallback(nonstatic.Listen_Callback), null);
                }
            }
            catch (Exception se)
            {
                Console.WriteLine(se.ToString());
            }
        }
        public void Listen_Callback(IAsyncResult asyn)
        {
            int ClientID = ClientsConnected;
            tempint = ClientID;
            ++ClientsConnected;
            try
            {
                ColoredConsole.ConsoleWriteGreenWithOut("Client Redirected to Worldserver!");
                //IP = RealmSocket.RemoteEndPoint;
                Worker_RealmserverSocket[ClientID] = RealmSocket.EndAccept(asyn);
                
                ColoredConsole.ConsoleWriteBlueWithOutAndWithDate("Challenged client to auth again.");
                WaitForData(Worker_RealmserverSocket[ClientID], ClientID);
                SendSMSG_AUTH_CHALLENGE(ClientID);
                RealmSocket.BeginAccept(new AsyncCallback(Listen_Callback), null);
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\n OnClientConnection: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                ColoredConsole.ConsoleWriteErrorWithOut(se.Message);
            }

        }
        public void Listen_Callback2(IAsyncResult asyn)
        {
            int ClientID = tempint;
            try
            {
                //IP = RealmSocket.RemoteEndPoint;
                Worker_RealmserverSocket[ClientID] = RealmSocket.EndAccept(asyn);
                WaitForData(Worker_RealmserverSocket[ClientID], ClientID);
                RealmSocket.BeginAccept(new AsyncCallback(Listen_Callback2), null);
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\n OnClientConnection: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                ColoredConsole.ConsoleWriteErrorWithOut(se.Message);
            }

        }
        public void WaitForData(System.Net.Sockets.Socket soc, int id)
        {
            try
            {
                if (!soc.Connected == true) soc.Disconnect(true);
                SocketPacket socketPacket = new SocketPacket();
                socketPacket.RealmserverSocket = soc;
                tempint = id;
                soc.BeginReceive(socketPacket.dataBuffer, 0,
                                   socketPacket.dataBuffer.Length,
                                   SocketFlags.None,
                                   new AsyncCallback(OnDataReceived),
                                   socketPacket);
            }
            catch (SocketException se)
            {
                ColoredConsole.ConsoleWriteErrorWithOut(se.Message);
            }

        }
        public void WaitForData(System.Net.Sockets.Socket soc)
        {
            try
            {
                if (!soc.Connected == true) soc.Disconnect(true);
                SocketPacket socketPacket = new SocketPacket();
                socketPacket.RealmserverSocket = soc;
                soc.BeginReceive(socketPacket.dataBuffer, 0,
                                   socketPacket.dataBuffer.Length,
                                   SocketFlags.None,
                                   new AsyncCallback(OnDataReceived),
                                   socketPacket);
            }
            catch (SocketException se)
            {
                ColoredConsole.ConsoleWriteErrorWithOut(se.Message);
            }
        }
        public void OnDataReceived(IAsyncResult asyn)
        {
            int ClientID = tempint;
            try
            {
                
                SocketPacket socketData = (SocketPacket)asyn.AsyncState;
                LenghtOfDataRecieved = socketData.RealmserverSocket.EndReceive(asyn);
                char[] chars = new char[LenghtOfDataRecieved + 1];
                System.Text.Decoder decode = System.Text.Encoding.UTF8.GetDecoder();
                int charLen = decode.GetChars(socketData.dataBuffer,
                                         0, LenghtOfDataRecieved, chars, 0);
                System.String szData = new System.String(chars);
                if (LenghtOfDataRecieved != 0) ProcessRecieved(socketData.dataBuffer, ClientID);
                Thread.Sleep(50);
                WaitForData(socketData.RealmserverSocket, ClientID);
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\nOnDataReceived: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                ColoredConsole.ConsoleWriteErrorWithOut(se.Message);
            }
        }
        void SendToOneClient(byte[] bytesToSend, int ClientID)
        {
            try
            {
                //byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                if (Worker_RealmserverSocket[ClientID] != null)
                {
                    if (Worker_RealmserverSocket[ClientID].Connected)
                    {
                        tempint = ClientID;
                        Worker_RealmserverSocket[ClientID].BeginSend(bytesToSend, 0, bytesToSend.Length, 0, new AsyncCallback(this.OnSended), this);
                    }
                }

            }
            catch (SocketException se)
            {
                ColoredConsole.ConsoleWriteErrorWithOut(se.Message);
            }
        }
        void SendToAllClients(byte[] bytesToSend)
        {
            try
            {
                for (int i = 0; i < ClientsConnected; i++)
                {
                    if (Worker_RealmserverSocket[i] != null)
                    {
                        if (Worker_RealmserverSocket[i].Connected)
                        {
                            tempint = i;
                            Worker_RealmserverSocket[i].BeginSend(bytesToSend, 0, bytesToSend.Length, 0, new AsyncCallback(this.OnSended), this);
                        }
                    }
                }

            }
            catch (SocketException se)
            {
                ColoredConsole.ConsoleWriteErrorWithOut(se.Message);
            }
        }
        public void OnSended(IAsyncResult ar)
        {
            try
            {
                int ClientID = tempint;
                int len = Worker_RealmserverSocket[ClientID].EndSend(ar);
            }
            catch
            {
            }
        }
        static byte[] N = { 0x89, 0x4B, 0x64, 0x5E, 0x89, 0xE1, 0x53, 0x5B, 
							  0xBD, 0xAD, 0x5B, 0x8B, 0x29, 0x06, 0x50, 0x53, 
							  0x08, 0x01, 0xB1, 0x8E, 0xBF, 0xBF, 0x5E, 0x8F, 
							  0xAB, 0x3C, 0x82, 0x87, 0x2A, 0x3E, 0x9B, 0xB7 };
        static byte[] rN = Reverse(N);
        byte[] rb;
        byte[] b = new byte[20];
        static Random rand = new Random();
        BigInteger B;
        BigInteger v;
        BigInteger K = new BigInteger();
        BigInteger temp1;
        BigInteger temp2;
        BigInteger temp3;
        public static Database.Data.Account LoginAccount;
        public static byte[] salt = new byte[32];
        public static byte[] username;
        private static Database.Data.Account PlayerAccount;
        public static int tempcount;
        byte[] key = new byte[] { 0, 0, 0, 0 };
        Hashtable pendAuth = null;
        void ProcessRecieved(byte[] data, int ClientID)
        {
            
            int t;
            int len = 0;
            int after = 0;
            int code = 0;
            if (PlayerAccount.user == null)
            {
                PlayerAccount.FirstPacket = true;
            }
            if (!PlayerAccount.FirstPacket)
            {
                byte a1 = data[after];
                byte a2 = data[after + 1];
                byte a3 = data[after + 2];
                byte a4 = data[after + 3];
                Decode(data, after, LenghtOfDataRecieved - after, PlayerAccount);
                code = ((int)data[after + 2]) + (((int)data[after + 3]) << 8);
                len = ((int)data[after + 1]) + (((int)data[after + 0]) << 8);
                if (after + len > data.Length)
                {
                    byte[] toret = new byte[data.Length - after];
                    Buffer.BlockCopy(data, after, toret, 0, toret.Length);
                    if (toret.Length > 0)
                        toret[0] = a1;
                    if (toret.Length > 1)
                        toret[1] = a2;
                    if (toret.Length > 2)
                        toret[2] = a3;
                    if (toret.Length > 3)
                        toret[3] = a4;
                    return;
                }
            }
            else
            {
                code = ((int)data[after + 2]) + (((int)data[after + 3]) << 8);
                len = ((int)data[after + 1]) + (((int)data[after + 0]) << 8);
            }
            /*while (after != -1)
            {
                byte a1 = data[after];
                byte a2 = data[after + 1];
                byte a3 = data[after + 2];
                byte a4 = data[after + 3];
                code = ((int)data[after + 2]) + (((int)data[after + 3]) << 8);
                len = ((int)data[after + 1]) + (((int)data[after + 0]) << 8);
                if (after + len > data.Length)
                {
                    byte[] toret = new byte[data.Length - after];
                    Buffer.BlockCopy(data, after, toret, 0, toret.Length);
                    if (toret.Length > 0)
                        toret[0] = a1;
                    if (toret.Length > 1)
                        toret[1] = a2;
                    if (toret.Length > 2)
                        toret[2] = a3;
                    if (toret.Length > 3)
                        toret[3] = a4;
                    break;

                }

            }*/
            int data3 = data[3];
            int data2 = data[2];
            string tempOPCode = data3.ToString("X") +data2.ToString("X");
            code = int.Parse(tempOPCode, System.Globalization.NumberStyles.HexNumber);
            t = 0;
            PlayerAccount.FirstPacket = false;
            switch (code)
            {
                case 476://CMSG_PING
                    {
                        ColoredConsole.ConsoleWriteGrayWithOut("Synchronized to Client...");
                        byte[] PONG = new byte[] { 0x00, 0x06, 0xDD, 0x01, data[6], data[7], data[8], data[9] };
                        SendToOneClient(PONG, ClientID);
                        break;

                    }
                case 493://CMSG_AUTH_SESSION
                    {
                        ColoredConsole.ConsoleWriteBlueWithOutAndWithDate("Recieved 2nd auth from client!");
                        byte[] unk1 = { data[4], data[5], data[6], data[7] };
                        byte[] unk2 = { data[8], data[9], data[10], data[11] };
                        string account = "";
                        char temp;
                        string tempSeed;
                        int ClientSeed;
                        int c;
                        for (c = 14; data[c].ToString("X") != "0"; c++)
                        {
                            temp = (char) data[c];
                            account += temp;
                        }
                        tempSeed = data[c + 1].ToString("X") + data[c + 2].ToString("X") + data[c + 3].ToString("X") + data[c + 4].ToString("X");
                        ClientSeed = int.Parse(tempSeed, System.Globalization.NumberStyles.HexNumber);

                        byte[] digest = new byte[20];
                        for (int d = 0; d <= 19; d++)
                        {
                            digest[d] = data[c+5+d];
                        }
                        
                        int acc = World.FindUserByUsername(account);
                        if (acc == -1)
                        {
                            ColoredConsole.ConsoleWriteErrorWithOne("Account not found: {0}", account);
                            SendToOneClient(new byte[] { 0xEE, 0x01, 0x21 }, ClientID);
                            return;
                        }
                        else
                        {
                            PlayerAccount.user = Database.Data.AccountArray.user[acc];
                            PlayerAccount.pass = Database.Data.AccountArray.pass[acc];
                            PlayerAccount.SS_Hash = Server.AuthSocket.SS_Hashs[acc].SS_Hash;
                            ColoredConsole.ConsoleWriteBlueWithOutAndWithDate("Account found: " + account);
                        }
                        uint seed = 0xDEADBABE;
                        SHA1 sha = new SHA1CryptoServiceProvider(); 
                        t = 0;
                        System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                        char[] CHAR_account = new char[account.Length];
                        CHAR_account = account.ToCharArray();
                        char[] CHAR_t = new char[t.ToString().Length];
                        CHAR_t = t.ToString().ToCharArray();
                        char[] CHAR_ClientSeed = new char[ClientSeed.ToString().Length];
                        CHAR_ClientSeed = ClientSeed.ToString().ToCharArray();
                        char[] CHAR_seed = new char[seed.ToString().Length];
                        CHAR_seed = seed.ToString().ToCharArray();
                        char[] CHAR_K = new char[K.ToString().Length];
                        CHAR_K = K.ToString().ToCharArray();
                        byte[] HASHED_account = sha.ComputeHash(encoding.GetBytes(CHAR_account));
                        byte[] HASHED_t = sha.ComputeHash(encoding.GetBytes(CHAR_t));
                        byte[] HASHED_ClientSeed = sha.ComputeHash(encoding.GetBytes(CHAR_ClientSeed));
                        byte[] HASHED_seed = sha.ComputeHash(encoding.GetBytes(CHAR_seed));
                        byte[] HASHED_K = sha.ComputeHash(encoding.GetBytes(CHAR_K));

                        byte[] HASHED_FINALIZED = new byte[HASHED_account.Length + HASHED_ClientSeed.Length + HASHED_K.Length + HASHED_seed.Length + HASHED_t.Length];
                        int i = 0;
                        int o = 0;
                        for (; o < HASHED_account.Length; o++)
                        {
                            HASHED_FINALIZED[o] = HASHED_account[i];
                            ++i;
                        }
                        i = 0;
                        for (; i < HASHED_t.Length; o++)
                        {
                            HASHED_FINALIZED[o] = HASHED_t[i];
                            ++i;
                        }
                        i = 0;
                        for (; i < HASHED_ClientSeed.Length; o++)
                        {
                            HASHED_FINALIZED[o] = HASHED_ClientSeed[i];
                            ++i;
                        }
                        i = 0;
                        for (; i < HASHED_seed.Length; o++)
                        {
                            HASHED_FINALIZED[o] = HASHED_seed[i];
                            ++i;
                        }
                        i = 0;
                        for (; i < HASHED_K.Length; o++)
                        {
                            HASHED_FINALIZED[o] = HASHED_K[i];
                            ++i;
                        }

                        //ColoredConsole.ConsoleWriteGreenWithOne("Temporair message: string account = {0}", account);
                        //ColoredConsole.ConsoleWriteGreenWithOne("Temporair message: int ClientSeed = {0}", ClientSeed);
                        //ColoredConsole.ConsoleWriteGreenWithOne("Temporair message: int ServerSeed = {0}", seed);
                        //ColoredConsole.ConsoleWriteGreenWithOut("Temporair message: byte[] digest = " + digest[0] + digest[1] + digest[2] + digest[3] + digest[4] + digest[5] + digest[6] + digest[7] + digest[8] + digest[9] + digest[10] + digest[11] + digest[12] + digest[13] + digest[14] + digest[15] + digest[16] + digest[17] + digest[18] + digest[19]);
                        //HexViewer.View(HASHED_FINALIZED, 0, HASHED_FINALIZED.Length);

                        //HexViewer.View(data, 0, 100);

                        byte[] AUTH_OK = new byte[] { 0x00, 0x0C, 0xEE, 0x01, 0x0C, 0xB0, 0x09, 0x02, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00 };
                        Encode(AUTH_OK, PlayerAccount);
                        SendToOneClient(AUTH_OK, ClientID);
                        //byte[] ADDON_PACKET = new byte[] { 0x00, 0x03, 0xEF, 0x02, 00, 01, 00, 01, 00, 01, 00, 01, 00, 01, 00, 01, 00, 01, 00, 01, 00, 01, 00, 01, 00, 01, 00, 01, 00, 01, 00, 01, 00, 01, 00, 01, 00, 01, 00, 01, 00, 01, 00, 01, 00 };
                        //Encode(ADDON_PACKET, PlayerAccount);
                        //SendToOneClient(ADDON_PACKET, ClientID);
                        break;
                    }
                case 0x0037:
                    {
                        t = 4;
                        byte[] pack = Database.Data.PrepareDataList(ref t);
                        t -= 2;
                        pack[0] = (byte)((t >> 8) & 0xff);
                        pack[1] = (byte)(t & 0xff);
                        pack[2] = 0x3B;
                        pack[3] = 0x00;
                        byte[] pack2 = new byte[] { 0x00, 0xAB, 0x3B, 0x00, 0x01, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x21, 0x50, 0x69, 0x43, 0x61, 0x53, 0x73, 0x4F, 0x21, 0x00, 0x04, 0x04, 0x01, 0x05, 0x05, 0x04, 0x00, 0x04, 0x06, 0x0E, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0xDF, 0x87, 0x1B, 0xC4, 0xB8, 0x4A, 0x85, 0xC5, 0x7A, 0xC7, 0x1E, 0x42, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x15, 0x27, 0x00, 0x00, 0x04, 0xF3, 0x41, 0x00, 0x00, 0x05, 0x6B, 0x38, 0x00, 0x00, 0x06, 0xF4, 0x42, 0x00, 0x00, 0x07, 0x6C, 0x38, 0x00, 0x00, 0x08, 0xA9, 0x37, 0x00, 0x00, 0x09, 0x6D, 0x38, 0x00, 0x00, 0x0A, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3C, 0x3B, 0x00, 0x00, 0x10, 0x77, 0x56, 0x00, 0x00, 0x0D, 0x77, 0x56, 0x00, 0x00, 0x0D, 0x72, 0x41, 0x00, 0x00, 0x19, 0x00, 0x00, 0x00, 0x00, 0x00, 0x18, 0x0A, 0x00, 0x00, 0x12 };
                        byte[] toSend = new byte[t + 2];
                        for (int i = 0; i < t + 2; i++)
                            toSend[i] = pack[i];
                        Encode(pack2, PlayerAccount);
                        SendToOneClient(pack2, ClientID);
                        ColoredConsole.ConsoleWriteGreenWithOut("Received CMSG_CHAR_ENUM");
                        
                        /*string name ="!PiCaSsO!"; //Temp-name
                        byte race = 0x01;
                        byte Class = 0x01;
                        byte gender = 0x01;
                        byte skin = 0x01;
                        byte face = 0x01;
                        byte hairStyle = 0x01;
                        byte hairColour = 0x01;
                        byte facialHair = 0x01;
                        byte Level = 0x3C;
                        byte PetDisplayId = 0x00;
                        byte PetLevel = 0x00;
                        byte PetCreatureFamily = 0x00;

                        char []n = name.ToCharArray();
                        byte[] chardata = new byte[2048];
                        int offset = 0;
                        Converter.ToBytes((byte)0x00, chardata, ref offset);//Packet initialize
                        Converter.ToBytes((byte)0x00, chardata, ref offset);//Packet initialize
                        Converter.ToBytes((byte)0x3B, chardata, ref offset);//OPCode
                        Converter.ToBytes((byte)0x00, chardata, ref offset);//OPCode
                        Converter.ToBytes((byte)0x01/*PlayerAccount.CharacterCount*//*, chardata, ref offset);

                        byte[] temp;
                            chardata[t++] = 0x70;
                            chardata[t++] = 0x00;
                            chardata[t++] = 0x00;
                            chardata[t++] = 0x00;
                            chardata[t++] = 0x00;
                            chardata[t++] = 0x00;
                            chardata[t++] = 0x00;
                            chardata[t++] = 0x00;
			            foreach( char c in n )
                            chardata[t++] = (byte)c;
                        chardata[t++] = 0;
                        chardata[t++] = (byte)race;
                        chardata[t++] = (byte)Class;
                        chardata[t++] = gender;
                        chardata[t++] = skin;
                        chardata[t++] = face;
                        chardata[t++] = hairStyle;
                        chardata[t++] = hairColour;
                        chardata[t++] = facialHair;
                        chardata[t++] = (byte)Level;
			            //data[ t++ ] = outfitID = 1;
                        int ZoneId = 1;
                        int MapId = 1;
                        float X = 1;
                        float Y = 1;
                        float Z = 1;
                        int GuildId = 1;
			            temp = BitConverter.GetBytes( (uint)ZoneId );
                        foreach (byte b in temp)
                        {
                            chardata[t++] = b;
                            ++tempcount;
                        }
			            temp = BitConverter.GetBytes( (uint)MapId );
			            foreach( byte b in temp )
                        {
                            chardata[t++] = b;
                            ++tempcount;
                        }
			            temp = BitConverter.GetBytes( X );
                        foreach (byte b in temp)
                        {
                            chardata[t++] = b;
                            ++tempcount;
                        }
			            temp = BitConverter.GetBytes( Y );
			            foreach( byte b in temp )
                        {
                            chardata[t++] = b;
                            ++tempcount;
                        }
			            temp = BitConverter.GetBytes( Z );
			            foreach( byte b in temp )
                        {
                            chardata[t++] = b;
                            ++tempcount;
                        }
			            temp = BitConverter.GetBytes( GuildId );
			            foreach( byte b in temp )
                        {
                            chardata[t++] = b;
                            ++tempcount;
                        }
			            data[ t++ ] = 02;//unknow;
			            temp = BitConverter.GetBytes( PetDisplayId = 1 );
			            foreach( byte b in temp )
                        {
                            chardata[t++] = b;
                            ++tempcount;
                        }
			            temp = BitConverter.GetBytes( PetLevel );
			            foreach( byte b in temp )
                        {
                            chardata[t++] = b;
                            ++tempcount;
                        }
			            temp = BitConverter.GetBytes( PetCreatureFamily );
			            foreach( byte b in temp )
                        {
                            chardata[t++] = b;
                            ++tempcount;
                        }
                        temp = BitConverter.GetBytes(0);// unknown

                        foreach (byte b in temp)
                            data[t++] = b;

                            chardata[t++] = 0;
                            chardata[t++] = 0;
                            chardata[t++] = 0;
                            chardata[t++] = 0;
                            chardata[t++] = 0;
                           
 

                                int temp2 = t -3;
                                temp = BitConverter.GetBytes((uint)temp2 );
                                    chardata[1] = temp[0];
                                    HexViewer.View(chardata,0,temp2);
                                    Encode(chardata, PlayerAccount);
                                    SendToOneClient(chardata, ClientID);
                        */
                                

                        break;
                    }
                case 54:
                    {
                        ColoredConsole.ConsoleWriteGreenWithOut("CMSG_CHAR_CREATE");
                        string name = "";
                        int i=6;
                        while(data[i] != 0)
                        {
                            name += (char)data[i];
                            ++i;
                        }
                        byte race = data[i + 1];
                        byte[] CREATE_OK = new byte[] { 0x00, 0x03, 0x3A, 0x00, 0x00 };
                        Encode(CREATE_OK, PlayerAccount);
                        SendToOneClient(CREATE_OK, ClientID);
                        ColoredConsole.ConsoleWriteGreenWithOut("Created char: " + name + ", race= " + race);
                        break;
                    }
                case 0x003D:
                    {
                        //byte[] WorldDown = new byte[] { 0x00, 0x03, 0x41, 0x00, 0x31 };
                        //Encode(WorldDown, PlayerAccount);
                        //SendToOneClient(WorldDown, ClientID);
                        //break;
                        /*byte[] MD5 = new byte[88];
                        MD5[0] = 00;
                        MD5[1] = 56;
                        MD5[2] = 09;
                        MD5[3] = 02;
                        Encode(MD5, PlayerAccount);
                        SendToOneClient(MD5, ClientID);*/

                        byte[] IgnoreList = new byte[]{ 0x00, 0x04, 0x6B, 0x00, 0x00, 0x00 };
                        Encode(IgnoreList, PlayerAccount);
                        SendToOneClient(IgnoreList, ClientID);
                        byte[] BindpointUpdate = new byte[] { 0x00, 0x16, 0x55, 0x01, 0x8F, 0x02, 0xC3, 0xC5, 0x39, 0x84, 0xA5, 0x43, 0x06, 0x61, 0xBF, 0x43, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                        Encode(BindpointUpdate, PlayerAccount);
                        SendToOneClient(BindpointUpdate, ClientID);
                        byte[] TutorialFlag = new byte[]{ 0x00 , 0x22 , 0xFD , 0x00 , 
										0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
										0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
                        Encode(TutorialFlag, PlayerAccount);
                        SendToOneClient(TutorialFlag, ClientID);
                        byte[] RestStart = new byte[] { 0x00, 0x0A, 0x66, 0x02, 0, 0, 0, 0, 0x4B, 0x71, 0x00, 0x00 };
                        Encode(RestStart, PlayerAccount);
                        SendToOneClient(RestStart, ClientID);
                        byte[] buffReaction = new byte[]{ 0x01, 0xB4, 0x21, 0x01, 0, 0, 0, 0, 0xff, 0, 0, 0,
												0x6A, 0x00, 0x61, 0x05, 
												0x00, 0x00, 0x60, 0x05, 
												0x00, 0x00, 0x5F, 0x05, 
												0x00, 0x00, 0x5E, 0x05, 
												0x00, 0x00, 0x5D, 0x05, 
												0x00, 0x00, 0x5C, 0x05, 
												0x00, 0x00, 0x5B, 0x05, 
												0x00, 0x00, 0x5A, 0x05, 
												0x00, 0x00, 0x59, 0x05, 
												0x00, 0x00, 0x58, 0x05, 
												0x00, 0x00, 0x57, 0x05, 
												0x00, 0x00, 0x56, 0x05, 
												0x0F, 0x27, 0x55, 0x05,
												0x00, 0x00, 0x54, 0x05, 
												0x01, 0x00, 0x53, 0x05, 
												0x01, 0x00, 0x52, 0x05, 
												0x01, 0x00, 0x51, 0x05, 
												0x01, 0x00, 0x4F, 0x05, 
												0x00, 0x00, 0x4E, 0x05, 
												0x00, 0x00, 0x4D, 0x05, 
												0x01, 0x00, 0x4C, 0x05, 
												0x00, 0x00, 0x4B, 0x05, 
												0x00, 0x00, 0x45, 0x05, 
												0x00, 0x00, 0x43, 0x05, 
												0x01, 0x00, 0x42, 0x05, 
												0x00, 0x00, 0x40, 0x05, 
												0x00, 0x00, 0x3F, 0x05, 
												0x00, 0x00, 0x3E, 0x05, 
												0x01, 0x00, 0x3D, 0x05, 
												0x00, 0x00, 0x3C, 0x05, 
												0x00, 0x00, 0x3B, 0x05, 
												0x00, 0x00, 0x3A, 0x05, 
												0x01, 0x00, 0x39, 0x05, 
												0x00, 0x00, 0x38, 0x05, 
												0x00, 0x00, 0x37, 0x05, 
												0x00, 0x00, 0x34, 0x05, 
												0x00, 0x00, 0x33, 0x05, 
												0x00, 0x00, 0x30, 0x05, 
												0x00, 0x00, 0x2F, 0x05, 
												0x00, 0x00, 0x2D, 0x05, 
												0x01, 0x00, 0x16, 0x05, 
												0x01, 0x00, 0x15, 0x05, 
												0x00, 0x00, 0xB6, 0x03, 
												0x00, 0x00, 0x45, 0x07, 
												0x02, 0x00, 0x36, 0x07, 
												0x01, 0x00, 0x35, 0x07, 
												0x01, 0x00, 0x34, 0x07, 
												0x01, 0x00, 0x33, 0x07, 
												0x01, 0x00, 0x32, 0x07, 
												0x01, 0x00, 0x02, 0x07, 
												0x00, 0x00, 0x01, 0x07, 
												0x00, 0x00, 0x00, 0x07, 
												0x00, 0x00, 0xFE, 0x06, 
												0x00, 0x00, 0xFD, 0x06, 
												0x00, 0x00, 0xFC, 0x06, 
												0x00, 0x00, 0xFB, 0x06, 
												0x00, 0x00, 0xF8, 0x06, 
												0x00, 0x00, 0xF7, 0x06, 
												0x00, 0x00, 0xF6, 0x06, 
												0x00, 0x00, 0xF4, 0x06, 
												0xD0, 0x07, 0xF2, 0x06, 
												0x00, 0x00, 0xF0, 0x06, 
												0x00, 0x00, 0xEF, 0x06, 
												0x00, 0x00, 0xEC, 0x06, 
												0x00, 0x00, 0xEA, 0x06, 
												0x00, 0x00, 0xE9, 0x06, 
												0x00, 0x00, 0xE8, 0x06, 
												0x00, 0x00, 0xE7, 0x06, 
												0x00, 0x00, 0x18, 0x05, 
												0x00, 0x00, 0x17, 0x05, 
												0x00, 0x00, 0x03, 0x07, 
												0x00, 0x00, 0xF9, 0x06, 
												0x00, 0x00, 0xF3, 0x06, 
												0x00, 0x00, 0xF1, 0x06, 
												0x00, 0x00, 0xEE, 0x06, 
												0x00, 0x00, 0xED, 0x06, 
												0x00, 0x00, 0x71, 0x05, 
												0x00, 0x00, 0x70, 0x05, 
												0x00, 0x00, 0x67, 0x05, 
												0x01, 0x00, 0x66, 0x05, 
												0x01, 0x00, 0x50, 0x05, 
												0x01, 0x00, 0x44, 0x05, 
												0x00, 0x00, 0x36, 0x05, 
												0x00, 0x00, 0x35, 0x05, 
												0x01, 0x00, 0x32, 0x05, 
												0x01, 0x00, 0x31, 0x05, 
												0x00, 0x00, 0x2E, 0x05, 
												0x00, 0x00, 0xC6, 0x03, 
												0x00, 0x00, 0xC4, 0x03, 
												0x00, 0x00, 0xC2, 0x03, 
												0x00, 0x00, 0xA3, 0x07, 
												0x0F, 0x27, 0x74, 0x05, 
												0x00, 0x00, 0x73, 0x05, 
												0x00, 0x00, 0x72, 0x05, 
												0x00, 0x00, 0x6F, 0x05, 
												0x00, 0x00, 0x6E, 0x05, 
												0x00, 0x00, 0x6D, 0x05, 
												0x00, 0x00, 0x6C, 0x05, 
												0x00, 0x00, 0x6B, 0x05, 
												0x00, 0x00, 0x6A, 0x05, 
												0x01, 0x00, 0x69, 0x05, 
												0x01, 0x00, 0x68, 0x05, 
												0x01, 0x00, 0x65, 0x05, 
												0x00, 0x00, 0x64, 0x05, 
												0x00, 0x00, 0x63, 0x05, 
												0x00, 0x00, 0x62, 0x05, 
												0x00, 0x00};
                        Encode(buffReaction, PlayerAccount);

                        SendToOneClient(buffReaction, ClientID);

                        byte[] SMSG_COMPRESSED_UPDATE_OBJECT = new byte[] { 0x00, 0x0D, 0xF6, 0x01, 0x05, 0x00, 0x00, 0x00, 0x78, 0x5E, 0x63, 0x60, 0x00, 0x02, 0x00 };
                        Encode(SMSG_COMPRESSED_UPDATE_OBJECT, PlayerAccount);
                        SendToOneClient(SMSG_COMPRESSED_UPDATE_OBJECT, ClientID);

                        byte[] Cinematic = new byte[] { 0x00, 0x06, 0xFA, 0x00, 0x00, 0x00, 0x00, 0x29 };
                        Encode(Cinematic, PlayerAccount);
                        SendToOneClient(Cinematic, ClientID);

                        byte[] LoginSetTimeSpeed = new byte[] { 0x00, 0x0A, 0x42, 0x00, 0x0C, 0xC9, 0x16, 0x05, 0x89, 0x88, 0x88, 0x3C };
                        Encode(LoginSetTimeSpeed, PlayerAccount);
                        SendToOneClient(LoginSetTimeSpeed, ClientID);
                        byte[] AllSpells = new byte[] { 0x00, 0x7F, 0x2A, 0x01, 0x00, 0x1E, 0x00, 0x37, 0x0C, 0x00, 0x00, 0x6B, 0x00, 0x00, 0x00, 0xCC, 0x0A, 0x00, 0x00, 0x99, 0x09, 0x00, 0x00, 0x4E, 0x00, 0x00, 0x00, 0xC4, 0x00, 0x00, 0x00, 0x9C, 0x04, 0x00, 0x00, 0xC6, 0x00, 0x00, 0x00, 0xC9, 0x00, 0x00, 0x00, 0x76, 0x23, 0x00, 0x00, 0x75, 0x23, 0x00, 0x00, 0x21, 0x22, 0x00, 0x00, 0x9C, 0x23, 0x00, 0x00, 0xCA, 0x00, 0x00, 0x00, 0xEE, 0x02, 0x00, 0x00, 0xC0, 0x3F, 0x00, 0x00, 0x9C, 0x02, 0x00, 0x00, 0xAC, 0x1C, 0x00, 0x00, 0xCB, 0x19, 0x00, 0x00, 0x51, 0x00, 0x00, 0x00, 0xCB, 0x00, 0x00, 0x00, 0x6D, 0x50, 0x00, 0x00, 0x6F, 0x50, 0x00, 0x00, 0x70, 0x50, 0x00, 0x00, 0x71, 0x50, 0x00, 0x00, 0x4B, 0x00, 0x00, 0x00, 0xCC, 0x0A, 0x00, 0x00, 0x08, 0x01, 0x00, 0x00, 0x0A, 0x01, 0x00, 0x00, 0x07, 0x0A, 0x00, 0x00, 0x00, 0x00 };
                        Encode(AllSpells, PlayerAccount);
                        SendToOneClient(AllSpells, ClientID);
                        byte[] ActionBar = new byte[] { 0x00, 0x04, 0x29, 0x01, 0xE4, 0x01 };
                        Encode(ActionBar, PlayerAccount);
                        SendToOneClient(ActionBar, ClientID);
                        byte[] TIMESPEED = new byte[] { 0x00, 0x0A, 0x42, 0x00, 0x0C, 0xC9, 0x16, 0x05, 0x89, 0x88, 0x88, 0x3C };
                        Encode(TIMESPEED, PlayerAccount);
                        SendToOneClient(TIMESPEED, ClientID);
                        byte[] buffTime = new byte[4 + 4 + 4];
                        int offset = 4;
                        Converter.ToBytes(World.GetActualTime(), buffTime, ref offset);
                        Converter.ToBytes((float)0.017f, buffTime, ref offset);
                        byte [] temp = BitConverter.GetBytes(buffTime.Length - 2);
                        t = -1;
                        foreach (byte b in temp)
                        {
                            t++;
                            buffTime[t] = b;
                        }
                        buffTime[2] = 0x42;
                        buffTime[3] = 0x00;
                        SendToOneClient(buffTime, ClientID);


                        ColoredConsole.ConsoleWriteGreenWithOut("Player entered World.");
                        byte[] AccountData = new byte[] { 0x00, 0x04, 0x0C, 0x02, 0x01, 0x00 };
                        Encode(AccountData, PlayerAccount);
                        SendToOneClient(AccountData, ClientID);
                        break;
                    }
                case 43:
                    {
                        ColoredConsole.ConsoleWriteGreenWithOut("Updated account data.");
                        break;
                    }
                default://UNKNOWN OPCODE
                    {
                        if (data[0] == 0x01)
                        {
                            if (data[1] == 0xF4)
                            {
                                ColoredConsole.ConsoleWriteGreenWithOut("Recieved CMSG_ZONE_UPDATE");
                                HexViewer.View(data, 0, 100);
                                break;
                            } 
                        }
                        ColoredConsole.ConsoleWriteErrorWithOne("Recieve unknown OPCode: {0}", code);
                        HexViewer.View(data, 0, 100);
                        return;
                    }

            }
        }
        public static byte[] Concat(byte[] a, byte[] b)
        {
            byte[] res = new byte[a.Length + b.Length];
            for (int t = 0; t < a.Length; t++)
                res[t] = a[t];
            for (int t = 0; t < b.Length; t++)
                res[t + a.Length] = b[t];
            return res;
        }
        public static byte[] Reverse(byte[] from)
        {
            byte[] res = new byte[from.Length];
            int i = 0;
            for (int t = from.Length - 1; t >= 0; t--)
                res[i++] = from[t];
            return res;
        }

    }
}


/*class ClientConnectionPool
{
    // Creates a synchronized wrapper around the Queue.
    private Queue SyncdQ = Queue.Synchronized(new Queue());

    public void Enqueue(ClientHandler client)
    {
        SyncdQ.Enqueue(client);
    }

    public ClientHandler Dequeue()
    {
        return (ClientHandler)(SyncdQ.Dequeue());
    }

    public int Count
    {
        get { return SyncdQ.Count; }
    }

    public object SyncRoot
    {
        get { return SyncdQ.SyncRoot; }
    }

} // class ClientConnectionPool

class ClientService
{

    const int NUM_OF_THREAD = 10;

    private ClientConnectionPool ConnectionPool;
    private bool ContinueProcess = false;
    private Thread[] ThreadTask = new Thread[NUM_OF_THREAD];

    public ClientService(ClientConnectionPool ConnectionPool)
    {
        this.ConnectionPool = ConnectionPool;
    }

    public void Start()
    {
        ContinueProcess = true;
        // Start threads to handle Client Task
        for (int i = 0; i < ThreadTask.Length; i++)
        {
            ThreadTask[i] = new Thread(new ThreadStart(this.Process));
            ThreadTask[i].Start();
        }
    }

    private void Process()
    {
        while (ContinueProcess)
        {

            ClientHandler client = null;
            lock (ConnectionPool.SyncRoot)
            {
                if (ConnectionPool.Count > 0)
                    client = ConnectionPool.Dequeue();
            }
            if (client != null)
            {
                client.Process(); // Provoke client hihi
                // if client still connected, schedule for later processingle it ;) 
                if (client.Alive)
                    ConnectionPool.Enqueue(client);
            }

            Thread.Sleep(100);
        }
    }

    public void Stop()
    {
        ContinueProcess = false;
        for (int i = 0; i < ThreadTask.Length; i++)
        {
            if (ThreadTask[i] != null && ThreadTask[i].IsAlive)
                ThreadTask[i].Join();
        }

        // Close all client connections :O  >( lol xD
        while (ConnectionPool.Count > 0)
        {
            ClientHandler client = ConnectionPool.Dequeue();
            client.Close();
            ColoredConsole.ConsoleWriteGreenWithOut("Client closed connection");
        }
    }

} // class ClientService

public class SynchronousSocketListener
{
 

    public static void StartListeningRealmServer()
    {

        ClientService ClientTask;

        // Client Connections Pool for multithread, so we have infinite connections
        ClientConnectionPool ConnectionPool = new ClientConnectionPool();

        // Client Task to handle client requests :P
        ClientTask = new ClientService(ConnectionPool);

        ClientTask.Start();
        TcpListener listener = new TcpListener(World.RealmserverPort);
        try
        {
            listener.Start();

            int TestingCycle = 3; // Number of testing cycles
            int ClientNbr = 0;

            // Start listening for connections. haha it begins HERE
            Log.WriteLogWithOne("Realmserver listening on port {0}", World.RealmserverPort);
            ColoredConsole.ConsoleWriteGreenWithOut("Waiting for incoming connections...");
            while (TestingCycle > 0)
            {

                TcpClient handler = listener.AcceptTcpClient();

                if (handler != null)
                {
                    ColoredConsole.ConsoleWriteGreenWithOne("Accepted incoming connection! Number assigned to client: {0}", ++ClientNbr);

                    // An incoming connection needs to be processed :O .
                    ConnectionPool.Enqueue(new ClientHandler(handler));

                    --TestingCycle;
                }
                else
                    break;
            }
            listener.Stop();

            // Stop client requests handling, finish!
            ClientTask.Stop();


        }
        catch (Exception e)
        {
            ColoredConsole.ConsoleWriteErrorWithOut(e.ToString());
        }

        ColoredConsole.ConsoleWriteErrorWithOut("\nNotice the above error message and press enter to continue...");
        Console.Read();
    }
}


class ClientHandler
{

    private TcpClient ClientSocket;
    private NetworkStream networkStream;
    bool ContinueProcess = false;
    private byte[] bytes; 		// Data buffer for incoming data. haha
    private StringBuilder sb = new StringBuilder(); // Received data string. :O
    private string data = null; // Incoming data from the client. :P

    public ClientHandler(TcpClient ClientSocket)
    {
        ClientSocket.ReceiveTimeout = 100; // 100 miliseconds is the timeout
        this.ClientSocket = ClientSocket;
        networkStream = ClientSocket.GetStream();
        bytes = new byte[ClientSocket.ReceiveBufferSize];
        ContinueProcess = true;
    }

    public void Process()
    {

        try
        {
            
            int BytesRead = networkStream.Read(bytes, 0, (int)bytes.Length);
            if (BytesRead > 0)
                // There might be more data, so we store the data received so far :P cos if there is more, we get it after.
                sb.Append(Encoding.ASCII.GetString(bytes, 0, BytesRead));
            else
                // All the data has arrived...  put it in response.
                ProcessDataReceived();


        }
        catch (IOException)
        {
            // All the data has arrived... put it in response :D .
            ProcessDataReceived();
        }
        catch (SocketException)
        {
            networkStream.Close();
            ClientSocket.Close();
            ContinueProcess = false;
            ColoredConsole.ConsoleWriteErrorWithOut("Socket exception!");
        }

    }  // Process()
    public static string ToString(byte[] bytes2)
    {
        string hexString = "";
        for (int i = 0; i < bytes2.Length; i++)
        {
            hexString += bytes2[i].ToString("X2");
        }
        return hexString;
    }

    private void ProcessDataReceived()
    {
        if (sb.Length > 0)
        {
            int i = 0;
            int c = 0;
            bytes.GetLength(c);
            /*for (i++; i == c - 1; i = i + 1)
            {
                data += bytes[i].ToString();
            }*/

//data = bytes.ToString();
/*data = ToString(bytes);

sb.Length = 0; // Clear buffer ;)

ColoredConsole.ConsoleWriteGrayWithOut("Unhandled data recieved from client :");
ColoredConsole.ConsoleWriteWhiteWithOut(data);
ColoredConsole.ConsoleWriteErrorWithOut("Please report this to pAbLoPiCaSsO or any member of the dev team");

StringBuilder response = new StringBuilder();
response.Append(OPCodes.SMSG_AUTH_CHALLENGE.ToString());

// Echo the data back to the client. haha, for now we do nothing else than sending the same back
byte[] sendBytes = Encoding.ASCII.GetBytes(response.ToString());
networkStream.Write(sendBytes, 0, sendBytes.Length);


}
}

public void Close()
{
networkStream.Close();
ClientSocket.Close();
}

public bool Alive
{
get
{
return ContinueProcess;
}
}

} // class ClientHandler*/




/*using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.Security.Cryptography;
using HelperTools;
using Server;

namespace WorldServer
{
    class WorldSocket
    {
        public static int tempint;
        public static EndPoint IP;
        public static int userNumber;
        public static int LenghtOfDataRecieved = 0;
        public Socket WorldserverSocket = new Socket(EndPoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        public static AddressFamily addressFamily;
        public static Socket[] Worker_WorldserverSocket = new Socket[10000];
        public static int ClientsConnected = 0;
        public static IPEndPoint EndPoint = new IPEndPoint(World.DNS.AddressList[0], World.WorldPort);
        public static string data;
        public static int sockettimer;
        public class SocketPacket
        {
            public System.Net.Sockets.Socket WorldserverSocket;
            public byte[] dataBuffer = new byte[5120];
        }
        public static void Start()
        {
            int i = 0;
            try
            {
                WorldSocket nonstatic = new WorldSocket();
                nonstatic.WorldserverSocket.Bind(EndPoint);
                nonstatic.WorldserverSocket.Listen(4);
                while (true)
                {
                    Thread.Sleep(10);
                    if (i == 0)
                    {
                        ColoredConsole.ConsoleWriteWhiteWithOne("Worldserver listening on port {0}", World.WorldPort);
                        i += 1;
                    }
                    nonstatic.WorldserverSocket.BeginAccept(new AsyncCallback(nonstatic.Listen_Callback), null);
                }
            }
            catch (Exception se)
            {
                Console.WriteLine(se.ToString());
            }
        }
        public void Listen_Callback(IAsyncResult asyn)
        {
            int ClientID = ClientsConnected;
            tempint = ClientID;
            ++ClientsConnected;
            try
            {

                ColoredConsole.ConsoleWriteGreenWithOut("Client Redirected to World Server!");
                //IP = RealmSocket.RemoteEndPoint;
                Worker_WorldserverSocket[ClientID] = WorldserverSocket.EndAccept(asyn);
                
                WaitForData(Worker_WorldserverSocket[ClientID], ClientID);
               
                WorldserverSocket.BeginAccept(new AsyncCallback(Listen_Callback2), null);
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\n OnClientConnection: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                ColoredConsole.ConsoleWriteErrorWithOut(se.Message);
            }

        }
        public void Listen_Callback2(IAsyncResult asyn)
        {
            int ClientID = tempint;
            try
            {
                ColoredConsole.ConsoleWriteGreenWithOut("Client Redirected to World Server!");
                //IP = RealmSocket.RemoteEndPoint;
                Worker_WorldserverSocket[ClientID] = WorldserverSocket.EndAccept(asyn);
                WaitForData(Worker_WorldserverSocket[ClientID], ClientID);
                WorldserverSocket.BeginAccept(new AsyncCallback(Listen_Callback2), null);
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\n OnClientConnection: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                ColoredConsole.ConsoleWriteErrorWithOut(se.Message);
            }

        }
        public void WaitForData(System.Net.Sockets.Socket soc, int id)
        {
            try
            {
                SocketPacket socketPacket = new SocketPacket();
                socketPacket.WorldserverSocket = soc;
                tempint = id;
                soc.BeginReceive(socketPacket.dataBuffer, 0,
                                   socketPacket.dataBuffer.Length,
                                   SocketFlags.None,
                                   new AsyncCallback(OnDataReceived),
                                   socketPacket);
            }
            catch (SocketException se)
            {
                ColoredConsole.ConsoleWriteErrorWithOut(se.Message);
            }

        }
        public void WaitForData(System.Net.Sockets.Socket soc)
        {
            try
            {

                SocketPacket socketPacket = new SocketPacket();
                socketPacket.WorldserverSocket = soc;
                soc.BeginReceive(socketPacket.dataBuffer, 0,
                                   socketPacket.dataBuffer.Length,
                                   SocketFlags.None,
                                   new AsyncCallback(OnDataReceived),
                                   socketPacket);
            }
            catch (SocketException se)
            {
                ColoredConsole.ConsoleWriteErrorWithOut(se.Message);
            }
        }
        public void OnDataReceived(IAsyncResult asyn)
        {

            int ClientID = tempint;
            try
            {
                SocketPacket socketData = (SocketPacket)asyn.AsyncState;
                LenghtOfDataRecieved = socketData.WorldserverSocket.EndReceive(asyn);
                char[] chars = new char[LenghtOfDataRecieved + 1];
                System.Text.Decoder decode = System.Text.Encoding.UTF8.GetDecoder();
                int charLen = decode.GetChars(socketData.dataBuffer,
                                         0, LenghtOfDataRecieved, chars, 0);
                System.String szData = new System.String(chars);
                if (LenghtOfDataRecieved != 0) ProcessRecieved(socketData.dataBuffer, ClientID, LenghtOfDataRecieved);
                WaitForData(socketData.WorldserverSocket);
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\nOnDataReceived: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                ColoredConsole.ConsoleWriteErrorWithOut(se.Message);
            }
        }
        void SendToOneClient(byte[] bytesToSend, int ClientID)
        {
            try
            {
                //byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                    if (Worker_WorldserverSocket[ClientID] != null)
                    {
                        if (Worker_WorldserverSocket[ClientID].Connected)
                        {
                            tempint = ClientID;
                            Worker_WorldserverSocket[ClientID].BeginSend(bytesToSend, 0, bytesToSend.Length, 0, new AsyncCallback(this.OnSended), this);
                        }
                    }

            }
            catch (SocketException se)
            {
                ColoredConsole.ConsoleWriteErrorWithOut(se.Message);
            }
        }
        void SendToAllClients(byte[] bytesToSend)
        {
            try
            {
                for (int i = 0; i < ClientsConnected; i++)
                {
                    if (Worker_WorldserverSocket[i] != null)
                    {
                        if (Worker_WorldserverSocket[i].Connected)
                        {
                            tempint = i;
                            Worker_WorldserverSocket[i].BeginSend(bytesToSend, 0, bytesToSend.Length, 0, new AsyncCallback(this.OnSended), this);
                        }
                    }
                }

            }
            catch (SocketException se)
            {
                ColoredConsole.ConsoleWriteErrorWithOut(se.Message);
            }
        }

        public void OnSended(IAsyncResult ar)
        {
            try
            {
                int ClientID = tempint;
                int len = Worker_WorldserverSocket[ClientID].EndSend(ar);
                WaitForData(WorldserverSocket);
                
            }
            catch
            {
            }
        }

        Database.Data.Account PlayerLoginAccount;
        void SendSMSG_AUTH_CHALLENGE(int ClientID)
        {
            byte[] data = new byte[8];
            int offset = 0;
            //Converter.ToBytes((ushort)0x0600, data, ref offset);
            Converter.ToBytes((ushort)OPCodes.SMSG_AUTH_CHALLENGE, data, ref offset);
            Converter.ToBytes(0xDEADBABE, data, ref offset);
            SendToOneClient(data, ClientID);
        }
        byte[] key = { 0, 0, 0, 0 };
        public void Encode(byte[] data)
        {
            if (PlayerLoginAccount.SS_Hash == null)
            {
                Console.WriteLine("Missing SS_Hash for this character !");
                return;
            }
            byte[] K = PlayerLoginAccount.SS_Hash;
            for (int t = 0; t < 4; t++)
            {
                byte a = key[3];
                a = (byte)(K[a] ^ data[t]);
                byte d = key[2];
                a += d;
                data[t] = a;
                key[2] = a;
                a = key[3];
                a++;
                key[3] = (byte)(a % 0x28);
            }
        }
        void ProcessRecieved(byte[] data, int ClientID, int length)
        {

             
            int t;
            int len = 0;
            int after = 0;
            int code = 0;
            while( after != - 1 )
				{	
						byte a1 = data[ after ];
						byte a2 = data[ after + 1 ];
						byte a3 = data[ after + 2 ];
						byte a4 = data[ after + 3 ];
						code = ( (int)data[ after + 2 ] ) + ( ( (int)data[ after + 3 ] ) << 8 );
						len = ( (int)data[ after + 1 ] ) + ( ( (int)data[ after + 0 ] ) << 8 );		
						if ( after + len > data.Length )
						{
							byte []toret = new byte[ data.Length - after ];
							Buffer.BlockCopy( data, after, toret, 0, toret.Length );
							if ( toret.Length > 0 )
								toret[ 0 ] = a1;
							if ( toret.Length > 1 )
								toret[ 1 ] = a2;
							if ( toret.Length > 2 )
								toret[ 2 ] = a3;
							if ( toret.Length > 3 )
								toret[ 3 ] = a4;
                            break;
							
						}

                }
               
					switch( code )
					{
						case 476://CMSG_PING
						{
                            Console.WriteLine("Synchronized to Client...");
							byte []PONG = new byte[]{  0x00, 0x06, 0xDD, 0x01, data[ 6 ], data[ 7 ], data[ 8 ], data[ 9 ] };
							SendToOneClient( PONG, ClientID );
							break;

						}
                    case 493://CMSG_AUTH_SESION
                        {
                            ColoredConsole.ConsoleWriteBlueWithOut("Recieved CMSG_AUTH_SESSION");
                            int[] digest = new int[20];
                            UInt32 clientSeed;
                            UInt32 unk2;
                            Int32 BuiltNumberClient;
                            UInt32 id, security;
                            string account;

                            BigInteger K;

                            BuiltNumberClient = data[0] + data[1] + data[2] + data[3];
                            ColoredConsole.ConsoleWriteBlueWithOne("Client built: {0}", BuiltNumberClient);
                            break;
                        }
						default:
                            Console.WriteLine("Synchronized to Client...");
                            byte[] PONG2 = new byte[] { 0x00, 0x06, 0xDD, 0x01, data[6], data[7], data[8], data[9] };
                            SendToOneClient(PONG2, ClientID);
                            ColoredConsole.ConsoleWriteErrorWithOne("Recieve unhandled OPCode: {0}", code);
							break;
					}
           

            }

        public void SendOPCodeWithEncrypt(int opcode, byte[] buffer, int ClientID)
        {
            if (buffer == null)
                ColoredConsole.ConsoleWriteErrorWithOut("buffer == null!");
                return;
            buffer[1] = (byte)((buffer.Length - 2) & 0xff);
            buffer[0] = (byte)(((buffer.Length - 2) >> 8) & 0xff);
            buffer[2] = (byte)(opcode & 0xff);
            buffer[3] = (byte)((opcode >> 8) & 0xff);
                Encode(buffer);
            SendToOneClient(buffer, ClientID);
        }
        public static byte[] Concat(byte[] a, byte[] b)
        {
            byte[] res = new byte[a.Length + b.Length];
            for (int t = 0; t < a.Length; t++)
                res[t] = a[t];
            for (int t = 0; t < b.Length; t++)
                res[t + a.Length] = b[t];
            return res;
        }
        public static byte[] Reverse(byte[] from)
        {
            byte[] res = new byte[from.Length];
            int i = 0;
            for (int t = from.Length - 1; t >= 0; t--)
                res[i++] = from[t];
            return res;
        }

    }
}*/