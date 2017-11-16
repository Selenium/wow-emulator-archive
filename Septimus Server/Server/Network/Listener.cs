namespace Server.Network
{
    using System;
    using System.Collections;
    using System.Net;
    using System.Net.Sockets;

    public class Listener : IDisposable
    {
        // Methods
        static Listener()
        {
            Listener.m_EmptySockets = new Socket[0];
            Listener.m_Port = 2593;
        }

        public Listener(int port)
        {
            IPHostEntry entry1;
            ArrayList list1;
            IPAddress[] addressArray1;
            int num1;
            this.m_ThisPort = port;
            this.m_Disposed = false;
            this.m_Accepted = new Queue();
            this.m_OnAccept = new AsyncCallback(this.OnAccept);
            this.m_Listener = this.Bind(IPAddress.Any, port);
            try
            {
                entry1 = Dns.Resolve(Dns.GetHostName());
                list1 = new ArrayList();
                list1.Add(IPAddress.Loopback);
                Console.WriteLine("Address: {0}:{1}", IPAddress.Loopback, port);
                addressArray1 = entry1.AddressList;
                for (num1 = 0; (num1 < addressArray1.Length); ++num1)
                {
                    if (!list1.Contains(addressArray1[num1]))
                    {
                        list1.Add(addressArray1[num1]);
                        Console.WriteLine("Address: {0}:{1}", addressArray1[num1], port);
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private Socket Bind(IPAddress ip, int port)
        {
            Socket socket2;
            IPEndPoint point1 = new IPEndPoint(ip, port);
            Socket socket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket1.Bind(point1);
                socket1.Listen(300);
                socket1.BeginAccept(this.m_OnAccept, socket1);
                return socket1;
            }
            catch
            {
                try
                {
                    socket1.Shutdown(SocketShutdown.Both);
                }
                catch
                {
                }
                try
                {
                    socket1.Close();
                }
                catch
                {
                }
                return null;
            }
            return socket2;
        }

        public void Dispose()
        {
            if (this.m_Disposed)
            {
                return;
            }
            this.m_Disposed = true;
            if (this.m_Listener == null)
            {
                return;
            }
            try
            {
                this.m_Listener.Shutdown(SocketShutdown.Both);
            }
            catch
            {
            }
            try
            {
                this.m_Listener.Close();
            }
            catch
            {
            }
            this.m_Listener = null;
        }

        private void OnAccept(IAsyncResult asyncResult)
        {
            Socket socket1;
            object obj1;
            try
            {
                socket1 = this.m_Listener.EndAccept(asyncResult);
                lock ((obj1 = this.m_Accepted.SyncRoot))
                {
                    this.m_Accepted.Enqueue(socket1);
                }
            }
            catch
            {
                return;
            }
            finally
            {
                this.m_Listener.BeginAccept(this.m_OnAccept, this.m_Listener);
            }
        }

        public Socket[] Slice()
        {
            object[] objArray1;
            Socket[] socketArray1;
            Socket[] socketArray2;
            object obj1;
            lock ((obj1 = this.m_Accepted.SyncRoot))
            {
                if (this.m_Accepted.Count == 0)
                {
                    return Listener.m_EmptySockets;
                }
                objArray1 = this.m_Accepted.ToArray();
                this.m_Accepted.Clear();
                socketArray1 = new Socket[objArray1.Length];
                Array.Copy(objArray1, socketArray1, objArray1.Length);
                return socketArray1;
            }
            return socketArray2;
        }


        // Properties
        public static int Port
        {
            get
            {
                return Listener.m_Port;
            }
            set
            {
                Listener.m_Port = value;
            }
        }

        public int UsedPort
        {
            get
            {
                return this.m_ThisPort;
            }
        }


        // Fields
        private Queue m_Accepted;
        private bool m_Disposed;
        private static Socket[] m_EmptySockets;
        private Socket m_Listener;
        private AsyncCallback m_OnAccept;
        private static int m_Port;
        private int m_ThisPort;
    }
}

