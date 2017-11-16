using System;
using System.IO;
using System.Collections;


namespace Server
{
	/// <summary>
	/// Summary description for MapZones.
	/// </summary>
	public class MapZones
	{
		public Hashtable Azeroth = new Hashtable();
		public ArrayList AzerothZones = new ArrayList();
		public Hashtable WorldDelimiters = new Hashtable();
		public Hashtable Continent( int mapId )
		{
			return (Hashtable)WorldDelimiters[ mapId ];
		}
		public MapZones( bool noload )
		{
		}
		public MapZones()
		{
//			Save();
			Init();
		}
		public IDictionaryEnumerator GetEnumerator( int mapId )
		{
			return Continent( mapId ).GetEnumerator();
		}
		public ArrayList Zone( int mapId, int zoneId )
		{
			return Continent( mapId )[ zoneId ] as ArrayList;
		}
		public static float UNITSIZE = ( 533.33333f / 128.0f );
		#region Prepare
#if DEBUG
		public void Save()
		{
			float TILESIZE =(533.33333f);
			float CHUNKSIZE =((TILESIZE) / 16.0f);
			UNITSIZE =(CHUNKSIZE / 8.0f);
			//	Map Y
			
				FileStream fs = new FileStream( "coordk.bin", FileMode.Open, FileAccess.Read);
				BinaryReader r = new BinaryReader(fs);

				Hashtable allMapid = new Hashtable();
				ArrayList allZone = new ArrayList();
				while( true )
				{
					if ( r.BaseStream.Position == r.BaseStream.Length )
						break;
					int areaid = r.ReadInt32();
					if ( World.map[ areaid ] != null )
					{
						if ( allMapid[ (int)World.map[ areaid ] ] == null )
						{
							FileStream wfsd = new FileStream( World.Path + "mapd" + ((int)World.map[ areaid ]).ToString() + ".bin", FileMode.Create );//.CreateNew);
							BinaryWriter wd = new BinaryWriter( wfsd );
							allMapid[ (int)World.map[ areaid ] ] = wd;
						}
					}
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
							//if ( pass % 4 != 0 )
							//	continue;
							float v = r.ReadSingle();
							if ( v <= -10000 )
								h[ o++ ] = -10000;
							else
								h[ o++ ] = v + ypos;
						}
					}
					allZone.Add( new Zone( xpos, zpos, ypos, areaid, h ) );
				//	AzerothZones.Add( new Zone( xpos, zpos, ypos, areaid, null ) );
				}
				fs.Close();

				Hashtable allrzone = new Hashtable();
				foreach( Zone z in allZone )
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
				}
		
				int size = 0;
			
				IDictionaryEnumerator zoneEnumerator = allrzone.GetEnumerator();
				while ( zoneEnumerator.MoveNext() )
				{
					int areaid = (int)zoneEnumerator.Key;
					if ( World.map[ areaid ] == null )
						continue;
					int mapId = (int)World.map[ areaid ];
					FileStream wfs = new FileStream( "./maps/map" + mapId.ToString("X4") + areaid.ToString("X4") + ".bin", FileMode.Create );//.CreateNew);
					BinaryWriter w = new BinaryWriter(wfs);
				
					ArrayList zones = (ArrayList)zoneEnumerator.Value;			
					float xmin = float.MaxValue;
					float xmax = float.MinValue;
					float ymin = float.MaxValue;
					float ymax = float.MinValue;

					for(int a = 0;a < zones.Count;a++ )
					{
						Zone z = (Zone)zones[ a ];
						for(int t = 0;t < 145;t++ )
						{
							float yy = z.X( t );
							float xx = z.Y( t );
							//	float zz = z.Z( t );
							if ( xx < xmin )
								xmin = xx;
							if ( xx > xmax )
								xmax = xx;
							if ( yy < ymin )
								ymin = yy;
							if ( yy > ymax )
								ymax = yy;
						}
					}
					//Console.WriteLine("{0} {1} {2} {3}", xmin, xmax, ymin, ymax );
					float xlen = ( xmax - xmin );
					float ylen = ( ymax - ymin );
					//	AzerothDelimiters[ areaid ] = new ZoneDelimiters( xmin, ymin, xmax, ymax );
					w.Write( (int)mapId );// MapId
					w.Write( (int)areaid );
					BinaryWriter wd = (BinaryWriter)allMapid[ mapId ];
					wd.Write( (int)mapId );// MapId
					wd.Write( (int)areaid );
					wd.Write( xmin );
					wd.Write( xmax );
					wd.Write( ymin );
					wd.Write( ymax );
					long offset = w.BaseStream.Position;
					w.Write( 0 );
					size = 0;
					for(int a = 0;a < zones.Count;a++ )
					{
						Zone z = (Zone)zones[ a ];
						for(int t = 0;t < 145;t++ )
						{
							float yy = z.X( t );
							float xx = z.Y( t );
							float zz = z.Z( t );
							if ( zz <= -100 )
								continue;
							size++;
							//yy = ( yy - ymin );
							//xx = ( xx - xmin );
													
							//	coordx = coordx >> 2;
							int coordy = (int)( yy / ( UNITSIZE * 0.5f ) );
							if ( (int)( coordy & 2 ) == 1 )
								xx -= ( UNITSIZE * 0.5f );
							int coordx = (int)( xx / ( UNITSIZE ) );
/*if ( mapId == 0 && Math.Abs( xx + 8943 ) < 50 && Math.Abs( yy + 137 ) < 50 )
	Console.WriteLine("");*/
							w.Write( coordx );
							w.Write( coordy );
							w.Write( zz );
						}
					}
					w.Seek( (int)offset, SeekOrigin.Begin );
					w.Write( size );
					w.Close();
				}
			
				allZone.Clear();
				allrzone.Clear();
				allrzone = null;

				GC.Collect();

			zoneEnumerator = allMapid.GetEnumerator();
			while ( zoneEnumerator.MoveNext() )
			{
				BinaryWriter wd = (BinaryWriter)zoneEnumerator.Value;
				wd.Write( (int)-1 );
				wd.Close();
			}
			
		}
#endif
		#endregion
		ArrayList Files( string path )
		{
			DirectoryInfo   dir = new DirectoryInfo( path );
			FileInfo[]      files;
			DirectoryInfo[] dirs;
			ArrayList fileNames = new ArrayList();
        
			dirs = dir.GetDirectories( "*" );
			foreach( DirectoryInfo di in dirs )
			{
				ArrayList ret = Files( path + "/" + di.Name );
				foreach( object o in ret )
				{		
					fileNames.Add( o );
				}
			}

			files = dir.GetFiles();
			foreach(FileInfo file in files)
			{
				if ( file.Extension.EndsWith( ".bin" ) )
				{
					fileNames.Add( file.FullName );
				}
			}
			return fileNames;
		}


		public void Init()
		{
			int []list = new int[] { 0, 1, 33, 30, 36, 37, 47, 169, 209, 269, 289, 309, 329, 451, 469, 489, 529 };
			foreach( int i in list )
			{
				FileStream fsa = new FileStream( World.Path + "mapd" + i.ToString() + ".bin", FileMode.Open, FileAccess.Read);
				BinaryReader ra = new BinaryReader( fsa );
				while( true )
				{
					int mapid = ra.ReadInt32();
					if ( mapid == -1 )
						break;
					int areaid = ra.ReadInt32();
					float xmin = ra.ReadSingle();
					float xmax = ra.ReadSingle();
					float ymin = ra.ReadSingle();
					float ymax = ra.ReadSingle();	
					if ( WorldDelimiters[ mapid ] == null )
						WorldDelimiters[ mapid ] = new Hashtable();
					Continent( mapid )[ areaid ] = new ZoneDelimiters( areaid, xmin, ymin, xmax, ymax );
				}
				ra.Close();
			}
		}
		class Pos3D
		{
			public float x;
			public float y;
			public ushort mapId;
			public ushort zoneId;
			public Pos3D( float X, float Y, ushort m, ushort z )
			{
				x = X;
				y = Y;
				mapId = m;
				zoneId = z;
			}
		}
#if DEBUG
		public ArrayList RawLoadAll()
		{
			ArrayList res = new ArrayList();
			ArrayList all = Files( World.Path + "maps/" );
			foreach( string filename in all )
			{
				FileStream fs = new FileStream( filename, FileMode.Open, FileAccess.Read);
				BinaryReader r = new BinaryReader(fs);
				ArrayList allZone = new ArrayList();
				int _mapId = r.ReadInt32();
				int areaId = r.ReadInt32();
				int n = r.ReadInt32();
				//Hashtable h = new Hashtable();
				//Azeroth[ areaId ] = h;
				if ( areaId == 2365 )
					Console.WriteLine("");
				for(int t = 0;t < n;t++ )
				{
					int ax = r.ReadInt32();
					int ay = r.ReadInt32();
					float z = r.ReadSingle();
					if ( t % 4 == 0 )
					{
						int mapId = (int)World.map[ areaId ];
						int zoneId = (int)World.zoneIds[ areaId ];
						float y = ay * UNITSIZE * 0.5f;
						float x = ax * UNITSIZE;
						if ( (int)( (int)ay & 2 ) == 1 )
							x += UNITSIZE * 0.5f;
					//	res.Add( new Pos3D( ax, ay, (ushort)mapId, (ushort)areaId ) );
						if ( Math.Abs( x + 2206 ) < 50 && Math.Abs( y + 391 ) < 50 )
							Console.WriteLine("");
					}
				}
				r.Close();
			}
			return res;
		}

		public void LoadAll()
		{
			ArrayList all = Files( World.Path + "maps/" );
			foreach( string filename in all )
			{
				FileStream fs = new FileStream( filename, FileMode.Open, FileAccess.Read);
				BinaryReader r = new BinaryReader(fs);
				ArrayList allZone = new ArrayList();
				long empty = r.ReadInt64();
				int n = r.ReadInt32();
				//if ( mapId == 1 )
				{
					
					Hashtable h = new Hashtable();
					//Azeroth[ areaId ] = h;
					for(int t = 0;t < n;t++ )
					{
						int ax = r.ReadInt32();
						int ay = r.ReadInt32();
					//	if ( mapId == 1 && Math.Abs( ax + 2206 ) < 10 && Math.Abs( ay + 391 ) < 10 )
							//Console.WriteLine("");
						uint x = (uint)( 0x8000 + ax );
						uint y = (uint)( 0x8000 + ay );
						float z = r.ReadSingle();
						uint res = ( (uint)x << 16 ) + (uint)y;
						h[ res ] = z;
						//	short xx = (short)( res >> 16 );
						//	short yy = (short)( res & 0xffff );
					}
				}
				r.Close();
			}
		}
#endif
		void Load( int mapId, int areaId )
		{
			FileStream fs = new FileStream( World.Path + "maps/map" + mapId.ToString( "X4" ) + areaId.ToString( "X4" ) + ".bin", FileMode.Open, FileAccess.Read);
			BinaryReader r = new BinaryReader(fs);
			ArrayList allZone = new ArrayList();
			long empty = r.ReadInt64();
			int n = r.ReadInt32();
			Hashtable h = new Hashtable();

			Azeroth[ mapId * 1024 + areaId ] = h;
			( Continent( mapId )[ areaId ] as ZoneDelimiters ).Loaded = true;

			for(int t = 0;t < n;t++ )
			{
				int ax = r.ReadInt32();
				int ay = r.ReadInt32();
				uint x = (uint)( 0x8000 + ax );
				uint y = (uint)( 0x8000 + ay );
				float z = r.ReadSingle();
				uint res = ( (uint)x << 16 ) + (uint)y;
				h[ res ] = z;
			//	if ( mapId == 1 && Math.Abs( ax + 2206 ) < 10 && Math.Abs( ay + 391 ) < 10 )
					//Console.WriteLine("");
			}
			r.Close();			
		}
#if DEBUG
		void InitBrut()
		{
			float TILESIZE =(533.33333f);
			float CHUNKSIZE =((TILESIZE) / 16.0f);
			UNITSIZE =(CHUNKSIZE / 8.0f);
			//	Map Y
			FileStream fs = new FileStream( World.Path + "coordz.bin", FileMode.Open, FileAccess.Read);
			BinaryReader r = new BinaryReader(fs);
			ArrayList allZone = new ArrayList();
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
						//if ( pass % 4 != 0 )
						//	continue;
						float v = r.ReadSingle();
						if ( v <= -10000 )
							h[ o++ ] = -10000;
						else
							h[ o++ ] = v + ypos;
					}
				}
				allZone.Add( new Zone( xpos, zpos, ypos, areaid, h ) );
				AzerothZones.Add( new Zone( xpos, zpos, ypos, areaid, null ) );
			}
			fs.Close();
			
			Hashtable allrzone = new Hashtable();
			foreach( Zone z in allZone )
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
			}
		
			int size = 0;
			
			IDictionaryEnumerator zoneEnumerator = allrzone.GetEnumerator();
			while ( zoneEnumerator.MoveNext() )
			{
				int areaid = (int)zoneEnumerator.Key;
				if ( World.map[ areaid ] == null )
					continue;
				int mapId = (int)World.map[ areaid ];
				Azeroth[  mapId * 1024 + areaid ] = new Hashtable();
				
				ArrayList zones = (ArrayList)zoneEnumerator.Value;			
				float xmin = float.MaxValue;
				float xmax = float.MinValue;
				float ymin = float.MaxValue;
				float ymax = float.MinValue;
				for(int a = 0;a < zones.Count;a++ )
				{
					Zone z = (Zone)zones[ a ];
					for(int t = 0;t < 145;t++ )
					{
						float yy = z.X( t );
						float xx = z.Y( t );
						//	float zz = z.Z( t );
						if ( xx < xmin )
							xmin = xx;
						if ( xx > xmax )
							xmax = xx;
						if ( yy < ymin )
							ymin = yy;
						if ( yy > ymax )
							ymax = yy;
					}
				}

				for(int a = 0;a < zones.Count;a++ )
				{
					Zone z = (Zone)zones[ a ];
					for(int t = 0;t < 145;t++ )
					{
						float yy = z.X( t );
						float xx = z.Y( t );
						float zz = z.Z( t );
						if ( zz <= -100 )
							continue;
						size++;
						//yy = ( yy - ymin );
						//xx = ( xx - xmin );
						int coordx = (int)( xx / ( UNITSIZE ) );						
						//	coordx = coordx >> 2;
						int coordy = (int)( yy / ( UNITSIZE * 0.5 ) );

						Hashtable cont = (Hashtable)Azeroth[  mapId * 1024 + areaid ];
						Hashtable hy = cont[ coordy ] as Hashtable;
						if ( hy == null )
						{
							hy = new Hashtable();
							cont[ coordy ] = hy;
						}
						/*Hashtable hx = (Hashtable)( hy[ coordx ] as Hashtable );
						if ( hx == null )
						{
							hx = new Hashtable();
							hy[ coordx ] = hx;
						}*/
						//		hx[ coordx ] = zz;
						//					if ( hy[ coordx ] != null )
						//						Console.WriteLine("");
						hy[ coordx ] = zz;
					}
				}
			}
			allZone.Clear();
			allrzone.Clear();
			allrzone = null;
			GC.Collect();
		}
		#endif
		public int NearestZoneId( Character ch )
		{
			double angle = ch.Orientation;			
			int x = (int)( ch.X + Math.Cos( angle ) * 50f );
			int y = (int)( ch.Y + Math.Sin( angle ) * 50f );
			int nearestDist = int.MaxValue;
			int nearest = 0;
			for(int t = 0;t < World.allSpawners.Count;t++ )
			{
				BaseSpawner bs = World.allSpawners[ t ];
				if ( bs.MapId != ch.MapId )
					continue;
				int a = x - (int)bs.X;
				int b = y - (int)bs.Y;
				a = a * a + b * b;
				if ( a < nearestDist )
				{
					nearestDist = a;
					nearest = bs.ZoneId;
				}
			}
			return nearest;
		}
		public int NearestZoneId( int mapId, float x, float y )
		{
			IDictionaryEnumerator zoneEnumerator = null;
			zoneEnumerator = Continent( mapId ).GetEnumerator();
			
			
			while ( zoneEnumerator.MoveNext() )
			{	
				ZoneDelimiters zd = zoneEnumerator.Value as ZoneDelimiters;
				if ( zd.Xmax + UNITSIZE >= x && zd.Xmin - UNITSIZE <= x && zd.Ymax + UNITSIZE / 2 >= y && zd.Ymin - UNITSIZE / 2 <= y )
				{
					return (int)zoneEnumerator.Key;
				}				
			}
			return -1;
		}

		public void FillZValues( Hashtable hy, float [,]zoneZ, MobileSpawner mob )
		{
			float x = mob.X;
			float y = mob.Y;
			int coordy = (int)( y / ( UNITSIZE * 0.5f ) );
			if ( (int)( coordy & 2 ) == 1 )
				x -= ( UNITSIZE * 0.5f );
			int coordx = (int)( x / UNITSIZE );
			if ( hy == null )
			{
				Console.WriteLine("hy map == null for {0}/{1}", mob.MapId, mob.ZoneId );
				return;
			}
			int oy = 0;
			for(int t = -32;t < 32;t++, oy++ )
				for(int i = -32, ox = 0;i < 32;i++, ox++ )
				{
					uint cx = (uint)( coordx + t ) + 0x8000;
					uint cy = (uint)( coordy + i ) + 0x8000;			
					object o = hy[ ( (uint)cx << 16 ) + (uint)cy ];
					if ( o != null )
						zoneZ[ oy, ox ]= (float)o;
					else
						zoneZ[ oy, ox ] = -200000;
				}
		}

		public MapPoint Get( int pos, int zoneId, int mapId, Mobile mob, bool reenter )
		{			
			float x = mob.X;
			float y = mob.Y;
	//		Hashtable hy = mob.SpawnerLink.ZoneHash;

			ZoneDelimiters zd = null;
			Hashtable continent = Continent( mapId );
			if ( continent == null )
			{
				Console.WriteLine("Invalid mapId {0} -> DrNexus", mapId );
				return null;
			}
			zd = continent[ zoneId ] as ZoneDelimiters;

			if ( !( zd.Xmax + UNITSIZE  > x && zd.Xmin - UNITSIZE < x && zd.Ymax + UNITSIZE > y && zd.Ymin - UNITSIZE < y ) )
			{
			//	Console.WriteLine( "Mob outside his zone {0} {1} [{2},{3};{4},{5}] {6}!", x, y, zd.Xmin, zd.Ymin, zd.Xmax, zd.Ymax, zoneId );
			//	return new MapPoint( mob.SpawnerLink.X, mob.SpawnerLink.Y, mob.SpawnerLink.Z );
				return this.NearestPoint( mob.SpawnerLink.ZoneHash, mapId, zoneId, x, y );
			}
			if ( !zd.Loaded )
				Load( mapId, zoneId );
			
			//	coordx = coordx >> 2;


			Hashtable hy = null;
			hy = (Hashtable)Azeroth[  mapId * 1024 + zoneId ];
			
			int coordy = (int)( y / ( UNITSIZE * 0.5f ) );
			if ( (int)( coordy & 2 ) == 1 )
				x -= ( UNITSIZE * 0.5f );
			int coordx = (int)( x / UNITSIZE );
			if ( hy == null )
			{
				Console.WriteLine("hy map == null for {0}/{1}", mapId, zoneId );
				return null;
			}
			switch( pos )
			{
				case 0:
					coordy--;
			//		if ( ( coordy & 1 ) == 0 )
						coordx--;
					break;
				case 1:
					coordy--;
		//			if ( ( coordy & 1 ) == 1 )
		//				coordx++;
					break;
				case 2:
					coordx++;
					break;
				case 5:
					coordx--;
					break;
				case 4:
					coordy++;
		//			if ( ( coordy & 1 ) == 0 )
		//				coordx--;
					break;
				case 3:
					coordy++;
			//		if ( ( coordy & 1 ) == 1 )
						coordx++;
					break;
			}
			uint cx = (uint)coordx + 0x8000;
			uint cy = (uint)coordy + 0x8000;
			
			object o = hy[ ( (uint)cx << 16 ) + (uint)cy ];
			if ( o == null )
			{
				o = hy[ cx + (uint) cy + 1 ];
				if ( o == null )
				{
					o = hy[ cx + (uint) cy - 1 ];
					if ( o == null )
					{
						o = hy[ (uint)(( cx + 1 ) << 16) + (uint)cy ];
						if ( o == null )
						{
							o = hy[ (uint)(( cx - 1 ) << 16 )+ (uint)cy ];
							if ( o != null )
								return new MapPoint( (float)--coordx * ( UNITSIZE ), (float)coordy * UNITSIZE * 0.5f, (float)o );		
						}
						else
							return new MapPoint( (float)++coordx * ( UNITSIZE ), (float)coordy * UNITSIZE * 0.5f, (float)o );		
					}
					else 
						return new MapPoint( (float)coordx * ( UNITSIZE ), (float)--coordy * UNITSIZE * 0.5f, (float)o );		
				}
				else
					return new MapPoint( (float)coordx * ( UNITSIZE ), (float)++coordy * UNITSIZE * 0.5f, (float)o );		
				if ( reenter )
					return null;
				MapPoint mp = NearestPoint( mob.SpawnerLink.ZoneHash, mapId, zoneId, x, y );
				return Get( pos, zoneId, mapId, mob, true );			
			}
			return new MapPoint( (float)coordx * ( UNITSIZE ), (float)coordy * UNITSIZE * 0.5f, (float)o );		
		}

		public Hashtable GetZoneHash( int mapId, int zoneId, float x, float y )
		{
			ZoneDelimiters zd = null;
			Hashtable continent = null;
			zd = Continent( mapId )[ zoneId ] as ZoneDelimiters;
			if ( zd == null )
			{
				Console.WriteLine("Unknown zone id {0}", zoneId );
				return null;
			}
			if ( !zd.Loaded )
				Load( mapId, zoneId );
			continent = (Hashtable)this.Azeroth[  mapId * 1024 + zoneId ];
			return continent;
		}

		public MapPoint NearestPoint( Hashtable continent, int mapId, int zoneId, float x, float y )
		{
			float dist = float.MaxValue;
			ZoneDelimiters zd = null;
			if ( continent == null )
			{
				zd = Continent( mapId )[ zoneId ] as ZoneDelimiters;
			
				if ( zd == null )
					Console.WriteLine("Unknown zone id {0}", zoneId );
				if ( !zd.Loaded )
					Load( mapId, zoneId );
				continent = (Hashtable)this.Azeroth[  mapId * 1024 + zoneId ];
			}
			if ( continent == null )
				Console.WriteLine("zone");
			IDictionaryEnumerator zoneEnumerator = continent.GetEnumerator();
			int ax = 0;
			int ay = 0;
			float az = 0;
			//x -= zd.Xmin;
			//y -= zd.Ymin;
			y /= UNITSIZE * 0.5f;
			int aey = (int)y;
			if ( (int)( (int)y & 2 ) == 1 )
				x -= UNITSIZE * 0.5f;
			x /= UNITSIZE;


			while ( zoneEnumerator.MoveNext() )
			{
				uint a = (uint)zoneEnumerator.Key;
				short xx = (short)( ( a >> 16 ) - 0x8000 );
				short yy = (short)( ( a & 0xffff ) - 0x8000 );
				float px = Math.Abs( (float)xx - x );
				float py = Math.Abs( (float)yy - y );
				px *= px;
				py *= py;
				px += py;
				if ( px < dist )
				{
					dist = px;
					ax = (int)xx;
					ay = (int)yy;
					az = (float)zoneEnumerator.Value;
				}
			}

			if ( (int)( ay & 2 ) == 1 )
				return new MapPoint( ( UNITSIZE / 2 ) + ( (float)ax * UNITSIZE ), (float)ay * UNITSIZE * 0.5f, az );
			return new MapPoint( (float)ax * UNITSIZE, (float)ay * UNITSIZE * 0.5f, az );
		}
	}
}
