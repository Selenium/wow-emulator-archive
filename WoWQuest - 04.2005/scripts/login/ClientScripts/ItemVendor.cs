using System; 
using WoWDaemon.Common; 
using WoWDaemon.Common.Attributes; 
using WoWDaemon.Login;
using WoWDaemon.Database;
using WoWDaemon.Database.DataTables;

namespace LoginScripts.ItemVendorsScripts
{
	[LoginPacketHandler()]
	public class Vendors
	{
		[LoginPacketDelegate(CMSG.LIST_INVENTORY)]
		static bool VendorLisr(LoginClient client, CMSG msgID, BinReader data)
		{

			BinWriter pkg2 = LoginClient.NewPacket(SMSG.LIST_INVENTORY);
			
			ulong vendorGUID = data.ReadUInt64();
			
			DataObject[] obj = DataServer.Database.SelectObjects(typeof(DBVendor), "GUID = '"+vendorGUID+"'");
			if (obj.Length==0) 
			{
				Chat.System(client, "Vendor not found");
				return true;
			}

			DBVendor tvendor = (DBVendor)obj[0];
			pkg2.Write(tvendor.GUID);						// Vendor GUID (OK)
			if (tvendor.VendorItems==null)
			{
				pkg2.Write((int)0);
				client.Send(pkg2);
				return true;
			}
			int Lenght = tvendor.VendorItems.Length;
			int i = 1;

			pkg2.Write((byte)Lenght);						// item counter (OK)
			foreach (DBVendorItem item in tvendor.VendorItems)
			{
				pkg2.Write((int)i);							// item counter number (OK)
				pkg2.Write((int)item.TemplateID);			// item template (OK)
				pkg2.Write((int)item.Template.DisplayID);	// item icon display_id (OK)
				pkg2.Write((int)item.CurrentQty);			// Quantity (OK)
				pkg2.Write((int)item.Price);				// Price (OK)
				pkg2.Write(0);								// Dunno
				pkg2.Write((int)item.Template.ReqLevel);	// Item Level (OK)
				i++;
			}

			client.Send(pkg2);
			return true;
		}
		
		[LoginPacketDelegate(CMSG.BUY_ITEM_IN_SLOT)]
		[LoginPacketDelegate(CMSG.BUY_ITEM)]
		static bool BuyItemVendor(LoginClient client, CMSG msgID, BinReader data)
		{

			ulong vendorGUID2 = data.ReadUInt64();
			int itembuy = data.ReadInt32();
			byte targetslot=0; 
			if (msgID==CMSG.BUY_ITEM_IN_SLOT)
			{
				data.ReadUInt64();
				targetslot= data.ReadByte();
			}
			DataObject[] obj = DataServer.Database.SelectObjects(typeof(DBVendor), "GUID = '"+vendorGUID2+"'");
			if (obj.Length==0) 
			{
				Chat.System(client, "Vendor not found");
				return true;
			}

			DBVendor tvendor = (DBVendor)obj[0];
			foreach (DBVendorItem item in tvendor.VendorItems)
			{
				if (item.TemplateID==itembuy)
				{
					DBItem newItem = new DBItem();
					newItem.OwnerID = client.Character.ObjectId;
					newItem.OwnerSlot = targetslot; //temp, checks for open slot on world side
					newItem.TemplateID = item.TemplateID;
					newItem.Template=item.Template;
					DataServer.Database.AddNewObject(newItem);
					client.WorldConnection.Send(newItem);

					ScriptPacket Item = new ScriptPacket(SCRMSG.BUYITEM);

					Item.Write(client.Character.ObjectId);
					Item.Write(newItem.ObjectId);
					Item.Write(item.Price);
//					Item.Write(23); // NEED TO MAKE THE SCRIPT SEND TO NEXT-FREE-SLOT, INSTEAD OF FIRST
					client.WorldConnection.Send(Item);

//					Chat.System(client, "Buy Item Working, Vendor GUI = "+vendorGUID2+" and item = "+itembuy+" on LoginServer");
					return true;
				}
			}
			Chat.System(client, "Item not found on this vendor");
			return true;


		}
	
		[LoginPacketDelegate(CMSG.SELL_ITEM)]
		static bool Selling(LoginClient client, CMSG msgID, BinReader data)
		{
			ulong vendorGUID = data.ReadUInt64();
			ulong item = data.ReadUInt64();
			
			Chat.System(client, "Selling item "+item+" to vendor "+vendorGUID);

			return true;
		}
	}
}


