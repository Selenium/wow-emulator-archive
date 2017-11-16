using System;
using System.IO;
using System.Net;

//Serialization v1.0
//Created by TUM 13.08.05
//Great Thanks to ShaiDeath for the help and bug fixing

//Serialization v1.1
//Modified by ShaiDeath 14.08.05

namespace Server.Serialization
{
	/// <summary>
	/// Summary description for BinaryFileReader.
	/// </summary>
	public class BinaryFileReader : GenReader
	{
		private BinaryReader m_File;

		public BinaryFileReader( BinaryReader br ) { m_File = br; }

		public void Close()
		{
			m_File.Close();
		}

		public long Position
		{
			get
			{
				return m_File.BaseStream.Position;
			}
		}

		public long Seek( long offset, SeekOrigin origin )
		{
			return m_File.BaseStream.Seek( offset, origin );
		}

		public override string ReadString()
		{
			if ( ReadByte() != 0 )
				return m_File.ReadString();
			else
				return null;
		}

		public override DateTime ReadDeltaTime()
		{
			long ticks = m_File.ReadInt64();
			long now = DateTime.Now.Ticks;

			if ( ticks > 0 && (ticks+now) < 0 )
				return DateTime.MaxValue;
			else if ( ticks < 0 && (ticks+now) < 0 )
				return DateTime.MinValue;

			try{ return new DateTime( now+ticks ); }
			catch{ if ( ticks > 0 ) return DateTime.MaxValue; else return DateTime.MinValue; }
		}

		
		public override int ReadEncodedInt()
		{
			int v = 0, shift = 0;
			byte b;

			do
			{
				b = m_File.ReadByte();
				v |= (b & 0x7F) << shift;
				shift += 7;
			} while ( b >= 0x80 );

			return v;
		}

		public override DateTime ReadDateTime()
		{
			return new DateTime( m_File.ReadInt64() );
		}

		public override TimeSpan ReadTimeSpan()
		{
			return new TimeSpan( m_File.ReadInt64() );
		}

		public override decimal ReadDecimal()
		{
			return m_File.ReadDecimal();
		}

		public override long ReadLong()
		{
			return m_File.ReadInt64();
		}

		public override ulong ReadULong()
		{
			return m_File.ReadUInt64();
		}

		public override int ReadInt()
		{
			return m_File.ReadInt32();
		}

		public override uint ReadUInt()
		{
			return m_File.ReadUInt32();
		}

		public override short ReadShort()
		{
			return m_File.ReadInt16();
		}

		public override ushort ReadUShort()
		{
			return m_File.ReadUInt16();
		}

		public override double ReadDouble()
		{
			return m_File.ReadDouble();
		}

		public override float ReadFloat()
		{
			return m_File.ReadSingle();
		}

		public override char ReadChar()
		{
			return m_File.ReadChar();
		}

		public override byte ReadByte()
		{
			return m_File.ReadByte();
		}

		public override sbyte ReadSByte()
		{
			return m_File.ReadSByte();
		}

		public override bool ReadBool()
		{
			return m_File.ReadBoolean();
		}
		public override bool End()
		{
			return m_File.PeekChar() == -1;
		}
		public override IPAddress ReadIPAddress()
		{			
			return IPAddress.Parse(ReadString());
		}

		public override Character ReadCharacter()
		{
			ulong guid = this.ReadULong();
			foreach(Account acct in World.allAccounts) 
			{ 
				foreach (Mobile m in acct.characteres) 
				{ 
					if (m.Guid == guid)
					{
						return m as Character;						
					}
				} 
			}
			return null;
		}
		public override BaseCreature ReadBaseCreature()
		{
			ulong guid = this.ReadULong();
			foreach(Mobile m in World.allMobiles)
			{
				if (m.Guid == guid)
				{
					return m as BaseCreature;						
				}				
			}
			return null;
		}

		public override Account ReadAccount()
		{
			string username = this.ReadString();
			foreach(Account acct in World.allAccounts) 
			{
				if (acct.Username == username)
				{
					return acct;
				}
			}
			return null;
		}
		public override GameObject ReadGameObject()
		{
			ulong guid = this.ReadULong();
			foreach(GameObject obj in World.allGameObjects) 
			{
				if (obj.Guid == guid)
				{
					return obj;
				}
			}
			return null;
		}
	}
}
