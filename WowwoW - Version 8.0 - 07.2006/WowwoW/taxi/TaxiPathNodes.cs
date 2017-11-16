using System;

namespace Server
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class TaxiPathNode
	{
		int id;
		int taxiPath;
		int index;
		int mapId;
		float x;
		float y;
		float z;

		public int Id
		{
			get {return id;}
		}

		public int Index
		{
			get {return index;}
		}
		public int TaxiPath
		{
			get {return taxiPath;}
		}
		
		public int MapId
		{
			get {return mapId;}
		}
		public float X
		{
			get {return x;}
		}
		public float Y
		{
			get {return y;}
		}
		public float Z
		{
			get {return z;}
		}

		public TaxiPathNode(int _id, int _taxiPath, int _index,int _mapId, double _x, double _y, double _z)
		{
			id = _id;
			taxiPath = _taxiPath;
			index = _index;
			mapId = _mapId;
			x = (float)_x;
			z = (float)_z;
			y = (float)_y;
			
			
		}
	}
}
