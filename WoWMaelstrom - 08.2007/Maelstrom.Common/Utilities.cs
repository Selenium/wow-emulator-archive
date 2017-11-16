using System;
using System.IO;
using System.Net;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Globalization;

namespace Maelstrom
{
	/// <summary>
	/// Provides a series of common utility methods.
	/// </summary>
	public sealed class Utilities
	{
		#region GetStreamResource

		public static Stream GetStreamResource(string Name)
		{
			return Assembly.GetExecutingAssembly().GetManifestResourceStream("Maelstrom."+Name);
		}

		#endregion
		#region GetStringResource

		public static string GetStringResource(string Name)
		{
			Stream ResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Maelstrom."+Name);

			if (ResourceStream == null) return null;

			StreamReader ResourceReader = new StreamReader(ResourceStream,System.Text.Encoding.ASCII);
			string Result = ResourceReader.ReadToEnd();
			ResourceReader.Close();

			return Result;
		}

		#endregion
		#region ToBoolean

		/// <summary>
		/// Attempts to convert the supplied string into a boolean value.
		/// </summary>
		/// <param name="Value">The value to attempt to convert.</param>
		/// <returns></returns>
		public static bool ToBoolean(string Value)
		{
			if (Value == null)
			{
				return false;
			}

			switch(Value.ToUpper())
			{
				case "YES":
				case "TRUE":
				case "1":
					return true;
				default:
					return false;
			}
		}

		#endregion
		#region ToUInt64

		public static ulong ToUInt64(string Value)
		{
			return (IsHexNumber(Value) ? ulong.Parse(Value.Substring(2,Value.Length-2),NumberStyles.HexNumber) : ulong.Parse(Value));
		}

		#endregion
		#region ToInt64

		public static long ToInt64(string Value)
		{
			return (IsHexNumber(Value) ? long.Parse(Value.Substring(2,Value.Length-2),NumberStyles.HexNumber) : long.Parse(Value));
		}

		#endregion
		#region ToSingle

		public static float ToSingle(string Value)
		{
			return float.Parse(Value);
		}

		#endregion
		#region ToNumericValue

		public static object ToNumericValue(string Value)
		{
			if (Utilities.IsHexNumber(Value))
			{
				Value = Value.Substring(2,Value.Length-2);
				return ulong.Parse(Value,System.Globalization.NumberStyles.AllowHexSpecifier);
			}
			else if (Utilities.IsWholeNumber(Value))
			{
				if (Value[0] == '-')
				{
					return long.Parse(Value);
				}
				else
				{
					return ulong.Parse(Value);
				}
			}
			else if (Utilities.IsRealNumber(Value))
			{
				return double.Parse(Value);
			}

			return null;
		}

		#endregion
		#region ToBytes

		public static byte[] ToBytes(BitArray Bits)
		{
			byte[] Result = new byte[(int)(Bits.Length/8)];
			Bits.CopyTo(Result,0);

			return Result;
		}

		/// <summary>
		/// Converts a string to its byte representation.
		/// </summary>
		/// <param name="Value">The string to convert.</param>
		/// <param name="IncludeTerminator">Indicates whether the string should include a null terminator.</param>
		/// <returns></returns>
		public static byte[] ToBytes(string Value, bool IncludeTerminator)
		{
			if (IncludeTerminator)
			{
				Value += (char)0;
			}

			return Encoding.ASCII.GetBytes(Value);
		}

		/// <summary>
		/// Converts a string to its byte representation.
		/// </summary>
		/// <param name="Value">The string to convert.</param>
		/// <param name="IncludeTerminator">Inidicates whether the string should include a null terminator.</param>
		/// <param name="Count">The amount of characters to convert.</param>
		/// <returns></returns>
		public static byte[] ToBytes(string Value, bool IncludeTerminator, int Count)
		{
			byte[] result = new byte[Count];

			if (IncludeTerminator)
			{
				Value += (char)0;
			}

			Array.Copy(Encoding.ASCII.GetBytes(Value),0,result,0,Value.Length);

			return result;
		}

		#endregion
		#region IsHexNumber

		public static bool IsHexNumber(string Value)
		{
			bool HasHexDelimiter = false;
			
			if ((Value.Length > 2) && (Value.Substring(0,2) == "0x"))
			{
				HasHexDelimiter = true;
				Value = Value.Substring(2,Value.Length-2).ToUpper();
			}

			if (HasHexDelimiter)
			{
				for(int i=0;i<=Value.Length-1;i++)
				{
					if (((Value[i] < '0') || (Value[i] > '9')) &&
						((Value[i] < 'A') || (Value[i] > 'F')))
					{
						return false;
					}
				}
			}
			else
			{
				return false;
			}

			return true;
		}

		#endregion
		#region IsWholeNumber

		public static bool IsWholeNumber(string Value)
		{
			if (Value[0] == '-')
			{
				Value = Value.Substring(1,Value.Length-1);
			}

			for(int i=0;i<=Value.Length-1;i++)
			{
				if ((Value[i] < '0') || (Value[i] > '9'))
				{
					return false;
				}
			}

			return true;
		}

		#endregion
		#region IsRealNumber

		public static bool IsRealNumber(string Value)
		{
			if (Value[0] == '-')
			{
				Value = Value.Substring(1,Value.Length-1);
			}

			if (Value[0] == '.')
			{
				return false;
			}

			if (Value[Value.Length-1] == '.')
			{
				return false;
			}

			string[] SplitValue = Value.Split('.');
			if (SplitValue.Length > 2)
			{
				return false;
			}
			else
			{
				for(int i=0;i<=SplitValue.Length-1;i++)
				{
					if (!IsWholeNumber(SplitValue[i]))
					{
						return false;
					}
				}

				return true;
			}
		}

		#endregion
		#region ToString

		/// <summary>
		/// Converts a byte array to its ASCII string representation.
		/// </summary>
		/// <param name="Value">The array of bytes to convert.</param>
		/// <returns></returns>
		public static string ToString(byte[] Value)
		{
			return Encoding.ASCII.GetString(Value);
		}

		#endregion
		#region ReadString

		public static string ReadString(BinaryReader Reader)
		{
			StringBuilder Result = new StringBuilder();

			byte CurrentByte = Reader.ReadByte();
			while (CurrentByte != 0)
			{
				Result.Append((char)CurrentByte);
				CurrentByte = Reader.ReadByte();
			}

			return Result.ToString();
		}

		#endregion
		#region FindFiles

		#region FindFilesInternal

		private static void FindFilesInternal(string Path, string Pattern, ref ArrayList List)
		{
			string[] Files = Directory.GetFiles(Path,Pattern);
			foreach(string File in Files)
			{
				List.Add(File);
			}
			
			string[] Directories = Directory.GetDirectories(Path);
			foreach(string Folder in Directories)
			{
				FindFilesInternal(Folder,Pattern,ref List);
			}
		}

		#endregion

		/// <summary>
		/// Obtains a list of files in the given path matching the given pattern, optionally searching through child folders.
		/// </summary>
		/// <param name="Path">The path to search the file(s) for.</param>
		/// <param name="Pattern">The pattern to match files for.</param>
		/// <param name="SearchChildFolders">Specifies whether to recurse through child folders.</param>
		/// <returns>An array of strings containing each file that matches the given pattern.</returns>
		public static string[] FindFiles(string Path, string Pattern, bool SearchChildFolders)
		{
			if (SearchChildFolders)
			{
				ArrayList List = new ArrayList();
				FindFilesInternal(Path,Pattern,ref List);

				string[] Result = new string[List.Count];
				List.CopyTo(Result);

				return Result;
			}
			else
			{
				return Directory.GetFiles(Path,Pattern);
			}
		}

		#endregion
	}
}
