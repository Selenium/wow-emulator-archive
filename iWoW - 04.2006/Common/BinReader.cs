using System;
using System.IO;
using System.Text;

namespace WoWDaemon.Common
{
	/// <summary>
	/// Replacement for BinaryReader so it reads C-strings instead of pascal strings
	/// </summary>
	public class BinReader : BinaryReader
	{
		public BinReader(byte[] data) : base(new MemoryStream(data))
		{

		}

		public BinReader(Stream input) : base(input)
		{
		}

		public BinReader(Stream input, Encoding encoding) : base(input, encoding)
		{
		}

//	*** this apparently doesn't work - I don't understand why; it'd be quite handy in RealmListServer
/*		public static BinReader MakeFromCompletePacket(byte[] header, byte[] data)
		{
			MemoryStream stream = new MemoryStream();
			stream.Write(header, 0, header.Length);
			stream.Write(data, 0, data.Length);

			BinReader b = new BinReader(stream);
			//BinReader k = new BinReader(data);
			return b;
		}
 */

		public override string ReadString()
		{
			if(BaseStream.Position >= BaseStream.Length)
				return string.Empty;
			StringBuilder s = new StringBuilder();
			while(BaseStream.Position < BaseStream.Length)
			{
				byte b = ReadByte();
				if(b == 0)
					break;
				s.Append((char)b);
			}
			return s.ToString();
		}

		public string ReadString(int maxlen)
		{
			if(maxlen == 0)
				return string.Empty;
			byte[] buf = new byte[maxlen];
			int i = 0;
			for(;i < maxlen;i++)
			{
				buf[i] = ReadByte();
				if(buf[i] == 0)
					break;
			}
			return System.Text.ASCIIEncoding.ASCII.GetString(buf, 0, i);
		}

		public Vector ReadVector()
		{
			return new Vector(ReadSingle(), ReadSingle(), ReadSingle());
		}

		public long Length()
		{
			return BaseStream.Length;
		}
	}
}
