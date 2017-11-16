namespace Server.Network
{
    using Server;
    using System;

    public sealed class MapPatches : Packet
    {
        // Methods
        public MapPatches() : base(191)
        {
            base.EnsureCapacity(33);
            this.m_Stream.Write(((short) 24));
            this.m_Stream.Write(4);
            this.m_Stream.Write(Map.Felucca.Tiles.Patch.StaticBlocks);
            this.m_Stream.Write(Map.Felucca.Tiles.Patch.LandBlocks);
            this.m_Stream.Write(Map.Trammel.Tiles.Patch.StaticBlocks);
            this.m_Stream.Write(Map.Trammel.Tiles.Patch.LandBlocks);
            this.m_Stream.Write(Map.Ilshenar.Tiles.Patch.StaticBlocks);
            this.m_Stream.Write(Map.Ilshenar.Tiles.Patch.LandBlocks);
            this.m_Stream.Write(Map.Malas.Tiles.Patch.StaticBlocks);
            this.m_Stream.Write(Map.Malas.Tiles.Patch.LandBlocks);
        }

    }
}

