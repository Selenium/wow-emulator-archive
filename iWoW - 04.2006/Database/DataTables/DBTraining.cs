using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
namespace WoWDaemon.Database.DataTables
{
	/// <summary>
	/// Summary description for DBSpawn.
	/// </summary>
	[DataTable(TableName="Training")]
	public class DBTraining : DBObject
	{
		[DataElement(Name="VendorID")]
		private uint m_vendorid;
		[DataElement(Name="Class")]
		private int m_class;
		[DataElement(Name="Level")]
		private uint m_level;
//		[DataElement(Name="Name")]
//		private String m_name;
		[DataElement(Name="TeachSpellId")]
		private uint m_teachspellid;
		[DataElement(Name="SpellId")]
		private uint m_spellid;
		[DataElement(Name="Price")]
		private int m_price;
		
		public DBTraining()
		{
		}
	
		public uint VendorID
		{
			get { return m_vendorid; }
			set { m_vendorid = value; Dirty = true;}
		}

		public uint TeachSpellID
		{
			get { return m_teachspellid; }
			set { m_teachspellid = value; Dirty = true;}
		}

		public int Class
		{
			get { return m_class; }
			set { m_class = value; Dirty = true;}
		}
/*
		public string Name
		{
			get { return m_name; }
			set { m_name = value; Dirty = true;}
		}
*/
		public uint SpellID
		{
			get { return m_spellid; }
			set { m_spellid = value; Dirty = true;}
		}

		public int Price
		{
			get { return m_price; }
			set { m_price = value; Dirty = true;}
		}

		public uint Level
		{
			get { return m_level; }
			set { m_level = value; Dirty = true;}
		}

		public override bool AutoSave
		{
			get { return true;}
			set {}
		}

		[Relation(LocalField="TeachSpellId", RemoteField="Spell_ID", AutoLoad=true, AutoDelete=false)]
		public DBSpell TeachSpell = null;

		[Relation(LocalField="SpellId", RemoteField="Spell_ID", AutoLoad=true, AutoDelete=false)]
		public DBSpell Spell = null;
	
	}
}
