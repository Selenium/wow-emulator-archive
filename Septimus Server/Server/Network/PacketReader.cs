namespace Server.Network
{
    using Server;
    using System;
    using System.IO;
    using System.Text;

    public class PacketReader
    {
        // Methods
        public PacketReader(byte[] data, bool fixedSize)
        {
            this.m_Data = data;
            this.m_Index = (fixedSize ? 1 : 3);
        }

        public bool IsSafeChar(int c)
        {
            if (c >= 32)
            {
                return (c < 65534);
            }
            return false;
        }

        public bool ReadBoolean()
        {
            if ((this.m_Index + 1) > this.m_Data.Length)
            {
                return false;
            }
            return (this.m_Data[this.m_Index++] != 0);
        }

        public byte ReadByte()
        {
            if ((this.m_Index + 1) > this.m_Data.Length)
            {
                return 0;
            }
            return this.m_Data[this.m_Index++];
        }

        public short ReadInt16()
        {
            if ((this.m_Index + 2) > this.m_Data.Length)
            {
                return 0;
            }
            return ((short) ((this.m_Data[this.m_Index++] << 8) | this.m_Data[this.m_Index++]));
        }

        public int ReadInt32()
        {
            if ((this.m_Index + 4) > this.m_Data.Length)
            {
                return 0;
            }
            return ((((this.m_Data[this.m_Index++] << 24) | (this.m_Data[this.m_Index++] << 16)) | (this.m_Data[this.m_Index++] << 8)) | this.m_Data[this.m_Index++]);
        }

        public sbyte ReadSByte()
        {
            if ((this.m_Index + 1) > this.m_Data.Length)
            {
                return 0;
            }
            return ((sbyte) this.m_Data[this.m_Index++]);
        }

        public string ReadString()
        {
            int num1;
            StringBuilder builder1 = new StringBuilder();
            while (((this.m_Index < this.m_Data.Length) && ((num1 = this.m_Data[this.m_Index++]) != 0)))
            {
                builder1.Append(((char) ((ushort) num1)));
            }
            return builder1.ToString();
        }

        public string ReadString(int fixedLength)
        {
            int num3;
            int num1 = (this.m_Index + fixedLength);
            int num2 = num1;
            if (num1 > this.m_Data.Length)
            {
                num1 = this.m_Data.Length;
            }
            StringBuilder builder1 = new StringBuilder();
            while (((this.m_Index < num1) && ((num3 = this.m_Data[this.m_Index++]) != 0)))
            {
                builder1.Append(((char) ((ushort) num3)));
            }
            this.m_Index = num2;
            return builder1.ToString();
        }

        public string ReadStringSafe()
        {
            int num1;
            StringBuilder builder1 = new StringBuilder();
            while (((this.m_Index < this.m_Data.Length) && ((num1 = this.m_Data[this.m_Index++]) != 0)))
            {
                if (!this.IsSafeChar(num1))
                {
                    continue;
                }
                builder1.Append(((char) ((ushort) num1)));
            }
            return builder1.ToString();
        }

        public string ReadStringSafe(int fixedLength)
        {
            int num3;
            int num1 = (this.m_Index + fixedLength);
            int num2 = num1;
            if (num1 > this.m_Data.Length)
            {
                num1 = this.m_Data.Length;
            }
            StringBuilder builder1 = new StringBuilder();
            while (((this.m_Index < num1) && ((num3 = this.m_Data[this.m_Index++]) != 0)))
            {
                if (!this.IsSafeChar(num3))
                {
                    continue;
                }
                builder1.Append(((char) ((ushort) num3)));
            }
            this.m_Index = num2;
            return builder1.ToString();
        }

        public ushort ReadUInt16()
        {
            if ((this.m_Index + 2) > this.m_Data.Length)
            {
                return 0;
            }
            return ((ushort) ((this.m_Data[this.m_Index++] << 8) | this.m_Data[this.m_Index++]));
        }

        public uint ReadUInt32()
        {
            if ((this.m_Index + 4) > this.m_Data.Length)
            {
                return 0;
            }
            return ((uint) ((((this.m_Data[this.m_Index++] << 24) | (this.m_Data[this.m_Index++] << 16)) | (this.m_Data[this.m_Index++] << 8)) | this.m_Data[this.m_Index++]));
        }

        public string ReadUnicodeString()
        {
            int num1;
            StringBuilder builder1 = new StringBuilder();
            while ((((this.m_Index + 1) < this.m_Data.Length) && ((num1 = ((this.m_Data[this.m_Index++] << 8) | this.m_Data[this.m_Index++])) != 0)))
            {
                builder1.Append(((char) ((ushort) num1)));
            }
            return builder1.ToString();
        }

        public string ReadUnicodeString(int fixedLength)
        {
            int num3;
            int num1 = (this.m_Index + (fixedLength << 1));
            int num2 = num1;
            if (num1 > this.m_Data.Length)
            {
                num1 = this.m_Data.Length;
            }
            StringBuilder builder1 = new StringBuilder();
            while ((((this.m_Index + 1) < num1) && ((num3 = ((this.m_Data[this.m_Index++] << 8) | this.m_Data[this.m_Index++])) != 0)))
            {
                builder1.Append(((char) ((ushort) num3)));
            }
            this.m_Index = num2;
            return builder1.ToString();
        }

        public string ReadUnicodeStringLE()
        {
            int num1;
            StringBuilder builder1 = new StringBuilder();
            while ((((this.m_Index + 1) < this.m_Data.Length) && ((num1 = (this.m_Data[this.m_Index++] | (this.m_Data[this.m_Index++] << 8))) != 0)))
            {
                builder1.Append(((char) ((ushort) num1)));
            }
            return builder1.ToString();
        }

        public string ReadUnicodeStringLESafe()
        {
            int num1;
            StringBuilder builder1 = new StringBuilder();
            while ((((this.m_Index + 1) < this.m_Data.Length) && ((num1 = (this.m_Data[this.m_Index++] | (this.m_Data[this.m_Index++] << 8))) != 0)))
            {
                if (!this.IsSafeChar(num1))
                {
                    continue;
                }
                builder1.Append(((char) ((ushort) num1)));
            }
            return builder1.ToString();
        }

        public string ReadUnicodeStringLESafe(int fixedLength)
        {
            int num3;
            int num1 = (this.m_Index + (fixedLength << 1));
            int num2 = num1;
            if (num1 > this.m_Data.Length)
            {
                num1 = this.m_Data.Length;
            }
            StringBuilder builder1 = new StringBuilder();
            while ((((this.m_Index + 1) < num1) && ((num3 = (this.m_Data[this.m_Index++] | (this.m_Data[this.m_Index++] << 8))) != 0)))
            {
                if (!this.IsSafeChar(num3))
                {
                    continue;
                }
                builder1.Append(((char) ((ushort) num3)));
            }
            this.m_Index = num2;
            return builder1.ToString();
        }

        public string ReadUnicodeStringSafe()
        {
            int num1;
            StringBuilder builder1 = new StringBuilder();
            while ((((this.m_Index + 1) < this.m_Data.Length) && ((num1 = ((this.m_Data[this.m_Index++] << 8) | this.m_Data[this.m_Index++])) != 0)))
            {
                if (!this.IsSafeChar(num1))
                {
                    continue;
                }
                builder1.Append(((char) ((ushort) num1)));
            }
            return builder1.ToString();
        }

        public string ReadUnicodeStringSafe(int fixedLength)
        {
            int num3;
            int num1 = (this.m_Index + (fixedLength << 1));
            int num2 = num1;
            if (num1 > this.m_Data.Length)
            {
                num1 = this.m_Data.Length;
            }
            StringBuilder builder1 = new StringBuilder();
            while ((((this.m_Index + 1) < num1) && ((num3 = ((this.m_Data[this.m_Index++] << 8) | this.m_Data[this.m_Index++])) != 0)))
            {
                if (!this.IsSafeChar(num3))
                {
                    continue;
                }
                builder1.Append(((char) ((ushort) num3)));
            }
            this.m_Index = num2;
            return builder1.ToString();
        }

        public string ReadUTF8String()
        {
            if (this.m_Index >= this.m_Data.Length)
            {
                return string.Empty;
            }
            int num1 = 0;
            int num2 = this.m_Index;
            while (((num2 < this.m_Data.Length) && (this.m_Data[num2++] != 0)))
            {
                ++num1;
            }
            num2 = 0;
            byte[] buffer1 = new byte[num1];
            int num3 = 0;
            while (((this.m_Index < this.m_Data.Length) && ((num3 = this.m_Data[this.m_Index++]) != 0)))
            {
                buffer1[num2++] = ((byte) num3);
            }
            return Utility.UTF8.GetString(buffer1);
        }

        public string ReadUTF8StringSafe()
        {
            int num4;
            int num5;
            if (this.m_Index >= this.m_Data.Length)
            {
                return string.Empty;
            }
            int num1 = 0;
            int num2 = this.m_Index;
            while (((num2 < this.m_Data.Length) && (this.m_Data[num2++] != 0)))
            {
                ++num1;
            }
            num2 = 0;
            byte[] buffer1 = new byte[num1];
            int num3 = 0;
            while (((this.m_Index < this.m_Data.Length) && ((num3 = this.m_Data[this.m_Index++]) != 0)))
            {
                buffer1[num2++] = ((byte) num3);
            }
            string text1 = Utility.UTF8.GetString(buffer1);
            bool flag1 = true;
            for (num4 = 0; (flag1 && (num4 < text1.Length)); ++num4)
            {
                flag1 = this.IsSafeChar(text1[num4]);
            }
            if (flag1)
            {
                return text1;
            }
            StringBuilder builder1 = new StringBuilder(text1.Length);
            for (num5 = 0; (num5 < text1.Length); ++num5)
            {
                if (this.IsSafeChar(text1[num5]))
                {
                    builder1.Append(text1[num5]);
                }
            }
            return builder1.ToString();
        }

        public string ReadUTF8StringSafe(int fixedLength)
        {
            int num6;
            int num7;
            if (this.m_Index >= this.m_Data.Length)
            {
                this.m_Index += fixedLength;
                return string.Empty;
            }
            int num1 = (this.m_Index + fixedLength);
            if (num1 > this.m_Data.Length)
            {
                num1 = this.m_Data.Length;
            }
            int num2 = 0;
            int num3 = this.m_Index;
            int num4 = this.m_Index;
            while (((num3 < num1) && (this.m_Data[num3++] != 0)))
            {
                ++num2;
            }
            num3 = 0;
            byte[] buffer1 = new byte[num2];
            int num5 = 0;
            while (((this.m_Index < num1) && ((num5 = this.m_Data[this.m_Index++]) != 0)))
            {
                buffer1[num3++] = ((byte) num5);
            }
            string text1 = Utility.UTF8.GetString(buffer1);
            bool flag1 = true;
            for (num6 = 0; (flag1 && (num6 < text1.Length)); ++num6)
            {
                flag1 = this.IsSafeChar(text1[num6]);
            }
            this.m_Index = (num4 + fixedLength);
            if (flag1)
            {
                return text1;
            }
            StringBuilder builder1 = new StringBuilder(text1.Length);
            for (num7 = 0; (num7 < text1.Length); ++num7)
            {
                if (this.IsSafeChar(text1[num7]))
                {
                    builder1.Append(text1[num7]);
                }
            }
            return builder1.ToString();
        }

        public int Seek(int offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                {
                    this.m_Index = offset;
                    goto Label_003F;
                }
                case SeekOrigin.Current:
                {
                    this.m_Index += offset;
                    goto Label_003F;
                }
                case SeekOrigin.End:
                {
                    goto Label_002F;
                }
            }
            goto Label_003F;
        Label_002F:
            this.m_Index = (this.m_Data.Length - offset);
        Label_003F:
            return this.m_Index;
        }

        public void Trace(NetState state)
        {
            byte[] buffer1;
            try
            {
                using (StreamWriter writer1 = new StreamWriter("Packets.log", true))
                {
                    buffer1 = this.m_Data;
                    if (buffer1.Length > 0)
                    {
                        writer1.WriteLine("Client: {0}: Unhandled packet 0x{1:X2}", state, buffer1[0]);
                    }
                    Utility.FormatBuffer(writer1, new MemoryStream(buffer1), buffer1.Length);
                    writer1.WriteLine();
                    writer1.WriteLine();
                    return;
                }
            }
            catch
            {
                return;
            }
        }


        // Properties
        public byte[] Buffer
        {
            get
            {
                return this.m_Data;
            }
        }


        // Fields
        private byte[] m_Data;
        private int m_Index;
    }
}

