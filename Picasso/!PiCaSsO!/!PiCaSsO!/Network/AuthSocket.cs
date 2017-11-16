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
    class AuthSocket
    {
        public static int tempint;
        public static EndPoint IP;
        public static int userNumber;
        public static int LenghtOfDataRecieved = 0;
        public Socket RealmSocket = new Socket(EndPoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        public static AddressFamily addressFamily;
        public static Socket[] Worker_RealmserverSocket = new Socket[10000];
        public static int ClientsConnected = 0;
        public static IPEndPoint EndPoint = new IPEndPoint(IPAddress.Any, World.RealmserverPort);
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
                    AuthSocket nonstatic = new AuthSocket();
                    nonstatic.RealmSocket.Bind(EndPoint);
                    nonstatic.RealmSocket.Listen(4);
                    while (true)
                    {
                        Thread.Sleep(10);
                        if(i==0)   
                        {
                        ColoredConsole.ConsoleWriteWhiteWithOne("AuthServer listening on port {0}", World.RealmserverPort);
                        ColoredConsole.ConsoleWriteGreenWithOut("Waiting for incoming connections...");
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
                ColoredConsole.ConsoleWriteGreenWithOut("Incoming connection!");
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
        public void Listen_Callback2(IAsyncResult asyn)
        {
            int ClientID = tempint;
            try
            {
                ColoredConsole.ConsoleWriteGreenWithOut("Incoming connection!");
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
                if(LenghtOfDataRecieved!=0) ProcessRecieved(socketData.dataBuffer, ClientID);
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
                //WaitForData(RealmSocket);
                
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
        BigInteger K;
        BigInteger temp1;
        BigInteger temp2;
        BigInteger temp3;
        public static Database.Data.Account LoginAccount;
        public static byte[] salt = new byte[32];
        public static byte[] username;
        public static Database.Data.SS_Hashs[] SS_Hashs = new Database.Data.SS_Hashs[10000];

        void ProcessRecieved(byte[] data, int ClientID)
        {
            int t;
            switch (data[0])
            {

                case 0x00: //LOGIN
                    {
                        ColoredConsole.ConsoleWriteGreenWithOut("Recieved Logon Challenge!");
                        int clientVersion = (((int)data[11]) * 256) + data[12];
                        if (clientVersion == 55574)
                           ColoredConsole.ConsoleWriteBlueWithOutAndWithDate("Cient version accepted: 2.0.0, ID = 56085!");
                        else
                        {
                           ColoredConsole.ConsoleWriteErrorWithOne("Wrong client version {0}. Excpected is 2.0.0, ID = 56085!", clientVersion);
                           //return;
                        }
                        byte userlenght = data[33];
                        username = new byte[userlenght];
                        string usern = "";
                        for (t = 0; t < userlenght; t++)
                        {
                            username[t] = data[34 + t];
                            usern += "" + (char)data[34 + t];
                            //ColoredConsole.ConsoleWriteGreenWithOne("{0}", "" + ((char)username[t]).ToString());
                        }
                        ColoredConsole.ConsoleWriteGreenWithOne("Recieved AUTH_CHALLENGE from user: {0}", usern);
                        userNumber = World.FindUserByUsername(usern);
                        if (userNumber == -1)
                        {
                            SendToOneClient(new byte[] { 0x00, 0x00, 0x15 }, ClientID);
                            ColoredConsole.ConsoleWriteErrorWithOut("Wrong login.");
                            return;
                        }
                        string pass = ":" + Database.Data.AccountArray.pass[userNumber];
                        char[] passchar = pass.ToCharArray();
                        byte[] passbyte = new byte[passchar.Length];
                        int ti = 0;
                        foreach (char c in passchar)
                            passbyte[ti++] = (byte)c;
                        byte[] user = Concat(username, passbyte);
                        SHA1 sha = new SHA1CryptoServiceProvider();
                        byte[] hash = sha.ComputeHash(user, 0, user.Length);
                        byte[] res = new Byte[hash.Length + salt.Length];
                        t = 0;
                        rand.NextBytes(salt);
                        foreach (byte s in salt)
                            res[t++] = s;
                        foreach (byte s in hash)
                            res[t++] = s;
                        byte[] hash2 = sha.ComputeHash(res, 0, res.Length);
                        byte[] x = Reverse(hash2);

                        rN = Reverse(N);
                        rand.NextBytes(b);
                        rb = Reverse(b);

                        BigInteger bi = new BigInteger(x);
                        BigInteger bi2 = new BigInteger(rN);
                        BigInteger g = new BigInteger(new byte[] { 7 });
                        v = g.modPow(bi, bi2);

                        K = new BigInteger(new Byte[] { 3 });
                        temp1 = K * v;
                        temp2 = g.modPow(new BigInteger(rb), new BigInteger(rN));
                        temp3 = temp1 + temp2;
                        B = temp3 % new BigInteger(rN);
                        byte[] pack = new byte[119];
                        pack[0] = pack[1] = 0;
                        byte[] tB = Reverse(B.getBytes());
                        for (t = 0; t < tB.Length; t++)
                            pack[3 + t] = tB[t];
                        pack[35] = 1;// g_length
                        pack[36] = 7;// g
                        pack[37] = 32;// n_len
                        for (t = 0; t < N.Length; t++)
                            pack[38 + t] = N[t];
                        for (t = 0; t < salt.Length; t++)
                            pack[70 + t] = salt[t];
                        //for( t = 0;t < 16;t++ )
                        for (t = 0; t < 17; t++)
                            pack[102 + t] = 0;

                        SendToOneClient(pack, ClientID);
                        LoginAccount.user = usern;
                        LoginAccount.pass = Database.Data.AccountArray.pass[userNumber];
                        return;
                    }
                case 0x01: //LOGON PROOF
                    {
                        ColoredConsole.ConsoleWriteGreenWithOut("Logon proof!");
                        //Console.WriteLine("Logon proof" );
                        byte[] A = new byte[32];
                        for (t = 0; t < 32; t++)
                        {
                            A[t] = data[t + 1];
                        }
                        byte[] kM1 = new byte[20];
                        for (t = 0; t < 20; t++)
                        {
                            kM1[t] = data[t + 1 + 32];
                        }

                        //A = new byte[] { 0x23, 0x2f, 0xb1, 0xb8, 0x85, 0x29, 0x64, 0x3d, 0x95, 0xb8, 0xdc, 0xe7, 0x8f, 0x27, 0x50, 0xc7, 0x5b, 0x2d, 0xf3, 0x7a, 0xcb, 0xa8, 0x73, 0xeb, 0x31, 0x07, 0x38, 0x39, 0xed, 0xa0, 0x73, 0x8d };
                        byte[] rA = Reverse(A);
                        //	B = new BigInteger( new byte[] { 0x64, 0x5d, 0x1f, 0x78, 0x97, 0x30, 0x73, 0x70, 0x1e, 0x12, 0xbc, 0x98, 0xaa, 0x38, 0xea, 0x99, 0xb4, 0xbc, 0x43, 0x5c, 0x32, 0xe8, 0x44, 0x7c, 0x73, 0xab, 0x07, 0x7a, 0xe4, 0xd7, 0x59, 0x64 } );
                        byte[] AB = Concat(A, Reverse(B.getBytes()));

                        SHA1 shaM1 = new SHA1CryptoServiceProvider();
                        byte[] U = shaM1.ComputeHash(AB);
                        //	U = new byte[] { 0x2f, 0x49, 0x69, 0xac, 0x9f, 0x38, 0x7f, 0xd6, 0x72, 0x23, 0x6f, 0x94, 0x91, 0xa5, 0x16, 0x77, 0x7c, 0xdd, 0xe1, 0xc1 };
                        byte[] rU = Reverse(U);

                        temp1 = v.modPow(new BigInteger(rU), new BigInteger(rN));
                        temp2 = temp1 * new BigInteger(rA);
                        temp3 = temp2.modPow(new BigInteger(rb), new BigInteger(rN));

                        byte[] S1 = new byte[16];
                        byte[] S2 = new byte[16];
                        byte[] S = new byte[32];
                        byte[] temp = temp3.getBytes();
                        /*	Console.WriteLine("temp");
                            HexViewer.View( temp, 0, temp.Length );
                            Console.WriteLine("temp1 {0}", temp1.ToHexString());
                            Console.WriteLine("temp2 {0}", temp2.ToHexString());
                            Console.WriteLine("temp3 {0}", temp3.ToHexString());*/
                        Buffer.BlockCopy(temp, 0, S, 0, temp.Length);
                        byte[] rS = Reverse(S);


                        for (t = 0; t < 16; t++)
                        {
                            S1[t] = rS[t * 2];
                            S2[t] = rS[(t * 2) + 1];
                        }
                        byte[] hashS1 = shaM1.ComputeHash(S1);
                        byte[] hashS2 = shaM1.ComputeHash(S2);
                        SS_Hashs[userNumber].SS_Hash = new byte[hashS1.Length + hashS2.Length];
                        for (t = 0; t < hashS1.Length; t++)
                        {
                            SS_Hashs[userNumber].SS_Hash[t * 2] = hashS1[t];
                            SS_Hashs[userNumber].SS_Hash[(t * 2) + 1] = hashS2[t];
                        }

                        //	SS_Hash = new byte[] { 0x02, 0x61, 0xf4, 0xeb, 0x48, 0x91, 0xb6, 0x6a, 0x1a, 0x82, 0x6e, 0xb7, 0x79, 0x28, 0xd8, 0x64, 0xb7, 0xea, 0x14, 0x54, 0x38, 0xdb, 0x7c, 0xfd, 0x0d, 0x3d, 0x2f, 0xc0, 0x22, 0xce, 0xcc, 0x46, 0x83, 0x79, 0xf2, 0xc0, 0x87, 0x78, 0x7f, 0x14 };

                        byte[] NHash = shaM1.ComputeHash(N);
                        byte[] GHash = shaM1.ComputeHash(new byte[] { 7 });
                        byte[] userHash = shaM1.ComputeHash(username);
                        byte[] NG_Hash = new byte[20];
                        for (t = 0; t < 20; t++)
                        {
                            NG_Hash[t] = (byte)(NHash[t] ^ GHash[t]);
                        }
                        byte[] Temp = Concat(NG_Hash, userHash);
                        Temp = Concat(Temp, salt);
                        Temp = Concat(Temp, A);
                        Temp = Concat(Temp, B.getBytes());
                        Temp = Concat(Temp, K.getBytes());//SS_Hash );

                        byte[] M1 = shaM1.ComputeHash(Temp);

                        Temp = Concat(A, kM1);
                        Temp = Concat(Temp, SS_Hashs[userNumber].SS_Hash);

                        byte[] M2 = shaM1.ComputeHash(Temp);

                        byte[] retur = new byte[M2.Length + 4/*NG_Hash.Length */+ 2];
                        //	byte []retur = new byte[ M2.Length + NG_Hash.Length + 2 ];
                        retur[0] = 0x1;
                        retur[1] = 0x0;
                        for (t = 0; t < M2.Length; t++)
                            retur[t + 2] = M2[t];

                        //for(t = 0;t < NG_Hash.Length;t++ )
                        //	retur[ t + 2 + 20 ] = NG_Hash[ t ];

                        //	set the account properties
                        //Console.WriteLine("Logon proof for {0}", IP.ToString());
                        LoginAccount.Ip = IP;
                        LoginAccount.Port = 0;
                        LoginAccount.K = SS_Hashs[userNumber].SS_Hash;

                        SendToOneClient(retur, ClientID);
                        return;
                    }
                case 0x02://Reconnect challenge
                    {
                        ColoredConsole.ConsoleWriteGreenWithOut( "Reconnect challenge!" );
                        byte[] packRecoChallenge = new byte[34];
                        packRecoChallenge[0] = 0x02;
                        packRecoChallenge[1] = 0x00;
                        for (t = 0; t < 16; t++)
                            packRecoChallenge[18 + t] = 0;
                        SendToOneClient(packRecoChallenge, ClientID);
                        return;
                    }
                case 0x03://Reconnect proof
                    {
                        ColoredConsole.ConsoleWriteGreenWithOut("Reconnect proof!");
                        SendToOneClient(new byte[] { 0x03, 0x00 }, ClientID);
                        return; 
                    }
                case 0x04://Update server
                    //	Console.WriteLine( "Update server" );
                    break;
                case 0x10://Realm List					
                    ColoredConsole.ConsoleWriteGreenWithOut( "Client requested realmlist!" );
                    string ip = World.DNS.AddressList[0].ToString();
                    byte[] retData = new byte[25 + ip.Length + World.ServerName.Length + World.WorldPort.ToString().Length];
                    int offset = 0;
                    Converter.ToBytes((byte)0x10, retData, ref offset);
                    Converter.ToBytes((byte)43, retData, ref offset);
                    Converter.ToBytes(1/*World.allConnectedChars.Count*/, retData, ref offset);
                    Converter.ToBytes((byte)0, retData, ref offset);
                    Converter.ToBytes(1, retData, ref offset);
                    Converter.ToBytes((short)0, retData, ref offset);
                    Converter.ToBytes(World.ServerName, retData, ref offset);
                    Converter.ToBytes((byte)0, retData, ref offset);
                    Converter.ToBytes(ip, retData, ref offset);
                    Converter.ToBytes((byte)':', retData, ref offset);
                    Converter.ToBytes(World.ServerPort.ToString(), retData, ref offset);
                    Converter.ToBytes((byte)0, retData, ref offset);
                    Converter.ToBytes(0, retData, ref offset);
                    //	Converter.ToBytes( (short)0, retData, ref offset );//	cr erreir
                    //Converter.ToBytes( (short)1, retData, ref offset );
                    //Converter.ToBytes( (short)2, retData, ref offset );

                    Converter.ToBytes((short) ClientsConnected, retData, ref offset);
                    Converter.ToBytes((byte)0, retData, ref offset);
                    Converter.ToBytes((short)1, retData, ref offset);
                    int atlen = 1;
                    offset -= 3;
                    Converter.ToBytes(offset, retData, ref atlen);
                    //Console.WriteLine("Connected player(s) {0}", ClientsConnected);
                    /*	if ( World.allConnectedChars.Count < 3 )*/
                    //Thread.Sleep( 500 );
                    SendToOneClient(retData, ClientID);
                    return; 
                   
                default://UNKNOWN OPCODE
                    {
                        ColoredConsole.ConsoleWriteErrorWithOne("Recieve unknown OPCode: {0}", data[0]);
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



