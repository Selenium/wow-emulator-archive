namespace Server
{
    using Server.Guilds;
    using System;
    using System.Collections;
    using System.Net;

    public abstract class GenericReader
    {
        // Methods
        public GenericReader()
        {
        }

        public abstract bool End();

        public abstract bool ReadBool();

        public abstract byte ReadByte();

        public abstract char ReadChar();

        public abstract DateTime ReadDateTime();

        public abstract decimal ReadDecimal();

        public abstract DateTime ReadDeltaTime();

        public abstract double ReadDouble();

        public abstract int ReadEncodedInt();

        public abstract float ReadFloat();

        public abstract BaseGuild ReadGuild();

        public abstract ArrayList ReadGuildList();

        public abstract int ReadInt();

        public abstract IPAddress ReadIPAddress();

        public abstract Item ReadItem();

        public abstract ArrayList ReadItemList();

        public abstract long ReadLong();

        public abstract Map ReadMap();

        public abstract Mobile ReadMobile();

        public abstract ArrayList ReadMobileList();

        public abstract Point2D ReadPoint2D();

        public abstract Point3D ReadPoint3D();

        public abstract Rectangle2D ReadRect2D();

        public abstract sbyte ReadSByte();

        public abstract short ReadShort();

        public abstract string ReadString();

        public abstract TimeSpan ReadTimeSpan();

        public abstract uint ReadUInt();

        public abstract ulong ReadULong();

        public abstract ushort ReadUShort();

    }
}

