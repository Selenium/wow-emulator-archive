namespace Server
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Threading;

    public class Timer
    {
        // Methods
        static Timer()
        {
            Server.Timer.m_Profiles = new Hashtable();
            Server.Timer.m_Queue = new Queue();
            Server.Timer.m_BreakCount = 20000;
        }

        public Timer(TimeSpan delay) : this(delay, TimeSpan.Zero, 1)
        {
        }

        public Timer(TimeSpan delay, TimeSpan interval) : this(delay, interval, 0)
        {
        }

        public Timer(TimeSpan delay, TimeSpan interval, int count)
        {
            this.m_Delay = delay;
            this.m_Interval = interval;
            this.m_Count = count;
            if (this.DefRegCreation)
            {
                this.RegCreation();
            }
        }

        public static TimerPriority ComputePriority(TimeSpan ts)
        {
            if (ts >= TimeSpan.FromMinutes(1))
            {
                return TimerPriority.FiveSeconds;
            }
            if (ts >= TimeSpan.FromSeconds(10))
            {
                return TimerPriority.OneSecond;
            }
            if (ts >= TimeSpan.FromSeconds(5))
            {
                return TimerPriority.TwoFiftyMS;
            }
            if (ts >= TimeSpan.FromSeconds(2.5))
            {
                return TimerPriority.FiftyMS;
            }
            if (ts >= TimeSpan.FromSeconds(1))
            {
                return TimerPriority.TwentyFiveMS;
            }
            if (ts >= TimeSpan.FromSeconds(0.5))
            {
                return TimerPriority.TenMS;
            }
            return TimerPriority.EveryTick;
        }

        public static Server.Timer DelayCall(TimeSpan delay, Server.TimerCallback callback)
        {
            return Server.Timer.DelayCall(delay, TimeSpan.Zero, 1, callback);
        }

        public static Server.Timer DelayCall(TimeSpan delay, TimerStateCallback callback, object state)
        {
            return Server.Timer.DelayCall(delay, TimeSpan.Zero, 1, callback, state);
        }

        public static Server.Timer DelayCall(TimeSpan delay, TimeSpan interval, Server.TimerCallback callback)
        {
            return Server.Timer.DelayCall(delay, interval, 0, callback);
        }

        public static Server.Timer DelayCall(TimeSpan delay, TimeSpan interval, TimerStateCallback callback, object state)
        {
            return Server.Timer.DelayCall(delay, interval, 0, callback, state);
        }

        public static Server.Timer DelayCall(TimeSpan delay, TimeSpan interval, int count, Server.TimerCallback callback)
        {
            Server.Timer timer1 = new DelayCallTimer(delay, interval, count, callback);
            if (count == 1)
            {
                timer1.Priority = Server.Timer.ComputePriority(delay);
            }
            else
            {
                timer1.Priority = Server.Timer.ComputePriority(interval);
            }
            timer1.Start();
            return timer1;
        }

        public static Server.Timer DelayCall(TimeSpan delay, TimeSpan interval, int count, TimerStateCallback callback, object state)
        {
            Server.Timer timer1 = new DelayStateCallTimer(delay, interval, count, callback, state);
            if (count == 1)
            {
                timer1.Priority = Server.Timer.ComputePriority(delay);
            }
            else
            {
                timer1.Priority = Server.Timer.ComputePriority(interval);
            }
            timer1.Start();
            return timer1;
        }

        public static void DumpInfo(TextWriter tw)
        {
            TimerThread.DumpInfo(tw);
        }

        private static string FormatDelegate(Delegate callback)
        {
            if (callback == null)
            {
                return "null";
            }
            return string.Format("{0}.{1}", callback.Method.DeclaringType.FullName, callback.Method.Name);
        }

        public TimerProfile GetProfile()
        {
            if (!Core.Profiling)
            {
                return null;
            }
            string text1 = this.ToString();
            if (text1 == null)
            {
                text1 = "null";
            }
            TimerProfile profile1 = ((TimerProfile) Server.Timer.m_Profiles[text1]);
            if (profile1 == null)
            {
                Server.Timer.m_Profiles[text1] = (profile1 = new TimerProfile());
            }
            return profile1;
        }

        protected virtual void OnTick()
        {
        }

        public virtual void RegCreation()
        {
            TimerProfile profile1 = this.GetProfile();
            if (profile1 != null)
            {
                profile1.RegCreation();
            }
        }

        public static void Slice()
        {
            int num1;
            DateTime time1;
            Server.Timer timer1;
            TimerProfile profile1;
            Queue queue1 = Server.Timer.m_Queue;
            lock (Server.Timer.m_Queue)
            {
                Server.Timer.m_QueueCountAtSlice = Server.Timer.m_Queue.Count;
                num1 = 0;
                time1 = DateTime.MinValue;
                goto Label_006B;
            Label_0026:
                timer1 = ((Server.Timer) Server.Timer.m_Queue.Dequeue());
                profile1 = timer1.GetProfile();
                if (profile1 != null)
                {
                    time1 = DateTime.Now;
                }
                timer1.OnTick();
                timer1.m_Queued = false;
                ++num1;
                if (profile1 != null)
                {
                    profile1.RegTicked(((TimeSpan) (DateTime.Now - time1)));
                }
            Label_006B:
                if (num1 >= Server.Timer.m_BreakCount)
                {
                    return;
                }
                if (!(Server.Timer.m_Queue.Count == 0))
                {
                    goto Label_0026;
                }
                return;
            }
        }

        public void Start()
        {
            TimerProfile profile1;
            if (!this.m_Running)
            {
                this.m_Running = true;
                TimerThread.AddTimer(this);
                profile1 = this.GetProfile();
                if (profile1 != null)
                {
                    profile1.RegStart();
                }
            }
        }

        public void Stop()
        {
            TimerProfile profile1;
            if (this.m_Running)
            {
                this.m_Running = false;
                TimerThread.RemoveTimer(this);
                profile1 = this.GetProfile();
                if (profile1 != null)
                {
                    profile1.RegStopped();
                }
            }
        }

        public override string ToString()
        {
            return base.GetType().FullName;
        }


        // Properties
        public static int BreakCount
        {
            get
            {
                return Server.Timer.m_BreakCount;
            }
            set
            {
                Server.Timer.m_BreakCount = value;
            }
        }

        public virtual bool DefRegCreation
        {
            get
            {
                return true;
            }
        }

        public TimeSpan Delay
        {
            get
            {
                return this.m_Delay;
            }
            set
            {
                this.m_Delay = value;
            }
        }

        public TimeSpan Interval
        {
            get
            {
                return this.m_Interval;
            }
            set
            {
                this.m_Interval = value;
            }
        }

        public TimerPriority Priority
        {
            get
            {
                return this.m_Priority;
            }
            set
            {
                if (this.m_Priority != value)
                {
                    this.m_Priority = value;
                    if (this.m_Running)
                    {
                        TimerThread.PriorityChange(this, ((int) this.m_Priority));
                    }
                }
            }
        }

        public static Hashtable Profiles
        {
            get
            {
                return Server.Timer.m_Profiles;
            }
        }

        public static Queue Queue
        {
            get
            {
                return Server.Timer.m_Queue;
            }
        }

        public static int QueueCountAtSlice
        {
            get
            {
                return Server.Timer.m_QueueCountAtSlice;
            }
        }

        public bool Running
        {
            get
            {
                return this.m_Running;
            }
            set
            {
                if (value)
                {
                    this.Start();
                    return;
                }
                this.Stop();
            }
        }


        // Fields
        private static int m_BreakCount;
        private int m_Count;
        private TimeSpan m_Delay;
        private int m_Index;
        private TimeSpan m_Interval;
        private ArrayList m_List;
        private DateTime m_Next;
        private TimerPriority m_Priority;
        private static Hashtable m_Profiles;
        private static Queue m_Queue;
        private static int m_QueueCountAtSlice;
        private bool m_Queued;
        private bool m_Running;

        // Nested Types
        private class DelayCallTimer : Server.Timer
        {
            // Methods
            public DelayCallTimer(TimeSpan delay, TimeSpan interval, int count, Server.TimerCallback callback) : base(delay, interval, count)
            {
                this.m_Callback = callback;
                this.RegCreation();
            }

            protected override void OnTick()
            {
                if (this.m_Callback != null)
                {
                    this.m_Callback.Invoke();
                }
            }

            public override string ToString()
            {
                return string.Format("DelayCallTimer[{0}]", Server.Timer.FormatDelegate(this.m_Callback));
            }


            // Properties
            public Server.TimerCallback Callback
            {
                get
                {
                    return this.m_Callback;
                }
            }

            public override bool DefRegCreation
            {
                get
                {
                    return false;
                }
            }


            // Fields
            private Server.TimerCallback m_Callback;
        }

        private class DelayStateCallTimer : Server.Timer
        {
            // Methods
            public DelayStateCallTimer(TimeSpan delay, TimeSpan interval, int count, TimerStateCallback callback, object state) : base(delay, interval, count)
            {
                this.m_Callback = callback;
                this.m_State = state;
                this.RegCreation();
            }

            protected override void OnTick()
            {
                if (this.m_Callback != null)
                {
                    this.m_Callback.Invoke(this.m_State);
                }
            }

            public override string ToString()
            {
                return string.Format("DelayStateCall[{0}]", Server.Timer.FormatDelegate(this.m_Callback));
            }


            // Properties
            public TimerStateCallback Callback
            {
                get
                {
                    return this.m_Callback;
                }
            }

            public override bool DefRegCreation
            {
                get
                {
                    return false;
                }
            }


            // Fields
            private TimerStateCallback m_Callback;
            private object m_State;
        }

        public class TimerThread
        {
            // Methods
            static TimerThread()
            {
                Server.Timer.TimerThread.m_ChangeQueue = Queue.Synchronized(new Queue());
                Server.Timer.TimerThread.m_NextPriorities = new DateTime[8];
                TimeSpan[] spanArray1 = new TimeSpan[8];
                spanArray1[0] = TimeSpan.Zero;
                spanArray1[1] = TimeSpan.FromMilliseconds(10);
                spanArray1[2] = TimeSpan.FromMilliseconds(25);
                spanArray1[3] = TimeSpan.FromMilliseconds(50);
                spanArray1[4] = TimeSpan.FromMilliseconds(250);
                spanArray1[5] = TimeSpan.FromSeconds(1);
                spanArray1[6] = TimeSpan.FromSeconds(5);
                spanArray1[7] = TimeSpan.FromMinutes(1);
                Server.Timer.TimerThread.m_PriorityDelays = spanArray1;
                ArrayList[] listArray1 = new ArrayList[8];
                listArray1[0] = new ArrayList();
                listArray1[1] = new ArrayList();
                listArray1[2] = new ArrayList();
                listArray1[3] = new ArrayList();
                listArray1[4] = new ArrayList();
                listArray1[5] = new ArrayList();
                listArray1[6] = new ArrayList();
                listArray1[7] = new ArrayList();
                Server.Timer.TimerThread.m_Timers = listArray1;
            }

            public TimerThread()
            {
            }

            public static void AddTimer(Server.Timer t)
            {
                Server.Timer.TimerThread.Change(t, ((int) t.Priority), true);
            }

            public static void Change(Server.Timer t, int newIndex, bool isAdd)
            {
                Server.Timer.TimerThread.m_ChangeQueue.Enqueue(TimerChangeEntry.GetInstance(t, newIndex, isAdd));
            }

            public static void DumpInfo(TextWriter tw)
            {
                int num1;
                Hashtable hashtable1;
                int num2;
                Server.Timer timer1;
                string text1;
                ArrayList list1;
                string text2;
                ArrayList list2;
                for (num1 = 0; (num1 < 8); ++num1)
                {
                    tw.WriteLine("Priority: {0}", num1);
                    tw.WriteLine();
                    hashtable1 = new Hashtable();
                    for (num2 = 0; (num2 < Server.Timer.TimerThread.m_Timers[num1].Count); ++num2)
                    {
                        timer1 = ((Server.Timer) Server.Timer.TimerThread.m_Timers[num1][num2]);
                        text1 = timer1.ToString();
                        list1 = ((ArrayList) hashtable1[text1]);
                        if (list1 == null)
                        {
                            hashtable1[text1] = (list1 = new ArrayList());
                        }
                        list1.Add(timer1);
                    }
                    foreach (DictionaryEntry entry1 in hashtable1)
                    {
                        text2 = ((string) entry1.Key);
                        list2 = ((ArrayList) entry1.Value);
                        tw.WriteLine("Type: {0}; Count: {1}; Percent: {2}%", text2, list2.Count, ((int) (100 * (list2.Count / Server.Timer.TimerThread.m_Timers[num1].Count))));
                    }
                    tw.WriteLine();
                    tw.WriteLine();
                }
            }

            public static void PriorityChange(Server.Timer t, int newPrio)
            {
                Server.Timer.TimerThread.Change(t, newPrio, false);
            }

            private static void ProcessChangeQueue()
            {
                TimerChangeEntry entry1;
                Server.Timer timer1;
                int num1;
                while ((Server.Timer.TimerThread.m_ChangeQueue.Count > 0))
                {
                    entry1 = ((TimerChangeEntry) Server.Timer.TimerThread.m_ChangeQueue.Dequeue());
                    timer1 = entry1.m_Timer;
                    num1 = entry1.m_NewIndex;
                    if (timer1.m_List != null)
                    {
                        timer1.m_List.Remove(timer1);
                    }
                    if (entry1.m_IsAdd)
                    {
                        timer1.m_Next = (DateTime.Now + timer1.m_Delay);
                        timer1.m_Index = 0;
                    }
                    if (num1 >= 0)
                    {
                        timer1.m_List = Server.Timer.TimerThread.m_Timers[num1];
                        timer1.m_List.Add(timer1);
                        continue;
                    }
                    timer1.m_List = null;
                }
            }

            public static void RemoveTimer(Server.Timer t)
            {
                Server.Timer.TimerThread.Change(t, -1, false);
            }

            public void TimerMain()
            {
                DateTime time1;
                int num1;
                int num2;
                Server.Timer timer1;
                Queue queue1;
                int num3;
                while (!Core.Closing)
                {
                    Thread.Sleep(10);
                    Server.Timer.TimerThread.ProcessChangeQueue();
                    num1 = 0;
                    while ((num1 < Server.Timer.TimerThread.m_Timers.Length))
                    {
                        time1 = DateTime.Now;
                        if (time1 >= Server.Timer.TimerThread.m_NextPriorities[num1])
                        {
                            Server.Timer.TimerThread.m_NextPriorities[num1] = (time1 + Server.Timer.TimerThread.m_PriorityDelays[num1]);
                            num2 = 0;
                            while ((num2 < Server.Timer.TimerThread.m_Timers[num1].Count))
                            {
                                timer1 = ((Server.Timer) Server.Timer.TimerThread.m_Timers[num1][num2]);
                                if (!timer1.m_Queued && (time1 > timer1.m_Next))
                                {
                                    timer1.m_Queued = true;
                                    queue1 = Server.Timer.m_Queue;
                                    lock (Server.Timer.m_Queue)
                                    {
                                        Server.Timer.m_Queue.Enqueue(timer1);
                                    }
                                    if (timer1.m_Count != 0)
                                    {
                                        timer1.m_Index = (num3 = (timer1.m_Index + 1));
                                        if (num3 >= timer1.m_Count)
                                        {
                                            timer1.Stop();
                                            goto Label_00F5;
                                        }
                                    }
                                    timer1.m_Next = (time1 + timer1.m_Interval);
                                }
                            Label_00F5:
                                ++num2;
                            }
                            ++num1;
                        }
                    }
                }
            }


            // Fields
            private static Queue m_ChangeQueue;
            private static DateTime[] m_NextPriorities;
            private static TimeSpan[] m_PriorityDelays;
            private static ArrayList[] m_Timers;

            // Nested Types
            private class TimerChangeEntry
            {
                // Methods
                static TimerChangeEntry()
                {
                    Server.Timer.TimerThread.TimerChangeEntry.m_InstancePool = new Queue();
                }

                private TimerChangeEntry(Server.Timer t, int newIndex, bool isAdd)
                {
                    this.m_Timer = t;
                    this.m_NewIndex = newIndex;
                    this.m_IsAdd = isAdd;
                }

                public void Free()
                {
                    Server.Timer.TimerThread.TimerChangeEntry.m_InstancePool.Enqueue(this);
                }

                public static Server.Timer.TimerThread.TimerChangeEntry GetInstance(Server.Timer t, int newIndex, bool isAdd)
                {
                    Server.Timer.TimerThread.TimerChangeEntry entry1;
                    if (Server.Timer.TimerThread.TimerChangeEntry.m_InstancePool.Count > 0)
                    {
                        entry1 = ((Server.Timer.TimerThread.TimerChangeEntry) Server.Timer.TimerThread.TimerChangeEntry.m_InstancePool.Dequeue());
                        entry1.m_Timer = t;
                        entry1.m_NewIndex = newIndex;
                        entry1.m_IsAdd = isAdd;
                        return entry1;
                    }
                    return new Server.Timer.TimerThread.TimerChangeEntry(t, newIndex, isAdd);
                }


                // Fields
                private static Queue m_InstancePool;
                public bool m_IsAdd;
                public int m_NewIndex;
                public Server.Timer m_Timer;
            }
        }
    }
}

