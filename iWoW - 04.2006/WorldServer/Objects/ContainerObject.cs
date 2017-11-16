using System;
using WoWDaemon.Common;
using WoWDaemon.Database.DataTables;
using WoWDaemon.Common.Attributes;
namespace WoWDaemon.World
{
	/// <summary>
	/// Summary description for ContainerObject.
	/// </summary>
	[UpdateObjectAttribute(MaxFields=(int)CONTAINERFIELDS.MAX)]
	public class ContainerObject : ItemObject
	{
		public ContainerObject(DBItem item, ObjectInventory inventory) : base(item, inventory)
		{
			m_numSlots = item.Template.ContainerSlots;
			Inventory = new ContainerInventory(this);
		}

		public override void PreCreateObject(bool isClient)
		{
			base.PreCreateObject (isClient);
			UpdateValue(CONTAINERFIELDS.NUM_SLOTS);
			Inventory.PreCreateOwner(isClient);
		}



		public override HIER_OBJECTTYPE HierType
		{
			get
			{
				return HIER_OBJECTTYPE.CONTAINER;
			}
		}

		public override OBJECTTYPE ObjectType
		{
			get
			{
				return OBJECTTYPE.CONTAINER;
			}
		}

		[UpdateValueAttribute(CONTAINERFIELDS.NUM_SLOTS)]
		int m_numSlots;
		public int NumSlots
		{
			get { return m_numSlots;}
		}
		
		[UpdateValueAttribute]
		public readonly ContainerInventory Inventory;
	}
}
