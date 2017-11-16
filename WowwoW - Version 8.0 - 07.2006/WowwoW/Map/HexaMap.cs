using System;
using System.Collections;
using System.Reflection;

namespace Server
{

	public class HexaPoint
	{
		public int x;
		public int y;
		public HexaPoint()
		{
		}
		public HexaPoint( HexaPoint v )
		{
			x = v.x;
			y = v.y;
		}
		public HexaPoint( int xx, int yy )
		{
			x = xx;
			y = yy;
		}
		public HexaPoint Clone()
		{
			return new HexaPoint( x, y );
		}


		public double Distance( HexaPoint with )
		{
			float xx = (float)x;
			float yy = (float)y;
			float zx = (float)with.x;
			float zy = (float)with.y;
			if ( ( with.y & 1 ) == 0 )
				zx+=0.5F;
			if ( ( y & 1 ) == 0 )
				xx+=0.5F;
			float dx = xx - zx;
			dx *= dx;
			float dy = yy - zy;
			dy *= dy;
			dx += dy;
			return (double)dx;
		}
	}


	public class HexaMap
	{
		public float []cluster;
		public int maxX;
		public int maxY;

		public static int []oppose = { 5, 4, 3, 2, 1, 0 };

		public HexaMap()
		{
		}

		public HexaPoint HexaCoordNoBorder( HexaPoint v, int t )
		{
			HexaPoint res = new HexaPoint( v );
			switch( t )
			{
				case 0:
					res.y--;
					if ( res.y < 0 )
						res.y += maxY;
					if ( ( res.y & 1 ) == 0 )
					{
						res.x--;
						if ( res.x < 0 )
							res.x += maxX;
					}
					return res;
				case 1:
					res.y--;
					if ( res.y < 0 )
						res.y += maxY;
					if ( ( res.y & 1 ) == 1 )
						res.x++;
					if ( res.x >= maxX )
						res.x = res.x - maxX;
					return res;
				case 2:
					res.x--;
					if ( res.x < 0 )
						res.x = res.x + maxX;
					return res;
				case 3:
					res.x++;
					if ( res.x >= maxX )
						res.x -= maxX;
					return res;
				case 4:
					res.y++;
					if ( res.y >= maxY )
						res.y -= maxY;
					if ( ( res.y & 1 ) == 0 )
					{
						res.x--;
						if ( res.x < 0 )
							res.x += maxX;
					}
					return res;
				case 5:
					res.y++;
					if ( res.y >= maxY )
						res.y -= maxY;
					if ( ( res.y & 1 ) == 1 )
						res.x++;
					if ( res.x >= maxX )
						res.x -= maxX;
					return res;
			}
			return null;
		}

		public HexaPoint HexaCoord( HexaPoint v, int t )
		{
			HexaPoint res = new HexaPoint( v );
			switch( t )
			{
				case 0:
					res.y--;
					if ( ( res.y & 1 ) == 0 )
						res.x--;
					return res;
				case 1:
					res.y--;
					res.x++;
					if ( ( res.y & 1 ) == 1 )
						res.x++;
					return res;
				case 2:
					res.x--;
					return res;
				case 3:
					res.x++;
					return res;
				case 4:
					res.y++;
					if ( ( res.y & 1 ) == 0 )
						res.x--;
					return res;
				case 5:
					res.y++;
					if ( ( res.y & 1 ) == 1 )
						res.x++;
					return res;
			}
			return null;
		}
		public HexaMap( int x, int y )
		{
			maxX = x;
			maxY = y;
			cluster = new float[ maxY * maxX ];
		}
		public float GetMapSafe( int x, int y )
		{
			if ( y >= maxY )
				y -= maxY;
			else
				if ( y < 0 )
				y += maxY;
			if ( x < 0 )
				x += maxX;
			else
				if ( x >= maxX )
				x -= maxX;

			return cluster[ x + y * maxX ];
		}
		public float GetMap( int x, int y )
		{
			return cluster[ x + y * maxX ];
		}
		public float GetMap( HexaPoint hp )
		{
			if ( hp == null )
				return float.MinValue;
			return cluster[ hp.x + hp.y * maxX ];
		}

		public bool IsEmpty( int x, int y )
		{
			if ( cluster[ x + y * maxX ] == float.MinValue )
				return true;
			return false;
		}
		public bool IsEmpty( HexaPoint hp )
		{
			if ( cluster[ hp.x + hp.y * maxX ] == float.MinValue )
				return true;
			return false;
		}
	}

}
