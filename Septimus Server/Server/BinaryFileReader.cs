namespace Server
{
    using Server.Guilds;
    using System;
    using System.Collections;
    using System.IO;
    using System.Net;

    public class BinaryFileReader : GenericReader
    {
        // Methods
        public BinaryFileReader(BinaryReader br)
        {
            this.m_File = br;
        }

        public override bool End()
        {
            return (this.m_File.PeekChar() == -1);
        }

        public override bool ReadBool()
        {
            return this.m_File.ReadBoolean();
        }

        public override byte ReadByte()
        {
            return this.m_File.ReadByte();
        }

        public override char ReadChar()
        {
            return this.m_File.ReadChar();
        }

        public override DateTime ReadDateTime()
        {
            return new DateTime(this.m_File.ReadInt64());
        }

        public override decimal ReadDecimal()
        {
            return this.m_File.ReadDecimal();
        }

        public override DateTime ReadDeltaTime()
        {
            DateTime time1;
            long num1 = this.m_File.ReadInt64();
            DateTime time2 = DateTime.Now;
            long num2 = time2.Ticks;
            if ((num1 > 0) && ((num1 + num2) < 0))
            {
                return DateTime.MaxValue;
            }
            if ((num1 < 0) && ((num1 + num2) < 0))
            {
                return DateTime.MinValue;
            }
            try
            {
                return new DateTime((num2 + num1));
            }
            catch
            {
                if (num1 > 0)
                {
                    return DateTime.MaxValue;
                }
                return DateTime.MinValue;
            }
            return time1;
        }

        public override double ReadDouble()
        {
            return this.m_File.ReadDouble();
        }

        public override int ReadEncodedInt()
        {
            byte num3;
            int num1 = 0;
            int num2 = 0;
            do
            {
                num3 = this.m_File.ReadByte();
                num1 |= ((num3 & 127) << (num2 & 31));
                num2 += 7;
            }
            while ((num3 >= 128));
            return num1;
        }

        public override float ReadFloat()
        {
            return this.m_File.ReadSingle();
        }

        public override BaseGuild ReadGuild()
        {
            return BaseGuild.Find(this.ReadInt());
        }

        public override ArrayList ReadGuildList()
        {
            int num2;
            BaseGuild guild1;
            int num1 = this.ReadInt();
            ArrayList list1 = new ArrayList(num1);
            for (num2 = 0; (num2 < num1); ++num2)
            {
                guild1 = this.ReadGuild();
                if (guild1 != null)
                {
                    list1.Add(guild1);
                }
            }
            return list1;
        }

        public override int ReadInt()
        {
            return this.m_File.ReadInt32();
        }

        public override IPAddress ReadIPAddress()
        {
            return new IPAddress(this.m_File.ReadInt64());
        }

        public override Item ReadItem()
        {
            return World.FindItem(Serial.op_Implicit(this.ReadInt()));
        }

        public override ArrayList ReadItemList()
        {
            int num2;
            Item item1;
            int num1 = this.ReadInt();
            ArrayList list1 = new ArrayList(num1);
            for (num2 = 0; (num2 < num1); ++num2)
            {
                item1 = this.ReadItem();
                if (item1 != null)
                {
                    list1.Add(item1);
                }
            }
            return list1;
        }

        public override long ReadLong()
        {
            return this.m_File.ReadInt64();
        }

        public override Map ReadMap()
        {
            return Map.Maps[this.ReadByte()];
        }

        public override Mobile ReadMobile()
        {
            return World.FindMobile(Serial.op_Implicit(this.ReadInt()));
        }

        public override ArrayList ReadMobileList()
        {
            int num2;
            Mobile mobile1;
            int num1 = this.ReadInt();
            ArrayList list1 = new ArrayList(num1);
            for (num2 = 0; (num2 < num1); ++num2)
            {
                mobile1 = this.ReadMobile();
                if (mobile1 != null)
                {
                    list1.Add(mobile1);
                }
            }
            return list1;
        }

        public override Point2D ReadPoint2D()
        {
            return new Point2D(this.ReadInt(), this.ReadInt());
        }

        public override Point3D ReadPoint3D()
        {
            return new Point3D(this.ReadInt(), this.ReadInt(), this.ReadInt());
        }

        public override Rectangle2D ReadRect2D()
        {
            return new Rectangle2D(this.ReadPoint2D(), this.ReadPoint2D());
        }

        public override sbyte ReadSByte()
        {
            return this.m_File.ReadSByte();
        }

        public override short ReadShort()
        {
            return this.m_File.ReadInt16();
        }

        public override string ReadString()
        {
            if (this.ReadByte() != 0)
            {
                return this.m_File.ReadString();
            }
            return null;
        }

        public override TimeSpan ReadTimeSpan()
        {
            return new TimeSpan(this.m_File.ReadInt64());
        }

        public override uint ReadUInt()
        {
            return this.m_File.ReadUInt32();
        }

        public override ulong ReadULong()
        {
            return this.m_File.ReadUInt64();
        }

        public override ushort ReadUShort()
        {
            return this.m_File.ReadUInt16();
        }

        public long Seek(long offset, SeekOrigin origin)
        {
            return this.m_File.BaseStream.Seek(offset, origin);
        }


        // Properties
        public long Position
        {
            get
            {
                return this.m_File.BaseStream.Position;
            }
        }


        // Fields
        private BinaryReader m_File;
    }
}

