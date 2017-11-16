using System;
using System.IO;

namespace Maelstrom
{
	/// <summary>
	/// Provides a stream writer capable of writing null-terminated ASCII strings, as well as returning a byte array representation of the buffer.
	/// </summary>
	public class DataWriter: BinaryWriter
	{
		public override void Write(string value)
		{
			foreach(char Character in value)
			{
				this.Write((byte)Character);
			}

			this.Write((byte)0); //Null terminated.
		}
		
		/// <summary>
		/// Writes the entire stream contents to a byte array.
		/// </summary>
		/// <returns></returns>
		public byte[] ToArray()
		{
			if (BaseStream is MemoryStream)
			{
				//Use the base memory stream method.
				return ((MemoryStream)BaseStream).ToArray();
			}
			else
			{
				byte[] Result = new byte[BaseStream.Length];
				BaseStream.Read(Result,0,(int)BaseStream.Length);

				return Result;
			}
		}

		public DataWriter(): this(new byte[0]) {}
		public DataWriter(byte[] Buffer): base(new MemoryStream(Buffer,true)) {}
	}
}
