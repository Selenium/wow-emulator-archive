using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Security.Cryptography;
using System.Net.Sockets;
using System.Net;
using HelperTools;

namespace Server
{
	public class ClientConnection : SockClient
	{
		public ClientConnection( Socket sock, RemoveClientDelegate rcd ) : base( sock, rcd )
		{
		}
		public static int s1 = 1;

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
		BigInteger K;
		static Random rand = new Random();
		//static 
		Account myAccount;

		public static Hashtable tryLoggin = new Hashtable();

		public override byte [] ProcessDataReceived( byte []data, int length )
		{
		//	Console.WriteLine("Rec {0}", data[ 0 ] );
		//	HexViewer.View( data, 0, length );
			int t;
			switch( data[ 0 ] )
			{
				case 0x00://	Logon challenge	
					/*foreach( Account acc in World.allAccounts )
						if ( acc.Ip != null && 
							ch.IP.Address == acc.Ip.Address && 
							//ch.Port == acc.Port &&
							(bool)tryLoggin[ ch.IP.Address.ToString() ] )
						{
							Console.WriteLine("wait!!!");
							return new byte[] { 0, 3, 0xEE, 0x1, 0x19 };
						}*/
				//	Console.WriteLine( "Logon challenge" );
					int clientVersion = ( ( (int)data[ 11 ] ) * 256  )+ data[ 12 ];
					byte len = data[ 33 ];
					userName = new byte[ len ];
					//Console.Write( "User : " );

					string usern = "";
					for( t = 0;t < len;t++ )
					{
						userName[ t ] = data[ 34 + t ];
						usern+= "" + (char)data[ 34 + t ];
					//	Console.Write( "{0}", "" + ((char)userName[ t ] ).ToString() );
					}
				//	Console.WriteLine( "" );
					
					myAccount = World.allAccounts.FindByUserName( usern );
					if ( World.FreeForAll )
					{
						if ( myAccount == null )
						{
							World.allAccounts.Add( myAccount = new Account( usern, usern ) );
						}
					}
					if ( myAccount == null )
						return new byte[] { 0x1, 0x4 };
					
					if ( myAccount.SelectedChar != null )
					{
					//	Console.WriteLine("Already loggin");
						return new byte[] { 1, 0x6 };
						 // Already logged in
					}
					
					SHA1 sha = new SHA1CryptoServiceProvider();

					string pass = ":" + myAccount.Password.ToUpper();
					char []passc = pass.ToCharArray();
					byte []passb = new byte[ passc.Length ];
					int ti = 0;
					foreach( char c in passc )
						passb[ ti++ ] = (byte)c;
					byte []user = Concat( userName, passb );
					byte []hash = sha.ComputeHash( user, 0 , user.Length );
					byte []res = new Byte[ hash.Length + salt.Length ];
					t = 0;
					rand.NextBytes( salt );
					foreach( byte s in salt )
						res[ t++ ] = s;
					foreach( byte s in hash )
						res[ t++ ] = s;
					byte []hash2 = sha.ComputeHash( res, 0, res.Length );
					byte []x = Reverse( hash2 );

					rN = Reverse( N );
					rand.NextBytes( b );
					rb = Reverse( b );
					
				
					BigInteger bi = new BigInteger( x );
					BigInteger bi2 = new BigInteger( rN );
					BigInteger g = new BigInteger( new byte[] { 7 } );
					v = g.modPow( bi, bi2 );
					
					K = new BigInteger( new Byte[] { 3 } );
					BigInteger temp1 = K * v;
					BigInteger temp2 = g.modPow( new BigInteger( rb ), new BigInteger( rN ) );
					BigInteger temp3 = temp1 + temp2;
					B = temp3 % new BigInteger( rN );

				/*	byte []ezfd= B.getBytes();
					Console.WriteLine("B");
					HexViewer.View( ezfd, 0, ezfd.Length );
					BigInteger C = new BigInteger();
					
					Console.WriteLine("C/Rn {0}", temp3/new BigInteger( rN ) );*/
					//Console.WriteLine("temp1 {0}",temp1.ToHexString());
					//Console.WriteLine("temp2 {0}",temp2.ToHexString());
					//Console.WriteLine("temp3 {0}",temp3.ToHexString());
			/*		for(int ll = 0;ll < 6;ll++)
					{
						C = B;
						C += new BigInteger( rN ) * ll;
						C -= temp1;
						Console.WriteLine("temp3 {0}",C.ToHexString());
					}*/

					byte []pack = new byte[ 118 ];
					pack[ 0 ] = pack[ 1 ] = 0;
					byte []tB = Reverse( B.getBytes() );
					for( t = 0;t < tB.Length ;t++ )
						pack[ 3 + t ] = tB[ t ];
					pack[ 35 ] = 1;// g_length
					pack[ 36 ] = 7;// g
					pack[ 37 ] = 32;// n_len
					for( t = 0;t < N.Length;t++ )
						pack[ 38 + t ] = N[ t ];
					for( t = 0;t < salt.Length ;t++ )
						pack[ 70 + t ] = salt[ t ];
					for( t = 0;t < 16;t++ )
						pack[ 102 + t ] = 0;

					return pack;

				case 0x01://	Logon proof	
				{					
					//Console.WriteLine("Logon proof" );
					byte []A = new byte[ 32 ];
					for( t = 0;t < 32;t++ )
					{
						A[ t ] = data[ t + 1 ];
					}
					byte []kM1 = new byte[ 20 ];
					for( t = 0;t < 20;t++ )
					{
						kM1[ t ] = data[ t + 1 + 32 ];
					}

					//A = new byte[] { 0x23, 0x2f, 0xb1, 0xb8, 0x85, 0x29, 0x64, 0x3d, 0x95, 0xb8, 0xdc, 0xe7, 0x8f, 0x27, 0x50, 0xc7, 0x5b, 0x2d, 0xf3, 0x7a, 0xcb, 0xa8, 0x73, 0xeb, 0x31, 0x07, 0x38, 0x39, 0xed, 0xa0, 0x73, 0x8d };
					byte []rA = Reverse( A );
					//	B = new BigInteger( new byte[] { 0x64, 0x5d, 0x1f, 0x78, 0x97, 0x30, 0x73, 0x70, 0x1e, 0x12, 0xbc, 0x98, 0xaa, 0x38, 0xea, 0x99, 0xb4, 0xbc, 0x43, 0x5c, 0x32, 0xe8, 0x44, 0x7c, 0x73, 0xab, 0x07, 0x7a, 0xe4, 0xd7, 0x59, 0x64 } );
					byte []AB = Concat( A, Reverse( B.getBytes() ) );

					SHA1 shaM1 = new SHA1CryptoServiceProvider();
					byte []U = shaM1.ComputeHash( AB );		
					//	U = new byte[] { 0x2f, 0x49, 0x69, 0xac, 0x9f, 0x38, 0x7f, 0xd6, 0x72, 0x23, 0x6f, 0x94, 0x91, 0xa5, 0x16, 0x77, 0x7c, 0xdd, 0xe1, 0xc1 };
					byte []rU = Reverse( U );					
					
					temp1 = v.modPow( new BigInteger( rU ), new BigInteger( rN ) );
					temp2 = temp1 * new BigInteger( rA );
					temp3 = temp2.modPow( new BigInteger( rb ), new BigInteger( rN ) );

					byte []S1 = new byte[ 16 ];
					byte []S2 = new byte[ 16 ];
					byte []S = new byte[ 32 ];
					byte []temp = temp3.getBytes();
				/*	Console.WriteLine("temp");
					HexViewer.View( temp, 0, temp.Length );
					Console.WriteLine("temp1 {0}", temp1.ToHexString());
					Console.WriteLine("temp2 {0}", temp2.ToHexString());
					Console.WriteLine("temp3 {0}", temp3.ToHexString());*/
					Buffer.BlockCopy( temp, 0, S, 0, temp.Length );
					byte []rS = Reverse( S );
				
					
					for( t = 0;t < 16;t++)
					{
						S1[ t ] = rS[ t * 2 ];
						S2[ t ] = rS[ ( t * 2 ) + 1 ];
					}
					byte []hashS1 = shaM1.ComputeHash( S1 );
					byte []hashS2 = shaM1.ComputeHash( S2 );
					myAccount.SS_Hash = new byte[ hashS1.Length + hashS2.Length ];
					for( t = 0;t < hashS1.Length ;t++ )
					{
						myAccount.SS_Hash[ t * 2 ] = hashS1[ t ];
						myAccount.SS_Hash[ ( t * 2 ) + 1 ] = hashS2[ t ];
					}

					//	SS_Hash = new byte[] { 0x02, 0x61, 0xf4, 0xeb, 0x48, 0x91, 0xb6, 0x6a, 0x1a, 0x82, 0x6e, 0xb7, 0x79, 0x28, 0xd8, 0x64, 0xb7, 0xea, 0x14, 0x54, 0x38, 0xdb, 0x7c, 0xfd, 0x0d, 0x3d, 0x2f, 0xc0, 0x22, 0xce, 0xcc, 0x46, 0x83, 0x79, 0xf2, 0xc0, 0x87, 0x78, 0x7f, 0x14 };

					byte []NHash = shaM1.ComputeHash( N );
					byte []GHash = shaM1.ComputeHash( new byte[]{ 7 } );
					byte []userHash = shaM1.ComputeHash( userName );
					byte []NG_Hash = new byte[ 20 ];
					for( t = 0;t < 20;t++ )
					{
						NG_Hash[ t ] = (byte)( NHash[ t ] ^ GHash[ t ] );
					}
					byte []Temp = Concat( NG_Hash, userHash );
					Temp = Concat( Temp, salt );
					Temp = Concat( Temp, A );
					Temp = Concat( Temp, B.getBytes() );
					Temp = Concat( Temp, K.getBytes() );//SS_Hash );

					byte []M1 = shaM1.ComputeHash( Temp );

					Temp = Concat( A, kM1 );
					Temp = Concat( Temp, myAccount.SS_Hash );

					byte []M2 = shaM1.ComputeHash( Temp );

					byte []retur = new byte[ M2.Length + 4/*NG_Hash.Length */+ 2 ];
					//	byte []retur = new byte[ M2.Length + NG_Hash.Length + 2 ];
					retur[ 0 ] = 0x1;
					retur[ 1 ] = 0x0;
					for(t = 0;t < M2.Length;t++ )
						retur[ t + 2 ] = M2[ t ];

					//for(t = 0;t < NG_Hash.Length;t++ )
					//	retur[ t + 2 + 20 ] = NG_Hash[ t ];

					//	set the account properties
					Console.WriteLine("Logon proof for {0},{1}", IP.ToString(), myAccount.Username );
					myAccount.Ip = this.IP;
					myAccount.Port = 0;
					myAccount.K = myAccount.SS_Hash;					

					return retur;
				}
				case 0x02://	Reconnect challenge
				{
				//	Console.WriteLine( "Reconnect challenge" );
					byte []packRecoChallenge = new byte[ 34 ];
					packRecoChallenge[ 0 ] = 0x02;
					packRecoChallenge[ 1 ] = 0x00;
					for( t = 0;t < 16 ;t++ )
						packRecoChallenge[ 18 + t ] = 0;
					return packRecoChallenge;
				}
				case 0x03://	Reconnect proof
				//	Console.WriteLine( "Reconnect proof" );
					return new byte[] { 0x03, 0x00 };
				case 0x04://	Update server
				//	Console.WriteLine( "Update server" );
					break;
				case 0x10://	Realm List					
				//	Console.WriteLine( "Realm lList request" );
					string ip = World.ServerIP;
				/*	if ( base.theClientHandler.IP.ToString().StartsWith( "192.168.0" ) )
					{
						ip = "192.168.0.2";
					}
					else*/
					if ( IP.ToString() == "127.0.0.1" )
					{
						ip = "127.0.0.1";
					}
					byte []retData = new byte[ 25 + ip.Length + World.ServerName.Length + World.ServerPort.ToString().Length ];
				/*
				byte []retData = new byte[ ]{   0x10, 45, 
										  0x00, 0x00, 0x00, 0x00, 
										  0x00, 
										  0x01, 0x00, 0x00, 0x00, 
										  0x00, 0x00, 
										  (byte)'D', (byte)'r', (byte)' ', (byte)'N', (byte)'e',
										  (byte)'x', (byte)'u', (byte)'s', 
										  0x00, (byte)'1', (byte)'9', (byte)'2', (byte)'.', 
										  (byte)'1', (byte)'6', (byte)'8', (byte)'.', 
										  (byte)'0', (byte)'.', 
										  (byte)'2', 
										  0x3a, 0x38, 0x30, 0x38, 0x35, 
										  0x00, 0x00, 0x00, 0x00, 
										  0x00, 0x00, 
										  0x01, 0x00, 
										  0x02, 0x00 };*/
					int offset = 0;
					Converter.ToBytes( (byte)0x10, retData, ref offset );
					Converter.ToBytes( (byte)43, retData, ref offset );
					Converter.ToBytes( 1/*World.allConnectedChars.Count*/, retData, ref offset );
					Converter.ToBytes( (byte)0, retData, ref offset );
					Converter.ToBytes( 1, retData, ref offset );
					Converter.ToBytes( (short)0, retData, ref offset );
					Converter.ToBytes( World.ServerName, retData, ref offset );
					Converter.ToBytes( (byte)0, retData, ref offset );
					Converter.ToBytes( ip, retData, ref offset );
					Converter.ToBytes( (byte)':', retData, ref offset );
					Converter.ToBytes( World.ServerPort.ToString(), retData, ref offset );
					Converter.ToBytes( (byte)0, retData, ref offset );
					Converter.ToBytes( 0, retData, ref offset );
				//	Converter.ToBytes( (short)0, retData, ref offset );//	cr erreir
					//Converter.ToBytes( (short)1, retData, ref offset );
					//Converter.ToBytes( (short)2, retData, ref offset );
					
					Converter.ToBytes( (short)World.allConnectedChars.Count, retData, ref offset );
					Converter.ToBytes( (byte)0, retData, ref offset );
					Converter.ToBytes( (short)1, retData, ref offset );
					int atlen = 1;
					offset -= 3;
					Converter.ToBytes( offset, retData, ref atlen );
					Console.WriteLine("Connected player(s) {0}", World.allConnectedChars.Count );
				/*	if ( World.allConnectedChars.Count < 3 )*/
						//Thread.Sleep( 500 );
					return retData;

				default:
					Console.WriteLine( "Receive unknown command {0}", data[ 0 ] );
					break;

			}
			byte []ret = { 0, 0, 0, 0 };
			return ret;
		}

	}
}
/*
 * 
 * 0x01 = Failure
0x02 = Cancelled
0x03 = Disconnect
0x04 = Failed to connect
0x05 = (connect)
0x06 = Wrong client version
0x07 = Connecting to server...
0x08 = Negotiating security
0x09 = Security negotiation complete
0x0a = Security negotiation failed
0x0b = Authenticating
0x0c = Authentication successful (login complete...)
0x0d = Authentication failed
0x0e = Login Unavailable - Please contact Customer Support
0x0f = Server is not valid
0x10 = System unavailable - Please try again later
0x11 = System error
0x12 = Billing system error
0x13 = Account billing has expired
0x14 = Wrong client version
0x15 = Unknown account
0x16 = Incorrect password
0x17 = Session expired
0x18 = Server shutting down
0x19 = Already logged in
0x1a = Invalid login server
0x1b = Position in Queue: 0
0x1c = This account has been banned for violating the Terms of Use Agreement
0x1d = This character is still logged on
0x1e = Your World of Warcraft subscription has expired
0x1f = This session has timed out
0x20 = This account has been temporarily suspended for violating the Terms of Use Agreement
0x21 = Retrieving realm list
0x22 = realm list retrieved
0x23 = Unable to connect to realm list server
0x24 = Invalid realm list
0x25 = The game server you have chosen is currently down
0x26 = Creating account
0x27 = Account created
0x28 = Character creation failed
0x29 = Retreiving characterlist
0x2a = Characterlist retreived
0x2b = Error retreiving characterlist
0x2c = Creating character
0x2d = Creating character --> and go's to charlist
0x2e = Error creating character
0x2f = Character creation failed
0x30 = Name unavailable
0x31 = Creation of that class / race is currently disabled
0x32 = All of your characters on a PVP realm must be on teh same team
0x33 = You already have the maximum number of characters allowed in this realm
0x34 = You already have the maximum number of characters allowed on this account
0x35 = Deleting character
0x36 = Character deleted
0x37 = Character deletion failed
0x38 = Entering World of Warcraft
0x39 = Login Succesfull
0x40 = World server is down
0x41 = A character with that name already exists
0x42 = No instance servers available
0x43 = Login Failed
0x44 = Login for that class, race or character is currently disabled
0x45 = Enter a name for your character
0x46 = Names must be atleast 2 characters
0x47 = Names must be nomore then 12 characters
0x48 = Names can only contain letters
0x49 = Names must contain only one language
0x50 = That name contains profanity
0x51 = That name is unavailable
0x52 = You cannot use an apostroph as the first or last character of you
0x53 = You can have only one apostroph
0x54 = You cannor use the same letter three times consecutively
0x55 = Invalid character name
0x56 = <empty window>
0x57 and up = numbers starting with (75)
*/