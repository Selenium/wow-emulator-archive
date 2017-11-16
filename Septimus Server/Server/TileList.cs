namespace Server
{
    using System;

    public class TileList
    {
        // Methods
        static TileList()
        {
            TileList.m_EmptyTiles = new Tile[0];
        }

        public TileList()
        {
            this.m_Tiles = new Tile[8];
            this.m_Count = 0;
        }

        public void Add(short id, sbyte z)
        {
            Tile[] tileArray1;
            int num1;
            if ((this.m_Count + 1) > this.m_Tiles.Length)
            {
                tileArray1 = this.m_Tiles;
                this.m_Tiles = new Tile[(tileArray1.Length * 2)];
                for (num1 = 0; (num1 < tileArray1.Length); ++num1)
                {
                    this.m_Tiles[num1] = tileArray1[num1];
                }
            }
            this.m_Tiles[this.m_Count].m_ID = id;
            this.m_Tiles[this.m_Count].m_Z = z;
            ++this.m_Count;
        }

        public void AddRange(Tile[] tiles)
        {
            Tile[] tileArray1;
            int num1;
            int num2;
            if ((this.m_Count + tiles.Length) > this.m_Tiles.Length)
            {
                tileArray1 = this.m_Tiles;
                this.m_Tiles = new Tile[((this.m_Count + tiles.Length) * 2)];
                for (num1 = 0; (num1 < tileArray1.Length); ++num1)
                {
                    this.m_Tiles[num1] = tileArray1[num1];
                }
            }
            for (num2 = 0; (num2 < tiles.Length); ++num2)
            {
                this.m_Tiles[this.m_Count++] = tiles[num2];
            }
        }

        public Tile[] ToArray()
        {
            int num1;
            if (this.m_Count == 0)
            {
                return TileList.m_EmptyTiles;
            }
            Tile[] tileArray1 = new Tile[this.m_Count];
            for (num1 = 0; (num1 < this.m_Count); ++num1)
            {
                tileArray1[num1] = this.m_Tiles[num1];
            }
            this.m_Count = 0;
            return tileArray1;
        }


        // Properties
        public int Count
        {
            get
            {
                return this.m_Count;
            }
        }


        // Fields
        private int m_Count;
        private static Tile[] m_EmptyTiles;
        private Tile[] m_Tiles;
    }
}

