using System;
using System.IO;

namespace WoWDaemon.Common
{
	/// <summary>
	/// Replacement for BinaryWriter so it writes C-strings instead of pascal strings
	/// </summary>
	public class BinWriter : BinaryWriter
	{
		public BinWriter() : base(new MemoryStream())
		{
		}

		public void WriteVector(Vector value)
		{
			Write(value.X);
			Write(value.Y);
			Write(value.Z);
		}

		// didn't like the implicit string operator
		public override void Write(string value)
		{
			byte[] data = System.Text.Encoding.ASCII.GetBytes(value);
			Write(data);
			Write((byte)0);
		}
		
		public byte[] GetBuffer()
		{
			return ((MemoryStream)BaseStream).GetBuffer();
		}

		public void Set(int offset, uint value)
		{
			long pos = BaseStream.Position;
			BaseStream.Position = offset;
			Write(value);
			BaseStream.Position = pos;
		}

		public void Set(int offset, int value)
		{
			long pos = BaseStream.Position;
			BaseStream.Position = offset;
			Write(value);
			BaseStream.Position = pos;
		}

		public void Set(int offset, ushort value)
		{
			long pos = BaseStream.Position;
			BaseStream.Position = offset;
			Write(value);
			BaseStream.Position = pos;
		}

		public void Set(int offset, short value)
		{
			long pos = BaseStream.Position;
			BaseStream.Position = offset;
			Write(value);
			BaseStream.Position = pos;
		}

		public void Set(int offset, byte value)
		{
			long pos = BaseStream.Position;
			BaseStream.Position = offset;
			Write(value);
			BaseStream.Position = pos;
		}

		public void Set(int offset, sbyte value)
		{
			long pos = BaseStream.Position;
			BaseStream.Position = offset;
			Write(value);
			BaseStream.Position = pos;
		}

		public void Set(int offset, string value)
		{
			long pos = BaseStream.Position;
			BaseStream.Position = offset;
			Write(value);
			BaseStream.Position = pos;
		}

		public void SetVector(int offset, Vector value)
		{
			long pos = BaseStream.Position;
			BaseStream.Position = offset;
			WriteVector(value);
			BaseStream.Position = pos;
		}

	}
}
