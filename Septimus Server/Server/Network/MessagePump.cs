namespace Server.Network
{
    using Server;
    using System;
    using System.Collections;
    using System.Net;
    using System.Net.Sockets;

    public class MessagePump
    {
        // Methods
        public MessagePump(Listener l)
        {
            Listener[] listenerArray1 = new Listener[1];
            listenerArray1[0] = l;
            this.m_Listeners = listenerArray1;
            this.m_Queue = new Queue();
            this.m_Throttled = new Queue();
            this.m_Peek = new byte[4];
        }

        public void AddListener(Listener l)
        {
            int num1;
            Listener[] listenerArray1 = this.m_Listeners;
            this.m_Listeners = new Listener[(listenerArray1.Length + 1)];
            for (num1 = 0; (num1 < listenerArray1.Length); ++num1)
            {
                this.m_Listeners[num1] = listenerArray1[num1];
            }
            this.m_Listeners[listenerArray1.Length] = l;
        }

        private void CheckListener()
        {
            int num1;
            Socket[] socketArray1;
            int num2;
            IPAddress address1;
            NetState state1;
            for (num1 = 0; (num1 < this.m_Listeners.Length); ++num1)
            {
                socketArray1 = this.m_Listeners[num1].Slice();
                num2 = 0;
                while ((num2 < socketArray1.Length))
                {
                    try
                    {
                        address1 = ((IPEndPoint) socketArray1[num2].RemoteEndPoint).Address;
                        if (!Firewall.IsBlocked(address1))
                        {
                            goto Label_0064;
                        }
                        Console.WriteLine("Client: {0}: Firewall blocked connection attempt.", address1);
                        try
                        {
                            socketArray1[num2].Shutdown(SocketShutdown.Both);
                        }
                        catch
                        {
                        }
                        try
                        {
                            socketArray1[num2].Close();
                            goto Label_009A;
                        }
                        catch
                        {
                            goto Label_009A;
                        }
                    }
                    catch
                    {
                    }
                    goto Label_009A;
                Label_0064:
                    state1 = new NetState(socketArray1[num2], this);
                    state1.Start();
                    if (state1.Running)
                    {
                        Console.WriteLine("Client: {0}: Connected. [{1} Online]", state1, NetState.Instances.Count);
                    }
                Label_009A:
                    ++num2;
                }
            }
        }

        public bool HandleReceive(NetState ns)
        {
            ByteQueue queue1;
            int num1;
            int num2;
            int num3;
            PacketHandler handler1;
            byte[] buffer1;
            int num4;
            ThrottlePacketCallback callback1;
            PacketProfile profile1;
            DateTime time1;
            PacketReader reader1;
            NetState state1 = ns;
            lock (ns)
            {
                queue1 = ns.Buffer;
                if (queue1 == null)
                {
                    return true;
                }
                num1 = queue1.Length;
                if (ns.Seeded)
                {
                    goto Label_0250;
                }
                if (num1 >= 4)
                {
                    queue1.Dequeue(this.m_Peek, 0, 4);
                    num2 = ((((this.m_Peek[0] << 24) | (this.m_Peek[1] << 16)) | (this.m_Peek[2] << 8)) | this.m_Peek[3]);
                    if (num2 == 0)
                    {
                        Console.WriteLine("Login: {0}: Invalid client detected, disconnecting", ns);
                        ns.Dispose();
                        return false;
                    }
                    ns.m_Seed = num2;
                    ns.Seeded = true;
                }
                return true;
            Label_009D:
                queue1.Peek(this.m_Peek, 0, 1);
                num3 = this.m_Peek[0];
                if (((!ns.SentFirstPacket && (num3 != 241)) && ((num3 != 207) && (num3 != 128))) && ((num3 != 145) && (num3 != 164)))
                {
                    Console.WriteLine("Client: {0}: Encrypted client detected, disconnecting", ns);
                    ns.Dispose();
                    goto Label_0269;
                }
                handler1 = PacketHandlers.GetHandler(num3);
                if (handler1 == null)
                {
                    buffer1 = queue1.Dequeue(num1);
                    new PacketReader(buffer1, 0).Trace(ns);
                    goto Label_0269;
                }
                num4 = handler1.Length;
                if (num4 <= 0)
                {
                    if (num1 < 3)
                    {
                        goto Label_0269;
                    }
                    queue1.Peek(this.m_Peek, 0, 3);
                    num4 = ((this.m_Peek[1] << 8) | this.m_Peek[2]);
                    if (num4 < 3)
                    {
                        ns.Dispose();
                        goto Label_0269;
                    }
                }
                if (num1 < num4)
                {
                    goto Label_0269;
                }
                if (handler1.Ingame && (ns.Mobile == null))
                {
                    Console.WriteLine("Client: {0}: Sent ingame packet (0x{1:X2}) before having been attached to a mobile", ns, num3);
                    ns.Dispose();
                    goto Label_0269;
                }
                if (handler1.Ingame && ns.Mobile.Deleted)
                {
                    ns.Dispose();
                    goto Label_0269;
                }
                callback1 = handler1.ThrottleCallback;
                if ((callback1 != null) && !callback1.Invoke(ns))
                {
                    this.m_Throttled.Enqueue(ns);
                    return false;
                }
                profile1 = PacketProfile.GetIncomingProfile(num3);
                time1 = ((profile1 == null) ? DateTime.MinValue : DateTime.Now);
                reader1 = new PacketReader(queue1.Dequeue(num4), (handler1.Length != 0));
                handler1.OnReceive(ns, reader1);
                num1 = queue1.Length;
                if (profile1 != null)
                {
                    profile1.Record(num4, ((TimeSpan) (DateTime.Now - time1)));
                }
            Label_0250:
                if (num1 > 0)
                {
                    if (ns.Running)
                    {
                        goto Label_009D;
                    }
                }
            }
        Label_0269:
            return true;
        }

        public void OnReceive(NetState ns)
        {
            object obj1;
            lock ((obj1 = this.m_Queue.SyncRoot))
            {
                this.m_Queue.Enqueue(ns);
            }
        }

        public void Slice()
        {
            NetState state1;
            object obj1;
            this.CheckListener();
            lock ((obj1 = this.m_Queue.SyncRoot))
            {
                while ((this.m_Queue.Count > 0))
                {
                    state1 = ((NetState) this.m_Queue.Dequeue());
                    if ((state1.Running && this.HandleReceive(state1)) && state1.Running)
                    {
                        state1.Continue();
                    }
                }
                while ((this.m_Throttled.Count > 0))
                {
                    this.m_Queue.Enqueue(this.m_Throttled.Dequeue());
                }
            }
        }


        // Properties
        public Listener[] Listeners
        {
            get
            {
                return this.m_Listeners;
            }
            set
            {
                this.m_Listeners = value;
            }
        }


        // Fields
        private Listener[] m_Listeners;
        private byte[] m_Peek;
        private Queue m_Queue;
        private Queue m_Throttled;
    }
}

