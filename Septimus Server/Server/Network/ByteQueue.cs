namespace Server.Network
{
    using System;
    using System.IO;

    public class ByteQueue
    {
        // Methods
        public ByteQueue()
        {
            this.m_Length = 0;
            this.m_Capacity = 0;
            this.m_Buffer = new byte[this.m_Capacity];
        }

        public void Dequeue(byte[] buffer)
        {
            this.Dequeue(buffer, 0, buffer.Length);
        }

        public byte[] Dequeue(int count)
        {
            byte[] buffer1 = new byte[count];
            this.Dequeue(buffer1, 0, count);
            return buffer1;
        }

        public void Dequeue(byte[] buffer, int offset, int count)
        {
            int num2;
            Buffer.BlockCopy(this.m_Buffer, 0, buffer, offset, count);
            this.m_Length -= count;
            int num1 = count;
            for (num2 = 0; (num2 < this.m_Length); ++num2)
            {
                this.m_Buffer[num2] = this.m_Buffer[num1];
                ++num1;
            }
        }

        public void Enqueue(byte[] buffer)
        {
            this.Enqueue(buffer, 0, buffer.Length);
        }

        public void Enqueue(Stream stream, int count)
        {
            byte[] buffer1 = new byte[count];
            count = stream.Read(buffer1, 0, count);
            this.Enqueue(buffer1, 0, count);
        }

        public void Enqueue(byte[] buffer, int offset, int count)
        {
            this.EnsureCapacity((this.m_Length + count));
            Buffer.BlockCopy(buffer, offset, this.m_Buffer, this.m_Length, count);
            this.m_Length += count;
        }

        private void EnsureCapacity(int length)
        {
            byte[] buffer1;
            if (length > this.m_Capacity)
            {
                buffer1 = this.m_Buffer;
                this.m_Capacity = ((length + 2047) & -2048);
                this.m_Buffer = new byte[this.m_Capacity];
                Buffer.BlockCopy(buffer1, 0, this.m_Buffer, 0, this.m_Length);
            }
        }

        public void Peek(byte[] buffer)
        {
            this.Peek(buffer, 0, buffer.Length);
        }

        public byte[] Peek(int count)
        {
            byte[] buffer1 = new byte[count];
            this.Peek(buffer1, 0, count);
            return buffer1;
        }

        public void Peek(byte[] buffer, int offset, int count)
        {
            Buffer.BlockCopy(this.m_Buffer, 0, buffer, offset, count);
        }


        // Properties
        public int Capacity
        {
            get
            {
                return this.m_Capacity;
            }
        }

        public int Length
        {
            get
            {
                return this.m_Length;
            }
        }


        // Fields
        private byte[] m_Buffer;
        private int m_Capacity;
        private int m_Length;
    }
}

