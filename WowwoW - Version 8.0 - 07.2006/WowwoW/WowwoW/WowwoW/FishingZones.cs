using System;
using System.Collections;


namespace Server
{
	/// <summary>
	/// Summary description for FishingZone.
	/// </summary>
	public class FishingZones
	{
		class FishZone
		{
			float x;
			float y;
			float z;
			float radius;
			public GameObjectDescription desc; 
			public FishZone( float _x, float _y, float _z, float _radius, GameObjectDescription _desc )
			{
				x = _x;
				y = _y;
				z = _z;
				radius = _radius * _radius;
				desc = _desc;
			}
			public bool Inside(  float _x, float _y, float _z )
			{
				float xx = x - _x;
				float yy = y - _y;
				xx *= xx;
				yy *= yy;
				if ( xx + yy < radius )
					return true;
				return false;
			}
		}
		ArrayList zones;

		public FishingZones()
		{			
			zones = new ArrayList();
		}
		public void Add( float x, float y, float z, float radius, GameObjectDescription d )
		{
			zones.Add( new FishZone( x, y, z, radius, d ) );
		}
		public GameObjectDescription InsideFishingZone( float x, float y, float z )
		{
			foreach( FishZone fz in zones )
			{
				if ( fz.Inside( x, y, z ) )
					return fz.desc;
			}
			return null;
		}
	}
}
