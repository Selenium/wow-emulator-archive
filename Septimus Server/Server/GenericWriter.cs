namespace Server
{
    using Server.Guilds;
    using System;
    using System.Collections;
    using System.Net;

    public abstract class GenericWriter
    {
        // Methods
        public GenericWriter()
        {
        }

        public abstract void Close();

        public abstract void Write(BaseGuild value);

        public abstract void Write(Item value);

        public abstract void Write(Map value);

        public abstract void Write(Mobile value);

        public abstract void Write(Point2D value);

        public abstract void Write(Point3D value);

        public abstract void Write(Rectangle2D value);

        public abstract void Write(bool value);

        public abstract void Write(byte value);

        public abstract void Write(char value);

        public abstract void Write(DateTime value);

        public abstract void Write(decimal value);

        public abstract void Write(double value);

        public abstract void Write(short value);

        public abstract void Write(int value);

        public abstract void Write(long value);

        public abstract void Write(IPAddress value);

        public abstract void Write(sbyte value);

        public abstract void Write(float value);

        public abstract void Write(string value);

        public abstract void Write(TimeSpan value);

        public abstract void Write(ushort value);

        public abstract void Write(uint value);

        public abstract void Write(ulong value);

        public abstract void WriteDeltaTime(DateTime value);

        public abstract void WriteEncodedInt(int value);

        public abstract void WriteGuildList(ArrayList list);

        public abstract void WriteGuildList(ArrayList list, bool tidy);

        public abstract void WriteItemList(ArrayList list);

        public abstract void WriteItemList(ArrayList list, bool tidy);

        public abstract void WriteMobileList(ArrayList list);

        public abstract void WriteMobileList(ArrayList list, bool tidy);


        // Properties
        public abstract long Position { get; }

    }
}

