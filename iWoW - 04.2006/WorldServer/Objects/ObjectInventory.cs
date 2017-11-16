using System;
using WoWDaemon.Common;
using WoWDaemon.Database.DataTables;
using WoWDaemon.Common.Attributes;
namespace WoWDaemon.World
{
	public abstract class ObjectInventory
	{
		protected WorldObject m_owner;
        [UpdateValueAttribute(PLAYERFIELDS.FIELD_INV_SLOT_HEAD, ArraySize = 69, OnlyForType = typeof(PlayerObject))]
		[UpdateValueAttribute(CONTAINERFIELDS.SLOTS, ArraySize=20, OnlyForType=typeof(ContainerObject))]
		protected ulong[] m_slots;
		protected ItemObject[] m_invObjects;
		int m_baseField;
		int m_itemCount;
		public ObjectInventory(WorldObject owner, int baseField)
		{
			m_owner = owner;
			m_baseField = baseField;
			m_itemCount = 0;
		}

		public ItemObject CreateItem(DBItem dbItem)
		{
			ItemObject item;
			if(dbItem.Template == null)
			{
				Console.WriteLine("DBItem " + dbItem.ObjectId + " is missing Item template on worldserver.");
				return null;
			}
			if(dbItem.Template.InvType == INVTYPE.BAG)
				item = new ContainerObject(dbItem, this);
			else
				item = new ItemObject(dbItem, this);
			m_slots[dbItem.OwnerSlot] = item.GUID;
			m_invObjects[dbItem.OwnerSlot] = item;
			m_owner.UpdateValue(m_baseField+dbItem.OwnerSlot*2);

			if(dbItem.OwnerSlot < 19)
			{
				m_owner.UpdateValue(((int)PLAYERFIELDS.VISIBLE_ITEM_1_0) + dbItem.OwnerSlot*9);
				m_owner.VisibleItems[dbItem.OwnerSlot] = m_invObjects[dbItem.OwnerSlot].Entry;
			}

			m_itemCount++;
			return item;
		}

		public virtual void PreCreateOwner(bool isClient)
		{
			for(int i = 0;i < m_slots.Length;i++)
				if(m_slots[i] != 0)
				{
					m_owner.UpdateValue(m_baseField+i*2);
					if(i < 19)
					{
						m_owner.UpdateValue(((int)PLAYERFIELDS.VISIBLE_ITEM_1_0) + i*9);
					}
				}
		}

		public ItemObject GetItem(int slot)
		{
			if(slot > m_invObjects.Length)
				return null;
			return m_invObjects[slot];
		}

		public ItemObject this[int slot]
		{
			get { return GetItem(slot);}
		}

		public int ItemCount
		{
			get { return m_itemCount;}
		}

		public int NumSlots
		{
			get { return m_slots.Length;}
		}

		public abstract PlayerObject Owner
		{
			get;
		}

		public virtual WorldObject InventoryOwner
		{
			get { return m_owner;}
		}
	}

	public class PlayerInventory : ObjectInventory
	{
		public PlayerInventory(WorldObject owner):base(owner,(int)PLAYERFIELDS.FIELD_INV_SLOT_HEAD)
		{
			m_slots = new ulong[69];
			m_invObjects = new ItemObject[69];
		}

		public override PlayerObject Owner
		{
			get
			{
				return (PlayerObject)m_owner;
			}
		}
		public ItemObject GetItem(INVSLOT slot)
		{
			return GetItem((int)slot);
		}

		public ItemObject this[INVSLOT slot]
		{
			get { return GetItem((int)slot);}
		}
		
		public byte GetOpenBackpackSlot()
		{
            for (int i = (int)INVSLOT.INBACKPACK; i < (int)INVSLOT.INBACKPACK+16; i++)//NUM_INVENTORY_SLOTS
				if(m_slots[i] == 0)
					return (byte)i;
			return 0;
		}


		public void ItemMove(int fromSlot, int toSlot)
		{
			ulong tmpGUID=0;
			ItemObject tmpObj=null;
			if (!(m_slots[toSlot]==0))
			{
				tmpGUID=m_slots[toSlot];
				tmpObj=m_invObjects[toSlot];
			}
			m_slots[toSlot]=m_slots[fromSlot];
			m_invObjects[toSlot]=m_invObjects[fromSlot];
			m_slots[fromSlot]=tmpGUID;
			m_invObjects[fromSlot]=tmpObj;
            m_owner.UpdateValue(((int)PLAYERFIELDS.FIELD_INV_SLOT_HEAD) + fromSlot * 2);
            m_owner.UpdateValue(((int)PLAYERFIELDS.FIELD_INV_SLOT_HEAD) + toSlot * 2);
			
			if(fromSlot < 19)
			{
				m_owner.VisibleItems[fromSlot]= 0;
				m_owner.UpdateValue(((int)PLAYERFIELDS.VISIBLE_ITEM_1_0) + fromSlot*9);
			}
			if(toSlot < 19)
			{
				m_owner.VisibleItems[toSlot]= m_invObjects[toSlot].Entry;
				m_owner.UpdateValue(((int)PLAYERFIELDS.VISIBLE_ITEM_1_0) + toSlot*9);
			}
			return;
		}

		public void RemoveItem(int slot)
		{
			m_slots[slot] = 0;
            m_owner.UpdateValue(((int)PLAYERFIELDS.FIELD_INV_SLOT_HEAD) + slot * 2);
			if(slot < 19)
			{
				m_owner.VisibleItems[slot] = 0;
				m_owner.UpdateValue(((int)PLAYERFIELDS.VISIBLE_ITEM_1_0)+ slot*9);
			}
		}
		public override void PreCreateOwner(bool isClient)
		{
            for (int i = 0; i <= (int)INVSLOT.EQUIPPEDFIRST; i++)
				if(m_slots[i] != 0)
				{
                    Owner.UpdateValue(((int)PLAYERFIELDS.FIELD_INV_SLOT_HEAD) + i * 2);
					if(i < 19)
					{
						Owner.UpdateValue(((int)PLAYERFIELDS.VISIBLE_ITEM_1_0)+i*9);
					}
				}
			if(isClient)
			{
                for (int i = (int)INVSLOT.EQUIPPEDFIRST; i < (int)INVSLOT.INVENTORY_SLOTS; i++)//NUM_INVENTORY_SLOTS
				{
					if(m_slots[i] != 0)
					{
                        Owner.UpdateValue(((int)PLAYERFIELDS.FIELD_INV_SLOT_HEAD) + i * 2);
						if(i < 19)
						{
							Owner.UpdateValue(((int)PLAYERFIELDS.VISIBLE_ITEM_1_0)+i*9);
						}
					}
				}

			}
		}

		public int AddCreateInventory(BinWriter w, bool isClient)
		{
			int numItems = 0;
			for(int i = 0;i <= (int)INVSLOT.EQUIPPEDFIRST;i++)
			{
				if(m_slots[i] != 0)
				{
					m_invObjects[i].AddCreateObject(w, false, true);
					numItems++;
				}
			}
			if(isClient)
			{
                for (int i = (int)INVSLOT.EQUIPPEDFIRST; i < (int)INVSLOT.NUM_INVENTORY_SLOTS; i++)//NUM_INVENTORY_SLOTS
				{
					if(m_slots[i] == 0)
						continue;
					numItems++;
					m_invObjects[i].AddCreateObject(w, false, true);
					if(m_invObjects[i].ObjectType == OBJECTTYPE.CONTAINER)
					{
						ContainerObject container = m_invObjects[i] as ContainerObject;
						for(int j = 0;j < container.Template.ContainerSlots;j++)
						{
							ItemObject item = container.Inventory[j];
							if(item != null)
							{
								numItems++;
								item.AddCreateObject(w, false, true);
							}
						}
					}
				}
			}
			return numItems;
		}

		public void SendDestroyInventory(uint toCharacterID)
		{
            for (int i = 0; i <= (int)INVSLOT.EQUIPPEDFIRST; i++)
			{
				if(m_slots[i] != 0)
				{
					ServerPacket pkg = new ServerPacket(SMSG.DESTROY_OBJECT);
					pkg.Write(m_slots[i]);
					pkg.Finish();
					pkg.AddDestination(toCharacterID);
					WorldServer.Send(pkg);
				}
			}
		}
	}

	public class ContainerInventory : ObjectInventory
	{
		public ContainerInventory(WorldObject owner) : base(owner, (int)CONTAINERFIELDS.SLOTS)
		{
			m_slots = new ulong[20];
			m_invObjects = new ItemObject[20];
		}

		public override PlayerObject Owner
		{
			get { return ((ContainerObject)m_owner).ContainedIn.Owner;}
		}
	}
}
