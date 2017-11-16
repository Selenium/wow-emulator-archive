namespace Server
{
    using System;
    using System.IO;

    public class ItemBounds
    {
        // Methods
        static ItemBounds()
        {
            BinaryReader reader1;
            int num1;
            int num2;
            int num3;
            int num4;
            int num5;
            if (File.Exists("Data/Binary/Bounds.bin"))
            {
                using (FileStream stream1 = new FileStream("Data/Binary/Bounds.bin", FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    reader1 = new BinaryReader(stream1);
                    ItemBounds.m_Bounds = new Rectangle2D[16384];
                    for (num1 = 0; (num1 < 16384); ++num1)
                    {
                        num2 = reader1.ReadInt16();
                        num3 = reader1.ReadInt16();
                        num4 = reader1.ReadInt16();
                        num5 = reader1.ReadInt16();
                        ItemBounds.m_Bounds[num1].Set(num2, num3, ((num4 - num2) + 1), ((num5 - num3) + 1));
                    }
                    return;
                }
            }
            Console.WriteLine("Warning: Data/Binary/Bounds.bin does not exist");
            ItemBounds.m_Bounds = new Rectangle2D[16384];
        }

        public ItemBounds()
        {
        }


        // Properties
        public static Rectangle2D[] Table
        {
            get
            {
                return ItemBounds.m_Bounds;
            }
        }


        // Fields
        private static Rectangle2D[] m_Bounds;
    }
}

