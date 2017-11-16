using System;

namespace Server
{
	/// <summary>
	/// Summary description for Position.
	/// </summary>
	public class Position
	{
		float x;
		float y;
		float z;
		int mapId;
		public Position( float xx, float yy, float zz, int map )
		{
			x = xx;
			y = yy;
			z = zz;
			mapId = map;
		}
		public int MapId
		{
			get { return mapId; }
		}
		public float X
		{
			get { return x; }
		}
		public float Y
		{
			get { return y; }
		}
		public float Z
		{
			get { return z; }
		}
		public int QuickDistance( Mobile with )
		{
			int xx = (int)x;
			int yy = (int)y;
			int x1 = (int)with.X;
			int y1 = (int)with.Y;
			xx = ( xx - x1 );
			yy = ( yy - y1 );
			xx *= xx;
			yy *= yy;
			xx += yy;
			return xx;

		}
	}
}
