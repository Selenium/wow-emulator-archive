namespace Server
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Runtime.InteropServices;

    public class TileMatrix
    {
        // Methods
        static TileMatrix()
        {
            TileMatrix.m_Instances = new ArrayList();
            TileMatrix.m_TilesList = new TileList();
            TileMatrix.m_TileBuffer = new StaticTile[128];
        }

        public TileMatrix(Map owner, int fileIndex, int mapID, int width, int height)
        {
            int num1;
            TileMatrix matrix1;
            string text1;
            string text2;
            string text3;
            int num2;
            int num3;
            object[] objArray1;
            this.m_FileShare = new ArrayList();
            for (num1 = 0; (num1 < TileMatrix.m_Instances.Count); ++num1)
            {
                matrix1 = ((TileMatrix) TileMatrix.m_Instances[num1]);
                if (matrix1.m_FileIndex == fileIndex)
                {
                    matrix1.m_FileShare.Add(this);
                    this.m_FileShare.Add(matrix1);
                }
            }
            TileMatrix.m_Instances.Add(this);
            this.m_FileIndex = fileIndex;
            this.m_Width = width;
            this.m_Height = height;
            this.m_BlockWidth = (width >> 3);
            this.m_BlockHeight = (height >> 3);
            this.m_Owner = owner;
            if (fileIndex != 127)
            {
                objArray1 = new object[1];
                objArray1[0] = fileIndex;
                text1 = Core.FindDataFile("map{0}.mul", objArray1);
                if (File.Exists(text1))
                {
                    this.m_Map = new FileStream(text1, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                }
                objArray1 = new object[1];
                objArray1[0] = fileIndex;
                text2 = Core.FindDataFile("staidx{0}.mul", objArray1);
                if (File.Exists(text2))
                {
                    this.m_Index = new FileStream(text2, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    this.m_IndexReader = new BinaryReader(this.m_Index);
                }
                objArray1 = new object[1];
                objArray1[0] = fileIndex;
                text3 = Core.FindDataFile("statics{0}.mul", objArray1);
                if (File.Exists(text3))
                {
                    this.m_Statics = new FileStream(text3, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                }
            }
            this.m_EmptyStaticBlock = new Tile[8][][];
            for (num2 = 0; (num2 < 8); ++num2)
            {
                this.m_EmptyStaticBlock[num2] = new Tile[8][];
                for (num3 = 0; (num3 < 8); ++num3)
                {
                    this.m_EmptyStaticBlock[num2][num3] = new Tile[0];
                }
            }
            this.m_InvalidLandBlock = new Tile[196];
            this.m_LandTiles = new Tile[this.m_BlockWidth][][];
            this.m_StaticTiles = new Tile[this.m_BlockWidth][][][][];
            this.m_StaticPatches = new int[this.m_BlockWidth][];
            this.m_LandPatches = new int[this.m_BlockWidth][];
            this.m_Patch = new TileMatrixPatch(this, mapID);
        }

        [DllImport("Kernel32")]
        private static extern unsafe int _lread(IntPtr hFile, void* lpBuffer, int wBytes);

        public void Dispose()
        {
            if (this.m_Map != null)
            {
                this.m_Map.Close();
            }
            if (this.m_Statics != null)
            {
                this.m_Statics.Close();
            }
            if (this.m_IndexReader != null)
            {
                this.m_IndexReader.Close();
            }
        }

        public void Force()
        {
            if ((ScriptCompiler.Assemblies == null) || (ScriptCompiler.Assemblies.Length == 0))
            {
                throw new Exception();
            }
        }

        public Tile[] GetLandBlock(int x, int y)
        {
            int num1;
            TileMatrix matrix1;
            Tile[][] tileArrayArray1;
            int[] numArray1;
            if (((x < 0) || (y < 0)) || (((x >= this.m_BlockWidth) || (y >= this.m_BlockHeight)) || (this.m_Map == null)))
            {
                return this.m_InvalidLandBlock;
            }
            if (this.m_LandTiles[x] == null)
            {
                this.m_LandTiles[x] = new Tile[this.m_BlockHeight][];
            }
            Tile[] tileArray1 = this.m_LandTiles[x][y];
            if (tileArray1 != null)
            {
                return tileArray1;
            }
            for (num1 = 0; ((tileArray1 == null) && (num1 < this.m_FileShare.Count)); ++num1)
            {
                matrix1 = ((TileMatrix) this.m_FileShare[num1]);
                if (((x >= 0) && (x < matrix1.m_BlockWidth)) && ((y >= 0) && (y < matrix1.m_BlockHeight)))
                {
                    tileArrayArray1 = matrix1.m_LandTiles[x];
                    if (tileArrayArray1 != null)
                    {
                        tileArray1 = tileArrayArray1[y];
                    }
                    if (tileArray1 != null)
                    {
                        numArray1 = matrix1.m_LandPatches[x];
                        if ((numArray1 != null) && ((numArray1[(y >> 5)] & (1 << ((y & 31) & 31))) != 0))
                        {
                            tileArray1 = null;
                        }
                    }
                }
            }
            if (tileArray1 == null)
            {
                tileArray1 = this.ReadLandBlock(x, y);
            }
            this.m_LandTiles[x][y] = tileArray1;
            return tileArray1;
        }

        public Tile GetLandTile(int x, int y)
        {
            Tile[] tileArray1 = this.GetLandBlock((x >> 3), (y >> 3));
            return tileArray1[(((y & 7) << 3) + (x & 7))];
        }

        public Tile[][][] GetStaticBlock(int x, int y)
        {
            int num1;
            TileMatrix matrix1;
            Tile[][][][] tileArrayArrayArrayArray1;
            int[] numArray1;
            if ((((x < 0) || (y < 0)) || ((x >= this.m_BlockWidth) || (y >= this.m_BlockHeight))) || ((this.m_Statics == null) || (this.m_Index == null)))
            {
                return this.m_EmptyStaticBlock;
            }
            if (this.m_StaticTiles[x] == null)
            {
                this.m_StaticTiles[x] = new Tile[this.m_BlockHeight][][][];
            }
            Tile[][][] tileArrayArrayArray1 = this.m_StaticTiles[x][y];
            if (tileArrayArrayArray1 != null)
            {
                return tileArrayArrayArray1;
            }
            for (num1 = 0; ((tileArrayArrayArray1 == null) && (num1 < this.m_FileShare.Count)); ++num1)
            {
                matrix1 = ((TileMatrix) this.m_FileShare[num1]);
                if (((x >= 0) && (x < matrix1.m_BlockWidth)) && ((y >= 0) && (y < matrix1.m_BlockHeight)))
                {
                    tileArrayArrayArrayArray1 = matrix1.m_StaticTiles[x];
                    if (tileArrayArrayArrayArray1 != null)
                    {
                        tileArrayArrayArray1 = tileArrayArrayArrayArray1[y];
                    }
                    if (tileArrayArrayArray1 != null)
                    {
                        numArray1 = matrix1.m_StaticPatches[x];
                        if ((numArray1 != null) && ((numArray1[(y >> 5)] & (1 << ((y & 31) & 31))) != 0))
                        {
                            tileArrayArrayArray1 = null;
                        }
                    }
                }
            }
            if (tileArrayArrayArray1 == null)
            {
                tileArrayArrayArray1 = this.ReadStaticBlock(x, y);
            }
            this.m_StaticTiles[x][y] = tileArrayArrayArray1;
            return tileArrayArrayArray1;
        }

        public Tile[] GetStaticTiles(int x, int y)
        {
            Tile[][][] tileArrayArrayArray1 = this.GetStaticBlock((x >> 3), (y >> 3));
            return tileArrayArrayArray1[(x & 7)][(y & 7)];
        }

        public Tile[] GetStaticTiles(int x, int y, bool multis)
        {
            IPooledEnumerable enumerable1;
            bool flag1;
            Tile[][][] tileArrayArrayArray1 = this.GetStaticBlock((x >> 3), (y >> 3));
            if (multis)
            {
                enumerable1 = this.m_Owner.GetMultiTilesAt(x, y);
                if (enumerable1 == Map.NullEnumerable.Instance)
                {
                    return tileArrayArrayArray1[(x & 7)][(y & 7)];
                }
                flag1 = false;
                foreach (Tile[] tileArray1 in enumerable1)
                {
                    if (!flag1)
                    {
                        flag1 = true;
                    }
                    TileMatrix.m_TilesList.AddRange(tileArray1);
                }
                enumerable1.Free();
                if (!flag1)
                {
                    return tileArrayArrayArray1[(x & 7)][(y & 7)];
                }
                TileMatrix.m_TilesList.AddRange(tileArrayArrayArray1[(x & 7)][(y & 7)]);
                return TileMatrix.m_TilesList.ToArray();
            }
            return tileArrayArrayArray1[(x & 7)][(y & 7)];
        }

        private Tile[] ReadLandBlock(int x, int y)
        {
            Tile[] tileArray1;
            Tile[] tileArray2;
            try
            {
                this.m_Map.Seek(((((x * this.m_BlockHeight) + y) * 196) + 4), SeekOrigin.Begin);
                tileArray1 = new Tile[64];
                try
                {
                    fixed (Tile* local1 = tileArray1)
                    {
                    }
                    TileMatrix._lread(this.m_Map.Handle, ((void*) local1), 192);
                }
                finally
                {
                    local1 = ((pinned ref Tile) IntPtr.Zero);
                }
                return tileArray1;
            }
            catch
            {
                if (DateTime.Now >= this.m_NextLandWarning)
                {
                    Console.WriteLine("Warning: Land EOS for {0} ({1}, {2})", this.m_Owner, x, y);
                    this.m_NextLandWarning = (DateTime.Now + TimeSpan.FromMinutes(1));
                }
                return this.m_InvalidLandBlock;
            }
            return tileArray2;
        }

        private Tile[][][] ReadStaticBlock(int x, int y)
        {
            int num1;
            int num2;
            int num3;
            StaticTile[] tileArray1;
            int num4;
            int num5;
            TileList[][] listArrayArray1;
            StaticTile* tilePtr1;
            StaticTile* tilePtr2;
            Tile[][][] tileArrayArrayArray1;
            int num6;
            int num7;
            Tile[][][] tileArrayArrayArray2;
            try
            {
                this.m_IndexReader.BaseStream.Seek((((x * this.m_BlockHeight) + y) * 12), SeekOrigin.Begin);
                num1 = this.m_IndexReader.ReadInt32();
                num2 = this.m_IndexReader.ReadInt32();
                if ((num1 < 0) || (num2 <= 0))
                {
                    return this.m_EmptyStaticBlock;
                }
                num3 = (num2 / 7);
                this.m_Statics.Seek(num1, SeekOrigin.Begin);
                if (TileMatrix.m_TileBuffer.Length < num3)
                {
                    TileMatrix.m_TileBuffer = new StaticTile[num3];
                }
                tileArray1 = TileMatrix.m_TileBuffer;
                try
                {
                    fixed (StaticTile* local1 = tileArray1)
                    {
                    }
                    TileMatrix._lread(this.m_Statics.Handle, ((void*) local1), num2);
                    if (TileMatrix.m_Lists == null)
                    {
                        TileMatrix.m_Lists = new TileList[8][];
                        for (num4 = 0; (num4 < 8); ++num4)
                        {
                            TileMatrix.m_Lists[num4] = new TileList[8];
                            for (num5 = 0; (num5 < 8); ++num5)
                            {
                                TileMatrix.m_Lists[num4][num5] = new TileList();
                            }
                        }
                    }
                    listArrayArray1 = TileMatrix.m_Lists;
                    tilePtr1 = local1;
                    tilePtr2 = (local1 + (num3 * sizeof(StaticTile)));
                    while ((tilePtr1 < tilePtr2))
                    {
                        listArrayArray1[(tilePtr1.m_X & 7)][(tilePtr1.m_Y & 7)].Add(((short) ((tilePtr1.m_ID & 16383) + 16384)), tilePtr1.m_Z);
                        tilePtr1 += sizeof(StaticTile);
                    }
                    tileArrayArrayArray1 = new Tile[8][][];
                    for (num6 = 0; (num6 < 8); ++num6)
                    {
                        tileArrayArrayArray1[num6] = new Tile[8][];
                        for (num7 = 0; (num7 < 8); ++num7)
                        {
                            tileArrayArrayArray1[num6][num7] = listArrayArray1[num6][num7].ToArray();
                        }
                    }
                    return tileArrayArrayArray1;
                }
                finally
                {
                    local1 = ((pinned ref StaticTile) IntPtr.Zero);
                }
            }
            catch (EndOfStreamException)
            {
                if (DateTime.Now >= this.m_NextStaticWarning)
                {
                    Console.WriteLine("Warning: Static EOS for {0} ({1}, {2})", this.m_Owner, x, y);
                    this.m_NextStaticWarning = (DateTime.Now + TimeSpan.FromMinutes(1));
                }
                return this.m_EmptyStaticBlock;
            }
            return tileArrayArrayArray2;
        }

        public void SetLandBlock(int x, int y, Tile[] value)
        {
            int[] numArray1;
            IntPtr ptr1;
            if (((x < 0) || (y < 0)) || ((x >= this.m_BlockWidth) || (y >= this.m_BlockHeight)))
            {
                return;
            }
            if (this.m_LandTiles[x] == null)
            {
                this.m_LandTiles[x] = new Tile[this.m_BlockHeight][];
            }
            this.m_LandTiles[x][y] = value;
            if (this.m_LandPatches[x] == null)
            {
                this.m_LandPatches[x] = new int[((this.m_BlockHeight + 31) >> 5)];
            }
            (numArray1 = this.m_LandPatches[x])[(ptr1 = ((IntPtr) (y >> 5)))] = (numArray1[ptr1] | (1 << ((y & 31) & 31)));
        }

        public void SetStaticBlock(int x, int y, Tile[][][] value)
        {
            int[] numArray1;
            IntPtr ptr1;
            if (((x < 0) || (y < 0)) || ((x >= this.m_BlockWidth) || (y >= this.m_BlockHeight)))
            {
                return;
            }
            if (this.m_StaticTiles[x] == null)
            {
                this.m_StaticTiles[x] = new Tile[this.m_BlockHeight][][][];
            }
            this.m_StaticTiles[x][y] = value;
            if (this.m_StaticPatches[x] == null)
            {
                this.m_StaticPatches[x] = new int[((this.m_BlockHeight + 31) >> 5)];
            }
            (numArray1 = this.m_StaticPatches[x])[(ptr1 = ((IntPtr) (y >> 5)))] = (numArray1[ptr1] | (1 << ((y & 31) & 31)));
        }


        // Properties
        public int BlockHeight
        {
            get
            {
                return this.m_BlockHeight;
            }
        }

        public int BlockWidth
        {
            get
            {
                return this.m_BlockWidth;
            }
        }

        public FileStream DataStream
        {
            get
            {
                return this.m_Statics;
            }
            set
            {
                this.m_Statics = value;
            }
        }

        public Tile[][][] EmptyStaticBlock
        {
            get
            {
                return this.m_EmptyStaticBlock;
            }
        }

        public bool Exists
        {
            get
            {
                if ((this.m_Map != null) && (this.m_Index != null))
                {
                    return (this.m_Statics != null);
                }
                return false;
            }
        }

        public int Height
        {
            get
            {
                return this.m_Height;
            }
        }

        public BinaryReader IndexReader
        {
            get
            {
                return this.m_IndexReader;
            }
            set
            {
                this.m_IndexReader = value;
            }
        }

        public FileStream IndexStream
        {
            get
            {
                return this.m_Index;
            }
            set
            {
                this.m_Index = value;
            }
        }

        public FileStream MapStream
        {
            get
            {
                return this.m_Map;
            }
            set
            {
                this.m_Map = value;
            }
        }

        public Map Owner
        {
            get
            {
                return this.m_Owner;
            }
        }

        public TileMatrixPatch Patch
        {
            get
            {
                return this.m_Patch;
            }
        }

        public int Width
        {
            get
            {
                return this.m_Width;
            }
        }


        // Fields
        private int m_BlockHeight;
        private int m_BlockWidth;
        private Tile[][][] m_EmptyStaticBlock;
        private int m_FileIndex;
        private ArrayList m_FileShare;
        private int m_Height;
        private FileStream m_Index;
        private BinaryReader m_IndexReader;
        private static ArrayList m_Instances;
        private Tile[] m_InvalidLandBlock;
        private int[][] m_LandPatches;
        private Tile[][][] m_LandTiles;
        private static TileList[][] m_Lists;
        private FileStream m_Map;
        private DateTime m_NextLandWarning;
        private DateTime m_NextStaticWarning;
        private Map m_Owner;
        private TileMatrixPatch m_Patch;
        private int[][] m_StaticPatches;
        private FileStream m_Statics;
        private Tile[][][][][] m_StaticTiles;
        private static StaticTile[] m_TileBuffer;
        private static TileList m_TilesList;
        private int m_Width;
    }
}

