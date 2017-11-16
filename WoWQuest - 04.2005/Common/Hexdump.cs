using System;
using System.IO;
using System.Text;

namespace WoWDaemon.Common
{
	/// <summary>
	/// Good for debugging
	/// </summary>
	public class Hexdump
	{
		public static void ToConsole(string msg, byte val)
		{
			Console.Write(msg);
			Console.WriteLine("0x{0,2:X2}", val);
		}

		public static void ToConsole(string msg, short val)
		{
			Console.Write(msg);
			Console.WriteLine("0x{0,4:X4}", val);
		}

		public static void ToConsole(string msg, ushort val)
		{
			Console.Write(msg);
			Console.WriteLine("0x{0,4:X4}", val);
		}


		public static void ToConsole(string msg, int val)
		{
			Console.Write(msg);
			Console.WriteLine("0x{0,8:X8}", val);
		}

		public static void ToConsole(string msg, uint val)
		{
			Console.Write(msg);
			Console.WriteLine("0x{0,8:X8}", val);
		}

		public static void ToConsole(string msg, long val)
		{
			Console.Write(msg);
			Console.WriteLine("0x{0,16:X16}", val);
		}

		public static void ToConsole(string msg, ulong val)
		{
			Console.Write(msg);
			Console.WriteLine("0x{0,16:X16}", val);
		}

		public static void ToConsole(string msg, float val)
		{
			Console.Write(msg);
			byte[] data = BitConverter.GetBytes(val);
			Console.WriteLine("{1} ({0})", BitConverter.ToString(data), val);
		}

		public static void ToConsole(string msg, byte[] buffer, int len)
		{
			Console.WriteLine(msg);
			Console.Write(ToString(buffer, len));
		}

		public static void ToConsole(byte[] buffer, int len)
		{
			Console.Write(ToString(buffer, len));
		}
		
		public static string ToString(byte[] buffer, int len)
		{
			uint i,r,c,rows;
			rows = (uint)len/16;
			if(len % 16 != 0)
				rows++;
			StringBuilder str = new StringBuilder((int)(rows * 78));
			

			for(r=0,i=0;r < rows;r++,i+= 16)
			{
				
				str.Append(string.Format("{0,4:X4}   ", i));
				for(c=i; c < i+8;c++)
				{
					if(c < len)
						str.Append(string.Format("{0,2:X2} ", buffer[c]));
					else
						str.Append(' ', 3);
				}
				str.Append(' ', 2);
				for(c=i+8;c<i+16;c++)
				{
					if(c < len)
						str.Append(string.Format("{0,2:X2} ", buffer[c]));
					else
						str.Append(' ', 3);
				}
				str.Append(' ', 2);
				for(c=i;c < i+16;c++)
				{
					if(c < len)
					{
						if(buffer[c]>=32 && buffer[c]<127)
							str.Append((char)buffer[c]);
						else
							str.Append('.');
					}
					else
					{
						str.Append(' ');
					}
				}
				str.Append(Environment.NewLine);
			}
			return str.ToString();
		}

		public static void ToFile(byte[] buffer)
		{
			WriteToFile(ToString(buffer, buffer.Length));
		}

		public static void ToFile(byte[] buffer, SMSG msgID)
		{
			WriteToFile(ToString(buffer, buffer.Length));
		}

		public static void ToFile(byte[] buffer, CMSG msgID)
		{
			WriteToFile(ToString(buffer, buffer.Length));
		}

		public static void ToFile(BinWriter data)
		{
			WriteToFile(ToString(data.GetBuffer(),(int)data.BaseStream.Length));
		}

		public static void ToFile(BinWriter data, SMSG msgID)
		{
			string msg = msgID.ToString() + " : \n";
			msg += ToString(data.GetBuffer(),(int)data.BaseStream.Length);
			WriteToFile(msg);
		}

		public static void ToFile(BinWriter data, CMSG msgID)
		{
			string msg = msgID.ToString() + " : \n";
			msg += ToString(data.GetBuffer(),(int)data.BaseStream.Length);
			WriteToFile(msg);
		}

		public static void ToFile(BinReader data)
		{
			WriteToFile(ToString(data.ReadBytes((int)data.Length()),(int)data.Length()));
		}

		public static void ToFile(BinReader data, SMSG msgID)
		{
			string msg = msgID.ToString() + " : \n";
			msg += ToString(data.ReadBytes((int)data.Length()),(int)data.Length());
			WriteToFile(msg);
		}

		public static void ToFile(BinReader data, CMSG msgID)
		{
			string msg = msgID.ToString() + " : \n";
			msg += ToString(data.ReadBytes((int)data.Length()),(int)data.Length());
			WriteToFile(msg);
		}
        
		private static void WriteToFile(string msg) 
		{
			StreamWriter writer = null;
			try 
			{
				writer = new StreamWriter("HexDump.log", true);
				writer.WriteLine("[" + DateTime.Now.ToString() + "] ----------------------------------------------------------");
				writer.WriteLine(msg);
				writer.WriteLine("----------------------------------------------------------------------------------");
			} 
			catch 
			{
			} 
			finally
			{
				if (writer != null)
					writer.Close();
			}
		}
	}
}
