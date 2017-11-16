using System;
using System.Collections.Generic;
using System.Text;

namespace WoWDaemon.Common
{
	public class PacketBuffer
	{
		public PacketBuffer(int size)
		{
			Reallocate(size);
		}

		public PacketBuffer()
		{

		}

		private byte[] m_buffer;
		private int bytes_read = 0;

		public ArraySegment<byte> ReadBuffer
		{
			get
			{
				if (Full)
					return new ArraySegment<byte>();
				else
					return new ArraySegment<byte>
						(m_buffer, bytes_read, m_buffer.Length - bytes_read);
			}
		}

		/// <summary>
		/// Number of bytes the packet buffer has read.
		/// </summary>
		public int BytesRead
		{
			get
			{
				return bytes_read;
			}
			set
			{
				if (value > bytes_read && value <= m_buffer.Length)
				{
					bytes_read = value;
				}
				else
				{
					Console.WriteLine("Error: Attempt to set packet buffer to invalid value {0}.", value);
					// I should be throwing an exception.
					throw new InvalidOperationException("Bad packet buffer BytesRead value " + value.ToString());
				}
			}
		}

		public bool Full
		{
			get { return m_buffer != null && m_buffer.Length == bytes_read; }
		}

		public void Reallocate(int size)
		{
			m_buffer = new byte[size];
			bytes_read = 0;
		}

		/// <summary>
		/// Extract the data from the buffer. You should ensure
		/// the PacketBuffer is Full first by checking buf.Full.
		/// 
		/// Once extracted extract() will reallocate the buffer.
		/// </summary>
		/// <returns>Filled data buffer</returns>
		public byte[] Extract()
		{
			if (!Full)
			{
//				System.Console.WriteLine("WARNING: extracting a non-full packet buffer!");
			}

			byte[] buf = m_buffer;

			Reallocate(buf.Length);

			return buf;
		}

		/// <summary>
		/// Take a look at the data in the packet buffer without extracting it.
		/// </summary>
		/// <returns></returns>
		public byte[] Peek()
		{
			return m_buffer;
		}
	}
}
