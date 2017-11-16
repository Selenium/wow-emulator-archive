using System;
using HelperTools;
using System.Threading;
using System.Collections;
using System.Reflection;
using Server.Items;
using System.IO;
using System.Diagnostics;
//using Server.Scripts.Properties;
//using Server.Scripts.Commands;

namespace Server
{
	public interface IInitialize
	{
	}
	/// <summary>
	/// Summary description for World.
	/// </summary>
	public class World
	{
		//	all the object list
		public static MobileList allMobiles;
		public static GameObjects allGameObjects;
		public static ArrayList allConnectedChars = new ArrayList();
		public static Accounts allAccounts;
		public static Accounts allConnectedAccounts = new Accounts();
		public static SpawnerList allSpawners = new SpawnerList();
		public static Trajets trajets;
		static Hashtable itemPool = new Hashtable();
		static Hashtable mobilePool = new Hashtable();
		static Hashtable questPool = new Hashtable();
		public static Hashtable QuestPool
		{
			get { return World.questPool; }
		}
		static Hashtable questPoolType = new Hashtable();
		public static MapZones mapZones;
		//	general timers part
		public static Queue []timers = new Queue[ 9 ];
		public static bool notEnded = true;
		long []lastCall = new long[ 9 ];
		WorldSave worldSaveTimer;
		public static Hashtable tempMobileCts = new Hashtable();
		public static Hashtable zoneIds = new Hashtable();
		public static Hashtable zones = new Hashtable();
		public static Hashtable map = new Hashtable();

		//	Globals
		public static FishingZones FishZones = new FishingZones();
		public static Loot[] FishLoot;
		public static int WorldSavingTimer;
		public static byte []tempBuff = new byte[ 1 * 1024 * 1024 ];
		public static string ServerIP = "127.0.0.1";
		public static string AllowHttpFrom = "0.0.0.0";
		public static string ServerName = "Dr Nexus test server";
		public static int ServerPort = 8085;
		public static int HttpServerPort = 8088;
		public static ArrayList Cemetery = new ArrayList();
		public static Hashtable Emote = new Hashtable();
		public static int DecayTime = 2 * 60 * 1000;
		public static Hashtable Locations = new Hashtable();
		public static string Version = "8.0";
		public static string ClientVer = "1.6.x";
		public static Hashtable MountsList = new Hashtable();
		public delegate void OnSaveDelegate();
		public static OnSaveDelegate onSave;
		public static Hashtable continent = new Hashtable();
		public static Hashtable continentZones = new Hashtable();
		public delegate void OnGetActualTime( ref int year, ref int month, ref int day, ref int dayOfTheWeek, ref int hour, ref int minute );
		public static OnGetActualTime onGetActualTime;
		public delegate bool OnHttpDataReceived( HttpConnection ch, byte []data, int lenght );
		public static OnHttpDataReceived onHttpDataReceived;
		public static ArrayList PendingGroup = new ArrayList();
		static bool loading = true;
		public static bool poolsReady = false;
		public static string Path = "./";
		public static float DropMultiplier = 1f;
		public static int DropGoldMultiplier = 1;
		public static bool FreeForAll = true;//	to allow everyone enter the server and create a free account
		public static bool nixSystem;
		public static Hashtable FriendRaces = new Hashtable();
		public static int []ViewingDistance = new int[ 61 ];
		public static Hashtable regSpawners = new Hashtable();
		public static bool DruidClassAvailable = true;
		public static bool HunterClassAvailable = true;
		public static bool PriestClassAvailable = true;
		public static bool WarriorClassAvailable = true;
		public static bool WarlockClassAvailable = true;
		public static bool MageClassAvailable = true;
		public static bool RogueClassAvailable = true;
		public static bool ShamanClassAvailable = true;
		public static bool PaladinClassAvailable = true;
		public static GameObjectsList GameObjectsAssociated = new GameObjectsList();
		#region For multi-server support
		public static bool RealmServer = false;
		public static bool StandardServer = true;
		#endregion

		#region ACCESSORS
		public static Hashtable MobilesPool
		{
			get
			{
				return mobilePool;
			}
		}
		public static Hashtable ItemsPool
		{
			get
			{
				return itemPool;
			}
		}
		public static bool Loading
		{
			get { return loading; }
		}
		#endregion

		#region WorldSave timer
		private class WorldSave : WowTimer
		{
			int timer;
			int every;
			public WorldSave( int time ) : base( WowTimer.Priorities.Minute , 60000, "WorldSave" )
			{
				every = time;
				Start();
			}
			public void Save()
			{
				string str = "Saving game...";
				allConnectedAccounts.BroadCastMessage( str );
				DateTime now = DateTime.Now;
				//allAccounts.Serialize( new GenericWriter( "accounts.bin" ) );
				GenericWriter gw = null;
				if ( File.Exists( World.Path + "accounts.4.xml" ) )
					File.Copy( World.Path + "accounts.4.xml", World.Path + "accounts.5.xml", true );
				if ( File.Exists( World.Path + "accounts.3.xml" ) )
					File.Copy( World.Path + "accounts.3.xml", World.Path + "accounts.4.xml", true );
				if ( File.Exists( World.Path + "accounts.2.xml" ) )
					File.Copy( World.Path + "accounts.2.xml", World.Path + "accounts.3.xml", true );
				if ( File.Exists( World.Path + "accounts.xml" ) )
					File.Copy( World.Path + "accounts.xml", World.Path + "accounts.2.xml", true );
				allAccounts.Save( World.Path + "accounts.xml" );
				if ( allGameObjects.Dirty )
				{
					allGameObjects.Serialize( gw = new GenericWriter( World.Path + "objects.bin" ) );
				}
				if ( trajets.Dirty )
				{
					if ( File.Exists( "coord.bin" ) )
						File.Copy( World.Path + "coord.bin", World.Path + "coord" + DateTime.Now.Ticks.ToString() + ".bin", true );
					trajets.Serialize( gw = new GenericWriter( World.Path + "coord.bin" ) );
				}
				if ( allSpawners.Dirty )
				{
					allSpawners.Serialize( gw = new GenericWriter( World.Path + "spawnpoints.bin" ) );
				}

				if ( File.Exists( World.Path + "savegame.4.bin" ) )
					File.Copy( World.Path + "savegame.4.bin", World.Path + "savegame.5.bin", true );
				if ( File.Exists( World.Path + "savegame.3.bin" ) )
					File.Copy( World.Path + "savegame.3.bin", World.Path + "savegame.4.bin", true );
				if ( File.Exists( World.Path + "savegame.2.bin" ) )
					File.Copy( World.Path + "savegame.2.bin", World.Path + "savegame.3.bin", true );
				if ( File.Exists( World.Path + "savegame.bin" ) )
					File.Copy( World.Path + "savegame.bin", World.Path + "savegame.2.bin", true );				

				gw = new GenericWriter( World.Path + "savegame.bin" );	
				allMobiles.Serialize( gw );
				foreach( Account acc in allAccounts )
					foreach( Character ch in acc.characteres )
					{
						gw.Write( (int)1 );
						ch.Serialize( gw );
					}
				gw.Write( (int)0 );
				gw.Close();

	
				if ( onSave != null )
					onSave();

				//GC.Collect();
				/*Process p = Process.GetCurrentProcess();
				Console.WriteLine("{0}",p.MinWorkingSet,p.MaxWorkingSet );*/
				TimeSpan ts = DateTime.Now.Subtract( now );
				str = "Game saved in " + ts.TotalSeconds.ToString() + " sec";
				allConnectedAccounts.BroadCastMessage( str );
			}
			public override void OnTick()
			{
				timer++;
				if ( every == timer )
				{
					Save();
					timer = 0;
				}
				base.OnTick ();
			}

		}
		#endregion

		#region CONSTRUCTOR
		//public ArrayList allItems = new ArrayList();
		Hashtable itemsHash = new Hashtable();
		public void AddItem( Type t )
		{
			ConstructorInfo []cts = t.GetConstructors();
		/*	Item i = (Item)cts[ 0 ].Invoke( null );		
			allItems.Add( i );
			int id = i.Id;			
			itemPool[ id ] = cts[ 0 ];
			*/
			
			itemPool[ itemsHash[ t.ToString() ] ] = cts[ 0 ];
		}
		public void AddMob( Type t )
		{

		}
		static Hashtable factionsAssociated = new Hashtable();
		public static Hashtable FactionAssociated
		{
			get { return factionsAssociated; }
		}
		public static ArrayList allMobs = new ArrayList();
		public World()
		{		
			#region Standard server
			if ( !RealmServer )
			{
				#region Zone Ids
				map[ 324 ] = 0;
				zones[ 324 ] = 45;
				zoneIds[ 324 ] = 56;
				map[ 327 ] = 0;
				zones[ 327 ] = 45;
				zoneIds[ 327 ] = 59;
				map[ 330 ] = 0;
				zones[ 330 ] = 330;
				zoneIds[ 330 ] = 60;
				map[ 332 ] = 1;
				zones[ 332 ] = 332;
				zoneIds[ 332 ] = 62;
				map[ 335 ] = 0;
				zones[ 335 ] = 45;
				zoneIds[ 335 ] = 65;
				map[ 341 ] = 0;
				zones[ 341 ] = 3;
				zoneIds[ 341 ] = 69;
				map[ 342 ] = 0;
				zones[ 342 ] = 3;
				zoneIds[ 342 ] = 70;
				map[ 343 ] = 0;
				zones[ 343 ] = 3;
				zoneIds[ 343 ] = 71;
				map[ 345 ] = 0;
				zones[ 345 ] = 3;
				zoneIds[ 345 ] = 73;
				map[ 346 ] = 0;
				zones[ 346 ] = 3;
				zoneIds[ 346 ] = 74;
				map[ 349 ] = 0;
				zones[ 349 ] = 47;
				zoneIds[ 349 ] = 77;
				map[ 351 ] = 0;
				zones[ 351 ] = 47;
				zoneIds[ 351 ] = 79;
				map[ 352 ] = 0;
				zones[ 352 ] = 47;
				zoneIds[ 352 ] = 80;
				map[ 353 ] = 0;
				zones[ 353 ] = 47;
				zoneIds[ 353 ] = 81;
				map[ 356 ] = 0;
				zones[ 356 ] = 47;
				zoneIds[ 356 ] = 82;
				map[ 359 ] = 1;
				zones[ 359 ] = 17;
				zoneIds[ 359 ] = 85;
				map[ 360 ] = 1;
				zones[ 360 ] = 215;
				zoneIds[ 360 ] = 86;
				map[ 361 ] = 1;
				zones[ 361 ] = 361;
				zoneIds[ 361 ] = 87;
				map[ 363 ] = 1;
				zones[ 363 ] = 14;
				zoneIds[ 363 ] = 89;
				map[ 367 ] = 1;
				zones[ 367 ] = 14;
				zoneIds[ 367 ] = 93;
				map[ 369 ] = 1;
				zones[ 369 ] = 14;
				zoneIds[ 369 ] = 95;
				map[ 372 ] = 1;
				zones[ 372 ] = 14;
				zoneIds[ 372 ] = 97;
				map[ 374 ] = 1;
				zones[ 374 ] = 14;
				zoneIds[ 374 ] = 99;
				map[ 375 ] = 1;
				zones[ 375 ] = 14;
				zoneIds[ 375 ] = 100;
				map[ 378 ] = 1;
				zones[ 378 ] = 17;
				zoneIds[ 378 ] = 102;
				map[ 380 ] = 1;
				zones[ 380 ] = 17;
				zoneIds[ 380 ] = 104;
				map[ 384 ] = 1;
				zones[ 384 ] = 17;
				zoneIds[ 384 ] = 107;
				map[ 385 ] = 1;
				zones[ 385 ] = 17;
				zoneIds[ 385 ] = 108;
				map[ 386 ] = 1;
				zones[ 386 ] = 17;
				zoneIds[ 386 ] = 109;
				map[ 388 ] = 1;
				zones[ 388 ] = 17;
				zoneIds[ 388 ] = 110;
				map[ 391 ] = 1;
				zones[ 391 ] = 17;
				zoneIds[ 391 ] = 112;
				map[ 394 ] = 0;
				zones[ 394 ] = 394;
				zoneIds[ 394 ] = 115;
				map[ 397 ] = 1;
				zones[ 397 ] = 215;
				zoneIds[ 397 ] = 118;
				map[ 1 ] = 0;
				zones[ 1 ] = 1;
				zoneIds[ 1 ] = 119;
				map[ 4 ] = 0;
				zones[ 4 ] = 4;
				zoneIds[ 4 ] = 122;
				map[ 8 ] = 0;
				zones[ 8 ] = 8;
				zoneIds[ 8 ] = 124;
				map[ 15 ] = 1;
				zones[ 15 ] = 15;
				zoneIds[ 15 ] = 128;
				map[ 18 ] = 0;
				zones[ 18 ] = 12;
				zoneIds[ 18 ] = 131;
				map[ 20 ] = 0;
				zones[ 20 ] = 40;
				zoneIds[ 20 ] = 132;
				map[ 21 ] = 0;
				zones[ 21 ] = 21;
				zoneIds[ 21 ] = 133;
				map[ 30 ] = 0;
				zones[ 30 ] = 30;
				zoneIds[ 30 ] = 138;
				map[ 32 ] = 0;
				zones[ 32 ] = 10;
				zoneIds[ 32 ] = 139;
				map[ 33 ] = 0;
				zones[ 33 ] = 33;
				zoneIds[ 33 ] = 140;
				map[ 35 ] = 0;
				zones[ 35 ] = 33;
				zoneIds[ 35 ] = 142;
				map[ 37 ] = 0;
				zones[ 37 ] = 33;
				zoneIds[ 37 ] = 144;
				map[ 38 ] = 0;
				zones[ 38 ] = 38;
				zoneIds[ 38 ] = 145;
				map[ 40 ] = 0;
				zones[ 40 ] = 40;
				zoneIds[ 40 ] = 146;
				map[ 42 ] = 0;
				zones[ 42 ] = 10;
				zoneIds[ 42 ] = 147;
				map[ 43 ] = 0;
				zones[ 43 ] = 33;
				zoneIds[ 43 ] = 148;
				map[ 47 ] = 0;
				zones[ 47 ] = 47;
				zoneIds[ 47 ] = 152;
				map[ 49 ] = 0;
				zones[ 49 ] = 22;
				zoneIds[ 49 ] = 153;
				map[ 51 ] = 0;
				zones[ 51 ] = 51;
				zoneIds[ 51 ] = 154;
				map[ 53 ] = 0;
				zones[ 53 ] = 12;
				zoneIds[ 53 ] = 155;
				map[ 55 ] = 0;
				zones[ 55 ] = 12;
				zoneIds[ 55 ] = 156;
				map[ 56 ] = 0;
				zones[ 56 ] = 12;
				zoneIds[ 56 ] = 157;
				map[ 61 ] = 0;
				zones[ 61 ] = 12;
				zoneIds[ 61 ] = 160;
				map[ 63 ] = 0;
				zones[ 63 ] = 12;
				zoneIds[ 63 ] = 162;
				map[ 66 ] = 1;
				zones[ 66 ] = 66;
				zoneIds[ 66 ] = 165;
				map[ 69 ] = 0;
				zones[ 69 ] = 44;
				zoneIds[ 69 ] = 167;
				map[ 70 ] = 0;
				zones[ 70 ] = 44;
				zoneIds[ 70 ] = 168;
				map[ 74 ] = 0;
				zones[ 74 ] = 8;
				zoneIds[ 74 ] = 171;
				map[ 76 ] = 0;
				zones[ 76 ] = 8;
				zoneIds[ 76 ] = 173;
				map[ 80 ] = 0;
				zones[ 80 ] = 12;
				zoneIds[ 80 ] = 175;
				map[ 82 ] = 451;
				zones[ 82 ] = 22;
				zoneIds[ 82 ] = 176;
				map[ 85 ] = 0;
				zones[ 85 ] = 85;
				zoneIds[ 85 ] = 179;
				map[ 86 ] = 0;
				zones[ 86 ] = 12;
				zoneIds[ 86 ] = 180;
				map[ 88 ] = 0;
				zones[ 88 ] = 12;
				zoneIds[ 88 ] = 181;
				map[ 89 ] = 0;
				zones[ 89 ] = 12;
				zoneIds[ 89 ] = 182;
				map[ 94 ] = 0;
				zones[ 94 ] = 10;
				zoneIds[ 94 ] = 184;
				map[ 96 ] = 0;
				zones[ 96 ] = 44;
				zoneIds[ 96 ] = 186;
				map[ 97 ] = 0;
				zones[ 97 ] = 44;
				zoneIds[ 97 ] = 187;
				map[ 101 ] = 0;
				zones[ 101 ] = 33;
				zoneIds[ 101 ] = 190;
				map[ 103 ] = 0;
				zones[ 103 ] = 33;
				zoneIds[ 103 ] = 191;
				map[ 106 ] = 0;
				zones[ 106 ] = 33;
				zoneIds[ 106 ] = 194;
				map[ 107 ] = 0;
				zones[ 107 ] = 40;
				zoneIds[ 107 ] = 195;
				map[ 115 ] = 0;
				zones[ 115 ] = 40;
				zoneIds[ 115 ] = 199;
				map[ 116 ] = 0;
				zones[ 116 ] = 8;
				zoneIds[ 116 ] = 200;
				map[ 118 ] = 0;
				zones[ 118 ] = 11;
				zoneIds[ 118 ] = 201;
				map[ 123 ] = 0;
				zones[ 123 ] = 33;
				zoneIds[ 123 ] = 204;
				map[ 126 ] = 0;
				zones[ 126 ] = 33;
				zoneIds[ 126 ] = 206;
				map[ 127 ] = 0;
				zones[ 127 ] = 33;
				zoneIds[ 127 ] = 207;
				map[ 128 ] = 0;
				zones[ 128 ] = 33;
				zoneIds[ 128 ] = 208;
				map[ 129 ] = 0;
				zones[ 129 ] = 33;
				zoneIds[ 129 ] = 209;
				map[ 132 ] = 0;
				zones[ 132 ] = 1;
				zoneIds[ 132 ] = 212;
				map[ 133 ] = 0;
				zones[ 133 ] = 1;
				zoneIds[ 133 ] = 213;
				map[ 135 ] = 0;
				zones[ 135 ] = 1;
				zoneIds[ 135 ] = 215;
				map[ 137 ] = 0;
				zones[ 137 ] = 1;
				zoneIds[ 137 ] = 217;
				map[ 142 ] = 0;
				zones[ 142 ] = 38;
				zoneIds[ 142 ] = 221;
				map[ 143 ] = 0;
				zones[ 143 ] = 38;
				zoneIds[ 143 ] = 222;
				map[ 144 ] = 0;
				zones[ 144 ] = 38;
				zoneIds[ 144 ] = 223;
				map[ 145 ] = 0;
				zones[ 145 ] = 38;
				zoneIds[ 145 ] = 224;
				map[ 147 ] = 0;
				zones[ 147 ] = 38;
				zoneIds[ 147 ] = 226;
				map[ 154 ] = 0;
				zones[ 154 ] = 85;
				zoneIds[ 154 ] = 231;
				map[ 155 ] = 0;
				zones[ 155 ] = 85;
				zoneIds[ 155 ] = 232;
				map[ 158 ] = 0;
				zones[ 158 ] = 85;
				zoneIds[ 158 ] = 235;
				map[ 160 ] = 0;
				zones[ 160 ] = 85;
				zoneIds[ 160 ] = 237;
				map[ 161 ] = 0;
				zones[ 161 ] = 85;
				zoneIds[ 161 ] = 238;
				map[ 168 ] = 0;
				zones[ 168 ] = 85;
				zoneIds[ 168 ] = 245;
				map[ 170 ] = 0;
				zones[ 170 ] = 170;
				zoneIds[ 170 ] = 246;
				map[ 172 ] = 0;
				zones[ 172 ] = 130;
				zoneIds[ 172 ] = 247;
				map[ 189 ] = 0;
				zones[ 189 ] = 1;
				zoneIds[ 189 ] = 249;
				map[ 190 ] = 0;
				zones[ 190 ] = 28;
				zoneIds[ 190 ] = 250;
				map[ 198 ] = 0;
				zones[ 198 ] = 28;
				zoneIds[ 198 ] = 255;
				map[ 199 ] = 0;
				zones[ 199 ] = 28;
				zoneIds[ 199 ] = 256;
				map[ 200 ] = 0;
				zones[ 200 ] = 28;
				zoneIds[ 200 ] = 257;
				map[ 202 ] = 0;
				zones[ 202 ] = 28;
				zoneIds[ 202 ] = 259;
				map[ 203 ] = 0;
				zones[ 203 ] = 28;
				zoneIds[ 203 ] = 260;
				map[ 207 ] = 36;
				zones[ 207 ] = 207;
				zoneIds[ 207 ] = 264;
				map[ 208 ] = 36;
				zones[ 208 ] = 208;
				zoneIds[ 208 ] = 265;
				map[ 210 ] = 36;
				zones[ 210 ] = 210;
				zoneIds[ 210 ] = 267;
				map[ 213 ] = 0;
				zones[ 213 ] = 130;
				zoneIds[ 213 ] = 270;
				map[ 214 ] = 0;
				zones[ 214 ] = 214;
				zoneIds[ 214 ] = 271;
				map[ 215 ] = 1;
				zones[ 215 ] = 215;
				zoneIds[ 215 ] = 272;
				map[ 222 ] = 1;
				zones[ 222 ] = 215;
				zoneIds[ 222 ] = 275;
				map[ 251 ] = 0;
				zones[ 251 ] = 46;
				zoneIds[ 251 ] = 2;
				map[ 252 ] = 0;
				zones[ 252 ] = 46;
				zoneIds[ 252 ] = 3;
				map[ 256 ] = 1;
				zones[ 256 ] = 141;
				zoneIds[ 256 ] = 6;
				map[ 258 ] = 1;
				zones[ 258 ] = 141;
				zoneIds[ 258 ] = 8;
				map[ 259 ] = 1;
				zones[ 259 ] = 141;
				zoneIds[ 259 ] = 9;
				map[ 260 ] = 1;
				zones[ 260 ] = 141;
				zoneIds[ 260 ] = 10;
				map[ 262 ] = 1;
				zones[ 262 ] = 141;
				zoneIds[ 262 ] = 12;
				map[ 266 ] = 1;
				zones[ 266 ] = 141;
				zoneIds[ 266 ] = 16;
				map[ 267 ] = 0;
				zones[ 267 ] = 267;
				zoneIds[ 267 ] = 17;
				map[ 269 ] = 0;
				zones[ 269 ] = 269;
				zoneIds[ 269 ] = 18;
				map[ 275 ] = 0;
				zones[ 275 ] = 267;
				zoneIds[ 275 ] = 20;
				map[ 279 ] = 0;
				zones[ 279 ] = 36;
				zoneIds[ 279 ] = 23;
				map[ 281 ] = 0;
				zones[ 281 ] = 36;
				zoneIds[ 281 ] = 25;
				map[ 283 ] = 0;
				zones[ 283 ] = 36;
				zoneIds[ 283 ] = 27;
				map[ 285 ] = 0;
				zones[ 285 ] = 267;
				zoneIds[ 285 ] = 29;
				map[ 286 ] = 0;
				zones[ 286 ] = 267;
				zoneIds[ 286 ] = 30;
				map[ 287 ] = 0;
				zones[ 287 ] = 267;
				zoneIds[ 287 ] = 31;
				map[ 288 ] = 0;
				zones[ 288 ] = 267;
				zoneIds[ 288 ] = 32;
				map[ 290 ] = 0;
				zones[ 290 ] = 267;
				zoneIds[ 290 ] = 34;
				map[ 297 ] = 0;
				zones[ 297 ] = 33;
				zoneIds[ 297 ] = 38;
				map[ 299 ] = 0;
				zones[ 299 ] = 11;
				zoneIds[ 299 ] = 40;
				map[ 300 ] = 0;
				zones[ 300 ] = 8;
				zoneIds[ 300 ] = 41;
				map[ 301 ] = 0;
				zones[ 301 ] = 33;
				zoneIds[ 301 ] = 42;
				map[ 303 ] = 0;
				zones[ 303 ] = 33;
				zoneIds[ 303 ] = 43;
				map[ 312 ] = 0;
				zones[ 312 ] = 33;
				zoneIds[ 312 ] = 49;
				map[ 314 ] = 0;
				zones[ 314 ] = 45;
				zoneIds[ 314 ] = 50;
				map[ 316 ] = 0;
				zones[ 316 ] = 45;
				zoneIds[ 316 ] = 51;
				map[ 318 ] = 0;
				zones[ 318 ] = 45;
				zoneIds[ 318 ] = 52;
				map[ 320 ] = 0;
				zones[ 320 ] = 45;
				zoneIds[ 320 ] = 53;
				map[ 139 ] = 0;
				zones[ 139 ] = 139;
				zoneIds[ 139 ] = 219;
				map[ 148 ] = 1;
				zones[ 148 ] = 148;
				zoneIds[ 148 ] = 227;
				map[ 211 ] = 0;
				zones[ 211 ] = 1;
				zoneIds[ 211 ] = 268;
				map[ 232 ] = 0;
				zones[ 232 ] = 130;
				zoneIds[ 232 ] = 284;
				map[ 244 ] = 0;
				zones[ 244 ] = 10;
				zoneIds[ 244 ] = 292;
				map[ 25 ] = 0;
				zones[ 25 ] = 25;
				zoneIds[ 25 ] = 136;
				map[ 28 ] = 0;
				zones[ 28 ] = 28;
				zoneIds[ 28 ] = 137;
				map[ 84 ] = 451;
				zones[ 84 ] = 22;
				zoneIds[ 84 ] = 178;
				map[ 997 ] = 0;
				zones[ 997 ] = 44;
				zoneIds[ 997 ] = 409;
				map[ 998 ] = 0;
				zones[ 998 ] = 44;
				zoneIds[ 998 ] = 410;
				map[ 999 ] = 0;
				zones[ 999 ] = 44;
				zoneIds[ 999 ] = 411;
				map[ 1000 ] = 0;
				zones[ 1000 ] = 44;
				zoneIds[ 1000 ] = 412;
				map[ 1120 ] = 1;
				zones[ 1120 ] = 357;
				zoneIds[ 1120 ] = 413;
				map[ 1221 ] = 1;
				zones[ 1221 ] = 16;
				zoneIds[ 1221 ] = 416;
				map[ 1224 ] = 1;
				zones[ 1224 ] = 16;
				zoneIds[ 1224 ] = 419;
				map[ 1226 ] = 1;
				zones[ 1226 ] = 16;
				zoneIds[ 1226 ] = 421;
				map[ 1227 ] = 1;
				zones[ 1227 ] = 16;
				zoneIds[ 1227 ] = 422;
				map[ 1229 ] = 1;
				zones[ 1229 ] = 16;
				zoneIds[ 1229 ] = 424;
				map[ 1231 ] = 1;
				zones[ 1231 ] = 16;
				zoneIds[ 1231 ] = 426;
				map[ 1233 ] = 1;
				zones[ 1233 ] = 16;
				zoneIds[ 1233 ] = 428;
				map[ 1235 ] = 1;
				zones[ 1235 ] = 16;
				zoneIds[ 1235 ] = 430;
				map[ 1237 ] = 1;
				zones[ 1237 ] = 16;
				zoneIds[ 1237 ] = 432;
				map[ 1256 ] = 1;
				zones[ 1256 ] = 16;
				zoneIds[ 1256 ] = 433;
				map[ 1277 ] = 1;
				zones[ 1277 ] = 406;
				zoneIds[ 1277 ] = 435;
				map[ 1337 ] = 70;
				zones[ 1337 ] = 1337;
				zoneIds[ 1337 ] = 437;
				map[ 1338 ] = 0;
				zones[ 1338 ] = 130;
				zoneIds[ 1338 ] = 438;
				map[ 98 ] = 0;
				zones[ 98 ] = 44;
				zoneIds[ 98 ] = 188;
				map[ 131 ] = 0;
				zones[ 131 ] = 1;
				zoneIds[ 131 ] = 211;
				map[ 138 ] = 0;
				zones[ 138 ] = 1;
				zoneIds[ 138 ] = 218;
				map[ 699 ] = 1;
				zones[ 699 ] = 141;
				zoneIds[ 699 ] = 301;
				map[ 436 ] = 1;
				zones[ 436 ] = 331;
				zoneIds[ 436 ] = 469;
				map[ 449 ] = 1;
				zones[ 449 ] = 148;
				zoneIds[ 449 ] = 481;
				map[ 468 ] = 1;
				zones[ 468 ] = 406;
				zoneIds[ 468 ] = 494;
				map[ 480 ] = 1;
				zones[ 480 ] = 400;
				zoneIds[ 480 ] = 505;
				map[ 398 ] = 1;
				zones[ 398 ] = 215;
				zoneIds[ 398 ] = 441;
				map[ 401 ] = 1;
				zones[ 401 ] = 17;
				zoneIds[ 401 ] = 443;
				map[ 404 ] = 1;
				zones[ 404 ] = 215;
				zoneIds[ 404 ] = 444;
				map[ 405 ] = 1;
				zones[ 405 ] = 405;
				zoneIds[ 405 ] = 445;
				map[ 410 ] = 1;
				zones[ 410 ] = 14;
				zoneIds[ 410 ] = 450;
				map[ 414 ] = 1;
				zones[ 414 ] = 331;
				zoneIds[ 414 ] = 453;
				map[ 415 ] = 1;
				zones[ 415 ] = 331;
				zoneIds[ 415 ] = 454;
				map[ 416 ] = 1;
				zones[ 416 ] = 331;
				zoneIds[ 416 ] = 455;
				map[ 417 ] = 1;
				zones[ 417 ] = 331;
				zoneIds[ 417 ] = 456;
				map[ 419 ] = 1;
				zones[ 419 ] = 331;
				zoneIds[ 419 ] = 458;
				map[ 421 ] = 1;
				zones[ 421 ] = 331;
				zoneIds[ 421 ] = 460;
				map[ 422 ] = 1;
				zones[ 422 ] = 331;
				zoneIds[ 422 ] = 461;
				map[ 427 ] = 1;
				zones[ 427 ] = 331;
				zoneIds[ 427 ] = 464;
				map[ 430 ] = 1;
				zones[ 430 ] = 331;
				zoneIds[ 430 ] = 465;
				map[ 433 ] = 1;
				zones[ 433 ] = 331;
				zoneIds[ 433 ] = 467;
				map[ 438 ] = 1;
				zones[ 438 ] = 331;
				zoneIds[ 438 ] = 470;
				map[ 440 ] = 1;
				zones[ 440 ] = 440;
				zoneIds[ 440 ] = 472;
				map[ 442 ] = 1;
				zones[ 442 ] = 148;
				zoneIds[ 442 ] = 474;
				map[ 443 ] = 1;
				zones[ 443 ] = 148;
				zoneIds[ 443 ] = 475;
				map[ 446 ] = 1;
				zones[ 446 ] = 148;
				zoneIds[ 446 ] = 478;
				map[ 452 ] = 1;
				zones[ 452 ] = 148;
				zoneIds[ 452 ] = 483;
				map[ 454 ] = 1;
				zones[ 454 ] = 148;
				zoneIds[ 454 ] = 484;
				map[ 456 ] = 1;
				zones[ 456 ] = 148;
				zoneIds[ 456 ] = 486;
				map[ 458 ] = 1;
				zones[ 458 ] = 17;
				zoneIds[ 458 ] = 487;
				map[ 460 ] = 1;
				zones[ 460 ] = 406;
				zoneIds[ 460 ] = 488;
				map[ 461 ] = 1;
				zones[ 461 ] = 406;
				zoneIds[ 461 ] = 489;
				map[ 465 ] = 1;
				zones[ 465 ] = 406;
				zoneIds[ 465 ] = 492;
				map[ 469 ] = 1;
				zones[ 469 ] = 406;
				zoneIds[ 469 ] = 495;
				map[ 470 ] = 1;
				zones[ 470 ] = 215;
				zoneIds[ 470 ] = 496;
				map[ 471 ] = 1;
				zones[ 471 ] = 215;
				zoneIds[ 471 ] = 497;
				map[ 472 ] = 1;
				zones[ 472 ] = 215;
				zoneIds[ 472 ] = 498;
				map[ 474 ] = 1;
				zones[ 474 ] = 215;
				zoneIds[ 474 ] = 499;
				map[ 476 ] = 1;
				zones[ 476 ] = 215;
				zoneIds[ 476 ] = 501;
				map[ 478 ] = 1;
				zones[ 478 ] = 141;
				zoneIds[ 478 ] = 503;
				map[ 479 ] = 1;
				zones[ 479 ] = 400;
				zoneIds[ 479 ] = 504;
				map[ 482 ] = 1;
				zones[ 482 ] = 400;
				zoneIds[ 482 ] = 506;
				map[ 485 ] = 1;
				zones[ 485 ] = 400;
				zoneIds[ 485 ] = 509;
				map[ 486 ] = 1;
				zones[ 486 ] = 400;
				zoneIds[ 486 ] = 510;
				map[ 487 ] = 1;
				zones[ 487 ] = 400;
				zoneIds[ 487 ] = 511;
				map[ 490 ] = 1;
				zones[ 490 ] = 490;
				zoneIds[ 490 ] = 514;
				map[ 492 ] = 0;
				zones[ 492 ] = 10;
				zoneIds[ 492 ] = 516;
				map[ 493 ] = 1;
				zones[ 493 ] = 493;
				zoneIds[ 493 ] = 517;
				map[ 495 ] = 0;
				zones[ 495 ] = 495;
				zoneIds[ 495 ] = 519;
				map[ 504 ] = 1;
				zones[ 504 ] = 15;
				zoneIds[ 504 ] = 523;
				map[ 505 ] = 1;
				zones[ 505 ] = 15;
				zoneIds[ 505 ] = 524;
				map[ 507 ] = 1;
				zones[ 507 ] = 15;
				zoneIds[ 507 ] = 526;
				map[ 508 ] = 1;
				zones[ 508 ] = 15;
				zoneIds[ 508 ] = 527;
				map[ 512 ] = 1;
				zones[ 512 ] = 15;
				zoneIds[ 512 ] = 530;
				map[ 513 ] = 1;
				zones[ 513 ] = 15;
				zoneIds[ 513 ] = 531;
				map[ 514 ] = 1;
				zones[ 514 ] = 15;
				zoneIds[ 514 ] = 532;
				map[ 517 ] = 1;
				zones[ 517 ] = 15;
				zoneIds[ 517 ] = 535;
				map[ 537 ] = 1;
				zones[ 537 ] = 490;
				zoneIds[ 537 ] = 538;
				map[ 539 ] = 1;
				zones[ 539 ] = 490;
				zoneIds[ 539 ] = 540;
				map[ 541 ] = 1;
				zones[ 541 ] = 490;
				zoneIds[ 541 ] = 542;
				map[ 542 ] = 1;
				zones[ 542 ] = 490;
				zoneIds[ 542 ] = 543;
				map[ 556 ] = 0;
				zones[ 556 ] = 38;
				zoneIds[ 556 ] = 545;
				map[ 87 ] = 0;
				zones[ 87 ] = 12;
				zoneIds[ 87 ] = 548;
				map[ 425 ] = 1;
				zones[ 425 ] = 331;
				zoneIds[ 425 ] = 549;
				map[ 226 ] = 0;
				zones[ 226 ] = 130;
				zoneIds[ 226 ] = 551;
				map[ 473 ] = 1;
				zones[ 473 ] = 215;
				zoneIds[ 473 ] = 554;
				map[ 41 ] = 0;
				zones[ 41 ] = 41;
				zoneIds[ 41 ] = 556;
				map[ 151 ] = 451;
				zones[ 151 ] = 151;
				zoneIds[ 151 ] = 560;
				map[ 188 ] = 1;
				zones[ 188 ] = 141;
				zoneIds[ 188 ] = 561;
				map[ 220 ] = 1;
				zones[ 220 ] = 215;
				zoneIds[ 220 ] = 562;
				map[ 276 ] = 0;
				zones[ 276 ] = 276;
				zoneIds[ 276 ] = 564;
				map[ 302 ] = 0;
				zones[ 302 ] = 33;
				zoneIds[ 302 ] = 565;
				map[ 403 ] = 1;
				zones[ 403 ] = 15;
				zoneIds[ 403 ] = 568;
				map[ 434 ] = 1;
				zones[ 434 ] = 331;
				zoneIds[ 434 ] = 570;
				map[ 481 ] = 1;
				zones[ 481 ] = 400;
				zoneIds[ 481 ] = 572;
				map[ 113 ] = 0;
				zones[ 113 ] = 40;
				zoneIds[ 113 ] = 576;
				map[ 169 ] = 0;
				zones[ 169 ] = 85;
				zoneIds[ 169 ] = 577;
				map[ 268 ] = 37;
				zones[ 268 ] = 268;
				zoneIds[ 268 ] = 580;
				map[ 387 ] = 1;
				zones[ 387 ] = 17;
				zoneIds[ 387 ] = 582;
				map[ 453 ] = 1;
				zones[ 453 ] = 148;
				zoneIds[ 453 ] = 583;
				map[ 238 ] = 0;
				zones[ 238 ] = 130;
				zoneIds[ 238 ] = 587;
				map[ 239 ] = 0;
				zones[ 239 ] = 130;
				zoneIds[ 239 ] = 588;
				map[ 311 ] = 0;
				zones[ 311 ] = 33;
				zoneIds[ 311 ] = 589;
				map[ 315 ] = 0;
				zones[ 315 ] = 45;
				zoneIds[ 315 ] = 590;
				map[ 354 ] = 0;
				zones[ 354 ] = 47;
				zoneIds[ 354 ] = 591;
				map[ 597 ] = 1;
				zones[ 597 ] = 405;
				zoneIds[ 597 ] = 594;
				map[ 609 ] = 1;
				zones[ 609 ] = 405;
				zoneIds[ 609 ] = 598;
				map[ 603 ] = 1;
				zones[ 603 ] = 405;
				zoneIds[ 603 ] = 600;
				map[ 604 ] = 1;
				zones[ 604 ] = 405;
				zoneIds[ 604 ] = 601;
				map[ 26 ] = 0;
				zones[ 26 ] = 40;
				zoneIds[ 26 ] = 602;
				map[ 60 ] = 0;
				zones[ 60 ] = 12;
				zoneIds[ 60 ] = 606;
				map[ 235 ] = 0;
				zones[ 235 ] = 130;
				zoneIds[ 235 ] = 608;
				map[ 317 ] = 0;
				zones[ 317 ] = 45;
				zoneIds[ 317 ] = 609;
				map[ 429 ] = 1;
				zones[ 429 ] = 331;
				zoneIds[ 429 ] = 611;
				map[ 437 ] = 1;
				zones[ 437 ] = 331;
				zoneIds[ 437 ] = 612;
				map[ 467 ] = 1;
				zones[ 467 ] = 406;
				zoneIds[ 467 ] = 613;
				map[ 10 ] = 0;
				zones[ 10 ] = 10;
				zoneIds[ 10 ] = 617;
				map[ 11 ] = 0;
				zones[ 11 ] = 11;
				zoneIds[ 11 ] = 618;
				map[ 616 ] = 1;
				zones[ 616 ] = 616;
				zoneIds[ 616 ] = 619;
				map[ 502 ] = 1;
				zones[ 502 ] = 15;
				zoneIds[ 502 ] = 624;
				map[ 412 ] = 1;
				zones[ 412 ] = 331;
				zoneIds[ 412 ] = 625;
				map[ 636 ] = 1;
				zones[ 636 ] = 406;
				zoneIds[ 636 ] = 626;
				map[ 71 ] = 0;
				zones[ 71 ] = 44;
				zoneIds[ 71 ] = 627;
				map[ 308 ] = 0;
				zones[ 308 ] = 308;
				zoneIds[ 308 ] = 631;
				map[ 338 ] = 0;
				zones[ 338 ] = 3;
				zoneIds[ 338 ] = 633;
				map[ 637 ] = 1;
				zones[ 637 ] = 215;
				zoneIds[ 637 ] = 635;
				map[ 638 ] = 1;
				zones[ 638 ] = 14;
				zoneIds[ 638 ] = 636;
				map[ 639 ] = 1;
				zones[ 639 ] = 14;
				zoneIds[ 639 ] = 637;
				map[ 716 ] = 0;
				zones[ 716 ] = 1;
				zoneIds[ 716 ] = 639;
				map[ 717 ] = 34;
				zones[ 717 ] = 717;
				zoneIds[ 717 ] = 640;
				map[ 720 ] = 1;
				zones[ 720 ] = 17;
				zoneIds[ 720 ] = 643;
				map[ 722 ] = 129;
				zones[ 722 ] = 722;
				zoneIds[ 722 ] = 644;
				map[ 796 ] = 189;
				zones[ 796 ] = 796;
				zoneIds[ 796 ] = 646;
				map[ 797 ] = 0;
				zones[ 797 ] = 12;
				zoneIds[ 797 ] = 647;
				map[ 798 ] = 0;
				zones[ 798 ] = 12;
				zoneIds[ 798 ] = 648;
				map[ 227 ] = 0;
				zones[ 227 ] = 130;
				zoneIds[ 227 ] = 279;
				map[ 228 ] = 0;
				zones[ 228 ] = 130;
				zoneIds[ 228 ] = 280;
				map[ 229 ] = 0;
				zones[ 229 ] = 130;
				zoneIds[ 229 ] = 281;
				map[ 230 ] = 0;
				zones[ 230 ] = 130;
				zoneIds[ 230 ] = 282;
				map[ 231 ] = 0;
				zones[ 231 ] = 130;
				zoneIds[ 231 ] = 283;
				map[ 240 ] = 0;
				zones[ 240 ] = 130;
				zoneIds[ 240 ] = 288;
				map[ 241 ] = 0;
				zones[ 241 ] = 10;
				zoneIds[ 241 ] = 289;
				map[ 242 ] = 0;
				zones[ 242 ] = 10;
				zoneIds[ 242 ] = 290;
				map[ 243 ] = 0;
				zones[ 243 ] = 10;
				zoneIds[ 243 ] = 291;
				map[ 247 ] = 0;
				zones[ 247 ] = 51;
				zoneIds[ 247 ] = 294;
				map[ 697 ] = 1;
				zones[ 697 ] = 141;
				zoneIds[ 697 ] = 299;
				map[ 698 ] = 1;
				zones[ 698 ] = 141;
				zoneIds[ 698 ] = 300;
				map[ 721 ] = 90;
				zones[ 721 ] = 721;
				zoneIds[ 721 ] = 305;
				map[ 838 ] = 0;
				zones[ 838 ] = 38;
				zoneIds[ 838 ] = 306;
				map[ 839 ] = 0;
				zones[ 839 ] = 38;
				zoneIds[ 839 ] = 307;
				map[ 922 ] = 0;
				zones[ 922 ] = 40;
				zoneIds[ 922 ] = 311;
				map[ 936 ] = 0;
				zones[ 936 ] = 38;
				zoneIds[ 936 ] = 318;
				map[ 956 ] = 169;
				zones[ 956 ] = 956;
				zoneIds[ 956 ] = 319;
				map[ 978 ] = 1;
				zones[ 978 ] = 440;
				zoneIds[ 978 ] = 321;
				map[ 980 ] = 1;
				zones[ 980 ] = 440;
				zoneIds[ 980 ] = 323;
				map[ 983 ] = 1;
				zones[ 983 ] = 440;
				zoneIds[ 983 ] = 326;
				map[ 985 ] = 1;
				zones[ 985 ] = 440;
				zoneIds[ 985 ] = 328;
				map[ 988 ] = 1;
				zones[ 988 ] = 440;
				zoneIds[ 988 ] = 331;
				map[ 989 ] = 1;
				zones[ 989 ] = 440;
				zoneIds[ 989 ] = 332;
				map[ 992 ] = 1;
				zones[ 992 ] = 440;
				zoneIds[ 992 ] = 335;
				map[ 1001 ] = 0;
				zones[ 1001 ] = 44;
				zoneIds[ 1001 ] = 336;
				map[ 1018 ] = 0;
				zones[ 1018 ] = 11;
				zoneIds[ 1018 ] = 340;
				map[ 1020 ] = 0;
				zones[ 1020 ] = 11;
				zoneIds[ 1020 ] = 342;
				map[ 1022 ] = 0;
				zones[ 1022 ] = 11;
				zoneIds[ 1022 ] = 344;
				map[ 1023 ] = 0;
				zones[ 1023 ] = 11;
				zoneIds[ 1023 ] = 345;
				map[ 1057 ] = 0;
				zones[ 1057 ] = 267;
				zoneIds[ 1057 ] = 349;
				map[ 1098 ] = 0;
				zones[ 1098 ] = 10;
				zoneIds[ 1098 ] = 352;
				map[ 1099 ] = 1;
				zones[ 1099 ] = 357;
				zoneIds[ 1099 ] = 353;
				map[ 1105 ] = 1;
				zones[ 1105 ] = 357;
				zoneIds[ 1105 ] = 354;
				map[ 1115 ] = 1;
				zones[ 1115 ] = 357;
				zoneIds[ 1115 ] = 357;
				map[ 1156 ] = 1;
				zones[ 1156 ] = 17;
				zoneIds[ 1156 ] = 362;
				map[ 1216 ] = 1;
				zones[ 1216 ] = 16;
				zoneIds[ 1216 ] = 364;
				map[ 1217 ] = 1;
				zones[ 1217 ] = 16;
				zoneIds[ 1217 ] = 365;
				map[ 1218 ] = 1;
				zones[ 1218 ] = 16;
				zoneIds[ 1218 ] = 366;
				map[ 1219 ] = 1;
				zones[ 1219 ] = 16;
				zoneIds[ 1219 ] = 367;
				map[ 1119 ] = 1;
				zones[ 1119 ] = 357;
				zoneIds[ 1119 ] = 369;
				map[ 1137 ] = 1;
				zones[ 1137 ] = 357;
				zoneIds[ 1137 ] = 370;
				map[ 1296 ] = 1;
				zones[ 1296 ] = 14;
				zoneIds[ 1296 ] = 372;
				map[ 1336 ] = 1;
				zones[ 1336 ] = 440;
				zoneIds[ 1336 ] = 373;
				map[ 1377 ] = 1;
				zones[ 1377 ] = 1377;
				zoneIds[ 1377 ] = 374;
				map[ 1397 ] = 169;
				zones[ 1397 ] = 1397;
				zoneIds[ 1397 ] = 376;
				map[ 1438 ] = 0;
				zones[ 1438 ] = 4;
				zoneIds[ 1438 ] = 379;
				map[ 1441 ] = 0;
				zones[ 1441 ] = 4;
				zoneIds[ 1441 ] = 382;
				map[ 1442 ] = 0;
				zones[ 1442 ] = 51;
				zoneIds[ 1442 ] = 383;
				map[ 1443 ] = 0;
				zones[ 1443 ] = 51;
				zoneIds[ 1443 ] = 384;
				map[ 1444 ] = 0;
				zones[ 1444 ] = 51;
				zoneIds[ 1444 ] = 385;
				map[ 1517 ] = 0;
				zones[ 1517 ] = 3;
				zoneIds[ 1517 ] = 686;
				map[ 1537 ] = 0;
				zones[ 1537 ] = 1537;
				zoneIds[ 1537 ] = 689;
				map[ 1579 ] = 0;
				zones[ 1579 ] = 1579;
				zoneIds[ 1579 ] = 693;
				map[ 1581 ] = 36;
				zones[ 1581 ] = 1581;
				zoneIds[ 1581 ] = 695;
				map[ 516 ] = 1;
				zones[ 516 ] = 15;
				zoneIds[ 516 ] = 534;
				map[ 540 ] = 1;
				zones[ 540 ] = 490;
				zoneIds[ 540 ] = 541;
				map[ 54 ] = 0;
				zones[ 54 ] = 12;
				zoneIds[ 54 ] = 550;
				map[ 599 ] = 1;
				zones[ 599 ] = 405;
				zoneIds[ 599 ] = 596;
				map[ 153 ] = 0;
				zones[ 153 ] = 85;
				zoneIds[ 153 ] = 607;
				map[ 295 ] = 0;
				zones[ 295 ] = 267;
				zoneIds[ 295 ] = 616;
				map[ 806 ] = 0;
				zones[ 806 ] = 1;
				zoneIds[ 806 ] = 656;
				map[ 815 ] = 1;
				zones[ 815 ] = 17;
				zoneIds[ 815 ] = 665;
				map[ 837 ] = 0;
				zones[ 837 ] = 38;
				zoneIds[ 837 ] = 673;
				map[ 249 ] = 0;
				zones[ 249 ] = 46;
				zoneIds[ 249 ] = 1;
				map[ 289 ] = 0;
				zones[ 289 ] = 267;
				zoneIds[ 289 ] = 33;
				map[ 323 ] = 0;
				zones[ 323 ] = 45;
				zoneIds[ 323 ] = 55;
				map[ 331 ] = 1;
				zones[ 331 ] = 331;
				zoneIds[ 331 ] = 61;
				map[ 336 ] = 0;
				zones[ 336 ] = 45;
				zoneIds[ 336 ] = 66;
				map[ 977 ] = 1;
				zones[ 977 ] = 440;
				zoneIds[ 977 ] = 390;
				map[ 1036 ] = 0;
				zones[ 1036 ] = 11;
				zoneIds[ 1036 ] = 391;
				map[ 1037 ] = 0;
				zones[ 1037 ] = 11;
				zoneIds[ 1037 ] = 392;
				map[ 1038 ] = 0;
				zones[ 1038 ] = 11;
				zoneIds[ 1038 ] = 393;
				map[ 1039 ] = 0;
				zones[ 1039 ] = 11;
				zoneIds[ 1039 ] = 394;
				map[ 1101 ] = 1;
				zones[ 1101 ] = 357;
				zoneIds[ 1101 ] = 396;
				map[ 1106 ] = 1;
				zones[ 1106 ] = 357;
				zoneIds[ 1106 ] = 399;
				map[ 1107 ] = 1;
				zones[ 1107 ] = 357;
				zoneIds[ 1107 ] = 400;
				map[ 1109 ] = 1;
				zones[ 1109 ] = 357;
				zoneIds[ 1109 ] = 401;
				map[ 1110 ] = 1;
				zones[ 1110 ] = 357;
				zoneIds[ 1110 ] = 402;
				map[ 1111 ] = 1;
				zones[ 1111 ] = 357;
				zoneIds[ 1111 ] = 403;
				map[ 1113 ] = 1;
				zones[ 1113 ] = 357;
				zoneIds[ 1113 ] = 405;
				map[ 1157 ] = 1;
				zones[ 1157 ] = 17;
				zoneIds[ 1157 ] = 406;
				map[ 1518 ] = 0;
				zones[ 1518 ] = 40;
				zoneIds[ 1518 ] = 687;
				map[ 1519 ] = 0;
				zones[ 1519 ] = 1519;
				zoneIds[ 1519 ] = 688;
				map[ 307 ] = 0;
				zones[ 307 ] = 47;
				zoneIds[ 307 ] = 46;
				map[ 77 ] = 0;
				zones[ 77 ] = 1;
				zoneIds[ 77 ] = 174;
				map[ 2102 ] = 0;
				zones[ 2102 ] = 1;
				zoneIds[ 2102 ] = 806;
				map[ 2103 ] = 0;
				zones[ 2103 ] = 11;
				zoneIds[ 2103 ] = 807;
				map[ 2104 ] = 0;
				zones[ 2104 ] = 11;
				zoneIds[ 2104 ] = 808;
				map[ 2157 ] = 1;
				zones[ 2157 ] = 17;
				zoneIds[ 2157 ] = 814;
				map[ 488 ] = 1;
				zones[ 488 ] = 400;
				zoneIds[ 488 ] = 512;
				map[ 810 ] = 0;
				zones[ 810 ] = 85;
				zoneIds[ 810 ] = 660;
				map[ 1118 ] = 1;
				zones[ 1118 ] = 357;
				zoneIds[ 1118 ] = 360;
				map[ 1228 ] = 1;
				zones[ 1228 ] = 16;
				zoneIds[ 1228 ] = 423;
				map[ 2240 ] = 1;
				zones[ 2240 ] = 400;
				zoneIds[ 2240 ] = 826;
				map[ 2243 ] = 1;
				zones[ 2243 ] = 618;
				zoneIds[ 2243 ] = 829;
				map[ 2245 ] = 1;
				zones[ 2245 ] = 618;
				zoneIds[ 2245 ] = 831;
				map[ 2247 ] = 1;
				zones[ 2247 ] = 618;
				zoneIds[ 2247 ] = 833;
				map[ 491 ] = 47;
				zones[ 491 ] = 491;
				zoneIds[ 491 ] = 515;
				map[ 506 ] = 1;
				zones[ 506 ] = 15;
				zoneIds[ 506 ] = 525;
				map[ 1769 ] = 1;
				zones[ 1769 ] = 361;
				zoneIds[ 1769 ] = 754;
				map[ 328 ] = 0;
				zones[ 328 ] = 45;
				zoneIds[ 328 ] = 566;
				map[ 355 ] = 0;
				zones[ 355 ] = 47;
				zoneIds[ 355 ] = 592;
				map[ 1658 ] = 1;
				zones[ 1658 ] = 1657;
				zoneIds[ 1658 ] = 713;
				map[ 1998 ] = 1;
				zones[ 1998 ] = 361;
				zoneIds[ 1998 ] = 794;
				map[ 2249 ] = 1;
				zones[ 2249 ] = 618;
				zoneIds[ 2249 ] = 835;
				map[ 2251 ] = 1;
				zones[ 2251 ] = 618;
				zoneIds[ 2251 ] = 837;
				map[ 2254 ] = 1;
				zones[ 2254 ] = 618;
				zoneIds[ 2254 ] = 840;
				map[ 2260 ] = 0;
				zones[ 2260 ] = 139;
				zoneIds[ 2260 ] = 846;
				map[ 2262 ] = 0;
				zones[ 2262 ] = 139;
				zoneIds[ 2262 ] = 848;
				map[ 2263 ] = 0;
				zones[ 2263 ] = 139;
				zoneIds[ 2263 ] = 849;
				map[ 2264 ] = 0;
				zones[ 2264 ] = 139;
				zoneIds[ 2264 ] = 850;
				map[ 2266 ] = 0;
				zones[ 2266 ] = 139;
				zoneIds[ 2266 ] = 852;
				map[ 2270 ] = 0;
				zones[ 2270 ] = 139;
				zoneIds[ 2270 ] = 856;
				map[ 800 ] = 0;
				zones[ 800 ] = 1;
				zoneIds[ 800 ] = 650;
				map[ 805 ] = 0;
				zones[ 805 ] = 1;
				zoneIds[ 805 ] = 655;
				map[ 807 ] = 0;
				zones[ 807 ] = 1;
				zoneIds[ 807 ] = 657;
				map[ 808 ] = 0;
				zones[ 808 ] = 1;
				zoneIds[ 808 ] = 658;
				map[ 811 ] = 0;
				zones[ 811 ] = 85;
				zoneIds[ 811 ] = 661;
				map[ 812 ] = 0;
				zones[ 812 ] = 85;
				zoneIds[ 812 ] = 662;
				map[ 814 ] = 1;
				zones[ 814 ] = 14;
				zoneIds[ 814 ] = 664;
				map[ 817 ] = 1;
				zones[ 817 ] = 14;
				zoneIds[ 817 ] = 667;
				map[ 819 ] = 1;
				zones[ 819 ] = 215;
				zoneIds[ 819 ] = 669;
				map[ 836 ] = 0;
				zones[ 836 ] = 11;
				zoneIds[ 836 ] = 672;
				map[ 856 ] = 0;
				zones[ 856 ] = 10;
				zoneIds[ 856 ] = 674;
				map[ 876 ] = 1;
				zones[ 876 ] = 876;
				zoneIds[ 876 ] = 675;
				map[ 877 ] = 1;
				zones[ 877 ] = 17;
				zoneIds[ 877 ] = 676;
				map[ 879 ] = 1;
				zones[ 879 ] = 331;
				zoneIds[ 879 ] = 678;
				map[ 917 ] = 0;
				zones[ 917 ] = 40;
				zoneIds[ 917 ] = 682;
				map[ 1858 ] = 0;
				zones[ 1858 ] = 45;
				zoneIds[ 1858 ] = 766;
				map[ 2259 ] = 0;
				zones[ 2259 ] = 139;
				zoneIds[ 2259 ] = 845;
				map[ 2303 ] = 1;
				zones[ 2303 ] = 400;
				zoneIds[ 2303 ] = 873;
				map[ 2319 ] = 1;
				zones[ 2319 ] = 17;
				zoneIds[ 2319 ] = 876;
				map[ 2320 ] = 1;
				zones[ 2320 ] = 14;
				zoneIds[ 2320 ] = 877;
				map[ 2323 ] = 1;
				zones[ 2323 ] = 357;
				zoneIds[ 2323 ] = 880;
				map[ 2326 ] = 1;
				zones[ 2326 ] = 148;
				zoneIds[ 2326 ] = 883;
				map[ 395 ] = 0;
				zones[ 395 ] = 394;
				zoneIds[ 395 ] = 116;
				map[ 2362 ] = 1;
				zones[ 2362 ] = 493;
				zoneIds[ 2362 ] = 892;
				map[ 2364 ] = 0;
				zones[ 2364 ] = 40;
				zoneIds[ 2364 ] = 894;
				map[ 2368 ] = 269;
				zones[ 2368 ] = 2367;
				zoneIds[ 2368 ] = 898;
				map[ 2369 ] = 269;
				zones[ 2369 ] = 2367;
				zoneIds[ 2369 ] = 899;
				map[ 2370 ] = 269;
				zones[ 2370 ] = 2367;
				zoneIds[ 2370 ] = 900;
				map[ 2371 ] = 269;
				zones[ 2371 ] = 2367;
				zoneIds[ 2371 ] = 901;
				map[ 2376 ] = 269;
				zones[ 2376 ] = 2367;
				zoneIds[ 2376 ] = 906;
				map[ 2397 ] = 0;
				zones[ 2397 ] = 267;
				zoneIds[ 2397 ] = 910;
				map[ 2398 ] = 0;
				zones[ 2398 ] = 130;
				zoneIds[ 2398 ] = 911;
				map[ 2399 ] = 0;
				zones[ 2399 ] = 85;
				zoneIds[ 2399 ] = 912;
				map[ 2402 ] = 0;
				zones[ 2402 ] = 11;
				zoneIds[ 2402 ] = 915;
				map[ 2403 ] = 0;
				zones[ 2403 ] = 8;
				zoneIds[ 2403 ] = 916;
				map[ 2408 ] = 1;
				zones[ 2408 ] = 405;
				zoneIds[ 2408 ] = 921;
				map[ 2417 ] = 0;
				zones[ 2417 ] = 46;
				zoneIds[ 2417 ] = 922;
				map[ 2421 ] = 0;
				zones[ 2421 ] = 46;
				zoneIds[ 2421 ] = 926;
				map[ 2437 ] = 389;
				zones[ 2437 ] = 2437;
				zoneIds[ 2437 ] = 927;
				map[ 2457 ] = 1;
				zones[ 2457 ] = 331;
				zoneIds[ 2457 ] = 928;
				map[ 2497 ] = 1;
				zones[ 2497 ] = 16;
				zoneIds[ 2497 ] = 934;
				map[ 2517 ] = 0;
				zones[ 2517 ] = 4;
				zoneIds[ 2517 ] = 935;
				map[ 2519 ] = 1;
				zones[ 2519 ] = 357;
				zoneIds[ 2519 ] = 937;
				map[ 2520 ] = 1;
				zones[ 2520 ] = 357;
				zoneIds[ 2520 ] = 938;
				map[ 2538 ] = 1;
				zones[ 2538 ] = 406;
				zoneIds[ 2538 ] = 942;
				map[ 2539 ] = 1;
				zones[ 2539 ] = 406;
				zoneIds[ 2539 ] = 943;
				map[ 2541 ] = 1;
				zones[ 2541 ] = 406;
				zoneIds[ 2541 ] = 945;
				map[ 2557 ] = 429;
				zones[ 2557 ] = 2557;
				zoneIds[ 2557 ] = 946;
				map[ 2559 ] = 0;
				zones[ 2559 ] = 41;
				zoneIds[ 2559 ] = 948;
				map[ 2562 ] = 0;
				zones[ 2562 ] = 41;
				zoneIds[ 2562 ] = 951;
				map[ 2563 ] = 0;
				zones[ 2563 ] = 41;
				zoneIds[ 2563 ] = 952;
				map[ 2617 ] = 1;
				zones[ 2617 ] = 405;
				zoneIds[ 2617 ] = 955;
				map[ 2620 ] = 0;
				zones[ 2620 ] = 28;
				zoneIds[ 2620 ] = 958;
				map[ 2621 ] = 0;
				zones[ 2621 ] = 139;
				zoneIds[ 2621 ] = 959;
				map[ 2623 ] = 0;
				zones[ 2623 ] = 139;
				zoneIds[ 2623 ] = 961;
				map[ 2624 ] = 0;
				zones[ 2624 ] = 139;
				zoneIds[ 2624 ] = 962;
				map[ 2625 ] = 0;
				zones[ 2625 ] = 139;
				zoneIds[ 2625 ] = 963;
				map[ 2637 ] = 1;
				zones[ 2637 ] = 331;
				zoneIds[ 2637 ] = 966;
				map[ 1497 ] = 0;
				zones[ 1497 ] = 1497;
				zoneIds[ 1497 ] = 685;
				map[ 1577 ] = 0;
				zones[ 1577 ] = 33;
				zoneIds[ 1577 ] = 691;
				map[ 2697 ] = 0;
				zones[ 2697 ] = 41;
				zoneIds[ 2697 ] = 969;
				map[ 2717 ] = 409;
				zones[ 2717 ] = 2717;
				zoneIds[ 2717 ] = 970;
				map[ 2738 ] = 1;
				zones[ 2738 ] = 1377;
				zoneIds[ 2738 ] = 972;
				map[ 2742 ] = 1;
				zones[ 2742 ] = 1377;
				zoneIds[ 2742 ] = 976;
				map[ 2744 ] = 1;
				zones[ 2744 ] = 1377;
				zoneIds[ 2744 ] = 978;
				map[ 1957 ] = 0;
				zones[ 1957 ] = 51;
				zoneIds[ 1957 ] = 788;
				map[ 2119 ] = 0;
				zones[ 2119 ] = 85;
				zoneIds[ 2119 ] = 811;
				map[ 2757 ] = 1;
				zones[ 2757 ] = 17;
				zoneIds[ 2757 ] = 979;
				map[ 1882 ] = 0;
				zones[ 1882 ] = 47;
				zoneIds[ 1882 ] = 772;
				map[ 2099 ] = 0;
				zones[ 2099 ] = 44;
				zoneIds[ 2099 ] = 803;
				map[ 1938 ] = 1;
				zones[ 1938 ] = 440;
				zoneIds[ 1938 ] = 782;
				map[ 2777 ] = 0;
				zones[ 2777 ] = 267;
				zoneIds[ 2777 ] = 980;
				map[ 2817 ] = 30;
				zones[ 2817 ] = 2817;
				zoneIds[ 2817 ] = 0;
				map[ 2137 ] = 1;
				zones[ 2137 ] = 215;
				zoneIds[ 2137 ] = 812;
				map[ 1597 ] = 1;
				zones[ 1597 ] = 17;
				zoneIds[ 1597 ] = 699;
				map[ 1599 ] = 1;
				zones[ 1599 ] = 17;
				zoneIds[ 1599 ] = 701;
				map[ 1600 ] = 1;
				zones[ 1600 ] = 17;
				zoneIds[ 1600 ] = 702;
				map[ 1601 ] = 1;
				zones[ 1601 ] = 17;
				zoneIds[ 1601 ] = 703;
				map[ 1602 ] = 1;
				zones[ 1602 ] = 17;
				zoneIds[ 1602 ] = 704;
				map[ 1641 ] = 1;
				zones[ 1641 ] = 1638;
				zoneIds[ 1641 ] = 711;
				map[ 1657 ] = 1;
				zones[ 1657 ] = 1657;
				zoneIds[ 1657 ] = 712;
				map[ 700 ] = 1;
				zones[ 700 ] = 141;
				zoneIds[ 700 ] = 302;
				map[ 1660 ] = 1;
				zones[ 1660 ] = 1657;
				zoneIds[ 1660 ] = 715;
				map[ 1661 ] = 1;
				zones[ 1661 ] = 1657;
				zoneIds[ 1661 ] = 716;
				map[ 1662 ] = 1;
				zones[ 1662 ] = 1657;
				zoneIds[ 1662 ] = 717;
				map[ 1680 ] = 0;
				zones[ 1680 ] = 36;
				zoneIds[ 1680 ] = 721;
				map[ 1681 ] = 0;
				zones[ 1681 ] = 36;
				zoneIds[ 1681 ] = 722;
				map[ 187 ] = 1;
				zones[ 187 ] = 141;
				zoneIds[ 187 ] = 248;
				map[ 984 ] = 1;
				zones[ 984 ] = 440;
				zoneIds[ 984 ] = 327;
				map[ 1717 ] = 1;
				zones[ 1717 ] = 17;
				zoneIds[ 1717 ] = 734;
				map[ 1740 ] = 0;
				zones[ 1740 ] = 33;
				zoneIds[ 1740 ] = 739;
				map[ 1883 ] = 0;
				zones[ 1883 ] = 47;
				zoneIds[ 1883 ] = 773;
				map[ 1885 ] = 0;
				zones[ 1885 ] = 47;
				zoneIds[ 1885 ] = 775;
				map[ 1897 ] = 0;
				zones[ 1897 ] = 3;
				zoneIds[ 1897 ] = 778;
				map[ 1917 ] = 0;
				zones[ 1917 ] = 47;
				zoneIds[ 1917 ] = 780;
				map[ 1959 ] = 0;
				zones[ 1959 ] = 51;
				zoneIds[ 1959 ] = 790;
				map[ 2078 ] = 1;
				zones[ 2078 ] = 148;
				zoneIds[ 2078 ] = 799;
				map[ 2079 ] = 1;
				zones[ 2079 ] = 15;
				zoneIds[ 2079 ] = 800;
				map[ 2117 ] = 0;
				zones[ 2117 ] = 85;
				zoneIds[ 2117 ] = 809;
				map[ 2160 ] = 1;
				zones[ 2160 ] = 406;
				zoneIds[ 2160 ] = 817;
				map[ 2339 ] = 0;
				zones[ 2339 ] = 33;
				zoneIds[ 2339 ] = 886;
				map[ 2358 ] = 1;
				zones[ 2358 ] = 331;
				zoneIds[ 2358 ] = 888;
				map[ 2359 ] = 1;
				zones[ 2359 ] = 331;
				zoneIds[ 2359 ] = 889;
				map[ 2375 ] = 269;
				zones[ 2375 ] = 2367;
				zoneIds[ 2375 ] = 905;
				map[ 1617 ] = 0;
				zones[ 1617 ] = 1519;
				zoneIds[ 1617 ] = 706;
				map[ 1637 ] = 1;
				zones[ 1637 ] = 1637;
				zoneIds[ 1637 ] = 707;
				map[ 1638 ] = 1;
				zones[ 1638 ] = 1638;
				zoneIds[ 1638 ] = 708;
				map[ 1640 ] = 1;
				zones[ 1640 ] = 1638;
				zoneIds[ 1640 ] = 710;
				map[ 280 ] = 0;
				zones[ 280 ] = 36;
				zoneIds[ 280 ] = 24;
				map[ 111 ] = 0;
				zones[ 111 ] = 40;
				zoneIds[ 111 ] = 198;
				map[ 167 ] = 0;
				zones[ 167 ] = 85;
				zoneIds[ 167 ] = 244;
				map[ 1002 ] = 0;
				zones[ 1002 ] = 44;
				zoneIds[ 1002 ] = 337;
				map[ 411 ] = 1;
				zones[ 411 ] = 331;
				zoneIds[ 411 ] = 451;
				map[ 431 ] = 1;
				zones[ 431 ] = 331;
				zoneIds[ 431 ] = 553;
				map[ 100 ] = 0;
				zones[ 100 ] = 33;
				zoneIds[ 100 ] = 585;
				map[ 296 ] = 0;
				zones[ 296 ] = 296;
				zoneIds[ 296 ] = 37;
				map[ 408 ] = 0;
				zones[ 408 ] = 408;
				zoneIds[ 408 ] = 448;
				map[ 1757 ] = 0;
				zones[ 1757 ] = 33;
				zoneIds[ 1757 ] = 742;
				map[ 1758 ] = 0;
				zones[ 1758 ] = 33;
				zoneIds[ 1758 ] = 743;
				map[ 1761 ] = 1;
				zones[ 1761 ] = 361;
				zoneIds[ 1761 ] = 746;
				map[ 1762 ] = 1;
				zones[ 1762 ] = 361;
				zoneIds[ 1762 ] = 747;
				map[ 1766 ] = 1;
				zones[ 1766 ] = 361;
				zoneIds[ 1766 ] = 751;
				map[ 1767 ] = 1;
				zones[ 1767 ] = 361;
				zoneIds[ 1767 ] = 752;
				map[ 1770 ] = 1;
				zones[ 1770 ] = 361;
				zoneIds[ 1770 ] = 755;
				map[ 1779 ] = 0;
				zones[ 1779 ] = 8;
				zoneIds[ 1779 ] = 759;
				map[ 1220 ] = 1;
				zones[ 1220 ] = 16;
				zoneIds[ 1220 ] = 415;
				map[ 1230 ] = 1;
				zones[ 1230 ] = 16;
				zoneIds[ 1230 ] = 425;
				map[ 1887 ] = 0;
				zones[ 1887 ] = 47;
				zoneIds[ 1887 ] = 777;
				map[ 1937 ] = 1;
				zones[ 1937 ] = 440;
				zoneIds[ 1937 ] = 781;
				map[ 701 ] = 1;
				zones[ 701 ] = 141;
				zoneIds[ 701 ] = 303;
				map[ 1683 ] = 0;
				zones[ 1683 ] = 36;
				zoneIds[ 1683 ] = 724;
				map[ 1697 ] = 1;
				zones[ 1697 ] = 17;
				zoneIds[ 1697 ] = 726;
				map[ 1698 ] = 1;
				zones[ 1698 ] = 17;
				zoneIds[ 1698 ] = 727;
				map[ 1699 ] = 1;
				zones[ 1699 ] = 17;
				zoneIds[ 1699 ] = 728;
				map[ 1700 ] = 1;
				zones[ 1700 ] = 17;
				zoneIds[ 1700 ] = 729;
				map[ 1702 ] = 1;
				zones[ 1702 ] = 17;
				zoneIds[ 1702 ] = 731;
				map[ 1739 ] = 0;
				zones[ 1739 ] = 33;
				zoneIds[ 1739 ] = 738;
				map[ 1741 ] = 0;
				zones[ 1741 ] = 33;
				zoneIds[ 1741 ] = 740;
				map[ 1759 ] = 0;
				zones[ 1759 ] = 33;
				zoneIds[ 1759 ] = 744;
				map[ 1777 ] = 0;
				zones[ 1777 ] = 8;
				zoneIds[ 1777 ] = 757;
				map[ 1797 ] = 0;
				zones[ 1797 ] = 8;
				zoneIds[ 1797 ] = 761;
				map[ 990 ] = 1;
				zones[ 990 ] = 440;
				zoneIds[ 990 ] = 333;
				map[ 1021 ] = 0;
				zones[ 1021 ] = 11;
				zoneIds[ 1021 ] = 343;
				map[ 1097 ] = 0;
				zones[ 1097 ] = 10;
				zoneIds[ 1097 ] = 351;
				map[ 1136 ] = 1;
				zones[ 1136 ] = 357;
				zoneIds[ 1136 ] = 361;
				map[ 1417 ] = 109;
				zones[ 1417 ] = 1417;
				zoneIds[ 1417 ] = 377;
				map[ 918 ] = 0;
				zones[ 918 ] = 40;
				zoneIds[ 918 ] = 683;
				map[ 976 ] = 1;
				zones[ 976 ] = 440;
				zoneIds[ 976 ] = 320;
				map[ 475 ] = 1;
				zones[ 475 ] = 215;
				zoneIds[ 475 ] = 500;
				map[ 1886 ] = 0;
				zones[ 1886 ] = 47;
				zoneIds[ 1886 ] = 776;
				map[ 1941 ] = 1;
				zones[ 1941 ] = 1941;
				zoneIds[ 1941 ] = 785;
				map[ 676 ] = 150;
				zones[ 676 ] = 676;
				zoneIds[ 676 ] = 297;
				map[ 696 ] = 1;
				zones[ 696 ] = 141;
				zoneIds[ 696 ] = 298;
				map[ 466 ] = 1;
				zones[ 466 ] = 406;
				zoneIds[ 466 ] = 493;
				map[ 381 ] = 1;
				zones[ 381 ] = 17;
				zoneIds[ 381 ] = 105;
				map[ 333 ] = 0;
				zones[ 333 ] = 45;
				zoneIds[ 333 ] = 63;
				map[ 923 ] = 0;
				zones[ 923 ] = 38;
				zoneIds[ 923 ] = 312;
				map[ 991 ] = 1;
				zones[ 991 ] = 440;
				zoneIds[ 991 ] = 334;
				map[ 1056 ] = 0;
				zones[ 1056 ] = 267;
				zoneIds[ 1056 ] = 348;
				map[ 1108 ] = 1;
				zones[ 1108 ] = 357;
				zoneIds[ 1108 ] = 355;
				map[ 896 ] = 0;
				zones[ 896 ] = 267;
				zoneIds[ 896 ] = 308;
				map[ 986 ] = 1;
				zones[ 986 ] = 440;
				zoneIds[ 986 ] = 329;
				map[ 1437 ] = 0;
				zones[ 1437 ] = 4;
				zoneIds[ 1437 ] = 378;
				map[ 1103 ] = 1;
				zones[ 1103 ] = 357;
				zoneIds[ 1103 ] = 397;
				map[ 396 ] = 1;
				zones[ 396 ] = 215;
				zoneIds[ 396 ] = 117;
				map[ 7 ] = 0;
				zones[ 7 ] = 33;
				zoneIds[ 7 ] = 123;
				map[ 2017 ] = 329;
				zones[ 2017 ] = 2017;
				zoneIds[ 2017 ] = 795;
				map[ 2037 ] = 0;
				zones[ 2037 ] = 2037;
				zoneIds[ 2037 ] = 796;
				map[ 305 ] = 0;
				zones[ 305 ] = 130;
				zoneIds[ 305 ] = 44;
				map[ 2077 ] = 1;
				zones[ 2077 ] = 148;
				zoneIds[ 2077 ] = 798;
				map[ 2101 ] = 0;
				zones[ 2101 ] = 38;
				zoneIds[ 2101 ] = 805;
				map[ 134 ] = 0;
				zones[ 134 ] = 1;
				zoneIds[ 134 ] = 214;
				map[ 1225 ] = 1;
				zones[ 1225 ] = 16;
				zoneIds[ 1225 ] = 420;
				map[ 3417 ] = 529;
				zones[ 3417 ] = 3358;
				zoneIds[ 3417 ] = 1055;
				map[ 2857 ] = 1;
				zones[ 2857 ] = 440;
				zoneIds[ 2857 ] = 985;
				map[ 2374 ] = 269;
				zones[ 2374 ] = 2367;
				zoneIds[ 2374 ] = 904;
				map[ 2979 ] = 1;
				zones[ 2979 ] = 14;
				zoneIds[ 2979 ] = 1002;
				map[ 146 ] = 0;
				zones[ 146 ] = 38;
				zoneIds[ 146 ] = 225;
				map[ 159 ] = 0;
				zones[ 159 ] = 85;
				zoneIds[ 159 ] = 236;
				map[ 3418 ] = 529;
				zones[ 3418 ] = 3358;
				zoneIds[ 3418 ] = 1056;
				map[ 197 ] = 0;
				zones[ 197 ] = 28;
				zoneIds[ 197 ] = 254;
				map[ 205 ] = 0;
				zones[ 205 ] = 11;
				zoneIds[ 205 ] = 262;
				map[ 212 ] = 0;
				zones[ 212 ] = 1;
				zoneIds[ 212 ] = 269;
				map[ 225 ] = 1;
				zones[ 225 ] = 215;
				zoneIds[ 225 ] = 278;
				map[ 237 ] = 0;
				zones[ 237 ] = 130;
				zoneIds[ 237 ] = 287;
				map[ 3419 ] = 309;
				zones[ 3419 ] = 1977;
				zoneIds[ 3419 ] = 1057;
				map[ 1016 ] = 0;
				zones[ 1016 ] = 11;
				zoneIds[ 1016 ] = 338;
				map[ 1025 ] = 0;
				zones[ 1025 ] = 11;
				zoneIds[ 1025 ] = 347;
				map[ 1116 ] = 1;
				zones[ 1116 ] = 357;
				zoneIds[ 1116 ] = 358;
				map[ 1076 ] = 1;
				zones[ 1076 ] = 406;
				zoneIds[ 1076 ] = 368;
				map[ 1583 ] = 0;
				zones[ 1583 ] = 1583;
				zoneIds[ 1583 ] = 697;
				map[ 277 ] = 0;
				zones[ 277 ] = 36;
				zoneIds[ 277 ] = 21;
				map[ 1222 ] = 1;
				zones[ 1222 ] = 16;
				zoneIds[ 1222 ] = 417;
				map[ 1234 ] = 1;
				zones[ 1234 ] = 16;
				zoneIds[ 1234 ] = 429;
				map[ 1316 ] = 1;
				zones[ 1316 ] = 17;
				zoneIds[ 1316 ] = 436;
				map[ 424 ] = 1;
				zones[ 424 ] = 331;
				zoneIds[ 424 ] = 462;
				map[ 409 ] = 0;
				zones[ 409 ] = 409;
				zoneIds[ 409 ] = 449;
				map[ 600 ] = 1;
				zones[ 600 ] = 405;
				zoneIds[ 600 ] = 597;
				map[ 987 ] = 1;
				zones[ 987 ] = 440;
				zoneIds[ 987 ] = 330;
				map[ 1580 ] = 36;
				zones[ 1580 ] = 1579;
				zoneIds[ 1580 ] = 694;
				map[ 1677 ] = 0;
				zones[ 1677 ] = 36;
				zoneIds[ 1677 ] = 718;
				map[ 1742 ] = 0;
				zones[ 1742 ] = 33;
				zoneIds[ 1742 ] = 741;
				map[ 1881 ] = 0;
				zones[ 1881 ] = 47;
				zoneIds[ 1881 ] = 771;
				map[ 2420 ] = 0;
				zones[ 2420 ] = 46;
				zoneIds[ 2420 ] = 925;
				map[ 2518 ] = 1;
				zones[ 2518 ] = 357;
				zoneIds[ 2518 ] = 936;
				map[ 448 ] = 1;
				zones[ 448 ] = 148;
				zoneIds[ 448 ] = 480;
				map[ 464 ] = 1;
				zones[ 464 ] = 406;
				zoneIds[ 464 ] = 491;
				map[ 477 ] = 0;
				zones[ 477 ] = 33;
				zoneIds[ 477 ] = 502;
				map[ 489 ] = 1;
				zones[ 489 ] = 357;
				zoneIds[ 489 ] = 513;
				map[ 497 ] = 1;
				zones[ 497 ] = 15;
				zoneIds[ 497 ] = 520;
				map[ 536 ] = 0;
				zones[ 536 ] = 10;
				zoneIds[ 536 ] = 537;
				map[ 92 ] = 0;
				zones[ 92 ] = 12;
				zoneIds[ 92 ] = 558;
				map[ 371 ] = 1;
				zones[ 371 ] = 14;
				zoneIds[ 371 ] = 567;
				map[ 19 ] = 0;
				zones[ 19 ] = 33;
				zoneIds[ 19 ] = 574;
				map[ 596 ] = 1;
				zones[ 596 ] = 405;
				zoneIds[ 596 ] = 593;
				map[ 607 ] = 1;
				zones[ 607 ] = 405;
				zoneIds[ 607 ] = 604;
				map[ 501 ] = 1;
				zones[ 501 ] = 15;
				zoneIds[ 501 ] = 614;
				map[ 500 ] = 1;
				zones[ 500 ] = 15;
				zoneIds[ 500 ] = 623;
				map[ 254 ] = 0;
				zones[ 254 ] = 46;
				zoneIds[ 254 ] = 630;
				map[ 718 ] = 43;
				zones[ 718 ] = 718;
				zoneIds[ 718 ] = 641;
				map[ 799 ] = 0;
				zones[ 799 ] = 10;
				zoneIds[ 799 ] = 649;
				map[ 809 ] = 0;
				zones[ 809 ] = 1;
				zoneIds[ 809 ] = 659;
				map[ 919 ] = 0;
				zones[ 919 ] = 40;
				zoneIds[ 919 ] = 684;
				map[ 2302 ] = 1;
				zones[ 2302 ] = 15;
				zoneIds[ 2302 ] = 872;
				map[ 2324 ] = 1;
				zones[ 2324 ] = 405;
				zoneIds[ 2324 ] = 881;
				map[ 2366 ] = 269;
				zones[ 2366 ] = 2366;
				zoneIds[ 2366 ] = 896;
				map[ 2373 ] = 269;
				zones[ 2373 ] = 2367;
				zoneIds[ 2373 ] = 903;
				map[ 2401 ] = 0;
				zones[ 2401 ] = 45;
				zoneIds[ 2401 ] = 914;
				map[ 1768 ] = 1;
				zones[ 1768 ] = 361;
				zoneIds[ 1768 ] = 753;
				map[ 2743 ] = 1;
				zones[ 2743 ] = 1377;
				zoneIds[ 2743 ] = 977;
				map[ 2797 ] = 1;
				zones[ 2797 ] = 331;
				zoneIds[ 2797 ] = 981;
				map[ 1598 ] = 1;
				zones[ 1598 ] = 17;
				zoneIds[ 1598 ] = 700;
				map[ 1659 ] = 1;
				zones[ 1659 ] = 1657;
				zoneIds[ 1659 ] = 714;
				map[ 1684 ] = 0;
				zones[ 1684 ] = 36;
				zoneIds[ 1684 ] = 725;
				map[ 1837 ] = 0;
				zones[ 1837 ] = 45;
				zoneIds[ 1837 ] = 764;
				map[ 1958 ] = 0;
				zones[ 1958 ] = 51;
				zoneIds[ 1958 ] = 789;
				map[ 2161 ] = 0;
				zones[ 2161 ] = 10;
				zoneIds[ 2161 ] = 818;
				map[ 67 ] = 17;
				zones[ 67 ] = 67;
				zoneIds[ 67 ] = 166;
				map[ 880 ] = 0;
				zones[ 880 ] = 45;
				zoneIds[ 880 ] = 679;
				map[ 1763 ] = 1;
				zones[ 1763 ] = 361;
				zoneIds[ 1763 ] = 748;
				map[ 1019 ] = 0;
				zones[ 1019 ] = 139;
				zoneIds[ 1019 ] = 341;
				map[ 1939 ] = 1;
				zones[ 1939 ] = 440;
				zoneIds[ 1939 ] = 783;
				map[ 981 ] = 1;
				zones[ 981 ] = 440;
				zoneIds[ 981 ] = 324;
				map[ 1276 ] = 1;
				zones[ 1276 ] = 331;
				zoneIds[ 1276 ] = 434;
				map[ 1943 ] = 1;
				zones[ 1943 ] = 490;
				zoneIds[ 1943 ] = 787;
				map[ 365 ] = 1;
				zones[ 365 ] = 14;
				zoneIds[ 365 ] = 91;
				map[ 1678 ] = 0;
				zones[ 1678 ] = 36;
				zoneIds[ 1678 ] = 719;
				map[ 608 ] = 1;
				zones[ 608 ] = 405;
				zoneIds[ 608 ] = 605;
				map[ 1978 ] = 0;
				zones[ 1978 ] = 8;
				zoneIds[ 1978 ] = 792;
				map[ 2097 ] = 1;
				zones[ 2097 ] = 400;
				zoneIds[ 2097 ] = 801;
				map[ 2138 ] = 1;
				zones[ 2138 ] = 17;
				zoneIds[ 2138 ] = 813;
				map[ 2237 ] = 1;
				zones[ 2237 ] = 400;
				zoneIds[ 2237 ] = 823;
				map[ 2246 ] = 1;
				zones[ 2246 ] = 618;
				zoneIds[ 2246 ] = 832;
				map[ 515 ] = 1;
				zones[ 515 ] = 15;
				zoneIds[ 515 ] = 533;
				map[ 271 ] = 0;
				zones[ 271 ] = 267;
				zoneIds[ 271 ] = 615;
				map[ 1771 ] = 1;
				zones[ 1771 ] = 361;
				zoneIds[ 1771 ] = 756;
				map[ 2257 ] = 369;
				zones[ 2257 ] = 2257;
				zoneIds[ 2257 ] = 843;
				map[ 2269 ] = 0;
				zones[ 2269 ] = 139;
				zoneIds[ 2269 ] = 855;
				map[ 2275 ] = 0;
				zones[ 2275 ] = 139;
				zoneIds[ 2275 ] = 861;
				map[ 2301 ] = 1;
				zones[ 2301 ] = 331;
				zoneIds[ 2301 ] = 871;
				map[ 455 ] = 1;
				zones[ 455 ] = 148;
				zoneIds[ 455 ] = 485;
				map[ 278 ] = 0;
				zones[ 278 ] = 36;
				zoneIds[ 278 ] = 22;
				map[ 344 ] = 0;
				zones[ 344 ] = 3;
				zoneIds[ 344 ] = 72;
				map[ 373 ] = 1;
				zones[ 373 ] = 14;
				zoneIds[ 373 ] = 98;
				map[ 14 ] = 1;
				zones[ 14 ] = 14;
				zoneIds[ 14 ] = 127;
				map[ 44 ] = 0;
				zones[ 44 ] = 44;
				zoneIds[ 44 ] = 149;
				map[ 141 ] = 1;
				zones[ 141 ] = 141;
				zoneIds[ 141 ] = 220;
				map[ 164 ] = 0;
				zones[ 164 ] = 85;
				zoneIds[ 164 ] = 241;
				map[ 921 ] = 0;
				zones[ 921 ] = 40;
				zoneIds[ 921 ] = 310;
				map[ 1024 ] = 0;
				zones[ 1024 ] = 11;
				zoneIds[ 1024 ] = 346;
				map[ 1440 ] = 0;
				zones[ 1440 ] = 4;
				zoneIds[ 1440 ] = 381;
				map[ 881 ] = 0;
				zones[ 881 ] = 11;
				zoneIds[ 881 ] = 680;
				map[ 1121 ] = 1;
				zones[ 1121 ] = 357;
				zoneIds[ 1121 ] = 414;
				map[ 236 ] = 0;
				zones[ 236 ] = 130;
				zoneIds[ 236 ] = 286;
				map[ 428 ] = 1;
				zones[ 428 ] = 331;
				zoneIds[ 428 ] = 569;
				map[ 602 ] = 1;
				zones[ 602 ] = 405;
				zoneIds[ 602 ] = 599;
				map[ 2378 ] = 269;
				zones[ 2378 ] = 2367;
				zoneIds[ 2378 ] = 908;
				map[ 2537 ] = 1;
				zones[ 2537 ] = 406;
				zoneIds[ 2537 ] = 941;
				map[ 2577 ] = 1;
				zones[ 2577 ] = 357;
				zoneIds[ 2577 ] = 953;
				map[ 1114 ] = 1;
				zones[ 1114 ] = 357;
				zoneIds[ 1114 ] = 356;
				map[ 2057 ] = 289;
				zones[ 2057 ] = 2057;
				zoneIds[ 2057 ] = 797;
				map[ 2248 ] = 1;
				zones[ 2248 ] = 618;
				zoneIds[ 2248 ] = 834;
				map[ 2256 ] = 1;
				zones[ 2256 ] = 618;
				zoneIds[ 2256 ] = 842;
				map[ 2521 ] = 1;
				zones[ 2521 ] = 357;
				zoneIds[ 2521 ] = 939;
				map[ 2267 ] = 0;
				zones[ 2267 ] = 139;
				zoneIds[ 2267 ] = 853;
				map[ 2677 ] = 469;
				zones[ 2677 ] = 2677;
				zoneIds[ 2677 ] = 968;
				map[ 818 ] = 1;
				zones[ 818 ] = 215;
				zoneIds[ 818 ] = 668;
				map[ 2978 ] = 30;
				zones[ 2978 ] = 2597;
				zoneIds[ 2978 ] = 1001;
				map[ 2958 ] = 30;
				zones[ 2958 ] = 2597;
				zoneIds[ 2958 ] = 993;
				map[ 2938 ] = 0;
				zones[ 2938 ] = 41;
				zoneIds[ 2938 ] = 991;
				map[ 3017 ] = 30;
				zones[ 3017 ] = 2597;
				zoneIds[ 3017 ] = 1003;
				map[ 3037 ] = 1;
				zones[ 3037 ] = 400;
				zoneIds[ 3037 ] = 1004;
				map[ 3038 ] = 1;
				zones[ 3038 ] = 400;
				zoneIds[ 3038 ] = 1005;
				map[ 3039 ] = 1;
				zones[ 3039 ] = 400;
				zoneIds[ 3039 ] = 1006;
				map[ 3058 ] = 30;
				zones[ 3058 ] = 2597;
				zoneIds[ 3058 ] = 1008;
				map[ 3097 ] = 1;
				zones[ 3097 ] = 1377;
				zoneIds[ 3097 ] = 1010;
				map[ 3098 ] = 1;
				zones[ 3098 ] = 1377;
				zoneIds[ 3098 ] = 1011;
				map[ 3099 ] = 1;
				zones[ 3099 ] = 1377;
				zoneIds[ 3099 ] = 1012;
				map[ 3100 ] = 1;
				zones[ 3100 ] = 1377;
				zoneIds[ 3100 ] = 1013;
				map[ 3117 ] = 1;
				zones[ 3117 ] = 357;
				zoneIds[ 3117 ] = 1014;
				map[ 2407 ] = 1;
				zones[ 2407 ] = 405;
				zoneIds[ 2407 ] = 920;
				map[ 2300 ] = 1;
				zones[ 2300 ] = 440;
				zoneIds[ 2300 ] = 870;
				map[ 2367 ] = 269;
				zones[ 2367 ] = 2367;
				zoneIds[ 2367 ] = 897;
				map[ 2242 ] = 1;
				zones[ 2242 ] = 618;
				zoneIds[ 2242 ] = 828;
				map[ 2478 ] = 1;
				zones[ 2478 ] = 361;
				zoneIds[ 2478 ] = 930;
				map[ 2252 ] = 1;
				zones[ 2252 ] = 618;
				zoneIds[ 2252 ] = 838;
				map[ 2839 ] = 0;
				zones[ 2839 ] = 36;
				zoneIds[ 2839 ] = 984;
				map[ 2961 ] = 30;
				zones[ 2961 ] = 2597;
				zoneIds[ 2961 ] = 996;
				map[ 272 ] = 0;
				zones[ 272 ] = 267;
				zoneIds[ 272 ] = 19;
				map[ 358 ] = 1;
				zones[ 358 ] = 215;
				zoneIds[ 358 ] = 84;
				map[ 59 ] = 0;
				zones[ 59 ] = 12;
				zoneIds[ 59 ] = 159;
				map[ 166 ] = 0;
				zones[ 166 ] = 85;
				zoneIds[ 166 ] = 243;
				map[ 926 ] = 0;
				zones[ 926 ] = 130;
				zoneIds[ 926 ] = 315;
				map[ 2272 ] = 0;
				zones[ 2272 ] = 139;
				zoneIds[ 2272 ] = 858;
				map[ 2273 ] = 0;
				zones[ 2273 ] = 139;
				zoneIds[ 2273 ] = 859;
				map[ 2274 ] = 0;
				zones[ 2274 ] = 139;
				zoneIds[ 2274 ] = 860;
				map[ 2277 ] = 0;
				zones[ 2277 ] = 139;
				zoneIds[ 2277 ] = 863;
				map[ 2278 ] = 0;
				zones[ 2278 ] = 139;
				zoneIds[ 2278 ] = 864;
				map[ 2280 ] = 0;
				zones[ 2280 ] = 2280;
				zoneIds[ 2280 ] = 866;
				map[ 2298 ] = 0;
				zones[ 2298 ] = 28;
				zoneIds[ 2298 ] = 868;
				map[ 2299 ] = 0;
				zones[ 2299 ] = 139;
				zoneIds[ 2299 ] = 869;
				map[ 3137 ] = 1;
				zones[ 3137 ] = 16;
				zoneIds[ 3137 ] = 1015;
				map[ 3138 ] = 1;
				zones[ 3138 ] = 16;
				zoneIds[ 3138 ] = 1016;
				map[ 3140 ] = 1;
				zones[ 3140 ] = 16;
				zoneIds[ 3140 ] = 1018;
				map[ 3177 ] = 1;
				zones[ 3177 ] = 331;
				zoneIds[ 3177 ] = 1020;
				map[ 1582 ] = 36;
				zones[ 1582 ] = 1581;
				zoneIds[ 1582 ] = 696;
				map[ 3197 ] = 0;
				zones[ 3197 ] = 28;
				zoneIds[ 3197 ] = 1021;
				map[ 1704 ] = 1;
				zones[ 1704 ] = 17;
				zoneIds[ 1704 ] = 733;
				map[ 2238 ] = 1;
				zones[ 2238 ] = 400;
				zoneIds[ 2238 ] = 824;
				map[ 2404 ] = 1;
				zones[ 2404 ] = 405;
				zoneIds[ 2404 ] = 917;
				map[ 2837 ] = 1;
				zones[ 2837 ] = 41;
				zoneIds[ 2837 ] = 982;
				map[ 2937 ] = 0;
				zones[ 2937 ] = 41;
				zoneIds[ 2937 ] = 990;
				map[ 3217 ] = 1;
				zones[ 3217 ] = 2557;
				zoneIds[ 3217 ] = 1022;
				map[ 1339 ] = 0;
				zones[ 1339 ] = 36;
				zoneIds[ 1339 ] = 439;
				map[ 264 ] = 1;
				zones[ 264 ] = 141;
				zoneIds[ 264 ] = 14;
				map[ 362 ] = 1;
				zones[ 362 ] = 14;
				zoneIds[ 362 ] = 88;
				map[ 122 ] = 0;
				zones[ 122 ] = 33;
				zoneIds[ 122 ] = 203;
				map[ 657 ] = 0;
				zones[ 657 ] = 8;
				zoneIds[ 657 ] = 296;
				map[ 1446 ] = 0;
				zones[ 1446 ] = 51;
				zoneIds[ 1446 ] = 387;
				map[ 130 ] = 0;
				zones[ 130 ] = 130;
				zoneIds[ 130 ] = 210;
				map[ 445 ] = 1;
				zones[ 445 ] = 148;
				zoneIds[ 445 ] = 477;
				map[ 576 ] = 0;
				zones[ 576 ] = 10;
				zoneIds[ 576 ] = 546;
				map[ 250 ] = 0;
				zones[ 250 ] = 46;
				zoneIds[ 250 ] = 579;
				map[ 2737 ] = 1;
				zones[ 2737 ] = 1377;
				zoneIds[ 2737 ] = 971;
				map[ 2338 ] = 0;
				zones[ 2338 ] = 33;
				zoneIds[ 2338 ] = 885;
				map[ 1357 ] = 0;
				zones[ 1357 ] = 36;
				zoneIds[ 1357 ] = 440;
				map[ 2118 ] = 0;
				zones[ 2118 ] = 85;
				zoneIds[ 2118 ] = 810;
				map[ 2177 ] = 0;
				zones[ 2177 ] = 33;
				zoneIds[ 2177 ] = 819;
				map[ 2255 ] = 1;
				zones[ 2255 ] = 618;
				zoneIds[ 2255 ] = 841;
				map[ 2897 ] = 1;
				zones[ 2897 ] = 331;
				zoneIds[ 2897 ] = 987;
				map[ 2917 ] = 1;
				zones[ 2917 ] = 2917;
				zoneIds[ 2917 ] = 988;
				map[ 2977 ] = 30;
				zones[ 2977 ] = 2597;
				zoneIds[ 2977 ] = 1000;
				map[ 12 ] = 0;
				zones[ 12 ] = 12;
				zoneIds[ 12 ] = 126;
				map[ 2321 ] = 1;
				zones[ 2321 ] = 16;
				zoneIds[ 2321 ] = 878;
				map[ 2361 ] = 1;
				zones[ 2361 ] = 493;
				zoneIds[ 2361 ] = 891;
				map[ 2400 ] = 0;
				zones[ 2400 ] = 47;
				zoneIds[ 2400 ] = 913;
				map[ 2418 ] = 0;
				zones[ 2418 ] = 46;
				zoneIds[ 2418 ] = 923;
				map[ 2480 ] = 1;
				zones[ 2480 ] = 361;
				zoneIds[ 2480 ] = 932;
				map[ 2522 ] = 1;
				zones[ 2522 ] = 357;
				zoneIds[ 2522 ] = 940;
				map[ 2657 ] = 1;
				zones[ 2657 ] = 405;
				zoneIds[ 2657 ] = 967;
				map[ 2740 ] = 1;
				zones[ 2740 ] = 1377;
				zoneIds[ 2740 ] = 974;
				map[ 2322 ] = 1;
				zones[ 2322 ] = 141;
				zoneIds[ 2322 ] = 879;
				map[ 1765 ] = 1;
				zones[ 1765 ] = 361;
				zoneIds[ 1765 ] = 750;
				map[ 2261 ] = 0;
				zones[ 2261 ] = 139;
				zoneIds[ 2261 ] = 847;
				map[ 2279 ] = 0;
				zones[ 2279 ] = 139;
				zoneIds[ 2279 ] = 865;
				map[ 2318 ] = 1;
				zones[ 2318 ] = 15;
				zoneIds[ 2318 ] = 875;
				map[ 2363 ] = 1;
				zones[ 2363 ] = 493;
				zoneIds[ 2363 ] = 893;
				map[ 2377 ] = 269;
				zones[ 2377 ] = 2367;
				zoneIds[ 2377 ] = 907;
				map[ 2406 ] = 1;
				zones[ 2406 ] = 405;
				zoneIds[ 2406 ] = 919;
				map[ 2558 ] = 0;
				zones[ 2558 ] = 41;
				zoneIds[ 2558 ] = 947;
				map[ 2618 ] = 1;
				zones[ 2618 ] = 361;
				zoneIds[ 2618 ] = 956;
				map[ 2739 ] = 1;
				zones[ 2739 ] = 1377;
				zoneIds[ 2739 ] = 973;
				map[ 2337 ] = 1;
				zones[ 2337 ] = 14;
				zoneIds[ 2337 ] = 884;
				map[ 2239 ] = 1;
				zones[ 2239 ] = 400;
				zoneIds[ 2239 ] = 825;
				map[ 2265 ] = 0;
				zones[ 2265 ] = 139;
				zoneIds[ 2265 ] = 851;
				map[ 2838 ] = 0;
				zones[ 2838 ] = 51;
				zoneIds[ 2838 ] = 983;
				map[ 2253 ] = 1;
				zones[ 2253 ] = 618;
				zoneIds[ 2253 ] = 839;
				map[ 2877 ] = 451;
				zones[ 2877 ] = 22;
				zoneIds[ 2877 ] = 986;
				map[ 418 ] = 1;
				zones[ 418 ] = 331;
				zoneIds[ 418 ] = 457;
				map[ 2957 ] = 30;
				zones[ 2957 ] = 2597;
				zoneIds[ 2957 ] = 992;
				map[ 2959 ] = 30;
				zones[ 2959 ] = 2597;
				zoneIds[ 2959 ] = 994;
				map[ 2960 ] = 30;
				zones[ 2960 ] = 2597;
				zoneIds[ 2960 ] = 995;
				map[ 2962 ] = 30;
				zones[ 2962 ] = 2597;
				zoneIds[ 2962 ] = 997;
				map[ 2963 ] = 30;
				zones[ 2963 ] = 2597;
				zoneIds[ 2963 ] = 998;
				map[ 2964 ] = 30;
				zones[ 2964 ] = 2597;
				zoneIds[ 2964 ] = 999;
				map[ 2276 ] = 0;
				zones[ 2276 ] = 139;
				zoneIds[ 2276 ] = 862;
				map[ 253 ] = 0;
				zones[ 253 ] = 46;
				zoneIds[ 253 ] = 4;
				map[ 263 ] = 1;
				zones[ 263 ] = 141;
				zoneIds[ 263 ] = 13;
				map[ 284 ] = 0;
				zones[ 284 ] = 36;
				zoneIds[ 284 ] = 28;
				map[ 293 ] = 0;
				zones[ 293 ] = 293;
				zoneIds[ 293 ] = 35;
				map[ 309 ] = 0;
				zones[ 309 ] = 11;
				zoneIds[ 309 ] = 47;
				map[ 377 ] = 1;
				zones[ 377 ] = 377;
				zoneIds[ 377 ] = 101;
				map[ 390 ] = 1;
				zones[ 390 ] = 17;
				zoneIds[ 390 ] = 111;
				map[ 9 ] = 0;
				zones[ 9 ] = 12;
				zoneIds[ 9 ] = 125;
				map[ 23 ] = 0;
				zones[ 23 ] = 12;
				zoneIds[ 23 ] = 134;
				map[ 46 ] = 0;
				zones[ 46 ] = 46;
				zoneIds[ 46 ] = 151;
				map[ 75 ] = 0;
				zones[ 75 ] = 8;
				zoneIds[ 75 ] = 172;
				map[ 99 ] = 0;
				zones[ 99 ] = 33;
				zoneIds[ 99 ] = 189;
				map[ 108 ] = 0;
				zones[ 108 ] = 40;
				zoneIds[ 108 ] = 196;
				map[ 125 ] = 0;
				zones[ 125 ] = 33;
				zoneIds[ 125 ] = 205;
				map[ 2159 ] = 1;
				zones[ 2159 ] = 2159;
				zoneIds[ 2159 ] = 816;
				map[ 2244 ] = 1;
				zones[ 2244 ] = 618;
				zoneIds[ 2244 ] = 830;
				map[ 68 ] = 0;
				zones[ 68 ] = 44;
				zoneIds[ 68 ] = 557;
				map[ 640 ] = 1;
				zones[ 640 ] = 14;
				zoneIds[ 640 ] = 638;
				map[ 2258 ] = 0;
				zones[ 2258 ] = 139;
				zoneIds[ 2258 ] = 844;
				map[ 2271 ] = 0;
				zones[ 2271 ] = 139;
				zoneIds[ 2271 ] = 857;
				map[ 2297 ] = 0;
				zones[ 2297 ] = 28;
				zoneIds[ 2297 ] = 867;
				map[ 24 ] = 0;
				zones[ 24 ] = 12;
				zoneIds[ 24 ] = 135;
				map[ 152 ] = 0;
				zones[ 152 ] = 85;
				zoneIds[ 152 ] = 230;
				map[ 156 ] = 0;
				zones[ 156 ] = 85;
				zoneIds[ 156 ] = 233;
				map[ 157 ] = 0;
				zones[ 157 ] = 85;
				zoneIds[ 157 ] = 234;
				map[ 163 ] = 0;
				zones[ 163 ] = 85;
				zoneIds[ 163 ] = 240;
				map[ 1718 ] = 1;
				zones[ 1718 ] = 17;
				zoneIds[ 1718 ] = 735;
				map[ 1760 ] = 0;
				zones[ 1760 ] = 33;
				zoneIds[ 1760 ] = 745;
				map[ 1780 ] = 0;
				zones[ 1780 ] = 8;
				zoneIds[ 1780 ] = 760;
				map[ 186 ] = 1;
				zones[ 186 ] = 141;
				zoneIds[ 186 ] = 622;
				map[ 1877 ] = 0;
				zones[ 1877 ] = 3;
				zoneIds[ 1877 ] = 767;
				map[ 1878 ] = 0;
				zones[ 1878 ] = 3;
				zoneIds[ 1878 ] = 768;
				map[ 1879 ] = 0;
				zones[ 1879 ] = 3;
				zoneIds[ 1879 ] = 769;
				map[ 1884 ] = 0;
				zones[ 1884 ] = 47;
				zoneIds[ 1884 ] = 774;
				map[ 195 ] = 0;
				zones[ 195 ] = 28;
				zoneIds[ 195 ] = 253;
				map[ 196 ] = 0;
				zones[ 196 ] = 28;
				zoneIds[ 196 ] = 578;
				map[ 201 ] = 0;
				zones[ 201 ] = 28;
				zoneIds[ 201 ] = 258;
				map[ 204 ] = 0;
				zones[ 204 ] = 130;
				zoneIds[ 204 ] = 261;
				map[ 209 ] = 33;
				zones[ 209 ] = 209;
				zoneIds[ 209 ] = 266;
				map[ 2098 ] = 0;
				zones[ 2098 ] = 10;
				zoneIds[ 2098 ] = 802;
				map[ 2197 ] = 1;
				zones[ 2197 ] = 1638;
				zoneIds[ 2197 ] = 820;
				map[ 1457 ] = 0;
				zones[ 1457 ] = 4;
				zoneIds[ 1457 ] = 388;
				map[ 149 ] = 0;
				zones[ 149 ] = 38;
				zoneIds[ 149 ] = 228;
				map[ 928 ] = 0;
				zones[ 928 ] = 130;
				zoneIds[ 928 ] = 317;
				map[ 2250 ] = 1;
				zones[ 2250 ] = 618;
				zoneIds[ 2250 ] = 836;
				map[ 511 ] = 1;
				zones[ 511 ] = 15;
				zoneIds[ 511 ] = 529;
				map[ 322 ] = 0;
				zones[ 322 ] = 45;
				zoneIds[ 322 ] = 581;
				map[ 820 ] = 1;
				zones[ 820 ] = 215;
				zoneIds[ 820 ] = 670;
				map[ 2561 ] = 0;
				zones[ 2561 ] = 41;
				zoneIds[ 2561 ] = 950;
				map[ 1857 ] = 0;
				zones[ 1857 ] = 45;
				zoneIds[ 1857 ] = 765;
				map[ 2379 ] = 269;
				zones[ 2379 ] = 2367;
				zoneIds[ 2379 ] = 909;
				map[ 1703 ] = 1;
				zones[ 1703 ] = 17;
				zoneIds[ 1703 ] = 732;
				map[ 2626 ] = 0;
				zones[ 2626 ] = 139;
				zoneIds[ 2626 ] = 964;
				map[ 95 ] = 0;
				zones[ 95 ] = 44;
				zoneIds[ 95 ] = 185;
				map[ 392 ] = 1;
				zones[ 392 ] = 17;
				zoneIds[ 392 ] = 113;
				map[ 498 ] = 1;
				zones[ 498 ] = 15;
				zoneIds[ 498 ] = 521;
				map[ 2741 ] = 1;
				zones[ 2741 ] = 1377;
				zoneIds[ 2741 ] = 975;
				map[ 2198 ] = 1;
				zones[ 2198 ] = 405;
				zoneIds[ 2198 ] = 821;
				map[ 2918 ] = 449;
				zones[ 2918 ] = 2918;
				zoneIds[ 2918 ] = 989;
				map[ 3077 ] = 1;
				zones[ 3077 ] = 1377;
				zoneIds[ 3077 ] = 1009;
				map[ 3157 ] = 1;
				zones[ 3157 ] = 406;
				zoneIds[ 3157 ] = 1019;
				map[ 165 ] = 0;
				zones[ 165 ] = 85;
				zoneIds[ 165 ] = 242;
				map[ 306 ] = 0;
				zones[ 306 ] = 130;
				zoneIds[ 306 ] = 45;
				map[ 432 ] = 1;
				zones[ 432 ] = 331;
				zoneIds[ 432 ] = 466;
				map[ 2365 ] = 0;
				zones[ 2365 ] = 11;
				zoneIds[ 2365 ] = 895;
				map[ 736 ] = 1;
				zones[ 736 ] = 141;
				zoneIds[ 736 ] = 645;
				map[ 406 ] = 1;
				zones[ 406 ] = 406;
				zoneIds[ 406 ] = 446;
				map[ 16 ] = 1;
				zones[ 16 ] = 16;
				zoneIds[ 16 ] = 129;
				map[ 925 ] = 0;
				zones[ 925 ] = 38;
				zoneIds[ 925 ] = 314;
				map[ 927 ] = 0;
				zones[ 927 ] = 130;
				zoneIds[ 927 ] = 316;
				map[ 2597 ] = 30;
				zones[ 2597 ] = 2597;
				zoneIds[ 2597 ] = 954;
				map[ 1232 ] = 1;
				zones[ 1232 ] = 16;
				zoneIds[ 1232 ] = 427;
				map[ 1682 ] = 0;
				zones[ 1682 ] = 36;
				zoneIds[ 1682 ] = 723;
				map[ 1738 ] = 0;
				zones[ 1738 ] = 33;
				zoneIds[ 1738 ] = 737;
				map[ 1778 ] = 0;
				zones[ 1778 ] = 8;
				zoneIds[ 1778 ] = 758;
				map[ 1940 ] = 1;
				zones[ 1940 ] = 440;
				zoneIds[ 1940 ] = 784;
				map[ 3139 ] = 1;
				zones[ 3139 ] = 618;
				zoneIds[ 3139 ] = 1017;
				map[ 337 ] = 0;
				zones[ 337 ] = 3;
				zoneIds[ 337 ] = 67;
				map[ 3257 ] = 1;
				zones[ 3257 ] = 1377;
				zoneIds[ 3257 ] = 1024;
				map[ 400 ] = 1;
				zones[ 400 ] = 400;
				zoneIds[ 400 ] = 442;
				map[ 3277 ] = 489;
				zones[ 3277 ] = 3277;
				zoneIds[ 3277 ] = 1025;
				map[ 821 ] = 1;
				zones[ 821 ] = 215;
				zoneIds[ 821 ] = 671;
				map[ 3057 ] = 30;
				zones[ 3057 ] = 2597;
				zoneIds[ 3057 ] = 1007;
				map[ 3237 ] = 1;
				zones[ 3237 ] = 2557;
				zoneIds[ 3237 ] = 1023;
				map[ 3297 ] = 30;
				zones[ 3297 ] = 2597;
				zoneIds[ 3297 ] = 1026;
				map[ 3298 ] = 30;
				zones[ 3298 ] = 2597;
				zoneIds[ 3298 ] = 1027;
				map[ 3299 ] = 30;
				zones[ 3299 ] = 2597;
				zoneIds[ 3299 ] = 1028;
				map[ 3300 ] = 30;
				zones[ 3300 ] = 2597;
				zoneIds[ 3300 ] = 1029;
				map[ 3301 ] = 30;
				zones[ 3301 ] = 2597;
				zoneIds[ 3301 ] = 1030;
				map[ 3302 ] = 30;
				zones[ 3302 ] = 2597;
				zoneIds[ 3302 ] = 1031;
				map[ 3303 ] = 30;
				zones[ 3303 ] = 2597;
				zoneIds[ 3303 ] = 1032;
				map[ 3304 ] = 30;
				zones[ 3304 ] = 2597;
				zoneIds[ 3304 ] = 1033;
				map[ 3305 ] = 30;
				zones[ 3305 ] = 2597;
				zoneIds[ 3305 ] = 1034;
				map[ 3306 ] = 30;
				zones[ 3306 ] = 2597;
				zoneIds[ 3306 ] = 1035;
				map[ 3317 ] = 0;
				zones[ 3317 ] = 47;
				zoneIds[ 3317 ] = 1036;
				map[ 3318 ] = 30;
				zones[ 3318 ] = 2597;
				zoneIds[ 3318 ] = 1037;
				map[ 3319 ] = 1;
				zones[ 3319 ] = 331;
				zoneIds[ 3319 ] = 1038;
				map[ 3320 ] = 489;
				zones[ 3320 ] = 3277;
				zoneIds[ 3320 ] = 1039;
				map[ 3321 ] = 489;
				zones[ 3321 ] = 3277;
				zoneIds[ 3321 ] = 1040;
				map[ 518 ] = 1;
				zones[ 518 ] = 15;
				zoneIds[ 518 ] = 536;
				map[ 3337 ] = 30;
				zones[ 3337 ] = 2597;
				zoneIds[ 3337 ] = 1041;
				map[ 3338 ] = 30;
				zones[ 3338 ] = 2597;
				zoneIds[ 3338 ] = 1042;
				map[ 1997 ] = 1;
				zones[ 1997 ] = 361;
				zoneIds[ 1997 ] = 793;
				map[ 105 ] = 0;
				zones[ 105 ] = 33;
				zoneIds[ 105 ] = 193;
				map[ 1104 ] = 1;
				zones[ 1104 ] = 357;
				zoneIds[ 1104 ] = 398;
				map[ 1117 ] = 1;
				zones[ 1117 ] = 357;
				zoneIds[ 1117 ] = 359;
				map[ 13 ] = 0;
				zones[ 13 ] = 10;
				zoneIds[ 13 ] = 555;
				map[ 1445 ] = 0;
				zones[ 1445 ] = 51;
				zoneIds[ 1445 ] = 386;
				map[ 1477 ] = 0;
				zones[ 1477 ] = 1477;
				zoneIds[ 1477 ] = 389;
				map[ 255 ] = 0;
				zones[ 255 ] = 46;
				zoneIds[ 255 ] = 5;
				map[ 265 ] = 1;
				zones[ 265 ] = 141;
				zoneIds[ 265 ] = 15;
				map[ 282 ] = 0;
				zones[ 282 ] = 36;
				zoneIds[ 282 ] = 26;
				map[ 294 ] = 0;
				zones[ 294 ] = 267;
				zoneIds[ 294 ] = 36;
				map[ 310 ] = 0;
				zones[ 310 ] = 33;
				zoneIds[ 310 ] = 48;
				map[ 326 ] = 0;
				zones[ 326 ] = 45;
				zoneIds[ 326 ] = 58;
				map[ 334 ] = 0;
				zones[ 334 ] = 45;
				zoneIds[ 334 ] = 64;
				map[ 348 ] = 0;
				zones[ 348 ] = 47;
				zoneIds[ 348 ] = 76;
				map[ 357 ] = 1;
				zones[ 357 ] = 357;
				zoneIds[ 357 ] = 83;
				map[ 366 ] = 1;
				zones[ 366 ] = 14;
				zoneIds[ 366 ] = 92;
				map[ 379 ] = 1;
				zones[ 379 ] = 17;
				zoneIds[ 379 ] = 103;
				map[ 393 ] = 1;
				zones[ 393 ] = 14;
				zoneIds[ 393 ] = 114;
				map[ 2 ] = 0;
				zones[ 2 ] = 40;
				zoneIds[ 2 ] = 120;
				map[ 17 ] = 1;
				zones[ 17 ] = 17;
				zoneIds[ 17 ] = 130;
				map[ 34 ] = 0;
				zones[ 34 ] = 12;
				zoneIds[ 34 ] = 141;
				map[ 45 ] = 0;
				zones[ 45 ] = 45;
				zoneIds[ 45 ] = 150;
				map[ 57 ] = 0;
				zones[ 57 ] = 12;
				zoneIds[ 57 ] = 158;
				map[ 72 ] = 0;
				zones[ 72 ] = 4;
				zoneIds[ 72 ] = 169;
				map[ 91 ] = 0;
				zones[ 91 ] = 12;
				zoneIds[ 91 ] = 183;
				map[ 104 ] = 0;
				zones[ 104 ] = 33;
				zoneIds[ 104 ] = 192;
				map[ 121 ] = 0;
				zones[ 121 ] = 10;
				zoneIds[ 121 ] = 202;
				map[ 136 ] = 0;
				zones[ 136 ] = 1;
				zoneIds[ 136 ] = 216;
				map[ 150 ] = 0;
				zones[ 150 ] = 11;
				zoneIds[ 150 ] = 229;
				map[ 162 ] = 0;
				zones[ 162 ] = 85;
				zoneIds[ 162 ] = 239;
				map[ 193 ] = 0;
				zones[ 193 ] = 28;
				zoneIds[ 193 ] = 252;
				map[ 206 ] = 36;
				zones[ 206 ] = 206;
				zoneIds[ 206 ] = 263;
				map[ 219 ] = 0;
				zones[ 219 ] = 40;
				zoneIds[ 219 ] = 273;
				map[ 233 ] = 0;
				zones[ 233 ] = 130;
				zoneIds[ 233 ] = 285;
				map[ 656 ] = 1;
				zones[ 656 ] = 493;
				zoneIds[ 656 ] = 295;
				map[ 924 ] = 0;
				zones[ 924 ] = 38;
				zoneIds[ 924 ] = 313;
				map[ 979 ] = 1;
				zones[ 979 ] = 440;
				zoneIds[ 979 ] = 322;
				map[ 1017 ] = 0;
				zones[ 1017 ] = 11;
				zoneIds[ 1017 ] = 339;
				map[ 1102 ] = 1;
				zones[ 1102 ] = 357;
				zoneIds[ 1102 ] = 350;
				map[ 1196 ] = 1;
				zones[ 1196 ] = 1196;
				zoneIds[ 1196 ] = 363;
				map[ 1176 ] = 209;
				zones[ 1176 ] = 1176;
				zoneIds[ 1176 ] = 371;
				map[ 1439 ] = 0;
				zones[ 1439 ] = 4;
				zoneIds[ 1439 ] = 380;
				map[ 1557 ] = 1;
				zones[ 1557 ] = 400;
				zoneIds[ 1557 ] = 690;
				map[ 120 ] = 0;
				zones[ 120 ] = 12;
				zoneIds[ 120 ] = 559;
				map[ 261 ] = 1;
				zones[ 261 ] = 141;
				zoneIds[ 261 ] = 11;
				map[ 1100 ] = 1;
				zones[ 1100 ] = 357;
				zoneIds[ 1100 ] = 395;
				map[ 1112 ] = 1;
				zones[ 1112 ] = 357;
				zoneIds[ 1112 ] = 404;
				map[ 321 ] = 0;
				zones[ 321 ] = 45;
				zoneIds[ 321 ] = 54;
				map[ 223 ] = 1;
				zones[ 223 ] = 215;
				zoneIds[ 223 ] = 276;
				map[ 83 ] = 451;
				zones[ 83 ] = 22;
				zoneIds[ 83 ] = 177;
				map[ 996 ] = 0;
				zones[ 996 ] = 44;
				zoneIds[ 996 ] = 408;
				map[ 1223 ] = 1;
				zones[ 1223 ] = 16;
				zoneIds[ 1223 ] = 418;
				map[ 1236 ] = 1;
				zones[ 1236 ] = 16;
				zoneIds[ 1236 ] = 431;
				map[ 109 ] = 0;
				zones[ 109 ] = 40;
				zoneIds[ 109 ] = 197;
				map[ 413 ] = 1;
				zones[ 413 ] = 331;
				zoneIds[ 413 ] = 452;
				map[ 407 ] = 1;
				zones[ 407 ] = 14;
				zoneIds[ 407 ] = 447;
				map[ 420 ] = 1;
				zones[ 420 ] = 331;
				zoneIds[ 420 ] = 459;
				map[ 435 ] = 1;
				zones[ 435 ] = 331;
				zoneIds[ 435 ] = 468;
				map[ 447 ] = 1;
				zones[ 447 ] = 148;
				zoneIds[ 447 ] = 479;
				map[ 463 ] = 1;
				zones[ 463 ] = 406;
				zoneIds[ 463 ] = 490;
				map[ 483 ] = 1;
				zones[ 483 ] = 400;
				zoneIds[ 483 ] = 507;
				map[ 496 ] = 1;
				zones[ 496 ] = 15;
				zoneIds[ 496 ] = 518;
				map[ 509 ] = 1;
				zones[ 509 ] = 15;
				zoneIds[ 509 ] = 528;
				map[ 538 ] = 1;
				zones[ 538 ] = 490;
				zoneIds[ 538 ] = 539;
				map[ 382 ] = 1;
				zones[ 382 ] = 17;
				zoneIds[ 382 ] = 552;
				map[ 245 ] = 0;
				zones[ 245 ] = 10;
				zoneIds[ 245 ] = 563;
				map[ 503 ] = 1;
				zones[ 503 ] = 15;
				zoneIds[ 503 ] = 573;
				map[ 102 ] = 0;
				zones[ 102 ] = 33;
				zoneIds[ 102 ] = 586;
				map[ 598 ] = 1;
				zones[ 598 ] = 405;
				zoneIds[ 598 ] = 595;
				map[ 399 ] = 1;
				zones[ 399 ] = 215;
				zoneIds[ 399 ] = 610;
				map[ 173 ] = 0;
				zones[ 173 ] = 85;
				zoneIds[ 173 ] = 620;
				map[ 618 ] = 1;
				zones[ 618 ] = 618;
				zoneIds[ 618 ] = 621;
				map[ 117 ] = 0;
				zones[ 117 ] = 33;
				zoneIds[ 117 ] = 629;
				map[ 719 ] = 48;
				zones[ 719 ] = 719;
				zoneIds[ 719 ] = 642;
				map[ 804 ] = 0;
				zones[ 804 ] = 1;
				zoneIds[ 804 ] = 654;
				map[ 816 ] = 1;
				zones[ 816 ] = 14;
				zoneIds[ 816 ] = 666;
				map[ 878 ] = 1;
				zones[ 878 ] = 16;
				zoneIds[ 878 ] = 677;
				map[ 2317 ] = 1;
				zones[ 2317 ] = 440;
				zoneIds[ 2317 ] = 874;
				map[ 2360 ] = 1;
				zones[ 2360 ] = 331;
				zoneIds[ 2360 ] = 890;
				map[ 2372 ] = 269;
				zones[ 2372 ] = 2367;
				zoneIds[ 2372 ] = 902;
				map[ 2405 ] = 1;
				zones[ 2405 ] = 405;
				zoneIds[ 2405 ] = 918;
				map[ 2479 ] = 1;
				zones[ 2479 ] = 361;
				zoneIds[ 2479 ] = 931;
				map[ 2560 ] = 0;
				zones[ 2560 ] = 41;
				zoneIds[ 2560 ] = 949;
				map[ 2622 ] = 0;
				zones[ 2622 ] = 139;
				zoneIds[ 2622 ] = 960;
				map[ 1584 ] = 0;
				zones[ 1584 ] = 1584;
				zoneIds[ 1584 ] = 698;
				map[ 1880 ] = 0;
				zones[ 1880 ] = 47;
				zoneIds[ 1880 ] = 770;
				map[ 2158 ] = 1;
				zones[ 2158 ] = 15;
				zoneIds[ 2158 ] = 815;
				map[ 1603 ] = 1;
				zones[ 1603 ] = 17;
				zoneIds[ 1603 ] = 705;
				map[ 1679 ] = 0;
				zones[ 1679 ] = 36;
				zoneIds[ 1679 ] = 720;
				map[ 1737 ] = 0;
				zones[ 1737 ] = 33;
				zoneIds[ 1737 ] = 736;
				map[ 916 ] = 0;
				zones[ 916 ] = 40;
				zoneIds[ 916 ] = 681;
				map[ 2357 ] = 1;
				zones[ 2357 ] = 331;
				zoneIds[ 2357 ] = 887;
				map[ 370 ] = 1;
				zones[ 370 ] = 14;
				zoneIds[ 370 ] = 96;
				map[ 339 ] = 0;
				zones[ 339 ] = 3;
				zoneIds[ 339 ] = 634;
				map[ 1764 ] = 1;
				zones[ 1764 ] = 361;
				zoneIds[ 1764 ] = 749;
				map[ 1817 ] = 0;
				zones[ 1817 ] = 8;
				zoneIds[ 1817 ] = 763;
				map[ 1898 ] = 0;
				zones[ 1898 ] = 3;
				zoneIds[ 1898 ] = 779;
				map[ 1639 ] = 1;
				zones[ 1639 ] = 1638;
				zoneIds[ 1639 ] = 709;
				map[ 1701 ] = 1;
				zones[ 1701 ] = 17;
				zoneIds[ 1701 ] = 730;
				map[ 1798 ] = 0;
				zones[ 1798 ] = 8;
				zoneIds[ 1798 ] = 762;
				map[ 1297 ] = 1;
				zones[ 1297 ] = 14;
				zoneIds[ 1297 ] = 407;
				map[ 1942 ] = 1;
				zones[ 1942 ] = 490;
				zoneIds[ 1942 ] = 786;
				map[ 350 ] = 0;
				zones[ 350 ] = 47;
				zoneIds[ 350 ] = 78;
				map[ 313 ] = 0;
				zones[ 313 ] = 45;
				zoneIds[ 313 ] = 632;
				map[ 1977 ] = 309;
				zones[ 1977 ] = 1977;
				zoneIds[ 1977 ] = 791;
				map[ 2100 ] = 349;
				zones[ 2100 ] = 2100;
				zoneIds[ 2100 ] = 804;
				map[ 3424 ] = 529;
				zones[ 3424 ] = 3358;
				zoneIds[ 3424 ] = 1062;
				map[ 3420 ] = 529;
				zones[ 3420 ] = 3358;
				zoneIds[ 3420 ] = 1058;
				map[ 3421 ] = 529;
				zones[ 3421 ] = 3358;
				zoneIds[ 3421 ] = 1059;
				map[ 3422 ] = 529;
				zones[ 3422 ] = 3358;
				zoneIds[ 3422 ] = 1060;
				map[ 3423 ] = 529;
				zones[ 3423 ] = 3358;
				zoneIds[ 3423 ] = 1061;
				map[ 22 ] = 451;
				zones[ 22 ] = 22;
				zoneIds[ 22 ] = 547;
				map[ 221 ] = 1;
				zones[ 221 ] = 215;
				zoneIds[ 221 ] = 274;
				map[ 2217 ] = 1;
				zones[ 2217 ] = 405;
				zoneIds[ 2217 ] = 822;
				map[ 224 ] = 1;
				zones[ 224 ] = 215;
				zoneIds[ 224 ] = 277;
				map[ 2241 ] = 1;
				zones[ 2241 ] = 618;
				zoneIds[ 2241 ] = 827;
				map[ 2268 ] = 0;
				zones[ 2268 ] = 139;
				zoneIds[ 2268 ] = 854;
				map[ 2325 ] = 1;
				zones[ 2325 ] = 331;
				zoneIds[ 2325 ] = 882;
				map[ 2419 ] = 0;
				zones[ 2419 ] = 46;
				zoneIds[ 2419 ] = 924;
				map[ 246 ] = 0;
				zones[ 246 ] = 51;
				zoneIds[ 246 ] = 293;
				map[ 2477 ] = 1;
				zones[ 2477 ] = 1377;
				zoneIds[ 2477 ] = 929;
				map[ 2481 ] = 1;
				zones[ 2481 ] = 361;
				zoneIds[ 2481 ] = 933;
				map[ 2540 ] = 1;
				zones[ 2540 ] = 406;
				zoneIds[ 2540 ] = 944;
				map[ 257 ] = 1;
				zones[ 257 ] = 141;
				zoneIds[ 257 ] = 7;
				map[ 2619 ] = 0;
				zones[ 2619 ] = 139;
				zoneIds[ 2619 ] = 957;
				map[ 2627 ] = 0;
				zones[ 2627 ] = 139;
				zoneIds[ 2627 ] = 965;
				map[ 298 ] = 0;
				zones[ 298 ] = 11;
				zoneIds[ 298 ] = 39;
				map[ 3 ] = 0;
				zones[ 3 ] = 3;
				zoneIds[ 3 ] = 121;
				map[ 325 ] = 0;
				zones[ 325 ] = 45;
				zoneIds[ 325 ] = 57;
				map[ 340 ] = 0;
				zones[ 340 ] = 3;
				zoneIds[ 340 ] = 68;
				map[ 347 ] = 0;
				zones[ 347 ] = 3;
				zoneIds[ 347 ] = 75;
				map[ 36 ] = 0;
				zones[ 36 ] = 36;
				zoneIds[ 36 ] = 143;
				map[ 364 ] = 1;
				zones[ 364 ] = 14;
				zoneIds[ 364 ] = 90;
				map[ 368 ] = 1;
				zones[ 368 ] = 14;
				zoneIds[ 368 ] = 94;
				map[ 383 ] = 1;
				zones[ 383 ] = 17;
				zoneIds[ 383 ] = 106;
				map[ 426 ] = 1;
				zones[ 426 ] = 331;
				zoneIds[ 426 ] = 463;
				map[ 439 ] = 1;
				zones[ 439 ] = 400;
				zoneIds[ 439 ] = 471;
				map[ 441 ] = 1;
				zones[ 441 ] = 331;
				zoneIds[ 441 ] = 473;
				map[ 444 ] = 1;
				zones[ 444 ] = 148;
				zoneIds[ 444 ] = 476;
				map[ 450 ] = 1;
				zones[ 450 ] = 148;
				zoneIds[ 450 ] = 482;
				map[ 457 ] = 1;
				zones[ 457 ] = 457;
				zoneIds[ 457 ] = 571;
				map[ 459 ] = 0;
				zones[ 459 ] = 85;
				zoneIds[ 459 ] = 375;
				map[ 484 ] = 1;
				zones[ 484 ] = 400;
				zoneIds[ 484 ] = 508;
				map[ 499 ] = 1;
				zones[ 499 ] = 15;
				zoneIds[ 499 ] = 522;
				map[ 510 ] = 1;
				zones[ 510 ] = 15;
				zoneIds[ 510 ] = 584;
				map[ 543 ] = 1;
				zones[ 543 ] = 490;
				zoneIds[ 543 ] = 544;
				map[ 606 ] = 1;
				zones[ 606 ] = 405;
				zoneIds[ 606 ] = 603;
				map[ 62 ] = 0;
				zones[ 62 ] = 12;
				zoneIds[ 62 ] = 161;
				map[ 64 ] = 0;
				zones[ 64 ] = 12;
				zoneIds[ 64 ] = 163;
				map[ 65 ] = 0;
				zones[ 65 ] = 65;
				zoneIds[ 65 ] = 164;
				map[ 702 ] = 1;
				zones[ 702 ] = 141;
				zoneIds[ 702 ] = 304;
				map[ 73 ] = 0;
				zones[ 73 ] = 4;
				zoneIds[ 73 ] = 170;
				map[ 801 ] = 0;
				zones[ 801 ] = 1;
				zoneIds[ 801 ] = 651;
				map[ 802 ] = 0;
				zones[ 802 ] = 1;
				zoneIds[ 802 ] = 652;
				map[ 803 ] = 0;
				zones[ 803 ] = 1;
				zoneIds[ 803 ] = 653;
				map[ 81 ] = 451;
				zones[ 81 ] = 22;
				zoneIds[ 81 ] = 575;
				map[ 813 ] = 0;
				zones[ 813 ] = 28;
				zoneIds[ 813 ] = 663;
				map[ 920 ] = 0;
				zones[ 920 ] = 40;
				zoneIds[ 920 ] = 309;
				map[ 93 ] = 0;
				zones[ 93 ] = 10;
				zoneIds[ 93 ] = 628;
				map[ 982 ] = 1;
				zones[ 982 ] = 440;
				zoneIds[ 982 ] = 325;
				map[ 3357 ] = 0;
				zones[ 3357 ] = 33;
				zoneIds[ 3357 ] = 1043;
				map[ 3358 ] = 529;
				zones[ 3358 ] = 3358;
				zoneIds[ 3358 ] = 1044;
				map[ 3377 ] = 309;
				zones[ 3377 ] = 1977;
				zoneIds[ 3377 ] = 1045;
				map[ 3378 ] = 309;
				zones[ 3378 ] = 1977;
				zoneIds[ 3378 ] = 1046;
				map[ 3379 ] = 309;
				zones[ 3379 ] = 1977;
				zoneIds[ 3379 ] = 1047;
				map[ 3380 ] = 309;
				zones[ 3380 ] = 1977;
				zoneIds[ 3380 ] = 1048;
				map[ 3381 ] = 309;
				zones[ 3381 ] = 1977;
				zoneIds[ 3381 ] = 1049;
				map[ 3382 ] = 309;
				zones[ 3382 ] = 1977;
				zoneIds[ 3382 ] = 1050;
				map[ 3383 ] = 309;
				zones[ 3383 ] = 1977;
				zoneIds[ 3383 ] = 1051;
				map[ 1578 ] = 0;
				zones[ 1578 ] = 33;
				zoneIds[ 1578 ] = 692;
				map[ 192 ] = 0;
				zones[ 192 ] = 28;
				zoneIds[ 192 ] = 251;
				map[ 3384 ] = 309;
				zones[ 3384 ] = 1977;
				zoneIds[ 3384 ] = 1052;
				map[ 3397 ] = 309;
				zones[ 3397 ] = 1977;
				zoneIds[ 3397 ] = 1053;
				map[ 3398 ] = 309;
				zones[ 3398 ] = 1977;
				zoneIds[ 3398 ] = 1054;

				#endregion
				#region Herb association			
				World.GameObjectsAssociated[ 1618 ] = typeof( BaseHerb );// Peacebloom );
				World.GameObjectsAssociated[ 3725 ] = typeof( BaseHerb );// Silverleaf );
				World.GameObjectsAssociated[ 3726 ] = typeof( BaseHerb );// Earthroot );
				World.GameObjectsAssociated[ 3727 ] = typeof( BaseHerb );// Mageroyal );
				World.GameObjectsAssociated[ 3729 ] = typeof( BaseHerb );// Briarthorn );
				World.GameObjectsAssociated[ 2045 ] = typeof( BaseHerb );// Stranglekelp );
				World.GameObjectsAssociated[ 3730 ] = typeof( BaseHerb );// Bruiseweed );
				World.GameObjectsAssociated[ 1623 ] = typeof( BaseHerb );// WildSteelbloom );
				World.GameObjectsAssociated[ 1628 ] = typeof( BaseHerb );// GraveMoss );
				World.GameObjectsAssociated[ 1624 ] = typeof( BaseHerb );// Kingsblood );
				World.GameObjectsAssociated[ 2041 ] = typeof( BaseHerb );// Liferoot );
				World.GameObjectsAssociated[ 2042 ] = typeof( BaseHerb );// Fadeleaf );
				World.GameObjectsAssociated[ 2046 ] = typeof( BaseHerb );// Goldthorn );
				World.GameObjectsAssociated[ 2043 ] = typeof( BaseHerb );// KhadgarsWhisker );
				World.GameObjectsAssociated[ 2044 ] = typeof( BaseHerb );// Wintersbite );
				World.GameObjectsAssociated[ 2866 ] = typeof( BaseHerb );// Firebloom );
				World.GameObjectsAssociated[ 142140 ] = typeof( BaseHerb );// PurpleLotus );
				World.GameObjectsAssociated[ 142141 ] = typeof( BaseHerb );// ArthasTears );
				World.GameObjectsAssociated[ 142142 ] = typeof( BaseHerb );// Sungrass );
				World.GameObjectsAssociated[ 142143 ] = typeof( BaseHerb );// Blindweed );
				World.GameObjectsAssociated[ 142144 ] = typeof( BaseHerb );// GhostMushroom );
				World.GameObjectsAssociated[ 142145 ] = typeof( BaseHerb );// Gromsblood );
				World.GameObjectsAssociated[ 176583 ] = typeof( BaseHerb );// GoldenSansam );
				World.GameObjectsAssociated[ 176584 ] = typeof( BaseHerb );// Dreamfoil );
				World.GameObjectsAssociated[ 176586 ] = typeof( BaseHerb );// MountainSilversage );
				World.GameObjectsAssociated[ 176587 ] = typeof( BaseHerb );// Plaguebloom );
				World.GameObjectsAssociated[ 176588 ] = typeof( BaseHerb );// Icecap );
				World.GameObjectsAssociated[ 176589 ] = typeof( BaseHerb );// BlackLotus );
				#endregion
				#region Vein list
				World.GameObjectsAssociated[ 1731 ] = typeof( BaseMine );// Copper Vein
				World.GameObjectsAssociated[ 1732 ] = typeof( BaseMine );// Tin Vein
				World.GameObjectsAssociated[ 1733 ] = typeof( BaseMine );// Silver Vein
				World.GameObjectsAssociated[ 1735 ] = typeof( BaseMine );// Iron Deposit
				World.GameObjectsAssociated[ 1734 ] = typeof( BaseMine );// Gold Vein
				World.GameObjectsAssociated[ 2040 ] = typeof( BaseMine );// Mithril Deposit
				World.GameObjectsAssociated[ 147516 ] = typeof( BaseMine );// Dark Iron
				World.GameObjectsAssociated[ 2047 ] = typeof( BaseMine );// Truesilver Deposit
				World.GameObjectsAssociated[ 324 ] = typeof( BaseMine );// Small Thorium Vein
				World.GameObjectsAssociated[ 175404 ] = typeof( BaseMine );// Rich Thorium Vein
				#endregion
				for(int t = 0;t < timers.Length;t++ )
				{
					timers[ t ] = new Queue();
					lastCall[ t ] = DateTime.Now.Ticks;
				}
				CustomSpellHandlers initSpellHandlersValues = new CustomSpellHandlers();
				Type []types = Utility.externAsm[ "Items" ].GetTypes();
				Hashtable files = new Hashtable();
			
				TextReader trItems = new StreamReader( World.Path + "items.txt" );
				while( true )
				{
					string name = trItems.ReadLine();
					if ( name == null )
						break;
					int id = Convert.ToInt32( trItems.ReadLine() );
					itemsHash[ name ] = id;
				}
				foreach( Type t in types )
				{
					if ( t.IsSubclassOf( typeof( Item ) ) )
					{
						AddItem( t );
						#region Automatic treasure list
						/*
						float a = 1;
						string cat = "";
						if ( i.BuyPrice < 51 )
						{
							cat = "Beginners";
							a = (float)i.BuyPrice / 51f;
						}
						else
							if ( i .BuyPrice < 500 )
						{
							cat = "Low";
							a = (float)i.BuyPrice / 500f;
						}
						else
							if ( i .BuyPrice < 5000 )
						{
							cat = "Medium";
							a = (float)i.BuyPrice / 5000f;
						}
						else
							if ( i .BuyPrice < 10000 )
						{
							cat = "Advanced";
							a = (float)i.BuyPrice / 10000f;
						}
						else
							if ( i .BuyPrice < 50000 )
						{
							cat = "High";
							a = (float)i.BuyPrice / 50000f;
						}
						else
							if ( i .BuyPrice < 100000 )
						{
							cat = "Amazing";
							a = (float)i.BuyPrice / 100000f;
						}
						else
						{
							//	if ( i .BuyPrice < 500000 )
							cat = "Incredible";
							a = (float)i.BuyPrice / 500000f;
						}
					//	else
					//		cat = 7;
						string typ = "NoCategory";
						if ( i.ObjectClass == 4 )
						{
							if ( i.SubClass == 0 )
								typ = "RingsAndJewels";
							else
								if ( i.SubClass == 1 )
								typ = "Cloths";
							else
								if ( i.SubClass == 2 )
								typ = "LeatherArmors";
							else
								if ( i.SubClass == 3 )
								typ = "MailArmors";
							else
								if ( i.SubClass == 4 )
								typ = "PlateArmors";
							else
								if ( i.SubClass == 6 )
								typ = "Shields";
						}
						else
							if ( i.ObjectClass == 6 )
							typ = "Ammos";
						else
							if ( i.ObjectClass == 11 || i.ObjectClass == 1 )
							typ = "Containers";
						else
							if ( i.ObjectClass == 0 )
							typ = "Consumable";
						else
							if ( i.ObjectClass == 7 )
						{
							if ( i.SubClass == 3 )
								typ = "FinalMaterials";
							else
								if ( i.SubClass == 0 )
								typ = "PrimMaterials";
							else
								if ( i.SubClass == 1 )
								typ = "SecondMaterials";
							else
								if ( i.SubClass == 2 )
								typ = "ThirdMaterials";
						}
						else
							if ( i.ObjectClass == 15 )
							typ = "MiscelenaousItems";
						else
							if ( i.ObjectClass == 9 )
							typ = "PlansAndRecipes";
						else
							if ( i.ObjectClass == 2 )
						{
							if ( i.SubClass == 0 )
								typ = "Axes";
							else
								if ( i.SubClass == 2 || i.SubClass == 18 )
								typ = "BowsAndCrossbows";
							else
								if ( i.SubClass == 13 )
								typ = "Claws";
							else
								if ( i.SubClass == 15 || i.SubClass == 7 )
								typ = "SwordsAndDaggers";
							else
								if ( i.SubClass == 4 )
								typ = "MacesAndHammers";
							else
								if ( i.SubClass == 3 )
								typ = "Muskets";
							else
								if ( i.SubClass == 6 )
								typ = "Spears";
							else
								if ( i.SubClass == 10 || i.SubClass == 19 )
								typ = "StavesAndWands";
							else
								if ( i.SubClass == 14 || i.SubClass == 20 )
								typ = "Tools";
							else
								if ( i.SubClass == 16 )
								typ = "ThrowingWeapons";
							else
								if ( i.SubClass == 1 || i.SubClass == 5 || i.SubClass == 8 )
								typ = "TwoHandedWeapons";
						}

						a = 1 - a;
						a *= 100f;
						if ( a < 0f ) 
							a = 0.0001f;
						if ( a > 95f )
							a = 95.000f;
						if ( files[ cat+typ ] == null )
						{
							TextWriter ntw = new StreamWriter( cat+typ+".cs" );
							files[ cat+typ ] = ntw;
							ntw.WriteLine( "//////////////////////////////////////////////////////////" );
							ntw.WriteLine( "// DrNexus " + cat + " " + typ + " Treasure list" );
							ntw.WriteLine( "//////////////////////////////////////////////////////////" );
							ntw.WriteLine( "using Server;" );
							ntw.WriteLine( "namespace Server.Items" );
							ntw.WriteLine( "{" );
							ntw.WriteLine( "\tpublic class " + cat + typ + "Drops" );
							ntw.WriteLine( "\t{" );
							ntw.WriteLine( "\t\tpublic static Loot[]" + cat + typ + " = new Loot[]" );
							ntw.WriteLine( "\t\t{" );
							ntw.WriteLine( "\t\t\tnew Loot( typeof( " + Utility.ClassName( i ) + " ), " + a.ToString() + "f )" );
						//		ntw.WriteLine( i.Id.ToString() + ";" + Utility.ClassName( i ) );
						
						}
						else
						{
							TextWriter ntw = (TextWriter)files[ cat+typ ];
							ntw.WriteLine( "\t\t\t\t, new Loot( typeof( " + Utility.ClassName( i ) + " ), " + a.ToString() + "f )" );
							//ntw.WriteLine( i.Id.ToString() + ";" + Utility.ClassName( i ) );						
						}*/
						#endregion
					}
				}
				itemsHash.Clear();
				/*	TextWriter tw = new StreamWriter( "./items.txt" );
					foreach( Item ite in allItems )
					{
						tw.WriteLine( ite.GetType().ToString() );
						tw.WriteLine( ite.Id.ToString() );
					}
					tw.Close();*/
				types = null;
				GC.Collect();
				//	TextWriter tw = new StreamWriter( "mob.txt" );
				types = Utility.externAsm[ "Creatures" ].GetTypes();
				
				foreach( Type t in types )
				{
					if ( t.IsSubclassOf( typeof( BaseCreature ) ) )
					{
						try
						{
							ConstructorInfo []cts = t.GetConstructors();
							BaseCreature bc = (BaseCreature)cts[ 0 ].Invoke( null );
							int id = bc.Id;
							mobilePool[ id ] = cts[ 0 ];	
							//	tw.WriteLine("{0}\t{1}\t{2}", bc.Name, bc.Id, bc.Level );
							allMobs.Add( bc );
						}
						catch( Exception )
						{
							Console.WriteLine( "Error in the constructor of {0}", t.ToString() );
						}
					}
				}
				poolsReady = true;
				types = Utility.externAsm[ "Quests" ].GetTypes();				
				foreach( Type t in types )
				{
					Type type = null;
					try
					{
						ConstructorInfo []ci = t.GetConstructors();
						BaseQuest i = (BaseQuest)ci[ 0 ].Invoke( null );
						questPool[ i.Id ] = i;
						questPoolType[ t ] = i;
					}
					catch( Exception e )
					{
						Console.WriteLine("Error in the quest constructor of {0}", type.ToString() );
						Console.WriteLine("{0}", e.Message.ToString() );
						Console.WriteLine("{0}", e.StackTrace.ToString() );
					}
				}
				GC.Collect();
				//	tw.Close();

				ConstructorInfo ct;// = Utility.FindConstructor( "Spawner", Utility.externAsm );
				//Mobile tempSpawner = (Mobile)ct.Invoke( null );
				//mobilePool[ tempSpawner.Id ] = ct;
				//	ct = Utility.FindConstructor( "GameObjectSpawner", Utility.externAsm );
				//	tempSpawner = (Mobile)ct.Invoke( null );
				//	mobilePool[ tempSpawner.Id ] = ct;

				TalentList initTalentSystem = new TalentList();

				GenericReader gr;

				DateTime ta = DateTime.Now;
				allSpawners = new SpawnerList( gr = new GenericReader( World.Path + "spawnpoints.bin" ) );

				TimeSpan ts =  DateTime.Now.Subtract( ta );

				allGameObjects = new GameObjects( new GenericReader( World.Path + "objects.bin" ) );
				allMobiles = new MobileList( new GenericReader( World.Path + "savegame.bin" ) );
			}
			else
				allMobiles = new MobileList( new GenericReader( World.Path + "savegame.bin" ) );
			#endregion
			allAccounts = new Accounts( World.Path + "accounts.xml" );

			#region Initialize standard server part 2
			if ( !RealmServer )
			{
				ConstructorInfo ct;
				trajets = new Trajets( new GenericReader( World.Path + "coord.bin" ) );
				ct = Utility.FindConstructor( "GameObjectList", Utility.externAsm[ "Game Objects" ] );
				ct.Invoke( null );


				#region SKILL ASSOCIATION
				Item.skillIdAssoc[ 4 * 100 + 1 ] = ClothSkill.SkillId;
				Item.skillIdAssoc[ 4 * 100 + 2 ] = LeatherSkill.SkillId;
				Item.skillIdAssoc[ 4 * 100 + 3 ] = MailSkill.SkillId;
				Item.skillIdAssoc[ 4 * 100 + 4 ] = PlateMailSkill.SkillId;
				Item.skillIdAssoc[ 4 * 100 + 6 ] = ShieldSkill.SkillId;
			
				Item.skillIdAssoc[ 2 * 100 + 0 ] = AxeSkill.SkillId;
				Item.skillIdAssoc[ 2 * 100 + 2 ] = BowsSkill.SkillId;
				//skillAssoc[ 2 * 100 + 18 ] = CrossbowSkill.SkillId;
				Item.skillIdAssoc[ 2 * 100 + 15 ] = DaggerSkill.SkillId;
				Item.skillIdAssoc[ 2 * 100 + 4 ] = MacesSkill.SkillId;
				Item.skillIdAssoc[ 2 * 100 + 3 ] = GunSkill.SkillId;
				//	skillAssoc[ 2 * 100 + 6 ] = SpearSkill.SkillId;
				Item.skillIdAssoc[ 2 * 100 + 10 ] = StavesSkill.SkillId;
				Item.skillIdAssoc[ 2 * 100 + 7 ] = SwordSkill.SkillId;
				Item.skillIdAssoc[ 2 * 100 + 16 ] = ThrowsSkill.SkillId;
				Item.skillIdAssoc[ 2 * 100 + 1 ] = TwoHandedAxeSkill.SkillId;
				Item.skillIdAssoc[ 2 * 100 + 5 ] = TwoHandedMaceSkill.SkillId;
				Item.skillIdAssoc[ 2 * 100 + 8 ] = TwoHandedSwordSkill.SkillId;
				Item.skillIdAssoc[ 2 * 100 + 19 ] = WandsSkill.SkillId;
				#endregion
				#region Faction Association
				factionsAssociated[ Factions.GnomereganExiles ] = 18;
				factionsAssociated[ Factions.Stormwind ] = 19;
				factionsAssociated[ Factions.IronForge ] = 20;
				factionsAssociated[ Factions.Darnasus ] = 21;
			
				factionsAssociated[ Factions.Ogrimmar ] = 14;
				factionsAssociated[ Factions.Undercity ] = 17;
				factionsAssociated[ Factions.ThunderBluff ] = 16;
				factionsAssociated[ Factions.DarkspearTrolls ] = 15;

				factionsAssociated[ Factions.Horde ] = 48;
				factionsAssociated[ Factions.Alliance ] = 47;
				#endregion
				#region Friend races list
				FriendRaces[ Races.Human ] = new ArrayList();
				FriendRaces[ Races.Orc ] = new ArrayList();
				FriendRaces[ Races.Gnome ] = new ArrayList();
				FriendRaces[ Races.Dwarf ] = new ArrayList();
				FriendRaces[ Races.Troll ] = new ArrayList();
				FriendRaces[ Races.Tauren ] = new ArrayList();
				FriendRaces[ Races.Undead ] = new ArrayList();
				FriendRaces[ Races.NightElf ] = new ArrayList();
				( FriendRaces[ Races.Human ] as ArrayList ).Add( Factions.Stormwind );
				( FriendRaces[ Races.Human ] as ArrayList ).Add( Factions.GnomereganExiles );
				( FriendRaces[ Races.Human ] as ArrayList ).Add( Factions.Alliance );
				( FriendRaces[ Races.Human ] as ArrayList ).Add( Factions.Darnasus );
				( FriendRaces[ Races.Human ] as ArrayList ).Add( Factions.IronForge );
				( FriendRaces[ Races.Dwarf ] as ArrayList ).Add( Factions.Stormwind );
				( FriendRaces[ Races.Dwarf ] as ArrayList ).Add( Factions.GnomereganExiles );
				( FriendRaces[ Races.Dwarf ] as ArrayList ).Add( Factions.Alliance );
				( FriendRaces[ Races.Dwarf ] as ArrayList ).Add( Factions.Darnasus );
				( FriendRaces[ Races.Dwarf ] as ArrayList ).Add( Factions.IronForge );
				( FriendRaces[ Races.NightElf ] as ArrayList ).Add( Factions.Stormwind );
				( FriendRaces[ Races.NightElf ] as ArrayList ).Add( Factions.GnomereganExiles );
				( FriendRaces[ Races.NightElf ] as ArrayList ).Add( Factions.Alliance );
				( FriendRaces[ Races.NightElf ] as ArrayList ).Add( Factions.Darnasus );
				( FriendRaces[ Races.NightElf ] as ArrayList ).Add( Factions.IronForge );
				( FriendRaces[ Races.Gnome ] as ArrayList ).Add( Factions.Stormwind );
				( FriendRaces[ Races.Gnome ] as ArrayList ).Add( Factions.GnomereganExiles );
				( FriendRaces[ Races.Gnome ] as ArrayList ).Add( Factions.Alliance );
				( FriendRaces[ Races.Gnome ] as ArrayList ).Add( Factions.Darnasus );
				( FriendRaces[ Races.Gnome ] as ArrayList ).Add( Factions.IronForge );
				( FriendRaces[ Races.Orc ] as ArrayList ).Add( Factions.Ogrimmar );
				( FriendRaces[ Races.Orc ] as ArrayList ).Add( Factions.ThunderBluff );
				( FriendRaces[ Races.Orc ] as ArrayList ).Add( Factions.DarkspearTrolls );
				( FriendRaces[ Races.Orc ] as ArrayList ).Add( Factions.Undercity );
				( FriendRaces[ Races.Orc ] as ArrayList ).Add( Factions.Horde );
				( FriendRaces[ Races.Undead ] as ArrayList ).Add( Factions.Ogrimmar );
				( FriendRaces[ Races.Undead ] as ArrayList ).Add( Factions.ThunderBluff );
				( FriendRaces[ Races.Undead ] as ArrayList ).Add( Factions.DarkspearTrolls );
				( FriendRaces[ Races.Undead ] as ArrayList ).Add( Factions.Undercity );
				( FriendRaces[ Races.Undead ] as ArrayList ).Add( Factions.Horde );
				( FriendRaces[ Races.Tauren ] as ArrayList ).Add( Factions.Ogrimmar );
				( FriendRaces[ Races.Tauren ] as ArrayList ).Add( Factions.ThunderBluff );
				( FriendRaces[ Races.Tauren ] as ArrayList ).Add( Factions.DarkspearTrolls );
				( FriendRaces[ Races.Tauren ] as ArrayList ).Add( Factions.Undercity );
				( FriendRaces[ Races.Tauren ] as ArrayList ).Add( Factions.Horde );
				( FriendRaces[ Races.Troll ] as ArrayList ).Add( Factions.Ogrimmar );
				( FriendRaces[ Races.Troll ] as ArrayList ).Add( Factions.ThunderBluff );
				( FriendRaces[ Races.Troll ] as ArrayList ).Add( Factions.DarkspearTrolls );
				( FriendRaces[ Races.Troll ] as ArrayList ).Add( Factions.Undercity );
				( FriendRaces[ Races.Troll ] as ArrayList ).Add( Factions.Horde );
				#endregion
				SpellTemplate.SpellEffects[ 7266 ] = new SingleTargetSpellEffect( Character.OnCastInvisibility );

				SpellTemplate.SpellEffects[ 0xA14 ] = 
					new OnSelfSpellEffect( Profession.OnFindMineral );
				SpellTemplate.SpellEffects[ 6478 ] = 
					new GameObjectTargetSpellEffect( GameObject.OnUseHandler );
	

				Assembly ass = Assembly.GetAssembly( typeof( Utility ) ); 
				Type []types = ass.GetTypes(); 
				for (int i=0; i< types.Length;i++) 
				{ 
					if ( types[ i ].GetInterface("IInitialize",true) != null )
					{ 
						System.Reflection.MethodInfo info = ((Type)types[i]).GetMethod("Initialize", BindingFlags.Static | BindingFlags.Public); 
						if (info!=null) 
						{ 
							info.Invoke( null, null ); 
							//	Console.WriteLine("Found object {0}", info.Name); 
						} 
					} 
				}

				ConstructorInfo glob = Utility.FindConstructor( "Globals", Utility.externAsm[ "globals" ] );
				glob.Invoke( null );			
				//	force le chargement de la base de sort
				int ider = Abilities.abilities[ 4 ].Id;
				worldSaveTimer = new WorldSave( WorldSavingTimer );

				float TILESIZE =(533.33333f);
				float CHUNKSIZE =((TILESIZE) / 16.0f);
				float UNITSIZE =(CHUNKSIZE / 8.0f);
				int pas = 0;
				int op = 0;
				for (int j=0; j<17; j++) 
				{
					int n = 8;
					if ( j % 2 == 0 )
						n = 9;
					for (int k=0; k<n; k++) 
					{
						pas++;
						//if ( pas % 4 != 0 )
						//	continue;
						float x,z;

						x = (float)k * UNITSIZE;
						z = (float)j * 0.5f * UNITSIZE;
						if (j%2 == 1) 
						{
							x += UNITSIZE*0.5f;
						}
						Zone.quickX[ op ] = x;
						Zone.quickY[ op++ ] = z;
					}
				}

				//	Load Map 
				Console.Write( "Loading maps..." );
				mapZones = new MapZones();
				//World.mapZones.RawLoadAll();
				Console.WriteLine( "[Done]" );
			}
			#endregion
			int nAccount = 0;
			int nCharacter = 0;
			
						foreach( Account acc in World.allAccounts )
						{		
							nAccount++;
							foreach( Character ch in acc.characteres )
							{
								nCharacter++;
								if ( ch.Friends == null )
									continue;
								ArrayList final = new ArrayList();
								for(int t = 0;t < ch.Friends.Count;t+=2 )
								{
									UInt64 guid = (UInt64)ch.Friends[ t ];
									string user = (string)ch.Friends[ t + 1 ];
									Account into = null;
									foreach( Account acc2 in World.allAccounts )
									{	
										if ( user == acc2.Username )
										{
											into = acc2;
											break;
										}
									}
									if ( into != null )
										foreach( Character ch2 in into.characteres )
										{
											if ( ch2.Guid == guid )
											{
												final.Add( ch2 );
												break;
											}
										}
						
								}
								ch.Friends = final;
							}
						}
						
			#region Region timers
			/*	IDictionaryEnumerator enumZones = zones.GetEnumerator();
				while (enumZones.MoveNext())
				{
					new ZoneTimer( enumZones.Value );
				}*/

			#endregion
			Console.WriteLine("{0} accounts, {1} characters", nAccount, nCharacter );
			loading = false;

			#region Standard region final
			if ( !RealmServer )
			{
				NPCQuests.Init();
				allMobs.Clear();
				Console.WriteLine( "Standard server mode" );
			}	
				#endregion
			else
				Console.WriteLine( "Realm list server mode" );
		}
	
	/*	public class ZoneTimer : WowTimer
		{
			int zoneId;
			public ZoneTimer( int zone ) : base( WowTimer.Priorities.Second30 , 30000 )
			{
				zoneId = zone;
			}
			public override void OnTick()
			{
				foreach( Character ch in World.allConnectedChars )
				{
					if ( ch.QuickDistance( 
				}
				base.OnTick ();
			}
		}*/
		public static void AdjustSpawnersNew()
		{
			int completed = 0;
			SpawnerList nsp = new SpawnerList();
			foreach( BaseSpawner bs in allSpawners )
			{
				if ( bs.MapId > 1 )
					Console.WriteLine("Invalid spawner at {0} {1} {2} continent {3}", bs.X, bs.Y, bs.Z, bs.MapId );
				else
				{
					bs.ZoneId = World.mapZones.NearestZoneId( bs.MapId, bs.X, bs.Y );
					if ( bs.ZoneId == -1 )
						Console.WriteLine("Invalid spawner at {0} {1} {2} continent {3}", bs.X, bs.Y, bs.Z, bs.MapId );
					else
					{
						if ( bs is MobileSpawner )
						{
							MapPoint mp = World.mapZones.NearestPoint( bs.ZoneHash, bs.MapId, bs.ZoneId, bs.X, bs.Y );
							( bs as MobileSpawner ).RealX = mp.x;
							( bs as MobileSpawner ).RealY = mp.y;
							( bs as MobileSpawner ).RealZ = mp.z;
						}						
						nsp.Add( bs );
					}
				}
				completed++;
				if ( completed % 500 == 0 )
					Console.WriteLine("Completed {0} %", ( (float)completed / (float)allSpawners.Count ) * 100f);
			}
			allSpawners = nsp;
		}
/*
		public static void AdjustSpawners()
		{
			int completed = 0;
			foreach( BaseSpawner bs in allSpawners )
			{
				if ( bs is MobileSpawner )
				{
					int zi = World.mapZones.NearestZoneId( bs.MapId, bs.X, bs.Y );
					bs.ZoneId = zi;
					MapPoint mp = World.mapZones.NearestPoint( null, bs.MapId, bs.ZoneId, bs.X, bs.Z );
					( bs as MobileSpawner ).RealX = mp.y;
					( bs as MobileSpawner ).RealY = mp.x;
					( bs as MobileSpawner ).RealZ = mp.z;
				}
				completed++;
				if ( completed % 500 == 0 )
				{
					Console.WriteLine("Import {0} %", 100 *
						 (float)completed / (float)allSpawners.Count );
				}
			}
		}*/
		public static void AdjustSpawners()
		{
			int nout = 0;
			//	Map Y
			FileStream fs = new FileStream( "coordk.bin", FileMode.Open, FileAccess.Read);
			BinaryReader r = new BinaryReader(fs);

			ArrayList []allZone = new ArrayList[ 8192 ];
			//allZone[ 0 ] = new ArrayList();
			//allZone[ 1 ] = new ArrayList();
			while( true )
			{
				if ( r.BaseStream.Position == r.BaseStream.Length )
					break;
				int areaid = r.ReadInt32();
				float xpos = r.ReadSingle();
				float ypos = r.ReadSingle();
				float zpos = r.ReadSingle();
				float []h = new float[ 145 ];
				int o = 0;
				int pass = 0;

				for (int j=0; j<17; j++) 
				{
					int n = 8;
					if ( j % 2 == 0 )
						n = 9;
					for (int k=0; k<n; k++) 
					{
						pass++;
						//		if ( pass % 4 != 0 )
						//			continue;
						float v = r.ReadSingle();
						if ( v <= -10000 )
							h[ o++ ] = -10000;
						else
							h[ o++ ] = v + ypos;
					}
				}
				if ( World.map[ areaid ] == null )
				{
					nout++;					
				}
				else
				{
					int mapid = (int)World.map[ areaid ];
					if ( allZone[ mapid ] == null )
						allZone[ mapid ] = new ArrayList();
					allZone[ mapid ].Add( new Zone( xpos, zpos, ypos, areaid, h ) );
				}
			
			}
			fs.Close();
			/*
			FileStream fsk = new FileStream( "coordk.bin", FileMode.Open, FileAccess.Read);
			BinaryReader rk = new BinaryReader(fsk);
			while( true )
			{
				if ( rk.BaseStream.Position == rk.BaseStream.Length )
					break;
				int areaid = rk.ReadInt32();
				float xpos = rk.ReadSingle();
				float ypos = rk.ReadSingle();
				float zpos = rk.ReadSingle();
				float []h = new float[ 145 ];
				int o = 0;
				int pass = 0;

				for (int j=0; j<17; j++) 
				{
					int n = 8;
					if ( j % 2 == 0 )
						n = 9;
					for (int k=0; k<n; k++) 
					{
						pass++;
						//		if ( pass % 4 != 0 )
						//			continue;
						float v = rk.ReadSingle();
						if ( v <= -10000 )
							h[ o++ ] = -10000;
						else
							h[ o++ ] = v + ypos;
					}
				}
				allZone[ 1 ].Add( new Zone( xpos, zpos, ypos, areaid, h ) );
			}
			fsk.Close();*/
		/*	Hashtable allrzone = new Hashtable();
			foreach( Zone z in allZone[ 1 ] )
			{
				ArrayList az = (allrzone[ z.zoneId ] as ArrayList );
				if ( az != null )
				{
					az.Add( z );
				}
				else
				{
					ArrayList a = new ArrayList();
					a.Add( z );
					allrzone[ z.zoneId ] = a;
				}
			}*/

			int completed = 0;
			foreach( BaseSpawner bs in allSpawners )
			{
				
				float dist = float.MaxValue;
				int zoneid = 0;
				Zone zone = null;
			//	if ( bs.MapId > 1 || bs.MapId < 0 )
			//		continue;
			//	bool trouve = false;
				if ( allZone[ bs.MapId ] == null )
				{
					Console.WriteLine("Unknow map id {0}", bs.MapId );
					continue;
				}
				completed++;
				foreach( Zone z in allZone[ bs.MapId ] )
				{
					float px = Math.Abs( z.y - bs.X );
					float py = Math.Abs( z.x - bs.Y );
					px *= px;
					py *= py;
					px += py;
					if ( px < dist )
					{
						dist = px;
						zoneid = z.zoneId;
						zone = z;
					}
				}
			//	if ( !trouve )
				{
					bs.ZoneId = (ushort)zoneid;
					if ( bs is MobileSpawner )
					{
						( bs as MobileSpawner ).RealX = zone.y;
						( bs as MobileSpawner ).RealY = zone.x;
						( bs as MobileSpawner ).RealZ = zone.z;
					}
				}
				
				if ( completed % 500 == 0 )
					Console.WriteLine("Completed {0}", (float)completed / allSpawners.Count );//zoneid, Math.Sqrt( dist ) );
			}
			int tot = 0;
			for(int i = 0;i < World.allSpawners.Count;i++ )
				//	foreach( BaseSpawner bs in World.allSpawners )
			{
				BaseSpawner bs = World.allSpawners[ i ] as BaseSpawner;
				for(int t = 0;t < World.allSpawners.Count;t++ )
				{
					BaseSpawner bs2 = World.allSpawners[ t ] as BaseSpawner;
					//foreach( BaseSpawner bs2 in World.allSpawners )
				
					if ( t == i || bs.MapId != bs2.MapId )
						continue;
					if ( bs.QuickDistance( bs2 ) < 150 * 150 )
					{
					//	uint sh = (uint)( bs.Guid & 0xffffffff );
						if ( regSpawners[ i ] == null )
							regSpawners[ i ] = new ArrayList();
						//( regcount[ sh ] as ArrayList ).Add( bs2 );
						( regSpawners[ i ] as ArrayList ).Add( t );
						tot++;
					}
				}
				
			}
			World.Save();
		}
		#endregion

		#region RESTART PROCESS
		/// <summary>
		/// 
		/// </summary>
		/// <param name="minutes"></param>
		public static void Restart( int minutes )
		{			
			if ( minutes == 0 )
			{
				string str = "Server is restarting now !!! ";
				allConnectedAccounts.BroadCastMessage( str );
				MainConsole.world.SaveGame();
				MainConsole.Restart();
			}
			else
			{
				new WorldRestart( minutes );
				string str = "Server will restart in " + minutes.ToString() + " minutes ...";
				allConnectedAccounts.BroadCastMessage( str );
			}
		}
		private class WorldRestart : WowTimer
		{
			int last = 0;
			int inMinute = 0;
			public WorldRestart( int time ) : base( WowTimer.Priorities.Minute , 60000, "WorldRestart" )
			{
				inMinute = time;
				Start();
			}
			public override void OnTick()
			{
				last++;
				if ( last > inMinute )
				{					
					string str = "Server is restarting now !!! ";
					allConnectedAccounts.BroadCastMessage( str );
					MainConsole.world.SaveGame();
					MainConsole.Restart();
					Stop();
					return;
				}				
				if ( last != inMinute && inMinute != 0 )
				{
					string str = "Server will restart in " + ( inMinute - last ).ToString() + " minutes ...";
					allConnectedAccounts.BroadCastMessage( str );
				}
				base.OnTick ();
			}

		}
		#endregion

		public static Trajet AllocateTrajet()
		{
			Trajet t = new Trajet();
			trajets.Add( t );
			return t;
		}
		public static void RemoveTrajet( Trajet t )
		{
			trajets.Remove( t );
		}

		public void SaveGame()
		{
			worldSaveTimer.Save();
		}
		public static void Save()
		{
			MainConsole.world.SaveGame();
		}
		public static Item CreateItemInPoolById( int id )
		{
			if ( itemPool[ id ] == null )
				return null;
			return (Item)( itemPool[ id ] as ConstructorInfo ).Invoke( null );
		}
		public static Type ItemTypeById( int id )
		{
			return ( itemPool[ id ] as ConstructorInfo ).ReflectedType;// .DeclaringType;
		}
		public static Type MobileTypeById( int id )
		{
			ConstructorInfo ci = mobilePool[ id ] as ConstructorInfo;
			if ( ci == null )
				Console.WriteLine("Unknow mobile id {0} !!!", id );
			return ci.DeclaringType;
		}
		public static BaseQuest CreateQuestById( int id )
		{
			return (BaseQuest)questPool[ id ];
		}
		public static BaseQuest CreateQuestByType( Type typ )
		{
			return (BaseQuest)questPoolType[ typ ];
		}
		public static ConstructorInfo MobilePool( int id )
		{
			return (ConstructorInfo)mobilePool[ id ];
		}
		public static GameObject Add( int gameObjectId, float X, float Y, float Z, float O, ushort MapId )
		{
			GameObject go = new GameObject( gameObjectId, X, Y, Z, MapId );
			go.Orientation = O;
		//	allGameObjects.Add( go );
			return go;
		}
		public static GameObject Add( int gameObjectId, float X, float Y, float Z, ushort MapId )
		{
			return Add( gameObjectId, X, Y, Z, 0, MapId );
		}
		public static void Add( BaseSpawner bs, float X, float Y, float Z, ushort MapId )
		{			
			allSpawners.Add( bs );
			bs.X = X;
			bs.Y = Y;
			bs.Z = Z;
			bs.MapId = MapId;
		}
		public static GameObject Add( int fake, string customgameobject, float X, float Y, float Z, float O, ushort MapId )
		{
			GameObject go = null;
#if !DEBUG
			try
			{
#endif
				if ( customgameobject == null )
					return Add( fake, X, Y, Z, MapId );
				ConstructorInfo ct = Utility.FindConstructor( customgameobject, Utility.externAsm[ "game objects" ] );
				if ( ct == null )
					ct = Utility.FindConstructor( customgameobject );
				go = (GameObject)ct.Invoke( null );
				go.X = X;
				go.Y = Y;
				go.Z = Z;			
				go.MapId = MapId;		
#if !DEBUG
			}
			catch( Exception e )
			{
				Console.WriteLine("Crash in add go {0}", fake );
				if ( customgameobject != null )
					Console.WriteLine("class = {0}", customgameobject );
			}
#endif
			return go;
		}
		public static GameObject Add( int fake, string customgameobject, float X, float Y, float Z, ushort MapId )
		{
			return World.Add( fake, customgameobject, X, Y, Z, 0, MapId );
		}
		public static BaseCreature Add( string mob, float X, float Y, float Z, ushort MapId )
		{
			ConstructorInfo ct = Utility.FindConstructor( mob, Utility.externAsm[ "creatures" ] );
			BaseCreature bc = null;
			bc =  (BaseCreature)ct.Invoke( null );
			bc.X = X;
			bc.Y = Y;
			bc.Z = Z;
			bc.MapId = MapId;
			World.allMobiles.Add( bc, true );		
			return bc;
		}
		public static BaseCreature Add( ConstructorInfo ct, float X, float Y, float Z, ushort MapId )
		{
			BaseCreature bc = null;
			bc =  (BaseCreature)ct.Invoke( null );
			bc.X = X;
			bc.Y = Y;
			bc.Z = Z;
			bc.MapId = MapId;
			World.allMobiles.Add( bc, true );		
			return bc;
		}

		public static void Add( BaseCreature bc, float X, float Y, float Z, ushort MapId )
		{
			bc.X = X;
			bc.Y = Y;
			bc.Z = Z;
			bc.MapId = MapId;
			if ( !World.Loading )
				World.allMobiles.Add( bc, true );				
		}
		public static Corps Add( Character c, float X, float Y, float Z, ushort MapId )
		{
			Corps corps = new Corps( c.Guid );
			corps.X = X;
			corps.Y = Y;
			corps.Z = Z;
			corps.MapId = MapId;
			corps.Name = c.Name;
			corps.Model = c.Model;
			corps.Faction = c.Faction;
			corps.Bytes3 = (uint)( ( (uint)c.FacialHair << 24 )| ( (uint)c.Face ) | ((uint)c.HairStyle << 8) | ((uint)c.HairColour << 16 )  );
			corps.Bytes2 = (((uint)c.Skin )<<24) /*+ (((uint)c.Gender )<<16)*/ +  ( ( (uint)c.Race << 8 ) );
			World.allMobiles.Add( corps, false );	
			float nearest = float.MaxValue;
			BaseSpawner nearSpawner = null;
			foreach( BaseSpawner bs in World.allSpawners )
				if ( bs.Distance( corps ) < nearest )
				{
					nearest = bs.Distance( corps );
					nearSpawner = bs;
				}
			if ( nearSpawner != null )
			{
				nearSpawner.Bind( corps );			
				corps.SpawnerLink = nearSpawner;
			}
			return corps;
		}
		/*public static void Remove( Object o )
		{
			if ( o is Mobile )
				World.allMobiles.Remove( o as Mobile );
			else
				if ( o is GameObject )
				World.allGameObjects.Remove( o as GameObject );
			//o.DestroyObject();
			byte []b = { 0x00, 0x0A, 0xAA, 0x00, 0x6E, 0x36, 0x05, 0x00, 0x00, 0x00, 0x00, 0x00 };
			int t = 4;
			Converter.ToBytes( o.Guid, b, ref t );
			World.ToNearestPlayer( o.X, o.Y, o.Z, 0xAA, b, t );
		}*/
		public static void Remove( Object o, Mobile from )
		{
			if ( World.allMobiles == null )
				return;
			if ( from.LastSeen != null && from.LastSeen.Player.KnownObjects.Contains( o ) )
				Remove( o, from.LastSeen );
			else
			{
				if ( o is Mobile )
					World.allMobiles.Remove( o as Mobile );
				else
					if ( o is GameObject )
					World.allGameObjects.Remove( o as GameObject );
			}
		}/*
		public static void Remove( Object o, Character from )
		{
			if ( o is Mobile )
				World.allMobiles.Remove( o as Mobile );
			else
				if ( o is GameObject )
				World.allGameObjects.Remove( o as GameObject );
			//o.DestroyObject();
			byte []b = { 0x00, 0x0A, 0xAA, 0x00, 0x6E, 0x36, 0x05, 0x00, 0x00, 0x00, 0x00, 0x00 };
			int t = 4;
			Converter.ToBytes( o.Guid, b, ref t );
			from.Player.ToAllPlayerNear( OpCodes.SMSG_DESTROY_OBJECT, b, t );
		}*/
		public static Item CreateItem( string item )
		{
			ConstructorInfo ct = Utility.FindConstructor( item, Utility.externAsm[ "Items" ] );
			return (Item)ct.Invoke( null );
		}
		public void TimerReport()
		{
			int t = 0;
			foreach( Queue timer in World.timers )
				Console.WriteLine("Timer queue {0} = {1}", t++, timer.Count );
		}

		#region TIMERS
		public static DateTime startingTime = DateTime.Now;
		public static long total = 0;
		public static long []localTime = new long[ 4 ];
		static DateTime datetime = DateTime.Now;
		public void Slice1ms()
		{
			WowTimer currentTimer = null;
/*#if !DEBUG
			try
			{
#endif*/
				int []elapse = { 1, 10, 100, 500, 1000, 5000, 30000, 60000, 60000 * 60 };
			//	int scan = 0;
				
				while( notEnded )
				{
			/*		if ( scan % 10000 == 0 )
					{
						for(int j = 0;j < elapse.Length;j++ )
							Console.WriteLine("Timers {0} ms : {1}", elapse[ j ], timers[ j ].Count );
					}
					scan++;*/
					/*
					foreach( Account a in World.allConnectedAccounts )
					{
						a.ExMutuel.WaitOne();
						if ( a.Packets.Count > 0 )
						{
							Packet p = (Packet)a.Packets.Dequeue();
							a.Handler.DequeueData( p.data, p.len );
						}
						a.ExMutuel.ReleaseMutex();
					}*/
				
					int t = 0;
				//			Console.WriteLine( "Ended cast at {0}", DateTime.Now.Ticks );
					DateTime now = DateTime.Now;
					TimeSpan el = now.Subtract( startingTime );
					if( el.TotalSeconds > 5 )
					{
						startingTime = now;
						foreach( Queue timer in World.timers )
						{
						/*	foreach( WowTimer wt in timer )
							{
								Console.WriteLine("Timer {0}", wt.name );
							}*/
							Console.WriteLine("queue{0} = {1}", t++, timer.Count );
						}
							
						int n = 0;
						foreach( BaseSpawner bs in World.allSpawners )
						{
							if ( bs is MobileSpawner )
							{
								if ( ( bs as MobileSpawner ).Objects.Count > 0 )
								{
									n+=( bs as MobileSpawner ).Objects.Count;
								}
							}
						}
						Console.WriteLine("Total mobs : {0}", n );
					}
					
					//bool debug = false;
					//if ( File.Exists( "debug2.txt" ) )
					//	debug = true;
					/*	DateTime now = DateTime.Now;
						TimeSpan el = now.Subtract( startingTime );
						long ulNow = (long)el.TotalMilliseconds;
						TimeSpan ts = now.Subtract( lastCall[ t ] );
						int total = (int)ts.TotalMilliseconds;*/

					//	bool debug = true;
					datetime = DateTime.Now;
					t = 0;
					foreach( Queue timer in timers )
					{	
						if ( t == 0 )
						{
							t++;
							continue;
						}
						
						long ulNow = (long)DateTime.Now.Ticks;
						int total = (int)( ( ulNow - lastCall[ t ] ) / 10000 );			
					//	total /= 10000;
						/*			if ( debug )
										Console.WriteLine("queue timer {0}/{1}", total, elapse[ t ] );
									debug = false;*/
					
						if ( total >= elapse[ t ] )
						{
							int ntimer = timer.Count;
							for(int nt = 0;nt < ntimer;nt++ )
							{
								currentTimer = (WowTimer)timer.Dequeue();								
								if ( currentTimer.Slice( ulNow ) )
									timer.Enqueue( currentTimer );
							}
							lastCall[ t ] = DateTime.Now.Ticks;
						}
						t++;
					}
					TimeSpan all = DateTime.Now.Subtract( datetime );
					World.total += all.Ticks;
					/*
					ts = now.Subtract( lastCall[ 1 ] );
					total = ts.TotalMilliseconds;
					if ( total >= 10 )
					{
						if ( timers[ 1 ].Count > 0 )
						{
							WowTimer timer = (WowTimer)timers[ 1 ].Dequeue();
							if ( timer.Slice() )
								timers[ 1 ].Enqueue( timer );
						}
						lastCall[ 1 ] = DateTime.Now;
					}
					ts = now.Subtract( lastCall[ 0 ] );
					total = ts.TotalMilliseconds;
					if ( timers[ 0 ].Count > 0 )
					{
						WowTimer timer = (WowTimer)timers[ 0 ].Dequeue();
						if ( timer.Slice() )
							timers[ 0 ].Enqueue( timer );
						lastCall[ 0 ] = DateTime.Now;
					}
					Slice500ms();*/
					Thread.Sleep( 2 );
				}
/*#if !DEBUG
			}
			catch( Exception e )
			{
				
				Console.WriteLine("Timer exception !" );
				Console.WriteLine( e.Message );
				Console.WriteLine( e.Source );
				Console.WriteLine( e.StackTrace );
				Slice1ms();
			}
#endif*/
		}
		
		#endregion

		#region HANDLERS
		/*
		public static void ToNearestPlayer( Mobile m, int opCode, byte []movePacket, int len )
		{
			foreach( Character c in allConnectedChars )
			{
				if ( c.logged && m.SeenBy( c ) )
				{
					c.Player.Handler.Send( opCode, movePacket, len );
				}
			}
		}
		public static void ToNearestPlayer( float x, float y, float z, int opCode, byte []movePacket, int len )
		{
			foreach( Character c in allConnectedChars )
			{
				if ( c.logged && c.Distance( x, y, z ) < 150 * 150 )
				{
					c.Player.Handler.Send( opCode, movePacket, len );
				}
			}
		}
		public static void ToNearestPlayer( Mobile m, OpCodes opCode, byte []movePacket, int len )
		{
			foreach( Character c in allConnectedChars )
			{
				if ( c.logged && m.SeenBy( c ) )
				{
					c.Player.Handler.Send( (int)opCode, movePacket, len );
				}
			}
		}
		public static void ToNearestPlayer( Object m, int opCode, byte []movePacket, int len )
		{
			foreach( Character c in allConnectedChars )
			{
				if ( c.logged && m.SeenBy( c ) )
				{
					c.Player.Handler.Send( opCode, movePacket, len );
				}
			}
		}*/

#if DEBUG
		public static uint GetActualTime()
		{
			DateTime n=DateTime.Now;
			int year = n.Year - 2000; 
			int month = n.Month - 1;
			int day = n.Day - 1;
			int dayOfTheWeek = (int)n.DayOfWeek;
			int hour = n.Hour;
			int minute = n.Minute;
			if ( onGetActualTime != null )
			{
				onGetActualTime( ref year, ref month, ref day, ref dayOfTheWeek, ref hour, ref minute );
			}
			return (uint)( minute | (hour<<6) | ((int)dayOfTheWeek << 11) | ((day)<<14) | ((year)<<18) | ((month)<<20) );
		}
#else
		public static uint GetActualTime()
		{
			DateTime n=DateTime.Now;
			int year = n.Year - 2000; 
			int month = n.Month - 1;
			int day = n.Day - 1;
			int dayOfTheWeek = (int)n.DayOfWeek;
			int hour = n.Hour;
			int minute = n.Minute;
			if ( onGetActualTime != null )
			{
				onGetActualTime( ref year, ref month, ref day, ref dayOfTheWeek, ref hour, ref minute );
			}
			
			//DateTime n=new DateTime( 2005,6,1,12,00,00 );
			//n.Subtract( TimeSpan.FromHours( 12 ) );
			return (uint)( minute | (hour<<6) | ((int)dayOfTheWeek << 11) | ((day)<<14) | ((year)<<18) | ((month)<<20) );
		}
#endif
		public static Account FindPlayerAccountByCharacterGUID( UInt64 guid )
		{
			foreach( Account acc in World.allAccounts )
				foreach( Character ch in acc.characteres )
					if ( ch.Guid == guid )
						return acc;
			return null;
		}
		public static Character FindCharacterGUID( UInt64 guid )
		{
			foreach( Account acc in World.allAccounts )
				foreach( Character ch in acc.characteres )
					if ( ch.Guid == guid )
						return ch;
			return null;
		}
		public static Mobile FindMobileByGUID( UInt64 guid )
		{
			if ( allMobiles == null )
				return null;
			foreach( Mobile m in allMobiles.onEasternKindoms )
				if ( m.Guid == guid )
					return m;
			foreach( Mobile m in allMobiles.onKalimdor )
				if ( m.Guid == guid )
					return m;
			return null;
		}
/*
		public static Object FindObjectByGUID( UInt64 guid )
		{
			foreach( Mobile m in allMobiles )
				if ( m.Guid == guid )
					return m;
			foreach( Object o in allGameObjects )
				if ( o.Guid == guid )
					return o;
			return null;
		}*/
		#endregion

	}











}

