using System;
using WoWDaemon.Database;
using WoWDaemon.Common.Attributes;

namespace WoWDaemon.Database.DataTables
{
	[DataTable(TableName="KnownSpell")]
	public class DBKnownSpell : DBObject
	{
		public DBKnownSpell()
		{
		}

		[DataElement(Name="CharacterID")]
		private uint m_charID;

		[DataElement(Name="Spell_Id")]
		private uint m_spellID;

		[DataElement(Name="SpellLevel")]
		private uint m_spelllevel;

		[DataElement(Name="Slot")]
		private uint m_slot;

		
		public uint CharacterID
		{
			get {return m_charID;}
			set {Dirty = true; m_charID = value;}
		}

		public uint Spell_Id
		{
			get {return m_spellID;}
			set {Dirty = true; m_spellID = value;}
		}

		public uint SpellLevel
		{
			get {return m_spelllevel;}
			set {Dirty = true; m_spelllevel = value;}
		}
		
		public uint Slot
		{
			get {return m_slot;}
			set {Dirty = true; m_slot = value;}
		}

		static bool m_autosave = true;
		public override bool AutoSave
		{
			get {return m_autosave;}
			set {m_autosave = value;}
		}

		[Relation(LocalField="Spell_Id", RemoteField="Spell_ID", AutoLoad=true, AutoDelete=false)]
		public DBSpell Spell=null;
	}
}
