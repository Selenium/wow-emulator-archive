using System;
using WoWDaemon.Common.Attributes;
using WoWDaemon.Common;

namespace WoWDaemon.Database.DataTables
{
	/// <summary>
	/// Summary description for DBWorldMap.
	/// </summary>
	[DataTable(TableName="WorldMap")]
	public class DBWorldMap : DBObject
	{
		[DataElement(Name="Continent")]
		private int m_continent;
		[DataElement(Name="BottomX")]
		private int m_bottomX;
		[DataElement(Name="BottomY")]
		private int m_bottomY;
		[DataElement(Name="TopX")]
		private int m_topX;
		[DataElement(Name="TopY")]
		private int m_topY;
		[DataElement(Name="TileSize")]
		private int m_tileSize;

		public DBWorldMap()
		{
		}

		public DBWorldMap(BinReader data)
		{
			Deserialize(data);
		}

		public DBWorldMap(int continent, int bottomX, int bottomY, int topX, int topY, int tileSize) : base()
		{
			m_continent = continent;
			m_bottomX = bottomX;
			m_bottomY = bottomY;
			m_topX = topX;
			m_topY = topY;
			m_tileSize = tileSize;
			Dirty = true;
		}

		public override bool AutoSave
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		public int Continent
		{
			get { return m_continent;}
		}

		public int BottomX
		{
			get { return m_bottomX;}
		}
		public int BottomY
		{
			get { return m_bottomY;}
		}
		public int TopX
		{
			get { return m_topX;}
		}
		public int TopY
		{
			get { return m_topY;}
		}

		public int TileSize
		{
			get { return m_tileSize;}
		}

		[Relation(LocalField="ObjectId", RemoteField="WorldMapID", AutoLoad=true, AutoDelete=true)]
		public DBSpawn[] Spawns;
	}
}
