using System;
using WoWDaemon.Database;
using WoWDaemon.Common.Attributes;
using WoWDaemon.Common;

namespace WoWDaemon.Database.DataTables
{
	public struct ItemEnchantment
	{
		[UpdateValueAttribute(Field=0)]
		[DataElement]
		public int id;
		[UpdateValueAttribute(Field=1)]
		[DataElement]
		public int expiration;
		[UpdateValueAttribute(Field=2)]
		[DataElement]
		public int chargesRemaining;
	};

	/// <summary>
	/// Summary description for Item.
	/// </summary>
	[DataTable(TableName="Item")]
	public class DBItem : DBObject
	{
		[DataElement(Name="OwnerID")]
		private uint m_ownerID;
		[DataElement(Name="OwnerSlot")]
		private byte m_ownerSlot;
		[DataElement(Name="TemplateID", AllowDbNull=false)]
		private uint m_templateID;

		//[UpdateValueAttribute(ITEMFIELDS.CREATOR)]
		[DataElement(Name="Creator")]
		private uint m_creator;
		
		[UpdateValueAttribute(ITEMFIELDS.STACK_COUNT)]
		[DataElement(Name="StackCount")]
		private int m_stackcount = 1;
		
		[UpdateValueAttribute(ITEMFIELDS.DURATION)]
		[DataElement(Name="Expiration")]
		private int m_expiration;
		
		[UpdateValueAttribute(ITEMFIELDS.SPELL_CHARGES, ArraySize=5)]
		[DataElement(Name="SpellCharge", ArraySize=5)]
		private int[] m_spellCharges = new int[5];
		
		[UpdateValueAttribute(ITEMFIELDS.FLAGS, ShortsIndex=0)]
		[DataElement(Name="StaticFlags")]
		private ushort m_staticFlags;
		
		[UpdateValueAttribute(ITEMFIELDS.FLAGS, ShortsIndex=1)]
		[DataElement(Name="DynamicFlags")]
		private ushort m_dynamicFlags;
		
		[UpdateValueAttribute(ITEMFIELDS.ENCHANTMENTS, ArraySize=7, NumSubFields=3)]
		[DataElement(Name="Enchantment", ArraySize=7)]
		private ItemEnchantment[] Enchantments = new ItemEnchantment[7];

		[UpdateValueAttribute(ITEMFIELDS.PROPERTY_SEED)]
		[DataElement(Name="PropertySeed")]
		private int m_randomPropertySeed;
		
		[UpdateValueAttribute(ITEMFIELDS.RANDOM_PROPERTIES_ID)]
		[DataElement(Name="PropertyID")]
		private int m_randomPropertyID;


		public DBItem()
		{

		}

		public DBItem(DBItemTemplate template) : base()
		{
			m_templateID = template.ObjectId;
			Template = template;

			for(int i = 0;i < 5;i++)
			{
				SpellStat stat = template.getSpellStat(i);
				if(stat.ID != 0)
				{
					Enchantments[i].id = stat.ID;
					Enchantments[i].expiration = 0;
					Enchantments[i].chargesRemaining = stat.Charges;
					m_spellCharges[i] = stat.Charges;
				}
			}
			Dirty = true;
		}

		static bool m_autosave = true;
		public override bool AutoSave
		{
			get {return m_autosave;}
			set {m_autosave = value;}
		}

		public uint OwnerID
		{
			get {return m_ownerID;}
			set {Dirty = true; m_ownerID = value;}
		}

		public byte OwnerSlot
		{
			get {return m_ownerSlot;}
			set {Dirty = true; m_ownerSlot = value;}
		}

		public uint TemplateID
		{
			get {return m_templateID;}
			set {Dirty = true; m_templateID = value;}
		}

		public uint Creator
		{
			get { return m_creator;}
			set {Dirty = true; m_creator = value;}
		}

		public int StackCount
		{
			get { return m_stackcount;}
			set {Dirty = true; m_stackcount = value;}
		}

		public int Expiration
		{
			get { return m_expiration;}
			set { Dirty = true; m_expiration = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ndx">0-4</param>
		/// <returns></returns>
		public int getSpellCharge(int ndx)
		{
			return m_spellCharges[ndx];
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ndx">0-4</param>
		/// <param name="value"></param>
		public void setSpellCharge(int ndx, int value)
		{
			m_spellCharges[ndx] = value;
			Dirty = true;
		}

		public ushort StaticFlags
		{
			get { return m_staticFlags;}
			set { Dirty = true;m_staticFlags = value;}
		}

		public ushort DynamicFlags
		{
			get { return m_dynamicFlags;}
			set { Dirty = true;m_dynamicFlags = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ndx">0-6</param>
		/// <returns></returns>
		public ItemEnchantment getItemEnchantment(int ndx)
		{
			return Enchantments[ndx];
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ndx">0-6</param>
		/// <param name="enchantment"></param>
		public void setItemEnchantment(int ndx, ItemEnchantment enchantment)
		{
			Enchantments[ndx] = enchantment;
			Dirty = true;
		}

		public int PropertySeed
		{
			get { return m_randomPropertySeed;}
			set { Dirty = true;m_randomPropertySeed = value;}
		}

		public int PropertyID
		{
			get { return m_randomPropertyID;}
			set { Dirty = true;m_randomPropertyID = value;}
		}

		[Relation(LocalField="TemplateID", RemoteField="ItemTemplate_ID", AutoLoad=true, AutoDelete=false)]
		public DBItemTemplate Template = null;
	}
}
