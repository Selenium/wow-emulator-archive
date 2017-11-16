namespace Server.Network
{
    using System;
    using System.Collections;

    public class SendQueue
    {
        // Methods
        static SendQueue()
        {
            SendQueue.m_CoalesceBufferSize = 512;
            SendQueue.m_UnusedBuffers = new Stack();
        }

        public SendQueue()
        {
            this.m_Queue = new Queue();
        }

        public byte[] Dequeue(ref int length)
        {
            Server.Network.SendQueue.Entry entry1;
            Server.Network.SendQueue.Entry.Release(((Server.Network.SendQueue.Entry) this.m_Queue.Dequeue()));
            if ((this.m_Queue.Count == 0) && (this.m_Buffered != null))
            {
                this.m_Queue.Enqueue(this.m_Buffered);
                this.m_Buffered = null;
            }
            if (this.m_Queue.Count > 0)
            {
                entry1 = ((Server.Network.SendQueue.Entry) this.m_Queue.Peek());
                length = entry1.m_Length;
                return entry1.m_Buffer;
            }
            return null;
        }

        public bool Enqueue(byte[] buffer, int length)
        {
            if (buffer == null)
            {
                Console.WriteLine("Warning: Attempting to send null packet buffer");
                return false;
            }
            if (this.m_Queue.Count == 0)
            {
                this.m_Queue.Enqueue(Server.Network.SendQueue.Entry.Pool(buffer, length, false));
                return true;
            }
            if ((this.m_Buffered != null) && ((this.m_Buffered.m_Length + length) > this.m_Buffered.m_Buffer.Length))
            {
                this.m_Queue.Enqueue(this.m_Buffered);
                this.m_Buffered = null;
            }
            if (length >= SendQueue.m_CoalesceBufferSize)
            {
                this.m_Queue.Enqueue(Server.Network.SendQueue.Entry.Pool(buffer, length, false));
            }
            else
            {
                if (this.m_Buffered == null)
                {
                    this.m_Buffered = Server.Network.SendQueue.Entry.Pool(SendQueue.GetUnusedBuffer(), 0, true);
                }
                Buffer.BlockCopy(buffer, 0, this.m_Buffered.m_Buffer, this.m_Buffered.m_Length, length);
                this.m_Buffered.m_Length += length;
            }
            return false;
        }

        public static byte[] GetUnusedBuffer()
        {
            byte[] buffer1;
            Stack stack1 = SendQueue.m_UnusedBuffers;
            lock (SendQueue.m_UnusedBuffers)
            {
                if (SendQueue.m_UnusedBuffers.Count == 0)
                {
                    return new byte[SendQueue.m_CoalesceBufferSize];
                }
                return ((byte[]) SendQueue.m_UnusedBuffers.Pop());
            }
            return buffer1;
        }

        public static void ReleaseBuffer(byte[] buffer)
        {
            Stack stack1 = SendQueue.m_UnusedBuffers;
            lock (SendQueue.m_UnusedBuffers)
            {
                if (buffer == null)
                {
                    Console.WriteLine("Warning: Attempting to release null packet buffer");
                    return;
                }
                if (buffer.Length == SendQueue.m_CoalesceBufferSize)
                {
                    SendQueue.m_UnusedBuffers.Push(buffer);
                }
            }
        }


        // Properties
        public static int CoalesceBufferSize
        {
            get
            {
                return SendQueue.m_CoalesceBufferSize;
            }
            set
            {
                Stack stack1 = SendQueue.m_UnusedBuffers;
                lock (SendQueue.m_UnusedBuffers)
                {
                    SendQueue.m_UnusedBuffers.Clear();
                    SendQueue.m_CoalesceBufferSize = value;
                }
            }
        }


        // Fields
        private Server.Network.SendQueue.Entry m_Buffered;
        private static int m_CoalesceBufferSize;
        private Queue m_Queue;
        private static Stack m_UnusedBuffers;

        // Nested Types
        private class Entry
        {
            // Methods
            static Entry()
            {
                SendQueue.Entry.m_Pool = new Stack();
            }

            private Entry(byte[] buffer, int length, bool managed)
            {
                this.m_Buffer = buffer;
                this.m_Length = length;
                this.m_Managed = managed;
            }

            public static SendQueue.Entry Pool(byte[] buffer, int length, bool managed)
            {
                SendQueue.Entry entry1;
                SendQueue.Entry entry2;
                Stack stack1 = SendQueue.Entry.m_Pool;
                lock (SendQueue.Entry.m_Pool)
                {
                    if (SendQueue.Entry.m_Pool.Count == 0)
                    {
                        return new SendQueue.Entry(buffer, length, managed);
                    }
                    entry1 = ((SendQueue.Entry) SendQueue.Entry.m_Pool.Pop());
                    entry1.m_Buffer = buffer;
                    entry1.m_Length = length;
                    entry1.m_Managed = managed;
                    return entry1;
                }
                return entry2;
            }

            public static void Release(SendQueue.Entry e)
            {
                Stack stack1 = SendQueue.Entry.m_Pool;
                lock (SendQueue.Entry.m_Pool)
                {
                    SendQueue.Entry.m_Pool.Push(e);
                    if (e.m_Managed)
                    {
                        SendQueue.ReleaseBuffer(e.m_Buffer);
                    }
                }
            }


            // Fields
            public byte[] m_Buffer;
            public int m_Length;
            public bool m_Managed;
            private static Stack m_Pool;
        }
    }
}

