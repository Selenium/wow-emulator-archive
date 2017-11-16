using System;
using HelperTools;
//using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System.IO;
using System.Net;
using System.Collections;
using System.Threading;
using System.Diagnostics;
using System.Xml; 

namespace Server
{

	public enum AccessLevels
	{
		PlayerLevel,
		GM,
		Admin
	}
	/// <summary>
	/// Summary description for Account.
	/// </summary>
	public class Account
	{
		string username;
		string password;
		IPAddress ip;
		int port;
		public byte []k;
		public ArrayList characteres = new ArrayList();
		PlayerHandler handler;
		Character selectedChar;
		public DateTime lastHeartBeat = DateTime.Now;
		AutoDeconnect autoDeconnectTimer;
		//	int newOne = 0;//	quand un perso viens d'etre créé
		AccessLevels accessLevel;
		public bool justLogged = true;
		Queue packets = new Queue();
		Mutex mutex = new Mutex();
	
		

		//	public, no serialisation		
		public bool realylogged;
		public InternalPacketTimer packetHandler;
		public byte []SS_Hash;
		ArrayList playersNear = new ArrayList();
		ArrayList knownObject = new ArrayList();//	Liste des objets que le client connait
		ArrayList toSendFirstTime = new ArrayList();//	Liste des objets demandant un fullupdate

		#region ACCESSOR
		public bool Realylogged
		{
			get { return realylogged; }
		}
		public ArrayList KnownObjects
		{
			get { return knownObject; }
		}
		public ArrayList PlayersNear
		{
			get { return playersNear; }
		}
		public Queue Packets
		{
			get { return packets; }
			set { packets = value; }
		}
		public Mutex ExMutuel
		{
			get { return mutex; }
		}
		#endregion

		#region CONSTRUCTORS
		public Account()
		{			
		}

		public Account( string u, string p ) : this()
		{
			username = u;
			password = p;
		}

		public Account( string u, string p, AccessLevels al ) : this( u, p )
		{
			accessLevel = al;
		}

		public Account( GenericReader gr )
		{
			Deserialize( gr );
		}
		#endregion

		private class AutoDeconnect : WowTimer
		{
			Account from;
			public AutoDeconnect( Account acc ) : base( WowTimer.Priorities.Second5, 10000, "AutoDeconnect" )
			{
				from = acc;
				Start();
			}
			public override void OnTick()
			{
				TimeSpan ts = from.lastHeartBeat.Subtract( DateTime.Now );
				if ( ts.TotalSeconds > 30 )
					from.Loggout( from.SelectedChar.Guid );
				base.OnTick();
				Stop();
			}

		}

		#region SERIALISATION
		public void Deserialize( GenericReader gr )
		{			
			characteres.Clear();
			/*
			int version = gr.ReadInt();
			username = gr.ReadString();
			password = gr.ReadString();
			accessLevel = (AccessLevels)gr.ReadInt();
			int nChar = gr.ReadInt();
			for(int t = 0;t < nChar;t++ )
			{
				UInt64 guid = gr.ReadInt64();
				Character character = (Character)World.FindMobileByGUID( guid );
				if ( character != null )
				{
					characteres.Add( character );
					World.allMobiles.Remove( character );
				}
			}*/
		}

		public void Serialize( GenericWriter gw )
		{
			gw.Write( (int)0 );
			gw.Write( username );
			gw.Write( password );
			gw.Write( (int)accessLevel );
			gw.Write( (int)characteres.Count );
			foreach( Character c in characteres )
			{
				gw.Write( c.Guid );
			}
		}


			#region Const (name of attributes change there) 
			protected static string xml_attr_username      = "name"; 
			protected static string xml_attr_password      = "pass"; 
			protected static string xml_attr_accesslevel   = "plevel"; 
			protected static string xml_attr_guid         = "guid"; 
			#endregion 

			/// <summary> 
			/// Create new Account, Load all info for acc from xml node 
			/// </summary> 
			/// <param name="version">version for loading</param> 
			/// <param name="node">load from</param> 
			/// <param name="doc">recursive reference for checking</param> 
			/// <returns>Loaded Account</returns> 
			public Account( int version, XmlNode node, XmlFile doc ) 
			{ 
				if ( version == 1 ) 
				{ 
					username      = doc.GetAttributeVal( node, xml_attr_username, null ); 
					password      = doc.GetAttributeVal( node, xml_attr_password, null ); 
					accessLevel   = (AccessLevels)Convert.ToInt32( doc.GetAttributeVal( node, xml_attr_accesslevel, "0" ) ); 
					foreach ( XmlNode char_node in node.SelectNodes( xml_attr_guid ) ) 
					{ 
						UInt64 guid = UInt64.Parse( doc.GetInnerText( char_node, "0" ) ); 
						Character character = (Character)World.FindMobileByGUID( guid );
						if ( character != null )
						{
							characteres.Add( character );
							if ( World.StandardServer )
								World.allMobiles.Remove( character );
						}
					}
				}
			} 

			/// <summary> 
			/// Create xmlnode from all elements of Account record 
			/// </summary> 
			/// <param name="doc">recursive reference for creating node</param> 
			/// <returns>xmlnode with all info about acc</returns> 
			public XmlNode Save( XmlFile doc )//not a static !!! 
			{//current version=1 (Core.Accounts.version) 
				XmlNode result = doc.CreateNode( "account", "" ); 
				doc.AddAttribute( result, xml_attr_username, username ); 
				doc.AddAttribute( result, xml_attr_password, password ); 
				doc.AddAttribute( result, xml_attr_accesslevel, ((int)accessLevel).ToString() ); 

				foreach ( Character ch in characteres )                        //{+} Added 
				{ 
					UInt64 guid = ch.Guid;
					doc.AddNode( result, xml_attr_guid, guid.ToString() ); 
				} 

				return result; 
			}
			#endregion 
		


		public byte[]PrepareDataList( ref int  t )
		{
			byte []pack = new byte[ 2048 ];
			pack[ t++ ] = (byte)characteres.Count;
			foreach( Character c in this.characteres )
			{
				c.toData( ref pack, ref t );
			}
			return pack;
		}
		public void AddCharacter( byte []data )
		{
		//	newOne = 1;//	pour les nouveau perso
	/*		if ( characteres.Count > 7 )
			{
				byte []buff = new byte[] { 0x1, 0x34 };
				handler.Send( buff );
				return;
			}*/
			Character character = new Character( this, data );
			if ( character.Name != null )
				this.characteres.Add( character );
		}
		#region TIMERS
		public delegate bool PacketHandlerDelegate();
		public class InternalPacketTimer : WowTimer
		{
			PacketHandlerDelegate handler;
			public InternalPacketTimer( PacketHandlerDelegate ph ) : base( 20, "InternalPacketTimer" )
			{				
				handler = ph;
				Start();
			}
			public override void OnTick()
			{
				if ( handler() )
				{
					base.Stop();
					return;
				}
				base.OnTick ();
			}

		}
		#endregion

		public void StopPacketHandler()
		{
			if ( packetHandler != null )
				packetHandler.Stop();
			packetHandler = null;
			Ip = null;
		}
		//byte []waiting = null;
		int timeout = 0;
		public bool PacketHandler()
		{
			//	Console.WriteLine("PacketHandler {0} {1}", this.username, Packets.Count );
			//	ExMutuel.WaitOne();
			if ( Handler == null )
				Console.WriteLine("Handler == null ----> DrNexus" );
			if ( Handler.Disposed )
			{
				timeout++;
				//	Console.WriteLine("timeoutPacketHandler {0}", timeout );
				if ( timeout > 500 )
				{
					StopPacketHandler();
					timeout = 0;
					return true;
				}				
			}

			Packet p = null;
			if ( Packets == null )
				Console.WriteLine("Packets == null ----> DrNexus" );
			lock( Packets )
			{
				if ( Packets.Count > 0 )
				{
					p = (Packet)Packets.Dequeue();
				}
			}

			if ( p != null )
				Handler.DequeueData( p.data, p.len );				
			return false;
		}
		public void ToAllPlayerNear( OpCodes code, byte []data )
		{
			ToAllPlayerNear( code, data, data.Length );
		}
		// For mobs
		public void ToAllPlayerNear( Mobile m, OpCodes code, byte []data, int len )
		{
			if ( this.knownObject.Contains( m ) )//	safe
			{
				handler.Send( code, data, len );
			}
			if ( playersNear.Count == 0 )
				return;
			foreach( Character c in playersNear )
				if ( c.Player.KnownObjects.Contains( m ) )//	safe
				{
					c.Player.Handler.Send( code, data, len );
				}
		}

		public void ToAllPlayerNear( OpCodes code, byte []data, int len )
		{
			handler.Send( code, data, len );
			if ( playersNear.Count == 0 )
				return;
			foreach( Character c in playersNear )
				if ( c.Player.PlayersNear.Contains( this.SelectedChar ) )//	safe
				{
				//	if ( c.Player.Username == "trace" )
					{
					/*	Console.WriteLine("{0} : ", code );
						for( int t = 0;t < len;t++ )
							Console.Write( "{0} ", data[ t ].ToString( "X2" ) );
						Console.WriteLine("");*/
					}
					c.Player.Handler.Send( code, data, len );
				}
		}
		public void ToAllPlayerNear( OpCodes code, byte []data, int after, int len )
		{
			byte []ret = new byte[ len ];
			Buffer.BlockCopy( data, after, ret, 0, len );

			handler.Send( code, ret, len );
			if ( playersNear.Count == 0 )
				return;
			foreach( Character c in playersNear )
				if ( c.Player.PlayersNear.Contains( SelectedChar ) )//	safe
				{
				//	if ( c.Player.Username == "trace" )
					{
					/*	Console.WriteLine("{0} : ", code );
						for( int t = 0;t < len;t++ )
							Console.Write( "{0} ", data[ t + after ].ToString( "X2" ) );
						Console.WriteLine("");*/
					}
					c.Player.Handler.Send( code, ret, len );
				}
		}
		public void ToAllPlayerNearExceptMe( OpCodes code, byte []data, int after, int len )
		{
			byte []ret = new byte[ len ];
			Buffer.BlockCopy( data, after, ret, 0, len );
			ToAllPlayerNearExceptMe( code, ret, len );
		}
		public void ToAllPlayerNearExceptMe( OpCodes code, byte []data, int len )
		{
			if ( playersNear.Count == 0 )
				return;
			foreach( Character c in playersNear )
				if ( c.Player.PlayersNear.Contains( SelectedChar ) )//	safe
				{
				//	if ( c.Player.Username == "trace" )
					{
					/*	Console.WriteLine("{0} : ", code );
						for( int t = 0;t < len;t++ )
							Console.Write( "{0} ", data[ t ].ToString( "X2" ) );
						Console.WriteLine("");*/
					}
					c.Player.Handler.Send( code, data, len );
				}
		}
		public void MvtToAllPlayerNear( int code, byte []data, int after, int len )
		{
			if ( playersNear.Count == 0 )
				return;
			byte []dest = new byte[ len + 8 ];
			Buffer.BlockCopy( data, after + 4, dest, 10, len - 4 );
			UInt64 guid = selectedChar.Guid;

			foreach( Character c in playersNear )
				if ( c.Player != null && c.Player.PlayersNear.Contains( SelectedChar ) )//	safe
				{
				//	if ( c.Player.Username == "trace" )
					{
					/*	Console.WriteLine("{0} : ", code );
						for( int t = 0;t < len;t++ )
							Console.Write( "{0} ", data[ t + after ].ToString( "X2" ) );
						Console.WriteLine("");*/
					}
					int offset = 4;
					Converter.ToBytes( guid, dest, ref offset );
					c.Player.Handler.Send( code, dest, len + 8 );
				}
		}

		public Character FindPlayerNearByGuid( UInt64 guid )
		{
			foreach( Character c in playersNear )
			{
				if ( c.Guid == guid )
					return c;
			}
			return null;
		}

		public void PreLogin()
		{
	//		Console.WriteLine( "PreLogin" );
		//	waiting = null;
			packetHandler = new InternalPacketTimer( new PacketHandlerDelegate( PacketHandler ) );
		}



		public Character Login( UInt64 guid )
		{
			realylogged = true;
			justLogged = true;
			SelectedChar = null;
			foreach( Character ch in characteres )
				if ( ch.Guid == guid )
				{
					SelectedChar = ch;
					break;
				}
			if ( SelectedChar == null )
				return null;
			if ( knownObject != null )
				knownObject.Clear();
			if ( PlayersNear != null )
				playersNear.Clear();
			else
				playersNear = new ArrayList();
			selectedChar.Login( this );

			//			packetHandler = new InternalPacketTimer( new PacketHandlerDelegate( PacketHandler ) );
			

			/*byte []MD5 = { 0,0,0,0,0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
			
			0xD4,0x1D,0x8C,0xD9,0x8F,0x00,0xB2,0x04,0xE9,0x80,0x09,0x98,0xEC,0xF8,0x42,0x7E,
			0xE8,0xDF,0xCF,0xA1,0x06,0xBD,0xdf,0xE5,0x17,0xD0,0x57,0x0C,0xFF,0x0F,0xBC,0x44
			};*/
			//	Wad
			/*byte []MD5 = { 0,0,0,0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
			0xD4, 0x1D, 0x8C, 0xD9, 0x8F, 0x00, 0xB2, 0x04, 
			0xE9, 0x80, 0x09, 0x98, 0xEC, 0xF8, 0x42, 0x7E, 
			0xCE, 0xD6, 0x14, 0xB4, 0x93, 0x75, 0x11, 0x33, 
			0xA4, 0xA8, 0x21, 0x48, 0xFD, 0x75, 0xB1, 0xFF};*/
			byte []MD5 = new byte[ 84 ];
			Handler.Send( (int)OpCodes.SMSG_ACCOUNT_DATA_MD5, MD5 );

			//	SMSG_IGNORE_LIST
			Handler.Send( new byte[]{ 0x00, 0x04, 0x6B, 0x00, 0x00, 0x00 } );
			//	SMSG_FRIEND_LIST
			SelectedChar.SendFriendList();
			//Handler.Send( new byte[]{ 0x00, 0x04, 0x67, 0x00, 0x00, 0x00 } );
			//	SMSG_BINDPOINTUPDATE
			Handler.Send( new byte[]{ 0x00 , 0x16 , 0x55 , 0x01 , 0x8F , 0x02 , 0xC3 , 0xC5 , 0x39 , 0x84 , 0xA5 , 0x43 , 0x06 , 0x61 , 0xBF , 0x43 , 0x01 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 , 0x00 } );
			//	SMSG_SET_REST_START
			Handler.Send( (int)OpCodes.SMSG_SET_REST_START, new byte[] { 0,0,0,0, 0x4B, 0x71, 0x00 , 0x00 } );
			//	SMSG_SET_FLAT_SPELL_MODIFIER
			Handler.Send( (int)OpCodes.SMSG_SET_FLAT_SPELL_MODIFIER, new byte[] { 0,0,0,0, 0x06, 0x0A, 0x38 , 0xFF , 0xFF , 0xFF } );

			
			//	set tutorial flag
			Handler.Send( new byte[]{ 0x00 , 0x22 , 0xFD , 0x00 , 
										0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
										0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF } );
			//selectedChar.SendMessage( "0" );
			//	Trigger cinematic  SMSG_TRIGGER_CINEMATIC
			//	Handler.Send( new byte[]{ 0x00 , 0x06 , 0xFA , 0x00 , 0x65, 00, 00, 00 } );
			//Handler.Send( new byte[]{ 0x00 , 0x06 , 0xFA , 0x00 , 0x65 , 0x00 , 0x00 , 0x00 } );

			SelectedChar.SendAllSpells();
			SelectedChar.SendAllActionButtons();
			/*	
				//	SMSG_INITIALIZE_FACTIONS
				byte []fact = new byte[ 0x148 ];
				for(int y = 8;y< fact.Length;y+=5)
					fact[ y ] = 1;
				fact[ 4 ] = 0x40;
	//40 00 00 00 03 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 03 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 03 00 00 00 00 01 00 00 00 00 03 00 00 00 00 03 00 00 00 00 03 00 00 00 00 03 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 03 00 00 00 00 01 00 00 00 00 01 00 00 00 00 03 00 00 00 00 01 00 00 00 00 01 00 00 00 00 03 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 01 00 00 00 00 
				Handler.Send( 0x122, fact, fact.Length );//new byte[]{ 0x01 , 0x46 , 0x22 , 0x01 , 0x01, 0x02, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00 } );
				*/
			#region Reaction
			byte []buffReaction = new byte[]{ 0, 0, 0, 0, 0xff, 0, 0, 0,
												0x6A, 0x00, 0x61, 0x05, 
												0x00, 0x00, 0x60, 0x05, 
												0x00, 0x00, 0x5F, 0x05, 
												0x00, 0x00, 0x5E, 0x05, 
												0x00, 0x00, 0x5D, 0x05, 
												0x00, 0x00, 0x5C, 0x05, 
												0x00, 0x00, 0x5B, 0x05, 
												0x00, 0x00, 0x5A, 0x05, 
												0x00, 0x00, 0x59, 0x05, 
												0x00, 0x00, 0x58, 0x05, 
												0x00, 0x00, 0x57, 0x05, 
												0x00, 0x00, 0x56, 0x05, 
												0x0F, 0x27, 0x55, 0x05,
												0x00, 0x00, 0x54, 0x05, 
												0x01, 0x00, 0x53, 0x05, 
												0x01, 0x00, 0x52, 0x05, 
												0x01, 0x00, 0x51, 0x05, 
												0x01, 0x00, 0x4F, 0x05, 
												0x00, 0x00, 0x4E, 0x05, 
												0x00, 0x00, 0x4D, 0x05, 
												0x01, 0x00, 0x4C, 0x05, 
												0x00, 0x00, 0x4B, 0x05, 
												0x00, 0x00, 0x45, 0x05, 
												0x00, 0x00, 0x43, 0x05, 
												0x01, 0x00, 0x42, 0x05, 
												0x00, 0x00, 0x40, 0x05, 
												0x00, 0x00, 0x3F, 0x05, 
												0x00, 0x00, 0x3E, 0x05, 
												0x01, 0x00, 0x3D, 0x05, 
												0x00, 0x00, 0x3C, 0x05, 
												0x00, 0x00, 0x3B, 0x05, 
												0x00, 0x00, 0x3A, 0x05, 
												0x01, 0x00, 0x39, 0x05, 
												0x00, 0x00, 0x38, 0x05, 
												0x00, 0x00, 0x37, 0x05, 
												0x00, 0x00, 0x34, 0x05, 
												0x00, 0x00, 0x33, 0x05, 
												0x00, 0x00, 0x30, 0x05, 
												0x00, 0x00, 0x2F, 0x05, 
												0x00, 0x00, 0x2D, 0x05, 
												0x01, 0x00, 0x16, 0x05, 
												0x01, 0x00, 0x15, 0x05, 
												0x00, 0x00, 0xB6, 0x03, 
												0x00, 0x00, 0x45, 0x07, 
												0x02, 0x00, 0x36, 0x07, 
												0x01, 0x00, 0x35, 0x07, 
												0x01, 0x00, 0x34, 0x07, 
												0x01, 0x00, 0x33, 0x07, 
												0x01, 0x00, 0x32, 0x07, 
												0x01, 0x00, 0x02, 0x07, 
												0x00, 0x00, 0x01, 0x07, 
												0x00, 0x00, 0x00, 0x07, 
												0x00, 0x00, 0xFE, 0x06, 
												0x00, 0x00, 0xFD, 0x06, 
												0x00, 0x00, 0xFC, 0x06, 
												0x00, 0x00, 0xFB, 0x06, 
												0x00, 0x00, 0xF8, 0x06, 
												0x00, 0x00, 0xF7, 0x06, 
												0x00, 0x00, 0xF6, 0x06, 
												0x00, 0x00, 0xF4, 0x06, 
												0xD0, 0x07, 0xF2, 0x06, 
												0x00, 0x00, 0xF0, 0x06, 
												0x00, 0x00, 0xEF, 0x06, 
												0x00, 0x00, 0xEC, 0x06, 
												0x00, 0x00, 0xEA, 0x06, 
												0x00, 0x00, 0xE9, 0x06, 
												0x00, 0x00, 0xE8, 0x06, 
												0x00, 0x00, 0xE7, 0x06, 
												0x00, 0x00, 0x18, 0x05, 
												0x00, 0x00, 0x17, 0x05, 
												0x00, 0x00, 0x03, 0x07, 
												0x00, 0x00, 0xF9, 0x06, 
												0x00, 0x00, 0xF3, 0x06, 
												0x00, 0x00, 0xF1, 0x06, 
												0x00, 0x00, 0xEE, 0x06, 
												0x00, 0x00, 0xED, 0x06, 
												0x00, 0x00, 0x71, 0x05, 
												0x00, 0x00, 0x70, 0x05, 
												0x00, 0x00, 0x67, 0x05, 
												0x01, 0x00, 0x66, 0x05, 
												0x01, 0x00, 0x50, 0x05, 
												0x01, 0x00, 0x44, 0x05, 
												0x00, 0x00, 0x36, 0x05, 
												0x00, 0x00, 0x35, 0x05, 
												0x01, 0x00, 0x32, 0x05, 
												0x01, 0x00, 0x31, 0x05, 
												0x00, 0x00, 0x2E, 0x05, 
												0x00, 0x00, 0xC6, 0x03, 
												0x00, 0x00, 0xC4, 0x03, 
												0x00, 0x00, 0xC2, 0x03, 
												0x00, 0x00, 0xA3, 0x07, 
												0x0F, 0x27, 0x74, 0x05, 
												0x00, 0x00, 0x73, 0x05, 
												0x00, 0x00, 0x72, 0x05, 
												0x00, 0x00, 0x6F, 0x05, 
												0x00, 0x00, 0x6E, 0x05, 
												0x00, 0x00, 0x6D, 0x05, 
												0x00, 0x00, 0x6C, 0x05, 
												0x00, 0x00, 0x6B, 0x05, 
												0x00, 0x00, 0x6A, 0x05, 
												0x01, 0x00, 0x69, 0x05, 
												0x01, 0x00, 0x68, 0x05, 
												0x01, 0x00, 0x65, 0x05, 
												0x00, 0x00, 0x64, 0x05, 
												0x00, 0x00, 0x63, 0x05, 
												0x00, 0x00, 0x62, 0x05, 
												0x00, 0x00};
								


			Handler.Send( 0x121/*OpCodes.SMSG_INITIALIZE_FACTIONS*/, buffReaction, buffReaction.Length );
			#endregion


			//	SMSG_LOGIN_SETTIMESPEED
			Handler.Send( new byte[] { 0x00, 0x0A, 0x42, 0x00, 0x0C, 0xC9, 0x16, 0x05, 0x89, 0x88, 0x88, 0x3C } );
			//	SMSG_CORPSE_RECLAIM_DELAY
			Handler.Send( (int)OpCodes.SMSG_CORPSE_RECLAIM_DELAY, new byte[]{ 0x01 , 0x46 , 0x22 , 0x01 ,00, 00, 00, 00 } );
			byte []buffTime = new byte[ 4 + 4 + 4 ];
			int offset = 4;
			Converter.ToBytes( World.GetActualTime(), buffTime, ref offset );
			Converter.ToBytes( (float)0.017f, buffTime, ref offset );
			Handler.Send( (int)OpCodes.SMSG_LOGIN_SETTIMESPEED, buffTime );
			
			//selectedChar.SendMessage( "1" );
			
			byte []part = new byte[ 0xF0 ];
			offset = 4;

			RefreshFactionReactions();

			World.allConnectedChars.Add( selectedChar );
			World.allConnectedAccounts.Add( this );
			World.allMobiles.Add( selectedChar );
			this.knownObject.Add( selectedChar );
			toSendFirstTime.Add( selectedChar );
			selectedChar.FullUpdate( knownObject );			
			selectedChar.ItemsUpdate();
			if ( selectedChar.Summon != null )
				selectedChar.SendPetActionBar();
			HeartBeat();
			//		RefreshMobileList( true );
			autoDeconnectTimer = new AutoDeconnect( this );

			SelectedChar.OnLogin();
			//Ready = true;
			return SelectedChar;
		}

		public void RefreshFactionReactions()
		{
			IDictionaryEnumerator e = SelectedChar.ReputationAdjustments.GetEnumerator();
			while ( e.MoveNext() )
			{
				int offset = 4;
				Converter.ToBytes( 1, SelectedChar.tempBuff, ref offset );
				Converter.ToBytes( (int)e.Key, SelectedChar.tempBuff, ref offset );
				Converter.ToBytes( (int)e.Value, SelectedChar.tempBuff, ref offset );
				SelectedChar.Send( OpCodes.SMSG_SET_FACTION_STANDING, SelectedChar.tempBuff, offset );
			}			
		}

		public class LoggoutTimer : WowTimer
		{
			Account from;
			public LoggoutTimer( Account acc ) : base( WowTimer.Priorities.Second, 3000, "LoggoutTimer" )
			{
				from = acc;
				if ( from.selectedChar == null )//	already loggout
					Stop();
				Start();
			}
			public override void OnTick()
			{
				if ( from.selectedChar == null )//	already loggout
					Stop();
				else
				{
					from.Handler.Send( (int)OpCodes.SMSG_LOGOUT_COMPLETE, new byte[] { 0, 0, 0, 0 } );
					from.Loggout( from.SelectedChar.Guid );
				}
				base.OnTick();
				Stop();
			}
		}
		public LoggoutTimer loggoutTimer;
		public void LoggoutStartTimer()
		{
			LoggoutTimer loggoutTimer = new LoggoutTimer( this );			
		}
		public void CancelLogout()
		{
			if ( loggoutTimer != null )
			{
				loggoutTimer.Stop();
				loggoutTimer = null;
				Handler.Send( OpCodes.SMSG_LOGOUT_CANCEL_ACK, new Byte[] { 0,0,0,0 } );
			}
		}
		public void Loggout( UInt64 guid )
		{		
			realylogged = false;
			if ( SelectedChar != null )
			{			
				SelectedChar.ReleaseAllAura();
				//if ( SelectedChar.gu != null )
				//	SelectedChar.CancelDuel();
				SelectedChar.QuitGroup();
			//	Console.WriteLine("{0} logout", SelectedChar.Name );
				SelectedChar.OnLogout();				
				World.allConnectedChars.Remove( selectedChar );
			}
		//	if ( packetHandler != null )
		//		packetHandler.Stop();	
		//	packetHandler = null;
			if ( World.allConnectedAccounts.Contains( this ) )
                World.allConnectedAccounts.Remove( this );
			if ( SelectedChar != null )
				World.allMobiles.Remove( selectedChar );
			playersNear = new ArrayList();
			knownObject = new ArrayList();
			Ip = null;
			SelectedChar = null;
		}

		public bool TestIfLoggout()
		{
			if ( selectedChar == null )
				return false;
			TimeSpan ts = DateTime.Now.Subtract( lastHeartBeat );
			if ( ts.TotalSeconds > 60 )
			{
				Loggout( 0 );
				return true;
			}
			return false;
		}

		int slowSpawnDelay = 0;
		Position lastRefreshPos = new Position( 0, 0, 0, 0 );
		public void RefreshMobileList()
		{
			RefreshMobileList( false );
		}
		
		public void RefreshMobileList( bool force )
		{
			if ( selectedChar == null )
				return;
			if ( !force )
			{
				if ( lastRefreshPos.QuickDistance( selectedChar as Mobile ) < 10 * 10 )
					return;
				lastRefreshPos = new Position( selectedChar.X, selectedChar.Y, selectedChar.Z, selectedChar.MapId );
			}
			ArrayList ko = new ArrayList();
			ko.Add( selectedChar );

			toSendFirstTime.Clear();
			if ( selectedChar.Summon != null )
			{
				ko.Add( selectedChar.Summon );
				if ( !knownObject.Contains( selectedChar.Summon ) )
					toSendFirstTime.Add( selectedChar.Summon );
			}
			foreach( Character ch in World.allConnectedChars )
			{
				if ( knownObject.Contains( ch ) )
				{
					ko.Add( ch );
					if ( ch.Summon != null )
						ko.Add( ch.Summon );
				}
				else
					if ( ch.Distance( selectedChar ) < 150 * 150 )
				{//	l'objet n'est pas connu du client
					toSendFirstTime.Add( ch );
					if ( ch.Summon != null )
						toSendFirstTime.Add( ch.Summon );
					if ( ch != selectedChar )
						playersNear.Add( ch );
				}
			}
			if ( selectedChar.LinkedSpawner == -1 || selectedChar.QuickDistance( World.allSpawners[ selectedChar.LinkedSpawner ] as BaseSpawner ) > 75 * 75 )
			{
				int dist = int.MaxValue;
				int m = selectedChar.MapId;
				for( int t = 0;t < World.allSpawners.Count;t++ )					
				{
					BaseSpawner bs = World.allSpawners[ t ] as BaseSpawner;
					if ( bs.MapId != m )
						continue;
					int odist = bs.QuickDistance( selectedChar );
					if ( odist < dist )
					{
						dist = odist;
						selectedChar.LinkedSpawner = t;
					}
				}
			}
			if ( selectedChar.LinkedSpawner != -1 )
			{
				ArrayList al = World.regSpawners[ selectedChar.LinkedSpawner ] as ArrayList;
				if ( al != null )
				{
					int bestt = selectedChar.LinkedSpawner;
					BaseSpawner best = World.allSpawners[ bestt ] as BaseSpawner;
					int dist = best.QuickDistance( selectedChar );	
					//selectedChar.SendMessage( "On " + al.Count.ToString() );
					for(int t = -1;t < al.Count;t++ )
					{
						BaseSpawner bs = best;
						if ( t >= 0 )
						{
							int ind = (int)al[ t ];
							if ( ind >= 0 )
							{
								bs = (BaseSpawner)World.allSpawners[ ind ];
								int d = bs.QuickDistance( selectedChar );
								if ( d < dist )
								{
									d = dist;
									bestt = (int)al[ t ];
								}
							}
						}
						bs.StillActive( selectedChar );
						if ( this.accessLevel != AccessLevels.PlayerLevel )
						{
							if ( knownObject.Contains( bs ) )
								ko.Add( bs );
							else
							{//	l'objet n'est pas connu du client
								toSendFirstTime.Add( bs );
							}
						}
						foreach( Object m in bs.Objects )
						{
							if ( selectedChar.CanSee( m ) )//selectedChar.Distance( m ) < 300 * 300 * 2 )
							{
								if ( m is BaseCreature )
									( m as BaseCreature ).StillActive( selectedChar );
							{
								if ( knownObject.Contains( m ) )
								{
									ko.Add( m );									
								}
								else
								{//	l'objet n'est pas connu du client
									toSendFirstTime.Add( m );
								}
							}
							}
						}
					}
					selectedChar.LinkedSpawner = bestt;					
				}
			}

			foreach( Object m in knownObject )
			{
				if ( /*m != selectedChar && */!ko.Contains( m ) )
				{//	l'objet n'est plus dans la zone du joueur	
					selectedChar.DestroyObject( m.Guid );
					if ( m is Character )
						playersNear.Remove( m );
				}				
			}

			knownObject = ko;
			if ( justLogged )
			{				
				selectedChar.FullUpdate( toSendFirstTime );	
				foreach( Object m in toSendFirstTime )
					if ( m is Character && m != selectedChar )	
						( m as Character ).ItemsUpdateForOther( this );
				selectedChar.ItemsUpdate();
				if ( selectedChar.Summon != null )
					selectedChar.SendPetActionBar();
			}
			else
			{
				selectedChar.PartialUpdate( toSendFirstTime );
				foreach( Object m in toSendFirstTime )
					if ( m is Character && m != selectedChar )					
						( m as Character ).ItemsUpdateForOther( this );
			}
			knownObject.AddRange( toSendFirstTime );
			toSendFirstTime.Clear();	
#if DEBUG
			selectedChar.SendMessage( "K : " + knownObject.Count.ToString() );
#endif
		}
		
		
		public void RefreshMobileListOld( bool force )
		{
			if ( selectedChar == null )
				return;
			ArrayList ko = new ArrayList();
			ko.Add( selectedChar );
			toSendFirstTime.Clear();

			ArrayList myZone = World.allMobiles.GetContinent( selectedChar.MapId );
			if ( ( !force && lastRefreshPos.QuickDistance( selectedChar ) < 150 * 150 ) )
			{
				return;
			}
		//	Console.WriteLine("RefreshMobileList5");
			slowSpawnDelay++;
			lastRefreshPos = new Position( selectedChar.X, selectedChar.Y, selectedChar.Z, selectedChar.MapId );
//Console.WriteLine("RefreshMobileList6");
			if ( this.accessLevel != AccessLevels.PlayerLevel )
			{
			//	Console.WriteLine("RefreshMobileList7");
				int zone = 0;
				if ( World.zones[ selectedChar.ZoneId ] != null )
				{
					zone = (int)World.zones[ selectedChar.ZoneId ];
				}
				ArrayList sl = World.allSpawners.Nearest( selectedChar.MapId * 1024 + zone );
				if ( sl != null )
				{
#if DEBUG
						selectedChar.SendMessage( "RefreshMobileList " + sl.Count.ToString() + "; " + selectedChar.ZoneId.ToString() + "; " + zone.ToString() );
#endif
					foreach( BaseSpawner m in sl )
					{
				/*		if ( m.Guid == 0xF10000000026A059 )
							{
								selectedChar.SendMessage( "Dist : " + selectedChar.Distance( m ).ToString() );							
							}*/
						float dist = selectedChar.Distance( m );
					/*	if ( dist < 50 * 50 )
						{
							m.StillActive( selectedChar, false );
							if ( knownObject.Contains( m ) )
								ko.Add( m );
							else
							{//	l'objet n'est pas connu du client
								toSendFirstTime.Add( m );
							}
						}
						else*/
						if ( dist < 300 * 300 )
						{
							m.StillActive( selectedChar );
							if ( knownObject.Contains( m ) )
								ko.Add( m );
							else
							{//	l'objet n'est pas connu du client
								toSendFirstTime.Add( m );
							}
						}
					}
				}
#if DEBUG
					else
						selectedChar.SendMessage("No spawn here ! " + zone.ToString() );
#endif
			}
			else
			{
				int zone = 0;
				if ( World.zones[ selectedChar.ZoneId ] != null )
				{
					zone = (int)World.zones[ selectedChar.ZoneId ];
				}
				ArrayList sl = World.allSpawners.Nearest( selectedChar.MapId * 1024 + zone );
				if ( sl != null )
					foreach( BaseSpawner m in sl )
						if ( selectedChar.Distance( m ) < 300 * 300 )
							m.StillActive( selectedChar );
			}
			
			if ( myZone != null )		
			{
				foreach( Mobile m in myZone )
				{
					if ( selectedChar.CanSee( m ) )//selectedChar.Distance( m ) < 300 * 300 * 2 )
					{
						if ( m is BaseCreature )
							( m as BaseCreature ).StillActive( selectedChar );
					{
						if ( knownObject.Contains( m ) )
							ko.Add( m );
						else
						{//	l'objet n'est pas connu du client
							if ( !justLogged || m is Character ) 
								toSendFirstTime.Add( m );
							if ( m is Character && m != selectedChar )
								playersNear.Add( m );
						}
					}
					}
				}	
			}
			if ( !justLogged )
			{
				foreach( GameObject go in World.allGameObjects )
				{
					if ( go.SeenBy( selectedChar ) )
					{
						if ( knownObject.Contains( go ) )
							ko.Add( go );
						else
						{//	l'objet n'est pas connu du client
							toSendFirstTime.Add( go );
						}
					}
				}	
			}
			foreach( Object m in knownObject )
			{
				if ( /*m != selectedChar && */!ko.Contains( m ) )
				{//	l'objet n'est plus dans la zone du joueur					
					selectedChar.DestroyObject( m.Guid );
					if ( m is Character )
						playersNear.Remove( m );
				}				
			}

			knownObject = ko;
			if ( justLogged )
			{				
				selectedChar.FullUpdate( toSendFirstTime );	
				foreach( Object m in toSendFirstTime )
					if ( m is Character && m != selectedChar )	
						( m as Character ).ItemsUpdateForOther( this );
				selectedChar.ItemsUpdate();
				if ( selectedChar.Summon != null )
					selectedChar.SendPetActionBar();
			}
			else
			{
				selectedChar.PartialUpdate( toSendFirstTime );
				foreach( Object m in toSendFirstTime )
					if ( m is Character && m != selectedChar )					
						( m as Character ).ItemsUpdateForOther( this );
			}
//Console.WriteLine("RefreshMobileList23");
			knownObject.AddRange( toSendFirstTime );
			toSendFirstTime.Clear();	
		//	all = DateTime.Now.Subtract( optim );
		//	World.localTime[ 3 ] = all.Ticks;
			if ( justLogged )
			{
			//	Console.WriteLine("RefreshMobileList24");
				justLogged = false;
				RefreshMobileList( true );
		//		Console.WriteLine("RefreshMobileList25");
			}
			#if DEBUG
			selectedChar.SendMessage( "K : " + knownObject.Count.ToString() );
#endif
			//Console.WriteLine("RefreshMobileList26");
		}

		public void HeartBeat()
		{			
			lastHeartBeat = DateTime.Now;
			if ( selectedChar == null )
				return;
			RefreshMobileList( true );
		}

		public void DeleteChar( UInt64 guid )
		{
			Character todel = null;
			foreach( Character ch in characteres )
				if ( ch.Guid == guid )
				{
					todel = ch;
					break;
				}
			if ( todel == null )
				return;
			characteres.Remove( todel );
			byte []del = new byte[ 12 ];
			int offset = 4;
			Converter.ToBytes( guid, del, ref offset );
			
			Handler.Send( OpCodes.SMSG_CHAR_DELETE, del );
		}


		public Mobile FindMobileByGuid( UInt64 guid )
		{
			foreach( Object m in knownObject )
				if ( m.Guid == guid )
					return (Mobile)m;
			return null;
		}
		public Object FindObjectByGuid( UInt64 guid )
		{
			foreach( Object m in knownObject )
				if ( m.Guid == guid )
					return m;
			return null;
		}
		


		#region setsgets
	
		public AccessLevels AccessLevel
		{
			get { return accessLevel; }
			set { accessLevel = value; }
		}

		public string Username
		{
			get { return username; }
			set { username = value; }
		}
		public string Password
		{
			get { return password; }
			set { password = value; }
		}
		public PlayerHandler Handler
		{
			get { return handler; }
			set { 
				handler = value; 
				if ( value == null )
					Console.WriteLine("");
			}
		}
		public Character SelectedChar
		{
			get { return selectedChar; }
			set { selectedChar = value; }
		}
		public IPAddress Ip
		{
			get { return ip; }
			set { ip = value; }
		}
		public int Port
		{
			get { return port; }
			set { port = value; }
		}
		public byte[] K
		{
			get { return k; }
			set { k = value; }
		}
		#endregion

	}
}
