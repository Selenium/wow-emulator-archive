namespace AuthServer
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;

    internal class Network
    {
        private ManualResetEvent AcceptDone = new ManualResetEvent(false);

        private void AcceptCallback(IAsyncResult ar)
        {
            this.AcceptDone.Set();
            Socket asyncState = (Socket) ar.AsyncState;
            ClientConnection connection = new ClientConnection();
            connection.ConnectionSocket = asyncState.EndAccept(ar);
            Console.WriteLine("Accepting new connection (socket " + connection.ConnectionSocket.Handle.ToString() + ")");
            lock (((Core) ServerBase.AuthCores[0]).NewClients)
            {
                ((Core) ServerBase.AuthCores[0]).NewClients.Add(connection);
            }
            try
            {
                connection.ConnectionSocket.BeginReceive(connection.Buffer, 0, connection.Buffer.Length, SocketFlags.None, new AsyncCallback(connection.ReadCallback), connection);
            }
            catch (SocketException exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void Run()
        {
            IPEndPoint localEP = new IPEndPoint(NetworkConfg.IP, NetworkConfg.Port);
            Socket state = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine(string.Concat(new object[] { "Listening on ", NetworkConfg.IP.ToString(), ":", NetworkConfg.Port }));
            try
            {
                bool flag;
                state.Bind(localEP);
                state.Listen(10);
                goto Label_0099;
            Label_006B:
                this.AcceptDone.Reset();
                state.BeginAccept(new AsyncCallback(this.AcceptCallback), state);
                this.AcceptDone.WaitOne();
            Label_0099:
                flag = true;
                goto Label_006B;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public void StartServer()
        {
            new Thread(new ThreadStart(this.Run)).Start();
        }
    }
}

