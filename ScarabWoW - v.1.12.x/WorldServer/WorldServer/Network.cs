namespace WorldServer
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
            lock (ServerBase.AuthCores)
            {
                Core core = (Core) ServerBase.AuthCores[0];
                foreach (Core core2 in ServerBase.AuthCores)
                {
                    if (core2.ConnectedClients.Count <= core.ConnectedClients.Count)
                    {
                        core = core2;
                    }
                }
                core.NewClients.Add(connection);
            }
            try
            {
                ByteArrayBuilderV2 data = new ByteArrayBuilderV2();
                data.Add((uint) 0xdeadbabe);
                connection.Send(OpCodes.SMSG_AUTH_CHALLENGE, data);
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

