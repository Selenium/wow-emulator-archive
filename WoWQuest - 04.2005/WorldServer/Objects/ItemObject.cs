using System;
using WoWDaemon.Common;
using WoWDaemon.Database.DataTables;
using WoWDaemon.Common.Attributes;
namespace WoWDaemon.World
{
	[UpdateObjectAttribute(MaxFields=(int)ITEMFIELDS.MAX)]
	public class ItemObject : WorldObject
	{
		ulong m_guid;
		[UpdateValueAttribute]
		protected DBItem m_itemData;
		ObjectInventory m_containedIn;
		DBItemTemplate m_template;
		public ItemObject(DBItem item, ObjectInventory inventory)
		{
			m_guid = ObjectManager.NextGUID();
			m_itemData = item;
			m_template = item.Template;
			if(m_itemData.ObjectId == 0)
				DBManager.CreateDBObject(m_itemData);
			m_containedIn = inventory;
			ObjectManager.AddWorldObject(this);
		}

		public DBItem DBItem
		{
			get { return m_itemData;}
		}

		public DBItemTemplate Template
		{
			get { return m_template;}
		}

		public ObjectInventory ContainedIn
		{
			get { return m_containedIn;}
		}

		public override void PreCreateObject(bool isClient)
		{
			base.PreCreateObject (isClient);
			UpdateValue(ITEMFIELDS.OWNER);
			UpdateValue(ITEMFIELDS.CONTAINED);
			UpdateValue(ITEMFIELDS.CREATOR);
			UpdateValue(ITEMFIELDS.STACK_COUNT);
		}


		#region OBJECTFIELDS
		public override ulong GUID
		{
			get
			{
				return m_guid;
			}
		}

		public override HIER_OBJECTTYPE HierType
		{
			get	{return HIER_OBJECTTYPE.ITEM;}
		}

		public override uint Entry
		{
			get
			{
				return m_itemData.TemplateID;
			}
			set
			{
			}
		}
		#endregion

		#region Object Properties
		public override OBJECTTYPE ObjectType
		{
			get { return OBJECTTYPE.ITEM;}
		}

		public override uint MovementFlags
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public override Vector Position
		{
			get
			{
				return new Vector(0, 0, 0);
			}
			set
			{
			}
		}

		public override float Facing
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}
		#endregion

		#region ITEMFIELDS
		[UpdateValueAttribute(ITEMFIELDS.OWNER)]
		ulong owner
		{
			get { return ContainedIn.Owner.GUID;}
		}

		[UpdateValueAttribute(ITEMFIELDS.CONTAINED)]
		ulong container
		{
			get { return ContainedIn.InventoryOwner.GUID;}
		}

		[UpdateValueAttribute(ITEMFIELDS.CREATOR)]
		ulong creator
		{
			get { return (ulong)m_itemData.Creator;}
		}

		public int StackCount
		{
			get { return m_itemData.StackCount;}
			set { UpdateValue(ITEMFIELDS.STACK_COUNT); m_itemData.StackCount = value;}
		}

		public int MaxStack
		{
			get { return m_template.MaxStack;}
		}

		#endregion


		public override void Save()
		{
			DBManager.SaveDBObject(m_itemData);
		}

		public override void SaveAndRemove()
		{
			if(this.MapTile != null)
			{
				MapTile.Map.Leave(this);
			}
			Save();
			DBManager.RemoveDBObject(m_itemData);
			ObjectManager.RemoveWorldObject(this);
		}


	}
}
