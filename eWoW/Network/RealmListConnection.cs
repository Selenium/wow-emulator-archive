//#define CHECK

using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Security.Cryptography;


namespace eWoW
{
	/// <summary>
	/// RealmList
	/// </summary>
	public class RealmListConnection : SocketClient 
	{ 
		public delegate void LogMessageHandler				(string message);
		public event LogMessageHandler						LogMessageEvent;

		RealmList rl;

        enum RealmType : byte
        {
            LOGON_CHALLENGE =       0x00,
            LOGON_PROOF =           0x01,
            RECONNECT_CHALLENGE =   0x02,
            RECONNECT_PROOF =       0x03,
            UPDATESRV =             0x04,
            REALMLIST =             0x10,
            XFER_INITIATE =         0x30,
            XFER_DATA =             0x31, // client? from server
            XFER_ACCEPT =           0x32, // not official name, from client
            XFER_RESUME =           0x33, // not official name, from client
            XFER_CANCEL =           0x34, // not official name, from client
        }

		public RealmListConnection(Socket sock, RealmList r) : base(sock) 
		{
			rl=r;
		} 

		BigInteger B; 
		static byte []N = { 0x89, 0x4B, 0x64, 0x5E, 0x89, 0xE1, 0x53, 0x5B, 
							  0xBD, 0xAD, 0x5B, 0x8B, 0x29, 0x06, 0x50, 0x53, 
							  0x08, 0x01, 0xB1, 0x8E, 0xBF, 0xBF, 0x5E, 0x8F, 
							  0xAB, 0x3C, 0x82, 0x87, 0x2A, 0x3E, 0x9B, 0xB7 }; 
		static byte []rN = Reverse( N ); 

		byte []salt = new byte[ 32 ]; 
		BigInteger v; 
		byte []b = new byte[ 20 ];
		byte []rb; 
		byte []userName; 
		string sUserName;
		BigInteger K; 
		BigInteger G; 

		ByteArrayBuilder input=new ByteArrayBuilder();
		
		public override byte[] OnRecv(byte[] section, int length)
		{
			int t;
			byte[] data;

			for(int i=0; i<length; i++)input.Add(section[i]);
			RealmType code=(RealmType)input[ 0 ];
			switch( code ) 
			{ 
				case RealmType.LOGON_CHALLENGE://   Logon challenge
				case RealmType.RECONNECT_CHALLENGE:
				{
					if(input.Length < 34 || input.Length < 34 + input[33])
                        return null;

					int clientVersion = input.Seek(11).GetWord();
                    
                    //byte[] blu = input.GetArray(5, input[33]);
                    //Console.WriteLine("DEBUG:" + clientVersion);
					
                    userName = input.GetArray(34, input[33]);

					data = input; input.Length = 0;

					sUserName = System.Text.Encoding.ASCII.GetString(userName);
                    //string ble = System.Text.Encoding.ASCII.GetString(blu);
                    
					byte []hash = rl.GetUserPasswordHash( sUserName );
                    //Console.WriteLine("DEBUG - ble:" + ble + "user: ");
                    if(hash == null)
					{
						if (LogMessageEvent != null)
							LogMessageEvent ( sUserName + " code: " + code);

						ByteArrayBuilder p = new ByteArrayBuilder();
						p.Add((byte)1, 3);
						p.Add(new byte[116]);
						return p;
					}

					if (LogMessageEvent != null)
						LogMessageEvent ( sUserName + " code: " + code);

					byte []res = new Byte[ hash.Length + salt.Length ]; 
					Const.rand.NextBytes( salt );
#if CHECK
					salt=new byte[]{0x33, 0xf1, 0x40, 0xd4, 0x6c, 0xb6, 0x6e, 0x63, 0x1f, 0xdb, 0xbb, 0xc9, 0xf0, 0x29, 0xad, 0x88, 0x98, 0xe0, 0x5e, 0xe5, 0x33, 0x87, 0x61, 0x18, 0x18, 0x5e, 0x56, 0xdd, 0xe8, 0x43, 0x67, 0x4f};
#endif

					t = 0; 
					foreach( byte s in salt ) res[ t++ ] = s; 
					foreach( byte s in hash ) res[ t++ ] = s; 

					SHA1 sha = new SHA1CryptoServiceProvider(); 
					byte []hash2 = sha.ComputeHash( res, 0, res.Length ); 
					byte []x = Reverse( hash2 ); 

					rN = Reverse( N ); 
					Const.rand.NextBytes( b ); 
#if CHECK
					b=new byte[]{0x86, 0x92, 0xE3, 0xA6, 0xBA, 0x48, 0xB5, 0xB1, 0x00, 0x4C, 0xEF, 0x76, 0x82, 0x51, 0x27, 0xB7, 0xEB, 0x7D, 0x1A, 0xEF};
#endif
					rb = Reverse( b ); 
			
			
					BigInteger bi = new BigInteger( x ); 
					BigInteger bi2 = new BigInteger( rN ); 
					G = new BigInteger( new byte[] { 7 } ); 
					v = G.modPow( bi, bi2 ); 
			
					K = new BigInteger( new Byte[] { 3 } ); 
					BigInteger temp1 = K * v; 
					BigInteger temp2 = G.modPow( new BigInteger( rb ), new BigInteger( rN ) ); 
					BigInteger temp3 = temp1 + temp2; 
					B = temp3 % new BigInteger( rN );

					ByteArrayBuilder pack=new ByteArrayBuilder();
					pack.Add( (byte)0, 0, 0);
					pack.Add( Reverse( B.getBytes(32) ) );
					pack.Add( (byte)1, 7, 32 );
					pack.Add( N );
					pack.Add( salt );
					pack.Add( new byte[16] );
					return pack;
				}

				case RealmType.LOGON_PROOF://   Logon proof    
				case RealmType.RECONNECT_PROOF:
				{                
					if(input.Length < 53)
                        return null;

					byte[] A = input.GetArray(1, 32);
					byte[] kM1 = input.GetArray(33, 20);

					data = input; 
                    input.Length = 0;


#if CHECK
					A=new byte[]{0x23, 0x2f, 0xb1, 0xb8, 0x85, 0x29, 0x64, 0x3d, 0x95, 0xb8, 0xdc, 0xe7, 0x8f, 0x27, 0x50, 0xc7, 0x5b, 0x2d, 0xf3, 0x7a, 0xcb, 0xa8, 0x73, 0xeb, 0x31, 0x07, 0x38, 0x39, 0xed, 0xa0, 0x73, 0x8d};
#endif
			
					byte []rA = Reverse( A ); 
			
					byte []AB = Concat( A, Reverse( B.getBytes(32) ) ); 

					SHA1 shaM1 = new SHA1CryptoServiceProvider(); 
					byte []U = shaM1.ComputeHash( AB );       
			
					byte []rU = Reverse( U );                
			
					// SS_Hash
					BigInteger temp1 = v.modPow( new BigInteger( rU ), new BigInteger( rN ) ); 
					BigInteger temp2 = temp1 * new BigInteger( rA ); 
					BigInteger temp3 = temp2.modPow( new BigInteger( rb ), new BigInteger( rN ) ); 

					byte []S1 = new byte[ 16 ]; 
					byte []S2 = new byte[ 16 ]; 
					byte []S = temp3.getBytes(32); 
					byte []rS = Reverse( S ); 
			
					for( t = 0;t < 16;t++) 
					{ 
						S1[ t ] = rS[ t * 2 ]; 
						S2[ t ] = rS[ ( t * 2 ) + 1 ]; 
					} 
					byte []hashS1 = shaM1.ComputeHash( S1 ); 
					byte []hashS2 = shaM1.ComputeHash( S2 ); 
					byte []SS_Hash = new byte[ hashS1.Length + hashS2.Length ]; 
					for( t = 0;t < hashS1.Length ;t++ ) 
					{ 
						SS_Hash[ t * 2 ] = hashS1[ t ]; 
						SS_Hash[ ( t * 2 ) + 1 ] = hashS2[ t ]; 
					} 

					// cal M1
					byte []NHash = shaM1.ComputeHash( N ); 
					byte []GHash = shaM1.ComputeHash( G.getBytes() ); 
					byte []userHash = shaM1.ComputeHash( userName ); 
					byte []NG_Hash = new byte[ 20 ]; 
					for( t = 0;t < 20;t++ ) 
					{ 
						NG_Hash[ t ] = (byte)( NHash[ t ] ^ GHash[ t ] ); 
					} 
					byte []Temp = Concat( NG_Hash, userHash ); 
					Temp = Concat( Temp, salt ); 
					Temp = Concat( Temp, A ); 
					Temp = Concat( Temp, Reverse(B.getBytes(32)) ); 
					Temp = Concat( Temp, SS_Hash );

					byte []M1 = shaM1.ComputeHash( Temp ); 

					ByteArrayBuilder pack;
					if(!ByteArray.Same(M1, kM1))
					{
						if (LogMessageEvent != null)
							LogMessageEvent ( sUserName + " code: " + code);

						pack=new ByteArrayBuilder();
						pack.Add((byte)1, 3);
						pack.Add(new byte[24]);
						return pack;
					}

					if (LogMessageEvent != null)
						LogMessageEvent ( sUserName + " code: " + code);

					rl.SetUserSessionKey(sUserName, SS_Hash);

					// cal M2
					Temp = Concat( A, M1 ); 
					Temp = Concat( Temp, SS_Hash ); 
					byte []M2 = shaM1.ComputeHash( Temp ); 

					pack=new ByteArrayBuilder();
					pack.Add((byte)1, 0);
					pack.Add(M2);
					pack.Add(new byte[4]);
			
					return pack; 
				} 

				case RealmType.UPDATESRV: // Update server 
					if(input.Length<1)return null;
					data=input; input.Length=0;
					if (LogMessageEvent != null)
						LogMessageEvent ("UPDATESRV");
					break; 

				case RealmType.REALMLIST: // Realm List                
				{
					if(input.Length < 1)
                        return null;
					byte[] request = input.GetArray(1,4);
					input.Length = 0;
					if (LogMessageEvent != null)
						LogMessageEvent ("REALMLIST");
					ByteArrayBuilder pack = new ByteArrayBuilder(false);
					pack.Add((byte)RealmType.REALMLIST, 0, 0);
					pack.Add(request);
					
					rl.GetRealmList(sUserName, pack);

					pack.Add((byte)0, (byte)0);
					pack.Set(1, (ushort)(pack.Length-3));

					return pack;
				}

				default: 
					data=input; input.Length=0;
					if (LogMessageEvent != null)
						LogMessageEvent ( "Receive unknown command {0}" + data[ 0 ] );
					break; 

			} 
			byte []ret = { 0, 0 }; 
			return ret; 
		} 

		public static byte[] Reverse( byte[]from ) 
		{ 
			byte []res = new byte[ from.Length ]; 
			int i = 0; 
			for(int t = from.Length - 1;t>=0;t--) 
				res[ i++ ] = from[ t ]; 
			return res; 
		} 

		public static byte[] Concat( byte []a, byte []b ) 
		{ 
			byte []res = new byte[ a.Length + b.Length ]; 
			for(int t = 0;t < a.Length;t++ ) 
				res[ t ] = a[ t ]; 
			for(int t = 0;t < b.Length;t++ ) 
				res[ t + a.Length ] = b[ t ]; 
			return res; 
		} 
	}

}
