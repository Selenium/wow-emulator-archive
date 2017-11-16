namespace Server
{
    using System;
    using System.IO;
    using System.Text;

    public class TileData
    {
        // Methods
        static TileData()
        {
            BinaryReader reader1;
            int num1;
            TileFlag flag1;
            int num2;
            TileFlag flag2;
            int num3;
            int num4;
            int num5;
            int num6;
            int num7;
            TileData.m_StringBuffer = new byte[20];
            string text1 = Core.FindDataFile("TileData.mul");
            if (File.Exists(text1))
            {
                using (FileStream stream1 = new FileStream(text1, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    reader1 = new BinaryReader(stream1);
                    TileData.m_LandData = new LandData[16384];
                    for (num1 = 0; (num1 < 16384); ++num1)
                    {
                        if ((num1 & 31) == 0)
                        {
                            reader1.ReadInt32();
                        }
                        flag1 = ((TileFlag) reader1.ReadInt32());
                        reader1.ReadInt16();
                        TileData.m_LandData[num1] = new LandData(TileData.ReadNameString(reader1), flag1);
                    }
                    TileData.m_ItemData = new ItemData[16384];
                    for (num2 = 0; (num2 < 16384); ++num2)
                    {
                        if ((num2 & 31) == 0)
                        {
                            reader1.ReadInt32();
                        }
                        flag2 = ((TileFlag) reader1.ReadInt32());
                        num3 = reader1.ReadByte();
                        num4 = reader1.ReadByte();
                        reader1.ReadInt16();
                        reader1.ReadByte();
                        num5 = reader1.ReadByte();
                        reader1.ReadInt32();
                        reader1.ReadByte();
                        num6 = reader1.ReadByte();
                        num7 = reader1.ReadByte();
                        TileData.m_ItemData[num2] = new ItemData(TileData.ReadNameString(reader1), flag2, num3, num4, num5, num6, num7);
                    }
                    return;
                }
            }
            Console.WriteLine("TileData.mul was not found");
            Console.WriteLine("Make sure your Scripts/Misc/DataPath.cs is properly configured");
            Console.WriteLine("After pressing return an exception will be thrown and the server will terminate");
            throw new Exception(string.Format("TileData: {0} not found", text1));
        }

        public TileData()
        {
        }

        private static string ReadNameString(BinaryReader bin)
        {
            bin.Read(TileData.m_StringBuffer, 0, 20);
            int num1 = 0;
            while (((num1 < 20) && (TileData.m_StringBuffer[num1] != 0)))
            {
                ++num1;
            }
            return Encoding.ASCII.GetString(TileData.m_StringBuffer, 0, num1);
        }


        // Properties
        public static ItemData[] ItemTable
        {
            get
            {
                return TileData.m_ItemData;
            }
        }

        public static LandData[] LandTable
        {
            get
            {
                return TileData.m_LandData;
            }
        }


        // Fields
        private static ItemData[] m_ItemData;
        private static LandData[] m_LandData;
        private static byte[] m_StringBuffer;
    }
}

