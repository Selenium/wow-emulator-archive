namespace Server.Network
{
    using Server;
    using Server.Accounting;
    using Server.Gumps;
    using Server.HuePickers;
    using Server.Items;
    using Server.Menus;
    using System;
    using System.Collections;
    using System.Net;
    using System.Net.Sockets;

    public class NetState
    {
        // Methods
        static NetState()
        {
            NetState.m_Instances = new ArrayList();
            NetState.m_Disposed = Queue.Synchronized(new Queue());
        }

        public NetState(Socket socket, MessagePump messagePump)
        {
            this.m_Socket = socket;
            this.m_Buffer = new ByteQueue();
            this.m_Seeded = false;
            this.m_Running = false;
            this.m_RecvBuffer = new byte[2048];
            this.m_MessagePump = messagePump;
            this.m_Gumps = new Gump[0];
            this.m_HuePickers = new HuePicker[0];
            this.m_Menus = new IMenu[0];
            this.m_Trades = new ArrayList();
            this.m_SendQueue = new SendQueue();
            this.m_NextCheckActivity = (DateTime.Now + TimeSpan.FromMinutes(0.5));
            NetState.m_Instances.Add(this);
            try
            {
                this.m_Address = ((IPEndPoint) this.m_Socket.RemoteEndPoint).Address;
                this.m_ToString = this.m_Address.ToString();
            }
            catch
            {
                this.m_Address = IPAddress.None;
                this.m_ToString = "(error)";
            }
            if (NetState.m_CreatedCallback != null)
            {
                NetState.m_CreatedCallback.Invoke(this);
            }
        }

        public void AddGump(Gump g)
        {
            if (this.m_Gumps == null)
            {
                return;
            }
            Gump[] gumpArray1 = this.m_Gumps;
            this.m_Gumps = new Gump[(gumpArray1.Length + 1)];
            Array.Copy(gumpArray1, 0, this.m_Gumps, 0, gumpArray1.Length);
            this.m_Gumps[gumpArray1.Length] = g;
        }

        public void AddHuePicker(HuePicker huePicker)
        {
            if (this.m_HuePickers == null)
            {
                return;
            }
            HuePicker[] pickerArray1 = this.m_HuePickers;
            this.m_HuePickers = new HuePicker[(pickerArray1.Length + 1)];
            Array.Copy(pickerArray1, 0, this.m_HuePickers, 0, pickerArray1.Length);
            this.m_HuePickers[pickerArray1.Length] = huePicker;
        }

        public void AddMenu(IMenu m)
        {
            if (this.m_Menus == null)
            {
                return;
            }
            IMenu[] menuArray1 = this.m_Menus;
            this.m_Menus = new IMenu[(menuArray1.Length + 1)];
            Array.Copy(menuArray1, 0, this.m_Menus, 0, menuArray1.Length);
            this.m_Menus[menuArray1.Length] = m;
        }

        public void CancelAllTrades()
        {
            int num1;
            for (num1 = (this.m_Trades.Count - 1); (num1 >= 0); --num1)
            {
                if (num1 < this.m_Trades.Count)
                {
                    ((SecureTrade) this.m_Trades[num1]).Cancel();
                }
            }
        }

        public bool CheckAlive()
        {
            if (this.m_Socket == null)
            {
                return false;
            }
            if (DateTime.Now < this.m_NextCheckActivity)
            {
                return true;
            }
            Console.WriteLine("Client: {0}: Disconnecting due to inactivity...", this);
            this.Dispose();
            return false;
        }

        public static void CheckAllAlive()
        {
            int num1;
            try
            {
                for (num1 = 0; (num1 < NetState.m_Instances.Count); ++num1)
                {
                    ((NetState) NetState.m_Instances[num1]).CheckAlive();
                }
            }
            catch
            {
                return;
            }
        }

        public void Continue()
        {
            if (this.m_Socket != null)
            {
                try
                {
                    this.m_Socket.BeginReceive(this.m_RecvBuffer, 0, 2048, SocketFlags.None, this.m_OnReceive, null);
                }
                catch
                {
                    this.Dispose();
                    return;
                }
            }
        }

        public void Dispose()
        {
            if (this.m_Socket == null)
            {
                return;
            }
            try
            {
                this.m_Socket.Shutdown(SocketShutdown.Both);
            }
            catch
            {
            }
            try
            {
                this.m_Socket.Close();
            }
            catch
            {
            }
            this.m_Socket = null;
            this.m_Buffer = null;
            this.m_RecvBuffer = null;
            this.m_OnReceive = null;
            this.m_OnSend = null;
            this.m_Running = false;
            NetState.m_Disposed.Enqueue(this);
        }

        public SecureTrade FindTrade(Mobile m)
        {
            int num1;
            SecureTrade trade1;
            for (num1 = 0; (num1 < this.m_Trades.Count); ++num1)
            {
                trade1 = ((SecureTrade) this.m_Trades[num1]);
                if ((trade1.From.Mobile == m) || (trade1.To.Mobile == m))
                {
                    return trade1;
                }
            }
            return null;
        }

        public static void Initialize()
        {
            Timer.DelayCall(TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1.5), new TimerCallback(NetState.CheckAllAlive));
        }

        public void LaunchBrowser(string url)
        {
            this.Send(new MessageLocalized(Serial.MinusOne, -1, MessageType.Label, 53, 3, 501231, "", ""));
            this.Send(new LaunchBrowser(url));
        }

        private void OnReceive(IAsyncResult asyncResult)
        {
            int num1;
            byte[] buffer1;
            NetState state1 = this;
            lock (this)
            {
                if (this.m_Socket != null)
                {
                    try
                    {
                        num1 = this.m_Socket.EndReceive(asyncResult);
                        if (num1 > 0)
                        {
                            this.m_NextCheckActivity = (DateTime.Now + TimeSpan.FromMinutes(1.2));
                            buffer1 = this.m_RecvBuffer;
                            if (NetState.m_Encoder != null)
                            {
                                NetState.m_Encoder.DecodeIncomingPacket(this, ref buffer1, ref num1);
                            }
                            this.m_Buffer.Enqueue(buffer1, 0, num1);
                            this.m_MessagePump.OnReceive(this);
                            return;
                        }
                        this.Dispose();
                    }
                    catch
                    {
                        this.Dispose();
                        return;
                    }
                }
            }
        }

        private void OnSend(IAsyncResult asyncResult)
        {
            int num1;
            int num2;
            byte[] buffer1;
            SendQueue queue1;
            if (this.m_Socket != null)
            {
                try
                {
                    num1 = this.m_Socket.EndSend(asyncResult);
                    if (num1 <= 0)
                    {
                        this.Dispose();
                        return;
                    }
                    this.m_NextCheckActivity = (DateTime.Now + TimeSpan.FromMinutes(1.2));
                    num2 = 0;
                    queue1 = this.m_SendQueue;
                    lock (this.m_SendQueue)
                    {
                        buffer1 = this.m_SendQueue.Dequeue(ref num2);
                    }
                    if (buffer1 != null)
                    {
                        this.m_Socket.BeginSend(buffer1, 0, num2, SocketFlags.None, this.m_OnSend, null);
                    }
                }
                catch
                {
                    this.Dispose();
                    return;
                }
            }
        }

        public static void ProcessDisposedQueue()
        {
            NetState state1;
            Mobile mobile1;
            int num1 = 0;
            while (((num1 < 200) && (NetState.m_Disposed.Count > 0)))
            {
                ++num1;
                state1 = ((NetState) NetState.m_Disposed.Dequeue());
                mobile1 = state1.m_Mobile;
                if (mobile1 != null)
                {
                    mobile1.NetState = null;
                    state1.m_Mobile = null;
                }
                NetState.m_Instances.Remove(state1);
                Console.WriteLine("Client: {0}: Disconnected. [{1} Online]", state1, NetState.m_Instances.Count);
            }
        }

        public void RemoveGump(int index)
        {
            if (this.m_Gumps == null)
            {
                return;
            }
            Gump[] gumpArray1 = this.m_Gumps;
            this.m_Gumps = new Gump[(gumpArray1.Length - 1)];
            Array.Copy(gumpArray1, 0, this.m_Gumps, 0, index);
            Array.Copy(gumpArray1, ((int) (index + 1)), this.m_Gumps, index, ((int) (this.m_Gumps.Length - index)));
        }

        public void RemoveHuePicker(int index)
        {
            if (this.m_HuePickers == null)
            {
                return;
            }
            HuePicker[] pickerArray1 = this.m_HuePickers;
            this.m_HuePickers = new HuePicker[(pickerArray1.Length - 1)];
            Array.Copy(pickerArray1, 0, this.m_HuePickers, 0, index);
            Array.Copy(pickerArray1, ((int) (index + 1)), this.m_HuePickers, index, ((int) (this.m_HuePickers.Length - index)));
        }

        public void RemoveMenu(int index)
        {
            if (this.m_Menus == null)
            {
                return;
            }
            IMenu[] menuArray1 = this.m_Menus;
            this.m_Menus = new IMenu[(menuArray1.Length - 1)];
            Array.Copy(menuArray1, 0, this.m_Menus, 0, index);
            Array.Copy(menuArray1, ((int) (index + 1)), this.m_Menus, index, ((int) (this.m_Menus.Length - index)));
        }

        public void RemoveTrade(SecureTrade trade)
        {
            this.m_Trades.Remove(trade);
        }

        public void Send(Packet p)
        {
            int num1;
            bool flag1;
            SendQueue queue1;
            if ((this.m_Socket == null) || this.m_BlockAllPackets)
            {
                return;
            }
            PacketProfile profile1 = PacketProfile.GetOutgoingProfile(((byte) p.PacketID));
            DateTime time1 = ((profile1 == null) ? DateTime.MinValue : DateTime.Now);
            byte[] buffer1 = p.Compile(this.m_CompressionEnabled);
            if (buffer1 != null)
            {
                if (buffer1.Length <= 0)
                {
                    return;
                }
                num1 = buffer1.Length;
                if (NetState.m_Encoder != null)
                {
                    NetState.m_Encoder.EncodeOutgoingPacket(this, ref buffer1, ref num1);
                }
                flag1 = false;
                queue1 = this.m_SendQueue;
                lock (this.m_SendQueue)
                {
                    flag1 = this.m_SendQueue.Enqueue(buffer1, num1);
                }
                if (flag1)
                {
                    try
                    {
                        this.m_Socket.BeginSend(buffer1, 0, num1, SocketFlags.None, this.m_OnSend, null);
                    }
                    catch
                    {
                        this.Dispose();
                    }
                }
                if (profile1 == null)
                {
                    return;
                }
                profile1.Record(num1, ((TimeSpan) (DateTime.Now - time1)));
                return;
            }
            this.Dispose();
        }

        public void Start()
        {
            this.m_OnReceive = new AsyncCallback(this.OnReceive);
            this.m_OnSend = new AsyncCallback(this.OnSend);
            this.m_Running = true;
            if (this.m_Socket != null)
            {
                try
                {
                    this.m_Socket.BeginReceive(this.m_RecvBuffer, 0, 4, SocketFlags.None, this.m_OnReceive, null);
                }
                catch
                {
                    this.Dispose();
                    return;
                }
            }
        }

        public override string ToString()
        {
            return this.m_ToString;
        }

        public Container TradeWith(NetState state)
        {
            int num1;
            SecureTrade trade1;
            for (num1 = 0; (num1 < this.m_Trades.Count); ++num1)
            {
                trade1 = ((SecureTrade) this.m_Trades[num1]);
                if (((trade1.From.Mobile == this.m_Mobile) || (trade1.To.Mobile == this.m_Mobile)) && ((trade1.From.Mobile == state.m_Mobile) || (trade1.To.Mobile == state.m_Mobile)))
                {
                    if (trade1.From.Mobile != this.m_Mobile)
                    {
                        return trade1.To.Container;
                    }
                    return trade1.From.Container;
                }
            }
            SecureTrade trade2 = new SecureTrade(this.m_Mobile, state.m_Mobile);
            this.m_Trades.Add(trade2);
            state.m_Trades.Add(trade2);
            return trade2.From.Container;
        }

        public void ValidateAllTrades()
        {
            int num1;
            SecureTrade trade1;
            for (num1 = (this.m_Trades.Count - 1); (num1 >= 0); --num1)
            {
                if (num1 < this.m_Trades.Count)
                {
                    trade1 = ((SecureTrade) this.m_Trades[num1]);
                    if (((trade1.From.Mobile.Deleted || trade1.To.Mobile.Deleted) || (!trade1.From.Mobile.Alive || !trade1.To.Mobile.Alive)) || (!trade1.From.Mobile.InRange(trade1.To.Mobile, 2) || (trade1.From.Mobile.Map != trade1.To.Mobile.Map)))
                    {
                        trade1.Cancel();
                    }
                }
            }
        }


        // Properties
        public IAccount Account
        {
            get
            {
                return this.m_Account;
            }
            set
            {
                this.m_Account = value;
            }
        }

        public IPAddress Address
        {
            get
            {
                return this.m_Address;
            }
        }

        public bool BlockAllPackets
        {
            get
            {
                return this.m_BlockAllPackets;
            }
            set
            {
                this.m_BlockAllPackets = value;
            }
        }

        public ByteQueue Buffer
        {
            get
            {
                return this.m_Buffer;
            }
        }

        public CityInfo[] CityInfo
        {
            get
            {
                return this.m_CityInfo;
            }
            set
            {
                this.m_CityInfo = value;
            }
        }

        public bool CompressionEnabled
        {
            get
            {
                return this.m_CompressionEnabled;
            }
            set
            {
                this.m_CompressionEnabled = value;
            }
        }

        public static NetStateCreatedCallback CreatedCallback
        {
            get
            {
                return NetState.m_CreatedCallback;
            }
            set
            {
                NetState.m_CreatedCallback = value;
            }
        }

        public int Flags
        {
            get
            {
                return this.m_Flags;
            }
            set
            {
                this.m_Flags = value;
            }
        }

        public Gump[] Gumps
        {
            get
            {
                return this.m_Gumps;
            }
        }

        public HuePicker[] HuePickers
        {
            get
            {
                return this.m_HuePickers;
            }
        }

        public static ArrayList Instances
        {
            get
            {
                return NetState.m_Instances;
            }
        }

        public IMenu[] Menus
        {
            get
            {
                return this.m_Menus;
            }
        }

        public Mobile Mobile
        {
            get
            {
                return this.m_Mobile;
            }
            set
            {
                this.m_Mobile = value;
            }
        }

        public static IPacketEncoder PacketEncoder
        {
            get
            {
                return NetState.m_Encoder;
            }
            set
            {
                NetState.m_Encoder = value;
            }
        }

        public bool Running
        {
            get
            {
                return this.m_Running;
            }
        }

        public bool Seeded
        {
            get
            {
                return this.m_Seeded;
            }
            set
            {
                this.m_Seeded = value;
            }
        }

        public bool SentFirstPacket
        {
            get
            {
                return this.m_SentFirstPacket;
            }
            set
            {
                this.m_SentFirstPacket = value;
            }
        }

        public int Sequence
        {
            get
            {
                return this.m_Sequence;
            }
            set
            {
                this.m_Sequence = value;
            }
        }

        public ServerInfo[] ServerInfo
        {
            get
            {
                return this.m_ServerInfo;
            }
            set
            {
                this.m_ServerInfo = value;
            }
        }

        public Socket Socket
        {
            get
            {
                return this.m_Socket;
            }
        }

        public ArrayList Trades
        {
            get
            {
                return this.m_Trades;
            }
        }

        public ClientVersion Version
        {
            get
            {
                return this.m_Version;
            }
            set
            {
                this.m_Version = value;
            }
        }


        // Fields
        private IAccount m_Account;
        private IPAddress m_Address;
        internal int m_AuthID;
        private bool m_BlockAllPackets;
        private ByteQueue m_Buffer;
        private CityInfo[] m_CityInfo;
        private bool m_CompressionEnabled;
        private static NetStateCreatedCallback m_CreatedCallback;
        private static Queue m_Disposed;
        private static IPacketEncoder m_Encoder;
        private int m_Flags;
        private Gump[] m_Gumps;
        private HuePicker[] m_HuePickers;
        private static ArrayList m_Instances;
        private IMenu[] m_Menus;
        private MessagePump m_MessagePump;
        private Mobile m_Mobile;
        private DateTime m_NextCheckActivity;
        private AsyncCallback m_OnReceive;
        private AsyncCallback m_OnSend;
        private byte[] m_RecvBuffer;
        private bool m_Running;
        internal int m_Seed;
        private bool m_Seeded;
        private SendQueue m_SendQueue;
        private bool m_SentFirstPacket;
        private int m_Sequence;
        private ServerInfo[] m_ServerInfo;
        private Socket m_Socket;
        private string m_ToString;
        private ArrayList m_Trades;
        private ClientVersion m_Version;
    }
}

