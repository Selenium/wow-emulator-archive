using System;
using System.Net.Sockets;
using WoWDaemon.Common;
using WoWDaemon.Database.DataTables;

namespace WoWDaemon.Realm
{
	public enum REALMLISTOPCODE : byte
	{
		CHALLENGE = 0,
		PROOF = 1,
		RECODE_CHALLENGE = 2,
		RECODE_PROOF = 3,
		REALMLIST_REQUEST = 16,
	}

	public class RealmListClient : ClientBase
	{
		public BigInteger B;
		public byte []salt = new byte[ 32 ]; 
		public BigInteger v; 
		public byte []b = new byte[ 20 ];
		public byte []rb;
		public BigInteger K; 
		public BigInteger G;
		public DBAccount account = null;
		public byte []Busername;
		public string username = null;
		public string password = null;

		public DateTime LastActivity;
		public RealmListClient(Socket sock) : base(sock)
		{
			LastActivity = DateTime.Now;
		}

		public override void Close(string reason)
		{
			base.Close (reason);
		}

		public override void OnException(Exception e)
		{
			if(e is SocketException)
				Close(e.Message + " (" + ((SocketException)e).ErrorCode.ToString() + ")");
			else if(e is RealmWarning)
				Close(e.Message);
			else
				Close(e.Message + Environment.NewLine + e.StackTrace);
		}

		public override int PacketHeaderSize
		{
			get
			{
				return 4;
			}
		}

		public override int PacketDataSize
		{
			get
			{
				byte[] header = m_packet_header.Peek();
				switch((REALMLISTOPCODE)header[0])
				{
					case REALMLISTOPCODE.CHALLENGE:
					case REALMLISTOPCODE.RECODE_CHALLENGE:
						return BitConverter.ToUInt16(header, 2);
					case REALMLISTOPCODE.PROOF:
						return 0x46;//0x4a;
					case REALMLISTOPCODE.RECODE_PROOF:
						return 0x46;//0x4a;
					case REALMLISTOPCODE.REALMLIST_REQUEST:
						return 0x01;//0x05
					default:
						throw(new RealmWarning("Unhandled realm opcode " + header[0]));
				}								
			}
		}
		
		public override bool Timedout
		{
			get
			{
				TimeSpan span = DateTime.Now.Subtract(LastActivity);
				return span.TotalSeconds > 30;
			}
		}

	}
/*
	/// <summary>
	/// This is the class that speaks to Clients
	/// </summary>
	internal class RealmListClient : RealmClientBase
	{
		public RealmListClient(Socket sock) : base(sock, 1)
		{
			Console.WriteLine("New RealmListClient created({0})", sock.RemoteEndPoint);
		}

		public override int DataSize
		{
			get
			{
				switch((REALMLISTOPCODE)m_headerBuffer[0])
				{
					case REALMLISTOPCODE.CHALLENGE:
					case REALMLISTOPCODE.RECODE_CHALLENGE:
						return 0x21;
					case REALMLISTOPCODE.PROOF:
						return 0x67;
					case REALMLISTOPCODE.RECODE_PROOF:
						return 0x57;
					case REALMLISTOPCODE.REALMLIST_REQUEST:
						return 0x04;
					default:
						throw(new RealmWarning("Unhandled realm opcode " + m_headerBuffer[0]));
				}
			}
		}

		static byte[] default_buffer = new byte[0x68];
		public override byte[] DataBuffer
		{
			get
			{
				return default_buffer;
			}
		}

		#region STATIC PACKET DATA
		static byte[] patch_challenge =
			{
				0x00,
				0x00,
				0x00,
				0xD7, 0xB9, 0x1A, 0x0B, 0x09, 0x39, 0x28, 0x45,
				0x48, 0xAE, 0x31, 0x9A, 0x3B, 0x85, 0x7A, 0xF4,
				0xFF, 0x79, 0x21, 0x58, 0xE6, 0x16, 0x5B, 0x35,
				0x21, 0x4C, 0xCE, 0x4B, 0x86, 0xF8, 0x41, 0x60,

				0x01,
				0x07,

				0x20,
				0x89,0x4B,0x64,0x5E,0x89,0xE1,0x53,0x5B,
				0xBD,0xAD,0x5B,0x8B,0x29,0x06,0x50,0x53,
				0x08,0x01,0xB1,0x8E,0xBF,0xBF,0x5E,0x8F,
				0xAB,0x3C,0x82,0x87,0x2A,0x3E,0x9B,0xB7,

				0xF4,0x3C,0xAA,0x7B,0x24,0x39,0x81,0x44,
				0xBF,0xA5,0xB5,0x0C,0x0E,0x07,0x8C,0x41,
				0x03,0x04,0x5B,0x6E,0x57,0x5F,0x37,0x87,
				0x31,0x9F,0xC4,0xF8,0x0D,0x35,0x94,0x29,

				0x2A,0xD5,0x48,0xCC,0x9B,0x9D,0xA1,0x99,
				0xCC,0x04,0x7A,0x60,0x91,0x15,0x6C,0x51
			};
		static byte[] realm_proof = {0x03,0x00};

		static byte[] realm_challenge = {0x02, 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 
											0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x10,
											0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 
											0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x10};
		static byte[] realmlist_empty = {0x10, 0x05, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
		#endregion

		public override void OnRecv(byte[] data, int size)
		{
			switch((REALMLISTOPCODE)m_headerBuffer[0])
			{
				case REALMLISTOPCODE.CHALLENGE:
				case REALMLISTOPCODE.RECODE_CHALLENGE:
				{
					if(data[0x20] == 0)
						throw new RealmWarning("Username length == 0");

					byte[] username = new byte[data[0x20]];
					if(m_socket.Available < username.Length)
						throw new RealmWarning(string.Format("m_socket.Available({0}) < username.Length({1})", m_socket.Available, username.Length));

					m_socket.Receive(username, 0, username.Length, SocketFlags.None);
					if(m_headerBuffer[0] == (byte)REALMLISTOPCODE.CHALLENGE)
						Send(RealmListClient.patch_challenge);
					else
						Send(RealmListClient.realm_challenge);
					break;
				}
				case REALMLISTOPCODE.PROOF:
				case REALMLISTOPCODE.RECODE_PROOF:
				{
					Send(RealmListClient.realm_proof);
					break;
				}
				case REALMLISTOPCODE.REALMLIST_REQUEST:
				{
					Send(RealmListServer.RealmList);
					Close();
					break;
				}
			}
		}
	}
*/
}
