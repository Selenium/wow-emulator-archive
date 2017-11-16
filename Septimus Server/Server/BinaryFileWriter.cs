namespace Server
{
    using Server.Guilds;
    using System;
    using System.Collections;
    using System.IO;
    using System.Net;

    public class BinaryFileWriter : GenericWriter
    {
        // Methods
        public BinaryFileWriter(FileStream strm, bool prefixStr)
        {
            this.PrefixStrings = prefixStr;
            this.m_Bin = new BinaryWriter(strm, Utility.UTF8);
            this.m_File = strm;
        }

        public BinaryFileWriter(string filename, bool prefixStr)
        {
            this.PrefixStrings = prefixStr;
            this.m_File = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            this.m_Bin = new BinaryWriter(this.m_File, Utility.UTF8WithEncoding);
        }

        public override void Close()
        {
            this.m_File.Close();
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
        }

        public override void Write(byte value)
        {
            this.m_Bin.Write(value);
        }

        public override void Write(char value)
        {
            this.m_Bin.Write(value);
        }

        public override void Write(DateTime value)
        {
            this.m_Bin.Write(value.Ticks);
        }

        public override void Write(decimal value)
        {
            this.m_Bin.Write(value);
        }

        public override void Write(double value)
        {
            this.m_Bin.Write(value);
        }

        public override void Write(short value)
        {
            this.m_Bin.Write(value);
        }

        public override void Write(int value)
        {
            this.m_Bin.Write(value);
        }

        public override void Write(long value)
        {
            this.m_Bin.Write(value);
        }

        public override void Write(IPAddress value)
        {
            this.m_Bin.Write(value.Address);
        }

        public override void Write(sbyte value)
        {
            this.m_Bin.Write(value);
        }

        public override void Write(float value)
        {
            this.m_Bin.Write(value);
        }

        public override void Write(string value)
        {
            if (this.PrefixStrings)
            {
                if (value == null)
                {
                    this.m_Bin.Write(((byte) 0));
                    return;
                }
                this.m_Bin.Write(((byte) 1));
                this.m_Bin.Write(value);
                return;
            }
            this.m_Bin.Write(value);
        }

        public override void Write(TimeSpan value)
        {
            this.m_Bin.Write(value.Ticks);
        }

        public override void Write(ushort value)
        {
            this.m_Bin.Write(value);
        }

        public override void Write(uint value)
        {
            this.m_Bin.Write(value);
        }

        public override void Write(ulong value)
        {
            this.m_Bin.Write(value);
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
        public override long Position
        {
            get
            {
                return this.m_File.Position;
            }
        }

        public Stream UnderlyingStream
        {
            get
            {
                return this.m_File;
            }
        }


        // Fields
        private BinaryWriter m_Bin;
        private FileStream m_File;
        private bool PrefixStrings;
    }
}

