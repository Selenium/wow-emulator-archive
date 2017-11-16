using System;
using System.IO;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip.Compression;

namespace WoWDaemon.Common
{
	/// <summary>
	/// Summary description for ZLib.
	/// </summary>
	public class ZLib
	{
		public static byte[] Compress(byte[] input)
		{
			return Compress(input, 0, input.Length);
		}

		public static byte[] Compress(byte[] input, int offset, int len)
		{
			byte[] output = new byte[1024];
			int outputused = 0;
			Deflater deflater = new Deflater();
			deflater.SetInput(input, offset, len);
			deflater.Finish();
			while(deflater.IsFinished == false)
			{
				
				//				if(deflater.IsNeedingInput && deflater.IsFinished == false)
				//					throw(new Exception("deflateData: input incomplete!"));
				if(outputused == output.Length)
				{
					byte[] newOutput = new byte[output.Length * 2];
					Array.Copy(output, newOutput, output.Length);
					output = newOutput;
				}
				try
				{
					outputused += deflater.Deflate(output, outputused, output.Length - outputused);
				}
				catch (FormatException e)
				{
					throw(new IOException(e.ToString()));
				}
			}
			deflater.Reset();
			byte[] realOutput = new byte[outputused];
			Array.Copy(output, realOutput, outputused);
			return realOutput;
		}

		public static byte[] Decompress(byte[] input)
		{
			return Decompress(input, 0, input.Length);
		}
		public static byte[] Decompress(byte[] input, int offset, int len)
		{
			byte[] output = new byte[1024];
			int outputused = 0;
			Inflater inflater = new Inflater();
			inflater.SetInput(input, offset, len);
			while(inflater.IsFinished == false)
			{
				if(inflater.IsNeedingInput)
					throw(new Exception("inflateData: input incomplete!"));
				if(outputused == output.Length)
				{
					byte[] newOutput = new byte[output.Length * 2];
					Array.Copy(output, newOutput, output.Length);
					output = newOutput;
				}
				try
				{
					outputused += inflater.Inflate(output, outputused, output.Length - outputused);
				}
				catch (FormatException e)
				{
					throw(new IOException(e.ToString()));
				}
			}
			inflater.Reset();
			byte[] realOutput = new byte[outputused];
			Array.Copy(output, realOutput, outputused);
			return realOutput;
		}
	}
}
