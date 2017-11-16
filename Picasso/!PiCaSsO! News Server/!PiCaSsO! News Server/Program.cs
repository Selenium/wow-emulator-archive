using System.IO;
using System.Net;
using System;
using System.Threading;
using N = System.Net;
using System.Collections;

class TalkServ
{
    public static string NEWS = "";

    System.Net.Sockets.TcpListener server;
    public static Hashtable handles;
    public static Hashtable handleByConnect;

    public static void Main()
    {
        FileStream config = new FileStream("NEWS.conf", FileMode.Open, FileAccess.Read);
        StreamReader configreader = new StreamReader(config);
        while (!configreader.EndOfStream)
        {
            NEWS = NEWS + configreader.ReadLine() + "\n"; 
        }
        TalkServ TS = new TalkServ();
    }

    public TalkServ()
    {
        server = new System.Net.Sockets.TcpListener(85);
        Console.WriteLine("Started News Server.\nNews are:\n" + NEWS);
        while (true)
        {
            server.Start();
            if (server.Pending())
            {
                N.Sockets.TcpClient connection = server.AcceptTcpClient();
                Console.WriteLine("Connecting client!");
                BackForth BF = new BackForth(connection);
            }
        }
    }

   

}

class BackForth
{
    N.Sockets.TcpClient client;
    System.IO.StreamReader SR;
    System.IO.StreamWriter SW;
    string handle;

    public BackForth(System.Net.Sockets.TcpClient c)
    {
        client = c;
        Thread t = new Thread(new ThreadStart(init));
        t.Start();
    }


    private void init()
    {
        SR = new System.IO.StreamReader(client.GetStream());
        SW = new System.IO.StreamWriter(client.GetStream());
        SW.WriteLine(TalkServ.NEWS);
        SW.Flush();
        client.Close();
        Console.WriteLine("Sent News. Closed Socket.");
        return;
    }
}