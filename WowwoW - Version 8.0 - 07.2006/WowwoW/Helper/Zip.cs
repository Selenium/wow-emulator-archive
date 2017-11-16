using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
//using zLibWrapper;

namespace HelperTools
{
	/// <summary>
	/// Summary description for Zip.
	/// </summary>
	public class Zip
	{
		public Zip()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public static byte[]Compress( byte []b, int offset, int len )
		{
			try
			{
				/*zLib e = new zLib();
				byte []compressedData = null;
				e.CompressStream( b, ref compressedData );*/
				
				MemoryStream ms = new MemoryStream();
				DeflaterOutputStream defl = new DeflaterOutputStream( ms );
				
				defl.Write(b, offset, len );
				defl.Flush();
				defl.Close();
				byte[] compressedData = (byte[])ms.ToArray();
				//HexViewer.View( compressedData, 0, compressedData.Length );
				return compressedData;
			}
			catch(Exception e)
			{
				Console.WriteLine( e.Message );
				return null;
			}
		}

		static byte []writeData = new byte[ 65536 * 16 ];
		public static byte[]DeCompress( byte []b )
		{
			Stream s2 = new InflaterInputStream( new MemoryStream( b ) );
			try
			{
				byte []dest = null;
				int size = s2.Read( writeData, 0, writeData.Length);
				if (size > 0) 
				{
					dest = new byte[ size ];
					Buffer.BlockCopy( writeData , 0, dest, 0, size );
				} 
				s2.Flush();
				s2.Close();
				return dest;
			}
			catch(Exception e)
			{
				Console.WriteLine( e.Message );
				return null;
			}
		}
	}
}
