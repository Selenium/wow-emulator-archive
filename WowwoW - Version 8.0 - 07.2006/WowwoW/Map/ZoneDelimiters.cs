using System;

namespace Server
{
	/// <summary>
	/// Summary description for ZoneDelimiters.
	/// </summary>
	public class ZoneDelimiters
	{
		float xmin;
		float ymin;
		float xmax;
		float ymax;
		int areaId;
		bool cached;

		public ZoneDelimiters( int area, float xmn, float ymn, float xmx, float ymx )
		{
			xmin = xmn;
			ymin = ymn;
			xmax = xmx;
			ymax = ymx;
			areaId = area;
			cached = false;
		}
		public bool Loaded
		{
			get { return cached; }
			set { cached = value; }
		}
		public float Xlen
		{
			get { return (float)( xmax - xmin ) / (533.33333f / 128.0f); }
		}
		public float Ylen
		{
			get { return (float)( ( ymax - ymin ) / ( (533.33333f / 128.0f) * 0.5 ) ); }
		}
		public float Xmin
		{
			get { return xmin; }
		}
		public float Ymin
		{
			get { return ymin; }
		}
		public float Xmax
		{
			get { return xmax; }
		}
		public float Ymax
		{
			get { return ymax; }
		}
	}
}
