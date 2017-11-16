namespace Server
{
    using System;
    using System.IO;

    public sealed class MultiComponentList
    {
        // Methods
        static MultiComponentList()
        {
            MultiComponentList.Empty = new MultiComponentList();
        }

        private MultiComponentList()
        {
            this.m_Tiles = new Tile[0][][];
            this.m_List = new MultiTileEntry[0];
        }

        public MultiComponentList(GenericReader reader)
        {
            int num3;
            int num4;
            int num5;
            int num6;
            int num7;
            int num8;
            int num9;
            int num10;
            MultiTileEntry[] entryArray2;
            int num11 = reader.ReadInt();
            if (num11 != 0)
            {
                return;
            }
            this.m_Min = reader.ReadPoint2D();
            this.m_Max = reader.ReadPoint2D();
            this.m_Center = reader.ReadPoint2D();
            this.m_Width = reader.ReadInt();
            this.m_Height = reader.ReadInt();
            int num2 = reader.ReadInt();
            this.m_List = (entryArray2 = new MultiTileEntry[num2]);
            MultiTileEntry[] entryArray1 = entryArray2;
            for (num3 = 0; (num3 < num2); ++num3)
            {
                entryArray1[num3].m_ItemID = reader.ReadShort();
                entryArray1[num3].m_OffsetX = reader.ReadShort();
                entryArray1[num3].m_OffsetY = reader.ReadShort();
                entryArray1[num3].m_OffsetZ = reader.ReadShort();
                entryArray1[num3].m_Flags = reader.ReadInt();
            }
            TileList[][] listArrayArray1 = new TileList[this.m_Width][];
            this.m_Tiles = new Tile[this.m_Width][][];
            for (num4 = 0; (num4 < this.m_Width); ++num4)
            {
                listArrayArray1[num4] = new TileList[this.m_Height];
                this.m_Tiles[num4] = new Tile[this.m_Height][];
                for (num5 = 0; (num5 < this.m_Height); ++num5)
                {
                    listArrayArray1[num4][num5] = new TileList();
                }
            }
            for (num6 = 0; (num6 < entryArray1.Length); ++num6)
            {
                if ((num6 == 0) || (entryArray1[num6].m_Flags != 0))
                {
                    num7 = (entryArray1[num6].m_OffsetX + this.m_Center.m_X);
                    num8 = (entryArray1[num6].m_OffsetY + this.m_Center.m_Y);
                    listArrayArray1[num7][num8].Add(((short) ((entryArray1[num6].m_ItemID & 16383) | 16384)), ((sbyte) entryArray1[num6].m_OffsetZ));
                }
            }
            for (num9 = 0; (num9 < this.m_Width); ++num9)
            {
                for (num10 = 0; (num10 < this.m_Height); ++num10)
                {
                    this.m_Tiles[num9][num10] = listArrayArray1[num9][num10].ToArray();
                }
            }
        }

        public MultiComponentList(MultiComponentList toCopy)
        {
            int num1;
            int num2;
            int num3;
            int num4;
            this.m_Min = toCopy.m_Min;
            this.m_Max = toCopy.m_Max;
            this.m_Center = toCopy.m_Center;
            this.m_Width = toCopy.m_Width;
            this.m_Height = toCopy.m_Height;
            this.m_Tiles = new Tile[this.m_Width][][];
            for (num1 = 0; (num1 < this.m_Width); ++num1)
            {
                this.m_Tiles[num1] = new Tile[this.m_Height][];
                for (num2 = 0; (num2 < this.m_Height); ++num2)
                {
                    this.m_Tiles[num1][num2] = new Tile[toCopy.m_Tiles[num1][num2].Length];
                    for (num3 = 0; (num3 < this.m_Tiles[num1][num2].Length); ++num3)
                    {
                        this.m_Tiles[num1][num2][num3] = toCopy.m_Tiles[num1][num2][num3];
                    }
                }
            }
            this.m_List = new MultiTileEntry[toCopy.m_List.Length];
            for (num4 = 0; (num4 < this.m_List.Length); ++num4)
            {
                this.m_List[num4] = toCopy.m_List[num4];
            }
        }

        public MultiComponentList(BinaryReader reader, int count)
        {
            int num1;
            MultiTileEntry entry1;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            int num7;
            int num8;
            MultiTileEntry[] entryArray2;
            this.m_List = (entryArray2 = new MultiTileEntry[count]);
            MultiTileEntry[] entryArray1 = entryArray2;
            for (num1 = 0; (num1 < count); ++num1)
            {
                entryArray1[num1].m_ItemID = reader.ReadInt16();
                entryArray1[num1].m_OffsetX = reader.ReadInt16();
                entryArray1[num1].m_OffsetY = reader.ReadInt16();
                entryArray1[num1].m_OffsetZ = reader.ReadInt16();
                entryArray1[num1].m_Flags = reader.ReadInt32();
                entry1 = entryArray1[num1];
                if ((num1 == 0) || (entry1.m_Flags != 0))
                {
                    if (entry1.m_OffsetX < this.m_Min.m_X)
                    {
                        this.m_Min.m_X = entry1.m_OffsetX;
                    }
                    if (entry1.m_OffsetY < this.m_Min.m_Y)
                    {
                        this.m_Min.m_Y = entry1.m_OffsetY;
                    }
                    if (entry1.m_OffsetX > this.m_Max.m_X)
                    {
                        this.m_Max.m_X = entry1.m_OffsetX;
                    }
                    if (entry1.m_OffsetY > this.m_Max.m_Y)
                    {
                        this.m_Max.m_Y = entry1.m_OffsetY;
                    }
                }
            }
            this.m_Center = new Point2D(-this.m_Min.m_X, -this.m_Min.m_Y);
            this.m_Width = ((this.m_Max.m_X - this.m_Min.m_X) + 1);
            this.m_Height = ((this.m_Max.m_Y - this.m_Min.m_Y) + 1);
            TileList[][] listArrayArray1 = new TileList[this.m_Width][];
            this.m_Tiles = new Tile[this.m_Width][][];
            for (num2 = 0; (num2 < this.m_Width); ++num2)
            {
                listArrayArray1[num2] = new TileList[this.m_Height];
                this.m_Tiles[num2] = new Tile[this.m_Height][];
                for (num3 = 0; (num3 < this.m_Height); ++num3)
                {
                    listArrayArray1[num2][num3] = new TileList();
                }
            }
            for (num4 = 0; (num4 < entryArray1.Length); ++num4)
            {
                if ((num4 == 0) || (entryArray1[num4].m_Flags != 0))
                {
                    num5 = (entryArray1[num4].m_OffsetX + this.m_Center.m_X);
                    num6 = (entryArray1[num4].m_OffsetY + this.m_Center.m_Y);
                    listArrayArray1[num5][num6].Add(((short) ((entryArray1[num4].m_ItemID & 16383) | 16384)), ((sbyte) entryArray1[num4].m_OffsetZ));
                }
            }
            for (num7 = 0; (num7 < this.m_Width); ++num7)
            {
                for (num8 = 0; (num8 < this.m_Height); ++num8)
                {
                    this.m_Tiles[num7][num8] = listArrayArray1[num7][num8].ToArray();
                }
            }
        }

        public void Add(int itemID, int x, int y, int z)
        {
            int num3;
            int num4;
            int num5;
            itemID &= 16383;
            itemID |= 16384;
            int num1 = (x + this.m_Center.m_X);
            int num2 = (y + this.m_Center.m_Y);
            if (((num1 < 0) || (num1 >= this.m_Width)) || ((num2 < 0) || (num2 >= this.m_Height)))
            {
                return;
            }
            Tile[] tileArray1 = this.m_Tiles[num1][num2];
            for (num3 = (tileArray1.Length - 1); (num3 >= 0); --num3)
            {
                if ((tileArray1[num3].Z == z) && ((tileArray1[num3].Height > 0) == (TileData.ItemTable[(itemID & 16383)].Height > 0)))
                {
                    this.Remove(tileArray1[num3].ID, x, y, z);
                }
            }
            tileArray1 = this.m_Tiles[num1][num2];
            Tile[] tileArray2 = new Tile[(tileArray1.Length + 1)];
            for (num4 = 0; (num4 < tileArray1.Length); ++num4)
            {
                tileArray2[num4] = tileArray1[num4];
            }
            tileArray2[tileArray1.Length] = new Tile(((short) itemID), ((sbyte) z));
            this.m_Tiles[num1][num2] = tileArray2;
            MultiTileEntry[] entryArray1 = this.m_List;
            MultiTileEntry[] entryArray2 = new MultiTileEntry[(entryArray1.Length + 1)];
            for (num5 = 0; (num5 < entryArray1.Length); ++num5)
            {
                entryArray2[num5] = entryArray1[num5];
            }
            entryArray2[entryArray1.Length] = new MultiTileEntry(((short) itemID), ((short) x), ((short) y), ((short) z), 1);
            this.m_List = entryArray2;
            if (x < this.m_Min.m_X)
            {
                this.m_Min.m_X = x;
            }
            if (y < this.m_Min.m_Y)
            {
                this.m_Min.m_Y = y;
            }
            if (x > this.m_Max.m_X)
            {
                this.m_Max.m_X = x;
            }
            if (y > this.m_Max.m_Y)
            {
                this.m_Max.m_Y = y;
            }
        }

        public void Remove(int itemID, int x, int y, int z)
        {
            int num3;
            Tile tile1;
            Tile[] tileArray2;
            int num4;
            int num5;
            int num6;
            MultiTileEntry entry1;
            MultiTileEntry[] entryArray2;
            int num7;
            int num8;
            int num1 = (x + this.m_Center.m_X);
            int num2 = (y + this.m_Center.m_Y);
            if (((num1 < 0) || (num1 >= this.m_Width)) || ((num2 < 0) || (num2 >= this.m_Height)))
            {
                return;
            }
            Tile[] tileArray1 = this.m_Tiles[num1][num2];
            for (num3 = 0; (num3 < tileArray1.Length); ++num3)
            {
                tile1 = tileArray1[num3];
                if (((tile1.ID & 16383) == (itemID & 16383)) && (tile1.Z == z))
                {
                    tileArray2 = new Tile[(tileArray1.Length - 1)];
                    for (num4 = 0; (num4 < num3); ++num4)
                    {
                        tileArray2[num4] = tileArray1[num4];
                    }
                    for (num5 = (num3 + 1); (num5 < tileArray1.Length); ++num5)
                    {
                        tileArray2[(num5 - 1)] = tileArray1[num5];
                    }
                    this.m_Tiles[num1][num2] = tileArray2;
                    break;
                }
            }
            MultiTileEntry[] entryArray1 = this.m_List;
            for (num6 = 0; (num6 < entryArray1.Length); ++num6)
            {
                entry1 = entryArray1[num6];
                if ((((entry1.m_ItemID & 16383) == ((short) (itemID & 16383))) && (entry1.m_OffsetX == ((short) x))) && ((entry1.m_OffsetY == ((short) y)) && (entry1.m_OffsetZ == ((short) z))))
                {
                    entryArray2 = new MultiTileEntry[(entryArray1.Length - 1)];
                    for (num7 = 0; (num7 < num6); ++num7)
                    {
                        entryArray2[num7] = entryArray1[num7];
                    }
                    for (num8 = (num6 + 1); (num8 < entryArray1.Length); ++num8)
                    {
                        entryArray2[(num8 - 1)] = entryArray1[num8];
                    }
                    this.m_List = entryArray2;
                    return;
                }
            }
        }

        public void RemoveXYZH(int x, int y, int z, int minHeight)
        {
            int num3;
            Tile tile1;
            Tile[] tileArray2;
            int num4;
            int num5;
            int num6;
            MultiTileEntry entry1;
            MultiTileEntry[] entryArray2;
            int num7;
            int num8;
            int num1 = (x + this.m_Center.m_X);
            int num2 = (y + this.m_Center.m_Y);
            if (((num1 < 0) || (num1 >= this.m_Width)) || ((num2 < 0) || (num2 >= this.m_Height)))
            {
                return;
            }
            Tile[] tileArray1 = this.m_Tiles[num1][num2];
            for (num3 = 0; (num3 < tileArray1.Length); ++num3)
            {
                tile1 = tileArray1[num3];
                if ((tile1.Z == z) && (tile1.Height >= minHeight))
                {
                    tileArray2 = new Tile[(tileArray1.Length - 1)];
                    for (num4 = 0; (num4 < num3); ++num4)
                    {
                        tileArray2[num4] = tileArray1[num4];
                    }
                    for (num5 = (num3 + 1); (num5 < tileArray1.Length); ++num5)
                    {
                        tileArray2[(num5 - 1)] = tileArray1[num5];
                    }
                    this.m_Tiles[num1][num2] = tileArray2;
                    break;
                }
            }
            MultiTileEntry[] entryArray1 = this.m_List;
            for (num6 = 0; (num6 < entryArray1.Length); ++num6)
            {
                entry1 = entryArray1[num6];
                if (((entry1.m_OffsetX == ((short) x)) && (entry1.m_OffsetY == ((short) y))) && ((entry1.m_OffsetZ == ((short) z)) && (TileData.ItemTable[(entry1.m_ItemID & 16383)].Height >= minHeight)))
                {
                    entryArray2 = new MultiTileEntry[(entryArray1.Length - 1)];
                    for (num7 = 0; (num7 < num6); ++num7)
                    {
                        entryArray2[num7] = entryArray1[num7];
                    }
                    for (num8 = (num6 + 1); (num8 < entryArray1.Length); ++num8)
                    {
                        entryArray2[(num8 - 1)] = entryArray1[num8];
                    }
                    this.m_List = entryArray2;
                    return;
                }
            }
        }

        public void Resize(int newWidth, int newHeight)
        {
            int num4;
            int num5;
            int num7;
            int num8;
            Tile[] tileArray1;
            int num9;
            Tile tile1;
            int num10;
            int num11;
            int num1 = this.m_Width;
            int num2 = this.m_Height;
            Tile[][][] tileArrayArrayArray1 = this.m_Tiles;
            int num3 = 0;
            Tile[][][] tileArrayArrayArray2 = new Tile[newWidth][][];
            for (num4 = 0; (num4 < newWidth); ++num4)
            {
                tileArrayArrayArray2[num4] = new Tile[newHeight][];
                for (num5 = 0; (num5 < newHeight); ++num5)
                {
                    if ((num4 < num1) && (num5 < num2))
                    {
                        tileArrayArrayArray2[num4][num5] = tileArrayArrayArray1[num4][num5];
                    }
                    else
                    {
                        tileArrayArrayArray2[num4][num5] = new Tile[0];
                    }
                    num3 += tileArrayArrayArray2[num4][num5].Length;
                }
            }
            this.m_Tiles = tileArrayArrayArray2;
            this.m_List = new MultiTileEntry[num3];
            this.m_Width = newWidth;
            this.m_Height = newHeight;
            this.m_Min = Point2D.Zero;
            this.m_Max = Point2D.Zero;
            int num6 = 0;
            for (num7 = 0; (num7 < newWidth); ++num7)
            {
                for (num8 = 0; (num8 < newHeight); ++num8)
                {
                    tileArray1 = tileArrayArrayArray2[num7][num8];
                    for (num9 = 0; (num9 < tileArray1.Length); ++num9)
                    {
                        tile1 = tileArray1[num9];
                        num10 = (num7 - this.m_Center.X);
                        num11 = (num8 - this.m_Center.Y);
                        if (num10 < this.m_Min.m_X)
                        {
                            this.m_Min.m_X = num10;
                        }
                        if (num11 < this.m_Min.m_Y)
                        {
                            this.m_Min.m_Y = num11;
                        }
                        if (num10 > this.m_Max.m_X)
                        {
                            this.m_Max.m_X = num10;
                        }
                        if (num11 > this.m_Max.m_Y)
                        {
                            this.m_Max.m_Y = num11;
                        }
                        this.m_List[num6++] = new MultiTileEntry(((short) tile1.ID), ((short) num10), ((short) num11), ((short) tile1.Z), 1);
                    }
                }
            }
        }

        public void Serialize(GenericWriter writer)
        {
            int num1;
            MultiTileEntry entry1;
            writer.Write(0);
            writer.Write(this.m_Min);
            writer.Write(this.m_Max);
            writer.Write(this.m_Center);
            writer.Write(this.m_Width);
            writer.Write(this.m_Height);
            writer.Write(this.m_List.Length);
            for (num1 = 0; (num1 < this.m_List.Length); ++num1)
            {
                entry1 = this.m_List[num1];
                writer.Write(entry1.m_ItemID);
                writer.Write(entry1.m_OffsetX);
                writer.Write(entry1.m_OffsetY);
                writer.Write(entry1.m_OffsetZ);
                writer.Write(entry1.m_Flags);
            }
        }


        // Properties
        public Point2D Center
        {
            get
            {
                return this.m_Center;
            }
        }

        public int Height
        {
            get
            {
                return this.m_Height;
            }
        }

        public MultiTileEntry[] List
        {
            get
            {
                return this.m_List;
            }
        }

        public Point2D Max
        {
            get
            {
                return this.m_Max;
            }
        }

        public Point2D Min
        {
            get
            {
                return this.m_Min;
            }
        }

        public Tile[][][] Tiles
        {
            get
            {
                return this.m_Tiles;
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
        public static readonly MultiComponentList Empty;
        private Point2D m_Center;
        private int m_Height;
        private MultiTileEntry[] m_List;
        private Point2D m_Max;
        private Point2D m_Min;
        private Tile[][][] m_Tiles;
        private int m_Width;
    }
}

