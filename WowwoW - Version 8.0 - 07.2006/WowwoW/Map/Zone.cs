using System;

namespace Server
{
	/// <summary>
	/// Summary description for Zone.
	/// </summary>
	public class Zone
	{
		public float x;
		public float y;
		public float z;
		public int zoneId;
		public float []h;
		public static float[]quickX = new float[ 145 ];
		public static float[]quickY = new float[ 145 ];
		public Zone( float _x, float _y, float _z, int zid, float []_h )
		{
			zoneId = zid;
			x = _x;
			y = _y;
			h = _h;
			z = _z;
		}
		public float X( int p )
		{
			return x - quickX[ p ];
		}
		public float Y( int p )
		{
			return y - quickY[ p ];
		}
		public float Z( int p )
		{
			return h[ p ];
		}
	}
}
