namespace WorldServer
{
    using System;

    internal class Endian
    {
        public static void CheckEndiannes()
        {
            if (BitConverter.IsLittleEndian)
            {
                Console.WriteLine("System is LittleEndian");
            }
            else
            {
                Console.WriteLine("System is BigEndian");
            }
        }

        public static short Swap(short s)
        {
            return BitConverter.ToInt16(Utils.Reverse(BitConverter.GetBytes(s)), 0);
        }

        public static int Swap(int s)
        {
            return BitConverter.ToInt32(Utils.Reverse(BitConverter.GetBytes(s)), 0);
        }

        public static float Swap(float s)
        {
            return BitConverter.ToSingle(Utils.Reverse(BitConverter.GetBytes(s)), 0);
        }

        public static ushort Swap(ushort s)
        {
            return BitConverter.ToUInt16(Utils.Reverse(BitConverter.GetBytes(s)), 0);
        }

        public static uint Swap(uint s)
        {
            return BitConverter.ToUInt32(Utils.Reverse(BitConverter.GetBytes(s)), 0);
        }

        public static ulong Swap(ulong s)
        {
            return BitConverter.ToUInt64(Utils.Reverse(BitConverter.GetBytes(s)), 0);
        }
    }
}

