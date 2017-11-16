using System;

namespace Server
{
	/// <summary>
	/// Summary description for Class2.
	/// </summary>
	public class TaxiNode
	{
		public int id;
		public short mapId;
		public float x;
		public float y;
		public float z;
		public int mountId = 0;

		public TaxiNode(int _id, short _mapId, double _x, double _y, double _z)
		{
			id = _id;
			mapId = _mapId;
			x = (float)_x;
			y = (float)_y;
			z =(float) _z;
		}

		public TaxiNode(int _id, short _mapId, double _x, double _y, double _z,int _mountId)
		{
			id = _id;
			mapId = _mapId;
			x = (float)_x;
			y = (float)_y;
			z =(float) _z;
			this.mountId = _mountId;
		}
	}
}
