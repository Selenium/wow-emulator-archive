namespace Server.Network
{
    using System;
    using System.IO;

    public abstract class Packet
    {
        // Methods
        public Packet(int packetID)
        {
            this.m_PacketID = packetID;
            PacketProfile profile1 = PacketProfile.GetOutgoingProfile(((byte) packetID));
            if (profile1 != null)
            {
                profile1.RegConstruct();
            }
        }

        public Packet(int packetID, int length)
        {
            this.m_PacketID = packetID;
            this.m_Length = length;
            this.m_Stream = PacketWriter.CreateInstance(length);
            this.m_Stream.Write(((byte) packetID));
            PacketProfile profile1 = PacketProfile.GetOutgoingProfile(((byte) packetID));
            if (profile1 != null)
            {
                profile1.RegConstruct();
            }
        }

        public byte[] Compile(bool compress)
        {
            if (this.m_CompiledBuffer == null)
            {
                this.InternalCompile(compress);
            }
            return this.m_CompiledBuffer;
        }

        public void EnsureCapacity(int length)
        {
            this.m_Stream = PacketWriter.CreateInstance(length);
            this.m_Stream.Write(((byte) this.m_PacketID));
            this.m_Stream.Write(((short) 0));
        }

        private void InternalCompile(bool compress)
        {
            long num1;
            int num2;
            byte[] buffer1;
            if (this.m_Length == 0)
            {
                num1 = this.m_Stream.Length;
                this.m_Stream.Seek(1, SeekOrigin.Begin);
                this.m_Stream.Write(((ushort) num1));
            }
            else if (this.m_Stream.Length != this.m_Length)
            {
                num2 = (((int) this.m_Stream.Length) - this.m_Length);
                Console.WriteLine("Packet: 0x{0:X2}: Bad packet length! ({1}{2} bytes)", this.m_PacketID, ((num2 >= 0) ? "+" : ""), num2);
            }
            MemoryStream stream1 = this.m_Stream.UnderlyingStream;
            this.m_CompiledBuffer = stream1.GetBuffer();
            int num3 = ((int) stream1.Length);
            if (compress)
            {
                try
                {
                    Compression.Compress(this.m_CompiledBuffer, num3, out this.m_CompiledBuffer, out num3);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Warning: Compression buffer overflowed on packet 0x{0:X2} (\'{1}\') (length={2})", this.m_PacketID, base.GetType().Name, num3);
                    this.m_CompiledBuffer = null;
                }
            }
            if (this.m_CompiledBuffer != null)
            {
                buffer1 = this.m_CompiledBuffer;
                this.m_CompiledBuffer = new byte[num3];
                Buffer.BlockCopy(buffer1, 0, this.m_CompiledBuffer, 0, num3);
            }
            PacketWriter.ReleaseInstance(this.m_Stream);
            this.m_Stream = null;
        }


        // Properties
        public int PacketID
        {
            get
            {
                return this.m_PacketID;
            }
        }

        public PacketWriter UnderlyingStream
        {
            get
            {
                return this.m_Stream;
            }
        }


        // Fields
        private byte[] m_CompiledBuffer;
        private int m_Length;
        private int m_PacketID;
        protected PacketWriter m_Stream;
    }
}

