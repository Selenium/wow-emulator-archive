namespace Server
{
    using Server.Network;
    using System;
    using System.IO;
    using System.Text;

    public class ObjectPropertyList : Packet
    {
        // Methods
        static ObjectPropertyList()
        {
            ObjectPropertyList.m_Enabled = false;
            ObjectPropertyList.m_Buffer = new byte[1024];
            ObjectPropertyList.m_Encoding = Encoding.Unicode;
        }

        public ObjectPropertyList(IEntity e) : base(214)
        {
            base.EnsureCapacity(128);
            this.m_Entity = e;
            this.m_Stream.Write(((short) 1));
            this.m_Stream.Write(Serial.op_Implicit(e.Serial));
            this.m_Stream.Write(((byte) 0));
            this.m_Stream.Write(((byte) 0));
            this.m_Stream.Write(Serial.op_Implicit(e.Serial));
        }

        public void Add(int number)
        {
            if (number == 0)
            {
                return;
            }
            this.AddHash(number);
            if (this.m_Header == 0)
            {
                this.m_Header = number;
                this.m_HeaderArgs = "";
            }
            this.m_Stream.Write(number);
            this.m_Stream.Write(((short) 0));
        }

        public void Add(string text)
        {
            this.Add(1042971, text);
        }

        public void Add(int number, string arguments)
        {
            if (number == 0)
            {
                return;
            }
            if (arguments == null)
            {
                arguments = "";
            }
            if (this.m_Header == 0)
            {
                this.m_Header = number;
                this.m_HeaderArgs = arguments;
            }
            this.AddHash(number);
            this.AddHash(arguments.GetHashCode());
            this.m_Stream.Write(number);
            int num1 = ObjectPropertyList.m_Encoding.GetByteCount(arguments);
            if (num1 > ObjectPropertyList.m_Buffer.Length)
            {
                ObjectPropertyList.m_Buffer = new byte[num1];
            }
            num1 = ObjectPropertyList.m_Encoding.GetBytes(arguments, 0, arguments.Length, ObjectPropertyList.m_Buffer, 0);
            this.m_Stream.Write(((short) num1));
            this.m_Stream.Write(ObjectPropertyList.m_Buffer, 0, num1);
        }

        public void Add(string format, string arg0)
        {
            this.Add(1042971, string.Format(format, arg0));
        }

        public void Add(string format, params object[] args)
        {
            this.Add(1042971, string.Format(format, args));
        }

        public void Add(int number, string format, params object[] args)
        {
            this.Add(number, string.Format(format, args));
        }

        public void Add(int number, string format, object arg0)
        {
            this.Add(number, string.Format(format, arg0));
        }

        public void Add(string format, string arg0, string arg1)
        {
            this.Add(1042971, string.Format(format, arg0, arg1));
        }

        public void Add(int number, string format, object arg0, object arg1)
        {
            this.Add(number, string.Format(format, arg0, arg1));
        }

        public void Add(string format, string arg0, string arg1, string arg2)
        {
            this.Add(1042971, string.Format(format, arg0, arg1, arg2));
        }

        public void Add(int number, string format, object arg0, object arg1, object arg2)
        {
            this.Add(number, string.Format(format, arg0, arg1, arg2));
        }

        public void AddHash(int val)
        {
            this.m_Hash ^= (val & 67108863);
            this.m_Hash ^= ((val >> 26) & 63);
        }

        public void Terminate()
        {
            this.m_Stream.Write(0);
            this.m_Stream.Seek(11, SeekOrigin.Begin);
            this.m_Stream.Write(this.m_Hash);
        }


        // Properties
        public static bool Enabled
        {
            get
            {
                return ObjectPropertyList.m_Enabled;
            }
            set
            {
                ObjectPropertyList.m_Enabled = value;
            }
        }

        public IEntity Entity
        {
            get
            {
                return this.m_Entity;
            }
        }

        public int Hash
        {
            get
            {
                return (1073741824 + this.m_Hash);
            }
        }

        public int Header
        {
            get
            {
                return this.m_Header;
            }
            set
            {
                this.m_Header = value;
            }
        }

        public string HeaderArgs
        {
            get
            {
                return this.m_HeaderArgs;
            }
            set
            {
                this.m_HeaderArgs = value;
            }
        }


        // Fields
        private static byte[] m_Buffer;
        private static bool m_Enabled;
        private static Encoding m_Encoding;
        private IEntity m_Entity;
        private int m_Hash;
        private int m_Header;
        private string m_HeaderArgs;
    }
}

