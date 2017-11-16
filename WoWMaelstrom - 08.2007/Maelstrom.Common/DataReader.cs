using System;
using System.IO;
using System.Text;

namespace Maelstrom
{
	/// <summary>
	/// Provides a stream reader capable of reading null-terminated ASCII strings.
	/// </summary>
	public class DataReader: BinaryReader
	{
		public override string ReadString()
		{
			if (BaseStream.Position == BaseStream.Length) return "";

			StringBuilder Result = new StringBuilder();
			byte CurrentByte = this.ReadByte();

			while((BaseStream.Position != BaseStream.Length) && (CurrentByte != 0))
			{
				Result.Append((char)CurrentByte);
				CurrentByte = this.ReadByte();
			}

			return Result.ToString();
		}

		public DataReader(byte[] Buffer): base(new MemoryStream(Buffer)) {}
	}
}
