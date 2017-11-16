using System;
using WoWDaemon.Common;
using WoWDaemon.Common.Attributes;
using WoWDaemon.World;
using WoWDaemon.Database.DataTables;

namespace WorldScripts.InventoryMove
{
	[WorldPacketHandler]
	public class Inventory
	{
		[WorldPacketDelegate(CMSG.SWAP_INV_ITEM)]
		static void ItemChange(WorldClient client, CMSG msgID, BinReader data)
		{
			INVSLOT sel = (INVSLOT)data.ReadByte();
			byte target = data.ReadByte();

			ItemObject aObj=client.Player.Inventory.GetItem(sel);
			ItemObject bObj=client.Player.Inventory.GetItem(target);
			aObj.DBItem.OwnerSlot=(byte)target;
			DBManager.SaveDBObject(aObj.DBItem);
			if (bObj!=null)
			{
				bObj.DBItem.OwnerSlot=(byte)sel;
				DBManager.SaveDBObject(bObj.DBItem);
			}

			client.Player.Inventory.ItemMove((int)sel, (int)target);

			// Check new stats of items
			StatManager.CalculateNewStats(client.Player);

			client.Player.UpdateData();

//			Chat.System(client, "Item Move : " + sel + " To slot " + target);

			return;
		}

		[WorldPacketDelegate(CMSG.DESTROYITEM)]
		static void ItemDestroy(WorldClient client, CMSG msgID, BinReader data)
		{
			byte bag = data.ReadByte();
			INVSLOT sel = (INVSLOT)data.ReadByte();
			
			ItemObject aObj=client.Player.Inventory.GetItem(sel);
			DBManager.DeleteDBObject(aObj.DBItem);
			client.Player.Inventory.RemoveItem((int)sel);
			// Check new stats of items
			StatManager.CalculateNewStats(client.Player);
			client.Player.UpdateData();
			return;
		}
		[WorldPacketDelegate(CMSG.AUTOEQUIP_ITEM)]
		static void ItemAutoEquip(WorldClient client, CMSG msgID, BinReader data)
		{
			byte bag = data.ReadByte();
			INVSLOT sel = (INVSLOT)data.ReadByte();
			
			ItemObject aObj=client.Player.Inventory.GetItem(sel);
			//need to work on sawp items here...
			ItemObject bObj=client.Player.Inventory.GetItem((byte)aObj.Template.InvType);

			int target = 0;

			#region Right INVTYPE for each weapon
			
			switch((INVTYPE)aObj.Template.InvType)
			{
				case INVTYPE.AMMO:
					
					target = 23;
					aObj.DBItem.OwnerSlot = ((byte)target);
					break;

				case INVTYPE.BAG:
					
					target = 23;
					aObj.DBItem.OwnerSlot = ((byte)target);
					break;

				case INVTYPE.BODY:
					
					target = 3;
					aObj.DBItem.OwnerSlot = ((byte)target);
					break;

				case INVTYPE.CHEST:
					
					target = 4;
					aObj.DBItem.OwnerSlot = ((byte)target);
					break;

				case INVTYPE.CLOAK:
					
					target = 14;
					aObj.DBItem.OwnerSlot = ((byte)target);
					break;

				case INVTYPE.FEET:
					
					target = 7;
					aObj.DBItem.OwnerSlot = ((byte)target);
					break;

				case INVTYPE.FINGER:
					
					target = 10;
					aObj.DBItem.OwnerSlot = ((byte)target);
					break;

				case INVTYPE.HAND:
					
					target = 9;
					aObj.DBItem.OwnerSlot = ((byte)target);
					break;

				case INVTYPE.HEAD:
					
					target = 0;
					aObj.DBItem.OwnerSlot = ((byte)target);
					break;

				case INVTYPE.HOLDABLE:
					
					target = 23;
					aObj.DBItem.OwnerSlot = ((byte)target);
					break;

				case INVTYPE.LEGS:
					
					target = 6;
					aObj.DBItem.OwnerSlot = ((byte)target);
					break;

				case INVTYPE.NECK:
					
					target = 1;
					aObj.DBItem.OwnerSlot = ((byte)target);
					break;

				case INVTYPE.RANGED:
					
					target = 17;
					aObj.DBItem.OwnerSlot = ((byte)target);
					break;

				case INVTYPE.ROBE:
					
					target = 4;
					aObj.DBItem.OwnerSlot = ((byte)target);
					break;

				case INVTYPE.SHIELD:
					
					target = 16;
					aObj.DBItem.OwnerSlot = ((byte)target);
					break;

				case INVTYPE.SHOULDER:
					
					target = 2;
					aObj.DBItem.OwnerSlot = ((byte)target);
					break;

				case INVTYPE.TABARD:
					
					target = 18;
					aObj.DBItem.OwnerSlot = ((byte)target);
					break;

				case INVTYPE.THROWN:
					
					target = 17;
					aObj.DBItem.OwnerSlot = ((byte)target);
					break;

				case INVTYPE.TRINKET:
					
					target = 23;
					aObj.DBItem.OwnerSlot = ((byte)target);
					break;

				case INVTYPE.TWOHANDEDWEAPON:
					
					target = 15;
					aObj.DBItem.OwnerSlot = ((byte)target);
					break;
				
				case INVTYPE.WEAPON:
					
					target = 15;
					aObj.DBItem.OwnerSlot = ((byte)target);
					break;

				case INVTYPE.WEAPONMAINHAND:
					
					target = 15;
					aObj.DBItem.OwnerSlot = ((byte)target);
					break;

				case INVTYPE.WEAPONOFFHAND:
					
					target = 16;
					aObj.DBItem.OwnerSlot = ((byte)target);
					break;

				case INVTYPE.WAIST:
					
					target = 5;
					aObj.DBItem.OwnerSlot = ((byte)target);
					break;
				
				case INVTYPE.WRIST:
					
					target = 8;
					aObj.DBItem.OwnerSlot = ((byte)target);
					break;
			}

			#endregion
			
			DBManager.SaveDBObject(aObj.DBItem);
			client.Player.Inventory.ItemMove((int)sel, (int)target);
			
			//...and here.
			if (bObj!=null)
			{
				bObj.DBItem.OwnerSlot=(byte)sel;
				DBManager.SaveDBObject(bObj.DBItem);
			}

			StatManager.CalculateNewStats(client.Player);
			client.Player.UpdateData();

			return;

		}
	} 
}
