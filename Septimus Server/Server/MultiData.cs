namespace Server
{
    using System;
    using System.IO;

    public class MultiData
    {
        // Methods
        static MultiData()
        {
            string text3;
            BinaryReader reader1;
            int num1;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            string text1 = Core.FindDataFile("Multi.idx");
            string text2 = Core.FindDataFile("Multi.mul");
            if (File.Exists(text1) && File.Exists(text2))
            {
                MultiData.m_Index = new FileStream(text1, FileMode.Open, FileAccess.Read, FileShare.Read);
                MultiData.m_IndexReader = new BinaryReader(MultiData.m_Index);
                MultiData.m_Stream = new FileStream(text2, FileMode.Open, FileAccess.Read, FileShare.Read);
                MultiData.m_StreamReader = new BinaryReader(MultiData.m_Stream);
                MultiData.m_Components = new MultiComponentList[((int) (MultiData.m_Index.Length / 12))];
                text3 = Core.FindDataFile("Verdata.mul");
                if (!File.Exists(text3))
                {
                    return;
                }
                using (FileStream stream1 = new FileStream(text3, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    reader1 = new BinaryReader(stream1);
                    num1 = reader1.ReadInt32();
                    for (num2 = 0; (num2 < num1); ++num2)
                    {
                        num3 = reader1.ReadInt32();
                        num4 = reader1.ReadInt32();
                        num5 = reader1.ReadInt32();
                        num6 = reader1.ReadInt32();
                        reader1.ReadInt32();
                        if ((((num3 == 14) && (num4 >= 0)) && ((num4 < MultiData.m_Components.Length) && (num5 >= 0))) && (num6 > 0))
                        {
                            reader1.BaseStream.Seek(num5, SeekOrigin.Begin);
                            MultiData.m_Components[num4] = new MultiComponentList(reader1, (num6 / 12));
                            reader1.BaseStream.Seek((24 + (num2 * 20)), SeekOrigin.Begin);
                        }
                    }
                    return;
                }
            }
            Console.WriteLine("Warning: Multi data files not found");
            MultiData.m_Components = new MultiComponentList[0];
        }

        public MultiData()
        {
        }

        public static MultiComponentList GetComponents(int multiID)
        {
            MultiComponentList list1;
            multiID &= 16383;
            if ((multiID >= 0) && (multiID < MultiData.m_Components.Length))
            {
                list1 = MultiData.m_Components[multiID];
                if (list1 != null)
                {
                    return list1;
                }
                MultiData.m_Components[multiID] = (list1 = MultiData.Load(multiID));
                return list1;
            }
            return MultiComponentList.Empty;
        }

        public static MultiComponentList Load(int multiID)
        {
            int num1;
            int num2;
            MultiComponentList list1;
            try
            {
                MultiData.m_IndexReader.BaseStream.Seek((multiID * 12), SeekOrigin.Begin);
                num1 = MultiData.m_IndexReader.ReadInt32();
                num2 = MultiData.m_IndexReader.ReadInt32();
                if ((num1 < 0) || (num2 <= 0))
                {
                    return MultiComponentList.Empty;
                }
                MultiData.m_StreamReader.BaseStream.Seek(num1, SeekOrigin.Begin);
                return new MultiComponentList(MultiData.m_StreamReader, (num2 / 12));
            }
            catch
            {
                return MultiComponentList.Empty;
            }
            return list1;
        }


        // Fields
        private static MultiComponentList[] m_Components;
        private static FileStream m_Index;
        private static BinaryReader m_IndexReader;
        private static FileStream m_Stream;
        private static BinaryReader m_StreamReader;
    }
}

