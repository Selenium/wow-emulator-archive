namespace Server
{
    using Server.Guilds;
    using System;
    using System.Collections;
    using System.IO;
    using System.Net;
    using System.Threading;

    public class AsyncWriter : GenericWriter
    {
        // Methods
        static AsyncWriter()
        {
            AsyncWriter.m_ThreadCount = 0;
        }

        public AsyncWriter(string filename, bool prefix) : this(filename, 1048576, prefix)
        {
        }

        public AsyncWriter(string filename, int buffSize, bool prefix)
        {
            this.PrefixStrings = prefix;
            this.m_Closed = false;
            this.m_WriteQueue = Queue.Synchronized(new Queue());
            this.BufferSize = buffSize;
            this.m_File = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            this.m_Mem = new MemoryStream((this.BufferSize + 1024));
            this.m_Bin = new BinaryWriter(this.m_Mem, Utility.UTF8WithEncoding);
        }

        public override void Close()
        {
            this.Enqueue(this.m_Mem);
            this.m_Closed = true;
        }

        private void Enqueue(MemoryStream mem)
        {
            this.m_WriteQueue.Enqueue(mem);
            if ((this.m_WorkerThread != null) && this.m_WorkerThread.IsAlive)
            {
                return;
            }
            this.m_WorkerThread = new Thread(new ThreadStart(new WorkerThread(this).Worker));
            this.m_WorkerThread.Priority = ThreadPriority.BelowNormal;
            this.m_WorkerThread.Start();
        }

        private void OnWrite()
        {
            long num1 = this.m_Mem.Length;
            this.m_CurPos += (num1 - this.m_LastPos);
            this.m_LastPos = num1;
            if (num1 >= this.BufferSize)
            {
                this.Enqueue(this.m_Mem);
                this.m_Mem = new MemoryStream((this.BufferSize + 1024));
                this.m_Bin = new BinaryWriter(this.m_Mem, Utility.UTF8WithEncoding);
                this.m_LastPos = 0;
            }
        }

        public override void Write(BaseGuild value)
        {
            if (value == null)
            {
                this.Write(0);
                return;
            }
            this.Write(value.Id);
        }

        public override void Write(Item value)
        {
            if ((value == null) || value.Deleted)
            {
                this.Write(Serial.op_Implicit(Serial.MinusOne));
                return;
            }
            this.Write(Serial.op_Implicit(value.Serial));
        }

        public override void Write(Map value)
        {
            if (value != null)
            {
                this.Write(((byte) value.MapIndex));
                return;
            }
            this.Write(((byte) 255));
        }

        public override void Write(Mobile value)
        {
            if ((value == null) || value.Deleted)
            {
                this.Write(Serial.op_Implicit(Serial.MinusOne));
                return;
            }
            this.Write(Serial.op_Implicit(value.Serial));
        }

        public override void Write(Point2D value)
        {
            this.Write(value.m_X);
            this.Write(value.m_Y);
        }

        public override void Write(Point3D value)
        {
            this.Write(value.m_X);
            this.Write(value.m_Y);
            this.Write(value.m_Z);
        }

        public override void Write(Rectangle2D value)
        {
            this.Write(value.Start);
            this.Write(value.End);
        }

        public override void Write(bool value)
        {
            this.m_Bin.Write(value);
            this.OnWrite();
        }

        public override void Write(byte value)
        {
            this.m_Bin.Write(value);
            this.OnWrite();
        }

        public override void Write(char value)
        {
            this.m_Bin.Write(value);
            this.OnWrite();
        }

        public override void Write(DateTime value)
        {
            this.m_Bin.Write(value.Ticks);
            this.OnWrite();
        }

        public override void Write(decimal value)
        {
            this.m_Bin.Write(value);
            this.OnWrite();
        }

        public override void Write(double value)
        {
            this.m_Bin.Write(value);
            this.OnWrite();
        }

        public override void Write(short value)
        {
            this.m_Bin.Write(value);
            this.OnWrite();
        }

        public override void Write(int value)
        {
            this.m_Bin.Write(value);
            this.OnWrite();
        }

        public override void Write(long value)
        {
            this.m_Bin.Write(value);
            this.OnWrite();
        }

        public override void Write(IPAddress value)
        {
            this.m_Bin.Write(value.Address);
            this.OnWrite();
        }

        public override void Write(sbyte value)
        {
            this.m_Bin.Write(value);
            this.OnWrite();
        }

        public override void Write(float value)
        {
            this.m_Bin.Write(value);
            this.OnWrite();
        }

        public override void Write(string value)
        {
            if (this.PrefixStrings)
            {
                if (value == null)
                {
                    this.m_Bin.Write(((byte) 0));
                }
                else
                {
                    this.m_Bin.Write(((byte) 1));
                    this.m_Bin.Write(value);
                }
            }
            else
            {
                this.m_Bin.Write(value);
            }
            this.OnWrite();
        }

        public override void Write(TimeSpan value)
        {
            this.m_Bin.Write(value.Ticks);
            this.OnWrite();
        }

        public override void Write(ushort value)
        {
            this.m_Bin.Write(value);
            this.OnWrite();
        }

        public override void Write(uint value)
        {
            this.m_Bin.Write(value);
            this.OnWrite();
        }

        public override void Write(ulong value)
        {
            this.m_Bin.Write(value);
            this.OnWrite();
        }

        public override void WriteDeltaTime(DateTime value)
        {
            TimeSpan span1;
            long num1 = value.Ticks;
            DateTime time1 = DateTime.Now;
            long num2 = time1.Ticks;
            try
            {
                span1 = new TimeSpan((num1 - num2));
            }
            catch
            {
                if (num1 < num2)
                {
                    span1 = TimeSpan.MaxValue;
                    goto Label_0037;
                }
                span1 = TimeSpan.MaxValue;
            }
        Label_0037:
            this.Write(span1);
        }

        public override void WriteEncodedInt(int value)
        {
            uint num1 = ((uint) value);
            while ((num1 >= 128))
            {
                this.m_Bin.Write(((byte) (num1 | 128)));
                num1 = ((uint) (num1 >> 7));
            }
            this.m_Bin.Write(((byte) num1));
            this.OnWrite();
        }

        public override void WriteGuildList(ArrayList list)
        {
            this.WriteGuildList(list, false);
        }

        public override void WriteGuildList(ArrayList list, bool tidy)
        {
            int num1;
            int num2;
            if (tidy)
            {
                for (num1 = 0; (num1 < list.Count); ++num1)
                {
                    if (((BaseGuild) list[num1]).Disbanded)
                    {
                        list.RemoveAt(num1);
                        continue;
                    }
                }
            }
            this.Write(list.Count);
            for (num2 = 0; (num2 < list.Count); ++num2)
            {
                this.Write(((BaseGuild) list[num2]));
            }
        }

        public override void WriteItemList(ArrayList list)
        {
            this.WriteItemList(list, false);
        }

        public override void WriteItemList(ArrayList list, bool tidy)
        {
            int num1;
            int num2;
            if (tidy)
            {
                for (num1 = 0; (num1 < list.Count); ++num1)
                {
                    if (((Item) list[num1]).Deleted)
                    {
                        list.RemoveAt(num1);
                        continue;
                    }
                }
            }
            this.Write(list.Count);
            for (num2 = 0; (num2 < list.Count); ++num2)
            {
                this.Write(((Item) list[num2]));
            }
        }

        public override void WriteMobileList(ArrayList list)
        {
            this.WriteMobileList(list, false);
        }

        public override void WriteMobileList(ArrayList list, bool tidy)
        {
            int num1;
            int num2;
            if (tidy)
            {
                for (num1 = 0; (num1 < list.Count); ++num1)
                {
                    if (((Mobile) list[num1]).Deleted)
                    {
                        list.RemoveAt(num1);
                        continue;
                    }
                }
            }
            this.Write(list.Count);
            for (num2 = 0; (num2 < list.Count); ++num2)
            {
                this.Write(((Mobile) list[num2]));
            }
        }


        // Properties
        public MemoryStream MemStream
        {
            get
            {
                return this.m_Mem;
            }
            set
            {
                if (this.m_Mem.Length > 0)
                {
                    this.Enqueue(this.m_Mem);
                }
                this.m_Mem = value;
                this.m_Bin = new BinaryWriter(this.m_Mem, Utility.UTF8WithEncoding);
                this.m_LastPos = 0;
                this.m_CurPos = this.m_Mem.Length;
                this.m_Mem.Seek(0, SeekOrigin.End);
            }
        }

        public override long Position
        {
            get
            {
                return this.m_CurPos;
            }
        }

        public static int ThreadCount
        {
            get
            {
                return AsyncWriter.m_ThreadCount;
            }
        }


        // Fields
        private int BufferSize;
        private BinaryWriter m_Bin;
        private bool m_Closed;
        private long m_CurPos;
        private FileStream m_File;
        private long m_LastPos;
        private MemoryStream m_Mem;
        private static int m_ThreadCount;
        private Thread m_WorkerThread;
        private Queue m_WriteQueue;
        private bool PrefixStrings;

        // Nested Types
        private class WorkerThread
        {
            // Methods
            public WorkerThread(AsyncWriter owner)
            {
                this.m_Owner = owner;
            }

            public void Worker()
            {
                MemoryStream stream1;
                ++AsyncWriter.m_ThreadCount;
                while ((this.m_Owner.m_WriteQueue.Count > 0))
                {
                    stream1 = ((MemoryStream) this.m_Owner.m_WriteQueue.Dequeue());
                    if ((stream1 != null) && (stream1.Length > 0))
                    {
                        stream1.WriteTo(this.m_Owner.m_File);
                    }
                }
                if (this.m_Owner.m_Closed)
                {
                    this.m_Owner.m_File.Close();
                }
                --AsyncWriter.m_ThreadCount;
            }


            // Fields
            private AsyncWriter m_Owner;
        }
    }
}

