using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Security.Cryptography;
using System.Net;
using HelperTools;
using System.Net.Sockets;
using Server.Items;
using System.IO;

namespace Server
{
	public class Packet
	{
		public byte []data;
		public int len;
		public Packet( byte []d, int l )
		{
			byte []newBuff = new byte[ l ];
			Buffer.BlockCopy( d, 0, newBuff, 0, l );
			data = newBuff;
			len = l;
		}
	}
	/// <summary>
	/// Summary description for ClientHandler.
	/// </summary>
	public class PlayerHandler : SockClient
	{
		byte []key = { 0, 0, 0, 0 };
		bool firstPacket = true;
		Account playerAccount;
		Character loggedChar;
		UpdateTimer updateTimer;
		bool needEncode = false;

		#region MSG_OPCODES
		public const int MSG_MOVE_START_FORWARD = 0x00B5;
		public const int MSG_MOVE_START_BACKWARD = 0x00B6;
		public const int MSG_MOVE_STOP = 0x00B7;
		public const int MSG_MOVE_START_STRAFE_LEFT = 0x00B8;
		public const int MSG_MOVE_START_STRAFE_RIGHT = 0x00B9;
		public const int MSG_MOVE_STOP_STRAFE = 0x00BA;
		public const int MSG_MOVE_JUMP = 0x00BB;
		public const int MSG_MOVE_START_TURN_LEFT = 0x00BC;
		public const int MSG_MOVE_START_TURN_RIGHT = 0x00BD;
		public const int MSG_MOVE_STOP_TURN = 0x00BE;
		public const int MSG_MOVE_START_PITCH_UP = 0x00BF;
		public const int MSG_MOVE_START_PITCH_DOWN = 0x00C0;
		public const int MSG_MOVE_STOP_PITCH = 0x00C1;
		public const int MSG_MOVE_SET_RUN_MODE = 0x00C2;
		public const int MSG_MOVE_SET_WALK_MODE = 0x00C3;
		public const int MSG_MOVE_TOGGLE_LOGGING = 0x00C4;
		public const int MSG_MOVE_TELEPORT = 0x00C5;
		public const int MSG_MOVE_TELEPORT_CHEAT = 0x00C6;
		public const int MSG_MOVE_TELEPORT_ACK = 0x00C7;
		public const int MSG_MOVE_TOGGLE_FALL_LOGGING = 0x00C8;
		public const int MSG_MOVE_COLLIDE_REDIRECT = 0x00C9;
		public const int MSG_MOVE_COLLIDE_STUCK = 0x00CA;
		public const int MSG_MOVE_START_SWIM = 0x00CB;
		public const int MSG_MOVE_STOP_SWIM = 0x00CC;
		public const int MSG_MOVE_SET_RUN_SPEED_CHEAT = 0x00CD;
		public const int MSG_MOVE_SET_RUN_SPEED = 0x00CE;
		public const int MSG_MOVE_SET_WALK_SPEED_CHEAT = 0x00CF;
		public const int MSG_MOVE_SET_WALK_SPEED = 0x00D0;
		public const int MSG_MOVE_SET_SWIM_SPEED_CHEAT = 0x00D1;
		public const int MSG_MOVE_SET_SWIM_SPEED = 0x00D2;
		public const int MSG_MOVE_SET_ALL_SPEED_CHEAT = 0x00D3;
		public const int MSG_MOVE_SET_TURN_RATE_CHEAT = 0x00D4;
		public const int MSG_MOVE_SET_TURN_RATE = 0x00D5;
		public const int MSG_MOVE_TOGGLE_COLLISION_CHEAT = 0x00D6;
		public const int MSG_MOVE_SET_FACING = 0x00D7;
		public const int MSG_MOVE_SET_PITCH = 0x00D8;
		#endregion

		public PlayerHandler( Socket from, RemoveClientDelegate rftsl ) : base ( from, rftsl )
		{
			byte []data = new byte[ 8 ];
			int offset = 0;
			Converter.ToBytes( (ushort)0x0600, data, ref offset );
			Converter.ToBytes( (ushort)OpCodes.SMSG_AUTH_CHALLENGE, data, ref offset );
			Converter.ToBytes( 0x1000, data, ref offset );			
			Send( data, true ); 
		}

		#region PUR SOCKET

		public void Send( byte []buffer, bool noEncode )
		{
			if ( buffer == null )
				return;
			if ( !noEncode )
				Encode( buffer );
			Send( buffer, 0, buffer.Length );
		}
		
		public void Send( byte []buffer )
		{
			if ( buffer == null )
				return;
			if ( needEncode )
				Encode( buffer );
			Send( buffer, 0, buffer.Length );
		}

		public void Send( int opcode, byte []buffer )
		{
			if ( buffer == null )
				return;
			buffer[ 1 ] = (byte)( ( buffer.Length - 2 ) & 0xff );
			buffer[ 0 ] = (byte)( ( ( buffer.Length - 2 ) >> 8 ) & 0xff );
			buffer[ 2 ] = (byte)( opcode & 0xff );
			buffer[ 3 ] = (byte)( ( opcode >> 8 ) & 0xff );

			if ( needEncode )
				Encode( buffer );
			Send( buffer, 0, buffer.Length );
		}
		public void Send( OpCodes opcode, byte []buffer )
		{
			if ( buffer == null )
				return;
			buffer[ 1 ] = (byte)( ( buffer.Length - 2 ) & 0xff );
			buffer[ 0 ] = (byte)( ( ( buffer.Length - 2 ) >> 8 ) & 0xff );
			buffer[ 2 ] = (byte)( (int)opcode & 0xff );
			buffer[ 3 ] = (byte)( ( (int)opcode >> 8 ) & 0xff );
			if ( needEncode )
				Encode( buffer );
			Send( buffer, 0, buffer.Length );
		}
		public void Send( int opcode, byte []buffer, int len )
		{
			if ( buffer == null )
				return;
			len -=2;
			buffer[ 1 ] = (byte)( len & 0xff );
			buffer[ 0 ] = (byte)( ( len >> 8 ) & 0xff );
			buffer[ 2 ] = (byte)( opcode & 0xff );
			buffer[ 3 ] = (byte)( ( opcode >> 8 ) & 0xff );
			if ( needEncode )
				Encode( buffer );		
			Send( buffer, 0, len + 2 );
		}
		public void Send( OpCodes opcode, byte []buffer, int len )
		{
			Send( (int)opcode, buffer, len );
		}

	
		public void Decode( byte []data, int offset, int length )
		{
			//	byte []res = new byte[ length ];
			
			byte []K = SS_Hash;
			for(int t = 0;t < 6;t++)//length;t++ )
			{				
				//	if ( t == 6 )
				//		break;
				byte a = key[ 0 ];
				key[ 0 ] = data[ offset + t ];
				byte b = data[ offset + t ];
				
				b = (byte)( b - a );
				byte d = key[ 1 ];
				a = K[ d ];
				a = (byte)( a ^ b );
				data[ t + offset ] = a;
				//Console.Write( "{0} ", a.ToString( "X2" ) );
				a = key[ 1 ];
				a++;
				key[ 1 ] = (byte)( a % 0x28 );					
			}
			//	PopulateMessageList( data, offset, true );
		}
		
		public  void Decode( byte []data, int length )
		{
			byte []K = SS_Hash;
			for(int t = 0;t < 6;t++)//length;t++ )
			{				
				//	if ( t == 6 )
				//		break;
				byte a = key[ 0 ];
				key[ 0 ] = data[ t ];
				byte b = data[ t ];
				
				b = (byte)( b - a );
				byte d = key[ 1 ];
				a = K[ d ];
				a = (byte)( a ^ b );
				data[ t ] = a;
				//Console.Write( "{0} ", a.ToString( "X2" ) );
				a = key[ 1 ];
				a++;
				key[ 1 ] = (byte)( a % 0x28 );					
			}
			//	PopulateMessageList( data, 0, true );
		}
		public void DecodeSansAff( byte []data, int length )
		{
			//	byte []res = new byte[ length ];
			
			byte []K = SS_Hash;
			for(int t = 0;t < 6;t++)//length;t++ )
			{				
				//	if ( t == 6 )
				//		break;
				byte a = key[ 0 ];
				key[ 0 ] = data[ t ];
				byte b = data[ t ];
				
				b = (byte)( b - a );
				byte d = key[ 1 ];
				a = K[ d ];
				a = (byte)( a ^ b );
				data[ t ] = a;
				//Console.Write( "{0} ", a.ToString( "X2" ) );
				a = key[ 1 ];
				a++;
				key[ 1 ] = (byte)( a % 0x28 );					
			}
			//	PopulateMessageList( data, 0, true );
		}
		public void Encode( byte []data )
		{			
			//////////////////////////////////////////////////////////////////////
			////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			/////////////////////////////////////////////////////////////////////////
			/////////////////////////////////////////////////////////////////////////
			/////////////////////////////////////////////////////////////////////////
			/////////////////////////////////////////////////////////////////////////
			/////////////////////////////////////////////////////////////////////////
			/////////////////////////////////////////////////////////////////////////			///
			/*
				if ( ( data[ 2 ] == 0x3e && data[ 3 ] == 0x01 ) || ( data[ 2 ] == 0xdd && data[ 3 ] == 0x00 ) 
					|| ( data[ 2 ] == 0x4A && data[ 3 ] == 0x01 ) )
				if ( data[ 2 ] != 0x4A )
				{
				}
				else*/
	/*		if ( File.Exists( "debug.txt"  ) )
			{
				Console.Write( "{0}:{1}:{2} {3} --> ", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, this.IP.ToString() );
				for( int t = 0;t < data.Length;t++ )
					Console.Write( "{0} ", data[ t ].ToString( "X2" ) );

				Console.WriteLine("");
			}	*/
			if ( SS_Hash == null )
			{
				Console.WriteLine("Missing SS_Hash for that character !!!!!" );
				return;
			}
			/*
						PopulateMessageList( data, 0, false );
			*/
			byte []K = SS_Hash;
			for(int t = 0;t < 4;t++ )
			{				
				byte a = key[ 3 ];
				a = (byte)( K[ a ] ^ data[ t ] );				
				byte d = key[ 2 ];
				a += d;
				data[ t ] = a;
				//Console.Write( "{0} ", a.ToString( "X2" ) );
				key[ 2 ] = a;
				a = key[ 3 ];
				a++;				
				key[ 3 ] = (byte)( a % 0x28 );
			}
			//Console.WriteLine("");
		}


		#endregion

		byte []nullAction = new byte[] { 0x00, 0x05, 0x00, 0x00, 0x00, 0x00, 0x00 };
		public void SendNullAction( int opcode )
		{
			int offset = 5;
			Converter.ToBytes( (short)opcode, nullAction, ref offset );
			Send( OpCodes.MSG_NULL_ACTION, nullAction );
		}
		public Queue test = new Queue();
		public bool debloque = false;
		public byte[]SS_Hash
		{
			get { try{return playerAccount.SS_Hash;}
				  catch(Exception e ){Console.WriteLine("Error {0}\n{1}", e.Message, e.StackTrace );return null;} }
		}
		bool alreadyCrashed = false;
		class DelaySend : WowTimer
		{
			int ti = 0;
			PlayerHandler playerHangler;
			public DelaySend( PlayerHandler ph ) : base( WowTimer.Priorities.Milisec100 , 300, "DelaySend" )
			{
				playerHangler = ph;
				Start();
			}
			public override void OnTick()
			{
				ti++;
				if ( ti > 30 )
				{
				//	playerHangler.Dispose();
					base.Stop();
				}
				//Console.WriteLine("send log for " + playerHangler.IP.ToString() );
				if ( ti == 2 || playerHangler.needLog )
				{
				//	Console.WriteLine("send log" );
					byte []pack = new byte[]{ 0x00, 0x03, 0xEE, 0x01, 0x0c };
					playerHangler.Send( pack, false );
					base.OnTick();
				}
				else
					base.OnTick();
			}
		}
		DelaySend dt;
		DateTime lastUpdate = DateTime.Now;
		public override byte [] ProcessDataReceived( byte []data, int length )
		{
		/*	Console.WriteLine("ProcessDataReceived receive" );
			HexViewer.View( data, 0, length );
			Console.WriteLine("ProcessDataReceived end" );*/
		//	Console.WriteLine("ProcessDataReceived enter" );
			if ( playerAccount == null )
			{
				Console.WriteLine("playerAccount == null, IP={0}", IP.ToString() );
				if ( ( data[ 0 ] == 0 || data[ 0 ] == 2 ) && data[ 2 ] == 0xed && data[ 3 ] == 0x1 )
				{
					string username = "";
					for(int t = 0xe;t < length;t++ )
					{
						if ( data[ t ] == 0 )
							break;
						username += "" + (char)data[ t ];
					}
					playerAccount = World.allAccounts.FindByUserName( username );
					Console.WriteLine("Player {0} with IP {1}", username, IP );
					if ( playerAccount == null )
					{
						Console.WriteLine("Strange bug, {0} was not found in the account list !", username );
						return null;
					}
					playerAccount.Handler = this;
					playerAccount.PreLogin();
					if ( playerAccount.packetHandler == null )
					{
						Console.WriteLine("packetHandler cannot be null");
					}

					if ( playerAccount.Packets.Count > 0 )
					{
						Queue q = new Queue();
						q.Enqueue( new Packet( data, length ) );
						while( playerAccount.Packets.Count > 0 )
							q.Enqueue( playerAccount.Packets.Dequeue() );
						playerAccount.Packets = q;
					}
				//	Console.WriteLine("Packets.Enqueue for {0} total {1}", playerAccount.Username, playerAccount.Packets.Count );
					if ( playerAccount.Packets.Count > 100 )
					{
						Console.WriteLine("Player {0} send too many packets !!! Kicked !!!" );
						playerAccount.Packets.Clear();
						this.Logout();
						return null;
					}
				//	playerAccount.Packets.Enqueue( new Packet( data, length ) );
				//	Console.Write( "{0}:{1}:{2}-{1} <-- ", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, this.IP.ToString() );
				//	HexViewer.View( data, 0, length );					
					key = new byte[]{ 0, 0, 0, 0 };
					needEncode = true;
					needLog = true;
					dt = new DelaySend( this );

					firstPacket = false;
				//	playerAccount.PacketHandler();
					return null;
				}
				else
					playerAccount = World.allAccounts.FindNotLoggedAccountByIp( IP );//, Port );

				if ( playerAccount == null )
				{
					Console.WriteLine( "IP doesn't match the prior IP client send !!!\nMake sure your IP match the IP in the realmlist.rtf" );
					this.Dispose();
					return null;
				}
				if ( !needEncode && playerAccount.packetHandler != null )
				{
		//			Console.WriteLine("!needEncode, playerAccount.packetHandler != null" );
					playerAccount.packetHandler.Stop();
					playerAccount.packetHandler = null;
				}
				if ( playerAccount != null && playerAccount.packetHandler == null )
				{
			//		Console.WriteLine("playerAccount.packetHandler == null" );
					playerAccount.Handler = this;
					playerAccount.PreLogin();
				}
					
			}
		//	if ( playerAccount != null )//&& playerAccount.SelectedChar != null )
		//	{
		//	Console.WriteLine("ExMutuel.WaitOne" );
			//	playerAccount.ExMutuel.WaitOne();
	//		Console.WriteLine("Packets.Enqueue for {0} total {1}", playerAccount.Username, playerAccount.Packets.Count );
			if ( playerAccount == null )
				Console.WriteLine("Loosing packet for {0}",IP.ToString() );
			else
			{
				lock( playerAccount.Packets )
				{
					playerAccount.Packets.Enqueue( new Packet( data, length ) );
				}
			}
			//	playerAccount.ExMutuel.ReleaseMutex();
		//	}

		//	else
		//		return DequeueData( data, length );
		//	Console.WriteLine("End" );
			return null;
		}
		bool needLog = false;
		
		public byte []DequeueData( byte []data, int length )
		{
			int len = 0; 
			int after = 0;
			int code = 0;
#if !DEBUG
			try
			{
#endif
			//	Console.Write( "{0}:{1}:{2} {1} <-- ", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, this.IP.ToString() );
			//	HexViewer.View( data, after, length );
			//	Console.WriteLine("IP {0} port {1} ", IP, this.Port );
				if ( playerAccount == null )
				{
			//		Console.WriteLine("playerAccount == null");
					firstPacket = true;
					if ( ( (IPEndPoint)this.clientSocket.RemoteEndPoint ) == null )
						return null;
					playerAccount = World.allAccounts.FindAccountByIp( IP, ( (IPEndPoint)this.clientSocket.RemoteEndPoint ).Port );
				//	Console.WriteLine("Account {2} IP {0} port {1} ", IP, this.Port, playerAccount.Username );
				}
				else
					playerAccount.lastHeartBeat = DateTime.Now;
				
			//	Console.WriteLine("after == {0}", after);
				while( after != - 1 )
				{	
					if ( !firstPacket )
					{
						byte a1 = data[ after ];
						byte a2 = data[ after + 1 ];
						byte a3 = data[ after + 2 ];
						byte a4 = data[ after + 3 ];
						Decode( data, after, length - after );
						code = ( (int)data[ after + 2 ] ) + ( ( (int)data[ after + 3 ] ) << 8 );
						len = ( (int)data[ after + 1 ] ) + ( ( (int)data[ after + 0 ] ) << 8 );		
					//	if ( File.Exists( "debug.txt"  ) )
							/*		switch( code )
									{
										case (int)OpCodes.MSG_MOVE_FALL_LAND:
										case MSG_MOVE_JUMP: case MSG_MOVE_START_FORWARD : case MSG_MOVE_START_BACKWARD: case MSG_MOVE_SET_FACING:
										case MSG_MOVE_STOP: case MSG_MOVE_START_STRAFE_LEFT: case MSG_MOVE_START_STRAFE_RIGHT: case MSG_MOVE_STOP_STRAFE:
										case MSG_MOVE_START_TURN_LEFT: case MSG_MOVE_START_TURN_RIGHT:  case MSG_MOVE_STOP_TURN: case MSG_MOVE_START_PITCH_UP :
										case MSG_MOVE_START_PITCH_DOWN: case MSG_MOVE_STOP_PITCH : case MSG_MOVE_SET_RUN_MODE: case MSG_MOVE_SET_WALK_MODE:
										case MSG_MOVE_SET_PITCH: case MSG_MOVE_START_SWIM:
										case MSG_MOVE_STOP_SWIM:
										case (int)OpCodes.SMSG_MONSTER_MOVE:
											break;
										default:
											if (	loggedChar != null ) 
											Console.Write( "{0}:{1}:{2} {3}-{1} <-- ", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, this.IP.ToString(), this.loggedChar.Guid );
											HexViewer.View( data, after, len + 2 );
											break;
									}*/
						if ( after + len > data.Length )
						{
							byte []toret = new byte[ data.Length - after ];
							Buffer.BlockCopy( data, after, toret, 0, toret.Length );
							if ( toret.Length > 0 )
								toret[ 0 ] = a1;
							if ( toret.Length > 1 )
								toret[ 1 ] = a2;
							if ( toret.Length > 2 )
								toret[ 2 ] = a3;
							if ( toret.Length > 3 )
								toret[ 3 ] = a4;
							return toret;
						}
					}
					else
					{
						code = ( (int)data[ after + 2 ] ) + ( ( (int)data[ after + 3 ] ) << 8 );
						len = ( (int)data[ after + 1 ] ) + ( ( (int)data[ after + 0 ] ) << 8 );
					}

					firstPacket = false;

					if ( playerAccount != null && playerAccount.loggoutTimer != null )
					{
					//	Console.WriteLine("playerAccount != null && playerAccount.loggoutTimer != null");
						if ( code == (int)OpCodes.CMSG_LOGOUT_CANCEL )
						{
							playerAccount.CancelLogout();
							return null;
						}
						SendNullAction( code );
						return null;
					}

				//	Console.WriteLine("code {0}",code);
					switch( code )
					{
						case 0x1DC:
						{
							//	Heart beat
							byte []pack = new byte[]{  0x00, 0x06, 0xDD, 0x01, data[ 6 ], data[ 7 ], data[ 8 ], data[ 9 ] };
							Send( pack );
							if ( playerAccount != null )
								playerAccount.HeartBeat();
							break;

						}
						case 0x0036://	new char request
						{						
							playerAccount.AddCharacter( data );
							break;
						}
						case 0x1ED:
							break;
						case (int)OpCodes.CMSG_CHAR_DELETE:
							playerAccount.Handler = this;
							playerAccount.DeleteChar( BitConverter.ToUInt64( data, after + 6 ) );												
							//Player.Handler = null;
							break;

						case 0x0037:
						{
							needLog = false;
							int t = 4;
							byte []pack = playerAccount.PrepareDataList( ref t );
							t-=2;
							pack[ 0 ] = (byte)( ( t >> 8 ) & 0xff );
							pack[ 1 ] = (byte)( t & 0xff );
							pack[ 2 ] = 0x3b;
							pack[ 3 ] = 0x00;	
							byte []toSend = new byte[ t + 2 ];
							for(int i = 0;i < t + 2;i++ )
								toSend[ i ] = pack[ i ];
							Send( toSend );
							break;
						}
						case 0x003D://	login
						{
							dt.Stop();
							UInt64 guid = (UInt64)BitConverter.ToInt64( data, after + 6 );
							playerAccount.Handler = this;
							loggedChar = playerAccount.Login( guid );
							if ( loggedChar != null )
							{
								//SMSG_FRIEND_LIST
								Send( new byte[]{ 0x00, 0x06, 0x67, 0x00, 0x00, 0x00, 0x00, 0x00 } );
								//	UpdateTimer updateTimer = new UpdateTimer( this, loggedChar );
							}
							else
								playerAccount.Handler.Send( new byte[]{ 0x00, 0x03, 0x41, 0x00, 0x00 } );
							break;
						}
						default:
							if ( loggedChar == null )
							{
								this.Dispose();
								return null;
							}
							break;
					}
					
					if ( loggedChar != null )
					{
						loggedChar.ManagePacket( code, data, ref after, len );
					}
/*
					switch( code )
					{
						case MSG_MOVE_START_FORWARD :
							
						case (int)OpCodes.MSG_MOVE_FALL_LAND:
						case (int)OpCodes.MSG_MOVE_JUMP:  
						case (int)OpCodes.MSG_MOVE_START_BACKWARD: case (int)OpCodes.MSG_MOVE_SET_FACING:
						case (int)OpCodes.MSG_MOVE_STOP: case (int)OpCodes.MSG_MOVE_START_STRAFE_LEFT: 
						case (int)OpCodes.MSG_MOVE_START_STRAFE_RIGHT: case (int)OpCodes.MSG_MOVE_STOP_STRAFE:
						case (int)OpCodes.MSG_MOVE_START_TURN_LEFT: case (int)OpCodes.MSG_MOVE_START_TURN_RIGHT:  
						case (int)OpCodes.MSG_MOVE_STOP_TURN: case (int)OpCodes.MSG_MOVE_START_PITCH_UP :
						case (int)OpCodes.MSG_MOVE_START_PITCH_DOWN: case (int)OpCodes.MSG_MOVE_STOP_PITCH : 
						case (int)OpCodes.MSG_MOVE_SET_RUN_MODE: case (int)OpCodes.MSG_MOVE_SET_WALK_MODE:
						case (int)OpCodes.MSG_MOVE_SET_PITCH: case (int)OpCodes.MSG_MOVE_START_SWIM:
						case (int)OpCodes.MSG_MOVE_STOP_SWIM: 


							// 00 30 EE 00 
							//00 00 01 20 00 00 6B 8C 09 00 
							//F8 6F 33 45 
							//42 F5 41 C4 
							//5D 6D 20 43 
							//AC 6A 73 40 
							//BA 00 00 00 00 00 00 00 CD F4 49 BF FF 51 1D BF 00 00 E0 40 .@ 
						case (int)OpCodes.MSG_MOVE_HEARTBEAT:
						{
							if ( code == (int)OpCodes.MSG_MOVE_START_TURN_LEFT ||
								code == (int)OpCodes.MSG_MOVE_SET_FACING || 
								code == (int)OpCodes.MSG_MOVE_START_TURN_RIGHT )
								loggedChar.deadEndTeleportLoop = false;
						//	TimeSpan ts = DateTime.Now.Subtract( lastUpdate );
						//	if ( ts.TotalSeconds > 2 )
							playerAccount.RefreshMobileList( false );
							playerAccount.realylogged = true;
							if (loggedChar.AutoShot != null)
								loggedChar.AutoShot.Restart();
							playerAccount.MvtToAllPlayerNear( code, data, after, len + 2 );
							float x = BitConverter.ToSingle( data, after + 14 );
							float y = BitConverter.ToSingle( data, after + 18 );
							float z = BitConverter.ToSingle( data, after + 22 );
							float orientation = BitConverter.ToSingle( data, after + 26 );
							loggedChar.MoveHandler( x, y, z, orientation );
							if ( code != (int)OpCodes.MSG_MOVE_FALL_LAND && loggedChar.path != null )
							{
								if ( loggedChar.path.Count > 0 )
								{
									int ne = loggedChar.path.Count - 1;
									float xx = loggedChar.path[ ne ].x - x;
									float yy = loggedChar.path[ ne ].y - y;
									float zz = loggedChar.path[ ne ].z - z;
									if ( xx + yy + zz != 0 )
									{
										loggedChar.SendMessage( "Pos x="+x.ToString()+"; y="+y.ToString()+"; z="+z.ToString() );
										Coord l = lastCoordTrajet;
										lastCoordTrajet = new Coord( x, y, z, lastCoordTrajet, null );
										l.next = lastCoordTrajet;
										loggedChar.path.Add( lastCoordTrajet, l );
									}
								}
								else
								{
									lastCoordTrajet = new Coord( x, y, z, null, null );
									loggedChar.path.Add( lastCoordTrajet );
								}
							}
							else
								if ( code == MSG_MOVE_START_STRAFE_RIGHT || code == MSG_MOVE_START_STRAFE_LEFT )
							{
								if ( loggedChar.IsCasting )
								{
									loggedChar.CancelCast();
								}
							}

							break;
						}
						case (int)OpCodes.CMSG_USE_ITEM:
							loggedChar.UseItem( data[ after + 6 ], BitConverter.ToInt32( data, after + 7 ) );
							break;
						case (int)OpCodes.CMSG_DUEL_CANCELLED:
						{
							loggedChar.CancelDuel( BitConverter.ToUInt64( data, after + 6 ) );
							break;
						}
						case (int)OpCodes.CMSG_DUEL_ACCEPTED:
						{
							loggedChar.SendDuelArbitrer( BitConverter.ToUInt64( data, after + 6 ) );
							break;
						}
						case (int)OpCodes.CMSG_ENABLE_PVP:
						{
							break;
						}
						case (int)OpCodes.CMSG_CANCEL_AUTO_REPEAT_SPELL:
						{
							loggedChar.OnCancelAutoCastSpell();
							break;
						}

						case (int)OpCodes.CMSG_CAST_SPELL:
							if ( loggedChar.taxiOn )
							{
								loggedChar.SpellFaillure( SpellFailedReason.YourAreInFligth );
							}
							else
							{
								if ( BitConverter.ToInt32( data, after + 6 ) == 7266 )
									loggedChar.PrepareInv( data, after );
								ushort type = BitConverter.ToUInt16( data, after + 10 );
								loggedChar.OnCastSpellCMSG(data,after,type);
							}
							break;
						case (int)OpCodes.CMSG_ATTACKSWING:
							loggedChar.AttackSwing( BitConverter.ToUInt64( data, after + 6 ) );
							break;
						case (int)OpCodes.CMSG_CANCEL_CAST:
							loggedChar.CancelCast();
							break;
						case (int)OpCodes.CMSG_SET_SELECTION:
							loggedChar.SetSelection( BitConverter.ToUInt64( data, after + 6 ) );
							//						SendNullAction( code );
							break;
						case (int)OpCodes.CMSG_STANDSTATECHANGE:
							loggedChar.ChangeStandState( BitConverter.ToInt32( data, after + 6 ) );
							break;
				

						case 0x1DC:
						{
							//	Heart beat
							byte []pack = new byte[]{  0x00, 0x06, 0xDD, 0x01, data[ 6 ], data[ 7 ], data[ 8 ], data[ 9 ] };
							Send( pack );
							if ( playerAccount != null )
								playerAccount.HeartBeat();
							break;

						}
						case 0x0036://	new char request
						{						
							playerAccount.AddCharacter( data );
							break;
						}
						
						case 0x0037:
						{
							needLog = false;
							int t = 4;
							byte []pack = playerAccount.PrepareDataList( ref t );
							t-=2;
							pack[ 0 ] = (byte)( ( t >> 8 ) & 0xff );
							pack[ 1 ] = (byte)( t & 0xff );
							pack[ 2 ] = 0x3b;
							pack[ 3 ] = 0x00;	
							byte []toSend = new byte[ t + 2 ];
							for(int i = 0;i < t + 2;i++ )
								toSend[ i ] = pack[ i ];
							//	byte[]toSend = new byte[]{ 0x00, 0xA6, 0x3B, 0x00 , 0x01 , 0xD4 , 0x2F , 0x15 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x52 , 0x69 , 0x73 , 0x65 , 0x00 , 0x07 , 0x01 , 0x01 , 0x04 , 0x03 , 0x03 , 0x01 , 0x06 , 0x01 , 0x01 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x8F , 0x02 , 0xC3 , 0xC5 , 0x39 , 0x84 , 0xA5 , 0x43 , 0x06 , 0x61 , 0xBF , 0x43 , 0x00 , 0x00 , 0x00 , 0x00 , 0x01 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0xA3 , 0x26 , 0x00 , 0x00 , 0x04 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0xA4 , 0x26 , 0x00 , 0x00 , 0x07 , 0x9D , 0x27 , 0x00 , 0x00 , 0x08 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x06 , 0x06 , 0x00 , 0x00 , 0x15 , 0x2A , 0x49 , 0x00 , 0x00 , 0x0E , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00  };
							Send( toSend );
							break;
						}
						case 0x003D://	login
						{
							dt.Stop();
							UInt64 guid = (UInt64)BitConverter.ToInt64( data, after + 6 );
							playerAccount.Handler = this;
							loggedChar = playerAccount.Login( guid );
							if ( loggedChar != null )
							{
								//SMSG_FRIEND_LIST
								Send( new byte[]{ 0x00, 0x06, 0x67, 0x00, 0x00, 0x00, 0x00, 0x00 } );
							//	UpdateTimer updateTimer = new UpdateTimer( this, loggedChar );
							}
							else
								playerAccount.Handler.Send( new byte[]{ 0x00, 0x03, 0x41, 0x00, 0x00 } );
							break;
						}
						case (int)OpCodes.CMSG_GAMEOBJECT_QUERY:
							loggedChar.GameObjectQuery( BitConverter.ToInt32( data, after + 6 ), (UInt64)BitConverter.ToUInt64( data, after + 10 ) );
							break;
						case (int)OpCodes.CMSG_SET_TARGET:
							loggedChar.Target = (UInt64)BitConverter.ToInt64( data, after + 6 );
							//	SendNullAction( code );
							break;
						case (int)OpCodes.CMSG_LIST_INVENTORY:
							loggedChar.ShowMobileInventory( (UInt64)BitConverter.ToInt64( data, after + 6 ) );
							SendNullAction( code );
							break;
						case (int)OpCodes.CMSG_BUY_ITEM:
							loggedChar.Buy( BitConverter.ToUInt64( data, after + 6 ), BitConverter.ToInt32( data, after + 14 ), Slots.None, data[ after + 19 ] );						
							break;
						case (int)OpCodes.CMSG_SELL_ITEM:
							loggedChar.Sell( BitConverter.ToUInt64( data, after + 6 ), BitConverter.ToUInt64( data, after + 14 ) );						
							break;

						case 0x020B:
							//SendNullAction( code );
							break;
						case (int)OpCodes.CMSG_SET_ACTIVE_MOVER://	Account update
							//	SendNullAction( code );
							break;
						case 0x211://	CMSG_GMTICKET
							playerAccount.Handler.Send( 0x212, new byte[]{ 0x00, 0x06 , 0x12 , 0x02 , 0x01 , 0x00 , 0x00 , 0x00 } );
							break;
						case 0x1CE://	Query time							
							byte []buffTime = { 0,0,0,0, 0x90,0xE0,0x22,0x42};
							playerAccount.Handler.Send( (int)OpCodes.SMSG_QUERY_TIME_RESPONSE, buffTime );
							break;
						case 0x1FF://	Looking for Group						
							SendNullAction( code );
							break;
						case (int)OpCodes.CMSG_NAME_QUERY:
							loggedChar.SendName( BitConverter.ToUInt64( data, after + 6 ) );
							break;
						case (int)OpCodes.CMSG_MESSAGECHAT:
							//00 00 00 00 00 00 07 00 00 00 7A 6F 62 00 
						{
							string cmd = "";
							for(int t = 0;data[ after + t + 14 ] != 0;t++ )
								cmd += "" + (char)data[ after + t + 14 ];
							loggedChar.MessageHandler( cmd, (Character.ChatMsgType)BitConverter.ToInt32( data, after + 6 ), BitConverter.ToInt32( data, after + 10 ) );						
							break;
						}
						case 0x284:// MSG_QUERY_NEXT_MAIL_TIME
							playerAccount.Handler.Send( OpCodes.MSG_QUERY_NEXT_MAIL_TIME, new byte[]{ 0,0,0,0, 0x00, 0x0 , 0x0 , 0x0 } );
							break;
						case 0xFB://	CMSG_NEXT_CINEMATIC_CAMERA
							break;
						case 0xFC://	CMSG_COMPLETE_CINEMATIC
							break;
						case 0xFE://	CMSG_TUTORIAL_FLAG
							//	loggedChar.Trace();
							break;
						case 0xFF://	CMSG_TUTORIAL_CLEAR
							break;
						case (int)OpCodes.CMSG_JOIN_CHANNEL://	CMSG_JOIN_CHANNEL
							loggedChar.JoinChannel( data, after + 6 );
							debloque = true;
							break;
						case 0x1F4://	CMSG_ZONEUPDATE		
							loggedChar.ZoneUpdateRequested( BitConverter.ToInt32( data, after + 6 ) );
							break;
						case 0x56://	CMSG_ITEM_QUERY_SINGLE
							loggedChar.SendItem( BitConverter.ToInt32( data, after + 6 ), BitConverter.ToUInt64( data, after + 10 ) );
							break;
						case (int)OpCodes.CMSG_LOOT_MONEY:
							loggedChar.OnLootMoney();
							break;
						case (int)OpCodes.CMSG_CREATURE_QUERY:
							loggedChar.CreatureQuery( (UInt64)BitConverter.ToInt64( data, after + 10 ), BitConverter.ToInt32( data, after + 6 ) );
							break;
						case (int)OpCodes.CMSG_LOOT_RELEASE:
							loggedChar.ReleaseLoot();
							break;
						case (int)OpCodes.CMSG_AUTOSTORE_LOOT_ITEM:
							loggedChar.AutostoreLootItem( data[ after + 6 ] );
							break;
						case (int)OpCodes.CMSG_LOOT:
							loggedChar.LootCreature( BitConverter.ToUInt64( data, after + 6 ) );
							break;
						case (int)OpCodes.CMSG_SETSHEATHED:
							loggedChar.Sheathed = BitConverter.ToInt32( data, after + 6 );
							break;
						case (int)OpCodes.CMSG_QUESTGIVER_QUERY_QUEST:
							loggedChar.QuestQueryForCreature( BitConverter.ToUInt64( data, after + 6 ), BitConverter.ToInt32( data, after + 14 ) );
							break;
						case (int)OpCodes.CMSG_QUESTGIVER_STATUS_QUERY:
							loggedChar.QuestStatus( BitConverter.ToUInt64( data, after + 6 ) );
							break;
						case (int)OpCodes.CMSG_QUESTGIVER_HELLO:
							loggedChar.QuestGiverHello( BitConverter.ToUInt64( data, after + 6 ) );
							break;
						case (int)OpCodes.CMSG_NPC_TEXT_QUERY:
							loggedChar.NpcTextQuery( BitConverter.ToInt32( data, after + 6 ), BitConverter.ToUInt64( data, after + 10 ) );
							break;	
						case (int)OpCodes.CMSG_GOSSIP_SELECT_OPTION:
							loggedChar.GossipSelectOption( BitConverter.ToUInt64( data, after + 6 ), BitConverter.ToInt32( data, after + 14 ) );
							break;	
						case (int)OpCodes.CMSG_QUESTGIVER_ACCEPT_QUEST:
							loggedChar.AcceptQuest( BitConverter.ToUInt64( data, after + 6 ), BitConverter.ToInt32( data, after + 14 ) );
							break;
						case (int)OpCodes.CMSG_QUESTLOG_REMOVE_QUEST:
							loggedChar.RemoveQuest( data[ after + 6 ] );
							break;
						case (int)OpCodes.CMSG_QUESTGIVER_COMPLETE_QUEST:
							loggedChar.QuestGiverCompleteQuest( BitConverter.ToUInt64( data, after + 6 ), BitConverter.ToInt32( data, after + 14 ) );
							break;
						case (int)OpCodes.CMSG_QUEST_QUERY:
							loggedChar.QuestQuery( BitConverter.ToInt32( data, after + 6 ) );
							break;
						case (int)OpCodes.CMSG_QUESTGIVER_CHOOSE_REWARD:
							loggedChar.ChooseReward( BitConverter.ToUInt64( data, after + 6 ), BitConverter.ToInt32( data, after + 14 ), BitConverter.ToInt32( data, after + 18 ) );
							break;
						case (int)OpCodes.CMSG_GAMEOBJ_USE:
							loggedChar.GameObjectUse( BitConverter.ToUInt64( data, after + 6 ) );
							break;
						case (int)OpCodes.CMSG_ATTACKSTOP:
							if ( playerAccount == null || loggedChar == null )
								return null;
							loggedChar.StopAttacking();
							break;
						case 0x20A://	CMSG_REQUEST_ACCOUNT_DATA
							break;
						case (int)OpCodes.CMSG_SWAP_INV_ITEM:
							loggedChar.SwapInv( (Slots)data[ after + 6 ], (Slots)data[ after + 7 ] );
							break;
						case (int)OpCodes.CMSG_SWAP_ITEM:
							loggedChar.SwapItem( data[ after + 6 ], data[ after + 7 ], data[ after + 8 ], data[ after + 9 ] );
							break;
						case (int)OpCodes.CMSG_DESTROYITEM:
							loggedChar.DestroyItem( Item.SlotNum( data[ after + 6 ], data[ after + 7 ] ), true );
							break;
						case (int)OpCodes.CMSG_AUTOEQUIP_ITEM:
							loggedChar.AutoEquip( Item.SlotNum( data[ after + 6 ], data[ after + 7 ] ) );
							break;
						case (int)OpCodes.CMSG_AUTOSTORE_BAG_ITEM:
							loggedChar.Autostore( Item.SlotNum( data[ after + 6 ], data[ after + 7 ] ), data[ after + 8 ] );
							break;
						case (int)OpCodes.CMSG_INITIATE_TRADE:
							loggedChar.InitiateTrade( BitConverter.ToUInt64( data, after + 6 ) );
							break;
						case (int)OpCodes.CMSG_BEGIN_TRADE:
							loggedChar.BeginTrade();
							break;
						case (int)OpCodes.CMSG_SET_TRADE_ITEM:
							loggedChar.TradeItem( data[ after + 6 ], Item.SlotNum( data[ after + 7 ], data[ after + 8 ] ) );
							break;
						case (int)OpCodes.CMSG_CLEAR_TRADE_ITEM:
							loggedChar.ClearTradeItem( (int)data[ after + 6 ] );
							break;				
						case (int)OpCodes.CMSG_SET_TRADE_GOLD:
							loggedChar.TradeGold( BitConverter.ToInt32( data, after + 6 ) );
							break;
						case (int)OpCodes.CMSG_LOGOUT_REQUEST:
						{
							playerAccount.Handler.Send( OpCodes.SMSG_LOGOUT_RESPONSE, new byte[]{ 0x00, 0x06 , 0x12 , 0x02 , 00, 00, 00, 00, 00 } );
							playerAccount.LoggoutStartTimer();
							break;
						}
						case (int)OpCodes.CMSG_SET_ACTION_BUTTON:
							loggedChar.AddToActionBar( data[ after + 6 ], BitConverter.ToUInt16( data, after + 7 ), data[ after + 9 ], data[ after + 10 ] );
							break;

						case (int)OpCodes.CMSG_TRAINER_LIST:
							loggedChar.TrainerList( BitConverter.ToUInt64( data, after + 6 ) );
							break;
						case (int)OpCodes.CMSG_TRAINER_BUY_SPELL:
							loggedChar.TrainerBuy( BitConverter.ToUInt64( data, after + 6 ), BitConverter.ToInt32( data, after + 14 ) );						
							break;
						case (int)OpCodes.CMSG_CHAR_DELETE:
							playerAccount.Handler = this;
							playerAccount.DeleteChar( BitConverter.ToUInt64( data, after + 6 ) );												
							//playerAccount.Handler = null;
							break;
						case (int)OpCodes.CMSG_UNLEARN_SKILL:
							loggedChar.SendMessage( "Not available yet !" );
							break;
						case (int)OpCodes.CMSG_SET_AMMO:
							loggedChar.SetAmmo( BitConverter.ToInt32( data, after + 6 ) );
							break;
						case (int)OpCodes.CMSG_TEXT_EMOTE:
							loggedChar.OnTextEmote( BitConverter.ToInt32( data, after + 6 ), BitConverter.ToUInt64( data, after + 14 ) );
							break;
						case (int)OpCodes.CMSG_RECLAIM_CORPSE:
							loggedChar.ReclaimCorps();
							break;
						case (int)OpCodes.MSG_CORPSE_QUERY:
							loggedChar.CorpseQuery();
							break;
						case (int)OpCodes.CMSG_REPOP_REQUEST:
							loggedChar.OnRepop();
							break;
						case (int)OpCodes.CMSG_CANCEL_TRADE:
							loggedChar.CancelTrade();
							break;
						case (int)OpCodes.CMSG_ACCEPT_TRADE:
							loggedChar.AcceptTrade();
							break;
						case (int)OpCodes.CMSG_UNACCEPT_TRADE:
							if ( loggedChar == null )
							{
								this.Dispose();
								break;
							}
							loggedChar.UnacceptTrade();
							break;
						case (int)OpCodes.CMSG_LEAVE_CHANNEL:
							SendNullAction( (int)OpCodes.SMSG_CHANNEL_NOTIFY );
							break;
						case (int)OpCodes.CMSG_MEETING_STONE_INFO:
							loggedChar.MeetingStoneInfo();
							break;
						case (int)OpCodes.CMSG_CANCEL_AURA:
							loggedChar.CancelAura(  BitConverter.ToInt32( data, after + 6 ) );
							break;
						case (int)OpCodes.CMSG_PET_ACTION:
							loggedChar.PetAction( BitConverter.ToUInt16( data, after + 0xe ), data[ after + 17 ], BitConverter.ToUInt64( data, after + 18 ) );
							break;
						case (int)OpCodes.CMSG_PET_SET_ACTION:
							if ( len == 0x14 )
								loggedChar.SetPetAction( BitConverter.ToUInt64( data, after + 6 ), BitConverter.ToInt32( data, after + 0xe ), BitConverter.ToUInt32( data, after + 0x12 ) );
							else
								loggedChar.SetPetAction( BitConverter.ToUInt64( data, after + 6 ), BitConverter.ToUInt32( data, after + 0xe ), BitConverter.ToUInt32( data, after + 0x12 ), BitConverter.ToUInt32( data, after + 0x16 ), BitConverter.ToUInt32( data, after + 0x1A ) );
							break;
						case (int)OpCodes.CMSG_PET_ABANDON:
							loggedChar.DismissPet( BitConverter.ToUInt64( data, after + 6 ) );
							break;
						case (int)OpCodes.MSG_MOVE_WORLDPORT_ACK:
							loggedChar.TeleportAck();
							break;
						case (int)OpCodes.CMSG_GROUP_INVITE:
								string name = "";
								for(int t = 0;data[ after + t + 6 ] != 0;t++ )
									name += "" + (char)data[ after + t + 6 ];
								loggedChar.GroupInvite( name );
							break;
						case (int)OpCodes.CMSG_LEARN_TALENT:
							loggedChar.LearnTalent( BitConverter.ToInt32( data, after + 6 ), BitConverter.ToInt32( data, after + 10 ) );
							break;
						case (int)OpCodes.CMSG_GROUP_ACCEPT:	
							loggedChar.GroupAccept();
							break;
						case (int)OpCodes.CMSG_GROUP_DISBAND:	
							loggedChar.QuitGroup();
							break;
						case (int)OpCodes.CMSG_GROUP_UNINVITE:	
							string uname = "";
							for(int t = 0;data[ after + t + 6 ] != 0;t++ )
								uname += "" + (char)data[ after + t + 6 ];
							loggedChar.GroupUninvite( uname );
							break;
						case (int)OpCodes.CMSG_GROUP_SET_LEADER:	
							string lname = "";
							for(int t = 0;data[ after + t + 6 ] != 0;t++ )
								lname += "" + (char)data[ after + t + 6 ];
							loggedChar.GroupSetLeader( lname );
							break;
						case (int)OpCodes.CMSG_GROUP_DECLINE:	
							loggedChar.GroupDecline();
							break;							
						case (int)OpCodes.CMSG_FORCE_RUN_SPEED_CHANGE_ACK:
							loggedChar.ForceSpeedAck();
							break;
						case (int)OpCodes.CMSG_AREATRIGGER:
							if (Character.onAreaTrigger != null)
								loggedChar.AreaTrigger( BitConverter.ToInt32( data, after + 6 ) );
							break;
						case (int)OpCodes.CMSG_TAXINODE_STATUS_QUERY:
							Taxi.OnCMSG_TAXINODE_STATUS_QUERY( loggedChar );
							break;
						case (int)OpCodes.CMSG_TAXIQUERYAVAILABLENODES:
							Taxi.OnCMSG_TAXIQUERYAVAILABLENODES( loggedChar );
							break;
						case (int)OpCodes.CMSG_ACTIVATETAXI:
							Taxi.OnCMSG_ACTIVATETAXI(loggedChar,BitConverter.ToUInt32( data, after + 14 ),BitConverter.ToUInt32( data, after + 18 ));
					//		HexViewer.View( data, after, length );
							break;
						case (int)OpCodes.CMSG_CANCEL_CHANNELLING:
							loggedChar.ChannelEnd();
							break;
						case (int)OpCodes.CMSG_BINDER_ACTIVATE:
						//	UInt64 fromg = BitConverter.ToUInt64( data, after + 12 );
						//	Mobile from = loggedChar.Player.FindMobileByGuid( fromg );
						//	Character.onBinderActivate( loggedChar, from, BitConverter.ToInt32( data, after + 6 ) );
							break;
						case (int)OpCodes.CMSG_GOSSIP_HELLO:
						{
							UInt64 fromh = BitConverter.ToUInt64( data, after + 6 );
							loggedChar.GossipHello( fromh );
							break;
						}
						case (int)OpCodes.CMSG_BUY_ITEM_IN_SLOT:
						{
							UInt64 fromseller = BitConverter.ToUInt64( data, after + 6 );
							int itemid = BitConverter.ToInt32( data, after + 0xe );
							byte slot = data[ after + 0x1A ];
							byte n = data[ after + 0x1B ];
							loggedChar.Buy( fromseller, itemid, (Slots)slot, n );
							break;
						}
						case (int)OpCodes.CMSG_LOOT_METHOD:
						{
							loggedChar.SetLootMethod( BitConverter.ToInt32( data, after + 0x6 ) );
							break;
						}
						case (int)OpCodes.CMSG_FRIEND_LIST:
						{
							loggedChar.SendFriendList();
							break;
						}
						case (int)OpCodes.CMSG_WHO:
						{
							loggedChar.WhoIsRequest();
							break;
						}
						case (int)OpCodes.CMSG_ADD_FRIEND:
						{
							string addf = "";
							for(int t = 0;data[ after + t + 6 ] != 0;t++ )
								addf += "" + (char)data[ after + t + 6 ];
							loggedChar.AddFriend( addf );
							break;
						}
						case (int)OpCodes.CMSG_SPIRIT_HEALER_ACTIVATE:
						{
							loggedChar.ReclaimCorps();
							break;
						}
							
						default:
							if ( code != 0x2CE )
								Console.WriteLine( "{2} : Receive unknown command {0} ({1})", (OpCodes)code, code.ToString( "X4" ), loggedChar.Name );
							if ( code > 0x330 )
							{							
								Console.WriteLine("");
								Console.WriteLine("{0} kicked", playerAccount.Username );
								playerAccount.Loggout( loggedChar.Guid );
								//playerAccount.StopPacketHandler();							
								this.Dispose();
							}
						
							break;
					}*/
					if ( len + 2 < ( length - after ) )
					{
						//	Console.WriteLine( "Partiel {0} sur {1}/{2}", after, len, length );
						after += ( len + 2 );
					}
					else 
					{
						//	Console.WriteLine( "Fin" );
						after = -1;
					}
				}
				return null;
#if !DEBUG
			}
			catch( Exception e )
			{
				if ( alreadyCrashed )
					return null;
				alreadyCrashed = true;
				string info1 = "";
				if ( playerAccount != null )
					info1 += "Account " + playerAccount.Username;
				if ( loggedChar != null )
					info1 += " character " + loggedChar.Name;
				info1 += " cause a crash";
				Console.WriteLine( info1 );
				Console.WriteLine( e.Message );
				Console.WriteLine( e.Source );
				Console.WriteLine( e.StackTrace );
				if ( this.loggedChar == null )
					Console.Write( "{0}:{1}:{2} NULL {3} <-- ", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, this.IP.ToString() );
				else
					Console.Write( "{0}:{1}:{2} {3} {4} <-- ", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, this.IP.ToString(), this.loggedChar.Guid );
				Console.WriteLine("Code {2} Len {0} After {1}", len, after, code );
				HexViewer.View( data, after, len + 2 );
				/*World.allConnectedAccounts.SendMessageToConnectedGM( info1 );
				World.allConnectedAccounts.SendMessageToConnectedGM( e.Message );
				World.allConnectedAccounts.SendMessageToConnectedGM( e.Source );
				World.allConnectedAccounts.SendMessageToConnectedGM( e.StackTrace );*/
				playerAccount.Loggout( 0 );
				this.Dispose();
				if ( MainConsole.sw1 != null )
					MainConsole.sw1.Flush();
				alreadyCrashed = false;
				return null;				
			}
#endif
		}

		public void Logout()
		{
			if ( loggedChar != null )
				playerAccount.Loggout( loggedChar.Guid );
		}

		private class UpdateTimer : WowTimer
		{
			PlayerHandler playerHangler;
			Character loggedChar;
			public UInt64 increment = 0;

			public UpdateTimer( PlayerHandler ph, Character lc ) : base( WowTimer.Priorities.Milisec10 , 50, "UpdateTimer" )
			{
				playerHangler = ph;
				loggedChar = lc;
				Start();
			}
			public override void OnTick()
			{
				byte []self = { 0x95, 0xA9, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x25, 0x30, 0x15, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1C, 0x00, 0x00, 0x80, 0x0F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3E, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
				int t = 9;
				Converter.ToBytes( loggedChar.Guid, self, ref t );
				t = 0x96 - 8;
				Converter.ToBytes( increment++, self, ref t );
				
				/*
				foreach( Mobile m in World.allMobiles )
				{
					if ( m.Distance( loggedChar ) < 200 )
					{
						playerHangler.Send( 0xA9, new byte[]{ 0x00, 0xB9, 0xA9, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x78, 0x56, 0x34, 0x12, 0x00, 0x00, 0x00, 0x00, 0x1C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0C, 0x0F, 0x00, 0x3C, 0x00, 0x3C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xD5, 0x2F, 0x15, 0x00, 0x00, 0x00, 0x00, 0x00, 0xD6, 0x2F, 0x15, 0x00, 0x00, 0x00, 0x00, 0x00, 0xD7, 0x2F, 0x15, 0x00, 0x00, 0x00, 0x00, 0x00, 0xD9, 0x2F, 0x15, 0x00, 0x00, 0x00, 0x00, 0x00, 0xD8, 0x2F, 0x15, 0x00, 0x00, 0x00, 0x00, 0x00, 0xDA, 0x2F, 0x15, 0x00, 0x00, 0x00, 0x00, 0x00, 0xDB, 0x2F, 0x15, 0x00, 0x00, 0x00, 0x00, 0x00} );
					}
				}*/
				base.OnTick ();
			}
		}
	}
}
