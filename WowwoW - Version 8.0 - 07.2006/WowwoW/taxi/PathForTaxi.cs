using System;
using HelperTools;
using System.Collections;
using Server.Items;
using System.Reflection;
using System.Diagnostics;
using System.IO;

namespace Server
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class PathForTaxi
	{
		Trajet t;
		public int mapChange;
		public MapIds[] mapIds = new MapIds[3];
		public struct MapIds
		{
			public int mapId;
			public int index;
		}
		public Trajet T
		{
			get {return t;}
		}
		public PathForTaxi(int taxiPathId,Character ch)
		{
			int map = ch.MapId;
			mapChange = 0;
			ArrayList list = new ArrayList();
			foreach(TaxiPathNode tpn in Server.Taxi.TaxiPathNodesList)
			{
				if(tpn.TaxiPath == taxiPathId)
				{
					if (map != tpn.MapId)
					{
						mapIds[mapChange].index = tpn.Index;
						mapIds[mapChange].mapId = tpn.MapId;
						mapChange++;
						map = tpn.MapId;
					}
					list.Add(tpn);
				}
			}
		
		
			int num = list.Count;
			Coord []coordinates = new Coord[num];
			TaxiPathNode []tpnArray = new TaxiPathNode[num];

			
			foreach(TaxiPathNode tpn in list)
			{
				tpnArray[tpn.Index] = tpn;
			}

			for(int i = 0; i < num; i++)
			{
				
				if (i == 0)	coordinates[i] = new Coord( tpnArray[i].X,tpnArray[i].Y,tpnArray[i].Z,null,null);
				else coordinates[i] = new Coord( tpnArray[i].X,tpnArray[i].Y,tpnArray[i].Z,coordinates[i-1],null);
			}
			
			t = new Trajet(coordinates);

		}
	}
}
