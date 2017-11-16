namespace AuthServer
{
    using System;
    using System.Net.Sockets;
    using System.Threading;

    internal class ClientConnection
    {
        public bool Authed = false;
        public byte[] Buffer = new byte[0x400];
        public Socket ConnectionSocket;
        public ByteArrayBuilderV2 Data = new ByteArrayBuilderV2();
        public ManualResetEvent MRE = new ManualResetEvent(false);
        private ByteArrayBuilderV2 temp = new ByteArrayBuilderV2();
        public Account User = new Account();

        public void Disconnect()
        {
            try
            {
                this.ConnectionSocket.Shutdown(SocketShutdown.Both);
                lock (((Core) ServerBase.AuthCores[0]).DisconectingClients)
                {
                    ((Core) ServerBase.AuthCores[0]).DisconectingClients.Add(this);
                }
            }
            catch (SocketException exception)
            {
                Console.WriteLine(exception);
                this.Disconnect();
            }
        }

        public void ReadCallback(IAsyncResult ar)
        {
            SocketException exception;
            int num = 0;
            try
            {
                num = this.ConnectionSocket.EndReceive(ar);
                if (num <= 0x400)
                {
                    lock (this.Data)
                    {
                        for (int i = 0; i <= num; i++)
                        {
                            this.Data.Add(this.Buffer[i]);
                        }
                    }
                }
                if (this.ConnectionSocket.Available > 0)
                {
                    this.Buffer = new byte[0x400];
                    this.ConnectionSocket.BeginReceive(this.Buffer, 0, this.Buffer.Length, SocketFlags.None, new AsyncCallback(this.ReadCallback), null);
                    return;
                }
            }
            catch (SocketException exception1)
            {
                exception = exception1;
                Console.WriteLine(exception);
                this.Disconnect();
            }
            if (num <= 0)
            {
                this.Disconnect();
            }
            else
            {
                this.MRE.WaitOne();
                this.Buffer = new byte[0x400];
                this.Data.Clear();
                this.MRE.Reset();
                try
                {
                    this.ConnectionSocket.BeginReceive(this.Buffer, 0, this.Buffer.Length, SocketFlags.None, new AsyncCallback(this.ReadCallback), null);
                }
                catch (SocketException exception2)
                {
                    exception = exception2;
                    Console.WriteLine(exception);
                    this.Disconnect();
                }
            }
        }

        public void Send(byte[] tosend)
        {
            try
            {
                this.ConnectionSocket.BeginSend(tosend, 0, tosend.Length, SocketFlags.None, new AsyncCallback(this.SendCallback), null);
            }
            catch (SocketException exception)
            {
                Console.WriteLine(exception);
                this.Disconnect();
            }
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                this.ConnectionSocket.EndSend(ar);
            }
            catch (SocketException exception)
            {
                Console.WriteLine(exception);
                this.Disconnect();
            }
        }
    }
}

