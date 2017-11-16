namespace WorldServer
{
    using ICSharpCode.SharpZipLib.Zip.Compression;
    using System;
    using System.IO;

    public class ZLib
    {
        public static byte[] Compress(byte[] input)
        {
            return Compress(input, 0, input.Length);
        }

        public static byte[] Compress(byte[] input, int offset, int len)
        {
            byte[] sourceArray = new byte[0x400];
            int num = 0;
            Deflater deflater = new Deflater();
            deflater.SetInput(input, offset, len);
            deflater.Finish();
            while (!deflater.IsFinished)
            {
                if (num == sourceArray.Length)
                {
                    byte[] buffer2 = new byte[sourceArray.Length * 2];
                    Array.Copy(sourceArray, buffer2, sourceArray.Length);
                    sourceArray = buffer2;
                }
                try
                {
                    num += deflater.Deflate(sourceArray, num, sourceArray.Length - num);
                }
                catch (FormatException exception)
                {
                    throw new IOException(exception.ToString());
                }
            }
            deflater.Reset();
            byte[] destinationArray = new byte[num];
            Array.Copy(sourceArray, destinationArray, num);
            return destinationArray;
        }

        public static byte[] Decompress(byte[] input)
        {
            return Decompress(input, 0, input.Length);
        }

        public static byte[] Decompress(byte[] input, int offset, int len)
        {
            byte[] sourceArray = new byte[0x400];
            int num = 0;
            Inflater inflater = new Inflater();
            inflater.SetInput(input, offset, len);
            while (!inflater.IsFinished)
            {
                if (inflater.IsNeedingInput)
                {
                    throw new Exception("inflateData: input incomplete!");
                }
                if (num == sourceArray.Length)
                {
                    byte[] buffer2 = new byte[sourceArray.Length * 2];
                    Array.Copy(sourceArray, buffer2, sourceArray.Length);
                    sourceArray = buffer2;
                }
                try
                {
                    num += inflater.Inflate(sourceArray, num, sourceArray.Length - num);
                }
                catch (FormatException exception)
                {
                    throw new IOException(exception.ToString());
                }
            }
            inflater.Reset();
            byte[] destinationArray = new byte[num];
            Array.Copy(sourceArray, destinationArray, num);
            return destinationArray;
        }
    }
}

