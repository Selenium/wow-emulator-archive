using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
namespace WoWDaemon.Database.DataTables
{
	/// <summary>
	/// Summary description for DBSpawn.
	/// </summary>
	[DataTable(TableName="VendorItem")]
	public class DBVendorItem : DBObject
	{
		[DataElement(Name="VendorID")]
		private uint m_vendorid;
		[DataElement(Name="Name")]
		private String m_name;
		[DataElement(Name="templateID")]
		private uint m_templateid;
		[DataElement(Name="CurrentQty")]
		private int m_currentqty;
		[DataElement(Name="Price")]
		private int m_price;
		
		public DBVendorItem()
		{
		}

		public uint VendorID
		{
			get { return m_vendorid; }
			set { m_vendorid = value; Dirty = true;}
		}

		public uint TemplateID
		{
			get { return m_templateid; }
			set { m_templateid = value; Dirty = true;}
		}

		public string Name
		{
			get { return m_name; }
			set { m_name = value; Dirty = true;}
		}

		public int CurrentQty
		{
			get { return m_currentqty; }
			set { m_currentqty = value; Dirty = true;}
		}

		public int Price
		{
			get { return m_price; }
			set { m_price = value; Dirty = true;}
		}

		public override bool AutoSave
		{
			get { return true;}
			set {}
		}

		[Relation(LocalField="TemplateID", RemoteField="ItemTemplate_ID", AutoLoad=true, AutoDelete=false)]
		public DBItemTemplate Template = null;
	}
}
