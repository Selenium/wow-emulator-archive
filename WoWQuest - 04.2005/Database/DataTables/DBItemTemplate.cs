using System;

using WoWDaemon.Database;
using WoWDaemon.Common.Attributes;
using WoWDaemon.Common;

namespace WoWDaemon.Database.DataTables
{
	public struct ItemBonus
	{
		[DataElement]
		public int Stat;
		[DataElement]
		public int Bonus;
	}

	public struct DamageStat
	{
		[DataElement]
		public int Min;
		[DataElement]
		public int Max;
		[DataElement]
		public int Type;
	}

	public struct SpellStat
	{
		[DataElement]
		public int ID;
		[DataElement]
		public int Trigger;
		[DataElement]
		public int Charges;
		[DataElement]
		public int Cooldown;
		[DataElement]
		public int Category;
		[DataElement]
		public int CategoryCooldown;
	}

	public struct Resistance
	{
		[DataElement(Name="Physical")]
		public int Physical;
		[DataElement]
		public int Holy;
		[DataElement]
		public int Fire;
		[DataElement]
		public int Nature;
		[DataElement]
		public int Frost;
		[DataElement]
		public int Shadow;
	}

	/// <summary>
	/// Summary description for ItemTemplate.
	/// </summary>
	[DataTable(TableName="ItemTemplate")]
	public class DBItemTemplate : DBObject
	{
		static bool m_autosave = true;
		[DataElement(Name="Class")]
		private ITEMCLASS m_class;
		[DataElement(Name="SubClass")]
		private int m_subClass;
		[DataElement(Name="Name")]
		private string m_name = "ITEM NAME UNSET!";
		[DataElement(Name="Name1")]
		private string m_name1 = "ITEM NAME1 UNSET!";
		[DataElement(Name="Name2")]
		private string m_name2 = "ITEM NAME2 UNSET!";
		[DataElement(Name="Name3")]
		private string m_name3 = "ITEM NAME3 UNSET!";
		[DataElement(Name="DisplayID")]
		private int m_displayID;
		[DataElement(Name="OverallQuality")]
		private int m_overallQuality;
		[DataElement(Name="Flags")]
		private int m_flags;
		[DataElement(Name="BuyPrice")]
		private int m_buyPrice;
		[DataElement(Name="SellPrice")]
		private int m_sellPrice;
		[DataElement(Name="InvType")]
		private INVTYPE m_invType;
		[DataElement(Name="AllowableClass")]
		private int m_allowableClass;
		[DataElement(Name="AllowableRace")]
		private int m_allowableRace;
		[DataElement(Name="ItemLevel")]
		private int m_itemlevel;
		[DataElement(Name="ReqLevel")]
		private int m_reqLevel;
		[DataElement(Name="ReqSkill")]
		private int m_reqSkill;
		[DataElement(Name="MinReqSkill")]
		private int m_minReqSkill;
		[DataElement(Name="ItemUnique")]
		private int m_itemUnique;
		[DataElement(Name="MaxStack")]
		private int m_maxStack;
		[DataElement(Name="ContainerSlots")]
		private int m_containerSlots;
		[DataElement(Name="ItemBonus", ArraySize=10)]
		private ItemBonus[] m_itemBonus = new ItemBonus[10];
		[DataElement(Name="DamageStat", ArraySize=5)]
		private DamageStat[] m_damageStats = new DamageStat[5];
		[DataElement(Name="Resistance")]
		private Resistance m_resists;
		[DataElement(Name="WeaponSpeed")]
		private int m_weaponSpeed;
		[DataElement(Name="AmmoType")]
		private int m_ammoType;
		[DataElement(Name="MaxDurability")]
		private int m_maxDurability;
		[DataElement(Name="SpellStat", ArraySize=5)]
		private SpellStat[] m_spellStats = new SpellStat[5];
		[DataElement(Name="Bonding")]
		private int m_bonding;
		[DataElement(Name="Description")]
		private string m_description = string.Empty;
		[DataElement(Name="PageText")]
		private int m_pageText;
		[DataElement(Name="LanguageID")]
		private int m_languageID;
		[DataElement(Name="PageMaterial")]
		private int m_pageMaterial;
		[DataElement(Name="StartQuest")]
		private int m_startQuest;
		[DataElement(Name="Lock")]
		private int m_lock;
		[DataElement(Name="Material")]
		private int m_material;
		[DataElement(Name="SheatheType")]
		private int m_sheatheType;
		[DataElement(Name="Unknown1")]
		private int m_unk1;
		[DataElement(Name="Unknown2")]
		private int m_unk2;

		public override bool AutoSave
		{
			get {return m_autosave;}
			set {m_autosave = value;}
		}
		public ITEMCLASS Class
		{
			get {return m_class;}
			set {Dirty = true; m_class = value;}
		}

		#region SubClass
		public int SubClass
		{
			get {return m_subClass;}
			set {Dirty = true; m_subClass = value;}
		}

		public WEAPONSUBCLASS WeaponSubClass
		{
			get {return (WEAPONSUBCLASS)m_subClass;}
			set {Dirty = true; m_subClass = (int)value;}
		}

		public ARMOURSUBCLASS ArmourSubClass
		{
			get {return (ARMOURSUBCLASS)m_subClass;}
			set {Dirty = true; m_subClass = (int)value;}
		}

		public QUIVERSUBCLASS QuiverSubClass
		{
			get {return (QUIVERSUBCLASS)m_subClass;}
			set {Dirty = true; m_subClass = (int)value;}
		}

		public PROJECTILESUBCLASS ProjectileSubClass
		{
			get {return (PROJECTILESUBCLASS)m_subClass;}
			set {Dirty = true; m_subClass = (int)value;}
		}
		#endregion


		public string Name
		{
			get {return m_name;}
			set {Dirty = true; m_name = value;}
		}

		public string Name1
		{
			get {return m_name1;}
			set {Dirty = true; m_name1 = value;}
		}

		public string Name2
		{
			get {return m_name2;}
			set {Dirty = true; m_name2 = value;}
		}

		public string Name3
		{
			get {return m_name3;}
			set {Dirty = true; m_name3 = value;}
		}

		public int DisplayID
		{
			get {return m_displayID;}
			set {Dirty = true; m_displayID = value;}
		}

		public int OverallQuality
		{
			get {return m_overallQuality;}
			set {Dirty = true; m_overallQuality = value;}
		}

		public int Flags
		{
			get {return m_flags;}
			set {Dirty = true; m_flags = value;}
		}

		/// <summary>
		/// Player buys for
		/// </summary>
		public int BuyPrice
		{
			get {return m_buyPrice;}
			set {Dirty = true; m_buyPrice = value;}
		}

		/// <summary>
		/// Player sells for
		/// </summary>
		public int SellPrice
		{
			get {return m_sellPrice;}
			set {Dirty = true; m_sellPrice = value;}
		}

		public INVTYPE InvType
		{
			get {return m_invType;}
			set {Dirty = true; m_invType = value;}
		}

		public int AllowableClass
		{
			get {return m_allowableClass;}
			set {Dirty = true; m_allowableClass = value;}
		}

		public int AllowableRace
		{
			get {return m_allowableRace;}
			set {Dirty = true; m_allowableRace = value;}
		}

		public int Itemlevel
		{
			get {return m_itemlevel;}
			set {Dirty = true; m_itemlevel = value;}
		}

		public int ReqLevel
		{
			get {return m_reqLevel;}
			set {Dirty = true; m_reqLevel = value;}
		}

		public int ReqSkill
		{
			get {return m_reqSkill;}
			set {Dirty = true; m_reqSkill = value;}
		}

		public int MinReqSkill
		{
			get {return m_minReqSkill;}
			set {Dirty = true; m_minReqSkill = value;}
		}

		public int ItemUnique
		{
			get {return m_itemUnique;}
			set {Dirty = true; m_itemUnique = value;}
		}

		public int MaxStack
		{
			get {return m_maxStack;}
			set {Dirty = true; m_maxStack = value;}
		}

		public int ContainerSlots
		{
			get {return m_containerSlots;}
			set {Dirty = true; m_containerSlots = value;}
		}
		
		public ItemBonus getItemBonus(int ndx) { return m_itemBonus[ndx];}
		public void setItemBonus(int ndx, ItemBonus bonus) {Dirty = true; m_itemBonus[ndx] = bonus;}

		public DamageStat getDamageStat(int ndx) { return m_damageStats[ndx];}
		public void setDamageStat(int ndx, DamageStat stat) {Dirty = true;m_damageStats[ndx] = stat;}

		public Resistance Resists
		{
			get { return m_resists;}
			set { Dirty = true; m_resists = value;}
		}
		
		public int WeaponSpeed
		{
			get {return m_weaponSpeed;}
			set {Dirty = true; m_weaponSpeed = value;}
		}

		public int AmmoType
		{
			get {return m_ammoType;}
			set {Dirty = true; m_ammoType = value;}
		}

		public int MaxDurability
		{
			get {return m_maxDurability;}
			set {Dirty = true; m_maxDurability = value;}
		}

		public SpellStat getSpellStat(int ndx) { return m_spellStats[ndx];}
		public void setSpellStat(int ndx, SpellStat stat) {Dirty = true;m_spellStats[ndx] = stat;}

		public int Bonding
		{
			get {return m_bonding;}
			set {Dirty = true; m_bonding = value;}
		}

		public string Description
		{
			get {return m_description;}
			set {Dirty = true; m_description = value;}
		}

		public int PageText
		{
			get {return m_pageText;}
			set {Dirty = true; m_pageText = value;}
		}

		public int LanguageID
		{
			get {return m_languageID;}
			set {Dirty = true; m_languageID = value;}
		}

		public int PageMaterial
		{
			get {return m_pageMaterial;}
			set {Dirty = true; m_pageMaterial = value;}
		}

		public int StartQuest
		{
			get {return m_startQuest;}
			set {Dirty = true; m_startQuest = value;}
		}

		public int Lock
		{
			get {return m_lock;}
			set {Dirty = true; m_lock = value;}
		}

		public int Material
		{
			get {return m_material;}
			set {Dirty = true; m_material = value;}
		}

		public int SheathType
		{
			get {return m_sheatheType;}
			set {Dirty = true; m_sheatheType = value;}
		}

		public int Unknown1
		{
			get {return m_unk1;}
			set {Dirty = true; m_unk1 = value;}
		}

		public int Unknown2
		{
			get {return m_unk2;}
			set {Dirty = true; m_unk2 = value;}
		}

		public DBItemTemplate()
		{

		}
	}
}