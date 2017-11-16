namespace Server
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;

    public class TileMatrixPatch
    {
        // Methods
        static TileMatrixPatch()
        {
            TileMatrixPatch.m_Enabled = true;
            TileMatrixPatch.m_TileBuffer = new StaticTile[128];
        }

        public TileMatrixPatch(TileMatrix matrix, int index)
        {
            if (!TileMatrixPatch.m_Enabled)
            {
                return;
            }
            object[] objArray1 = new object[1];
            objArray1[0] = index;
            string text1 = Core.FindDataFile("mapdif{0}.mul", objArray1);
            objArray1 = new object[1];
            objArray1[0] = index;
            string text2 = Core.FindDataFile("mapdifl{0}.mul", objArray1);
            if (File.Exists(text1) && File.Exists(text2))
            {
                this.m_LandBlocks = this.PatchLand(matrix, text1, text2);
            }
            objArray1 = new object[1];
            objArray1[0] = index;
            string text3 = Core.FindDataFile("stadif{0}.mul", objArray1);
            objArray1 = new object[1];
            objArray1[0] = index;
            string text4 = Core.FindDataFile("stadifl{0}.mul", objArray1);
            objArray1 = new object[1];
            objArray1[0] = index;
            string text5 = Core.FindDataFile("stadifi{0}.mul", objArray1);
            if ((File.Exists(text3) && File.Exists(text4)) && File.Exists(text5))
            {
                this.m_StaticBlocks = this.PatchStatics(matrix, text3, text4, text5);
            }
        }

        [DllImport("Kernel32")]
        private static extern unsafe int _lread(IntPtr hFile, void* lpBuffer, int wBytes);

        private int PatchLand(TileMatrix matrix, string dataPath, string indexPath)
        {
            BinaryReader reader1;
            int num1;
            int num2;
            int num3;
            int num4;
            int num5;
            Tile[] tileArray1;
            int num6;
            using (FileStream stream1 = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (FileStream stream2 = new FileStream(indexPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    reader1 = new BinaryReader(stream2);
                    num1 = ((int) (reader1.BaseStream.Length / 4));
                    for (num2 = 0; (num2 < num1); ++num2)
                    {
                        num3 = reader1.ReadInt32();
                        num4 = (num3 / matrix.BlockHeight);
                        num5 = (num3 % matrix.BlockHeight);
                        stream1.Seek(4, SeekOrigin.Current);
                        tileArray1 = new Tile[64];
                        try
                        {
                            fixed (Tile* local1 = tileArray1)
                            {
                            }
                            TileMatrixPatch._lread(stream1.Handle, ((void*) local1), 192);
                        }
                        finally
                        {
                            local1 = ((pinned ref Tile) IntPtr.Zero);
                        }
                        matrix.SetLandBlock(num4, num5, tileArray1);
                    }
                    return num1;
                }
            }
            return num6;
        }

        private int PatchStatics(TileMatrix matrix, string dataPath, string indexPath, string lookupPath)
        {
            BinaryReader reader1;
            BinaryReader reader2;
            int num1;
            TileList[][] listArrayArray1;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            int num7;
            int num8;
            int num9;
            int num10;
            StaticTile[] tileArray1;
            StaticTile* tilePtr1;
            StaticTile* tilePtr2;
            Tile[][][] tileArrayArrayArray1;
            int num11;
            int num12;
            int num13;
            using (FileStream stream1 = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (FileStream stream2 = new FileStream(indexPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (FileStream stream3 = new FileStream(lookupPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        reader1 = new BinaryReader(stream2);
                        reader2 = new BinaryReader(stream3);
                        num1 = ((int) (reader1.BaseStream.Length / 4));
                        listArrayArray1 = new TileList[8][];
                        for (num2 = 0; (num2 < 8); ++num2)
                        {
                            listArrayArray1[num2] = new TileList[8];
                            for (num3 = 0; (num3 < 8); ++num3)
                            {
                                listArrayArray1[num2][num3] = new TileList();
                            }
                        }
                        for (num4 = 0; (num4 < num1); ++num4)
                        {
                            num5 = reader1.ReadInt32();
                            num6 = (num5 / matrix.BlockHeight);
                            num7 = (num5 % matrix.BlockHeight);
                            num8 = reader2.ReadInt32();
                            num9 = reader2.ReadInt32();
                            reader2.ReadInt32();
                            if ((num8 < 0) || (num9 <= 0))
                            {
                                matrix.SetStaticBlock(num6, num7, matrix.EmptyStaticBlock);
                            }
                            else
                            {
                                stream1.Seek(num8, SeekOrigin.Begin);
                                num10 = (num9 / 7);
                                if (TileMatrixPatch.m_TileBuffer.Length < num10)
                                {
                                    TileMatrixPatch.m_TileBuffer = new StaticTile[num10];
                                }
                                tileArray1 = TileMatrixPatch.m_TileBuffer;
                                try
                                {
                                    fixed (StaticTile* local1 = tileArray1)
                                    {
                                    }
                                    TileMatrixPatch._lread(stream1.Handle, ((void*) local1), num9);
                                    tilePtr1 = local1;
                                    tilePtr2 = (local1 + (num10 * sizeof(StaticTile)));
                                    while ((tilePtr1 < tilePtr2))
                                    {
                                        listArrayArray1[(tilePtr1.m_X & 7)][(tilePtr1.m_Y & 7)].Add(((short) ((tilePtr1.m_ID & 16383) + 16384)), tilePtr1.m_Z);
                                        tilePtr1 += sizeof(StaticTile);
                                    }
                                    tileArrayArrayArray1 = new Tile[8][][];
                                    for (num11 = 0; (num11 < 8); ++num11)
                                    {
                                        tileArrayArrayArray1[num11] = new Tile[8][];
                                        for (num12 = 0; (num12 < 8); ++num12)
                                        {
                                            tileArrayArrayArray1[num11][num12] = listArrayArray1[num11][num12].ToArray();
                                        }
                                    }
                                    matrix.SetStaticBlock(num6, num7, tileArrayArrayArray1);
                                }
                                finally
                                {
                                    local1 = ((pinned ref StaticTile) IntPtr.Zero);
                                }
                            }
                        }
                        return num1;
                    }
                }
            }
            return num13;
        }


        // Properties
        public static bool Enabled
        {
            get
            {
                return TileMatrixPatch.m_Enabled;
            }
            set
            {
                TileMatrixPatch.m_Enabled = value;
            }
        }

        public int LandBlocks
        {
            get
            {
                return this.m_LandBlocks;
            }
        }

        public int StaticBlocks
        {
            get
            {
                return this.m_StaticBlocks;
            }
        }


        // Fields
        private static bool m_Enabled;
        private int m_LandBlocks;
        private int m_StaticBlocks;
        private static StaticTile[] m_TileBuffer;
    }
}

