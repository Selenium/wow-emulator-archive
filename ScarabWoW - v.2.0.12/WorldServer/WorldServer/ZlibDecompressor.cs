namespace WorldServer
{
    using ICSharpCode.SharpZipLib.Zip.Compression;
    using System;

    internal class ZlibDecompressor
    {
        public byte[] Decompress(byte[] compressed, int LengthOffset)
        {
            Inflater inflater = new Inflater();
            inflater.SetInput(compressed);
            byte[] buf = new byte[compressed.Length + LengthOffset];
            inflater.Inflate(buf);
            return buf;
        }
    }
}

