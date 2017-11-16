namespace Server.Network
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Text;

    public class PacketWriter
    {
        // Methods
        static PacketWriter()
        {
            PacketWriter.m_Pool = new Stack();
            PacketWriter.m_Buffer = new byte[4];
        }

        public PacketWriter() : this(32)
        {
        }

        public PacketWriter(int capacity)
        {
            this.m_Stream = new MemoryStream(capacity);
            this.m_Capacity = capacity;
        }

        public static PacketWriter CreateInstance()
        {
            return PacketWriter.CreateInstance(32);
        }

        public static PacketWriter CreateInstance(int capacity)
        {
            PacketWriter writer1 = null;
            Stack stack1 = PacketWriter.m_Pool;
            lock (PacketWriter.m_Pool)
            {
                if (PacketWriter.m_Pool.Count > 0)
                {
                    writer1 = ((PacketWriter) PacketWriter.m_Pool.Pop());
                    if (writer1 != null)
                    {
                        writer1.m_Capacity = capacity;
                        writer1.m_Stream.SetLength(0);
                    }
                }
            }
            if (writer1 == null)
            {
                writer1 = new PacketWriter(capacity);
            }
            return writer1;
        }

        public void Fill()
        {
            this.Fill(((int) (this.m_Capacity - this.m_Stream.Length)));
        }

        public void Fill(int length)
        {
            if (this.m_Stream.Position == this.m_Stream.Length)
            {
                this.m_Stream.SetLength((this.m_Stream.Length + length));
                this.m_Stream.Seek(0, SeekOrigin.End);
                return;
            }
            this.m_Stream.Write(new byte[length], 0, length);
        }

        public static void ReleaseInstance(PacketWriter pw)
        {
            Stack stack1 = PacketWriter.m_Pool;
            lock (PacketWriter.m_Pool)
            {
                if (!PacketWriter.m_Pool.Contains(pw))
                {
                    PacketWriter.m_Pool.Push(pw);
                    return;
                }
                try
                {
                    using (StreamWriter writer1 = new StreamWriter("neterr.log"))
                    {
                        writer1.WriteLine("{0}\tInstance pool contains writer", DateTime.Now);
                        return;
                    }
                }
                catch
                {
                    Console.WriteLine("net error");
                    return;
                }
            }
        }

        public long Seek(long offset, SeekOrigin origin)
        {
            return this.m_Stream.Seek(offset, origin);
        }

        public byte[] ToArray()
        {
            return this.m_Stream.ToArray();
        }

        public void Write(bool value)
        {
            this.m_Stream.WriteByte(((byte) (value ? 1 : 0)));
        }

        public void Write(byte value)
        {
            this.m_Stream.WriteByte(value);
        }

        public void Write(short value)
        {
            PacketWriter.m_Buffer[0] = ((byte) (value >> 8));
            PacketWriter.m_Buffer[1] = ((byte) value);
            this.m_Stream.Write(PacketWriter.m_Buffer, 0, 2);
        }

        public void Write(int value)
        {
            PacketWriter.m_Buffer[0] = ((byte) (value >> 24));
            PacketWriter.m_Buffer[1] = ((byte) (value >> 16));
            PacketWriter.m_Buffer[2] = ((byte) (value >> 8));
            PacketWriter.m_Buffer[3] = ((byte) value);
            this.m_Stream.Write(PacketWriter.m_Buffer, 0, 4);
        }

        public void Write(sbyte value)
        {
            this.m_Stream.WriteByte(((byte) value));
        }

        public void Write(ushort value)
        {
            PacketWriter.m_Buffer[0] = ((byte) (value >> 8));
            PacketWriter.m_Buffer[1] = ((byte) value);
            this.m_Stream.Write(PacketWriter.m_Buffer, 0, 2);
        }

        public void Write(uint value)
        {
            PacketWriter.m_Buffer[0] = ((byte) (value >> 24));
            PacketWriter.m_Buffer[1] = ((byte) (value >> 16));
            PacketWriter.m_Buffer[2] = ((byte) (value >> 8));
            PacketWriter.m_Buffer[3] = ((byte) value);
            this.m_Stream.Write(PacketWriter.m_Buffer, 0, 4);
        }

        public void Write(byte[] buffer, int offset, int size)
        {
            this.m_Stream.Write(buffer, offset, size);
        }

        public void WriteAsciiFixed(string value, int size)
        {
            if (value == null)
            {
                Console.WriteLine("Network: Attempted to WriteAsciiFixed() with null value");
                value = string.Empty;
            }
            byte[] buffer1 = Encoding.ASCII.GetBytes(value);
            if (buffer1.Length >= size)
            {
                this.m_Stream.Write(buffer1, 0, size);
                return;
            }
            this.m_Stream.Write(buffer1, 0, buffer1.Length);
            this.Fill((size - buffer1.Length));
        }

        public void WriteAsciiNull(string value)
        {
            if (value == null)
            {
                Console.WriteLine("Network: Attempted to WriteAsciiNull() with null value");
                value = string.Empty;
            }
            byte[] buffer1 = Encoding.ASCII.GetBytes(value);
            this.m_Stream.Write(buffer1, 0, buffer1.Length);
            this.m_Stream.WriteByte(0);
        }

        public void WriteBigUniFixed(string value, int size)
        {
            if (value == null)
            {
                Console.WriteLine("Network: Attempted to WriteBigUniFixed() with null value");
                value = string.Empty;
            }
            size *= 2;
            byte[] buffer1 = Encoding.BigEndianUnicode.GetBytes(value);
            if (buffer1.Length >= size)
            {
                this.m_Stream.Write(buffer1, 0, size);
                return;
            }
            this.m_Stream.Write(buffer1, 0, buffer1.Length);
            this.Fill((size - buffer1.Length));
        }

        public void WriteBigUniNull(string value)
        {
            if (value == null)
            {
                Console.WriteLine("Network: Attempted to WriteBigUniNull() with null value");
                value = string.Empty;
            }
            byte[] buffer1 = Encoding.BigEndianUnicode.GetBytes(value);
            this.m_Stream.Write(buffer1, 0, buffer1.Length);
            PacketWriter.m_Buffer[0] = 0;
            PacketWriter.m_Buffer[1] = 0;
            this.m_Stream.Write(PacketWriter.m_Buffer, 0, 2);
        }

        public void WriteLittleUniFixed(string value, int size)
        {
            if (value == null)
            {
                Console.WriteLine("Network: Attempted to WriteLittleUniFixed() with null value");
                value = string.Empty;
            }
            size *= 2;
            byte[] buffer1 = Encoding.Unicode.GetBytes(value);
            if (buffer1.Length >= size)
            {
                this.m_Stream.Write(buffer1, 0, size);
                return;
            }
            this.m_Stream.Write(buffer1, 0, buffer1.Length);
            this.Fill((size - buffer1.Length));
        }

        public void WriteLittleUniNull(string value)
        {
            if (value == null)
            {
                Console.WriteLine("Network: Attempted to WriteLittleUniNull() with null value");
                value = string.Empty;
            }
            byte[] buffer1 = Encoding.Unicode.GetBytes(value);
            this.m_Stream.Write(buffer1, 0, buffer1.Length);
            PacketWriter.m_Buffer[0] = 0;
            PacketWriter.m_Buffer[1] = 0;
            this.m_Stream.Write(PacketWriter.m_Buffer, 0, 2);
        }


        // Properties
        public long Length
        {
            get
            {
                return this.m_Stream.Length;
            }
        }

        public long Position
        {
            get
            {
                return this.m_Stream.Position;
            }
            set
            {
                this.m_Stream.Position = value;
            }
        }

        public MemoryStream UnderlyingStream
        {
            get
            {
                return this.m_Stream;
            }
        }


        // Fields
        private static byte[] m_Buffer;
        private int m_Capacity;
        private static Stack m_Pool;
        private MemoryStream m_Stream;
    }
}

