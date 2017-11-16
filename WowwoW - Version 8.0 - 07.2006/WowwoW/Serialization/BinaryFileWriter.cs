using System;
using System.IO;
using System.Text;
using System.Net;
using HelperTools;

//Serialization v1.0
//Created by TUM 13.08.05
//Great Thanks to ShaiDeath for the help and bug fixing

//Serialization v1.1
//Modified by ShaiDeath 14.08.05

namespace Server.Serialization
{
	/// <summary>
	/// Summary description for BinaryFileWriter.
	/// </summary>
	public class BinaryFileWriter : GenWriter
	{
		//private bool PrefixStrings;
		//private BinaryWriter m_Bin;
		private FileStream m_File;

		private const int BufferSize = 4096;

		private byte[] m_Buffer;
		private int m_Index;

		private Encoding m_Encoding;

		public BinaryFileWriter( FileStream strm ) 
		{ 
			m_Encoding = Utility.UTF8;
			m_Buffer = new byte[BufferSize];
			m_File = strm;
		}

		public BinaryFileWriter( string filename )
		{
			
			m_Buffer = new byte[BufferSize];
			m_File = new FileStream( filename, FileMode.Create, FileAccess.Write, FileShare.None );
			m_Encoding = Utility.UTF8WithEncoding;
			
		}

		public void Flush()
		{
			if ( m_Index > 0 )
			{
				m_File.Write( m_Buffer, 0, m_Index );
				m_Index = 0;
			}
		}

		public override long Position
		{
			get
			{
				Flush();
				return m_File.Position;
			}
		}

		public Stream UnderlyingStream
		{
			get
			{
				Flush();
				return m_File;
			}
		}

		public override void Close()
		{
			Flush();
			m_File.Close();
		}

		public override void WriteEncodedInt( int value )
		{
			uint v = (uint) value;

			while ( v >= 0x80 ) 
			{
				if ( (m_Index + 1) > BufferSize )
					Flush();

				m_Buffer[m_Index++] = (byte) (v | 0x80);
				v >>= 7;
			}

			if ( (m_Index + 1) > BufferSize )
				Flush();

			m_Buffer[m_Index++] = (byte) v;
		}

		private byte[] m_CharacterBuffer;
		private int m_MaxBufferChars;
		private const int LargeByteBufferSize = 256;  

		internal void InternalWriteString( string value )
		{
			int length = m_Encoding.GetByteCount( value );

			WriteEncodedInt( length );

			if ( m_CharacterBuffer == null )
			{
				m_CharacterBuffer = new byte[LargeByteBufferSize];
				m_MaxBufferChars = LargeByteBufferSize / m_Encoding.GetMaxByteCount( 1 );
			}

			if ( length > LargeByteBufferSize )
			{
				int current = 0;
				int charsLeft = value.Length;

				while ( charsLeft > 0 )
				{
					int charCount = ( charsLeft > m_MaxBufferChars ) ? m_MaxBufferChars : charsLeft;
					int byteLength = m_Encoding.GetBytes( value, current, charCount, m_CharacterBuffer, 0 );

					if ( (m_Index + byteLength) > BufferSize )
						Flush();

					Buffer.BlockCopy( m_CharacterBuffer, 0, m_Buffer, m_Index, byteLength );
					m_Index += byteLength;

					current += charCount;
					charsLeft -= charCount;
				}
			}
			else
			{
				int byteLength = m_Encoding.GetBytes( value, 0, value.Length, m_CharacterBuffer, 0 );

				if ( (m_Index + byteLength) > BufferSize )
					Flush();

				Buffer.BlockCopy( m_CharacterBuffer, 0, m_Buffer, m_Index, byteLength );
				m_Index += byteLength;
			}
		}

		public override void Write( string value )
		{
			if ( value == null ) 
			{
				if ( (m_Index + 1) > BufferSize )
					Flush();

				m_Buffer[m_Index++] = 0;
			}
			else 
			{
				if ( (m_Index + 1) > BufferSize )
					Flush();

				m_Buffer[m_Index++] = 1;

				InternalWriteString( value );
			}
			
		}

		public override void Write( DateTime value )
		{
			Write( value.Ticks );
		}

		public override void WriteDeltaTime( DateTime value )
		{
			long ticks = value.Ticks;
			long now = DateTime.Now.Ticks;

			TimeSpan d;

			try{ d = new TimeSpan( ticks-now ); }
			catch{ if ( ticks < now ) d = TimeSpan.MaxValue; else d = TimeSpan.MaxValue; }

			Write( d );
		}

		
		public override void Write( TimeSpan value )
		{
			Write( value.Ticks );
		}

		public override void Write( decimal value )
		{
			int[] bits = Decimal.GetBits( value );

			for ( int i = 0; i < bits.Length; ++i )
				Write( bits[i] );
		}

		public override void Write( long value )
		{
			if ( (m_Index + 8) > BufferSize )
				Flush();

			m_Buffer[m_Index    ] = (byte) value;
			m_Buffer[m_Index + 1] = (byte)(value >> 8);
			m_Buffer[m_Index + 2] = (byte)(value >> 16);
			m_Buffer[m_Index + 3] = (byte)(value >> 24);
			m_Buffer[m_Index + 4] = (byte)(value >> 32);
			m_Buffer[m_Index + 5] = (byte)(value >> 40);
			m_Buffer[m_Index + 6] = (byte)(value >> 48);
			m_Buffer[m_Index + 7] = (byte)(value >> 56);
			m_Index += 8;
		}

		public override void Write( ulong value )
		{
			if ( (m_Index + 8) > BufferSize )
				Flush();

			m_Buffer[m_Index    ] = (byte) value;
			m_Buffer[m_Index + 1] = (byte)(value >> 8);
			m_Buffer[m_Index + 2] = (byte)(value >> 16);
			m_Buffer[m_Index + 3] = (byte)(value >> 24);
			m_Buffer[m_Index + 4] = (byte)(value >> 32);
			m_Buffer[m_Index + 5] = (byte)(value >> 40);
			m_Buffer[m_Index + 6] = (byte)(value >> 48);
			m_Buffer[m_Index + 7] = (byte)(value >> 56);
			m_Index += 8;
		}

		public override void Write( int value )
		{
			if ( (m_Index + 4) > BufferSize )
				Flush();

			m_Buffer[m_Index    ] = (byte) value;
			m_Buffer[m_Index + 1] = (byte)(value >> 8);
			m_Buffer[m_Index + 2] = (byte)(value >> 16);
			m_Buffer[m_Index + 3] = (byte)(value >> 24);
			m_Index += 4;
		}

		public override void Write( uint value )
		{
			if ( (m_Index + 4) > BufferSize )
				Flush();

			m_Buffer[m_Index    ] = (byte) value;
			m_Buffer[m_Index + 1] = (byte)(value >> 8);
			m_Buffer[m_Index + 2] = (byte)(value >> 16);
			m_Buffer[m_Index + 3] = (byte)(value >> 24);
			m_Index += 4;
		}

		public override void Write( short value )
		{
			if ( (m_Index + 2) > BufferSize )
				Flush();

			m_Buffer[m_Index    ] = (byte) value;
			m_Buffer[m_Index + 1] = (byte)(value >> 8);
			m_Index += 2;
		}

		public override void Write( ushort value )
		{
			if ( (m_Index + 2) > BufferSize )
				Flush();

			m_Buffer[m_Index    ] = (byte) value;
			m_Buffer[m_Index + 1] = (byte)(value >> 8);
			m_Index += 2;
		}

		public override void Write( double value )		
		{
			if ( (m_Index + 8) > BufferSize )
				Flush();
			byte[] Bytes = System.BitConverter.GetBytes(value);
			for (int i=0; i<8; i++) 			
			{
				m_Buffer[m_Index + i] = Bytes[i];
			}
			m_Index += 8;		
		}

		public override void Write( float value )
		
		{
			if ( (m_Index + 4) > BufferSize )
				Flush();
			byte[] Bytes = System.BitConverter.GetBytes(value);
			for (int i=0; i<4; i++)			
			{
				m_Buffer[m_Index + i] = Bytes[i];
			}
			m_Index += 4;		
		}

		private char[] m_SingleCharBuffer = new char[1];

		public override void Write( char value )
		{
			if ( (m_Index + 8) > BufferSize )
				Flush();

			m_SingleCharBuffer[0] = value;

			int byteCount = m_Encoding.GetBytes( m_SingleCharBuffer, 0, 1, m_Buffer, m_Index );
			m_Index += byteCount;
		}

		public override void Write( byte value )
		{
			if ( (m_Index + 1) > BufferSize )
				Flush();

			m_Buffer[m_Index++] = value;
		}

		public override void Write( sbyte value )
		{
			if ( (m_Index + 1) > BufferSize )
				Flush();

			m_Buffer[m_Index++] = (byte) value;
		}

		public override void Write( bool value )
		{
			if ( (m_Index + 1) > BufferSize )
				Flush();

			m_Buffer[m_Index++] = (byte) (value ? 1 : 0);
		}
		public override void Write( IPAddress value )
		{			
			Write(value.ToString());		
		}
		public override void Write( Character value )
		{			
			Write(value.Guid);		
		}
		public override void Write( BaseCreature value)
		{
			Write(value.Guid);
		}
		public override void Write(Account value)
		{
			Write(value.Username);
		}
		public override void Write(GameObject value)
		{
			Write(value.Guid);
		}
	}
}

