using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
namespace WoWDaemon.Database.DataTables
{
	/// <summary>
	/// Summary description for DBVendor.
	/// </summary>
	[DataTable(TableName="Vendor")]
	public class DBVendor : DBObject
	{
		[DataElement(Name="SpawnID")]
		private uint m_spawnid;
		[DataElement(Name="Name")]
		private string m_name;
		[DataElement(Name="GUID")]
		private ulong m_sGUID;
		[DataElement(Name="Class")]
		private int m_class;
		[DataElement(Name="Level")]
		private uint m_level;
		[DataElement(Name="TaxiNodeID")]
		private uint m_taxinode;
		[DataElement(Name="TaxiFlags")]
		private ulong m_taxiflags;


		
		
		public DBVendor()
		{
		}

		public ulong GUID
		{
			get { return m_sGUID; }
			set { m_sGUID = value; Dirty = true;}
		}

		public uint SpawnID
		{
			get { return m_spawnid; }
			set { m_spawnid = value; Dirty = true;}
		}

		public string Name
		{
			get { return m_name; }
			set { m_name = value; Dirty = true;}
		}

		public int Class
		{
			get {return m_class;}
			set {Dirty = true; m_class = value;}
		}

		public uint Level
		{
			get {return m_level;}
			set {Dirty = true; m_level = value;}
		}

		public uint TaxiNodeID
		{
			get {return m_taxinode;}
			set {Dirty = true; m_taxinode = value;}
		}

		public ulong TaxiFlags
		{
			get {return m_taxiflags;}
			set {Dirty = true; m_taxiflags = value;}
		}
			

		public override bool AutoSave
		{
			get { return true;}
			set {}
		}

		[Relation(LocalField="ObjectId", RemoteField="VendorID", AutoLoad=true, AutoDelete=false)]
		public DBVendorItem[] VendorItems=null;

		[Relation(LocalField="Class", RemoteField="Class", AutoLoad=true, AutoDelete=false)]
		public DBTraining[] Trainings=null;

	}
}
