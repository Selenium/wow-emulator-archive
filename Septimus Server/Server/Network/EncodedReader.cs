namespace Server.Network
{
    using Server;
    using System;

    public class EncodedReader
    {
        // Methods
        public EncodedReader(PacketReader reader)
        {
            this.m_Reader = reader;
        }

        public int ReadInt32()
        {
            if (this.m_Reader.ReadByte() != 0)
            {
                return 0;
            }
            return this.m_Reader.ReadInt32();
        }

        public Point3D ReadPoint3D()
        {
            if (this.m_Reader.ReadByte() != 3)
            {
                return Point3D.Zero;
            }
            return new Point3D(this.m_Reader.ReadInt16(), this.m_Reader.ReadInt16(), this.m_Reader.ReadByte());
        }

        public string ReadUnicodeString()
        {
            if (this.m_Reader.ReadByte() != 2)
            {
                return "";
            }
            int num1 = this.m_Reader.ReadUInt16();
            return this.m_Reader.ReadUnicodeString(num1);
        }

        public string ReadUnicodeStringSafe()
        {
            if (this.m_Reader.ReadByte() != 2)
            {
                return "";
            }
            int num1 = this.m_Reader.ReadUInt16();
            return this.m_Reader.ReadUnicodeStringSafe(num1);
        }

        public void Trace(NetState state)
        {
            this.m_Reader.Trace(state);
        }


        // Properties
        public byte[] Buffer
        {
            get
            {
                return this.m_Reader.Buffer;
            }
        }


        // Fields
        private PacketReader m_Reader;
    }
}

