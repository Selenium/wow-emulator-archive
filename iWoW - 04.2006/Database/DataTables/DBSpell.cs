using System;
using WoWDaemon.Database;
using WoWDaemon.Common.Attributes;

namespace WoWDaemon.Database.DataTables
{
	[DataTable(TableName="Spell")]
	public class DBSpell : DBObject
	{
		public DBSpell()
		{
		}

		[DataElement(Name="Name")]
		private string m_name = null;
		[DataElement(Name="CastTime")]
		private uint m_casttime;
		[DataElement(Name="CoolDown")]
		private uint m_cooldown;
		[DataElement(Name="PlayerLevel")]
		private uint m_playerlevel;
		[DataElement(Name="MaxLevel")]
		private uint m_maxlevel;
		[DataElement(Name="Duration")]
		private uint m_duration;
		[DataElement(Name="PowerType")]
		private uint m_powertype;
		[DataElement(Name="ManaCost")]
		private uint m_manacost;
		[DataElement(Name="ManaCostPerLevel")]
		private uint m_manacostperlevel;
		[DataElement(Name="Range")]
		private uint m_range;
		[DataElement(Name="RandomPercentageDamage")]
		private uint m_randompercentagedamage;
		[DataElement(Name="Speed")]
		private uint m_speed;
		[DataElement(Name="Damage")]
		private uint m_damage;
		[DataElement(Name="Radius")]
		private uint m_radius;
		[DataElement(Name="Rank")]
		private string m_rank;
		[DataElement(Name="Description")]
		private string m_description = null;
		[DataElement(Name="SpellID")]
		private uint m_spellid;
		
		public string Name
		{
			get {return m_name;}
			set {Dirty = true; m_name = value;}
		}

		public string Description
		{
			get {return m_description;}
			set {Dirty = true; m_description = value;}
		}

		public uint CastTime
		{
			get {return m_casttime;}
			set {Dirty = true; m_casttime = value;}
		}

		public uint CoolDown
		{
			get {return m_cooldown;}
			set {Dirty = true; m_cooldown = value;}
		}
		public uint PlayerLevel
		{
			get {return m_playerlevel;}
			set {Dirty = true; m_playerlevel = value;}
		}
		public uint MaxLevel
		{
			get {return m_maxlevel;}
			set {Dirty = true; m_maxlevel = value;}
		}
		public uint Duration
		{
			get {return m_duration;}
			set {Dirty = true; m_duration = value;}
		}
		public uint PowerType
		{
			get {return m_powertype;}
			set {Dirty = true; m_powertype = value;}
		}

		public uint ManaCost
		{
			get {return m_manacost;}
			set {Dirty = true; m_manacost = value;}
		}
		public uint ManaCostPerLevel
		{
			get {return m_manacostperlevel;}
			set {Dirty = true; m_manacostperlevel = value;}
		}

		public uint Range
		{
			get {return m_range;}
			set {Dirty = true; m_range = value;}
		}
		public uint RandomPercentageDamage
		{
			get {return m_randompercentagedamage;}
			set {Dirty = true; m_randompercentagedamage = value;}
		}

		public uint Speed
		{
			get {return m_speed;}
			set {Dirty = true; m_speed = value;}
		}
		public uint Damage
		{
			get {return m_damage;}
			set {Dirty = true; m_damage = value;}
		}
		public uint Radius
		{
			get {return m_radius;}
			set {Dirty = true; m_radius = value;}
		}

		public string Rank
		{
			get {return m_rank;}
			set {Dirty = true; m_rank = value;}
		}
		public uint SpellID
		{
			get {return m_spellid;}
			set {Dirty = true; m_spellid = value;}
		}
		static bool m_autosave = true;
		public override bool AutoSave
		{
			get {return m_autosave;}
			set {m_autosave = value;}
		}	
	
	}
}