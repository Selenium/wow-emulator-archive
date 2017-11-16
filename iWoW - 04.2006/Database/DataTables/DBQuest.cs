using System;
using WoWDaemon.Database;
using WoWDaemon.Common.Attributes;

namespace WoWDaemon.Database.DataTables
{
	[DataTable(TableName="Quest")]
	public class DBQuest : DBObject
	{
		public DBQuest()
		{
		}

		// Description
		[DataElement(Name="Title")]
		private string m_title = null;
		[DataElement(Name="Description")]
		private string m_description = null;
		[DataElement(Name="Objectives")]
		private string m_objectives = null;
		[DataElement(Name="CompletedText")]
		private string m_completedtext = null;
		[DataElement(Name="IncompletedText")]
		private string m_incompletedtext = null;
		
		// Pre-Requirements
		[DataElement(Name="RequiredLevel")]
		private uint m_reqlevel;
		[DataElement(Name="RequiredQuest")]
		private uint m_reqquest;
		
		// Rewards
		[DataElement(Name="ChooseRewardID")]
		private uint m_chooserewardID;
		[DataElement(Name="ChooseDisplayID")]
		private uint m_choosedisplayID;
		[DataElement(Name="ChooseQuantity")]
		private uint m_chooserewardQuantity;
		[DataElement(Name="AlwaysRewardID")]
		private uint m_alwaysrewardID;
		[DataElement(Name="AlwaysDisplayID")]
		private uint m_alwaysdisplayID;
		[DataElement(Name="AlwaysRewardQuantity")]
		private uint m_alwaysrewardQuantity;
		[DataElement(Name="MoneyReward")]
		private uint m_moneyreward;
		[DataElement(Name="XPReward")]
		private uint m_xpreward;
		
		// Objectives
		
		[DataElement(Name="OriginalGUID")]	// GUID of the original questgiving creature // only needed when m_targetGuid is filled out
		private uint m_originalGUID;
		[DataElement(Name="TargetGUID")]	// GUID of a creature to speak with to complete the quest
		private uint m_targetGUID;
		[DataElement(Name="MonsterToKill")]
		private uint m_monsterToKill;
		[DataElement(Name="MonsterQuantity")]
		private uint m_monsterQuantity;
		[DataElement(Name="ItemToCollect")]
		private uint m_itemToCollect;
		[DataElement(Name="ItemQuantity")]
		private uint m_itemQuantity;
		
		
		public string Title
		{
			get {return m_title;}
			set {Dirty = true; m_title = value;}
		}

		public string Description
		{
			get {return m_description;}
			set {Dirty = true; m_description = value;}
		}

		public string Objectives
		{
			get {return m_objectives;}
			set {Dirty = true; m_title = value;}
		}
		
		public string CompletedText
		{
			get {return m_completedtext;}
			set {Dirty = true; m_completedtext = value;}
		}
		
		public string IncompletedText
		{
			get {return m_incompletedtext;}
			set {Dirty = true; m_incompletedtext = value;}
		}
		
		
		public uint RequiredLevel
		{
			get {return m_reqlevel;}
			set {Dirty = true; m_reqlevel = value;}
		}

		public uint RequiredQuest
		{
			get {return m_reqquest;}
			set {Dirty = true; m_reqquest = value;}
		}

		public uint ChooseRewardID
		{
			get {return m_chooserewardID;}
			set {Dirty = true; m_chooserewardID = value;}
		}

		public uint ChooseDisplayID
		{
			get {return m_choosedisplayID;}
			set {Dirty = true; m_choosedisplayID = value;}
		}

		public uint ChooseQuantity
		{
			get {return m_chooserewardQuantity;}
			set {Dirty = true; m_chooserewardQuantity = value;}
		}

		public uint AlwaysRewardID
		{
			get {return m_alwaysrewardID;}
			set {Dirty = true; m_alwaysrewardID = value;}
		}

		public uint AlwaysDisplayID
		{
			get {return m_alwaysdisplayID;}
			set {Dirty = true; m_alwaysdisplayID = value;}
		}

		public uint AlwaysRewardQuantity
		{
			get {return m_alwaysrewardQuantity;}
			set {Dirty = true; m_alwaysrewardQuantity = value;}
		}

		public uint MoneyReward
		{
			get {return m_moneyreward;}
			set {Dirty = true; m_moneyreward = value;}
		}

		public uint XPReward
		{
			get {return m_xpreward;}
			set {Dirty = true; m_xpreward = value;}
		}

		public uint OriginalGUID
		{
			get {return m_originalGUID;}
			set {Dirty = true; m_originalGUID = value;}
		}

		public uint TargetGUID
		{
			get {return m_targetGUID;}
			set {Dirty = true; m_targetGUID = value;}
		}

		public uint MonsterToKill
		{
			get {return m_monsterToKill;}
			set {Dirty = true; m_monsterToKill = value;}
		}

		public uint MonsterQuantity
		{
			get {return m_monsterQuantity;}
			set {Dirty = true; m_monsterQuantity = value;}
		}

		public uint ItemToCollect
		{
			get {return m_itemToCollect;}
			set {Dirty = true; m_itemToCollect = value;}
		}

		public uint ItemQuantity
		{
			get {return m_itemQuantity;}
			set {Dirty = true; m_itemQuantity = value;}
		}

		static bool m_autosave = true;
		public override bool AutoSave
		{
			get {return m_autosave;}
			set {m_autosave = value;}
		}

		[Relation(LocalField="ChooseRewardID", RemoteField="ItemTemplate_ID", AutoLoad=true, AutoDelete=false)]
		public DBItemTemplate ChooseTemplate = null;

		[Relation(LocalField="AlwaysRewardID", RemoteField="ItemTemplate_ID", AutoLoad=true, AutoDelete=false)]
		public DBItemTemplate AlwaysTemplate = null;

	}
}