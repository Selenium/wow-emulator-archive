using System;

namespace Server
{
	public class MapPoint
	{
		public float x;
		public float y;
		public float z;
		public MapPoint( float _x, float _y, float _z )
		{
			x = _x;
			y = _y;
			z = _z;
		}
	}
	public class Coord
	{
		public float x;
		public float y;
		public float z;
		public BaseCreature occ;
		public Coord next;
		public Coord previous;

		public Coord( float a, float b, float c, Coord p, Coord n )
		{
			x = a;
			y = b;
			z = c;
			next = n;
			previous = p;
		}
		public void TrajetNum( ref int ntr, ref int nc )
		{
			ntr = 0;				
			foreach( Trajet tr in World.trajets )
			{
				nc = 0;
				foreach( Coord c in tr )
				{
					if ( c == this )
						return;
					nc++;
				}
				ntr++;
			}
		}
	}
	public class Intersection : Coord
	{
		public Coord left;
		public Coord right;
		public Intersection( Coord t, Coord o, Coord l, Coord r, float a, float b, float c ) : base( a, b, c, l, r )
		{
			left = t;
			right = o;
		}
	}
	/// <summary>
	/// Summary description for Vector.
	/// </summary>
	public class Vector
	{


		public Vector()
		{
		}
	
		public static float Angle( int d )
		{
			d = (int)( d & 0x1FF );
			float a = (float)d;
			a /= 256;
			return a * (float)Math.PI;
		}
		public static float ToAngleDistance( float a, float dist )
		{
			a = a % ( (float)Math.PI * 2f );
			a /= (float)Math.PI * 2.0f;
			a *= 256;
			int d = ( (int)a ) + 256;
			dist *= 4;
			int di = (int)dist;
			d += di << 9;
			return (ushort)d;
		}		

		public static ushort ToAngleDistance( float x1, float y1, float x2, float y2 )
		{
			float a = (float)Math.Atan2( y2 - y1, x2 - x1 );
			x1 = x2 - x1;
			y1 = y2 - y1;
			float dist = (float)Math.Sqrt( x1 * x1 + y1 * y1 );
			if ( a >= 2 * Math.PI )
				a = (float)a % ( (float)Math.PI * 2 );
			else
				if ( a < 0 )
				a = ( 2f * (float)Math.PI ) - ( (float)-a % ( (float)Math.PI * 2 ) );
			
			a /= (float)Math.PI * 2f;
			a *= 512;
			int d = ( (int)a );
			dist *= 4;
			int di = (int)dist;
			d += di << 9;
			return (ushort)d;
		}				
		public static float Distance( ushort d )
		{
			d = (ushort)( d >> 9 );
			float a = (float)d;
			a /= 4;
			return a;
		}
		/*		public static void Main(string[] args)
				{
					Coord []c = new Coord[ 200 ];
					for(int t = 0;t < 36;t++ )
					{
						c[ t ] = new Coord( 50f * (float)Math.Cos( ( (double)t ) * Math.PI / 18.0 ), 50f * (float)Math.Sin( ( (double)t ) * Math.PI / 18.0 ) );
					}		
					Transform( c );
				}*/
		
		
		public static ushort []Transform( Coord []coords )
		{			
			float xx = coords[ 0 ].x;
			float yy = coords[ 0 ].y;			
			
			ushort []trajet = new ushort[ coords.Length - 1 ];
			float ax;
			float ay;
			
			for(int j = 1;j < coords.Length;j++ )
			{
				ushort res = ToAngleDistance( xx, yy, coords[j].x, coords[j].y );
				trajet[ j - 1 ] = res;
				int angle = res & 0x1FF;
				int dist = res >> 9;

				//Console.Write("de {0}, {1} vers {2}, {3} ----- ", x[ j - 1 ], y[ j - 1 ], x[ j ], y[ j ] );
				
				float xt = xx + ( Distance( res ) * (float)Math.Cos( ( (double)Angle( res ) ) ) );
				float yt = yy + ( Distance( res ) * (float)Math.Sin( ( (double)Angle( res ) ) ) );
				
				xx = xt;				
				yy = yt;
				ax = xx - coords[ j ].x;
				ay = yy - coords[ j ].y;
				//Console.WriteLine("Decalage : {0}", Math.Sqrt( ax *ax + ay *ay ) );
			}
			ax = xx - coords[ coords.Length - 1 ].x;
			ay = yy - coords[ coords.Length - 1 ].y;	
			Console.WriteLine("Déviation final : {0}", Math.Sqrt( ax * ax + ay * ay ) );
			return trajet;
			
		}
	}
}
