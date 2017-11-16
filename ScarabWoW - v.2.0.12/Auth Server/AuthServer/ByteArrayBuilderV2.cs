namespace AuthServer
{
    using System;
    using System.Collections;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text;

    public class ByteArrayBuilderV2
    {
        private ArrayList list = new ArrayList();
        public int pos = 0;

        public void Add(byte b)
        {
            this.list.Add(b);
        }

        public void Add(string s)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            byte[] array = new byte[bytes.Length + 1];
            bytes.CopyTo(array, 0);
            this.Add(array);
        }

        public void Add(ushort b)
        {
            this.Add((byte) b);
            this.Add((byte) (b >> 8));
        }

        public void Add(uint b)
        {
            this.Add((byte) b);
            this.Add((byte) (b >> 8));
            this.Add((byte) (b >> 0x10));
            this.Add((byte) (b >> 0x18));
        }

        public void Add(ulong u)
        {
            this.Add((uint) u);
            this.Add((uint) (u >> 0x20));
        }

        public void Add(byte[] bs)
        {
            foreach (byte num in bs)
            {
                this.Add(num);
            }
        }

        public void Add(float[] bs)
        {
            foreach (float num in bs)
            {
                this.Add(num);
            }
        }

        public void Add(string[] bs)
        {
            foreach (string str in bs)
            {
                this.Add(str);
            }
        }

        public void Add(ushort[] bs)
        {
            foreach (ushort num in bs)
            {
                this.Add(num);
            }
        }

        public void Add(uint[] bs)
        {
            foreach (uint num in bs)
            {
                this.Add(num);
            }
        }

        public void Add(float f)
        {
            this.Add(BitConverter.ToUInt32(BitConverter.GetBytes(f), 0));
        }

        public void Add(double f)
        {
            this.Add((float) f);
        }

        public void Add(ulong[] bs)
        {
            foreach (ulong num in bs)
            {
                this.Add(num);
            }
        }

        public void Clear()
        {
            this.list = new ArrayList();
            this.pos = 0;
        }

        public void Get(out byte b)
        {
            b = this.GetByte();
        }

        public void Get(out float b)
        {
            b = this.GetFloat();
        }

        public void Get(out string b)
        {
            b = this.GetString();
        }

        public void Get(out ushort b)
        {
            b = this.GetWord();
        }

        public void Get(out uint b)
        {
            b = this.GetDWord();
        }

        public void Get(out ulong b)
        {
            b = this.GetULong();
        }

        public byte[] GetArray(int count)
        {
            int pos = this.pos;
            this.pos += count;
            return this.GetArray(pos, count);
        }

        public byte[] GetArray(int start, int count)
        {
            byte[] array = new byte[count];
            this.list.CopyTo(start, array, 0, count);
            return array;
        }

        public byte GetByte()
        {
            return (byte) this.list[this.pos++];
        }

        public byte GetByte(int p)
        {
            return (byte) this.list[p];
        }

        public uint GetDWord()
        {
            int pos = this.pos;
            this.pos += 4;
            return (uint) ((((((byte) this.list[pos + 3]) << 0x18) + (((byte) this.list[pos + 2]) << 0x10)) + (((byte) this.list[pos + 1]) << 8)) + ((byte) this.list[pos]));
        }

        public float GetFloat()
        {
            return BitConverter.ToSingle(BitConverter.GetBytes(this.GetDWord()), 0);
        }

        public string GetString()
        {
            int pos = this.pos;
            while (pos < this.Length)
            {
                if (((byte) this.list[pos]) == 0)
                {
                    break;
                }
                pos++;
            }
            byte[] array = this.GetArray(this.pos, pos - this.pos);
            this.pos = pos + 1;
            return Encoding.UTF8.GetString(array);
        }

        public ulong GetULong()
        {
            return (this.GetDWord() + (this.GetDWord() << 0x20));
        }

        public ushort GetWord()
        {
            int pos = this.pos;
            this.pos += 2;
            return (ushort) ((((byte) this.list[pos + 1]) << 8) + ((byte) this.list[pos]));
        }

        public static implicit operator byte[](ByteArrayBuilderV2 m)
        {
            return m.GetArray(0, m.Length);
        }

        public static implicit operator ByteArrayBuilderV2(byte[] m)
        {
            ByteArrayBuilderV2 rv = new ByteArrayBuilderV2();
            rv.Add(m);
            return rv;
        }

        public void Remove(int start, int count)
        {
            this.list.RemoveRange(start, count);
        }

        public void Seek(int len)
        {
            this.pos += len;
        }

        public void Set(int pos, byte bs)
        {
            this.list[pos++] = bs;
        }

        public void Set(int pos, ushort b)
        {
            this.list[pos + 1] = (byte) (b >> 8);
            this.list[pos] = (byte) b;
        }

        public void Set(int pos, uint b)
        {
            this.list[pos + 3] = (byte) (b >> 0x18);
            this.list[pos + 2] = (byte) (b >> 0x10);
            this.list[pos + 1] = (byte) (b >> 8);
            this.list[pos] = (byte) b;
        }

        public void Set(int pos, params byte[] bs)
        {
            foreach (byte num in bs)
            {
                this.list[pos++] = num;
            }
        }

        public byte this[int index]
        {
            get
            {
                return (byte) this.list[index];
            }
            set
            {
                this.list[index] = value;
            }
        }

        public int Length
        {
            get
            {
                return this.list.Count;
            }
            set
            {
                while (value > this.list.Count)
                {
                    this.list.Add((byte) 0);
                }
                if (value < this.list.Count)
                {
                    this.list.RemoveRange(value, this.list.Count - value);
                }
            }
        }
    }
}

